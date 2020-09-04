using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassManager.Info;
using System.Data.SqlClient;
using System.Data;
using ClassManager.Common;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class AccountHandller
    {
        static SqlCommand com;
        static SqlTransaction objTrans;
        public static List<Account> getAccounts(string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_accounts");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ACT_BRANCH_ID", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = DAL.Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Account.getAccounts(dt);
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
        //getAccountsIndividual

        public static List<Account> getAccountsIndividual(string branchid, string fromDate, string toDate)
        {
            try
            {
                com = new SqlCommand("s_pr_get_signleaccounts");
                com.CommandType = CommandType.StoredProcedure; // DateTime.Today.AddDays(-1); DateTime.Today.
                com.Parameters.Add("@ACT_BRANCH_ID", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = fromDate; //DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"); ;
                com.Parameters.Add("@toDate", SqlDbType.VarChar).Value = toDate; //DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"); 

                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = DAL.Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Account.getAccountsIndividual(dt);
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
        public static DataTable getTransferAmount(string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_transfer_amount");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = DAL.Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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
        public static Account getAccount(int accountId, int branchID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_account");
                com.Parameters.Add("@ACCOUNT_ID", SqlDbType.Int).Value = accountId;
                com.Parameters.Add("@ACT_BRANCH_ID", SqlDbType.Int).Value = branchID;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = DAL.Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dt.Rows.Count > 0)
                    {
                        return Info.Account.getAccount(dt.Rows[0]);
                    }
                    else
                    {
                        throw new ClassManager.Common.Exceptions.RecordNotFoundException("Account with account id " + accountId + " not found");
                    }
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

        public static Account createAccount(Account account)
        {
            try
            {
                com = new SqlCommand("s_pr_create_account");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ACT_NAME", SqlDbType.VarChar).Value = account.AccountName;
                com.Parameters.Add("@ACT_BAL", SqlDbType.Decimal).Value = account.Balance;
                //com.Parameters.Add("@ACT_TYPE", SqlDbType.VarChar).Value = account.AccountType;
                com.Parameters.Add("@ACT_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ACT_BRANCH_ID", SqlDbType.Int).Value = account.BranchID;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                ClassManager.DAL.Sqlhelper.ExecuteNonQuery(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    account.Id = Convert.ToInt32(com.Parameters[Constants.RETURN_CODE_VARIABLE].Value.ToString());
                    return account;
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

        public static bool updateAccount(Account account)
        {
            try
            {
                com = new SqlCommand("s_pr_update_account");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ACT_NAME", SqlDbType.VarChar).Value = account.AccountName;
                com.Parameters.Add("@ACT_BAL", SqlDbType.Decimal).Value = account.Balance;
                //com.Parameters.Add("@ACT_TYPE", SqlDbType.VarChar).Value = account.AccountType;
                com.Parameters.Add("@ACT_ID", SqlDbType.Int).Value = account.Id;
                com.Parameters.Add("@ACT_BRANCH_ID", SqlDbType.Int).Value = account.BranchID;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                ClassManager.DAL.Sqlhelper.ExecuteNonQuery(com);

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

        public static bool deleteAccount(int accountId, int branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_account");

                com.Parameters.Add("@ACT_ID", SqlDbType.Int).Value = accountId;
                com.Parameters.Add("@ACT_BRANCH_ID", SqlDbType.Int).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                ClassManager.DAL.Sqlhelper.ExecuteNonQuery(com);

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


      
        public static bool deleteTranferTrans(Int64 toaccountId, string branchid, decimal Amount, Int64 tranId, string fromAccount)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_transfer_transaction");
                com.Parameters.Add("@amount", SqlDbType.Decimal).Value = Amount;
                com.Parameters.Add("@fromAccount", SqlDbType.VarChar).Value = fromAccount;
                com.Parameters.Add("@toAccount", SqlDbType.BigInt).Value = toaccountId;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add("@transID", SqlDbType.BigInt).Value = tranId;
                com.Parameters.Add(Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                ClassManager.DAL.Sqlhelper.ExecuteNonQuery(com);

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

        public static bool TransferAmount(int branchId, Account From, Account To, Transaction objTransaction,decimal Cheque)
        {
            try
            {

                objTrans = Sqlhelper.getConnection().BeginTransaction();
                
                com = new SqlCommand("s_pr_transfer_balance");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;

                com.Parameters.Add("@MainAccount", SqlDbType.Int).Value = From.Id;
                com.Parameters.Add("@TransferAccount", SqlDbType.Int).Value = To.Id;
                com.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objTransaction.Amount;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = objTransaction.Date;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@Mode", SqlDbType.VarChar).Value = objTransaction.PaymentMode;
                com.Parameters.Add("@ChequeAmount", SqlDbType.Decimal).Value = Cheque;
                com.Parameters.Add("@DiscReason", SqlDbType.VarChar).Value = objTransaction.reason;
                com.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ReceiptNo", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    objTransaction.TrancID = Convert.ToInt32(com.Parameters["@TransactionID"].Value);
                    objTransaction.ReceiptNo = com.Parameters["@ReceiptNo"].Value.ToString();
                    com = new SqlCommand("s_pr_insert_cheque");
                    com.CommandType = CommandType.StoredProcedure;
                    foreach (Cheque objCheque in objTransaction.Cheques)
                    {   
                        com.Transaction = objTrans;
                        com.Parameters.Clear();
                        com.Parameters.Add("@CHEQUE_DATE", SqlDbType.Date).Value = objCheque.Date;
                        com.Parameters.Add("@CHEQUE_DEPOSIT_ACC", SqlDbType.Int).Value = objCheque.DepositAccount.Id;
                        com.Parameters.Add("@CHEQUE_BRANK", SqlDbType.NVarChar).Value = objCheque.Bank;
                        com.Parameters.Add("@CHEQUE_No", SqlDbType.NVarChar).Value = objCheque.ChequeNo;
                        com.Parameters.Add("@CHEQUE_BRANK_BRANCH", SqlDbType.NVarChar).Value = objCheque.BankBranch;
                        com.Parameters.Add("@CHEQUE_AMOUNT", SqlDbType.Decimal).Value = objCheque.Amount;
                        com.Parameters.Add("@CHEQUE_STATUS", SqlDbType.VarChar).Value = objCheque.Status.ToString();
                        com.Parameters.Add("@CHEQUE_TRANC_ID", SqlDbType.Int).Value = objTransaction.TrancID;
                        com.Parameters.Add("@CHEQUE_BRANCH_ID", SqlDbType.Int).Value =branchId;
                        
                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                        Sqlhelper.ExecuteNonQuery(com,true);

                        if (Common.Exceptions.ExceptionHandller.HandleDBError(com) == false)
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
                    }

           
                    
                    objTrans.Commit();
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;
                throw ex;       
            }
        }

    }

}
