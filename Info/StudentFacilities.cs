using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace ClassManager.Info
{
    [Serializable]
    public class StudentFacility
    {
        public int Id { get; set; }
        public string FacilityName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status {  get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public bool AutoRenewEnabled { get; set; }
        public string Reason { get; set; }
        public bool RenewDiscount { get; set; }
        public decimal RenewalDiscount { get; set; }
        public string FacultyName { get; set; }
        public decimal CreditAmount { get; set; }
        public FeesPackage Package { get; set; }
        public Student Student { get; set; }
        public Branch Branch { get; set; }

        public List<DateTime> selectedMonths { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsMainPackage { get; private set; }

        public string DiscountReason { get; set; }
        public int InvoiceId { get;  set; }
        public decimal Pending { get; set; }
        public decimal Amount_Paid { get; set; }
        public decimal Canc_Amt{ get; set; }
        public decimal OutstandingFees { get; set; }
        public Batch Batch { get; set; }

        public Int32 InstructorId { get; set; }

        public Standard standard;

        public List<Info.InstallmentDetail> Installments;

        public bool RemindRenewal;

        public override string ToString()
        {
            return (this.FacilityName == "") ? this.Package.PackageName : this.FacilityName;
        }

        enum ColumnName
        {
            STFL_ID,
            STFL_ADMISSION_NO,
            STFL_FACILITY_NAME,
            STFL_PACKAGE_ID,
            
            STFL_ADMSION_DATE,
            STFL_FROM_DATE,
            STFL_TO_DATE,
            STFL_STATUS,
            STFL_FEES_ID,
            STFL_AMOUNT,
            STFL_IS_MAIN_PACKAGE,
            STFL_IS_AUTO_RENEW,
            STFL_DISCOUNT,
            STFL_BRANCH_ID,
            STFL_IS_RENEW_DISCOUNT,
            STFL_RENEWAL_DISCOUNT,
            STFL_CRTD_AT,
            STFL_UPDT_AT,
            STFL_DLTD_AT,
            STFL_CRTD_BY,
            STFL_UPDAT_BY,
            STFL_DLTD_BY,
            ID,
            STFL_INVC_ID,
            STFL_REMIND_RENEWAL,
            STFL_INSTRUCTIR_ID,
            STFL_EXPIRY_SMS_DATE,
            FCLT_NAME,
            STFL_CREDIT_AMOUNT
        }
        public static StudentFacility getStudentFacility(DataRow dr)
        {
            try
            {
                StudentFacility objFacility = new StudentFacility();

               
                objFacility.Id = EntityManager.getValue<Int32>(dr, ColumnName.STFL_ID.ToString());
                objFacility.FacilityName = EntityManager.getValue<string>(dr, ColumnName.STFL_FACILITY_NAME.ToString());
                objFacility.FromDate = EntityManager.getValue<DateTime>(dr, ColumnName.STFL_FROM_DATE.ToString());
                objFacility.ToDate = EntityManager.getValue<DateTime>(dr, ColumnName.STFL_TO_DATE.ToString());
                objFacility.Status = EntityManager.getValue<string>(dr, ColumnName.STFL_STATUS.ToString());
                objFacility.Amount = EntityManager.getValue<decimal>(dr, ColumnName.STFL_AMOUNT.ToString());
                objFacility.Discount = EntityManager.getValue<decimal>(dr, ColumnName.STFL_DISCOUNT.ToString());
                objFacility.AutoRenewEnabled = EntityManager.getValue<bool>(dr, ColumnName.STFL_IS_AUTO_RENEW.ToString());
                objFacility.RenewalDiscount = EntityManager.getValue<decimal>(dr, ColumnName.STFL_RENEWAL_DISCOUNT.ToString());
                objFacility.RenewDiscount = EntityManager.getValue<bool>(dr, ColumnName.STFL_IS_RENEW_DISCOUNT.ToString());
                objFacility.AdmissionDate = EntityManager.getValue<DateTime>(dr, ColumnName.STFL_ADMSION_DATE.ToString());
                objFacility.IsMainPackage = EntityManager.getValue<bool>(dr, ColumnName.STFL_IS_MAIN_PACKAGE.ToString());
                objFacility.Pending = EntityManager.getValue<Decimal>(dr, "pending");
                objFacility.Amount_Paid = EntityManager.getValue<Decimal>(dr, "Amount_Paid");
                objFacility.Canc_Amt = EntityManager.getValue<Decimal>(dr, "Canc_Amt");
                objFacility.FacultyName = EntityManager.getValue<string>(dr, ColumnName.FCLT_NAME.ToString());
                objFacility.Branch = Branch.getBranch(dr);
                objFacility.Student = Info.Student.getStudent(dr);
                // objFacility.Installments = Info.InstallmentDetail.getInstallmentDetail(dr);
                objFacility.InvoiceId = EntityManager.getValue<Int32>(dr, ColumnName.STFL_INVC_ID.ToString());
                objFacility.CreditAmount = EntityManager.getValue<Decimal>(dr, ColumnName.STFL_CREDIT_AMOUNT.ToString());
                objFacility.RemindRenewal = EntityManager.getValue<bool>(dr, ColumnName.STFL_REMIND_RENEWAL.ToString());

                if (objFacility.IsMainPackage == true)
                {
                    objFacility.Package = FeesPackage.getPackage(dr);
                }
                else
                {
                    objFacility.Package = FeeStructure.getFeeStructure(dr);
                }
                if(SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).Equals("") && objFacility.Package != null && objFacility.Package.Standard != null && objFacility.Package.Standard.Stream != null )
                {
                    objFacility.FacilityName = objFacility.Package.Standard.StandardName + "/" + objFacility.Package.Standard.Stream.Name;
                }

                return objFacility;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        public static List<StudentFacility> getStudentFacilities(DataSet dsFacility)
        {
            List<StudentFacility> lstFacilities = new List<StudentFacility>();
            
            foreach (DataRow drFacility in dsFacility.Tables[0].Rows)
            {
                lstFacilities.Add(getStudentFacility(drFacility));
            }

            foreach (DataRow drFacility in dsFacility.Tables[1].Rows)
            {
                lstFacilities.Add(getStudentFacility(drFacility));
            }

            return lstFacilities;
        }


        public static StudentFacility getStudentFacility(DataSet dsFacility)
        {
            StudentFacility objStudentFacility = getStudentFacility(dsFacility.Tables[0].Rows[0]);
            objStudentFacility.Installments = InstallmentDetail.getInstallmentDetails(dsFacility.Tables[1]); //Package Installments in second table
            return objStudentFacility;

        }

       
    }
}
