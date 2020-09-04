using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManager.Common;

namespace ClassManager.BLL
{
    public class BiometricHandller
    {
        static String ipAddress;
        static String portNo;
        const string defaultIP = "192.168.0.150";
        const string defaultPort = "4730";
        const string logFileName = "BiomtricLog";
        static int branchId;

        //Create Standalone SDK class dynamicly.
        public static zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        /********************************************************************************************************************************************
        * Bee you refer to this demo,we strongly suggest you read the development manual deeply first.                                           *
        * This part is for demonstrating the communication with your device.There are 3 communication ways: "TCP/IP","Serial Port" and "USB Client".*
        * The communication way which you can use duing to the model of the device.                                                                 *
        * *******************************************************************************************************************************************/
        #region Communication
        public static bool bIsConnected = false;//the boolean value identifies whether the device is connected
        public static int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

        static BiometricHandller()
        {
            ipAddress = ClassManager.Common.Properties.Settings.Default.MACHINE_IP;
            portNo = ClassManager.Common.Properties.Settings.Default.MACHINE_PORT;
        }

        public static bool connectBiometric(int machineBranchId)
        {
            ClassManager.Common.Log.LogError(ClassManager.Common.Log.Level.INFORMATION, "Connecting Device Started");
            branchId = machineBranchId;
            bool getLog = true;
            
            if (ipAddress== "" || portNo == "")
            {
                ClassManager.Common.Log.LogError(ClassManager.Common.Log.Level.ERROR, "No ip defined trying default configuration",logFileName);

                ipAddress = defaultIP;
                portNo = defaultPort;
            }

            int idwErrorCode = 0;

            bIsConnected = axCZKEM1.Connect_Net(ipAddress, Convert.ToInt32(portNo));

            if (bIsConnected == true)
            {
                ClassManager.Common.Log.LogError(ClassManager.Common.Log.Level.INFORMATION, "Connecting to device at " + ipAddress);
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.

                if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    registerEvents();
                }

                ClassManager.Common.Log.LogError(ClassManager.Common.Log.Level.INFORMATION, "Connected to device at " + ipAddress);

                ClassManager.Common.Properties.Settings.Default.MACHINE_IP = ipAddress;
                ClassManager.Common.Properties.Settings.Default.MACHINE_PORT = portNo;

                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.DEVICE_ID, ipAddress);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.DEVICE_PORT_NO, portNo);

