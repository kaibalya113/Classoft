using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.BLL;
using System.Data.SqlClient;
using ClassManager.WinApp.UICommon;
using MaterialSkin;
using System.Net;
using System.Threading;

namespace ClassManager.WinApp
{

    public partial class FrmLogin : FrmParentForm
    {

        string sCaption = "Login";
        public static int Branch_Id;
        public static FrmLogin frmLoginInstance;

        private FrmLogin()
        {
            InitializeComponent();

        }
        [STAThread]
        public static FrmLogin getInstance()
        {

            if (frmLoginInstance == null)
            {
                frmLoginInstance = new FrmLogin();
            }

            return frmLoginInstance;

        }


        private void loadForm()
        {
            try
            {

                cmdLogin.Enabled = true;

                List<Branch> lstBranches = BLL.BranchHandler.getBranches();
                if (lstBranches.Count > 0)
                {
                    cmbBranch.DataSource = null;
                    cmbBranch.DisplayMember = "BranchName";
                    cmbBranch.ValueMember = "BranchId";
                    cmbBranch.DataSource = lstBranches;

                    if (SysParam.contains(SysParam.Parameters.ALLOW_BRANCH_SELECTION) ? SysParam.getValue<bool>(SysParam.Parameters.ALLOW_BRANCH_SELECTION) : false)
                    {
                        cmbBranch.Enabled = true;
                    }
                    else
                    {
                        cmbBranch.Enabled = false;
                    }


                    int currentBranchId = ClassManager.Properties.Settings.Default.BranchId;


                    string className = SysParam.contains(SysParam.Parameters.NAME) ? SysParam.getValue<string>(SysParam.Parameters.NAME) : "";
                    Info.Branch currentBranch = lstBranches.Where(branch => branch.BranchId == currentBranchId).FirstOrDefault();
                    if (currentBranch != null)
                    {
                        cmbBranch.Text = currentBranch.BranchName;
                        lblclasName.Text = className + " Branch " + currentBranch.BranchName;
                    }

                }
                else
                {
                    UICommon.WinForm.showStatus("No Branches Availbale.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (SqlException ex)
            {
                UICommon.WinForm.showError(ex, "Database not configred Properly", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            try
            {

                cmdLogin.BackColor = System.Drawing.Color.DarkSlateGray;
                int noOfLoginsRemaining = Info.SysParam.getValue<Int32>(SysParam.Parameters.NO_OF_LOGINS);

                if (loginUser() == true)
                {
                    FrmMainForm homeForm = (FrmMainForm)UICommon.FormFactory.GetForm(Forms.FrmMainForm, null);
                    noOfLoginsRemaining++;

                    BLL.SystemParameterHandler.updateSysParam(SysParam.Parameters.NO_OF_LOGINS, noOfLoginsRemaining.ToString(), Convert.ToInt32(Program.LoggedInUser.BranchId));
                    Thread thrdNotification = new Thread(() => Program.sendNotification(Common.ClsCommon.branchId));
                    thrdNotification.Start();
                    homeForm.Visible = true;
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    txtUsername.Focus();
                    this.Visible = false;
                }
            }
            catch (KeyNotFoundException ex)
            {
                WinForm.checkInternetConnection(ex, sCaption, this);
                UICommon.WinForm.showStatus("System parameters not configured correctly, Please contact support", sCaption, this);
            }
            catch (Exception ex)
            {
                WinForm.checkInternetConnection(ex, sCaption, this);
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private bool loginUser()
        {
            try
            {

                if (txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0 || txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please enter valid username and password.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    return false;
                }
                else
                {
                    User objUser = new User();


                    objUser = BLL.LoginHandller.LoginUser(txtUsername.Text, txtPassword.Text.ToString(), ((Info.Branch)cmbBranch.SelectedItem).BranchId);

                    if (objUser == null)
                    {
                        UICommon.WinForm.showStatus("Invalid Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                        return false;
                    }
                    else
                    {
                        objUser.BranchId = ((Info.Branch)cmbBranch.SelectedItem).BranchId;
                        objUser.BranchName = cmbBranch.Text;
                        Program.LoggedInUser = objUser;
                        Common.ClsCommon.branchId = objUser.BranchId;
                        UserHandler.loggedInUser = objUser;
                        Common.Log.Client = SysParam.getValue<string>(SysParam.Parameters.NAME) + " " + SysParam.getValue<string>(SysParam.Parameters.CONTACT_NO) + " " + SysParam.getValue<string>(SysParam.Parameters.SW_BRANCH_NAME);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                return false;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                if (ClassManager.BLL.DBHandller.checkDBCOnnectivity() == false)
                {
                    cmdLogin.Enabled = false;
                }
                else
                {
                    loadForm();
                    if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == "Gym")
                    {
                        this.Text = "GymWise";
                        lblName.Text = "GYM - WISE";
                        lblName.Visible = true;
                    }

                    if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == "Dance")
                    {
                        this.Text = "DanceWise";
                        lblName.Text = "DANCE-WISE";
                        lblName.Visible = true;
                    }

                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(this.cmdLogin, "Login");
                    cmdLogin.BackColor = System.Drawing.Color.DarkSlateGray;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }

        }

        private void linkConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length == 0 && txtPassword.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please enter username and password.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else if (txtUsername.Text == "SystemAdmin" && Common.EncryptionDecryption.Encrypt(txtPassword.Text) == "n1eH3V1Nukelp3eujsTYxEz4uHxgpBXMXd/4ZNW8P3k=")
                {
                    FrmConfig.getInstance().Visible = true;
                    this.Hide();
                }
                else
                {
                    UICommon.WinForm.showStatus("The  Username Or The Password Is Incorrect.", sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }



        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginUser();
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Program.objMutex.ReleaseMutex();
                Application.ExitThread();

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);




            }
        }



        private static ParameterizedThreadStart sendNotification()
        {
            try
            {

                BLL.NotificationHandler.autoSendNotifications(DateTime.Now, (Convert.ToInt32(Program.LoggedInUser.BranchId)));
                return null;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                return null;
            }

        }
    }

}
