using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassManager.Common;

namespace ClassManager.Info
{
    [Serializable]
    public class Fees
    {

        private static List<InstallmentDetail> objInstDetail;
        private static Info.InstallmentDetail objInst;

        public List<InstallmentDetail> Installments { get; set; }

        public FeesPackage FeesPackage { get; set; }

        public string DisplayName;
        public string RollNo;

        public int AdmissionNo { get; set; }

        public int AcadYear { get; set; }

        public Decimal TotalFees { get; set; }

        public Decimal FeesPaid { get; set; }

        public Decimal FeesDiscount { get; set; }

        public Decimal BookingAmount { get; set; }

        public string PaymentType { get; set; }

        public string PkgType { get; set; }

        public DateTime PaymentDate { get; set; }

        public Decimal FineAmount { get; set; }

        public Decimal RegAmnt { get; set; }

        public Decimal MiscAmnt { get; set; }

        public Decimal TuitionAmnt { get; set; }

        public string LastPayStatus { get; set; }

        public int LastInstPaid { get; set; }

        public int LastMonthPaid { get; set; }

        public int FeesId { get; set; }

        public DateTime InstallDate { get; set; }

        public Decimal TodaysDue { get; set; }

        public DateTime PayDate { get; set; }

        public string MonthPaidStatus { get; set; }

        public string DiscountReason { get; set; }

        public object InstallmetPaymentStatus { get; set; }

        public string InstsPaid { get; set; }

        public string MonthsPaid { get; set; }

        public DateTime InstallmentPaidDate { get; set; }

        public DateTime PaymentStartDate { get; set; }

        public DateTime LastPaymetDate { get; set; }

        public decimal OutstandingAsOfDate { get; set; }

        public decimal OutstandingFees { get; set; }


        //added 12/12/2016
        public decimal PndgChqAmnt { get; set; }

        public decimal CashAmnt { get; set; }

        public decimal ChequeAmnt { get; set; }
        public decimal TransferAmount { get; set; }



        public static Fees getNameFees(System.Data.DataRow dataRow)
        {
            Fees objFees = new Fees();
            objFees.MembershipNo = dataRow["MemberShipNo"].ToString();
            objFees.RollNo = dataRow["RollNo"].ToString();
            objFees.DisplayName = dataRow["Fname"].ToString() + " " + dataRow["Mname"].ToString() + " " + dataRow["Lname"].ToString();
            return objFees;
        }
        enum ColumnName
        {
            FEE_ID,
            FEE_ADMISSION_NO,
            FEE_ACADEMIC_YEAR,
            FEE_TOTAL_FEES,
            FEE_FEES_PAID,
            FEE_DISCOUNT,
            FEE_CANCD_FEES,
            FEE_BOOKING_AMOUNT,
            FEE_REG_AMOUNT,
            FEE_MISC_AMOUNT,
            FEE_BRANCH_ID,
            FEE_TUTION_AMOUNT,
            FEE_FINE_AMOUNT,
            FEE_PAYMENT_TYPE,
            FEE_LAST_INSTALLMENT_MONTH,
            FEE_LAST_PAYMENT_DATE,
            FEE_LAST_INSTALLMENT_PAID_ID,
            FEE_DISCOUND_REASON,
            FEE_LAST_PAYMENT_STATUS,
            FEE_PAID_INSTALLMENT_ID,
            FEE_PAYMENT_START_DATE,
            FEE_CRTD_AT,
            FEE_UPDT_AT,
            FEE_DLTD_AT,
            FEE_CRTD_BY,
            FEE_UPDAT_BY,
            FEE_DLTD_BY,
            ID,
            FEE_PNDG_CHEQUE_AMNT

        }
        public static Fees getFees(System.Data.DataRow dataRow)
        {
            try
            {
                Fees objFees = new Fees();
                FeesPackage objFeesPack = new FeesPackage();
                objFees.AcadYear = EntityManager.getValue<Int32>(dataRow, ColumnName.FEE_ACADEMIC_YEAR.ToString());
              
                objFees.AdmissionNo = EntityManager.getValue<Int32>(dataRow, ColumnName.FEE_ADMISSION_NO.ToString());
               
                objFees.BookingAmount = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_BOOKING_AMOUNT.ToString());
                
                objFees.FeesDiscount = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_DISCOUNT.ToString());
                
                objFees.FineAmount = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_FINE_AMOUNT.ToString());
                
                objFees.MiscAmnt = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_MISC_AMOUNT.ToString());
               
                objFees.TuitionAmnt = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_TUTION_AMOUNT.ToString());
               
                objFees.FeesPaid = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_FEES_PAID.ToString());
              
                objFees.TotalFees = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_TOTAL_FEES.ToString());
              
                objFees.PaymentDate = EntityManager.getValue<DateTime>(dataRow, ColumnName.FEE_LAST_PAYMENT_DATE.ToString());
                
                objFees.PaymentType = EntityManager.getValue<string>(dataRow, ColumnName.FEE_PAYMENT_TYPE.ToString());
                
                objFees.FeesId = EntityManager.getValue<Int32>(dataRow, ColumnName.FEE_ID.ToString());
               
                objFees.LastMonthPaid = EntityManager.getValue<Int32>(dataRow, ColumnName.FEE_LAST_INSTALLMENT_MONTH.ToString());
               
                objFees.LastInstPaid = EntityManager.getValue<Int32>(dataRow, ColumnName.FEE_LAST_INSTALLMENT_PAID_ID.ToString());
               
                objFees.PkgType = EntityManager.getValue<string>(dataRow, ColumnName.FEE_PAYMENT_TYPE.ToString());
                
                objFees.LastPayStatus = EntityManager.getValue<string>(dataRow, ColumnName.FEE_LAST_PAYMENT_STATUS.ToString());
                
                objFees.PayDate = EntityManager.getValue<DateTime>(dataRow, ColumnName.FEE_LAST_PAYMENT_DATE.ToString());
                
                objFees.PndgChqAmnt = EntityManager.getValue<decimal>(dataRow, ColumnName.FEE_PNDG_CHEQUE_AMNT.ToString());

                return objFees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Fees getFees( System.Data.DataTable dtFeesDetails)
        {
            try
            {
                Fees objFees = new Fees();
                objFees = getFees(dtFeesDetails.Rows[0]);
                objFees.Installments = Info.InstallmentDetail.getInstallmentDetails(dtFeesDetails);

                return objFees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Fees getFees(System.Data.DataSet dsFeesDetails)
        {
            try
            {
                Fees objFees = new Fees();
                objFees = getFees(dsFeesDetails.Tables[0].Rows[0]);
                objFees.Installments = Info.InstallmentDetail.getInstallmentDetails(dsFeesDetails.Tables[1]);

                return objFees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return Formatter.FormatCurrency(this.TotalFees);
        }


        public Fees(int feesId)
        {
            // TODO: Complete member initialization
            this.FeesId = feesId;
        }

        public Fees()
        {
            // TODO: Complete member initialization
        }

        public string MembershipNo { get; set; }
        public decimal TotalOutstanding { get; set; }
        public int facilityPaid { get; set; }
    }

}
