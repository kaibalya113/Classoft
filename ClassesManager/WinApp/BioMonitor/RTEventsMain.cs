
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
        string BioId;
        string[] BioArray;
        DataTable dt = new DataTable();
        public RTEventsMain()
        {
            InitializeComponent();
        }

        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();


        /********************************************************************************************************************************************
        * Bee you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
        * This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
        * The communication way which you can use duing to the model of the device.                                                                 *
        * *******************************************************************************************************************************************/
        #region Communication
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

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
                MessageBox.Show("Could not connect to device");
            }
        }

        private void connectDevice()
        {
            Common.Log.LogError(Common.Log.Level.INFORMATION, "Connecting Device Started");
            bool getLog = true;
            //if (BioMonitor.Properties.Settings.Default.MACHINE_IP == "" || BioMonitor.Properties.Settings.Default.MACHINE_PORT == "")
            if (txtIP.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("IP and Port cannot be null", "Error");
                return;
            }

            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (btnConnect.Text == "DisConnect")
            {
                disconnectDevice();
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

                lbRTShow.Items.Add("Connected...");

                ClassManager.Common.Properties.Settings.Default.MACHINE_IP = txtIP.Text;
                ClassManager.Common.Properties.Settings.Default.MACHINE_PORT = txtPort.Text;

                BLL.SystemParameterHandler.updateSysParam(SysParam.Parameters.DEVICE_ID, txtIP.Text);
                BLL.SystemParameterHandler.updateSysParam(SysParam.Parameters.DEVICE_PORT_NO, txtPort.Text);

                

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
            this.AbsentLectureTimer.Interval = 1800000;
            this.AbsentLectureTimer.Enabled = true;
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
            Common.Log.LogError(Common.Log.Level.INFORMATION, "RTEvent OnFinger Has been Triggered");
            lbRTShow.Items.Add("RTEvent OnFinger Has been Triggered");
        }

        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        private void axCZKEM1_OnVerify(int iUserID)
        {
            Common.Log.LogError(Common.Log.Level.INFORMATION, "RTEvent OnVerify Has been Triggered, Verifying...");
            lbRTShow.Items.Add("RTEvent OnVerify Has been Triggered,Verifying...");

            if (iUserID != -1)
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Verified OK, the UserID is " + iUserID.ToString());
                lbRTShow.Items.Add("Verified OK,the UserID is " + iUserID.ToString());
            }
            else
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Verified Failed...");
                lbRTShow.Items.Add("Verified Failed... ");
            }

            //To insert in attendence log biometric id iUserID






        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered
        private void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Log Attendance Function Started");
                logAttendence(sEnrollNumber, iIsInValid, iAttState, iVerifyMethod, iYear, iMonth, iDay, iHour, iMinute, iSecond, iWorkCode);
            }
            catch (Exception)
            {
                throw;
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
                MessageBox.Show(ex.Message);
                throw ex;
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


        #endregion

        private void RTEventsMain_Load(object sender, EventArgs e)
        {
            try
            {

                this.ControlBox = false;
                txtIP.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_IP;
                txtPort.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_PORT;

                //Set Start and End for this two DTPs.Mohan(2-Dec-2017).
                dtFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtTo.Value = DateTime.Now;
                //Mohan(2-Dec-2017).

                this.niBioMon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                this.niBioMon.BalloonTipText = "ClassWise BioMonitor";
                this.niBioMon.BalloonTipTitle = "ClassWise BioMonitor";
                //this.niBioMon.Icon = ClassManager.Properties.Resources; //The tray icon to use #TODO add icon
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
                connectDevice();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(Common.Log.Level.ERROR, ex.Message);
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


        public void logAttendence(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                lbRTShow.Items.Clear();

                lbRTShow.Items.Add("RTEvent OnAttTrasactionEx Has been Triggered");
                lbRTShow.Items.Add("UserID:" + sEnrollNumber + " isInvalid:" + iIsInValid.ToString() + " attState:" + iAttState.ToString() + " VerifyMethod:" + iVerifyMethod.ToString() + " Workcode:" + iWorkCode.ToString());
                lbRTShow.Items.Add("Time:" + iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString());

                int enrollmentNo = Convert.ToInt32(sEnrollNumber);
                BioId = sEnrollNumber;
                BioArray = new string[] { BioId };
                lbRTShow.Items.Add("Enrollment no " + enrollmentNo.ToString() + " branch " + SysParam.getValue<string>(SysParam.Parameters.SW_BRANCH_ID));
                Int32 isChekin = 0;

                DateTime timePunchIn = new DateTime();
                try
                {
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Started AttandanceHandler.Log Attendance");
                    timePunchIn = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);
                    int sendSMS;
                    isChekin = ClassManager.BLL.AttendanceHandler.logAttendence(enrollmentNo, SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID), timePunchIn, txtIP.Text,out sendSMS);
                }
                catch (Exception ex)
                {
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Error checkin. ");
                    lbRTShow.Items.Add("Error checkin " + ex.Message);
                }

                List<Student> objstud = new List<Student>();
                Student objStudentMaster = new Student();
                Faculty objFaculty = new Faculty();
                try
                {
                    //Common.Log.LogError(Common.Log.Level.INFORMATION, "Get Student by Biometric ");
                    objStudentMaster = ClassManager.BLL.StudentHandller.getStudentByBioMetric(enrollmentNo, ClassManager.Common.ClsCommon.branchId.ToString());
                    bool disableUser = false;

                    if (objStudentMaster != null)
                    {
                        string Date = null;
                        var Maxdate = Date;

                        //Common.Log.LogError(Common.Log.Level.INFORMATION, "Get Facility of Students ");
                        DataTable dt = ClassManager.BLL.StudentHandller.getFacility(objStudentMaster.AdmissionNo);

                        //Common.Log.LogError(Common.Log.Level.INFORMATION, "Called Popup Screen");
                        StringBuilder displaypopup = new StringBuilder();
                        FrmBiomPopup.addItem(objStudentMaster, timePunchIn,out disableUser, isChekin);
                    }
                    else
                    {
                        //Common.Log.LogError(Common.Log.Level.INFORMATION, "Get Faculty by Id ");
                        objFaculty = BLL.FacultyHandler.getFacultiesByBiomID(enrollmentNo, ClassManager.Common.ClsCommon.branchId);
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

                    try
                    {
                        //axCZKEM1.SSR_EnableUser(1, enrollmentNo.ToString(), disableUser);
                    }
                    catch(Exception ex)
                    {
                        Common.Log.LogError(ex, "Error disabling user " + enrollmentNo);
                    }

                }
                catch (Exception ex)
                {
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
            }
            catch (Exception ex)
            {
                lbRTShow.Items.Add("Error : Member Not Registered");
                Common.Log.LogError(Common.Log.Level.ERROR, ex.Message);
            }
        }

        private void btnSimAttendence_Click(object sender, EventArgs e)
        {
            logAttendence(txtSimEnrollment.Text.ToString(), 0, 0, 0, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);

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
                throw ex;
            }
        }


        //Read All data from BioMetric.Hemlata(1-Dec-2017).
        private void btnFetch_Click(object sender, EventArgs e)
        {

            dt.Columns.AddRange(new DataColumn[]
            { new DataColumn("sdwEnrollNumber"),
              new DataColumn("Date"),
              new DataColumn("idwHour"),
              new DataColumn("idwMinute"),
              new DataColumn("idwSecond"),
            });


            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }

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

            Cursor = Cursors.WaitCursor;
            lbRTShow.Items.Clear();
            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            if (dtFrom.Value.Date > dtTo.Value.Date)
            {
                //throw new Exception("Invalid Date.");
                MessageBox.Show("Invalid Date.", "Information");
                return;
            }
            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
            {
                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                           out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {


                    DateTime date = new DateTime(idwYear, idwMonth, idwDay);
                    dt.Rows.Add(sdwEnrollNumber, date.ToShortDateString(), idwHour, idwMinute, idwSecond);

                    //logAttendence(sdwEnrollNumber, 0, 0, idwVerifyMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode);
                }


                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Date >= #{0}# AND Date <= #{1}#", dtFrom.Value.ToShortDateString(), dtTo.Value.ToShortDateString());
                DGBiom.DataSource = dv;


            }
            else
            {
                Cursor = Cursors.Default;
                axCZKEM1.GetLastError(ref idwErrorCode);

                if (idwErrorCode != 0)
                {
                    MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                }
                else
                {
                    MessageBox.Show("No data from terminal returns!", "Error");
                }
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            Cursor = Cursors.Default;
        }
        //Hemlata(1-Dec-2017).

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] recordsForSelectedDate = dt.Select(string.Format("Date >= #{0}# AND Date <= #{1}#", dtFrom.Value.ToShortDateString(), dtTo.Value.ToShortDateString()));


                foreach (DataRow row in recordsForSelectedDate)
                {
                    //  logAttendence(row.ItemArray[0].ToString(), 0, 0, 0, Convert.ToDateTime(row.ItemArray[1]).Year, Convert.ToDateTime(row.ItemArray[1]).Month, Convert.ToDateTime(row.ItemArray[1]).Day, Convert.ToInt32(row.ItemArray[2]), Convert.ToInt32(row.ItemArray[3]), Convert.ToInt32(row.ItemArray[4]), 0, dtFrom.Value.Date,dtTo.Value.Date);
                    //  private void logAttendence(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode, DateTime? FromDate = null, DateTime? ToDate = null)

                    lbRTShow.Items.Add("RTEvent OnAttTrasactionEx Has been Triggered,Verified OK");
                    lbRTShow.Items.Add("...UserID:" + row.ItemArray[0].ToString());
                    lbRTShow.Items.Add("...isInvalid:" + 0);
                    lbRTShow.Items.Add("...attState:" + 0);
                    lbRTShow.Items.Add("...VerifyMethod:" + 0);
                    lbRTShow.Items.Add("...Workcode:" + 0);//the difference between the event OnAttTransaction and OnAttTransactionEx
                    lbRTShow.Items.Add("...Time:" + Convert.ToDateTime(row.ItemArray[1]).Year + "-" + Convert.ToDateTime(row.ItemArray[1]).Month + "-" + Convert.ToDateTime(row.ItemArray[1]).Day + " " + Convert.ToInt32(row.ItemArray[2]) + ":" + Convert.ToInt32(row.ItemArray[3]) + ":" + Convert.ToInt32(row.ItemArray[4]));

                    int enrollmentNo = Convert.ToInt32(row.ItemArray[0].ToString());

                    lbRTShow.Items.Add("Enrollment no " + enrollmentNo.ToString() + " branch " + SysParam.getValue<string>(SysParam.Parameters.SW_BRANCH_ID));
                    Int32 isChekin = 0;
                    try
                    {
                        DateTime timepunchedin = new DateTime(Convert.ToDateTime(row.ItemArray[1]).Year, Convert.ToDateTime(row.ItemArray[1]).Month, Convert.ToDateTime(row.ItemArray[1]).Day, Convert.ToInt32(row.ItemArray[2]), Convert.ToInt32(row.ItemArray[3]), Convert.ToInt32(row.ItemArray[4]));
                        isChekin = ClassManager.BLL.AttendanceHandler.FetchLogAttendance(Convert.ToInt16(row.ItemArray[0]), SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID), timepunchedin, txtIP.Text, dtFrom.Value.Date, dtTo.Value.Date);
                        // isChekin = ClassManager.BLL.AttendanceHandler.logAttendence(Convert.ToInt16(row.ItemArray[0]), SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID), timepunchedin, txtIP.Text, dtFrom.Value.Date, dtTo.Value.Date);
                    }
                    catch (Exception ex)
                    {
                        lbRTShow.Items.Add("Error checkin " + ex.Message);
                    }

                }

                MessageBox.Show("Completed", "Information");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AbsentLectureTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "AbsentMsg Started");
                DataTable DtStudent = BLL.AttendanceHandler.getLecturewiseAbsentStudent(DateTime.Now, ClassManager.Common.ClsCommon.branchId.ToString());
                NotificationHandler.sendAbsentMessageForADay(DtStudent);
                Common.Log.LogError(Common.Log.Level.INFORMATION, "AbsentMsg Completed");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.E:
                    this.Close();
                    Application.Exit();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDisableUser_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Return "+ axCZKEM1.SSR_EnableUser(iMachineNumber, txtSimEnrollment.Text,false));
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
    }
}
