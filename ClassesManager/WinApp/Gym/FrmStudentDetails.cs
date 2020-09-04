

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
using System.Configuration;
using System.Text.RegularExpressions;
using ClassManager.Info.Reporting;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using System.Collections;
using ClassManager.WinApp.Reports;
using ClassManager.WinApp.UICommon;
using ClassManager.Info;
using ClassManager.WinApp.Popups;

namespace ClassManager.WinApp.Gym
{
    public partial class FrmStudentDetails : StudentDetailsParent
    {

        RolePrivilege formPrevileges;

        bool picture = false;
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Student Details";
        List<InstallmentDetail> lstInstallmentDetails { get; set; }
        StudentMaster ObjStudentMaster;
        bool bAllowIndexChange = false;
        static List<Info.InstallmentDetail> lstStudentInstallment;
        List<ComboItem> lstStudentDetails = new List<ComboItem>();
        List<Info.StudentFacility> selctedSubjects;
        bool allow;
        DataTable dtExam;
        Boolean boolProcess = false;
        Boolean boolChange = false;
        Boolean allowIndexChnge;
        DateTime OldDate;
        DateTimePicker DateTimePicker = new DateTimePicker();
        /// <summary>
        /// Student object loaded when user search for a student
        /// </summary>
        public static Info.Student objStudent;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmStudentDetails()
        {
            InitializeComponent();
        }

        #region Events

        private void StudentDetails_Load(object sender, EventArgs e)
        {

            try
                {


                lnkViewStudents.Visible = false;
                lstStudentDetails.Add(new ComboItem(-1, "Select Member"));

                lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(branchId));

                StudName.DataSource = new List<Student>();
                StudName.DisplayMember = "name";
                StudName.DataSource = lstStudentDetails;

                // then you have to set the PropertySelector like this:
                StudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);

                if (this.IsMdiChild != true)
                {
                    //string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    //if (name == "Gym" || name == "Dance")
                    //{
                    //    tabMain.TabPages.Remove(tabPage10);
                    //}
                    ApplyPrevileges();
                    StudName.Text = objStudent.DisplayName;
                }
                else
                {
                    materialTabSelector1.BaseTabControl = tabMain;

                    //Last Tab Column(FollowUp).
                    DataGridViewCheckBoxColumn isFollowpClosed = new DataGridViewCheckBoxColumn();
                    isFollowpClosed.Name = "chkbxisClosed";
                    isFollowpClosed.HeaderText = "Close";
                    ADGVFollowup.Columns.Insert(0, isFollowpClosed);
                    //ADGVFollowup.Columns[0].ReadOnly = false;
                    UICommon.WinForm.setDate(dtpfrm, dtptod);
                    UICommon.WinForm.setDate(dtpfrom, dtpto);

                    ofdImage.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";
                    dtpDOB.MaxDate = DateTime.Now.AddYears(-2);

                    //List<ComboItem> lstStudentDetails = new List<ComboItem>();
                    List<ComboItem> lstBatch = new List<ComboItem>();

                    assignValidationEvents();
                    AssignEvents();
                    clearForm();
                    btnAddFacilities.Enabled = false;
                    cmdBrwseImg.Enabled = false;
                    linkLabel1.Enabled = false;
                    lnkClear.Enabled = false;
                    bAllowIndexChange = true;
                    lnlTotalFees.Visible = true;
                    lnklblviewHistory.Visible = true;
                    tabMain.Visible = false;
                    formatForm();
                    allow = true;
                    //  addColumns();
                    formatdate();
                    ApplyPrevileges();

                    //////string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    //////if (name == "Gym" || name == "Dance")
                    //////{
                    //////    tabMain.TabPages.Remove(tabPage10);

                    //////   // tabMain.Visible = false;

                    //////}
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }

        }
        private void addColumns()
        {
            try
            {////ADDED BY ASHVINI 4-1-2019
             //FOR avoidind repeations of these columns04-02-2019
                if (ADGVStudentFacility.Columns.Contains("btnPayFees"))
                {


                }
                else
                {
                    ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()
                    {
                        Image = Properties.Resources.pay,
                        Name = "btnPayFees",
                        HeaderText = "Pay Fees"
                    });
                }
                if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                {


                }
                else
                {

                    ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()
                    {
                        Image = Properties.Resources.deleteBin,
                        Name = "btnDelete",
                        HeaderText = "Cancel"
                    });
                }

