using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
namespace ClassManager.WinApp
{
    public partial class FrmChangePassword : FrmParentForm
    {
        RolePrivilege formPrevileges;
        string sCaption = "Change Password";
        public FrmChangePassword()
        {
            InitializeComponent();
        }

       

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
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
                int functionId = Convert.ToInt32(this.Tag.ToString());
                formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {
                    }

                    if (formPrevileges.Modify == false)
                    {
                        cmdChangePassword.Visible = false;
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

        private void cmdChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text.ToString().Trim() == "")
                {
                    UICommon.WinForm.showStatus("Password cannot be Blank Space", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
                else
                {
                    if (LoginHandller.ChangePassWord(Program.LoggedInUser.UserId, txtNewPassword.Text.ToString(), txtOldPassword.Text.ToString()))
                    {
                        UICommon.WinForm.showStatus("Password changed successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        this.Dispose();
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Invalid old password \n Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
