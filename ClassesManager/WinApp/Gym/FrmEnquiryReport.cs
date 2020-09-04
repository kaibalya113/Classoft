using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassManager.WinApp.UICommon;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.Common;

namespace ClassManager.WinApp.Gym
{
    public partial class FrmEnquiryReport : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "All Enquiry Details";
        DataTable dtEnquiries; DataTable dt;
        int EnquiryId;

        /// <>
        /// 
        /// </summary>
        public FrmEnquiryReport()
        {
            InitializeComponent();
        }

        #region Events
        private void FrmEnquiryReport_Load(object sender, EventArgs e)
        {
            try
            {
                //adding for proper format of date by ashvini
                UICommon.WinForm.formatDateTimePicker(dtFollowup);

                //loadfieds method is used to load parameters added in  cmb_followBy
                loadFieldsOfFollowby();

                SGStudents.RowTemplate.MinimumHeight = 25;
                SGStudents.RowTemplate.Height = 25;
                branchID = Program.LoggedInUser.BranchId.ToString();
                addColumns();

                dtEnquiries = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
                getcount(dtEnquiries);
                SGStudents.bs.PositionChanged += pageChanged;
                AssignEvents();              
                HelpPanel.Visible = true;
               cmbViewEnquiry.SelectedIndex = 1;
              

                
                this.Text = "Enquiry";
                ApplyPrevileges();
                PanelFollowUp.Visible = false;
                this.Width =940;
                this.Height = 646;
                formatRows();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

      //load parameters in cmb_followBy combobox in AdgvViewFolow
        private void loadFieldsOfFollowby()
        {

            string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
            if (check == "")
            {
                cmb_followBy.Visible = false;
              
            }
            else
            {
                string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                foreach (String value in items)
                {
                    cmb_followBy.Items.Add(value);
                }
            }
        }
        private void cmbViewEnquiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                branchID = Program.LoggedInUser.BranchId.ToString();

                BindingSource bs = IndexSelection(cmbViewEnquiry.SelectedIndex);
                SGStudents.PageSize = 25;
                SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(), bindingNavigator1);
           //     cmbViewEnquiry.SelectedIndex = 1;
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
                BindingSource bs = IndexSelection(cmbViewEnquiry.SelectedIndex);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

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
		
        private void btnSaveFollowp_Click(object sender, EventArgs e)
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
                    objFollowup.FollowupMediam = cmbMediam.Text;
					//Addded by ashwini for adding followup by field
                    objFollowup.FollowupBy=    (cmb_followBy.SelectedIndex == -1 ? "NA" : cmb_followBy.SelectedItem.ToString());
                    BLL.FollowupHandler.SaveFollowup(objFollowup, branchID);

                    Enquiry objEnquiry = new Enquiry();

                    UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearall();
                    PanelFollowUp.Visible = false;
                    this.Width = 956;
                    this.Height = 646;

                    BindingSource bs = new BindingSource();
                    bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                    bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                    DataTable dt = (bs.List as DataView).ToTable(); ;
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



        #endregion

        #region Functions

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
                int Index = 2;

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
            SGStudents.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            SGStudents.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        private void formatEnquiryGrid()
        {
            try
            {

                SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false;
                SGStudents.Columns["Priority"].Visible = false;
                SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false;
                SGStudents.Columns["Remark"].Visible = false;

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
                if (SGStudents.Columns["ENQ_SCHOOL_NAME"]!= null)
                {
                    SGStudents.Columns["ENQ_SCHOOL_NAME"].HeaderText = "School Name";
                }
                
                SGStudents.Columns["ENQ_ID"].HeaderText = "Enquiry No";
                SGStudents.Columns["ENQ_ADDRESS"].HeaderText = "Address";
                SGStudents.Columns["ENQ_CONTACT_NO"].HeaderText = "Mobile No";
                SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                SGStudents.Columns["ENQ_DOB"].HeaderText = "DOB";
                SGStudents.Columns["ENQ_DOB"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].HeaderText = "EnquiryDate";
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                SGStudents.Columns["ENQ_EMAIL"].HeaderText = "Email";
                SGStudents.Columns["Branchname"].HeaderText = "Branch";
                SGStudents.Columns["ENQ_IS_REGISTERED"].HeaderText = "Registered";
                SGStudents.Columns["STD_NAME"].HeaderText = "Package";
                SGStudents.Columns["STD_NAME"].Width = 100;
                SGStudents.Columns["STRM_NAME"].HeaderText = "Stream";
                SGStudents.Columns["Prev_FollowUp"].HeaderText = "Prev Followup";
                SGStudents.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";
                SGStudents.Columns["Prev_FollowUp"].Width =180;
                SGStudents.Columns["ENQ_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["ENQ_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                SGStudents.Columns["Prev_FollowUp"].DefaultCellStyle.Format= Common.Formatter.DateFormat;
                //Ordering Columns.

                SGStudents.Columns["Name"].DisplayIndex = 3;

                SGStudents.Columns["Name"].ReadOnly = true;
                SGStudents.Columns["Name"].Width = 200;
                SGStudents.Columns["STD_NAME"].DisplayIndex = 4;
                SGStudents.Columns["ENQ_CONTACT_NO"].DisplayIndex = 5;
                SGStudents.Columns["Prev_FollowUp"].DisplayIndex = 6;
                SGStudents.Columns["Prev_FollowUp"].ReadOnly = true;
                //  SGStudents.Columns["Remark"].DisplayIndex = 7;
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
               // SGStudents.Columns["Remark"].Visible = true;
                SGStudents.Columns["ENQ_ID"].ReadOnly = true;
                SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                SGStudents.Columns["STD_NAME"].ReadOnly = true;
                SGStudents.Columns["Branchname"].ReadOnly = true;
                SGStudents.Columns["ENQ_IS_REGISTERED"].ReadOnly = true;
                SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                //SGStudents.Sort(SGStudents.Columns["ENQ_DATE"], ListSortDirection.Descending);
                SGStudents.Columns["ENQ_DATE"].Width = 70;
                SGStudents.Columns["SbtnEdit"].Visible = false; ;
                SGStudents.Columns["EditImage"].DisplayIndex = SGStudents.Columns.Count - 4;
                SGStudents.Columns["new_followup"].DisplayIndex = SGStudents.Columns.Count - 2;
                SGStudents.Columns["FollowUps"].DisplayIndex = SGStudents.Columns.Count - 3;
                SGStudents.Columns["Delete"].DisplayIndex = SGStudents.Columns.Count - 1;
                SGStudents.Columns["FollowUps"].Width = 85;
                SGStudents.Columns["FollowUps"].HeaderText = "Followups";
                SGStudents.Columns["new_followup"].HeaderText = "Add Followup";
                SGStudents.Columns["new_followup"].Width = 85;
                SGStudents.Columns["Delete"].Width = 60;
                SGStudents.Columns["EditImage"].Width = 60;
                SGStudents.Columns["ENQ_STATE"].Visible = false;
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

        private BindingSource IndexSelection(int index)
        {
            try
            {
                branchID = Program.LoggedInUser.BranchId.ToString();

                BindingSource bs = new BindingSource();
                //changed by ashvini 4-1-2019
                //for proper filtered data
                bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                //end by ashvini
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

                if (txtCourseName.Text.Length > 0)
                {
                    bs.Filter += string.Format(" and STD_NAME LIKE '%{0}%'", txtCourseName.Text);
                }

                if (txtFname.Text.Length > 0)
                {
                    bs.Filter += string.Format(" and Name LIKE '%{0}%'", txtFname.Text);
                }

                SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(), bindingNavigator1);




                return bs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        private bool validateFollowupDetails()
        {
            try
            {

                if (dtFollowup.Value.ToShortDateString() == System.DateTime.Now.ToShortDateString())
                {
                    UICommon.WinForm.showStatus("Next Followup-Date Should be greater than todays date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtFollowup.Focus();
                    return false;
                }
              else   if (cmbMediam.SelectedItem == null)
                {
                    UICommon.WinForm.showStatus("Select Medium for followup", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbMediam.Focus();
                    return false;
                }
               else  if(cmb_followBy.SelectedItem==null)
                {
                    UICommon.WinForm.showStatus("Select FollowpupBy for followup", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmb_followBy.Focus();
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

        private void clearall()
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

        #endregion

        #region GridView Events

        private void SGStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatEnquiryGrid();
                formatRows();
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

                            branchID = SGStudents.Rows[e.RowIndex].Cells["ENQ_BRANCH_ID"].Value.ToString();
                            EnquiryId = (Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value));
                            PanelFollowUp.Visible = true;
                            pnlViewFollowUp.Visible = false;
                            AdgvViewFolow.Visible = false;
                            BtnCancel.Visible = false;
                            lblStudName.Text = SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                            bindParamWithCmbFolloBy();
                            this.Width = 1156;
                            this.Height = 646;
                            BindingSource bs = new BindingSource();
                            bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                            bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                            DataTable dt = (bs.List as DataView).ToTable(); ;
                            SGStudents.PageSize = 25;
                            SGStudents.SetPagedDataSource(dt, bindingNavigator1);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            DataGridViewColumn Folloup_by = new DataGridViewColumn();
                            Folloup_by.HeaderText = "Followup By";
                            Folloup_by.Name = "follo";
                            Folloup_by.Visible = true;
                            Folloup_by.Width = 80;

                            PanelFollowUp.Visible = false;
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


                    else if (SGStudents.Columns.Contains("EditImage") && e.ColumnIndex == SGStudents.Columns["EditImage"].Index)
                    {
                        string[] name = { "Gym" };

                        WinApp.Gym.FrmEnquiryEntryForm objEnqUpdate = (WinApp.Gym.FrmEnquiryEntryForm)UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm, this, true, name, null);
                        objEnqUpdate.setValuesForUpdate(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                        objEnqUpdate.ShowDialog();

                        //changed by ashvini 4-1-2019
                        //for proper filtered data                   
                        BindingSource bs = new BindingSource();
                        bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);                       
                       cmbViewEnquiry.SelectedIndex = 1;                
                        SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(), bindingNavigator1);
                        
                        this.Visible = true;
                        //end by ashvini04-01

                    }
                    else if (SGStudents.Columns.Contains("Delete") && e.ColumnIndex == SGStudents.Columns["Delete"].Index)
                    {
                        var sure = MessageBox.Show("Do you Want to Delete " + SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString().Trim(), "Details", MessageBoxButtons.YesNo);

                        if (sure == DialogResult.Yes)
                        {
                            BLL.EnquiryHandller.DeleteEnquiry((Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value)), SGStudents.Rows[e.RowIndex].Cells["Name"].Value.ToString(), SGStudents.Rows[e.RowIndex].Cells["ENQ_CONTACT_NO"].Value.ToString(), Convert.ToInt32(branchID));
                            UICommon.WinForm.showStatus("Deleted Sucessfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);


                            BindingSource bs = new BindingSource();
                            bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                            bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                            DataTable data = (bs.List as DataView).ToTable(); ;

                            SGStudents.PageSize = 25;
                            SGStudents.SetPagedDataSource(data, bindingNavigator1);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        //method for binding parameter with FollowupBy Combobox by Ashvini
        private void bindParamWithCmbFolloBy()
        {
            Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS);
            BindingSource bs = new BindingSource();
            bs.DataMember= Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS);
           

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


        private void AdgvViewFolow_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {  //changed by ashvini 4-1-2019
                //for proper column formatting
                if (AdgvViewFolow.Columns.Contains("Description"))
                {
                   
                    AdgvViewFolow.Columns["Description"].Width =150;
                }
                if (AdgvViewFolow.Columns.Contains("Date"))
                {
                    AdgvViewFolow.Columns["Date"].HeaderText = "Next Followup";
                    AdgvViewFolow.Columns["Date"].Width = 80;
                }

                if (AdgvViewFolow.Columns.Contains("FOLU_BY"))
                {
                    AdgvViewFolow.Columns["FOLU_BY"].HeaderText = "Followup By";
                    AdgvViewFolow.Columns["FOLU_BY"].Width =80;
                }

                if (    AdgvViewFolow.Columns.Contains("FOLU_CRTD_AT"))
                    {
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].HeaderText = "Followup On";
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].DisplayIndex = 4;
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].Width = 100;
                    AdgvViewFolow.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                }
                AdgvViewFolow.Columns["Date"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                AdgvViewFolow.Columns[1].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                
                //end by ashvini04-01
            }

            catch (Exception)
            {
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

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = IndexSelection(cmbViewEnquiry.SelectedIndex);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }





        #endregion

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {

            try
            {
                SGStudents.DataSource = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
                formatEnquiryGrid();

                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFname.Text;
                getParameter.EnqNo = "Package:- " +txtCourseName .Text + "";
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
