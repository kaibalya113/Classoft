using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using ClassManager.Common.Exceptions;
using ClassManager.WinApp.UICommon;
using ClassManager.Info;
using ClassManager.BLL;

namespace ClassManager.WinApp
{
    public partial class FrmConfig : WinApp.UICommon.FrmParentForm
    {
        string sCaption = "Configuration Settings";
        public static FrmConfig configForm;
        public static FrmLogin frmLoginReference;


        public FrmConfig()
        {
            InitializeComponent();
        }



        public static FrmConfig getInstance()
        {
            try
            {
                if (configForm == null || configForm.IsDisposed)
                {
                    configForm = new FrmConfig();
                }
                return configForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Config_Load(object sender, EventArgs e)
        {

            loadConfig();
        }

        private void loadConfig()
        {
            try
            {

                SqlConnectionStringBuilder sb = BLL.DBHandller.getConnectionStringBuilder();

                txtIP.Text = sb.DataSource;
                txtIniCat.Text = sb.InitialCatalog;
                txtUsername.Text = sb.UserID;
                txtPassword.Text = sb.Password;

                if (!sb.DataSource.Equals("") && BLL.DBHandller.checkDBConnectivity(sb))
                {

                    BLL.SystemParameterHandler.loadSystemParameter();
                    List<Info.Branch> branches = BLL.BranchHandler.getAllBranches();
                    cmbBranch.Items.Clear();
                    cmbRoleBranch.Items.Clear();
                   // comboType.Items.Clear();
                    if (branches.Count > 0)
                    {
                        //cmbRoleBranch.DataSource = branches;
                        //cmbBranch.DataSource = branches;

                        foreach (Info.Branch items in branches)
                        {
                            cmbBranch.Items.Add(new Info.ComboItem(items.BranchId, items.BranchName));
                            cmbRoleBranch.Items.Add(new Info.ComboItem(items.BranchId, items.BranchName));
                        }

                        //if (branches.Count > 1)
                        //{
                        cmbRoleBranch.SelectedIndex = 0;
                        cmbBranch.SelectedIndex = 0;
                        comboType.Items.Clear();
                        List<Info.RoleMaster> roles = BLL.UserHandler.getRoles(branches[0].BranchId);

                        foreach (Info.RoleMaster rm in roles)
                        {
                            comboType.Items.Add(new Info.ComboItem(rm.Id, rm.RoleName));
                        }



                        if (comboType.Items.Count > 0)
                        {
                            comboType.SelectedIndex = 0;
                        }
                        //}
                    }



                    try
                    {
                        txtsyncbranchid.Text = Info.SysParam.contains(Info.SysParam.Parameters.SW_BRANCH_ID) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SW_BRANCH_ID) : "";


                        txtCurrentBranchId.Text = Info.SysParam.contains(Info.SysParam.Parameters.SW_BRANCH_ID) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SW_BRANCH_ID) : "";
                        txtSyncUsername.Text = Info.SysParam.contains(Info.SysParam.Parameters.SYNC_USERNAME) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SYNC_USERNAME) : "ClassManagerSync";
                        txtSyncBranch.Text = Info.SysParam.contains(Info.SysParam.Parameters.SYNC_BRANCH) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SYNC_BRANCH) : "master";
                        txtSyncPassword.Text = Info.SysParam.contains(Info.SysParam.Parameters.SYNC_PASSWORD) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SYNC_PASSWORD) : "v+G+0L4zj138jMR8OJ8gBxEXvvR4z79A/SPwR1w8we0=";
                        txtSyncURL.Text = Info.SysParam.contains(Info.SysParam.Parameters.SYNC_REMOTE) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SYNC_REMOTE) : "https://classmanagersync@gitlab.com/classmanagersync/##reponame##.git";
                        txtSyncFolder.Text = Info.SysParam.contains(Info.SysParam.Parameters.SYNC_REPOFOLDER) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SYNC_REPOFOLDER) : "DBSYNC";
                        txtSyncEmail.Text = Info.SysParam.contains(Info.SysParam.Parameters.SYNC_EMAIL) ? Info.SysParam.getValue<string>(Info.SysParam.Parameters.SYNC_EMAIL) : "classmanagersync@gmail.com";


                    }
                    catch (KeyNotFoundException ex)
                    {
                        UICommon.WinForm.showStatus("System Parameters not found", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("0"))
                {
                    UICommon.WinForm.showStatus("Internet Connection is not Available or Server not found", sCaption, null);
                }

                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, null);
                }
            }
        }

        private void btnCreateBranch_Click(object sender, EventArgs e)
        {
            FrmBranchMaster frmbranchMaster = new FrmBranchMaster();
            frmbranchMaster.Visible = true;
        }
        public bool validateUserPanelPart()
        {
            try
            {
                 if (txtNewUserName.Text == "")
                {
                    UICommon.WinForm.showStatus("Enter UserName.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPassword.Focus();
                    return false;
                }
                else if (txtNewPassword.Text == "")
                {
                    UICommon.WinForm.showStatus("Enter Password.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPassword.Focus();
                    return false;
                }
              
            
               else if(cmbBranch.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Create Branch.", sCaption, this);
                    cmbBranch.Focus();
                    return false;
                }
              else  if(comboType.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Create Role.", sCaption, this);
                    comboType.Focus();
                    return false;
                }
              else  if (string.IsNullOrWhiteSpace(txtNewUserName.Text) && txtNewUserName.Text.Length > 0)
                {
                    UICommon.WinForm.showStatus("Enter valid UserName.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPassword.Focus();
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateUserPanelPart())
                {
                    BLL.LoginHandller.RegisterUser((cmbBranch.SelectedItem as Info.ComboItem).key, txtNewUserName.Text, txtNewPassword.Text, (comboType.SelectedItem as Info.ComboItem).key);
                   // BLL.LoginHandller.RegisterUser( txtNewUserName.Text, txtNewPassword.Text, (comboType.SelectedItem as Info.ComboItem).key);
                    UICommon.WinForm.showStatus("User created successfully", sCaption, this);
                    clearUserPanel();
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Username already exists, Please provide different username."))
                {
                    UICommon.WinForm.showStatus(ex.Message, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Config", this, ex.Message);
                }
            }
        }
        public void clearUserPanel()
        {
            try
            {
                txtNewPassword.Text = "";
                //txtNewPassword.Text = "";
                txtNewUserName.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool validateBranchPanel()
        {
            try
            {
               
                if (txtName.Text == "" )
                {
                    UICommon.WinForm.showStatus("Enter the branch name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                    txtName.Focus();
                }
                if(string.IsNullOrWhiteSpace(txtName.Text) && txtName.Text.Length > 0)
                {
                    UICommon.WinForm.showStatus("Enter Valid branch name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                    txtName.Focus();
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
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateBranchPanel())
                {
                    cmbBranch.Items.Clear();
                    cmbRoleBranch.Items.Clear();
                    Info.Branch objBranch = new Info.Branch();

                    objBranch.Address = txtAddress.Text;
                    objBranch.Head = txtHead.Text;
                    objBranch.IsCurrent = "";
                    objBranch.BranchName = txtName.Text;
                    BLL.BranchHandler.createBranch(objBranch);
                   
                    foreach (Info.Branch items in BLL.BranchHandler.getAllBranches())
                    {
                        cmbBranch.Items.Add(new Info.ComboItem(items.BranchId, items.BranchName));
                        cmbRoleBranch.Items.Add(new Info.ComboItem(items.BranchId, items.BranchName));
                    }

                    UICommon.WinForm.showStatus("Branch created successfully", sCaption, this);
                    cmbRoleBranch.SelectedIndex = 0;
                    txtAddress.Text = "";
                    txtHead.Text = "";
                    txtName.Text = "";
                }
            }
            catch (RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Branch Already Created with this name", sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        private bool Vaildate()
        {
            try
            {
                if (txtRole.Text == "")
                {
                    UICommon.WinForm.showStatus("Enter the Role.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (cmbRoleBranch.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Select Branch.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
        private bool validateRolePanel()
        {
            try
            {
             //   if (cmbRoleBranch.SelectedIndex == -1)
               // {
                   // UICommon.WinForm.showStatus("Please Create Branch", sCaption, this);
                    //eturn false;
                //}
                if (string.IsNullOrWhiteSpace(txtRole.Text) && txtRole.Text.Length > 0)
                {
                    UICommon.WinForm.showStatus("Enter Valid RoleName", sCaption, this);
                    return false;
                }
                if (txtRole.Text == "")
                {
                    UICommon.WinForm.showStatus("Enter Role Name", sCaption, this);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            try
            {
                // if(cmbRoleBranch.SelectedIndex == -1)
                // {
                //     UICommon.WinForm.showStatus("Please Create Branch", sCaption, this);
                // }
                // if(string.IsNullOrWhiteSpace(txtRole.Text) && txtRole.Text.Length > 0)
                // {
                //     UICommon.WinForm.showStatus("Enter Valid RoleName", sCaption, this);
                // }

                // else if (txtRole.Text != "") 
             
               if(validateRolePanel())
                {
                   comboType.Items.Clear();
                   int branchId = (cmbRoleBranch.SelectedItem as Info.ComboItem).key;
                    BLL.UserHandler.createRole(txtRole.Text);//, branchId);
                    foreach (Info.RoleMaster role in BLL.UserHandler.getRoles(branchId))
                       // foreach (Info.RoleMaster role in BLL.UserHandler.getRoles())
                        {
                        comboType.Items.Add(new Info.ComboItem (role.Id, role.RoleName));
                    }

                    UICommon.WinForm.showStatus("Role " + txtRole.Text + " created successfully", sCaption, this);
                    txtRole.Text = "";
                }
                //else
                //{
                //    UICommon.WinForm.showStatus("Enter Role Name", sCaption, this);
                //}
            }
             
            catch (RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Role " + txtRole.Text + " already exists", sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboType.Items.Clear();
                int branchId = (cmbBranch.SelectedItem as Info.ComboItem).key;

                //foreach (info.rolemaster rm in bll.userhandler.getroles(branchid))
                foreach(Info.RoleMaster rm in BLL.UserHandler.getRoles(branchId))
                {
                    comboType.Items.Add(new Info.ComboItem(rm.Id, rm.RoleName));
                }

                if (comboType.Items.Count > 0)
                {
                    comboType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
            
        }



        private void cmbRoleBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int branchId = (cmbRoleBranch.SelectedItem as Info.Branch).BranchId;
                foreach (Info.RoleMaster rm in BLL.UserHandler.getRoles(branchId))
                {
                    comboType.Items.Add(new Info.ComboItem(rm.Id, rm.RoleName));
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();
                conBuilder.InitialCatalog = txtIniCat.Text;
                conBuilder.DataSource = txtIP.Text;
                conBuilder.UserID = txtUsername.Text;
                conBuilder.Password = txtPassword.Text;

                if (BLL.DBHandller.checkDBConnectivity(conBuilder))
                {
                    BLL.DBHandller.saveDBConfig(conBuilder);
                    loadConfig();
                    if (UICommon.WinForm.showStatus("Database configured successfully,Do you want to login now?", "DB Config", this, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        BLL.SystemParameterHandler.loadSystemParameter();
                        BLL.TemplateHandler.loadTemplates();
                        Program.startBiomonitor();
                        showLoginForm();
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Cannot Connect to DB using given details", "DB Configuration", this);
                }

                //loadConfig();
             // ClearFeilds();

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("0"))
                {
                    
                    UICommon.WinForm.showStatus("Internet Connection is not Available or Server not found", sCaption, null);
                   
                }

                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, null);
                }

            }

        }
        private void ClearFeilds()
        {
            try
            {

                cmbBranch.Items.Clear();
                comboType.Items.Clear();
               cmbRoleBranch.Items.Clear();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void chkCurrentBranch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCurrentBranch.Checked)
                {
                    Info.ComboItem branch = cmbRoleBranch.SelectedItem as Info.ComboItem;
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_ID, branch.strKey.ToString());
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_NAME, branch.name.ToString());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void showLoginForm()
        {
            try
            {
                FrmLogin.frmLoginInstance = null;
                FrmLogin.getInstance().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }

        }

        private void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
                //showLoginForm();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
                this.Close();
            }

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsyncbranchid.Text != "")
                {
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_ID, txtsyncbranchid.Text);

                    //Import All data
                    //DBSyncService.Program.Main(new string[] { "sync", txtsyncbranchid.Text });

                    //Reset SW_BRANCH_ID
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_ID, txtsyncbranchid.Text);
                    UICommon.WinForm.showStatus("Data sync completed successfully", "Data Sync", this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Please specify current branch id", sCaption, this);
                    txtsyncbranchid.Focus();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Sync Data", this, "Unable to complete backup, Please conatct support");
               
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                tsLblStatus.Text = "Export is in Proress";
                //DBSyncService.Program.Main(new string[] { "export", txtsyncbranchid.Text });
                tsLblStatus.Text = "Expoert Completed Successfully";
                UICommon.WinForm.showStatus("Data Export completed successfully", "Data Sync", this);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Sync Data", this, "Unable to complete export, Please conatct support");
               
            }
        }

        private void btnSaveparam_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_ID, txtCurrentBranchId.Text);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SYNC_USERNAME, txtSyncUsername.Text);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SYNC_BRANCH, txtSyncBranch.Text);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SYNC_PASSWORD, txtSyncPassword.Text);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SYNC_REMOTE, txtSyncURL.Text);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SYNC_REPOFOLDER, txtSyncFolder.Text);
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SYNC_EMAIL, txtSyncEmail.Text);

                UICommon.WinForm.showStatus("System Parameters updated successfully", sCaption, this);

            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Config", this, "Error Saving Parameters");

            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                tsLblStatus.Text = "Import in Process";
                //DBSyncService.Program.Main(new string[] { "import", txtsyncbranchid.Text });
                tsLblStatus.Text = "Import in Completed Successfully";
                MessageBox.Show("Import Compteted Successfully", "Import Data");
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Config", this, "Error in import");
            }
        }

        private void btnImportAll_Click(object sender, EventArgs e)
        {

            try
            {
                //Import All data
                tsLblStatus.Text = "Import all data in progress";
                //DBSyncService.Program.Main(new string[] { "importAll", txtsyncbranchid.Text });
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_ID, txtsyncbranchid.Text);
                tsLblStatus.Text = "Import all completed successfully";
                UICommon.WinForm.showStatus("Import completed successfully", sCaption, this);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Import Data", this, "Unable to complete import, Please conatct support");
            }

        }

        private void btnExpoerAll_Click(object sender, EventArgs e)
        {
            try
            {
                tsLblStatus.Text = "Export all in progress";
                //DBSyncService.Program.Main(new string[] { "exportAll", txtsyncbranchid.Text });
                tsLblStatus.Text = "Export all completed successfully";
                UICommon.WinForm.showStatus("Data Export completed successfully", "Data Sync", this);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Sync Data", this, "Unable to complete export, Please conatct support");
                throw;
            }
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
        }
       
    }
}
