using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
using ClassManager.Common.Exceptions;
using System.Collections;

namespace ClassManager.WinApp
{   

    public partial class FrmAssignPermissions : FrmParentForm
    {
        bool bAllowIndexChange = true;
        string sCaption = "Assign Permissions";
        RolePrivilege formPrevileges;
        public FrmAssignPermissions()
        {
            InitializeComponent();
        }

        private void FrmAssignPermissions_Load(object sender, EventArgs e)
        {
            try
            {
                WinForm.AssignFilterEvent(ADGVPrivileges);
                AssignEvents();
                cmbRoles.DisplayMember = "RoleName";
                cmbRoles.ValueMember = "Id";
                cmbRoles.DataSource = BLL.UserHandler.getRoles(Program.LoggedInUser.BranchId);

                if (cmbRoles.Items.Count > 0)
                {
                    cmbRoles.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        private void AssignEvents()
        {
            
            ADGVPrivileges.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVPrivileges.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
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
                        //chkShowAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        //cmdCreateExpence.Visible = false;
                        //cmdAddExpense.Visible = false;
                        //tabPCreateExpense.Hide();
                        btnNew.Visible = false;
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
        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bAllowIndexChange == true && cmbRoles.SelectedItem != null)
                {
                    ADGVPrivileges.DataSource = WinForm.ToDataTable(BLL.UserHandler.getRolePrivileges(Convert.ToInt32(cmbRoles.SelectedValue), Program.LoggedInUser.BranchId));
                    formatGrid();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void formatGrid()
        {
            try
            {
                ADGVPrivileges.Columns["FunctionName"].Width = 200;
                ADGVPrivileges.Columns["FunctionName"].HeaderText = "Screen";
                ADGVPrivileges.Columns["AllBranches"].HeaderText = "All Branches";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ADGVPrivileges_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                ADGVPrivileges.Columns[0].Visible = false;
                ADGVPrivileges.Columns[1].Visible = false;
                ADGVPrivileges.Columns[2].Visible = false;
                ADGVPrivileges.Columns[3].ReadOnly = true;
                ADGVPrivileges.Columns[9].Visible = false;

                foreach (DataGridViewRow adrow in ADGVPrivileges.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }
                ADGVPrivileges.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
                
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void chkAllView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in ADGVPrivileges.Rows)
                {
                    dr.Cells[4].Value = chkAllView.Checked;
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
          
        }

        private void chkAllModify_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in ADGVPrivileges.Rows)
                {
                    dr.Cells[5].Value = chkAllModify.Checked;
                }
            }
            catch(Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void chkAllDelete_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in ADGVPrivileges.Rows)
                {
                    dr.Cells[6].Value = chkAllDelete.Checked;
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void chkAllCreate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in ADGVPrivileges.Rows)
                {
                    dr.Cells[7].Value = chkAllCreate.Checked;
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }           
        }

        private void chkViewAllBranch_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow dr in ADGVPrivileges.Rows)
                {
                    dr.Cells[8].Value = chkViewAllBranch.Checked;
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
         
        }

       

        private void ADGVPrivileges_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVPrivileges, e);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                String role = Prompt.ShowDialog("Role", "New Role");
                if ((role.Trim() != ""))
                {
                    try
                    {
                        BLL.UserHandler.createRole(role);//, Program.LoggedInUser.BranchId);
                    }
                    catch (RecordAlreadyExistsException ex)
                    {
                        UICommon.WinForm.showStatus("Role " + role + " already exists, Please provide different role name", sCaption, this);
                    }
                }
                else
                {

                    UICommon.WinForm.showStatus("Role cannot be Blank", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                }
            }
            
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<RolePrivilege> lstRolePrivileges = WinForm.ToList<RolePrivilege>((DataTable)ADGVPrivileges.DataSource) as  List<RolePrivilege>;   
                foreach (RolePrivilege privilege in lstRolePrivileges)
                {
                    BLL.UserHandler.updatePrivileges(privilege);
                }
                UICommon.WinForm.showStatus("Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVPrivileges_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ADGVPrivileges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    }
}


