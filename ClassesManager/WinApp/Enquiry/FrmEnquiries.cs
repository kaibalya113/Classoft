using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ClassManager.WinApp.Popups;
using ClassManager.WinApp.UICommon;
using System.Windows.Forms;

using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmEnquiries : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "All Enquiry Details";
        DataTable dtEnquiries; DataTable dt;
        private bool considerGroupBy;
        private int strmid;

        public FrmEnquiries()
        {
            InitializeComponent();
        }

        private void ShowAllEnquiries_Load(object sender, EventArgs e)
        {

            try
            {
                SGStudents.RowTemplate.MinimumHeight = 25;
                SGStudents.RowTemplate.Height = 25;

                SGView.Visible = false;
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
                //SGStudents.DataSource = dtEnquiries;
                SGStudents.PageSize = 25;
                SGStudents.SetPagedDataSource(dtEnquiries, bindingNavigator1);
                AssignEvents();
                getcount(dtEnquiries);
                cmbViewEnquiry.SelectedIndex = 1;
             //   cmbGroupBy.SelectedIndex = 2;
                formatdate();
                ApplyPrevileges();
                this.Width = 1089;
                this.Height = 369;
             
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
                if (functionId != 0)
                {
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

        private void formatViewGrid()
        {
            try
            {
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                if (appName == "" || appName == "Asset")

                {
                    SGView.Columns["Parent Contact"].Visible = true;

                }
                else
                {
                    SGView.Columns["Parent Contact"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        private void formatEnquiryGrid()
       {
            try
            {
                if (SGStudents.Columns.Contains("ENQ_STATE"))
                {
                    SGStudents.Columns["ENQ_STATE"].Visible = false;
                  
                }
                //Hide & disable unnecessary columns
                // ADGVEnquiries.Columns["ENQ_ID"].Visible = false;
                if (SGStudents.Columns.Contains("ENQ_BRANCH_ID"))
                { SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false; }
                if (SGStudents.Columns.Contains("Count"))
                {
                    SGStudents.Columns["Count"].Width = 50;
                    SGStudents.Columns["Count"].ReadOnly = true;
                }
                if (SGStudents.Columns.Contains("Course"))
                {
                 
                    SGStudents.Columns["Course"].ReadOnly = true;
                }
                if (SGStudents.Columns.Contains("Priority"))
                {
                    SGStudents.Columns["Priority"].Visible = true;
                    SGStudents.Columns["Priority"].ReadOnly = true;

                    foreach (DataGridViewRow row in SGStudents.Rows)
                    {
                        if (row.Cells["Priority"].Value.ToString().Trim().Equals("Mid"))
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF176");
                        }
                        if (row.Cells["Priority"].Value.ToString().Trim().Equals("High"))
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EF9A9A");
                        }
                        if (row.Cells["Priority"].Value.ToString().Trim().Equals("Low"))
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#AED581");
                        }

                        foreach (DataGridViewRow adrow in SGStudents.Rows)
                        {

                            adrow.Height = 30;
                            adrow.MinimumHeight = 30;

                        }
                    }
                }
          
                if (SGStudents.Columns.Contains("FOLU_DESCRIPTION"))
                { SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false; }
                if (SGStudents.Columns.Contains("Remark"))
                { SGStudents.Columns["Remark"].Visible = true; }
                if (SGStudents.Columns.Contains("STD_NAME"))
                {  SGStudents.Columns["STD_NAME"].HeaderText = "Course";
                    SGStudents.Columns["STD_NAME"].ReadOnly = true;

                }
                if (SGStudents.Columns.Contains("STRM_NAME"))
                {
                    SGStudents.Columns["STRM_NAME"].HeaderText = "Course";
                    SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                }
               



                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString() == "")
                {

                    if (SGStudents.Columns.Contains("Counselor"))
                    { SGStudents.Columns["Counselor"].Visible = true;
                        SGStudents.Columns["Counselor"].ReadOnly = true;
                    }
                    if (SGStudents.Columns.Contains("Batch"))
                    { SGStudents.Columns["Batch"].Visible = false; }

                    if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                    { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }
                    if (SGStudents.Columns.Contains("ENQ_PARENT_CONTACT"))
                    { SGStudents.Columns["ENQ_PARENT_CONTACT"].HeaderText = "Parent Contact";
                        SGStudents.Columns["ENQ_PARENT_CONTACT"].DisplayIndex = 9;
                    }
                    if (SGStudents.Columns.Contains("Qualification"))
                    { SGStudents.Columns["Qualification"].Visible = false; }


                }
                else
                {
                    if (SGStudents.Columns.Contains("Counselor"))
                    { SGStudents.Columns["Counselor"].Visible = true;
                        SGStudents.Columns["Counselor"].ReadOnly = true;
                    }
                    if (SGStudents.Columns.Contains("Batch"))
                    { SGStudents.Columns["Batch"].Visible = false; }

                    if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                    { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }
                    if (SGStudents.Columns.Contains("ENQ_PARENT_CONTACT"))
                    { SGStudents.Columns["ENQ_PARENT_CONTACT"].Visible = false;
                       
                    }


                }
              
                if (SGStudents.Columns.Contains("Batch"))
                { SGStudents.Columns["Batch"].Visible = false; }

                if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }
             
                if (SGStudents.Columns.Contains("Qualification"))
                { SGStudents.Columns["Qualification"].Visible = false; }
              
            

                if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }
           
         
          

                if (SGStudents.Columns.Contains("ENQ_ADDRESS"))
                {
                    SGStudents.Columns["ENQ_ADDRESS"].HeaderText = "Address";
                }
                if (SGStudents.Columns.Contains("Enquiry_Registered"))
                { SGStudents.Columns["Enquiry_Registered"].HeaderText = "Registered"; }
                if (SGStudents.Columns.Contains("ENQ_ID"))
                { SGStudents.Columns["ENQ_ID"].HeaderText = "Enquiry No"; }
                if (SGStudents.Columns.Contains("Subjects"))
                {
                    SGStudents.Columns["Subjects"].Visible = false;


                    SGStudents.Columns["ENQ_CONTACT_NO"].HeaderText = "Contact No";
                    SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                    SGStudents.Columns["ENQ_DOB"].HeaderText = "DOB";
                    SGStudents.Columns["ENQ_DATE"].HeaderText = "EnquiryDate";
                    SGStudents.Columns["ENQ_EMAIL"].HeaderText = "Email";
                    SGStudents.Columns["Branchname"].HeaderText = "Branch";
                    SGStudents.Columns["ENQ_IS_REGISTERED"].HeaderText = "Registered";
                    SGStudents.Columns["STD_NAME"].HeaderText = "Course";
                    SGStudents.Columns["STRM_NAME"].HeaderText = "Stream";

                    SGStudents.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";

                    SGStudents.Columns["ENQ_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                    SGStudents.Columns["ENQ_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;

                    //Ordering Columns.
                    SGStudents.Columns["ENQ_ID"].DisplayIndex = 3;
                    SGStudents.Columns["ENQ_DATE"].DisplayIndex = 4;
                    SGStudents.Columns["Name"].DisplayIndex = 5;
                    SGStudents.Columns["Name"].ReadOnly = true;
                    SGStudents.Columns["Prev_FollowUp"].Visible = false;

                    SGStudents.Columns["ENQ_ID"].DisplayIndex = 6;
                    SGStudents.Columns["STD_NAME"].DisplayIndex = 7;

                    SGStudents.Columns["ENQ_CONTACT_NO"].DisplayIndex = 8;
                    SGStudents.Columns["ENQ_ADDRESS"].DisplayIndex = 10;
                    SGStudents.Columns["ENQ_EMAIL"].DisplayIndex = 11;
                    SGStudents.Columns["Branchname"].DisplayIndex = 12;
                    SGStudents.Columns["ENQ_IS_REGISTERED"].DisplayIndex = 13;
                    SGStudents.Columns["Remark"].DisplayIndex = 14;
                    // SGStudents.Columns["Counselor"].DisplayIndex = 14;
                    SGStudents.Columns["Subjects"].DisplayIndex = 15;

                    SGStudents.Columns["ENQ_ID"].ReadOnly = true;
                    SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                    SGStudents.Columns["STD_NAME"].ReadOnly = true;
                    SGStudents.Columns["Branchname"].ReadOnly = true;
                    SGStudents.Columns["ENQ_IS_REGISTERED"].ReadOnly = true;
                    SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                    SGStudents.Sort(SGStudents.Columns["ENQ_DATE"], ListSortDirection.Descending);
                    SGStudents.Columns["FollowUps"].DisplayIndex = SGStudents.Columns.Count - 2;
                    SGStudents.Columns["Delete"].DisplayIndex = SGStudents.Columns.Count - 1;
                }





            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void formatEnquiryGridpdf()
        {
            try
            {

                //Hide & disable unnecessary columns
                // ADGVEnquiries.Columns["ENQ_ID"].Visible = false;
                if (SGStudents.Columns.Contains("ENQ_BRANCH_ID"))
                { SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false; }
                if (SGStudents.Columns.Contains("Count"))
                {
                    SGStudents.Columns["Count"].Width = 50;
                    SGStudents.Columns["Count"].ReadOnly = true;
                }
                if (SGStudents.Columns.Contains("Course"))
                {

                    SGStudents.Columns["Course"].ReadOnly = true;
                }
                if (SGStudents.Columns.Contains("Priority"))
                {
                    SGStudents.Columns["Priority"].Visible = true;
                    SGStudents.Columns["Priority"].ReadOnly = true;

                    foreach (DataGridViewRow row in SGStudents.Rows)
                    {
                        if (row.Cells["Priority"].Value.ToString().Trim().Equals("Mid"))
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF176");
                        }
                        if (row.Cells["Priority"].Value.ToString().Trim().Equals("High"))
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EF9A9A");
                        }
                        if (row.Cells["Priority"].Value.ToString().Trim().Equals("Low"))
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#AED581");
                        }

                        foreach (DataGridViewRow adrow in SGStudents.Rows)
                        {

                            adrow.Height = 30;
                            adrow.MinimumHeight = 30;

                        }
                    }
                }

                if (SGStudents.Columns.Contains("FOLU_DESCRIPTION"))
                { SGStudents.Columns["FOLU_DESCRIPTION"].Visible = false; }
                if (SGStudents.Columns.Contains("Remark"))
                { SGStudents.Columns["Remark"].Visible = true; }
                if (SGStudents.Columns.Contains("STD_NAME"))
                {
                    SGStudents.Columns["STD_NAME"].HeaderText = "Course";
                    SGStudents.Columns["STD_NAME"].ReadOnly = true;

                }
                if (SGStudents.Columns.Contains("STRM_NAME"))
                {
                    SGStudents.Columns["STRM_NAME"].HeaderText = "Course";
                    SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                }

                if (SGStudents.Columns.Contains("ENQ_STATE"))
                {
                    SGStudents.Columns["ENQ_STATE"].Visible = true;
                    SGStudents.Columns["ENQ_STATE"].HeaderText = "Status";
                    SGStudents.Columns["ENQ_STATE"].DisplayIndex = 14;
                }


                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString() == "")
                {

                    if (SGStudents.Columns.Contains("Counselor"))
                    {
                        SGStudents.Columns["Counselor"].Visible = true;
                        SGStudents.Columns["Counselor"].ReadOnly = true;
                    }
                    if (SGStudents.Columns.Contains("Batch"))
                    { SGStudents.Columns["Batch"].Visible = false; }

                    if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                    { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }
                    if (SGStudents.Columns.Contains("ENQ_PARENT_CONTACT"))
                    { SGStudents.Columns["ENQ_PARENT_CONTACT"].HeaderText = "Parent Contact"; }
                    if (SGStudents.Columns.Contains("Qualification"))
                    { SGStudents.Columns["Qualification"].Visible = false; }


                }
                else
                {
                    if (SGStudents.Columns.Contains("Counselor"))
                    {
                        SGStudents.Columns["Counselor"].Visible = true;
                        SGStudents.Columns["Counselor"].ReadOnly = true;
                    }
                    if (SGStudents.Columns.Contains("Batch"))
                    { SGStudents.Columns["Batch"].Visible = false; }

                    if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                    { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }
                    if (SGStudents.Columns.Contains("ENQ_PARENT_CONTACT"))
                    {
                        SGStudents.Columns["ENQ_PARENT_CONTACT"].Visible = false;

                    }


                }

                if (SGStudents.Columns.Contains("Batch"))
                { SGStudents.Columns["Batch"].Visible = false; }

                if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }

                if (SGStudents.Columns.Contains("Qualification"))
                { SGStudents.Columns["Qualification"].Visible = false; }



                if (SGStudents.Columns.Contains("ENQ_BATCH_ID"))
                { SGStudents.Columns["ENQ_BATCH_ID"].Visible = false; }




                if (SGStudents.Columns.Contains("ENQ_ADDRESS"))
                {
                    SGStudents.Columns["ENQ_ADDRESS"].HeaderText = "Address";
                }
                if (SGStudents.Columns.Contains("Enquiry_Registered"))
                { SGStudents.Columns["Enquiry_Registered"].HeaderText = "Registered"; }
                if (SGStudents.Columns.Contains("ENQ_ID"))
                { SGStudents.Columns["ENQ_ID"].HeaderText = "Enquiry No"; }
                if (SGStudents.Columns.Contains("Subjects"))
                {
                    SGStudents.Columns["Subjects"].Visible = false;


                    SGStudents.Columns["ENQ_CONTACT_NO"].HeaderText = "Contact No";
                    SGStudents.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                    SGStudents.Columns["ENQ_DOB"].HeaderText = "DOB";
                    SGStudents.Columns["ENQ_DATE"].HeaderText = "EnquiryDate";
                    SGStudents.Columns["ENQ_EMAIL"].HeaderText = "Email";
                    SGStudents.Columns["Branchname"].HeaderText = "Branch";
                    SGStudents.Columns["ENQ_IS_REGISTERED"].HeaderText = "Registered";
                    SGStudents.Columns["STD_NAME"].HeaderText = "Course";
                    SGStudents.Columns["STRM_NAME"].HeaderText = "Stream";

                    SGStudents.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";

                    SGStudents.Columns["ENQ_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                    SGStudents.Columns["ENQ_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;

                    //Ordering Columns.
                    SGStudents.Columns["ENQ_ID"].DisplayIndex = 3;
                    SGStudents.Columns["ENQ_DATE"].DisplayIndex = 4;
                    SGStudents.Columns["Name"].DisplayIndex = 5;
                    SGStudents.Columns["Name"].ReadOnly = true;
                    SGStudents.Columns["Prev_FollowUp"].Visible = false;

                    SGStudents.Columns["ENQ_ID"].DisplayIndex = 6;
                    SGStudents.Columns["STD_NAME"].DisplayIndex = 7;

                    SGStudents.Columns["ENQ_CONTACT_NO"].DisplayIndex = 8;
                    SGStudents.Columns["ENQ_ADDRESS"].DisplayIndex = 9;
                    SGStudents.Columns["ENQ_EMAIL"].DisplayIndex = 10;
                    SGStudents.Columns["Branchname"].DisplayIndex = 11;
                    SGStudents.Columns["ENQ_IS_REGISTERED"].DisplayIndex = 12;
                    SGStudents.Columns["Remark"].DisplayIndex = 13;
                    // SGStudents.Columns["Counselor"].DisplayIndex = 14;
                    SGStudents.Columns["Subjects"].DisplayIndex = 15;

                    SGStudents.Columns["ENQ_ID"].ReadOnly = true;
                    SGStudents.Columns["STRM_NAME"].ReadOnly = true;
                    SGStudents.Columns["STD_NAME"].ReadOnly = true;
                    SGStudents.Columns["Branchname"].ReadOnly = true;
                    SGStudents.Columns["ENQ_IS_REGISTERED"].ReadOnly = true;
                    SGStudents.Columns["ENQ_DATE"].ReadOnly = true;
                    SGStudents.Sort(SGStudents.Columns["ENQ_DATE"], ListSortDirection.Descending);
                    SGStudents.Columns["FollowUps"].DisplayIndex = SGStudents.Columns.Count - 2;
                    SGStudents.Columns["Delete"].DisplayIndex = SGStudents.Columns.Count - 1;
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

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IndexSelection(cmbViewEnquiry.SelectedIndex);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                bs.Filter = string.Format("Name LIKE '%{0}%'", txtFname.Text);
                SGStudents.DataSource = bs;
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
                SGView.Visible = false;
                
                IndexSelection(cmbViewEnquiry.SelectedIndex);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void removeColumn()
        {
            try
            {
                if (SGStudents.Columns.Contains("View"))
                {
                    SGStudents.Columns.Remove("View");
                }
                if (SGStudents.Columns.Contains("Counselor"))
                {
                    SGStudents.Columns.Remove("Counselor");
                }
                if (SGStudents.Columns.Contains("Priority"))
                {
                    SGStudents.Columns.Remove("Priority");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void IndexSelection(int index)
        {
            try
            {
                branchID = Program.LoggedInUser.BranchId.ToString();

                BindingSource bs = new BindingSource();
                bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
                removeColumn();
               
                switch (cmbViewEnquiry.SelectedIndex)
                {
                    case 0:
                       // SGView.Visible = false;
                        bs.Filter = "ENQ_IS_REGISTERED in ('Yes', 'No')";
                        break;
                    case 1:
                      //  SGView.Visible = false;
                        bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                        break;
                    case 2:
                     //   SGView.Visible = false;
                        bs.Filter = "ENQ_IS_REGISTERED = 'Yes'";
                        break;
                    case 3:
                      //  SGView.Visible = false;
                        bs.Filter = "Priority='High'and ENQ_IS_REGISTERED = 'No'";
                        break;
                    case 4:
                        bs.Filter = "Priority='Mid'and ENQ_IS_REGISTERED = 'No'";
                        break;
                    case 5:
                       // SGView.Visible = false;
                        bs.Filter = "Priority='Low'and ENQ_IS_REGISTERED = 'No'";
                        break;
                    case 6:
                       // SGView.Visible = false;
                        bs.Filter = "Priority='Not Interested' and ENQ_IS_REGISTERED = 'No'";
                        break;
                }
                dt = (bs.List as DataView).ToTable(); ;
                SGStudents.DataSource = dt;
                removeColumn();
                SGStudents.Height = 550;
             
                SGView.Visible = false;
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
                    SGStudents.DataSource = null;

                    string Fromdate = dtpFrmDtEnq.Value.ToShortDateString();
                    string Todate = dtpToDteEnq.Value.ToShortDateString();

                    dtEnquiries = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1, Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate));
                    SGStudents.DataSource = dtEnquiries;
                    AssignEvents();
                    getcount(dtEnquiries);
                    cmbViewEnquiry.SelectedIndex = 0;
                    SGStudents.Width = 1062;
                    SGStudents.Height = 402;
                }
                else
                {
                    UICommon.WinForm.showStatus("From Date Cannot be Greater", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            try
            {
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
                            DataTable data = (bs.List as DataView).ToTable(); ;
                            SGStudents.DataSource = data;

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
                    btn_saveview_pdf.Visible = true;
                    BtnExcelView.Visible = true;
                    SGView.ReadOnly = true;
                    DataTable dt = null;
                    //added by ashvini for displaying data like courese, name,contactno ... on 31-01-2019
                    if (SGStudents.Columns.Contains("View") && e.ColumnIndex == SGStudents.Columns["View"].Index)
                    {

                        if (SGStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                        {

                            switch (cmbGroupBy.SelectedIndex)
                            {
                                case 0:
                                    string status;

                                    string con = (SGStudents.Rows[e.RowIndex].Cells["Counselor"].Value).ToString();
                                    if (SGStudents.Columns.Contains("Priority"))
                                    {
                                        status = (SGStudents.Rows[e.RowIndex].Cells["Priority"].Value).ToString();
                                        dt = BLL.StudentHandller.getStudentsByGroupByofEnquiry(0, con, status, branchID.ToString());
                                    }
                                    if (SGStudents.Columns.Contains("Enquiry_Registered"))
                                    {
                                        string registered = (SGStudents.Rows[e.RowIndex].Cells["Enquiry_Registered"].Value).ToString();

                                        dt = BLL.StudentHandller.getStudents_pending(0, con, registered, branchID.ToString());
                                    }

                      

                                    SGView.Visible = true;
                                    SGView.DataSource = dt;
                                    formatViewGrid();
                                    SGStudents.Width = 400;
                                    SGStudents.Height = 397;

                                    //  formatGrid(1);
                                    break;

                                case 1:
                                    string Priority;

                                    string Course = (SGStudents.Rows[e.RowIndex].Cells["Course"].Value).ToString();
                                    if (SGStudents.Columns.Contains("Priority"))
                                    {
                                        Priority = (SGStudents.Rows[e.RowIndex].Cells["Priority"].Value).ToString();
                                        dt = BLL.StudentHandller.getStudentsByGroupByofEnquiry(1, Course, Priority, branchID.ToString());
                                    }
                                    if (SGStudents.Columns.Contains("Enquiry_Registered"))
                                    {
                                        string registered = (SGStudents.Rows[e.RowIndex].Cells["Enquiry_Registered"].Value).ToString();

                                        dt = BLL.StudentHandller.getStudents_pending(1, Course, registered, branchID.ToString());
                                    }


                                    SGView.Visible = true;
                                    SGView.DataSource = dt;
                                     formatViewGrid();
                                    SGStudents.Width = 400;
                                   SGStudents.Height = 397;
                               
                                    break;
                                case 2:
                                   

                                    string Reference = (SGStudents.Rows[e.RowIndex].Cells["Pending"].Value).ToString();
                                    if (SGStudents.Columns.Contains("Priority"))
                                    {
                                        Priority = (SGStudents.Rows[e.RowIndex].Cells["Priority"].Value).ToString();
                                        dt = BLL.StudentHandller.getStudentsByGroupByofEnquiry(2, Reference, Priority, branchID.ToString());
                                    }
                                    if (SGStudents.Columns.Contains("Enquiry_Registered"))
                                    {
                                        string registered = (SGStudents.Rows[e.RowIndex].Cells["Enquiry_Registered"].Value).ToString();

                                        dt = BLL.StudentHandller.getStudents_pending(2, Reference, registered, branchID.ToString());
                                    }

                                    SGView.Visible = true;
                                    SGView.DataSource = dt;
                                    formatViewGrid();
                                    SGStudents.Width = 400;
                                    SGStudents.Height = 397;

                                  
                                    break;
                            }
                            //end by ashvini to display data based on cmbgroupby combobox on 31-01-2019


                            if (SGStudents.Columns.Contains("FollowUps") && e.ColumnIndex == SGStudents.Columns["FollowUps"].Index)
                            {
                                if (SGStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                                {

                                    pnlViewFollowUp.Visible = true;
                                    AdgvViewFolow.Visible = true;
                                    BtnCancel.Visible = true;
                                    this.Width = 1375;
                                    this.Height = 656;
                                    int EnqID = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ENQ_ID"].Value.ToString());
                                    dt = BLL.FollowupHandler.viewFollowUp(EnqID);
                                    AdgvViewFolow.DataSource = dt;
                                }
                            }


                            else if (SGStudents.Columns.Contains("SbtnEdit") && e.ColumnIndex == SGStudents.Columns["SbtnEdit"].Index)
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
                        }
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
                DataTable dt = BLL.FollowupHandler.CountOfFollowUp(Program.LoggedInUser.BranchId.ToString());




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



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BtnCancel.Visible = false;
                pnlViewFollowUp.Visible = false;
                AdgvViewFolow.Visible = false;
                this.Width = 1098;
                this.Height = 657;

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
                if (AdgvViewFolow.Columns.Contains("FOLU_BY"))
                {
                    AdgvViewFolow.Columns["FOLU_BY"].HeaderText = "Followup By";
                    AdgvViewFolow.Columns["FOLU_BY"].Width = 150;
                }
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

        private void dtpFrmDtEnq_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrmDtEnq.Value > dtpToDteEnq.Value)
            {
                dtpToDteEnq = dtpFrmDtEnq;
            }
        }

        private void dtpToDteEnq_ValueChanged(object sender, EventArgs e)
        {
            if (dtpToDteEnq.Value < dtpFrmDtEnq.Value)
            {
                dtpFrmDtEnq = dtpToDteEnq;
            }
        }
        private void removecolumn()
        {
            if (SGStudents.Columns.Contains("ENQ_BRANCH_ID"))
            { SGStudents.Columns["ENQ_BRANCH_ID"].Visible = false; }
            if (SGStudents.Columns.Contains("STRM_NAME"))
            {
                SGStudents.Columns["STRM_NAME"].Visible = false;
            }
            if (SGStudents.Columns.Contains("ENQ_EMAIL"))
            {
                SGStudents.Columns["ENQ_EMAIL"].Visible = false;
            }

            if (SGStudents.Columns.Contains("ENQ_ADDRESS"))
            {
                SGStudents.Columns["ENQ_ADDRESS"].Visible = false;
            }
            if (SGStudents.Columns.Contains("Branchname"))
            {
                SGStudents.Columns["Branchname"].Visible = false;
            }
         
        }
        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SGStudents.DataSource = BLL.EnquiryHandller.GetAllEnquries(Program.LoggedInUser.BranchId.ToString(), -1);
                formatEnquiryGridpdf();
                removecolumn();
                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFname.Text;
                getParameter.EnqNo = "EnqNo:- " + txtEnqNo.Text + "";
                getParameter.View = "View:- " + cmbViewEnquiry.SelectedItem.ToString();
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFrmDtEnq.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDteEnq.Value);
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




        private void IndexSelectionGroupby(int index)
        {
            try
            {
                branchID = Program.LoggedInUser.BranchId.ToString();

                considerGroupBy = true;
                switch (cmbGroupBy.SelectedIndex)
                {
                    case 0:
                        DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                              .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Priority = r.Field<string>("Priority") })
                                              .Select(g => new
                                              {
                                                  Counselor = g.Key.Counselor,

                                                  Count = g.Count()
                                                  ,
                                                  Priority = g.Key.Priority
                                              }).Where(stat => stat.Counselor != "NA" & stat.Counselor != "")
                                            .ToList());
                        SGStudents.Columns["FollowUps"].Visible = false;
                        SGStudents.Columns["Delete"].Visible = false;
                        SGStudents.DataSource = stream;
                        if (SGStudents.Columns.Contains("View"))
                        {
                            SGStudents.Columns["View"].Visible = false;

                        }
                        else
                        {
                            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                            lnk.Name = "View";
                            lnk.HeaderText = "View Members";
                            lnk.DefaultCellStyle.NullValue = "View";
                            SGStudents.Columns.Insert(5, lnk);
                        }
                 
                        break;
            

                }
                SGStudents.Width = 1062;
                SGStudents.Height = 402;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //added by ashvini for displaying data based on group by of refence,course,counselor on 31-01-2019
        private void cmbGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SGView.Visible = false;
            if (SGStudents.Columns.Contains("View"))
            {
                SGStudents.Columns["View"].Visible = true;

            }
            else
            {
           DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            lnk.Name = "View";
            lnk.HeaderText = "View Members";
            lnk.DefaultCellStyle.NullValue = "View";
            SGStudents.Columns.Insert(2, lnk);
            }
          
            try
            {
                if (cmbGroupBy.SelectedIndex == 0 & cmbViewEnquiry.SelectedItem.ToString() == "High")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Counselor = g.Key.Counselor,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("High"))
                                            .ToList());
                
                    SGStudents.DataSource = stream;

                }
                if (cmbViewEnquiry.SelectedItem.ToString() == "ALL")
                {
                    SGStudents.Columns["View"].Visible = false;
                }
                if (cmbGroupBy.SelectedIndex == 2 & cmbViewEnquiry.SelectedItem.ToString() == "High")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new {ReferenceBy= r.Field<string>("Referred By"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                            Pending = g.Key.ReferenceBy,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("High"))
                                            .ToList());

                    SGStudents.DataSource = stream;
                }
                if (cmbGroupBy.SelectedIndex == 2 & cmbViewEnquiry.SelectedItem.ToString() == "Mid")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { ReferenceBy = r.Field<string>("Referred By"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Pending = g.Key.ReferenceBy,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Mid"))
                                            .ToList());

                    SGStudents.DataSource = stream;
                }
                if (cmbGroupBy.SelectedIndex == 2 & cmbViewEnquiry.SelectedItem.ToString() == "Low")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { ReferenceBy = r.Field<string>("Referred By"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Pending = g.Key.ReferenceBy,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Low"))
                                            .ToList());

                    SGStudents.DataSource = stream;
                }

                if (cmbGroupBy.SelectedIndex == 1 & cmbViewEnquiry.SelectedItem.ToString() == "High")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Course = r.Field<string>("STD_NAME"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Course = g.Key.Course,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("High"))
                                            .ToList());
               
                    SGStudents.DataSource = stream;            
                }
                if (cmbGroupBy.SelectedIndex == 1 & cmbViewEnquiry.SelectedItem.ToString() == "Mid")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Course = r.Field<string>("STD_NAME"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Course = g.Key.Course,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Mid"))
                                            .ToList());
                  
                    SGStudents.DataSource = stream;
   
                }
                if (cmbGroupBy.SelectedIndex == 1 & cmbViewEnquiry.SelectedItem.ToString() == "Low")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Course = r.Field<string>("STD_NAME"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Course = g.Key.Course,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Low"))
                                            .ToList());
                  
                    SGStudents.DataSource = stream;
               

                }
                if (cmbGroupBy.SelectedIndex == 0 & cmbViewEnquiry.SelectedItem.ToString() == "Pending")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Counselor = g.Key.Counselor,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("No"))
                                           .ToList());
                    SGStudents.Columns["FollowUps"].Visible = false;
                    SGStudents.Columns["Delete"].Visible = false;
                    SGStudents.DataSource = stream;
                  
                }
                if (cmbGroupBy.SelectedIndex == 1 & cmbViewEnquiry.SelectedItem.ToString() == "Pending")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Course = r.Field<string>("STD_NAME"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Course = g.Key.Course,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("No"))
                                           .ToList());

                    SGStudents.DataSource = stream;

                }

                    if (cmbGroupBy.SelectedIndex == 2 & cmbViewEnquiry.SelectedItem.ToString() == "Pending")
                    {
                        branchID = Program.LoggedInUser.BranchId.ToString();


                        DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                              .GroupBy(r => new { RefereredBy = r.Field<string>("Referred By"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                              .Select(g => new
                                              {
                                                  Pending = g.Key.RefereredBy,

                                                  Count = g.Count()
                                                  ,
                                                  Enquiry_Registered = g.Key.Enquiry_Registered
                                              }).Where(stud => stud.Enquiry_Registered.Contains("No"))
                                               .ToList());

                        SGStudents.DataSource = stream;


                    }
                if (cmbGroupBy.SelectedIndex == 2 & cmbViewEnquiry.SelectedItem.ToString() == "Confirm")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { RefereredBy = r.Field<string>("Referred By"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Pending = g.Key.RefereredBy,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("Yes"))
                                           .ToList());

                    SGStudents.DataSource = stream;


                }
                if (cmbGroupBy.SelectedIndex == 0 & cmbViewEnquiry.SelectedItem.ToString() == "Not Interested")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Counselor = g.Key.Counselor,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Not Interested"))
                                            .ToList());
                  
                    SGStudents.DataSource = stream;
                  


                }
                if (cmbGroupBy.SelectedIndex == 2 & cmbViewEnquiry.SelectedItem.ToString() == "Not Interested")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { RefereredBy = r.Field<string>("Referred By"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Pending = g.Key.RefereredBy,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("Not Interested"))
                                           .ToList());

                    SGStudents.DataSource = stream;


                }
                if (cmbGroupBy.SelectedIndex == 1 & cmbViewEnquiry.SelectedItem.ToString() == "Not Interested")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                           .GroupBy(r => new { RefereredBy = r.Field<string>("Referred By"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Pending = g.Key.RefereredBy,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("Not Interested"))
                                           .ToList());

                    SGStudents.DataSource = stream;
  
                }
                if (cmbGroupBy.SelectedIndex == 0 & cmbViewEnquiry.SelectedItem.ToString() == "Confirm")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Counselor = g.Key.Counselor,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("Yes"))
                                           .ToList());
                  
                    SGStudents.DataSource = stream;
      
                }
                if (cmbGroupBy.SelectedIndex == 1 & cmbViewEnquiry.SelectedItem.ToString() == "Confirm")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Course = r.Field<string>("STD_NAME"), Enquiry_Registered = r.Field<string>("ENQ_IS_REGISTERED") })
                                          .Select(g => new
                                          {
                                              Course = g.Key.Course,

                                              Count = g.Count()
                                              ,
                                              Enquiry_Registered = g.Key.Enquiry_Registered
                                          }).Where(stud => stud.Enquiry_Registered.Contains("Yes"))
                                           .ToList());
                    
                    SGStudents.DataSource = stream;
                  
                }
                if (cmbGroupBy.SelectedIndex == 0 & cmbViewEnquiry.SelectedItem.ToString() == "Mid")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Counselor = g.Key.Counselor,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Mid"))
                                            .ToList());
                   
                    SGStudents.DataSource = stream;                   

                }

                if (cmbGroupBy.SelectedIndex == 0 & cmbViewEnquiry.SelectedItem.ToString() == "Low")
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();


                    DataTable stream = WinForm.ToDataTable(dtEnquiries.DefaultView.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Counselor = r.Field<string>("Counselor"), Priority = r.Field<string>("Priority") })
                                          .Select(g => new
                                          {
                                              Counselor = g.Key.Counselor,

                                              Count = g.Count()
                                              ,
                                              Priority = g.Key.Priority
                                          }).Where(stud => stud.Priority.Contains("Low"))
                                            .ToList());

                 
                    SGStudents.DataSource = stream;
                }
                foreach (DataGridViewRow adrow in SGStudents.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }
                SGStudents.Columns["FollowUps"].Visible = false;
                SGStudents.Columns["Delete"].Visible = false;
                SGStudents.Width =872;
                SGStudents.Height = 402;

            }

            
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (SGView.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(SGView, null);
                }
                else
                {
                    WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btn_saveview_pdf_Click(object sender, EventArgs e)
        {
            try
            {

                if (SGView.Rows.Count != 0)
                {
                    PdfParameters getParameter = new PdfParameters();
                    getParameter.name = "Name:- " + txtFname.Text;
                    getParameter.EnqNo = "EnqNo:- " + txtEnqNo.Text + "";
                    getParameter.View = "View:- " + cmbViewEnquiry.SelectedItem.ToString();
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFrmDtEnq.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDteEnq.Value);
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.Title = "Enquiry Report";
                    getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (SGView.Rows.Count != 0)

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
                            Common.ImportExport.ImportToPDF(SGView, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                            if (SGStudents.Columns.Contains("ENQ_STATE"))
                            {
                                SGStudents.Columns["ENQ_STATE"].Visible = false;

                            }
                        }
                    }
                }
                else
                {
                    WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void lblGropBy_Click(object sender, EventArgs e)
        {

        }
        //end by ashvini on 31-01-2019

    }
}





