using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    [Serializable]
    public class SmsConfig
    {

        public string MarketingUrl { get; set; }

        static SmsConfig SMSConfiguration;

        public string SmsUrl { get; set; }

        //string smsUsername, smsPassword, smsSender, smsContactNo, smsText, smsPriority, smsStype, smsUsernamePromo;

        public string SmsUsernamePromo { get; set; }

        public string SmsUsername { get; set; }

        public string SmsPassword { get; set; }

        public string SmsSender { get; set; }

        public string SmsContactNo { get; set; }

        public string SmsText { get; set; }

        public string SmsPriority { get; set; }

        public string SmsStype { get; set; }

        public StringBuilder SURL { get; set; }

        public string Sll { get; set; }

        public static Boolean fromAdvtiseForm;

        public string BlnceUrl {get;set;}

        public static void loadSmsConfig()
        {
            try
            {
                SMSConfiguration = new SmsConfig();

                SMSConfiguration.SmsUrl = SysParam.getValue<String>(SysParam.Parameters.SMS_URL);// Properties.Settings.Default.smsURL;                   
                SMSConfiguration.MarketingUrl = SysParam.getValue<String>(SysParam.Parameters.SMS_MARKETING_URL);// Properties.Settings.Default.smsURL;                                          
                SMSConfiguration.SmsUsername = SysParam.getValue<String>(SysParam.Parameters.SMS_USERNAME);// Properties.Settings.Default.smsUsername;
                SMSConfiguration.SmsPassword = SysParam.getValue<String>(SysParam.Parameters.SMS_PASSWORD); //Properties.Settings.Default.smsPassword;
                SMSConfiguration.SmsSender = SysParam.getValue<String>(SysParam.Parameters.SMS_SENDER);  //Properties.Settings.Default.smsSender;   
                SMSConfiguration.SmsStype = SysParam.getValue<String>(SysParam.Parameters.SMS_TYPE);  //Properties.Settings.Default.smsSender; 
                SMSConfiguration.SmsUsernamePromo = SysParam.getValue<String>(SysParam.Parameters.SMS_USERNAME_PROMO);  //Properties.Settings.Default.smsSender; 
                //SMSConfiguration.BlnceUrl = SysParam.getValue<String>(SysParam.Parameters.)
                StringBuilder markURL = new StringBuilder(SMSConfiguration.MarketingUrl);

                markURL.Replace(":SMS_USERNAME", SMSConfiguration.SmsUsernamePromo);
                markURL.Replace(":SMS_PASSWORD", SMSConfiguration.SmsPassword);
                markURL.Replace(":SMS_SENDER", SMSConfiguration.SmsSender);
                markURL.Replace(":SMS_TYPE", SMSConfiguration.SmsStype);
                StringBuilder sURL = new StringBuilder(SMSConfiguration.SmsUrl);

                sURL.Replace(":SMS_USERNAME", SMSConfiguration.SmsUsername);
                sURL.Replace(":SMS_PASSWORD", SMSConfiguration.SmsPassword);
                sURL.Replace(":SMS_SENDER", SMSConfiguration.SmsSender);
                sURL.Replace(":SMS_TYPE", SMSConfiguration.SmsStype);


                SMSConfiguration.SmsUrl = sURL.ToString();
                SMSConfiguration.MarketingUrl = markURL.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        static SmsConfig()
        {
            loadSmsConfig();
        }

        public static SmsConfig getSMSConfig()
        {
            if (SMSConfiguration == null)
            {
                loadSmsConfig();
            }
            return SMSConfiguration;
        }


    }
}
