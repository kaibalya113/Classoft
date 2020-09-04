using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;


namespace ClassManager.Info
{
    [Serializable]
    public class FeesCollRpt
    {
       
        
        public string ReceiptNo { get; set; }

        public int AdmissionNo { get; set; }

        public Decimal FeesPaid { get; set; }

        public string Name { get; set; }

        public string RollNo { get; set; }
        

        public DateTime PaymentDate { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string Day { get; set; }

        public Stream Stream { get; set; }
        
        public Standard Standard { get; set; }

        public Batch Batch { get; set; }

        public int BranchId { get; set; }

        public string BranchName { get; set; }
        public string Mode { get; set; }
        public string BranchIdStr { get; set; }
        public Decimal CashAmount { get; set; }
        public Decimal OtherAmount { get; set; }
        public string PackageName { get; private set; }
        public string CourseName { get; private set; }
        public string StreamName { get; private set; }
        public decimal TransactionAmt { get; private set; }

        public string ChequeNo { get; set; }
        public string TrensferRef { get; set; }
        public bool ISRENEW { get; set; }
        public FeesCollRpt()
        {
            this.Stream = new Stream();
            this.Standard = new Standard();
            this.Batch = new Batch();
        }

        public static FeesCollRpt getFCollectionRpt(System.Data.DataRow drFeesCol)
        {
            FeesCollRpt objFCR = new FeesCollRpt();
            if (drFeesCol.Table.Columns.Contains("Year") && drFeesCol["Year"] != DBNull.Value)
            {
                objFCR.Year = drFeesCol["Year"].ToString();
            }
            if (drFeesCol.Table.Columns.Contains("Month") && drFeesCol["Month"] != DBNull.Value)
            {
                objFCR.Month = drFeesCol["Month"].ToString();
            }

            //if (drFeesCol.Table.Columns.Contains("FEE_LAST_PAYMENT_DATE") && drFeesCol["FEE_LAST_PAYMENT_DATE"] != DBNull.Value)
            //{
            //    objFCR.Date = Convert.ToDateTime(drFeesCol["FEE_LAST_PAYMENT_DATE"]);
            //}



            //if (drFeesCol.Table.Columns.Contains("Stream") && drFeesCol["Stream"] != DBNull.Value)
            //{
            //    objFCR.Stream = drFeesCol["Stream"].ToString();
            //}
            //if (drFeesCol.Table.Columns.Contains("Standard") && drFeesCol["Standard"] != DBNull.Value)
            //{
            //    objFCR.course = drFeesCol["Standard"].ToString();
            //}

            //if (drFeesCol.Table.Columns.Contains("BatchID") && drFeesCol["BatchID"] != DBNull.Value)
            //{
            //    objFCR.batch = drFeesCol["BatchID"].ToString();
            //}
            if (drFeesCol.Table.Columns.Contains("Branch_ID") && drFeesCol["Branch_ID"] != DBNull.Value)
            {
                objFCR.BranchId = Convert.ToInt32(drFeesCol["Branch_ID"]);
            }
            if (drFeesCol.Table.Columns.Contains("TRNC_RECEIPT_NO") && drFeesCol["TRNC_RECEIPT_NO"] != DBNull.Value)
            {
                objFCR.ReceiptNo = drFeesCol["TRNC_RECEIPT_NO"].ToString();
            }
            if (drFeesCol.Table.Columns.Contains("RollNo") && drFeesCol["RollNo"] != DBNull.Value)
            {
                objFCR.RollNo = drFeesCol["RollNo"].ToString();
            }
            if (drFeesCol.Table.Columns.Contains("BranchName") && drFeesCol["BranchName"] != DBNull.Value)
            {
                objFCR.BranchName = drFeesCol["BranchName"].ToString();
            }

            if (drFeesCol.Table.Columns.Contains("AdmissionNo") && drFeesCol["AdmissionNo"] != DBNull.Value)
            {
                objFCR.AdmissionNo = Convert.ToInt32(drFeesCol["AdmissionNo"]);
            }
            if (drFeesCol.Table.Columns.Contains("Name") && drFeesCol["Name"] != DBNull.Value)
            {
                objFCR.Name = drFeesCol["Name"].ToString();
            }
            if (drFeesCol.Table.Columns.Contains("FeesPaid") && drFeesCol["FeesPaid"] != DBNull.Value)
            {
                objFCR.FeesPaid = Convert.ToDecimal(drFeesCol["FeesPaid"]);
            }
            if (drFeesCol.Table.Columns.Contains("TRNC_AMOUNT") && drFeesCol["TRNC_AMOUNT"] != DBNull.Value)
            {
                objFCR.TransactionAmt = Convert.ToDecimal(drFeesCol["TRNC_AMOUNT"]);
            }

            if (drFeesCol.Table.Columns.Contains("TRNC_DATE") && drFeesCol["TRNC_DATE"] != DBNull.Value)
            {
                objFCR.PaymentDate = Convert.ToDateTime(drFeesCol["TRNC_DATE"]);
            }
            if (drFeesCol.Table.Columns.Contains("TRNC_ADMISSION_NO") && drFeesCol["TRNC_ADMISSION_NO"] != DBNull.Value)
            {
                objFCR.AdmissionNo = Convert.ToInt32(drFeesCol["TRNC_ADMISSION_NO"]);
            }
            if (drFeesCol.Table.Columns.Contains("TRNC_CASH_AMOUNT") && drFeesCol["TRNC_CASH_AMOUNT"] != DBNull.Value)
            {
                objFCR.CashAmount = Convert.ToDecimal(drFeesCol["TRNC_CASH_AMOUNT"]);
            }
            if ((drFeesCol.Table.Columns.Contains("TRNC_CHEQUE_AMOUNT") && drFeesCol["TRNC_CHEQUE_AMOUNT"] != DBNull.Value )  && (drFeesCol.Table.Columns.Contains("TRNC_TRANSFER_AMOUNT") && drFeesCol["TRNC_TRANSFER_AMOUNT"] != DBNull.Value))
            {
                  objFCR.OtherAmount = Convert.ToDecimal(drFeesCol["TRNC_CHEQUE_AMOUNT"]) + Convert.ToDecimal(drFeesCol["TRNC_TRANSFER_AMOUNT"]);
            }
            if (drFeesCol.Table.Columns.Contains("TRNC_PAYMENT_MODE") && drFeesCol["TRNC_PAYMENT_MODE"] != DBNull.Value)
            {
                objFCR.Mode = (drFeesCol["TRNC_PAYMENT_MODE"]).ToString();
            }
            if (drFeesCol.Table.Columns.Contains("FPKG_PACKAGE_NAME") && drFeesCol["FPKG_PACKAGE_NAME"] != DBNull.Value)
            {
                objFCR.PackageName = (drFeesCol["FPKG_PACKAGE_NAME"]).ToString();
            }
            if (drFeesCol.Table.Columns.Contains("STD_NAME") && drFeesCol["STD_NAME"] != DBNull.Value)
            {
                objFCR.CourseName = (drFeesCol["STD_NAME"]).ToString();
            }
            if (drFeesCol.Table.Columns.Contains("STRM_NAME") && drFeesCol["STRM_NAME"] != DBNull.Value)
            {
                objFCR.StreamName = (drFeesCol["STRM_NAME"]).ToString();
            }
            if (drFeesCol.Table.Columns.Contains("CHQ_No") && drFeesCol["CHQ_No"] != DBNull.Value)
            {
                objFCR.ChequeNo = (drFeesCol["CHQ_No"]).ToString();
            }
            if (drFeesCol.Table.Columns.Contains("PD_REFERANCE_NO") && drFeesCol["PD_REFERANCE_NO"] != DBNull.Value)
            {
                objFCR.TrensferRef = (drFeesCol["PD_REFERANCE_NO"]).ToString();
            }
            if (drFeesCol.Table.Columns.Contains("ISRENEW") && drFeesCol["ISRENEW"] != DBNull.Value)
            {
                objFCR.ISRENEW = (bool)(drFeesCol["ISRENEW"]);
            }

            objFCR.Stream = Stream.getStream(drFeesCol);
            objFCR.Standard = Standard.getStandard(drFeesCol);
            objFCR.Batch = Batch.GetBatch(drFeesCol);
            return objFCR;
        }



        public static List<Info.FeesCollRpt> getFCollRpt(DataTable dtFeess)
        {
            try
            {
                List<Info.FeesCollRpt> lstFeeColl = new List<Info.FeesCollRpt>();

                foreach (DataRow drFess in dtFeess.Rows)
                {
                    FeesCollRpt objFeeColl = FeesCollRpt.getFCollectionRpt(drFess);

                    lstFeeColl.Add(objFeeColl);
                }

                return lstFeeColl;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }




        
    }





}
