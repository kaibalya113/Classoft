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

namespace ClassManager.WinApp.Asset
{
    public partial class FrmStudentDetails : FrmParentForm
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

        /// <summary>
        /// Student object loaded when user search for a student
        /// </summary>
        static Info.Student objStudent;

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
                lstStudentDetails.Add(new ComboItem(-1, "Select Member"));

                lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(branchId));

                StudName.DataSource = new List<Student>();
                StudName.DisplayMember = "name";
                StudName.DataSource = lstStudentDetails;

                // then you have to set the PropertySelector like this:
                StudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);
                if (this.IsMdiChild != true)
                {
                    string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    if (name == "Gym"  || name == "Dance")
                    {
                        tabMain.TabPages.Remove(tabPage10);
                    }
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

                    UICommon.WinForm.setDate(dtpfrom, dtpto);

                    ofdImage.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";
                    dtpDOB.MaxDate = DateTime.Now.AddYears(-2);

                    List<ComboItem> lstStudentDetails = new List<ComboItem>();
                    List<ComboItem> lstBatch = new List<ComboItem>();
                    //lstStudentDetails.Add(new ComboItem(-1, "Select Student"));

                    lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(branchId));




                    StudName.DataSource = new List<Student>();
                    StudName.DisplayMember = "name";
                    StudName.DataSource = lstStudentDetails;
                    StudName.SelectedIndex = -1;

                    // then you have to set the PropertySelector like this:
                    StudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);



                    assignValidationEvents();
                    AssignEvents();
                    clearForm();
                    btnAddFacilities.Enabled = false;
                    cmdBrwseImg.Enabled = false;
                    linkLabel1.Enabled = false;
                    lnkClear.Enabled = false;
                    bAllowIndexChange = true;
                    tabMain.Visible = false;
                    formatForm();
                    allow = true;
                    formatdate();
                    ApplyPrevileges();
                    string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    if (name == "Gym" || name == "Dance")
                    {
                        tabMain.TabPages.Remove(tabPage10);
                    }
                    loadFields();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void loadFields()
        {
            try
            {
                string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
                if (check == "")
                {
                    cmbField.Visible = false;
                    lblcounselor.Visible = false;
                }
                else
                {
                    string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                    foreach (String value in items)
                    {
                        cmbField.Items.Add(value);
                    }
                }
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

                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;

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
                objStudent = StudentHandller.GetStudent(null, txtContctNo.Text, null, null, Program.LoggedInUser.BranchId);
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

                    ObjStudentMaster.FatherName = txtFFname.Text;
                    ObjStudentMaster.FatherContactNo = txtFContact.Text;
                    ObjStudentMaster.Gender = ((rbMale.Checked) ? "M" : "F");
                   
                    ObjStudentMaster.BloodGroup = "";
                    ObjStudentMaster.BMI = "";
                    ObjStudentMaster.Weight = "";
                    ObjStudentMaster.Height = "";
                   
                    ObjStudentMaster.BiometricId = Convert.ToInt32(txtBiometric.Text);
                    ObjStudentMaster.ImgPhoto = pbPhoto.Image;
                    ObjStudentMaster.AdmissionStandard = (Standard)ObjStudentMaster.AdmissionStandard;
                    ObjStudentMaster.batchID = ((cmbBatch.SelectedItem as ComboItem).key);


                    //changedfor asset
                    ObjStudentMaster.MembershipNo = cmbQualification.SelectedItem.ToString();
                    ObjStudentMaster.AdharCard = txtschoolName.Text.ToString();
                    //if (rbMWF.Checked)
                    //{
                    //    ObjStudentMaster.Remark = "MWF";
                    //}
                    //else if (rbTTS.Checked)
                    //{
                    //    ObjStudentMaster.Remark = "TTS";
                    //}
                    //else if (rbsunday.Checked)
                    //{
                    //    ObjStudentMaster.Remark = "Sunday Special";
                    //}
                    ObjStudentMaster.Remark = batchCmb.SelectedItem.ToString();
                    ObjStudentMaster.Category = cmbCategory.SelectedItem.ToString();
                    
                    ObjStudentMaster.counselor = cmbField.SelectedItem == null ? "" : cmbField.SelectedItem.ToString() ;
                    //

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

        private void SgstCmbStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bAllowIndexChange && StudName.SelectedIndex >= 0 && StudName.SelectedItem != null)
                {
                    loadStudent((StudName.SelectedItem as ComboItem).key);
                }
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
                    UICommon.WinForm.showStatus("No search found.\n\n Please enter valid Contact No", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
                    else if (tabMain.SelectedIndex == 6)
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
                    }
                    else if (tabMain.SelectedIndex == 5)
                    {
                        loadFolloup(objStudent.AdmissionNo, branchId);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

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

                    if (e.ColumnIndex == ADGVStudentFacility.Columns["btnDelete"].Index)
                    {

                        foreach (DataGridViewRow facilty in ADGVStudentFacility.Rows)
                        {
                            if (facilty.Cells[0].Selected)
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
                                    UICommon.WinForm.showStatus("Already deactivated.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                }
                            }
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
                                }

                                if (packagetype != "INSTALLMENT")
                                {
                                    UICommon.WinForm.showStatus("Package Renewed Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
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
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        DataTable dtTransaction = BLL.FeesHandller.getTransactionReprint(Convert.ToString(ADGVReceipt.Rows[e.RowIndex].Cells[4].Value));

                        Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                        objFeeData.BranchId = objStudent.Branch.BranchName.ToString();

                        objFeeData.PaymentDate = Convert.ToDateTime(dtTransaction.Rows[0].ItemArray[3].ToString());

                        objFeeData.ReceiptNo = dtTransaction.Rows[0].ItemArray[16].ToString();
                        objFeeData.RollNo = objStudent.RollNo;
                        objFeeData.RupeesInWord = Utility.currencyInWords(Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[5]));
                        objFeeData.Standard = objStudent.Course.Standard.StandardName + "-" + objStudent.Course.Standard.Stream.Name;
                        objFeeData.StudentName = objStudent.DisplayName;
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
                        objFeeData.ServiceTaxNo = Info.SysParam.getValue<String>(SysParam.Parameters.SERVICE_TAX_NO);
                        objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                        objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                        objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;
                        //objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount;
                        objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.Installments.Sum(outs => outs.Discount);
                        if (objFeeData.OutstandingAmount == decimal.MinusOne)
                        {
                            objFeeData.OutstandingAmount = decimal.Zero;
                        }
                        objFeeData.MembershipNo = objStudent.MembershipNo;


                        objFeeData.TransactionId = Convert.ToInt32(dtTransaction.Rows[0].ItemArray[0]);
                        objFeeData.TuitionFees = objStudent.Fees.TuitionAmnt - objFeeData.ServiceTax;
                        //objFeeData.Cheques = objTransaction.Cheques;
                        //objFeeData.PaymentMode = objTransaction.PaymentMode.ToString();
                        objFeeData.Adhar = objStudent.AdharCard;
                        objFeeData.CashPayment = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[30].ToString());
                        objFeeData.ChequePayment = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[29].ToString());
                        objFeeData.Batch = objStudent.Course.Batch.Name;
                        objFeeData.StartDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_FROM_DATE"].ToString());
                        objFeeData.EndDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_TO_DATE"].ToString());
                        objFeeData.BatchDays = objStudent.Remark;
                        //NumberToMonth.Months installmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objTransaction.Month.ToString());
                        NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                        //objFeeData.InstallmentMonths = installmonth.ToString();
                        objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();

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
                        frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
                        FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;
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
                StringBuilder filterStatus = new StringBuilder();
                if (cmbViewPackage.SelectedIndex == 1)
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "A").ToList();
                    ADGVStudentFacility.Columns["btnRenew"].Visible = false;
                    ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                }
                else if (cmbViewPackage.SelectedIndex == 2)
                {

                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "D").ToList();
                    ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                    ADGVStudentFacility.Columns["btnRenew"].Visible = true;

                }
                //To View Expired Facilities.Mohan(14-Aug-2017).
                else if (cmbViewPackage.SelectedIndex == 3)
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "E").ToList();
                    ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                    ADGVStudentFacility.Columns["btnRenew"].Visible = true;

                }

                //Mohan(14-Aug-2017).
                else
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities;
                    ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                    ADGVStudentFacility.Columns["btnRenew"].Visible = true;
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
                DataGridViewButtonColumn btnRepntReceipt = new DataGridViewButtonColumn();
                btnRepntReceipt.HeaderText = "Reprint";
                btnRepntReceipt.Text = "Reprint";
                btnRepntReceipt.Name = "Reprint";
                btnRepntReceipt.DefaultCellStyle.NullValue = "Reprint";
                ADGVReceipt.Columns.Insert(0, btnRepntReceipt);
                // UICommon.FormFactory.GetForm(UICommon.Forms)
            }


            //formatting HeaderText
            ADGVReceipt.Columns["TRNC_AMOUNT"].HeaderText = "Amount";
            ADGVReceipt.Columns["TRNC_DATE"].HeaderText = "PaymentDate";
            ADGVReceipt.Columns["TRNC_RECEIPT_NO"].HeaderText = "ReceiptNo";


            //formatting Date
            ADGVReceipt.Columns["TRNC_DATE"].DefaultCellStyle.Format = Formatter.DateFormat;

            //Hiding Columns
            ADGVReceipt.Columns["TRNC_ID"].Visible = false;
        }
        private void formatFeesGrid()
        {
            try
            {
                //Order column
                ADGVInstDetails.Columns["InstDate"].DisplayIndex = 0;
                ADGVInstDetails.Columns["InstAmount"].DisplayIndex = 1;
                ADGVInstDetails.Columns["AmntPaid"].DisplayIndex = 2;
                ADGVInstDetails.Columns["PaymentDate"].DisplayIndex = 3;
                ADGVInstDetails.Columns["Discount"].DisplayIndex = 4;
                ADGVInstDetails.Columns["Description"].DisplayIndex = 5;
                //ADGVInstDetails.Columns["Facility"].DisplayIndex = 6; 

                //Hide Columns
                ADGVInstDetails.Columns["id"].Visible = false;
                ADGVInstDetails.Columns["InstMonth"].Visible = false;
                ADGVInstDetails.Columns["InstNo"].Visible = false;
                ADGVInstDetails.Columns["TodaysDue"].Visible = false;
                ADGVInstDetails.Columns["Fees"].Visible = false;

                //Format 
                ADGVInstDetails.Columns["InstDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVInstDetails.Columns["PaymentDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVInstDetails.Columns["InstAmount"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;
                ADGVInstDetails.Columns["AmntPaid"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;


                //Change Header
                ADGVInstDetails.Columns["InstDate"].HeaderText = "Date";
                ADGVInstDetails.Columns["InstAmount"].HeaderText = "Amount";
                ADGVInstDetails.Columns["AmntPaid"].HeaderText = "Paid";
                ADGVInstDetails.Columns["PaymentDate"].HeaderText = "Payment Date";
                ADGVInstDetails.Columns["Discount"].HeaderText = "Discount";
                ADGVInstDetails.Columns["Description"].HeaderText = "Description";
                ADGVInstDetails.Columns["Description"].Width = 150;
                ADGVInstDetails.Columns["Facility"].HeaderText = "Course";

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void formatFacilityGrid()
        {
            try
            {
                //It's not working
                //foreach (DataGridViewRow dr in ADGVStudentFacility.Rows)
                //{
                //    if (dr.Cells["Status"].Value.ToString() == "D")
                //    {
                //        dr.Cells["btnDelete"].Value = "";
                //    }

                //}

                //Hiding Renew button if facility is not expired.
                foreach (DataGridViewRow dr in ADGVStudentFacility.Rows)
                {
                    if (Convert.ToDateTime(dr.Cells["ToDate"].Value) == DateTime.Now.AddDays(-1))
                    {
                        //dr.Cells["btnRenew"].ReadOnly = false;
                        //dr.Cells["btnRenew"].Visible = true;
                    }
                }

                //Hide Column
                ADGVStudentFacility.Columns["Id"].Visible = false;
                ADGVStudentFacility.Columns["Package"].Visible = false;
                ADGVStudentFacility.Columns["Student"].Visible = false;
                ADGVStudentFacility.Columns["IsMainPackage"].Visible = false;
                ADGVStudentFacility.Columns["AdmissionDate"].Visible = false;

                //Make readonly
                ADGVStudentFacility.Columns["Id"].ReadOnly = true;
                ADGVStudentFacility.Columns["FacilityName"].ReadOnly = true;
                ADGVStudentFacility.Columns["FromDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["ToDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["Status"].ReadOnly = true;
                ADGVStudentFacility.Columns["Amount"].ReadOnly = true;
                ADGVStudentFacility.Columns["Discount"].ReadOnly = true;
                ADGVStudentFacility.Columns["RenewalDiscount"].ReadOnly = true;
                ADGVStudentFacility.Columns["Package"].ReadOnly = true;
                ADGVStudentFacility.Columns["Branch"].ReadOnly = true;
                ADGVStudentFacility.Columns["AdmissionDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["IsMainPackage"].ReadOnly = true;

                //Change Column Header
                ADGVStudentFacility.Columns["FacilityName"].HeaderText = "Course";
                ADGVStudentFacility.Columns["FromDate"].HeaderText = "From";
                ADGVStudentFacility.Columns["ToDate"].HeaderText = "To";
                ADGVStudentFacility.Columns["AutoRenewEnabled"].HeaderText = "AutoRenew";
                ADGVStudentFacility.Columns["RenewDiscount"].HeaderText = "Discount on Renew";

                //Format Column
                ADGVStudentFacility.Columns["FromDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVStudentFacility.Columns["ToDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                //setting the width of the column
                ADGVStudentFacility.Columns["FromDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ADGVStudentFacility.Columns["ToDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ADGVStudentFacility.Columns["FacilityName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            }
            catch (Exception)
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

                //Set Header Text
                ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                ADGVAttendance.Columns["ATTD_IN_TIME"].HeaderText = "In Time";
                ADGVAttendance.Columns["ATTD_OUT_TIME"].HeaderText = "Out Time";
                ADGVAttendance.Columns["ATTD_STATUS"].HeaderText = "Status";
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
                    loadStudentFacilities(objStudent);


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
            lblTotalFees.Text = "";
            lblPendingFees.Text = "";
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
                    ADGVStudentFacility.DataSource = WinForm.ToDataTable(objStudent.Facilities.Where(facility => facility.Status == "A").ToList());
                    //}
                    formatFacilityGrid();

                }

                else
                {
                    MessageBox.Show("No courses for " + objStudent.ToString());
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
                foreach (DataRow dr in dtmarks.Rows)
                {
                    if (dr[8].ToString().Equals("-1"))
                    {
                        dr[8] = "A";
                    }
                }

                ADGVExamDetails.DataSource = dtmarks.DefaultView;
            }
        }

        private void showPersonnelDetails(Info.Student objStudent)
        {
            try
            {

                UICommon.WinForm.formatDateTimePicker(dtpDOB);

                cmbQualification.SelectedItem = objStudent.MembershipNo;// changed for asset
                txtAddress.Text = objStudent.Address;
                txtFName.Text = objStudent.Fname;
                txtMName.Text = objStudent.Mname;
                txtLName.Text = objStudent.Lname;
                txtBiometric.Text = objStudent.BiometricId.ToString();
                txtNewContact.Text = objStudent.ContactNo;
                txtEmailID.Text = objStudent.EmailID;
                lblSName.Text = objStudent.DisplayName;
                txtschoolName.Text = objStudent.AdharCard;//chnaged for asset
                txtBiometric.Text = objStudent.BiometricId.ToString();
                txtFContact.Text = objStudent.FatherContactNo;
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
                txtFFname.Text = objStudent.FatherName;

                // chnages for asset
                cmbField.SelectedItem = objStudent.counselor;
                cmbCategory.SelectedItem = objStudent.Category;
                batchCmb.SelectedItem = objStudent.Remark;
                //if(objStudent.Remark == "MWF")
                //{
                //    rbMWF.Checked = true;

                //}
                //else if (objStudent.Remark == "TTS")
                //{
                //    rbTTS.Checked = true;
                //}
                //else if (objStudent.Remark == "Sunday Special")
                //{
                //    rbsunday.Checked = true;
                //}
                    if (objStudent.Gender == "F")
                {
                    rbFemale.Checked = true;
                }
                else

                {
                    rbMale.Checked = true;
                }
               //
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
            {

                //lblPayStartDate.Text = (objStudent.Fees.PaymentStartDate != DateTime.MinValue) ? objStudent.Fees.PaymentStartDate.ToString(Common.Formatter.DateFormat) : "";
                lblTotalFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.TotalFees);
                lblTtlDiscount.Text = Common.Formatter.FormatCurrency(objStudent.Fees.FeesPaid);
                label58.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(inst => inst.CancelledAmount));
                //lblPendingFees.Text = (objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)).ToString();
                //lblTtlDiscount.Text = objStudent.Fees.FeesDiscount.ToString();
                label64.Text = Common.Formatter.FormatCurrency((objStudent.Fees.Installments.Sum(ttl => ttl.InstAmount) - objStudent.Fees.Installments.Sum(paid => paid.AmntPaid) - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)));
                //lblPendingFees.Text =Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount));
                lblPendingFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.FeesDiscount);
                ADGVInstDetails.DataSource = objStudent.Fees.Installments.ToDataTable<InstallmentDetail>();
                formatFeesGrid();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadStudent(int admissionNo = -1)
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
            }
            catch (Exception)
            {

                throw;
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

                objFeeData.RollNo = objStudent.RollNo;
                objFeeData.RupeesInWord = Utility.currencyInWords(Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[0]));

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
                objFeeData.clasContct = Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO);
                objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;
                objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount;
                if (objFeeData.OutstandingAmount == decimal.MinusOne)
                {
                    objFeeData.OutstandingAmount = decimal.Zero;
                }
                objFeeData.MembershipNo = objStudent.MembershipNo;

                objFeeData.TuitionFees = objStudent.Fees.TuitionAmnt - objFeeData.ServiceTax;

                objFeeData.CashPayment = Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[1].ToString());
                objFeeData.ChequePayment = Convert.ToDecimal(dtCumulative.Rows[0].ItemArray[2].ToString());

                NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());

                objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();

                Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT_PRO", "Fee_Receipt_" + objStudent.AdmissionNo + "_" + null, true);
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
            txtFContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtNewContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtFFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
        }
        private bool validatePersonalInfo()
        {
            try
            {

                if (txtFName.Text.Length == 0 || txtFName.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please fill student first name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if ((string.IsNullOrWhiteSpace(txtFName.Text)))
                {
                    UICommon.WinForm.showStatus("Enter Valid Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtMName.Text == "  ")
                {
                    UICommon.WinForm.showStatus("Enter Valid  Middle Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtMName.Focus();
                    return false;
                }
              
                else if (txtFContact.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please fill Father's contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFContact.Focus();
                    return false;
                }


                else if (txtNewContact.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please fill student contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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


                else if (txtNewContact.Text.Length != 0 && txtNewContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Phone Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtNewContact.Focus();
                    return false;
                }
                else if (txtContctNo.Text.Length != 0 && txtContctNo.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Phone Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtContctNo.Focus();
                    return false;
                }
                else if (txtMbrsNo.Text.Length == 0)
                {
                    txtMbrsNo.Text = "UnAssigned";
                    txtMbrsNo.Focus();
                    return true;
                }
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

            ADGVReceipt.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVReceipt.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVFollowup.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVFollowup.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtFFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtNewContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtBiometric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
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
            txtFContact.Text = "";
            dtpDOB.Text = "";
            lblAdmsnDate.Text = "";
            lblBatch.Text = "NA";
            txtFFname.Text = "";
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
            //cmbStudName.SelectedIndex = 0;

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
                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 4))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }
                    }

                    else if ((Convert.ToInt32(row.Cells[7].Value) == 20))
                    {
                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 8))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                          if ((Convert.ToInt32(row.Cells[7].Value) == 30))
                    {
                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 11))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                           if ((Convert.ToInt32(row.Cells[7].Value) == 40))
                    {
                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 14))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                       if ((Convert.ToInt32(row.Cells[7].Value) == 50))
                    {

                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 17))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }


                    }
                    else
                            if ((Convert.ToInt32(row.Cells[7].Value) == 80))
                    {
                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 24))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                        if ((Convert.ToInt32(row.Cells[7].Value) == 100))
                    {
                        if (((row.Cells[8].Value.ToString()) != "A"))
                        {
                            if ((Convert.ToInt32(row.Cells[8].Value) < 35))
                            {
                                row.DefaultCellStyle.BackColor = Color.Tomato;
                            }
                        }
                        else
                        {
                            row.Cells[8].Style.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                            row.Cells[8].Style.ForeColor = Color.Red;
                        }
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
                ADGVExamDetails.Columns["TSUB_MARKS"].HeaderText = "Total Marks";
                ADGVExamDetails.Columns["STTD_MARKS_OPTAINED"].HeaderText = "Marks Obtained";
                ADGVExamDetails.Columns["STTD_REMARK"].HeaderText = "Remark";

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

                        if (dt.Rows.Count != 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr[8].ToString().Equals("-1"))
                                {
                                    dr[8] = "A";
                                }
                            }

                            ADGVExamDetails.DataSource = dt;
                        }
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

            Info.ComboItem objAllTest = new Info.ComboItem("%", "All");
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
            try
            {
                FrmAnyFollowUp objForm = new FrmAnyFollowUp();
                objForm.setValue(objStudent);
                objForm.ShowDialog();
                loadFolloup(objStudent.AdmissionNo, branchId);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
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
                ADGVFollowup.Columns["FOLU_CRTD_AT"].Visible = false;
                ADGVFollowup.Columns["FOLU_CRTD_BY"].Visible = false;
                ADGVFollowup.Columns["FOLU_UPDAT_BY"].Visible = false;
                ADGVFollowup.Columns["FOLU_UPDT_AT"].Visible = false;
                ADGVFollowup.Columns["FOLU_DLTD_AT"].Visible = false;
                ADGVFollowup.Columns["FOLU_DLTD_BY"].Visible = false;
                ADGVFollowup.Columns["FOLU_STATUS"].Visible = false;

                //Changing HeaderText.
                ADGVFollowup.Columns["FOLU_FOLLOWUP_TYPE"].HeaderText = "Type";
                ADGVFollowup.Columns["FOLU_DATE"].HeaderText = "Date";
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].HeaderText = "Decsription";
                ADGVFollowup.Columns["FOLU_MEDIUM"].HeaderText = "Meduim";

                //Formatting Date.
                ADGVFollowup.Columns["FOLU_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat; ;

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
                    
                    pbPhoto.Image = capture.capturedImage;

                    pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    
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
            if (txtFContact.Text.Length >= 10)
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

        private void ADGVReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ADGVFollowup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            WinForm.ADGVSerialNo(ADGVFollowup, e);
        }

        private void ADGVReceipt_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(ADGVReceipt, e);
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        }

       
        private void lnkViewStud_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                FrmStudent frmstudents = new FrmStudent();
                frmstudents = UICommon.FormFactory.GetForm(UICommon.Forms.FrmStudent) as FrmStudent;

                //this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ADGVInstDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
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

        private void dtpReceiptFrmDate_ValueChanged(object sender, EventArgs e)
        {

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
    }
}







