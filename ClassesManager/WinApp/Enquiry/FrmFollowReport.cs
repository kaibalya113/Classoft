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
using ClassManager.Common;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
//using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System.IO;
namespace ClassManager.WinApp
{
    public partial class FrmFollowReport : FrmParentForm
    {

        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        DataTable dt;
        string sCaption = "All FollowUp Details";
        int EnquiryId;
        static SqlConnection con = new SqlConnection();
        public FrmFollowReport()
        {
            InitializeComponent();
        }

        private void FrmFollowReport_Load(object sender, EventArgs e)
        {
            try
            {
                //adding for proper format of date by ashvini
                UICommon.WinForm.formatDateTimePicker(dtFollowup);

                //loadfieds method is used to load parameters added in   cmb_Followpby
                loadFields();
                branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                addColumns();
                dt = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), BLL.DBHandller.getMaxSQLDate());
                ADGVFollowup.DataSource = dt;
                //LoadFollowupChart();
                cmbViewFollowUp.SelectedIndex = 1;
                getcount(dt);
                HelpPanel.Visible = true;
                AssignEvents();
                ApplyPrevileges();
                DataGridViewColumn Folloup_by = new DataGridViewColumn();

                Folloup_by.HeaderText = "Followup By";
                Folloup_by.Name = "follo";
                Folloup_by.Visible = true;
                Folloup_by.Width = 80;
                AdgvViewFolow.RowTemplate.Height = 30;

                PanelFollowUp.Visible = false;
                this.Width = 955;
                this.Height = 672;