                ClassManager.Common.Properties.Settings.Default.Save();
                return true;

            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ClassManager.Common.Log.LogError(ClassManager.Common.Log.Level.ERROR, "Unable to connect the device "+ ipAddress +",ErrorCode=" + idwErrorCode.ToString(), logFileName);
                return false;
            }
        }

        private static void registerEvents()
        {
            axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);

            axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            axCZKEM1.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            axCZKEM1.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            axCZKEM1.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
            axCZKEM1.ReadRTLog(iMachineNumber);
            while ((axCZKEM1.GetRTLog(iMachineNumber)))
            {
                axCZKEM1.ReadRTLog(iMachineNumber);
            }
            axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
        }

        public static void disconnectDevice()
        {
            axCZKEM1.Disconnect();
            deregisterEvents();
            bIsConnected = false;
            return;
        }

        #endregion Communication

        /*************************************************************************************************
        * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
        * This part is for demonstrating the RealTime Events that triggered  by your operations          *
        **************************************************************************************************/
        #region RealTime Events

        //When you place your finger on sensor of the device,this event will be triggered
        private static void axCZKEM1_OnFinger()
        {
            Common.Log.LogError(Common.Log.Level.INFORMATION, "RTEvent OnFinger Has been Triggered",logFileName);
        }

        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        private static void axCZKEM1_OnVerify(int iUserID)
        {
            Common.Log.LogError(Common.Log.Level.INFORMATION, "RTEvent OnVerify Has been Triggered, Verifying...", logFileName);

            if (iUserID != -1)
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Verified OK, the UserID is " + iUserID.ToString(), logFileName);
            }
            else
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Verified Failed...", logFileName);
            }

            //To insert in attendence log biometric id iUserID
        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered
        private static void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Log Attendance Function Started", logFileName);
                DateTime checkInTime = new DateTime(iYear, iMonth, iDay, iHour, iMonth, iSecond);
                int sendSMS;
                BLL.AttendanceHandler.logAttendence(Convert.ToInt32(sEnrollNumber),branchId,checkInTime,ipAddress,out sendSMS);
            }
            catch (Exception)
            {
                throw;
            }

        }



        //When you have enrolled your finger,this event will be triggered and return the quality of the fingerprint you have enrolled
        private static void axCZKEM1_OnFingerFeature(int iScore)
        {
            if (iScore < 0)
            {
               //"The quality of your fingerprint is poor";
            }
            else
            {
                //RTEvent OnFingerFeature Has been Triggered...Score:　" + iScore.ToString());
            }
        }

        //When you are enrolling your finger,this event will be triggered.
        private static void axCZKEM1_OnEnrollFingerEx(string sEnrollNumber, int iFingerIndex, int iActionResult, int iTemplateLength)
        {
            if (iActionResult == 0)
            {
                //"RTEvent OnEnrollFigerEx Has been Triggered...."
                //.....UserID: " + sEnrollNumber + " Index: " + iFingerIndex.ToString() + " tmpLen: " + iTemplateLength.ToString());
            }
            else
            {
                //RTEvent OnEnrollFigerEx Has been Triggered Error,actionResult=" + iActionResult.ToString());
            }
        }

        //When you have deleted one one fingerprint template,this event will be triggered.
        private static void axCZKEM1_OnDeleteTemplate(int iEnrollNumber, int iFingerIndex)
        {
            //RTEvent OnDeleteTemplate Has been Triggered...");
            //...UserID=" + iEnrollNumber.ToString() + " FingerIndex=" + iFingerIndex.ToString());
        }

        //When you have enrolled a new user,this event will be triggered.
        private static void axCZKEM1_OnNewUser(int iEnrollNumber)
        {
            //RTEvent OnNewUser Has been Triggered...");
            //...NewUserID=" + iEnrollNumber.ToString());


            try
            {
                //"New User Added in Biometric System Userid is " + iEnrollNumber.ToString(), ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        //When you swipe a card to the device, this event will be triggered to show you the card number.
        private static void axCZKEM1_OnHIDNum(int iCardNumber)
        {
            //RTEvent OnHIDNum Has been Triggered...");
            //...Cardnumber=" + iCardNumber.ToString());
        }

        //When the dismantling machine or duress alarm occurs, trigger this event.
        private static void axCZKEM1_OnAlarm(int iAlarmType, int iEnrollNumber, int iVerified)
        {
            //RTEvnet OnAlarm Has been Triggered...");
            //...AlarmType=" + iAlarmType.ToString());
            //...EnrollNumber=" + iEnrollNumber.ToString());
            //...Verified=" + iVerified.ToString());
        }

        //Door sensor event
        private static void axCZKEM1_OnDoor(int iEventType)
        {
            //RTEvent Ondoor Has been Triggered...");
            //...EventType=" + iEventType.ToString());
        }

        //When you have emptyed the Mifare card,this event will be triggered.
        private static void axCZKEM1_OnEmptyCard(int iActionResult)
        {
            //RTEvent OnEmptyCard Has been Triggered...");
            if (iActionResult == 0)
            {
                //...Empty Mifare Card OK");
            }
            else
            {
                //...Empty Failed");
            }
        }

        //When you have written into the Mifare card ,this event will be triggered.
        private static void axCZKEM1_OnWriteCard(int iEnrollNumber, int iActionResult, int iLength)
        {
            //RTEvent OnWriteCard Has been Triggered...");
            if (iActionResult == 0)
            {
                //...Write Mifare Card OK");
                //...EnrollNumber=" + iEnrollNumber.ToString());
                //...TmpLength=" + iLength.ToString());
            }
            else
            {
                //...Write Failed");
            }
        }

        private static void deregisterEvents()
        {
            axCZKEM1.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
            axCZKEM1.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
            axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
            axCZKEM1.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
            axCZKEM1.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
            axCZKEM1.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
            axCZKEM1.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
            axCZKEM1.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
            axCZKEM1.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
            axCZKEM1.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
            axCZKEM1.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
            axCZKEM1.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
        }


        #endregion


    }
}
