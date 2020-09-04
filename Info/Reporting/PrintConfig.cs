using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Info.Reporting
{
    public class PrintingConfig
    {
        public bool PrintReport, SaveReport, ViewReport;
        public string reportType,exportFileName;
        public Reports ReportName;
        public object exportFormat;
        public bool sendEmail;
        public bool sendSMS;
        public DateTime printdate;
        
    }
}
