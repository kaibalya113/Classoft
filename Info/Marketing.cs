using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;

namespace ClassManager.Info
{
    [Serializable]
    public class Marketing
    {
  
        public int Id { get; set; }
      
        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string Group { get; set; }

        public DateTime BirthDay { get; set; }
        
        public DateTime Anniversary { get; set; }

        public string EmailID { get; set; }

        public string StudType { get; set; }


        public static List<Marketing> getGroup(DataTable dtGroup)
        {
            try
            {
                List<Marketing> lstGroup = new List<Marketing>();

                foreach (DataRow drGroup in dtGroup.Rows)
                {
                    Marketing objMark = Marketing.getGroups(drGroup);
                    lstGroup.Add(getGroups(drGroup));
                }

                return lstGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        enum ColumnName
        {
            MKTG_ID,
            MKTG_STUDENT_NAME,
            MKTG_PHONE_NO,
            MKTG_STREAM,
            MKTG_BIRTH_DATE,
            MKTG_ANIVERSRY_DATE,
            MKTG_EMAILID,
            MKTG_STUDENT_TYPE,
            MKTG_BRANCH_ID,
            MKTG_CRTD_AT,
            MKTG_UPDT_AT,
            MKTG_DLTD_AT,
            MKTG_CRTD_BY,
            MKTG_UPDAT_BY,
            MKTG_DLTD_BY,
            ID

        }

        public static Marketing getGroups(System.Data.DataRow drGrp)
        {
            try
            {
                Marketing objMarketing = new Marketing();
            //if (drGrp.Table.Columns.Contains("MKTG_STUDENT_NAME") && drGrp["MKTG_STUDENT_NAME"] != DBNull.Value)
            //{
            //    objMarketing.Name = drGrp["MKTG_STUDENT_NAME"].ToString();
            //}
            objMarketing.Name = EntityManager.getValue<string>(drGrp, ColumnName.MKTG_STUDENT_NAME.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_STREAM") && drGrp["MKTG_STREAM"] != DBNull.Value)
            //{
            //    objMarketing.Stream = drGrp["MKTG_STREAM"].ToString();
            //}
            objMarketing.Group = EntityManager.getValue<string>(drGrp, ColumnName.MKTG_STREAM.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_PHONE_NO") && drGrp["MKTG_PHONE_NO"] != DBNull.Value)
            //{
            //    objMarketing.ContactNo = drGrp["MKTG_PHONE_NO"].ToString();
            //}
            objMarketing.ContactNo = EntityManager.getValue<string>(drGrp, ColumnName.MKTG_PHONE_NO.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_ID") && drGrp["MKTG_ID"] != DBNull.Value)
            //{
            //    objMarketing.Id = Convert.ToInt32(drGrp["MKTG_ID"]);
            //}
            objMarketing.Id = EntityManager.getValue<Int32>(drGrp, ColumnName.MKTG_ID.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_BIRTH_DATE") && drGrp["MKTG_BIRTH_DATE"] != DBNull.Value)
            //{
            //    objMarketing.BirthDay = Convert.ToDateTime(drGrp["MKTG_BIRTH_DATE"]);

            //}
            objMarketing.BirthDay = EntityManager.getValue<DateTime>(drGrp, ColumnName.MKTG_BIRTH_DATE.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_ANIVERSRY_DATE") && drGrp["MKTG_ANIVERSRY_DATE"] != DBNull.Value)
            //{
            //    objMarketing.Anniversary = Convert.ToDateTime(drGrp["MKTG_ANIVERSRY_DATE"]);
            //}
            objMarketing.Anniversary = EntityManager.getValue<DateTime>(drGrp, ColumnName.MKTG_ANIVERSRY_DATE.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_EMAILID") && drGrp["MKTG_EMAILID"] != DBNull.Value)
            //{
            //    objMarketing.EmailID = (drGrp["MKTG_EMAILID"]).ToString();
            //}
            objMarketing.EmailID = EntityManager.getValue<string>(drGrp, ColumnName.MKTG_EMAILID.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_ID") && drGrp["MKTG_ID"] != DBNull.Value)
            //{
            //    objMarketing.Id = Convert.ToInt32(drGrp["MKTG_ID"]);
            //}
            //objMarketing.Id = EntityManager.getValue<Int32>(drGrp, ColumnName.MKTG_ID.ToString());
            //if (drGrp.Table.Columns.Contains("MKTG_STUDENT_TYPE") && drGrp["MKTG_STUDENT_TYPE"] != DBNull.Value)
            //{
            //    objMarketing.StudType = drGrp["MKTG_STUDENT_TYPE"].ToString();
            //}
            objMarketing.StudType = EntityManager.getValue<string>(drGrp, ColumnName.MKTG_STUDENT_TYPE.ToString());
            return objMarketing;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}