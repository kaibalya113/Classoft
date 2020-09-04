using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;
using ClassManager.WinApp.UICommon;
using System.Windows.Forms;
using System.Reflection;
using ClassManager.Common;

namespace ClassManager.WinApp.Gym
{
    public partial class FrmEnquiries : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "All Enquiry Details";
        DataTable dtEnquiries;DataTable dt;


        public FrmEnquiries()
        {
            InitializeComponent();
        }

        private void ShowAllEnquiries_Load(object sender, EventArgs e)
        {

          
            SGStudents.RowTemplate.MinimumHeight = 25;
            SGStudents.RowTemplate.Height = 25;
            SGStudents.bs.PositionChanged += pageChanged;

            if (chkBranchID.Checked)
            {
                branchID = "%";
            }
            else
            {
                branchID = Program.LoggedInUser.BranchId.ToString();
            }
            addColumns();
            dtEnquiries = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
         
            SGStudents.PageSize = 25;
            SGStudents.SetPagedDataSource(dtEnquiries, bindingNavigator1);
            
            AssignEvents();
            getcount(dtEnquiries);
            cmbViewEnquiry.SelectedIndex = 1;
            formatdate();
            ApplyPrevileges();
            this.Width = 1040;
            this.Height = 666;
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(m => m.FunctionId == functionId).Where(w => w.BranchId.ToString() == branchID).FirstOrDefault();
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(pr => pr.BranchId == Program.LoggedInUser.BranchId).Where(se => se.FunctionId == functionId).FirstOrDefault();
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
                        btnNewEnquiry.Visible = false;
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

        private void formatdate()
        {
            UICommon.WinForm.setDate(dtpFrmDtEnq, dtpToDteEnq);
            UICommon.WinForm.formatDateTimePicker(dtpToDteEnq);
            UICommon.WinForm.formatDateTimePicker(dtpFrmDtEnq);
        }

        public void formatEnquiryGrid()
        {
            try
            {
                //Hide & disable unnecessary columns
                // ADGVEnquiries.Columns["ENQ_ID"].Visible = false;
                SGStudents.Columns["Counselor"].Visible =true;
                SGStudents.Columns["Batch"].Visible = false;
                SGStudents.Columns["ENQ_BATCH_ID"].Visible = false;
               // SGStudents.Columns["SbtnEdit"].Visible = false;
                SGStudents.Columns["Qualification"].Visible = false;
                SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false;
                SGStudents.Columns["Remark"].Visible = true;
                SGStudents.Columns["Counselor"].Visible = false;
                SGStudents.Columns["Subjects"].Visible = false;
                SGStudents.Columns["Priority"].Visible = true;
                SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false;
                SGStudents.Columns["ENQ_PARENT_CONTACT"].Visible = false;
                //Set Column Headers
                SGStudents.Columns["ENQ_ID"].HeaderText = "Enquiry No";
                SGStudents.Columns["ENQ_ADDRESS"].HeaderText = "Address";
                SGStudents.Columns["ENQ_CONTACT_NO"].HeaderText = "Contact No";
                SGStudents.Columns["ENQ_DOB"].HeaderText = "DOB";
                SGStudents.Columns["ENQ_DATE"].HeaderText = "EnquiryDate";
                SGStudents.Columns["ENQ_EMAIL"].HeaderText = "Email";
			   	SGStudents.Columns["Branchname"].HeaderText = "Branch";
                SGStudents.Columns["Branchname"].Visible = false; 
                SGStudents.Columns["ENQ_IS_REGISTERED"].HeaderText = "Registered";
                SGStudents.Columns["STD_NAME"].HeaderText = "PackageType";
                SGStudents.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";
				SGStudents.Columns["STRM_NAME"].HeaderText = "Package";
                SGStudents.Columns["STRM_NAME"].Visible = false;
                // ADGVEnquiries.Columns["ENQ_PARENT_CONTACT"].Headertext = "Father Contact";
                SGStudents.Columns["ENQ_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["ENQ_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;

                //Ordering Columns.
                SGStudents.Columns["ENQ_ID"].DisplayIndex = 3;
                SGStudents.Columns["ENQ_DATE"].DisplayIndex = 4;
                SGStudents.Columns["Name"].DisplayIndex = 5;

               
                SGStudents.Columns["STD_NAME"].DisplayIndex = 6;
                SGStudents.Columns["ENQ_CONTACT_NO"].DisplayIndex = 7;
                SGStudents.Columns["ENQ_ADDRESS"].DisplayIndex = 8;
                SGStudents.Columns["ENQ_EMAIL"].DisplayIndex = 9;
                SGStudents.Columns["Branchname"].DisplayIndex = 10;
                SGStudents.Columns["ENQ_IS_REGISTERED"].DisplayIndex = 11;
                SGStudents.Columns["Remark"].DisplayIndex = 12;
                SGStudents.Columns["ENQ_DOB"].DisplayIndex = 13;
                SGStudents.Columns["Priority"].DisplayIndex = 14;
                SGStudents.Columns["Referred By"].DisplayIndex = 15;
                SGStudents.Columns["STRM_NAME"].DisplayIndex = 16;
                SGStudents.Columns["Prev_FollowUp"].Visible = false;


                SGStudents.Columns["ENQ_ID"].ReadOnly = true;
                SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                SGStudents.Columns["STD_NAME"].ReadOnly = true;
                SGStudents.Columns["Branchname"].ReadOnly = true;
                SGStudents.Columns["ENQ_IS_REGISTERED"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                SGStudents.Columns["FollowUps"].DisplayIndex = SGStudents.Columns.Count - 2;
                SGStudents.Columns["Delete"].DisplayIndex = SGStudents.Columns.Count -1;
                SGStudents.Sort(SGStudents.Columns["ENQ_DATE"], ListSortDirection.Descending);
               
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
               
                SGStudents.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.deleteBin,

                    Name = "Delete",
                    HeaderText = "Delete"
                });

                SGStudents.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.eye,
                    Name = "FollowUps",
                    HeaderText = "View FollowUp"
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getcount(DataTable dt)
        {

            DataView dataView = dt.AsDataView();
            dataView.RowFilter = "([ENQ_IS_REGISTERED] IN ('Yes'))";
            lblActive.Text = (from DataRow dRow in dataView.ToTable().Rows
                              select dRow["ENQ_ID"]).Distinct().Count().ToString();


            dataView.RowFilter = "([Priority] <> 'Not Interested' and [ENQ_IS_REGISTERED] = 'No')";
            lblInactive.Text = (from DataRow dRow in dataView.ToTable().Rows
                                select dRow["ENQ_ID"]).Distinct().Count().ToString();

            dataView.RowFilter = "([ENQ_IS_REGISTERED] IN ('Yes','No'))";
            lblAll.Text = (from DataRow dRow in dataView.ToTable().Rows
                           select dRow["ENQ_ID"]).Distinct().Count().ToString();


            dataView.RowFilter = "([Priority] = 'Not Interested' and [ENQ_IS_REGISTERED] = 'No')";
            lblNotIntrst.Text = (from DataRow dRow in dataView.ToTable().Rows
                           select dRow["ENQ_ID"]).Distinct().Count().ToString();
        }

        private void AssignEvents()
        {
            txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtEnqNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            SGStudents.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            SGStudents.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }



        private void txtEnqNo_TextChanged(object sender, EventArgs e)
       {
            try
            {
                if (txtEnqNo.Text.Length > 0)
                {
                    IndexSelection(cmbViewEnquiry.SelectedIndex);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    // bs.Filter = ADGVEnquiries.Columns[2].HeaderText.ToString() + "" + Convert.ToInt32(txtEnqNo.Text) + "";
                    bs.Filter = "ENQ_ID = " + Convert.ToInt32(txtEnqNo.Text) + "";
                    SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(),bindingNavigator1);
                }
                else
                {

                    BindingSource bs = new BindingSource();
                    IndexSelection(cmbViewEnquiry.SelectedIndex);
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            try
            {

                IndexSelection(cmbViewEnquiry.SelectedIndex);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                bs.Filter = string.Format("Name LIKE '%{0}%'", txtFname.Text);
                SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(),bindingNavigator1);   
                if (bs.Filter == "Name LIKE '%%'")
                {
                    IndexSelection(cmbViewEnquiry.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        
        private void cmbViewEnquiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IndexSelection(cmbViewEnquiry.SelectedIndex);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void IndexSelection(int index)
        {
            try
            {
                branchID = Program.LoggedInUser.BranchId.ToString();

                BindingSource bs = new BindingSource();
                bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);

                switch (cmbViewEnquiry.SelectedIndex)
                {
                    case 0:
                        bs.Filter = "ENQ_IS_REGISTERED in ('Yes', 'No')";
                        break;
                    case 1:
                        bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                        break;
                    case 2:
                        bs.Filter = "ENQ_IS_REGISTERED = 'Yes'";
                        break;
                    case 3:
                        bs.Filter = "Priority='High'and ENQ_IS_REGISTERED = 'No'";
                        break;
                    case 4:
                        bs.Filter = "Priority='Mid'and ENQ_IS_REGISTERED = 'No'";
                        break;
                    case 5:
                        bs.Filter = "Priority='Low'and ENQ_IS_REGISTERED = 'No'";
                        break;
                    case 6:
                        bs.Filter = "Priority='Not Interested' and ENQ_IS_REGISTERED = 'No'";
                        break;
                }
                dt = (bs.List as DataView).ToTable(); ;
                SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(),bindingNavigator1);

                SGStudents.PageSize = 25;
                SGStudents.SetPagedDataSource(dt, bindingNavigator1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        private void dtpFrmDtEnq_CloseUp(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dtpToDteEnq_CloseUp(object sender, EventArgs e)
        {
            LoadGrid();
        }

        public void LoadGrid()
        {
            try
            {
                if (dtpFrmDtEnq.Value < dtpToDteEnq.Value)
                {


                    string Fromdate = dtpFrmDtEnq.Value.ToShortDateString();
                    string Todate = dtpToDteEnq.Value.ToShortDateString();

                    dtEnquiries = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1, Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate));
                    SGStudents.SetPagedDataSource(dtEnquiries,bindingNavigator1);
                    AssignEvents();
                    getcount(dtEnquiries);
                    cmbViewEnquiry.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("From Date Cannot be Greater", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        

        private void btnNewEnquiry_Click(object sender, EventArgs e)

        {
            try
            {

                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                string[] assmbly = { appName };
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmEnquiryEntryForm, null, false, assmbly).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                formatEnquiryGrid();
                if (SGStudents.Rows.Count != 0)
                {

                    Common.ImportExport.ImportToExcel(SGStudents, null);
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

   



        private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (SGStudents.Rows.Count != 0)
                {
                    if (HelpPanel.Visible == false)
                    {
                        HelpPanel.Visible = true;
                    }
                    else
                    {
                        HelpPanel.Visible = false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SGStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 0)
                {
                    if (formPrevileges.Delete == false)
                    {
                        UICommon.WinForm.showStatus("You don't have permission to Update the Detials, Please contact admin", sCaption, this);
                        return;
                    }
                }
                if (e.RowIndex != -1)
                {
                    if (SGStudents.Columns.Contains("Delete") && e.ColumnIndex == SGStudents.Columns["Delete"].Index)
                    {
                        var sure = MessageBox.Show("Do you Want to Delete " + SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString().Trim(), "Details", MessageBoxButtons.YesNo);

                        if (sure == DialogResult.Yes)
                        {
                            BLL.EnquiryHandller.DeleteEnquiry((Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value)), SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString(), SGStudents.Rows[e.RowIndex].Cells["ENQ_CONTACT_NO"].Value.ToString(), Convert.ToInt32(branchID));
                            UICommon.WinForm.showStatus("Deleted Sucessfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);


                            BindingSource bs = new BindingSource();
                            bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                            bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                            DataTable data = (bs.List as DataView).ToTable(); 
                           
                            SGStudents.PageSize = 25;
                            SGStudents.SetPagedDataSource(data, bindingNavigator1);

                        }
                    }
                
            }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);

            }
        }

        private void SGStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataTable dt = null;
                    if (SGStudents.Columns.Contains("FollowUps") && e.ColumnIndex == SGStudents.Columns["FollowUps"].Index)
                    {
                        if (SGStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                        {
                           
                            pnlViewFollowUp.Visible = true;
                            AdgvViewFolow.Visible = true;
                            BtnCancel.Visible = true;
                            this.Width = 1299;
                            this.Height = 646;
                            int EnqID = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                            dt = BLL.FollowupHandler.viewFollowUp(EnqID);
                            AdgvViewFolow.DataSource = dt;

                        }
                    }


                    else if (SGStudents.Columns.Contains("btnEdit") && e.ColumnIndex == SGStudents.Columns["btnEdit"].Index)
                    {
                        string[] name = { "Gym" };
                        // Gym.FrmEnquiryEntryForm objEnqUpdate = (Gym.FrmEnquiryEntryForm)UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm, this, true);
                        FrmEnquiryEntryForm objEnqUpdate = (FrmEnquiryEntryForm)UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm, this, true, name, null);
                        objEnqUpdate.setValuesForUpdate(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                        objEnqUpdate.ShowDialog();
                       
                        getcount(dtEnquiries);
                        cmbViewEnquiry.SelectedIndex = 1;

                        BindingSource bs = new BindingSource();
                        bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                        bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";

                        SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(),bindingNavigator1);
                        this.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void SGStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                formatEnquiryGrid();
 
               
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void SGStudents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(SGStudents, e);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SGStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BtnCancel.Visible = false;
                pnlViewFollowUp.Visible = false;
                AdgvViewFolow.Visible = false;
                this.Width = 1040;
                this.Height = 666;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AdgvViewFolow_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow adrow in AdgvViewFolow.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

              
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AdgvViewFolow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(AdgvViewFolow, e);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
         }


        private void pageChanged(object sender, EventArgs e)
        {
            formatRows();
        }

        private void formatRows()
        {
            int pageNo = SGStudents.bs.Position;


            foreach (DataGridViewRow row in SGStudents.Rows)
            {
                if (row.Cells["Priority"].Value.ToString().Trim().Equals("Mid"))
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF176");
                }
                else if (row.Cells["Priority"].Value.ToString().Trim().Equals("High"))
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EF9A9A");
                }
                else if (row.Cells["Priority"].Value.ToString().Trim().Equals("Low"))
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#AED581");
                }

                row.Height = 30;
                row.MinimumHeight = 30;
            }
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFname.Text.ToString();
                getParameter.EnqNo = "EnqNo:- " + txtEnqNo.Text.ToString();
              
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Enquiry Report";
                getParameter.BranchName = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
           //     getParameter.GroupBy = "GroupBy:- " + cmbGroupBy.SelectedItem.ToString();
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (SGStudents.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Enquiry Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(SGStudents, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
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
  

