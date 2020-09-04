using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmPackagesView :FrmParentForm
    {

        RolePrivilege formPrevileges;

        string sCaption = "Package";
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        public FrmPackagesView()
        {
            InitializeComponent();
        }

        private void ShowPackage_Load(object sender, EventArgs e)
        {
            try
            {
                addColumns();
                ADGVPackage.DataSource = BLL.FeesPackageHandller.GetPackagesInBranch(branchID);
                AssignEvents();

                ApplyPrevileges();
            }
            catch(Exception ex)
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {
                        chkBranchID.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnNewPackage.Visible = false;
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


        private void addColumns()
        {
            try
            {
                DataGridViewButtonColumn newFollowupButtonColumn = new DataGridViewButtonColumn();
                newFollowupButtonColumn.Name = "view_details";
                newFollowupButtonColumn.Text = "Details";
                newFollowupButtonColumn.HeaderText = "Package";
                newFollowupButtonColumn.DefaultCellStyle.NullValue = "Edit";

                if (ADGVPackage.Columns["view_details"] == null)
                {
                    ADGVPackage.Columns.Insert(0, newFollowupButtonColumn);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AssignEvents()
        {
            ADGVPackage.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVPackage.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ADGVPackage.DataSource;
                bs.Filter = ADGVPackage.Columns["PackageName"].HeaderText.ToString() + " LIKE '%" + textBox1.Text + "%'";
                ADGVPackage.DataSource = bs;

            }
            catch (Exception ex)
            {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVPackage.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVPackage,null);
                }
                else 
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBranchID.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                }
                ADGVPackage.DataSource = BLL.FeesPackageHandller.GetPackagesInBranch(branchID);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }      
        }

        private void btnNewPackage_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmSubjectPackageMasterForm).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ADGVPackage.Columns["view_details"].Index)
                    {
                        if (formPrevileges != null)
                        {
                            if (formPrevileges.Delete == false)
                            {
                                UICommon.WinForm.showStatus("You don't have permission to Edit the Package, Please contact admin", sCaption, this);
                                return;
                            }
                        }
                        FrmSubjectPackageMasterForm frmPkgMstr = UICommon.FormFactory.GetForm(UICommon.Forms.FrmSubjectPackageMasterForm, null, false) as FrmSubjectPackageMasterForm;
                        frmPkgMstr.setPackage(Convert.ToInt32(ADGVPackage.Rows[e.RowIndex].Cells["FPKG_ID"].Value));
                        frmPkgMstr.Visible = true;
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
      
        private void ADGVPackage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatPackageViewGrid();
                foreach (DataGridViewRow adrow in ADGVPackage.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVPackage.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        public void formatPackageViewGrid()
        {
            try
            {
                //Hiding Columns
                ADGVPackage.Columns["FPKG_ID"].Visible = false;
                ADGVPackage.Columns["STD_BRANCH_ID"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVPackage_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVPackage, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
          
        }
    }
}
