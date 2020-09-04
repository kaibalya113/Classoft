using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassManager.Info;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Common;
using System.IO;

namespace ClassManager.BLL
{
    public class ExpenseHandler
    {


        public static SqlCommand com;
        #region CRUD

        public static bool createNewExpense(string expenseName, int branchId, bool isExpense)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_create_expense_master");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@IsExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = expenseName;
                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@ExpernceMasterId", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public static bool insertExpense(Expense expense, int branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_insert_expense");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ExpenseID", SqlDbType.Int).Value = expense.ExpenseId;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = expense.Description;
                com.Parameters.Add("@PaidTo", SqlDbType.NVarChar).Value = expense.PaidTo;
                com.Parameters.Add("@Amount", SqlDbType.Decimal).Value = expense.Amount;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = expense.Date;
                com.Parameters.Add("@DebitAccountId", SqlDbType.Int).Value = expense.Account.Id;
                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@isExpense", SqlDbType.Bit).Value = expense.IsExpense;
                com.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = expense.FilePath;
                com.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = expense.PayMode;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
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
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getPaidExpense( Boolean isForProfitLoss,  Boolean isExpense, string branchId="%" , DateTime fromDate = default(DateTime), DateTime? toDate = null)
        {
            try
            {
                string spName = "s_pr_disp_expenses";
                SqlCommand com = new SqlCommand(spName);
                com.CommandType = CommandType.StoredProcedure;
                if (toDate == null)
                {
                    toDate = DateTime.MaxValue;
                }
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@isExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@isForPrfitLoss", SqlDbType.Bit).Value = isForProfitLoss;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt= Sqlhelper.GetDatatable(com);

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

        public static DataTable getExpense(string PdexID,string Branch, Boolean isExpense)
        {
            try
            {
                com = new SqlCommand("s_pr_get_expense");
                com.CommandType = CommandType.StoredProcedure; 
                com.Parameters.Add("@PdexId", SqlDbType.VarChar).Value = PdexID;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = Branch;
                com.Parameters.Add("@isExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                DataTable dtExp = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    return dtExp;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

        #endregion CRUD


        public static DataTable getYearlyReport(int companyId, int buildingID, ExpenseTypes expenseType)
        {
            try
            {
                StringBuilder query = new StringBuilder("SELECT PaidExpences.FinancialYear as Particulars, SUM(PaidExpences.Amount) AS Amount FROM ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID where 1=1");
                if (companyId > 0)
                {
                    query.Append(" and CompanyID = " + companyId);
                }

                if (expenseType != ExpenseTypes.Indirect)
                {
                    if (buildingID > 0)
                    {
                        query.Append(" and buildingID = " + buildingID);
                    }
                }
                query.Append(getExpenseTypeCondition(expenseType));
                query.Append(" GROUP BY PaidExpences.FinancialYear");
                return Sqlhelper.GetDatatable(query.ToString());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
            
        }

        public static string getExpenseTypeCondition(ExpenseTypes expenseTye)
        {
            if (expenseTye == ExpenseTypes.Direct)
            {
                return " and ExpensesMaster.IsDirect = 'True'";
            }
            else if (expenseTye == ExpenseTypes.Indirect)
            {
                return " and ExpensesMaster.IsDirect = 'False'";
            }
            else
            {
                return "";
            }
        }

        public static DataSet get_Income_Expense(bool isForProfitLoss, bool isExpense, DateTime fromdate, DateTime todate, string branchId)
        {
            try
            {
                string spName = "s_pr_disp_expenses";
                SqlCommand com = new SqlCommand(spName);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@isExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = fromdate;
                com.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = todate;
                com.Parameters.Add("@isForPrfitLoss", SqlDbType.Bit).Value = isForProfitLoss;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataSet ds = Sqlhelper.GetDataset(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return ds;
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

        public static DataTable getQuarterlyReport(int companyId, int buildingID, ExpenseTypes expenseType, string financialYear)
        {
            try
            {
                StringBuilder query = new StringBuilder("SELECT PaidExpences.Quarter as Particulars, SUM(PaidExpences.Amount) AS Amount FROM ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID where 1=1");
                if (companyId > 0)
                {
                    query.Append(" and CompanyID = " + companyId);
                }
                if (financialYear != "ALL")
                    query.Append(" and PaidExpences.FinancialYear = '" + financialYear + "'");
                if (expenseType != ExpenseTypes.Indirect)
                {
                    if (buildingID > 0)
                    {
                        query.Append(" and buildingID = " + buildingID);
                    }
                }
                query.Append(getExpenseTypeCondition(expenseType));
                query.Append(" GROUP BY PaidExpences.Quarter");
                return Sqlhelper.GetDatatable(query.ToString());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

            //  return null;
        }

        public static DataTable getMonthlyReport(int companyId, int buildingID, ExpenseTypes expenseType, string financialYear, string month)
        {
            try
            {
                StringBuilder query = new StringBuilder("SELECT MONTH(PaidExpences.Date) as Particulars, SUM(PaidExpences.Amount) AS Amount FROM ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID where 1=1");
                if (companyId > 0)
                    query.Append(" and CompanyID = " + companyId);

                if (financialYear != "ALL")
                    query.Append(" and PaidExpences.FinancialYear = '" + financialYear + "'");

                if (expenseType != ExpenseTypes.Indirect)
                {
                    if (buildingID > 0)
                    {
                        query.Append(" and buildingID = " + buildingID);
                    }
                }

                if (month != "ALL")
                    query.Append(" and MONTH(PaidExpences.Date) = " + Convert.ToInt32(month));

                query.Append(getExpenseTypeCondition(expenseType));
                query.Append(" GROUP BY MONTH(PaidExpences.Date)");
                return Sqlhelper.GetDatatable(query.ToString());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getBuildingWiseReport(int companyId, int buildingID, ExpenseTypes expenseType, string financialYear, string month)
        {
            try
            {
                StringBuilder query = new StringBuilder("SELECT Building.BuildingName as Particulars, SUM(PaidExpences.Amount),Building.BuildingID AS Amount FROM ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID  INNER JOIN Building ON PaidExpences.CompanyID = Building.CompanyID where 1=1");
                if (companyId > 0)
                    query.Append(" and PaidExpences .CompanyID = " + companyId);

                if (financialYear != "ALL")
                    query.Append(" and PaidExpences.FinancialYear = '" + financialYear + "'");

                if (expenseType != ExpenseTypes.Indirect)
                {
                    if (buildingID > 0)
                    {
                        query.Append(" and PaidExpences.buildingID = " + buildingID);
                    }
                }

                if (month != "ALL")
                    query.Append(" and MONTH(PaidExpences.Date) = " + Convert.ToInt32(month));

                query.Append(getExpenseTypeCondition(expenseType));
                query.Append(" GROUP BY Building.BuildingName, Building.BuildingID");
                return Sqlhelper.GetDatatable(query.ToString());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getReceiptwiseReport(int companyId, int buildingID, ExpenseTypes expenseType, string financialYear, string month)
        {

            try
            {
                StringBuilder query;
                if (expenseType == ExpenseTypes.Direct)
                    query = new StringBuilder("SELECT  PaidExpences.Id,Company.CompanyName, Building.BuildingName, ExpensesMaster.Description AS 'Expense', PaidExpences.Description, PaidExpences.PaidTo, PaidExpences.Amount,cast(day(PaidExpences.Date) as nvarchar)+'/'+cast(month(PaidExpences.Date) as nvarchar)+'/'+cast(year(PaidExpences.Date) as nvarchar) as 'Date' FROM  ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID INNER JOIN Building ON PaidExpences.BuildingID = Building.BuildingID INNER JOIN Company ON PaidExpences.CompanyID = Company.CompanyID where 1=1");
                else
                    query = new StringBuilder("SELECT  PaidExpences.Id,Company.CompanyName, ExpensesMaster.Description AS 'Expense', PaidExpences.Description, PaidExpences.PaidTo, PaidExpences.Amount, cast(day(PaidExpences.Date) as nvarchar)+'/'+cast(month(PaidExpences.Date) as nvarchar)+'/'+cast(year(PaidExpences.Date) as nvarchar) as 'Date' FROM  ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID  INNER JOIN Company ON PaidExpences.CompanyID = Company.CompanyID where 1=1");


                if (companyId > 0)
                    query.Append(" and PaidExpences .CompanyID = " + companyId);

                if (financialYear != "ALL")
                    query.Append(" and PaidExpences.FinancialYear = '" + financialYear + "'");

                if (expenseType == ExpenseTypes.Direct)
                {
                    if (buildingID > 0)
                    {
                        query.Append(" and PaidExpences.buildingID = " + buildingID);
                    }
                }

                if (month != "ALL")
                    query.Append(" and MONTH(PaidExpences.Date) = " + Convert.ToInt32(month));

                query.Append(getExpenseTypeCondition(expenseType));

                return Sqlhelper.GetDatatable(query.ToString());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static DataTable getAccumulatedReport(int companyId, int buildingID, ExpenseTypes expenseType, string financialYear, string month)
        {
            try
            {
                StringBuilder query;
                if (expenseType == ExpenseTypes.Direct)
                    query = new StringBuilder("SELECT  ExpensesMaster.Description AS 'Particulars',sum (PaidExpences.Amount) as 'Amount' FROM  ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID INNER JOIN Building ON PaidExpences.BuildingID = Building.BuildingID INNER JOIN Company ON PaidExpences.CompanyID = Company.CompanyID where 1=1");
                else
                    query = new StringBuilder("SELECT  ExpensesMaster.Description AS 'Particulars', sum(PaidExpences.Amount) as Amount FROM  ExpensesMaster INNER JOIN PaidExpences ON ExpensesMaster.ExpenceID = PaidExpences.ExpenseID  INNER JOIN Company ON PaidExpences.CompanyID = Company.CompanyID where 1=1");


                if (companyId > 0)
                    query.Append(" and PaidExpences .CompanyID = " + companyId);

                if (financialYear != "ALL")
                    query.Append(" and PaidExpences.FinancialYear = '" + financialYear + "'");

                if (expenseType == ExpenseTypes.Direct)
                {
                    if (buildingID > 0)
                    {
                        query.Append(" and PaidExpences.buildingID = " + buildingID);
                    }
                }

                if (month != "ALL")
                    query.Append(" and MONTH(PaidExpences.Date) = " + Convert.ToInt32(month));

                query.Append(getExpenseTypeCondition(expenseType));
                query.Append(" GROUP BY ExpensesMaster.Description");
                return Sqlhelper.GetDatatable(query.ToString());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static int deleteExpendeMaster(int expenseId, bool isExpense, string description, int branchID)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_expense_master");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ExpenseId", SqlDbType.Int).Value = expenseId;
                com.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = Convert.ToInt32(branchID);
                com.Parameters.Add("@IsExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return 1;
                }
                else
                {
                    
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                return 2;
                //throw ex;
            }
        }

        public static int UpdateExpenseMaster(int expenseId, bool isExpense, string description, int branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_update_expense_master");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ExpenseId", SqlDbType.Int).Value = expenseId;
                com.Parameters.Add("@IsExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchID;
                com.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return 1;
                }
                else
                {
                    return 2;
                    //throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {

                return 2;
                //throw ex;
            }
        }

        public static List<Expense> loadExpensesDetails(bool isExpense, string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_expense_master");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@IsExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtExpense = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Expense.getIncomeExps(dtExpense);
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

        public static int UpdatePaidExpenseOrIncome(Expense objExpense, int PdexId, int branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_update_paid_expense");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@paidID", SqlDbType.Int).Value = PdexId;
                com.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = objExpense.Description;
                com.Parameters.Add("@ACCOUNT_ID", SqlDbType.Int).Value = objExpense.Account.Id;
                com.Parameters.Add("@paidTo", SqlDbType.VarChar).Value = objExpense.PaidTo;
                com.Parameters.Add("@amount", SqlDbType.Decimal).Value = objExpense.Amount;
                com.Parameters.Add("@date", SqlDbType.Date).Value = objExpense.Date;
                com.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = objExpense.FilePath;
                com.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = objExpense.PayMode;
                com.Parameters.Add("@expId", SqlDbType.Int).Value = objExpense.ExpenseId;
                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Convert.ToInt32(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value);
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

        public static DataTable getCategoryWiseCollection(bool isExpense, string branchID , DateTime fromDate=default(DateTime), DateTime? toDate=null)
        {
            try
            {
                if (toDate == null)
                {
                    toDate = DateTime.MaxValue ;
                }
                SqlCommand com = new SqlCommand("s_pr_disp_categorywise_expense");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@isExpense", SqlDbType.Bit).Value = isExpense;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = toDate;
                
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = Sqlhelper.GetDatatable(com);

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

        public static DataSet getIncomeExpence(string branchId)
        {
            try
            {
                //com = new SqlCommand("s_pr_get_Income_Expence");
                com = new SqlCommand("s_pr_disp_expenses");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataSet ds = Sqlhelper.GetDataset(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return ds;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception e)
            {
                Common.Log.LogError(e, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw e;
            }
        }

        public static void exportData(DateTime reportDate,String branchId,Boolean closeApp = false)
        {
            string ReportFolder;

            string fromdate = reportDate.ToShortDateString();
            string date = reportDate.ToShortDateString();
            DataSet ds = BLL.ExpenseHandler.get_Income_Expense(true, false, Convert.ToDateTime(fromdate), Convert.ToDateTime(date), branchId.ToString());
            DataTable income = ds.Tables[0];
            DataTable expence = ds.Tables[1];
            DataView dv_Income = new DataView(income);
            if (date != null)
            {
                dv_Income.RowFilter = " (PDEX_DATE >= #" + Convert.ToDateTime(fromdate).ToString("MM/dd/yyyy") + "# And PDEX_DATE <= #" + Convert.ToDateTime(date).ToString("MM/dd/yyyy") + "# ) ";
            }

            DataView dv_Expense = new DataView(expence);
            if (date != null)
            {
                dv_Expense.RowFilter = " (PDEX_DATE >= #" + Convert.ToDateTime(fromdate).ToString("MM/dd/yyyy") + "# And PDEX_DATE <= #" + Convert.ToDateTime(date).ToString("MM/dd/yyyy") + "# ) ";
            }

            if (income.Rows.Count != 0)
            {
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp"))
                {
                    DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp");
                    Di.Delete(true);
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp");
                }
                else
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp");
                }

                ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Expense\\Exp\\ExpenseReport-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                Common.ImportExport.exportToExcel(income, ReportFolder, closeApp);
            }


            if (expence.Rows.Count != 0)
            {
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Income\\Inc"))
                {
                    DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Income\\Inc");
                    Di.Delete(true);
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Income\\Inc");
                }
                else
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Income\\Inc");
                }
                ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "Income\\Inc\\IncomeReport-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                Common.ImportExport.exportToExcel(expence, ReportFolder,closeApp);
            }
        }
        
    }
}
