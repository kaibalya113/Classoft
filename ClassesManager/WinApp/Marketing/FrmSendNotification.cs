using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Common;
using ClassManager.Info;
using ClassManager.BLL;
using ClassManager.WinApp.UICommon;
namespace ClassManager.WinApp
{
    public partial class FrmSendNotification : FrmParentForm
    {

        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        public static Boolean isFrmmrktng = false;
        string sCaption = "SMS Notification";
        Boolean allowIndexPositionChange;
        Boolean AddColumn = false;
        public FrmSendNotification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        public void sendIndividualMessage()
        {

            isFrmmrktng = true;
            Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
            BLL.MailHandler.sendSMS(smsConfig, txtNotice.Text, txtPhnNo.Text, false, "IndividualSMS");
            UICommon.WinForm.showStatus("Message sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        }

        private void getData()
        {
            try
            {
                DateTime dt = dtpNotificationDate.Value;
                if (cmbType.Text.Equals("BirthDay"))
                {
                    if (ADGVData.Columns.Contains("chkSMS"))
                    {
                        ADGVData.Columns.Remove("chkSMS");
                        AddColumn = false;
                    }

                    ADGVData.DataSource = null;
                    pnlndvsl.Visible = false;
                    btnSend.Enabled = true;
                    btnSend.Visible = true;
                    ADGVData.DataSource = WinForm.ToDataTable(BLL.MarketingHandler.getBirthdays(dt, branchID));
                    panelBatchWise.Visible = false;
                    btnSaveExcel.Visible = true;
                    lblToDate.Visible = true;
                    dtpToDate.Visible = true;
                    chkSelectAll.Visible = false;
                }
                else if (cmbType.Text.Equals("Anniversary"))
                {
                    if (ADGVData.Columns.Contains("chkSMS"))
                    {
                        ADGVData.Columns.Remove("chkSMS");
                        AddColumn = false;
                    }
                    ADGVData.DataSource = null;
                    btnSend.Enabled = true;
                    btnSend.Visible = true;
                    pnlndvsl.Visible = false;
                    ADGVData.DataSource = WinForm.ToDataTable(BLL.MarketingHandler.getAnniversaries(dt, branchID));
                    //ADGVData.DataSource = lstAnniversary;
                    panelBatchWise.Visible = false;
                    btnSaveExcel.Visible = false;
                    lblToDate.Visible = false;
                    dtpToDate.Visible = false;
                    chkSelectAll.Visible = false;
                }
                else if (cmbType.Text.Equals("Followup Sms"))
                {
                    if (ADGVData.Columns.Contains("chkSMS"))
                    {
                        ADGVData.Columns.Remove("chkSMS");
                        AddColumn = false;
                    }
                    ADGVData.DataSource = null;
                    btnSend.Enabled = true;
                    btnSend.Visible = true;
                    pnlndvsl.Visible = false;
                    ADGVData.DataSource = BLL.FollowupHandler.getFollStud(dt, branchID);
                    btnSaveExcel.Visible = false;
                    lblToDate.Visible = false;
                    dtpToDate.Visible = false;
                    panelBatchWise.Visible = false;
                    chkSelectAll.Visible = false;
                }


                else if (cmbType.Text.Equals("Before Outstanding Date"))
                {
                    if (ADGVData.Columns.Contains("chkSMS"))
                    {
                        ADGVData.Columns.Remove("chkSMS");
                        AddColumn = false;
                    }
                    ADGVData.DataSource = null;
                    pnlndvsl.Visible = false;
                    btnSend.Enabled = true;
                    btnSend.Visible = true;
                    btnSaveExcel.Visible = false;
                    lblToDate.Visible = false;
                    dtpToDate.Visible = false;
                    chkSelectAll.Visible = false;
                }
                else if (cmbType.Text.Equals("Absent Message"))
                {
                    if (AddColumn == false)
                    {
                        AddColumninBatch();
                    }
                    getAbsentStudents();
                }
                else if (cmbType.Text.Equals("Individual"))
                {
                    if (ADGVData.Columns.Contains("chkSMS"))
                    {
                        ADGVData.Columns.Remove("chkSMS");
                        AddColumn = false;
                    }
                    ADGVData.DataSource = null;

                    panelBatchWise.Visible = false;
                    pnlndvsl.Visible = true;
                    btnSend.Enabled = false;
                    btnSend.Visible = false;
                    btnSaveExcel.Visible = false;
                    lblToDate.Visible = false;
                    dtpToDate.Visible = false;
                    chkSelectAll.Visible = false;
                }


                else if (cmbType.Text.Equals("BatchWise"))
                {
                    if (AddColumn == false)
                    {
                        AddColumninBatch();
                    }
                    panelBatchWise.Visible = true;
                    ADGVData.DataSource = null;
                    btnSend.Enabled = false;
                    btnSend.Visible = false;
                    pnlndvsl.Visible = false;
                    txtNotice.Visible = true;
                    lblMsg.Visible = true;
                    displaycombostrm();
                    getStudentsInBatch();
                    btnSaveExcel.Visible = false;
                    lblToDate.Visible = false;
                    dtpToDate.Visible = false;
                    chkSelectAll.Visible = true;
                }
                else
                {
                    if (ADGVData.Columns.Contains("chkSMS"))
                    {
                        ADGVData.Columns.Remove("chkSMS");
                        AddColumn = false;
                    }
                    ADGVData.DataSource = null;
                    btnSend.Enabled = true;
                    btnSend.Visible = true;
                    pnlndvsl.Visible = false;
                    btnSaveExcel.Visible = false;
                    lblToDate.Visible = false;
                    dtpToDate.Visible = false;
                    chkSelectAll.Visible = false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void AddColumninBatch()
        {
            try
            {
                AddColumn = true;
                DataGridViewCheckBoxColumn chkSMS = new DataGridViewCheckBoxColumn();
                chkSMS.Name = "chkSMS";
                chkSMS.HeaderText = "Send";
                chkSMS.TrueValue = true;
                chkSMS.FalseValue = false;
                chkSMS.ReadOnly = false;
                chkSMS.Selected = false;
                ADGVData.Columns.Insert(0, chkSMS);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void SendNotification_Load(object sender, EventArgs e)
        {
            try
            {
                //Formatting Date
                allowIndexPositionChange = false;
                pnlndvsl.Visible = false;
                AssignEvents();
                allowIndexPositionChange = true;
                ApplyPrevileges();
                dtpNotificationDate.Value = DateTime.Now;
                int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                DateTime monthEndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, daysInMonth);
                dtpToDate.Value = monthEndDate;
                UICommon.WinForm.formatDateTimePicker(dtpNotificationDate);
                UICommon.WinForm.formatDateTimePicker(dtpToDate);
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {
                        chkBrnchId.Visible = false;
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



        private void AssignEvents()
        {
            ADGVData.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVData.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            txtPhnNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);

        }


        #region  "Combobox"

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkSelectAll.Checked = false;
                if (allowIndexPositionChange == true)
                {
                    allowIndexPositionChange = false;
                    if (cmbStream.SelectedIndex != 0)
                    {
                        cmbCourse.Items.Clear();
                        cmbCourse.Items.Add(new Info.ComboItem("%", "All"));
                        String stream = (cmbStream.SelectedItem as ComboItem).strKey;
                        displaycombocrse(stream);
                    }
                    else
                    {
                        cmbCourse.Items.Clear();
                        cmbCourse.Items.Add(new Info.ComboItem("%", "All"));
                        cmbCourse.SelectedIndex = 0;

                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new Info.ComboItem("%", "All"));

                        cmbBatch.SelectedIndex = 0;
                    }
                    //cmbCourse.SelectedIndex = 0;
                    //cmbBatch.SelectedIndex = 0;
                    getStudentsInBatch();
                }
                allowIndexPositionChange = true;
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "cannot display course, please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkSelectAll.Checked = false;
                if (allowIndexPositionChange == true)
                {
                    allowIndexPositionChange = false;
                    if (cmbCourse.SelectedIndex != 0)
                    {
                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new Info.ComboItem("%", "All"));
                        String sID = ((cmbCourse.SelectedItem as Info.ComboItem).strKey).ToString();
                        displaybtch(Convert.ToInt32(sID));
                        cmbBatch.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new Info.ComboItem("%", "All"));
                        cmbBatch.SelectedIndex = 0;
                    }
                    getStudentsInBatch();
                    allowIndexPositionChange = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkSelectAll.Checked = false;
                if (allowIndexPositionChange == true)
                {
                    allowIndexPositionChange = false;
                    getStudentsInBatch();
                    allowIndexPositionChange = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion "Combobox"


        #region "Methods"



        public void displaycombostrm()
        {
            try
            {
                List<Info.Stream> lststream = BLL.StreamHandller.getStreams(branchID);
                Info.ComboItem objAll = new Info.ComboItem("%", "All");
                cmbStream.Items.Clear();
                cmbStream.Items.Add(objAll);

                foreach (Info.Stream objStream in lststream)
                {
                    cmbStream.Items.Add(new Info.ComboItem(objStream.ID.ToString(), objStream.Name));
                }
                cmbStream.SelectedIndex = 0;
                //displaycombocrse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void displaycombocrse(string stream = "%")
        {
            try
            {
                List<Info.Standard> lstStandard = BLL.StandardHandller.getStandard(branchID.ToString(), stream);
                Info.ComboItem objAll = new Info.ComboItem("%", "All");
                cmbCourse.Items.Clear();
                cmbCourse.Items.Add(objAll);

                foreach (Info.Standard objStandard in lstStandard)
                {
                    cmbCourse.Items.Add(new Info.ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                }
                cmbCourse.SelectedIndex = 0;
                int sID = ((cmbCourse.SelectedItem as Info.ComboItem).key);
                displaybtch((sID));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void displaybtch(int sID = '%')
        {
            try
            {
                List<Info.Batch> lstBatch = BLL.StandardHandller.GetBatches(sID, Program.LoggedInUser.BranchId);
                Info.ComboItem objAll = new Info.ComboItem("%", "All");
                cmbBatch.Items.Clear();
                cmbBatch.Items.Add(objAll);

                foreach (Info.Batch objBatch in lstBatch)
                {
                    cmbBatch.Items.Add(new Info.ComboItem(objBatch.id.ToString(), objBatch.Name));
                }
                cmbBatch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        private void getStudentsInBatch()
        {
            try
            {
                string StreamId = (cmbStream.SelectedItem as Info.ComboItem).strKey;

                string BatchId = (cmbBatch.SelectedItem as Info.ComboItem).strKey;
                string BranchId = branchID;
                string CourseId = (cmbCourse.SelectedItem as Info.ComboItem).strKey;
                DataTable dt = BLL.StudentHandller.getStudentsInBatch(StreamId, CourseId, BatchId, BranchId);

                ADGVData.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion "Methods"


        private void ADGVData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (cmbType.Text.Equals("Followup Sms"))
                {


                    ADGVData.Columns["ENQ_CONTACT_NO"].HeaderText = "Contact No.";
                    ADGVData.Columns["ENQ_DATE"].HeaderText = "Enquiry Date";
                    ADGVData.Columns["FOLU_DATE"].HeaderText = "Followup date";
                    ADGVData.Columns["FOLU_DESCRIPTION"].HeaderText = "Description";
                    ADGVData.Columns["STRM_NAME"].HeaderText = "Package";
                    ADGVData.Columns["STD_NAME"].HeaderText = "Standard";
                }
                else if (cmbType.SelectedIndex == 1)
                {
                    ADGVData.Columns["Group"].Visible = false;
                    ADGVData.Columns["StudType"].Visible = false;
                }
                else if (cmbType.SelectedIndex == 6)
                {
                    //Hiding Columns
                    ADGVData.Columns["STMT_CONTACT_NO"].HeaderText = "ContactNo";
                    ADGVData.Columns["STD_NAME"].HeaderText = "Standard";
                    ADGVData.Columns["rn"].Visible = false;
                }
                else if (cmbType.SelectedIndex == 5)
                {
                    //Hiding Columns.
                    if (ADGVData.Rows.Count != 0)
                    {
                        ADGVData.Columns["ATTD_ID"].Visible = false;
                        ADGVData.Columns["ATTD_IS_HOLIDAY"].Visible = false;

                        //Changing HeaderText.
                        ADGVData.Columns["ATTD_ADMISSION_NO"].HeaderText = "AdmissionNo";
                        ADGVData.Columns["ATTD_DATE"].HeaderText = "Date";
                        ADGVData.Columns["ATTD_IN_TIME"].HeaderText = "In_Time";
                        ADGVData.Columns["ATTD_OUT_TIME"].HeaderText = "Out_Time";
                        ADGVData.Columns["ATTD_STATUS"].HeaderText = "Attendance";
                        ADGVData.Columns["STMT_FATHER_CONTACT"].HeaderText = "FatherNo";
                        if (ADGVData.Columns.Contains("STRM_NAME"))
                        {
                            ADGVData.Columns["STRM_NAME"].HeaderText = "Stream";
                        }
                        if (ADGVData.Columns.Contains("STD_NAME"))
                        {
                            ADGVData.Columns["STD_NAME"].HeaderText = "Course";
                        }
                        if (ADGVData.Columns.Contains("STRM_ID"))
                        {
                            ADGVData.Columns["STRM_ID"].Visible = false;
                        }
                        if (ADGVData.Columns.Contains("STD_ID"))
                        {
                            ADGVData.Columns["STD_ID"].Visible = false;
                        }
                        ADGVData.Columns["ATTD_REMARK"].HeaderText = "Remark";
                        if (ADGVData.Columns.Contains("BTCH_ID"))
                        {
                            ADGVData.Columns["BTCH_ID"].Visible = false;
                        }
                        if (ADGVData.Columns.Contains("BTCH_NAME"))
                        {
                            ADGVData.Columns["BTCH_NAME"].HeaderText = "Batch";
                        }
                        if (ADGVData.Columns.Contains("ATTD_LECTURE_ID"))
                        {
                            ADGVData.Columns["ATTD_LECTURE_ID"].Visible = false;
                        }

                        //Changing Grid DateFormat
                        ADGVData.Columns["ATTD_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                        ADGVData.Columns["ATTD_IN_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                        ADGVData.Columns["ATTD_OUT_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                    }
                }


                else if (cmbType.SelectedIndex == 0)
                {

                    //Hiding Columns.
                    ADGVData.Columns["Id"].Visible = false;
                    ADGVData.Columns["Group"].Visible = false;
                    ADGVData.Columns["Anniversary"].Visible = false;
                    ADGVData.Columns["EmailID"].Visible = false;
                    ADGVData.Columns["StudType"].Visible = false;

                    //Formatting Date.
                    ADGVData.Columns["BirthDay"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                }


                foreach (DataGridViewRow adrow in ADGVData.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVData.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void chkBrnchId_CheckedChanged(object sender, EventArgs e)
        {
            checkBranch();
        }
        public void checkBranch()
        {
            try
            {
                //if (WinApp.Program.LoggedInUser.Type == "A")
                //{
                if (chkBrnchId.Checked)
                {
                    branchID = "%";
                    //  loadDetails(branchID);
                }
                else
                {
                    branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                    // loadDetails(branchID);
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void ADGVData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVData, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        private void getAbsentStudents()
        {
            try
            {
                ADGVData.DataSource = null;
                pnlndvsl.Visible = false;
                panelBatchWise.Visible = false;
                btnSend.Enabled = true;
                btnSend.Visible = true;
                DataTable onlyAbsent = BLL.AttendanceHandler.getAttendanceStatus("%", "%", "%", dtpNotificationDate.Value, System.DateTime.Now, branchID, "%", "S");
                //onlyAbsent.Rows.Find(string.Format("ATTD_STATUS='A'"));
                ADGVData.DataSource = onlyAbsent.Select(string.Format("ATTD_STATUS='A'")).AsEnumerable().CopyToDataTable();

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The source contains no DataRows."))
                {

                }
                else
                {
                    UICommon.WinForm.showError(ex, sCaption, this);
                }

            }
        }
        private void dtpNotificationDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.SelectedIndex == 5)
                {
                    getAbsentStudents();
                }

                getData();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVData.Rows.Count > 0)
                {
                    //send today's date
                    DateTime dt = System.DateTime.Now;
                    string BranchId = Program.LoggedInUser.BranchId.ToString();

                    //ADGVData.DataSource = null;

                    if (cmbType.SelectedItem != null && cmbType.Text != "")
                    {
                        if (cmbType.Text.Equals("BirthDay"))
                        {
                            DataTable dtBday = new DataTable();
                            dtBday = ADGVData.DataSource as DataTable;
                            BLL.NotificationHandler.sendBirthdaySMS(WinForm.ToList<Info.Marketing>(dtBday));// as List<Info.Marketing>);
                                                                                                            //BLL.NotificationHandler.sendBirthdaySMS( WinForm.ToList<((DataTable)ADGVData.DataSource)> as List<Info.Marketing>);

                            UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }


                        else if (cmbType.Text == "Anniversary")
                        {
                            BLL.NotificationHandler.sendAnniversarySMS(ADGVData.DataSource as List<Info.Marketing>);
                            UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        else if (cmbType.Text == "Followup Sms")
                        {
                            BLL.NotificationHandler.sendFollowupSMS(ADGVData.DataSource as DataTable);
                            UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        //   else if (cmbType.Text == "Daily Report")
                        //  {
                        //    BLL.NotificationHandler.sendTotalCountOfToday(NotificationHandler.getDailyReport(dtpNotificationDate.Value, dtpNotificationDate.Value, Program.LoggedInUser.BranchId.ToString()));
                        // }
                        else if (cmbType.Text == "Before Outstanding Date")
                        {
                            BLL.NotificationHandler.sendOutstandingFeesSMS(ADGVData.DataSource as List<DueNotification>);
                            UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        else if (cmbType.Text == "Individual")
                        {
                            pnlndvsl.Visible = true;
                            sendIndividualMessage();
                            UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        else if (cmbType.Text == "Absent Message")
                        {
                            // BLL.NotificationHandler.sendAbsentMessage((DataTable)ADGVData.DataSource);
                            // UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            try
                            {

                                List<Int32> lstAdmsnNo = new List<Int32>();
                                StringBuilder contactNos = new StringBuilder();
                                DataTable absntStuds = new DataTable();
                                absntStuds.Columns.Add("Name");
                                absntStuds.Columns.Add("ATTD_DATE");
                                absntStuds.Columns.Add("STMT_FATHER_CONTACT");
                                absntStuds.Columns.Add("Id");
                                foreach (DataGridViewRow gvrBatchWise in ADGVData.Rows)
                                {
                                    if (gvrBatchWise.Cells[0].Value != null && (Boolean)gvrBatchWise.Cells[0].Value == true)
                                    {
                                        absntStuds.Rows.Add(new object[] { gvrBatchWise.Cells["Name"].Value, gvrBatchWise.Cells["ATTD_DATE"].Value, gvrBatchWise.Cells["STMT_FATHER_CONTACT"].Value, gvrBatchWise.Cells["ATTD_ID"].Value });
                                    }
                                }
                                if (absntStuds.Rows.Count > 0)
                                {
                                    bool isSent = BLL.NotificationHandler.sendAbsentMessage(absntStuds);

                                    UICommon.WinForm.showStatus("Message Send Successfully!!!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                    UICommon.WinForm.setSMSStatus(isSent, sCaption, this);
                                }

                                else
                                {
                                    UICommon.WinForm.showStatus("Please select Student to Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }

                            }
                            catch (Exception ex)
                            {
                                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                            }
                        }
                    }

                    else
                    {
                        UICommon.WinForm.showStatus("Select One of the Type", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("No Records to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }


            }
            catch (Exception ex)
            {
                // UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    //UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    UICommon.WinForm.showSMSError(sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }

        }

        private void sendBatchwiseSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVData.Rows.Count > 0)
                {
                    if (txtBatchWiseSMS.Text.Length != 0 && txtBatchWiseSMS.Text != "")
                    {
                        List<Int32> lstAdmsnNo = new List<Int32>();
                        StringBuilder contactNos = new StringBuilder();
                        foreach (DataGridViewRow gvrBatchWise in ADGVData.Rows)
                        {
                            if (gvrBatchWise.Cells[0].Value != null && (Boolean)gvrBatchWise.Cells[0].Value == true)
                            {
                                if (gvrBatchWise.Cells["STMT_CONTACT_NO"].Value != null)
                                {
                                    contactNos.Append((gvrBatchWise.Cells["STMT_CONTACT_NO"].Value).ToString() + ',');
                                }
                            }
                        }
                        if (contactNos.Length > 0)
                        {
                            bool isSent = MailHandler.sendSMS(SmsConfig.getSMSConfig(), txtBatchWiseSMS.Text, contactNos.ToString().Substring(0, contactNos.Length - 1), false, "BatchWiseSMS");
                            if (isSent)
                            {
                                UICommon.WinForm.showStatus("Message Send Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            }
                            else
                            {
                                UICommon.WinForm.showStatus("Message not Sent", sCaption, this);
                            }
                        }

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Please Enter Message to Send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else if (ADGVData.Rows.Count == 0)
                {
                    UICommon.WinForm.showStatus("No Records to Send SMS", sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSendIndividual_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateindividualPanel())
                {

                    sendIndividualMessage();
                }


            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }
        private bool validateindividualPanel()
        {
            try
            {
                if (txtNotice.Text == "")
                {

                    UICommon.WinForm.showStatus("Please Enter Message to Send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtNotice.Focus();
                    return false;
                }
                else if (txtPhnNo.Text == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPhnNo.Focus();
                    return false;
                }
                else if (txtPhnNo.Text.Length < 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtPhnNo.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtPhnNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtPhnNo.Text.Length >= 10)
                {
                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVData.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVData, null);
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

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow gvrFees in ADGVData.Rows)
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

        private void ADGVData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = ADGVData.Rows[e.RowIndex];
                DataGridViewCheckBoxCell chckBx = new DataGridViewCheckBoxCell();
                if (e.ColumnIndex == 0)
                {
                    foreach (DataGridViewRow row in ADGVData.SelectedRows)
                    {
                        chckBx = (DataGridViewCheckBoxCell)ADGVData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        if (chckBx.Value == null)
                        {
                            chckBx.Value = false;
                            chckBx.Value = !(Boolean)chckBx.Value;
                        }
                        else
                        {
                            chckBx.Value = !(Boolean)chckBx.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

