using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassManager.Info;



namespace ClassManager.Info
{
    [Serializable]
    public class SysParam
    {

        public static User LoggedInUser;
        public static int branchId;
        // public int BranchID { get; set; }
        public string PRM_Name { get; set; }
        public string PRM_Value { get; set; }
        public int PRM_Value_Int { get; set; }
        public string PRM_Frm_Dt { get; set; }
        public string PRM_To_Dt { get; set; }

        public enum Parameters
        {
            ADMISSION_COUNT,
            ACADEMIC_YEAR,
            ADD_FOLLWP_DATE,
            ALLOW_BRANCH_SELECTION,
            ALLOW_TO_SEND_SMS,
            APP_NAME,
            APP_START_YEAR,
            BUFFER_TIME,
            ADDRESS,
            CONTACT_NO,
            EMAIL_ADDRESS,
            NAME,
            DAYS_FOR_ABSENT_MSG,
            DB_BACKUP_PATH,
            DB_NAME,
            DEVICE_ID,
            DEVICE_PORT_NO,
            DUE_NOTIFICATION,
            EMAIL_SIGNATURE_FEES,
            FEES_NOTIFICATION,
            FINANCIAL_YEAR,
            FISCAL_YEAR,
            LOGO_PATH,
            NOTE,
            MAIN_FORM_IMAGE,
            NO_OF_LOGINS,
            NOTIFICATION_SENT_DATE,
            OWNER_NOS,
            OUTSTANDING_NOTIFICATION,
            PHOTO_PATH,
            RSPOND_URL,
            SEND_ABSENT_SMS,
            SEND_ANNI_SMS,
            SEND_BDAY_SMS,
            SEND_DAILYREPORTS_SMS,
            SEND_DUE_NOTIFICATION,
            SEND_ENQ_SMS,
            SEND_FEES_SMS,
            SEND_FOLLOWPUP_SMS,
            SEND_LECTURE_SCHEDULE_SMS_FACULTY,
            SEND_OUTSTANDINGFEES_SMS,
            SEND_REG_SMS,
            SEND_SIGN_IN_SMS,
            SEND_SIGN_OUT_SMS,
            //SENDER_EMAIL,
            SERVICE_TAX,
            SIR_NAME,
            SMS_MARKETING_URL,
            SMS_PASSWORD,
            SMS_SENDER,
            SMS_TYPE,
            SMS_URL,
            SMS_USERNAME,
            SMS_USERNAME_PROMO,
            SMTP_HOST,
            SMTP_PASSWORD,
            SMTP_PORT,
            SMTP_USERNAME,
            SW_BRANCH_NAME,
            IS_AUTOMATIC,
            SW_BRANCH_ID,
            FACILITY_COLLECTION_DATE,
            EXPIRY_NOTIFICATION_DURATION,
            LICENCE_KEY,
            REG_CONTACT,
            SUPPORT_CONTACT,
            NOTIFY_FEES_RECEIPT,
            NOTIFY_ADMISSIONS,
            NOTIFY_EXPENSE,
            CIN_NO,
            SUB_NAME,
            COMPANY_PAN_NO,
            SERVICE_TAX_NO,
            ATTNDCE_LOG_COL_SEPERATOR,
            ATTNDCE_USERID_COL_INDEX,
            ATTNDCE_PUNCH_TIME_INDEX,
            CONSIDER_FEES_PROFIT_LOSS,
            FULL_ADDRESS,
            SEND_CHEQUE_DUE,
            SYNC_REPOFOLDER,
            SYNC_USERNAME,
            SYNC_EMAIL,
            SYNC_BRANCH,
            SYNC_REMOTE,
            SYNC_PASSWORD,
            RECEIPT_COUNT,
            FEE_RECEIPT_TYPE,
            FIELDS,
            APPLICATION_NAME,
            SEND_LECTURESMS_STUDENT,
            APP_RUNNING_MODE,
            TAX_INCLUSIVE,
            SGST_PERCENT,
            CGST_PERCENT,
            BIOMONITOR_MANUAL_TIMER,
            FREQUENCY_TO_SEND_MSG,
            FREQ_SMS_SEND_DATE,
            POPUP_TIMER,
            GENERATE_INVOICE,
            SEND_FEES_MAIL,
            SEND_INVOICE_MAIL,
            LECT_BUFFER_TIME,  //To Mark Attendance between from and to time 
            ENABLE_EDIT_DATE,//TO Enable the Expiry Date of Add facillity screen
            LECTUREWISE_ATTD,//To check for whether the attendancne marking is done lecturewise or studentwise
            IS_ONLY_REG, // Added for School (To identify whether to add packages  while registration of student or not.
            DOCUMENT_PATH, // To save the documents (Receipt ).
            AUTO_PRINT_RECEIPT, // To get the print of the receipt if true else false
            VIEW_RECEIPT,     // on Payment whether to view Report or not .
            APPEND_BRANCH_ID,  //TO append branchid to admissionNO or Not.
            BIO_SHOW_OUTSTAING_FEES_IN_POPUP, //Show outstanding fees in biomonitor popup
            SEND_OUTST_FEES_IN_SMS,//append outstanding fees and dispaly if true otherwise not
            BRCH_HEAD,
            SEND_EXPIRY_MSG,
            SEND_TOBE_EXPIRY_MSG,
            NOTIFY_EXPIRY,
            BIO_EXP_COLOR,
            NOTIFY_PAKG_EXPIRY,
            ACTIVE_PKG_COLOR,
            OUT_MSG_PROVISION,
            GST_NO,
            CUMMULATIVE_PAYMENT,
            ENQUIRY_SOURCES,
            RESUME,
            ADDRESS_PROOF
        }

        public static List<Parameters> branchMasterParameters = new List<Parameters>();

        static SysParam()
        {
            branchMasterParameters = new List<Parameters>();

            branchMasterParameters.Add(Parameters.CONTACT_NO);
            branchMasterParameters.Add(Parameters.ADDRESS);
            branchMasterParameters.Add(Parameters.MAIN_FORM_IMAGE);
            branchMasterParameters.Add(Parameters.RECEIPT_COUNT);
            branchMasterParameters.Add(Parameters.SUB_NAME);
            branchMasterParameters.Add(Parameters.NOTE);
            branchMasterParameters.Add(Parameters.NAME);
            branchMasterParameters.Add(Parameters.LOGO_PATH);
            branchMasterParameters.Add(Parameters.NOTIFICATION_SENT_DATE);
            branchMasterParameters.Add(Parameters.GST_NO);
        }

        public static bool contains(Parameters parameter)
        {
            try
            {
                return dictSysParam.ContainsKey(parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Dictionary<Parameters, object> dictSysParam = new Dictionary<Parameters, object>();


        public static T getValue<T>(Parameters paramName)
        {
            try
            {
                // return (T)Convert.ChangeType(dictSysParam[], typeof(T));
                return (T)Convert.ChangeType(dictSysParam[paramName], typeof(T));
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

    }
}