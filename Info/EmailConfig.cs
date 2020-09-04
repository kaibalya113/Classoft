using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class EmailConfig
    {
        public static string EmailID { get; set; }
        public static string HostName { get; set; }
        public static int PortNumber { get; set; }
        public static string UsernameEmail { get; set; }
        public static string PasswordEmail { get; set; }



        static EmailConfig()
        {
            loadData();
        }


        public static Boolean loadEmailConfig()
        {
            try
            {
                if (UsernameEmail == "" || UsernameEmail == String.Empty)
                {
                    loadData();
                }
                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void loadData()
        {
            try
            {
                EmailID = Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS);
                if (EmailID == "" || EmailID == null || EmailID == string.Empty)
                {
                    EmailID = "alert@accunityservices.com";
                }

                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    String result;
                    string appNam = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    if (appNam == Common.Constants.GYM_APP_TYPE)
                    {
                        result = client.DownloadString("https://accunityservices.com/client_tracking/email-credentials.php?key=innovation&app=" + appNam);
                    }
                    else
                    {
                        result = client.DownloadString("https://accunityservices.com/client_tracking/email-credentials.php?key=innovation&app=Class");
                    }

                    String[] data = result.Split(',');
                    UsernameEmail = data[0];
                    PasswordEmail = data[1];
                    PortNumber = Convert.ToInt32(data[2]);
                    HostName = data[3];
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }
    }
}
