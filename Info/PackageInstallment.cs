using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class PackageInstallment
    {
        public PackageInstallment()
        {
            Package = new FeesPackage();
        }
        public int countofInstallment { get; set; }

        public int InstallmentId { get; set; }

        public Decimal InstallmentAmount { get; set; }

        public int InstallmentDuration { get; set; }

        public int NoOfMonth { get; set; }

        public int NoOfDays { get; set; }

        public FeesPackage Package { get; set; }

        public Decimal Total { get; set; }

        public int Duration { get; set; }

        public string InstName { get; set; }

        enum ColumnName
        {
            PKGI_ID,
            PKGI_PKG_ID,
            PKGI_INSTLMNT_AMNT,
            PKGI_NO_OF_MONTHS,
            PKGI_NO_OF_DAYS,
            PKGI_DURATION,
            PKGI_BRANCH_ID,
            PKGI_CRTD_AT,
            PKGI_UPDT_AT,
            PKGI_DLTD_AT,
            PKGI_CRTD_BY,
            PKGI_UPDAT_BY,
            PKGI_DLTD_BY,
            ID,
            PKGI_INST_NAME

        }

        public static List<PackageInstallment> getInstallments(System.Data.DataTable installmentDT)
        {
            try
            {
                List<PackageInstallment> objPackgeInstallments = new List<PackageInstallment>();

                foreach (DataRow dr in installmentDT.Rows)
                {
                    PackageInstallment installment = new PackageInstallment();

                    //if (dr.Table.Columns.Contains("PKGI_INSTLMNT_AMNT") && dr["PKGI_INSTLMNT_AMNT"] != DBNull.Value)
                    //{
                    //    installment.InstallmentAmount = Convert.ToDecimal(dr["PKGI_INSTLMNT_AMNT"]);
                    //}
                    installment.InstallmentAmount = EntityManager.getValue<decimal>(dr, ColumnName.PKGI_INSTLMNT_AMNT.ToString());
                    //if (dr.Table.Columns.Contains("PKGI_ID") && dr["PKGI_ID"] != DBNull.Value)
                    //{
                    //    installment.InstallmentId = Convert.ToInt32(dr["PKGI_ID"]);
                    //}
                    installment.InstallmentId = EntityManager.getValue<Int32>(dr, ColumnName.PKGI_ID.ToString());
                    //if (dr.Table.Columns.Contains("PKGI_NO_OF_MONTHS") && dr["PKGI_NO_OF_MONTHS"] != DBNull.Value)
                    //{
                    //    installment.NoOfMonth = Convert.ToInt32(dr["PKGI_NO_OF_MONTHS"]);
                    //}
                    installment.NoOfMonth = EntityManager.getValue<Int32>(dr, ColumnName.PKGI_NO_OF_MONTHS.ToString());
                    //if (dr.Table.Columns.Contains("PKGI_NO_OF_DAYS") && dr["PKGI_NO_OF_DAYS"] != DBNull.Value)
                    //{
                    //    installment.NoOfDays = Convert.ToInt32(dr["PKGI_NO_OF_DAYS"]);
                    //}
                    installment.NoOfDays = EntityManager.getValue<Int32>(dr, ColumnName.PKGI_NO_OF_DAYS.ToString());
                    installment.InstName = EntityManager.getValue<string>(dr, ColumnName.PKGI_INST_NAME.ToString());
                    installment.Duration = EntityManager.getValue<int>(dr, ColumnName.PKGI_DURATION.ToString());
                    objPackgeInstallments.Add(installment);
                    installment.Package = FeesPackage.getPackage(dr);
                }
                return objPackgeInstallments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return "No : " + countofInstallment + " Amount :" + InstallmentAmount + " Month: " + NoOfMonth + " Days : " + NoOfDays;
        }

    }


}

