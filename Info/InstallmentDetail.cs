using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ClassManager.Info
{
    [Serializable]
    public class InstallmentDetail : ICloneable
    {
        public int Id { get; set; }                
        public int InstMonth { get; set; }        
        public int InstNo { get; set; }        
        public DateTime InstDate { get; set; }        
        public Decimal AmntPaid { get; set; }
        public Decimal InstAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }        
        public Decimal TodaysDue { get; set; }
        public Decimal Discount { get; set; }
        public string Reason { get; set; }
        public Decimal CancelledAmount { get; set; }
        public string Description { get; set; }
        public Fees Fees { get; set; }
        public StudentFacility Facility { get; set; }
        public int Duration { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
       
        private InstallmentDetail installmentStructure;
        
        
        public object Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (InstallmentDetail)formatter.Deserialize(ms);
            }
        }


        public static List<InstallmentDetail> getInstallmentDetails(System.Data.DataTable installmentDT)
        {
            try
            {
                List<InstallmentDetail> objPackgeInstallments = new List<InstallmentDetail>();
                foreach (DataRow dataRow in installmentDT.Rows)
                {
                    objPackgeInstallments.Add(getInstallmentDetail(dataRow));
                }
                return objPackgeInstallments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        enum ColumnName
        {
            INSD_ID,
            INSD_FEES_ID,
            INSD_INST_MONTH,
            INSD_INST_NO,
            INSD_DATE,
            INSD_AMOUNT_PAID,
            INSD_PAYMENT_DATE,
            INSD_CNCLD_AMT,
            INSD_STATUS,
            INSD_INSTMNT_AMT,
            INSD_DISCOUNT,
            INSD_TOTAL_DISCOUNT,
            INSD_DESC,
            INSD_FACILITY_ID,
            INSD_BRANCH_ID,
            INSD_COURCE_ID,
            INSD_CRTD_AT,
            INSD_UPDT_AT,
            INSD_DLTD_AT,
            INSD_CRTD_BY,
            INSD_UPDAT_BY,
            INSD_DLTD_BY,
            ID,
            INSD_REASON,
            INSD_DURATION

        }

        public static InstallmentDetail getInstallmentDetail(DataRow dataRow)
        {
            try
            {
                InstallmentDetail installment = new InstallmentDetail();

                installment.PaymentDate = null;

               
                installment.Id = EntityManager.getValue<Int32>(dataRow, ColumnName.INSD_ID.ToString());
                
                installment.InstMonth = EntityManager.getValue<Int32>(dataRow, ColumnName.INSD_INST_MONTH.ToString());
                
                installment.InstNo = EntityManager.getValue<Int32>(dataRow, ColumnName.INSD_INST_NO.ToString());
                
                installment.InstDate = EntityManager.getValue<DateTime>(dataRow, ColumnName.INSD_DATE.ToString());
                
                installment.AmntPaid = EntityManager.getValue<decimal>(dataRow, ColumnName.INSD_AMOUNT_PAID.ToString());

                installment.CancelledAmount = EntityManager.getValue<decimal>(dataRow, ColumnName.INSD_CNCLD_AMT.ToString());


                installment.Duration = EntityManager.getValue<int>(dataRow, ColumnName.INSD_DURATION.ToString());
                DateTime? tempPaymentDate = null;

                EntityManager.setValue<DateTime?>(dataRow, ColumnName.INSD_PAYMENT_DATE.ToString(),out tempPaymentDate);
                installment.PaymentDate = tempPaymentDate;


                installment.Status = EntityManager.getValue<string>(dataRow, ColumnName.INSD_STATUS.ToString());
                
                installment.InstAmount = EntityManager.getValue<decimal>(dataRow, ColumnName.INSD_INSTMNT_AMT.ToString());
                
                installment.Discount = EntityManager.getValue<decimal>(dataRow, ColumnName.INSD_DISCOUNT.ToString());
                installment.Reason = EntityManager.getValue<string>(dataRow, ColumnName.INSD_REASON.ToString());
                installment.Description = EntityManager.getValue<string>(dataRow, ColumnName.INSD_DESC.ToString());
                installment.Fees = Fees.getFees(dataRow);
              //  installment.Duration = PackageInstallment.getInstallments(dataRow);
                installment.Facility = StudentFacility.getStudentFacility(dataRow);
                installment.FromDate = installment.Facility.FromDate;
                installment.ToDate = installment.Facility.ToDate;
            return installment;


            }
            catch (Exception ex)
             {
                throw ex;
            }
        }

    }
}
