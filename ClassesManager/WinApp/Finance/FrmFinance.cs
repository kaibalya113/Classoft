using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Common;
using ClassManager.Info;
using ClassManager.BLL;
using System.Globalization;
using ClassManager.WinApp.UICommon;
using System.Net.Mail;
using System.IO;


namespace ClassManager.WinApp
{
    public partial class FrmFinance : FrmParentForm
    {
        RolePrivilege formPrevileges;
        private static FrmFinance ExcelSave;
        string sCaption = "Profit And Loss";
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        Boolean sAllowIndexChange;
        Boolean allow = true;
        public FrmFinance()
        {
            InitializeComponent();
        }

        private void Profit_OR_Loss_Load(object sender, EventArgs e)
        { 
           try
            {
                // ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, WinApp.Program.LoggedInUser.BranchId.ToString());
                formatDTP();

                sAllowIndexChange = false;

                populateComboMonth();
                //populateComboYear();

                AssignEvents();
                ADGVExpense.ReadOnly = true;
                ADGVFeesColl.ReadOnly = true;

                sAllowIndexChange = true;

                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        internal static FrmFinance getExcel()
        {
            if (ExcelSave == null)
            {
                ExcelSave = new FrmFinance();
            }


            return ExcelSave;
        }
        /// <summary>
        /// This Function will assign Privileges based on the type of the user logged in.
        /// </summary>
        private void ApplyPrevileges()
        {
            try
            {
                int functionId = Convert.ToInt32(this.Tag.ToString());
                formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {
                        chkBranchID.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {

                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formatDTP()
        {
            try
            {
                //Formats DatetimePicker
                UICommon.WinForm.formatDateTimePicker(dtpFromdate);
                UICommon.WinForm.formatDateTimePicker(dtpDate);

                //Sets Date
                UICommon.WinForm.setDate(dtpFromdate, dtpDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void AssignEvents()
        {

            ADGVFeesColl.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVFeesColl.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVExpense.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVExpense.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            feesCollection(branchId);

        }
        /*  public void populateComboYear()
          {

              for (int j = Convert.ToInt32(SysParam.getValue<Int32>(SysParam.Parameters.APP_START_YEAR)); j <= DateTime.Now.Year; j++)
              {
                  Info.ComboItem objAll = new ComboItem(j.ToString(), j.ToString());
                  cmbYear.Items.Add(objAll);
              }

              if (cmbYear.Items.Count > 0)
              {
                  cmbYear.SelectedIndex = 0;
              }
          }*/
        public void populateComboMonth()
        {

            Info.ComboItem objAll = new ComboItem("0", "ALL");
            Info.ComboItem objJan = new ComboItem("1", "January");


            Info.ComboItem objFeb = new ComboItem("2", "February");
            Info.ComboItem objMar = new ComboItem("3", "March");

            Info.ComboItem objAprl = new ComboItem("4", "April");
            Info.ComboItem objMay = new ComboItem("5", "May");


            Info.ComboItem objJun = new ComboItem("6", "Jun");
            Info.ComboItem objJul = new ComboItem("7", "July");


            Info.ComboItem objAug = new ComboItem("8", "August");
            Info.ComboItem objSept = new ComboItem("9", "September");


            Info.ComboItem objOct = new ComboItem("10", "October");
            Info.ComboItem objNov = new ComboItem("11", "November");

            Info.ComboItem objDec = new ComboItem("12", "December");
            /* cmbMonth.Items.Clear();
             cmbMonth.Items.Add(objAll);
             cmbMonth.Items.Add(objJan);
             cmbMonth.Items.Add(objFeb);
             cmbMonth.Items.Add(objMar);
             cmbMonth.Items.Add(objAprl);
             cmbMonth.Items.Add(objMay);
             cmbMonth.Items.Add(objJun);
             cmbMonth.Items.Add(objJul);
             cmbMonth.Items.Add(objAug);
             cmbMonth.Items.Add(objSept);
             cmbMonth.Items.Add(objOct);
             cmbMonth.Items.Add(objNov);
             cmbMonth.Items.Add(objDec);

             cmbMonth.SelectedIndex = 0;*/

        }



        public void feesCollection(string branchID)
        {
            loadFeesCollection(branchID);
            calculateProfLoss(branchID);
        }

        private void loadDetails(string branchId)
        {
            try
            {
                if (chkBranchID.Checked)
                {
                    branchId = "%";

                }
                else
                {
                    branchId = WinApp.Program.LoggedInUser.BranchId.ToString();

                }
                loadData();
                feesCollection(branchId);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {


        }
        private void calculateProfLoss(string branchID)
        {
            Decimal total = ADGVFeesColl.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));


            Decimal totalExp = ADGVExpense.Rows.Cast<DataGridViewRow>()
                     .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));

            lblTotalExpence.Text = totalExp.ToString();
            lblFCOLL.Text = total.ToString();
            lblFCOLL.Text = Common.Formatter.FormatCurrency(total);
            lblTotalExpence.Text = Common.Formatter.FormatCurrency(totalExp);
            Decimal prof_loss = 0;
            prof_loss = total - totalExp;

            if (prof_loss > 0)
            {
                lblProfLoss.Text = "Profit : ";
                lblPL.Text = Common.Formatter.FormatCurrency(prof_loss);
            }
            else if (prof_loss == 0)
            {
                lblProfLoss.Text = "Profit/Loss : ";
                lblPL.Text = " ";
            }
            else if (prof_loss < 0)
            {

                lblProfLoss.Text = "Loss : ";
                lblPL.Text = Math.Abs(prof_loss).ToString();
            }


        }

        private void FilterValue(string branchID)
        {
            try
            {
                //ADGVFeesColl.DataSource = income;
                Decimal total = ADGVFeesColl.Rows.Cast<DataGridViewRow>()
                      .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));
                lblFCOLL.Text = total.ToString();

                Decimal totalExp = ADGVExpense.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));
                lblTotalExpence.Text = totalExp.ToString();

                calculateProfLoss(branchID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void loadFeesCollection(string branchID)
        {
            try
            {
                ADGVFeesColl.DataSource = null;
                ADGVExpense.DataSource = null;


                //DataSet ds = BLL.ExpenseHandler.getIncomeExpence(branchID);

                DataSet ds = BLL.ExpenseHandler.get_Income_Expense(true, false, dtpFromdate.Value, dtpDate.Value, branchId.ToString());

                DataTable income = ds.Tables[0];
                DataTable expence = ds.Tables[1];


                ADGVFeesColl.DataSource = income;
                Decimal total = ADGVFeesColl.Rows.Cast<DataGridViewRow>()
                     .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));

                lblFCOLL.Text = total.ToString();

                ADGVExpense.DataSource = expence;
                Decimal totalExp = ADGVExpense.Rows.Cast<DataGridViewRow>()
                     .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));

                lblTotalExpence.Text = totalExp.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void loadExpenseDetails(Boolean considerDate, int branchID)
        {
            try
            {
                //considerDate = false;
                //DataSet ds = BLL.FeesCollRptHandler.getIncomeExpence(branchID);
                //ADGVExpense.DataSource = ds.Tables[1];

                //Decimal totalExp = ADGVExpense.Rows.Cast<DataGridViewRow>()
                //     .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));

                //lblTotalExpence.Text = totalExp.ToString();

                //string year = (cmbYear.SelectedItem as ComboItem).strKey;
                //string month = (cmbMonth.SelectedItem as ComboItem).strKey;
                //DataTable dtExpence=ExpenceCollection.getExpenceDetails(year, month,branchID);

                //if (dtExpence != null)
                //{

                //    ADGVExpense.DataSource = dtExpence;

                //}
                //else
                //{

                //    ADGVExpense.DataSource = null;


                //}

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sAllowIndexChange == true)
            {
                sAllowIndexChange = false;
                //cmbMonth.SelectedIndex = 0;
            }

            sAllowIndexChange = true;
            loadDetails(branchId);
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (sAllowIndexChange == true)
                {
                    //loadDetails(branchID);
                    ADGVFeesColl.DataSource = null;
                    ADGVExpense.DataSource = null;
                    // int month = Convert.ToInt32((cmbMonth.SelectedItem as ComboItem).strKey);
                    DataSet ds = BLL.ExpenseHandler.getIncomeExpence(branchId);

                    DataTable income = ds.Tables[0];
                    DataTable expence = ds.Tables[1];
                    DataView dv_Income = new DataView(income);
                    // if(month!=0)
                    // dv_Income.RowFilter = "Month=" + month;

                    DataView dv_Expense = new DataView(expence);
                    //if (month != 0)
                    // dv_Expense.RowFilter = "Month=" + month;
                    if (dv_Income.Count != 0)
                    {
                        ADGVFeesColl.DataSource = dv_Income;
                        calculateProfLoss(branchId);
                    }
                    else
                    {

                        lblFCOLL.Text = "0";
                        lblPL.Text = (Convert.ToInt32(lblFCOLL.Text) - Convert.ToInt32(lblTotalExpence.Text)).ToString();

                    }
                    if (dv_Expense.Count != 0)
                    {
                        ADGVExpense.DataSource = dv_Expense;
                        calculateProfLoss(branchId);
                    }
                    else
                    {
                        lblTotalExpence.Text = "0";
                        lblPL.Text = (Convert.ToUInt32(lblFCOLL.Text) - Convert.ToInt32(lblTotalExpence.Text)).ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVFeesColl_SortStringChanged(object sender, EventArgs e)
        {
            try
            {
                ADGV.AdvancedDataGridView gridView = (ADGV.AdvancedDataGridView)sender;
                BindingSource bs = new BindingSource();
                bs.DataSource = gridView.DataSource;
                bs.Sort = gridView.SortString;

                calculateProfLoss(branchId);
            }
            catch (Exception)
            { }
        }

        private void ADGVFeesColl_FilterStringChanged(object sender, EventArgs e)
        {
            try
            {
                ADGV.AdvancedDataGridView gridView = (ADGV.AdvancedDataGridView)sender;
                BindingSource bs = new BindingSource();
                bs.DataSource = gridView.DataSource;
                string s = gridView.FilterString;

                // you code to format FilterString

                bs.Filter = s;
                calculateProfLoss(branchId);
            }
            catch (Exception)
            { }

        }

        private void ADGVExpense_FilterStringChanged(object sender, EventArgs e)
        {
            try
            {
                ADGV.AdvancedDataGridView gridView = (ADGV.AdvancedDataGridView)sender;
                BindingSource bs = new BindingSource();
                bs.DataSource = gridView.DataSource;
                string s = gridView.FilterString;

                // you code to format FilterString

                bs.Filter = s;
                calculateProfLoss(branchId);
            }
            catch (Exception)
            { }
        }

        private void ADGVExpense_SortStringChanged(object sender, EventArgs e)
        {
            try
            {
                ADGV.AdvancedDataGridView gridView = (ADGV.AdvancedDataGridView)sender;
                BindingSource bs = new BindingSource();
                bs.DataSource = gridView.DataSource;
                bs.Sort = gridView.SortString;
                calculateProfLoss(branchId);
            }
            catch (Exception)
            { }
        }

        private void ADGVFeesColl_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //follow for hiding columns
            //for (int i = 6; i < 12; i++)
            //{
            //    ADGVFeesColl.Columns[i].Visible = false;
            //}
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadDetails(branchId);

        }

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {

            checkBranch();

        }
        public void checkBranch()
        {
            try
            {
                //if (WinApp.Program.LoggedInUser.Type == "A")
                //{
                if (chkBranchID.Checked)
                {
                    branchId = "%";
                    loadDetails(branchId);
                }
                else
                {
                    branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
                    loadDetails(branchId);
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void Income_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Income.SelectedIndex == 0)
            //{
            //    ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false,  WinApp.Program.LoggedInUser.BranchId.ToString());
            //}
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            string branchID;
            if (chkBranchID.Checked)
            {
                branchId = "%";
                // ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(true, branchId);
            }
            else
            {
                branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
                // /ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(true, WinApp.Program.LoggedInUser.BranchId.ToString());
            }
            //ADGVExpense.DataSource = BLL.ExpenseHandler.getPaidExpense(true, true,branchId.ToString());
            // feesCollection(branchId);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void loadData() //sayali
        {
            try
            {
                if (sAllowIndexChange == true)
                {

                    ADGVFeesColl.DataSource = null;
                    ADGVExpense.DataSource = null;

                    string fromdate = dtpFromdate.Value.ToShortDateString();
                    string date = dtpDate.Value.ToShortDateString();
                    DataSet ds = BLL.ExpenseHandler.get_Income_Expense(true, false, Convert.ToDateTime(fromdate), Convert.ToDateTime(date), branchId.ToString());
                    DataTable income = ds.Tables[0];
                    DataTable expence = ds.Tables[1];
                    DataView dv_Income = new DataView(income);
                    if (date != null)

                        //dv_Income.RowFilter = "" + date.ToString("dd/MMM/yyyy") ;  
                        //dv_Income.RowFilter = string.Format("Date= '{0}'",date);    //working for single date value
                        dv_Income.RowFilter = " (PDEX_DATE >= #" + Convert.ToDateTime(fromdate).ToString("MM/dd/yyyy") + "# And PDEX_DATE <= #" + Convert.ToDateTime(date).ToString("MM/dd/yyyy") + "# ) ";
                    DataView dv_Expense = new DataView(expence);
                    if (date != null)
                        //dv_Expense.RowFilter = string.Format("Date= '{0}'", date);  //working for single date value
                        dv_Expense.RowFilter = " (PDEX_DATE >= #" + Convert.ToDateTime(fromdate).ToString("MM/dd/yyyy") + "# And PDEX_DATE <= #" + Convert.ToDateTime(date).ToString("MM/dd/yyyy") + "# ) ";
                    if (dv_Income.Count != 0)
                    {
                        ADGVFeesColl.DataSource = dv_Income;
                        calculateProfLoss(branchId);
                    }
                    else

                    {
                        //lblFCOLL.Text = Common.Formatter.FormatCurrency(decimal.Zero);
                        lblFCOLL.Text = "0.00";
                        Decimal totalExp = ADGVExpense.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));
                        Decimal profitLoss = (totalExp - 0);
                        lblFCOLL.Text = Common.Formatter.FormatCurrency(0);
                        lblPL.Text = Common.Formatter.FormatCurrency(profitLoss);
                        //lblPL.Text = (Convert.ToInt32(lblFCOLL.Text) - Convert.ToInt32(lblTotalExpence.Text)).ToString();
                    }
                    if (dv_Expense.Count != 0)
                    {
                        ADGVExpense.DataSource = dv_Expense;
                        calculateProfLoss(branchId);
                    }
                    else
                    {
                        lblTotalExpence.Text = "0.00";
                        Decimal total = ADGVFeesColl.Rows.Cast<DataGridViewRow>()
                       .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));
                        //lblPL.Text = ((Convert.ToDecimal(lblFCOLL.Text) - Convert.ToDecimal(lblTotalExpence.Text)).ToString());
                        Decimal profitLoss = (total - 0);
                        lblTotalExpence.Text = Common.Formatter.FormatCurrency(0);
                        lblPL.Text = Common.Formatter.FormatCurrency(profitLoss);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        //private void cmdSaveExpense_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ADGVExpense.Rows.Count != 0)
        //        {
        //            Common.ImportExport.ImportToExcel(ADGVExpense);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        //private void cmdSaveIncome_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ADGVFeesColl.Rows.Count != 0)
        //        {
        //            Common.ImportExport.ImportToExcel(ADGVFeesColl);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.None, sCaption, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }

        //}

        private void dtpFromdate_CloseUp(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtpDate_CloseUp(object sender, EventArgs e)
        {
            loadData();
        }

        private void ADGVExpense_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatExpenseGrids();
                FilterValue(branchId);
                foreach (DataGridViewRow adrow in ADGVExpense.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVExpense.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVFeesColl_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatIncomeGrids();
                FilterValue(branchId);
                foreach (DataGridViewRow adrow in ADGVFeesColl.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVFeesColl.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void formatExpenseGrids()
        {
            try
            {
                //changing Date format.
                ADGVExpense.Columns["PDEX_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                //Hiding Columns.
                ADGVExpense.Columns["PDEX_ID"].Visible = false;
                ADGVExpense.Columns["PDEX_BRANCH_ID"].Visible = false;
                ADGVExpense.Columns["PDEX_ACCNT_ID"].Visible = false;

                //Changing HeaderText.
                ADGVExpense.Columns["PDEX_DATE"].HeaderText = "Date";
                ADGVExpense.Columns["PDEX_DESC"].HeaderText = "Description";
                ADGVExpense.Columns["PDEX_PAID_TO"].HeaderText = "Paid To";
                ADGVExpense.Columns["ACT_NAME"].HeaderText = "Account";
                ADGVExpense.Columns["PDEX_PAYMENT_MODE"].HeaderText = "Payment Mode";
                ADGVExpense.Columns["PDEX_FILE_PATH"].HeaderText = "File Path";
                ADGVExpense.Columns["PDEX_FILE_PATH"].Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void formatIncomeGrids()
        {
            try
            {
                //Changing Date format
                ADGVFeesColl.Columns["PDEX_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                //Changing HeaderText.
                ADGVFeesColl.Columns["PDEX_DATE"].HeaderText = "Date";
                ADGVFeesColl.Columns["PDEX_DESC"].HeaderText = "Description";
                ADGVFeesColl.Columns["ACT_NAME"].HeaderText = "Account";
                //Hiding Columns.
                // ADGVFeesColl.Columns["PDEX_DESC"].Visible = false;
                ADGVFeesColl.Columns["PDEX_ACCNT_ID"].Visible = false;
                ADGVFeesColl.Columns["PDEX_PAYMENT_MODE"].HeaderText = "Payment Mode";
                ADGVFeesColl.Columns["PDEX_FILE_PATH"].HeaderText = "File Path";
                ADGVFeesColl.Columns["PDEX_FILE_PATH"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void chkBranchID_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (chkBranchID.Checked)
        //    {
        //        branchId = "%";
        //        //ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(true, branchId);
        //    }
        //    else
        //    {
        //        branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        //        //ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(true, WinApp.Program.LoggedInUser.BranchId.ToString());
        //    }
        //    loadData();
        //}

        private void ADGVExpense_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVExpense, e);
        }

        private void ADGVFeesColl_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVFeesColl, e);
        }

        private void cmdSaveExpense_Click(object sender, EventArgs e)
        {

            try
            {
               // ExcelIncome();
                string ReportFolder;
                if (ADGVExpense.Rows.Count != 0)
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
                    Common.ImportExport.ImportToExcel(ADGVExpense, ReportFolder);
                }

                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmdSaveIncome_Click(object sender, EventArgs e)
        {
            try
            {
                string ReportFolder;
                if (ADGVFeesColl.Rows.Count != 0)
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
                    Common.ImportExport.ImportToExcel(ADGVFeesColl, ReportFolder);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.None, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void btnExpenseMail_Click(object sender, EventArgs e)
        {
            try
            {
                Expense();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnMailExpense_Click(object sender, EventArgs e)
        {
            try
            {
                Income();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpFromdate_ValueChanged(object sender, EventArgs e)
        {

        }
        public void Expense()
        {
            try
            {
                bool sentMail = false;
                string ReportFolder;
                List<string> attachment = new List<string>();
                if (ADGVExpense.Rows.Count != 0)
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
                    Common.ImportExport.ImportToExcel(ADGVExpense, ReportFolder);

                    attachment.Add(ReportFolder);


                    
                    string emailbody = "Please find the Attachment given below of Expense Report :";
                    List<string> EmailId = new List<string>();
                    EmailId.Add(Info.SysParam.getValue<string>(SysParam.Parameters.EMAIL_ADDRESS));

                    sentMail = MailHandler.sendEmail(emailbody, EmailId, "Expense Report", attachment);
                    if (sentMail == true)
                    {
                        UICommon.WinForm.showStatus("Mail Sent Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Mail not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("As there are No records for Expense to Save,Mail Cannot be send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Income()
        {
            try
            {
                bool sentMail = false;
                string ReportFolder;
                List<string> attachment = new List<string>();
                if (ADGVFeesColl.Rows.Count != 0)
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
                    Common.ImportExport.ImportToExcel(ADGVFeesColl, ReportFolder);

                    attachment.Add(ReportFolder);

                    
                    string emailbody = "Please find the Attachment given below of Income Report :";
                    List<string> EmailId = new List<string>();
                    EmailId.Add(Info.SysParam.getValue<string>(SysParam.Parameters.EMAIL_ADDRESS));

                    sentMail = MailHandler.sendEmail( emailbody, EmailId, "Income Report", attachment);
                    if (sentMail == true)
                    {
                        UICommon.WinForm.showStatus("Mail Sent Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Mail not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("As there are No records for Income to Save,Mail Cannot be send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcelIncome()
        {
            try
            {
                string ReportFolder;
                if (ADGVExpense.Rows.Count != 0)
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
                    Common.ImportExport.ImportToExcel(ADGVExpense, ReportFolder);
                }


                if (ADGVFeesColl.Rows.Count != 0)
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
                    Common.ImportExport.ImportToExcel(ADGVFeesColl, ReportFolder);
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void DataLoad(string branchID)
        {
            ADGVFeesColl.DataSource = null;
            ADGVExpense.DataSource = null;

            var today = DateTime.Today;
            DataSet ds = BLL.ExpenseHandler.get_Income_Expense(true, false, DateTime.Today.AddDays(-(DateTime.Today.Day - 1)), DateTime.Now, branchId.ToString());

            DataTable income = ds.Tables[0];
            DataTable expence = ds.Tables[1];

            ADGVFeesColl.DataSource = income;

            ADGVExpense.DataSource = expence;

        }

       
    }
}
