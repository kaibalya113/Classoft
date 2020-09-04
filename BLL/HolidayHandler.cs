using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
namespace ClassManager.BLL
{
   public class HolidayHandler
    {
       static SqlCommand com;
       public static bool createHoliday(Info.Holiday objHoldy, int branchId)
       {
           try
           {
               com = new SqlCommand("s_pr_create_Holiday");
               com.CommandType = CommandType.StoredProcedure;


               /*
                (
	            @Id int output,
	            @Date date,
	            @Name varchar(50),

	            @NUM_ERROR_CODE INT OUTPUT
	            )
                */

               com.Parameters.Add("@fromDate", SqlDbType.Date).Value = objHoldy.Fromdate;

               com.Parameters.Add("@toDate", SqlDbType.Date).Value = objHoldy.Todate;
               com.Parameters.Add("@Name", SqlDbType.VarChar).Value = objHoldy.Name;
               com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
               com.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
               
               Sqlhelper.ExecuteNonQuery(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                   objHoldy.Id = (int)com.Parameters["@Id"].Value;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

                return true;
           }

           catch (Exception ex)
           {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex; 
           }

       }

       public static DataTable getHolidays(string branchId)
       {
           try
           {
               com = new SqlCommand("s_pr_get_holidays");
               com.CommandType = CommandType.StoredProcedure;
               com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
               DataTable dtHolidays=Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                   return dtHolidays;
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
