using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp.Popups
{
    public partial class FrmChequePopup : FrmParentForm
    {

        List<Account> lstAccount;
        public static Cheque objCheque = null;
       
        private static FrmChequePopup myInstance;
        private string sCaption = "Add Cheque";
        public static bool isAdd = true;
        string branchId = Program.LoggedInUser.BranchId.ToString();


        private bool isFormToClose;

        public FrmChequePopup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdd == false)
                {
                    objCheque.Amount = Convert.ToDecimal(txtAmount.Text);
                    objCheque.Bank = txtBank.Text;
                    objCheque.BankBranch = txtBranch.Text;
                    objCheque.ChequeNo = txtChequeNo.Text;
                    objCheque.Status = (Info.Cheque.ChequeStatus)cmbChequeStatus.SelectedIndex;
                    string bounce = txtBounceCharges.Text;
                    if (bounce == "")
                    {
                        txtBounceCharges.Text = "0";
                    }
                    objCheque.BounceCharges = Convert.ToDecimal(txtBounceCharges.Text);
                    objCheque.Date = dtpCheque.Value;
                    objCheque.DepositAccount = cmbAccounts.SelectedItem as Account;
                    BLL.ChequeHandler.UpdateCheque(objCheque);
                    this.Close();
                }
                else
                {
                    if (isFormToClose= validateForm())
                    {
                        objCheque = new Cheque();
                        objCheque.Amount = Convert.ToDecimal(txtAmount.Text);
                        objCheque.Bank = txtBank.Text;
                        objCheque.BankBranch = txtBranch.Text;
                        objCheque.ChequeNo = txtChequeNo.Text;
                        objCheque.Status = (Info.Cheque.ChequeStatus)cmbChequeStatus.SelectedIndex;
                        string bounce = txtBounceCharges.Text;
                        if(bounce == "")
                        {
                            txtBounceCharges.Text = "0";
                        }
                        objCheque.BounceCharges = Convert.ToDecimal(txtBounceCharges.Text);
                        objCheque.Date = dtpCheque.Value;
                        objCheque.DepositAccount = cmbAccounts.SelectedItem as Account;
                        clearForm();
                    }
                }
                
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        /// <summary>
        /// Sets the control values based on input cheque object
        /// </summary>
        /// <param name="objCheq"></param>
        /// 


        public void assignAccountDataSource()
        {
            try
            {
                cmbAccounts.Items.Clear();
                lstAccount = new List<Account>();
                lstAccount = BLL.AccountHandller.getAccounts(branchId.ToString());
                cmbAccounts.DisplayMember = "AccountName";
                cmbAccounts.ValueMember = "Id";

             

                foreach (var str in lstAccount)
                {
                    if (str.AccountName.ToLower() != "cash")
                    {
                        cmbAccounts.Items.Add(str);
                        
                    }
                }
                cmbAccounts.SelectedIndex = 0;
                //cmbAccounts.DataSource = lstAccount.Where(acc => acc.AccountType == "CR").ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool validateForm()
        {
            try
            {
               if (txtBank.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Bank Name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtBank.Focus();
                    return false;
                }
                else if (txtBranch.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Branch of Bank.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtBranch.Focus();
                    return false;
                }
                else if (txtChequeNo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Cheque Number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtChequeNo.Focus();
                    return false;
                }
                else if (cmbChequeStatus.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select Status of the Cheque.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    return false;
                }

                else if (cmbAccounts.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select Account for the Cheque to be deposited.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (txtAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtAmount.Focus();
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
    


        public  void setCheque(Cheque objCheq)
        {
            try
            {
                isAdd = false;
                btnSave.Text = "Update";
               // cmbAccounts.SelectedIndex = 0;
                if (isAdd == false)
                {
                    if (objCheq.Status == Cheque.ChequeStatus.CLRD)
                    {
                        txtAmount.Enabled = false;
                        cmbChequeStatus.Enabled = false;
                    }
                    else
                    {
                        txtAmount.Enabled = false;
                        cmbChequeStatus.Enabled = true;
                    }
                    txtAmount.Text = objCheq.Amount.ToString();
                    txtBank.Text = objCheq.Bank;
                    txtBranch.Text = objCheq.BankBranch;
                    txtBounceCharges.Text = objCheq.BounceCharges.ToString();
                    txtChequeNo.Text = objCheq.ChequeNo;
                    dtpCheque.Value = objCheq.Date.Value;
                    cmbChequeStatus.SelectedIndex = (int)objCheq.Status;
                   
                    assignAccountDataSource();
                   string account= (objCheq.DepositAccount.ToString());
                 
                    cmbAccounts.Text = account;

                    objCheque = objCheq;
                    ShowDialog();
                  
                    isAdd = true;
                    btnSave.Text = "Add";
                    clearForm();
                    myInstance = null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        internal static FrmChequePopup getInstance()
        {
            if(myInstance == null)
            {
                myInstance = new FrmChequePopup();
            }

            return myInstance;
        }
        private void FrmChequePopup_Load(object sender, EventArgs e)
        {
            try
            {
                //Setting cheque status. By default, it would be cleared.

                //if (myInstance == null || btnSave.Text=="Add")
                //{
                    cmbChequeStatus.SelectedIndex = 0;
                //}
               
                AssignEvents();
                UICommon.WinForm.formatDateTimePicker(dtpCheque);
                if (isAdd == true)
                {
                    assignAccountDataSource();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        /// <summary>
        /// Clears the form
        /// </summary>
        public void clearForm()
        {
            txtBounceCharges.Text = "0";
            txtAmount.Text = "";
            txtBank.Text = "";
            txtBranch.Text = "";
            txtChequeNo.Text = "";
            cmbChequeStatus.SelectedIndex = 0;
            cmbAccounts.SelectedIndex = 0;
        }


        public void AssignEvents()
        {
            txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtBounceCharges.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }
        
        private void FrmChequePopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(e.CloseReason==CloseReason.UserClosing)
                {
                    //isFormToClose = true;
                    e.Cancel = false;
                    return;
                }

                if (!isFormToClose)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (txtChequeNo.Text.Length >= 6)
            {
                if (e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            
            }
       }
    }
}
