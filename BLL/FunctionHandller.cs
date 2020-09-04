using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class FunctionHandller
    {
        public static List<Info.FunctionMaster> getFunctionMaster()
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_function_master");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtFunctionMaster  =  Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.FunctionMaster.getFunctionMaster(dtFunctionMaster);
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
