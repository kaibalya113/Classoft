
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.BioMonitor;
using System.Threading;

namespace ClassManager.BioMonitor
{
    public partial class RTEventsMain : Form
    {

        Fees objfees;
        string enrollmentNo;
        string[] BioArray;
        DataTable dt = new DataTable();
        public RTEventsMain()
        {
            InitializeComponent();
        }

        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        public zkemkeeper.CZKEMClass axCZKEM2 = new zkemkeeper.CZKEMClass();


        /********************************************************************************************************************************************
        * Bee you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
        * This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
        * The communication way which you can use duing to the model of the device.                                                                 *
        * *******************************************************************************************************************************************/
        #region Communication
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.
        private bool bIsConnected2;

        //If your device supports the TCP/IP communications, you can refer to this.
        //when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                connectDevice();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                MessageBox.Show("Could not connect to device");
            }
        }

        private void connectDevice(bool silent = false)
        {
            Common.Log.LogError("Connecting Device Started", Common.ErrorLevel.INFORMATION);
            bool getLog = true;

            //if (BioMonitor.Properties.Settings.Default.MACHINE_IP == "" || BioMonitor.Properties.Settings.Default.MACHINE_PORT == "")
            if (txtIP.Text == "" || txtPort.Text == "")
            {
                lblState.Text = "IP and Port cannot be null";
                return;
            }

            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (btnConnect.Text == "DisConnect")
            {
                disconnectDevice();
                return;
            }

            bIsConnected = axCZKEM1.Connect_Net(txtIP.Text, Convert.ToInt32(txtPort.Text));

            if (bIsConnected == true)
            {
                btnConnect.Text = "DisConnect";
                btnConnect.Refresh();
                lblState.Text = "Current State:Connected";
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.

                if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    registerEvents();
                }

                lbRTShow.Items.Add("Connected..." + txtIP.Text);

                ClassManager.Common.Properties.Settings.Default.MACHINE_IP = txtIP.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_PORT = txtPort.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_NAME = txtMachine1Name.Text;

                BLL.SystemParameterHandler.updateSysParam(SysParam.Parameters.DEVICE_ID, txtIP.Text);
                BLL.SystemParameterHandler.updateSysParam(SysParam.Parameters.DEVICE_PORT_NO, txtPort.Text);

                ClassManager.Common.Properties.Settings.Default.Save();

                string Timer = Info.SysParam.getValue<String>(SysParam.Parameters.BIOMONITOR_MANUAL_TIMER).ToString();
                if (Timer == "True")
                {
                    this.rtTimer.Interval = 500;
                    this.rtTimer.Enabled = true;
                }
                else
                {
                    this.rtTimer.Enabled = false;
                }


            }
            else
            {

                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }

        private void registerEvents()
        {
            this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);

            this.axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            this.axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            this.axCZKEM1.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.axCZKEM1.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            this.axCZKEM1.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
            axCZKEM1.ReadRTLog(iMachineNumber);
            while ((axCZKEM1.GetRTLog(iMachineNumber)))
            {

                axCZKEM1.ReadRTLog(iMachineNumber);
            }
            this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
        }

        private void disconnectDevice()
        {
            axCZKEM1.Disconnect();

            deregisterEvents();

            bIsConnected = false;
            btnConnect.Text = "Connect";
            lblState.Text = "Current State:DisConnected";
            Cursor = Cursors.Default;
            return;
        }

        private void disconnectDevice2()
        {
            axCZKEM2.Disconnect();

            deregisterEvents2();

            bIsConnected2 = false;
            btnConnect2.Text = "Connect";
            lblState2.Text = "Current State:DisConnected";
            Cursor = Cursors.Default;
            return;
        }

        //If your device supports the SerialPort communications, you can refer to this.
        private void btnRsConnect_Click(object sender, EventArgs e)
        {
            if (cbPort.Text.Trim() == "" || cbBaudRate.Text.Trim() == "" || txtMachineSN.Text.Trim() == "")
            {
                MessageBox.Show("Port,BaudRate and MachineSN cannot be null", "Error");
                return;
            }
            int idwErrorCode = 0;
            //accept serialport number from string like "COMi"
            int iPort;
            string sPort = cbPort.Text.Trim();
            for (iPort = 1; iPort < 10; iPort++)
            {
                if (sPort.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            Cursor = Cursors.WaitCursor;
            if (btnRsConnect.Text == "Disconnect")
            {
                axCZKEM1.Disconnect();

                this.axCZKEM1.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                this.axCZKEM1.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                this.axCZKEM1.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                this.axCZKEM1.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
                this.axCZKEM1.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                this.axCZKEM1.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                this.axCZKEM1.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                this.axCZKEM1.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                this.axCZKEM1.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
                this.axCZKEM1.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                this.axCZKEM1.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);

                bIsConnected = false;
                btnRsConnect.Text = "Connect";
                btnRsConnect.Refresh();
                lblState.Text = "Current State:Disconnected";
                Cursor = Cursors.Default;
                return;
            }

            iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim());//when you are using the serial port communication,you can distinguish different devices by their serial port number.
            bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()));

            if (bIsConnected == true)
            {
                btnRsConnect.Text = "Disconnect";
                btnRsConnect.Refresh();
                lblState.Text = "Current State:Connected";

                if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                    this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                    this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                    this.axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                    this.axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
                    this.axCZKEM1.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                    this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                    this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                    this.axCZKEM1.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                    this.axCZKEM1.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
                    this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                    this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                }
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }

        //If your device supports the USBCLient, you can refer to this.
        //Not all series devices can support this kind of connection.Please make sure your device supports USBClient.
        //Connect the device via the virtual serial port created by USBClient
        private void btnUSBConnect_Click(object sender, EventArgs e)
        {
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;

            if (btnUSBConnect.Text == "Disconnect")
            {
                axCZKEM1.Disconnect();

                this.axCZKEM1.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                this.axCZKEM1.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                this.axCZKEM1.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                this.axCZKEM1.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
                this.axCZKEM1.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                this.axCZKEM1.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                this.axCZKEM1.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                this.axCZKEM1.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                this.axCZKEM1.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
                this.axCZKEM1.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                this.axCZKEM1.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);

                bIsConnected = false;
                btnUSBConnect.Text = "Connect";
                btnUSBConnect.Refresh();
                lblState.Text = "Current State:Disconnected";
                Cursor = Cursors.Default;
                return;
            }

            SearchforUSBCom usbcom = new SearchforUSBCom();
            string sCom = "";
            bool bSearch = usbcom.SearchforCom(ref sCom);//modify by Darcy on Nov.26 2009
            if (bSearch == false)//modify by Darcy on Nov.26 2009
            {
                MessageBox.Show("Can not find the virtual serial port that can be used", "Error");
                Cursor = Cursors.Default;
                return;
            }

            int iPort;
            for (iPort = 1; iPort < 10; iPort++)
            {
                if (sCom.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            iMachineNumber = Convert.ToInt32(txtMachineSN2.Text.Trim());
            if (iMachineNumber == 0 || iMachineNumber > 255)
            {
                MessageBox.Show("The Machine Number is invalid!", "Error");
                Cursor = Cursors.Default;
                return;
            }

            int iBaudRate = 115200;//115200 is one possible baudrate value(its value cannot be 0)
            bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, iBaudRate);

            if (bIsConnected == true)
            {
                btnUSBConnect.Text = "Disconnect";
                btnUSBConnect.Refresh();
                lblState.Text = "Current State:Connected";
                if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                    this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                    this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                    this.axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                    this.axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
                    this.axCZKEM1.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                    this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                    this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                    this.axCZKEM1.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                    this.axCZKEM1.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
                    this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                    this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                }
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }

        #endregion

        /*************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
        * This part is for demonstrating the RealTime Events that triggered  by your operations          *
        **************************************************************************************************/
        #region RealTime Events

        //When you place your finger on sensor of the device,this event will be triggered
        private void axCZKEM1_OnFinger()
        {
            Common.Log.LogError("RTEvent OnFinger Has been Triggered", Common.ErrorLevel.INFORMATION);
            lbRTShow.Items.Add("RTEvent OnFinger Has been Triggered");
        }

        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        private void axCZKEM1_OnVerify(int iUserID)
        {
            Common.Log.LogError("RTEvent OnVerify Has been Triggered, Verifying...", Common.ErrorLevel.INFORMATION);
            lbRTShow.Items.Add("RTEvent OnVerify Has been Triggered,Verifying...");

            if (iUserID != -1)
            {
                Common.Log.LogError("Verified OK, the UserID is " + iUserID.ToString(), Common.ErrorLevel.INFORMATION);
                lbRTShow.Items.Add("Verified OK,the UserID is " + iUserID.ToString());
            }
            else
            {
                Common.Log.LogError("Verified Failed...", Common.ErrorLevel.INFORMATION);
                lbRTShow.Items.Add("Verified Failed... ");
            }

            //To insert in attendence log biometric id iUserID






        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered
        private void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                lbRTShow.Items.Clear();
                Common.Log.LogError("Log Attendance Function Started", Common.ErrorLevel.INFORMATION);
                lbRTShow.Items.Add("Triggered first machine");
                logAttendence(sEnrollNumber, iIsInValid, iAttState, iVerifyMethod, iYear, iMonth, iDay, iHour, iMinute, iSecond, iWorkCode, txtMachine1Name.Text);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                MessageBox.Show("Somethong went wrong", ex.Message);
            }

        }





        //get as of today outstanding amount;



        //When you have enrolled your finger,this event will be triggered and return the quality of the fingerprint you have enrolled
        private void axCZKEM1_OnFingerFeature(int iScore)
        {
            if (iScore < 0)
            {
                lbRTShow.Items.Add("The quality of your fingerprint is poor");
            }
            else
            {
                lbRTShow.Items.Add("RTEvent OnFingerFeature Has been Triggered...Score:　" + iScore.ToString());
            }
        }

        //When you are enrolling your finger,this event will be triggered.
        private void axCZKEM1_OnEnrollFingerEx(string sEnrollNumber, int iFingerIndex, int iActionResult, int iTemplateLength)
        {
            if (iActionResult == 0)
            {
                lbRTShow.Items.Add("RTEvent OnEnrollFigerEx Has been Triggered....");
                lbRTShow.Items.Add(".....UserID: " + sEnrollNumber + " Index: " + iFingerIndex.ToString() + " tmpLen: " + iTemplateLength.ToString());
            }
            else
            {
                lbRTShow.Items.Add("RTEvent OnEnrollFigerEx Has been Triggered Error,actionResult=" + iActionResult.ToString());
            }
        }

        //When you have deleted one one fingerprint template,this event will be triggered.
        private void axCZKEM1_OnDeleteTemplate(int iEnrollNumber, int iFingerIndex)
        {
            lbRTShow.Items.Add("RTEvent OnDeleteTemplate Has been Triggered...");
            lbRTShow.Items.Add("...UserID=" + iEnrollNumber.ToString() + " FingerIndex=" + iFingerIndex.ToString());
        }

        //When you have enrolled a new user,this event will be triggered.
        private void axCZKEM1_OnNewUser(int iEnrollNumber)
        {
            lbRTShow.Items.Add("RTEvent OnNewUser Has been Triggered...");
            lbRTShow.Items.Add("...NewUserID=" + iEnrollNumber.ToString());


            try
            {
                niBioMon.ShowBalloonTip(3000, "New User", "New User Added in Biometric System Userid is " + iEnrollNumber.ToString(), ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                MessageBox.Show("Something went wrong " + ex.Message);
            }

        }

        //When you swipe a card to the device, this event will be triggered to show you the card number.
        private void axCZKEM1_OnHIDNum(int iCardNumber)
        {
            lbRTShow.Items.Add("RTEvent OnHIDNum Has been Triggered...");
            lbRTShow.Items.Add("...Cardnumber=" + iCardNumber.ToString());
        }

        //When the dismantling machine or duress alarm occurs, trigger this event.
        private void axCZKEM1_OnAlarm(int iAlarmType, int iEnrollNumber, int iVerified)
        {
            lbRTShow.Items.Add("RTEvnet OnAlarm Has been Triggered...");
            lbRTShow.Items.Add("...AlarmType=" + iAlarmType.ToString());
            lbRTShow.Items.Add("...EnrollNumber=" + iEnrollNumber.ToString());
            lbRTShow.Items.Add("...Verified=" + iVerified.ToString());
        }

        //Door sensor event
        private void axCZKEM1_OnDoor(int iEventType)
        {
            lbRTShow.Items.Add("RTEvent Ondoor Has been Triggered...");
            lbRTShow.Items.Add("...EventType=" + iEventType.ToString());
        }

        //When you have emptyed the Mifare card,this event will be triggered.
        private void axCZKEM1_OnEmptyCard(int iActionResult)
        {
            lbRTShow.Items.Add("RTEvent OnEmptyCard Has been Triggered...");
            if (iActionResult == 0)
            {
                lbRTShow.Items.Add("...Empty Mifare Card OK");
            }
            else
            {
                lbRTShow.Items.Add("...Empty Failed");
            }
        }

        //When you have written into the Mifare card ,this event will be triggered.
        private void axCZKEM1_OnWriteCard(int iEnrollNumber, int iActionResult, int iLength)
        {
            lbRTShow.Items.Add("RTEvent OnWriteCard Has been Triggered...");
            if (iActionResult == 0)
            {
                lbRTShow.Items.Add("...Write Mifare Card OK");
                lbRTShow.Items.Add("...EnrollNumber=" + iEnrollNumber.ToString());
                lbRTShow.Items.Add("...TmpLength=" + iLength.ToString());
            }
            else
            {
                lbRTShow.Items.Add("...Write Failed");
            }
        }

        //After function GetRTLog() is called ,RealTime Events will be triggered.
        //When you are using these two functions, it will request data from the device forwardly.
        private void rtTimer_Tick(object sender, EventArgs e)
        {
            rtTimer.Enabled = false;
            //deregisterEvents();
            //registerEvents();

            if (bIsConnected == false)
            {
                rtTimer.Enabled = false;
                return;
            }

            if (axCZKEM1.GetRTLog(iMachineNumber))
            {
                lbRTShow.Items.Add("GetRTLog");

            }
            else
            {
                if (axCZKEM1.ReadRTLog(iMachineNumber))
                {
                    lbRTShow.Items.Add("readrtlog");

                }
            }


            if (axCZKEM2.GetRTLog(iMachineNumber))
            {
                lbRTShow.Items.Add("GetRTLog");

            }
            else
            {
                if (axCZKEM2.ReadRTLog(iMachineNumber))
                {
                    lbRTShow.Items.Add("readrtlog");

                }
            }

            rtTimer.Enabled = true;

        }


        private void deregisterEvents()
        {
            this.axCZKEM1.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            this.axCZKEM1.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
            this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
            this.axCZKEM1.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            this.axCZKEM1.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            this.axCZKEM1.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            this.axCZKEM1.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            this.axCZKEM1.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.axCZKEM1.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            this.axCZKEM1.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            this.axCZKEM1.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            this.axCZKEM1.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
        }



        private void deregisterEvents2()
        {
            this.axCZKEM2.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            this.axCZKEM2.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
            this.axCZKEM2.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
            this.axCZKEM2.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            this.axCZKEM2.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            this.axCZKEM2.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            this.axCZKEM2.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            this.axCZKEM2.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.axCZKEM2.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            this.axCZKEM2.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            this.axCZKEM2.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            this.axCZKEM2.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
        }


        #endregion

        private void RTEventsMain_Load(object sender, EventArgs e)
        {
            try
            {
                addrange();
                this.ControlBox = false;

                connectionCheckTImer.Interval = 10000;
                connectionCheckTImer.Enabled = true;


                txtIP.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_IP;
                txtPort.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_PORT;
                txtMachine1Name.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_NAME;


                txtIP2.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_IP2;
                txtPort2.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_PORT2;
                txtMachine2Name.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_NAME2;


                cmbfetchDevice.Items.Add(ClassManager.Common.Properties.Settings.Default.MACHINE_NAME);
                cmbfetchDevice.Items.Add(ClassManager.Common.Properties.Settings.Default.MACHINE_NAME2);


                //Set Start and End for this two DTPs.Mohan(2-Dec-2017).
                dtFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtTo.Value = DateTime.Now;
                //Mohan(2-Dec-2017).

                this.niBioMon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                this.niBioMon.BalloonTipText = "ClassWise BioMonitor";
                this.niBioMon.BalloonTipTitle = "ClassWise BioMonitor";
                this.niBioMon.Icon = BioMonitor.Properties.Resources.logo; //The tray icon to use
                this.niBioMon.Text = "ClassWise BioMonitor";

                lblConstr.Text = ClassManager.BLL.DBHandller.getConnectionDescription();

                string Timer = Info.SysParam.getValue<String>(SysParam.Parameters.BIOMONITOR_MANUAL_TIMER).ToString();
                if (Timer == "True")
                {
                    chkTimer.Checked = true;
                }
                else
                {
                    chkTimer.Checked = false;
                }

                axCZKEM1 = new zkemkeeper.CZKEMClass();
                axCZKEM2 = new zkemkeeper.CZKEMClass();
                connectDevice();
                connectDevice2();

                if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME) != Common.Constants.GYM_APP_TYPE)
                {
                    this.AbsentLectureTimer.Interval = 10000;
                    this.AbsentLectureTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError("RTEventsMain_Load", Common.ErrorLevel.ERROR, ex);
                MessageBox.Show("Oops something went wrong, Please contact support");
            }
        }

        private void RTEventsMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                niBioMon.Visible = true;
                niBioMon.ShowBalloonTip(10000);
                this.ShowInTaskbar = false;
            }
        }

        private void niBioMon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            niBioMon.Visible = false;
        }

        private void RTEventsMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void cmdChangeDB_Click(object sender, EventArgs e)
        {
            Config conf = Config.getInstance();
            conf.Visible = true;
            disconnectDevice();
            this.Close();
        }


        public bool logAttendence(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode, string machineName, bool bulk = false)
        {
            try
            {
                int sendSMS = 0;
                int isChekin = 0;


                int enrollmentNo = Convert.ToInt32(sEnrollNumber);
                this.enrollmentNo = sEnrollNumber;
                BioArray = new string[] { this.enrollmentNo };

                if (!bulk)
                {
                    lbRTShow.Items.Add("Time:" + iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString());
                    lbRTShow.Items.Add("Enrollment no " + enrollmentNo.ToString() + " branch " + SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID));
                }


                DateTime timePunchIn = new DateTime();
                try
                {
                    //Common.Log.LogError("Started AttandanceHandler.Log Attendance", Common.ErrorLevel.INFORMATION);
                    timePunchIn = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);

                    isChekin = ClassManager.BLL.AttendanceHandler.logAttendence(enrollmentNo, SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID), timePunchIn, txtIP.Text, out sendSMS);
                    if (isChekin == 52)
                    {
                        lbRTShow.Items.Add("No member with id " + enrollmentNo);
                        Common.Log.LogError(Common.Log.Level.INFORMATION, "Biomonitor: No member with biometric id:" + enrollmentNo);
                        return false;
                    }
                    if (bulk == true)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Common.Log.LogError("Error checkin. ", Common.ErrorLevel.INFORMATION);
                    lbRTShow.Items.Add("Error checkin " + ex.Message);
                    return false;
                }

                List<Student> objstud = new List<Student>();
                Student objStudentMaster = new Student();
                Faculty objFaculty = new Faculty();
                try
                {
                    //Common.Log.LogError(Common.Log.Level.INFORMATION, "Get Student by Biometric ");
                    objStudentMaster = ClassManager.BLL.StudentHandller.getStudentByBioMetric(enrollmentNo, Program.LoggedInUser.BranchId.ToString());


                    bool disableUser = false;

                    if (objStudentMaster != null)
                    {
                        string Date = null;
                        var Maxdate = Date;

                        //No of checking 
                        Int32 chekinCount = ClassManager.BLL.AttendanceHandler.getAttendenceCountToday(objStudentMaster.AdmisionNo, DateTime.Now.Date);
                        objStudentMaster.dailyAttendanceCount = chekinCount;

                        objStudentMaster.checkinMachine = machineName;

                        StringBuilder displaypopup = new StringBuilder();
                        FrmBiomPopup.addItem(objStudentMaster, timePunchIn, out disableUser, isChekin);
                        if (sendSMS == 1 && SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_IN_SMS) == true && SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_OUT_SMS) == true)
                        {
                            (new Thread(() =>
                            {
                                MailHandler.sendAttendanceSMS(isChekin, objStudentMaster);
                            })).Start();
                        }
                    }
                    else
                    {
                        objFaculty = BLL.FacultyHandler.getFacultiesByBiomID(enrollmentNo, Program.LoggedInUser.BranchId);
                        if (objFaculty != null)
                        {
                            FrmBiomPopup objPopup = FrmBiomPopup.addItem(objFaculty, timePunchIn, out disableUser, isChekin);
                        }
                    }

                    //if(disableUser == true)
                    //{
                    //    lbRTShow.Items.Add("Disabling user " + enrollmentNo.ToString());
                    //}
                    //else
                    //{
                    //    lbRTShow.Items.Add("Enabling user " + enrollmentNo.ToString());
                    //}

                    //Common.Log.LogError(Common.Log.Level.INFORMATION, "Disabling user " + enrollmentNo.ToString() + " " + disableUser);

                    //try
                    //{
                    //    axCZKEM1.SSR_EnableUser(1, enrollmentNo.ToString(), disableUser);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Common.Log.LogError(ex, "Error disabling user " + enrollmentNo);
                    //}

                }
                catch (Exception ex)
                {
                    Common.Log.LogError(ex);
                    lbRTShow.Items.Add("Error getstudent " + ex.Message);
                }

                if (objStudentMaster != null)
                {
                    lbRTShow.Items.Add("Admissin no" + objStudentMaster.AdmissionNo.ToString());
                }
                else if (objFaculty != null)
                {
                    lbRTShow.Items.Add("Faculty id " + objFaculty.FacultyID);
                }
                else
                {
                    lbRTShow.Items.Add("Not a valid member");
                }

                return true;
            }
            catch (Exception ex)
            {
                lbRTShow.Items.Add("Error : Member Not Registered");
                Common.Log.LogError("logAttendence " + sEnrollNumber + " " + iIsInValid + " " + iAttState + " " + iVerifyMethod + " " + iYear + " " + iMonth + " " + iDay + " " + iHour + " " + iMinute + " " + iSecond + " " + iWorkCode, Common.ErrorLevel.ERROR, ex);
                return false;
            }
        }

        private void btnSimAttendence_Click(object sender, EventArgs e)
        {
            try
            {
                logAttendence(txtSimEnrollment.Text.ToString(), 0, 0, 0, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0, txtMachine1Name.Text);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                MessageBox.Show("Something went wrong." + ex.Message);
            }


        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RTEventsMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                this.Close();
            }
        }

        private void chkTimer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.BIOMONITOR_MANUAL_TIMER, chkTimer.Checked.ToString());
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
            }
        }
        public void addrange()
        {
            dt.Columns.AddRange(new DataColumn[]
            { new DataColumn("sdwEnrollNumber"),
              new DataColumn("Date"),
              new DataColumn("idwHour"),
              new DataColumn("idwMinute"),
              new DataColumn("idwSecond"),
            });


        }

        //Read All data from BioMetric.Hemlata(1-Dec-2017).
        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (cmbfetchDevice.Text == ClassManager.Common.Properties.Settings.Default.MACHINE_NAME)
            {

                if (bIsConnected == false)
                {
                    MessageBox.Show("Please connect the device first", "Error");
                    return;
                }
                else
                {
                    fetchData(axCZKEM1);
                }
            }
            else
            {
                if (bIsConnected2 == false)
                {
                    MessageBox.Show("Please connect the device first", "Error");
                    return;
                }
                else
                {
                    fetchData(axCZKEM2);
                }
            }


        }
        //Hemlata(1-Dec-2017).

        private void fetchData(zkemkeeper.CZKEMClass axCZKEM)
        {
            try
            {
                string sdwEnrollNumber = "";
                int idwTMachineNumber = 0;
                int idwEMachineNumber = 0;
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkcode = 0;

                int idwErrorCode = 0;
                int iGLCount = 0;
                int iIndex = 0;

                this.Cursor = Cursors.WaitCursor;
                lbRTShow.Items.Clear();
                axCZKEM.EnableDevice(iMachineNumber, false);//disable the device
                if (dtFrom.Value.Date > dtTo.Value.Date)
                {
                    MessageBox.Show("Invalid Date.", "Information");
                    return;
                }
                if (axCZKEM.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    dt = new DataTable();
                    addrange();
                    while (axCZKEM.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                    {
                        DateTime date = new DateTime(idwYear, idwMonth, idwDay);
                        dt.Rows.Add(sdwEnrollNumber, date.ToShortDateString(), idwHour, idwMinute, idwSecond);
                    }

                    DataView dv = new DataView(dt);
                    dv.RowFilter = string.Format("Date >= #{0}# AND Date <= #{1}#", dtFrom.Value.ToShortDateString(), dtTo.Value.ToShortDateString());
                    DGBiom.DataSource = dv;
                    MessageBox.Show("Received " + dv.Count + " records from machine.","Biomonitor");
                }
                else
                {
                    axCZKEM.GetLastError(ref idwErrorCode);

                    if (idwErrorCode != 0)
                    {
                        MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                    }
                    else
                    {
                        MessageBox.Show("No data from terminal returns!", "Error");
                    }
                }
                axCZKEM.EnableDevice(iMachineNumber, true);//enable the device

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Something went wrong, Please contact support. " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                
                DataTable gridSource = ((DGBiom.DataSource as DataView).ToTable());

                if (MessageBox.Show("Importing "+ gridSource.Rows.Count+" records. Do you want to continue?","Biomonitor",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                int count = 0;
                foreach (DataRow row in gridSource.Rows)
                {
                    int enrollmentNo = Convert.ToInt32(row.ItemArray[0].ToString());
                    try
                    {
                        DateTime timepunchedin = new DateTime(Convert.ToDateTime(row.ItemArray[1]).Year, Convert.ToDateTime(row.ItemArray[1]).Month, Convert.ToDateTime(row.ItemArray[1]).Day, Convert.ToInt32(row.ItemArray[2]), Convert.ToInt32(row.ItemArray[3]), Convert.ToInt32(row.ItemArray[4]));
                        if (logAttendence(row.ItemArray[0].ToString(), 0, 0, 0, timepunchedin.Year, timepunchedin.Month, timepunchedin.Day, Convert.ToInt32(row.ItemArray[2]), Convert.ToInt32(row.ItemArray[3]), Convert.ToInt32(row.ItemArray[4]), 0, txtMachine1Name.Text, true))
                        {
                            count++;
                        }
                    }
                    catch (Exception ex)
                    {
                        lbRTShow.Items.Add("Error checkin " + ex.Message);
                        Common.Log.LogError(ex);
                    }


                }

                MessageBox.Show("Imported " + count + " record", "Information");

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Common.Log.LogError(ex);

                MessageBox.Show("Something went wrong " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AbsentLectureTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.AbsentLectureTimer.Enabled = false;
                Common.Log.LogError("AbsentMsg Started", Common.ErrorLevel.INFORMATION);
                DataTable DtStudent = BLL.AttendanceHandler.getLecturewiseAbsentStudent(DateTime.Now, Program.LoggedInUser.BranchId.ToString());
                NotificationHandler.sendAbsentMessageForADay(DtStudent);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, " AbsentLectureTimer_Tick");
            }
            finally
            {
                this.AbsentLectureTimer.Enabled = true;
            }

        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.E:
                    this.Close();
                    Program.exit();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDisableUser_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Return " + axCZKEM1.SSR_EnableUser(iMachineNumber, txtSimEnrollment.Text, false));
                int error = 0;
                axCZKEM1.GetLastError(ref error);
                MessageBox.Show("Return code " + error);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Error disabling user " + 0);
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Return " + axCZKEM1.SSR_EnableUser(iMachineNumber, txtSimEnrollment.Text, true));
                int error = 0;
                axCZKEM1.GetLastError(ref error);
                MessageBox.Show("Return code " + error);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Error disabling user " + 0);
            }
        }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            try
            {
                connectDevice2();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                MessageBox.Show("Could not connect to device");
            }
        }

        private void connectDevice2(bool silent = false)
        {
            Common.Log.LogError("Connecting Device Started", Common.ErrorLevel.INFORMATION);
            bool getLog = true;

            if ((txtIP2.Text == "" || txtPort2.Text == ""))
            {
                lblState2.Text = "IP and Port cannot be null";
                return;
            }

            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (btnConnect2.Text == "DisConnect")
            {
                disconnectDevice2();
                return;
            }


            bIsConnected2 = axCZKEM2.Connect_Net(txtIP2.Text, Convert.ToInt32(txtPort2.Text));

            if (bIsConnected2 == true)
            {
                btnConnect2.Text = "DisConnect";
                btnConnect2.Refresh();
                lblState2.Text = "Current State:Connected";
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.

                if (axCZKEM2.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    registerEvents2();
                }

                lbRTShow.Items.Add("Connected..." + txtIP2.Text);

                ClassManager.Common.Properties.Settings.Default.MACHINE_IP2 = txtIP2.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_PORT2 = txtPort2.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_NAME2 = txtMachine2Name.Text;
                ClassManager.Common.Properties.Settings.Default.Save();

                string Timer = Info.SysParam.getValue<String>(SysParam.Parameters.BIOMONITOR_MANUAL_TIMER).ToString();
                if (Timer == "True")
                {
                    this.rtTimer.Interval = 500;
                    this.rtTimer.Enabled = true;
                }
                else
                {
                    this.rtTimer.Enabled = false;
                }


            }
            else
            {

                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }



        private void registerEvents2()
        {
            this.axCZKEM2.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            this.axCZKEM2.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);

            this.axCZKEM2.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            this.axCZKEM2.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            this.axCZKEM2.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            this.axCZKEM2.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            this.axCZKEM2.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            this.axCZKEM2.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            this.axCZKEM2.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            this.axCZKEM2.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            this.axCZKEM2.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
            axCZKEM2.ReadRTLog(iMachineNumber);
            while ((axCZKEM2.GetRTLog(iMachineNumber)))
            {

                axCZKEM2.ReadRTLog(iMachineNumber);
            }
            this.axCZKEM2.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM2_OnAttTransactionEx);
        }


        //If your fingerprint(or your card) passes the verification,this event will be triggered
        private void axCZKEM2_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                lbRTShow.Items.Clear();
                Common.Log.LogError("Log Attendance Function Started", Common.ErrorLevel.INFORMATION);
                lbRTShow.Items.Add("Triggered 2nd machine");
                logAttendence(sEnrollNumber, iIsInValid, iAttState, iVerifyMethod, iYear, iMonth, iDay, iHour, iMinute, iSecond, iWorkCode, txtMachine2Name.Text);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                MessageBox.Show("Something went wrong " + ex.Message);
            }

        }

        private void connectionCheckTImer_Tick(object sender, EventArgs e)
        {

            connectionCheckTImer.Enabled = false;
            if (bIsConnected == false && !txtIP.Text.Equals("") && txtIP.Text.Length > 0)
            {
                connectDevice(silent: true);
            }

            if (bIsConnected2 == false && !txtIP2.Text.Equals("") && txtIP2.Text.Length > 0)
            {
                connectDevice2(silent: true);
            }

            connectionCheckTImer.Enabled = true;
        }

        private void btnStopAutoCommect_Click(object sender, EventArgs e)
        {
            if (connectionCheckTImer.Enabled == true)
            {
                connectionCheckTImer.Enabled = false;
                btnStopAutoCommect.Text = "Start Autoconnect";
            }
            else
            {
                connectionCheckTImer.Enabled = true;
                btnStopAutoCommect.Text = "Stop Autoconnect";
            }

        }

        private void btnClearIp_Click(object sender, EventArgs e)
        {
            try
            {
                disconnectDevice();
                disconnectDevice2();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
            }
            finally
            {
                clearIPs();
            }
        }

        private void clearIPs()
        {
            try
            {
                txtIP.Text = "";
                txtIP2.Text = "";
                txtPort.Text = "";
                txtPort2.Text = "";
                txtMachine1Name.Text = "";
                txtMachine2Name.Text = "";

                ClassManager.Common.Properties.Settings.Default.MACHINE_IP = txtIP.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_PORT = txtPort.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_NAME = txtMachine1Name.Text;


                ClassManager.Common.Properties.Settings.Default.MACHINE_IP2 = txtIP2.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_PORT2 = txtPort2.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_NAME2 = txtMachine2Name.Text;

                ClassManager.Common.Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw;
            }
        }
    }
}
