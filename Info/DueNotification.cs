using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;

namespace ClassManager.Info
{
    [Serializable]
    public class DueNotification
    {
        public string EmailId { get; set; }
       
        string fName;

        public string ParentName { get; set; }
    
        public string StudentName { get; set; }
        
        Decimal todaysDue;

        public Decimal TodaysDue { get; set; }

        Decimal totalPaid;
        public Decimal TotalPaid { get; set; }
        DateTime dueDate;

        public DateTime DueDate { get; set; }
        
        public string PhnNO { get; set; }
      
        public string Standard { get; set; }
     
        public string Address { get; set; }

        public string FContactNo { get; set; }
     
        public decimal DueAmount { get; set; }
     public string PackageName { get; set; }

        //get datatable
        public static List<Info.DueNotification> getDues(DataTable dtTodaysDue)
        {
            try
            {
                List<DueNotification> lstDue = new List<DueNotification>();
                foreach (DataRow drTodaysDue in dtTodaysDue.Rows)
                {
                    DueNotification objDueNotify = DueNotification.getDue(drTodaysDue);
                    lstDue.Add(objDueNotify);
                }
                return lstDue;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // FOR GETTING DUES INFORMATION i.e studName,studPhnno, todaysDue,totalPaid,date

        public static DueNotification getDue(System.Data.DataRow drStudent)
        {
            DueNotification objDue = new DueNotification();
            if (drStudent.Table.Columns.Contains("ParentName") && drStudent["ParentName"] != DBNull.Value)
            {
                objDue.ParentName = drStudent["ParentName"].ToString();

            }
            if (drStudent.Table.Columns.Contains("StudentName") && drStudent["StudentName"] != DBNull.Value)
            {
                objDue.StudentName = drStudent["StudentName"].ToString();

            }
            if (drStudent.Table.Columns.Contains("EmailID") && drStudent["EmailID"] != DBNull.Value)
            {
                objDue.EmailId = drStudent["EmailID"].ToString();

            }
            if (drStudent.Table.Columns.Contains("Address") && drStudent["Address"] != DBNull.Value)
            {
                objDue.Address = drStudent["Address"].ToString();

            }
            if (drStudent.Table.Columns.Contains("ContactNo") && drStudent["ContactNo"] != DBNull.Value)
            {
                objDue.FContactNo = (drStudent["ContactNo"]).ToString();
            }
            if (drStudent.Table.Columns.Contains("TotalOutstanding") && drStudent["TotalOutstanding"] != DBNull.Value)
            {
                objDue.TotalDue = Convert.ToDecimal(drStudent["TotalOutstanding"]);
            }
            if (drStudent.Table.Columns.Contains("todaysDue") && drStudent["todaysDue"] != DBNull.Value)
            {
                objDue.TodaysDue = Convert.ToDecimal(drStudent["todaysDue"]);
            }
            if (drStudent.Table.Columns.Contains("totalPaid") && drStudent["totalPaid"] != DBNull.Value)
            {
                objDue.TotalPaid = Convert.ToDecimal(drStudent["totalPaid"]);
            }
            if (drStudent.Table.Columns.Contains("DueDate") && drStudent["DueDate"] != DBNull.Value)
            {
                objDue.DueDate = Convert.ToDateTime(drStudent["DueDate"]);
            }
            if (drStudent.Table.Columns.Contains("STMT_CONTACT_NO") && drStudent["STMT_CONTACT_NO"] != DBNull.Value)
            {
                objDue.PhnNO = drStudent["STMT_CONTACT_NO"].ToString();
            }
            if (drStudent.Table.Columns.Contains("Standard") && drStudent["Standard"] != DBNull.Value)
            {
                objDue.Standard = drStudent["Standard"].ToString();
            }

            //for dueNotification
            if (drStudent.Table.Columns.Contains("DueAmount") && drStudent["DueAmount"] != DBNull.Value)
            {
                objDue.DueAmount = Convert.ToDecimal(drStudent["DueAmount"]);
            }
            if (drStudent.Table.Columns.Contains("PackageName") && drStudent["PackageName"] != DBNull.Value)
            {
                objDue.PackageName = (drStudent["PackageName"]).ToString();
            }
             return objDue;
        }



        public decimal TotalDue { get; set; }

        public static List<DueNotification> getDue(DataTable dtTodaysDue)
        {
            List<DueNotification> dues = new List<DueNotification>();
            foreach(DataRow dr in dtTodaysDue.Rows)
            {
                dues.Add(getDue(dr));
            }

            return dues;

        }
    }
}
