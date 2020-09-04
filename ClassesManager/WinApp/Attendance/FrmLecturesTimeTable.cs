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
using ClassManager.Info.Reporting;

namespace ClassManager.WinApp
{
    public partial class FrmLecturesTimeTable : FrmParentForm
    {
        RolePrivilege formPrevileges;
        Lecture lect = new Lecture();
        bool allow;
        string sCaption = "LecturesTimeTable";
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        List<Lecture> lstlect = new List<Lecture>();

        //To Avoid Clash of Faculty during lectures, this List is use.
        List<Lecture> lstFacLec = new List<Lecture>();

        bool allowIndexChanges = false;
        private List<Lecture> lstLoadedLectures;

        /// <summary>
        /// 
        /// </summary>
        public FrmLecturesTimeTable()
        {
            InitializeComponent();
        }

        private void LecturesTimeTable_Load(object sender, EventArgs e)
        {
            try
            {
                populateStream();
                cmbCourseType.Items.Clear();
                cmbCourse.Items.Clear();
                cmbCourseType.Items.Add(new ComboItem("%", "All", null));

                cmbBatch.Items.Clear();
                cmbBtch.Items.Clear();
                cmbBatch.Items.Add(new ComboItem("%", "All", null));

                cmbCourse.SelectedItem = 0;
                cmbCourseType.SelectedIndex = 0;

                cmbBatch.SelectedIndex = 0;
                cmbBtch.SelectedItem = 0;
                // DateTime.Now.ToString("HH:mm:ss tt");

                fromTime.CustomFormat = "HH:mm";
                toTime.CustomFormat = "HH:mm";

                allowIndexChanges = true;

                //Assign Events.
                WinForm.AssignFilterEvent(ADGVLectureDetails);
                WinForm.AssignFilterEvent(ADGVLectures);


                formatDTP();

                ApplyPrevileges();
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

                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {
                        btnSend.Visible = false;
                        btnSave.Visible = false;
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


        /// <summary>
        /// Formats the DateTimePicker.
        /// </summary>
        private void formatDTP()
        {
            try
            {
                //Sets the Date Format
                UICommon.WinForm.formatDateTimePicker(dtpFrom);
                UICommon.WinForm.formatDateTimePicker(dtpTo);
                UICommon.WinForm.formatDateTimePicker(dtpLect);

                //Sets Start and End Date.
                WinForm.setDate(dtpFrom, dtpTo);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void populateStream()
        {
            try
            {
                cmbStream.Items.Clear();
                cmbStream.Items.Add(new ComboItem("%", "All", null));
                List<Stream> lstStream = StreamHandller.getStreams(branchID);
                if (lstStream.Count != 0)
                {
                    foreach (Stream objStream in lstStream)
                    {
                        cmbStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name, objStream));
                    }
                    cmbStream.SelectedIndex = 0;
                    cmbStrm.SelectedItem = 1;
                }
                else
                {
                    UICommon.WinForm.showStatus("No Streams available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void populateCourse()
        {
            try
            {
                cmbCourseType.Items.Clear();
                cmbCourseType.Items.Add(new ComboItem("%", "All", null));
                if (((cmbStream.SelectedItem as ComboItem).name) == "All")
                {
                    cmbCourseType.SelectedIndex = 0;
                }
                else
                {
                    List<Standard> lstStd = StandardHandller.getStandard(branchID, (cmbStream.Items[cmbStream.SelectedIndex] as ComboItem).strKey);
                    if (lstStd.Count != 0)
                    {
                        foreach (Standard objStandard in lstStd)
                        {
                            cmbCourseType.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName, objStandard));
                        }
                        cmbCourseType.SelectedIndex = 0;
                        cmbCourseType_SelectedIndexChanged(cmbCourseType, new EventArgs());
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No Courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void populateSubject()
        {
            try
            {
                lblSubject.Visible = true;
                lblfaculty.Visible = true;
                cmbSubj.Visible = true;
                cmbFaculty.Visible = true;
                cmbSubj.Items.Clear();

                List<Info.TestSubject> lstSubjc = StandardHandller.getSubjectList(Program.LoggedInUser.BranchId, (cmbCourse.Items[cmbCourse.SelectedIndex] as ComboItem).key);

                if (lstSubjc.Count != 0)
                {
                    foreach (Info.TestSubject objSubject in lstSubjc)
                    {
                        cmbSubj.Items.Add(new ComboItem(objSubject.subjectmaster.SubjId, objSubject.subjectmaster.SubjName));
                    }

                    cmbSubj.SelectedIndex = 0;
                    //cmbSubj_SelectedIndexChanged(cmbSubj, new EventArgs());
                }
                else
                {
                    var selectPackage = UICommon.WinForm.showStatus("No Subjects available.\nDo you want to Add Subject ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (selectPackage == DialogResult.Yes)
                    {
                        try
                        {
                            UICommon.FormFactory.GetForm(UICommon.Forms.FrmSubjectMaster).Visible = true;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void populateBatch()
        {
            try
            {
                if (allowIndexChanges)
                {
                    allowIndexChanges = false;

                    cmbBatch.Items.Clear();
                    cmbBatch.Items.Add(new ComboItem("%", "All", null));
                    if (((cmbCourseType.SelectedItem as ComboItem).name) == "All")
                    {
                        cmbBatch.SelectedIndex = 0;
                    }
                    else
                    {
                        List<Batch> lstBatch = StandardHandller.GetBatches((cmbCourseType.Items[cmbCourseType.SelectedIndex] as ComboItem).key, Program.LoggedInUser.BranchId);

                        if (lstBatch.Count != 0)
                        {
                            foreach (Batch objBatch in lstBatch)
                            {
                                cmbBatch.Items.Add(new ComboItem(objBatch.id.ToString(), objBatch.Name, objBatch));
                                Batch obj = new Batch();
                                obj = lstBatch[0];
                                fromTime.Value = (obj.FromTime == null) ? DateTime.Now : obj.FromTime.Value;
                                toTime.Value = (obj.ToTime == null) ? DateTime.Now : obj.ToTime.Value;
                                cmbBatch.SelectedIndex = 0;
                                //cmbBatch_SelectedIndexChanged(cmbBatch, new EventArgs());
                            }
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No Batches available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                    allowIndexChanges = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void populateFaculty()
        {
            try
            {
                cmbFaculty.Items.Clear();
                List<Info.Faculty> lstFaculty = StandardHandller.getFacultiesBySubject((cmbSubj.Items[cmbSubj.SelectedIndex] as ComboItem).key, branchID);

                if (lstFaculty.Count != 0)
                {
                    foreach (Info.Faculty objFaculty in lstFaculty)
                    {
                        cmbFaculty.Items.Add(new ComboItem(objFaculty.FacultyID.ToString(), objFaculty.Name));
                    }
                    cmbFaculty.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No Faculties available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


       
        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            try
            {
                ADGVLectures.DataSource = null;
                lstlect = new List<Lecture>();

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChanges)
                {
                    populateCourse();
                }
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
                if (allowIndexChanges)
                {
                    populateBatch();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private bool ValidateControls()
        {
            if (cmbStream.SelectedIndex == -1)
            {
                UICommon.WinForm.showStatus("Please Select Stream ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            else if (cmbCourseType.SelectedIndex == -1)
            {
                UICommon.WinForm.showStatus("Please Select course", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            else if (cmbBatch.SelectedIndex == -1)
            {
                UICommon.WinForm.showStatus("Please Select batch", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            else if (cmbSubj.SelectedIndex == -1)
            {
                UICommon.WinForm.showStatus("Please Select subject", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }

            else if (cmbFaculty.SelectedIndex == -1)
            {
                UICommon.WinForm.showStatus("Please Select Faculty", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            else if (dtpLect.Value.Date <= System.DateTime.Now.AddDays(-1))
            {
                UICommon.WinForm.showStatus("Can't select date before today's date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            else if (fromTime.Value.ToShortTimeString() == toTime.Value.ToShortTimeString())
            {
                UICommon.WinForm.showStatus("Please select proper time,From and To time cannot be same", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }

            else
            {
                return true;
            }
        }

        /// <summary>
        /// This Function is to validate whether Faculty has lecture anywhere else or not while Scheduling Lecture.
        /// </summary>
        /// <returns></returns>
        public bool ValidateFaculty()
        {
            //Fetching selected Faculty's Lecture and Validating whether He/She has Lecture elsewhere.
            lstFacLec = BLL.LectureHandler.GetFacultyLec((cmbFaculty.SelectedItem as ComboItem).key, dtpLect.Value, branchID);
            foreach (Lecture objchk in lstFacLec)
            {
                if (objchk.Date.ToShortDateString() == dtpLect.Value.ToShortDateString())
                {
                    if ((fromTime.Value >= objchk.FromTime && fromTime.Value < objchk.ToTime) || (toTime.Value > objchk.FromTime && toTime.Value <= objchk.ToTime))
                    {
                        UICommon.WinForm.showStatus(("Faculty " + (cmbFaculty.SelectedItem as ComboItem).name + " has lecture from " + objchk.FromTime.ToShortTimeString() + " to " + objchk.ToTime.ToShortTimeString() + " in Batch " + objchk.Batch.Name + " of Standard " + objchk.Standard.StandardName), sCaption, this);
                        return false;
                    }
                }
            }

            //This Will Validate Whether Batch already has Lecture anywhere or not.
            if (lstlect.Count > 0)
            {
                foreach (Lecture obj in lstlect)
                {
                    if ((fromTime.Value >= obj.FromTime && fromTime.Value < obj.ToTime) || (toTime.Value >= obj.FromTime && toTime.Value <= obj.ToTime))
                    {
                        //if (obj.Faculty.FacultyID == (cmbFaculty.SelectedItem as ComboItem).key)
                        //{
                        //    UICommon.WinForm.showStatus("Cannot schedule lecture. " + (cmbFaculty.SelectedItem as ComboItem).name + " already has lecture from " + obj.FromTime.ToShortTimeString() + " to " + obj.ToTime.ToShortTimeString(), MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        //    return false;
                        //}
                        UICommon.WinForm.showStatus("Batch " + (cmbBtch.SelectedItem as ComboItem).name + " has lecture from " + obj.FromTime.ToShortTimeString() + " to " + obj.ToTime.ToShortTimeString(), MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// This Method will be called when batch or date is change
        /// </summary>
        private void BatchLecture()
        {

            lstlect = null;
            lstlect = BLL.LectureHandler.getLectures(dtpLect.Value, (cmbBtch.SelectedItem as ComboItem).key);
            ADGVLectures.DataSource = null;
            if (lstlect.Count != 0)
            {
                ADGVLectures.DataSource = WinForm.ToDataTable(lstlect);
            }
            else
            {
                ADGVLectures.DataSource = null;
            }
        }
        private void FacultyLecture()
        {
            lstFacLec = null;
            lstFacLec = BLL.LectureHandler.GetFacultyLec((cmbFaculty.SelectedItem as ComboItem).key, dtpLect.Value, branchID);
            ADGVLectures.DataSource = null;
            if (lstFacLec.Count != 0)
            {
                ADGVLectures.DataSource = WinForm.ToDataTable(lstFacLec);
            }
            else
            {
                ADGVLectures.DataSource = null; ;
            }
        }

        private void cmbSubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                populateFaculty();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVLectures_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                formatLectureGrid();
                foreach (DataGridViewRow adrow in ADGVLectures.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVLectures.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        public void formatLectureGrid()
        {
            try
            {
                if (ADGVLectures.Rows.Count > 0)
                {
                    //Setting Visibility and formatting cellstyle
                    ADGVLectures.Columns["LectureID"].Visible = false;
                    ADGVLectures.Columns[1].Visible = false;
                    ADGVLectures.Columns[2].Visible = true;
                    ADGVLectures.Columns[3].Visible = true;
                    ADGVLectures.Columns[4].Visible = false;
                    ADGVLectures.Columns[5].Visible = false;
                    ADGVLectures.Columns[7].DisplayIndex = 1;
                    ADGVLectures.Columns[2].DisplayIndex = 2;
                    ADGVLectures.Columns[3].DisplayIndex = 3;
                    ADGVLectures.Columns[8].DisplayIndex = 4;
                    ADGVLectures.Columns[9].DisplayIndex = 5;
                    ADGVLectures.Columns[10].DisplayIndex = 6;

                    for (int i = 1; i < ADGVLectureDetails.Columns.Count; i++)
                    {
                        ADGVLectures.Columns[i].ReadOnly = true;
                    }




                    foreach (DataGridViewRow row in ADGVLectures.Rows)
                    {
                        if ((Convert.ToInt32(row.Cells[5].Value) != 0))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                    }

                    ADGVLectures.Columns["FromTime"].DefaultCellStyle.Format = Common.Formatter.TimeFormat;
                    ADGVLectures.Columns["ToTime"].DefaultCellStyle.Format = Common.Formatter.TimeFormat;
                    ADGVLectures.Columns["Date"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                    if (allow)
                    {
                        ADGVLectures.Columns[4].Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        private void ADGVLectures_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ADGVLectures.Columns["btnDelete"].Index)
                    {

                        if (formPrevileges.Delete == false)
                        {
                            UICommon.WinForm.showStatus("You don't have permission to Delete the Test, Please contact admin", sCaption, this);
                            return;
                        }

                        int lectureId;
                        foreach (DataGridViewRow lecture in ADGVLectures.Rows)
                        {
                            if (lecture.Cells[0].Selected != false && lecture.Cells[0].Selected)// && lecture.Cells["LectureID"].Value=="0")
                            {
                                if (lstlect.Count != 0 && Convert.ToInt32(lecture.Cells[5].Value) == 0)
                                {


                                    lstlect.RemoveAt(e.RowIndex);
                                    ADGVLectures.Refresh();
                                    ADGVLectures.DataSource = UICommon.WinForm.ToDataTable(lstlect);

                                }
                                else
                                {
                                    lectureId = (Convert.ToInt32(lecture.Cells["LectureID"].Value));

                                    var a = MessageBox.Show("Are you sure to delete this item?", sCaption, MessageBoxButtons.YesNo);
                                    if (a == DialogResult.Yes)
                                    {
                                        bool retrnCode = BLL.LectureHandler.deleteLecture(lectureId, Program.LoggedInUser.BranchId);
                                        if (retrnCode)
                                        {
                                            UICommon.WinForm.showStatus("Lecture deleted successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                                        }
                                        else
                                        {
                                            UICommon.WinForm.showStatus("Already deleted ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                        }
                                        List<Lecture> lstlecture = BLL.LectureHandler.getLectures(dtpLect.Value, (cmbBtch.SelectedItem as ComboItem).key);
                                        ADGVLectures.DataSource = lstlecture;
                                    }
                                    else
                                    {

                                        ADGVLectures.Refresh();
                                    }
                                }
                            }

                        }
                        //if (lecture.Cells[0].Selected != null && lecture.Cells[0].Selected)
                        //{
                        //    lecture.Cells.Remove(lecture.Cells[0]);
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        private void showLectures()
        {
            try
            {

                Info.Lecture objLect = new Lecture();
                //DateTime fromDate, toDate;
                objLect.Stream.ID = (cmbStream.SelectedItem as ComboItem).key;
                objLect.Standard.Standardid = (cmbCourseType.SelectedItem as ComboItem).key;
                objLect.Batch.id = (cmbBatch.SelectedItem as ComboItem).key;
                //fromDate = dtpFrom.Value;
                //toDate = dtpTo.Value;
                lstLoadedLectures = BLL.LectureHandler.getLecturesDetails(objLect, dtpFrom.Value, dtpTo.Value, branchID);

                if (lstLoadedLectures.Count > 0)
                {

                    ADGVLectureDetails.DataSource = WinForm.ToDataTable(lstLoadedLectures);
                    formatADGVLectureDetails();
                }
                else
                {
                    UICommon.WinForm.showStatus("No lectures available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    ADGVLectureDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }





        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        allow = false;
        //        showLectures();

        //        string stdID;
        //        string batchID;

        //        stdID = (cmbCourseType.SelectedItem as ComboItem).strKey;
        //        batchID = (cmbBatch.SelectedItem as ComboItem).strKey;


        //        BLL.NotificationHandler.sendLectureSMSToStudent(lstLoadedLectures,Program.LoggedInUser.Branch.BranchId);
        //        BLL.NotificationHandler.sendLectureSMSToFaculty(lstLoadedLectures, WinApp.Program.LoggedInUser.BranchId);
        //    }
        //    catch (Exception ex)
        //    {

        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private void btnShowLect_Click(object sender, EventArgs e)
        {
            showLectures();
        }


        void formatADGVLectureDetails()
        {
            try
            {
                //Hiding columns
                ADGVLectureDetails.Columns["LectureID"].Visible = false;
                ADGVLectureDetails.Columns["BranchID"].Visible = false;
                ADGVLectureDetails.Columns["Stream"].Visible = false;
                ADGVLectureDetails.Columns["Standard"].Visible = true;
                ADGVLectureDetails.Columns["Batch"].Visible = true;
               // ADGVLectureDetails.Columns["TMTL_ID"].Visible = true;
                //ADGVLectureDetails.Columns["TMTL_FACULTY_ID"].Visible = true;
                //Formatting Date and Time 
                ADGVLectureDetails.Columns["ToTime"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                ADGVLectureDetails.Columns["FromTime"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                ADGVLectureDetails.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVLectureDetails.Columns["ExpectedPortion"].ReadOnly = true;
                //Ordering Column Position
                ADGVLectureDetails.Columns["Date"].DisplayIndex = 0;
                ADGVLectureDetails.Columns["Standard"].DisplayIndex = 1;
                ADGVLectureDetails.Columns["Batch"].DisplayIndex = 2;
                ADGVLectureDetails.Columns["Subject"].DisplayIndex = 3;
                ADGVLectureDetails.Columns["FromTime"].DisplayIndex = 4;
                ADGVLectureDetails.Columns["ToTime"].DisplayIndex = 5;
                ADGVLectureDetails.Columns["Faculty"].DisplayIndex = 6;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void cmbStrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChanges)
                {
                    populateCourseOfCreate();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChanges)
                {
                    populateBatchOfCreateLec();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        private void cmbBtch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (allowIndexChanges)
                //{
                populateSubject();
                //}

                if (cmbBatch.SelectedIndex != -1)
                {
                    Batch objBatch = cmbBatch.SelectedItem as Batch;
                    if (objBatch != null)
                    {
                        if (objBatch.FromTime != null)
                        {
                            fromTime.Value = objBatch.FromTime.Value;
                        }
                        else
                        {
                            fromTime.Value = DateTime.Now;
                        }
                        if (objBatch.ToTime != null)
                        {
                            toTime.Value = objBatch.ToTime.Value;
                        }
                        else
                        {
                            toTime.Value = DateTime.Now;
                        }
                    }
                    //if index position of batch is changed, then according to the selected batch, data will be displayed
                    lstlect = null;
                    lstlect = BLL.LectureHandler.getLectures(dtpLect.Value, (cmbBtch.SelectedItem as ComboItem).key);
                    ADGVLectures.DataSource = null;
                    if (lstlect.Count != 0)
                    {
                        ADGVLectures.DataSource = WinForm.ToDataTable(lstlect);
                    }
                    else
                    {
                        //UICommon.WinForm.showStatus("")
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void tabLecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                allowIndexChanges = true;
                lblSubject.Visible = false;
                lblfaculty.Visible = false;
                cmbSubj.Visible = false;
                cmbFaculty.Visible = false;
                populateStreamOfCreate();
                fromTime.CustomFormat = "HH:mm :tt";
                toTime.CustomFormat = "HH:mm :tt";
                lstlect = null;
                if (cmbBtch.SelectedItem != null)
                {
                    lstlect = BLL.LectureHandler.getLectures(dtpLect.Value, (cmbBtch.SelectedItem as ComboItem).key);
                }
                ADGVLectures.DataSource = null;


                if (lstlect == null)
                {
                    UICommon.WinForm.showStatus("There is no Lecture", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    if (lstlect.Count != 0)
                    {
                        ADGVLectures.DataSource = WinForm.ToDataTable(lstlect);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }


        }

        private void populateStreamOfCreate()
        {
            try
            {
                cmbStrm.Items.Clear();
                //cmbStrm.Items.Add(new ComboItem("%", "All", null));

                List<Stream> lstStream = StreamHandller.getStreams(branchID);
                if (lstStream.Count != 0)
                {
                    foreach (Stream objStream in lstStream)
                    {
                        cmbStrm.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name, objStream));
                    }
                    cmbStrm.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No Streams available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void populateCourseOfCreate()
        {
            try
            {
                cmbCourse.Items.Clear();

                List<Standard> lstStd = StandardHandller.getStandard(branchID.ToString(), (cmbStrm.Items[cmbStrm.SelectedIndex] as ComboItem).strKey);
                if (lstStd.Count != 0)
                {
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbCourse.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName, objStandard));
                    }
                    cmbCourse.SelectedIndex = 0;
                    //cmbCourse_SelectedIndexChanged(cmbCourseType, new EventArgs());
                }
                else
                {
                    UICommon.WinForm.showStatus("No Courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void populateBatchOfCreateLec()
        {
            try
            {
                if (allowIndexChanges)
                {
                    allowIndexChanges = false;
                    cmbBtch.Items.Clear();
                    //cmbBtch.Items.Add(new ComboItem("%", "All", null));
                    //if (((cmbCourse.SelectedItem as ComboItem).name) == "All")
                    //{
                    //    cmbBtch.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    List<Batch> lstBatch = StandardHandller.GetBatches((cmbCourse.Items[cmbCourse.SelectedIndex] as ComboItem).key, Program.LoggedInUser.BranchId);

                    if (lstBatch.Count != 0)
                    {
                        foreach (Batch objBatch in lstBatch)
                        {
                            cmbBtch.Items.Add(new ComboItem(objBatch.id.ToString(), objBatch.Name, objBatch));
                        }
                        Batch obj = new Batch();
                        obj = lstBatch[0];
                        fromTime.Value = (obj.FromTime == null) ? DateTime.Now : obj.FromTime.Value;
                        toTime.Value = (obj.ToTime == null) ? DateTime.Now : obj.ToTime.Value;
                        cmbBtch.SelectedIndex = 0;
                        //cmbBatch_SelectedIndexChanged(cmbBatch, new EventArgs());
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No Batches available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                    //}
                    allowIndexChanges = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ADGVLectures_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVLectureDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpLect_CloseUp(object sender, EventArgs e)
        {
            try
            {
                BatchLecture();
                //FacultyLecture();
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVLectureDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVLectureDetails, e);
        }

        private void fromTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ADGVLectures_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVLectures, e);
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                allow = false;
                showLectures();

                string stdID;
                string batchID;

                stdID = (cmbCourseType.SelectedItem as ComboItem).strKey;
                batchID = (cmbBatch.SelectedItem as ComboItem).strKey;


              bool sentStud =  BLL.NotificationHandler.sendLectureSMSToStudent(lstLoadedLectures, Program.LoggedInUser.Branch.BranchId);
               bool sentFac =  BLL.NotificationHandler.sendLectureSMSToFaculty(lstLoadedLectures, WinApp.Program.LoggedInUser.BranchId);


                if(sentFac == true && sentStud == true)
                {
                    UICommon.WinForm.showStatus("Message Sent Successfully !!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Message Not Sent !", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                allow = true;
                if (ValidateControls())
                {
                    if (ValidateFaculty())
                    {
                        Lecture objLecture = new Lecture();
                        DateTime lectDate, from, to;
                        lectDate = Convert.ToDateTime(dtpLect.Value);
                        //from = Convert.ToDateTime(lectDate.ToShortDateString() + " " + fromTime.Value.ToShortTimeString());
                        //to = Convert.ToDateTime(lectDate.ToShortDateString() + " " + toTime.Value.ToShortTimeString());
                        from = Convert.ToDateTime(fromTime.Value.ToShortTimeString());
                        to = Convert.ToDateTime(toTime.Value.ToShortTimeString());
                        objLecture.Stream.Name = (cmbStrm.SelectedItem as ComboItem).name; //used to show in Gridview
                        objLecture.Standard.StandardName = (cmbCourse.SelectedItem as ComboItem).name;//used to show in Gridview
                        objLecture.Batch.Name = (cmbBtch.SelectedItem as ComboItem).name;//used to show in Gridview
                        objLecture.Date = lectDate;
                        objLecture.FromTime = from;
                        objLecture.ToTime = to;
                        objLecture.Subject.SubjName = (cmbSubj.SelectedItem as ComboItem).name;
                        objLecture.Faculty = new Faculty();
                        objLecture.Faculty.Name = (cmbFaculty.SelectedItem == null) ? "NA" : (cmbFaculty.SelectedItem as ComboItem).name;
                        objLecture.Batch.location = ((cmbBtch.SelectedItem as ComboItem).objectValue as Batch).location;
                        objLecture.ExpectedPortion = txtAddress.Text;
                        objLecture.Stream.ID = (cmbStrm.SelectedItem as ComboItem).key;
                        objLecture.Standard.Standardid = (cmbCourse.SelectedItem as ComboItem).key;
                        objLecture.Batch.id = (cmbBtch.SelectedItem as ComboItem).key;
                        objLecture.Faculty.FacultyID = (cmbFaculty.SelectedItem == null) ? -1 : Convert.ToInt32((cmbFaculty.SelectedItem as ComboItem).strKey);
                        
                        objLecture.Faculty.FacultyID = objLecture.Faculty.FacultyID;
                        objLecture.Subject.SubjId = Convert.ToInt32((cmbSubj.SelectedItem as ComboItem).key);
                        objLecture.BranchID = Convert.ToInt32(branchID);
                        lstlect.Add(objLecture);
                        
                    }
                }
                if (lstlect.Count != 0)
                {
                    // ADGVLectures.DataSource = null;
                    //DGVLectures.DataSource = lstFacLec;
                    ADGVLectures.DataSource = null;
                    ADGVLectures.DataSource = WinForm.ToDataTable(lstlect);
                    ADGVLectures.Columns["ActualDone"].Visible = false;
                  
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                allow = false;
                //List<Lecture> lstlect= BLL.LectureHandler.getLectures(dtpLect.Value);
                ADGVLectures.DataSource = null;
                if (lstlect.Count > 0)
                {
                    ADGVLectures.DataSource = WinForm.ToDataTable(lstlect);
                    ADGVLectures.Columns["ActualDone"].Visible = false;
                }
                else
                {
                    UICommon.WinForm.showStatus("No lectures available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
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

                if (ADGVLectures.Rows.Count == 0)
                {
                    UICommon.WinForm.showStatus("There Is No Data To Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    Info.Lecture objLect = new Info.Lecture();
                    int retrnCode = 0;
                    DataTable dt = new DataTable();
                    dt = ADGVLectures.DataSource as DataTable;


                    if (lstlect.Count > 0)
                    {
                        foreach (Lecture objLecture in lstlect)
                        {
                            if (objLecture.LectureID == 0)
                            {
                                retrnCode = BLL.LectureHandler.saveLectures(objLecture);
                            }
                        }
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            DateTime lectDate, fromdate, toDate, from, to;
                            int lectID = Convert.ToInt32(dr["LectureID"]);
                            lectDate = Convert.ToDateTime(dr["Date"]);
                            from = Convert.ToDateTime(dr["FromTime"].ToString());
                            to = Convert.ToDateTime(dr["ToTime"].ToString());
                            fromdate = Convert.ToDateTime(lectDate.ToShortDateString() + " " + from.ToShortTimeString());
                            toDate = Convert.ToDateTime(lectDate.ToShortDateString() + " " + to.ToShortTimeString());

                            if (lectID != 0)
                            {
                                objLect.LectureID = lectID;
                            }

                            objLect.Stream.ID = Convert.ToInt32(dr["StreamId"]);
                            objLect.Standard.Standardid = Convert.ToInt32(dr["StandardID"]);
                            objLect.Batch.id = Convert.ToInt32(dr["BatchID"]);
                            objLect.Date = Convert.ToDateTime(lectDate.ToShortDateString());
                            objLect.Faculty.FacultyID = Convert.ToInt32(dr["FacId"]);
                            objLect.FromTime = fromdate;
                            objLect.ToTime = toDate;
                            objLect.Subject.SubjId = Convert.ToInt32(dr["SubjId"]);
                            objLect.Subject.SubjName = dr["SubjName"].ToString();
                            objLect.BranchID = Convert.ToInt32(branchID);
                            retrnCode = BLL.LectureHandler.saveLectures(objLect);
                        }
                    }


                    if (retrnCode == 1 || retrnCode == 2)
                    {
                        UICommon.WinForm.showStatus("Lectures saved successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                    else
                    {
                        UICommon.WinForm.showStatus("Can't save lecture", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    lstlect = new List<Lecture>();
                    ADGVLectures.DataSource = null;
                    lstlect = BLL.LectureHandler.getLectures(dtpLect.Value, (cmbBtch.SelectedItem as ComboItem).key);
                    ADGVLectures.DataSource = WinForm.ToDataTable(lstlect);
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        //Repeat Lectures-Mohan(23-05-2017).
        private int repeatLectures(FormClosingEventArgs close)
        {
            try
            {
                //To return a value based on the execution of a function.(Pass or Fail).
                int retrnCode = 0;
                if (ADGVLectureDetails.Rows.Count > 0)
                {

                    FrmLectureRepeat repeat = new FrmLectureRepeat();

                    var result = repeat.ShowDialog();

                    string repMode = repeat.whichchecked();
                    DateTime dateTillToRepaeat = repeat.tillToRepeat();

                    if (result == DialogResult.OK)
                    {
                        foreach (Lecture objRepeat in lstLoadedLectures)
                        {

                            objRepeat.BranchID = Convert.ToInt32(branchID);

                            //Lecture Repeat on Daily basis.
                            if (repMode == "Daily")
                            {
                                DateTime nextDay = Convert.ToDateTime(objRepeat.Date).AddDays(1);
                                while (nextDay < dateTillToRepaeat)
                                {

                                    try
                                    {
                                        //Code to Save Lecture that to be Repeat.
                                        objRepeat.Date = nextDay;
                                        retrnCode = BLL.LectureHandler.saveLectures(objRepeat);
                                        nextDay = Convert.ToDateTime(nextDay).AddDays(1);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }

                                }
                            }

                            //On Weekly basis.
                            else if (repMode == "Weekly")
                            {
                                DateTime nextDayofWeek = Convert.ToDateTime(objRepeat.Date).AddDays(7);
                                while (nextDayofWeek < dateTillToRepaeat)
                                {
                                    if (Convert.ToDateTime(objRepeat.Date).DayOfWeek == nextDayofWeek.DayOfWeek)
                                    {
                                        try
                                        {
                                            //Code to Save Lecture that to be Repeat.
                                            objRepeat.Date = nextDayofWeek;
                                            retrnCode = BLL.LectureHandler.saveLectures(objRepeat);
                                            nextDayofWeek = Convert.ToDateTime(nextDayofWeek).AddDays(7);
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                }
                            }

                            //On Monthly basis.
                            else if (repMode == "Monthly")
                            {
                                DateTime nextDayofMonth = Convert.ToDateTime(objRepeat.Date).AddMonths(1);
                                while (nextDayofMonth < dateTillToRepaeat)
                                {
                                    if (Convert.ToDateTime(objRepeat.Date).Day == nextDayofMonth.Day)
                                    {
                                        try
                                        {
                                            //Code to Save Lecture that to be Repeat.
                                            objRepeat.Date = nextDayofMonth;
                                            retrnCode = BLL.LectureHandler.saveLectures(objRepeat);
                                            nextDayofMonth = Convert.ToDateTime(nextDayofMonth).AddDays(7);
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }

                                }
                            }
                        }
                    }
                    return retrnCode;
                }

                else
                {
                    WinForm.showStatus("No Lectures To Repeat.", sCaption, this);
                    return retrnCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            try
            {
                int retValue = repeatLectures(null);
                if (retValue == 1)
                {
                    WinForm.showStatus("Done.", sCaption, this);
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVLectureDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVLectureDetails.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVLectureDetails.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bgwLectureSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
                }
                else
                {
                    UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    PrintingConfig objPrintngConfig = new PrintingConfig();
                    objPrintngConfig.ViewReport = true;
                    objPrintngConfig.SaveReport = true;
                    objPrintngConfig.exportFormat = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;

                    CommonReportData CommonRprtData = new CommonReportData();
                    CommonRprtData.FromDate = dtpFrom.Value;
                    CommonRprtData.ToDate = dtpTo.Value;
                    CommonRprtData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                    CommonRprtData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                    CommonRprtData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                    CommonRprtData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                    CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    CommonRprtData.Std = (cmbCourseType.SelectedItem as ComboItem).strKey;
                    CommonRprtData.Batch = (cmbBatch.SelectedItem as ComboItem).strKey;
                    

                    CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "LECTURE");

                    FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
                    frmRprtViewer.viewReport(CommonRprtData.ReportName, CommonRprtData, objPrintngConfig);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool validate()
        {
            try
            {

                if (dtpFrom.Value.Date > dtpTo.Value.Date)
                {
                    UICommon.WinForm.showStatus("Please select date properly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void lblfaculty_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Info.Lecture objLect = new Info.Lecture();
            Lecture objLecture = new Lecture();
            
            //  objLect.Stream.ID 
            // objLecture.ActualDone = objLecture.ActualDone.ToString();
            DataTable dt = new DataTable();
            dt = ADGVLectureDetails.DataSource as DataTable;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int lectID = Convert.ToInt32(dr["LectureID"]);
                    if (lectID != 0)
                    {
                        objLect.LectureID = lectID;

                    }

                  //  objLect.Stream.ID = Convert.ToInt32(dr["StreamId"]);
                 //   objLect.Standard.Standardid = Convert.ToInt32(dr["StandardID"]);
                  //  objLect.Batch.id = Convert.ToInt32(dr["BatchID"]);
                 
                  //  objLect.Faculty.FacultyID = Convert.ToInt32(dr["FacId"]);
                    objLect.ActualDone = dr["Actualdone"].ToString();
                    objLect.ExpectedPortion = dr["ExpectedPortion"].ToString();
                    
                     BLL.LectureHandler.updateLectures(objLect);
                }
            }






        }
    }
}

