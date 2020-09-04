using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassManager.Info;
using System.Threading;
using System.Diagnostics;
namespace ClassManager.WinApp
{
    static class Program
    {
        //public static int standard=24;
        public static User LoggedInUser;
        public static int branchId;


        //Mohan(05-Dec-2017).
        public static Mutex objMutex = new Mutex(false, "ClassManager");
        //Mohan(05-Dec-2017).

        /// <summary>
        /// The main entry point for the application.
        /// </summary>S22
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (!objMutex.WaitOne(TimeSpan.FromSeconds(2), false))
                {
                    MessageBox.Show("Application is already Running!", "ClassWise", MessageBoxButtons.OK);
                    return;
                }
                try
                {
                    if (BLL.DBHandller.checkDBCOnnectivity())
                    {
                        try
                        {
                            BLL.DBHandller.enableTrigger();
                        }
                        catch (Exception ex)
                        {
                            Common.Log.LogError(ex, "Program.Main()");
                        }

                        BLL.SystemParameterHandler.loadSystemParameter();
                        BLL.TemplateHandler.loadTemplates();
                        startBiomonitor();

                        if (licenceCheck())
                        {
                            Application.Run(FrmLogin.getInstance());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please configure ClassManager properly, Connection is Lost", "ClassManager");
                        Application.Run(FrmLogin.getInstance());
                    }
                }
                catch (KeyNotFoundException ex)
                {
                    Common.Log.LogError(ex, "Program.Main()");
                    Application.Run(FrmLogin.getInstance());
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("The type initializer for 'ClassManager.Info.SysParam' threw an exception."))
                    {
                        MessageBox.Show("Please Configure System Parameter properly", "ClassManager");
                    }
                    else
                    {
                        Common.Log.LogError(ex, "Program.Main()");
                        MessageBox.Show("Something went wrong, Please contact support");
                    }
                }
            }
            finally
            {

            }
        }

        public static void startBiomonitor()
        {
            try
            {
                bool runBiomonitor = ClassManager.Properties.Settings.Default.RunBiomonitor;

                if (runBiomonitor == true)
                {
                    var runningProcessByName = Process.GetProcessesByName("biomonitor");
                    if (runningProcessByName.Length == 0)
                    {
                        Common.Log.LogError("Biomonitor not running starting biomonitor", Common.ErrorLevel.INFORMATION);
                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "biomonitor.exe");
                        Common.Log.LogError("Started Biomonotor", Common.ErrorLevel.INFORMATION);
                    }
                    else
                    {
                        Common.Log.LogError("Biomonitor already running", Common.ErrorLevel.INFORMATION);
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError("Error starting Biomonotor", Common.ErrorLevel.ERROR,ex);
            }

        }

        private static bool licenceCheck()
        {
            try
            {
                String storedLicenceKey = SysParam.getValue<string>(SysParam.Parameters.LICENCE_KEY);
                if (storedLicenceKey == null || storedLicenceKey == "" || storedLicenceKey == String.Empty)
                {
                    Application.Run(new FrmRegistration());
                    return false;
                }
                string[] licenceKey = storedLicenceKey.Split(',');
                string regContactNo = SysParam.getValue<string>(SysParam.Parameters.REG_CONTACT);

                if (licenceKey[0].Equals("") || licenceKey[0].Equals("DEMO"))
                {
                    Application.Run(new FrmRegistration());
                    return false;
                }
                else
                {
                    if (Common.FingerPrint.appReleaseDate > DateTime.Now.Date)
                    {
                        MessageBox.Show("Invalid system date, Please set valid date", "ClassManager");
                        return false;
                    }
                    else
                    {
                        int noOfDaysForExpiry = 0;
                        foreach (string key in licenceKey)
                        {
                            String keyStatus = Common.FingerPrint.validateLicence(regContactNo, key, out noOfDaysForExpiry);
                            if (keyStatus.Equals("E"))
                            {
                                MessageBox.Show("Your licence is expired, Please contact our support", UICommon.WinForm.getAppName());
                            }
                            else if (keyStatus.Equals("I"))
                            {

                            }
                            else
                            {
                                DateTime? notificationSent = Common.Formatter.parseExactDate(SysParam.getValue<String>(SysParam.Parameters.NOTIFICATION_SENT_DATE), Common.Formatter.DateFormat);

                                if (noOfDaysForExpiry < 60 && noOfDaysForExpiry > 0 && (notificationSent == null || notificationSent.Value < DateTime.Now))
                                {
                                    if (noOfDaysForExpiry > 20 && DateTime.Now.Day % 4 == 0)
                                    {
                                        MessageBox.Show("Your licence is going to expire in next " + noOfDaysForExpiry + " days, Please contact support to renew your licence.", UICommon.WinForm.getAppName());
                                    }
                                    else if (noOfDaysForExpiry < 20)
                                    {
                                        MessageBox.Show("Your licence is going to expire in next " + noOfDaysForExpiry + " days, Please contact support to renew your licence.", UICommon.WinForm.getAppName());
                                    }
                                }
                                return true;
                            }
                        }
                        MessageBox.Show("Invalid licence key, Please provide valid licence key","Registration");
                        Application.Run(new FrmRegistration());
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                return false;
            }
        }

        public static void sendNotification(int branchId)
        {
            try
            {
                BLL.SystemParameterHandler.loadSystemParameter(branchId);
                BLL.NotificationHandler.autoSendNotifications( DateTime.Now, branchId);
                Common.Log.LogError("Thread completed", Common.ErrorLevel.INFORMATION);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
            }

        }
    }
}
