using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmEnquiryReport : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "All Enquiry Details";
        DataTable dtEnquiries; DataTable dt;
        int EnquiryId;
        string Status;
        public FrmEnquiryReport()
        {
            InitializeComponent();
        }

        private void FrmEnquiryReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Enquiry";
                ApplyPrevileges();
                //loadfieds method is used to load parameters added in   cmb_Followpby
                loadFields();
                SGStudents.RowTemplate.MinimumHeight = 25;
                SGStudents.RowTemplate.Height = 25;

                AdgvViewFolow.RowTemplate.MinimumHeight = 25;
                AdgvViewFolow.RowTemplate.Height = 25;

                AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                branchID = Program.LoggedInUser.BranchId.ToString();
                addColumns();
                dtEnquiries = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
                SGStudents.PageSize = 25;
                SGStudents.SetPagedDataSource(dtEnquiries, bindingNavigator1);
                SGStudents.bs.PositionChanged += pageChanged;
                AssignEvents();
                getcount(dtEnquiries);
               

                cmbViewEnquiry.SelectedIndex = 1;
                HelpPanel.Visible = true;
                
                PanelFollowUp.Visible = false;
                this.Width = 940;
                this.Height = 646;
                formatRows();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        //load parameters in cmb_followBy combobox in AdgvViewFolow
        private void loadFields()
        {

            string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
            if (check == "")
            {
                cmb_Followpby.Visible = false;
                //  lblBrnch.Visible = false;
            }
            else
            {
                string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                foreach (String value in items)
                {
                   cmb_Followpby.Items.Add(value);
                }
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

        private void addColumns()
        {
            try
            {
               
                 SGStudents.Columns.Add(new DataGridViewImageColumn()
           
                {
                    Image = Properties.Resources.Add,
                    Name = "new_followup",
                    HeaderText = "Add FollowUp"
                 });
              

                SGStudents.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.eye,
                 
                    Name = "FollowUps",
                    HeaderText = "View FollowUp"
                });
                SGStudents.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.deleteBin,

                    Name = "Delete",
                    HeaderText = "Delete"
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
           

            dataView.RowFilter = "([Priority] <> 'Not Interested' and [ENQ_IS_REGISTERED] = 'No')";
            lblInactive.Text = (from DataRow dRow in dataView.ToTable().Rows
                                select dRow["ENQ_ID"]).Distinct().Count().ToString();

         
        }

        private void AssignEvents()
        {
            txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtEnqNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            SGStudents.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            SGStudents.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        public void formatEnquiryGridForPdf()
        {
            try
            {
                if (SGStudents.Columns.Contains("ENQ_STATE"))
                {
                    SGStudents.Columns["ENQ_STATE"].Visible = true;
                    SGStudents.Columns["ENQ_STATE"].HeaderText = "Status";
                    SGStudents.Columns["ENQ_STATE"].DisplayIndex = 8;
                }
                //Hide & disable unnecessary columns
                // ADGVEnquiries.Columns["ENQ_ID"].Visible = false;
                SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false;
                SGStudents.Columns["Priority"].Visible = false;
                SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false;
                // SGStudents.Columns["Remark"].Visible = false;

                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString() == "")
                {
                    SGStudents.Columns["Counselor"].Visible = false;
                    SGStudents.Columns["Batch"].Visible = false;
                    SGStudents.Columns["ENQ_BATCH_ID"].Visible = false;
                    SGStudents.Columns["ENQ_PARENT_CONTACT"].HeaderText = "Parent Contact";
                    SGStudents.Columns["Qualification"].Visible = false;
                }
                else
                {
                    SGStudents.Columns["Counselor"].Visible = false;
                    SGStudents.Columns["Batch"].Visible = false;
                    SGStudents.Columns["ENQ_BATCH_ID"].Visible = false;
                    SGStudents.Columns["ENQ_PARENT_CONTACT"].HeaderText = "Parent Contact";
                }
                SGStudents.Columns["Subjects"].Visible = false;
                //Set Column Headers
                SGStudents.Columns["ENQ_ID"].HeaderText = "Enquiry No";
                SGStudents.Columns["ENQ_ADDRESS"].HeaderText = "Address";
                SGStudents.Columns["ENQ_CONTACT_NO"].HeaderText = "Mobile No";
                SGStudents.Columns["ENQ_DOB"].HeaderText = "DOB";
                SGStudents.Columns["ENQ_DATE"].HeaderText = "EnquiryDate";
                SGStudents.Columns["ENQ_EMAIL"].HeaderText = "Email";
                SGStudents.Columns["Branchname"].HeaderText = "Branch";
                SGStudents.Columns["ENQ_IS_REGISTERED"].HeaderText = "Registered";
                SGStudents.Columns["STD_NAME"].HeaderText = "Course";
                SGStudents.Columns["STRM_NAME"].HeaderText = "Stream";
                SGStudents.Columns["Prev_FollowUp"].HeaderText = "Prev Followup";
                SGStudents.Columns["Prev_FollowUp"].ReadOnly = true;
                SGStudents.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";

                SGStudents.Columns["ENQ_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["ENQ_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["Prev_FollowUp"].Width = 200;
                //Ordering Columns.
                SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                SGStudents.Columns["ENQ_DOB"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                SGStudents.Columns["Name"].DisplayIndex = 3;
                SGStudents.Columns["Name"].ReadOnly = true;
                SGStudents.Columns["STD_NAME"].DisplayIndex = 4;
                SGStudents.Columns["ENQ_CONTACT_NO"].DisplayIndex = 5;
                SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                SGStudents.Columns["Prev_FollowUp"].DisplayIndex = 6;
                SGStudents.Columns["Remark"].DisplayIndex = 7;
                SGStudents.Columns["Qualification"].Visible = false;
                SGStudents.Columns["ENQ_ADDRESS"].Visible = false;
                SGStudents.Columns["ENQ_EMAIL"].Visible = false;
                SGStudents.Columns["Branchname"].Visible = false;
                SGStudents.Columns["ENQ_IS_REGISTERED"].Visible = false;
                SGStudents.Columns["ENQ_ID"].Visible = false;
                SGStudents.Columns["ENQ_DATE"].Visible = false;
                SGStudents.Columns["ENQ_DOB"].Visible = false;
                SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false;
                SGStudents.Columns["STRM_NAME"].Visible = false;
                SGStudents.Columns["ENQ_EMAIL"].Visible = false;
                SGStudents.Columns["STD_NAME"].Visible = true;
                SGStudents.Columns["Referred By"].Visible = false;
                SGStudents.Columns["ENQ_PARENT_CONTACT"].Visible = false;
                // SGStudents.Columns["Counselor"].DisplayIndex = 14;
                SGStudents.Columns["Subjects"].Visible = false;
                SGStudents.Columns["Remark"].Visible = true;
                SGStudents.Columns["Remark"].ReadOnly = true;
                SGStudents.Columns["ENQ_ID"].ReadOnly = true;
                SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                SGStudents.Columns["STD_NAME"].ReadOnly = true;
                SGStudents.Columns["Branchname"].ReadOnly = true;
                SGStudents.Columns["ENQ_IS_REGISTERED"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                SGStudents.Sort(SGStudents.Columns["ENQ_DATE"], ListSortDirection.Descending);

                SGStudents.Columns["SbtnEdit"].Visible = false; ;
                SGStudents.Columns["EditImage"].DisplayIndex = SGStudents.Columns.Count - 4;
                SGStudents.Columns["new_followup"].DisplayIndex = SGStudents.Columns.Count - 2;
                SGStudents.Columns["FollowUps"].DisplayIndex = SGStudents.Columns.Count - 3;
                SGStudents.Columns["Delete"].DisplayIndex = SGStudents.Columns.Count - 1;
                SGStudents.Columns["FollowUps"].Width = 75;
                SGStudents.Columns["new_followup"].Width = 75;
                SGStudents.Columns["Delete"].Width = 60;
                SGStudents.Columns["EditImage"].Width = 60;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void formatEnquiryGrid()
        {
            try
            {
			    if(SGStudents.Columns.Contains("ENQ_STATE"))
                {
                    SGStudents.Columns["ENQ_STATE"].Visible = false;
                }
                //Hide & disable unnecessary columns
                // ADGVEnquiries.Columns["ENQ_ID"].Visible = false;
                SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false;
                SGStudents.Columns["Priority"].Visible = false;
                SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false;
               // SGStudents.Columns["Remark"].Visible = false;

                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString() == "")
                {
                    SGStudents.Columns["Counselor"].Visible = false;
                    SGStudents.Columns["Batch"].Visible = false;
                    SGStudents.Columns["ENQ_BATCH_ID"].Visible = false;
                    SGStudents.Columns["ENQ_PARENT_CONTACT"].HeaderText = "Parent Contact";
                    SGStudents.Columns["Qualification"].Visible = false;
                    SGStudents.Columns["ENQ_PARENT_CONTACT"].DisplayIndex = 6;
                    SGStudents.Columns["ENQ_PARENT_CONTACT"].ReadOnly = true;
                }
                else
                {
                    SGStudents.Columns["Counselor"].Visible = false;
                    SGStudents.Columns["Batch"].Visible = false;
                    SGStudents.Columns["ENQ_BATCH_ID"].Visible = false;
                    SGStudents.Columns["ENQ_PARENT_CONTACT"].Visible = false; ;
                }
                SGStudents.Columns["Subjects"].Visible = false;
                //Set Column Headers
                SGStudents.Columns["ENQ_ID"].HeaderText = "Enquiry No";
                SGStudents.Columns["ENQ_ADDRESS"].HeaderText = "Address";
                SGStudents.Columns["ENQ_CONTACT_NO"].HeaderText = "Mobile No";
                SGStudents.Columns["ENQ_DOB"].HeaderText = "DOB";
                SGStudents.Columns["ENQ_DATE"].HeaderText = "EnquiryDate";
                SGStudents.Columns["ENQ_EMAIL"].HeaderText = "Email";
                SGStudents.Columns["Branchname"].HeaderText = "Branch";
                SGStudents.Columns["ENQ_IS_REGISTERED"].HeaderText = "Registered";
                SGStudents.Columns["STD_NAME"].HeaderText = "Course";
                SGStudents.Columns["STRM_NAME"].HeaderText = "Stream";
                SGStudents.Columns["Prev_FollowUp"].HeaderText = "Prev Followup";
                SGStudents.Columns["Prev_FollowUp"].ReadOnly = true;
               // SGStudents.Columns["Prev_FollowUp"].Width = ;
                SGStudents.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";

                SGStudents.Columns["ENQ_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["ENQ_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["Prev_FollowUp"].Width = 150;
                //Ordering Columns.
                SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                SGStudents.Columns["ENQ_DOB"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                SGStudents.Columns["Name"].DisplayIndex = 3;
                SGStudents.Columns["Name"].ReadOnly = true;
                SGStudents.Columns["STD_NAME"].DisplayIndex = 4;
                SGStudents.Columns["ENQ_CONTACT_NO"].DisplayIndex = 5;
                SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                SGStudents.Columns["Prev_FollowUp"].DisplayIndex = 7;
                SGStudents.Columns["Remark"].DisplayIndex = 8;
                SGStudents.Columns["Qualification"].Visible = false;
                SGStudents.Columns["ENQ_ADDRESS"].Visible = false;
                SGStudents.Columns["ENQ_EMAIL"].Visible = false;
                SGStudents.Columns["Branchname"].Visible = false;
                SGStudents.Columns["ENQ_IS_REGISTERED"].Visible = false;
                SGStudents.Columns["ENQ_ID"].Visible = false;
                SGStudents.Columns["ENQ_DATE"].Visible = false;
                SGStudents.Columns["ENQ_DOB"].Visible = false;
                SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false;
                SGStudents.Columns["STRM_NAME"].Visible = false;
                SGStudents.Columns["ENQ_EMAIL"].Visible = false;
                SGStudents.Columns["STD_NAME"].Visible = true;
                SGStudents.Columns["Referred By"].Visible = false;
            // SGStudents.Columns["ENQ_PARENT_CONTACT"].Visible = false;
               // SGStudents.Columns["Counselor"].DisplayIndex = 14;
               SGStudents.Columns["Subjects"].Visible = false;
                SGStudents.Columns["Remark"].Visible = true;
                SGStudents.Columns["Remark"].ReadOnly = true;
                SGStudents.Columns["ENQ_ID"].ReadOnly = true;
                SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                SGStudents.Columns["STD_NAME"].ReadOnly = true;
                SGStudents.Columns["Branchname"].ReadOnly = true;
                SGStudents.Columns["ENQ_IS_REGISTERED"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                SGStudents.Sort(SGStudents.Columns["ENQ_DATE"], ListSortDirection.Descending);

                SGStudents.Columns["SbtnEdit"].Visible = false;
                SGStudents.Columns["SbtnEdit"].Width = 50;
                SGStudents.Columns["EditImage"].DisplayIndex = SGStudents.Columns.Count - 4;
                SGStudents.Columns["new_followup"].DisplayIndex = SGStudents.Columns.Count - 2;
                SGStudents.Columns["FollowUps"].DisplayIndex = SGStudents.Columns.Count - 3;
                SGStudents.Columns["Delete"].DisplayIndex = SGStudents.Columns.Count - 1;
                SGStudents.Columns["FollowUps"].Width = 50;
                SGStudents.Columns["new_followup"].Width =50;
                SGStudents.Columns["Delete"].Width = 50;
                SGStudents.Columns["EditImage"].Width = 60;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ApplyPrevileges()
        {
            try
            {
                int functionId = Convert.ToInt32(this.Tag.ToString());
                if (functionId != 0)
                {
                    formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                 
                    if (formPrevileges != null)
                    {
                        if (formPrevileges.AllBranches == false)
                        {
                           
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
            }
            catch (Exception ex)
            {
                throw ex;
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
                SGStudents.DataSource = bs;
                if(bs.Filter == "Name LIKE '%%'")
                {
                    IndexSelection(cmbViewEnquiry.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
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
                    SGStudents.DataSource = bs;
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
                SGStudents.DataSource = dt;

                SGStudents.PageSize = 25;
                SGStudents.SetPagedDataSource(dt, bindingNavigator1);
            }
            catch (Exception ex)
            {
                throw ex;
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
                    if (e.ColumnIndex == SGStudents.Columns["new_followup"].Index)
                    {
                        if (Convert.ToBoolean(SGStudents.Rows[e.RowIndex].Cells["ENQ_IS_REGISTERED"].Value.Equals("Yes")))
                        {
                            UICommon.WinForm.showStatus("Enquiry is closed as Member has already took admission", sCaption, this);
                        }
                        else
                        {
                            //UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUp).Visible = false;
                            branchID = SGStudents.Rows[e.RowIndex].Cells["ENQ_BRANCH_ID"].Value.ToString();
                            EnquiryId = (Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value));
                                pnlViewFollowUp.Visible = false;
                                BtnCancel.Visible = false;
                                AdgvViewFolow.Visible = false;
                                PanelFollowUp.Visible = true;
                                lblStudName.Text = SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                                this.Width = 1152;
                                this.Height = 646;
                            
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
                        {//adding column FollowupBy in AdgvViewFolow by Ashvini
                            

                            PanelFollowUp.Visible = false;
                            pnlViewFollowUp.Visible = true;
                            AdgvViewFolow.Visible = true;
                            BtnCancel.Visible = true;
                            this.Width = 1299;
                            this.Height = 646;
                            int EnqID = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                            dt = BLL.FollowupHandler.viewFollowUp(EnqID);
                            AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                            AdgvViewFolow.DataSource = dt;
                           
                        }
                    }
                    
                    else if (SGStudents.Columns.Contains("EditImage") && e.ColumnIndex == SGStudents.Columns["EditImage"].Index)
                    {
                        if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString() == "")
                        {
                            FrmEnquiryEntryForm EnqUpdate = (FrmEnquiryEntryForm)UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm, this, true);
                            EnqUpdate.setValuesForUpdate(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                            EnqUpdate.ShowDialog();
                        }
                        else
                        {
                            string[] name = { "Asset" };
                            WinApp.Asset.FrmEnquiryEntryForm objEnqUpdate = (WinApp.Asset.FrmEnquiryEntryForm)UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm, this, true, name, null);
                            objEnqUpdate.setValuesForUpdate(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                            objEnqUpdate.ShowDialog();
                        }

                        SGStudents.DataSource = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
                        getcount(dtEnquiries);
                        cmbViewEnquiry.SelectedIndex = 1;
                        BindingSource bs = new BindingSource();
                        bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                        bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                        SGStudents.DataSource = bs;
                        this.Visible = false;
                        this.Visible = true;

                    }
                    else if (SGStudents.Columns.Contains("Delete") && e.ColumnIndex == SGStudents.Columns["Delete"].Index)
                    {
                        var sure =  MessageBox.Show("Do you really want to delete an enquiry from " + SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString().Trim(), sCaption, MessageBoxButtons.YesNo);

                        if (sure == DialogResult.Yes)
                        {
                           BLL.EnquiryHandller.DeleteEnquiry((Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value)), SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString(), SGStudents.Rows[e.RowIndex].Cells["ENQ_CONTACT_NO"].Value.ToString(), Convert.ToInt32(branchID));
                            UICommon.WinForm.showStatus("Deleted Sucessfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);


                            BindingSource bs = new BindingSource();
                            bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                            bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                            DataTable data = (bs.List as DataView).ToTable(); ;
                            SGStudents.DataSource = data;

                            SGStudents.PageSize = 25;
                            SGStudents.SetPagedDataSource(data, bindingNavigator1);

                            pnlViewFollowUp.Visible = false;
                            AdgvViewFolow.Visible = false;
                            BtnCancel.Visible = false;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

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

        public bool validateFollowupDetails()
        {
            try
            {

                if (dtFollowup.Value.ToShortDateString() == System.DateTime.Now.ToShortDateString())
                {
                    UICommon.WinForm.showStatus("Next Followup-Date Should be greater than todays date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtFollowup.Focus();
                    return false;
                }
                else if(cmbMediam.SelectedItem == "" )
                {
                    UICommon.WinForm.showStatus("Select Medium for followup", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtFollowup.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void clearall()
        {
            try
            {
                cmbMediam.Text = "";
                txtDescription.Clear();
                dtFollowup.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void FolloupBy_Click(object sender, EventArgs e)
        {
             
            try
            {
                if (validateFollowupDetails())
                {
                    Followup objFollowup = new Followup();
                    objFollowup.ReferenceID = EnquiryId.ToString();
                    objFollowup.FollowupType = "Enquiry";
                    objFollowup.FollowupDate = dtFollowup.Value;
                    objFollowup.FollowupDesc = txtDescription.Text;
                    objFollowup.FollowupBy = (cmb_Followpby.SelectedIndex == -1 ? "NA" : cmb_Followpby.SelectedItem.ToString());
                    objFollowup.FollowupMediam = cmbMediam.Text;

                   BLL. FollowupHandler.SaveFollowup(objFollowup, branchID);

                    Enquiry objEnquiry = new Enquiry();
                 
                    UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearall();
                    PanelFollowUp.Visible = false;
                    this.Width = 962;
                    this.Height = 646;
                   
                    BindingSource bs = new BindingSource();
                    bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                    bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                    DataTable dt = (bs.List as DataView).ToTable(); ;
                    SGStudents.DataSource = dt;

                    SGStudents.PageSize = 25;
                    SGStudents.SetPagedDataSource(dt, bindingNavigator1);

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
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmEnquiryEntryForm).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void AdgvViewFolow_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {//added by ashvini 2-01-19 for proper formatting
                
                if (AdgvViewFolow.Columns.Contains("Description"))
                {

                    AdgvViewFolow.Columns["Description"].Width = 150;
                }
                if (AdgvViewFolow.Columns.Contains("Date"))
                {
                    AdgvViewFolow.Columns["Date"].HeaderText = "Next Followup";
                    AdgvViewFolow.Columns["Date"].Width = 80;
                }

                if (AdgvViewFolow.Columns.Contains("FOLU_BY"))
                {
                    AdgvViewFolow.Columns["FOLU_BY"].HeaderText = "Followup By";
                    AdgvViewFolow.Columns["FOLU_BY"].Width = 150;
                }

                if (AdgvViewFolow.Columns.Contains("FOLU_CRTD_AT"))
                {
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].HeaderText = "Followup On";
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].DisplayIndex = 4;
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].Width = 100;
                    AdgvViewFolow.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                }
                AdgvViewFolow.Columns["Date"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                AdgvViewFolow.Columns[1].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
               

                AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            }
            catch (Exception)
            {

                throw;
            }
            //end by ashvini 02-01-2019
        }

        private void AdgvViewFolow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(AdgvViewFolow, e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BtnCancel.Visible = false;
                pnlViewFollowUp.Visible = false;
                AdgvViewFolow.Visible = false;
                this.Width = 962;
                this.Height = 646;

            }
            catch (Exception)
            {

                throw;
            }


        }
        //added by ashvini on 30-03-2019

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {

            try
            {
                SGStudents.DataSource = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
                formatEnquiryGridForPdf();
           
                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFname.Text;
                getParameter.EnqNo = "EnqNo:- " + txtEnqNo.Text + "";
                getParameter.View = "View:- " + cmbViewEnquiry.SelectedItem.ToString();
           
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Enquiry Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

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

                        if (SGStudents.Columns.Contains("ENQ_STATE"))
                        {
                            SGStudents.Columns["ENQ_STATE"].Visible = false;

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }
        //end by ashvini on 30-03-2019
    }
}
