using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using static ClassManager.Info.SysParam;

namespace ClassManager.BLL
{
    public class SystemParameterHandler
    {
        static SqlCommand objSqlCmd;

        public static void updateSysParam(Info.SysParam.Parameters parameterName, string param_Value, int branchId = 0)
        {
            try
            {
                if (Info.SysParam.branchMasterParameters.Contains(parameterName))
                {
                    objSqlCmd = new SqlCommand("update BRANCH_MASTER set " + parameterName.ToString() + " = '" + param_Value + "' where BRCH_ID = " + branchId);
                    objSqlCmd.CommandType = CommandType.Text;

                    Sqlhelper.ExecuteNonQuery(objSqlCmd);
                }
                else
                {

                    objSqlCmd = new SqlCommand("update SYSTEM_PRM set PRM_VALUE='" + param_Value + "' where PRM_NAME ='" + parameterName.ToString() + "'");
                    objSqlCmd.CommandType = CommandType.Text;

                    if (Sqlhelper.ExecuteNonQuery(objSqlCmd) == 0)
                    {
                        objSqlCmd = new SqlCommand("INSERT INTO SYSTEM_PRM (PRM_NAME,PRM_VALUE) values ('" + parameterName + "','" + param_Value + "')");
                        objSqlCmd.CommandType = CommandType.Text;
                        if (Sqlhelper.ExecuteNonQuery(objSqlCmd) == 0)
                        {
                            throw new Exception("Can't Update system parameters INSERT INTO SYSTEM_PRM(PRM_NAME, PRM_VALUE) values('" + parameterName + "', '" + param_Value + "' failed");
                        }
                    }
                }

                loadSystemParameter(branchId);


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool updateSystemParam(Info.SysParam objSysParam)
        {
            try
            {
                objSqlCmd = new SqlCommand("update SYSTEM_PRM set PRM_VALUE='" + objSysParam.PRM_Value + "' where PRM_NAME ='" + objSysParam.PRM_Name + "'");
                objSqlCmd.CommandType = CommandType.Text;

                return Sqlhelper.ExecuteQuery(objSqlCmd);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static bool updateBranchParam(Info.SysParam objbrchParam, int branchId)
        {
            try
            {
                objSqlCmd = new SqlCommand("update BRANCH_MASTER set  " + objbrchParam.PRM_Name + "=" + "'" + objbrchParam.PRM_Value + "' where BRANCH_MASTER.BRCH_ID = " + branchId);
                objSqlCmd.CommandType = CommandType.Text;

                return Sqlhelper.ExecuteQuery(objSqlCmd);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static DataTable getSysParam()
        {
            try
            {
                objSqlCmd = new SqlCommand("Select PRM_Name,PRM_Value from SYSTEM_PRM");
                objSqlCmd.CommandType = CommandType.Text;
                DataTable dtSysparam = Sqlhelper.GetDatatable(objSqlCmd);
                return dtSysparam;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getUserParam()
        {
            try
            {
                objSqlCmd = new SqlCommand("select PRM_Name,PRM_VALUE from SYSTEM_PRM where PRM_NAME in ('CIN_NO','EMAIL_ADDRESS','FULL_ADDRESS','EMAIL_ADDRESS','COMPANY_PAN_NO', 'NOTIFY_EXPENSE', 'NOTIFY_FEES_RECEIPT', 'SMTP_USERNAME', 'SMTP_PASSWORD','SERVICE_TAX', 'SERVICE_TAX_NO', 'SENDER_EMAIL', 'SIR_NAME', 'EMAIL_SIGNATURE_FEES','OWNER_NOS')");
                objSqlCmd.CommandType = CommandType.Text;
                DataTable dtUserparam = Sqlhelper.GetDatatable(objSqlCmd);
                return dtUserparam;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }



        public static DataTable getBrnchParam(int branchId)
        {
            try
            {
                objSqlCmd = new SqlCommand("select BRANCH_MASTER.SUB_NAME,ADDRESS,CONTACT_NO,NOTE,MAIN_FORM_IMAGE from BRANCH_MASTER  where BRCH_ID =" + branchId);
                objSqlCmd.CommandType = CommandType.Text;
                DataTable dtBrnchparam = Sqlhelper.GetDatatable(objSqlCmd);



                DataTable actualdt = new DataTable();
                actualdt.Columns.Add("PRM_NAME");
                actualdt.Columns.Add("PRM_VALUE");

                for (int col = 0; col < dtBrnchparam.Columns.Count; col++)
                {
                    var r = actualdt.NewRow();
                    r[0] = dtBrnchparam.Columns[col].ToString();
                    for (int j = 1; j <= dtBrnchparam.Rows.Count; j++)
                        r[j] = dtBrnchparam.Rows[j - 1][col];

                    actualdt.Rows.Add(r);

                }
                return actualdt;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static void loadSystemParameter(int branchId = 0)
        {
            try
            {

                SqlCommand com = new SqlCommand("select PRM_NAME,PRM_VALUE from SYSTEM_PRM");
                DataTable dtSysParam = DAL.Sqlhelper.GetDatatable(com);

                Info.SysParam.dictSysParam = new Dictionary<Parameters, object>();

                foreach (System.Data.DataRow dr in dtSysParam.Rows)
                {
                    try
                    {
                        dictSysParam.Add((Info.SysParam.Parameters)Enum.Parse(typeof(Info.SysParam.Parameters), dr["PRM_NAME"].ToString()), dr["PRM_VALUE"]);
                    }
                    catch (Exception ex)
                    {
                        Common.Log.LogError("parsing system parameter failed " + dr["PRM_NAME"].ToString(), Common.ErrorLevel.ERROR);
                    }
                }


                SqlCommand newcom = new SqlCommand("select BRCH_HEAD,CONTACT_NO,ADDRESS,MAIN_FORM_IMAGE,RECEIPT_COUNT,SUB_NAME,NOTE,BRCH_CLASS_NAME,BRCH_LOGO_PATH,NOTIFICATION_SENT_DATE,GST_NO from BRANCH_MASTER where BRCH_ID =" + branchId);
                DataTable dtBrchParam = DAL.Sqlhelper.GetDatatable(newcom);

                if (dtBrchParam.Rows.Count > 0)
                {
                    dictSysParam[Parameters.CONTACT_NO] = dtBrchParam.Rows[0]["CONTACT_NO"].ToString();
                    dictSysParam[Parameters.ADDRESS] = dtBrchParam.Rows[0]["ADDRESS"].ToString();
                    dictSysParam[Parameters.MAIN_FORM_IMAGE] = dtBrchParam.Rows[0]["MAIN_FORM_IMAGE"].ToString();
                    dictSysParam[Parameters.RECEIPT_COUNT] = dtBrchParam.Rows[0]["RECEIPT_COUNT"].ToString();
                    dictSysParam[Parameters.SUB_NAME] = dtBrchParam.Rows[0]["SUB_NAME"].ToString();
                    dictSysParam[Parameters.NOTE] = dtBrchParam.Rows[0]["NOTE"].ToString();
                    dictSysParam[Parameters.NAME] = dtBrchParam.Rows[0]["BRCH_CLASS_NAME"].ToString();
                    dictSysParam[Parameters.LOGO_PATH] = dtBrchParam.Rows[0]["BRCH_LOGO_PATH"].ToString();
                    dictSysParam[Parameters.NOTIFICATION_SENT_DATE] = dtBrchParam.Rows[0]["NOTIFICATION_SENT_DATE"].ToString();
                    dictSysParam[Parameters.BRCH_HEAD] = dtBrchParam.Rows[0]["BRCH_HEAD"].ToString();
                    dictSysParam[Parameters.GST_NO] = dtBrchParam.Rows[0]["GST_NO"].ToString();
                }




            }

            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
