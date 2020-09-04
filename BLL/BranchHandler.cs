using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
namespace ClassManager.BLL
{
    public class BranchHandler
    {
        static SqlCommand com;

        public static bool createBranch(Info.Branch objBranchMaster)
        {
            try
            {
                com = new SqlCommand("s_pr_create_branchMaster");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Name", SqlDbType.VarChar).Value = objBranchMaster.BranchName;
                com.Parameters.Add("@Address", SqlDbType.VarChar).Value = objBranchMaster.Address;
                com.Parameters.Add("@Head", SqlDbType.VarChar).Value = objBranchMaster.Head;
                com.Parameters.Add("@IsCurrent", SqlDbType.VarChar).Value = objBranchMaster.IsCurrent;
                com.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objBranchMaster.BranchId = (int)com.Parameters["@Id"].Value;
                    return true;
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


        public static List<Info.Branch> getBranches(string branchId = "%")
        {
            try
            {

                com = new SqlCommand("s_pr_get_branches");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branch_id", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtBranches = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Branch.getBranchs(dtBranches);
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

        public static Info.Branch getBranch(int branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_branches");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branch_id", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtBranches = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Branch.getBranch(dtBranches.Rows[0]);
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


        public static List<Info.Branch> getAllBranches()
        {
            try
            {
                com = new SqlCommand("s_pr_get_all_branches");
                com.CommandType = CommandType.StoredProcedure;
            

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtBranches = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Branch.getBranchs(dtBranches);
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

         

        public static bool updateBranchMaster(Info.Branch objBrnch)
        {
            try
            {
                com = new SqlCommand("s_pr_update_branch_master");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = objBrnch.BranchId;
                com.Parameters.Add("@Name", SqlDbType.VarChar).Value = objBrnch.BranchName;
                com.Parameters.Add("@Address", SqlDbType.VarChar).Value = objBrnch.Address;
                com.Parameters.Add("@Head", SqlDbType.VarChar).Value = objBrnch.Head;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }


            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Procedure or function 's_pr_update_branch_master' expects parameter '@Name', which was not supplied."))
                {
                  
                }
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
            
            
        }
    }
}
