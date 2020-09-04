using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Followup
    {

        public enum TpyeOfFollowUp
        {
            Enquiry = 0,
            Fees = 1,
            Attendance=2,
            OutstandingDue=3
        }
        public enum FollowupMedium
        {
            Telephonic = 0,
            Mail = 1,
            Sms = 2,
        }

        public Student Student { get; set; }

        public int FollowupID { get; set; }

        public string ReferenceID { get; set; }
         
        public int BranchID { get; set; }

        public string FollowupType { get; set; }

        public DateTime FollowupDate { get; set; }

        public string FollowupDesc { get; set; }

        public string FollowupMediam { get; set; }

        public string FollowupBy{ get; set; }

        public static List<Followup> getFollowups(DataTable dtFolwp)
        {
            try
            {
                List<Followup> lstFollwp = new List<Followup>();

                foreach (DataRow drFolwp in dtFolwp.Rows)
                {
                    lstFollwp.Add(getFollowUp(drFolwp));
                }
                return lstFollwp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        enum ColumnName
        {
            FOLU_ID,
            FOLU_REF_NO,
            FOLU_FOLLOWUP_TYPE,
            FOLU_DATE,
            FOLU_DESCRIPTION,
            FOLU_MEDIUM,
            FOLU_BRANCH_ID,
            //added by ashvini 04-02-2019
            FOLU_CRTD_AT,
            //end by ashvini
            FOLU_UPDT_AT,
            FOLU_DLTD_AT,
            FOLU_CRTD_BY,
            FOLU_UPDAT_BY,
            FOLU_DLTD_BY,
            ID,
            FOLU_BY

        }
        public static Followup getFollowUp(DataRow drFolwp)
        {
            try
            {
                Followup objFollowup = new Followup();
                //if (drFolwp.Table.Columns.Contains("FOLU_ID") && drFolwp["FOLU_ID"] != DBNull.Value)
                //{
                //    objFollowup.FollowupID = Convert.ToInt32(drFolwp["FOLU_ID"]);
                //}
                objFollowup.FollowupID = EntityManager.getValue<Int32>(drFolwp, ColumnName.FOLU_ID.ToString());
                //if (drFolwp.Table.Columns.Contains("FOLU_REF_NO") && drFolwp["FOLU_REF_NO"] != DBNull.Value)
                //{
                //    objFollowup.ReferenceID = drFolwp["FOLU_REF_NO"].ToString();
                //}
                objFollowup.ReferenceID = EntityManager.getValue<string>(drFolwp, ColumnName.FOLU_REF_NO.ToString());
                //if (drFolwp.Table.Columns.Contains("FOLU_FOLLOWUP_TYPE") && drFolwp["FOLU_FOLLOWUP_TYPE"] != DBNull.Value)
                //{
                //    objFollowup.FollowupType = drFolwp["FOLU_FOLLOWUP_TYPE"].ToString();
                //}
                objFollowup.FollowupType = EntityManager.getValue<string>(drFolwp, ColumnName.FOLU_FOLLOWUP_TYPE.ToString());
                //if (drFolwp.Table.Columns.Contains("FOLU_DATE") && drFolwp["FOLU_DATE"] != DBNull.Value)
                //{
                //    objFollowup.FollowupDate = Convert.ToDateTime(drFolwp["FOLU_DATE"]);
                //}
                objFollowup.FollowupDate = EntityManager.getValue<DateTime>(drFolwp, ColumnName.FOLU_DATE.ToString());
                //if (drFolwp.Table.Columns.Contains("FOLU_DESCRIPTION") && drFolwp["FOLU_DESCRIPTION"] != DBNull.Value)
                //{
                //    objFollowup.FollowupDesc = drFolwp["FOLU_DESCRIPTION"].ToString();
                //}
                objFollowup.FollowupDesc = EntityManager.getValue<string>(drFolwp, ColumnName.FOLU_DESCRIPTION.ToString());
                //if (drFolwp.Table.Columns.Contains("FOLU_MEDIUM") && drFolwp["FOLU_MEDIUM"] != DBNull.Value)
                //{
                //    objFollowup.FollowupMediam = drFolwp["FOLU_MEDIUM"].ToString();
                //}
                objFollowup.FollowupMediam = EntityManager.getValue<string>(drFolwp, ColumnName.FOLU_MEDIUM.ToString());
                objFollowup.FollowupBy = EntityManager.getValue<string>(drFolwp, ColumnName.FOLU_BY.ToString());
                return objFollowup;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