                if (ADGVStudentFacility.Columns.Contains("btnRenew"))
                {


                }
                else
                {

                    ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()

                    {
                        Image = Properties.Resources.calendar,
                        Name = "btnRenew",
                        HeaderText = "Renew"
                    });
                }

                if (ADGVStudentFacility.Columns.Contains("btnUpgrade"))
                {


                }
                else
                {

                    ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()
                    {
                        Image = Properties.Resources.upgrade,
                        Name = "btnUpgrade",
                        HeaderText = "Upgrade"
                    });
                }
            }
            //end by ashvini04-02
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

                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                        ADGVStudentFacility.Columns["btnEdit"].Visible = false;
                        ADGVStudentFacility.Columns["btnUpgrade"].Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnAddFacilities.Visible = false;
                        btnPayFees.Visible = false;
                        btnNewFollowUp.Visible = false;
                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                    if (formPrevileges.View == false)
                    {
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                        ADGVStudentFacility.Columns["btnEdit"].Visible = false;
                        ADGVStudentFacility.Columns["btnUpgrade"].Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtAdmissionNo.Text != "")
                {
                    Int32 admissionNo = 0;
                    if (Int32.TryParse(txtAdmissionNo.Text, out admissionNo))
                    {
                        objStudent = StudentHandller.GetStudent(admissionNo, null, null, null, Program.LoggedInUser.BranchId);
                    }

                    if(objStudent == null)
                    {
                        objStudent = StudentHandller.GetStudent(null, null, null, null, Program.LoggedInUser.BranchId, admissionNo);
                    }
                }
                else if(txtContctNo.Text != "")
                {
                    objStudent = StudentHandller.GetStudent(null, txtContctNo.Text, null, null, Program.LoggedInUser.BranchId,  null);
                }
                
                populateData();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private void cmdBrwseImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pbPhoto.Image = new Bitmap(new Bitmap(ofdImage.FileName), new Size(100, 100));
                    picture = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                pbPhoto.Image = Properties.Resources.img;
                picture = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                loadAttendance(dtpAttdFromDate.Value, dtpAttdToDate.Value);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                clearForm();
                tabMain.Visible = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatePersonalInfo())
                {
                    ObjStudentMaster = new StudentMaster();
                    ObjStudentMaster.AdmissionNo = objStudent.AdmissionNo;
                    ObjStudentMaster.Fname = txtFName.Text;
                    ObjStudentMaster.Mname = txtMName.Text;
                    ObjStudentMaster.Lname = txtLName.Text;
                    ObjStudentMaster.BiometricId = Convert.ToInt32(txtBiometric.Text);
                    DateTime dateDiff = DateTime.Now.AddYears(-2);
                    if (dateDiff.ToShortDateString().Equals(dtpDOB.Value.ToShortDateString()))
                    {
                        ObjStudentMaster.Dob = DateTime.MinValue;
                    }
                    else
                    {
                        ObjStudentMaster.Dob = dtpDOB.Value;
                    }
                    ObjStudentMaster.Address = txtAddress.Text;
                    ObjStudentMaster.ContactNo = txtNewContact.Text;
                    ObjStudentMaster.EmailID = txtEmailID.Text;
                    ObjStudentMaster.Remark = txtRemark.Text;
                    ObjStudentMaster.FatherName = "";
                    ObjStudentMaster.FatherContactNo = "";
                    ObjStudentMaster.BloodGroup = txtBloodgrp.Text;
                    ObjStudentMaster.BMI = txtBMI.Text;
                    ObjStudentMaster.HeathIssue = txtHeathIssue.Text; //added by ashvini on 30 - 03 - 2019
                    ObjStudentMaster.Weight = txtWght.Text;
                    ObjStudentMaster.Height = txtheight.Text;
                    ObjStudentMaster.Gender = ((rbMale.Checked) ? "M" : "F");
                    ObjStudentMaster.MembershipNo = txtMbrsNo.Text;
                    ObjStudentMaster.BiometricId = Convert.ToInt32(txtBiometric.Text);
                    ObjStudentMaster.ImgPhoto = pbPhoto.Image;

                    ObjStudentMaster.Source = cmbSource.Text;//added by ashvini on 30-03-2019

                    ObjStudentMaster.AdharCard = "";

                    ObjStudentMaster.Category = "";
                    ObjStudentMaster.counselor = "";


                    ObjStudentMaster.AdmissionStandard = (Standard)ObjStudentMaster.AdmissionStandard;
                    if (cmbBatch.SelectedItem != null)
                    {
                        ObjStudentMaster.batchID = ((cmbBatch.SelectedItem as ComboItem).key);
                    }
                    else
                    {
                        ObjStudentMaster.batchID = 0;
                    }
                    StudentHandller.updateStudPersnlDtl(ObjStudentMaster);
                    UICommon.WinForm.showStatus("Details Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, "Student Details", this);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("A generic error occurred in GDI+."))
                {
                    UICommon.WinForm.showStatus("Set proper path to save the Image." + System.Environment.NewLine + objStudent.DisplayName + "'s " + "Detail not Updated.", sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, sCaption, this);
                }
            }
        }

        private void cmbStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if (bAllowIndexChange && StudName.SelectedIndex > 0 && StudName.SelectedItem != null)
                {
                    loadStudent((StudName.SelectedItem as ComboItem).key);

                    tabMain.SelectedIndex = 3;
                    //Doubtfull
                    {

                        showExamDetails();
                        cmbTests.DisplayMember = "TestName";
                        cmbTests.ValueMember = "TestId";
                        populateOnlyTest();
                    }
                    //Doubtfull
                }
                panelReceipt.Height = 316;
                panelReceipt.Width = 841;
                ADGVReceipt.Height = 316;
                ADGVReceipt.Width = 841;
                panelInvoiceGenerate.Visible = false;
                ADGVInvoice.Visible = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (objStudent == null)
                {
                    UICommon.WinForm.showStatus("No member found.\n\n Please enter valid Contact no or Memberid", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtContctNo.Text = "";
                    txtContctNo.Focus();
                }
                else
                {
                    if (tabMain.SelectedIndex == 2)
                    {
                        //sets the start and end date of the month.
                        UICommon.WinForm.setDate(dtpAttdFromDate, dtpAttdToDate);

                        loadAttendance(dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    }
                    else if (tabMain.SelectedIndex == 3)
                    {
                        showExamDetails();
                        cmbTests.DisplayMember = "TestName";
                        cmbTests.ValueMember = "TestId";
                        populateOnlyTest();
                    }
                    else if (tabMain.SelectedIndex == 4)
                    {
                        //sets the start and end date of the month
                        UICommon.WinForm.setDate(dtpReceiptFrmDate, dtpReceiptToDate);

                        //Gets the payment details against a admission no.
                        ADGVReceipt.DataSource = BLL.FeesHandller.getPayments(objStudent.AdmissionNo);
                        formatReceiptGrid();
                        if (SysParam.getValue<bool>(SysParam.Parameters.GENERATE_INVOICE) == true)
                        {
                            btnInvoice.Visible = true;

                        }
                    }
                    else if (tabMain.SelectedIndex == 5)
                    {
                        loadFolloup(objStudent.AdmissionNo, branchId);
                    }
                    //added by ashvini09-01-2019
                    //for displaying activity_log table data
                    else if (tabMain.SelectedIndex == 6)
                    {

                        ActivityGrid.DataSource = BLL.StudentHandller.GetActivities(objStudent.AdmissionNo, branchId);

                        FormatActivityGrid();
                    }
                    //added by ashvini 21-01-2019
                    //for displaying measuemnets on grid
                    else if (tabMain.SelectedIndex == 7)
                    {
                        MeasurementGrid.DataSource = BLL.StudentHandller.getmeasurementsOfStudent(dtpfrm.Value, dtptod.Value, objStudent.AdmissionNo, branchId);

                        FormatmeasureGrid();
                    }
                    //end by ashvini21-01-2019

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        //added by ashvini forr fromatting measurementgrid
        private void FormatmeasureGrid()
        {
            try
            {
                MeasurementGrid.ReadOnly = true;
                if (MeasurementGrid.Columns.Contains("MM_MID"))
                {
                    MeasurementGrid.Columns["MM_MID"].Visible = false;
                }
                if (MeasurementGrid.Columns.Contains("MM_ID"))
                {
                    MeasurementGrid.Columns["MM_ID"].Visible = false;
                }
                if (MeasurementGrid.Columns.Contains("MM_ADMISSIONNO"))
                {
                    MeasurementGrid.Columns["MM_ADMISSIONNO"].Visible = false;
                }
                if (MeasurementGrid.Columns.Contains("MM_BRANCHID"))
                {
                    MeasurementGrid.Columns["MM_BRANCHID"].Visible = false;

                }
                if (MeasurementGrid.Columns.Contains("MM_DATE"))
                {
                    MeasurementGrid.Columns["MM_DATE"].DisplayIndex = 0;
                    MeasurementGrid.Columns["MM_DATE"].Width = 85;
                    MeasurementGrid.Columns["MM_DATE"].HeaderText = "Date";

                }
                if (MeasurementGrid.Columns.Contains("MM_WEIGHT"))
                {

                    MeasurementGrid.Columns["MM_WEIGHT"].Width = 60;
                    MeasurementGrid.Columns["MM_WEIGHT"].HeaderText = "Weight";
                }
                if (MeasurementGrid.Columns.Contains("MM_HEIGHT"))
                {

                    MeasurementGrid.Columns["MM_HEIGHT"].Width = 60;
                    MeasurementGrid.Columns["MM_HEIGHT"].HeaderText = "Height";
                }
                if (MeasurementGrid.Columns.Contains("MM_BMI"))
                {

                    MeasurementGrid.Columns["MM_BMI"].Width = 55;
                    MeasurementGrid.Columns["MM_BMI"].HeaderText = "Bmi";
                }
                if (MeasurementGrid.Columns.Contains("MM_FAT"))
                {

                    MeasurementGrid.Columns["MM_FAT"].Width = 55;
                    MeasurementGrid.Columns["MM_FAT"].HeaderText = "Fat";
                }
                if (MeasurementGrid.Columns.Contains("MM_NECK"))
                {

                    MeasurementGrid.Columns["MM_NECK"].Width = 58;
                    MeasurementGrid.Columns["MM_NECK"].HeaderText = "Neck";
                }
                if (MeasurementGrid.Columns.Contains("MM_SHOULDER"))
                {

                    MeasurementGrid.Columns["MM_SHOULDER"].Width = 60;
                    MeasurementGrid.Columns["MM_SHOULDER"].HeaderText = "Shoulder";
                }
                if (MeasurementGrid.Columns.Contains("MM_CHEST"))
                {

                    MeasurementGrid.Columns["MM_CHEST"].Width = 60;
                    MeasurementGrid.Columns["MM_CHEST"].HeaderText = "Chest";
                }

                if (MeasurementGrid.Columns.Contains("MM_ARMS"))
                {

                    MeasurementGrid.Columns["MM_ARMS"].Width = 60;
                    MeasurementGrid.Columns["MM_ARMS"].HeaderText = "Arms";
                }
                if (MeasurementGrid.Columns.Contains("MM_HIPS"))
                {

                    MeasurementGrid.Columns["MM_HIPS"].Width = 60;
                    MeasurementGrid.Columns["MM_HIPS"].HeaderText = "Hips";
                }
                if (MeasurementGrid.Columns.Contains("MM_THIGH"))
                {

                    MeasurementGrid.Columns["MM_THIGH"].Width = 60;
                    MeasurementGrid.Columns["MM_THIGH"].HeaderText = "Thigh";
                }
                if (MeasurementGrid.Columns.Contains("MM_CALVES"))
                {

                    MeasurementGrid.Columns["MM_CALVES"].Width = 60;
                    MeasurementGrid.Columns["MM_CALVES"].HeaderText = "Calves";
                }
                if (MeasurementGrid.Columns.Contains("MM_FOREARMS"))
                {

                    MeasurementGrid.Columns["MM_FOREARMS"].Width = 70;
                    MeasurementGrid.Columns["MM_FOREARMS"].HeaderText = "Forearms";
                }
                if (MeasurementGrid.Columns.Contains("MM_UPPER_ABD"))
                {

                    MeasurementGrid.Columns["MM_UPPER_ABD"].Width = 70;
                    MeasurementGrid.Columns["MM_UPPER_ABD"].HeaderText = "Upper Abd";
                }
                if (MeasurementGrid.Columns.Contains("MM_LOWER_ABD"))
                {

                    MeasurementGrid.Columns["MM_LOWER_ABD"].Width = 70;
                    MeasurementGrid.Columns["MM_LOWER_ABD"].HeaderText = "Lower Abd";
                }
                if (MeasurementGrid.Columns.Contains("MM_HEIGHT"))
                {

                    MeasurementGrid.Columns["MM_WAIST"].Width = 60;
                    MeasurementGrid.Columns["MM_WAIST"].HeaderText = "Waist";
                }
                MeasurementGrid.Columns["MM_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //end by ashvini 21-01-2019
        private void loadFolloup(int admissionNo, string branchId)
        {
            try
            {
                ADGVFollowup.DataSource = FollowupHandler.getFollowupAny(admissionNo, branchId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            //
            ADGVStudentFacility.CurrentCell.Value = DateTimePicker.Text.ToString();
        }


        void DateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            DateTimePicker.Visible = false;
        }
        private void ADGVStudentFacility_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {

                    //Declared to store renewd packageName.(26-Oct-2017).
                    string packageName = "";

                    string packagetype = "";
                    //(26-Oct-2017).

                    int studfacilityID;

                    ADGVStudentFacility.EndEdit();


                    if (e.ColumnIndex == ADGVStudentFacility.Columns["FromDate"].Index)
                    {
                        //Initialized a new DateTimePicker Control 
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        OldDate = (Convert.ToDateTime(selectedRow.Cells["FromDate"].Value));
                        DateTimePicker = new DateTimePicker();
                        ADGVStudentFacility.Controls.Add(DateTimePicker);
                        DateTimePicker.Format = DateTimePickerFormat.Short;
                        Rectangle oRectangle = ADGVStudentFacility.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        oRectangle.Height = oRectangle.Height + 500;
                        DateTimePicker.Font = new Font("Microsoft Sans Serif", 11);
                        DateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                        DateTimePicker.Location = new Point(oRectangle.X, 43);
                        DateTimePicker.CloseUp += new EventHandler(DateTimePicker_CloseUp);
                        DateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                        DateTimePicker.Visible = true;
                    }
                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["btnPayFees"].Index)
                    {
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        studfacilityID = (Convert.ToInt32(selectedRow.Cells["Id"].Value));

                        foreach (StudentFacility objFacility in objStudent.Facilities)
                        {
                            if (studfacilityID == objFacility.Id)
                            {
                                if (objFacility.Pending > 0)
                                {
                                    FrmFeesPayment frmFeesPaymentForm = (FrmFeesPayment)FormFactory.GetForm(Forms.FrmFeesPayment);
                                    frmFeesPaymentForm.LoadFeeDetailsFromRegistration(objStudent, objFacility);

                                }
                                else
                                {
                                    UICommon.WinForm.showStatus("Payment is already done.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }
                        }
                    }

                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["btnDelete"].Index)
                    {

                        foreach (DataGridViewRow facilty in ADGVStudentFacility.Rows)
                        {
                            if (facilty.Cells[1].Selected)
                            {
                                string status = facilty.Cells["Status"].Value.ToString();
                                if (status == "A")
                                {
                                    var result = UICommon.WinForm.showStatus("Do You Want Delete this Package?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                                    if (result == DialogResult.Yes)
                                    {
                                        studfacilityID = (Convert.ToInt32(facilty.Cells["Id"].Value));
                                        deleteFacilty(studfacilityID);
                                        loadStudent(objStudent.AdmissionNo);
                                    }
                                }
                                else
                                {
                                    DataTable dt = BLL.StudentHandller.getFacility(objStudent.AdmissionNo);

                                    if (status == "E")
                                    {
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            if (facilty.Index != -1)
                                            {
                                                if (dr.ItemArray[8].Equals((Convert.ToInt32(facilty.Cells["Id"].Value))))
                                                {
                                                    decimal Pending = Convert.ToDecimal(dr.ItemArray[11]);
                                                    // if (Pending == 0)
                                                    {
                                                        var result = UICommon.WinForm.showStatus("Do You Want Delete this Package?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                                                        if (result == DialogResult.Yes)
                                                        {
                                                            studfacilityID = (Convert.ToInt32(facilty.Cells["Id"].Value));
                                                            deleteFacilty(studfacilityID);
                                                            loadStudent(objStudent.AdmissionNo);
                                                        }
                                                    }
                                                    // else
                                                    // {
                                                    //   UICommon.WinForm.showStatus("As there is Outstanding Fees, Cannot Delete this Package", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                                    // }
                                                }
                                            }
                                        }

                                    }
                                    // UICommon.WinForm.showStatus("Already deactivated.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }
                        }
                    }
                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["btnUpgrade"].Index)
                    {
                        DataGridViewRow row = ADGVStudentFacility.Rows[e.RowIndex];
                        studfacilityID = Convert.ToInt32(row.Cells["Id"].Value);

                        if (row.Cells["Status"].Value.ToString() == "A")
                        {
                            foreach (StudentFacility objFacility in objStudent.Facilities)
                            {
                                if (studfacilityID == objFacility.Id)
                                {
                                    if (checkPackageType(objFacility))
                                    {

                                        objFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                                        objFacility.FacilityName = objFacility.Package.PackageName;

                                        objFacility.Student.RollNo = objStudent.RollNo;
                                        FrmMonthSelector frmMnthSelector = new FrmMonthSelector(objStudent, objFacility, true);

                                        frmMnthSelector.ShowDialog();
                                        packageName = objFacility.Package.PackageName;

                                        break;
                                    }
                                }
                                packagetype = objFacility.Package.PackageType.ToString();
                            }

                        }
                        else
                        {
                            UICommon.WinForm.showStatus("This Package Can't be Upgraded as it is deleted", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }

                    }

                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["AutoRenewEnabled"].Index)
                    {
                        ADGVStudentFacility.BeginEdit(true);
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        DataGridViewCell selectedCell = ADGVStudentFacility.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        DataGridViewCheckBoxCell dgvChkbx = selectedCell as DataGridViewCheckBoxCell;

                        dgvChkbx.Value = Convert.ToBoolean(selectedRow.Cells["AutoRenewEnabled"].Value);

                        if (Convert.ToBoolean(dgvChkbx.Value) == true)
                        {
                            selectedRow.Cells["AutoRenewEnabled"].Value = false;
                        }
                        else
                        {
                            selectedRow.Cells["AutoRenewEnabled"].Value = true;
                        }
                        bool isAutoRenew, isMainPackage;
                        studfacilityID = (Convert.ToInt32(selectedRow.Cells["Id"].Value));
                        isAutoRenew = Convert.ToBoolean(selectedRow.Cells["AutoRenewEnabled"].Value);
                        isMainPackage = (Convert.ToBoolean(selectedRow.Cells["isMainPackage"].Value));
                        if (BLL.StudentHandller.renewStudPackageOrFacility(studfacilityID, isAutoRenew, isMainPackage))
                        {
                            UICommon.WinForm.showStatus((isAutoRenew) ? "Autorenewal is turned on" : "Autorenewal is turned off", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }

                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["RenewDiscount"].Index)
                    {
                        ADGVStudentFacility.BeginEdit(true);
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        DataGridViewCell selectedCell = ADGVStudentFacility.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        DataGridViewCheckBoxCell dgvChkbx = selectedCell as DataGridViewCheckBoxCell;

                        dgvChkbx.Value = Convert.ToBoolean(selectedRow.Cells["RenewDiscount"].Value);

                        if (Convert.ToBoolean(dgvChkbx.Value) == true)
                        {
                            selectedRow.Cells["RenewDiscount"].Value = false;
                        }
                        else
                        {
                            selectedRow.Cells["RenewDiscount"].Value = true;
                        }
                        studfacilityID = (Convert.ToInt32(selectedRow.Cells["Id"].Value));
                        bool isRenewDiscount = Convert.ToBoolean(selectedRow.Cells["RenewDiscount"].Value);
                        if (BLL.StudentHandller.enableRenewDiscount(studfacilityID, isRenewDiscount))
                        {
                            UICommon.WinForm.showStatus(isRenewDiscount ? "Renew Discount is on" : "Renew Discount is off", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["btnRenew"].Index)
                    {
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        studfacilityID = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                        if (selectedRow.Cells["Status"].Value.ToString() == "A")
                        {
                            foreach (StudentFacility objFacility in objStudent.Facilities)
                            {
                                if (studfacilityID == objFacility.Id)
                                {
                                    if (checkPackageType(objFacility))
                                    {

                                        objFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                                        objFacility.FacilityName = objFacility.Package.PackageName;

                                        objFacility.Student.RollNo = objStudent.RollNo;
                                        FrmMonthSelector frmMnthSelector = new FrmMonthSelector(objStudent);
                                        frmMnthSelector.feeStructure = objFacility;
                                        frmMnthSelector.ShowDialog();
                                        packageName = objFacility.Package.PackageName;

                                        break;
                                    }
                                }
                                packagetype = objFacility.Package.PackageType.ToString();
                            }

                        }
                        else if (selectedRow.Cells["Status"].Value.ToString() == "E")
                        {
                            var result = UICommon.WinForm.showStatus("The selected Facility is Deactive." + System.Environment.NewLine + "Do you want to Activate and Renew?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                            if (result == DialogResult.Yes)
                            {
                                foreach (StudentFacility objFacility in objStudent.Facilities)
                                {
                                    if (studfacilityID == objFacility.Id)
                                    {
                                        if (checkPackageType(objFacility))
                                        {

                                            objFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                                            objFacility.FacilityName = objFacility.Package.PackageName;
                                            objFacility.Student.RollNo = objStudent.RollNo;
                                            objFacility.FacultyName = objFacility.FacultyName;
                                            FrmMonthSelector frmMnthSelector = new FrmMonthSelector(objStudent);
                                            frmMnthSelector.feeStructure = objFacility;
                                            frmMnthSelector.ShowDialog();

                                            //Storing PackageName.(26-Oct-2017).
                                            packageName = objFacility.Package.PackageName;
                                            //(26-Oct-2017).

                                            break;


                                        }
                                    }
                                    packagetype = objFacility.Package.PackageType.ToString();
                                    MailHandler.RenewPackage(objStudent.DisplayName, packageName, objStudent.ContactNo, Program.LoggedInUser.BranchId);
                                }


                            }
                        }

                        else
                        {
                            return;
                        }
                        loadStudent();
                    }
                }
            }
            catch (Exception)
            {
                //         UICommon.WinForm.showError( sCaption, this);
            }
        }



        /// <summary>
        /// This function is to check the type of the package while Renewal. If it is of INSTALLMENT type then package is not suppose to renew.
        /// </summary>
        /// <param name="objFacility"></param>
        /// <returns></returns>
        public static bool checkPackageType(StudentFacility objFacility)
        {
            try
            {
                return true;

                if (objFacility.Package.PackageType != PackageType.INSTALLMENT)
                {
                    return true;
                }
                else
                {
                    UICommon.WinForm.showStatus("Package Type is Installment, Cannot Renew this Package.", "Renewal", null);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnCancelled_Click(object sender, EventArgs e)
        {
            try
            {
                //button1.Text;
                lstInstallmentDetails = objStudent.Fees.Installments;
                if (btnCancelled.Text == "Show Cancelled")
                {
                    ADGVInstDetails.DataSource = lstInstallmentDetails.Where(installment => installment.Status == "CNCLD").ToList<InstallmentDetail>();
                    btnCancelled.Text = "Show Active";
                }
                else
                {
                    ADGVInstDetails.DataSource = lstInstallmentDetails.Where(installment => installment.Status == "NP" || installment.Status == "Partial Payment" || installment.Status == "PAID").ToList<InstallmentDetail>();
                    btnCancelled.Text = "Show Cancelled";
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ADGVStudentFacility.DataSource;
                bs.Filter = "([Status] IN ('D'))";
                ADGVStudentFacility.DataSource = bs;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnShowReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                ADGVReceipt.DataSource = BLL.FeesHandller.getPayments(objStudent.AdmissionNo, dtpReceiptFrmDate.Value, dtpReceiptToDate.Value);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int TransactionId = Convert.ToInt32(Convert.ToString(ADGVReceipt.Rows[e.RowIndex].Cells["TRNC_ID"].Value));
                if (e.ColumnIndex == ADGVReceipt.Columns["Reprint"].Index)
                {
                    DataTable dtTransaction = BLL.FeesHandller.getTransactionReprint(TransactionId.ToString());
                    List<PaymentDetails> bankTransfers = BLL.FeesHandller.getTransactionPaymentDetails(TransactionId);

                    Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                    objFeeData.BranchId = objStudent.Branch.BranchName.ToString();

                    objFeeData.PaymentDate = Convert.ToDateTime(dtTransaction.Rows[0].ItemArray[3].ToString());
                    objFeeData.minDate = DateTime.MinValue;
                    objFeeData.ReceiptNo = dtTransaction.Rows[0].ItemArray[16].ToString();
                    objFeeData.RollNo = objStudent.RollNo;
                    objFeeData.RupeesInWord = Utility.currencyInWords(Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[5]));

                    objFeeData.Standard = dtTransaction.Rows[0]["STRM_NAME"].ToString();
                    if (ClassManager.Properties.Settings.Default.ShowBatchInReceipt == true)
                    {
                        objFeeData.Standard += "/" + dtTransaction.Rows[0]["FPKG_PACKAGE_NAME"].ToString();
                    }

                    objFeeData.PackageName = dtTransaction.Rows[0]["FPKG_PACKAGE_NAME"].ToString();
                    objFeeData.Batch = objStudent.Course.Batch.Name;
                    objFeeData.StudentName = objStudent.Fname + " " + objStudent.Lname;
                    objFeeData.FatherContactNo = objStudent.ContactNo;
                    objFeeData.EmailId = objStudent.EmailID;
                    objFeeData.ParentName = objStudent.ParentName;
                    objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);
                    objFeeData.TotalFees = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[5].ToString());
                    objFeeData.SirName = Info.SysParam.getValue<String>(SysParam.Parameters.SIR_NAME);
                    objFeeData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                    objFeeData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                    objFeeData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    objFeeData.CmpnyPanNO = Info.SysParam.getValue<String>(SysParam.Parameters.COMPANY_PAN_NO);
                    objFeeData.CINNO = Info.SysParam.getValue<String>(SysParam.Parameters.CIN_NO);
                    objFeeData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                    objFeeData.OwnerNo = Info.SysParam.getValue<String>(SysParam.Parameters.OWNER_NOS);
                    objFeeData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                    objFeeData.Email = Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS);
                    objFeeData.MainAdd = Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS);
                    objFeeData.clasContct = Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO);
                    objFeeData.stud_photo = objStudent.PhotoURL;
                    objFeeData.AdmsnNo = objStudent.AdmissionNo;
                    objFeeData.BranchAddress = Info.SysParam.getValue<String>(SysParam.Parameters.SW_BRANCH_NAME);
                    objFeeData.PackageAmount = objStudent.Fees.TotalFees;
                    objFeeData.StartDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_FROM_DATE"].ToString());
                    objFeeData.EndDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_TO_DATE"].ToString());
                    objFeeData.TotalAmount = objStudent.Fees.TotalFees;//added for etech on 30-03-2019
                    objFeeData.FinalAmount = objStudent.Fees.TotalFees - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount); //added for monark fitness by ashvini on 8--2019
                    objFeeData.FeesId = objStudent.Fees.FeesId;
                    objFeeData.ServiceTaxNo = Info.SysParam.getValue<String>(SysParam.Parameters.SERVICE_TAX_NO);
                    objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                    objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                    objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;
                    objFeeData.BankTransfer = bankTransfers;
                    objFeeData.ReceivedBy = dtTransaction.Rows[0]["TRNC_CRTD_BY"].ToString();

                    //objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount;
                    objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.Installments.Sum(outs => outs.Discount);
                    if (objFeeData.OutstandingAmount == decimal.MinusOne)
                    {
                        objFeeData.OutstandingAmount = decimal.Zero;
                    }
                    objFeeData.MembershipNo = objStudent.MembershipNo;


                    objFeeData.TransactionId = Convert.ToInt32(dtTransaction.Rows[0].ItemArray[0]);
                    objFeeData.TuitionFees = objStudent.Fees.TuitionAmnt - objFeeData.ServiceTax;

                    //objFeeData.PaymentMode = objTransaction.PaymentMode.ToString();
                    objFeeData.Adhar = objStudent.AdharCard;
                    objFeeData.CashPayment = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[30].ToString());
                    objFeeData.ChequePayment = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[29].ToString());
                    objFeeData.StartDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_FROM_DATE"].ToString());
                    objFeeData.EndDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_TO_DATE"].ToString());
                    //NumberToMonth.Months installmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objTransaction.Month.ToString());
                    NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                    //objFeeData.InstallmentMonths = installmonth.ToString();
                    objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();
                    //Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT", "Fee_Receipt_" + objStudent.AdmissionNo + "_" /*+ objTransaction.ReceiptNo.Replace(@"/", "-")*/);
                    // Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT_PRO", "Fee_Receipt_" + objStudent.AdmissionNo + "_" + dtTransaction.Rows[0].ItemArray[16].ToString().Replace(@"/", "-"), true);
                    PrintingConfig objPrintngConfig = new PrintingConfig();
                    objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                    objPrintngConfig.PrintReport = true;
                    objPrintngConfig.reportType = "FEE_RECEIPT";
                    objPrintngConfig.SaveReport = false;
                    objPrintngConfig.ViewReport = true;
                    if (SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE) == "FEE_RECEIPT")
                    {
                        objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "FEE_RECEIPT");
                    }
                    else
                    {
                        objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE_RECEIPT");
                    }
                    objPrintngConfig.exportFileName = "Fee_Receipt_" + objStudent.AdmissionNo + "_" + dtTransaction.Rows[0].ItemArray[16].ToString().Replace(@"/", "-");
                    objPrintngConfig.sendSMS = true;
                    objPrintngConfig.sendEmail = true;



                    FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
                    frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, true);
                    FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;
                }
                else if (ADGVReceipt.Columns.Contains("Invoice") &&  e.ColumnIndex == ADGVReceipt.Columns["Invoice"].Index)
                {
                    Invoice objInvoice = null;
                    if (ADGVReceipt.Rows[e.RowIndex].Cells["INVOICE_ID"].Value != null && ADGVReceipt.Rows[e.RowIndex].Cells["INVOICE_ID"].Value.ToString() != "")
                    {
                        objInvoice = FeesHandller.loadInvoiceDetails(Convert.ToInt32(ADGVReceipt.Rows[e.RowIndex].Cells["INVOICE_ID"].Value));
                        if (objInvoice == null)
                        {
                            UICommon.WinForm.showMessage("Invoice not present in system, Please contact support for additional help", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                            return;
                        }
                    }
                    
                    else
                    {
                        objInvoice = new Invoice();

                        DataTable dtTransaction = BLL.FeesHandller.getTransactionReprint(TransactionId.ToString());
                        Transaction objTransaction = Transaction.getTransaction(dtTransaction.Rows[0]);


                        objInvoice.admissionNo = objStudent.AdmisionNo;
                        objInvoice.amount = objTransaction.Amount;
                        objInvoice.branchId = objStudent.batchID;
                        objInvoice.clientGSTN = objStudent.GSTNo;
                        objInvoice.clientName = objStudent.Fname + " " + objStudent.Lname;
                        objInvoice.invoiceDate = objTransaction.Date;
                        objInvoice.facilityId = 0;
                        objInvoice.TransactionId = objTransaction.TrancID;

                        InvoiceDetails objInvoiceDetails = new InvoiceDetails();

                        objInvoiceDetails.actualAmount = Math.Round((objTransaction.Amount) / (decimal)1.18, 2);
                        objInvoiceDetails.amount = objTransaction.Amount;
                        objInvoiceDetails.SACCode = ClassManager.Common.ClsCommon.DefaultSACCode;
                        objInvoiceDetails.quantity = 1;


                        objInvoiceDetails.packageAmount = objTransaction.Amount;
                        objInvoiceDetails.SGSTPercentage = SysParam.getValue<decimal>(SysParam.Parameters.SGST_PERCENT);
                        objInvoiceDetails.CGSTPercentage = SysParam.getValue<decimal>(SysParam.Parameters.CGST_PERCENT);
                        objInvoiceDetails.CGSTAmount = Math.Round(objInvoiceDetails.actualAmount * objInvoiceDetails.CGSTPercentage / (decimal)100, 2);
                        objInvoiceDetails.SGSTAmount = Math.Round(objInvoiceDetails.actualAmount * objInvoiceDetails.SGSTPercentage / (decimal)100, 2);

                        //Adjust amount without tax based on taxes collected
                        objInvoiceDetails.actualAmount = (objTransaction.Amount) - (objInvoiceDetails.CGSTAmount + objInvoiceDetails.SGSTAmount);
                        objInvoiceDetails.totalTax = (objInvoiceDetails.CGSTAmount + objInvoiceDetails.SGSTAmount);
                        objInvoiceDetails.paidAmount = 0;
                        objInvoiceDetails.packageAmount = objTransaction.Amount;
                        objInvoiceDetails.balanceAmount = objInvoiceDetails.actualAmount;
                        objInvoiceDetails.branchId = objStudent.Branch.BranchId;
                        objInvoiceDetails.packageName = dtTransaction.Rows[0]["STRM_NAME"] + "/" + dtTransaction.Rows[0]["STD_NAME"];
                        objInvoiceDetails.discount = 0;

                        List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();
                        invoiceDetails.Add(objInvoiceDetails);
                        objInvoice.invoiceItems = invoiceDetails;

                        objInvoice = BLL.FeesHandller.createInvoice(objInvoice, objStudent.Branch.BranchId);
                    }

                    printInvoice(objInvoice.id, TransactionId);
                    loadStudent(objStudent.AdmissionNo);
                }
                else if (ADGVReceipt.Columns.Contains("Cancel") && e.ColumnIndex == ADGVReceipt.Columns["Cancel"].Index)
                {
                    var result = UICommon.WinForm.showStatus("Do You Want Delete this Payment?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (result == DialogResult.Yes)
                    {
                        BLL.FeesHandller.cancelPayment(TransactionId);
                        loadStudent(objStudent.AdmissionNo);
                    }
                    
                    
                }
                else if (e.ColumnIndex == ADGVReceipt.Columns["Details"].Index)
                {
                   // DataTable dtTransaction = BLL.FeesHandller.getTransaction(TransactionId.ToString());
                    UICommon.FrmDetailsTran objpopup = new UICommon.FrmDetailsTran();
                    //objpopup = UICommon.FormFactory.GetForm(UICommon.Forms.FrmDetailsTran) as FrmDetailsTran;
                    objpopup.Show();
                    objpopup.SetData(TransactionId.ToString());

                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }


        private void ADGVInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        DataTable dtInvoice = BLL.FeesHandller.getInvoiceReprint(Convert.ToString(ADGVInvoice.Rows[e.RowIndex].Cells[2].Value), Convert.ToString(ADGVInvoice.Rows[e.RowIndex].Cells[1].Value));

                        Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                        objFeeData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                        objFeeData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                        objFeeData.ServiceTaxNo = Info.SysParam.getValue<String>(SysParam.Parameters.SERVICE_TAX_NO);
                        objFeeData.StudentName = objStudent.Fname + " " + objStudent.Lname;
                        objFeeData.ContactNo = objStudent.ContactNo;
                        objFeeData.ReceiptNo = dtInvoice.Rows[0].ItemArray[1].ToString();
                        objFeeData.PaymentDate = Convert.ToDateTime(dtInvoice.Rows[0].ItemArray[3].ToString());
                        objFeeData.AdmsnNo = objStudent.AdmissionNo;
                        objFeeData.PackageName = dtInvoice.Rows[0].ItemArray[36].ToString();
                        objFeeData.PackageAmount = Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[4]);
                        objFeeData.SACCode = dtInvoice.Rows[0].ItemArray[18].ToString();
                        objFeeData.TuitionFees = Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[4]) + Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[37]);
                        objFeeData.DisCount = Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[37]);
                        objFeeData.ClientGSTNo = objStudent.GSTNo;
                        objFeeData.BranchId = objStudent.Branch.BranchName.ToString();
                        objFeeData.RupeesInWord = Utility.currencyInWords(Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[4]));
                        objFeeData.OutstandingAmount = Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[27]);
                        objFeeData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                        objFeeData.Address = objStudent.Address;
                        objFeeData.Standard = objStudent.Course.Standard.Stream.Name + "-" + objStudent.Course.Standard.StandardName;

                        objFeeData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                        objFeeData.TotalFees = Convert.ToDecimal(dtInvoice.Rows[0].ItemArray[26]);
                        PrintingConfig objPrintngConfig = new PrintingConfig();
                        objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                        objPrintngConfig.PrintReport = true;
                        objPrintngConfig.reportType = "INVOICE_REPORT";
                        objPrintngConfig.SaveReport = false;
                        objPrintngConfig.ViewReport = true;
                        if (SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE) == "FEE_RECEIPT")
                        {
                            objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE_REPORT");
                        }
                        else
                        {
                            objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE");
                        }


                        //objPrintngConfig.exportFileName = "INVOICE_REPORT_" + objStudent.AdmissionNo + "_" + Receipt.Replace(@"/", "-");
                        objPrintngConfig.sendSMS = true;
                        objPrintngConfig.sendEmail = true;
                        FrmReportViewer frmRprtViewer = new FrmReportViewer();
                        frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
                        //Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT_PRO", "Fee_Receipt_" + objStudent.AdmissionNo + "_" + dtTransaction.Rows[0].ItemArray[16].ToString().Replace(@"/", "-"), true);
                    }

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnCumPrnt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVReceipt.Rows.Count > 0)
                {
                    getCumulativeTransaction();
                }
                else
                {
                    UICommon.WinForm.showStatus("There is no data to show cumulative receipt.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmbViewPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //this method is added for loading columns in     ADGVStudentFacility gridview in these event by ashvini
                StringBuilder filterStatus = new StringBuilder();
                if (cmbViewPackage.SelectedIndex == 1)
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "A").ToList();

                    if (ADGVStudentFacility.Columns.Contains("btnRenew"))
                    {
                        ADGVStudentFacility.Columns["btnRenew"].Visible = true;
                    }
                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = false;
                        }
                    }
                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                    }

                }
                else if (cmbViewPackage.SelectedIndex == 2)
                {

                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "D").ToList();
                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;

                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                        //if (ADGVStudentFacility.Columns.Contains("btnUpgrade"))
                        //{
                        //    ADGVStudentFacility.Columns["btnUpgrade"].Visible = true;
                        //}

                    }


                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                        //if (ADGVStudentFacility.Columns.Contains("btnUpgrade"))
                        //{
                        //    ADGVStudentFacility.Columns["btnUpgrade"].Visible = false;
                        //}
                    }
                    ADGVStudentFacility.Columns["btnRenew"].Visible = true;

                }
                //To View Expired Facilities.Mohan(14-Aug-2017).
                else if (cmbViewPackage.SelectedIndex == 3)
                {
                    List<StudentFacility> data = new List<StudentFacility>();
                    data.AddRange(objStudent.Facilities.Where(f => f.RemindRenewal == true));

                    StudentFacility expiredFacilityToShow = (objStudent.Facilities.Where(f => f.RemindRenewal == false).Where(facility => facility.Status == "E").OrderByDescending(fac => fac.ToDate).FirstOrDefault());

                    if(expiredFacilityToShow != null)
                    {
                        data.Add(expiredFacilityToShow);
                    }

                    
                    ADGVStudentFacility.DataSource = data;
                    if (ADGVStudentFacility.Columns.Contains("btnRenew"))
                    {
                        ADGVStudentFacility.Columns["btnRenew"].Visible = true;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                        //if (ADGVStudentFacility.Columns.Contains("btnUpgrade"))
                        //{
                        //    ADGVStudentFacility.Columns["btnUpgrade"].Visible = true;
                        //}
                    }
                    else

                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                        //if (ADGVStudentFacility.Columns.Contains("btnUpgrade"))
                        //{
                        //    ADGVStudentFacility.Columns["btnUpgrade"].Visible = false;
                        //}
                    }

                }
                else if (cmbViewPackage.SelectedIndex == 4)
                {

                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "R").ToList();
                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;

                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                        

                    }


                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                    }
                    ADGVStudentFacility.Columns["btnRenew"].Visible = true;

                }
                //Mohan(14-Aug-2017).
                else
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities;
                    if (ADGVStudentFacility.Columns.Contains("btnRenew"))
                    {
                        ADGVStudentFacility.Columns["btnRenew"].Visible = true;
                    }
                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                    }
                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                        if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                        {
                            ADGVStudentFacility.Columns["btnEdit"].Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void btnAddFacilities_Click(object sender, EventArgs e)
        {
            try
            {

                //UICommon.FormFactory.GetForm(UICommon.Forms.FrmAddFacilities, null, false);

                FrmAddFacilities frmAddfacilities = new FrmAddFacilities(objStudent);
                frmAddfacilities.ShowDialog(this);

                lstStudentInstallment = FrmAddFacilities.lstStudentInstallment;
                selctedSubjects = FrmAddFacilities.selctedSubjects;
                loadStudent();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        #endregion

        #region Formatting Functions

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpAttdFromDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpAttdToDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpReceiptToDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpReceiptFrmDate, Common.Formatter.DateFormat);

                dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void formatReceiptGrid()
        {
            if (!ADGVReceipt.Columns.Contains("Reprint"))
            {


                ADGVReceipt.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.printer,
                    Name = "Reprint",
                    HeaderText = "Reprint"
                });

                if (SysParam.getValue<bool>(SysParam.Parameters.GENERATE_INVOICE) == true)
                {
                    ADGVReceipt.Columns.Add(new DataGridViewImageColumn()
                    {

                        Image = Properties.Resources.printer,
                        Name = "Invoice",
                        HeaderText = "Invoice"
                    });
                }
                ADGVReceipt.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.deleteBin,
                    Name = "Cancel",
                    HeaderText = "Cancel"
                });
                ADGVReceipt.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.Edit,
                    Name = "Details",
                    HeaderText = "Details"
                });
            }


            //formatting HeaderText
            ADGVReceipt.Columns["TRNC_AMOUNT"].HeaderText = "Amount";
            ADGVReceipt.Columns["TRNC_DATE"].HeaderText = "Date";
            ADGVReceipt.Columns["TRNC_RECEIPT_NO"].HeaderText = "Receipt No";
            if (ADGVAttendance.Columns.Contains("FPKG_PACKAGE_NAME"))
            {
                ADGVReceipt.Columns["FPKG_PACKAGE_NAME"].HeaderText = "Package";
            }
           

            //formatting Date
            ADGVReceipt.Columns["TRNC_DATE"].DefaultCellStyle.Format = Formatter.DateFormat;

            //Hiding Columns
            ADGVReceipt.Columns["TRNC_ID"].Visible = false;
            ADGVReceipt.Columns["INVOICE_ID"].Visible = false;

            ADGVReceipt.Columns["TRNC_RECEIPT_NO"].Width = 170;
            ADGVReceipt.Columns["TRNC_AMOUNT"].Width = 60;
            ADGVReceipt.Columns["Reprint"].Width = 60;
            ADGVReceipt.Columns["TRNC_DATE"].Width = 80;
            ADGVReceipt.Columns["Reprint"].DisplayIndex = 0;
        }
        private void formatFeesGrid()
        {
            try
            {
                ////Order column
                ADGVInstDetails.Columns["Facility"].DisplayIndex = 0;
                ADGVInstDetails.Columns["FromDate"].DisplayIndex = 1;
                ADGVInstDetails.Columns["ToDate"].DisplayIndex = 2;
                ADGVInstDetails.Columns["InstAmount"].DisplayIndex = 3;
                ADGVInstDetails.Columns["AmntPaid"].DisplayIndex = 4;
                ADGVInstDetails.Columns["Discount"].DisplayIndex = 5;
                ADGVInstDetails.Columns["Reason"].DisplayIndex = 6;

                ////Hide Columns
                ADGVInstDetails.Columns["id"].Visible = false;
                ADGVInstDetails.Columns["InstMonth"].Visible = false;
                ADGVInstDetails.Columns["InstNo"].Visible = false;
                ADGVInstDetails.Columns["TodaysDue"].Visible = false;
                ADGVInstDetails.Columns["Fees"].Visible = false;
                ADGVInstDetails.Columns["PaymentDate"].Visible = false;
                ADGVInstDetails.Columns["Description"].Visible = false;
                ADGVInstDetails.Columns["InstDate"].Visible = false;
                ADGVInstDetails.Columns["CancelledAmount"].Visible = false;
                ADGVInstDetails.Columns["Status"].Visible = false;
                ADGVInstDetails.Columns["TodaysDue"].Visible = false;
                ADGVInstDetails.Columns["Fees"].Visible = false;
                ADGVInstDetails.Columns["Duration"].Visible = false;

                ////Format 

                ADGVInstDetails.Columns["FromDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat; ;
                ADGVInstDetails.Columns["ToDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat; ;
                ADGVInstDetails.Columns["InstAmount"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;
                ADGVInstDetails.Columns["AmntPaid"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;
                ADGVInstDetails.Columns["Discount"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;

                ////Change Header

                ADGVInstDetails.Columns["InstAmount"].HeaderText = "Amount";
                ADGVInstDetails.Columns["AmntPaid"].HeaderText = "Paid";
                ADGVInstDetails.Columns["Discount"].HeaderText = "Discount";
                ADGVInstDetails.Columns["Facility"].HeaderText = "PackageType";
                //// Order column

            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        private void formatInvoice()
        {
            if (!ADGVInvoice.Columns.Contains("Reprint"))
            {
                DataGridViewButtonColumn btnRepntReceipt = new DataGridViewButtonColumn();
                btnRepntReceipt.HeaderText = "Reprint";
                btnRepntReceipt.Text = "Reprint";
                btnRepntReceipt.Name = "Reprint";
                btnRepntReceipt.DefaultCellStyle.NullValue = "Reprint";
                ADGVInvoice.Columns.Insert(0, btnRepntReceipt);

            }


            //formatting HeaderText
            ADGVInvoice.Columns["INVOICE_AMOUNT"].HeaderText = "Amount";
            ADGVInvoice.Columns["INVOICE_DATE"].HeaderText = "Date";
            ADGVInvoice.Columns["INVOICE_NO"].HeaderText = "InvoiceNo.";


            //ADGVInvoice Date
            ADGVInvoice.Columns["INVOICE_DATE"].DefaultCellStyle.Format = Formatter.DateFormat;

            //Hiding Columns
            ADGVInvoice.Columns["INVOICE_ID"].Visible = false;
        }
        //added by ashvini09-01-2019
        //for formatting data of actinvity_
        private void FormatActivityGrid()
        {
            try
            {
                ActivityGrid.ReadOnly = true;
                if (ActivityGrid.Columns.Contains("ACT_ADMISSIONNO"))
                {
                    ActivityGrid.Columns["ACT_ADMISSIONNO"].HeaderText = "ID";
                    ActivityGrid.Columns["ACT_ADMISSIONNO"].Width = 40;
                    ActivityGrid.Columns["ACT_ADMISSIONNO"].DisplayIndex = 0;
                }
                if (ActivityGrid.Columns.Contains("ACT_USER"))
                {
                    ActivityGrid.Columns["ACT_USER"].HeaderText = "Name";
                    ActivityGrid.Columns["ACT_USER"].Width = 200;
                    ActivityGrid.Columns["ACT_USER"].DisplayIndex = 1;
                }
                if (ActivityGrid.Columns.Contains("ACT_LOGIN_USER"))
                {
                    ActivityGrid.Columns["ACT_LOGIN_USER"].HeaderText = "Activity By";
                    ActivityGrid.Columns["ACT_LOGIN_USER"].Width = 80;
                    ActivityGrid.Columns["ACT_LOGIN_USER"].DisplayIndex = 2;
                }
                if (ActivityGrid.Columns.Contains("ACT_OLD_VALUE"))
                {
                    ActivityGrid.Columns["ACT_OLD_VALUE"].HeaderText = "Old Value";
                    ActivityGrid.Columns["ACT_OLD_VALUE"].Width = 100;
                    ActivityGrid.Columns["ACT_OLD_VALUE"].DisplayIndex = 3;
                }
                if (ActivityGrid.Columns.Contains("ACT_NEW_VALUE"))
                {
                    ActivityGrid.Columns["ACT_NEW_VALUE"].HeaderText = "New Value";
                    ActivityGrid.Columns["ACT_NEW_VALUE"].Width = 100;
                    ActivityGrid.Columns["ACT_NEW_VALUE"].DisplayIndex = 4;
                }
                if (ActivityGrid.Columns.Contains("ACT_DESC"))
                {
                    ActivityGrid.Columns["ACT_DESC"].HeaderText = "Remark";
                    ActivityGrid.Columns["ACT_DESC"].Width = 250;

                }

                ActivityGrid.Columns["ACT_DATE"].Visible = false;
                ActivityGrid.Columns["ACT_CRTD_AT"].Visible = false;
                ActivityGrid.Columns["ACT_CRTD_BY"].Visible = false;
                ActivityGrid.Columns["ACT_UPDT_AT"].Visible = false;
                ActivityGrid.Columns["ACT_UPDT_BY"].Visible = false;
                ActivityGrid.Columns["ACT_DLTD_AT"].Visible = false;
                ActivityGrid.Columns["ACT_DLTD_BY"].Visible = false;
                ActivityGrid.Columns["ID"].Visible = false;
                ActivityGrid.Columns["ACT_ID"].Visible = false;
                ActivityGrid.Columns["ACT_BRANCH_ID"].Visible = false;
                ActivityGrid.Columns["ACT_DESC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ActivityGrid.Columns[2].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void formatFacilityGrid()
        {
            try
            {



                if (ADGVStudentFacility.Columns.Contains("btnPayFees"))
                {
                    ADGVStudentFacility.Columns["btnPayFees"].DisplayIndex = 0;
                    ADGVStudentFacility.Columns["btnPayFees"].HeaderText = "Pay";
                    ADGVStudentFacility.Columns["btnPayFees"].Width = 50;
                }
                if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                {
                    ADGVStudentFacility.Columns["btnDelete"].DisplayIndex = 1;
                    ADGVStudentFacility.Columns["btnDelete"].Width = 70;
                }
                if (ADGVStudentFacility.Columns.Contains("btnRenew"))
                {
                    ADGVStudentFacility.Columns["btnRenew"].DisplayIndex = 2;
                    ADGVStudentFacility.Columns["btnRenew"].Width = 70;
                }
                if (ADGVStudentFacility.Columns.Contains("btnEdit"))
                {
                    ADGVStudentFacility.Columns["btnEdit"].DisplayIndex = 3;
                    ADGVStudentFacility.Columns["btnEdit"].Width = 70;
                }
                if (ADGVStudentFacility.Columns.Contains("btnUpgrade"))
                {
                    ADGVStudentFacility.Columns["btnUpgrade"].DisplayIndex = 4;
                    ADGVStudentFacility.Columns["btnUpgrade"].Width = 70;
                }
                //added by ashvini07-01-2019
                if (ADGVStudentFacility.Columns.Contains("Canc_Amt"))
                {
                    ADGVStudentFacility.Columns["Canc_Amt"].ReadOnly = true;
                    ADGVStudentFacility.Columns["Canc_Amt"].HeaderText = "Cancelled Amount";
                    ADGVStudentFacility.Columns["Canc_Amt"].DisplayIndex = 23;
                    //end by ashvini04-02
                }
                ///ADDED BY ASHVINI 4-1-2019

                if (ADGVStudentFacility.Columns.Contains("Amount_Paid"))
                {
                    ADGVStudentFacility.Columns["Amount_Paid"].ReadOnly = true;
                    ADGVStudentFacility.Columns["Amount_Paid"].HeaderText = "Paid Amount";
                    ADGVStudentFacility.Columns["Amount_Paid"].DisplayIndex = 11;
                    //end by ashvini04-02
                }

                //Hide Column
                ADGVStudentFacility.Columns["Id"].Visible = false;
                ADGVStudentFacility.Columns["Package"].Visible = false;
                ADGVStudentFacility.Columns["Student"].Visible = false;
                ADGVStudentFacility.Columns["IsMainPackage"].Visible = false;
                ADGVStudentFacility.Columns["AdmissionDate"].Visible = false;
                ADGVStudentFacility.Columns["RenewalDiscount"].Visible = false;
                ADGVStudentFacility.Columns["Package"].Visible = false;
                ADGVStudentFacility.Columns["Branch"].Visible = false;
                ADGVStudentFacility.Columns["AdmissionDate"].Visible = false;
                ADGVStudentFacility.Columns["IsMainPackage"].Visible = false;
                ADGVStudentFacility.Columns["AutoRenewEnabled"].Visible = false;
                ADGVStudentFacility.Columns["RenewDiscount"].Visible = false;
                ADGVStudentFacility.Columns["Reason"].Visible = false;
                ADGVStudentFacility.Columns["DiscountReason"].Visible = false;
                //Make readonly
                ADGVStudentFacility.Columns["Id"].ReadOnly = true;
                ADGVStudentFacility.Columns["FacilityName"].ReadOnly = true;

                ADGVStudentFacility.Columns["FromDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["ToDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["Status"].ReadOnly = true;
                ADGVStudentFacility.Columns["Status"].Width = 60;
                ADGVStudentFacility.Columns["Amount"].ReadOnly = true;
                ADGVStudentFacility.Columns["Amount"].Width = 70;
                ADGVStudentFacility.Columns["Discount"].ReadOnly = true;
                ADGVStudentFacility.Columns["Discount"].Width = 70;
                ADGVStudentFacility.Columns["InvoiceId"].Width = 70;
                ADGVStudentFacility.Columns["InvoiceId"].DisplayIndex = 23;
                ADGVStudentFacility.Columns["Pending"].Width = 70;
                ADGVStudentFacility.Columns["Pending"].DisplayIndex = 22;
                //Change Column Header
                ADGVStudentFacility.Columns["FacilityName"].HeaderText = "PackageName";
                ADGVStudentFacility.Columns["FacilityName"].Width = 150;
                ADGVStudentFacility.Columns["FromDate"].HeaderText = "From";
                ADGVStudentFacility.Columns["ToDate"].HeaderText = "To";
                ADGVStudentFacility.Columns["AutoRenewEnabled"].HeaderText = "AutoRenew";
                ADGVStudentFacility.Columns["AutoRenewEnabled"].Width = 70;
                ADGVStudentFacility.Columns["RenewDiscount"].HeaderText = "Discount on Renew";
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                if (appName == "Gym" || appName == "Dance")
                {
                    ADGVStudentFacility.Columns["FacultyName"].HeaderText = "Instructors Name";
                    ADGVStudentFacility.Columns["FacultyName"].Visible = true;

                    ADGVStudentFacility.Columns["FacultyName"].DisplayIndex = 6; 

                }
                else
                {
                    ADGVStudentFacility.Columns["FacultyName"].Visible = false;
                }
                ADGVStudentFacility.Columns["InstructorId"].Visible = false;
                
                //Format Column
                ADGVStudentFacility.Columns["FromDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVStudentFacility.Columns["ToDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                //setting the width of the column
                ADGVStudentFacility.Columns["FromDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ADGVStudentFacility.Columns["ToDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                //  ADGVStudentFacility.Columns["FacilityName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Functions

        private void loadAttendance(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable attendance = BLL.AttendanceHandler.getStduentAttendance(fromDate, toDate, branchId, objStudent.AdmissionNo);
                if (attendance != null)
                {
                    ADGVAttendance.DataSource = attendance;
                    assignValueAttendance(attendance);
                    formatAttendenceGrid();
                }
                else
                {
                    UICommon.WinForm.showStatus("No Attendance Log is there", MessageBoxButtons.OK, MessageBoxIcon.Information, "AttendanceInfo", this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void assignValueAttendance(DataTable attendance)
        {
            try
            {
                lblPresent.Text = attendance.AsEnumerable().Where(row => row.Field<string>("ATTD_STATUS") == "P").Count().ToString();
                lblAbsent.Text = attendance.AsEnumerable().Where(row => row.Field<string>("ATTD_STATUS") == "A").Count().ToString();
                lblHours.Text = Convert.ToString(attendance.Compute("SUM(Total)", string.Empty)) == "" ? "0" : Convert.ToString(attendance.Compute("SUM(Total)", string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void formatAttendenceGrid()
        {
            try
            {
                //Hide Columns
                ADGVAttendance.Columns["ATTD_ID"].Visible = false;
                ADGVAttendance.Columns["ATTD_ADMISSION_NO"].Visible = false;
                ADGVAttendance.Columns["ATTD_BRANCH_ID"].Visible = false;
                ADGVAttendance.Columns["ATTD_CHECKIN_STATUS"].Visible = false;
                if (ADGVAttendance.Columns.Contains("ATLC_IS_SCHEDULED"))
                {
                    ADGVAttendance.Columns["ATLC_IS_SCHEDULED"].Visible = false;
                }
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                if (ADGVAttendance.Columns.Contains("Name"))
                {
                    ADGVAttendance.Columns["Name"].Visible = false;

                }

                if (ADGVAttendance.Columns.Contains("Contact No"))
                {
                    ADGVAttendance.Columns["Contact No"].Visible = false;
                }
                if (appName == "Gym" || appName == "Dance")

                {
                    if (ADGVAttendance.Columns.Contains("Father Contact"))
                    {

                        ADGVAttendance.Columns["Father Contact"].Visible = false;
                    }
                }

                if (ADGVAttendance.Columns.Contains("STD_NAME"))
                {
                    ADGVAttendance.Columns["STD_NAME"].Visible = false;
                }

                if (ADGVAttendance.Columns.Contains("ATLC_COUNT"))
                {
                    ADGVAttendance.Columns["ATLC_COUNT"].Visible = false;


                }

                if (ADGVAttendance.Columns.Contains("STAM_LECTURES_COUNT"))
                {
                    ADGVAttendance.Columns["STAM_LECTURES_COUNT"].Visible = false;
                }

                if (ADGVAttendance.Columns.Contains("ATLC_IS_SCHEDULED"))
                {
                    ADGVAttendance.Columns["ATLC_IS_SCHEDULED"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("ATTD_LATE_MARK"))
                {
                    ADGVAttendance.Columns["ATTD_LATE_MARK"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("Column1"))
                {
                    ADGVAttendance.Columns["Column1"].ReadOnly = true;
                }


                //Set Header Text
                ADGVAttendance.Columns["Column1"].HeaderText = "Late Mark";
                ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                ADGVAttendance.Columns["ATTD_IN_TIME"].HeaderText = "In Time";
                ADGVAttendance.Columns["ATTD_OUT_TIME"].HeaderText = "Out Time";
                if (ADGVAttendance.Columns.Contains("ATTD_STATUS"))
                { ADGVAttendance.Columns["ATTD_STATUS"].HeaderText = "Status"; }
                ADGVAttendance.Columns["ATTD_IS_HOLIDAY"].HeaderText = "Holiday";
                ADGVAttendance.Columns["BRCH_NAME"].HeaderText = "Branch";

                //Format
                ADGVAttendance.Columns["ATTD_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVAttendance.Columns["ATTD_IN_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                ADGVAttendance.Columns["ATTD_OUT_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void populateData()
        {
            try
            {
                clearForm();

                if (objStudent == null)
                {
                    tabMain.Visible = false;
                    UICommon.WinForm.showStatus("No search found.\n\n Please enter valid Contact No", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    btnAddFacilities.Enabled = false;
                    cmdBrwseImg.Enabled = false;
                    linkLabel1.Enabled = false;
                    lnkClear.Enabled = false;
                    txtContctNo.Text = "";
                    txtContctNo.Focus();

                }
                else
                {
                    addColumns();
                    StudName.Text = objStudent.DisplayName;
                    cmdBrwseImg.Visible = true;
                    assignValueToControls(objStudent);
                    tabMain.Visible = true;
                    tabMain.SelectedIndex = 0;
                    btnAddFacilities.Enabled = true;
                    cmdBrwseImg.Enabled = true;
                    linkLabel1.Enabled = true;
                    lnkClear.Enabled = true;

                    showPersonnelDetails(objStudent);
                    showFeesDetails(objStudent);
                    ApplyPrevileges();
                    loadStudentFacilities(objStudent);
                    // displaying package tab when StudName.selectedIndexChange
                    tabMain.SelectedIndex = 3;

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void assignValueToControls(Info.Student objStudent)
        {
            try
            {
                lblAdmissionNo.Text = objStudent.AdmissionNo.ToString();
                lblSName.Text = objStudent.DisplayName;
                txtContctNo.Text = objStudent.ContactNo;
                if (objStudent.Course != null)
                {
                    lblRollNo.Text = objStudent.Course.RollNo;
                    lblStrm.Text = objStudent.Course.Standard.Stream.Name;
                    lblCourse.Text = objStudent.Course.Standard.StandardName;
                    lblBatch.Text = objStudent.Course.Batch.Name;
                }
                //lblAdmsnDate
                lblAdmsnDate.Text = Common.Formatter.FormatDate(objStudent.AdmissionDate);
                lblMmbrNo.Text = objStudent.MembershipNo;


                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objStudent.PhotoURL.ToString();
                try
                {
                    pbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(100, 100));
                }
                catch (Exception ex)
                {
                    pbPhoto.Image = Properties.Resources.img;
                }

                if (objStudent.Gender == "F")
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void clearFeesDetsils()
        {
            //lblPayStartDate.Text = "";
            lblTotalFees.Text = "";
            lblTtlDiscount.Text = "";
            label64.Text = "";
            label58.Text = "";
            //ADDED BY ASHVINI 4-1-2019
            //FOR reset pending fees amount
            lblPendingFees.Text = "";
            //end by ashvini4-1-
            ADGVInstDetails.DataSource = null;

        }


        private void loadStudentFacilities(Student objStudent)
        {
            try
            {
                cmbViewPackage.SelectedIndex = 1;
                if (objStudent.Facilities != null && objStudent.Facilities.Count > 0)
                {
                    //ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "D").ToList();
                    //if (ADGVStudentFacility.Rows.Count == 0)
                    //{
                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "A").ToList();
                    //}
                    formatFacilityGrid();

                }

                else
                {
                    MessageBox.Show("No Package for " + objStudent.ToString());
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void deleteFacilty(int studFacID)
        {
            int returnCode = BLL.StudentHandller.deleteFacility(studFacID, Program.LoggedInUser.BranchId);
            if (returnCode == 1)
            {
                UICommon.WinForm.showStatus("Package Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            else
            {
                UICommon.WinForm.showStatus("Error occured while deleting package", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
        }
        private void showExamDetails()
        {
            DataTable dtmarks = BLL.TestHandler.getStudentExamDetails(objStudent.AdmissionNo.ToString(), dtFrmDate.Value, dtToDate.Value);
            if (dtmarks.Rows.Count != 0)
            {

                ADGVExamDetails.DataSource = dtmarks.DefaultView;
            }
        }

        private void showPersonnelDetails(Info.Student objStudent)
        {
            try
            {
                txtMbrsNo.Text = objStudent.MembershipNo;
                txtAddress.Text = objStudent.Address;
                txtFName.Text = objStudent.Fname;
                txtMName.Text = objStudent.Mname;
                txtLName.Text = objStudent.Lname;
                txtBiometric.Text = objStudent.BiometricId.ToString();
                txtNewContact.Text = objStudent.ContactNo;
                txtEmailID.Text = objStudent.EmailID;
                lblSName.Text = objStudent.DisplayName;
               
                txtBloodgrp.Text = objStudent.BloodGroup;
                txtWght.Text = objStudent.Weight;
                txtBMI.Text = objStudent.BMI;
                txtheight.Text = objStudent.Height;
                txtRemark.Text = objStudent.Remark;
                cmbSource.Text = objStudent.Source;
                txtBiometric.Text = objStudent.BiometricId.ToString();
                //txtBMI.Text = objStudent.FatherContactNo;
                if (objStudent.Dob != null && (objStudent.Dob.Value >= dtpDOB.MinDate && objStudent.Dob.Value <= dtpDOB.MaxDate))
                {
                    dtpDOB.Value = objStudent.Dob.Value;
                }
                lblAdmsnDate.Text = Common.Formatter.FormatDate(objStudent.AdmissionDate);
                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objStudent.PhotoURL.ToString();

                try
                {

                    pbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                }
                catch (Exception ex)
                {
                    pbPhoto.Image = Properties.Resources.img;
                    Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for member : " + objStudent.AdmisionNo, Common.ErrorLevel.INFORMATION);
                }
                // txtBloodgrp.Text = objStudent.FatherName;


                //GetBatch();
                cmbBatch.Text = "";
                cmbBatch.Items.Clear();
                if (objStudent.Course != null)
                {
                    List<Batch> lstBtch = BLL.StandardHandller.GetBatches(objStudent.Course.Standard.Standardid, Program.LoggedInUser.BranchId);

                    foreach (Batch objbatch in lstBtch)
                    {
                        cmbBatch.Items.Add(new ComboItem(objbatch.id, objbatch.Name));
                    }
                    cmbBatch.Text = objStudent.Course.Batch.Name;
                }

                else
                {
                    cmbBatch.Items.Add(new ComboItem(0, "NA"));
                    cmbBatch.SelectedIndex = 0;
                }
                //cmbBatch.Text = (objStudent.Course.Batch as ComboItem).name;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void showFeesDetails(Info.Student objStudent)
        {
            try
            { //ADDED BY ASHVINI 4-1-2019
              //FOR displaying pending fees total 
                lblpending.Text = Common.Formatter.FormatCurrency((objStudent.Fees.Installments.Sum(ttl => ttl.InstAmount) - objStudent.Fees.Installments.Sum(paid => paid.AmntPaid) - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)));
                //end by ashvini04-01

                //lblPayStartDate.Text = (objStudent.Fees.PaymentStartDate != DateTime.MinValue) ? objStudent.Fees.PaymentStartDate.ToString(Common.Formatter.DateFormat) : "";
                lblTotalFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.TotalFees);
                lblTtlDiscount.Text = Common.Formatter.FormatCurrency(objStudent.Fees.FeesPaid);
                label58.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(inst => inst.CancelledAmount));
                //lblPendingFees.Text = (objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)).ToString();
                //lblTtlDiscount.Text = objStudent.Fees.FeesDiscount.ToString();
                label64.Text = Common.Formatter.FormatCurrency((objStudent.Fees.Installments.Sum(ttl => ttl.InstAmount) - objStudent.Fees.Installments.Sum(paid => paid.AmntPaid) - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)));
                lblPendingFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount));
                // lblPendingFees.Text =Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount));
                lstInstallmentDetails = objStudent.Fees.Installments;
                // ADGVInstDetails.DataSource = objStudent.Fees.Installments.ToDataTable<InstallmentDetail>();
                ADGVInstDetails.DataSource = lstInstallmentDetails.Where(installment => installment.Status == "NP" || installment.Status == "PARTIAL" || installment.Status == "PAID").ToList<InstallmentDetail>();
                formatFeesGrid();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void loadStudent(int admissionNo = -1)
        {
            try
            {
                if (admissionNo == -1)
                {
                    admissionNo = (objStudent != null) ? objStudent.AdmissionNo : -1;
                }

                if (admissionNo == -1)
                {
                    throw new Common.Exceptions.RecordNotFoundException("Student details not exists");
                }

                objStudent = BLL.StudentHandller.GetStudent(admissionNo, null, null, null, Program.LoggedInUser.BranchId);
                populateData();
                ApplyPrevileges();
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void getCumulativeTransaction()
        {
            try
            {
                DataTable dtCumulative = BLL.FeesHandller.getCumulative(objStudent.AdmissionNo, dtpReceiptFrmDate.Value, dtpReceiptToDate.Value);
                Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                objFeeData.BranchId = objStudent.Branch.BranchName.ToString();

                objFeeData.PaymentDate = dtpReceiptToDate.Value;
                objFeeData.FromDate = dtpAttdFromDate.Value;

                //objFeeData.ReceiptNo = dtCumulative.Rows[0].ItemArray[16].ToString();

                objFeeData.RollNo = objStudent.RollNo;
                objFeeData.RupeesInWord = Utility.currencyInWords(Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[0]));
                //objFeeData.ServiceTax = dtTransaction.Rows[0].ItemArray[17];
                objFeeData.Standard = objStudent.Course.Standard.StandardName + "-" + objStudent.Course.Standard.Stream.Name;
                objFeeData.StudentName = objStudent.DisplayName;
                objFeeData.FatherContactNo = objStudent.ContactNo;
                objFeeData.EmailId = objStudent.EmailID;
                objFeeData.ParentName = objStudent.ParentName;
                objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);
                objFeeData.TotalFees = Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[0].ToString());
                objFeeData.SirName = Info.SysParam.getValue<String>(SysParam.Parameters.SIR_NAME);
                objFeeData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                objFeeData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                objFeeData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                objFeeData.CmpnyPanNO = Info.SysParam.getValue<String>(SysParam.Parameters.COMPANY_PAN_NO);
                objFeeData.CINNO = Info.SysParam.getValue<String>(SysParam.Parameters.CIN_NO);
                objFeeData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                objFeeData.ServiceTaxNo = Info.SysParam.getValue<String>(SysParam.Parameters.SERVICE_TAX_NO);
                objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;
                objFeeData.clasContct = Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO);
                objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount;
                if (objFeeData.OutstandingAmount == decimal.MinusOne)
                {
                    objFeeData.OutstandingAmount = decimal.Zero;
                }
                objFeeData.MembershipNo = objStudent.MembershipNo;

                objFeeData.TuitionFees = objStudent.Fees.TuitionAmnt - objFeeData.ServiceTax;
                //objFeeData.Cheques = objTransaction.Cheques;
                //objFeeData.PaymentMode = objTransaction.PaymentMode.ToString();

                objFeeData.CashPayment = Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[1].ToString());
                objFeeData.ChequePayment = Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[2].ToString());

                //NumberToMonth.Months installmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objTransaction.Month.ToString());
                NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                //objFeeData.InstallmentMonths = installmonth.ToString();
                objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();
                //Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT", "Fee_Receipt_" + objStudent.AdmissionNo + "_" /*+ objTransaction.ReceiptNo.Replace(@"/", "-")*/);
                Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT_PRO", "Fee_Receipt_" + objStudent.AdmissionNo + "_" + null, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Validations
        private void assignValidationEvents()
        {
            txtContctNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            //txtBMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtNewContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtWght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            // txtBloodgrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            // txtheight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }
        private bool validatePersonalInfo()
        {
            try
            {

                if (txtFName.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please fill student first name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                //  else if (txtBMI.Text.Length == 0)
                //  {
                //     UICommon.WinForm.showStatus("Please Enter BMI.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                //     txtBMI.Focus();
                //     return false;
                //  }


                else if (txtNewContact.Text.Length != 0 && txtNewContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Phone Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtNewContact.Focus();
                    return false;
                }
                else if (txtEmailID.Text.Length > 0)
                {
                    bool isEmail = Regex.IsMatch(txtEmailID.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                    if (!isEmail)
                    {
                        UICommon.WinForm.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtEmailID.Focus();
                        return false;
                    }
                    return true;
                }
                // else if (txtMbrsNo.Text.Length == 0)
                // {
                //  txtMbrsNo.Text = "UnAssigned";
                //  txtMbrsNo.Focus();
                //   return true;
                //  }
                return true;
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

                return false;
            }
        }
        private void AssignEvents()
        {

            ADGVExamDetails.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVExamDetails.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVAttendance.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVAttendance.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVInstDetails.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVInstDetails.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVStudentFacility.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVStudentFacility.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        private void clearForm()
        {
            bAllowIndexChange = false;
            lblAdmissionNo.Text = "";
            txtContctNo.Text = "";
            txtAddress.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtNewContact.Text = "";
            txtEmailID.Text = "";
            lblSName.Text = "";
            lblRollNo.Text = "NA";
            lblStrm.Text = "NA";
            lblCourse.Text = "NA";
            txtBMI.Text = "";
            dtpDOB.Text = "";
            lblAdmsnDate.Text = "";
            lblBatch.Text = "NA";
            txtBloodgrp.Text = "";
            pbPhoto.Image = Properties.Resources.img;
            picture = false;

            //lblPayStartDate.Text = "";
            lblTotalFees.Text = "";
            lblTotalFees.Text = "";
            lblPendingFees.Text = "";
            lblMmbrNo.Text = "";
            ADGVExamDetails.DataSource = null;
            ADGVAttendance.DataSource = null;
            ADGVInstDetails.DataSource = null;
            ADGVStudentFacility.DataSource = null;
            bAllowIndexChange = true;
            txtMbrsNo.Text = "";
            // cmbStud.SelectedIndex = 0;

        }
        #endregion
        private void ADGVInstDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVInstDetails, e);
        }

        private void ADGVAttendance_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVAttendance, e);
        }

        private void ADGVStudentFacility_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVStudentFacility, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ADGVExamDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatgrid();


                foreach (DataGridViewRow row in ADGVExamDetails.Rows)
                {
                    if ((Convert.ToInt32(row.Cells[7].Value) == 10))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 4))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }

                    else if ((Convert.ToInt32(row.Cells[7].Value) == 20))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 8))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                    else
                          if ((Convert.ToInt32(row.Cells[7].Value) == 30))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 11))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                    else
                           if ((Convert.ToInt32(row.Cells[7].Value) == 40))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 14))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                    else
                       if ((Convert.ToInt32(row.Cells[7].Value) == 50))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 17))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                    else
                            if ((Convert.ToInt32(row.Cells[7].Value) == 80))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 24))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                    else
                            if ((Convert.ToInt32(row.Cells[7].Value) == 100))
                    {
                        if ((Convert.ToInt32(row.Cells[8].Value) < 35))
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                }
                foreach (DataGridViewRow adrow in ADGVExamDetails.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVExamDetails.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void formatdate()
        {
            try
            {

                UICommon.WinForm.formatDateTimePicker(dtFrmDate);
                UICommon.WinForm.formatDateTimePicker(dtToDate);
                UICommon.WinForm.setDate(dtFrmDate, dtToDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void formatgrid()
        {
            try
            {
                //For hiding columns
                ADGVExamDetails.Columns["STMT_FNAME"].Visible = false;
                ADGVExamDetails.Columns["STRM_NAME"].Visible = false;
                ADGVExamDetails.Columns["STD_NAME"].Visible = false;
                ADGVExamDetails.Columns["TEST_ID"].Visible = false;

                //For changing headertext
                ADGVExamDetails.Columns["TEST_NAME"].HeaderText = "TestName";
                ADGVExamDetails.Columns["TSUB_DATETIME"].HeaderText = "TestDate";
                ADGVExamDetails.Columns["SUBM_NAME"].HeaderText = "Subject";
                ADGVExamDetails.Columns["TSUB_MARKS"].HeaderText = "TotalMarks";
                ADGVExamDetails.Columns["STTD_MARKS_OPTAINED"].HeaderText = "MarksObtained";

                //to format date
                ADGVExamDetails.Columns["TSUB_DATETIME"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ADGVExamDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVExamDetails, e);
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private void dtFrmDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                loaddata();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                loaddata();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void loaddata()
        {
            try
            {
                ADGVExamDetails.DataSource = null;

                string Fromdate = dtFrmDate.Value.ToShortDateString();
                string Todate = dtToDate.Value.ToShortDateString();

                DataTable dtmarks = BLL.TestHandler.getStudentExamDetails(objStudent.AdmissionNo.ToString(), Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate));

                ADGVExamDetails.DataSource = dtmarks;
                AssignEvents();
                //   UICommon.WinForm.setDate(dtFrmDate, dtToDate);
                //  UICommon.WinForm.formatDateTimePicker(dtToDate);
                //  UICommon.WinForm.formatDateTimePicker(dtFrmDate);
                // cmbTests.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbTests_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (allow == true)
                {

                    string testID = (cmbTests.SelectedItem as ComboItem).strKey;

                    if (testID != "0")
                    {
                        DataTable dt = TestHandler.getTestDetails(objStudent.AdmissionNo.ToString(), testID);
                        ADGVExamDetails.DataSource = null;
                        ADGVExamDetails.DataSource = dt;
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        public void populateOnlyTest()
        {

            dtExam = new DataTable();
            dtExam = TestHandler.getTestForstudent(objStudent.AdmissionNo.ToString(), branchId).AsEnumerable()
                                            .GroupBy(r => new { ID = r.Field<int>("TEST_ID"), Name = r.Field<string>("TEST_NAME") })
                                            .Select(g => new
                                            {
                                                AdmissionNo = g.Key.ID,
                                                Name = g.Key.Name,
                                            }).ToList().ToDataTable();
            ;



            cmbTests.Items.Clear();

            Info.ComboItem objAllTest = new Info.ComboItem(-1, "Select Test");
            cmbTests.Items.Add(objAllTest);

            foreach (DataRow dr in dtExam.Rows)
            {
                cmbTests.Items.Add(new ComboItem(Convert.ToInt32(dr.ItemArray[0]), dr.ItemArray[1].ToString()));
            }

            cmbTests.SelectedIndex = 0;
            cmbTests.SelectedItem = objAllTest;
        }

        private void btnPayFees_Click(object sender, EventArgs e)
        {
            try
            {
                FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
                objRedirect.LoadFeeDetailsFromRegistration(objStudent);
                //UICommon.FormFactory.GetForm(UICommon.Forms.FrmFeesPayment).Visible = true;
                objRedirect.Visible = true;


            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }


        }


        private void button2_Click(object sender, EventArgs e)
        {
            //UICommon.FormFactory.GetForm(UICommon.Forms.FrmAnyFollowUp).Visible = true;
            try
            {
                FrmAnyFollowUp objForm = new FrmAnyFollowUp();
                objForm.setValue(objStudent);
                objForm.ShowDialog();
                loadFolloup(objStudent.AdmissionNo, branchId);
            }
            catch (Exception ex)
            {
                WinForm.showStatus("Please add Package", null, null);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                ADGVFollowup.DataSource = FollowupHandler.getFollowupAny(objStudent.AdmissionNo, branchId);
            }
        }

        /// <summary>
        /// Formats FollowUp Tab Grid.
        /// </summary>
        private void formatADGVFollowUp()
        {
            try
            {
                //Hiding Columns.
                ADGVFollowup.Columns["FOLU_ID"].Visible = false;
                ADGVFollowup.Columns["ID"].Visible = false;
                ADGVFollowup.Columns["FOLU_REF_NO"].Visible = false;
                ADGVFollowup.Columns["FOLU_BRANCH_ID"].Visible = false;
                ADGVFollowup.Columns["FOLU_CRTD_AT"].Visible = true;
                ADGVFollowup.Columns["FOLU_CRTD_BY"].Visible = false;
                ADGVFollowup.Columns["FOLU_UPDAT_BY"].Visible = false;
                ADGVFollowup.Columns["FOLU_UPDT_AT"].Visible = false;
                ADGVFollowup.Columns["FOLU_DLTD_AT"].Visible = false;
                ADGVFollowup.Columns["FOLU_DLTD_BY"].Visible = false;
                ADGVFollowup.Columns["FOLU_STATUS"].Visible = false;

                //Changing HeaderText.
                ADGVFollowup.Columns["FOLU_CRTD_AT"].HeaderText = "Start Date";
                ADGVFollowup.Columns["FOLU_CRTD_AT"].DisplayIndex = 1;

                ADGVFollowup.Columns["FOLU_FOLLOWUP_TYPE"].HeaderText = "Type";
                ADGVFollowup.Columns["FOLU_FOLLOWUP_TYPE"].DisplayIndex = 3;
                ADGVFollowup.Columns["FOLU_DATE"].HeaderText = "Next Followup";
                ADGVFollowup.Columns["FOLU_DATE"].DisplayIndex = 7;
                ADGVFollowup.Columns["FOLU_By"].HeaderText = "Followup By";
                ADGVFollowup.Columns["FOLU_By"].DisplayIndex = 6;
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].HeaderText = "Decsription";
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].Width = 200;
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].DisplayIndex = 4;
                ADGVFollowup.Columns["FOLU_MEDIUM"].HeaderText = "Medium";

                ADGVFollowup.Columns["FOLU_MEDIUM"].DisplayIndex = 5;
                //Formatting Date.
                ADGVFollowup.Columns["FOLU_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat; ;
                ADGVFollowup.Columns["FOLU_CRTD_AT"].DefaultCellStyle = UICommon.WinForm.GridDateFormat; ;




                foreach (DataGridViewRow check in ADGVFollowup.Rows)
                {
                    if (Convert.ToString(check.Cells["FOLU_STATUS"].Value) == "CLOSE")
                    {
                        check.Cells[0].Value = true;
                    }
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVFollowup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVFollowUp();
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


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                FrmCaptureImage capture = new FrmCaptureImage();
                capture.ShowDialog();

                if (capture.capturedImage != null)
                {
                    //pbPhoto.Height = capture.capturedImage.Height;
                    //pbPhoto.Width = capture.capturedImage.Width;
                    //pbPhoto.Height = 108;
                    //pbPhoto.Width = 109;
                    pbPhoto.Image = capture.capturedImage;

                    pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    // pbPhoto.Dock = DockStyle.Fill;
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
                if (allowIndexChnge == true)
                {
                    int BatchId = ((cmbBatch.SelectedItem as ComboItem).key);
                }
                allowIndexChnge = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVFollowup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (BLL.FollowupHandler.updateFollowStatus(Convert.ToInt32(ADGVFollowup.Rows[e.RowIndex].Cells[1].Value), Convert.ToBoolean(ADGVFollowup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true ? "OPEN" : "CLOSE"))
                        {
                            UICommon.WinForm.showStatus("Status Updated", sCaption, this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //button1.Text;
                lstInstallmentDetails = objStudent.Fees.Installments;
                if (btnCancelled.Text == "Show Cancelled")
                {
                    ADGVInstDetails.DataSource = lstInstallmentDetails.Where(installment => installment.Status == "CNCLD").ToList<InstallmentDetail>();
                    btnCancelled.Text = "Show Active";
                }
                else
                {
                    ADGVInstDetails.DataSource = lstInstallmentDetails.Where(installment => installment.Status == "NP" || installment.Status == "Partial Payment" || installment.Status == "PAID").ToList<InstallmentDetail>();
                    btnCancelled.Text = "Show Cancelled";
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtFContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBMI.Text.Length >= 10)
            {
                if (e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtNewContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNewContact.Text.Length >= 10)
            {
                if (e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }



        private void txtheight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double weight;
                double height;
                double BMI;
                if (txtheight.Text == "")
                {
                    txtBMI.Text = "";
                }
                if (txtheight.Text.Length != 0 && txtWght.Text.Length != 0)
                {


                    weight = Convert.ToDouble(txtWght.Text);
                    height = Convert.ToDouble(txtheight.Text);
                    BMI = Convert.ToDouble(weight / (height * height));
                    //String.Format("{0:0.00}", BMI.ToString());
                    BMI = System.Math.Round(BMI, 2);
                    txtBMI.Text = BMI.ToString();
                    txtBMI.Enabled = false;
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Enter Value", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVFollowup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            WinForm.ADGVSerialNo(ADGVFollowup, e);
        }



        private void ADGVInstDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // formatFeesGrid();
                foreach (DataGridViewRow adrow in ADGVInstDetails.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVInstDetails.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ADGVAttendance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVAttendance.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVAttendance.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ADGVStudentFacility_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVStudentFacility.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVStudentFacility.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ADGVReceipt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVReceipt.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVReceipt.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ADGVInvoice_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVReceipt.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVInvoice.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void lnlTotalFees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmPackagePopup objpopup = new FrmPackagePopup();
                objpopup = UICommon.FormFactory.GetForm(UICommon.Forms.FrmPackagePopup) as FrmPackagePopup;
                objpopup.SetData(objStudent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {


        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                panelReceipt.Height = 316;
                panelReceipt.Width = 420;
                ADGVReceipt.Width = 418;
                ADGVReceipt.Height = 316;
                ADGVReceipt.Dock = DockStyle.Fill;
                panelInvoiceGenerate.Visible = true;
                ADGVInvoice.Visible = true;
                ADGVInvoice.DataSource = BLL.FeesHandller.getInvoice(objStudent.AdmissionNo);
                formatInvoice();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtheight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if ((Convert.ToInt32(e.KeyChar) >= 65) && (Convert.ToInt32(e.KeyChar) <= 122))
                {
                    e.Handled = true;
                }
                // if the key is anything other than a letter or a backspace, do not accept it
                else if ((Keys)e.KeyChar != Keys.Back)
                {

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //ADDED BY ASHVINI 4-1-2019
        //for displaying payment history
        private void lnklblviewHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrmPackagePopup objpopup = new FrmPackagePopup();
            objpopup = UICommon.FormFactory.GetForm(UICommon.Forms.FrmPackagePopup) as FrmPackagePopup;
            objpopup.SetData(objStudent);
        }
        //end by ashvini 040-01

        //ADDED BY ASHVINI 4-1-2019
        //FOR adding pay fees button in package tab
        private void btnPayfee_Click(object sender, EventArgs e)
        {
            FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
            objRedirect.LoadFeeDetailsFromRegistration(objStudent);
            //UICommon.FormFactory.GetForm(UICommon.Forms.FrmFeesPayment).Visible = true;
            objRedirect.Visible = true;
        }

        //ADDED BY ASHVINI 21-1-2019
        //for getting new measurement

        private void Get_Measurement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMeasurement obj = new FrmMeasurement();
            obj.setValue(objStudent);
            obj.ShowDialog();
            MeasurementGrid.DataSource = BLL.StudentHandller.getmeasurementsOfStudent(dtpfrm.Value, dtptod.Value, objStudent.AdmissionNo, branchId);


        }
        //added by ashvini on 30-03-2019
        //for converting attendence data to pdf
        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();

                getParameter.name = "Name:- " + objStudent.Fname.ToString();
                getParameter.Contact = "Contact No:- " + objStudent.ContactNo.ToString();
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpAttdFromDate.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpAttdToDate.Value);
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Attendence Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                getParameter.Present = "Present:- " + Convert.ToInt32(lblPresent.Text);
                getParameter.Absent = "Absent:- " + Convert.ToInt32(lblAbsent.Text);
                getParameter.Total = "Total Hours" + Convert.ToInt32(lblHours.Text);
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ADGVAttendance.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Attendence Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(ADGVAttendance, pathTosave, getParameter);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();


                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpfrm.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtptod.Value);
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Measurement Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (MeasurementGrid.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Measurement Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(MeasurementGrid, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
            objRedirect.LoadFeeDetailsFromRegistration(objStudent);
            //UICommon.FormFactory.GetForm(UICommon.Forms.FrmFeesPayment).Visible = true;
            objRedirect.Visible = true;
        }


        private void printInvoice(int invoiceId, int transactionId = -1, int facilityId = -1)
        {
            try
            {
                DataTable dtTransaction = new DataTable();
                List<Transaction> transactions;
                Invoice objInvoice = FeesHandller.loadInvoiceDetails(invoiceId);
                StudentFacility facility;

                decimal amountPaid = 0;
                if (!transactionId.Equals("-1"))
                {
                    //Get transactio details for facility
                    dtTransaction = BLL.FeesHandller.getTransactionReprint(transactionId.ToString(), facilityId);
                    transactions = Info.Transaction.getTransactions(dtTransaction);
                    facility = FeesHandller.getTransactionFacility(transactionId);
                    amountPaid = transactions.Sum(t => t.Amount);
                }
                else
                {
                    facility = objStudent.Facilities.Where(fac => fac.Id == facilityId).FirstOrDefault();
                    amountPaid = objInvoice.amount;
                }

                InvoiceDetails currentInvoiceDetails = objInvoice.invoiceItems[0];



                if (amountPaid > currentInvoiceDetails.amount - currentInvoiceDetails.discount)
                {
                    amountPaid = currentInvoiceDetails.amount - currentInvoiceDetails.discount;
                }
                Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                objFeeData.BranchId = objStudent.Branch.BranchId.ToString();
                objFeeData.PaymentDate = objInvoice.invoiceDate.Value;

                objFeeData.ReceiptNo = objInvoice.invoiceNo;
                objFeeData.RollNo = objStudent.RollNo;
                objFeeData.RupeesInWord = Utility.currencyInWords(currentInvoiceDetails.amount - currentInvoiceDetails.discount);
                objFeeData.ServiceTax = SysParam.getValue<int>(SysParam.Parameters.SERVICE_TAX);

                objFeeData.StudentName = objStudent.Fname + ' ' + objStudent.Lname;
                objFeeData.FatherContactNo = objStudent.ContactNo;
                objFeeData.EmailId = objStudent.EmailID;
                objFeeData.ParentName = objStudent.ParentName;


                objFeeData.TotalFees = currentInvoiceDetails.amount - currentInvoiceDetails.discount;
                objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);
                objFeeData.SirName = Info.SysParam.getValue<String>(SysParam.Parameters.SIR_NAME);
                objFeeData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                objFeeData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                objFeeData.CmpnyPanNO = Info.SysParam.getValue<String>(SysParam.Parameters.COMPANY_PAN_NO);
                objFeeData.CINNO = Info.SysParam.getValue<String>(SysParam.Parameters.CIN_NO);
                objFeeData.ServiceTaxNo = Info.SysParam.getValue<String>(SysParam.Parameters.SERVICE_TAX_NO);
                objFeeData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                objFeeData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                objFeeData.Email = Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS);
                objFeeData.OwnerNo = Info.SysParam.getValue<String>(SysParam.Parameters.OWNER_NOS);
                objFeeData.MainAdd = Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS);
                objFeeData.clasContct = Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO);
                objFeeData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;
                objFeeData.AmountPaid = amountPaid;


                objFeeData.OutstandingAmount = objFeeData.TotalFees - amountPaid;

                if (Math.Sign(objFeeData.OutstandingAmount) == -1)
                {
                    objFeeData.OutstandingAmount = decimal.Zero;
                }
                objFeeData.MembershipNo = objStudent.MembershipNo;

                objFeeData.ChequePayment = 0;
                objFeeData.AdmsnNo = objStudent.AdmisionNo;
                NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();

                objFeeData.Address = objStudent.Address;
                objFeeData.ContactNo = objStudent.ContactNo;
                objFeeData.FatherCntct = objStudent.FatherContactNo;
                objFeeData.DOB = objStudent.Dob;
                objFeeData.duration = objStudent.FeesPackage.PackageDuration.ToString();
                objFeeData.Batch = objStudent.Batch.BatchDesc;
                objFeeData.stud_photo = objStudent.PhotoURL;
                objFeeData.Adhar = objStudent.AdharCard;
                objFeeData.PackageName = currentInvoiceDetails.packageName;
                objFeeData.PackageAmount = currentInvoiceDetails.actualAmount;
                objFeeData.CashPayment = 0;
                objFeeData.SACCode = currentInvoiceDetails.SACCode;
                objFeeData.TuitionFees = currentInvoiceDetails.actualAmount;
                objFeeData.DisCount = currentInvoiceDetails.discount;
                objFeeData.ClientGSTNo = objStudent.GSTNo;

                objFeeData.CGST = currentInvoiceDetails.CGSTAmount.ToString();
                objFeeData.NonTaxAmount = currentInvoiceDetails.actualAmount.ToString();
                objFeeData.FacilityId = facilityId;
                objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.Installments.Sum(outs => outs.Discount);
                objFeeData.TransactionId = Convert.ToInt32(transactionId);

                if (facility != null)
                {
                    objFeeData.StartDate = facility.FromDate;
                    objFeeData.EndDate = facility.ToDate;
                }

                PrintingConfig objPrintngConfig = new PrintingConfig();

                objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                objPrintngConfig.PrintReport = false;
                objPrintngConfig.reportType = "INVOICE_REPORT";
                objPrintngConfig.SaveReport = false;
                objPrintngConfig.ViewReport = true;


                if (SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE) == "FEE_RECEIPT")
                {
                    objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE_REPORT");
                }
                else if (SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE) == "INVOICE_REPORT")
                {
                    objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE_REPORT");
                }
                else
                {
                    objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE");
                }

                objPrintngConfig.exportFileName = objPrintngConfig.ReportName + "_" + objStudent.AdmissionNo + "_" + objInvoice.invoiceNo.Replace(@"/", "-");
                objPrintngConfig.sendSMS = false;
                objPrintngConfig.sendEmail = false;

                FrmReportViewer frmRprtViewer = new FrmReportViewer();
                frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void txtContctNo_Click(object sender, EventArgs e)
        {

        }

        private void ADGVAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ADGVStudentFacility_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
//end by ashvini21-01

//end by ashvini on 30-03-2019








