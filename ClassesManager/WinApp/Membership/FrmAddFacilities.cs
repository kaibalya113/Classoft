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

namespace ClassManager.WinApp
{
    public partial class FrmAddFacilities : ClassManager.WinApp.UICommon.FrmParentForm
    {
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        string sCaption = "Add facilities";

        List<FeesPackage> lstPackage;
        int duration;
        public Student objStudent { get; set; }
        public FeeStructure objPack { get; set; }
        bool sAllowIndexChange;
        public List<StudentFacility> takenFacilities { get; set; }

        List<Info.InstallmentDetail> lstInst;

        public static List<Info.StudentFacility> selctedSubjects;
        public static Decimal totalSubjectCost;
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();

        public static List<Info.InstallmentDetail> lstStudentInstallment;
        public static FeesPackage selectedPackage;
        public FrmStudentDetails studDetails;
        public static Decimal facilitiesTotalFees = 0;

        decimal totalFees = 0;
        public static bool isLumpSum;
        private List<Batch> lstBatches;
        private decimal totalDiscount;
        private bool isCustom;
        private StudentFacility lastDeletedFacility;
        List<ScheduledLecture> lstlect = new List<ScheduledLecture>();
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

                this.Text = "Add Cources for " + objStudent.Fname + " " + objStudent.Lname + " (" + objStudent.AdmissionNo + ")";


                takenFacilities = objStudent.Facilities;

                objStudent.Facilities = new List<StudentFacility>();


                cmbStd.DisplayMember = "StandardName";
                cmbStd.ValueMember = "Standardid";

                cmbStream.DisplayMember = "StreamName";
                cmbStream.ValueMember = "Streamid";

                populateStream();
                formatForm();

                dtpAdmissionDt.Value = DateTime.Now;
                dtpPayStrt.Value = DateTime.Now;

                sAllowIndexChange = true;

                AddColumn();
                if (cmbStream.Items.Count > 0)
                {
                    cmbStream.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No streams available.", sCaption, this);
                }

                txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                pnlLecture.Visible = false;
                this.Height = 400;
            }


            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }

        }

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpAdmissionDt, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpPayStrt, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtExpDate, Common.Formatter.DateFormat);

                UICommon.WinForm.formatDateTimePicker(dtpPayStart, Common.Formatter.DateFormat);

                bool enableDate, Lecturewise;

                enableDate = SysParam.getValue<bool>(SysParam.Parameters.ENABLE_EDIT_DATE);
                Lecturewise = SysParam.getValue<bool>(SysParam.Parameters.LECTUREWISE_ATTD);

                if (Lecturewise == true)
                {
                    btnScheduleLect.Visible = true;
                    txtBiometricId.Visible = true;
                    txtLectureCount.Visible = true;
                    ADGVLecture.DataSource = null;
                    pnlLecture.Visible = true;
                    lblExpDate.Visible = true;
                    dtExpDate.Visible = true;
                    dtExpDate.Enabled = true;
                   
                }
                else
                {
                    btnScheduleLect.Visible = false;
                    txtBiometricId.Visible = false;
                    txtLectureCount.Visible = false;
                    ADGVLecture.DataSource = null;
                    pnlLecture.Visible = false;
                }

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
                    UICommon.WinForm.showStatus("No courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

                cmbPack.SelectedIndex = 0;


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
                    pnlPkgDtls.Visible = false;
                    pnlFinalCourses.Visible = false;
                    var createPackage = UICommon.WinForm.showStatus("No Package Available." + System.Environment.NewLine + "Do you want to create Package for " + (cmbStd.SelectedItem as ComboItem).name + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (createPackage == DialogResult.Yes)
                    {
                        FrmSubjectPackageMasterForm objMasterForm = new FrmSubjectPackageMasterForm();
                        objMasterForm.loadfromAddFacilities(cmbStd.SelectedIndex);
                        objMasterForm.ShowDialog();
                        lstPackage = FeesPackageHandller.getStandardPackages((cmbStd.SelectedItem as ComboItem).key, UserHandler.loggedInUser.BranchId);
                        pnlPkgDtls.Visible = true;
                    }
                }

                cmbPack.Items.Clear();
                cmbPack.Items.Add(new ComboItem(-1, "Select Package"));

                foreach (FeesPackage feesPackage in lstPackage)
                {
                    cmbPack.Items.Add(new ComboItem(feesPackage.Id, feesPackage.PackageName));
                }
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
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void createBatchifEmpty()
        {
            try
            {
                pnlPkgDtls.Visible = false;
                pnlFinalCourses.Visible = false;
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
                        pnlPkgDtls.Visible = true;
                        pnlFinalCourses.Visible = false;
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

                //if (lstBatches.Count == 0)
                //{
                //    pnlPkgDtls.Visible = false;
                //    pnlFacilities.Visible = false;
                //    var createBatch = UICommon.WinForm.showStatus("No Batch Available." + System.Environment.NewLine + "Do you want to create Batch for " + (cmbStd.SelectedItem as ComboItem).name + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                //    if (createBatch == DialogResult.Yes)
                //    {
                //        FrmStandardMasterForm objMasterForm = new FrmStandardMasterForm();
                //        objMasterForm.loadfromAddFacilities(cmbStd.SelectedIndex);
                //        objMasterForm.ShowDialog();
                //        lstBatches = StandardHandller.GetBatches((cmbStd.SelectedItem as ComboItem).key, UserHandler.loggedInUser.BranchId);
                //        pnlPkgDtls.Visible = true;
                //        pnlFacilities.Visible = true;
                //        //this.Close();
                //    }
                //    createBatchifEmpty();
                //}
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
                if (sAllowIndexChange == true)
                {
                    if (cmbBatches.Items.Count == 0)
                    {
                        createBatchifEmpty();
                    }

                    sAllowIndexChange = false;
                    int packageId = (cmbPack.SelectedItem as ComboItem).key;
                    if (packageId != -1)
                    {
                        selectedPackage = FeesPackageHandller.GetPackage(packageId);

                        pnlFacilitiesDtls.Visible = true;
                        getPackageCost(isLumpSum);
                        duration = selectedPackage.PackageDuration;
                        dtpPayStrt.Value = DateTime.Now;
                        dtpAdmissionDt.Value = DateTime.Now;
                        dtExpDate.Value = DateTime.Now.AddMonths(+duration);
                        dtExpDate.Value = dtExpDate.Value.AddDays(-1);
                            
                    }
                    else
                    {
                        selectedPackage = null;
                        pnlFacilitiesDtls.Visible = false;
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

        //private void btnAddSubject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmdPackageFacilities.SelectedItem != null)
        //        {
        //            Info.StudentFacility objNewFacility = new StudentFacility();

        //            objNewFacility.Package = (cmdPackageFacilities.SelectedItem as Info.FeesPackage).Clone();


        //            if (objStudent.Facilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage).Count() > 0)
        //            {
        //                UICommon.WinForm.showStatus("Package is already added. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else if (takenFacilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage && facility.Status == "A" && facility.ToDate > DateTime.Now).Count() > 0)
        //            {
        //                UICommon.WinForm.showStatus("This package is currently active.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else
        //            {
        //                objNewFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
        //                //objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
        //                objNewFacility.FacilityName = objNewFacility.Package.PackageName;
        //                objNewFacility.Student.RollNo = txtRollNo.Text;
        //                objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
        //                objNewFacility.Package.Standard = selectedPackage.Standard;


        //                FrmMonthSelector frmMnthSelector = new FrmMonthSelector();
        //                frmMnthSelector.feeStructure = objNewFacility;

        //                frmMnthSelector.ShowDialog();

        //                objNewFacility.selectedMonths = frmMnthSelector.selectedMonths;
        //                objNewFacility.Amount = objNewFacility.Package.SubjAmount * objNewFacility.selectedMonths.Count;

        //                if (frmMnthSelector.selectedMonths.Count > 0)
        //                {
        //                    objStudent.Facilities.Add(objNewFacility);
        //                    cmbSelectedPackages.DataSource = null;
        //                    cmbSelectedPackages.DataSource = objStudent.Facilities;
        //                    BLL.FeesHandller.calculateInstallments(objNewFacility);
        //                    updateFees();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("Please select course to Add.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex);
        //        UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}
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


        //private void btnRemoveSubject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbSelectedPackages.SelectedItem != null)
        //        {
        //            lastDeletedFacility = cmbSelectedPackages.SelectedItem as StudentFacility;
        //            objStudent.Facilities.Remove(lastDeletedFacility);
        //            cmbSelectedPackages.DataSource = null;
        //            cmbSelectedPackages.DataSource = objStudent.Facilities;
        //            updateFees();
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("Select course to remove.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex);
        //        UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        saveDetails();
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private void chkLumsum_CheckedChanged(object sender, EventArgs e)
        {

            isLumpSum = false;
            txtPackgCost.Text = selectedPackage.PackageCost.ToString(Common.Formatter.CurrencyFormat);

            getPackageCost(isLumpSum);

        }

        private void getPackageCost(bool isLumpSum = false)
        {
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
                    txtDiscount.Text = "0";
                    discount = 0;
                }
                else
                {
                    facilitiesTotalFees = selectedPackage.PackageCost - discount;
                }
            }

          
            txtPackgCost.Text = (facilitiesTotalFees + discount).ToString();
        }


        private void addPackage(bool isLumpsum)
        {
            StudentFacility objStudentFacility = new StudentFacility();

            
            objStudentFacility.Package.SubjAmount = selectedPackage.PackageCost;
           

            objStudentFacility.FromDate = dtpPayStrt.Value;
            objStudent.Facilities.Add(objStudentFacility);
            cmbSelectedPackages.DataSource = null;
            cmbSelectedPackages.DataSource = objStudent.Facilities;
            updateFees();
        }

        //private void btnAddPackage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (selectedPackage != null)
        //        {
        //            Info.StudentFacility objNewFacility = new StudentFacility();

        //            objNewFacility.Package = selectedPackage;

        //            if (objStudent.Facilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage).Count() > 0)
        //            {
        //                UICommon.WinForm.showStatus("Package is already added. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else if (takenFacilities.Where(facility => facility.Package.Id == objNewFacility.Package.Id && facility.Package.IsMainPackage == objNewFacility.Package.IsMainPackage && facility.Status == "A").Count() > 0)
        //            {
        //                UICommon.WinForm.showStatus("This package is already taken by student.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else
        //            {
        //                objNewFacility.FromDate = dtpPayStart.Value;
        //                objNewFacility.Package.IsLumSum = chkLumsum.Checked;
        //                objNewFacility.AdmissionDate = dtpAdmissionDt.Value;
        //                objNewFacility.Discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
        //                objNewFacility.RenewDiscount = chkOnetimeDiscount.Checked;
        //                objNewFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
        //                objNewFacility.Student.RollNo = txtRollNo.Text;
        //                objNewFacility.Student.Batch = (cmbBatches.SelectedItem as Batch);
        //                objNewFacility.FacilityName = selectedPackage.PackageName;


        //                if (objNewFacility.Package.IsLumSum)
        //                {
        //                    objNewFacility.Amount = objNewFacility.Package.LumsumAmount;
        //                }
        //                else
        //                {
        //                    objNewFacility.Amount = objNewFacility.Package.PackageCost;
        //                }

        //                objStudent.Facilities.Add(objNewFacility);
        //                cmbSelectedPackages.DataSource = null;
        //                cmbSelectedPackages.DataSource = objStudent.Facilities;
        //                BLL.FeesHandller.calculateInstallments(objNewFacility);
        //                updateFees();
        //                btnRemoveSubject.Visible = true;
        //                txtDiscount.Text = "0";
        //                pnlFinalCourses.Visible = true;
        //            }

        //        }
        //        else
        //        {
        //            if (cmbBatches.SelectedIndex == -1)
        //            {
        //                UICommon.WinForm.showStatus("Please select Batch to add. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else if (cmbPack.SelectedIndex == 0)
        //            {
        //                UICommon.WinForm.showStatus("Please select package to add. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex);
        //        UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }

        //}

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Decimal newDiscount;

            if (Decimal.TryParse(txtDiscount.Text, out newDiscount) == true)
            {
                discount = newDiscount;
            }

           
                getPackageCost();
            
        }

        public decimal discount { get; set; }

        private void bgwStudRegistred_DoWork(object sender, DoWorkEventArgs e)
        {
            objStudent = (Student)e.Argument;
            MailHandler.sendRegistrationSms(objStudent, objStudent.DisplayName, objStudent.Fees.TotalFees, objStudent.RollNo, objStudent.FatherContactNo, Program.LoggedInUser.BranchName);
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

        //private void btnViewInstallments_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbSelectedPackages.Items.Count != 0)
        //        {
        //            FrmStudentInstallments frmStudentInstallements = new FrmStudentInstallments();
        //            Info.FeesPackage objFeeStruct = new FeesPackage();

        //            frmStudentInstallements.setInstallments(objStudent.Facilities[cmbSelectedPackages.SelectedIndex]);
        //            frmStudentInstallements.ShowDialog();                  
        //            updateFees();

        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("Please Add Package to view Installment Details", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex);
        //        UICommon.WinForm.showError(ex, sCaption, this);
        //    }
        //}




        private void saveDetails()
        {

            // For Inserting in to StudentLecture Table (change done  for Artistic Impresssion )

            if (lstlect.Count > 0)
            {
                foreach (ScheduledLecture objLecture in lstlect)
                {
                    objLecture.AdmissionNo = objStudent.AdmissionNo.ToString();
                    objLecture.Standard = (cmbStd.SelectedItem as ComboItem).key;
                    if (txtBiometricId.Text == "")
                    {
                        objLecture.BiometricId = objStudent.AdmisionNo;
                    }
                    else
                    {
                        objLecture.BiometricId = Convert.ToInt64(txtBiometricId.Text);
                    }
                    BLL.LectureHandler.insertScheduledLect(objLecture, Convert.ToInt16(branchID));

                }
            }


            //For inserting into the StudentFacility and StudentAdmission

            if (objStudent.Facilities.Count > 0)
            {
                int biom; int count;
                //Roll No is Passed
                objStudent.Facilities[0].Student.RollNo = (txtRollNo.Text == "") ? objStudent.RollNo : txtRollNo.Text;
                if (txtBiometricId.Text == "")
                {
                    biom = objStudent.AdmisionNo;
                }
                else
                {
                    biom = Convert.ToInt16(txtBiometricId.Text);
                }
                if (txtLectureCount.Text == "")
                {
                    count = 0;
                }
                else
                {
                    count = Convert.ToInt16(txtLectureCount.Text);
                }
                StudentHandller.addStudentFacilities(objStudent, objStudent.Facilities, biom, count);

                // UICommon.WinForm.showStatus("Courses added Successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                bgwStudRegistred.RunWorkerAsync(objStudent);
             //   UICommon.WinForm.showStatus("Courses added Successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);


                try
                {
                    //Closes the AddFacility Form.
                    this.Close();


                    FrmFeesPayment objFees = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
                    objFees.LoadFeeDetailsFromRegistration(objStudent);
                    objFees.Visible = true;
                }
                catch (Exception ex)
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }


            }
            else
            {
                UICommon.WinForm.showStatus("No Course Available to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
                    UICommon.WinForm.showStatus("Select course to remove.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
                    //frmStudentInstallements.Visible = true;
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
                saveDetails();
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
                        objNewFacility.FromDate = dtpPayStrt.Value;
                        objNewFacility.Package.IsLumSum = false;
                        objNewFacility.AdmissionDate = dtpAdmissionDt.Value;
                        objNewFacility.Discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
                        //objNewFacility.RenewDiscount = !chkOnetimeDiscount.Checked;
                        
                            objNewFacility.RenewalDiscount = 1;
                       

                        objNewFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                        objNewFacility.Student.RollNo = (txtRollNo.Text == "") ? objStudent.RollNo : txtRollNo.Text;
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
                        // txtDiscount.Text = "0";
                        pnlFinalCourses.Visible = true;
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

                //dtpAdmissionDt.Value = dtpPayStrt.Value;
                getPackageCost(isLumpSum);
                duration = selectedPackage.PackageDuration;

                dtExpDate.Value = dtpPayStrt.Value.AddMonths(+duration);
                dtExpDate.Value = dtExpDate.Value.AddDays(-1);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtpAdmissionDt_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                // dtpAdmissionDt.Value = dtpPayStart.Value;
                //getPackageCost(isLumpSum);
                //duration = selectedPackage.PackageDuration;

                //dtExpDate.Value = dtpAdmissionDt.Value.AddMonths(+duration);
                //dtExpDate.Value = dtExpDate.Value.AddDays(-1);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pnlPkgDtls_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnLectureAdd_Click(object sender, EventArgs e)
        {
            try
            {

                ScheduledLecture objLect = new ScheduledLecture();
                objLect.Day = cmbDay.SelectedItem.ToString();
                objLect.FromTime = Convert.ToDateTime(fromTime.Value.ToShortTimeString());
                objLect.ToTime = Convert.ToDateTime(ToTime.Value.ToShortTimeString());

                lstlect.Add(objLect);
                if (lstlect.Count != 0)
                {
                    ADGVLecture.DataSource = null;
                    ADGVLecture.DataSource = WinForm.ToDataTable(lstlect);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void formatLectureGrid()
        {
            try
            {
                if (ADGVLecture.Rows.Count > 0)
                {
                    //Setting Visibility and formatting cellstyle
                    ADGVLecture.Columns[3].DisplayIndex = 0;
                    ADGVLecture.Columns[1].DisplayIndex = 1;
                    ADGVLecture.Columns[2].DisplayIndex = 2;

                    ADGVLecture.Columns[4].Visible = false;
                    ADGVLecture.Columns[5].Visible = false;
                    ADGVLecture.Columns[6].Visible = false;

                    ADGVLecture.Columns["FromTime"].DefaultCellStyle.Format = Common.Formatter.TimeFormat;
                    ADGVLecture.Columns["ToTime"].DefaultCellStyle.Format = Common.Formatter.TimeFormat;

                    ADGVLecture.Columns["Delete"].DisplayIndex = ADGVLecture.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ADGVLecture_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            formatLectureGrid();
            foreach (DataGridViewRow adrow in ADGVLecture.Rows)
            {

                adrow.Height = 30;
                adrow.MinimumHeight = 30;

            }

            ADGVLecture.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
        }

        private void btnScheduleLect_Click(object sender, EventArgs e)
        {
            try
            {
                fromTime.CustomFormat = "HH:mm:tt";
                ToTime.CustomFormat = "HH:mm:tt";
                if (pnlLecture.Visible == true)
                {
                    pnlLecture.Visible = false;

                }
                else
                {
                    pnlLecture.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void AddColumn()
        {
            try
            {
                ADGVLecture.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.deleteBin,

                    Name = "Delete",
                    HeaderText = "Delete"
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnLectSave_Click(object sender, EventArgs e)
        {
            try
            {

                bool retrnCode = false;

                if (lstlect.Count > 0)
                {
                    foreach (ScheduledLecture objLecture in lstlect)
                    {
                        objLecture.AdmissionNo = objStudent.AdmissionNo.ToString();
                        objLecture.Standard = (cmbStd.SelectedItem as ComboItem).key;
                        objLecture.BiometricId = Convert.ToInt16(txtBiometricId.Text);
                        retrnCode = BLL.LectureHandler.insertScheduledLect(objLecture, Convert.ToInt16(branchID));

                    }
                }

                if (retrnCode == true)
                {
                    UICommon.WinForm.showStatus("Sessions saved successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

                else
                {
                    UICommon.WinForm.showStatus("Can't save Sessions", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void ADGVLecture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ADGVLecture.Columns["Delete"].Index)
                    {
                        int lectureId;
                        foreach (DataGridViewRow lecture in ADGVLecture.Rows)
                        {
                            if (lecture.Cells[0].Selected != false && lecture.Cells[0].Selected)// && lecture.Cells["LectureID"].Value=="0")
                            {
                                if (lstlect.Count != 0)
                                {


                                    lstlect.RemoveAt(e.RowIndex);
                                    ADGVLecture.Refresh();
                                    ADGVLecture.DataSource = UICommon.WinForm.ToDataTable(lstlect);

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
                                        // List<Lecture> lstlecture = BLL.LectureHandler.getLectures(dtpLect.Value, (cmbBtch.SelectedItem as ComboItem).key);
                                        // ADGVLecture.DataSource = lstlecture;
                                    }
                                    else
                                    {

                                        ADGVLecture.Refresh();
                                    }
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pnlFinalCourses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

