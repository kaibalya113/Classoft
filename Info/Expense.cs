using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Expense
    {

        public int ExpenseId { get; set; }
        public bool IsDirectExp { get; set; }
        public bool IsExpense { get; set; }
        public int BranchID { get; set; }
        public string ExpenseName { get; set; }
        public string PaidTo { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public PaymentMode PaymentMode;
        public string FilePath { get; set; }
        public Transaction Trasaction { get; set; }
        public Branch Branch { get; set; }
        public string PayMode { get; set;}
        public Expense()
        {
            Account = new Account();
        }

        public Expense(int expenseID)
        {

            this.ExpenseId = expenseID;

        }
        public Expense(int expenseID, bool isDirect, string expense = "")
        {
            this.ExpenseId = expenseID;
            this.IsDirectExp = isDirect;
            this.ExpenseName = expense;
        }
        public Expense(bool isExpense, string expense = "")
        {
            this.IsExpense = isExpense;
            this.ExpenseName = expense;
        }


        public Expense(int expenseID, string description, int companyID, int buildingID, string paidTo, decimal amount, DateTime date)
        {
            this.ExpenseName = description;
            this.PaidTo = paidTo;
            this.Amount = amount;
            this.Date = date;
        }
        enum ColumnName
        {
            EXPM_ID,
            EXPM_DESCRIPTION,
            EXPM_IS_DIRECT,
            EXPM_IS_EXPENSE,
            EXPM_BRANCH_ID,
            PDEX_ID,
            PDEX_EXPNSE_ID,
            PDEX_DESC,
            PDEX_PAID_TO,
            PDEX_AMOUNT,
            PDEX_DATE,
            PDEX_BRANCH_ID,
            PDEX_IS_EXPNSE,
            PDEX_TRANSACTION_ID,
            PDEX_FILE_PATH
            
        }
        public static Expense getIncomeExp(System.Data.DataRow drIncomeExp)
        {
            try
            {
                Expense objIncomeExp = new Expense();

                //if (drIncomeExp.Table.Columns.Contains("EXPM_ID") && drIncomeExp["EXPM_ID"] != DBNull.Value)
                //{
                //    objIncomeExp.ExpenseId = Convert.ToInt32(drIncomeExp["EXPM_ID"]);
                //}
                objIncomeExp.ExpenseId = EntityManager.getValue<Int32>(drIncomeExp, ColumnName.EXPM_ID.ToString());
                //if (drIncomeExp.Table.Columns.Contains("EXPM_DESCRIPTION") && drIncomeExp["EXPM_DESCRIPTION"] != DBNull.Value)
                //{
                //    objIncomeExp.ExpenseName = (drIncomeExp["EXPM_DESCRIPTION"].ToString());
                //}
                objIncomeExp.ExpenseName = EntityManager.getValue<string>(drIncomeExp, ColumnName.EXPM_DESCRIPTION.ToString());
                //if (drIncomeExp.Table.Columns.Contains("EXPM_IS_DIRECT") && drIncomeExp["EXPM_IS_DIRECT"] != DBNull.Value)
                //{
                //    objIncomeExp.IsDirectExp = Convert.ToBoolean(drIncomeExp["EXPM_IS_DIRECT"]);
                //}
                objIncomeExp.IsDirectExp = EntityManager.getValue<bool>(drIncomeExp, ColumnName.EXPM_IS_DIRECT.ToString());
                //if (drIncomeExp.Table.Columns.Contains("EXPM_IS_EXPENSE") && drIncomeExp["EXPM_IS_EXPENSE"] != DBNull.Value)
                //{
                //    objIncomeExp.IsExpense = Convert.ToBoolean(drIncomeExp["EXPM_IS_EXPENSE"]);
                //}
                objIncomeExp.IsExpense = EntityManager.getValue<bool>(drIncomeExp, ColumnName.EXPM_IS_EXPENSE.ToString());
                //if (drIncomeExp.Table.Columns.Contains("EXPM_BRANCH_ID") && drIncomeExp["EXPM_BRANCH_ID"] != DBNull.Value)
                //{
                //    objIncomeExp.BranchID = Convert.ToInt32(drIncomeExp["EXPM_BRANCH_ID"]);
                //}
                objIncomeExp.BranchID = EntityManager.getValue<Int32>(drIncomeExp, ColumnName.EXPM_BRANCH_ID.ToString());
                //if (drIncomeExp.Table.Columns.Contains("PDEX_PAID_TO") && drIncomeExp["PDEX_PAID_TO"] != DBNull.Value)
                //{
                //    objIncomeExp.PaidTo = drIncomeExp["PDEX_PAID_TO"].ToString();
                //}
                objIncomeExp.PaidTo = EntityManager.getValue<string>(drIncomeExp, ColumnName.PDEX_PAID_TO.ToString());
                //if (drIncomeExp.Table.Columns.Contains("PDEX_AMOUNT") && drIncomeExp["PDEX_AMOUNT"] != DBNull.Value)
                //{
                //    objIncomeExp.Amount = Convert.ToDecimal( drIncomeExp["PDEX_AMOUNT"].ToString());
                //}
                objIncomeExp.Amount = EntityManager.getValue<decimal>(drIncomeExp, ColumnName.PDEX_AMOUNT.ToString());
                //if (drIncomeExp.Table.Columns.Contains("PDEX_DATE") && drIncomeExp["PDEX_DATE"] != DBNull.Value)
                //{
                //    objIncomeExp.Date = Convert.ToDateTime(drIncomeExp["PDEX_DATE"].ToString());
                //}
                objIncomeExp.FilePath = EntityManager.getValue<string>(drIncomeExp, ColumnName.PDEX_FILE_PATH.ToString());
                objIncomeExp.Date = EntityManager.getValue<DateTime>(drIncomeExp, ColumnName.PDEX_DATE.ToString());
                objIncomeExp.Account = Account.getAccount(drIncomeExp);
                objIncomeExp.Trasaction = Transaction.getTransaction(drIncomeExp);
                objIncomeExp.Branch = Branch.getBranch(drIncomeExp);

                return objIncomeExp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Expense> getIncomeExps(DataTable dtIncomeExp)
        {
            try
            {
                List<Expense> lstIncomeExp = new List<Expense>();
                foreach (DataRow drIncomeExp in dtIncomeExp.Rows)
                {
                    lstIncomeExp.Add(getIncomeExp(drIncomeExp));
                }
                return lstIncomeExp;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override string ToString()
        {
            return ExpenseName;
        }
    }
}