                UICommon.WinForm.formatDateTimePicker(dtFollowup, Common.Formatter.DateFormat);

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
            ADGVFollowup.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVFollowup.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
        }
        private void addColumns()
        {
            try
            {


                if (ADGVFollowup.Columns.Contains("new_followup") == false)
                {
                    ADGVFollowup.Columns.Add(new DataGridViewImageColumn()

                    {
                        Image = Properties.Resources.Add,
                        Name = "new_followup",
                        HeaderText = " Add FollowUp"
                    });
                }

                if (ADGVFollowup.Columns.Contains("FollowUps") == false)
                {
                    ADGVFollowup.Columns.Add(new DataGridViewImageColumn()

                    {
                        Image = Properties.Resources.eye,
                        Name = "FollowUps",
                        HeaderText = "View FollowUp"
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void fomatGridView()
        {
            try
            {
                ADGVFollowup.Columns["ENQ_ID"].HeaderText = "Enquiry ID";
                ADGVFollowup.Columns["ENQ_CONTACT_NO"].HeaderText = "Mobile No";

                ADGVFollowup.Columns["FollowupDate"].Visible = false;

                ADGVFollowup.Columns["BRCH_NAME"].HeaderText = "Branch";
                ADGVFollowup.Columns["Prev_FollowUp"].HeaderText = "Last Followup";
                ADGVFollowup.Columns["Prev_FollowUp"].ReadOnly = true;

                ADGVFollowup.Columns["ENQ_STATUS"].Visible = false;
                ADGVFollowup.Columns["ENQ_BRANCH_ID"].Visible = false;
                ADGVFollowup.Columns["ENQ_IS_REGISTERED"].Visible = false;
                ADGVFollowup.Columns["ENQ_ID"].DisplayIndex = 4;
                ADGVFollowup.Columns["ENQ_ID"].ReadOnly = true;

                ADGVFollowup.Columns["Name"].DisplayIndex = 1;

                ADGVFollowup.Columns["ENQ_CONTACT_NO"].DisplayIndex = 2;
                ADGVFollowup.Columns["ENQ_CONTACT_NO"].DisplayIndex = 7;

                ADGVFollowup.Columns["BRCH_NAME"].DisplayIndex = 7;
                ADGVFollowup.Columns["BRCH_NAME"].ReadOnly = true;
                ADGVFollowup.Columns["new_followup"].DisplayIndex = ADGVFollowup.Columns.Count - 1;
                ADGVFollowup.Columns["new_followup"].HeaderText = "Add Followup";
                ADGVFollowup.Columns["FollowUps"].DisplayIndex = ADGVFollowup.Columns.Count - 2;
                ADGVFollowup.Columns["FollowUps"].HeaderText = "Followups";
                ADGVFollowup.Columns["BRCH_NAME"].Visible = false;
                ADGVFollowup.Columns["ENQ_ID"].Visible = false;
                ADGVFollowup.Columns["Prev_FollowUp"].Width = 210;
                ADGVFollowup.Columns["Name"].Width = 170;
                ADGVFollowup.Columns["Name"].ReadOnly = true;
                ADGVFollowup.Columns["ENQ_CONTACT_NO"].Width = 110;
                ADGVFollowup.Columns["ENQ_CONTACT_NO"].ReadOnly = true;
                ADGVFollowup.Columns["new_followup"].Width = 85;
                ADGVFollowup.Columns["FollowUps"].Width = 85;
                ADGVFollowup.Columns["STD_NAME"].Width = 130;
                ADGVFollowup.Columns["STD_NAME"].ReadOnly = true;
                if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Gym" || Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Dance")
                {
                    ADGVFollowup.Columns["STD_NAME"].HeaderText = "Package";
                    ADGVFollowup.Columns["STD_NAME"].DisplayIndex = 5;
                    ADGVFollowup.Columns["STD_NAME"].Width = 150;
                    ADGVFollowup.Columns["STD_NAME"].ReadOnly = true;
                }
                else
                {
                    ADGVFollowup.Columns["STD_NAME"].HeaderText = "Course";
                    ADGVFollowup.Columns["STD_NAME"].DisplayIndex = 5;
                    ADGVFollowup.Columns["STD_NAME"].ReadOnly = true;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //code upgraded for dispalying count also for 1 week followup by ashvini on 30-03-2019
        private void getcount(DataTable dt)
        {

            DateTime datetime = System.DateTime.Now.Date;

            DataView dataView = dt.AsDataView();


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
            lblTomorrow.Text = (from DataRow dRow in dataVieww.ToTable().Rows
                                select dRow["ENQ_ID"]).Distinct().Count().ToString();


        }
        //end by ashvini on 30-03-2019

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
        //code upgraded by ashvni on 30-03-2019  because adding 1 week followup 
        private void cmbViewFollowUp_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //ALL
                //Pending Followup
                //Today's Followup
                //Tomorrow's Followup

                branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

                if (cmbViewFollowUp.SelectedIndex == 0)
                {
                    DataTable dt = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), BLL.DBHandller.getMaxSQLDate());
                    DataView dataView = dt.AsDataView();
                    dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
                    ADGVFollowup.DataSource = dataView;
                }
                else if (cmbViewFollowUp.SelectedIndex == 1)
                {
                    DataTable dt = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), System.DateTime.Now.AddDays(-1));
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
        //end by ashini on 30-03-2019

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ADGVFollowup.DataSource = dt;
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

        private void ADGVFollowup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVFollowup, e);
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
                DataTable dt = BLL.FollowupHandler.CountOfFollowUp(Program.LoggedInUser.BranchId.ToString());

                foreach (DataGridViewRow row in ADGVFollowup.Rows)
                {
                    DateTime Date = Convert.ToDateTime(row.Cells["FollowupDate"].Value);
                    DateTime RealDate = Convert.ToDateTime(Date.ToShortDateString());
                    if (RealDate == Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")))
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

                //    ADGVFollowup.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        //load parameters in cmb_followBy combobox in AdgvViewFolow
        private void loadFields()
        {

            string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
            if (check == "")
            {
                cmbFollowupBy.Visible = false;

            }
            else
            {
                string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                foreach (String value in items)
                {
                    cmbFollowupBy.Items.Add(value);
                }
            }
        }
        private void ADGVFollowup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dt = null;
                if (ADGVFollowup.Columns.Contains("FollowUps") && e.ColumnIndex == ADGVFollowup.Columns["FollowUps"].Index)
                {
                    if (e.RowIndex != -1)
                    {
                        if (ADGVFollowup.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                        {//adding column FollowupBy in AdgvViewFolow by Ashvini
                            DataGridViewColumn Folloup_by = new DataGridViewColumn();
                            Folloup_by.HeaderText = "Followup By";
                            Folloup_by.Name = "follo";
                            Folloup_by.Visible = true;
                            Folloup_by.Width = 80;

                            EnquiryId = (Convert.ToInt32(ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_ID"].Value));
                            dt = BLL.FollowupHandler.viewFollowUp(EnquiryId);
                            PanelFollowUp.Visible = false;
                            pnlViewFollowUp.Visible = true;
                            AdgvViewFolow.Visible = true;
                            BtnCancel.Visible = true;
                            this.Width = 1301;
                            this.Height = 672;

                            dt = BLL.FollowupHandler.viewFollowUp(EnquiryId);
                            AdgvViewFolow.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
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
                    if (e.ColumnIndex == ADGVFollowup.Columns["new_followup"].Index)
                    {
                        if (Convert.ToBoolean(ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_IS_REGISTERED"].Value.Equals("Yes")))
                        {
                            UICommon.WinForm.showStatus("Enquiry is closed as student has already taken admission", sCaption, this);
                        }
                        else
                        {

                            EnquiryId = (Convert.ToInt32(ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_ID"].Value));
                            branchID = ADGVFollowup.Rows[e.RowIndex].Cells["ENQ_BRANCH_ID"].Value.ToString();
                            pnlViewFollowUp.Visible = false;
                            BtnCancel.Visible = false;
                            AdgvViewFolow.Visible = false;
                            PanelFollowUp.Visible = true;
                            lblStudName.Text = ADGVFollowup.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                            this.Width = 955;
                            this.Height = 672;
                        }
                    }
                }
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
                this.Width = 955;
                this.Height = 672;

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
            {    //ADDED BY ASHVINI 4-1-2019
                 //FOR displaying proper formatting04-01-2019
                if (AdgvViewFolow.Columns.Contains("Date"))
                {
                    AdgvViewFolow.Columns["Date"].Width = 80;
                    AdgvViewFolow.Columns["Date"].HeaderText = "Next Followup";

                }
                if (AdgvViewFolow.Columns.Contains("Medium"))
                {
                    AdgvViewFolow.Columns["medium"].Width = 90;

                }
                if (AdgvViewFolow.Columns.Contains("FOLU_CRTD_AT"))
                {
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].Width = 80;
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].HeaderText = "Followup On";
                    AdgvViewFolow.Columns["FOLU_CRTD_AT"].DisplayIndex = 4;

                }
                if (AdgvViewFolow.Columns.Contains("FOLU_BY"))
                {
                    AdgvViewFolow.Columns["FOLU_BY"].Width = 70;
                    AdgvViewFolow.Columns["FOLU_BY"].HeaderText = "Followup By";

                }

                if (AdgvViewFolow.Columns.Contains("Description"))
                {
                    AdgvViewFolow.Columns["Description"].Width = 200;

                }
                AdgvViewFolow.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                AdgvViewFolow.Columns[1].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }
            //end by ashvini 04-01-2019
            catch (Exception)
            {

                throw;
            }
        }

        private void saveFollowup_Click(object sender, EventArgs e)
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
                    objFollowup.FollowupBy = (cmbFollowupBy.SelectedIndex == -1 ? "NA" : cmbFollowupBy.SelectedItem.ToString());
                    BLL.FollowupHandler.SaveFollowup(objFollowup, branchID);

                    Enquiry objEnquiry = new Enquiry();

                    UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearall();
                    PanelFollowUp.Visible = false;
                    this.Width = 955;
                    this.Height = 672;
                    DataTable dt = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), System.DateTime.Now.AddDays(-1));
                    DataView dataView = dt.AsDataView();
                    dataView.RowFilter = "([ENQ_STATUS] <> 'Not Interested')";
                    ADGVFollowup.DataSource = dataView;

                    getcount(dt);

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
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
                else if (cmbMediam.SelectedItem == "")
                {
                    UICommon.WinForm.showStatus("Select Medium for followup", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtFollowup.Focus();
                    return false;
                }
                else if (txtDescription.Text == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Description.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDescription.Focus();
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



        //added by ashvini on 30-03-2019 for converting data into pdf 
        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();

                getParameter.name = "Name:- " + txtFName.Text.ToString();
                getParameter.View = "View:- " + cmbViewFollowUp.SelectedItem.ToString();
                getParameter.Title = "Followup Report";
                getParameter.BranchName = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                getParameter.count = "Followup Count:- " + ADGVFollowup.Rows.Count;
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ADGVFollowup.Rows.Count != 0)

                {
                    // chart1.Visible = true;
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Followup Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        ImportToPDF(ADGVFollowup, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        //end by ashvini on 30-03-2019
        public void ImportToPDF(ADGV.AdvancedDataGridView dgv, string pathTosave, ClassManager.Common.PdfParameters getparamvalue, bool closeApp = false)
        {   //added by ashvini 4-12-17
            //creating parameter instance to display title
            Paragraph p = new Paragraph(getparamvalue.Title, FontFactory.GetFont(FontFactory.HELVETICA, 25));
            p.Alignment = Element.ALIGN_CENTER;
            //end


            //added by ashvini 4-12-17
            //create pdftable to dispay stream, course, package
            int columns = 3;
            PdfPTable DispayHeaderInfo = new PdfPTable(columns);
            DispayHeaderInfo.HorizontalAlignment = Element.ALIGN_CENTER;
            if (getparamvalue.name != null)
            {
                Phrase str = new Phrase(getparamvalue.name, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppw = new PdfPCell(str);
                ppw.Border = PdfPCell.NO_BORDER;
                ppw.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(ppw);


            }
            if (getparamvalue.Stream != null)
            {
                Phrase str = new Phrase(getparamvalue.Stream, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pp = new PdfPCell(str);
                pp.Border = PdfPCell.NO_BORDER;
                pp.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(pp);
            }



            if (getparamvalue.Course != null)
            {
                Phrase course = new Phrase(getparamvalue.Course, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppp = new PdfPCell(course);
                ppp.Border = PdfPCell.NO_BORDER;
                ppp.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(ppp);


            }

            if (getparamvalue.EnqNo != null)
            {
                Phrase course = new Phrase(getparamvalue.EnqNo, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppt = new PdfPCell(course);
                ppt.Border = PdfPCell.NO_BORDER;
                ppt.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(ppt);
            }

            if (getparamvalue.View != null)
            {
                Phrase course = new Phrase(getparamvalue.View, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell fd = new PdfPCell(course);
                fd.Border = PdfPCell.NO_BORDER;
                fd.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(fd);

            }

            if (getparamvalue.Package != null)
            {
                Phrase pack = new Phrase(getparamvalue.Package, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pppp = new PdfPCell(pack);
                pppp.Border = PdfPCell.NO_BORDER;
                pppp.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(pppp);
            }

            if (getparamvalue.BranchName != "" && getparamvalue.BranchName != null)
            {
                Phrase br = new Phrase(getparamvalue.BranchName, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell cn = new PdfPCell(br);
                cn.Border = PdfPCell.NO_BORDER;
                cn.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(cn);
            }

            if (getparamvalue.Contact != "" && getparamvalue.Contact != null)
            {
                Phrase br = new Phrase(getparamvalue.Contact, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell cn = new PdfPCell(br);
                cn.Border = PdfPCell.NO_BORDER;
                cn.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(cn);
            }

            if (getparamvalue.ParentNo != null)
            {
                Phrase pn = new Phrase(getparamvalue.ParentNo, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pm = new PdfPCell(pn);
                pm.Border = PdfPCell.NO_BORDER;
                pm.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(pm);
            }
            //end

            //added by ashvini 4-12-17
            //create pdfptable instance to display branch,fromdate,todate.

            int columnsForSecond = 3;
            PdfPTable DisplayHeaderInfo = new PdfPTable(columnsForSecond);

            if (getparamvalue.FromDate != "" && getparamvalue.FromDate != null)

            {
                Phrase fdate = new Phrase(getparamvalue.FromDate, FontFactory.GetFont("Arial", 15));
                PdfPCell c2 = new PdfPCell(fdate);
                c2.Border = PdfPCell.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c2);
            }
            if (getparamvalue.ToDate != "" && getparamvalue.ToDate != null)
            {
                Phrase Ldate = new Phrase(getparamvalue.ToDate, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell c3 = new PdfPCell(Ldate);
                c3.Border = PdfPCell.NO_BORDER;
                c3.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c3);
            }
            if (getparamvalue.GroupBy != null)
            {
                Phrase gb = new Phrase(getparamvalue.GroupBy, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell g = new PdfPCell(gb);
                g.Border = PdfPCell.NO_BORDER;
                g.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(g);
            }
            if (getparamvalue.Branch != "" && getparamvalue.Branch != null)
            {
                Phrase br = new Phrase(getparamvalue.Branch, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell c1 = new PdfPCell(br);
                c1.Border = PdfPCell.NO_BORDER;
                c1.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c1);
            }
            if (getparamvalue.att_View != null)
            {
                Phrase vw = new Phrase(getparamvalue.att_View, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell va = new PdfPCell(vw);
                va.Border = PdfPCell.NO_BORDER;
                va.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(va);
            }
            int columnsForFooter = 1;
            PdfPTable DisplayFooter = new PdfPTable(columnsForFooter);


            {
                Phrase co = new Phrase(getparamvalue.count, FontFactory.GetFont("Arial", 19));
                PdfPCell c2 = new PdfPCell(co);
                c2.Border = PdfPCell.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_RIGHT;
                DisplayFooter.AddCell(c2);
            }
            Paragraph p2 = new Paragraph(getparamvalue.Footer, FontFactory.GetFont(FontFactory.HELVETICA, 10));
            p2.Alignment = Element.ALIGN_CENTER;
            //added by ashvini 4-12-17


            //added by ashvini 4-12-17
            //get visible rows count of gridview.      
            int f2 = 3;
            PdfPTable Dispayfooter = new PdfPTable(f2);
            Dispayfooter.HorizontalAlignment = Element.ALIGN_CENTER;
            if (getparamvalue.Present != null)
            {
                Phrase str = new Phrase(getparamvalue.Present, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppw = new PdfPCell(str);
                ppw.Border = PdfPCell.NO_BORDER;
                ppw.HorizontalAlignment = Element.ALIGN_CENTER;
                Dispayfooter.AddCell(ppw);


            }
            if (getparamvalue.Absent != null)
            {
                Phrase str = new Phrase(getparamvalue.Absent, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pp = new PdfPCell(str);
                pp.Border = PdfPCell.NO_BORDER;
                pp.HorizontalAlignment = Element.ALIGN_CENTER;
                Dispayfooter.AddCell(pp);
            }



            if (getparamvalue.Total != null)
            {
                Phrase course = new Phrase(getparamvalue.Total, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppp = new PdfPCell(course);
                ppp.Border = PdfPCell.NO_BORDER;
                ppp.HorizontalAlignment = Element.ALIGN_CENTER;
                Dispayfooter.AddCell(ppp);


            }

            int TotalColumns = 0;
            int Colount = 0;
            for (int m = 1; m < dgv.Columns.Count + 1; m++)
            {
                if (dgv.Columns[m - 1].Visible == true && (dgv.Columns[m - 1].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                {
                    Colount = TotalColumns + 1;
                    TotalColumns++;
                }
            }
            //end

            //added by ashvini 4-12-17
            //added for new line
            int columnForNewline = 1;
            PdfPTable pdfname = new PdfPTable(columnForNewline);
            Phrase phSpace = new Phrase("\n");
            PdfPCell clSpace = new PdfPCell(phSpace);
            clSpace.Border = PdfPCell.NO_BORDER;
            clSpace.Colspan = columns;
            pdfname.AddCell(clSpace);
            PdfPTable pdfTable = new PdfPTable(Colount);
            pdfTable.DefaultCell.Padding = 6;
            pdfTable.HorizontalAlignment = 4;



            //added by ashvini 4-12-17
            //used to set headertext in pdf
            if (dgv.Rows.Count > 0)
            {


                int PDFColumnIndex = 1;
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    if (dgv.Columns[i - 1].Visible == true && (dgv.Columns[i - 1].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                    {
                        string s = (dgv.Columns[i - 1].HeaderText);
                        Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD));
                        PdfPCell head = new PdfPCell(ph);
                        head.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));
                        head.PaddingBottom = 6;

                        head.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                        //var width = e.PdfPage.GetClientSize().Width;
                        pdfTable.AddCell(head);
                        PDFColumnIndex++;

                    }


                }


                //end

                //added by ashvini 4-12-17
                //by using these get data and ignore those columns data which contain images.
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    PDFColumnIndex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                        {
                            if (dgv.Rows[i].Cells[j].Value != null)
                            {
                                PdfPCell pdfcell = new PdfPCell(new Phrase(dgv.Rows[i].Cells[j].FormattedValue.ToString()));
                                //  cell.Width = 200;
                                pdfcell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#f1f5f6"));
                                pdfcell.PaddingBottom = 6;
                                //  pdfcell.Width = 60;

                                pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

                                pdfTable.AddCell(pdfcell);
                            }
                            PDFColumnIndex++;
                        }
                    }
                }
            }

            //added by ashvini 4-12-17
            //used to set path and create documen and dispay pdf data.             
            using (FileStream stream = new FileStream(pathTosave, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(p);

                pdfDoc.Add(pdfname);

                pdfDoc.Add(DispayHeaderInfo);
                pdfDoc.Add(DisplayHeaderInfo);

                pdfDoc.Add(pdfname);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfname);
                pdfDoc.Add(Dispayfooter);
                pdfDoc.Add(DisplayFooter);
                ///  chart1.SaveImage(stream, ChartImageFormat.Png);

                pdfDoc.Add(p2);
                pdfDoc.Close();
                stream.Close();
            }



        }

    }
}
