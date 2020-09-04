using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info.Reporting
{
     public class CommonReportData : IReportData
    {
        public string ClassName, ClassSubName, ClassNote,Logo,ClassAddress,Std,Batch,Name,Roll;
        public DateTime FromDate;
        public DateTime ToDate;
        public Reports ReportName;
    }
}
