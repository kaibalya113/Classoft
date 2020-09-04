using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class FeesPackage : Info.FeeStructure
    {
        #region "Variables and Properties"


        public FeesPackage() : base()
        {
            Subjects = new List<FeesPackage>();
        }

        
        public bool HasOptionalSubject { get; set; }
        public int ValidStandards { get; set; }
        public string ComboID { get; set; }
        public List<FeesPackage> Subjects { get; set; }
        public string SubList { get; set; }
        public string SACCode { get; set; }
        public override string ToString()
        {
            return PackageName; 
        }

        public Decimal RecurAmnt { get; set; }
        public Decimal TotalTuiAmnt { get; set; }
        public decimal SGSTPercentage { get; set; }
        public decimal CGSTPercentage { get; set; }
        public double PackageDurationDays { get; set; }
        public bool RemindRenewal { get; set; }

        #endregion



        public static List<FeesPackage> getPackages(DataTable dtStd)
        {
            try
            {
                List<FeesPackage> lstPackage = new List<FeesPackage>();

                foreach (DataRow drStd in dtStd.Rows)
                {
                    lstPackage.Add(getPackage(drStd));
                }

                return lstPackage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        enum ColumnName
        {
            FPKG_ID,
            FPKG_STANDARD_ID,
            FPKG_COMBO_ID,
            FPKG_PACKAGE_NAME,
            FPKG_SUBJECT,
            FPKG_PACKAGE_TYPE,
            FPKG_VALID_STANDARD,
            FPKG_REG_FEES,
            FPKG_MISC_FEES,
            FPKG_RECURSIVE_FEES,
            FPKG_TOTAL_TUTION_FEES,
            FPKG_PACKAGE_COST,
            FPKG_LUMSUM_AMOUNT,
            FPKG_HAS_OPTIONAL_SUBJECTS,
            FPKG_DURATION,
            FPKG_AUTORENEW,
            FPKG_BRANCH_ID,
            FPKG_CRTD_AT,
            FPKG_UPDT_AT,
            FPKG_DLTD_AT,
            FPKG_CRTD_BY,
            FPKG_UPDAT_BY,
            FPKG_DLTD_BY,
            ID,
            FPKG_SAC_CODE,
            FPKG_SGST_PER,
            FPKG_CGST_PER,
            FPKG_DURATION_DAYS,
            FPKG_RMIND_RENEWAL

        }

        internal static Info.FeesPackage getPackage(DataRow drPkg)
        {
            try
            {
                Info.FeesPackage fPackage = new Info.FeesPackage();

                fPackage.IsMainPackage = true;
                fPackage.Id = EntityManager.getValue<Int32>(drPkg, ColumnName.FPKG_ID.ToString());
                fPackage.PackageName = EntityManager.getValue<string>(drPkg, ColumnName.FPKG_PACKAGE_NAME.ToString());
                fPackage.ComboID = EntityManager.getValue<string>(drPkg, ColumnName.FPKG_COMBO_ID.ToString());
                fPackage.PackageType = EntityManager.getValue<PackageType>(drPkg, ColumnName.FPKG_PACKAGE_TYPE.ToString());
                fPackage.SubList = EntityManager.getValue<string>(drPkg, ColumnName.FPKG_SUBJECT.ToString());
                fPackage.ValidStandards = EntityManager.getValue<Int32>(drPkg, ColumnName.FPKG_VALID_STANDARD.ToString());
                fPackage.RegistrationAmount = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_REG_FEES.ToString());
                fPackage.MiscAmount = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_MISC_FEES.ToString());
                fPackage.RecurAmnt = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_RECURSIVE_FEES.ToString());
                fPackage.TotalTuiAmnt = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_TOTAL_TUTION_FEES.ToString());
                fPackage.LumsumAmount = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_LUMSUM_AMOUNT.ToString());
                fPackage.PackageCost = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_PACKAGE_COST.ToString());
                fPackage.HasOptionalSubject = EntityManager.getValue<bool>(drPkg, ColumnName.FPKG_HAS_OPTIONAL_SUBJECTS.ToString());
                fPackage.AutoRenew = EntityManager.getValue<bool>(drPkg, ColumnName.FPKG_AUTORENEW.ToString());
                fPackage.RemindRenewal = EntityManager.getValue<bool>(drPkg, ColumnName.FPKG_RMIND_RENEWAL.ToString());
                
                fPackage.PackageDuration = EntityManager.getValue<Int32>(drPkg, ColumnName.FPKG_DURATION.ToString());
                fPackage.MonthIncrement = getMonthIncerment(fPackage.PackageType);
                fPackage.BranchID= EntityManager.getValue<Int32>(drPkg, ColumnName.FPKG_BRANCH_ID.ToString());
                fPackage.SubjAmount = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_RECURSIVE_FEES.ToString());
                fPackage.SACCode = EntityManager.getValue<string>(drPkg, ColumnName.FPKG_SAC_CODE.ToString());
                fPackage.SGSTPercentage = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_SGST_PER.ToString());
                fPackage.CGSTPercentage = EntityManager.getValue<decimal>(drPkg, ColumnName.FPKG_CGST_PER.ToString());
                fPackage.PackageDurationDays = EntityManager.getValue<Int32>(drPkg, ColumnName.FPKG_DURATION_DAYS.ToString());

                fPackage.Standard = Standard.getStandard(drPkg);
                return fPackage;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Info.FeesPackage getPackage(DataSet dsPackage)
        {
            try
            {
                FeesPackage package = new FeesPackage();
                if (dsPackage.Tables[0].Rows.Count > 0)
                {
                    package = getPackage(dsPackage.Tables[0].Rows[0]);
                }
                package.packInstmnts = PackageInstallment.getInstallments(dsPackage.Tables[1]);
                package.Subjects = FeeStructure.getFeeStructures(dsPackage.Tables[2]);

                return package;
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public FeesPackage Clone()
        {
            return this.MemberwiseClone() as FeesPackage;
        }
    }
}
