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
using System.Data.SqlClient;
using ClassManager.Info.Reporting;


namespace ClassManager.WinApp.Gym
{
    public partial class FrmAddFacilities : ClassManager.WinApp.UICommon.FrmParentForm
    {
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        string sCaption = "Add facilities";

        List<FeesPackage> lstPackage;

        public Student objStudent { get; set; }
        public FeeStructure objPack { get; set; }
        bool sAllowIndexChange;
        public List<StudentFacility> takenFacilities { get; set; }
        int duration;
        List<Info.InstallmentDetail> lstInst;

        public static List<Info.StudentFacility> selctedSubjects;
        public static Decimal totalSubjectCost;
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();

        public static List<Info.InstallmentDetail> lstStudentInstallment;
        public static FeesPackage selectedPackage;
        public FrmStudentDetails studDetails;
        public static Decimal facilitiesTotalFees = 0;
        Boolean EnableDate;
        decimal totalFees = 0;
        public static bool isLumpSum;
        private List<Batch> lstBatches;
        private decimal totalDiscount;
        private bool isCustom;
        private StudentFacility lastDeletedFacility;
        public decimal discount { get; set; }
        public FrmAddFacilities(Student objStudent)
        {
            InitializeComponent();
            this.objStudent = objStudent;
            selectedPackage = new FeesPackage();
        }

