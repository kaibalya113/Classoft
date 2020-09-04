using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;

namespace ClassManager.Info
{
   [Serializable]
   public class DailyReport
    {
        public int NoOfEnq { get; set; }
        public int NoOfReg { get; set; }
        public int NoOfFeesPaymnt { get; set; }
        public decimal TotalCollected { get; set; }
        public int NoOfFollwp { get; set; }
        public decimal TotalExpence { get; set; }
        public string BranchName  { get; set; }
        //public string ReportDate { get; set; }
        public int TotalPresents { get; set; }
        public int TotalAbsents { get; set; }
        public decimal Bycash { get; set; }
       public decimal ByCheque { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int ExpiredPackage { get; set; }
        public int TobeExpiredPackage { get; set; }
        public int  TodayExpired { get; set; }
        public decimal TotalOutstanding { get; set; }

        internal static DailyReport getTotalCounts(System.Data.DataRow drStudent)
        {
            DailyReport objDue = new DailyReport();

            if (drStudent.Table.Columns.Contains("no_of_enq") && drStudent["no_of_enq"] != DBNull.Value)
            {
                objDue.NoOfEnq = Convert.ToInt32(drStudent["no_of_enq"]);
            }
            if (drStudent.Table.Columns.Contains("no_of_registration") && drStudent["no_of_registration"] != DBNull.Value)
            {
                objDue.NoOfReg = Convert.ToInt32(drStudent["no_of_registration"]);
            }
            if (drStudent.Table.Columns.Contains("no_of_feesPayment") && drStudent["no_of_feesPayment"] != DBNull.Value)
            {
                objDue.NoOfFeesPaymnt = Convert.ToInt32(drStudent["no_of_feesPayment"]);
            }
            if (drStudent.Table.Columns.Contains("total_Collected") && drStudent["total_Collected"] == DBNull.Value)
            {
                objDue.TotalCollected = Convert.ToDecimal(drStudent["total_Collected"]);
            }
            if (drStudent.Table.Columns.Contains("no_of_followup") && drStudent["no_of_followup"] == DBNull.Value)
            {
                objDue.NoOfFollwp = Convert.ToInt32(drStudent["no_of_followup"]);
            }
            if (drStudent.Table.Columns.Contains("total_expence") )
            {
                objDue.TotalExpence = Convert.ToDecimal(drStudent["total_expence"]);
            }
            if (drStudent.Table.Columns.Contains("TRNC_CASH_AMOUNT"))
            {
                objDue.Bycash = Convert.ToDecimal(drStudent["TRNC_CASH_AMOUNT"]);
            }
            if (drStudent.Table.Columns.Contains("TRNC_CHEQUE_AMOUNT"))
            {
                objDue.ByCheque = Convert.ToDecimal(drStudent["TRNC_CHEQUE_AMOUNT"]);
            }
            if (drStudent.Table.Columns.Contains("ExpiredPackage"))
            {
                objDue.ExpiredPackage = Convert.ToInt32(drStudent["ExpiredPackage"]);
            }
            if (drStudent.Table.Columns.Contains("ToBeExpiredPackage"))
            {
                objDue.TobeExpiredPackage = Convert.ToInt32(drStudent["ToBeExpiredPackage"]);
            }
            if (drStudent.Table.Columns.Contains("todayExpiry"))
            {
                objDue.TodayExpired = Convert.ToInt32(drStudent["todayExpiry"]);
            }
            if (drStudent.Table.Columns.Contains("totalOutstanding"))
            {
                objDue.TotalOutstanding = Convert.ToInt32(drStudent["totalOutstanding"]);
            }
            return objDue;
        }



        public decimal OtherIncome { get; set; }
    }
}
