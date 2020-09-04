using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using ClassManager.DAL;
using ClassManager.Info;
using ClassManager.BLL;
using System.IO;

namespace ClassManager.BLL
{
    public class NotificationHandler
    {
        static SqlCommand com;

        #region Senders

        public static DataTable sendBirthdaySMS(List<Info.Marketing> lstStudent)
        {
            try
            {
                bool allowtoSndBrthdaySMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_BDAY_SMS);

                if (allowtoSndBrthdaySMS)
                {
                    Dictionary<string, string> smsData = new Dictionary<string, string>();
                    string smsTemplate;

                    //Get sms config                
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //Traversing each student
                    foreach (Info.Marketing student in lstStudent)
                    {
                        //get template
                        smsTemplate = Template.getValue<string>(Info.TemplateType.BIRTHDAYSMS);

                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                        smsBody.Replace(":Name", student.Name);
                        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                        string Phone = student.ContactNo;

                        if (!smsData.ContainsKey(Phone))
                        {
                            smsData.Add(student.ContactNo, smsBody.ToString());
                        }

                    }

                    MailHandler.sendSMS(smsConfig, smsData, false, "BirthDaySMS");
                }

                return Common.Utility.ToDataTable<Info.Marketing>(lstStudent);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable sendAnniversarySMS(List<Marketing> lstAnniversary)
        {
            try
            {

                bool allowtosndAnnSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_ANNI_SMS);
                if (allowtosndAnnSMS)
                {
                    string smsTemplate;


                    //Get sms config                
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //Traversing each student
                    foreach (Info.Marketing student in lstAnniversary)
                    {
                        //get template
                        smsTemplate = Template.getValue<string>(Info.TemplateType.ANNIVERSARIESSMS); ;

                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                        smsBody.Replace(":Name", student.Name);
                        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                        MailHandler.sendSMS(smsConfig, smsBody.ToString(), student.ContactNo, false, "AnniversarySMS");
                    }
                }

                return ClassManager.Common.Utility.ToDataTable<Info.Marketing>(lstAnniversary);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static Boolean sendFollowupSMS(DataTable records)
        {
            try
            {
                bool allowtosndFollowUpSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_FOLLOWPUP_SMS);

                if (allowtosndFollowUpSMS)
                {
                    string smsTemplate;
                    string adminContactNo = Info.SysParam.getValue<String>(SysParam.Parameters.NOTIFY_ADMISSIONS);

                    Dictionary<string, string> smsData = new Dictionary<string, string>();

                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                    //get template

                    smsTemplate = Template.getValue<string>(Info.TemplateType.FOLLOWUPSMSTOADMIN);
                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                    //Traversing each student
                    if (records.Rows.Count > 0)
                    {
                        foreach (DataRow dr in records.Rows)
                        {
                            smsBody.Replace(":admin", "Admin");
                            // smsBody.Append("\n" + enqStudent.Fullname + " " + enqStudent.ContactNo + " " + enqStudent.Standard.StandardName +" "+ enqStudent.Standard.Stream.Name + ".\n");
                            smsBody.Append("\n" + dr.ItemArray[0] + " " + dr.ItemArray[1] + " " + dr.ItemArray[5] + " " + dr.ItemArray[6] + ".\n");
                        }


                        MailHandler.sendSMS(smsConfig, smsBody.ToString(), adminContactNo, false, "FollowUpSMSToAdmin");

                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static DataTable sendOutstandingFeesSMS(List<Info.DueNotification> lstDue)
        {
            try
            {
                bool allowtosndOutstandingSMS = Info.SysParam.getValue<Boolean>(SysParam.Parameters.SEND_OUTSTANDINGFEES_SMS);
                if (allowtosndOutstandingSMS)
                {

                    string smsTemplate;


                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.OUTSTANDINGFEESSMS); ;

                    //Traversing each student
                    foreach (Info.DueNotification todaysdue in lstDue)
                    {
                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                        if (todaysdue.TodaysDue > 0)
                        {
                            if (todaysdue.ParentName == "")
                            {
                                smsBody.Replace(":parent_name", "Parent ");
                            }
                            else
                            {
                                smsBody.Replace(":parent_name", todaysdue.ParentName);
                            }
                            //  smsBody.Replace(":total_paid", todaysdue.TotalPaid.ToString());
                            smsBody.Replace(":Name", todaysdue.StudentName);
                            smsBody.Replace(":outstanding_fees", todaysdue.TodaysDue.ToString());
                            smsBody.Replace(":date", Common.Formatter.FormatDate(DateTime.Now));
                            smsBody.Replace(":total", todaysdue.TotalDue.ToString());
                            smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                            smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                            smsBody.Replace(":EMAIL_ADDRESS", Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS));

                            MailHandler.sendSMS(smsConfig, smsBody.ToString(), todaysdue.PhnNO, false, "OutStandingFeesSMS");
                        }
                    }
                }

                return Common.Utility.ToDataTable<Info.DueNotification>(lstDue);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static Boolean sendTotalCountOfToday(DailyReport report, string Name = "")
        {
            try
            {
                bool allowtosndDailyReportSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_DAILYREPORTS_SMS);

                if (allowtosndDailyReportSMS)
                {

                    string smsTemplate;
                    string adminContactNos = Info.SysParam.getValue<String>(SysParam.Parameters.OWNER_NOS);
                    adminContactNos = adminContactNos + "," + Info.SysParam.getValue<String>(SysParam.Parameters.BRCH_HEAD);

                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    //  smsTemplate = MailHandler.getTemplate(Info.TemplateType.TOTALCOUNT);
                    smsTemplate = Template.getValue<string>(Info.TemplateType.TOTALCOUNT);
                    //SMS content
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                    
                    

                    if (report.fromDate.ToShortDateString() != report.toDate.ToShortDateString())
                    {
                        smsBody.Replace(":ToDay", "Report from " + Common.Formatter.FormatDate(report.fromDate) + " to " + Common.Formatter.FormatDate(report.toDate) + ",");
                    }
                    else
                    {
                        smsBody.Replace(":ToDay", Common.Formatter.FormatDate(report.fromDate));
                    }
                    smsBody.Replace(":branch", Name);
                   // smsBody.Replace(":branch", Namw)
                   // smsBody.Replace(":admin", SysParam.getValue<String>(SysParam.Parameters.SIR_NAME));
                    smsBody.Replace(":No_of_enquiries", report.NoOfEnq.ToString());
                    smsBody.Replace(":No_of_registration", report.NoOfReg.ToString());
                    smsBody.Replace(":No_of_feesPayment", report.NoOfFeesPaymnt.ToString());
                    smsBody.Replace(":feesCollected", report.TotalCollected.ToString());
                    smsBody.Replace(":no_of_followup", report.NoOfFollwp.ToString());
                    smsBody.Replace(":total_expence", report.TotalExpence.ToString());
                    smsBody.Replace(":otherIncome", report.OtherIncome.ToString());
                    smsBody.Replace(":ttlPrsnt", report.TotalPresents.ToString());
                    smsBody.Replace(":ttlAbsnt", report.TotalAbsents.ToString());
                    smsBody.Replace(":byCash", report.Bycash.ToString());
                    smsBody.Replace(":byCheque", report.ByCheque.ToString());
                    smsBody.Replace(":TotalOutstanding", report.TotalOutstanding.ToString());
                    List<Info.Account> objAcc = new List<Account>();
                    string branchId = SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID).ToString();
                    objAcc = BLL.AccountHandller.getAccounts(branchId);
                    List<Info.Account> objAcc1 = new List<Account>();
                    objAcc1 = BLL.AccountHandller.getAccountsIndividual(branchId, report.fromDate.ToString("yyyy-MM-dd"), report.toDate.ToString("yyyy-MM-dd"));

                   // smsBody.Append("\n A/C Balances Previous Day:");
                    foreach (Account obj in objAcc1)
                    {
                        smsBody.Append("\n" + obj.AccountName + ": " + obj.Balance);
                    }

                    smsBody.Append("\n A/C Balances:");
                    
                    foreach (Account obj in objAcc)
                    {
                        smsBody.Append("\n" + obj.AccountName + ": " + obj.Balance);
                    }
                   
                    string Appname = (SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME));
                    if (Appname == "Gym" || Appname == "Dance")
                    {
                        smsBody.Append("\nExpiry Today:" + report.TodayExpired.ToString() + "\n");
                        smsBody.Append("Total Expiry:" + report.ExpiredPackage.ToString() + "\n");

                    }
                    MailHandler.sendSMS(smsConfig, smsBody.ToString(), adminContactNos, false, "DailyReportSMS");

                }
                return true;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static bool sendAbsentMessage(DataTable absentStudents)
        {
            try
            {
                bool allowToSndAbsentSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_ABSENT_SMS);
                bool send = false;
                if (allowToSndAbsentSMS)
                {
                    string smsTemplate;

                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.ABSENTSMS);


                    foreach (DataRow dr in absentStudents.Rows)
                    {
                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                        //smsBody.Replace(":parent_name", dr["parentName"].ToString());
                        smsBody.Replace(":Name", dr["Name"].ToString());
                        smsBody.Replace("last :no_of_days days", Common.Formatter.FormatDate(Convert.ToDateTime(dr["ATTD_DATE"])));
                        //smsBody.Replace(":no_of_days", dr["absentDays"].ToString());
                        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                        smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));
                        send = MailHandler.sendSMS(smsConfig, smsBody.ToString(), dr["STMT_FATHER_CONTACT"].ToString(), false, "AbsentSMS");
                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static void sendPaymentDueNotification(List<Info.DueNotification> lstDue)
        {
            try
            {
                bool allowtosndDueSMS = Info.SysParam.getValue<Boolean>(SysParam.Parameters.SEND_DUE_NOTIFICATION);
                if (allowtosndDueSMS)
                {
                    string smsTemplate;

                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.DUE_NOTIFICATION);

                    //Traversing each student
                    foreach (Info.DueNotification dueNotify in lstDue)
                    {
                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                        if (dueNotify.ParentName == " ")
                        {
                            smsBody.Replace(":parent_name", "Parent ");
                        }
                        else
                        {
                            smsBody.Replace(":parent_name", dueNotify.ParentName);
                        }
                        smsBody.Replace(":dueAmount", dueNotify.DueAmount.ToString());
                        smsBody.Replace(":dueDate", Common.Formatter.FormatDate(dueNotify.DueDate));
                        smsBody.Replace(":Name", dueNotify.StudentName);
                        if (dueNotify.DueAmount > 0)
                        {
                            MailHandler.sendSMS(smsConfig, smsBody.ToString(), dueNotify.PhnNO, false, "DueNotificationSMS");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        #endregion

        #region Getters


        public static DailyReport getDailyReport(DateTime fromDate, DateTime toDate, string branchId)
        {
            try
            {
                DailyReport objDue = new DailyReport();

                com = new SqlCommand("s_pr_get_report");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add("@no_of_enq", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@no_of_reg", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@no_of_fcount", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@no_of_fcollected", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                com.Parameters.Add("@no_of_followup", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@total_expence", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                com.Parameters.Add("@total_other_income", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                com.Parameters.Add("@total_presents", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@total_absents", SqlDbType.Int).Direction = ParameterDirection.Output;

                com.Parameters.Add("@byCash", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@byCheque", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ExpiredPackage", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ToBeExpiredPackage", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@todayExpiry", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@totalOutstanding", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    if (com.Parameters["@no_of_enq"].Value == DBNull.Value)
                    {
                        objDue.NoOfEnq = 0;
                    }
                    else
                    {
                        objDue.NoOfEnq = Convert.ToInt32(com.Parameters["@no_of_enq"].Value);
                    }

                    if (com.Parameters["@ExpiredPackage"].Value == DBNull.Value)
                    {
                        objDue.ExpiredPackage = 0;
                    }
                    else
                    {
                        objDue.ExpiredPackage = Convert.ToInt32(com.Parameters["@ExpiredPackage"].Value);
                    }


                    if (com.Parameters["@ToBeExpiredPackage"].Value == DBNull.Value)
                    {
                        objDue.TobeExpiredPackage = 0;
                    }
                    else
                    {
                        objDue.TobeExpiredPackage = Convert.ToInt32(com.Parameters["@ToBeExpiredPackage"].Value);
                    }


                    if (com.Parameters["@todayExpiry"].Value == DBNull.Value)
                    {
                        objDue.TodayExpired = 0;
                    }
                    else
                    {
                        objDue.TodayExpired = Convert.ToInt32(com.Parameters["@todayExpiry"].Value);
                    }


                    if (com.Parameters["@totalOutstanding"].Value == DBNull.Value)
                    {
                        objDue.TotalOutstanding = 0;
                    }
                    else
                    {
                        objDue.TotalOutstanding = Convert.ToInt32(com.Parameters["@totalOutstanding"].Value);
                    }


                    if (com.Parameters["@no_of_reg"].Value == DBNull.Value)
                    {
                        objDue.NoOfReg = 0;
                    }
                    else
                    {
                        objDue.NoOfReg = Convert.ToInt32(com.Parameters["@no_of_reg"].Value);
                    }
                    if (com.Parameters["@no_of_fcount"].Value == DBNull.Value)
                    {
                        objDue.NoOfFeesPaymnt = 0;
                    }
                    else
                    {
                        objDue.NoOfFeesPaymnt = Convert.ToInt32(com.Parameters["@no_of_fcount"].Value);
                    }
                    if (com.Parameters["@no_of_fcollected"].Value == DBNull.Value)
                    {
                        objDue.TotalCollected = 0;
                    }
                    else
                    {
                        objDue.TotalCollected = Convert.ToDecimal(com.Parameters["@no_of_fcollected"].Value);
                    }
                    if (com.Parameters["@no_of_followup"].Value == DBNull.Value)
                    {
                        objDue.NoOfFollwp = 0;
                    }
                    else
                    {
                        objDue.NoOfFollwp = Convert.ToInt32(com.Parameters["@no_of_followup"].Value);
                    }
                    if (com.Parameters["@total_expence"].Value == DBNull.Value)
                    {
                        objDue.TotalExpence = 0;
                    }
                    else
                    {
                        objDue.TotalExpence = Convert.ToDecimal(com.Parameters["@total_expence"].Value);
                    }

                    if (com.Parameters["@total_other_income"].Value == DBNull.Value)
                    {
                        objDue.OtherIncome = 0;
                    }
                    else
                    {
                        objDue.OtherIncome = Convert.ToDecimal(com.Parameters["@total_other_income"].Value);
                    }

                    if (com.Parameters["@total_absents"].Value == DBNull.Value)
                    {
                        objDue.OtherIncome = 0;
                    }
                    else
                    {
                        objDue.TotalAbsents = Convert.ToInt32(com.Parameters["@total_absents"].Value);
                    }
                    if (com.Parameters["@total_presents"].Value == DBNull.Value)
                    {
                        objDue.OtherIncome = 0;
                    }
                    else
                    {
                        objDue.TotalPresents = Convert.ToInt32(com.Parameters["@total_presents"].Value);
                    }
                    if (com.Parameters["@byCash"].Value == DBNull.Value)
                    {
                        objDue.Bycash = 0;
                    }
                    else
                    {
                        objDue.Bycash = Convert.ToInt32(com.Parameters["@byCash"].Value);
                    }
                    if (com.Parameters["@byCheque"].Value == DBNull.Value)
                    {
                        objDue.ByCheque = 0;
                    }
                    else
                    {
                        objDue.ByCheque = Convert.ToInt32(com.Parameters["@byCheque"].Value);
                    }
                    objDue.fromDate = fromDate;
                    objDue.toDate = toDate;
                    return objDue;
                }

                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }


            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }



        #endregion

        #region AutoProcessing

        public static Boolean autoSendNotifications(DateTime notificationDate, int branchId)
        {
            try
            {
                DateTime? notificationSent = Common.Formatter.parseExactDate(SysParam.getValue<String>(SysParam.Parameters.NOTIFICATION_SENT_DATE), Common.Formatter.DateFormat);

                try
                {
                    //Deactivates the expired facilities
                    BLL.StudentHandller.deactivateFacilities(notificationDate.Date, branchId.ToString());
                }
                catch (Exception ex)
                {
                    Common.Log.LogError(ex, "autoSendNotifications.deactivateFacilities");
                }


                if (notificationSent == null)
                {
                    notificationSent = DateTime.Now;
                    Common.Log.LogError("notificationSent in system is null", Common.ErrorLevel.INFORMATION);
                }


                if (notificationDate.Date > notificationSent.Value)
                {
                    if (branchId == -1)
                    {
                        List<Info.Branch> obj = new List<Branch>();

                        obj = BLL.BranchHandler.getAllBranches();
                        foreach (Info.Branch objbranch in obj)
                        {
                            try
                            {
                                sendTotalCountOfToday(getDailyReport(notificationSent.Value, notificationDate.AddDays(-1), objbranch.BranchId.ToString()), objbranch.BranchName);
                            }
                            catch (Exception ex)
                            {
                                Common.Log.LogError(ex, "autoSendNotifications.sendTotalCountOfToday");
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            List<Info.Branch> obj = new List<Branch>();

                            obj = BLL.BranchHandler.getAllBranches();
                            foreach (Info.Branch objbranch in obj)
                            {
                                sendTotalCountOfToday(getDailyReport(notificationSent.Value, notificationDate.AddDays(-1), branchId.ToString()), objbranch.BranchName.ToString());
                            }
                                
                        }
                        catch (Exception ex)
                        {
                            Common.Log.LogError(ex, "autoSendNotifications.sendTotalCountOfToday");
                        }
                    }
                    try
                    {
                        sendFollowupSMS(FollowupHandler.getFollStud(notificationDate, branchId.ToString()));

                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.sendFollowupSMS");
                    }

                    try
                    {
                        sendBirthdaySMS(BLL.MarketingHandler.getBirthdays(notificationDate, branchId.ToString()));
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.sendBirthdaySMS");
                    }

                    try
                    {
                        sendAnniversarySMS(BLL.MarketingHandler.getAnniversaries(notificationDate, branchId.ToString()));
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.sendAnniversarySMS");
                    }

                    try
                    {
                        sendAbsentMessage(BLL.StudentHandller.getAbsentStudentDetails(notificationDate, branchId.ToString()));
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications. sendAbsentMessage");
                    }

                    try
                    {
                        autoRenewFacility(notificationDate, branchId.ToString());
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.autoRenewPackageAndfacility");
                    }
                    try
                    {
                        int NotificationDay = SysParam.getValue<Int32>(SysParam.Parameters.OUTSTANDING_NOTIFICATION);
                        if (DateTime.Now.Day == NotificationDay)
                        {
                            Common.Log.LogError("date matched", Common.ErrorLevel.INFORMATION);
                            sendOutstandingFeesSMS(BLL.FeesHandller.getOutstandingFeesDetails(branchId.ToString(), notificationDate));
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.sendOutstandingNotification");
                    }

                    try
                    {
                        sendPaymentDueNotification(FeesHandller.getPaymentDueDetails(branchId.ToString()));
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.sendPaymentDueNotification");
                    }

                    try
                    {
                        int branchid = SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID);
                        BLL.AttendanceHandler.populateLecturesinAttendanceLog((DateTime.Now.ToShortDateString()), branchid);
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "AttendanceHandler.populateLecturesinAttendanceLog");
                    }

                    try
                    {
                        BLL.ChequeHandler.sendChequeDueSMS(DateTime.Now, branchId);
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "ChequeHandler.sendCHequeDueSMS");
                    }
                    try
                    {
                        //SendExpiredPackagesNotificationToOwner(BLL.StudentHandller.GetExpiringFacilities(notificationDate.Date, branchId.ToString()));
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "sendExp_Packages_Notification");
                    }

                    try
                    {
                        //MailHandler.ToBeExpirePackageSMSAuto((BLL.FeesHandller.getRenewalOnLoad(branchId.ToString(), 2)), branchId);
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "FeesHandller.ToBeExpirePackageSMS");
                    }

                    try
                    {

                        //Get pacakges expiring today and send sms to them identifier is 5 that is active and expiring today
                        DataTable expiredPackages = BLL.FeesHandller.getRenewalOnLoad(branchId.ToString(), 5, DateTime.Now.Date, DateTime.Now.Date);
                        if (expiredPackages != null && expiredPackages.Rows.Count > 0)
                        {
                            MailHandler.SendExpiredPackagesSMS(expiredPackages, branchId);
                        }
                        Int32 expiryFrequency = SysParam.getValue<Int32>(SysParam.Parameters.FREQUENCY_TO_SEND_MSG);
                        BLL.FeesHandller.updateExpirySMSSentDate(DateTime.Now.AddDays(-expiryFrequency));
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "FeesHandller.ToBeExpirePackageSMS");

                    }



                    //done by hemlata (todelete the backup files - 5 aug 17 )
                    try
                    {

                        string Dir = (AppDomain.CurrentDomain.BaseDirectory + "Backup\\");

                        string[] file = Directory.GetFiles(Dir, "*.bak");

                        if (Directory.Exists(Dir))
                        {
                            foreach (string f in file)
                            {
                                if (File.GetLastWriteTime(f) < DateTime.Now.AddDays(-15))
                                {
                                    File.Delete(f);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }


                    ExpenseHandler.exportData(notificationDate.AddDays(-1), branchId.ToString(), true);

                    try
                    {
                        IncomeMail();
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError(ex, "autoSendNotifications.incomemail"); ;
                    }

                    try
                    {
                        // DataTable Exp = BLL.FeesHandller.getRenewalOnLoad(branchId.ToString(), 0);
                        // DataTable TobeExp = BLL.FeesHandller.getRenewalOnLoad(branchId.ToString(), 1);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

                Common.Log.LogError("Updating date with " + notificationDate.ToString(), Common.ErrorLevel.ERROR);

                SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.NOTIFICATION_SENT_DATE, Common.Formatter.FormatDate(notificationDate), branchId);
                Common.Log.LogError("Updated date with " + notificationDate.ToString(), Common.ErrorLevel.ERROR);

                return true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, "autoSendNotifications");
                return false;
            }
        }

        private static void SendExpiredPackagesNotificationToOwner(DataTable dataTable)
        {
            StringBuilder msgbody = new StringBuilder();

            //Get sms config
            Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

            string ContactNo = SysParam.getValue<string>(SysParam.Parameters.NOTIFY_PAKG_EXPIRY);
            if (ContactNo != "")
            {
                msgbody.Append("Expiry Report For" + DateTime.Now.Date + "\n");
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        msgbody.Append("\n" + dr.ItemArray[0] + "  " + "\n " + dr.ItemArray[1] + "  " + "\n" + dr.ItemArray[2] + "  " + "\n");
                    }
                    MailHandler.sendSMS(smsConfig, msgbody.ToString(), ContactNo, false, "ExpNotificationSMS");
                }
            }
        }

        public static void autoRenewFacility(DateTime notificationDate, string branchid)
        {
            try
            {
                DataTable dt = BLL.StudentHandller.getExpiredFacilities(notificationDate, branchid);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int facilitiyId = Convert.ToInt32(dr["FacilityID"]);
                        BLL.FeesPackageHandller.renewFacility(facilitiyId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void IncomeMail()
        {
            try
            {
                string ReportFolder;
                List<string> attachment = new List<string>();
                string emailbody = "Please find the daily reports attached";
                List<string> EmailId = new List<string>();
                EmailId.Add(Info.SysParam.getValue<string>(SysParam.Parameters.EMAIL_ADDRESS));

                List<String> files = new List<string>();
                ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Income\\Inc");
                files.AddRange(Directory.GetFiles(ReportFolder, "*.xls"));



                ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp");
                files.AddRange(Directory.GetFiles(ReportFolder, "*.xls"));

                // ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp\\IncomeExpense-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                foreach (string singlefile in files)
                {
                    attachment.Add(singlefile);
                }

                if (files.Count() != 0)
                {
                    MailHandler.sendEmail(emailbody, EmailId, "Daily Report", attachment);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void ExpenseMail()
        {
            try
            {
                string ReportFolder;
                List<string> attachment = new List<string>();
                
                string emailbody = "Please find the Attachment given below of Expense Report :";
                List<string> EmailId = new List<string>();

                EmailId.Add(Info.SysParam.getValue<string>(SysParam.Parameters.EMAIL_ADDRESS));
                ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp");
                string[] file = Directory.GetFiles(ReportFolder, "*.xls");

                // ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp\\IncomeExpense-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                foreach (string singlefile in file)
                {
                    attachment.Add(singlefile);
                }
                if (file.Count() != 0)
                {
                    MailHandler.sendEmail( emailbody, EmailId, "Expense Report", attachment);
                }



                // for other work

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region Send Notification


        public static void notifyFeesPayment(Info.Reporting.FeeReceiptReportData objFeeReceipt, String branchName)
        {
            try
            {
                string contactNos = SysParam.getValue<string>(SysParam.Parameters.NOTIFY_FEES_RECEIPT);
                if (contactNos != null && contactNos != string.Empty)
                {
                    StringBuilder sbPaymentNotification = new StringBuilder();
                    sbPaymentNotification.Append(Template.getValue<string>(TemplateType.FEES_NOTIFICATION));

                    sbPaymentNotification.Replace(":amount", Common.Formatter.FormatCurrency(objFeeReceipt.TotalFees));
                    sbPaymentNotification.Replace(":Name", objFeeReceipt.StudentName);
                    sbPaymentNotification.Replace(":branchName", branchName);

                    if (objFeeReceipt.CashPayment != 0)
                    {
                        sbPaymentNotification.Replace(":cashAmnt", Common.Formatter.FormatCurrency(objFeeReceipt.CashPayment));
                    }
                    else
                    {
                        sbPaymentNotification.Replace(":cashAmnt", "0");
                    }

                    if (objFeeReceipt.ChequePayment != 0)
                    {
                        sbPaymentNotification.Replace(":cheqAmnt", Common.Formatter.FormatCurrency(objFeeReceipt.ChequePayment));
                    }

                    else
                    {
                        sbPaymentNotification.Replace(":cheqAmnt", "0");
                    }
                    if (objFeeReceipt.OutstandingAmount != 0)
                    {
                        sbPaymentNotification.Replace(":outstanding", Common.Formatter.FormatCurrency(objFeeReceipt.OutstandingAmount));

                    }
                    else
                    {
                        sbPaymentNotification.Replace(":outstanding", "0");
                    }
                    sbPaymentNotification.Append(" Collected by " + UserHandler.loggedInUser.UserId);
                    MailHandler.sendSMS(SmsConfig.getSMSConfig(), sbPaymentNotification.ToString(), contactNos, false, "FeesPaidSMS");
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        /// <summary>
        /// Following function will be called when absent message is to sent for a day.
        /// </summary>
        public static bool sendAbsentMessageForADay(DataTable absntStuds)
        {
            try
            {

                bool isSent = false;
                string TemplateSMS;
                Dictionary<string, string> smsData = new Dictionary<string, string>();
                bool tobeSent = SysParam.getValue<bool>(SysParam.Parameters.SEND_ABSENT_SMS);
                Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                TemplateSMS = Template.getValue<string>(Info.TemplateType.ABSENTCHILD);
                if (tobeSent)
                {
                    foreach (DataRow row in absntStuds.Rows)
                    {
                        StringBuilder smsBody = new StringBuilder(TemplateSMS);

                        List<string> lstContactNo = new List<string>();
                        lstContactNo.Add(row["ContactNo"].ToString());

                        smsBody.Replace(":Name", row["Name"].ToString());
                        smsBody.Replace(":date", Common.Formatter.FormatDate(Convert.ToDateTime(row["Date"])));
                        smsBody.Replace(":CNAME", SysParam.getValue<string>(SysParam.Parameters.NAME));
                        smsBody.Replace(":CONTACT_NO", SysParam.getValue<string>(SysParam.Parameters.CONTACT_NO));
                        if (!smsData.ContainsKey(row["contactno"].ToString()))
                        {
                            smsData.Add(row["contactno"].ToString(), smsBody.ToString());
                        }

                        AttendanceHandler.updateAbsentSMSStaus(Convert.ToInt32(row["ATTD_ID"].ToString()), Convert.ToInt32(row["Id"].ToString()));
                    }

                    isSent = MailHandler.sendSMS(SmsConfig.getSMSConfig(), smsData, false, Info.TemplateType.ABSENTCHILD.ToString());

                }
                return Common.Utility.retBoolStatus(isSent);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool SendHomeWorkMsg(DataTable absntStuds)
        {
            try
            {
                bool isSent = false;
                Dictionary<string, string> smsData = new Dictionary<string, string>();


                foreach (DataRow row in absntStuds.Rows)
                {
                    StringBuilder smsBody = new StringBuilder(Template.getValue<string>(Info.TemplateType.HOMEWORKSMS));

                    smsBody.Replace(":Name", row["Name"].ToString());
                    smsBody.Replace(":date", Common.Formatter.FormatDate(Convert.ToDateTime(row["Date"])));
                    smsBody.Replace(":CNAME", SysParam.getValue<string>(SysParam.Parameters.NAME));
                    smsBody.Replace(":CONTACT_NO", SysParam.getValue<string>(SysParam.Parameters.CONTACT_NO));

                    if (!smsData.ContainsKey(row["ContactNo"].ToString()))
                    {
                        smsData.Add(row["ContactNo"].ToString(), smsBody.ToString());
                    }
                }
                isSent = MailHandler.sendSMS(SmsConfig.getSMSConfig(), smsData, false, "HomeWorkSMS");

                return Common.Utility.retBoolStatus(isSent);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static void notifyNewAdmission(Student objStudent, String branchName)
        {
            try
            {
                string contactNos = SysParam.getValue<string>(SysParam.Parameters.NOTIFY_ADMISSIONS);
                if (contactNos != null && contactNos != string.Empty)
                {
                    StringBuilder sbPaymentNotification = new StringBuilder();
                    sbPaymentNotification.Append(Template.getValue<string>(TemplateType.ADMISSION_NOTIFICATION));

                    sbPaymentNotification.Replace(":Name", objStudent.Fname + ' ' + objStudent.Lname);
                    sbPaymentNotification.Replace(":cources", objStudent.NewCourse);
                    sbPaymentNotification.Replace(":branchName", branchName);
                    MailHandler.sendSMS(SmsConfig.getSMSConfig(), sbPaymentNotification.ToString(), contactNos, false, "RegistrationDetailToOwner");
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

        public static bool sendLectureSMSToStudent(List<Info.Lecture> lstLect, int branchId)
        {
            try
            {
                bool allowtosndlectSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_LECTURESMS_STUDENT);
                StringBuilder timetableBody = new StringBuilder();
                Dictionary<string, string> smsdata = new Dictionary<string, string>();
                bool addFaculty = false;

                if (allowtosndlectSMS)
                {
                    string smsTemplate;
                    //String timetable = string.Empty;
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //Get SMS TEMPLATE
                    smsTemplate = Template.getValue<string>(Info.TemplateType.LECTURESMS);


                    //It will select unique Batches.
                    var result = lstLect.GroupBy(test => test.Batch.id).Select(grp => grp.First());


                    if (smsTemplate.Contains(":Faculty"))
                    {
                        addFaculty = true;
                    }

                    smsTemplate.Replace(":Faculty", "");

                    foreach (var batch in result.ToList())
                    {
                        timetableBody = new StringBuilder();

                        foreach (Info.Lecture objLect in lstLect.Where(lecture => lecture.Batch.id == batch.Batch.id))
                        {

                            if (objLect.Date.Date >= DateTime.Now.Date)
                            {
                                timetableBody.Append("\n" + objLect.Subject.SubjName + " " + Common.Formatter.FormatDate(objLect.Date) + " " + objLect.FromTime.ToShortTimeString() + " To " + objLect.ToTime.ToShortTimeString() + " ");
                                if (addFaculty == true)
                                {
                                    timetableBody.Append("By " + objLect.Faculty.Name);
                                }
                            }
                        }

                        foreach (Info.Student objStudent in BLL.StudentHandller.getStudents(batch.Batch.StandardID.ToString(), batch.Batch.id.ToString(), branchId.ToString()))
                        {
                            StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                            smsBody.Replace(":Name", objStudent.Fname);
                            smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                            smsBody.Append(timetableBody);
                            if (smsdata.ContainsKey(objStudent.ContactNo) == false)
                            {
                                smsdata.Add(objStudent.ContactNo, smsBody.ToString());
                            }
                        }
                        MailHandler.sendSMS(smsConfig, smsdata, false, "LectureSMSToStudent");
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static bool sendLectureSMSToFaculty(List<Info.Lecture> lstLect, int branchID)
        {
            try
            {
                bool allowtosndlectSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_LECTURE_SCHEDULE_SMS_FACULTY);
                if (allowtosndlectSMS)
                {
                    Dictionary<string, string> smsData = new Dictionary<string, string>();

                    string smsTemplate;
                    List<Info.Faculty> lstfclty = new List<Faculty>();
                    //Get sms config                
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                    //Get SMS TEMPLATE
                    smsTemplate = Template.getValue<string>(Info.TemplateType.LECTURESMS);
                    //Traversing each student.

                    foreach (int facultyId in lstLect.Select(l => l.Faculty.FacultyID).Distinct<int>().ToList<int>())
                    {
                        Faculty objFaulty = BLL.FacultyHandler.getFacultiesByID(facultyId, branchID);

                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                        smsBody.Replace(":Name", objFaulty.Name);
                        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));

                        foreach (Lecture objLecture in lstLect.Where(l => l.Faculty.FacultyID == facultyId).ToList<Lecture>())
                        {
                            if (objLecture.Date.Date >= DateTime.Now.Date)
                            {
                                smsBody.Append("\n" + objLecture.Standard.StandardName + "/" + objLecture.Subject.SubjName + " " + Common.Formatter.FormatDate(objLecture.Date) + " " + objLecture.FromTime.ToShortTimeString() + " to " + objLecture.ToTime.ToShortTimeString());
                            }
                        }
                        if (!smsData.ContainsKey(objFaulty.ContactNo))
                        {
                            smsData.Add(objFaulty.ContactNo, smsBody.ToString());
                        }

                        MailHandler.sendSMS(smsConfig, smsData, false, "LectureSMSToFaculty");
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        //As Checkin SMSs are directly being send from the biomonitor
        public static void sendCheckInMessage(Student objStudentMaster, Int32 CheckInStatus)
        {
            try
            {
                //    bool allowtosndSignINSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_IN_SMS);

                //    if (allowtosndSignINSMS)
                //    {
                //        bool isFrmmrktng = false;
                //        string smsTemplate;
                //        //Get sms config
                //        Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();




                //        //get template
                //        smsTemplate = "";


                //        //SMS content
                //        StringBuilder smsBody = new StringBuilder();

                //        if (CheckInStatus == 1)
                //        {
                //            smsBody.Append(objStudentMaster.Fname + " has checked in classes");
                //        }
                //        else if (CheckInStatus == 2)
                //        {
                //            smsBody.Append(objStudentMaster.Fname + " has checked out classes");
                //        }
                //        else
                //        {
                //            return;
                //        }
                //        MailHandler.sendSMS(smsConfig, smsBody.ToString(), objStudentMaster.FatherContactNo, false);

                //}
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static bool sendTestSMS(DataTable dt, string Testname)
        {
            try
            {

                bool isSent = false;
                string remark = "";


                List<KeyValuePair<string, string>> smsData = new List<KeyValuePair<string, string>>();

                //Absent Members will be added to this List.Mohan(22-July-2017).
                List<KeyValuePair<string, string>> kvabsentForTest = new List<KeyValuePair<string, string>>();
                //Dictionary<string, string> smsdata = new Dictionary<string, string>();

                string contactNo = null;

                //Get SMS config
                Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                string[] TobeDistinct = { "STMT_ADMISSION_NO" };
                DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);

                foreach (DataRow row in dtDistinct.Rows)
                {

                    //Get Test template
                    string smsTemplate, absentforTest;
                    smsTemplate = Template.getValue<string>(Info.TemplateType.EXAMSMS);
                    absentforTest = Template.getValue<string>(Info.TemplateType.TESTABSENTSMS);
                    StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                    StringBuilder absentBody = new StringBuilder(absentforTest.ToString());

                    DataRow[] dr = dt.Select("STMT_ADMISSION_NO=" + row.ItemArray[0]);

                    foreach (DataRow actualrecords in dr)
                    {

                        {
                            if (!smsBody.ToString().Contains(actualrecords.ItemArray[1].ToString() + "'s"))
                            {
                                smsBody.Replace(":Name", actualrecords.ItemArray[1].ToString() + "'s");
                            }
                            if (!smsBody.ToString().Contains(Testname))
                            {
                                smsBody.Replace(":testName", Testname + " held on " + Common.Formatter.FormatDate(Convert.ToDateTime(actualrecords.ItemArray[5].ToString())));
                            }

                            smsBody.AppendLine();
                            if (actualrecords.ItemArray[3].ToString() == "-1")
                            {
                                smsBody.Append(actualrecords.ItemArray[7] + ": absent,");
                            }
                            else
                            {
                                smsBody.Append(actualrecords.ItemArray[7] + ":" + actualrecords.ItemArray[3] + "/" + actualrecords.ItemArray[4] + ",");
                            }

                            remark = actualrecords.ItemArray[8].ToString();

                        }
                        if (contactNo != actualrecords.ItemArray[2].ToString())
                        {
                            contactNo = actualrecords.ItemArray[2].ToString();
                        }
                    }

                    smsBody.AppendLine();



                    if (!smsBody.ToString().Contains(remark))
                    {
                        smsBody.Append(remark);
                    }



                    smsBody.Append(" Regards " + SysParam.getValue<string>(SysParam.Parameters.NAME) + ".");

                    KeyValuePair<string, string> item = new KeyValuePair<string, string>(contactNo, smsBody.ToString());

                    contactNo = null;
                    smsData.Clear();
                    if (!smsData.Contains(item))
                    {
                        smsData.Add(item);

                    }
                    isSent = MailHandler.sendSMS(smsConfig, smsData, false, "ExamsMarksSMS");
                }


                return Common.Utility.retBoolStatus(isSent);


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
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

        public static void sendCheckInMessage(int iUserID, bool isChekin)
        {
            try
            {
                bool allowtosndSignINSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_IN_SMS);

                if (allowtosndSignINSMS)
                {

                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    Student objStudent = BLL.StudentHandller.getStudentByBioMetric(iUserID, Info.SysParam.getValue<bool>(SysParam.Parameters.SW_BRANCH_ID).ToString()) as Info.Student;

                    //get template
                    smsTemplate = "";

                    //SMS content
                    StringBuilder smsBody = new StringBuilder();

                    if (isChekin == true)
                    {
                        smsBody.Append(objStudent + " has checked in classes");
                    }
                    else
                    {
                        smsBody.Append(objStudent.Fname + " has checked out classes");
                    }
                    MailHandler.sendSMS(smsConfig, smsBody.ToString(), objStudent.FatherContactNo, false, "SignInSMS");
                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }
        public static void sendCheckOutMessage(int iUserID, bool isChekout)
        {
            try
            {
                bool allowtosndSignOutSMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_SIGN_OUT_SMS);

                if (allowtosndSignOutSMS)
                {

                    string smsTemplate;
                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    Student objStiudentMaster = BLL.StudentHandller.getStudentByBioMetric(iUserID, Info.SysParam.getValue<bool>(SysParam.Parameters.SW_BRANCH_ID).ToString());

                    //get template
                    smsTemplate = "";


                    //SMS content
                    StringBuilder smsBody = new StringBuilder();

                    if (isChekout == true)
                    {
                        smsBody.Append(objStiudentMaster.Fname + " has checked in classes");
                    }
                    else
                    {
                        smsBody.Append(objStiudentMaster.Fname + " has checked out classes");
                    }
                    MailHandler.sendSMS(smsConfig, smsBody.ToString(), objStiudentMaster.FatherContactNo, false, "SignOutSMS");

                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static int checkSMSSent(string contactNo, string smsbody)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_check_sms_sent");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@contactNo", SqlDbType.VarChar).Value = contactNo;
                com.Parameters.Add("@smsBody", SqlDbType.VarChar).Value = smsbody;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteQuery(com);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable GetSMSdetails(string branchID, DateTime? FromDt = null, DateTime? ToDt = null)
        {
            try
            {
                if (ToDt == null || FromDt == null)
                {

                    FromDt = new DateTime(1753, 1, 1);
                    ToDt = DateTime.MaxValue;
                }
                com = new SqlCommand("s_pr_disp_SMS_Details");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branch", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@from", SqlDbType.DateTime).Value = FromDt.Value.Date;
                com.Parameters.Add("@to", SqlDbType.DateTime).Value = ToDt.Value.Date;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable result = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return result;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        #endregion

    }
}

