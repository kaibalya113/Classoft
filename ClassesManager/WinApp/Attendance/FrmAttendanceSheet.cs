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
using System.Text.RegularExpressions;

namespace ClassManager.WinApp
{
    public partial class FrmAttendanceSheet : FrmParentForm
    {
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        RolePrivilege formPrevileges;

        //This DataTable is to store data Globally.
        DataTable toStoreDataGlobally;
        List<Lecture> lstLecture;
        string sCaption = "AttendanceSheet";
        string appName = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
        public static bool isAutomaticBio = Info.SysParam.getValue<bool>(Info.SysParam.Parameters.IS_AUTOMATIC);
        private bool isFormClosed = false;
        DataGridViewCheckBoxCell chckBx = new DataGridViewCheckBoxCell();
        bool isForFaculty = false;
        Boolean IndexChange; bool isSent = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmAttendanceSheet()
        {
            InitializeComponent();
        }

        #region "Events"


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVAttendanceSheet.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVAttendanceSheet, null);
                }
                else
                {
                    UICommon.WinForm.showStatus("There Is No Data To Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chbFaculty.Checked)
            {
                isForFaculty = true;
            }
            else
            {
                isForFaculty = false;
            }

            try
            {
                //SelectedIndex should be set to 0 if we click on search button.
                attdgrbBy.SelectedIndex = -1;
                enableControls();

                loadAttencence();

                if (ADGVAttendanceSheet.Rows.Count == 0)
                {
                    if (!chbFaculty.Checked)
                    {
                        int stdid = (cmbCourseType.SelectedItem as ComboItem).key;
                        int batchid = (cmbBatch.SelectedItem as ComboItem).key;

                        var result = UICommon.WinForm.showStatus("Do you want to Mark Attentance of the requested batch?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                        if (result == DialogResult.Yes)
                        {
                            FrmAttendance objAttendance = (FrmAttendance)UICommon.FormFactory.GetForm(Forms.FrmAttendance, null, false);
                            objAttendance.setDate(dtpFromdate.Value);
                            objAttendance.Visible = true;
                        }
                    }
                    else
                    {
                        int stdid = (cmbCourseType.SelectedItem as ComboItem).key;
                        int batchid = (cmbBatch.SelectedItem as ComboItem).key;

                        var result = UICommon.WinForm.showStatus("Do you want to Mark Attendance of All Faculties?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                        if (result == DialogResult.Yes)
                        {
                            FrmAttendance objAttendance = (FrmAttendance)UICommon.FormFactory.GetForm(Forms.FrmAttendance, null, false);
                            objAttendance.setDate(dtpFromdate.Value);
                            objAttendance.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private void AttendanceSheet_Load(object sender, EventArgs e)
        {
            try
            {

                if (isAutomaticBio == true)
                {
                    ADGVAttendanceSheet.ReadOnly = true;
                }

                showToolTip();

                formatDTP();

                AssignEvents();
                ADGVAttendanceSheet.CurrentCell = null;

                IndexChange = false;
                LoadStream();
                cmbCourseType.Items.Add(new ComboItem(-1, "All"));
                cmbBatch.Items.Add(new ComboItem(-1, "All"));

                cmbBatch.SelectedIndex = 0;
                cmbCourseType.SelectedIndex = 0;
                cmbStream.SelectedIndex = 0;
                IndexChange = true;

                LoadLectures();
                ApplyPrevileges();
                loadAttencence();

                if (appName == "Gym" || appName == "Dance")
                {
                    lblLecture.Visible = false;
                    cmbLecture.Visible = false;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void chkViewAbsent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                attdgrbBy.SelectedIndex = -1;
                if (chkViewAbsent.Checked)
                {
                    viewAbsents();
                }
                else
                {
                    ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            AttendanceHandler.prepareAttendeceFromLog(dtpFromdate.Value, dtpToDate.Value, branchID);
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                //SelecctedIndex should be set to 0 if we click on search button.
                attdgrbBy.SelectedIndex = -1;

                loadAttencence();
                if (ADGVAttendanceSheet.Rows.Count == 0)
                {
                    string stdid = (cmbCourseType.SelectedItem as ComboItem).strKey;
                    string batchid = (cmbBatch.SelectedItem as ComboItem).strKey;


                    var result = UICommon.WinForm.showStatus("Do you want to Mark attentance of the requested batch", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (result == DialogResult.Yes)
                    {
                        BLL.AttendanceHandler.markAttendenceManually(batchid, stdid, dtpFromdate.Value, branchID, cmbLecture.SelectedIndex == 0 ? 0 : (cmbLecture.SelectedItem as ComboItem).key);
                        //ADGVAttendanceSheet.DataSource = data;
                        loadAttencence();
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
            //ADGVAttendanceSheet.DataSource = null;
            //ADGVAttendanceSheet.DataSource = BLL.AttendanceHandler.getAttendanceStatus("%", "%", "%", dtpFromdate.Value, dtpToDate.Value, branchID, "%", (chbFaculty.Checked) ? "F" : "S");
            //assignValues();
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IndexChange == true)
                {
                    IndexChange = false;
                    LoadCourse(Convert.ToInt32((cmbStream.SelectedItem as ComboItem).strKey));
                }
                IndexChange = true;
                cmbCourseType.SelectedIndex = 0;
                int lect = cmbLecture.SelectedIndex;
                cmbLecture.SelectedIndex = lect;
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (IndexChange == true)
                {
                    IndexChange = false;
                    int sID = ((cmbCourseType.SelectedItem as Info.ComboItem).key);
                    LoadBatches(sID);

                    IndexChange = true;

                    LoadLectures();
                    int lect = cmbLecture.SelectedIndex;
                    cmbLecture.SelectedIndex = lect;
                    //CmbSubject.DataSource = lstAvailableSujects;
                }
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chbFaculty_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnInstructorAttendance.Text == "INSTRUCTOR ATTENDANCE")
                {
                    isForFaculty = true;
                    disableControls();
                    ADGVAttendanceSheet.DataSource = null;
                    attdgrbBy.SelectedIndex = -1;
                    if (cmbLecture.SelectedIndex == 0 || cmbLecture.SelectedIndex == -1)
                    {
                        toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).strKey, (cmbCourseType.SelectedItem as ComboItem).strKey, (cmbBatch.SelectedItem as ComboItem).strKey, dtpFromdate.Value, dtpToDate.Value, branchID, "%", "F");
                    }
                    else
                    {
                        toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).strKey, (cmbCourseType.SelectedItem as ComboItem).strKey, (cmbBatch.SelectedItem as ComboItem).strKey, dtpFromdate.Value, dtpToDate.Value, Program.LoggedInUser.BranchId.ToString(), "%", "F", cmbLecture.SelectedIndex == 0 ? 0 : (cmbLecture.SelectedItem as ComboItem).key);
                    }
                    ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                    AssignValues();
                    btnInstructorAttendance.Text = "STUDENT ATTENDANCE";
                    //chbFaculty.Checked = false;
                }
                else
                {
                    isForFaculty = false;
                    enableControls();
                    ADGVAttendanceSheet.DataSource = null;
                    attdgrbBy.SelectedIndex = -1;
                    if (cmbLecture.SelectedIndex == 0 || cmbLecture.SelectedIndex == -1)
                    {
                        toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).strKey, (cmbCourseType.SelectedItem as ComboItem).strKey, (cmbBatch.SelectedItem as ComboItem).strKey, dtpFromdate.Value, dtpToDate.Value, branchID, "%", "S");
                    }
                    else
                    {
                        //toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as Stream).ID.ToString(), (cmbCourseType.SelectedItem as Standard).Standardid.ToString(), (cmbBatch.SelectedItem as Batch).id.ToString(), dtpFromdate.Value, dtpToDate.Value, branchID, "%", "S", (cmbLecture.SelectedItem as ComboItem).key);
                        toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).strKey, (cmbCourseType.SelectedItem as ComboItem).strKey, (cmbBatch.SelectedItem as ComboItem).strKey, dtpFromdate.Value, dtpToDate.Value, Program.LoggedInUser.BranchId.ToString(), "%", "S", cmbLecture.SelectedIndex == 0 ? 0 : (cmbLecture.SelectedItem as ComboItem).key);
                    }
                    ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                    AssignValues();
                    btnInstructorAttendance.Text = "INSTRUCTOR ATTENDANCE";
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }


        }

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAllBranch.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                }

                loadAttencence();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVAttendanceSheet_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            if (ADGVAttendanceSheet.Columns.Contains("sort_order"))
            {
                ADGVAttendanceSheet.Columns["sort_order"].Visible = false;
            }


            //Checking whether Lecture is selected or not.
            if (cmbLecture.SelectedIndex > 0)
            {
                if (attdgrbBy.SelectedIndex == -1)
                {
                    AssignValues();

                    //If Faculty's Attendance is Viewed for a Lecture, then only this much part will be executed.Mohan(31-July-2017).
                    if (cmbStream.Enabled == false)
                    {
                        formatFacultyGrid();
                        return;
                    }

                    //Changing HeaderText.
                    ADGVAttendanceSheet.Columns["ATTD_DATE"].HeaderText = "Date";
                    if (ADGVAttendanceSheet.Columns.Contains("STMT_FATHER_CONTACT"))
                    {
                        ADGVAttendanceSheet.Columns["STMT_FATHER_CONTACT"].HeaderText = "FatherNo";
                    }
                    //ADGVAttendanceSheet.Columns["ATTD_ADMISSION_NO"].HeaderText = "AdmissionNo";
                    ADGVAttendanceSheet.Columns["ATTD_STATUS"].HeaderText = "Attendance";

                    //Making it ReadOnly.
                    ADGVAttendanceSheet.Columns["ATTD_STATUS"].ReadOnly = true;

                    ADGVAttendanceSheet.Columns["ATTD_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                    ADGVAttendanceSheet.Columns["STMT_FATHER_CONTACT"].Visible = false;


                    //Ordering Column Position
                    ADGVAttendanceSheet.Columns["chkPresent"].DisplayIndex = 0;
                    //ADGVAttendanceSheet.Columns["chkHW"].DisplayIndex = 1;
                    ADGVAttendanceSheet.Columns["ATTD_DATE"].DisplayIndex = 2;
                    ADGVAttendanceSheet.Columns["Name"].DisplayIndex = 3;
                    if (ADGVAttendanceSheet.Columns.Contains("STMT_FATHER_CONTACT"))
                    {
                        ADGVAttendanceSheet.Columns["STMT_FATHER_CONTACT"].DisplayIndex = 4;
                    }
                    //ADGVAttendanceSheet.Columns["ATTD_ADMISSION_NO"].DisplayIndex = 5;
                    ADGVAttendanceSheet.Columns["ATTD_STATUS"].DisplayIndex = 6;

                    //Hiding Columns.
                    if (ADGVAttendanceSheet.Columns.Contains("ATLC_ID"))
                    {
                        ADGVAttendanceSheet.Columns["ATLC_ID"].Visible = false;
                    }
                    ADGVAttendanceSheet.Columns["ATTD_ADMISSION_NO"].Visible = false;

                    ADGVAttendanceSheet.Columns["chkHW"].Visible = false;
                    if (ADGVAttendanceSheet.Columns.Contains("STRM_ID"))
                    {
                        ADGVAttendanceSheet.Columns["STRM_ID"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STD_ID"))
                    {
                        ADGVAttendanceSheet.Columns["STD_ID"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STRM_NAME"))
                    {
                        ADGVAttendanceSheet.Columns["STRM_NAME"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STD_NAME"))
                    {
                        ADGVAttendanceSheet.Columns["STD_NAME"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("BTCH_NAME"))
                    {
                        ADGVAttendanceSheet.Columns["BTCH_NAME"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("BTCH_ID"))
                    {
                        ADGVAttendanceSheet.Columns["BTCH_ID"].Visible = false;
                    }

                }
                else
                {
                    ADGVAttendanceSheet.Columns["chkPresent"].Visible = false;
                    ADGVAttendanceSheet.Columns["chkHW"].Visible = false;
                }
            }

            else
            {

                if (attdgrbBy.SelectedIndex == -1)
                {
                    AssignValues();
                    formatADGVAttendanceSheet();

                    if (IsAccessible == false)
                    {
                        //ADGVAttendanceSheet.Columns[0].ReadOnly = false;
                    }
                    else
                    {
                        ADGVAttendanceSheet.Columns[0].ReadOnly = true;

                    }
                }
                else
                {
                    //assignValues();
                    //formatADGVAttendanceSheet();

                    ADGVAttendanceSheet.Columns["chkPresent"].Visible = false;
                    ADGVAttendanceSheet.Columns["chkHW"].Visible = false;
                }
            }



            foreach (DataGridViewRow adrow in ADGVAttendanceSheet.Rows)
            {
                adrow.Height = 30;
                adrow.MinimumHeight = 30;
                if (chbFaculty.Checked == true)
                {

                }
                if (isForFaculty == false)
                {
                    if (attdgrbBy.SelectedIndex == -1)
                    {
                        if (cmbLecture.SelectedIndex == 0)// || cmbLecture.Text == "Full Day")
                        {
                            if (((adrow.Cells["ATTD_LECTURE_ID"].Value.ToString()) == ""))
                            {
                                if ((adrow.Cells["ATTD_STATUS"].Value.ToString()) == "P")
                                {
                                    //////  adrow.DefaultCellStyle.BackColor = Color.Tomato;
                                }
                            }
                        }
                    }
                }
            }
            ADGVAttendanceSheet.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

        }

        private void btnReCalc_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (branchID.Equals("%"))
                {
                    branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
                }
                bool returnStatus = AttendanceHandler.prepareAttendeceFromLog(dtpFromdate.Value, dtpToDate.Value, branchID);
                if (returnStatus == true)
                {
                    UICommon.WinForm.showStatus("Attendance log processed successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void dtpFromdate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                loadAttencence();
                LoadLectures();
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }



        private void cmbLecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IndexChange == true && chbFaculty.Checked == false)
                {
                    if (cmbLecture.SelectedIndex > 0)
                    {
                        btnSearch.Visible = false;
                    }
                    else
                    {
                        btnSearch.Visible = true;
                    }

                    attdgrbBy.SelectedIndex = -1;
                    btnSend.Enabled = true;
                    loadAttencence();
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnInstructorAttendance.Text == "INSTRUCTOR ATTENDANCE")
                {
                    // chbFaculty.Checked = true; 
                    isForFaculty = true;
                    disableControls();
                    ADGVAttendanceSheet.DataSource = null;
                    attdgrbBy.SelectedIndex = -1;
                    toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).strKey, (cmbCourseType.SelectedItem as ComboItem).strKey, (cmbBatch.SelectedItem as ComboItem).strKey, dtpFromdate.Value, dtpToDate.Value, branchID, "%", "F", cmbLecture.SelectedIndex == 0 ? 0 : (cmbLecture.SelectedItem as ComboItem).key);
                    ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                    AssignValues();
                    btnInstructorAttendance.Text = "STUDENT ATTENDANCE";
                    // chbFaculty.Checked = false;
                }
                else
                {
                    isForFaculty = false;
                    enableControls();
                    ADGVAttendanceSheet.DataSource = null;
                    attdgrbBy.SelectedIndex = -1;

                    toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).strKey, (cmbCourseType.SelectedItem as ComboItem).strKey, (cmbBatch.SelectedItem as ComboItem).strKey, dtpFromdate.Value, dtpToDate.Value, branchID, "%", "S", cmbLecture.SelectedIndex == 0 ? 0 : (cmbLecture.SelectedItem as ComboItem).key);
                    ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                    AssignValues();
                    btnInstructorAttendance.Text = "INSTRUCTOR ATTENDANCE";
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void bgwSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            List<String[]> smsDataList = (List<String[]>)e.Argument;

            SmsConfig smsConfig = SmsConfig.getSMSConfig();

            foreach (String[] smsData in smsDataList)
            {
                bool isSuccess;
                isSuccess = MailHandler.sendSMS(smsConfig, smsData[0], smsData[1], false, "AttendanceSMS");
                if (isSuccess == true)
                {
                    UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Message not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
        }

        private void bgwSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
            }


            if (isFormClosed == true)
            {
                this.Close();
            }

        }

        private void AttendanceSheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwSMS.IsBusy)
            {
                e.Cancel = true;
                this.Visible = false;
                isFormClosed = true;
            }
        }

        private void ADGVAttendanceSheet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVAttendanceSheet, e);
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable absntStuds = new DataTable();
                absntStuds.Columns.Add("Name");
                absntStuds.Columns.Add("Date");
                absntStuds.Columns.Add("ContactNo");
                absntStuds.Columns.Add("Id");

                DataTable homework = new DataTable();
                homework.Columns.Add("Name");
                homework.Columns.Add("Date");
                homework.Columns.Add("ContactNo");

                bool isAbsent = false;
                bool isHW = false;
                foreach (DataGridViewRow row in ADGVAttendanceSheet.Rows)
                {
                    //if (row.Cells["ATTD_STATUS"].Value.ToString() == "A
                    if (row.Cells[6].Value.ToString() == "A")
                    {
                        absntStuds.Rows.Add(new object[] { row.Cells["Name"].Value, row.Cells["ATTD_DATE"].Value, row.Cells["STMT_FATHER_CONTACT"].Value, row.Cells[2].Value });
                        isAbsent = true;
                    }

                }
                if (appName != "Gym" && appName != "Dance")
                {
                    foreach (DataGridViewRow row in ADGVAttendanceSheet.Rows)
                    {

                        if (row.Cells[1].Value.Equals(false))
                        {
                            homework.Rows.Add(new object[] { row.Cells["Name"].Value, row.Cells["ATTD_DATE"].Value, row.Cells["STMT_FATHER_CONTACT"].Value });
                            isHW = true;
                        }
                    }
                }

                if (isAbsent == true)
                {
                    isSent = NotificationHandler.sendAbsentMessageForADay(absntStuds);
                    UICommon.WinForm.setSMSStatus(isSent, sCaption, this);
                }

                else if (isHW == true)
                {
                    isSent = NotificationHandler.SendHomeWorkMsg(homework);
                    UICommon.WinForm.setSMSStatus(isSent, sCaption, this);
                }
                else
                {
                    UICommon.FormFactory.setMainFormStatus("SMS cannot sent has every student is Present and  has done Homework:" + sCaption);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVAttendanceSheet_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVAttendanceSheet, e);
        }

        private void attdgrbBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkViewAbsent.Checked = false;
                if (attdgrbBy.SelectedIndex != -1)
                {
                    //btnSaveToDatabase.Enabled = false;
                    if (ADGVAttendanceSheet.Rows.Count > 0)
                    {
                        switch (attdgrbBy.SelectedIndex)
                        {
                            case 0:
                                ADGVAttendanceSheet.DataSource = WinForm.ToDataTable(toStoreDataGlobally.AsEnumerable()
                                                    .GroupBy(r => new { ID = r.Field<int>("STRM_ID"), Stream = r.Field<string>("STRM_NAME") })
                                                    .Select(g => new
                                                    {
                                                        Stream = g.Key.Stream,
                                                        Total = g.Count(),
                                                        //Absent = toStoreDataGlobally.Select("ATTD_ADMISSION_NO='A'").Count().ToString(),
                                                        Absent = toStoreDataGlobally.Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='A'").ToString(),
                                                        Present = toStoreDataGlobally.Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='P'").ToString()


                                                    })
                                                    .ToList());

                                break;
                            case 1:
                                ADGVAttendanceSheet.DataSource = WinForm.ToDataTable(toStoreDataGlobally.AsEnumerable()
                                                    .GroupBy(r => new { ID = r.Field<int>("STD_ID"), Course = r.Field<string>("STD_NAME") })
                                                    .Select(g => new
                                                    {
                                                        Course = g.Key.Course,
                                                        Total = g.Count(),
                                                        Absent = toStoreDataGlobally.Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='A'").ToString(),
                                                        Present = toStoreDataGlobally.Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='P'").ToString()
                                                    })
                                                    .ToList());
                                break;
                            case 2:

                                ADGVAttendanceSheet.DataSource = WinForm.ToDataTable(toStoreDataGlobally.AsEnumerable()
                                                  .GroupBy(r => new { ID = r.Field<int>("btch_id"), Batch = r.Field<string>("BTCH_NAME") })
                                                  .Select(g => new
                                                  {
                                                      Batch = g.Key.Batch,
                                                      Total = g.Count(),
                                                      Absent = toStoreDataGlobally.Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='A'").ToString(),
                                                      Present = toStoreDataGlobally.Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='P'").ToString()
                                                  })
                                                  .ToList());

                                break;
                        }
                        btnSend.Enabled = false;
                    }
                    else
                    {
                        attdgrbBy.SelectedIndex = -1;
                        btnSend.Enabled = true;
                        UICommon.WinForm.showStatus("No Records", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }


        #endregion

        #region "Load Methods"

        private void LoadLectures()
        {
            if (cmbCourseType.SelectedItem != null)
            {
                lstLecture = BLL.LectureHandler.getSubjectsForAttendance((cmbCourseType.SelectedItem as ComboItem).key, (cmbBatch.SelectedItem as ComboItem).key, dtpToDate.Value, Program.LoggedInUser.BranchId);

                IndexChange = false;
                cmbLecture.Items.Clear();
                cmbLecture.Items.Add(new ComboItem(0, "Full Day"));
                if (lstLecture.Count > 0)
                {
                    foreach (Lecture objLecture in lstLecture)
                    {
                        cmbLecture.Items.Add(new ComboItem(objLecture.LectureID, objLecture.Standard.StandardName + " " + objLecture.Batch.Name + " " + objLecture.Subject.SubjName));
                    }
                }
                cmbLecture.SelectedIndex = 0;
                IndexChange = true;
            }
        }

        private void LoadStream()
        {
            try
            {
                List<Stream> lstStream = StreamHandller.getStreams(branchID);

                cmbStream.Items.Add(new ComboItem("-1", "All"));

                foreach (Stream objStream in lstStream)
                {
                    cmbStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }

            }

            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadCourse(int streamId = -1)
        {
            try
            {
                cmbCourseType.Items.Clear();
                cmbCourseType.Items.Add(new ComboItem("-1", "All"));
                if (streamId != -1)
                {
                    List<Standard> lstStd = StreamHandller.getStandards(Program.LoggedInUser.BranchId, streamId);
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbCourseType.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                    }
                }

                LoadBatches(-1);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadBatches(int stdID = -1)
        {
            cmbBatch.Items.Clear();
            Info.ComboItem objAll = new Info.ComboItem("-1", "ALL");
            cmbBatch.Items.Add(objAll);

            if (stdID != -1)
            {
                List<Batch> lstBtch = StandardHandller.GetBatches(stdID, Program.LoggedInUser.BranchId);
                foreach (Batch objbatch in lstBtch)
                {
                    cmbBatch.Items.Add(new ComboItem(objbatch.id, objbatch.Name));
                }
            }
            cmbBatch.SelectedIndex = 0;
        }

        private void AssignValues()
        {
            try
            {
                int noOfDays = ((DataTable)ADGVAttendanceSheet.DataSource).AsEnumerable()
                    .Select(r => new
                    {
                        date = r.Field<DateTime>("ATTD_DATE"),
                    })
                    .Distinct()
                    .Count();

                if (noOfDays < 1)
                {
                    noOfDays = 1;
                }

                int totalPresent = ((DataTable)ADGVAttendanceSheet.DataSource).AsEnumerable()
                    .Select(r => new
                    {
                        id = r.Field<int>("ATTD_ADMISSION_NO"),
                        status = r.Field<string>("ATTD_STATUS")
                    })
                    .Where(att => att.status == "P")
                    .Distinct()
                    .Count();

                totalPrsnt.Text = Math.Floor(Convert.ToDecimal(totalPresent / noOfDays)).ToString();
                string lateMark = ((DataTable)ADGVAttendanceSheet.DataSource).AsEnumerable()
                    .Select(r => new
                    {
                        id = r.Field<int>("ATTD_ADMISSION_NO"),
                        status = r.Field<string>("ATTD_LATE_MARK")
                    })
                    .Where(att => att.status == "A").ToString();

                int totalAbsent = ((DataTable)ADGVAttendanceSheet.DataSource).AsEnumerable()
                    .Select(r => new
                    {
                        id = r.Field<int>("ATTD_ADMISSION_NO"),
                        status = r.Field<string>("ATTD_STATUS")
                    })
                    .Where(att => att.status == "A")
                    .Distinct()
                    .Count();

                totalAbsnt.Text = Math.Floor(Convert.ToDecimal(totalAbsent / noOfDays)).ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AssignEvents()
        {
            ADGVAttendanceSheet.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVAttendanceSheet.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }



        #endregion "Load Methods"

        #region "Formatting Methods"
        /// <summary>
        /// Formats DTP and Sets Date.
        /// </summary>
        private void formatDTP()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpFromdate);
                UICommon.WinForm.formatDateTimePicker(dtpToDate);
                dtpFromdate.Value = DateTime.Now;
                dtpToDate.Value = DateTime.Now;

                // UICommon.WinForm.setDate(dtpFromdate, dtpToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formatADGVAttendanceSheet()
        {
            try
            {

                //Hiding Columns
                if (ADGVAttendanceSheet.Columns.Contains("ATTD_ID"))
                {
                    ADGVAttendanceSheet.Columns["ATTD_ID"].Visible = false;
                }
                if (ADGVAttendanceSheet.Columns.Contains("ATTD_IS_HOLIDAY"))
                {
                    ADGVAttendanceSheet.Columns["ATTD_IS_HOLIDAY"].Visible = false;
                }
                if (ADGVAttendanceSheet.Columns.Contains("ATTD_ADMISSION_NO"))
                {
                    ADGVAttendanceSheet.Columns["ATTD_ADMISSION_NO"].Visible = false;
                }
                if (ADGVAttendanceSheet.Columns.Contains("late_mark"))
                {
                    ADGVAttendanceSheet.Columns["late_mark"].Visible = false;
                }
                if (ADGVAttendanceSheet.Columns.Contains("ATTD_LECTURE_ID"))
                {
                    ADGVAttendanceSheet.Columns["ATTD_LECTURE_ID"].Visible = false;
                }
                string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                if (name == "Gym" || name == "Dance")
                {
                    ADGVAttendanceSheet.Columns["Name"].Width = 160;
                }
                else
                {
                    ADGVAttendanceSheet.Columns["Name"].Width = 190;
                    ADGVAttendanceSheet.Columns["ATTD_DATE"].Width = 90;
                    ADGVAttendanceSheet.Columns["ATTD_STATUS"].Width = 85;
                }
                //Changing Date Format
                ADGVAttendanceSheet.Columns["ATTD_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVAttendanceSheet.Columns["ATTD_IN_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                ADGVAttendanceSheet.Columns["ATTD_OUT_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;


                //Changing HeaderText
                if (ADGVAttendanceSheet.Columns.Contains("Column1"))
                {
                    ADGVAttendanceSheet.Columns["Column1"].HeaderText = "Late Status";
                }
               
                ADGVAttendanceSheet.Columns["ATTD_IN_TIME"].HeaderText = "InTime";
                ADGVAttendanceSheet.Columns["ATTD_OUT_TIME"].HeaderText = "OutTime";
                ADGVAttendanceSheet.Columns["ATTD_DATE"].HeaderText = "Date";
                ADGVAttendanceSheet.Columns["ATTD_STATUS"].HeaderText = "Status";
                if (ADGVAttendanceSheet.Columns.Contains("STMT_FATHER_CONTACT"))
                {
                    ADGVAttendanceSheet.Columns["STMT_FATHER_CONTACT"].HeaderText = "ContactNo";
                }

                //if ((cmbStream.Enabled == true || cmbLecture.SelectedIndex>=0) && btnInstructorAttendance.Text!= "Instructor Attendance")    
                if (isForFaculty == false)
                {
                    //Hiding Columns
                    string appname = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);

                    if (ADGVAttendanceSheet.Columns.Contains("STMT_FATHER_CONTACT"))
                    {
                        ADGVAttendanceSheet.Columns["STMT_FATHER_CONTACT"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STRM_ID"))
                    {
                        ADGVAttendanceSheet.Columns["STRM_ID"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STD_ID"))
                    {
                        ADGVAttendanceSheet.Columns["STD_ID"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STRM_NAME"))
                    {
                        ADGVAttendanceSheet.Columns["STRM_NAME"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("STD_NAME"))
                    {
                        ADGVAttendanceSheet.Columns["STD_NAME"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("BTCH_NAME"))
                    {
                        ADGVAttendanceSheet.Columns["BTCH_NAME"].Visible = false;
                    }
                    if (ADGVAttendanceSheet.Columns.Contains("BTCH_ID"))
                    {
                        ADGVAttendanceSheet.Columns["BTCH_ID"].Visible = false;
                    }



                    if (ADGVAttendanceSheet.Columns.Contains("ATTD_REMARK"))
                    {
                        ADGVAttendanceSheet.Columns["ATTD_REMARK"].Visible = false;
                    }

                   // ADGVAttendanceSheet.Columns["Id"].DisplayIndex = 2;
                    ADGVAttendanceSheet.Columns["ATTD_DATE"].DisplayIndex = 2;
                    ADGVAttendanceSheet.Columns["Name"].DisplayIndex = 3;
                    ADGVAttendanceSheet.Columns["ATTD_IN_TIME"].DisplayIndex = 4;
                    ADGVAttendanceSheet.Columns["ATTD_OUT_TIME"].DisplayIndex = 5;
                    ADGVAttendanceSheet.Columns["Total"].DisplayIndex = 6;

                }
                else
                {

                    //Did For Faculty's Remark.Mohan(27-July-2017).
                    ADGVAttendanceSheet.ReadOnly = false;
                    //Other Columns Should not be editable.Mohan(27-July-2017).
                    ADGVAttendanceSheet.Columns["ATTD_DATE"].ReadOnly = true;
                    ADGVAttendanceSheet.Columns["ATTD_IN_TIME"].ReadOnly = true;
                    ADGVAttendanceSheet.Columns["ATTD_OUT_TIME"].ReadOnly = true;
                    ADGVAttendanceSheet.Columns["Total"].ReadOnly = true;
                    ADGVAttendanceSheet.Columns["ATTD_STATUS"].ReadOnly = true;
                    ADGVAttendanceSheet.Columns["Name"].ReadOnly = true;



                    ADGVAttendanceSheet.Columns["ATTD_REMARK"].HeaderText = "Remark";
                    ADGVAttendanceSheet.Columns["ATTD_REMARK"].ReadOnly = true;
                    //Ordering Column Position

                    ADGVAttendanceSheet.Columns["ATTD_DATE"].DisplayIndex = 1;
                    ADGVAttendanceSheet.Columns["Name"].DisplayIndex = 2;
                    //ADGVAttendanceSheet.Columns["FCLT_CONTACT_NO"].DisplayIndex = 3;
                    ADGVAttendanceSheet.Columns["ATTD_IN_TIME"].DisplayIndex = 3;
                    ADGVAttendanceSheet.Columns["ATTD_OUT_TIME"].DisplayIndex = 4;
                    ADGVAttendanceSheet.Columns["Total"].DisplayIndex = 5;


                    //Changing HeaderText
                    if (ADGVAttendanceSheet.Columns.Contains("FCLT_CONTACT_NO"))
                    {
                        ADGVAttendanceSheet.Columns["FCLT_CONTACT_NO"].HeaderText = "ContactNo";
                    }
                }

                ADGVAttendanceSheet.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //If Faculty's Attendance is Viewed according to Lecturewise, then this function is called.Mohan(31-July-2017).
        private void formatFacultyGrid()
        {
            try
            {
                //Hiding Columns
                ADGVAttendanceSheet.Columns["ATLC_ID"].Visible = false;
                ADGVAttendanceSheet.Columns["chkHW"].Visible = false;
                ADGVAttendanceSheet.Columns["ATTD_ADMISSION_NO"].Visible = false;

                //Changing HeaderText.
                ADGVAttendanceSheet.Columns["ATTD_STATUS"].HeaderText = "Attendance";

                //Changing Date Format.
                ADGVAttendanceSheet.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;


                ADGVAttendanceSheet.Columns["Date"].DisplayIndex = 1;
                ADGVAttendanceSheet.Columns["Name"].DisplayIndex = 2;


                ADGVAttendanceSheet.Columns["ContactNo"].DisplayIndex = 3;
                ADGVAttendanceSheet.Columns["ATTD_STATUS"].DisplayIndex = 4;
            }
            catch (Exception ex)
            {
                throw ex;
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
                        chkAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                        btnSend.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        //btnSearch.Visible = false;
                        //btnViewAll.Visible = false;
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


        #endregion

        #region "Methods"

        private void showToolTip()
        {
            try
            {
                ToolTip showText = new ToolTip();

                // Set up the delays for the ToolTip.
                showText.AutoPopDelay = 8000;
                showText.InitialDelay = 800;
                showText.ReshowDelay = 500;
                // Force the ToolTip text to be displayed whether or not the form is active.
                showText.ShowAlways = true;

                showText.SetToolTip(btnInstructorAttendance, "Click to view Instructor's Attendance");
                showText.SetToolTip(cmbLecture, "View Lecture-Wise Attendance." + System.Environment.NewLine + "Consider From Date for filtering Lecture.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void loadAttencence()
        {
            try
            {

                string stream = (cmbStream.SelectedItem as ComboItem).strKey;
                string course = (cmbCourseType.SelectedItem as ComboItem).strKey;
                string batch = (cmbBatch.SelectedItem as ComboItem) == null ? "0" : (cmbBatch.SelectedItem as ComboItem).strKey;

                DateTime fromDate = dtpFromdate.Value;
                DateTime toDate = dtpToDate.Value;
                if (dtpFromdate.Value <= dtpToDate.Value)
                {
                    if (!chbFaculty.Checked)
                    {
                        toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus(stream, course, batch, fromDate, toDate, branchID, chkViewAbsent.Checked == true ? "A" : "%", "S", (cmbLecture.SelectedItem as ComboItem).key);
                        ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                    }
                    else
                    {
                        toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus(stream, course, batch, fromDate, toDate, branchID, chkViewAbsent.Checked == true ? "A" : "%", "F", (cmbLecture.SelectedItem as ComboItem).key);
                        ADGVAttendanceSheet.DataSource = toStoreDataGlobally;
                    }
                }

                else
                {
                    UICommon.WinForm.showStatus("FromDate Cannot be Greater than ToDate", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //View only Absents.Mohan(10-July-2017).
        private void viewAbsents()
        {
            try
            {
                if (toStoreDataGlobally != null)
                {
                    ADGVAttendanceSheet.DataSource = toStoreDataGlobally.Select("ATTD_STATUS='A'").CopyToDataTable();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The source contains no DataRows."))
                {
                    WinForm.showStatus("No Absent Members.", sCaption, this);
                }
                else
                {
                    throw ex;
                }
            }
        }




        //This function is to disable controls when user clicks on Faculty CheckBox.
        private void disableControls()
        {
            try
            {
                cmbStream.Enabled = false;
                cmbCourseType.Enabled = false;
                cmbBatch.Enabled = false;
                btnSend.Visible = false;
                attdgrbBy.Enabled = false;
                cmbLecture.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //This function is to enable controls when user unchecks the Faculty CheckBox.
        private void enableControls()
        {
            try
            {
                cmbStream.Enabled = true;
                cmbCourseType.Enabled = true;
                cmbBatch.Enabled = true;
                btnSend.Visible = true;
                attdgrbBy.Enabled = true;
                cmbLecture.Enabled = true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
