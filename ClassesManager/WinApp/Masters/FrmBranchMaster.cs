using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmBranchMaster : FrmParentForm
    {
        string sCaption = "Branch";
        Boolean isCurrent = true;

        RolePrivilege formPrevileges;

        public FrmBranchMaster()
        {
            InitializeComponent();
        }

        private void BRANCH_MASTER_Load(object sender, EventArgs e)
        {

            ADGVBranchMaster.DataSource = WinForm.ToDataTable(BLL.BranchHandler.getAllBranches());

            AssignEvents();
         

        }
        private void AssignEvents()
        {
           txtHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
           ADGVBranchMaster.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
           ADGVBranchMaster.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        //private void btnCreate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ValidateDetails())
        //        {
        //            Info.Branch objBranch = new Info.Branch();

        //            objBranch.Address = txtAddress.Text;
        //            objBranch.Head = txtHead.Text;
        //            objBranch.IsCurrent = "";
        //            objBranch.BranchName = txtName.Text;
        //            BLL.BranchHandler.createBranch(objBranch);
        //            UICommon.WinForm.showStatus("Branch Created Successfuly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            clear();
        //            ADGVBranchMaster.Refresh();

        //        }
        //        //else
        //        //{
        //        //    UICommon.WinForm.showStatus("Branch not Created", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        //}
        //    }

        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Equals("Branch Already Created with this name"))
        //        {
        //            UICommon.WinForm.showStatus("Branch Already Created with this name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            clear();
        //        }

        //        else

        //        {
        //            UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //        }
        //    }
        //}

        public void clear()
        {
            txtName.Text = "";
            txtHead.Text = "";
            txtAddress.Text = "";
        
        }
            
        public bool ValidateDetails()
        {
            if (txtName.Text == "" || txtName.Text.Trim()=="" ) 
            {
                UICommon.WinForm.showStatus("Please Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
              
                txtName.Focus();
                return false;
            }
            else if(txtAddress.Text == "")
            {
                UICommon.WinForm.showStatus("Please Enter Address", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
               
                txtAddress.Focus();
                return false;
            }
           else if (string.IsNullOrWhiteSpace(txtName.Text) && txtName.Text.Length > 0)
            {
                UICommon.WinForm.showStatus("Please Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                txtName.Focus();
                return false;
            }
            return true;
        }

        internal static object getCurrentBranch()
        {
            return BLL.BranchHandler.getBranch(Properties.Settings.Default.BranchId);
        }

       
        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<Branch> lstbranch = new List<Branch>();
        //        lstbranch  =ADGVBranchMaster.DataSource as List<Branch>;
           
        //        foreach (Info.Branch objBranch in lstbranch)
        //        {
        //            BLL.BranchHandler.updateBranchMaster(objBranch);
        //        }
        //            UICommon.WinForm.showStatus("Branch details updated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private void ADGVBranchMaster_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ADGVBranchMaster.Columns[0].ReadOnly=true;
            foreach (DataGridViewRow adrow in ADGVBranchMaster.Rows)
            {

                adrow.Height = 30;
                adrow.MinimumHeight = 30;

            }

            ADGVBranchMaster.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ADGVBranchMaster.DataSource = WinForm.ToDataTable(BLL.BranchHandler.getAllBranches());

        }

        private void ADGVBranchMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVBranchMaster,e);
        }

        private void FrmBranchMaster_Load(object sender, EventArgs e)
        {
            try
            {
                AssignEvents();

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
                        //chkAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnCreate.Visible = false;
                        //tabPage1.Hide();
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                //  List<Branch> lstbranch = new List<Branch>();
                DataTable dt = new DataTable();
                dt = ADGVBranchMaster.DataSource as DataTable;
                Info.Branch objBranch = new Branch();
                // DataTable branch = new DataTable();
                // branch = ADGVBranchMaster.DataSource as DataTable;

                foreach (DataRow dr in dt.Rows)
             
                {
                    objBranch.BranchId = Convert.ToInt16(dr[0]);
                    objBranch.BranchName = dr[1].ToString();
                    objBranch.Address = dr[2].ToString();
                    objBranch.Head =dr[3].ToString() ;
                    BLL.BranchHandler.updateBranchMaster(objBranch);
                }
                UICommon.WinForm.showStatus("Branch details updated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Procedure or function 's_pr_update_branch_master' expects parameter '@Name', which was not supplied."))
                {
                    UICommon.WinForm.showStatus("Branch Name Cannot be Blank", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetails())
                {
                    Info.Branch objBranch = new Info.Branch();

                    objBranch.Address = txtAddress.Text;
                    objBranch.Head = txtHead.Text;
                    objBranch.IsCurrent = "";
                    objBranch.BranchName = txtName.Text;
                    BLL.BranchHandler.createBranch(objBranch);
                    UICommon.WinForm.showStatus("Branch Created Successfuly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clear();
                    ADGVBranchMaster.Refresh();

                }
                //else
                //{
                //    UICommon.WinForm.showStatus("Branch not Created", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                //}
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Branch Already Created with this name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Branch Already Created with this name"))
                {
                    UICommon.WinForm.showStatus("Branch Already Created with this name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clear();
                }

                else

                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }
    }
}
