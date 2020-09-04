using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Info;

namespace ClassManager.BLL
{
    public class TemplateHandler
    {
        static SqlCommand objSqlCmd;

        public static DataTable getTemplate()
        {
            try
            {
                objSqlCmd = new SqlCommand("Select * from TEMPLATE");
                objSqlCmd.CommandType = CommandType.Text;
                DataTable dtTemplate = Sqlhelper.GetDatatable(objSqlCmd);
                return dtTemplate;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static string getTemplateByType(string type)
        {
            try
            {
                objSqlCmd = new SqlCommand("Select Temp_Template from TEMPLATE where Temp_Type = '" + type + "'");
                objSqlCmd.CommandType = CommandType.Text;
                Object o = Sqlhelper.ExeScaler(objSqlCmd);
                return o.ToString();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool updateTemplatesByType(string type, string Message)
        {
            objSqlCmd = new SqlCommand("Update TEMPLATE set TEMP_Template ='" + Message + "'where TEMP_Type = '" + type + "'");
            objSqlCmd.CommandType = CommandType.Text;

            Sqlhelper.ExecuteQuery(objSqlCmd);
            return true;

        }

        public static bool updateTemplates(Info.Template objtemplate)
        {
            objSqlCmd = new SqlCommand("Update TEMPLATE set TEMP_TEMPLATE ='" + objtemplate.Template_text + "'where TEMP_TYPE = '" + objtemplate.Template_name + "'");
            objSqlCmd.CommandType = CommandType.Text;

            Sqlhelper.ExecuteQuery(objSqlCmd);
            return true;

        }


        public static void loadTemplates()
        {
            try
            {
                SqlCommand com = new SqlCommand("select TEMP_TEMPLATE,TEMP_TYPE from TEMPLATE");

                DataTable dtSysParam = DAL.Sqlhelper.GetDatatable(com);
                Info.Template.dictSysParam = new Dictionary<TemplateType, object>();

                foreach (System.Data.DataRow dr in dtSysParam.Rows)
                {
                    Info.Template.dictSysParam.Add((TemplateType)Enum.Parse(typeof(TemplateType), dr["TEMP_TYPE"].ToString()), dr["TEMP_TEMPLATE"]);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
        }

    }
}
