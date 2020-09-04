using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Holiday
    {

      
        public int Id { get; set; }
   
        public string Name { get; set; }
        public DateTime Fromdate { get; set; }
        
       
        public DateTime Todate { get; set; }

        enum ColumnName
        {
            HOLM_ID,
            HOLM_FROM_DATE,
            HOLM_TO_DATE,
            HOLM_NAME,
            HOLM_BRANCH_ID,
            HOLM_CRTD_AT,
            HOLM_UPDT_AT,
            HOLM_DLTD_AT,
            HOLM_CRTD_BY,
            HOLM_UPDAT_BY,
            HOLM_DLTD_BY,
            ID

        }
        internal static List<Holiday> getHolidays(DataTable dtHoliday)
        {
            try
            {
                List<Holiday> lstHoliday = new List<Holiday>();

                foreach (DataRow drHolidy in dtHoliday.Rows)
                {
                    Holiday objholiday = new Holiday();

                    //if (drHolidy.Table.Columns.Contains("HOLM_ID") && drHolidy["HOLM_ID"] != DBNull.Value)
                    //{
                    //    objholiday.Id = Convert.ToInt32(drHolidy["HOLM_ID"]);
                    //}
                    objholiday.Id = EntityManager.getValue<Int32>(drHolidy, ColumnName.HOLM_ID.ToString());
                    //if (drHolidy.Table.Columns.Contains("HOLM_FROM_DATE") && drHolidy["HOLM_FROM_DATE"] != DBNull.Value)
                    //{
                    //    objholiday.Fromdate = Convert.ToDateTime(drHolidy["HOLM_FROM_DATE"].ToString());
                    //}
                    objholiday.Fromdate = EntityManager.getValue<DateTime>(drHolidy, ColumnName.HOLM_FROM_DATE.ToString());
                    //if (drHolidy.Table.Columns.Contains("HOLM_TO_DATE") && drHolidy["HOLM_TO_DATE"] != DBNull.Value)
                    //{
                    //    objholiday.Todate = Convert.ToDateTime(drHolidy["HOLM_TO_DATE"].ToString());
                    //}
                    objholiday.Todate = EntityManager.getValue<DateTime>(drHolidy, ColumnName.HOLM_TO_DATE.ToString());
                    //if (drHolidy.Table.Columns.Contains("HOLM_NAME") && drHolidy["HOLM_NAME"] != DBNull.Value)
                    //{
                    //    objholiday.Name = drHolidy["HOLM_NAME"].ToString();
                    //}
                    objholiday.Name = EntityManager.getValue<string>(drHolidy, ColumnName.HOLM_NAME.ToString());
                    lstHoliday.Add(objholiday);
                }
                return lstHoliday;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
