using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmFollowUpVew :FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        DataTable dt;
        int EnquiryId;
        string sCaption = "All FollowUp Details";        
        static SqlConnection con = new SqlConnection();
        int pageIndex = 1;
        int PageSize = 20;
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmFollowUpVew()
        {
            InitializeComponent();
        }

        private void FollowUp_Load(object sender, EventArgs e)
        {
            try {
               
                formatdate();
              
                branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                ColumnfollowUp();
                dt = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), BLL.DBHandller.getMaxSQLDate());
                
              
               ADGVFollowup.DataSource = dt;
                cmbViewFollowUp.SelectedIndex = 1;
                getcount(dt);
                AssignEvents();
                ApplyPrevileges();
                PanelFollowup.Visible = false;
                this.Width = 1000;
                this.Height = 657;
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
                        chkShowAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {
                        btnNewFollowup.Visible = false;
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
        private void ColumnfollowUp()
        {
            try
            {
                DataGridViewButtonColumn Btn = new DataGridViewButtonColumn();
                Btn.Name = "new_followup";
                Btn.Text = "Follow";
                Btn.HeaderText = "Follow Up";
                Btn.DefaultCellStyle.NullValue = "FollowUp";

                int columnIndex = 0;
                if (ADGVFollowup.Columns["new_followup"] == null)
                {
                    ADGVFollowup.Columns.Insert(columnIndex, Btn);
                }

                //  DataTable dt = BLL.FollowupHandler.CountOfFollowUp(Program.LoggedInUser.BranchId.ToString());
                DataGridViewLinkColumn link = new DataGridViewLinkColumn();
                link.Name = "FollowUps";
                link.HeaderText = "View FollowUps";
                link.Text = "FollowUp";
                link.DefaultCellStyle.NullValue = "Followup";
                link.Width = 98;
                link.MinimumWidth = 22;

                int column = 1;
                if (ADGVFollowup.Columns["FollowUps"] == null)
                {
                    ADGVFollowup.Columns.Insert(column, link);
                }

                
                ADGVFollowup.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.eye,
                    Name = "FollowUp",
                    HeaderText = "View FollowUp"
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void formatdate()
        {
            UICommon.WinForm.setDate(dtFrmDate, dtToDate);
            UICommon.WinForm.formatDateTimePicker(dtToDate);
            UICommon.WinForm.formatDateTimePicker(dtFrmDate);
        }


        private void AssignEvents()
        {
            ADGVFollowup.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVFollowup.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
        }
        
        private void txtFName_TextChanged(object sender, EventArgs e)
       {
            try
            {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = ADGVFollowup.DataSource;
                bs.Filter = string.Format("Name LIKE '%{0}%'", txtFName.Text);
               // bs.Filter = ADGVFollowup.Columns["Name"].HeaderText.ToString() + " LIKE '%" + txtFName.Text + "%'";
                ADGVFollowup.DataSource = bs;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            } 
        }

        private void getcount(DataTable dt)
        {

            DateTime datetime = System.DateTime.Now.Date;

            DataView dataView = dt.AsDataView();


            //All Followup count
            dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
            lblAll.Text = (from DataRow dRow in dataView.ToTable().Rows
                          select dRow["ENQ_ID"]).Distinct().Count().ToString();


            //Pending Followup
            dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested') and FollowupDate < #" + Common.Formatter.FormatDate(datetime) + "#";
            lblInactive.Text = (from DataRow dRow in dataView.ToTable().Rows
                                select dRow["ENQ_ID"]).Distinct().Count().ToString();

            //Todays Followups
            dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested') and FollowupDate  = #" + Common.Formatter.FormatDate(datetime) + "#";
            lblToday.Text = (from DataRow dRow in dataView.ToTable().Rows
                             select dRow["ENQ_ID"]).Distinct().Count().ToString();

            //Tomorrows Followups
            DataTable dtW = FollowupHandler.getFolloups(branchID, System.DateTime.Now, System.DateTime.Now.AddDays(7));
            DataView dataVieww = dtW.AsDataView();
            dataVieww.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
           // dataVieww.RowFilter = "([ENQ_STATUS] <> 'Not Interested') and  FollowupDate  >= #* and   FollowupDate  < #" + Common.Formatter.FormatDate(datetime.AddDays(7)) + "#" +Common.Formatter.FormatDate(datetime) + "#*";
            lblTomorrow.Text = (from DataRow dRow in dataVieww.ToTable().Rows
                                select dRow["ENQ_ID"]).Distinct().Count().ToString();


        }
        //code upgraded by ashvini on 30-03-2019 for filter on 1 week followup
        private void cmbViewFollowUp_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //ALL
                //Pending Followup
                //Today's Followup
                //Tomorrow's Followup

                if (chkShowAllBranch.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                }

                if (cmbViewFollowUp.SelectedIndex == 0)
                {                    
                    DataTable dt = FollowupHandler.getFolloups(branchID,BLL.DBHandller.getMinSQLDate(), BLL.DBHandller.getMaxSQLDate());
                    DataView dataView = dt.AsDataView();
                    dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
                    ADGVFollowup.DataSource = dataView;
                }
                else if (cmbViewFollowUp.SelectedIndex == 1)
                { 
                    DataTable dt = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(),System.DateTime.Now.AddDays(-1));
                    DataView dataView = dt.AsDataView();
                    dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
                    ADGVFollowup.DataSource = dataView;
                    foreach (DataGridViewRow row in ADGVFollowup.Rows)
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EF9A9A");
                    }
                }
                else if (cmbViewFollowUp.SelectedIndex == 2)
                {   
                    DataTable dt = FollowupHandler.getFolloups(branchID, System.DateTime.Now, System.DateTime.Now);
                    DataView dataView = dt.AsDataView();
                    dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
                    ADGVFollowup.DataSource = dataView;
                    foreach (DataGridViewRow Todayrow in ADGVFollowup.Rows)
                    {
                        Todayrow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF176");
                    }

                }
                else if (cmbViewFollowUp.SelectedIndex == 3)
                {
                    DataTable dt = FollowupHandler.getFolloups(branchID, System.DateTime.Now, System.DateTime.Now.AddDays(7));
                    DataView dataView = dt.AsDataView();
                    dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
                    ADGVFollowup.DataSource = dataView;
                    foreach (DataGridViewRow Tomrwrow in ADGVFollowup.Rows)
                    {
                        Tomrwrow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#AED581");
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }
        //end by ashvini on 30-03-2019
        

        public void fomatGridView()
        {
            try
            {
                ADGVFollowup.ReadOnly = true;
                ADGVFollowup.Columns["ENQ_ID"].HeaderText = "Enquiry ID";
                ADGVFollowup.Columns["ENQ_CONTACT_NO"].HeaderText = "Contact No";
                ADGVFollowup.Columns["FollowupDate"].HeaderText = "Followup Date";
               // ADGVFollowup.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";
                ADGVFollowup.Columns["BRCH_NAME"].HeaderText = "Branch";
                ADGVFollowup.Columns["BRCH_NAME"].Visible = false;
                ADGVFollowup.Columns["Prev_FollowUp"].HeaderText = "Next FollowUp";
                ADGVFollowup.Columns["ENQ_STATUS"].Visible = false;
                ADGVFollowup.Columns["ENQ_BRANCH_ID"].Visible = false;
                ADGVFollowup.Columns["ENQ_IS_REGISTERED"].Visible = false;
                ADGVFollowup.Columns["ENQ_ID"].DisplayIndex =1;
                ADGVFollowup.Columns["FollowupDate"].Visible = false;
                ADGVFollowup.Columns["Name"].DisplayIndex = 2;
               
                ADGVFollowup.Columns["ENQ_CONTACT_NO"].DisplayIndex = 4;
             
                ADGVFollowup.Columns["BRCH_NAME"].DisplayIndex = ADGVFollowup.Columns.Count -1;
                ADGVFollowup.Columns["Prev_FollowUp"].DisplayIndex = 5;
                if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Gym" || Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Dance")
                {
                    ADGVFollowup.Columns["STD_NAME"].HeaderText = "PackageName";
                    ADGVFollowup.Columns["STD_NAME"].DisplayIndex = 3;
                }
                else
                {
                    ADGVFollowup.Columns["STD_NAME"].HeaderText = "Course";
                    ADGVFollowup.Columns["STD_NAME"].DisplayIndex = 3;
                }

                ADGVFollowup.Columns["FollowupDate"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                ADGVFollowup.Columns["new_followup"].Visible = false;
                ADGVFollowup.Columns["FollowUps"].Visible = false;
                ADGVFollowup.Columns["FollowUps"].ReadOnly = false;
                ADGVFollowup.Columns["FollowUp"].DisplayIndex = ADGVFollowup.Columns.Count - 2;
                ADGVFollowup.Columns["Prev_FollowUp"].Width = 150;
                ADGVFollowup.Columns["Name"].Width = 140;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVFollowup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                fomatGridView();
               
                foreach(DataGridViewRow row in ADGVFollowup.Rows)
                {
                   // DateTime Date1 = Convert.ToDateTime(row.Cells[6].Value);
                    DateTime Date =Convert.ToDateTime(row.Cells[7].Value);
                    DateTime RealDate = Convert.ToDateTime(Date.ToShortDateString()) ;
                    if ( RealDate == Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")))
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF176");//high
                    }
                    if (RealDate > Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")))
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#AED581");//low
                    }
                    if (RealDate < Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")))
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EF9A9A");//mid
                    }
                }
                foreach (DataGridViewRow adrow in ADGVFollowup.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

               ADGVFollowup.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
            
        }

        private void dtFrmDate_CloseUp(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (dtFrmDate.Value < dtToDate.Value)
                {
                    ADGVFollowup.DataSource = null;

                    string Fromdate = dtFrmDate.Value.ToShortDateString();
                    string Todate = dtToDate.Value.ToShortDateString();
                    DataTable dt = FollowupHandler.getFolloups(branchID, Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate));
  

                    ADGVFollowup.DataSource = dt;
                 //   cmbViewFollowUp.SelectedIndex = 0;
                    getcount(dt);
                }
                else
                {
                    UICommon.WinForm.showStatus("From Date Cannot be Greater than ToDate",null,null);
                }
            
            }
           
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
       }

        private void ADGVFollowup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVFollowup, e);
        }

        private void btnNewFollowup_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUp).Visible = true;
                this.Close();
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
              
                if (ADGVFollowup.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVFollowup, null);
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

        private void ADGVFollowup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                   

                DataTable dt = null;
                if (ADGVFollowup.Columns.Contains("FollowUp") && e.ColumnIndex == ADGVFollowup.Columns["FollowUp"].Index)
                {
                    if (e.RowIndex != -1)
                    {
                        if (ADGVFollowup.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                        {

                            EnquiryId = (Convert.ToInt32(ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_ID"].Value));
                            dt = BLL.FollowupHandler.viewFollowUp(EnquiryId);
                            PanelFollowup.Visible = true;
                            
                            AdgvViewFolow.Visible = true;
                            BtnCancel.Visible = true;
                            this.Width = 1386; 
                            this.Height = 657;

                            dt = BLL.FollowupHandler.viewFollowUp(EnquiryId);
                            AdgvViewFolow.DataSource = dt;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       

        private void ADGVFollowup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex ==ADGVFollowup.Columns["new_followup"].Index)
                    {
                        if (Convert.ToBoolean(ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_IS_REGISTERED"].Value.Equals("Yes")))
                        {
                            UICommon.WinForm.showStatus("Enquiry is closed as student has already taken admission", sCaption, this);
                        }
                        else
                        {
                            UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUp).Visible = false;
                            branchID = ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_BRANCH_ID"].Value.ToString();
                            FrmFollowUp frmFollowUp = UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUp, null, true) as FrmFollowUp;
                            frmFollowUp.setEnquiry((Convert.ToInt32(ADGVFollowup.Rows[e.RowIndex].Cells[2].Value)), branchID);
                            this.Hide();
                            frmFollowUp.ShowDialog();

                        }
                    }
                }
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
                if (ADGVFollowup.Rows.Count != 0)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFrmDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BtnCancel.Visible = false;
                PanelFollowup.Visible = false;
                AdgvViewFolow.Visible = false;
                this.Width = 1046;
                this.Height = 657;

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
            catch (Exception)
            {

                throw;
            }
        }

        private void AdgvViewFolow_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {//added by ashvini for proper formatting02-01-2019
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
                    AdgvViewFolow.Columns["FOLU_BY"].Width = 80;
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

                foreach (DataGridViewRow adrow in AdgvViewFolow.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

                //endby ashvini 02-01-2019
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

}
