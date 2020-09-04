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
using ClassManager.Info;

namespace ClassManager.WinApp.Popups
{
    public partial class FrmBankTransfer : FrmParentForm
    {
        List<Account> lstAccount;
        public static PaymentDetails objDetails = null;
        private static FrmBankTransfer form;
        private string sCaption = "BankTransfere Details";
        public static bool isAdd = true;
        string branchId = Program.LoggedInUser.BranchId.ToString();
        public  static  StudentMaster objStudentMaster = new StudentMaster();

        private bool isFormToClose;

        public FrmBankTransfer()
        {
            InitializeComponent();
        }

        private void FrmBankTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                AssignEvents();
                UICommon.WinForm.formatDateTimePicker(dtpDate);
                assignAccountDataSource();
               if(form!=null)
                {
                    setName(objStudentMaster);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setName(StudentMaster objstudent)
        {
            try
            {
                txtFromAcnt.Text = objstudent.DisplayName.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if (isFormToClose = validateForm())
                    {
                        objDetails = new PaymentDetails();
                        objDetails.Amount = Convert.ToDecimal(txtAmount.Text);
                        objDetails.FromAcc = txtFromAcnt.Text.ToString();
                        objDetails.ToAcc = cmbToAccount.SelectedItem.ToString();
                        objDetails.ReferenceNo =  (txtRefNo.Text).ToString();
                        objDetails.Type = Info.PaymentDetails.PaymentType.BANK_TRANSFER;
                        objDetails.PaymentDate = dtpDate.Value.Date;
                        objDetails.DepositAccount = cmbToAccount.SelectedItem as Account;
                        clearForm();
                    }
              

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal static FrmBankTransfer getform()
        {
            if (form == null)
            {
                form = new FrmBankTransfer();
            }

            return form;
        }
        public void AssignEvents()
        {
            try
            {
                txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               
               
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
                if (txtFromAcnt.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Enter value for From Account", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFromAcnt.Focus();
                    return false;
                }
                
                else if (txtRefNo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Referance Number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtRefNo.Focus();
                    return false;
                }
             

                else if (cmbToAccount.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select To Account", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (txtAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Enter Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

        public void assignAccountDataSource()
        {
            try
            {
                cmbToAccount.Items.Clear();
                lstAccount = new List<Account>();
                lstAccount = BLL.AccountHandller.getAccounts(branchId.ToString());
                cmbToAccount.DisplayMember = "AccountName";
                cmbToAccount.ValueMember = "Id";
                foreach(var str in lstAccount)
                {
                    if(str.AccountName.ToLower()!=("cash"))
                    {
                        cmbToAccount.Items.Add(str);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void clearForm()
        {
            txtFromAcnt.Text = "";
            txtAmount.Text = "";
            cmbToAccount.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            UICommon.WinForm.formatDateTimePicker(dtpDate);
            txtRefNo.Text = "";
           cmbToAccount.SelectedIndex = 0;
        }

        private void FrmBankTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                 
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

                throw ex;
            }
        }

        private void cmbToAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRefNo.Text = cmbToAccount.Text;
        }
    }
}
