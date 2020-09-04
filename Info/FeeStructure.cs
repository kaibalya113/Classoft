using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class FeeStructure
    {

        public Decimal SubjAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int MainPackageId { get; set; }

        public bool AutoRenew { get; set; }
        public Decimal LumsumAmount { get; set; }
        public Decimal InstallmentAmt { get; set; }
        public bool IsLumSum { get; set; }
        public int PackageDuration { get; set; }

        public bool IsMainPackage { get; set; }
        public int MonthIncrement { get; set; }
        public Decimal RegistrationAmount { get; set; }
        public Decimal MiscAmount { get; set; }
        public string PackageName { get; set; }
        public PackageType PackageType { get; set; }

        public int Id { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalFees { get; set; }

        public bool RenewDiscount { get; set; }
        public Standard Standard { get; set; }
        Decimal packageCost;

        public int BranchID { get; set; }

        public Decimal PackageCost
        {
            get { return packageCost; }
            set
            {
                SubjAmount = value;
                packageCost = value;
            }
        }

        public decimal Discount { get; set; }
        public List<Info.PackageInstallment> packInstmnts;


        public override string ToString()
        {

            return PackageName + "\t" + SubjAmount + "\t" + PackageType.ToString();

        }
        public static List<FeesPackage> getFeeStructures(System.Data.DataTable subjectDt)
        {
            try
            {
                List<FeesPackage> lstFeeStructure = new List<FeesPackage>();
                foreach (DataRow dr in subjectDt.Rows)
                {
                    lstFeeStructure.Add(getFeeStructure(dr));
                }

                return lstFeeStructure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        enum ColumnName
        {
            FSTR_ID,
            FSTR_PACKAGE_ID,
            FSTR_SUBJECT_NAME,
            FSTR_AMOUNT,
            FSTR_LUMSUM_AMOUNT,
            FSTR_INSTALLMENT_AMOUNT,
            FSTR_REG_AMOUNT,
            FSTR_MISC_AMOUNT,
            FSTR_BRANCH_ID,
            FSTR_PACKAGE_TYPE,
            FSTR_IS_FACILITY,
            FSTR_AUTORENEW,
            FSTR_CRTD_AT,
            FSTR_UPDT_AT,
            FSTR_DLTD_AT,
            FSTR_CRTD_BY,
            FSTR_UPDAT_BY,
            FSTR_DLTD_BY,
            ID

        }

        public static FeesPackage getFeeStructure(DataRow dr)
        {
            try
            {
                FeesPackage objFeeStructure = new FeesPackage();
                objFeeStructure.IsMainPackage = false;
                objFeeStructure.InstallmentAmt = EntityManager.getValue<decimal>(dr, ColumnName.FSTR_INSTALLMENT_AMOUNT.ToString());
                objFeeStructure.LumsumAmount = EntityManager.getValue<decimal>(dr, ColumnName.FSTR_LUMSUM_AMOUNT.ToString());
                objFeeStructure.MiscAmount = EntityManager.getValue<decimal>(dr, ColumnName.FSTR_MISC_AMOUNT.ToString());
                objFeeStructure.RegistrationAmount = EntityManager.getValue<decimal>(dr, ColumnName.FSTR_REG_AMOUNT.ToString());
                objFeeStructure.SubjAmount = EntityManager.getValue<decimal>(dr, ColumnName.FSTR_AMOUNT.ToString());
                objFeeStructure.PackageName = EntityManager.getValue<string>(dr, ColumnName.FSTR_SUBJECT_NAME.ToString());
                objFeeStructure.PackageType = EntityManager.getValue<PackageType>(dr, ColumnName.FSTR_PACKAGE_TYPE.ToString());
                objFeeStructure.AutoRenew = EntityManager.getValue<bool>(dr, ColumnName.FSTR_AUTORENEW.ToString());
                objFeeStructure.Id = EntityManager.getValue<Int32>(dr, ColumnName.FSTR_ID.ToString());
                objFeeStructure.IsMainPackage = false;
                objFeeStructure.MainPackageId = EntityManager.getValue<Int32>(dr, ColumnName.FSTR_PACKAGE_ID.ToString());

                objFeeStructure.Standard = Standard.getStandard(dr);
                objFeeStructure.MonthIncrement = getMonthIncerment(objFeeStructure.PackageType);

                return objFeeStructure;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public static int getMonthIncerment(Info.PackageType packageType)
        {
            switch (packageType)
            {
                case PackageType.HALF_YEARLY: return 6;
                case PackageType.MONTHLY: return 1;
                case PackageType.QUARTERLY: return 3;
                case PackageType.YEARLY: return 12;
                default: return 0;
            }
        }



    }
}
