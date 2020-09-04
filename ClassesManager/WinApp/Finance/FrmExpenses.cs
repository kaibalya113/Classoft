using ClassManager.WinApp.UICommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClassManager.Info;

namespace ClassManager.WinApp
{
    public partial class FrmExpenses : FrmParentForm
    {

        List<Info.Account> lstAccount;
        Info.RolePrivilege formPrevileges;
        string branchID = Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Expences";
        int PdexId = 0;
        List<Info.Expense> lstExpense = new List<Info.Expense>();

        public string oldExpenseValue { get; private set; }


        /// <summary>
        /// Initialize components
        /// </summary>
        public FrmExpenses()
        {
            InitializeComponent();
        }


        private void clearForm()
        {
            try
            {
                txtDescription.Text = "";
                txtPaidTo.Text = "";
                txtAmount.Text = "";
                dateDt.Value = DateTime.Now.Date;
                txtPath.Text = "";
                cmbPaymentMode.SelectedItem = "";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool ValidateExpenses()
        {
            if (tabExpense.SelectedIndex == 0)
            {
                if (comboIndirectExpenses.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Select Expense Head", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    comboIndirectExpenses.Focus();
                    return false;
                }
                else if (txtPaidTo.Text.Length == 0 || txtPaidTo.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Paid To for the Expense", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPaidTo.Focus();
                    return false;
                }
                else if (txtAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Amount for the Expense", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtAmount.Focus();
                    return false;
                }
                else if (cmbPaymentMode.SelectedItem == null)
                {
                    UICommon.WinForm.showStatus("Please Select Payment Mode", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbPaymentMode.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (tabExpense.SelectedIndex == 1)
            {

                if (string.IsNullOrWhiteSpace(txtExpense.Text) && txtExpense.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Expense", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtExpense.Focus();
                    return false;
                }

                return true;

            }
            return true;


        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            try
            {

                if (this.IsMdiChild != true)
                {
                    tabExpense.SelectedIndex = 0;
                   // btnUpdt.Visible = true;
                    ApplyPrevileges();
                    cmbAccounts.Enabled = true;

                }
                else
                {
                    comboIndirectExpenses.DisplayMember = "expName";
                    comboIndirectExpenses.ValueMember = "expID";
                    tabExpense.SelectedIndex = 0;

                    //formatting datetimepicker
                    UICommon.WinForm.formatDateTimePicker(dateDt);
                    reloadExpense();

                    //Hemlata(It will redirect the user to create screen if the expenses are not created)
                    if (tabExpense.SelectedIndex == 0)
                    {
                        if (comboIndirectExpenses.Items.Count == 0)
                        {
                            tabExpense.SelectedIndex = 1;
                            lblMsg.Visible = true;
                        }
                        else
                        {
                            tabExpense.SelectedIndex = 0;
                            lblMsg.Visible = false;
                        }

                        AssignEvent();
                        ApplyPrevileges();

                        tabExpense.TabPages.Remove(tabExpenseView);
                        cmbAccounts.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }

        }

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
                        chkShowAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdatePaidExp.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        cmdCreateExpence.Visible = false;
                        cmdAddExpense.Visible = false;
                        tabPCreateExpense.Hide();
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

        /// <summary>
        /// Reloads the expenses
        /// </summary>
        public void reloadExpense()
        {

            try
            {
                lstExpense = BLL.ExpenseHandler.loadExpensesDetails(true, branchID.ToString());
                getAccounts(lstAccount);
                comboIndirectExpenses.DataSource = lstExpense;
                ADGVExpDetails.DataSource = WinForm.ToDataTable(lstExpense);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AssignEvent()
        {
            txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtPaidTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);

            //Assigning Events.Mohan(28-July-2017).
            WinForm.AssignFilterEvent(adgvExpsnses);
            WinForm.AssignFilterEvent(ADGVExpDetails);
        }

        private void tabExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabExpense.SelectedIndex == 2)
            {
                adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString());
            }
            else if (tabExpense.SelectedIndex == 1)
            {
                reloadExpense();
            }
        }


        private void ADGVExpDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVExpDetails();
                foreach (DataGridViewRow adrow in ADGVExpDetails.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVExpDetails.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void formatADGVExpDetails()
        {
            try
            {
                //Hiding Columns
                ADGVExpDetails.Columns["ExpenseId"].Visible = false;
                ADGVExpDetails.Columns["IsDirectExp"].Visible = false;
                ADGVExpDetails.Columns["IsExpense"].Visible = false;

                ADGVExpDetails.Columns["PaidTo"].Visible = false;
                ADGVExpDetails.Columns["Amount"].Visible = false;
                ADGVExpDetails.Columns["Description"].Visible = false;
                ADGVExpDetails.Columns["Date"].Visible = false;
                ADGVExpDetails.Columns["Account"].Visible = false;
                ADGVExpDetails.Columns["Trasaction"].Visible = false;
                ADGVExpDetails.Columns["BranchID"].Visible = false;
                ADGVExpDetails.Columns["FilePath"].Visible = false;
                ADGVExpDetails.Columns["PayMode"].Visible = false;
                //Ordering positions of columns
                ADGVExpDetails.Columns["ExpenseName"].DisplayIndex = 2;
                ADGVExpDetails.Columns["Branch"].ReadOnly = true;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVExpDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Info.Expense objEx = new Info.Expense();
                string description;
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ADGVExpDetails.Columns["btnDelete"].Index)
                    {
                        if (formPrevileges.Delete == false)
                        {
                            UICommon.WinForm.showStatus("You don't have permission to delete the expense, Please contact admin", "Delete Expense", this);
                            return;
                        }

                        foreach (DataGridViewRow income in ADGVExpDetails.Rows)
                        {
                            if (income.Cells[0].Selected)
                            {
                                description = (income.Cells["ExpenseName"].Value).ToString();
                                objEx = lstExpense.Find(ex => ex.ExpenseName == description);

                                int returnCode = BLL.ExpenseHandler.deleteExpendeMaster(objEx.ExpenseId, objEx.IsExpense, objEx.ExpenseName, Convert.ToInt32(branchID));
                                if (returnCode == 1)
                                {
                                    UICommon.WinForm.showStatus("Expense deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                                else
                                {
                                    UICommon.WinForm.showStatus("Expense cannot be deleted as " + objEx.ExpenseName + " is being used", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }

                        }
                    }

                    else if (e.ColumnIndex == ADGVExpDetails.Columns["btnUpdate"].Index)
                    {
                        if (formPrevileges.Modify == false)
                        {
                            UICommon.WinForm.showStatus("You don't have permission to update the expense, Please contact admin", "Update Expense", this);
                            return;
                        }

                        foreach (DataGridViewRow income in ADGVExpDetails.Rows)
                        {
                            if (income.Cells[1].Selected)
                            {
                                description = (income.Cells["ExpenseName"].Value).ToString();
                                objEx = lstExpense.Find(ex => ex.ExpenseName == description);

                                int returnCode = BLL.ExpenseHandler.UpdateExpenseMaster(objEx.ExpenseId, objEx.IsExpense, objEx.ExpenseName, Convert.ToInt32(branchID));
                                if (returnCode == 1)
                                {
                                    UICommon.WinForm.showStatus("Expense updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                                else
                                {
                                    UICommon.WinForm.showStatus("Please use some different name to update details", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }
                        }
                    }
                    reloadExpense();
                    if (ADGVExpDetails.Rows.Count == 0)
                    {
                        lblMsg.Visible = true;
                    }
                    else
                    {
                        lblMsg.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void adgvExpsnses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void adgvExpsnses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
                if (adgvExpsnses.Columns.Contains("PDEX_DATE"))
                {
                    adgvExpsnses.Columns["PDEX_DATE"].HeaderText = "Date";
                    adgvExpsnses.Columns["PDEX_DATE"].ReadOnly = true;
                    adgvExpsnses.Columns["PDEX_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                }
                if (adgvExpsnses.Columns.Contains("PDEX_DESC"))
                {
                    adgvExpsnses.Columns["PDEX_DESC"].HeaderText = "Description";
                }
                if (adgvExpsnses.Columns.Contains("PDEX_PAID_TO"))
                {
                    adgvExpsnses.Columns["PDEX_PAID_TO"].HeaderText = "PaidTo";
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void loadValuesForUpdate(Faculty objFaculty)
        {
            try
            {
                if (objFaculty != null)
                {
                    txtPaidTo.Text = objFaculty.Name;
                   // comboIndirectExpenses.Name = "salary";

                }
                reloadExpense();
                comboIndirectExpenses.SelectedIndex = 1;
                // isFormClear = true;
                //  return true;
            }
            catch(Exception ex)
            {

            }
        }

        private void adgvExpsnses_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (adgvExpsnses.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Common.Events.numOnly);
                }
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
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbViewExpenses_SelectedIndexChanged(object sender, EventArgs e)
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
                        btnUpdatePaidExp.Enabled = false;
                    }
                    else
                    {
                        adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                        btnUpdatePaidExp.Enabled = true;
                        panelMaxExp.Visible = false;
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

        private void chkShowAllBranch_CheckedChanged(object sender, EventArgs e)
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
        private void dtpToDate_CloseUp(object sender, EventArgs e)
        {
            if (validateDates())
            {
                adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
            }
        }

        /// <summary>
        /// It will filter the accounts
        /// </summary>
        /// <param name="lstAccount"></param>
        public void getAccounts(List<Info.Account> lstAccount)
        {
            try
            {
                //lstAccount = BLL.AccountHandller.getAccounts(branchID.ToString());
                //cmbAccounts.DataSource = lstAccount;
                //if (cmbAccounts.Items.Count > 0)
                //{
                //    cmbAccounts.SelectedIndex = 0;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkDtFilter_CheckedChanged(object sender, EventArgs e)
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
        private void lnkAddAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {


                FrmCreateAccount objCreateAccount = new FrmCreateAccount();
                UICommon.WinForm.openForm(objCreateAccount, cmbAccounts);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
            if (validateDates())
            {
                adgvExpsnses.DataSource = BLL.ExpenseHandler.getPaidExpense(false, true, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
            }
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

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpToDate.MinDate = dtpFromDate.Value;
        }

        private void ADGVExpDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVExpDetails, e);
        }

        private void adgvExpsnses_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(adgvExpsnses, e);
        }

        private void cmdAddExpense_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateExpenses())
                {
                    if (this.ValidateChildren(ValidationConstraints.Visible))
                    {
                        Info.Expense expense = new Info.Expense();
                        expense.ExpenseId = (comboIndirectExpenses.SelectedItem as Info.Expense).ExpenseId;
                        expense.Description = txtDescription.Text;
                        expense.PaidTo = txtPaidTo.Text;
                        expense.Amount = Convert.ToDecimal(txtAmount.Text);
                        expense.Date = dateDt.Value;
                        expense.Account.Id = (cmbAccounts.SelectedItem as Info.Account).Id;
                        expense.IsExpense = true;
                        expense.FilePath = txtPath.Text.ToString();
                        expense.PayMode = cmbPaymentMode.SelectedItem.ToString();
                        string filePath = expense.FilePath;
                        string lastFolder = Path.GetFileName(filePath);
                        string fileLocCopy = AppDomain.CurrentDomain.BaseDirectory + "ExpenseDocuments\\" + lastFolder;
                        if (File.Exists(expense.FilePath))
                        {
                            if (File.Exists(expense.FilePath))
                            {
                                // If file already exists in destination, delete it.
                                if (File.Exists(fileLocCopy))
                                    File.Delete(fileLocCopy);
                                File.Copy(expense.FilePath, fileLocCopy);
                            }
                        }

                        if (BLL.ExpenseHandler.insertExpense(expense, Convert.ToInt32(branchID)))
                        {
                            UICommon.WinForm.showStatus("Expense added successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            clearForm();
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("Error adding expense please try later..Failure", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showStatus("Following error occured\n\n" + ex.Message + "\n\nPlease contact System Admin if problem persists.Error has Occured", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void cmdCreateExpence_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateExpenses())
                {

                    if (BLL.ExpenseHandler.createNewExpense(txtExpense.Text, Convert.ToInt32(branchID), true))
                    {
                        UICommon.WinForm.showStatus("Expense created successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        reloadExpense();
                        lblMsg.Visible = false;
                    }
                    txtExpense.Text = "";
                }
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Expense \"" + txtExpense.Text + "\" already exists", sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showStatus("Following error occured\n\n" + ex.Message + "\n\nPlease contact System Admin if problem persists.Error has Occured", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnUpdatePaidExp_Click(object sender, EventArgs e)
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
                        returnCode = BLL.ExpenseHandler.UpdatePaidExpenseOrIncome(objExpense, PdexId, Convert.ToInt32(branchID));
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

        private void btnSave_Click(object sender, EventArgs e)
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


        private void ADGVExpDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void tabCreateExpenseHead_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog csvFilePath = new OpenFileDialog();
                csvFilePath.InitialDirectory = Application.ExecutablePath.ToString();

                csvFilePath.RestoreDirectory = true;
                if (csvFilePath.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = csvFilePath.FileName.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void dtpFromDate_ValueChanged_1(object sender, EventArgs e)
        {

        }

        public void setValuesForUpdate(string Id, string branch)
        {
            try
            {

                DataTable record = BLL.ExpenseHandler.getExpense(Id, branch, true);
                reloadExpense();
                getAccounts(lstAccount);
                comboIndirectExpenses.Text = record.Rows[0].ItemArray[1].ToString();

                foreach(object obj in cmbAccounts.Items)
                {
                    if((obj as Info.Account).Id.ToString().Equals(record.Rows[0]["PDEX_ACCNT_ID"].ToString())){
                        cmbAccounts.SelectedItem = obj;
                        break;
                    }
                    
                }

                txtPaidTo.Text = record.Rows[0]["PDEX_PAID_TO"].ToString();
                cmbPaymentMode.Text = record.Rows[0]["PDEX_PAYMENT_MODE"].ToString();
                txtAmount.Text = record.Rows[0]["Amount"].ToString();
                txtDescription.Text = record.Rows[0]["PDEX_DESC"].ToString();
                txtPath.Text = record.Rows[0]["PDEX_FILE_PATH"].ToString();
                dateDt.Value = Convert.ToDateTime(record.Rows[0]["PDEX_DATE"]);
                PdexId = Convert.ToInt32(Id);
                oldExpenseValue = record.Rows[0]["Amount"].ToString();
                cmbAccounts.Enabled = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            try
            {
                int returnCode = 0;
                if (ValidateExpenses())
                {
                    if (this.ValidateChildren(ValidationConstraints.Visible))
                    {
                        Info.Expense expense = new Info.Expense();
                        expense.ExpenseId = (comboIndirectExpenses.SelectedItem as Info.Expense).ExpenseId;
                        expense.Description = txtDescription.Text;
                   
                        expense.PaidTo = txtPaidTo.Text;
                        expense.Amount = Convert.ToDecimal(txtAmount.Text);
                        expense.Date = dateDt.Value;
                        expense.Account.Id = (cmbAccounts.SelectedItem as Info.Account).Id;
                        expense.IsExpense = true;
                        expense.FilePath = txtPath.Text.ToString();
                        expense.PayMode = cmbPaymentMode.SelectedItem.ToString();
                        string filePath = expense.FilePath;

                        string lastFolder = Path.GetFileName(filePath);
                        string fileLocCopy = AppDomain.CurrentDomain.BaseDirectory + "ExpenseDocuments\\" + lastFolder;
                        if (File.Exists(expense.FilePath))
                        {

                            // If file already exists in destination, delete it.
                            if (File.Exists(fileLocCopy))
                                File.Delete(fileLocCopy);
                            File.Copy(expense.FilePath, fileLocCopy);

                        }
                        returnCode = BLL.ExpenseHandler.UpdatePaidExpenseOrIncome(expense, PdexId, Convert.ToInt32(branchID));
                        BLL.UserHandler.createActivity(0,DateTime.Now.Date, "Update in Expense", Program.LoggedInUser.UserId.ToString(), oldExpenseValue, expense.Amount.ToString(), Program.LoggedInUser.UserId.ToString(), branchID.ToString());
                        if (returnCode == 1)
                        {
                            UICommon.WinForm.showStatus("Expense updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            clearForm();
                        }

                        else
                        {

                            UICommon.WinForm.showStatus("Error updating expense please try later..Failure", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        this.Close();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAccounts.Items.Clear();
            //ADDED BY ASHVINI 4-1-2019
            //FOR SELECTING ANY CASH ITEM WITH CASH
            if (cmbPaymentMode.SelectedItem.ToString().Contains("CASH"))
            {       //END BY ASHVINI
                lstAccount = BLL.AccountHandller.getAccounts(branchID.ToString());
                //List<Info.Account> creditAccounts = lstAccount.Where(u => u.AccountType == "CR").ToList();
                //cmbAccounts.DataSource = lstAccount;
                foreach (var str in lstAccount)
                {
                    if (str.AccountName.ToLower().Contains ("cash"))
                    {
                        cmbAccounts.Items.Add(str);
                      
                    }
                  
                }
              //  cmbAccounts.SelectedIndex = 0;
            }
            else
            {
                lstAccount = BLL.AccountHandller.getAccounts(branchID.ToString());
                //chnged code 25-12
                foreach (var str in lstAccount)
                {    //ADDED BY ASHVINI 4-1-2019
                     //FOR SELECTING ANY CASH ITEM WITH CASH then select any text contains cash
                    if (str.AccountName.ToLower().Contains("cash"))
                    {
                        cmbAccounts.Items.Remove(str);
                    }
                    else
                    { //end by ashvini
                        cmbAccounts.Items.Add(str);

                    }

                }
               
            }
 if (cmbAccounts.Items.Count > 0)
                {
                    cmbAccounts.SelectedIndex = 0;
                }

        }

        private void comboIndirectExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    

