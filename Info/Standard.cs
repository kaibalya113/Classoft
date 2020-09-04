using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;

namespace ClassManager.Info
{
    [Serializable]
    public class Standard
    {

        public string DisplayName { get; set; }
        public int Standardid { get; set; }
        public string StandardName { get; set; }
        public Stream Stream { get; set; }
        public int DurationInMonths { get; set; }
        public DateTime AdmissinoDate { get; set; }
        public Branch Branch { get; set; }

        public Standard()
        {
            Stream = new Stream();
            Branch = new Branch();
        }


        //public override string ToString()
        //{
        //    if (DisplayName == null)
        //    {
        //        DisplayName = StandardName;
        //    }
        //    return DisplayName;

        //}


        public static List<Standard> getStandards(DataTable dtStandards)
        {
            try
            {
                List<Standard> lstStandards = new List<Standard>();

                foreach (DataRow drStandards in dtStandards.Rows)
                {
                    lstStandards.Add(getStandard(drStandards));
                }

                return lstStandards;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        enum ColumnName
        {
            STD_ID,
            STD_NAME,
            STD_DURATION,
            STD_STREAM_ID,
            STD_BRANCH_ID,
            STD_CRTD_AT,
            STD_UPDT_AT,
            STD_DLTD_AT,
            STD_CRTD_BY,
            STD_UPDAT_BY,
            STD_DLTD_BY,
            ID

        }

        public static Standard getStandard(DataRow drStandard)
        {
            try
            {
                Standard objStandard = new Standard();
                //if (drStandard.Table.Columns.Contains("STD_ID") && drStandard["STD_ID"] != DBNull.Value)
                //{
                //    objStandard.Standardid = Convert.ToInt32(drStandard["STD_ID"]);
                //}
                objStandard.Standardid = EntityManager.getValue<Int32>(drStandard, ColumnName.STD_ID.ToString());
                //if (drStandard.Table.Columns.Contains("STD_NAME") && drStandard["STD_NAME"] != DBNull.Value)
                //{
                //    objStandard.StandardName = drStandard["STD_NAME"].ToString();
                //}
                objStandard.StandardName = EntityManager.getValue<string>(drStandard, ColumnName.STD_NAME.ToString());
                //if (drStandard.Table.Columns.Contains("STD_DURATION") && drStandard["STD_DURATION"] != DBNull.Value)
                //{
                //    objStandard.DurationInMonths = Convert.ToInt32(drStandard["STD_DURATION"]);
                //}
                objStandard.DurationInMonths = EntityManager.getValue<Int32>(drStandard, ColumnName.STD_DURATION.ToString());
                //if (drStandard.Table.Columns.Contains("AdmissionDate") && drStandard["AdmissionDate"] != DBNull.Value)
                //{
                //    objStandard.AdmissinoDate = Convert.ToDateTime(drStandard["AdmissionDate"]);
                //}
                //objStandard.AdmissinoDate = EntityManager.getValue<DateTime>(drStandard, ColumnName.A.ToString());
                objStandard.Stream = Stream.getStream(drStandard);

                return objStandard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return StandardName;
        }


    }
}