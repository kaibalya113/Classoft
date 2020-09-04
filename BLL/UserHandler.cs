using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassManager.Info;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using System.Configuration;
using ClassManager.Common.Exceptions;
using ClassManager.Common;


namespace ClassManager.BLL
{
   public class UserHandler
    {
        //This static member is declared to hold or track which user is Logged in.
        public static User loggedInUser;

        static SqlCommand com;



       public static bool logNewBiometricUser(int branchId, int userId)
       {
           try
           {
               com = new SqlCommand("s_pr_add_biometric_user");
               com.CommandType = CommandType.StoredProcedure;

               com.Parameters.Add("@biometricId", SqlDbType.Int).Value = userId;
               com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
               Sqlhelper.ExecuteNonQuery(com);
               return true;
           }
           catch (Exception ex)
           {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
           }
       }


       public static bool getAllUsers()
       {
           try
           {
               com = new SqlCommand("select RM_NAME from ROLE_MASTER");
               com.CommandType = CommandType.Text;
               return true;
           }
           catch (Exception ex)
           {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
           }
          
       }

       public static List<RoleMaster> getRoles(int branchId)
       {
           try
           {
               com = new SqlCommand("s_pr_get_roles");
               
               com.CommandType = CommandType.StoredProcedure;

               com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

               DataTable dtRoles = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                   return RoleMaster.getRole(dtRoles);
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

       public static List<RolePrivilege> getRolePrivileges(int roleId, int branchId)
       {

           try
           {
               com = new SqlCommand("s_pr_get_role_privileges");

               com.CommandType = CommandType.StoredProcedure;

               com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
               com.Parameters.Add("@roleId", SqlDbType.Int).Value = roleId;               
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


               DataTable dtRolePrivileges = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                   return RolePrivilege.getPrivileges(dtRolePrivileges);
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




        public static DataTable getUsers()
        {

            try
            {
                com = new SqlCommand("s_pr_View_user");

                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtUser = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtUser;
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
   

        public static bool updatePrivileges(RolePrivilege rolePrivilege)
       {
           try
           {

               com = new SqlCommand("s_pr_update_role_privileges");

               com.CommandType = CommandType.StoredProcedure;

               com.Parameters.Add("@RP_ID", SqlDbType.Int).Value = rolePrivilege.ID;
               com.Parameters.Add("@RP_FM_ID", SqlDbType.Int).Value = rolePrivilege.FunctionId;
               com.Parameters.Add("@RP_RM_ID", SqlDbType.Int).Value = rolePrivilege.RoleId;
               com.Parameters.Add("@RP_VIEW", SqlDbType.Int).Value = rolePrivilege.View;
               com.Parameters.Add("@RP_CREATE", SqlDbType.Int).Value = rolePrivilege.Create;
               com.Parameters.Add("@RP_MODIFY", SqlDbType.Int).Value = rolePrivilege.Modify;
               com.Parameters.Add("@RP_DELETE", SqlDbType.Int).Value = rolePrivilege.Delete;
               com.Parameters.Add("@RP_ALL_BRANCHES", SqlDbType.Int).Value = rolePrivilege.AllBranches;
              // com.Parameters.Add("@RP_BRANCH_ID", SqlDbType.Int).Value = rolePrivilege.BranchId;
               
               
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


               Sqlhelper.ExecuteNonQuery(com);

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
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
           }
       }

        
        public static bool createRole(string role)//, int branchId)
       {
           try
           {
               com = new SqlCommand("s_pr_create_role");

               com.CommandType = CommandType.StoredProcedure;

               com.Parameters.Add("@ROLE_NAME", SqlDbType.VarChar).Value = role;
              // com.Parameters.Add("@BRANCH_ID", SqlDbType.VarChar).Value = branchId;
               com.Parameters.Add("@role_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                
               com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

               Sqlhelper.ExecuteNonQuery(com);

               ErrorCodes returnCode;      
         
               Enum.TryParse<ErrorCodes>(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString(),out returnCode);


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
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
           }
       }

        public static bool createActivity(int AdmissionNo,DateTime date,String activity,string user,string oldvalue,string newvalue,string loginuser,string branch)
        {
            try
            {
                com = new SqlCommand("s_pr_insert_activityLog");
              
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value =AdmissionNo ;
                com.Parameters.Add("@date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@activity", SqlDbType.VarChar).Value = activity;
                com.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                com.Parameters.Add("@oldValue", SqlDbType.VarChar).Value = oldvalue;
                com.Parameters.Add("@newValue", SqlDbType.VarChar).Value = newvalue;
                com.Parameters.Add("@loginuser", SqlDbType.VarChar).Value = loginuser;
                com.Parameters.Add("@branch", SqlDbType.VarChar).Value = branch;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                ErrorCodes returnCode;

                Enum.TryParse<ErrorCodes>(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString(), out returnCode);


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
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }



    }
}
