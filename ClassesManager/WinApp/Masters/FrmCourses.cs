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
    public partial class FrmCourses : FrmParentForm
    {
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        RolePrivilege formPrevileges;

        string sCaption=" All Course Details";
        public FrmCourses()
        {
            InitializeComponent();
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
                        chkBranchID.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                      
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnNewCourse.Visible = false;
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


        private void ShowAllCourses_Load_1(object sender, EventArgs e)
        {
            try
            {
                ADGVCourses.DataSource = BLL.StreamHandller.getCourses(branchID);
                AssignEvents();
                ApplyPrevileges();
            }
            catch(Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }



        private void AssignEvents()
        {
            ADGVCourses.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVCourses.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            txtCrseNm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);

        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ADGVCourses.Rows.Count != 0)
        //        {
        //            Common.ImportExport.ImportToExcel(ADGVCourses);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //         UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }
        //}



        private void txtCrseNm_TextChanged(object sender, EventArgs e)
       {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ADGVCourses.DataSource;
                bs.Filter = ADGVCourses.Columns[1].HeaderText.ToString() + " LIKE '%" + txtCrseNm.Text.ToString() + "%'";
                ADGVCourses.DataSource = bs;

            }
            catch (Exception ex)
            {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

  

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranchID.Checked)
            {

                branchID = "%";
            }
            else
            {
                branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
               
            }
            ADGVCourses.DataSource = BLL.StreamHandller.getCourses(branchID);
        }

       
        private void ADGVCourses_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVCourses,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
     
            try
            {
                if (ADGVCourses.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVCourses,null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnNewCourse_Click(object sender, EventArgs e)
        {
          try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmStandardMasterForm).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVCourses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVCourses.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

               ADGVCourses.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            }
            
            catch (Exception)
            {

                throw;
            }
        }
    }
    }

