using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class MarketingHandler
    {
        static SqlCommand com;
        static SqlTransaction objTrans;

        public static List<Info.Marketing> getGroup(string studType, string branchID="%")
        {
            try
            {
                //    ALTER PROCEDURE [dbo].[s_pr_get_groups]
	
                //(
                //@studType varchar(20),
                //@NUM_ERROR_CODE int output 
                //)


                SqlCommand com = new SqlCommand("s_pr_get_marketing_data");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@studType", SqlDbType.VarChar).Value = studType;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtGroup = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Marketing.getGroup(dtGroup);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static List<object> getBirthdays(DateTime dt, object branchId)
        {
            throw new NotImplementedException();
        }

        public static List<Info.Marketing> getBirthdayReport(int month,string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_birthdays_report");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@month", SqlDbType.Int).Value = month;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = (branchId == "-1") ? "%" : branchId.ToString();
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Marketing.getGroup(dtStudent);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static List<Info.Marketing> getBirthdays(DateTime date,string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_birthdays");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = (branchId == "-1" )? "%" : branchId.ToString();
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Marketing.getGroup(dtStudent);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static List<Info.Marketing> getAnniversaries(DateTime date,string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_anniversaries");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@branchId", SqlDbType.NVarChar).Value = (branchId == "-1") ? "%" : branchId.ToString();
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Marketing.getGroup(dtStudent);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
    }
}
