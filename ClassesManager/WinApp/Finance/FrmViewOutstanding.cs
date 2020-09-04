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
using ClassManager.Info;
using ClassManager.BLL;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmViewOutstanding : FrmParentForm
    {
        RolePrivilege formPrevileges;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        const string sCaption = "Outstanding Fees";
        DataTable objAllStdOutstanding;
        DataSet dsAllOutstanding;
        DataGridViewCheckBoxColumn chkEmail = new DataGridViewCheckBoxColumn();
        DataTable dtMembers; DataView newList;
        int AdmissionNo;
        public static Info.Student objStudent;

        public FrmViewOutstanding()
        {
            InitializeComponent();
        }

        private void FrmViewOutstanding_Load(object sender, EventArgs e)
        {
            try
            {
                BtnCancel.Visible = false;
                UICommon.WinForm.formatDateTimePicker(dtFollowup);

                SGOutstFees.RowTemplate.MinimumHeight = 30;
                SGOutstFees.RowTemplate.Height = 30;
                SGOutstFees.PageSize = 30;
                SGOutstFees.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

                AdgvViewFolow.RowTemplate.Height = 30;
                AdgvViewFolow.RowTemplate.MinimumHeight = 30;

                loadData(branchID, true);
                loadFields();
                addcolumn();
                ApplyPrevileges();

                PanelFollowUp.Visible = false;
                pnlFolloupGrid.Visible = false;
                this.Height = 458;
                this.Width = 806;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //Load parameters in cmb_ cmb_Followpby combobox in AdgvViewFolow
        private void loadFields()
        {

            string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
            if (check == "")
            {
                cmbFollowpby.Visible = false;
            }
            else
            {
                string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                foreach (String value in items)
                {
                    cmbFollowpby.Items.Add(value);
                }
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
                        // chkAllBranchs.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {
                        btnSend.Visible = false;
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

        private void loadFee(string branchId, bool formLoad = false, DataView newList = null)
        {
            try
            {


                if (newList == null)
                {
                    newList = new DataView(objAllStdOutstanding);
                }

                else if (newList.Count > 0)
                {

                    SGOutstFees.DataSource = newList;
                    SGOutstFees.SetPagedDataSource((newList.ToTable()), bindingNavigator1);
                }

                calculate(newList);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void clearTotal()
        {
            try
            {

                lblTotalOtst.Text = "0";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void calculate(DataView lst)
        {
            try
            {
                if (lst != null)
                {
                    DataTable dt = lst.ToTable();
                    if (dt.Rows.Count != 0)
                    {
                        lblTotalOtst.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Total Outstanding])", "")));
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void formatADGVOutstFeesGrid()
        {
            try
            {
                int displayIndex = 0;
                SGOutstFees.Columns[0].ReadOnly = false;
                SGOutstFees.Columns[1].ReadOnly = false;
                SGOutstFees.Columns["chkEmail"].Visible = true;
                SGOutstFees.Columns["chkEmail"].Width = 60;

                if (SGOutstFees.Columns.Contains("STD_ID"))
                {
                    SGOutstFees.Columns["STD_ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("STD_STREAM_ID"))
                {
                    SGOutstFees.Columns["STD_STREAM_ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("STRM_NAME"))
                {
                    SGOutstFees.Columns["STRM_NAME"].HeaderText = "Stream";
                    SGOutstFees.Columns["STRM_NAME"].ReadOnly = true;
                }
                if (SGOutstFees.Columns.Contains("STD_NAME"))
                {
                    SGOutstFees.Columns["STD_NAME"].HeaderText = "Package";
                    SGOutstFees.Columns["STD_NAME"].Width = 90;
                }
                if (SGOutstFees.Columns.Contains("Name"))
                {
                    SGOutstFees.Columns["Name"].HeaderText = "Member Name";
                    SGOutstFees.Columns["Name"].DisplayIndex = ++displayIndex;
                    SGOutstFees.Columns["Name"].Width = 200;
                }
                //  SGOutstFees.Columns["Name"].HeaderText = "Member Name";
                //SGOutstFees.Columns["Roll No"].Visible = false;
                if (SGOutstFees.Columns.Contains("ID"))
                {
                    SGOutstFees.Columns["ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("AdmissionNo"))
                {
                    SGOutstFees.Columns["AdmissionNo"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("Admission"))
                {
                    SGOutstFees.Columns["Admission"].HeaderText = Lang.translate("AdmissionNo");
                }
                if (SGOutstFees.Columns.Contains("ID"))
                {
                    SGOutstFees.Columns["ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("Today Due"))
                {
                    SGOutstFees.Columns["Today Due"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("TodayDue"))
                {
                    SGOutstFees.Columns["TodayDue"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("CancelledAmount"))
                {
                    SGOutstFees.Columns["CancelledAmount"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("STRM_NAME"))
                {
                    SGOutstFees.Columns["STRM_NAME"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("Package Name"))
                {
                    SGOutstFees.Columns["Package Name"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("Email ID"))
                {
                    SGOutstFees.Columns["Email ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("Batch"))
                {
                    SGOutstFees.Columns["Batch"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("Branch"))
                {
                    SGOutstFees.Columns["Branch"].Visible = false;
                }


                if (SGOutstFees.Columns.Contains("btnPayFees"))
                {
                    SGOutstFees.Columns["btnPayFees"].DisplayIndex = 1;

                }

                int currentIndex = ++displayIndex;
                if (SGOutstFees.Columns.Contains("Total Outstanding"))
                {
                    SGOutstFees.Columns["Total Outstanding"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["Total Outstanding"].HeaderText = "Outstanding";
                    SGOutstFees.Columns["Total Outstanding"].Width = 100;
                    SGOutstFees.Columns["Total Outstanding"].DisplayIndex = 5;
                    SGOutstFees.Columns["Total Outstanding"].ReadOnly = true;

                }

                currentIndex = ++displayIndex;
                if (SGOutstFees.Columns.Contains("Contact No"))
                {
                    SGOutstFees.Columns["Contact No"].HeaderText = "Contact";
                    SGOutstFees.Columns["Contact No"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["Contact No"].Width = 100;
                    SGOutstFees.Columns["Contact No"].ReadOnly = true;
                }

                if (SGOutstFees.Columns.Contains("Contact"))
                {
                    SGOutstFees.Columns["Contact"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["Contact"].Width = 100;
                    SGOutstFees.Columns["Contact"].ReadOnly = true;
                }
                //added by ashvini 7-12
                //displaying parent no in case of class
                string app = SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                if (app == "" || app == "Asset")
                {
                    if (SGOutstFees.Columns.Contains("Parent's No"))
                    {
                        SGOutstFees.Columns["Parent's No"].DisplayIndex = ++displayIndex;
                        SGOutstFees.Columns["Parent's No"].Width = 100;
                        SGOutstFees.Columns["Parent's No"].HeaderText = "Parent Contact";
                        SGOutstFees.Columns["Parent's No"].ReadOnly = true;
                    }
                }
                else
                {
                    SGOutstFees.Columns["Parent's No"].Visible = false;
                }

                currentIndex = ++displayIndex;
                if (SGOutstFees.Columns.Contains("Fees Paid"))
                {
                    SGOutstFees.Columns["Fees Paid"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["Fees Paid"].Width = 90;
                    SGOutstFees.Columns["Fees Paid"].ReadOnly = true;
                }
                if (SGOutstFees.Columns.Contains("FeesPaid"))
                {
                    SGOutstFees.Columns["FeesPaid"].ReadOnly = true;
                    SGOutstFees.Columns["FeesPaid"].Width = 90;
                    SGOutstFees.Columns["FeesPaid"].DisplayIndex = currentIndex;
                }

                if (SGOutstFees.Columns.Contains("Discount"))
                {
                    SGOutstFees.Columns["Discount"].DisplayIndex = ++displayIndex;
                    SGOutstFees.Columns["Discount"].Width = 90;
                    SGOutstFees.Columns["Discount"].ReadOnly = true;
                }

                currentIndex = ++displayIndex;
                if (SGOutstFees.Columns.Contains("Total Fees"))
                {
                    SGOutstFees.Columns["Total Fees"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["Total Fees"].ReadOnly = true;
                }
                if (SGOutstFees.Columns.Contains("TotalFees"))
                {
                    SGOutstFees.Columns["TotalFees"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["TotalFees"].ReadOnly = true;
                }

                currentIndex = ++displayIndex;
                if (SGOutstFees.Columns.Contains("STD_NAME"))
                {
                    SGOutstFees.Columns["STD_NAME"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["STD_NAME"].ReadOnly = true;
                }
                if (SGOutstFees.Columns.Contains("Package"))
                {
                    SGOutstFees.Columns["Package"].DisplayIndex = currentIndex;
                    SGOutstFees.Columns["Package"].Width = 150;
                    SGOutstFees.Columns["Package"].ReadOnly = true;
                }


                if (SGOutstFees.Columns.Contains("View"))
                {
                    SGOutstFees.Columns["View"].HeaderText = "Followups";
                    SGOutstFees.Columns["View"].DisplayIndex = SGOutstFees.Columns.Count - 2;
                    SGOutstFees.Columns["View"].Width = 100;
                 
                }
                //string app = SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);

                if (SGOutstFees.Columns.Contains("NewFollowUp"))
                {
                    SGOutstFees.Columns["NewFollowUp"].HeaderText = "New Followup";
                    SGOutstFees.Columns["NewFollowUp"].DisplayIndex = SGOutstFees.Columns.Count - 1;
                    SGOutstFees.Columns["NewFollowup"].Width = 130;
                }


            
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = objAllStdOutstanding;
                bs.Filter = string.Format("Name LIKE '%{0}%'", txtFName.Text);
            
                SGOutstFees.DataSource = bs;

                
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void loadAllFees(String mode, DateTime date, DateTime? todate = null, bool formLoad = false)
        {
            try
            {
                newList = null;
                SGOutstFees.DataSource = null;
                 objAllStdOutstanding = BLL.FeesHandller.getOutstandingFees(branchID,true, date,"%","%","%",todate);
                SGOutstFees.PageSize = 25;
                SGOutstFees.SetPagedDataSource(objAllStdOutstanding, bindingNavigator1);

                dsAllOutstanding = new DataSet();
                dsAllOutstanding.Tables.Add(objAllStdOutstanding);

                switch (mode)
                {
                    case "ALL":
                        newList = new DataView(objAllStdOutstanding);
                        break;
                    case "TODAY":
                        newList = new DataView(objAllStdOutstanding);
                        newList.RowFilter = "[Today Due] > 0";
                        break;
                    case "ALLOUTSTANDING":
                        newList = new DataView(objAllStdOutstanding);
                        newList.RowFilter = "[Total Outstanding]  > 0";
                        break;
                    case "CUSTOM_DATE":
                        newList = new DataView(objAllStdOutstanding);
                        newList.RowFilter = "[Today Due] > 0";
                        break;

                }
                if (newList.Count == 0)
                {
                    UICommon.FormFactory.setMainFormStatus("No data for selected course");
                    loadFee(branchID, formLoad, newList);
                }
                else
                {
                    loadFee(branchID, formLoad, newList);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                loadAllFees("ALLOUTSTANDING", System.DateTime.Now);
                SGOutstFees.DataSource = newList;
                foreach (DataGridViewRow gvrFees in SGOutstFees.Rows)
                {
                    DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrFees.Cells[0];
                    chckBx.Value = chkSelectAll.Checked;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                List<Int32> lstAdmsnNo = new List<Int32>();
                DataTable dtOutstanding = new DataTable();

                if (chkSelectAll.Checked)
                {
                    foreach (DataGridViewRow gvrFees in SGOutstFees.Rows)
                    {
                        lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[4].Value));
                    }
                }
                else
                {
                    foreach (DataGridViewRow gvrFees in SGOutstFees.Rows)
                    {
                        if (gvrFees.Cells[0].Value != null && (Boolean)gvrFees.Cells[0].Value == true)
                        {
                            lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[4].Value));

                        }
                    }
                }
                lstAdmsnNo = lstAdmsnNo.Select(admissionNos => admissionNos).Distinct().ToList();

                if (lstAdmsnNo.Count != 0)
                {
                    btnSend.Enabled = true;
                    bgwOutstandingSMS.RunWorkerAsync(lstAdmsnNo);
                }
                else
                {
                    UICommon.WinForm.showStatus("No Student Selected to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
                }
            }

            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }

            }
        }

        private void bgwOutstandingSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<Int32> objStudent = (List<Int32>)e.Argument;
                if (chkApplyDateFilter.Checked)
                {
                    MailHandler.sendOutstandingFeesNotification(objStudent, dtFrmDte.Value, true, true, Program.LoggedInUser.BranchId,dtToDte.Value);
                }
                else
                {
                    MailHandler.sendOutstandingFeesNotification(objStudent, DateTime.Now, true, true, Program.LoggedInUser.BranchId);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bgwOutstandingSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
                }
                else
                {
                    btnSend.Enabled = true;
                    UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SGOutstFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                UICommon.WinForm.formatDateTimePicker(dtFollowup);
                AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

                if (e.RowIndex != -1)
                { int studfacilityID;
                    if (SGOutstFees.Columns.Contains("AdmissionNo"))
                    {
                        AdmissionNo = (Convert.ToInt32(SGOutstFees.Rows[e.RowIndex].Cells["AdmissionNo"].Value));
                    }
                    else

                    {
                        AdmissionNo = (Convert.ToInt32(SGOutstFees.Rows[e.RowIndex].Cells["AdmissionNo"].Value));
                    }
                    if (e.ColumnIndex == 0)
                    {
                        DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)SGOutstFees.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        chckBx.Value = !(Boolean)chckBx.Selected;
                    }
                 if (SGOutstFees.Columns.Contains("btnPayFees") && e.ColumnIndex == SGOutstFees.Columns["btnPayFees"].Index)

                    {
                        objStudent = BLL.StudentHandller.GetStudent(AdmissionNo, null, null, null, Program.LoggedInUser.BranchId);
                        DataGridViewRow selectedRow = SGOutstFees.Rows[e.RowIndex];
                      // studfacilityID = (Convert.ToInt32(selectedRow.Cells["Id"].Value));


                        FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
                        objRedirect.LoadFeeDetailsFromRegistration(objStudent);
                        UICommon.FormFactory.GetForm(UICommon.Forms.FrmFeesPayment).Visible = true;
                        objRedirect.Visible = true;

                    }
                        }
                        //added for displaying StudentDetails on clicking on name column in SGOutstFees grid
                        if (SGOutstFees.Columns.Contains("Name") && e.ColumnIndex == SGOutstFees.Columns["Name"].Index)
                    {


                        StudentDetailsParent objStudentDetails = (StudentDetailsParent)FormFactory.GetForm(Forms.FrmStudentDetails, this, true);

                        objStudentDetails.loadStudent(AdmissionNo);
                        objStudentDetails.ShowDialog();

                    }
                    else if (SGOutstFees.Columns.Contains("View") && e.ColumnIndex == SGOutstFees.Columns["View"].Index)
                    {

                    pnlFolloupGrid.Visible = true;
                    PanelFollowUp.Visible = false;
                        AdgvViewFolow.Visible = true;
                    BtnCancel.Visible = true;
                    this.Width = 1300;
                    this.Height = 700;

                    DataTable dt = BLL.FollowupHandler.getFollowupofoutstanding(AdmissionNo, branchID);
                        AdgvViewFolow.DataSource = dt;
                    }
                    else if (SGOutstFees.Columns.Contains("NewFollowup") && e.ColumnIndex == SGOutstFees.Columns["NewFollowup"].Index)
                    {
                        PanelFollowUp.Visible = true;
                        AdgvViewFolow.Visible = false;
                        pnlFolloupGrid.Visible = false;
                    BtnCancel.Visible = true;
                    this.Width = 1100;
                    this.Height = 600;
                       // lblStudName.Text = SGOutstFees.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    }
                

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void SGOutstFees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVOutstFeesGrid();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void SGOutstFees_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(SGOutstFees, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
      private void addcolumn()
        {
         SGOutstFees.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.pay,
                Name = "btnPayFees",
                HeaderText = "Pay Fees"
            });
        }
        private void loadData(string branchId, bool formLoad = false)
        {
            try
            {
                AssignEvents();


                //Add Checkbox in datagridview
                DataGridViewCheckBoxColumn chkEmail = new DataGridViewCheckBoxColumn();
                chkEmail.Name = "chkEmail";
                chkEmail.HeaderText = "Send";
                chkEmail.TrueValue = true;
                chkEmail.FalseValue = false;
                chkEmail.ReadOnly = false;
                chkEmail.Selected = false;
                SGOutstFees.Columns.Insert(0, chkEmail);
          
                loadAllFees("ALLOUTSTANDING", System.DateTime.Now);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void AssignEvents()
        {
            try
            {
                txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                SGOutstFees.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
                SGOutstFees.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
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
                AdgvViewFolow.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSaveFollowup_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFollowupDetails())
                {
                    Followup objFollowup = new Followup();
                    objFollowup.ReferenceID = AdmissionNo.ToString();
                    objFollowup.FollowupType = "OutstandingDue";
                    objFollowup.FollowupDate = dtFollowup.Value;
                    objFollowup.FollowupDesc = txtDescription.Text;
                    objFollowup.FollowupMediam = cmbMediam.Text;
                    objFollowup.FollowupBy = (cmbFollowpby.SelectedIndex == -1 ? "NA" : cmbFollowpby.SelectedItem.ToString());
                    BLL.FollowupHandler.SaveFollowup(objFollowup, branchID);

                    Enquiry objEnquiry = new Enquiry();

                    UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearall();
                    PanelFollowUp.Visible = false;
                }
            }

            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
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
                else if (cmbMediam.SelectedItem == "")
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
            {//ADDED BY ASHVINI 4-1-2019
             //FOR displaying proper formatting04-01-2019
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
                //ennd by ashvini 04-01-2019
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SGOutstFees.DataSource = objAllStdOutstanding;
                if (SGOutstFees.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(SGOutstFees, null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SGOutstFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();


                getParameter.name = "Name:- " + txtFName.Text; 
              
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Outstanding Report";
                getParameter.BranchName = "Branch:- " + Program.LoggedInUser.Branch.BranchName;
               
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if(SGOutstFees.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Outstanding Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(SGOutstFees, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void BtnCancel_Click_1(object sender, EventArgs e)
        {

            try
            {
                pnlFolloupGrid.Visible = false;
                PanelFollowUp.Visible = false;

                BtnCancel.Visible = false;
             // fol.Visible = false;
                AdgvViewFolow.Visible = false;
                this.Height = 458;
                this.Width = 806;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtFrmDte_CloseUp(object sender, EventArgs e)
        {
            loadAllFees("ALLOUTSTANDING", dtFrmDte.Value, dtToDte.Value,false);
        }

        private void dtToDte_CloseUp(object sender, EventArgs e)
        {
            loadAllFees("ALLOUTSTANDING", dtFrmDte.Value, dtToDte.Value,false);
        }

        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyDateFilter.Checked == true)
            {
                dtToDte.Enabled = true;
                dtFrmDte.Enabled = true;
                loadAllFees("ALLOUTSTANDING", dtFrmDte.Value, dtToDte.Value, false);
            }
            else
            {
                dtToDte.Enabled = false;
                dtFrmDte.Enabled = false;
                loadAllFees("ALLOUTSTANDING", DateTime.Now);

            }
        }
    }
}
