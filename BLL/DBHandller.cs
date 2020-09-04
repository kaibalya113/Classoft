using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassManager.DAL;
using System.Data;
using System.Data.SqlTypes;
using ClassManager.Info;
using System.IO;


namespace ClassManager.BLL
{
    public class DBHandller
    {
        static SqlCommand objSqlCmd;
        static DateTime MAX_SQL_DATE;
        static DateTime MIN_SQL_DATE;

        static SqlTransaction transaction;
        static string  syncFolder;

        static DBHandller()
        {
            MAX_SQL_DATE = (DateTime) SqlDateTime.MaxValue;
            MIN_SQL_DATE = (DateTime)SqlDateTime.MinValue;
        }


        public static bool backUpDB()
        {
            try
            {
                objSqlCmd = new SqlCommand("BackupDatabase");
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                Sqlhelper.ExecuteNonQuery(objSqlCmd);
                return true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                return false;
            }
        }

        public static bool generateBackup(int branchId,string folder)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_sync_data");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;

                DataSet data = Sqlhelper.GetDataset(com);
                DataSet finalDS = new DataSet();

                foreach (DataTable table in data.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        table.TableName = table.Rows[0]["TableName"].ToString();
                    }

                    DataTable dtCloned = table.Clone();
                    foreach (DataColumn dc in dtCloned.Columns)
                        dc.DataType = typeof(string);
                    foreach (DataRow row in table.Rows)
                    {
                        dtCloned.ImportRow(row);
                    }

                    foreach (DataRow row in dtCloned.Rows)
                    {
                        for (int i = 0; i < dtCloned.Columns.Count; i++)
                        {
                            dtCloned.Columns[i].ReadOnly = false;

                            if (string.IsNullOrEmpty(row[i].ToString()))
                                row[i] = string.Empty;
                        }
                    }
                    
                    finalDS.Tables.Add(dtCloned);
                    
                }

               

                System.IO.StreamWriter sw = System.IO.File.CreateText(folder+branchId.ToString()+".xml");
                finalDS.WriteXml(sw);
                sw.Close();

                return true;
               
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool checkDBCOnnectivity()
        {
            return DAL.Sqlhelper.checkDBCOnnectivity();
        }

        public static string GetConString()
        {
            return DAL.Sqlhelper.ConString;
        }

        public static string getConnectionDescription()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(DAL.Sqlhelper.ConString);
            return sb.InitialCatalog + "@" + sb.DataSource;
        }


        public static bool checkDBConnectivity(SqlConnectionStringBuilder conBuilder)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                conBuilder.ConnectTimeout = 5;
                con.ConnectionString = conBuilder.ConnectionString;
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void syncData(int branchToExclude,string folderPath)
        {
            try
            {
                syncFolder = folderPath;
                disableTrigger();
                List<Branch> branches = BranchHandler.getAllBranches();

                transaction = Sqlhelper.getConnection().BeginTransaction();

                foreach (Info.Branch branch in branches)
                {
                    if (branch.BranchId != branchToExclude)
                    {
                        //if (DBHandller.deleteBranchdata(branch.BranchId) == true)
                        //{
                        //    DBHandller.uploadBranchData(branch.BranchId);
                        //}
                        

                    }
                }
                transaction.Commit();

                enableTrigger();

                
            }
            catch (Exception ex)
            {

                if (transaction != null)
                {
                    transaction.Rollback();
                }

                transaction = null;
                enableTrigger();
            }
            
        }

        public static bool deleteBranchdata(int branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_delete_branch_data");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = transaction;

                com.Parameters.Add("@branch_id",SqlDbType.Int).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com,true);

                return ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com);
                
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool uploadBranchData(int branchId)
        {
            try
            {
                DataSet branchData = new DataSet();
                branchData.ReadXml(syncFolder + branchId + ".xml");

                //RemoveTimezoneForDataSet(branchData);

                using (SqlBulkCopy bc = new SqlBulkCopy(transaction.Connection,SqlBulkCopyOptions.Default, transaction))
                {
                    // Destination table with owner - this example doesn't
                    // check the owner and table names!

                    foreach (DataTable dt in branchData.Tables)
                    {
                        bc.DestinationTableName = "[dbo].[" + dt.TableName + "]";
                        // Starts the bulk copy.

                        bc.WriteToServer(dt);
                    }

                    // Closes the SqlBulkCopy instance.
                    bc.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static void RemoveTimezoneForDataSet(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType == typeof(DateTime))
                    {
                        dc.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
            }
        }

        public static void saveConnection(SqlConnectionStringBuilder conBuilder)
        {
            throw new NotImplementedException();
        }

        public static DateTime getMinSQLDate()
        {
            return MIN_SQL_DATE;
        }

        public static DateTime getMaxSQLDate()
        {
            return MAX_SQL_DATE;
        }

        public static bool enableTrigger()
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_enable_disable_triggers");
                com.CommandType = CommandType.StoredProcedure;
                

                com.Parameters.Add("@is_enable", SqlDbType.Bit).Value = true;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                return ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

        public static bool disableTrigger()
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_enable_disable_triggers");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@is_enable", SqlDbType.Bit).Value = false;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                Sqlhelper.ExecuteNonQuery(com);

                return ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

        public static void saveDBConfig(System.Data.SqlClient.SqlConnectionStringBuilder conBuilder)
        {
            try
            {

                System.IO.StreamWriter sw = System.IO.File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "//CONSTR.xml");
                sw.Write(Common.EncryptionDecryption.Encrypt(conBuilder.ToString()));
                sw.Close();
                Sqlhelper.disposeConnection();

                //ClassManager.Common.Properties.Settings.Default.ServerIP = conBuilder.DataSource;
                //ClassManager.Common.Properties.Settings.Default.UserName = conBuilder.UserID;
                //ClassManager.Common.Properties.Settings.Default.Password = conBuilder.Password;
                //ClassManager.Common.Properties.Settings.Default.DatabaseName = conBuilder.InitialCatalog;

                //ClassManager.Common.Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

        public static System.Data.SqlClient.SqlConnectionStringBuilder getConnectionStringBuilder()
        {
            try
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "//CONSTR.xml"))
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "//CONSTR.xml");
                    string conStr = Common.EncryptionDecryption.Decrypt(sr.ReadToEnd());
                    sr.Close();

                    return new System.Data.SqlClient.SqlConnectionStringBuilder(conStr);
                }
                else
                {
                    return new SqlConnectionStringBuilder();
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static void setDateFormat(string dateFormat)
        {
            try
            {
                DAL.Sqlhelper.ExecuteQuery("SET DATEFORMAT " + dateFormat);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
            
        }

        public static SqlConnection getConnection()
        {
            try
            {
                return DAL.Sqlhelper.getConnection();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

       
    }
}