using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.Info.Reporting;
using ClassManager.Info;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmIncomeReport : FrmParentForm
    {

        string branchID = Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Income";
        List<Info.Expense> lstIncm = new List<Info.Expense>();
        public FrmIncomeReport()
        {
            InitializeComponent();
        }

        private void FrmIncomeReport_Load(object sender, EventArgs e)
        {
            try
            {
                AddColumn();
                Formatdate();
            
                if (validateDates())
                {
                    if (cmbViewExpenses.SelectedIndex != 1)
                    {
                    
                           DataTable dt= BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                        ADGVIncome.DataSource = dt;
                        if (ADGVIncome.Rows.Count > 0)
                        { label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", ""))); }
                        else
                        {
							label1.Text = "";
                        }
                    }
                }
                AssignEvents();

                //UICommon.WinForm.setDate(dtpFromDate, dtpToDate);
                //ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(),dtpFromDate.Value,dtpToDate.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AssignEvents()
        {
            try
            {

                ADGVIncome.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
                ADGVIncome.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void AddColumn()
        {
            ADGVIncome.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.download,
                Name = "ViewFile",
                HeaderText = "View"
            });
            ADGVIncome.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.Edit,
                Name = "Edit",
                HeaderText = "Edit"
            });
        }

        private void btnUpdatePaidIncome_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = ADGVIncome.DataSource as DataTable;
                Info.Expense objExpense = new Info.Expense();
                int returnCode = 0;

                foreach (DataRow income in dt.Rows)
                {
                    if (income[0] != null && income[0].ToString() != "0")
                    {
                        
                        objExpense.ExpenseId = Convert.ToInt32(income["PDEX_ID"]);
                        objExpense.PaidTo = income["PDEX_PAID_TO"].ToString();
                        objExpense.Amount = Convert.ToDecimal(income["Amount"].ToString());
                        objExpense.Date = Convert.ToDateTime(income["PDEX_DATE"]);
                        objExpense.Description = Convert.ToString(income["PDEX_DESC"]);
                        objExpense.Account.Id = Convert.ToInt32(income["PDEX_ACCNT_ID"]);
                        objExpense.BranchID = Convert.ToInt32(income["PDEX_BRANCH_ID"]);
                     //   returnCode = BLL.ExpenseHandler.UpdatePaidExpenseOrIncome(objExpense);

                        
                    }
                }
                if (returnCode == 1)
                {
                    UICommon.WinForm.showStatus("Income Updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

                //If ShowAllBranch CheckBox is checked then Data will be fetched accordingly.
                if (!chkShowAllBranch.Checked)
                {
                    ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());
                }
                else
                {
                    ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, "%");
                }


            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVIncome.DataSource != null)
                {
                    Common.ImportExport.ImportToExcel(ADGVIncome, null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showStatus("Please Install Excel So that Document can be Saved.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkShowAllBranch_CheckedChanged(object sender, EventArgs e)
        {

            if (chkShowAllBranch.Checked)
            {
                branchID = "%";
            }
            else
            {
                branchID = Program.LoggedInUser.BranchId.ToString();
            }



            if (cmbViewExpenses.SelectedIndex != -1)
            {
                if (cmbViewExpenses.SelectedIndex == 0)
                {
                    panelMaxInc.Visible = false;
                    btnUpdatePaidIncome.Enabled = true;
                    if (!chkShowAllBranch.Checked)
                    {
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());
                    }
                    else
                    {
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, "%");

                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    panelMaxInc.Visible = true;

                    btnUpdatePaidIncome.Enabled = false;
                    if (!chkShowAllBranch.Checked)
                    {
                        dt = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID);
                    }
                    else
                    {
                        dt = BLL.ExpenseHandler.getCategoryWiseCollection(false, "%");
                    }
                    if (dt.Rows.Count != 0)
                    {
                        ADGVIncome.DataSource = dt;
                        showMaxIncome(dt);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No records to display.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        ADGVIncome.DataSource = null;
                    }

                }
            }
            else
            {
                ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());
            }

        }


        private void showIncome(DataTable dt)
        {
            try
            {
                if (ADGVIncome.Rows.Count != 0)
                {
                    panelMaxInc.Visible = true;

                }
                else
                {
                    panelMaxInc.Visible = false;
                }
                DataView expenseView = new DataView(dt);
                if (expenseView.Table.Rows.Count > 0)
                {
                   
                    Decimal TotAmount = ADGVIncome.Rows.Cast<DataGridViewRow>()
                                 .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));
                    label1.Text = TotAmount.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void showMaxIncome(DataTable dt)
        {
            try
            {
                if (ADGVIncome.Rows.Count != 0)
                {
                    panelMaxInc.Visible = true;

                }
                else
                {
                    panelMaxInc.Visible = false;
                }
                DataView expenseView = new DataView(dt);
                if (expenseView.Table.Rows.Count > 0)
                {
                    Decimal maxAmount = ADGVIncome.Rows.Cast<DataGridViewRow>()
                                 .Max(t => Convert.ToDecimal(t.Cells["Total"].Value));

                    string name = ((from DataRow dr in dt.Rows where Convert.ToDecimal(dr["Total"]) == maxAmount select (string)dr[0]).FirstOrDefault()).ToString();


                    lblNameAndAmount.Text = name + ":  " + maxAmount.ToString();

                    Decimal TotAmount = ADGVIncome.Rows.Cast<DataGridViewRow>()
                                 .Sum(t => Convert.ToDecimal(t.Cells["Total"].Value));
                    label1.Text = TotAmount.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbViewExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                if (chkDtFilter.Checked == true)
                {
                    if (cmbViewExpenses.SelectedIndex == 1)
                    {
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID, dtpFromDate.Value, dtpToDate.Value);
                        showMaxIncome((DataTable)ADGVIncome.DataSource);
                        btnUpdatePaidIncome.Enabled = false;

                    }
                    else
                    {
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                        showIncome((DataTable)ADGVIncome.DataSource);
                        panelMaxInc.Visible = false;
                        btnUpdatePaidIncome.Enabled = true;
                    }
                }

                else
                {
                    if (cmbViewExpenses.SelectedIndex == 0)
                    {
                        panelMaxInc.Visible = false;
                        btnUpdatePaidIncome.Enabled = true;
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());

                    }
                    else if (cmbViewExpenses.SelectedIndex == 1)
                    {

                        //panel6.Visible = false;

                        panelMaxInc.Visible = true;
                        // showPanel = true;
                        btnUpdatePaidIncome.Enabled = false;
                        dt = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID);
                        if (dt.Rows.Count != 0)
                        {
                            ADGVIncome.DataSource = dt;
                            showMaxIncome(dt);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No records to display.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            ADGVIncome.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkDtFilter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDtFilter.Checked == false)
                {
                    panel6.Visible = false;
                }
                else if (chkDtFilter.Checked == true)
                {
                    panel6.Visible = true;
                    //dtpFromDate.Visible = true;
                    //dtpToDate.Visible = true;
                    formateLastTabDates();
                    if (cmbViewExpenses.SelectedIndex == 1)
                    {
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID, dtpFromDate.Value, dtpToDate.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formateLastTabDates()
        {
            try
            {
                WinForm.formatDateTimePicker(dtpFromDate);
                WinForm.formatDateTimePicker(dtpToDate);
                WinForm.setDate(dtpFromDate, dtpToDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value < dtpToDate.Value)
            {
                if (cmbViewExpenses.SelectedIndex != 1)
                {
                    ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                }


            }
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                dtpFromDate.Value = dtpToDate.Value;

            }

            //try
            //{
            //    //dtpToDate.MinDate = dtpFromDate.Value;
            //    if (cmbViewExpenses.SelectedIndex == 1)
            //    {
            //        ADGVIncome.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID, dtpFromDate.Value, dtpToDate.Value);
            //        showMaxIncome((DataTable)ADGVIncome.DataSource);
            //        btnUpdatePaidIncome.Enabled = false;

            //    }
            //    else
            //    {
            //        ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
            //        panelMaxInc.Visible = false;
            //        btnUpdatePaidIncome.Enabled = true;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        private void Formatdate()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpFromDate);
                UICommon.WinForm.formatDateTimePicker(dtpToDate);
                UICommon.WinForm.setDate(dtpFromDate, dtpToDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
               try
            {
                if (dtpToDate.Value > dtpFromDate.Value)
                {
                    if (cmbViewExpenses.SelectedIndex != 1)
                    {
                        ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    }


                }
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    dtpFromDate.Value = dtpToDate.Value;
                }

                //  if (validateDates())
                // {

                //   }
            }
            catch (Exception)
            {

                throw;
            }
            //try
            //{
            //    DataTable dt = new DataTable();

            //    if (chkDtFilter.Checked == true)
            //    {
            //        if (cmbViewExpenses.SelectedIndex == 1)
            //        {
                      // ADGVIncome.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID, dtpFromDate.Value, dtpToDate.Value);
                      //showMaxIncome((DataTable)ADGVIncome.DataSource);
                      //  btnUpdatePaidIncome.Enabled = false;

            //        }
            //        else
            //        {
            //            ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
            //            panelMaxInc.Visible = false;
            //            btnUpdatePaidIncome.Enabled = true;
            //        }
            //    }

            //    else
            //    {
            //        if (cmbViewExpenses.SelectedIndex == 0)
            //        {
            //            panelMaxInc.Visible = false;
            //            btnUpdatePaidIncome.Enabled = true;
            //            ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());

            //        }
            //        else if (cmbViewExpenses.SelectedIndex == 1)
            //        {

            //            //panel6.Visible = false;

            //            panelMaxInc.Visible = true;
            //            // showPanel = true;
            //            btnUpdatePaidIncome.Enabled = false;
            //            dt = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID);
            //            if (dt.Rows.Count != 0)
            //            {
            //                ADGVIncome.DataSource = dt;
            //                showMaxIncome(dt);
            //            }
            //            else
            //            {
            //                UICommon.WinForm.showStatus("No records to display.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            //                ADGVIncome.DataSource = null;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            //}
        }

        private void ADGVIncome_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
                foreach (DataGridViewRow adrow in ADGVIncome.Rows)
            try
            {
                formatADGVIncome();
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVIncome.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void formatADGVIncome()
        {
            try
            {
                if (ADGVIncome.Columns.Contains("Expense"))
                {
                    ADGVIncome.Columns["Expense"].HeaderText = "Income";
                   // ADGVIncome.Columns["PDEX_PAID_TO"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("PDEX_DATE"))
                {
                    ADGVIncome.Columns["PDEX_DATE"].HeaderText = "Date";
                    ADGVIncome.Columns["PDEX_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                    ADGVIncome.Columns["PDEX_DATE"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("PDEX_DESC"))
                {
                    ADGVIncome.Columns["PDEX_DESC"].HeaderText = "Description";
                    ADGVIncome.Columns["PDEX_DESC"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("PDEX_PAID_TO"))
                {
                    ADGVIncome.Columns["PDEX_PAID_TO"].HeaderText = "PaidFrom";
                    ADGVIncome.Columns["PDEX_PAID_TO"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("PDEX_BRANCH_ID"))
                {
                    ADGVIncome.Columns["PDEX_BRANCH_ID"].Visible = false;
                }
                if (ADGVIncome.Columns.Contains("PDEX_ID"))
                {
                    ADGVIncome.Columns["PDEX_ID"].Visible = false;
                }
                if (ADGVIncome.Columns.Contains("PDEX_ACCNT_ID"))
                {
                    ADGVIncome.Columns["PDEX_ACCNT_ID"].Visible = false;
                }
                if (ADGVIncome.Columns.Contains("ACT_NAME"))
                {
                    ADGVIncome.Columns["ACT_NAME"].HeaderText = "Account";
                    ADGVIncome.Columns["ACT_NAME"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("Branch"))
                {
                    ADGVIncome.Columns["Branch"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("Amount"))
                {
                    ADGVIncome.Columns["Amount"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("Category"))
                {
                    ADGVIncome.Columns["Category"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("PDEX_FILE_PATH"))
                {
                    ADGVIncome.Columns["PDEX_FILE_PATH"].HeaderText = "File Path";
                    ADGVIncome.Columns["PDEX_FILE_PATH"].Visible = false;
                }
                if (ADGVIncome.Columns.Contains("PDEX_PAYMENT_MODE"))
                {
                    ADGVIncome.Columns["PDEX_PAYMENT_MODE"].HeaderText = "Payment Mode";
                    ADGVIncome.Columns["PDEX_PAYMENT_MODE"].ReadOnly = true;
                }
               
                    ADGVIncome.Columns["ViewFile"].DisplayIndex = ADGVIncome.Columns.Count - 2;
                    ADGVIncome.Columns["Edit"].DisplayIndex = ADGVIncome.Columns.Count - 1;
                ADGVIncome.Columns["ViewFile"].Width = 100;
                ADGVIncome.Columns["ViewFile"].HeaderText = "Document";
                    ADGVIncome.Columns["Edit"].Width = 60;
                    if (ADGVIncome.Columns.Contains("PDEX_DESC"))
                    {
                        ADGVIncome.Columns["PDEX_DESC"].Width = 126;
                    ADGVIncome.Columns["PDEX_DESC"].ReadOnly = true;

                }

                if (cmbViewExpenses.SelectedIndex == 1)
                {
                    ADGVIncome.Columns["ViewFile"].Visible = false;
                    ADGVIncome.Columns["Edit"].Visible = false;
                }
                else
                {
                    ADGVIncome.Columns["ViewFile"].Visible = true;
                    ADGVIncome.Columns["Edit"].Visible = true;
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
         
        }
        private bool validateDates()
        {
            try
            {
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    WinForm.showStatus("Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    formateLastTabDates();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVIncome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ADGVIncome.Columns["ViewFile"].Index)
                    {
                        string filename = (ADGVIncome.Rows[e.RowIndex].Cells["PDEX_FILE_PATH"].Value).ToString();
                        if (filename != null && filename != "")
                        {
                            System.Diagnostics.Process.Start(filename);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No Attachment to View", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                    if (e.ColumnIndex == ADGVIncome.Columns["Edit"].Index)
                    {
                        FrmIncomeEntry objInc = (FrmIncomeEntry)UICommon.FormFactory.GetForm(Forms.FrmIncomeEntry, this, true);
                        if (ADGVIncome.Rows[e.RowIndex].Cells["PDEX_DESC"].Value.ToString() != "FEES")
                        {
                            objInc.setValuesForUpdate(ADGVIncome.Rows[e.RowIndex].Cells["PDEX_ID"].Value.ToString(), branchID);
                            objInc.ShowDialog();
                            UICommon.WinForm.setDate(dtpFromDate, dtpToDate);
                            ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(),dtpFromDate.Value,dtpToDate.Value);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("Income Entry of FEES cannot be Edited.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVIncome_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVIncome, e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    PrintingConfig objPrintngConfig = new PrintingConfig();
                    objPrintngConfig.ViewReport = true;
                    objPrintngConfig.SaveReport = true;
                    objPrintngConfig.exportFormat = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;

                    CommonReportData CommonRprtData = new CommonReportData();
                    CommonRprtData.FromDate = dtpFromDate.Value;
                    CommonRprtData.ToDate = dtpToDate.Value;
                    CommonRprtData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                    CommonRprtData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                    CommonRprtData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                   // CommonRprtData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                    CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "FIN_INCOME");

                    FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
                    frmRprtViewer.viewReport(CommonRprtData.ReportName, CommonRprtData, objPrintngConfig);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool validate()
        {
            try
            {

                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    UICommon.WinForm.showStatus("Please select date properly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
          
                if (cmbViewExpenses.SelectedIndex == 0)
                {
                    DataTable dt = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    ADGVIncome.DataSource = dt;
                    label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                    PdfParameters getParameter = new PdfParameters();

                    getParameter.att_View = "View:- " + cmbViewExpenses.SelectedItem.ToString();
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.count = "Total Income:-" + label1.Text;
                    getParameter.Title = "Income Report";
                    //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (ADGVIncome.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Income Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(ADGVIncome, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                        }
                    }
                }
                else if(cmbViewExpenses.SelectedIndex==1)
                {

                    DataTable dt = BLL.ExpenseHandler.getCategoryWiseCollection(false, branchID, dtpFromDate.Value, dtpToDate.Value);
                    ADGVIncome.DataSource = dt;
                    label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Total])", "")));
                    PdfParameters getParameter = new PdfParameters();

                    getParameter.att_View = "View:- " + cmbViewExpenses.SelectedItem.ToString();
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                    getParameter.count = "Total Income:-" + label1.Text;
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.Title = "Income Report";
                    //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (ADGVIncome.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Income Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(ADGVIncome, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                        }
                    }
                }
                else
                {
                    DataTable dt = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    ADGVIncome.DataSource = dt;
                    label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                    PdfParameters getParameter = new PdfParameters();

                    getParameter.att_View = "View:- " + cmbViewExpenses.SelectedItem;
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.count = "Total Income:-" + label1.Text;
                    getParameter.Title = "Income Report";
                    //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (ADGVIncome.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Income Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(ADGVIncome, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                        }
                    }
                }
               
            }
           

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }
    }
}
