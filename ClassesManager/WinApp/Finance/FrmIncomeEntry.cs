using ClassManager.Info;
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
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmIncomeEntry : FrmParentForm
    {

        RolePrivilege formPrevileges;
        string sCaption = "IncomeEntry";

        List<Info.Account> lstAccount;
        string branchID = Program.LoggedInUser.BranchId.ToString();
        List<Info.Expense> lstIncm = new List<Info.Expense>();
        private bool showPanel;
        int PdexId;

        public string oldExpenseValue { get; private set; }

        public FrmIncomeEntry()
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
                cmbPaymentMode.SelectedText = "";
                txtPath.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool validateIncome()
        {
            if (tabIncome.SelectedIndex == 0)
            {
                if (comboIndirectExpenses.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Select Income Head", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    comboIndirectExpenses.Focus();
                    return false;
                }
                else if (txtPaidTo.Text.Length == 0 || txtPaidTo.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Received From for Income", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPaidTo.Focus();
                    return false;
                }
                else if (txtAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Amount for the Income", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
            else if (tabIncome.SelectedIndex == 1)
            {
                if (txtIncome.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Value for Income", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtIncome.Focus();
                    return false;
                }

                return true;
            }
            return true;
        }

        private void IncomeEntry_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsMdiChild != true)
                {
                    tabIncome.SelectedIndex = 0;
                    btnUpdt.Visible = true;
                    ApplyPrevileges();
                    cmbAccounts.Enabled = true;
                }
                else
                {
                    comboIndirectExpenses.DisplayMember = "expName";
                    comboIndirectExpenses.ValueMember = "expID";
                    tabIncome.SelectedIndex = 0;

                    //formatting datetimepicker
                    UICommon.WinForm.formatDateTimePicker(dateDt);
                    reloadIncome();

                    //Hemlata( if the Income entry is not there than it will redirect user to the create screen)
                    if (tabIncome.SelectedIndex == 0)
                    {
                        if (comboIndirectExpenses.Items.Count == 0)

                        {
                            tabIncome.SelectedIndex = 1;
                            lblMsgIncm.Visible = true;
                        }

                        else
                        {
                            tabIncome.SelectedIndex = 0;
                            lblMsgIncm.Visible = false;
                        }
                    }

                    AssignEvents();
                    WinForm.AssignFilterEvent(ADGVIncome);
                    WinForm.AssignFilterEvent(ADGVIncomeDetails);
                    ApplyPrevileges();
                    tabIncome.TabPages.Remove(tabPage6);
                    cmbAccounts.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
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
                        chkShowAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdatePaidIncome.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        cmdAddExpense.Visible = false;
                        cmdCreateExpence.Visible = false;
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
        /// This code is to filter the Accounts
        /// </summary>
        /// <param name="lstAccount"></param>
        public void getAccounts(List<Info.Account> lstAccount)
        {
            try
            {
                //lstAccount = BLL.AccountHandller.getAccounts(branchID.ToString());
                ////List<Info.Account> creditAccounts = lstAccount.Where(u => u.AccountType == "CR").ToList();
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

        private void AssignEvents()
        {
            txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }

       
        public void reloadIncome()
        {
            
            lstIncm = BLL.ExpenseHandler.loadExpensesDetails(false,branchID.ToString());
            comboIndirectExpenses.DataSource = lstIncm;
        //    ADGVIncomeDetails.DataSource = null;
            ADGVIncomeDetails.DataSource = WinForm.ToDataTable(lstIncm);
            getAccounts(lstAccount);
        }

        private bool ValidateIncome()
        {
            if (tabIncome.SelectedIndex == 0)
            {
                if (comboIndirectExpenses.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Select income Head", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    comboIndirectExpenses.Focus();
                    return false;
                }
                else if (txtPaidTo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Paid To for the income", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPaidTo.Focus();
                    return false;
                }
                else if (txtAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Amount for the income", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtAmount.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (tabIncome.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(txtIncome.Text)  && txtIncome.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid income", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtIncome.Focus();
                    return false;
                }

                return true;

            }
            return true;
        }

        private void tabIncome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabIncome.SelectedIndex == 2)
            {

                ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());

            }
            else if (tabIncome.SelectedIndex == 1)
            {
                reloadIncome();
              
            }
        }
      

        private void ADGVIncomeDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Info.Expense objIncm = new Info.Expense();
                string description;
                if (e.RowIndex != -1)
                { 
                    if (e.ColumnIndex == ADGVIncomeDetails.Columns["btnDelete"].Index)
                    {

                        if (formPrevileges.Delete == false)
                        {
                            UICommon.WinForm.showStatus("You don't have permission to Delete the Income, Please contact admin", sCaption, this);
                            return;
                        }

                        foreach (DataGridViewRow income in ADGVIncomeDetails.Rows)
                        {
                            if (income.Cells[0].Selected)
                            {
                                description = (income.Cells["ExpenseName"].Value).ToString();
                                objIncm = lstIncm.Find(ex => ex.ExpenseName == description);

                                int returnCode = BLL.ExpenseHandler.deleteExpendeMaster(objIncm.ExpenseId, objIncm.IsExpense, objIncm.ExpenseName, Convert.ToInt32(branchID));
                                if (returnCode == 1)
                                {
                                    UICommon.WinForm.showStatus("Income deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);  
                                }
                                else
                                {
                                    UICommon.WinForm.showStatus("Expense cannot be deleted as " + objIncm.ExpenseName + " is being used", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }
                        }
                    }

                    else if (e.ColumnIndex == ADGVIncomeDetails.Columns["btnUpdate"].Index)
                    {
                        if (formPrevileges.Delete == false)
                        {
                            UICommon.WinForm.showStatus("You don't have permission to Update the Income, Please contact admin", sCaption, this);
                            return;
                        }

                        foreach (DataGridViewRow income in ADGVIncomeDetails.Rows)
                        {
                            if (income.Cells[1].Selected != null && income.Cells[1].Selected)
                            {
                                description = (income.Cells["ExpenseName"].Value).ToString();
                                objIncm = lstIncm.Find(ex => ex.ExpenseName == description);

                                int returnCode = BLL.ExpenseHandler.UpdateExpenseMaster(objIncm.ExpenseId, objIncm.IsExpense, objIncm.ExpenseName, Program.LoggedInUser.BranchId);
                                if (returnCode == 1)
                                {
                                    UICommon.WinForm.showStatus("Income updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                                else
                                {
                                    UICommon.WinForm.showStatus("Cant update with same name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }
                        }
                    }
                    reloadIncome();
                    if(ADGVIncomeDetails.Rows.Count == 0)
                    {
                        lblMsgIncm.Visible = true;
                    }
                    else
                    {
                        lblMsgIncm.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVIncomeDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVIncomeDetails();
                foreach (DataGridViewRow adrow in ADGVIncomeDetails.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVIncomeDetails.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void formatADGVIncomeDetails()
        {
            try
            {
                //Hiding Columns
                ADGVIncomeDetails.Columns["ExpenseId"].Visible = false;
                ADGVIncomeDetails.Columns["IsDirectExp"].Visible = false;
                ADGVIncomeDetails.Columns["IsExpense"].Visible = false;
                ADGVIncomeDetails.Columns["Account"].Visible = false;
                ADGVIncomeDetails.Columns["Description"].Visible = false;
                ADGVIncomeDetails.Columns["PaidTo"].Visible = false;
                ADGVIncomeDetails.Columns["Amount"].Visible = false;
                ADGVIncomeDetails.Columns["Date"].Visible = false;
                ADGVIncomeDetails.Columns["Trasaction"].Visible = false;
                ADGVIncomeDetails.Columns["BranchID"].Visible = false;
                ADGVIncomeDetails.Columns["FilePath"].Visible = false;
                ADGVIncomeDetails.Columns["PayMode"].Visible = false;
                ADGVIncomeDetails.Columns["ExpenseName"].DisplayIndex = 2;

                ADGVIncomeDetails.Columns["ExpenseName"].HeaderText = "Income Name";

                ADGVIncomeDetails.Columns["Branch"].ReadOnly = true;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        private void ADGVIncome_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                formatADGVIncome();
                foreach (DataGridViewRow adrow in ADGVIncome.Rows)
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
                if (ADGVIncome.Columns.Contains("PDEX_DATE"))
                {
                    ADGVIncome.Columns["PDEX_DATE"].HeaderText = "Date";
                    ADGVIncome.Columns["PDEX_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                    ADGVIncome.Columns["PDEX_DATE"].ReadOnly = true;
                }
                if (ADGVIncome.Columns.Contains("PDEX_DESC"))
                {
                    ADGVIncome.Columns["PDEX_DESC"].HeaderText = "Description";
                }
                if (ADGVIncome.Columns.Contains("PDEX_PAID_TO"))
                {
                    ADGVIncome.Columns["PDEX_PAID_TO"].HeaderText = "PaidFrom";
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
                if (ADGVIncome.Columns.Contains("Category"))
                {
                    ADGVIncome.Columns["Category"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        private void ADGVIncome_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ADGVIncome.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Common.Events.numOnly);
                }
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

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            

            //ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString());
        }
        private void cmbViewExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                //  branchID = WinApp.Program.LoggedInUser.BranchId;
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

                        panelMaxInc.Visible = true;
                        showPanel = true;
                        btnUpdatePaidIncome.Enabled = false;
                        dt = BLL.ExpenseHandler.getCategoryWiseCollection(false,branchID);
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
               
                formateLastTabDates();
                if (cmbViewExpenses.SelectedIndex == 1)
                {
                    ADGVIncome.DataSource = BLL.ExpenseHandler.getCategoryWiseCollection(false ,branchID, dtpFromDate.Value, dtpToDate.Value);
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
        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
            if (validateDates())
            {
                ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
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

        private void ADGVIncomeDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVIncome_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVIncome,e);
        }

        private void ADGVIncomeDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVIncomeDetails,e);
        }

      

        private void cmdAddExpense_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validateIncome())
                {
                    if (this.ValidateChildren(ValidationConstraints.Visible))
                    {
                        Info.Expense expense = new Info.Expense();
                        expense.ExpenseId =(comboIndirectExpenses.SelectedItem as Info.Expense).ExpenseId;
                        expense.Description = txtDescription.Text;
                        expense.PaidTo = txtPaidTo.Text;
                        expense.Amount = Convert.ToDecimal(txtAmount.Text);
                        expense.Date = dateDt.Value;
                        expense.IsExpense = false;
                        expense.Account.Id = (cmbAccounts.SelectedItem as Info.Account).Id;
                        expense.FilePath = txtPath.Text.ToString();
                        expense.PayMode = cmbPaymentMode.SelectedItem.ToString();

                        string filePath = expense.FilePath;
                        string lastFolder = Path.GetFileName(filePath);
                        string fileLocCopy = AppDomain.CurrentDomain.BaseDirectory + "IncomeDocuments\\" + lastFolder;
                        if (File.Exists(expense.FilePath))
                        {

                            // If file already exists in destination, delete it.
                            if (File.Exists(fileLocCopy))
                                File.Delete(fileLocCopy);
                            File.Copy(expense.FilePath, fileLocCopy);


                        }
                        if (BLL.ExpenseHandler.insertExpense(expense, Convert.ToInt32(branchID)))
                        {
                            UICommon.WinForm.showStatus("Income added successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            // UICommon.WinForm.clearTextBoxes(tabPage1);
                            clearForm();
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("Error adding income please try later", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
                if (ValidateIncome())
                {
                    bool returnCode = BLL.ExpenseHandler.createNewExpense(txtIncome.Text, Convert.ToInt32(branchID), false);
                    if (returnCode)
                    {
                        UICommon.WinForm.showStatus("Income created successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                        reloadIncome();
                        lblMsgIncm.Visible = false;

                    }
                    else if (returnCode)
                    {
                        UICommon.WinForm.showStatus("Please use some different name to update details", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    txtIncome.Text = "";
                }
            }
          
                  catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Income \"" + txtIncome.Text + "\" already exists", sCaption, this);
            }
           
            catch (Exception ex)
            {
                UICommon.WinForm.showStatus("Following error occured\n\n" + ex.Message + "\n\nPlease contact System Admin if problem persists.Error has Occured", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        

        private void btnUpdatePaidIncome_Click_1(object sender, EventArgs e)
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
                     
                    }
                }
                if (returnCode == 1)
                {
                    UICommon.WinForm.showStatus("Income cupdated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ADGVIncome.DataSource != null)
                {
                    Common.ImportExport.ImportToExcel(ADGVIncome,null);
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

        private void dtpToDate_CloseUp(object sender, EventArgs e)
        {
            {
                if (validateDates())
                {
                    ADGVIncome.DataSource = BLL.ExpenseHandler.getPaidExpense(false, false, branchID.ToString(), dtpFromDate.Value, dtpToDate.Value);
                }
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
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

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            try
            {
                int returnCode = 0;
                if (validateIncome())
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
                        expense.IsExpense = false;
                        expense.FilePath = txtPath.Text.ToString();
                        expense.PayMode = cmbPaymentMode.SelectedItem.ToString();
                        string filePath = expense.FilePath;

                        string lastFolder = Path.GetFileName(filePath);
                        string fileLocCopy = AppDomain.CurrentDomain.BaseDirectory + "IncomeDocuments\\" + lastFolder;
                        if (File.Exists(expense.FilePath))
                        {
                            // If file already exists in destination, delete it.
                            if (File.Exists(fileLocCopy))
                                File.Delete(fileLocCopy);
                            File.Copy(expense.FilePath, fileLocCopy);
                        }
                        returnCode = BLL.ExpenseHandler.UpdatePaidExpenseOrIncome(expense, PdexId, Convert.ToInt32(branchID));
                        BLL.UserHandler.createActivity(0,DateTime.Now.Date, "Update in Income", Program.LoggedInUser.UserId.ToString(), oldExpenseValue, expense.Amount.ToString(), Program.LoggedInUser.UserId, branchID.ToString());
                        if (returnCode == 1)
                        {
                            UICommon.WinForm.showStatus("Income updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            clearForm();
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("Error updating Income please try later..Failure", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setValuesForUpdate(string Id, string branch)
        {
            try
            {

                DataTable record = BLL.ExpenseHandler.getExpense(Id, branch,false);
                reloadIncome();
                getAccounts(lstAccount);


                foreach (object obj in cmbAccounts.Items)
                {
                    if ((obj as Info.Account).Id.ToString().Equals(record.Rows[0]["PDEX_ACCNT_ID"].ToString()))
                    {
                        cmbAccounts.SelectedItem = obj;
                        break;
                    }
                }


                comboIndirectExpenses.Text = record.Rows[0].ItemArray[1].ToString();
                txtPaidTo.Text = record.Rows[0]["PDEX_PAID_TO"].ToString();
                cmbPaymentMode.Text = record.Rows[0]["PDEX_PAYMENT_MODE"].ToString();
                txtAmount.Text = record.Rows[0]["Amount"].ToString();
                txtDescription.Text = record.Rows[0]["PDEX_DESC"].ToString();
                txtPath.Text = record.Rows[0]["PDEX_FILE_PATH"].ToString();
                dateDt.Value = Convert.ToDateTime(record.Rows[0]["PDEX_DATE"]);
                PdexId = Convert.ToInt32(Id);
                oldExpenseValue = record.Rows[0]["Amount"].ToString();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAccounts.Items.Clear();
            //ADDED BY ASHVINI 4-1-2019
            //FOR SELECTING ANY CASH ITEM WITH CASH
            if (cmbPaymentMode.SelectedItem.ToString().Contains("CASH") )
                //END BY ASHVINI

            {
                lstAccount = BLL.AccountHandller.getAccounts(branchID.ToString());            
                foreach (var str in lstAccount)
                {
                    if (str.AccountName.ToLower().Contains("cash"))
                    {
                        cmbAccounts.Items.Add(str);
                      
                    }

                }
            }
            else
            {
                lstAccount = BLL.AccountHandller.getAccounts(branchID.ToString());

                foreach (var str in lstAccount)
                {//changed on 25-12
                    if (str.AccountName.ToLower().Contains("cash"))
                    {
                        cmbAccounts.Items.Remove(str);
                    }
                    else
                    {
                        cmbAccounts.Items.Add(str);

                    }
               
                }
              

            }
            if (cmbAccounts.Items.Count>0)
                {
                    cmbAccounts.SelectedIndex = 0;
                }

        }

      
    }
 }


