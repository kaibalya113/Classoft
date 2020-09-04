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
    public partial class FrmExpenseReport : FrmParentForm
    {
        string branchID = Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Expences";
        public FrmExpenseReport()
        {
            InitializeComponent();
        }

        private void FrmExpenseReport_Load(object sender, EventArgs e)

        {
            try
            {
                AddColumn();
                Formatdate();
                if (validateDates())
                {
                    if (cmbViewExpenses.SelectedIndex != 1)
                    {
                        DataTable dt = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                        adgvExpsnses.DataSource = dt;
                        if(adgvExpsnses.Rows.Count>0)
                        {
                     label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No Records!!!!!", null, null); 
                        }

                      
                    }
                  
                }

                // UICommon.WinForm.setDate(dtpFromDate, dtpToDate);
                //DataTable dt  = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(),dtpFromDate.Value,dtpToDate.Value);
                //  adgvExpsnses.DataSource = dt;

                //  panelMaxExp.Visible = true;
                //  showMaxExpense(dt);
                AssignEvents();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void AssignEvents()
        {
            try
            {

              adgvExpsnses.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
               adgvExpsnses.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddColumn()
        {
            adgvExpsnses.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.download,
                Name = "ViewFile",
                HeaderText = "View"
            });
            adgvExpsnses.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.Edit,
                Name = "Edit",
                HeaderText = "Edit"
            });
        }

        private void adgvExpsnses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == adgvExpsnses.Columns["ViewFile"].Index)
                    {
                        string filename = (adgvExpsnses.Rows[e.RowIndex].Cells["PDEX_FILE_PATH"].Value).ToString();
                        if (filename != null && filename != "")
                        {
                            System.Diagnostics.Process.Start(filename);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No Attachment to View", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                    if (e.ColumnIndex == adgvExpsnses.Columns["Edit"].Index)
                    {
                        FrmExpenses objExp = (FrmExpenses)UICommon.FormFactory.GetForm(Forms.FrmExpenses, this, true);
                        objExp.setValuesForUpdate(adgvExpsnses.Rows[e.RowIndex].Cells["PDEX_ID"].Value.ToString(), branchID);
                        objExp.ShowDialog();
                        UICommon.WinForm.setDate(dtpFromDate, dtpToDate);
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void btnUpdatePaidExp_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = adgvExpsnses.DataSource as DataTable;
                Info.Expense objExpense = new Info.Expense();
                int returnCode = 0;
                foreach (DataRow expense in dt.Rows)
                {
                    if (expense[0] != null && expense[0].ToString() != "0")
                    {
                        objExpense.ExpenseId = Convert.ToInt32(expense["PDEX_ID"]);
                        objExpense.PaidTo = expense["PDEX_PAID_TO"].ToString();
                        objExpense.Amount = Convert.ToDecimal(expense["Amount"].ToString());
                        objExpense.Date = Convert.ToDateTime(expense["PDEX_DATE"]);
                        objExpense.Description = Convert.ToString(expense["PDEX_DESC"]);
                        objExpense.Account.Id = Convert.ToInt32(expense["PDEX_ACCNT_ID"]);
                        objExpense.BranchID = Convert.ToInt32(expense["PDEX_BRANCH_ID"]);
                        // returnCode = BLL.ExpenseHandler.UpdatePaidExpenseOrIncome(objExpense);
                    }
                }
                if (returnCode == 1)
                {
                    UICommon.WinForm.showStatus("Expense updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                if (!chkShowAllBranch.Checked)
                {
                    adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString());
                }
                else
                {
                    adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, "%");
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            try
            {
                Common.ImportExport.ImportToExcel(adgvExpsnses, null);
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void chkShowAllBranch_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (chkShowAllBranch.Checked == true)
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
                        panelMaxExp.Visible = false;
                        btnUpdatePaidExp.Enabled = true;
                        if (!chkShowAllBranch.Checked)
                        {
                            adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString());
                        }
                        else
                        {
                            adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, "%");

                        }
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        panelMaxExp.Visible = true;

                        btnUpdatePaidExp.Enabled = false;
                        if (!chkShowAllBranch.Checked)
                        {
                            dt = BLL.ExpenseHandler.getCategoryWiseCollection(true, branchID);
                        }
                        else
                        {
                            dt = BLL.ExpenseHandler.getCategoryWiseCollection(true, "%");
                        }
                        if (dt.Rows.Count != 0)
                        {
                            adgvExpsnses.DataSource = dt;
                            showMaxExpense(dt);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No records to display.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            adgvExpsnses.DataSource = null;
                        }

                    }
                }
                else
                {
                    adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString());
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void showMaxExpense(DataTable dt)
        {
            try
            {

                if (adgvExpsnses.Rows.Count != 0)
                {
                    panelMaxExp.Visible = true;

                }
                else
                {
                    panelMaxExp.Visible = false;
                }

                DataView expenseView = new DataView(dt);
                if (expenseView.Table.Rows.Count > 0)
                {
                    Decimal maxAmount = adgvExpsnses.Rows.Cast<DataGridViewRow>()
                                .Max(t => Convert.ToDecimal(t.Cells["Total"].Value));

                    string name = ((from DataRow dr in dt.Rows where Convert.ToDecimal(dr["Total"]) == maxAmount select (string)dr[0]).FirstOrDefault());


                    lblNameAndAmount.Text = name + ":  " + maxAmount.ToString();
                    Decimal totalAmount = adgvExpsnses.Rows.Cast<DataGridViewRow>()
                                .Sum(t => Convert.ToDecimal(t.Cells["Total"].Value));

                    //string tot = ((from DataRow dr in dt.Rows where Convert.ToDecimal(dr["Total"]) == maxAmount select (string)dr[0]).FirstOrDefault());
                    label1.Text = totalAmount.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void showExpense(DataTable dt)
        {
            try
            {

                if (adgvExpsnses.Rows.Count != 0)
                {
                    panelMaxExp.Visible = true;

                }
                else
                {
                    panelMaxExp.Visible = false;
                }

                DataView expenseView = new DataView(dt);
                if (expenseView.Table.Rows.Count > 0)
                {
                    
                    Decimal totalAmount = adgvExpsnses.Rows.Cast<DataGridViewRow>()
                                .Sum(t => Convert.ToDecimal(t.Cells["Amount"].Value));

                    //string tot = ((from DataRow dr in dt.Rows where Convert.ToDecimal(dr["Total"]) == maxAmount select (string)dr[0]).FirstOrDefault());
                    label1.Text = totalAmount.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void cmbViewExpenses_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                if (chkDtFilter.Checked == true)
                {
                    if (cmbViewExpenses.SelectedIndex == 1)
                    {
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(true, branchID, dtpFromDate.Value, dtpToDate.Value);
                        showMaxExpense((DataTable)adgvExpsnses.DataSource);

                     //  label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                        btnUpdatePaidExp.Enabled = false;
                    }
                    else
                    {
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                        showExpense((DataTable)adgvExpsnses.DataSource);
                        btnUpdatePaidExp.Enabled = true;
                     //  label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                        panelMaxExp.Visible = false;
                        // showMaxExpense((DataTable)adgvExpsnses.DataSource);
                    }
                }

                else
                {
                    if (cmbViewExpenses.SelectedIndex == 0)
                    {
                        panelMaxExp.Visible = false;
                        btnUpdatePaidExp.Enabled = true;
                        if (!chkShowAllBranch.Checked)
                        {
                            adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString());
                        }
                        else
                        {
                            adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, "%");

                        }
                    }
                    else if (cmbViewExpenses.SelectedIndex == 1)
                    {


                        panelMaxExp.Visible = true;

                        btnUpdatePaidExp.Enabled = false;
                        if (!chkShowAllBranch.Checked)
                        {
                            dt = BLL.ExpenseHandler.getCategoryWiseCollection(true, branchID);
                        }
                        else
                        {
                            dt = BLL.ExpenseHandler.getCategoryWiseCollection(true, "%");
                        }
                        if (dt.Rows.Count != 0)
                        {
                            adgvExpsnses.DataSource = dt;
                            showMaxExpense(dt);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No records to display.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            adgvExpsnses.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkDtFilter_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {

                if (chkDtFilter.Checked == false)
                {
                    panel3.Visible = false;
                }
                else if (chkDtFilter.Checked == true)
                {
                    panel3.Visible = true;

                    formateLastTabDates();
                    if (cmbViewExpenses.SelectedIndex == 1)
                    {
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(true, branchID, dtpFromDate.Value, dtpToDate.Value);
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

        private void adgvExpsnses_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatadgvExpenses();
                foreach (DataGridViewRow adrow in adgvExpsnses.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                adgvExpsnses.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formatadgvExpenses()
        {
            try
            {
                if (adgvExpsnses.Columns.Contains("Category"))
                {
                    adgvExpsnses.Columns["Category"].ReadOnly = true;
                }

                if (adgvExpsnses.Columns.Contains("Amount"))
                {
                    adgvExpsnses.Columns["Amount"].ReadOnly = true;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_DATE"))
                {
                    adgvExpsnses.Columns["PDEX_DATE"].HeaderText = "Date";
                    adgvExpsnses.Columns["PDEX_PAYMENT_MODE"].HeaderText = "Payment Mode";
                    adgvExpsnses.Columns["PDEX_PAYMENT_MODE"].ReadOnly = true;
                    adgvExpsnses.Columns["PDEX_FILE_PATH"].HeaderText = "File Path";
                    adgvExpsnses.Columns["PDEX_FILE_PATH"].Visible = false;
                    adgvExpsnses.Columns["PDEX_DATE"].ReadOnly = true;
                    adgvExpsnses.Columns["PDEX_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_DESC"))
                {
                    adgvExpsnses.Columns["PDEX_DESC"].HeaderText = "Description";
                    adgvExpsnses.Columns["PDEX_DESC"].ReadOnly = true;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_PAID_TO"))
                {
                    adgvExpsnses.Columns["PDEX_PAID_TO"].HeaderText = "PaidTo";
                    adgvExpsnses.Columns["PDEX_PAID_TO"].ReadOnly = true;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_BRANCH_ID"))
                {
                    adgvExpsnses.Columns["PDEX_BRANCH_ID"].Visible = false;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_ID"))
                {
                    adgvExpsnses.Columns["PDEX_ID"].Visible = false;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_ACCNT_ID"))
                {
                    adgvExpsnses.Columns["PDEX_ACCNT_ID"].Visible = false;
                }
                if (adgvExpsnses.Columns.Contains("ACT_NAME"))
                {
                    adgvExpsnses.Columns["ACT_NAME"].HeaderText = "Account";
                    adgvExpsnses.Columns["ACT_NAME"].ReadOnly = true;
                }
                if (adgvExpsnses.Columns.Contains("Branch"))
                {
                    adgvExpsnses.Columns["Branch"].ReadOnly = true;
                }
                if (adgvExpsnses.Columns.Contains("Category"))
                {
                    adgvExpsnses.Columns["Category"].ReadOnly = true;
                }

                adgvExpsnses.Columns["ViewFile"].DisplayIndex = adgvExpsnses.Columns.Count - 2;
                adgvExpsnses.Columns["Edit"].DisplayIndex = adgvExpsnses.Columns.Count - 1;
                adgvExpsnses.Columns["ViewFile"].Width = 100;
                adgvExpsnses.Columns["ViewFile"].HeaderText = "Document";
                adgvExpsnses.Columns["Edit"].Width = 60;
                if (adgvExpsnses.Columns.Contains("PDEX_DESC"))
                {
                    adgvExpsnses.Columns["PDEX_DESC"].Width = 126;
                    adgvExpsnses.Columns["PDEX_DESC"].ReadOnly = true;
                }

                if (cmbViewExpenses.SelectedIndex == 1)
                {
                    adgvExpsnses.Columns["ViewFile"].Visible = false;
                    adgvExpsnses.Columns["Edit"].Visible = false;
                }
                else
                {
                    adgvExpsnses.Columns["ViewFile"].Visible = true;
                    adgvExpsnses.Columns["Edit"].Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Value < dtpToDate.Value)
                {
                    if (cmbViewExpenses.SelectedIndex != 1)
                    {
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    }


                }
                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    dtpFromDate.Value = dtpToDate.Value;

                }



                //  if (validateDates())
                //   {

                // }
            }

            catch (Exception)
            {

                throw;
            }
        }
        //try
        //{
        //    dtpToDate.MinDate = dtpFromDate.Value;
        //    if (cmbViewExpenses.SelectedIndex == 1)
        //    {
        //        adgvExpsnses.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(true, branchID, dtpFromDate.Value, dtpToDate.Value);
        //        showMaxExpense((DataTable)adgvExpsnses.DataSource);
        //        btnUpdatePaidExp.Enabled = false;
        //    }
        //    else
        //    {
        //        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
        //        btnUpdatePaidExp.Enabled = true;
        //        panelMaxExp.Visible = false;
        //    }

        //}
        //catch (Exception)
        //{

        //    throw;
        //}

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
        private void dtpFromDate_CloseUp_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (validateDates())
            //    {
            //        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        private bool validateDates()
        {
            try
            {
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    dtpFromDate = dtpToDate; ;
                    // WinForm.showStatus("Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    // formateLastTabDates();
                    return true;

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

        private void adgvExpsnses_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(adgvExpsnses, e);
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
                    CommonRprtData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                    CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "FIN_EXPENSE");

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

                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
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
        public bool validateCategory()
        {
            try
            {

                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
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
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpToDate.Value > dtpFromDate.Value)
                {
                    if (cmbViewExpenses.SelectedIndex != 1)
                    {
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
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
        }
        //added by ashvini on 30-03-2019
        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbViewExpenses.SelectedIndex == 0)
                {
                    DataTable dt = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    adgvExpsnses.DataSource = dt;
                    label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                    PdfParameters getParameter = new PdfParameters();

                    getParameter.att_View = "View:- " + cmbViewExpenses.SelectedItem.ToString();
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.count = "Total Expense:-" + label1.Text;
                    getParameter.Title = "Expense Report";
                    //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (adgvExpsnses.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Expense Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(adgvExpsnses, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                        }
                    }
                }
                else if (cmbViewExpenses.SelectedIndex == 1)
                {
                  DataTable dt = BLL.ExpenseHandler.getCategoryWiseCollection(true, branchID, dtpFromDate.Value, dtpToDate.Value);
                    adgvExpsnses.DataSource = dt;
                    label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Total])", "")));
                    PdfParameters getParameter = new PdfParameters();

                    getParameter.att_View = "View:- " + cmbViewExpenses.SelectedItem.ToString();
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.count = "Total Expense:-" + label1.Text;
                    getParameter.Title = "Expense Report";
                    //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (adgvExpsnses.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Expense Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(adgvExpsnses, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                        }
                    }
                }
                else
                {
                    DataTable dt = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                    adgvExpsnses.DataSource = dt;
                    label1.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Amount])", "")));
                    PdfParameters getParameter = new PdfParameters();

                    getParameter.att_View = "View:- " + cmbViewExpenses.SelectedItem;
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.count = "Total Expense:-" + label1.Text;
                    getParameter.Title = "Expense Report";
                    //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (adgvExpsnses.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Expense Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(adgvExpsnses, pathTosave, getParameter);
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
        //end by ashvini on 30-03-2019
    }
    }


