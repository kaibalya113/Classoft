using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.BLL
{
    public class TestingSampleHandler
    {
        public static Boolean isFrmmrktng = false;
        public static Boolean sendSampleSMS(string ContactNo, bool sendSms, string smsBody)
        {
            isFrmmrktng = false;
            try
            {
                Info.SmsConfig smsconfig = Info.SmsConfig.getSMSConfig();

                bool success = MailHandler.sendSMS(smsconfig, smsBody, ContactNo, isFrmmrktng, "TestingSMS");
                if (success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        public static Boolean sendSampleEmail(string emailID, bool sendEmail, string emailBody)
        {
            try
            {
                

                List<string> lstAdd = new List<string>();
                lstAdd.Add(emailID);
                bool isSent = MailHandler.sendEmail( emailBody, lstAdd, "Testing Sample ");
                if (isSent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("This property is not supported for protocols that do not use URI."))
                {
                    return false;
                }
               else if (ex.Message.EndsWith("which was not supplied."))
                {
                    throw ex;
                }
                else
                {
                    return false;
                    throw ex;
                }
            }
        }
        public static Boolean sendIncomeMail(string emailID, bool sendEmail, string emailBody,string attachment)
        {
            try
            {
                

                List<string> lstAdd = new List<string>();
                lstAdd.Add(emailID);
                List<string> lstAttch = new List<string>();
                lstAdd.Add(attachment);
                bool isSent = MailHandler.sendEmail(emailBody, lstAdd, "Profit/Loss for Expense and Income ",lstAttch);
                if (isSent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("This property is not supported for protocols that do not use URI."))
                {
                    return false;
                }
                else if (ex.Message.EndsWith("which was not supplied."))
                {
                    throw ex;
                }
                else
                {
                    return false;
                    throw ex;
                }
            }
        }
    }
}
