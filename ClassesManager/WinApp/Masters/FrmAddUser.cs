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
    public partial class FrmAddUser : FrmParentForm
    {
        string sCaption = "User Management";
        public FrmAddUser()
        {
            InitializeComponent();
        }
        private bool validateAddUser()
        {
            try
            {
                if (cmbBranch.SelectedIndex == -1 || txtPassword.Text.Trim() == "" || txtUsername.Text.Trim() == "" || comboType.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please enter the details properly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
        //private void cmdLogin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validateAddUser())
        //        {
        //            int BranchID = ((Info.Branch)(cmbBranch.SelectedItem)).BranchId;
        //            if (LoginHandller.RegisterUser(BranchID, txtUsername.Text, txtPassword.Text.ToString(), (comboType.SelectedItem as RoleMaster).Id))
        //            {
        //                UICommon.WinForm.showStatus("User registered.Success", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else
        //            {
        //                UICommon.WinForm.showStatus("Username already exists Error register user", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Something went wrong,  Please contact System Admin if problem persists", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

      
        private void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                //Assign Filter Event.Mohan(28-July-2017).
                WinForm.AssignFilterEvent(ADGVUsers);

                cmbBranch.DisplayMember = "Name";
                cmbBranch.ValueMember = "BranchID";
                cmbBranch.DataSource = BranchHandler.getBranches();

                if (cmbBranch.Items.Count > 0)
                {
                    cmbBranch.SelectedIndex = 0;
                    comboType.DataSource = UserHandler.getRoles((cmbBranch.SelectedItem as Info.Branch).BranchId);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateAddUser())
                {
                    int BranchID = ((Info.Branch)(cmbBranch.SelectedItem)).BranchId;
                    if (LoginHandller.RegisterUser(BranchID, txtUsername.Text, txtPassword.Text.ToString(), (comboType.SelectedItem as RoleMaster).Id))
                    {
                        UICommon.WinForm.showStatus("User Created Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Username already exists Error register user", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Something went wrong,  Please contact System Admin if problem persists", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ADGVUsers.DataSource = BLL.UserHandler.getUsers();
            }
            catch(Exception ex) 
            {
                throw (ex);
            }
        }

        private void ADGVUsers_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(ADGVUsers, e);
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVUsers.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;
                    
                }
             
               ADGVUsers.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
