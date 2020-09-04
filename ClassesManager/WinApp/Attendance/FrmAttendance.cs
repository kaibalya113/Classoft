using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassManager.WinApp
{
    public partial class FrmAttendance : FrmParentForm
    {

        string sCaption = "Attendance";
        string branchId = (Program.LoggedInUser.BranchId.ToString());
        Boolean IndexChange;
        string AppName = Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME);


        /// <summary>
        /// 
        /// </summary>
        public FrmAttendance()
        {
            InitializeComponent();
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                ToolTip toolTip1 = new ToolTip();

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;


                toolTip1.SetToolTip(chbFaculty, "Select if you want to mark attendance for Instructor.");

                formatDTP();
                IndexChange = false;
                Collectstream();
                // cmbStream.DataSource = StreamHandller.getStreams(branchID);
                cmbCourseType.Items.Add(new ComboItem(-1, "All"));
                cmbBatch.Items.Add(new ComboItem(-1, "All"));

                cmbBatch.SelectedIndex = 0;
                cmbCourseType.SelectedIndex = 0;
                cmbStream.SelectedIndex = 0;
                IndexChange = true;
                // cmbStream.DataSource = StreamHandller.getStreams(Program.LoggedInUser.BranchId.ToString());
                if (AppName == "Gym" || AppName == "Dance")
                {
                    lblLecture.Visible = false;
                    cmbLecture.Visible = false;
                    lblStream.Visible = true;
                    lblcrse.Visible = true;
                    label1.Visible = false;
                    label2.Visible = false;
                }
                dtpmarkfor.CustomFormat = "dd-MMM-yyyy";
                DateTime date = dtpmarkfor.Value;
                Common.Formatter.FormatDate(date);

                this.Text = "Mark Attendance of " + Common.Formatter.FormatDate(date);

                ADGVAttendance.RowTemplate.MinimumHeight = 25;
                ADGVAttendance.RowTemplate.Height = 25;
                ADGVAttendance.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
                AssignEvents();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void AssignEvents()
        {
            ADGVAttendance.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVAttendance.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        //Formats DTP.Mohan(10 July 2017).
        private void formatDTP()
        {
            UICommon.WinForm.formatDateTimePicker(dtpmarkfor);
        }

        public void Collectstream()
        {
            try
            {
                List<Stream> lstStream = StreamHandller.getStreams(branchId);

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




        public void CollectCourse(int streamId = -1)
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

                CollectBatch(-1);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CollectBatch(int stdID = -1)
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


        //Disable Controls.Mohan(10-July-2017).
        private void disableControls()
        {
            try
            {
                cmbStream.Enabled = false;
                cmbCourseType.Enabled = false;
                cmbBatch.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Enable Controls.Mohan(10-July-2017).
        private void enableControls()
        {
            try
            {
                cmbStream.Enabled = true;
                cmbCourseType.Enabled = true;
                cmbBatch.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chbFaculty_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbFaculty.Checked)
                {
                    disableControls();
                }
                else
                {
                    enableControls();
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }
        //If form is to be open from Attendance, then Date should get set.Mohan(31-July-2017).
        public void setDate(DateTime value)
        {
            dtpmarkfor.Value = value;
        }

        //Function To Mark Attendance.Mohan(01-Aug-2017).
        private void markAttendance(bool silent = false)
        {

            try
            {
                if (chbFaculty.Checked)
                {
                    if (silent == false)
                    {
                        var result = UICommon.WinForm.showStatus("Do you want to Mark Attendance of All Faculties?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                        if (result == DialogResult.Yes)
                        {
                            BLL.AttendanceHandler.markAttendenceManually("0", "0", dtpmarkfor.Value, Program.LoggedInUser.BranchId.ToString(), (cmbLecture.SelectedItem as ComboItem).key, true);
                            ADGVAttendance.DataSource = BLL.AttendanceHandler.getAttendanceStatus("0", "0", "0", dtpmarkfor.Value, dtpmarkfor.Value, Program.LoggedInUser.BranchId.ToString(), "%", "F", (cmbLecture.SelectedItem as ComboItem).key);
                            formatFacultyGrid();
                        }
                    }
                    else
                    {
                        ADGVAttendance.DataSource = BLL.AttendanceHandler.getAttendanceStatus("0", "0", "0", dtpmarkfor.Value, dtpmarkfor.Value, Program.LoggedInUser.BranchId.ToString(), "%", "F", (cmbLecture.SelectedItem as ComboItem).key);
                        formatFacultyGrid();
                    }
                }
                else
                {

                    string stdid = (cmbCourseType.SelectedItem as ComboItem).strKey;
                    string batchid = (cmbBatch.SelectedItem as ComboItem).strKey;
                    if (silent == false)
                    {
                        var result = UICommon.WinForm.showStatus("Do you want to Mark Attendance ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                        if (result == DialogResult.Yes)
                        {
                            if (ValidationForLectureAttd())
                            {
                                BLL.AttendanceHandler.markAttendenceManually(batchid, stdid, dtpmarkfor.Value, Program.LoggedInUser.BranchId.ToString(), (cmbLecture.SelectedItem as ComboItem).key);
                                DataTable dt = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).key.ToString(), (cmbCourseType.SelectedItem as ComboItem).key.ToString(), (cmbBatch.SelectedItem as ComboItem).key.ToString(), dtpmarkfor.Value, dtpmarkfor.Value, Program.LoggedInUser.BranchId.ToString(), "%", "S", (cmbLecture.SelectedItem as ComboItem).key);
                                ADGVAttendance.DataSource = dt;
                                formatStudentGrid();
                            }
                        }
                    }
                    else
                    {
                        DataTable dt = BLL.AttendanceHandler.getAttendanceStatus((cmbStream.SelectedItem as ComboItem).key.ToString(), (cmbCourseType.SelectedItem as ComboItem).key.ToString(), (cmbBatch.SelectedItem as ComboItem).key.ToString(), dtpmarkfor.Value, dtpmarkfor.Value, Program.LoggedInUser.BranchId.ToString(), "%", "S", (cmbLecture.SelectedItem as ComboItem).key);
                        ADGVAttendance.DataSource = dt;
                        formatStudentGrid();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private bool ValidationForLectureAttd()
        {
            try
            {
                if ((cmbLecture.SelectedItem as ComboItem).key != 0)
                {
                    if ((cmbStream.SelectedItem as ComboItem).strKey == "-1")
                    {
                        UICommon.WinForm.showStatus("Please Select the Stream to mark Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        cmbStream.Focus();
                        return false;

                    }
                    else if ((cmbCourseType.SelectedItem as ComboItem).strKey == "-1")
                    {
                        UICommon.WinForm.showStatus("Please Select the Course to mark Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        cmbCourseType.Focus();
                        return false;
                    }
                    else if ((cmbBatch.SelectedItem as ComboItem).strKey == "-1")
                    {
                        UICommon.WinForm.showStatus("Please Select the Batch to mark Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        cmbBatch.Focus();
                        return false;
                    }
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void formatFacultyGrid()
        {
            try
            {

                if (!ADGVAttendance.Columns.Contains("chkPresent"))
                {
                    DataGridViewCheckBoxColumn chkPresent = new DataGridViewCheckBoxColumn();
                    chkPresent.Name = "chkPresent";
                    chkPresent.HeaderText = "Status";
                    chkPresent.ReadOnly = true;
                    ADGVAttendance.Columns.Insert(0, chkPresent);
                }

                if ((cmbLecture.SelectedItem as ComboItem).key == 0)
                {

                    ADGVAttendance.ReadOnly = false;


                    //Making it ReadOnly.
                   // DataGridViewCheckBoxColumn chkPresent = new DataGridViewCheckBoxColumn();
                   // chkPresent.Name = "chkPresent";
                    //chkPresent.HeaderText = "Late Marks";
                    ADGVAttendance.Columns["Name"].ReadOnly = false;
                    ADGVAttendance.Columns["FCLT_CONTACT_NO"].ReadOnly = true;
                    ADGVAttendance.Columns["ATTD_DATE"].ReadOnly = true;
                    ADGVAttendance.Columns["ATTD_STATUS"].ReadOnly = true;

                    ADGVAttendance.Columns["ATTD_REMARK"].Visible = true;

                    //Hiding Columns
                    ADGVAttendance.Columns["ATTD_IS_HOLIDAY"].Visible = false;
                    ADGVAttendance.Columns["ATTD_ID"].Visible = false;


                    //Changing HeaderText.
                    ADGVAttendance.Columns["ATTD_IN_TIME"].HeaderText = "In";
                    ADGVAttendance.Columns["ATTD_OUT_TIME"].HeaderText = "Out";
                    ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                    ADGVAttendance.Columns["ATTD_STATUS"].HeaderText = "Attendance";
                    ADGVAttendance.Columns["ATTD_REMARK"].HeaderText = "Remark";
                    ADGVAttendance.Columns["FCLT_CONTACT_NO"].HeaderText = "ContactNo";

                    //Ordering Columns.
                    ADGVAttendance.Columns["ATTD_DATE"].DisplayIndex = 1;
                    ADGVAttendance.Columns["Name"].DisplayIndex = 2;
                    ADGVAttendance.Columns["FCLT_CONTACT_NO"].DisplayIndex = 3;
                    ADGVAttendance.Columns["ATTD_IN_TIME"].DisplayIndex = 4;
                    ADGVAttendance.Columns["ATTD_OUT_TIME"].DisplayIndex = 5;
                    ADGVAttendance.Columns["Total"].DisplayIndex = 6;
                    ADGVAttendance.Columns["ATTD_STATUS"].DisplayIndex = 7;
                    ADGVAttendance.Columns["ATTD_REMARK"].DisplayIndex = 8;

                    //GridDate Format.
                    ADGVAttendance.Columns["ATTD_DATE"].DefaultCellStyle = WinForm.GridDateFormat;
                }
                else
                {

                    ADGVAttendance.ReadOnly = false;


                    //Making it ReadOnly.
                    ADGVAttendance.Columns["Name"].ReadOnly = true;
                    ADGVAttendance.Columns["ContactNo"].ReadOnly = true;
                    ADGVAttendance.Columns["Date"].ReadOnly = true;
                    ADGVAttendance.Columns["ATTD_STATUS"].ReadOnly = true;

                    ADGVAttendance.Columns["Remark"].Visible = true;

                    //Hiding Columns.
                    ADGVAttendance.Columns["ATLC_ID"].Visible = false;

                    //GridDate Format.
                    ADGVAttendance.Columns["DATE"].DefaultCellStyle = WinForm.GridDateFormat;

                    ADGVAttendance.Columns["Date"].DisplayIndex = 1;
                    ADGVAttendance.Columns["ATTD_ADMISSION_NO"].DisplayIndex = 2;
                    ADGVAttendance.Columns["Name"].DisplayIndex = 3;
                    ADGVAttendance.Columns["ContactNo"].DisplayIndex = 4;
                    ADGVAttendance.Columns["ATTD_STATUS"].DisplayIndex = 5;
                    ADGVAttendance.Columns["Remark"].DisplayIndex = 6;

                }

                ADGVAttendance.Columns["ATTD_ADMISSION_NO"].HeaderText = "Id";
                ADGVAttendance.Columns["Name"].Width = 170;
                ADGVAttendance.Columns["sort_order"].Visible = false;


                //Checking Absent Students.
                foreach (DataGridViewRow row in ADGVAttendance.Rows)
                {
                    if (row.Cells["ATTD_STATUS"].Value.ToString() == "A")
                    {
                        row.Cells["chkPresent"].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Mohan(01-Aug-2017).
        private void formatStudentGrid()
        {
            try
            {
                if (!ADGVAttendance.Columns.Contains("chkPresent"))
                {
                    DataGridViewCheckBoxColumn chkPresent = new DataGridViewCheckBoxColumn();
                    chkPresent.Name = "chkPresent";
                    chkPresent.HeaderText = "Status";
                    chkPresent.ReadOnly = true;
                    //chkPresent.ReadOnly = false;
                    ADGVAttendance.Columns.Insert(0, chkPresent);
                }
                if (!ADGVAttendance.Columns.Contains("late_mark"))
                {
                    DataGridViewCheckBoxColumn chkPresent = new DataGridViewCheckBoxColumn();
                    chkPresent.Name = "late_Mark";
                    chkPresent.HeaderText = "Late Mark";
                    chkPresent.ReadOnly = false;
                    //chkPresent.ReadOnly = false;
                    ADGVAttendance.Columns.Insert(1, chkPresent);
                }
                if (!ADGVAttendance.Columns.Contains("Column1"))
                {
                    DataGridViewCheckBoxColumn chkPresent = new DataGridViewCheckBoxColumn();
                    chkPresent.Name = "late_Mark";
                    chkPresent.HeaderText = "Late Mark";
                    chkPresent.ReadOnly = false;
                    //chkPresent.ReadOnly = false;
                    ADGVAttendance.Columns.Insert(1, chkPresent);
                }
                //Hiding Columns.
                if (ADGVAttendance.Columns.Contains("STRM_ID"))
                {
                    ADGVAttendance.Columns["STRM_ID"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("STD_ID"))
                {
                    ADGVAttendance.Columns["STD_ID"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("STRM_NAME"))
                {
                    ADGVAttendance.Columns["STRM_NAME"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("STD_NAME"))
                {
                    ADGVAttendance.Columns["STD_NAME"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("BTCH_NAME"))
                {
                    ADGVAttendance.Columns["BTCH_NAME"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("BTCH_ID"))
                {
                    ADGVAttendance.Columns["BTCH_ID"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("ATTD_LECTURE_ID"))
                {
                    ADGVAttendance.Columns["ATTD_LECTURE_ID"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("ATTD_Admission_No"))
                {
                    ADGVAttendance.Columns["ATTD_Admission_No"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("late_mark"))
                {
                    ADGVAttendance.Columns["late_mark"].HeaderText = "Late Mark";
                }
                if (ADGVAttendance.Columns.Contains("Column1"))
                {
                    ADGVAttendance.Columns["Column1"].HeaderText = "Late Mark";
                }
                if ((cmbLecture.SelectedItem as ComboItem).key == 0)
                {
                    ADGVAttendance.Columns["ATTD_REMARK"].Visible = false;
                    ADGVAttendance.Columns["ATTD_IS_HOLIDAY"].Visible = false;
                    ADGVAttendance.Columns["ATTD_ID"].Visible = false;

                    //Changing HeaderText
                    ADGVAttendance.Columns["Id"].HeaderText = "ID";
                    ADGVAttendance.Columns["ATTD_IN_TIME"].HeaderText = "In";
                    ADGVAttendance.Columns["ATTD_OUT_TIME"].HeaderText = "Out";
                    ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                    ADGVAttendance.Columns["ATTD_STATUS"].HeaderText = "Attendance";
                    ADGVAttendance.Columns["late_mark"].HeaderText = "Late Mark";
                    //Ordering Columns.
                    ADGVAttendance.Columns["Id"].DisplayIndex = 3;
                    ADGVAttendance.Columns["ATTD_DATE"].DisplayIndex = 2;
                    ADGVAttendance.Columns["Name"].DisplayIndex = 4;
                    ADGVAttendance.Columns["ATTD_IN_TIME"].DisplayIndex = 5;
                    ADGVAttendance.Columns["ATTD_OUT_TIME"].DisplayIndex = 6;
                    ADGVAttendance.Columns["Total"].DisplayIndex = 7;
                    ADGVAttendance.Columns["ATTD_STATUS"].DisplayIndex = 8;
                    ADGVAttendance.Columns["late_mark"].DisplayIndex = 1;
                    //  ADGVAttendance.Columns["late_mark"].DisplayIndex = 7;

                    // width setting:
                       ADGVAttendance.Columns["chkPresent"].Width = 30;
                    ADGVAttendance.Columns["late_mark"].Width = 60;
                    ADGVAttendance.Columns["ATTD_IN_TIME"].Width = 70;
                    ADGVAttendance.Columns["ATTD_OUT_TIME"].Width = 70;
                    ADGVAttendance.Columns["Total"].Width = 50;
                    ADGVAttendance.Columns["ATTD_STATUS"].Width = 70;
                    ADGVAttendance.Columns["ID"].Width = 50;
                   // ADGVAttendance.Columns["Attendance"].Width = 30;



                }

                else
                {
                    //Hiding.
                    ADGVAttendance.Columns["ATLC_ID"].Visible = false;

                    //Changing HeaderText.
                    ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                    ADGVAttendance.Columns["ATTD_STATUS"].HeaderText = "Attendance";

                    //Formatting Date.
                    //ADGVAttendance.Columns["ATTD_DATE"].DefaultCellStyle = WinForm.GridDateFormat;

                    //Ordering Columns.
                    ADGVAttendance.Columns["ATTD_DATE"].DisplayIndex = 1;
                    ADGVAttendance.Columns["Name"].DisplayIndex = 2;
                    ADGVAttendance.Columns["ATTD_STATUS"].DisplayIndex = 3;
                }

                //Hiding Columns.
                ADGVAttendance.Columns["STMT_FATHER_CONTACT"].Visible = false;
                ADGVAttendance.Columns["sort_order"].Visible = false;

                //GridDate Format.
                ADGVAttendance.Columns["ATTD_DATE"].DefaultCellStyle = WinForm.GridDateFormat;
                ADGVAttendance.Columns["Name"].Width = 170;
                ADGVAttendance.Columns["chkPresent"].Width = 70;
                //ADGVAttendance.Columns["late_mark"].Width = 70;
                //Checking Absent Students.
                foreach (DataGridViewRow row in ADGVAttendance.Rows)
                {
                    if (row.Cells["ATTD_STATUS"].Value.ToString() == "A")
                    {
                        row.Cells["chkPresent"].Value = true;
                    }
                }

                ADGVAttendance.Columns["Name"].ReadOnly = true;
                ADGVAttendance.Columns["ATTD_DATE"].ReadOnly = true;
                ADGVAttendance.Columns["ATTD_STATUS"].ReadOnly = true;
                ADGVAttendance.Columns["Total"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbStream.Items.Count == 0)
                {
                    UICommon.WinForm.showStatus("Please create Stream", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
                else
                {
                    markAttendance();
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        //Mohan.(01-Aug-2017).
        private void dtpmarkfor_CloseUp(object sender, EventArgs e)
        {
            try
            {
                loadSubjects();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int stdID = ((cmbCourseType.SelectedItem as Info.ComboItem).key);

                CollectBatch(stdID);
                if (cmbBatch.Items.Count > 0)
                {
                    cmbBatch.SelectedIndex = 0;
                }
                loadSubjects();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String stream = (cmbStream.SelectedItem as ComboItem).strKey;
                //  cmbCourseType.DataSource = StandardHandller.getStandard(Program.LoggedInUser.BranchId.ToString(), stream);
                CollectCourse(Convert.ToInt32((cmbStream.SelectedItem as ComboItem).strKey));
                if (cmbCourseType.Items.Count > 0)
                {
                    cmbCourseType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        //Function to load Subjects in cmbLecture(Combo Lecture).
        private void loadSubjects()
        {
            //Clears the Items.
            cmbLecture.Items.Clear();
            cmbLecture.Items.Add(new ComboItem(0, "Full Day"));
            //Loading Subjects in cmbLecture
            //List<Lecture> lstLecture = BLL.LectureHandler.getSubjectsForAttendance((cmbCourseType.SelectedItem as Standard).Standardid, (cmbBatch.SelectedItem as Batch).id, dtpmarkfor.Value, Program.LoggedInUser.BranchId);
            List<Lecture> lstLecture = BLL.LectureHandler.getSubjectsForAttendance((cmbCourseType.SelectedItem as ComboItem).key, (cmbBatch.SelectedItem as ComboItem).key, dtpmarkfor.Value, Program.LoggedInUser.BranchId);
            if (lstLecture.Count > 0)
            {

                foreach (Lecture objLecture in lstLecture)
                {
                    cmbLecture.Items.Add(new ComboItem(objLecture.LectureID, objLecture.Standard.StandardName + " " + objLecture.Batch.Name + " " + objLecture.Subject.SubjName));
                }
            }
            cmbLecture.SelectedIndex = 0;
        }

        //Function To Mark Attendance.Mohan(01-Aug-2017).
        private void updateAttendance()
        {
            try
            {
                if (!chbFaculty.Checked)
                {

                    DataTable dt = new DataTable();
                    dt = ADGVAttendance.DataSource as DataTable;

                    foreach (DataRow dtRows in dt.Rows)
                    {
                        Boolean lateStatus;

                        // if(dt["late_mark"])
                        try
                        {
                            if ((bool)dtRows["late_mark"])
                            {
                                lateStatus = (bool)dtRows["late_mark"];
                            }
                            else
                            {
                                lateStatus = false;
                            }
                        }catch(Exception e)
                        {
                            lateStatus = false;
                        }

                       
                        


                        string status = dtRows["ATTD_STATUS"].ToString();
                        int attendanceID = Convert.ToInt32(dtRows["ATTD_ID"]);
                        string inTime = dtRows["ATTD_IN_TIME"].ToString();
                        string outTime = dtRows["ATTD_OUT_TIME"].ToString();
                        DateTime? dtInTime = null;
                        DateTime? dtOutTime = null;

                        if (SysParam.getValue<bool>(SysParam.Parameters.IS_AUTOMATIC) == false)
                        {
                            if (!inTime.Equals(""))
                            {
                                try
                                {
                                    inTime = Common.Formatter.formatTime(inTime);
                                    dtInTime = DateTime.ParseExact(inTime, "h:m tt", System.Globalization.CultureInfo.InvariantCulture);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Invalid in time for " + dtRows["Name"].ToString(), sCaption);
                                    throw new FormatException();
                                }
                            }

                            if (!outTime.Equals(""))
                            {
                                try
                                {
                                    outTime = Common.Formatter.formatTime(outTime);
                                    dtOutTime = DateTime.ParseExact(outTime, "h:m tt", System.Globalization.CultureInfo.InvariantCulture);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Invalid out time for " + dtRows["Name"].ToString());
                                    throw new FormatException();
                                }
                            }
                        }

                        BLL.AttendanceHandler.updateAttendaceStatus(lateStatus, attendanceID, status, Program.LoggedInUser.BranchId, (cmbLecture.SelectedItem as ComboItem).key == 0 ? false : true, dtInTime, dtOutTime);
                    }
                    UICommon.WinForm.showStatus("Attendance saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    //BLL.AttendanceHandler.updateAttendaceStatus()
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = ADGVAttendance.DataSource as DataTable;

                    foreach (DataRow dtRows in dt.Rows)
                    {
                        Boolean lateStatus = (bool)dtRows["late_mark"];
                        if ((bool)dtRows["late_mark"])
                        {
                            lateStatus = (bool)dtRows["late_mark"];
                        }else
                        {
                            lateStatus = false;
                        }
                        string status = dtRows["ATTD_STATUS"].ToString();
                        int attendanceID = Convert.ToInt32(dtRows["ATTD_ID"]);
                        string remark = dtRows["ATTD_REMARK"].ToString();
                        string inTime = dtRows["ATTD_IN_TIME"].ToString();
                        string outTime = dtRows["ATTD_IN_TIME"].ToString();
                        DateTime? dtInTime = null;
                        DateTime? dtOutTime = null;

                        if (SysParam.getValue<bool>(SysParam.Parameters.IS_AUTOMATIC) == false)
                        {
                            if (!inTime.Equals(""))
                            {
                                try
                                {
                                    inTime = Common.Formatter.formatTime(inTime);
                                    dtInTime = DateTime.ParseExact(inTime, "h:m tt", System.Globalization.CultureInfo.InvariantCulture);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Invalid in time for " + dtRows["Name"].ToString(), sCaption);
                                    throw new FormatException();
                                }
                            }

                            if (!outTime.Equals(""))
                            {
                                try
                                {
                                    outTime = Common.Formatter.formatTime(outTime);
                                    dtOutTime = DateTime.ParseExact(outTime, "h:m tt", System.Globalization.CultureInfo.InvariantCulture);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Invalid out time for " + dtRows["Name"].ToString());
                                    throw new FormatException();
                                }
                            }
                        }

                        BLL.AttendanceHandler.updateAttendaceStatus(lateStatus, attendanceID, status, Program.LoggedInUser.BranchId, (cmbLecture.SelectedItem as ComboItem).key == 0 ? false : true, dtInTime, dtOutTime, (cmbLecture.SelectedItem as ComboItem).key == 0 ? dtRows["ATTD_REMARK"].ToString() : dtRows["ATTD_REMARK"].ToString());
                    }
                    UICommon.WinForm.showStatus("Attendance saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    //BLL.AttendanceHandler.updateAttendaceStatus()

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex != -1)
                {

                    string newValue;

                    if (FrmAttendanceSheet.isAutomaticBio == false)
                    {

                        if (e.ColumnIndex == 0)
                        {
                            DataGridViewCheckBoxCell dgvChckbx = (DataGridViewCheckBoxCell)ADGVAttendance.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            dgvChckbx.Value = (Convert.ToBoolean(dgvChckbx.Value));

                            ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].Value = "";
                            ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_OUT_TIME"].Value = "";
                            ADGVAttendance.Rows[e.RowIndex].Cells["Total"].Value = "";

                            if ((Boolean)dgvChckbx.Value == true)
                            {
                                dgvChckbx.Value = true;
                                newValue = "P";
                                ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_STATUS"].Value = newValue;
                                ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].ReadOnly = false;
                                ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_OUT_TIME"].ReadOnly = false;


                            }
                            else
                            {
                                dgvChckbx.Value = false;
                                newValue = "A";
                                ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_STATUS"].Value = newValue;
                                ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].ReadOnly = true;
                                ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_OUT_TIME"].ReadOnly = true;

                            }

                            DataGridViewCheckBoxCell dgvChckbxvalue = (DataGridViewCheckBoxCell)ADGVAttendance.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            dgvChckbx.Value = !(Convert.ToBoolean(dgvChckbx.Value));
                            dgvChckbx.TrueValue = true;
                            dgvChckbx.FalseValue = false;
                        }

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Can not mark attendence manually", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        //Mohan.(01-Aug-2017).
        private void ADGVAttendance_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(ADGVAttendance, e);
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        }

        public void getStatus()
        {
            try
            {
                DataTable dt = ADGVAttendance.DataSource as DataTable;
                int i = 0;
                foreach (DataRow dtRows in dt.Rows)
                {

                    //string status = dtRows[6].ToString();
                    string status = dtRows[4].ToString();

                    DataGridViewCheckBoxCell dgvChckbx = (DataGridViewCheckBoxCell)ADGVAttendance.Rows[i].Cells[0];
                    dgvChckbx.Value = !(Convert.ToBoolean(dgvChckbx.Value));
                    if (status == "A")
                    {
                        //    ADGVAttendanceSheet.Columns[0].Selected = true;
                        dgvChckbx.Value = true;

                    }
                    else
                    {
                        //  ADGVAttendanceSheet.Columns[0].Selected = false;
                        dgvChckbx.Value = false;
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Mohan.(02-Aug-2017).
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVAttendance.Rows.Count == 0)
                {
                    UICommon.WinForm.showStatus("No Records to Save,First Mark attendence for the Batch ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
                else
                {
                    updateAttendance();
                    markAttendance(true);
                }


                if (chbFaculty.Checked == false)
                {
                    var result = UICommon.WinForm.showStatus("Do You Want to send SMS to Absent Members.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (result == DialogResult.Yes)
                    {
                        DataTable absntStuds = new DataTable();
                        absntStuds.Columns.Add("Name");
                        absntStuds.Columns.Add("Date");
                        absntStuds.Columns.Add("ContactNo");
                        absntStuds.Columns.Add("Id");
                        absntStuds.Columns.Add("ATTD_ID");

                        foreach (DataGridViewRow row in ADGVAttendance.Rows)
                        {
                            string name = SysParam.getValue<string>(SysParam.Parameters.LECTUREWISE_ATTD);
                            if (row.Cells[5].Value.ToString() == "A")
                            {

                                absntStuds.Rows.Add(new object[] { row.Cells["Name"].Value, row.Cells["ATTD_DATE"].Value, row.Cells["STMT_FATHER_CONTACT"].Value, row.Cells[1].Value, row.Cells["ATTD_ID"].Value });

                            }
                        }
                        bool isSent = NotificationHandler.sendAbsentMessageForADay(absntStuds);
                        UICommon.WinForm.setSMSStatus(isSent, sCaption, this);
                    }
                }
                  
            }
            catch (FormatException ex)
            {

            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnViewAttd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAttendanceSheet objattd = UICommon.FormFactory.GetForm(UICommon.Forms.FrmAttendanceSheet) as FrmAttendanceSheet;
                objattd.Visible = true;
                this.Close();
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
                bs.DataSource = ADGVAttendance.DataSource;
                bs.Filter = string.Format("Name LIKE '%{0}%'", txtFName.Text);
                // bs.Filter = ADGVFollowup.Columns["Name"].HeaderText.ToString() + " LIKE '%" + txtFName.Text + "%'";
                ADGVAttendance.DataSource = bs;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVAttendance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                ADGVAttendance.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ADGVAttendance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ADGVAttendance.Columns["ATTD_IN_TIME"].Index || e.ColumnIndex == ADGVAttendance.Columns["ATTD_OUT_TIME"].Index)
                {
                    DateTime dtOutTime;
                    DateTime dtInTime;
                    try
                    {
                        string inTime = ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].Value.ToString();
                        inTime = Common.Formatter.formatTime(inTime);
                        dtInTime = DateTime.ParseExact(inTime, "h:m tt", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        return;
                    }

                    try
                    {
                        string outTime = ADGVAttendance.Rows[e.RowIndex].Cells["ATTD_OUT_TIME"].Value.ToString();
                        outTime = Common.Formatter.formatTime(outTime);
                        dtOutTime = DateTime.ParseExact(outTime, "h:m tt", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        return;
                    }

                    ADGVAttendance.Rows[e.RowIndex].Cells["total"].Value = (dtOutTime - dtInTime).ToString("g");
                }
            }
            catch (Exception)
            {

            }

        }

        private void ADGVAttendance_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
