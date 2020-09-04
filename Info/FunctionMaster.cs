using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    public class FunctionMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortcutKey { get; set; }
        public string HotKey { get; set; }
        public string FormClass { get; set; }
        public string FormAssembly { get; set; }
        public string LevelIndicator { get; set; }
        public int ParentId { get; set; }
        public int GroupSeqno { get; set; }
        public string AppName { get; set; }


        public static List<FunctionMaster> getFunctionMaster(DataTable dtFunctions)
        {
            List<FunctionMaster> lstFunctionMaster = new List<FunctionMaster>();

            try
            {
                foreach (DataRow dr in dtFunctions.Rows)
                {
                    lstFunctionMaster.Add(getFunctionMaster(dr));
                }

                return lstFunctionMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        enum ColumnName
        {
                FM_ID,
                FM_NAME,
                FM_SHORT_KEY,
                FM_HOT_KEY,
                FM_FORM_CLASS,
                FM_FORM_ASSEMBLY,
                FM_LEVEL_INDCTR,
                FM_PARENT_ID,
                FM_GRP_SEQ,
                FM_BRANCH_ID,
                FM_CRTD_AT,
                FM_UPDT_AT,
                FM_DLTD_AT,
                FM_CRTD_BY,
                FM_UPDAT_BY,
                FM_DLTD_BY,
                ID,
                FM_APP_NAME

        }
        public static FunctionMaster getFunctionMaster(DataRow dr)
        {
            try
            {
                FunctionMaster objFunctionMaster = new FunctionMaster();

                //if (dr.Table.Columns.Contains("FM_ID") && dr["FM_ID"] != DBNull.Value)
                //{
                //    objFunctionMaster.ID = Convert.ToInt32(dr["FM_ID"]);
                //}
                objFunctionMaster.ID = EntityManager.getValue<Int32>(dr, ColumnName.FM_ID.ToString());
                //if (dr.Table.Columns.Contains("FM_NAME") && dr["FM_NAME"] != DBNull.Value)
                //{
                //    objFunctionMaster.Name = dr["FM_NAME"].ToString();
                //}
                objFunctionMaster.Name = EntityManager.getValue<string>(dr, ColumnName.FM_NAME.ToString());
                //if (dr.Table.Columns.Contains("FM_SHORT_KEY") && dr["FM_SHORT_KEY"] != DBNull.Value)
                //{
                //    objFunctionMaster.ShortcutKey = dr["FM_SHORT_KEY"].ToString();
                //}
                objFunctionMaster.ShortcutKey = EntityManager.getValue<string>(dr, ColumnName.FM_SHORT_KEY.ToString());
                //if (dr.Table.Columns.Contains("FM_HOT_KEY") && dr["FM_HOT_KEY"] != DBNull.Value)
                //{
                //    objFunctionMaster.HotKey = dr["FM_HOT_KEY"].ToString();
                //}
                objFunctionMaster.HotKey = EntityManager.getValue<string>(dr, ColumnName.FM_HOT_KEY.ToString());
                //if (dr.Table.Columns.Contains("FM_FORM_CLASS") && dr["FM_FORM_CLASS"] != DBNull.Value)
                //{
                //    objFunctionMaster.FormClass = dr["FM_FORM_CLASS"].ToString();
                //}
                objFunctionMaster.FormClass = EntityManager.getValue<string>(dr, ColumnName.FM_FORM_CLASS.ToString());
                //if (dr.Table.Columns.Contains("FM_FORM_ASSEMBLY") && dr["FM_FORM_ASSEMBLY"] != DBNull.Value)
                //{
                //    objFunctionMaster.FormAssembly = dr["FM_FORM_ASSEMBLY"].ToString();
                //}
                objFunctionMaster.FormAssembly = EntityManager.getValue<string>(dr, ColumnName.FM_FORM_ASSEMBLY.ToString());
                //if (dr.Table.Columns.Contains("FM_LEVEL_INDCTR") && dr["FM_LEVEL_INDCTR"] != DBNull.Value)
                //{
                //    objFunctionMaster.LevelIndicator = dr["FM_LEVEL_INDCTR"].ToString();
                //}
                objFunctionMaster.LevelIndicator = EntityManager.getValue<string>(dr, ColumnName.FM_LEVEL_INDCTR.ToString());
                //if (dr.Table.Columns.Contains("FM_PARENT_ID") && dr["FM_PARENT_ID"] != DBNull.Value)
                //{
                //    objFunctionMaster.ParentId = Convert.ToInt32(dr["FM_PARENT_ID"]);
                //}
                objFunctionMaster.ParentId = EntityManager.getValue<Int32>(dr, ColumnName.FM_PARENT_ID.ToString());
                //if (dr.Table.Columns.Contains("FM_GRP_SEQ") && dr["FM_GRP_SEQ"] != DBNull.Value)
                //{
                //    objFunctionMaster.GroupSeqno = Convert.ToInt32(dr["FM_GRP_SEQ"]);
                //}
                objFunctionMaster.GroupSeqno = EntityManager.getValue<Int32>(dr, ColumnName.FM_GRP_SEQ.ToString());
                objFunctionMaster.AppName = EntityManager.getValue<string>(dr, ColumnName.FM_APP_NAME.ToString());
                return objFunctionMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public override String ToString()
        {
            return Name.Replace("&","");
        }

    }
}
