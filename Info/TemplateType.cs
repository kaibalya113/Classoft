using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ClassManager.Info
{
    [Serializable]

    public class Template
    {
        public string Template_name { get; set; }


        public static Dictionary<TemplateType, object> dictSysParam;

        public string Template_text { get; set; }

        public static T getValue<T>(TemplateType paramName)
        {
            if(dictSysParam != null)
            { // TESTABSENTSMS
                return (T)Convert.ChangeType(dictSysParam[paramName], typeof(T));
            }
            else
            {
                throw new Exception("Templates not loaded");
            }
        }
    }


    public enum TemplateType
    {
        OUTSTANDINGFEESEMAIL,
        OUTSTANDINGFEESSMS,
        ENQUIRYSMS,
        ARVERTISESMS,
        FOLLOWUPSMSTOADMIN,
        REGISTRATION,
        FEESEMAIL,
        FEESSMS,
        BIRTHDAYSMS,
        ANNIVERSARIESSMS,
        TOTALCOUNT,
        TODAYSDUEREMINDER,
        ABSENTSMS,
        ABSENTCHILD,
        DUE_NOTIFICATION,
        FEES_NOTIFICATION,
        ADMISSION_NOTIFICATION,
        LECTURESMS,
        TESTSMS,
        CHECKOUTSMS,
        CHECKINSMS,
        CHEQUESMS,
        EXAMSMS,
        TESTABSENTSMS,
        EXPIRED_PACKAGE_SMS,
        GOINGTOEXPIRE_PACKAGE_SMS,
        PACKAGE_RENEWED_SMS,
        HOMEWORKSMS,
        INVOICEMAIL
    }
}
