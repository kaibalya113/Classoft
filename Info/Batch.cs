using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Batch
    {
        public int id { get; set; }
        public int BatchDuration { get; set; }
        public string BatchDesc { get; set; }
        public string Name { get; set; }
        public int RollNoSeq { get; set; }
        public int StandardID { get; set; }
        public DateTime? StartDate { get; set; }
        public string location { get; set; }
        public Branch Branch { get; set; }
        public int minPercent { get; set;}
        enum ColumnName
        {
            BTCH_Id,
            BTCH_NAME,
            BTCH_ROLLNO_SEQ,
            BTCH_STANDARD_ID,
            BTCH_DESCRIPTION,
            BTCH_START_DATE,
            BTCH_LOCATION,
            BTCH_FROM_TIME,
            BTCH_TO_TIME,
            BTCH_BRANCH_ID


        }

        public DateTime? FromTime
        {
            get;
            set;
        }


        public DateTime? ToTime { get; set; }
        
        public Batch(int BatchId)
        {
            this.id = BatchId;
        }

        public Batch()
        {
            // TODO: Complete member initialization
        }
        
        public override string ToString()
        {
            return Name;
        }


        public static List<Batch> GetBatches(System.Data.DataTable dtBatches)
        {
         try
            {
                List<Batch> lstBatchs = new List<Batch>();
                foreach (DataRow drBatch in dtBatches.Rows)
                {
                    lstBatchs.Add(GetBatch(drBatch));
                }

                return lstBatchs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Batch GetBatch(DataRow drBatch)
        {
            try
            {
                Batch objBatch = new Batch();

                //if (drBatch.Table.Columns.Contains("BTCH_NAME") && drBatch["BTCH_NAME"] != DBNull.Value)
                //{
                //    objBatch.Name = drBatch["BTCH_NAME"].ToString();
                //}
                objBatch.Name = EntityManager.getValue<string>(drBatch, ColumnName.BTCH_NAME.ToString());
                //if (drBatch.Table.Columns.Contains("BTCH_Id") && drBatch["BTCH_Id"] != DBNull.Value)
                //{
                //    objBatch.id = Convert.ToInt32(drBatch["BTCH_Id"]);
                //}
                objBatch.id = EntityManager.getValue<Int32>(drBatch, ColumnName.BTCH_Id.ToString());
                //if (drBatch.Table.Columns.Contains("BTCH_STANDARD_ID") && drBatch["BTCH_STANDARD_ID"] != DBNull.Value)
                //{
                //    objBatch.StandardID = Convert.ToInt32(drBatch["BTCH_STANDARD_ID"].ToString());
                //}
                objBatch.StandardID = EntityManager.getValue<Int32>(drBatch, ColumnName.BTCH_STANDARD_ID.ToString());
                //if (drBatch.Table.Columns.Contains("BTCH_ROLLNO_SEQ") && drBatch["BTCH_ROLLNO_SEQ"] != DBNull.Value)
                //{
                //    objBatch.RollNoSeq = Convert.ToInt32(drBatch["BTCH_ROLLNO_SEQ"].ToString());
                //}
                objBatch.RollNoSeq = EntityManager.getValue<Int32>(drBatch, ColumnName.BTCH_ROLLNO_SEQ.ToString());

                //if (drBatch.Table.Columns.Contains("BTCH_START_DATE") && drBatch["BTCH_START_DATE"] != DBNull.Value)
                //{
                //    objBatch.StartDate = Convert.ToDateTime(drBatch["BTCH_START_DATE"].ToString());
                //}
                objBatch.StartDate = EntityManager.getValue<DateTime>(drBatch, ColumnName.BTCH_START_DATE.ToString());
                ////else
                ////{
                ////    objBatch.StartDate = null;
                ////}
                //if (drBatch.Table.Columns.Contains("BTCH_LOCATION") && drBatch["BTCH_LOCATION"] != DBNull.Value)
                //{
                //    objBatch.location = (drBatch["BTCH_LOCATION"]).ToString();
                //}
                objBatch.location = EntityManager.getValue<string>(drBatch, ColumnName.BTCH_LOCATION.ToString());
                //if (drBatch.Table.Columns.Contains("BTCH_FROM_TIME"))
                //{
                //    if (drBatch["BTCH_FROM_TIME"] != DBNull.Value)
                //    {
                //        objBatch.FromTime = DateTime.Now.Date + TimeSpan.Parse(drBatch["BTCH_FROM_TIME"].ToString());
                //    }
                objBatch.FromTime = EntityManager.getTime<DateTime>(drBatch, ColumnName.BTCH_FROM_TIME.ToString());
                //    else
                //    {
                //        objBatch.FromTime = null;
                //    }
                //}
                //if (drBatch.Table.Columns.Contains("BTCH_TO_TIME") && drBatch["BTCH_TO_TIME"] != DBNull.Value)
                //{
                //    if (drBatch["BTCH_TO_TIME"] != DBNull.Value)
                //    {
                //objbatch.totime = datetime.now.date + timespan.parse(drbatch["btch_to_time"].tostring());
                //    }
                //    else
                //    {
                //        objBatch.ToTime = null;
                //    }
                //}
                objBatch.ToTime = EntityManager.getTime<DateTime>(drBatch, ColumnName.BTCH_TO_TIME.ToString());
                objBatch.Branch = Branch.getBranch(drBatch);
                return objBatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
