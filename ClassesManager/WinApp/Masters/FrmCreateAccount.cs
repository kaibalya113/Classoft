using ClassManager.Info;
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

namespace ClassManager.WinApp
{
    public partial class FrmCreateAccount : FrmParentForm
    {
        RolePrivilege formPrevileges;
        string sCaption = "CreateAccount";
        public FrmCreateAccount()

        {
            InitializeComponent();
        }
        public bool vaildate()
        {
            try
            {
                if (txtName.Text.Trim() == "" ) 
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Account Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtName.Focus();
                    return false;
                }
                else if(txtBalance.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtBalance.Focus();
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
     
       
        public void clearform()
        {
            txtName.Text = "";
            txtBalance.Text = "";
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void AssignEvenets()
        {
            try
            {
                txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void FrmCreateAccount_Load(object sender, EventArgs e)
        {
            try
            {
                AssignEvenets();
                ApplyPrevileges();
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
                if (this.Tag != null)
                {
                    int functionId = Convert.ToInt32(this.Tag.ToString());
                    formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                    if (formPrevileges != null)
                    {
                        if (formPrevileges.AllBranches == false)
                        {

                        }

                        if (formPrevileges.Modify == false)
                        {

                        }

                        if (formPrevileges.Create == false)
                        {
                            btnSave.Visible = false;
                        }

                        if (formPrevileges.Delete == false)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (vaildate())
                {
                    Info.Account objaccount = new Info.Account();
                    objaccount.AccountName = txtName.Text;
                    objaccount.Balance = Convert.ToDecimal(txtBalance.Text);
                    objaccount.AccountType = Convert.ToString(cmbType.SelectedItem);
                    objaccount.BranchID = Program.LoggedInUser.BranchId.ToString();
                    BLL.AccountHandller.createAccount(objaccount);
                    UICommon.WinForm.showStatus("Account created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearform();
                    //ADGVAccounts.DataSource = BLL.AccountHandller.getAccounts(Program.LoggedInUser.BranchId);
                }
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Account already Exist with this Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
    }
}

