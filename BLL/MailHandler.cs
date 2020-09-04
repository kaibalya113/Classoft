using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using ClassManager.Info.Reporting;
using ClassManager.Info;
namespace ClassManager.BLL
{
    public class MailHandler
    {
        //Mohan(25-July-2017.To store sent and not sent Items. 
        public static DataTable smsReport = new DataTable();

        public static void addColumnstoDatatable()
        {
            if (smsReport.Columns.Count == 0)
            {
                DataColumn[] columns = new DataColumn[] { new DataColumn { ColumnName = "Date" }, new DataColumn { ColumnName = "MobileNo" }, new DataColumn { ColumnName = "Message" }, new DataColumn { ColumnName = "Status" } };

                smsReport.Columns.AddRange(columns);
            }
        }


        public static Boolean isFrmmrktng = false;

        public static bool sendOutstandingFeesNotification(List<Int32> lstAdmsnNo, DateTime date, bool sendMail, bool sendSms, int branchId, DateTime? toDate = null)
        {
            Dictionary<int, List<DueNotification>> studentDues = new Dictionary<int, List<DueNotification>>();

            List<Info.DueNotification> lstStudent = new List<Info.DueNotification>();
            string outstandingFeesTemplateEmail;
            string outstandingFeesTemplateSMS;
            isFrmmrktng = false;
            string branchID = branchId.ToString();
            bool EmailSentStatus = false;
            bool SMSSentStatus = false;
            string emailSubject = "Notification of Outstanding Fees";
            try
            {


                if (SysParam.getValue<bool>(SysParam.Parameters.SEND_OUTSTANDINGFEES_SMS))
                {
                    foreach (Int32 admisionno in lstAdmsnNo)
                    {
                        studentDues.Add(admisionno, BLL.FeesHandller.getOutstandingFeesDetails(branchID, date, admisionno.ToString(), toDate));
                    }
                    
                    

                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //Get email / sms template

                    outstandingFeesTemplateEmail = Template.getValue<string>(Info.TemplateType.OUTSTANDINGFEESEMAIL);
                    outstandingFeesTemplateSMS = Template.getValue<string>(Info.TemplateType.OUTSTANDINGFEESSMS);

                    //Traversing each student
                    foreach (KeyValuePair<int, List<DueNotification>> due in studentDues)
                    {
                        List<DueNotification> currentStudentDue = due.Value;
                        DueNotification student = currentStudentDue[0];

                        decimal totalTodaysDue = currentStudentDue.Sum(studdue => studdue.TodaysDue);
                        decimal totalDue = currentStudentDue.Sum(studdue => studdue.TotalDue);


                        //list of email address
                        if (totalDue > 0)
                        {

                            if (student.EmailId != null && student.EmailId != "")
                            {
                                List<string> lstEmlAddress = new List<string>();
                                lstEmlAddress.Add(student.EmailId);


                                //Email content
                                StringBuilder emailBody = new StringBuilder(outstandingFeesTemplateEmail.ToString());
                                emailBody.Replace(":date", date.ToShortDateString());
                                emailBody.Replace(":parent_name", (student.ParentName == "") ? "Parents" : student.ParentName);

                                emailBody.Replace(":Name", (student.StudentName == "") ? " your child" : student.StudentName);
                                // emailBody.Replace(":standard", student.Standard.StandardName);
                                emailBody.Replace(":outstanding_fees", totalTodaysDue.ToString());
                                //  emailBody.Replace(":outstanding_fees", student.Fees.OutstandingFees.ToString());
                                emailBody.Replace(":CLASS_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS));
                                emailBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                                emailBody.Replace(":EMAIL_SIGNATURE_FEES", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_SIGNATURE_FEES));
                                emailBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));


                                if (sendMail == true)
                                {
                                    EmailSentStatus = EmailSentStatus && MailHandler.sendEmail(emailBody.ToString(), lstEmlAddress, emailSubject);
                                }
                            }
                            if (student.PhnNO != null && student.PhnNO != "")
                            {
                                //list of contact no
                                List<string> lstContactNo = new List<string>();
                                lstContactNo.Add(student.PhnNO);

                                //SMS content
                                StringBuilder smsBody = new StringBuilder(outstandingFeesTemplateSMS.ToString());
                                smsBody.Replace(":parent_name", (student.ParentName == "") ? "Parents" : student.ParentName);
                                smsBody.Replace(":Name", (student.StudentName == "") ? " your child" : student.StudentName);
                                smsBody.Replace(":date", Common.Formatter.FormatDate(date));
                                //smsBody.Replace(":total_paid", student.Fees.FeesPaid.ToString());
                                //smsBody.Replace(":outstanding_fees", student.Fees.OutstandingFees.ToString());
                                smsBody.Replace(":outstanding_fees", totalTodaysDue.ToString());
                                smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                smsBody.Replace(":CLASS_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS));
                                smsBody.Replace(":total", totalDue.ToString());
                                smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                                smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));


                                if (sendSms == true)
                                {
                                    SMSSentStatus = MailHandler.sendSMS(smsConfig, smsBody.ToString(), student.PhnNO, false, "OutStandingFeesSMS") && SMSSentStatus;
                                }
                            }
                        }

                    }

                }
                return EmailSentStatus && SMSSentStatus;
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }



        public static Boolean sendFeesPayment(FeeReceiptReportData objFeeReceipt, bool sendSms, bool sendMail, String branchName)
        {

            try
            {

                bool allowtosndFeesSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_FEES_SMS);
                Boolean sendStatus = false;


                string FeesTemplateEmail;
                string FeesTemplateSMS;
                isFrmmrktng = false;

                string emailSubject = "Fees Payment Details";

                //Get sms config
                Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                //Get email sms template
                FeesTemplateEmail = Template.getValue<string>(Info.TemplateType.FEESEMAIL);
                FeesTemplateSMS = Template.getValue<string>(Info.TemplateType.FEESSMS);

                List<string> listEmail = new List<string>();

                //Traversing each student
                if (objFeeReceipt.EmailId != null && objFeeReceipt.EmailId != "" || objFeeReceipt.Email != null)
                {
                    listEmail.Add(objFeeReceipt.Email);
                    listEmail.Add(objFeeReceipt.EmailId);
                }

                //Email content
                StringBuilder emailBody = new StringBuilder(FeesTemplateEmail.ToString());
                //emailBody.Replace(":date", System.DateTime.Now.Date.ToString());
                emailBody.Replace(":date", objFeeReceipt.PaymentDate.ToString());

                emailBody.Replace(":parent_name", objFeeReceipt.StudentName);
                if (objFeeReceipt.StudentName == "")
                {
                    emailBody.Replace("Dear", "Dear Member");
                }
                else
                {
                    emailBody.Replace(":Name", objFeeReceipt.StudentName);
                }

                //This is required for Gym because mail will be sent to Members intead of being them sent to parents
                //emailBody.Replace(":studentName", objFeeReceipt.StudentName);

                emailBody.Replace(":amountPaid", objFeeReceipt.TotalFees.ToString());


                //emailBody.Replace(":month", objFeeReceipt.InstMonth.ToString());

                //changed on 03/01/2017 because null value was produced here
                Common.NumberToMonth.Months paymentMonth = (Common.NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (objFeeReceipt.PaymentDate.Month).ToString());
                emailBody.Replace(":month", paymentMonth.ToString());
                if (objFeeReceipt.ReceiptNo != null)
                {
                    emailBody.Replace(":receiptNo", objFeeReceipt.ReceiptNo.ToString());
                }
                if (objFeeReceipt.BankTransfer != null)
                {
                    emailBody.Replace(":receiptNo", objFeeReceipt.ReceiptNo.ToString());
                }

                emailBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));
                emailBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                emailBody.Replace(":EMAIL_SIGNATURE_FEES", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_SIGNATURE_FEES));

                emailBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));


                //SMS content
                StringBuilder smsBody = new StringBuilder(FeesTemplateSMS.ToString());


                //TODO: :amountPaid variable to be replaced like "3000 (1000 By Cash and 2000 by cheque (CHeque details))
                string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                if (name == "Gym")
                {
                    smsBody.Replace(":paymentDetails", "Payment Details:" + System.Environment.NewLine + "Dear " + System.Environment.NewLine + " Fees of amount " + Common.Formatter.FormatCurrency(objFeeReceipt.TotalFees) + " is paid successfully by CASH. ");
                    smsBody.Replace("Dear", "Dear " + objFeeReceipt.StudentName + ",");

                }
                else
                {
                    smsBody.Replace(":paymentDetails", "Payment Details:" + System.Environment.NewLine + "Dear " + objFeeReceipt.ParentName + System.Environment.NewLine + " Fees of amount " + Common.Formatter.FormatCurrency(objFeeReceipt.TotalFees) + " is paid successfully by CASH. ");
                    if (objFeeReceipt.ParentName.Trim() == "")
                    {
                        smsBody.Replace("Dear", "Dear Parent,");
                    }
                }
                if (objFeeReceipt.Cheques != null && objFeeReceipt.Cheques.Count > 0)
                {
                    decimal chequeAmount = objFeeReceipt.Cheques.Sum(chq => chq.Amount);
                    if (objFeeReceipt.CashPayment > 0)
                    {
                        smsBody.Replace(" by CASH.", "." + Common.Formatter.FormatCurrency(objFeeReceipt.CashPayment) + " by CASH and " + Common.Formatter.FormatCurrency(chequeAmount) + " by CHEQUE." + System.Environment.NewLine);
                    }
                    else
                    {
                        smsBody.Replace(" by CASH.", "." + Common.Formatter.FormatCurrency(chequeAmount) + " by CHEQUE." + System.Environment.NewLine);
                    }
                    foreach (Cheque objChe in objFeeReceipt.Cheques)
                    {
                        if (!smsBody.ToString().Contains("ChequeDetails:"))
                        {
                            smsBody.Append("ChequeDetails:" + System.Environment.NewLine);
                        }
                        smsBody.Append(objChe.Bank + ", " + "Amount:" + objChe.Amount + ", " + "Date:" + Common.Formatter.FormatDate(objChe.Date.Value) + System.Environment.NewLine);
                    }
                }

                ///01 dec


                if (objFeeReceipt.BankTransfer != null && objFeeReceipt.BankTransfer.Count > 0)
                {
                    decimal TransferAmount = objFeeReceipt.BankTransfer.Sum(bank => bank.Amount);
                    smsBody.Replace(" by CASH.", " " + " by BankTransfer." + System.Environment.NewLine);
                    //foreach (PaymentDetails objdetails in objFeeReceipt.BankTransfer)
                    //{
                    //    if (!smsBody.ToString().Contains("BankTransfer Details:"))
                    //    {
                    //        smsBody.Append("BankTranfer Details:" + System.Environment.NewLine);
                    //    }
                    //    smsBody.Append("Amount:" + Common.Formatter.FormatCurrency(objdetails.Amount) + ", " + "Date:" + Common.Formatter.FormatDate(objdetails.PaymentDate) + System.Environment.NewLine);
                    //}
                }



                ///01 dec

                if (objFeeReceipt.CashPayment == 0)
                {
                    smsBody.Replace("Rs. 0.00 by CASH and ", "");
                }
                if (objFeeReceipt.TotalOutstanding != 0)
                {

                    bool append_Outst_fee_msg = SysParam.getValue<bool>(SysParam.Parameters.SEND_OUTST_FEES_IN_SMS);
                    if (append_Outst_fee_msg == true)
                    { smsBody.Append("Outstanding Fees is " + Common.Formatter.FormatCurrency(objFeeReceipt.TotalOutstanding) + "."); }

                }
                sendStatus = false;

                if (sendSms == true && allowtosndFeesSMS == true)
                {
                    try
                    {
                        String contactnos;

                        if(objFeeReceipt.ContactNo  == objFeeReceipt.FatherContactNo)
                        {
                            contactnos = objFeeReceipt.ContactNo;
                        }
                        else
                        {
                            contactnos = objFeeReceipt.ContactNo;
                        }
                        sendStatus = MailHandler.sendSMS(smsConfig, smsBody.ToString(), contactnos, false, "FeesPaymentDetailsSMS");
                        NotificationHandler.notifyFeesPayment(objFeeReceipt, branchName);
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "Send SMS");
                        sendStatus = false;
                    }
                }
                if (sendMail == true)
                {
                    try
                    {
                        sendStatus = MailHandler.sendEmail(emailBody.ToString(), listEmail, emailSubject, objFeeReceipt.attachments);
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "Send Email");
                        sendStatus = false;
                    }
                }
                //return sendStatus;

                return sendStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // send invoice Email


        public static Boolean sendInvoiceMail(FeeReceiptReportData objFeeReceipt, bool sendSms, bool sendMail, String branchName)
        {

            try
            {


                Boolean sendStatus = false;

                {
                    string FeesTemplateEmail;

                    string emailSubject = "Invoice for Package";


                    //Get email sms template
                    FeesTemplateEmail = Template.getValue<string>(Info.TemplateType.INVOICEMAIL);

                    List<string> listEmail = new List<string>();
                    //  listEmail.Add("pawarashvini28@gmail.com");
                    //Traversing each student
                    if (objFeeReceipt.EmailId != null && objFeeReceipt.EmailId != "")
                    {
                        listEmail.Add(objFeeReceipt.EmailId);
                    }

                    //Email content
                    StringBuilder emailBody = new StringBuilder(FeesTemplateEmail.ToString());
                    //emailBody.Replace(":date", System.DateTime.Now.Date.ToString());
                    emailBody.Replace(":date", objFeeReceipt.PaymentDate.ToString());

                    emailBody.Replace(":parent_name", objFeeReceipt.StudentName);
                    if (objFeeReceipt.StudentName == "")
                    {
                        emailBody.Replace("Dear", "Dear Member");
                    }


                    Common.NumberToMonth.Months paymentMonth = (Common.NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (objFeeReceipt.PaymentDate.Month).ToString());
                    emailBody.Replace(":month", paymentMonth.ToString());
                    if (objFeeReceipt.ReceiptNo != null)
                    {
                        emailBody.Replace(":receiptNo", objFeeReceipt.ReceiptNo.ToString());
                    }
                    if (objFeeReceipt.BankTransfer != null)
                    {
                        emailBody.Replace(":receiptNo", objFeeReceipt.ReceiptNo.ToString());
                    }
                    emailBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));
                    emailBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                    emailBody.Replace(":EMAIL_SIGNATURE_FEES", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_SIGNATURE_FEES));
                    emailBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));

                    sendStatus = false;


                    if (sendMail == true)
                    {
                        try
                        {
                            sendStatus = MailHandler.sendEmail(emailBody.ToString(), listEmail, emailSubject, objFeeReceipt.attachments);
                        }
                        catch (Exception ex)
                        {
                            Common.Log.LogError(ex, "Send Email");
                            sendStatus = false;
                        }
                    }

                }
                return sendStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //send advertise sms
        public static Boolean sendAdvertiseSms(List<Info.Marketing> marketing, bool sendSms, bool istrans, string messageBody)
        {

            string advertiseSMS;

            //Get sms config
            Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
            //Get sms template

            //Traversing each student

            foreach (Info.Marketing mid in marketing)
            {

                //list of contact no
                List<string> lstContactNo = new List<string>();

                if (mid.ContactNo != null && mid.ContactNo != "")
                {
                    lstContactNo.Add(mid.ContactNo);
                }
                else
                {
                    continue;
                }

                //SMS content
                StringBuilder smsBody = new StringBuilder(messageBody);
                smsBody.Replace(":Name", mid.Name);
                smsBody.Replace(":streamName", mid.Group);
                smsBody.Replace(":MId", mid.Id.ToString());
                smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                smsBody.Replace(":CLASS_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS));
                smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));
                if (sendSms == true)
                {
                    if (istrans == false)
                    {
                        MailHandler.sendSMS(smsConfig, smsBody.ToString(), mid.ContactNo, true, "MarketingSMS");
                    }
                    else
                    {
                        MailHandler.sendSMS(smsConfig, smsBody.ToString(), mid.ContactNo, false, "MarketingSMS");

                    }
                }

            }
            return true;
        }

        //Get template
        public static string getTemplate(Info.TemplateType templateType)
        {
            try
            {
                SqlCommand com = new SqlCommand("select TEMP_TEMPLATE from TEMPLATE where TEMP_TYPE = @Type");
                com.Parameters.Add("@Type", SqlDbType.VarChar).Value = templateType.ToString();
                object obj = DAL.Sqlhelper.ExeScaler(com);

                return obj.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed please try later \n" + ex.Message);
                //throw new Exception("Template not found" + ex.Message);
            }
        }

        //send email 
        public static bool sendEmail(string mailBody, List<string> lstEmailAddress, string subject, List<string> attachments = null)
        {
            try
            {
                Info.SmsParameter objSMS = new Info.SmsParameter();
                objSMS.ToSMS = "NONE";
                objSMS.Body = mailBody;
                objSMS.Type = "";
                objSMS.SendTime = System.DateTime.Now;
                objSMS.ResponseID = "";
                objSMS.Template = "Email";
                //   objSMS.ToEmail = "classesmanager@gmail.com";
                MailMessage mail = new MailMessage();


                mail.From = new MailAddress(EmailConfig.EmailID);
                MailAddress copy = new MailAddress("classesmanager@gmail.com");
                mail.CC.Add(copy);
                foreach (String emailAddress in lstEmailAddress)
                {
                    if (emailAddress != null & emailAddress != "")
                    {
                        mail.To.Add(new MailAddress(emailAddress));
                        objSMS.ToEmail = emailAddress;
                    }
                    else
                    {

                    }
                }

                mail.Subject = subject;
                mail.Body = mailBody;

                if (attachments != null && attachments.Count > 0)
                {
                    foreach (String filePath in attachments)
                    {
                        if (System.IO.File.Exists(filePath))
                        {
                            mail.Attachments.Add(new Attachment(filePath));
                        }

                    }
                }

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = EmailConfig.HostName;
                smtp.Port = EmailConfig.PortNumber;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;


                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
                credential.UserName = EmailConfig.UsernameEmail;
                credential.Password = EmailConfig.PasswordEmail;

                smtp.Credentials = credential;

                if (mail.To.Count > 0)
                {
                    try
                    {
                        smtp.Send(mail);
                        objSMS.Status = "Sent";
                        saveSMSDetails(objSMS);
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
                            objSMS.Status = "Failed";
                            saveSMSDetails(objSMS);
                            return false;
                        }
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                //if (ex.Message.Equals("Procedure or function 's_pr_save_sms_details' expects parameter '@sent_status', ))
                //{
                //    throw ex;
                //}
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
                    Common.Log.LogError(ex, "Send Email");
                    return false;
                }
            }
            //return true;
        }

        //send sms
        public static bool sendSMS(Info.SmsConfig smsConfig, string smsBody, string ContactNo, bool isPromotional, string Type, bool Resend = false)
        {
            //Mohan.(25-July-2017).Adding Columns To Static DataTable.
            addColumnstoDatatable();
            int rtnCode = 0;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    Info.SmsParameter objSMS = new Info.SmsParameter();
                    if (Resend == false)
                    {
                        rtnCode = BLL.NotificationHandler.checkSMSSent(ContactNo, smsBody);
                    }
                    if (rtnCode != 1)
                    {
                        bool allow = Info.SysParam.getValue<bool>(SysParam.Parameters.ALLOW_TO_SEND_SMS);
                        Boolean status = true;
                        if (allow)
                        {
                            //Info.SmsParameter objSMS = new Info.SmsParameter();

                            Common.Log.LogError("Allow sms true", Common.ErrorLevel.INFORMATION);

                            StringBuilder smsURL;
                            if (isPromotional == true)
                            {
                                smsURL = new StringBuilder(smsConfig.MarketingUrl);
                                objSMS.Type = "SDND";    
                            }
                            else
                            {
                                smsURL = new StringBuilder(smsConfig.SmsUrl);
                                objSMS.Type = "DND";
                            }

                            StringBuilder tempUrl = new StringBuilder(smsURL.ToString());
                            tempUrl.Replace(":MOBILE_NO", ContactNo.ToString());
                            tempUrl.Replace(":SMS_BODY", smsBody.ToString());
                            string result = string.Empty;

                            try
                            {
                                result = client.DownloadString(tempUrl.ToString());
                            }
                            catch (Exception ex)
                            {
                                status = false;
                            }

                            result = result + " ";

                            string[] lstResults = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] mobileNos = ContactNo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);


                            for (int i = 0; i < mobileNos.Length; i++)
                            {
                                objSMS = new SmsParameter();
                                objSMS.ToSMS = mobileNos[i];
                                objSMS.Body = smsBody;
                                objSMS.SendTime = System.DateTime.Now;
                                objSMS.ResponseID = "";
                                objSMS.ToEmail = "";
                                objSMS.Template = Type;
                                if (status == true)
                                {
                                    if (i < lstResults.Length)
                                    {
                                        objSMS.ResponseID = lstResults[i];
                                        objSMS.Status = "SENT";
                                    }
                                    else
                                    {
                                        objSMS.Status = "NA";
                                    }
                                }
                                else
                                {
                                    if (lstResults.Length > i)
                                    {
                                        objSMS.Status = lstResults[i];
                                    }
                                    else
                                    {
                                        objSMS.Status = "STATUS NOT RECEIVED";
                                    }
                                }
                                if (isPromotional == true)
                                {
                                    objSMS.Type = "SDND";
                                }
                                else
                                {
                                    objSMS.Type = "DND";
                                }
                                smsReport.Rows.Add(new object[] { objSMS.SendTime.ToString("dd-MMM-yyyy"), objSMS.ToSMS, objSMS.Body, objSMS.Status });
                                saveSMSDetails(objSMS);
                            }
                            return status;
                        }
                        else
                        {
                            objSMS.Body = smsBody;
                            objSMS.SendTime = DateTime.Now;
                            objSMS.ToSMS = ContactNo;
                            objSMS.Status = "ALLOW_TO_SEND_SMS : " + SysParam.getValue<string>(SysParam.Parameters.ALLOW_TO_SEND_SMS);
                            objSMS.ResponseID = "";
                            objSMS.Type = "";
                            objSMS.ToEmail = "";
                            objSMS.Template = Type;
                            //  smsReport.Rows.Add(new object[] { objSMS.SendTime.ToString("dd-MMM-yyyy"), objSMS.ToSMS, objSMS.Body, objSMS.Status });
                            smsReport.Rows.Add(new object[] { objSMS.SendTime, objSMS.ToSMS, objSMS.Body, objSMS.Status });
                            saveSMSDetails(objSMS);
                            return false;
                        }
                    }
                    else
                    {
                        objSMS.Body = smsBody;
                        objSMS.SendTime = DateTime.Now;
                        objSMS.ToSMS = ContactNo;
                        objSMS.Status = "Already Sent";
                        objSMS.ResponseID = "";
                        objSMS.Type = "";
                        objSMS.ToEmail = "";
                        objSMS.Template = Type;
                        smsReport.Rows.Add(new object[] { objSMS.SendTime.ToString("dd-MMM-yyyy"), objSMS.ToSMS, objSMS.Body, objSMS.Status });
                        saveSMSDetails(objSMS);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Common.Log.LogError(ex, "Send SMS");
                    return false;
                }
            }
        }


        public static bool sendAttendanceSMS(int checkIn, Student objStudent)
        {
            try
            {
                if (checkIn == 1)
                {
                    return sendCheckInSMS(objStudent);
                }
                else if (checkIn == 2)
                {
                    return sendCheckoutSMS(objStudent);
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                return false;
            }

        }

        private static bool sendCheckoutSMS(Student objStudent)
        {
            try
            {
                if (SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_OUT_SMS) == true)
                {
                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.CHECKOUTSMS);

                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                    smsBody.Replace(":Name", objStudent.Fname);
                    smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                    smsBody.Replace(":date", DateTime.Now.ToShortTimeString());
                    smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));


                    return (MailHandler.sendSMS(smsConfig, smsBody.ToString(), objStudent.FatherContactNo, false, "CHECKOUTSMS"));

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool sendCheckInSMS(Student objStudent)
        {
            try
            {
                if (SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_IN_SMS) == true)
                {
                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.CHECKINSMS);
                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                    smsBody.Replace(":Name", objStudent.Fname);
                    smsBody.Replace(":date", DateTime.Now.ToShortTimeString());
                    smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                    smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));

                    return (MailHandler.sendSMS(smsConfig, smsBody.ToString(), objStudent.FatherContactNo, false, "CHECKINSMS"));
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool sendEnquirySms(string studentName, string contactNo, int enquiryID, string Course, string branchName)
        {
            try
            {
                bool allowtosndEnquirySMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_ENQ_SMS);
                if (allowtosndEnquirySMS)
                {
                    isFrmmrktng = false;
                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    // smsTemplate = MailHandler.getTemplate(Info.TemplateType.ENQUIRYSMS);
                    smsTemplate = Template.getValue<string>(Info.TemplateType.ENQUIRYSMS);
                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                    smsBody.Replace(":Name", studentName);
                    smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                    smsBody.Replace(":Course", Course);
                    smsBody.Replace(":CLASS_ADDRESS", branchName);
                    smsBody.Replace(":enquiryID", enquiryID.ToString());
                    smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                    smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));


                    if (MailHandler.sendSMS(smsConfig, smsBody.ToString(), contactNo, false, "EnquirySMS"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;

            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Send Enquiry message");
                throw ex;
            }

        }

        public static bool sendFeesSms(string studentName, string contactNo, String receiptNo)
        {
            try
            {
                bool allowtosndFeesSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_FEES_SMS);
                if (allowtosndFeesSMS)
                {
                    isFrmmrktng = false;
                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.FEESSMS);
                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                    smsBody.Replace(":Name", studentName);
                    smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                    smsBody.Replace(":CLASS_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS));

                    smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                    smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));

                    if (MailHandler.sendSMS(smsConfig, smsBody.ToString(), contactNo, false, "EnquirySMS"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Send Fees message");
                throw ex;
            }

        }

        //send registration sms by sayali
        public static bool sendRegistrationSms(Student objStudent, string studName, Decimal totalFees, string rollNo, string phnNo, String branchName)
        {
            try
            {
                bool allowtosndRegistrationSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_REG_SMS);
                if (allowtosndRegistrationSMS)
                {
                    isFrmmrktng = false;
                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.REGISTRATION);
                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                    smsBody.Replace(":Name", studName);
                    smsBody.Replace(":cources", objStudent.NewCourse);
                    smsBody.Replace(":courseType", objStudent.Stream.ToString());
                    smsBody.Replace(":BranchName", branchName);
                    smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                    smsBody.Replace(":totalFees", totalFees.ToString());
                    smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                    smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));
                    phnNo = objStudent.ContactNo;
                    bool result = (MailHandler.sendSMS(smsConfig, smsBody.ToString(), phnNo, false, "RegistrationSMS"));

                    NotificationHandler.notifyNewAdmission(objStudent, branchName);
                    return result;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Send Registration message");
                throw ex;
            }

        }


        public static bool sendSMS(SmsConfig smsConfig, Dictionary<string, string> smsdata, bool isPromotional, string Type)
        {
            try
            {
                bool isSent = false;
                foreach (KeyValuePair<string, string> data in smsdata)
                {
                    isSent = sendSMS(smsConfig, data.Value, data.Key, isPromotional, Type);
                }
                return Common.Utility.retBoolStatus(isSent);
                //return true; //#TODO : Return code should be based on actual status
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Send sendSMS message");
                throw;
            }
        }

        internal static bool sendSMS(SmsConfig smsConfig, List<KeyValuePair<string, string>> smsData, bool isPromotional, string Type)
        {
            try
            {
                bool isSent = false;
                foreach (KeyValuePair<string, string> data in smsData)
                {
                    //sendSMS(smsConfig, data.Value, data.Key, isPromotional);
                    isSent = sendSMS(smsConfig, data.Value, data.Key, isPromotional, Type);
                    //if (isSent)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
                return Common.Utility.retBoolStatus(isSent);
                //return true; //#TODO : Return code should be based on actual status
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Send sendSMS message");
                throw;
            }
        }


        public static bool saveSMSDetails(SmsParameter objSMS)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_save_SMS_Details");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branch_id", SqlDbType.Int).Value = SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID);
                com.Parameters.Add("@contactno", SqlDbType.VarChar).Value = objSMS.ToSMS;
                com.Parameters.Add("@email_id", SqlDbType.VarChar).Value = objSMS.ToEmail;
                com.Parameters.Add("@sms_body", SqlDbType.VarChar).Value = objSMS.Body;
                com.Parameters.Add("@type", SqlDbType.VarChar).Value = objSMS.Type;
                com.Parameters.Add("@sms_sent_time", SqlDbType.DateTime).Value = objSMS.SendTime;
                com.Parameters.Add("@sms_code", SqlDbType.VarChar).Value = objSMS.ResponseID;
                com.Parameters.Add("@sent_status", SqlDbType.VarChar).Value = objSMS.Status;
                com.Parameters.Add("@Template", SqlDbType.VarChar).Value = objSMS.Template;
                com.Parameters.Add("@smsID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DAL.Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "Send saveSMSDetails ");
                throw ex;
            }
        }



        public static Boolean sendAdvetiseForExpiredPackage(DataTable dt, bool sendSms, bool istrans, string messageBody)
        {
            try
            {
                List<KeyValuePair<string, string>> smsData = new List<KeyValuePair<string, string>>();
                string advertiseSMS;
                string contactNo = null;
                bool isSent = false;
                //Get sms config
                Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                //Get sms template

                //Traversing each student


                if (dt.Rows.Count != 0)
                {

                    string[] TobeDistinct = { "AdmissionNo" };
                    DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);


                    foreach (DataRow row in dtDistinct.Rows)
                    {
                        DataRow[] dr = dt.Select("AdmissionNo=" + row.ItemArray[0]);

                        foreach (DataRow actualrecords in dr)
                        {
                            StringBuilder smsBody = new StringBuilder(messageBody);
                            smsBody.Replace(":Name", actualrecords.ItemArray[1].ToString());
                            smsBody.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                            smsBody.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[4])).ToString("dd-MMM-yyyy"));
                            smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                            if (contactNo != actualrecords.ItemArray[2].ToString())
                            {
                                contactNo = actualrecords.ItemArray[2].ToString();
                            }
                            KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, smsBody.ToString());

                            contactNo = null;
                            if (!smsData.Contains(items))
                            {
                                smsData.Add(items);
                            }
                            isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ToBeExpiredPackageSMS");
                            smsData.Clear();
                        }

                    }
                }
                return Common.Utility.retBoolStatus(isSent);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "sendAdvetiseForExpiredPackage");
                throw;
            }


        }


        //                foreach (Info.Marketing mid in marketing)
        //    {

        //        //list of contact no
        //        List<string> lstContactNo = new List<string>();

        //        if (mid.ContactNo != null && mid.ContactNo != "")
        //        {
        //            lstContactNo.Add(mid.ContactNo);
        //        }
        //        else
        //        {
        //            continue;
        //        }

        //        //SMS content
        //        StringBuilder smsBody = new StringBuilder(messageBody);
        //        smsBody.Replace(":Name", mid.Name);
        //        smsBody.Replace(":streamName", mid.Group);
        //        smsBody.Replace(":MId", mid.Id.ToString());
        //        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
        //        smsBody.Replace(":CLASS_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS));
        //        smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
        //        smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));
        //        if (sendSms == true)
        //        {
        //            if (istrans == false)
        //            {
        //                MailHandler.sendSMS(smsConfig, smsBody.ToString(), mid.ContactNo, true, "MarketingSMS");
        //            }
        //            else
        //            {
        //                MailHandler.sendSMS(smsConfig, smsBody.ToString(), mid.ContactNo, false, "MarketingSMS");

        //            }
        //        }

        //    }
        //    return true;
        //}


        // For ExpiredPackage SMS

        public static bool ExpirePackageSMS(DataTable dt, int branchId)
        {
            List<KeyValuePair<string, string>> smsData = new List<KeyValuePair<string, string>>();
            string ExpiredPackage;
            isFrmmrktng = false;
            string contactNo = null;
            string branchID = branchId.ToString();
            bool SMSSentStatus = false;
            bool isSent = false;
            try
            {
                if (dt.Rows.Count != 0)
                {
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                    string[] TobeDistinct = { "AdmissionNo" };
                    DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);


                    foreach (DataRow row in dtDistinct.Rows)
                    {

                        //   GoingToExpireTemplateSMS = Template.getValue<string>(Info.TemplateType.GOINGTOEXPIRE_PACKAGE_SMS); ;
                        ExpiredPackage = Template.getValue<string>(Info.TemplateType.EXPIRED_PACKAGE_SMS);
                        // StringBuilder TobeExpSMS = new StringBuilder(GoingToExpireTemplateSMS.ToString());
                        StringBuilder expiredSMS = new StringBuilder(ExpiredPackage.ToString());

                        DataRow[] dr = dt.Select("AdmissionNo=" + row.ItemArray[0]);

                        foreach (DataRow actualrecords in dr)
                        {
                            //if (Convert.ToDateTime(actualrecords.ItemArray[5]) >= DateTime.Now)
                            //{
                            //    bool ToBeExpired = SysParam.getValue<bool>(SysParam.Parameters.SEND_TOBE_EXPIRY_MSG);
                            //    if (ToBeExpired == true)
                            //    {

                            //        TobeExpSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                            //        TobeExpSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                            //        TobeExpSMS.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[4])).ToString("dd-MMM-yyyy"));
                            //        TobeExpSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                            //        if (contactNo != actualrecords.ItemArray[2].ToString())
                            //        {
                            //            contactNo = actualrecords.ItemArray[2].ToString();
                            //        }
                            //        KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, TobeExpSMS.ToString());

                            //        contactNo = null;
                            //        if (!smsData.Contains(items))
                            //        {
                            //            smsData.Add(items);
                            //        }
                            //        isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ToBeExpiredPackageSMS");
                            //        smsData.Clear();
                            //    }



                            //    else
                            //    {
                            bool Expired = SysParam.getValue<bool>(SysParam.Parameters.SEND_EXPIRY_MSG);
                            if (Expired == true)
                            {
                                expiredSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                                expiredSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                                expiredSMS.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[5])).ToString("dd-MMM-yyyy"));
                                expiredSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                if (contactNo != actualrecords.ItemArray[2].ToString())
                                {
                                    contactNo = actualrecords.ItemArray[2].ToString();
                                }
                                KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, expiredSMS.ToString());

                                contactNo = null;
                                if (!smsData.Contains(items))
                                {
                                    smsData.Add(items);
                                }
                                isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ExpiredPackageSMS");
                                smsData.Clear();
                                //}
                                //}
                            }
                        }
                    }
                }
                return Common.Utility.retBoolStatus(isSent);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool SendExpiredPackagesSMS(DataTable dt, int branchId)
        {
            List<KeyValuePair<string, string>> smsData = new List<KeyValuePair<string, string>>();
            string GoingToExpireTemplateSMS, ExpiredPackage;
            isFrmmrktng = false;
            string contactNo = null;
            string branchID = branchId.ToString();
            bool isSent = false;
            try
            {
                if (dt.Rows.Count != 0)
                {
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                    string[] TobeDistinct = { "AdmissionNo" };
                    DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);


                    foreach (DataRow row in dtDistinct.Rows)
                    {
                        //GoingToExpireTemplateSMS = MailHandler.getTemplate(Info.TemplateType.GOINGTOEXPIRE_PACKAGE_SMS);
                        GoingToExpireTemplateSMS = Template.getValue<string>(Info.TemplateType.GOINGTOEXPIRE_PACKAGE_SMS);
                        ExpiredPackage = Template.getValue<string>(Info.TemplateType.EXPIRED_PACKAGE_SMS);
                        StringBuilder TobeExpSMS = new StringBuilder(GoingToExpireTemplateSMS.ToString());
                        StringBuilder expiredSMS = new StringBuilder(ExpiredPackage.ToString());

                        DataRow[] dr = dt.Select("AdmissionNo=" + row.ItemArray[0]);

                        foreach (DataRow actualrecords in dr)
                        {
                            if (!actualrecords.Table.Columns.Contains("ExpiredOn") || Convert.ToDateTime(actualrecords["ExpiredOn"]) >= DateTime.Now.Date)
                            {
                                bool ToBeExpired = SysParam.getValue<bool>(SysParam.Parameters.SEND_TOBE_EXPIRY_MSG);
                                if (ToBeExpired == true)
                                {

                                    TobeExpSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                                    TobeExpSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                                    DateTime expiryDate = DateTime.Parse(actualrecords["ExpiredOn"].ToString());
                                    String expiryStr = "";
                                    if (expiryDate == DateTime.Now.Date)
                                    {
                                        expiryStr = "today";
                                    }
                                    else
                                    {
                                        expiryStr = expiryDate.ToString(Common.Formatter.DateFormat);
                                    }

                                    TobeExpSMS.Replace(":Date", expiryStr);
                                    TobeExpSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                    if (contactNo != actualrecords.ItemArray[2].ToString())
                                    {
                                        contactNo = actualrecords.ItemArray[2].ToString();
                                    }
                                    KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, TobeExpSMS.ToString());

                                    contactNo = null;
                                    if (!smsData.Contains(items))
                                    {
                                        smsData.Add(items);
                                    }
                                    isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ToBeExpiredPackageSMS");
                                    smsData.Clear();
                                }
                            }
                            else
                            {
                                bool Expired = SysParam.getValue<bool>(SysParam.Parameters.SEND_EXPIRY_MSG);
                                if (Expired == true)
                                {
                                    expiredSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                                    expiredSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                                    expiredSMS.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[4])).ToString("dd-MMM-yyyy"));
                                    expiredSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                    if (contactNo != actualrecords.ItemArray[2].ToString())
                                    {
                                        contactNo = actualrecords.ItemArray[2].ToString();
                                    }
                                    KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, expiredSMS.ToString());

                                    contactNo = null;
                                    if (!smsData.Contains(items))
                                    {
                                        smsData.Add(items);
                                    }
                                    isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ExpiredPackageSMS");
                                    smsData.Clear();

                                }
                            }
                        }
                    }
                }
                return Common.Utility.retBoolStatus(isSent);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool ToBeExpirePackageSMSAuto(DataTable dt, int branchId)
        {
            List<KeyValuePair<string, string>> smsData = new List<KeyValuePair<string, string>>();
            string GoingToExpireTemplateSMS, ExpiredPackage;
            isFrmmrktng = false;
            string contactNo = null;
            string branchID = branchId.ToString();
            bool SMSSentStatus = false;
            bool isSent = false;
            try
            {
                if (dt.Rows.Count != 0)
                {
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                    string[] TobeDistinct = { "AdmissionNo" };
                    DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);


                    foreach (DataRow row in dtDistinct.Rows)
                    {

                        GoingToExpireTemplateSMS = Template.getValue<string>(Info.TemplateType.GOINGTOEXPIRE_PACKAGE_SMS);
                        ExpiredPackage = Template.getValue<string>(Info.TemplateType.EXPIRED_PACKAGE_SMS);
                        StringBuilder TobeExpSMS = new StringBuilder(GoingToExpireTemplateSMS.ToString());
                        StringBuilder expiredSMS = new StringBuilder(ExpiredPackage.ToString());

                        DataRow[] dr = dt.Select("AdmissionNo=" + row.ItemArray[0]);

                        foreach (DataRow actualrecords in dr)
                        {
                            if (Convert.ToDateTime(actualrecords.ItemArray[5]) >= DateTime.Now.Date)
                            {
                                bool ToBeExpired = SysParam.getValue<bool>(SysParam.Parameters.SEND_TOBE_EXPIRY_MSG);
                                if (ToBeExpired == true)
                                {

                                    TobeExpSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                                    TobeExpSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                                    TobeExpSMS.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[5])).ToString("dd-MMM-yyyy"));
                                    TobeExpSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                    if (contactNo != actualrecords.ItemArray[2].ToString())
                                    {
                                        contactNo = actualrecords.ItemArray[2].ToString();
                                    }
                                    KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, TobeExpSMS.ToString());

                                    contactNo = null;
                                    if (!smsData.Contains(items))
                                    {
                                        smsData.Add(items);
                                    }
                                    isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ToBeExpiredPackageSMS");
                                    smsData.Clear();
                                }
                            }



                            else
                            {
                                bool Expired = SysParam.getValue<bool>(SysParam.Parameters.SEND_EXPIRY_MSG);
                                if (Expired == true)
                                {
                                    expiredSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                                    expiredSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                                    expiredSMS.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[4])).ToString("dd-MMM-yyyy"));
                                    expiredSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                    if (contactNo != actualrecords.ItemArray[2].ToString())
                                    {
                                        contactNo = actualrecords.ItemArray[2].ToString();
                                    }
                                    KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, expiredSMS.ToString());

                                    contactNo = null;
                                    if (!smsData.Contains(items))
                                    {
                                        smsData.Add(items);
                                    }
                                    isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ExpiredPackageSMS");
                                    smsData.Clear();

                                }
                                //{
                                //    bool Expired = SysParam.getValue<bool>(SysParam.Parameters.SEND_EXPIRY_MSG);
                                //    if (Expired == true)
                                //    {
                                //        expiredSMS.Replace(":Name", actualrecords.ItemArray[1].ToString());
                                //        expiredSMS.Replace(":PackageName", actualrecords.ItemArray[3].ToString());
                                //        expiredSMS.Replace(":Date", (Convert.ToDateTime(actualrecords.ItemArray[4])).ToString("dd-MMM-yyyy"));
                                //        expiredSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                                //        if (contactNo != actualrecords.ItemArray[2].ToString())
                                //        {
                                //            contactNo = actualrecords.ItemArray[2].ToString();
                                //        }
                                //        KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, expiredSMS.ToString());

                                //        contactNo = null;
                                //        if (!smsData.Contains(items))
                                //        {
                                //            smsData.Add(items);
                                //        }
                                //        isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ExpiredPackageSMS");
                                //        smsData.Clear();
                                //    }
                                //}
                            }
                        }
                    }
                }
                return Common.Utility.retBoolStatus(isSent);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        /// <summary>
        /// Message to be sent on Renewing a Package.Hemlata(26-Oct-2017).
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public static bool RenewPackage(string Name, string CourseName, string Phone, int branchId)
        {
            List<KeyValuePair<string, string>> smsData = new List<KeyValuePair<string, string>>();
            string RenewPackage;
            isFrmmrktng = false;
            string contactNo = null;
            string branchID = branchId.ToString();
            bool SMSSentStatus = false;
            bool isSent = false;
            try
            {
                //Get sms config
                Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                //string[] TobeDistinct = { "AdmissionNo" };
                //DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);
                // foreach (DataRow row in dtDistinct.Rows)
                // {
                RenewPackage = Template.getValue<string>(Info.TemplateType.PACKAGE_RENEWED_SMS);
                StringBuilder RenewSMS = new StringBuilder(RenewPackage.ToString());

                //  DataRow[] dr = dt.Select("AdmissionNo=" + row.ItemArray[0]);

                // foreach (DataRow actualrecords in dr)
                // {
                RenewSMS.Replace(":Name", Name.ToString());
                RenewSMS.Replace(":PackageName", CourseName.ToString());
                RenewSMS.Replace(":Date", DateTime.Now.ToString("dd-MMM-yyyy"));
                RenewSMS.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                if (contactNo != Phone.ToString())
                {
                    contactNo = Phone.ToString();
                }
                KeyValuePair<string, string> items = new KeyValuePair<string, string>(contactNo, RenewSMS.ToString());
                contactNo = null;
                if (!smsData.Contains(items))
                {
                    smsData.Add(items);
                }
                isSent = MailHandler.sendSMS(smsConfig, smsData, false, "RenewPackageSMS");
                // }
                //}
                return Common.Utility.retBoolStatus(isSent);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        //Ended for change.Hemlata(26-Oct-2017).


        private static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        {
            try
            {
                DataTable dtUniqRecords = new DataTable();
                dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
                return dtUniqRecords;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

    }
}
