using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string BranchID { get; set; }
        public Branch Branch { get; set; }
        public string PendingAmount { get; set; }
        enum ColumnName
        {
            ACT_ID,
            ACT_NAME,
            ACT_BAL,
            ACT_TYPE,
            ACT_BRANCH_ID,
            ACT_PDNG_AMNT
        }



        public override string ToString()
        {
            //return AccountName + " " + "("+ Balance.ToString() +")";
            return AccountName;
        }

        public static List<Account> getAccounts(System.Data.DataTable dt)
        {
            try
            {
                List<Account> lstAccounts = new List<Account>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstAccounts.Add(getAccount(dr));
                }

                return lstAccounts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Account> getAccountsIndividual(System.Data.DataTable dt)
        {
            try
            {
                List<Account> lstAccounts = new List<Account>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstAccounts.Add(getAccountsIndividual(dr));
                }

                return lstAccounts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Account getAccount(DataRow dr)
        {
            try
            {
                Account objAccount = new Account();
                objAccount.Id = EntityManager.getValue<Int32>(dr, ColumnName.ACT_ID.ToString());
                objAccount.AccountName = EntityManager.getValue<string>(dr, ColumnName.ACT_NAME.ToString());
                objAccount.Balance = EntityManager.getValue<decimal>(dr, ColumnName.ACT_BAL.ToString());
                objAccount.AccountType = EntityManager.getValue<string>(dr, ColumnName.ACT_TYPE.ToString());
                objAccount.BranchID = EntityManager.getValue<string>(dr, ColumnName.ACT_BRANCH_ID.ToString());
                objAccount.PendingAmount = EntityManager.getValue<string>(dr,ColumnName.ACT_PDNG_AMNT.ToString());
                objAccount.Branch = Branch.getBranch(dr);
                return objAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Account getAccountsIndividual(DataRow dr)
        {
            try
            {
                Account objAccount = new Account();
                objAccount.Id = EntityManager.getValue<Int32>(dr, ColumnName.ACT_ID.ToString());
                objAccount.AccountName = EntityManager.getValue<string>(dr, ColumnName.ACT_NAME.ToString());
                objAccount.Balance = EntityManager.getValue<decimal>(dr, ColumnName.ACT_BAL.ToString());
                objAccount.AccountType = EntityManager.getValue<string>(dr, ColumnName.ACT_TYPE.ToString());
                objAccount.BranchID = EntityManager.getValue<string>(dr, ColumnName.ACT_BRANCH_ID.ToString());
                objAccount.PendingAmount = EntityManager.getValue<string>(dr, ColumnName.ACT_PDNG_AMNT.ToString());
                objAccount.Branch = Branch.getBranch(dr);
                return objAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
