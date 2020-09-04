using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClassManager.Common;
using ClassManager.DAL;
using ClassManager.Common.Exceptions;
using ClassManager;


namespace ClassManager.BLL
{
    public class LoginHandller
    {
        static SqlTransaction objtrans;

        public static bool CheckUserName(String Username)
        {
            SqlCommand com = new SqlCommand("select regid from login where userid='" + Username + "'");
            try
            {
                return DAL.Sqlhelper.ExecuteScalar(com);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
            finally
            {
                com.Dispose();
                com = null;
            }



        }

        public static String[] GetRegid(String Username, String Password)
        {
            SqlCommand com = new SqlCommand();
            try
            {
                Password = Common.EncryptionDecryption.Encrypt(Password);
                com.CommandText = "select regid,type from login where userid='" + Username + "' and password='" + Password + "'";
                DAL.Sqlhelper.ExecuteQuery(com);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                String[] Det = new String[2];
                Det[0] = dt.Rows[0][0].ToString();
                Det[1] = dt.Rows[0][1].ToString();
                return Det;

            }
            catch (Exception ex)
            {
                Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
            finally
            {
                com.Dispose();
                com = null;
            }

        }//in login user

        public static bool UpdateLogin(String Regid, String SessionId, String HostIp)
        {
            SqlCommand com = new SqlCommand("sp_updatelogin");
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@hostip", SqlDbType.NVarChar).Value = Regid;
                com.Parameters.Add("@SessionId", SqlDbType.NVarChar).Value = SessionId;
                com.Parameters.Add("@regid", SqlDbType.NVarChar).Value = HostIp;

                return DAL.Sqlhelper.ExecuteQuery(com);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
            finally
            {
                com.Dispose();
                com = null;
            }

        }
        public static Info.User LoginUser(String Username, String Password, int branchid)
        {
            try
            {


                
                Info.User objUser = new Info.User();

                 Password = Common.EncryptionDecryption.Encrypt(Password);

                SqlCommand com = new SqlCommand("s_pr_login_user");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                com.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                com.Parameters.Add("@branchID", SqlDbType.Int).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtUser = Sqlhelper.GetDatatable(com);

                if (Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.User.getUsersData(dtUser);

                }
                else
                {
                    throw new InvalidReturnCodeException("Error in user login");
                }
            }
            catch (Exception ex)
            {
               
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                return null;
            }
        }

        public static string getBranchID(String Username)
        {

            try
            {
                SqlCommand com = new SqlCommand("select Branch_Id  from login where userid =  @Username");
                com.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;

                object obj = DAL.Sqlhelper.ExeScaler(com);
                if (obj == null)
                    return "-1";
                else
                    return obj.ToString();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
        }

        public static bool RegisterUser(int BranchID, string userName, string password, int roleId)
        {
            try
            {
                
                Sqlhelper.beginTransaction();
                SqlCommand com = new SqlCommand("s_pr_register_user");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = Sqlhelper.getTransaction();
                
                com.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = userName;
                com.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Common.EncryptionDecryption.Encrypt(password);
                com.Parameters.Add("@BRANCHID", SqlDbType.Int).Value = BranchID;
                com.Parameters.Add("@ROLEID", SqlDbType.Int).Value = roleId;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DAL.Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {   
                    Sqlhelper.commitTransaction();
                    return true;
                }
                else
                {
                    throw new Exception("Error varifying return code for sp " + com.CommandText);
                }
            }
            catch (RecordAlreadyExistsException ex)
            {
                Sqlhelper.rollBackTransaction();
                throw new Exception("Username already exists, Please provide different username.");
            }
            catch (Exception ex)
            {
                Sqlhelper.rollBackTransaction();
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw new Exception(ex.Message);
            }
        }

        public static bool DeleteUser(string Username)
        {
            try
            {
                SqlCommand com = new SqlCommand("delete from login where userid = '" + Username + "'");
                return DAL.Sqlhelper.ExecuteQuery(com);
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
        }


        public static Boolean ChangePassWord(String Username, String NewPassword, String OldPassword)
        {
            try
            {
                NewPassword = Common.EncryptionDecryption.Encrypt(NewPassword);
                OldPassword = Common.EncryptionDecryption.Encrypt(OldPassword);

                SqlCommand com = new SqlCommand("update login set lgn_password = '" + NewPassword + "' where lgn_user_id = '" + Username + "' and lgn_password = '" + OldPassword + "'");
                try
                {
                    if (Sqlhelper.ExecuteNonQuery(com) <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                    throw new Exception("Error changing password for user " + Username);
                }
                finally
                {
                    com.Dispose();
                    com = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
        }

        public static string[] GetRegisteredUsers()
        {
            try
            {
                SqlCommand com = new SqlCommand("select userid from login");
                DataTable dt = DAL.Sqlhelper.GetDatatable(com);
                string[] users = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    users[i] = dt.Rows[i][0].ToString();
                }
                return users;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw new Exception("Database connection failed please try later \n" + ex.Message);
            }
        }
    }
}
