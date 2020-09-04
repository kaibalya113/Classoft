using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Configuration;
using ClassManager.Common;


namespace ClassManager.DAL
{
    public class Sqlhelper
    {

        static SqlConnection con;
        static string ConnectionString = "";
        public static string SettingsPath;
        public static string Database;
        public static string Username;
        public static string Password;
        private static SqlTransaction transaction;

        public static String[] GetAvailableSQLServerInstances()
        {
            SqlDataSourceEnumerator Sources;
            DataTable Dt;
            try
            {
                Sources = SqlDataSourceEnumerator.Instance;
                string[] Servers = new string[2];
                int i = 0;
                Dt = Sources.GetDataSources();
                foreach (DataRow Dr in Dt.Rows)
                {
                    Servers[i++] = Dr["ServerName"].ToString();// +"\\" + Dr["InstanceName"].ToString();
                }
                return Servers;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {
                Sources = null;
                Dt = null;
            }


        }

        public static void disposeConnection()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
            ConString = "";
        }

        public static string getConnectionString()
        {
            try
          {
                System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//CONSTR.xml");
                string conStr = Common.EncryptionDecryption.Decrypt(sr.ReadToEnd());
                sr.Close();
                return conStr;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static String LoadConnectionString()//Load Connection String from PropertyFile
        {
            try
            {
                return getConnectionString();               
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static String ConString
        {
            get
            {
                if (ConnectionString.Equals(""))
                {
                    ConnectionString = LoadConnectionString();
                }
                return ConnectionString;
            }
            set
            {
                ConnectionString = value;
            }

        }

        public static Boolean CreateCon()
        {
            try
            {
                if (IsValidConnection)
                {
                    return true;
                }

                else
                {
                    throw new Exception("Error occured while connecting to database");
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static Boolean SetCom(SqlCommand com)
        {
            try
            {
                com.Connection = con;
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static Boolean ExecuteQuery(SqlCommand com)
        {
            try
            {
                ExecuteNonQuery(com);
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {
                com.Dispose();
                com = null;
            }
        }

        public static SqlTransaction getTransaction()
        {
            return transaction;
        }

        public static Boolean IsValidConnection
        {
            get
            {
                try
                {
                    if (con != null)
                    {
                        if ((con.State == ConnectionState.Closed) || (con.State == ConnectionState.Broken))
                        {
                            con.Dispose();
                            con = null;
                            ConString = "";
                            con = new SqlConnection(ConString);
                            con.Open();
                        }
                    }
                    if (con == null)
                    {
                        con = new SqlConnection();
                        ConString = "";
                        con.ConnectionString = ConString;
                        con.Open();
                    }

                    return true;
                }

                catch (Exception ex)
                {
                    Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                    try
                    {
                        System.Diagnostics.Process process;

                        

                        string[] serverName = ConString.Split(';')[0].Split('=')[1].Split ('\\');
                        string instanceName;
                        if (serverName.Length > 1)
                        {
                            instanceName = serverName[1];
                        }
                        else
                        {
                            instanceName = serverName[0];
                        }

                        ProcessStartInfo startInfo = new ProcessStartInfo("net", "start MSSQL$" + instanceName);
                        startInfo.Verb = "runas";
                        process = System.Diagnostics.Process.Start(startInfo);
                        process.WaitForExit();


                        con = new SqlConnection();
                        ConString = "";
                        con.ConnectionString = ConString;
                        con.Open();
                        return true;
                    }
                    catch(Exception exec)
                    {
                        Log.LogError(exec, new StackFrame(0).GetMethod().Name);
                        throw exec;
                    }
                    
                }
            }
        }

        public static void rollBackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }

            transaction = null;
        }

        public static void commitTransaction()
        {
            transaction.Commit();
        }

        public static SqlTransaction beginTransaction()
        {
            try
            {
                if (CreateCon())
                {
                    transaction = con.BeginTransaction();
                    return transaction;
                }
                else
                    throw new Exception("Error occured getting connection");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Boolean ExecuteScalar(SqlCommand com)
        {
            try
            {
                object obj = new object();
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    com.Connection = con;
                    con.Open();
                    obj = com.ExecuteScalar();
                }

                if (obj == null)
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
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }

            finally
            {
                com.Dispose();
                com = null;
            }
        }

        public static void SetConnection(SqlCommand com)
        {
            try
            {
                CreateCon();
                com.Connection = con;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {

            }
        }

        public static object ExeScaler(SqlCommand com)
        {
            try
            {
                Object obj;
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    com.Connection = con;
                    con.Open();
                    obj = com.ExecuteScalar();
                }

                return obj;
            }
            catch (Exception ex)        
            {
                Log.LogDBError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }

            finally
            {
                com.Dispose();
                com = null;
            }
        }

        public static object ExeScaler(SqlCommand com,bool isTransactionAttached)
        {
            try
            {
                Object obj;
                if (isTransactionAttached == true)
                {
                    com.Connection = com.Transaction.Connection;
                    obj = com.ExecuteScalar();
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(ConString))
                    {
                        com.Connection = con;
                        con.Open();
                        obj = com.ExecuteScalar();
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                Log.LogDBError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }

            finally
            {
                com.Dispose();
                com = null;
            }
        }

        public static Boolean JustExucuteScalar(SqlCommand com)
        {
            try
            {
                object obj = new object();
                obj = ExecuteScalar(com);
                if (obj == null)
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
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {
                com.Dispose();
                com = null;
            }


        }

        public static DataTable GetDatatable(string query)
        {
            SqlCommand com = new SqlCommand(query);
            com.CommandType = CommandType.Text;

            try
            {
                //  ExecuteQuery(com);
                //  SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = GetDatatable(com);
              //  da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {
                com.Dispose();
                com = null;
            }

        }

        public static void ExecuteQuery(string query)
        {
            try
            {
                SqlCommand com = new SqlCommand(query);
                com.CommandType = CommandType.Text;

                ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetDatatable(SqlCommand com)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    com.Connection = con;
                    con.Open();
                    com.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {
                com.Dispose();
                com = null;
            }

        }

        public static int UpdateDatabase(SqlCommand Com, DataTable Dt, StringBuilder Text)
        {
            try
            {
                CreateCon();
                Text.Append("\nConnection Created Succefully");
                SetCom(Com);
                Text.Append("\nConnection set to Command Successfull");
                SqlDataAdapter Da = new SqlDataAdapter(Com);
                Da.InsertCommand = Com;
                Text.Append("\nSuccesfully Updated Database");
                return Da.Update(Dt);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                return -1;
            }
        }

        public static int ExecuteNonQuery(SqlCommand com, bool isTransactionAttched = false)
        {
            try
            {
                if (isTransactionAttched == false)
                {
                    using (SqlConnection con = new SqlConnection(ConString))
                    {
                        com.Connection = con;
                        con.Open();
                        return com.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (com.Transaction != null)
                    {
                        com.Connection = com.Transaction.Connection;
                        return com.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Transaction is null");
                    }

                }
                

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static void backupDatabase()
        {
            SqlCommand com = new SqlCommand("BackupDatabase");
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                ExecuteQuery(com);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static SqlConnection getConnection()
        {
            try
            {
                if (CreateCon())
                {
                    return con;
                }
                else
                    throw new Exception("Error occured getting connection");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static DataSet GetDataset(SqlCommand com)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    com.Connection = con;
                    con.Open();
                    com.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, new StackFrame(0).GetMethod().Name);
                throw ex;
            }
            finally
            {
                com.Dispose();
                com = null;
            }

        }

        public static bool checkDBCOnnectivity()
        {
            try
            {
                DBConStatus = CreateCon();
                return DBConStatus;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public static bool DBConStatus { get; set; }
    }
}
