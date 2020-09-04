using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmRegistrationsView : Form
    {

        RolePrivilege formPrevileges;


        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption ="Show All Registered Student";

        public FrmRegistrationsView()
        {
            InitializeComponent();
        }

        private void ShowAllRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'herambCCDataSet1.Registration' table. You can move, or remove it, as needed.
                //  this.registrationTableAdapter.Fill(this.herambCCDataSet1.Registration,branchID.ToString());

                //cmbStream.DataSource = StreamHandller.getStreams();
                AssignEvents();
                ADGVRegistration.DataSource = BLL.StudentHandller.AllRegistered(branchID);

                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, null);
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



        private void AssignEvents()
        {
            ADGVRegistration.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVRegistration.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
            BindingSource bs = new BindingSource();
            bs.DataSource = ADGVRegistration.DataSource;
            bs.Filter = ADGVRegistration.Columns[2].HeaderText.ToString() + " LIKE '%" + textBox1.Text + "%'";
            ADGVRegistration.DataSource = bs;
            }
            catch (Exception ex)
            {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
  

        private void btnSave_Click(object sender, EventArgs e)
        {
            try{
            Common.ImportExport.ImportToExcel(ADGVRegistration,null);
             }
            catch (Exception ex)
            {
                
                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved.,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (WinApp.Program.LoggedInUser.Type == "A")
                {
                    if (chkBranchID.Checked)
                    {
                        branchID = "%";
                    }
                    else
                    {
                        branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

                    }
                    ADGVRegistration.DataSource = BLL.StudentHandller.AllRegistered(branchID);

                }
                else
                {
                    UICommon.WinForm.showStatus("No permission to show all branches record", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

            }
            catch (Exception ex)
            {
                 UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void ADGVRegistration_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVRegistration,e);
        }
    }
}

