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

namespace ClassManager.WinApp
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
                addColumns();

                //hide tab panel on load
                panel2.Visible = false;
                btnAddFacilities.Visible = false;

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
                    if (name == "Gym" || name == "Dance")
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
                    panel2.Visible = false;
                    btnAddFacilities.Visible = false;
                    formatForm();
                    allow = true;
                    formatdate();
                    ApplyPrevileges();
                    string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    if (name == "Gym" || name == "Dance")
                    {
                        tabMain.TabPages.Remove(tabPage10);
                    }
                }

                loadEnquiryReferences();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void loadEnquiryReferences()
        {
            try
            {
                string enquiryReferences = SysParam.getValue<string>(SysParam.Parameters.ENQUIRY_SOURCES);

                if (enquiryReferences != null && enquiryReferences.Length > 0)
                {
                    String[] sources = enquiryReferences.Split(',');
                    cmbSource.Items.AddRange(sources);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void addColumns()
        {
            try
            {

                ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.deleteBin,
                    Name = "btnDelete",
                    HeaderText = "Delete"
                });

                ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.printer,
                    Name = "btnPrint",
                    HeaderText = "Print"
                });

                ADGVStudentFacility.Columns.Add(new DataGridViewImageColumn()
                {
                    Image = Properties.Resources.Edit,
                    Name = "btnEdit",
                    HeaderText = "Installments"
                });

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
                panel2.Visible = false;
                btnAddFacilities.Visible = false;
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
                    ObjStudentMaster.HeathIssue = "";
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
                    ObjStudentMaster.MembershipNo = txtMbrsNo.Text;
                    ObjStudentMaster.BloodGroup = "";
                    ObjStudentMaster.BMI = "";
                    ObjStudentMaster.Weight = "";
                    ObjStudentMaster.Source = cmbSource.Text;//added by ashvini 
                    ObjStudentMaster.Height = "";
                    ObjStudentMaster.Remark = txtRemark.Text;
                    ObjStudentMaster.BiometricId = Convert.ToInt32(txtBiometric.Text);
                    ObjStudentMaster.ImgPhoto = pbPhoto.Image;
                    ObjStudentMaster.AdmissionStandard = (Standard)ObjStudentMaster.AdmissionStandard;
                    ObjStudentMaster.batchID = ((cmbBatch.SelectedItem as ComboItem).key);
                    // ObjStudentMaster.RollNo = txtRollNo.Text;
                    //ObjStudentMaster.AdharCard = txtSchoolName.Text;
                    ObjStudentMaster.SchoolName = txtSchoolName.Text;
                    ObjStudentMaster.Category = "";
                    ObjStudentMaster.counselor = "";

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
                        UICommon.WinForm.setDateForAttendance(dtpAttdFromDate, dtpAttdToDate);
                        loadAttendance(dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    }
                    else if (tabMain.SelectedIndex == 1)
                    {

                    }
                    else if (tabMain.SelectedIndex == 5)
                    {
                        // dtpAttdFromDate
                        UICommon.WinForm.setDateForAttendance(dtFrmDate, dtToDate);
                        showExamDetails(dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        cmbTests.DisplayMember = "TestName";
                        cmbTests.ValueMember = "TestId";
                        populateOnlyTest();
                    }
                    else if (tabMain.SelectedIndex == 3)
                    {
                        //sets the start and end date of the month
                        UICommon.WinForm.setDate(dtpReceiptFrmDate, dtpReceiptToDate);

                        //Gets the payment details against a admission no.
                        ADGVReceipt.DataSource = BLL.FeesHandller.getPayments(objStudent.AdmissionNo);
                        formatReceiptGrid();
                    }
                    else if (tabMain.SelectedIndex == 4)
                    {
                        loadFolloup(objStudent.AdmissionNo, branchId);
                    }
                    else if (tabMain.SelectedIndex == 6)
                    {

                        ActivityGrid.DataSource = BLL.StudentHandller.GetActivities(objStudent.AdmissionNo, branchId);

                        FormatActivityGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
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


                    if (e.ColumnIndex == ADGVStudentFacility.Columns["btnPrint"].Index)
                    {
                        try
                        {

                            DataGridViewRow selected = ADGVStudentFacility.Rows[e.RowIndex];
                            int facilityId = Convert.ToInt32(selected.Cells["Id"].Value);

                            Invoice objInvoice = new Invoice();


                            if (selected.Cells["InvoiceId"].Value != null && !selected.Cells["InvoiceId"].Value.ToString().Equals("") && !selected.Cells["InvoiceId"].Value.ToString().Equals("0"))
                            {
                                objInvoice = FeesHandller.loadInvoiceDetails(Convert.ToInt32(selected.Cells["InvoiceId"].Value));
                                if(objInvoice == null)
                                {
                                    UICommon.WinForm.showMessage("Invoice not present in system, Please contact support for additional help", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                                    return;
                                }
                            }
                            else
                            {
                                objInvoice = new Invoice();
                                StudentFacility currentFacility = objStudent.Facilities.First(facility => facility.Id == facilityId);



                                objInvoice.admissionNo = objStudent.AdmisionNo;
                                objInvoice.amount = currentFacility.Amount - currentFacility.Discount;
                                objInvoice.branchId = objStudent.Branch.BranchId;
                                objInvoice.clientGSTN = objStudent.GSTNo;
                                objInvoice.clientName = objStudent.Fname + " " + objStudent.Lname;
                                objInvoice.invoiceDate = currentFacility.AdmissionDate;
                                objInvoice.facilityId = currentFacility.Id;

                                InvoiceDetails objInvoiceDetails = new InvoiceDetails();

                                objInvoiceDetails.actualAmount = Math.Round((currentFacility.Amount - currentFacility.Discount) / (decimal)1.18, 2);
                                objInvoiceDetails.amount = currentFacility.Amount;
                                objInvoiceDetails.SACCode = currentFacility.Package.SACCode;
                                objInvoiceDetails.quantity = 1;
                                if (currentFacility.Package.CGSTPercentage == 0)
                                {
                                    currentFacility.Package.CGSTPercentage = SysParam.getValue<decimal>(SysParam.Parameters.SGST_PERCENT);
                                }
                                if (currentFacility.Package.SGSTPercentage == 0)
                                {
                                    currentFacility.Package.SGSTPercentage = SysParam.getValue<decimal>(SysParam.Parameters.CGST_PERCENT);
                                }

                                objInvoiceDetails.packageAmount = currentFacility.Amount;
                                objInvoiceDetails.SGSTPercentage = currentFacility.Package.SGSTPercentage;
                                objInvoiceDetails.CGSTPercentage = currentFacility.Package.CGSTPercentage;
                                objInvoiceDetails.CGSTAmount = Math.Round(objInvoiceDetails.actualAmount * currentFacility.Package.CGSTPercentage / (decimal)100, 2);
                                objInvoiceDetails.SGSTAmount = Math.Round(objInvoiceDetails.actualAmount * currentFacility.Package.CGSTPercentage / (decimal)100, 2);
                                //Adjust amount without tax based on taxes collected
                                objInvoiceDetails.actualAmount = (currentFacility.Amount - currentFacility.Discount) - (objInvoiceDetails.CGSTAmount + objInvoiceDetails.SGSTAmount);
                                objInvoiceDetails.totalTax = (objInvoiceDetails.CGSTAmount + objInvoiceDetails.SGSTAmount);
                                objInvoiceDetails.paidAmount = 0;
                                objInvoiceDetails.packageAmount = currentFacility.Amount;
                                objInvoiceDetails.balanceAmount = objInvoiceDetails.actualAmount;
                                objInvoiceDetails.branchId = objStudent.Branch.BranchId;
                                objInvoiceDetails.packageName = currentFacility.FacilityName;
                                objInvoiceDetails.discount = currentFacility.Discount;

                                List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();
                                invoiceDetails.Add(objInvoiceDetails);
                                objInvoice.invoiceItems = invoiceDetails;

                                objInvoice = BLL.FeesHandller.createInvoice(objInvoice, objStudent.Branch.BranchId);
                            }

                            printInvoice(objInvoice.id, -1, facilityId);

                            loadStudent(objStudent.AdmissionNo);

                        }
                        catch (Exception ex)
                        {
                            UICommon.WinForm.showError(ex, sCaption, this, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["FromDate"].Index)
                    {
                        //Initialized a new DateTimePicker Control 
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        OldDate = (Convert.ToDateTime(selectedRow.Cells["FromDate"].Value));
                        DateTimePicker = new DateTimePicker();
                        ADGVStudentFacility.Controls.Add(DateTimePicker);
                        DateTimePicker.Format = DateTimePickerFormat.Short;
                        Rectangle oRectangle = ADGVStudentFacility.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        // oRectangle.Height = oRectangle.Height + 500;
                        DateTimePicker.Font = new Font("Microsoft Sans Serif", 11);
                        DateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                        DateTimePicker.Location = new Point(oRectangle.X, 28);
                        DateTimePicker.CloseUp += new EventHandler(DateTimePicker_CloseUp);
                        DateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                        DateTimePicker.Visible = true;
                    }
                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["ToDate"].Index)
                    {
                        //Initialized a new DateTimePicker Control 
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        OldDate = (Convert.ToDateTime(selectedRow.Cells["ToDate"].Value));
                        DateTimePicker = new DateTimePicker();
                        ADGVStudentFacility.Controls.Add(DateTimePicker);
                        DateTimePicker.Format = DateTimePickerFormat.Short;
                        Rectangle oRectangle = ADGVStudentFacility.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        oRectangle.Height = oRectangle.Height + 500;
                        DateTimePicker.Font = new Font("Microsoft Sans Serif", 11);
                        DateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                        DateTimePicker.Location = new Point(oRectangle.X, 28);
                        DateTimePicker.CloseUp += new EventHandler(DateTimePicker_CloseUp);
                        DateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                        DateTimePicker.Visible = true;
                    }

                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["btnDelete"].Index)
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
                                                    if (Pending == 0)
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
                                                        UICommon.WinForm.showStatus("As there is Outstanding Fees, Cannot Delete this Package", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                                    }
                                                }
                                            }
                                        }

                                    }
                                    // UICommon.WinForm.showStatus("Already deactivated.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
                    else if (e.ColumnIndex == ADGVStudentFacility.Columns["btnEdit"].Index)
                    {
                        ADGVStudentFacility.BeginEdit(true);
                        DataGridViewRow selectedRow = ADGVStudentFacility.Rows[e.RowIndex];
                        DataGridViewCell selectedCell = ADGVStudentFacility.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        studfacilityID = (Convert.ToInt32(selectedRow.Cells["Id"].Value));

                        FrmStudentInstallments frmStudentInstallements = new FrmStudentInstallments();
                        Info.FeesPackage objFeeStruct = new FeesPackage();

                        StudentFacility studeFacility = objStudent.Facilities.Find(facility => facility.Id == studfacilityID);
                        studeFacility.Installments = InstallmentHandler.getFacilityInstallments(studeFacility.Id);

                        decimal oldFees = studeFacility.Installments.Sum(inst => inst.InstAmount);
                        decimal oldDiscount = studeFacility.Installments.Sum(inst => inst.Discount);

                        frmStudentInstallements.setInstallments(studeFacility, false);
                        DialogResult result =  frmStudentInstallements.ShowDialog();

                        if (result != DialogResult.Cancel)
                        {
                            BLL.InstallmentHandler.updateFacilityInstallments(studeFacility,objStudent);
                            loadStudent(objStudent.AdmissionNo);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
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

                if(facility != null)
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
                else if(SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE) == "INVOICE_REPORT")
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
            }
            catch (Exception ex)
            {
                throw ex;
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
                    if (e.ColumnIndex == ADGVReceipt.Columns["Reprint"].Index)
                    {
                        DataTable dtTransaction = BLL.FeesHandller.getTransactionReprint(Convert.ToString(ADGVReceipt.Rows[e.RowIndex].Cells["TRNC_ID"].Value));

                        Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                        objFeeData.BranchId = objStudent.Branch.BranchName.ToString();

                        objFeeData.PaymentDate = Convert.ToDateTime(dtTransaction.Rows[0]["TRNC_DATE"].ToString());
                        objFeeData.minDate = DateTime.MinValue;
                        objFeeData.ReceiptNo = dtTransaction.Rows[0]["TRNC_RECEIPT_NO"].ToString();
                        objFeeData.RollNo = objStudent.RollNo;
                        objFeeData.RupeesInWord = Utility.currencyInWords(Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[5]));

                        if (SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).Equals(""))
                        {
                            objFeeData.Standard = dtTransaction.Rows[0]["STD_NAME"].ToString();
                        }
                        else
                        {
                            objFeeData.Standard = dtTransaction.Rows[0]["STRM_NAME"].ToString();
                        }

                        if (ClassManager.Properties.Settings.Default.ShowBatchInReceipt == true)
                        {
                            objFeeData.Standard += "/" + dtTransaction.Rows[0]["FPKG_PACKAGE_NAME"].ToString();
                        }
                        objFeeData.PackageName = dtTransaction.Rows[0]["FPKG_PACKAGE_NAME"].ToString();

                        objFeeData.Standard = objStudent.Course.Standard.StandardName + "-" + objStudent.Course.Standard.Stream.Name;
                        objFeeData.StudentName = objStudent.DisplayName;
                        objFeeData.FatherContactNo = objStudent.FatherContactNo;
                        objFeeData.ContactNo = objStudent.ContactNo;
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
                        objFeeData.BranchAddress = Info.SysParam.getValue<String>(SysParam.Parameters.SW_BRANCH_NAME);
                        objFeeData.PackageAmount = objStudent.Fees.TotalFees;
                        objFeeData.Batch = objStudent.Course.Batch.Name;
                        //objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.FeesDiscount;
                        objFeeData.OutstandingAmount = objStudent.Fees.TotalFees - objStudent.Fees.FeesPaid - objStudent.Fees.Installments.Sum(outs => outs.Discount);
                        if (objFeeData.OutstandingAmount == decimal.MinusOne)
                        {
                            objFeeData.OutstandingAmount = decimal.Zero;
                        }
                        objFeeData.MembershipNo = objStudent.MembershipNo;
                        objFeeData.FeesId = objStudent.Fees.FeesId;
                        objFeeData.FinalAmount = objStudent.Fees.TotalFees - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount);
                        objFeeData.TransactionId = Convert.ToInt32(dtTransaction.Rows[0].ItemArray[0]);
                        objFeeData.TuitionFees = objStudent.Fees.TuitionAmnt - objFeeData.ServiceTax;
                        objFeeData.Adhar = objStudent.AdharCard;
                        objFeeData.CashPayment = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[30].ToString());
                        objFeeData.ChequePayment = Convert.ToDecimal(dtTransaction.Rows[0].ItemArray[29].ToString());
                        objFeeData.StartDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_FROM_DATE"].ToString());
                        objFeeData.EndDate = Convert.ToDateTime(dtTransaction.Rows[0]["STFL_TO_DATE"].ToString());
                        objFeeData.ReceivedBy = dtTransaction.Rows[0]["TRNC_CRTD_BY"].ToString();
                        NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());

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
                        frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, true);
                        FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;
                        // Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT_PRO", "Fee_Receipt_" + objStudent.AdmissionNo + "_" + dtTransaction.Rows[0].ItemArray[16].ToString().Replace(@"/", "-"), true);
                    }

                    else if (SysParam.getValue<string>(SysParam.Parameters.GENERATE_INVOICE).ToLower() == "true" && e.ColumnIndex == ADGVReceipt.Columns["Invoice"].Index )
                    {
                        Invoice objInvoice = null;
                        int TransactionId = Convert.ToInt32(Convert.ToString(ADGVReceipt.Rows[e.RowIndex].Cells["TRNC_ID"].Value));

                        if (ADGVReceipt.Rows[e.RowIndex].Cells["INVOICE_ID"].Value != null && ADGVReceipt.Rows[e.RowIndex].Cells["INVOICE_ID"].Value.ToString() != "")
                        {
                            objInvoice = FeesHandller.loadInvoiceDetails(Convert.ToInt32(ADGVReceipt.Rows[e.RowIndex].Cells["INVOICE_ID"].Value));
                            if(objInvoice == null)
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
                    else if (e.ColumnIndex == ADGVReceipt.Columns["Cancel"].Index)
                    {
                        Int32 transactionId = Convert.ToInt32(ADGVReceipt.Rows[e.RowIndex].Cells["TRNC_ID"].Value);
                        var result = UICommon.WinForm.showStatus("Do You Want Delete this Payment?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                        if (result == DialogResult.Yes)
                        {
                            BLL.FeesHandller.cancelPayment(transactionId);
                            loadStudent(objStudent.AdmissionNo);
                        }
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

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }

                    }
                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }

                    }
                }
                else if (cmbViewPackage.SelectedIndex == 2)
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "D").ToList();
                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                    }
                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                    }



                }
                //To View Expired Facilities.Mohan(14-Aug-2017).
                else if (cmbViewPackage.SelectedIndex == 3)
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities.Where(facility => facility.Status == "E").ToList();

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                    }
                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
                        }
                    }


                }

                //Mohan(14-Aug-2017).
                else
                {
                    ADGVStudentFacility.DataSource = objStudent.Facilities;
                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                    }
                    else
                    {
                        if (ADGVStudentFacility.Columns.Contains("btnDelete"))
                        {
                            ADGVStudentFacility.Columns["btnDelete"].Visible = true;
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

                ADGVReceipt.Columns.Add(new DataGridViewImageColumn()
                {

                    Image = Properties.Resources.deleteBin,
                    Name = "Cancel",
                    HeaderText = "Cancel"
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
            }



            //formatting HeaderText
            ADGVReceipt.Columns["TRNC_AMOUNT"].HeaderText = "Amount";
            ADGVReceipt.Columns["TRNC_DATE"].HeaderText = "Date";
            ADGVReceipt.Columns["TRNC_RECEIPT_NO"].HeaderText = "Receipt No";
            ADGVReceipt.Columns["TRNC_RECEIPT_NO"].Width = 170;
            ADGVReceipt.Columns["TRNC_AMOUNT"].ReadOnly = true;
            ADGVReceipt.Columns["TRNC_DATE"].ReadOnly = true;
            ADGVReceipt.Columns["TRNC_RECEIPT_NO"].ReadOnly = true;
            //ADGVReceipt.Columns["Reprint"].DisplayIndex = 0;
            //formatting Date
            ADGVReceipt.Columns["TRNC_DATE"].DefaultCellStyle.Format = Formatter.DateFormat;

            //Hiding Columns
            ADGVReceipt.Columns["TRNC_ID"].Visible = false;

            if (ADGVReceipt.Columns.Contains("INVOICE_ID"))
            {
                ADGVReceipt.Columns["INVOICE_ID"].Visible = false;
            }

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
                ADGVInstDetails.Columns["InstAmount"].ReadOnly = true;
                ADGVInstDetails.Columns["AmntPaid"].ReadOnly = true;
                ADGVInstDetails.Columns["PaymentDate"].ReadOnly = true;
                ADGVInstDetails.Columns["Discount"].ReadOnly = true;
                ADGVInstDetails.Columns["Description"].ReadOnly = true;
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
                ADGVInstDetails.Columns["Facility"].HeaderText = "Course";
                ADGVInstDetails.Columns["Facility"].Width = 100;
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

                //Hide Column
                ADGVStudentFacility.Columns["Id"].Visible = false;
                ADGVStudentFacility.Columns["Package"].Visible = false;
                ADGVStudentFacility.Columns["Student"].Visible = false;
                ADGVStudentFacility.Columns["IsMainPackage"].Visible = false;
                ADGVStudentFacility.Columns["AdmissionDate"].Visible = false;
                ADGVStudentFacility.Columns["InvoiceId"].Visible = false;
                ADGVStudentFacility.Columns["FromDate"].Visible = false;
                ADGVStudentFacility.Columns["ToDate"].Visible = false;
                ADGVStudentFacility.Columns["RenewDiscount"].Visible = false;
                ADGVStudentFacility.Columns["AutoRenewEnabled"].Visible = false;
                ADGVStudentFacility.Columns["OutstandingFees"].Visible = false;

                if (ADGVStudentFacility.Columns.Contains("Canc_Amt"))
                {
                    ADGVStudentFacility.Columns["Canc_Amt"].ReadOnly = true;
                    ADGVStudentFacility.Columns["Canc_Amt"].HeaderText = "Cancelled";
                    ADGVStudentFacility.Columns["Canc_Amt"].DisplayIndex = 10;

                    //end by ashvini04-02
                }
                //Make readonly
                ADGVStudentFacility.Columns["Id"].ReadOnly = true;
                ADGVStudentFacility.Columns["FacilityName"].ReadOnly = true;
                ADGVStudentFacility.Columns["FromDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["ToDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["Status"].ReadOnly = true;
                ADGVStudentFacility.Columns["Status"].DisplayIndex = 11;
                ADGVStudentFacility.Columns["Amount"].ReadOnly = true;
                ADGVStudentFacility.Columns["Amount"].DisplayIndex = 5;
                ADGVStudentFacility.Columns["Amount_Paid"].ReadOnly = true;
                ADGVStudentFacility.Columns["Amount_Paid"].DisplayIndex = 6;
                ADGVStudentFacility.Columns["Amount_Paid"].HeaderText = "Paid";
                ADGVStudentFacility.Columns["Discount"].ReadOnly = true;
                ADGVStudentFacility.Columns["Discount"].DisplayIndex = 7;
                ADGVStudentFacility.Columns["RenewalDiscount"].Visible = false;
                ADGVStudentFacility.Columns["Package"].ReadOnly = true;
                ADGVStudentFacility.Columns["Branch"].ReadOnly = true;
                ADGVStudentFacility.Columns["Branch"].DisplayIndex = 12;
                ADGVStudentFacility.Columns["Reason"].ReadOnly = true;
                ADGVStudentFacility.Columns["AdmissionDate"].ReadOnly = true;
                ADGVStudentFacility.Columns["IsMainPackage"].ReadOnly = true;
                ADGVStudentFacility.Columns["Pending"].ReadOnly = true;
                ADGVStudentFacility.Columns["Pending"].DisplayIndex = 9;
                //Change Column Header
                ADGVStudentFacility.Columns["FacilityName"].HeaderText = "Course";
                ADGVStudentFacility.Columns["FacilityName"].Width = 60;
                ADGVStudentFacility.Columns["FacilityName"].DisplayIndex = 4;
                ADGVStudentFacility.Columns["FromDate"].HeaderText = "From";
                ADGVStudentFacility.Columns["ToDate"].HeaderText = "To";
                ADGVStudentFacility.Columns["AutoRenewEnabled"].HeaderText = "AutoRenew";
                ADGVStudentFacility.Columns["RenewDiscount"].HeaderText = "Discount on Renew";
                ADGVStudentFacility.Columns["DiscountReason"].HeaderText = "Reason";
                ADGVStudentFacility.Columns["DiscountReason"].ReadOnly = true;
                ADGVStudentFacility.Columns["DiscountReason"].DisplayIndex = 8;


                //Format Column
                ADGVStudentFacility.Columns["FromDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVStudentFacility.Columns["ToDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                //Adjust Width


                //setting the width of the column
                ADGVStudentFacility.Columns["FromDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ADGVStudentFacility.Columns["ToDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ADGVStudentFacility.Columns["FacilityName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ADGVStudentFacility.Columns["btnDelete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ADGVStudentFacility.Columns["btnPrint"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


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
                if (SysParam.getValue<Boolean>(SysParam.Parameters.LECTUREWISE_ATTD) == true)
                {
                    lnkScheduleSessions.Visible = true;
                }
                
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
                if (ADGVAttendance.Columns.Contains("Name"))
                {
                    ADGVAttendance.Columns["Name"].Visible = false;

                }
                if (ADGVAttendance.Columns.Contains("Father Contact"))
                { ADGVAttendance.Columns["Father Contact"].Visible = false; }
                if (ADGVAttendance.Columns.Contains("Contact No"))
                { ADGVAttendance.Columns["Contact No"].Visible = false; }
                if (ADGVAttendance.Columns.Contains("ATTD_CHECKIN_STATUS"))
                {
                    ADGVAttendance.Columns["ATTD_CHECKIN_STATUS"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("ATLC_IS_SCHEDULED"))
                {
                    ADGVAttendance.Columns["ATLC_IS_SCHEDULED"].Visible = false;
                }
                if (ADGVAttendance.Columns.Contains("STAM_LECTURES_COUNT"))
                {
                    ADGVAttendance.Columns["STAM_LECTURES_COUNT"].Visible = false;
                }
                //Set Header Text
                ADGVAttendance.Columns["Total"].Width = 80;
                ADGVAttendance.Columns["ATTD_DATE"].HeaderText = "Date";
                ADGVAttendance.Columns["Column1"].HeaderText = "Late Mark";
                ADGVAttendance.Columns["ATTD_IN_TIME"].HeaderText = "In Time";
                ADGVAttendance.Columns["ATTD_OUT_TIME"].HeaderText = "Out Time";
                if (ADGVAttendance.Columns.Contains("ATTD_STATUS"))
                {
                    ADGVAttendance.Columns["ATTD_STATUS"].HeaderText = "Status";
                }

                if (ADGVAttendance.Columns.Contains("ATTD_IS_HOLIDAY"))
                {
                    ADGVAttendance.Columns["ATTD_IS_HOLIDAY"].HeaderText = "Holiday";
                }
                ADGVAttendance.Columns["BRCH_NAME"].HeaderText = "Branch";
                if (ADGVAttendance.Columns.Contains("STD_NAME"))
                {
                    ADGVAttendance.Columns["STD_NAME"].HeaderText = "Course";
                }

                if (ADGVAttendance.Columns.Contains("ATLC_COUNT"))
                {
                    ADGVAttendance.Columns["ATLC_COUNT"].HeaderText = "Session Count";
                }
                if (ADGVAttendance.Columns.Contains("ATTD_IN_TIME1"))
                {
                    ADGVAttendance.Columns["ATTD_IN_TIME1"].Visible = false;
                    // ADGVAttendance.Columns["ATTD_IN_TIME1"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
                }
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
                    panel2.Visible = false;
                    btnAddFacilities.Visible = false;
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
                    panel2.Visible = true;
                    btnAddFacilities.Visible = true;
                    tabMain.SelectedIndex = 0;
                    btnAddFacilities.Enabled = true;
                    cmdBrwseImg.Enabled = true;
                    linkLabel1.Enabled = true;
                    lnkClear.Enabled = true;
                    showPersonnelDetails(objStudent);
                    showFeesDetails(objStudent);
                    ApplyPrevileges();
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
                if (txtSchoolName.Text != "")
                {
                    txtSchoolName.Text = objStudent.SchoolName;
                }
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
            lblPendingFees.Text = "";
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
        private void showExamDetails(DateTime fromDate, DateTime toDate)
        {
            DataTable dtmarks = BLL.TestHandler.getStudentExamDetails(objStudent.AdmissionNo.ToString(), fromDate, toDate);
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
                if (txtSchoolName.Text == "")
                {
                    txtSchoolName.Text = objStudent.SchoolName;
                }
                txtMbrsNo.Text = objStudent.MembershipNo;
                txtAddress.Text = objStudent.Address;
                txtFName.Text = objStudent.Fname;
                txtMName.Text = objStudent.Mname;
                txtLName.Text = objStudent.Lname;
                txtBiometric.Text = objStudent.BiometricId.ToString();
                txtNewContact.Text = objStudent.ContactNo;
                txtEmailID.Text = objStudent.EmailID;
                lblSName.Text = objStudent.DisplayName;
                txtRemark.Text = objStudent.Remark;
                cmbSource.Text = objStudent.Source;
                txtBiometric.Text = objStudent.BiometricId.ToString();
                txtFContact.Text = objStudent.FatherContactNo;
               // txtSchoolName.Text = objStudent.AdharCard;
                if (objStudent.Dob != null && (objStudent.Dob.Value >= dtpDOB.MinDate && objStudent.Dob.Value <= dtpDOB.MaxDate))
                {
                    dtpDOB.Value = objStudent.Dob.Value;
                }
                lblAdmsnDate.Text = Common.Formatter.FormatDate(objStudent.AdmissionDate);
                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objStudent.PhotoURL.ToString();
                // txtRollNo.Text = objStudent.RollNo.ToString();
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
                //   lblpending.Text = Common.Formatter.FormatCurrency((objStudent.Fees.Installments.Sum(ttl => ttl.InstAmount) - objStudent.Fees.Installments.Sum(paid => paid.AmntPaid) - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)));

                //lblPayStartDate.Text = (objStudent.Fees.PaymentStartDate != DateTime.MinValue) ? objStudent.Fees.PaymentStartDate.ToString(Common.Formatter.DateFormat) : "";
                lblTotalFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.TotalFees);
                lblTtlDiscount.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount));
                lblCancelledFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(inst => inst.CancelledAmount));
                lblPendingFees.Text = Common.Formatter.FormatCurrency((objStudent.Fees.Installments.Sum(ttl => ttl.InstAmount) - objStudent.Fees.Installments.Sum(paid => paid.AmntPaid) - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)));
                //lblPendingFees.Text =Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount));
                //lblPendingFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.FeesDiscount);
                //ADGVInstDetails.DataSource = objStudent.Fees.Installments.ToDataTable<InstallmentDetail>();
                //formatFeesGrid();
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
                objFeeData.ContactNo = objStudent.ContactNo;
                objFeeData.FatherContactNo = objStudent.FatherContactNo;
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
                ADGVExamDetails.Columns["TEST_NAME"].HeaderText = "Test";
                ADGVExamDetails.Columns["TSUB_DATETIME"].HeaderText = "Date";
                ADGVExamDetails.Columns["SUBM_NAME"].HeaderText = "Subject";
                ADGVExamDetails.Columns["TSUB_MARKS"].HeaderText = "Total";
                ADGVExamDetails.Columns["STTD_MARKS_OPTAINED"].HeaderText = "Obtained";
                ADGVExamDetails.Columns["STTD_REMARK"].HeaderText = "Remark";

                //to format date
                ADGVExamDetails.Columns["TSUB_DATETIME"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                ADGVExamDetails.ReadOnly = true;
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

                WinForm.showStatus("Please add Course", null, null);
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
                ADGVFollowup.Columns["FOLU_CRTD_AT"].HeaderText = "Date";
                ADGVFollowup.Columns["FOLU_CRTD_AT"].ReadOnly = true;
                ADGVFollowup.Columns["FOLU_CRTD_AT"].DisplayIndex = 1;
                ADGVFollowup.Columns["FOLU_CRTD_AT"].ReadOnly = true;
                ADGVFollowup.Columns["FOLU_FOLLOWUP_TYPE"].HeaderText = "Type";
                ADGVFollowup.Columns["FOLU_FOLLOWUP_TYPE"].ReadOnly = true;
                ADGVFollowup.Columns["FOLU_FOLLOWUP_TYPE"].DisplayIndex = 3;
                ADGVFollowup.Columns["FOLU_DATE"].HeaderText = "Next Followup Date";
                ADGVFollowup.Columns["FOLU_DATE"].ReadOnly = true;
                ADGVFollowup.Columns["FOLU_DATE"].DisplayIndex = 7;
                ADGVFollowup.Columns["FOLU_By"].HeaderText = "Followup By";
                ADGVFollowup.Columns["FOLU_By"].ReadOnly = true;
                ADGVFollowup.Columns["FOLU_By"].DisplayIndex = 6;
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].HeaderText = "Decsription";
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].ReadOnly = true;
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].DisplayIndex = 4;
                ADGVFollowup.Columns["FOLU_DESCRIPTION"].Width = 175;

                ADGVFollowup.Columns["FOLU_MEDIUM"].HeaderText = "Medium";
                ADGVFollowup.Columns["FOLU_MEDIUM"].ReadOnly = true;

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

                ADGVFollowup.Columns["FOLU_DATE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ADGVFollowup.Columns["FOLU_By"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



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



        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }



        private void ADGVAttendance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow adrow in ADGVAttendance.Rows)
                {
                    if (adrow.Cells[10].Value.ToString() == "False")
                    {
                        adrow.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                }
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

        private void lnkScheduleSessions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmViewScheduleLect objpopup = new FrmViewScheduleLect();
                objpopup = UICommon.FormFactory.GetForm(UICommon.Forms.FrmViewScheduleLect) as FrmViewScheduleLect;
                objpopup.SetData(objStudent);
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
                    CommonRprtData.FromDate = dtFrmDate.Value;
                    CommonRprtData.ToDate = dtToDate.Value;
                    CommonRprtData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                    CommonRprtData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                    CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    CommonRprtData.Name = objStudent.DisplayName.ToString();
                    CommonRprtData.Roll = objStudent.AdmisionNo.ToString();
                    CommonRprtData.Std = objStudent.Course.Standard.StandardName + "-" + objStudent.Course.Batch.Name;
                    CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "EXAM_WISE_REPORT");

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

                if (dtFrmDate.Value.Date > dtToDate.Value.Date)
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

        private void btnSubPrint_Click(object sender, EventArgs e)
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
                    CommonRprtData.FromDate = dtFrmDate.Value;
                    CommonRprtData.ToDate = dtToDate.Value;
                    CommonRprtData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                    CommonRprtData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                    CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    CommonRprtData.Name = objStudent.DisplayName.ToString();
                    CommonRprtData.Roll = objStudent.AdmisionNo.ToString();
                    CommonRprtData.Std = objStudent.Course.Standard.StandardName + "-" + objStudent.Course.Batch.Name;
                    CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "SUB_WISE_REPORT");

                    FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
                    frmRprtViewer.viewReport(CommonRprtData.ReportName, CommonRprtData, objPrintngConfig);
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();

                getParameter.ParentNo = "Parent No:- " + objStudent.FatherContactNo.ToString();
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


        private void btnPayfee_Click(object sender, EventArgs e)
        {
            FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
            objRedirect.LoadFeeDetailsFromRegistration(objStudent);
            //UICommon.FormFactory.GetForm(UICommon.Forms.FrmFeesPayment).Visible = true;
            objRedirect.Visible = true;
        }
    }
}