        private void AddFacilities_Load(object sender, EventArgs e)
        {
            try
            {
                sAllowIndexChange = false;
                isCustom = false;

                this.Text = "Add Packages for " + objStudent.Fname + " " + objStudent.Lname + " (" + objStudent.AdmissionNo + ")";


                takenFacilities = objStudent.Facilities;

                objStudent.Facilities = new List<StudentFacility>();


                cmbStd.DisplayMember = "StandardName";
                cmbStd.ValueMember = "Standardid";

                cmbStream.DisplayMember = "StreamName";
                cmbStream.ValueMember = "Streamid";

                populateStream();
                formatForm();

                populateInstructor();

                dtpAdmissionDt.Value = objStudent.AdmissionDate;
                dtpPayStart.Value = objStudent.AdmissionDate;

                sAllowIndexChange = true;


                if (cmbStream.Items.Count > 0)
                {
                    cmbStream.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No streams available.", sCaption, this);
                }
                txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }


            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void populateInstructor()
        {
            try
            {
                cmbInstructor.Items.Clear();
                List<Faculty> faculties = FacultyHandler.getFacultyList(WinApp.Program.LoggedInUser.BranchId);
                //  cmbInstructor.ValueMember = "FacultyID";
                //  cmbInstructor.DisplayMember = "Name";
                //   cmbInstructor.DataSource = faculties;
                foreach (Info.Faculty objFaculty in faculties)
                {
                    cmbInstructor.Items.Add(new ComboItem(objFaculty.FacultyID.ToString(), objFaculty.Name));
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpAdmissionDt, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpPayStart, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtExpDate, Common.Formatter.DateFormat);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void populateStream()
        {
            try
            {
                
                List<Stream> lstStream = StreamHandller.getStreams(branchID);

                foreach (Stream objStream in lstStream)
                {
                    cmbStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void populateCourse(string stream = "%")
        {
            try
            {

                if (cmbStd.Items.Count != -1)
                {
                    cmbStd.Items.Clear();
                    List<Standard> lstStd = StandardHandller.getStandard(branchId.ToString(), stream);
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbStd.Items.Add(new ComboItem(objStandard.Standardid, objStandard.StandardName));
                    }
                    cmbStd.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No PackageType available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw;
            }
        }

        private void populatePackage(int stdID)
        {
            try
            {

                List<FeesPackage> lstPackage = FeesPackageHandller.getStandardPackages(stdID);

                foreach (FeesPackage objPack in lstPackage)
                {
                    cmbPack.Items.Add(new ComboItem(objPack.Id.ToString(), objPack.PackageName));
                }

                cmbPack.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void loadCourses()
        {
            //sAllowIndexChange = false;
            cmbStd.DataSource = StandardHandller.getStandard(((cmbStream.SelectedItem as Stream).ID).ToString());
            cmbStd.SelectedIndex = 0;
            sAllowIndexChange = true;
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange)
                {
                    String stream = (cmbStream.SelectedItem as ComboItem).strKey;
                    populateCourse(stream);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void loadPackages()
        {
            try
            {
                cmbPack.DataSource = null;
                lstPackage = FeesPackageHandller.getStandardPackages((cmbStd.SelectedItem as ComboItem).key);

                if (lstPackage.Count == 0)
                {
                    //UICommon.WinForm.showStatus("No Packages for selected standard", MessageBoxButtons.OK, MessageBoxIcon.Information, "Package Not Available", this);
                    //return;
                    pnlPkgDtls.Visible = true;
                    //pnlFinalCourses.Visible = false;
                    pnlFacilities.Visible = false;
                    var createPackage = UICommon.WinForm.showStatus("No Package Available." + System.Environment.NewLine + "Do you want to create Package for " + (cmbStd.SelectedItem as ComboItem).name + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (createPackage == DialogResult.Yes)
                    {
                        FrmSubjectPackageMasterForm objMasterForm = new FrmSubjectPackageMasterForm();
                        objMasterForm.loadfromAddFacilities(cmbStd.SelectedIndex);
                        objMasterForm.ShowDialog();
                        lstPackage = FeesPackageHandller.getStandardPackages((cmbStd.SelectedItem as ComboItem).key, UserHandler.loggedInUser.BranchId);
                        // pnlPkgDtls.Visible = true;
                        pnlFacilities.Visible = true;
                    }
                }

                cmbPack.Items.Clear();
                cmbPack.Items.Add(new ComboItem(-1, "Select Package"));

                foreach (FeesPackage feesPackage in lstPackage)
                {
                    cmbPack.Items.Add(new ComboItem(feesPackage.Id, feesPackage.PackageName));

                }
                //cmbPack.SelectedIndex = 0;

                //if (cmbPack.SelectedIndex == 0)
                //{
                //    selectedPackage = null;
                //    pnlFacilitiesDtls.Visible = false;
                //    pnlPkgDtls.Visible = true;
                //}
                //  updateFees();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void cmbStd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange)
                {
                    sAllowIndexChange = false;
                    loadPackages();
                    loadBatches();
                    sAllowIndexChange = true;
                    if (cmbPack.Items.Count > 0)
                    {
                        cmbPack.SelectedIndex = 0;
                    }

                    // changes


                    if (sAllowIndexChange == true)
                    {
                        if (cmbBatches.Items.Count == 0)
                        {
                            createBatchifEmpty();
                        }

                        else
                        {
                            sAllowIndexChange = false;
                            // txtDiscount.Text = "0";
                            int packageId = (cmbStd.SelectedItem as ComboItem).key;

                            //  if (cmbPack.SelectedIndex != -1)
                            //  {
                            if (packageId < -1)
                            {
                                selectedPackage = FeesPackageHandller.GetPackage(packageId);

                                cmdPackageFacilities.Items.Clear();
                                pnlPkgDtls.Visible = true;
                                pnlFacilitiesDtls.Visible = true;
                                //  getPackageCost(isLumpSum);
                                duration = selectedPackage.PackageDuration;
                                dtpPayStart.Value = DateTime.Now;
                                dtpAdmissionDt.Value = DateTime.Now;
                                dtExpDate.Value = DateTime.Now.AddMonths(+duration);
                                dtExpDate.Value = dtExpDate.Value.AddDays(-1);

                            }
                            else
                            {
                                selectedPackage = null;
                                pnlFacilitiesDtls.Visible = false;
                                pnlPkgDtls.Visible = true;
                            }
                            // getPackageCost(isLumpSum);
                            if (selectedPackage != null)
                            {
                                if (selectedPackage.Subjects != null)
                                {
                                    foreach (FeeStructure facility in selectedPackage.Subjects)
                                    {
                                        cmdPackageFacilities.Items.Add(facility);
                                    }
                                    // pnlPkgDtls.Visible = true;
                                    pnlFacilities.Visible = true;
                                    //nlFinalCourses.Visible = true;
                                    btnAddSubject.Enabled = true;
                                }

                                else
                                {
                                    pnlFacilities.Visible = false;
                                    btnAddSubject.Enabled = false;
                                }
                            }
                            //   }

                            // }
                            // else
                            // {
                            //   selectedPackage = null;
                            ////   pnlFacilitiesDtls.Visible = false;
                            //  pnlPkgDtls.Visible = true;
                            // }
                            sAllowIndexChange = true;
                            txtPackgCost.Text = "0.00";
                            txtPayable.Text = "0.00";
                        }
                    }








                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        //Function to open Batch Create Screen if no Batch Exists.Mohan
        private void createBatchifEmpty()
        {
            try
            {
                pnlPkgDtls.Visible = true;
                pnlFacilities.Visible = false;
                //pnlFinalCourses.Visible = false;
                var createBatch = UICommon.WinForm.showStatus("No Batch Available." + System.Environment.NewLine + "Do you want to create Batch for " + (cmbStd.SelectedItem as ComboItem).name + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                if (createBatch == DialogResult.Yes)
                {
                    FrmStandardMasterForm objMasterForm = (FrmStandardMasterForm)UICommon.FormFactory.GetForm(Forms.FrmStandardMasterForm, this, true);
                    objMasterForm.loadfromAddFacilities(cmbStream.SelectedIndex, cmbStd.SelectedIndex);
                    objMasterForm.ShowDialog();

                    lstBatches = StandardHandller.GetBatches((cmbStd.SelectedItem as ComboItem).key, UserHandler.loggedInUser.BranchId);
                    cmbBatches.DataSource = lstBatches;
                    if (cmbPack.Items.Count != 0)
                    {
                        // pnlPkgDtls.Visible = true;
                        pnlFacilities.Visible = true;
                        //nlFinalCourses.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }
        private void loadBatches()
        {
            try
            {
                cmbBatches.DataSource = null;

                lstBatches = StandardHandller.GetBatches((cmbStd.SelectedItem as ComboItem).key, Program.LoggedInUser.BranchId);

                cmbBatches.DataSource = lstBatches;
                if (lstBatches.Count != 0)
                {
                    cmbBatches.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void cmbPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                EnableDate = SysParam.getValue<bool>(SysParam.Parameters.ENABLE_EDIT_DATE);
                if (EnableDate == true)
                {
                    dtExpDate.Enabled = true;
                }
                if (cmbBatches.Items.Count == 0)
                {
                    createBatchifEmpty();
                }

                else
                {
                    sAllowIndexChange = false;
                    // txtDiscount.Text = "0";
                    int packageId = (cmbPack.SelectedItem as ComboItem).key;
                    if (packageId != -1)
                    {
                        selectedPackage = FeesPackageHandller.GetPackage(packageId);
                        cmdPackageFacilities.Items.Clear();
                        pnlPkgDtls.Visible = true;
                        pnlFacilitiesDtls.Visible = true;
                        getPackageCost(isLumpSum);
                        duration = selectedPackage.PackageDuration;
                        dtpPayStart.Value = DateTime.Now;
                        dtpAdmissionDt.Value = DateTime.Now;
                        dtExpDate.Value = DateTime.Now.AddMonths(+duration);
                        dtExpDate.Value = dtExpDate.Value.AddDays(-1);
                        if (txtDiscount.Text != "")
                        {
                            txtDiscount.Text = "";
                            txtDiscount.Hint = "Enter Discount";

                        }

                        if (selectedPackage.Subjects != null)
                        {
                            foreach (FeeStructure facility in selectedPackage.Subjects)
                            {
                                cmdPackageFacilities.Items.Add(facility);
                            }
                            // pnlPkgDtls.Visible = true;
                            pnlFacilities.Visible = true;
                            //nlFinalCourses.Visible = true;
                            btnAddSubject.Enabled = true;
                        }
                        else
                        {
                            pnlFacilities.Visible = false;
                            btnAddSubject.Enabled = false;
                        }

                        getPackageCost(isLumpSum);
                    }
                    else
                    {
                        selectedPackage = null;
                        pnlFacilitiesDtls.Visible = false;
                        pnlPkgDtls.Visible = true;
                    }
                    sAllowIndexChange = true;
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }


        }


        private void updateFees()
        {
            try
            {
                totalFees = 0;
                totalDiscount = 0;
                foreach (StudentFacility selectedFeeStructure in objStudent.Facilities)
                {
                    totalFees = totalFees + selectedFeeStructure.Package.SubjAmount;
                    totalDiscount = totalDiscount + selectedFeeStructure.Discount;
                }
                txtTotalDiscount.Text = Common.Formatter.FormatCurrency(totalDiscount);
                txtPayable.Text = Common.Formatter.FormatCurrency(totalFees - totalDiscount);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }

        }



        private void chkLumsum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLumsum.Checked)
            {
                txtPackgCost.Text = selectedPackage.LumsumAmount.ToString(Common.Formatter.CurrencyFormat);
                isLumpSum = true;
            }
            else
            {
                isLumpSum = false;
                txtPackgCost.Text = selectedPackage.PackageCost.ToString(Common.Formatter.CurrencyFormat);
            }
            getPackageCost(isLumpSum);

        }

        private void getPackageCost(bool isLumpSum = false)
        {
            discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
            if (isLumpSum)
            {
                if (selectedPackage.LumsumAmount - discount < 0)
                {
                    UICommon.WinForm.showStatus("Discount can not be greater than package amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDiscount.Text = "0";
                    discount = 0;
                }
                else
                {
                    facilitiesTotalFees = selectedPackage.LumsumAmount - discount;
                }
            }
            else
            {
                if (selectedPackage.LumsumAmount - discount < 0)
                {
                    UICommon.WinForm.showStatus("Discount can not be greater than package amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    // txtDiscount.Text = "0";
                    discount = 0;
                }
                else
                {
                    facilitiesTotalFees = selectedPackage.PackageCost - discount;
                }
            }

            if (selectedPackage.PackageType == PackageType.INSTALLMENT || selectedPackage.PackageType == PackageType.ONE_TIME)
            {
                chkOnetimeDiscount.Checked = true;
                chkOnetimeDiscount.Visible = false;
            }
            else
            {
                chkOnetimeDiscount.Checked = true;
                chkOnetimeDiscount.Visible = true;
            }
            txtPackgCost.Text = (facilitiesTotalFees + discount).ToString();
            txtPayable.Text = (facilitiesTotalFees - discount).ToString();
        }


        private void addPackage(bool isLumpsum)
        {
            StudentFacility objStudentFacility = new StudentFacility();

            if (chkLumsum.Checked)
            {
                objStudentFacility.Package.SubjAmount = selectedPackage.LumsumAmount;
            }
            else
            {
                objStudentFacility.Package.SubjAmount = selectedPackage.PackageCost;
            }

            objStudentFacility.FromDate = dtpPayStart.Value;
            objStudent.Facilities.Add(objStudentFacility);
            cmbSelectedPackages.DataSource = null;
            cmbSelectedPackages.DataSource = objStudent.Facilities;
            updateFees();
        }


        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Decimal newDiscount;

            if (Decimal.TryParse(txtDiscount.Text, out newDiscount) == true)
            {
                discount = newDiscount;
            }

            if (chkLumsum.Checked)
            {
                getPackageCost(true);
            }
            else
            {
                getPackageCost();
            }
        }



        private void bgwStudRegistred_DoWork(object sender, DoWorkEventArgs e)
        {
            objStudent = (Student)e.Argument;
            MailHandler.sendRegistrationSms(objStudent, objStudent.DisplayName, objStudent.Fees.TotalFees, objStudent.RollNo, objStudent.ContactNo, Program.LoggedInUser.BranchName);
        }

        private void bgwStudRegistred_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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


        private void saveDetails()
        {
            if (objStudent.Facilities.Count > 0)
            {
                //Roll No is Passed
                objStudent.Facilities[0].Student.RollNo = (txtRollNo.Text == "") ? objStudent.RollNo : txtRollNo.Text;

                StudentHandller.addStudentFacilities(objStudent, objStudent.Facilities, objStudent.BiometricId, 0);

                //UICommon.WinForm.showStatus("Courses added Successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                bgwStudRegistred.RunWorkerAsync(objStudent);
                if (false && SysParam.getValue<bool>(SysParam.Parameters.GENERATE_INVOICE) == true) //This should not be generated automatically in any case
                {
                    try
                    {

                        Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();

                        objFeeData.BranchId = branchId;
                        objFeeData.PaymentDate = dtpPayStart.Value;
                        Info.Branch obj = new Branch();
                        obj = BLL.BranchHandler.getBranch(Convert.ToInt16(branchId));
                        string Receipt = SysParam.getValue<int>(SysParam.Parameters.FINANCIAL_YEAR).ToString() + '/' + branchId + '/' + obj.InvoiceNo.ToString();
                        objFeeData.ReceiptNo = Receipt;
                        objFeeData.RollNo = objStudent.RollNo;
                        objFeeData.RupeesInWord = Utility.currencyInWords(objStudent.Facilities[0].Package.PackageCost - objStudent.Facilities[0].Discount);
                        objFeeData.ServiceTax = SysParam.getValue<int>(SysParam.Parameters.SERVICE_TAX);
                        objFeeData.Standard = objStudent.NewCourse;
                        objFeeData.StudentName = objStudent.Fname + ' ' + objStudent.Lname;
                        objFeeData.FatherContactNo = objStudent.ContactNo;
                        objFeeData.EmailId = objStudent.EmailID;
                        objFeeData.ParentName = objStudent.ParentName;
                        objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);
                        objFeeData.TotalFees = (objStudent.Facilities[0].Package.TotalFees);
                        objFeeData.SirName = Info.SysParam.getValue<String>(SysParam.Parameters.SIR_NAME);
                        //objFeeData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.CLASS_ADDRESS
                        objFeeData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                        objFeeData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                        objFeeData.CmpnyPanNO = Info.SysParam.getValue<String>(SysParam.Parameters.COMPANY_PAN_NO);
                        objFeeData.CINNO = Info.SysParam.getValue<String>(SysParam.Parameters.CIN_NO);
                        //objFeeData.SubClassname = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_CLASSNAME);
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
                        //objFeeData.OutstandingAmount = (Convert.ToDecimal(lblOFees.Text)-Convert.ToDecimal(lblDiscountGiven.Text));
                        objFeeData.OutstandingAmount = objStudent.Facilities[0].Package.PackageCost - objStudent.Facilities[0].Discount;
                        if (Math.Sign(objFeeData.OutstandingAmount) == -1)
                        {
                            objFeeData.OutstandingAmount = decimal.Zero;
                        }
                        objFeeData.MembershipNo = objStudent.MembershipNo;


                        objFeeData.CashPayment = objStudent.Fees.CashAmnt + objStudent.Fees.TransferAmount;
                        objFeeData.ChequePayment = objStudent.Fees.ChequeAmnt + objStudent.Fees.PndgChqAmnt;
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
                        objFeeData.PackageName = objStudent.Facilities[0].Package.PackageName;
                        objFeeData.PackageAmount = objStudent.Facilities[0].Package.PackageCost - objStudent.Facilities[0].Discount;
                        objFeeData.SACCode = objStudent.Facilities[0].Package.SACCode;
                        objFeeData.TuitionFees = objStudent.Facilities[0].Package.PackageCost;
                        objFeeData.DisCount = objStudent.Facilities[0].Discount;
                        objFeeData.ClientGSTNo = objStudent.GSTNo;

                        double PackageAmt = Convert.ToDouble(objFeeData.PackageAmount);
                        double nontax = (PackageAmt / 1.18);
                        double cgst = (nontax * 0.09);
                        objFeeData.CGST = cgst.ToString();
                        objFeeData.NonTaxAmount = nontax.ToString();

                        string stflId = objStudent.Facilities[0].Id.ToString();
                        BLL.FeesHandller.InsertInvoice(Convert.ToInt16(branchId), objFeeData, stflId);



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
                        else
                        {
                            objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE");
                        }

                        objPrintngConfig.exportFileName = "INVOICE_REPORT_" + objStudent.AdmissionNo + "_" + Receipt.Replace(@"/", "-");
                        objPrintngConfig.sendSMS = true;
                        objPrintngConfig.sendEmail = true;
                        FrmReportViewer frmRprtViewer = new FrmReportViewer();
                        frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
                        FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;

                        FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment); ;
                        objRedirect.LoadFeeDetailsFromRegistration(objStudent);
                        objRedirect.Visible = true;
                        if (SysParam.getValue<bool>(SysParam.Parameters.SEND_INVOICE_MAIL) == true)
                        {
                            bgwInvoice.RunWorkerAsync(objFeeData);
                        }
                    }

                    catch (Exception ex)
                    {
                        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    }
                }

                this.Close();
                bool feesscreen = ClassManager.Properties.Settings.Default.ShowPaymentScreen;
                if (feesscreen == true)
                {
                    FrmFeesPayment objRedirect = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment); ;
                    objRedirect.LoadFeeDetailsFromRegistration(objStudent);
                    objRedirect.Visible = true;

                }
            }
            else
            {
                UICommon.WinForm.showStatus("No Package Available to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
        }

        private void cmbSelectedPackages_Click(object sender, EventArgs e)
        {
            if (cmbSelectedPackages.Items.Count >= 0)
            {
                btnRemoveSubject.Visible = true;
                btnRemoveSubject.Text = "Remove";
            }
            else
            {
                btnRemoveSubject.Visible = false;
            }
        }


        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdPackageFacilities.SelectedItem != null)
                {
                    Info.StudentFacility objNewFacility = new StudentFacility();

                    objNewFacility.Package = (cmdPackageFacilities.SelectedItem as Info.FeesPackage).Clone();


                    if (objStudent.Facilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage).Count() > 0)
                    {
                        UICommon.WinForm.showStatus("Package is already added. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else if (takenFacilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage && facility.Status == "A" && facility.ToDate > DateTime.Now).Count() > 0)
                    {
                        UICommon.WinForm.showStatus("This package is currently active.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        objNewFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                        //objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
                        objNewFacility.FacilityName = objNewFacility.Package.PackageName;
                        objNewFacility.Student.RollNo = txtRollNo.Text;
                        objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
                        objNewFacility.Package.Standard = selectedPackage.Standard;


                        FrmMonthSelector frmMnthSelector = new FrmMonthSelector(objStudent);
                        frmMnthSelector.feeStructure = objNewFacility;

                        frmMnthSelector.ShowDialog();

                        objNewFacility.selectedMonths = frmMnthSelector.selectedMonths;
                        objNewFacility.Amount = objNewFacility.Package.SubjAmount * objNewFacility.selectedMonths.Count;

                        //Added DiscountReason.Mohan(11-Aug-2017).
                        objNewFacility.DiscountReason = txtReason.Text;
                        //Mohan(11-Aug-2017).

                        if (frmMnthSelector.selectedMonths.Count > 0)
                        {
                            objStudent.Facilities.Add(objNewFacility);
                            cmbSelectedPackages.DataSource = null;
                            cmbSelectedPackages.DataSource = objStudent.Facilities;
                            BLL.FeesHandller.calculateInstallments(objNewFacility);
                            updateFees();
                        }
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Please select Facility to Add.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnRemoveSubject_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbSelectedPackages.SelectedItem != null)
                {
                    lastDeletedFacility = cmbSelectedPackages.SelectedItem as StudentFacility;
                    objStudent.Facilities.Remove(lastDeletedFacility);
                    cmbSelectedPackages.DataSource = null;
                    cmbSelectedPackages.DataSource = objStudent.Facilities;
                    updateFees();
                }
                else
                {
                    UICommon.WinForm.showStatus("Select PackageType to remove.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private void btnViewInstallments_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSelectedPackages.Items.Count != 0)
                {
                    FrmStudentInstallments frmStudentInstallements = new FrmStudentInstallments();
                    Info.FeesPackage objFeeStruct = new FeesPackage();

                    frmStudentInstallements.setInstallments(objStudent.Facilities[cmbSelectedPackages.SelectedIndex]);
                    frmStudentInstallements.ShowDialog();
                    updateFees();

                }
                else
                {
                    UICommon.WinForm.showStatus("Please Add Package to view Installment Details", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //

                try
                {
                    if (selectedPackage != null && cmbPack.SelectedIndex != -1)
                    {
                        Info.StudentFacility objNewFacility = new StudentFacility();

                        objNewFacility.Package = selectedPackage;

                        if (objStudent.Facilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage).Count() > 0)
                        {
                            UICommon.WinForm.showStatus("Package is already added. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        else if (takenFacilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage && facility.Status == "A").Count() > 0)
                        {
                            UICommon.WinForm.showStatus("This package is already taken by " + objStudent.DisplayName + ".", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        else
                        {
                            objNewFacility.FromDate = dtpPayStart.Value;
                            objNewFacility.Package.IsLumSum = chkLumsum.Checked;
                            objNewFacility.AdmissionDate = dtpAdmissionDt.Value;
                            objNewFacility.Discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
                            // objNewFacility.RenewDiscount = !chkOnetimeDiscount.Checked;
                            if (cmbDiscount.SelectedIndex == 0)
                            {
                                objNewFacility.RenewalDiscount = 0;
                            }
                            else
                            {
                                objNewFacility.RenewalDiscount = 1;
                            }
                            objNewFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                            objNewFacility.Student.RollNo = (txtRollNo.Text == "") ? objStudent.RollNo : txtRollNo.Text; ;
                            objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
                            objNewFacility.FacilityName = selectedPackage.PackageName;
                            objNewFacility.DiscountReason = txtReason.Text;
                            objNewFacility.ToDate = dtExpDate.Value;
                            if(cmbInstructor.SelectedIndex == -1)
                            {
                                objNewFacility.InstructorId = 0;
                            }
                            else
                            {
                                objNewFacility.InstructorId = ((ClassManager.Info.ComboItem)cmbInstructor.SelectedItem).key;
                            }
                            
                            //((cmbInstructor.SelectedItem as ComboItem).key);
                            //((ClassManager.Info.ComboItem)cmbInstructor.SelectedItem).key;
                            //Convert.ToInt32(cmbInstructor.SelectedValue).;
                            if (objNewFacility.Package.IsLumSum)
                            {
                                objNewFacility.Amount = objNewFacility.Package.LumsumAmount;
                            }
                            else
                            {
                                objNewFacility.Amount = objNewFacility.Package.PackageCost;
                            }

                            objStudent.Facilities.Add(objNewFacility);
                            cmbSelectedPackages.DataSource = null;
                            cmbSelectedPackages.DataSource = objStudent.Facilities;
                            BLL.FeesHandller.calculateInstallments(objNewFacility);
                            updateFees();
                            saveDetails();
                            if (objNewFacility.Discount > 0)
                            {
                                BLL.UserHandler.createActivity(objStudent.AdmissionNo, DateTime.Now.Date, "Discount Given: " + txtDiscount.Text + " reason for discount " + objNewFacility.DiscountReason, objStudent.DisplayName, "0", txtDiscount.Text, Program.LoggedInUser.UserId, Program.LoggedInUser.BranchId.ToString());
                            }
                            btnRemoveSubject.Visible = true;
                            //  txtDiscount.Text = "0";
                            //nlFinalCourses.Visible = true;
                        }

                    }
                    else
                    {
                        if (cmbBatches.SelectedIndex == -1)
                        {
                            UICommon.WinForm.showStatus("Please select Batch to add. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        else if (cmbPack.SelectedIndex == 0)
                        {
                            UICommon.WinForm.showStatus("Please select package to add. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }

                    }

                }
                catch (Exception ex)
                {
                    Common.Log.LogError(ex);
                    UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }


            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Roll No already exist."))
                {
                    UICommon.WinForm.showStatus("Roll No already used.", sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPackage != null)
                {
                    Info.StudentFacility objNewFacility = new StudentFacility();

                    objNewFacility.Package = selectedPackage;

                    if (objStudent.Facilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage).Count() > 0)
                    {
                        UICommon.WinForm.showStatus("Package is already added. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else if (takenFacilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage && facility.Status == "A").Count() > 0)
                    {
                        UICommon.WinForm.showStatus("This package is already taken by student.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        objNewFacility.FromDate = dtpPayStart.Value;
                        objNewFacility.Package.IsLumSum = chkLumsum.Checked;
                        objNewFacility.AdmissionDate = dtpAdmissionDt.Value;
                        objNewFacility.Discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
                        // objNewFacility.RenewDiscount = !chkOnetimeDiscount.Checked;
                        if (cmbDiscount.SelectedIndex == 0)
                        {
                            objNewFacility.RenewalDiscount = 0;
                        }
                        else
                        {
                            objNewFacility.RenewalDiscount = 1;
                        }
                        objNewFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                        objNewFacility.Student.RollNo = (txtRollNo.Text == "") ? objStudent.RollNo : txtRollNo.Text; ;
                        objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
                        objNewFacility.FacilityName = selectedPackage.PackageName;
                        objNewFacility.DiscountReason = txtReason.Text;
                        objNewFacility.ToDate = dtExpDate.Value;
                        if (objNewFacility.Package.IsLumSum)
                        {
                            objNewFacility.Amount = objNewFacility.Package.LumsumAmount;
                        }
                        else
                        {
                            objNewFacility.Amount = objNewFacility.Package.PackageCost;
                        }

                        objStudent.Facilities.Add(objNewFacility);
                        cmbSelectedPackages.DataSource = null;
                        cmbSelectedPackages.DataSource = objStudent.Facilities;
                        BLL.FeesHandller.calculateInstallments(objNewFacility);
                        updateFees();
                        btnRemoveSubject.Visible = true;
                        txtDiscount.Text = "0";
                        //nlFinalCourses.Visible = true;
                    }

                }
                else
                {
                    if (cmbBatches.SelectedIndex == -1)
                    {
                        UICommon.WinForm.showStatus("Please select Batch to add. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else if (cmbPack.SelectedIndex == 0)
                    {
                        UICommon.WinForm.showStatus("Please select package to add. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void dtpPayStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpAdmissionDt.Value = dtpPayStart.Value;
                // getPackageCost(isLumpSum);
                duration = selectedPackage.PackageDuration;

                dtExpDate.Value = dtpPayStart.Value.AddMonths(+duration);
                dtExpDate.Value = dtExpDate.Value.AddDays(-1);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtExpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                decimal Fees;
                decimal dscnt = 0;
                if (!txtDiscount.Text.Equals(""))
                {
                    dscnt = Convert.ToDecimal(txtDiscount.Text);
                }

                txtTotalDiscount.Text = Common.Formatter.FormatCurrency(dscnt);
                if (dscnt <= selectedPackage.PackageCost)
                {
                    Fees = selectedPackage.PackageCost - dscnt;
                    txtPayable.Text = Common.Formatter.FormatCurrency(Fees);
                }
                else
                {

                    txtPayable.Text = Common.Formatter.FormatCurrency(selectedPackage.PackageCost);

                    UICommon.WinForm.showStatus("Discount Amount Canot be Greater than the Package Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDiscount.Text = "0";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bgwInvoice_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool sendMail = (SysParam.getValue<bool>(SysParam.Parameters.SEND_INVOICE_MAIL));
                FeeReceiptReportData objFeeReceiptdata = (FeeReceiptReportData)e.Argument;
                MailHandler.sendInvoiceMail(objFeeReceiptdata, false, sendMail, branchId);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void bgwInvoice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
                }
                else
                {
                    UICommon.FormFactory.setMainFormStatus("Mail Sent Successfully for Invoice from " + sCaption);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
