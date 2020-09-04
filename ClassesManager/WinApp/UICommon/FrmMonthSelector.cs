using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
using ClassManager.Info.Reporting;
using ClassManager.Common;
using System.Data.SqlClient;
using ClassManager.BLL;

namespace ClassManager.WinApp
{
    public partial class FrmMonthSelector : FrmParentForm
    {

        RolePrivilege formPrevileges;
        decimal AmountPaid;

        string sCaption = "Month Selector ";
        public List<DateTime> selectedMonths;
        List<Label> lstCheckBoxes;
        List<FeesPackage> lstPackage;
        public StudentFacility feeStructure;
        public static Info.Student objStud;
        public Student objStudent { get; set; }
        public StudentFacility objstfl { get; set; }
        public static FeesPackage selectedPackage;
        int id; int stdid;
        Boolean Upgrade = false;
        private List<Batch> lstBatches;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        //Variable declared to identify from where this form is opened.
        //public bool isManaulRenewal=false;


        public FrmMonthSelector(Student objStudent, StudentFacility stfl = null, Boolean Upgradethis = false)
        {
            InitializeComponent();
            this.objStudent = objStudent;
            this.feeStructure = stfl;
            this.Upgrade = Upgradethis;

        }

        private void MonthSelector_Load(object sender, EventArgs e)
        {
            try
            {
                LoadForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void loadPackages()
        {
            try
            {
                cmbPack.DataSource = null;
                lstPackage = BLL.FeesPackageHandller.getCourseWisePackages(id, Convert.ToInt16(branchID));

                if (lstPackage.Count == 0)
                {

                    var createPackage = UICommon.WinForm.showStatus("No Package Available." + System.Environment.NewLine + "Do you want to create Package for " + id + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (createPackage == DialogResult.Yes)
                    {
                        FrmSubjectPackageMasterForm objMasterForm = new FrmSubjectPackageMasterForm();
                        objMasterForm.loadfromAddFacilities(id);
                        objMasterForm.ShowDialog();
                        lstPackage = BLL.FeesPackageHandller.getStandardPackages(id, Convert.ToInt16(branchID));

                    }
                }

                cmbPack.Items.Clear();
                //cmbPack.Items.Add(new ComboItem(-1, "Select Package"));
                if (Upgrade == true)
                {
                    foreach (FeesPackage feesPackage in lstPackage)
                    {
                        cmbPack.Items.Add(new ComboItem(feesPackage.Id, feesPackage.PackageName));
                    }
                    string pack = feeStructure.Package.PackageName;
                    cmbPack.Text = pack.ToString();
                    dtpToMonth.Value = feeStructure.ToDate;
                }
                else
                {
                    cmbPack.Items.Add(new ComboItem(feeStructure.Package.Id, feeStructure.Package.PackageName));// = feeStructure.Package;  
                    cmbPack.SelectedIndex = 0;
                }


            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex);
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
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




        private void MonthSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                //feeStructure.selectedMonths = null;

                //if (e.CloseReason == CloseReason.UserClosing)
                //{
                //    //this.DialogResult = DialogResult.Cancel;
                //}
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (feeStructure.Id != 0)
                {
                    if (Convert.ToDecimal(txtTotalAmount.Text) > 0)
                    {
                        if (selectedPackage.Id == feeStructure.Package.Id)
                        {
                            if (txtDiscount.Text == "")
                            {
                                txtDiscount.Text = "0";
                            }
                            int InstructorId =0 ;
                            if (cmbInstructor.SelectedIndex == -1)
                            {
                                InstructorId = 0;
                            }
                            else
                            {
                                InstructorId = ((cmbInstructor.SelectedItem as ComboItem).key);
                            }
                          //  int InstructorId = ((cmbInstructor.SelectedItem as ComboItem).key);
                                //Convert.ToInt32(cmbInstructor.SelectedValue);
                            BLL.StudentHandller.facilityManualRenewal(feeStructure, dtpFromMonth.Value, dtpToMonth.Value, feeStructure.Package.TotalTuiAmnt.ToString(), Convert.ToDecimal(txtDiscount.Text), InstructorId);

                            //  this.Dispose();
                            //  DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            UpgradePackage();
                        }

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Renewal Amount should be greater than 0." + System.Environment.NewLine + "Package Amount for " + feeStructure.Package + " is " + feeStructure.Amount + ".", sCaption, this);
                        txtAmount.Text = feeStructure.Package.TotalTuiAmnt.ToString();
                        txtTotalAmount.Text = feeStructure.Package.TotalTuiAmnt.ToString();
                    }
                }

                DateTime todaysDate = dtpToMonth.Value;
                string dateString = String.Format("{0:dd/MM/yyyy}", todaysDate);
                DateTime cdate = feeStructure.ToDate; ;
                string cd = String.Format("{0:dd/MM/yyyy}", cdate);
                objStudent = BLL.StudentHandller.GetStudent(feeStructure.Student.AdmisionNo, null, null, null, Program.LoggedInUser.BranchId);
                BLL.UserHandler.createActivity(feeStructure.Student.AdmisionNo, DateTime.Now.Date, "Package Renewal: " + selectedPackage.PackageName + " From " + feeStructure.ToDate + " To " + dtpToMonth.Value + " Because Discount On Renewal: Rs." + txtDiscount.Text + ":-" + txtdiscountReason.Text, objStudent.DisplayName, cd, dateString, Program.LoggedInUser.UserId, Program.LoggedInUser.BranchId.ToString());
                UICommon.WinForm.showStatus("Package Renewed Successfully ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                InvoiceGenerate(objStudent, feeStructure);
                FrmFeesPayment objFees = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
                objFees.LoadFeeDetailsFromRegistration(objStudent);
                objFees.Visible = true;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void UpgradePackage()
        {
            try
            {
                Info.StudentFacility objnewfacility = new StudentFacility();
                loadBatches();
                //  objnewfacility.Student.AdmisionNo = objStudent.AdmisionNo;
                objnewfacility.Package = selectedPackage;
                objnewfacility.FromDate = dtpFromMonth.Value;
                objnewfacility.Package.IsLumSum = false;
                 objnewfacility.InstructorId = ((cmbInstructor.SelectedItem as ComboItem).key);
                //Convert.ToInt32(cmbInstructor.SelectedValue);
                objnewfacility.AdmissionDate = dtpFromMonth.Value;
                objnewfacility.RenewalDiscount = 0;
                objnewfacility.Discount = Convert.ToDecimal(txtDiscount.Text);
                objnewfacility.Student = objStudent;
                objnewfacility.Student.RollNo = objStudent.RollNo;
                objnewfacility.Student.Batch = lstBatches[0];
                objnewfacility.FacilityName = selectedPackage.PackageName;
                objnewfacility.DiscountReason = txtdiscountReason.Text;
                objnewfacility.Student.AdmissionNo = objStudent.AdmissionNo;
                objnewfacility.ToDate = dtpToMonth.Value;
                if (objnewfacility.Package.IsLumSum)
                {
                    objnewfacility.Amount = objnewfacility.Package.LumsumAmount;
                }
                else
                {
                    objnewfacility.Amount = objnewfacility.Package.TotalTuiAmnt;
                }
                if (AmountPaid > selectedPackage.TotalTuiAmnt)
                {
                    objnewfacility.CreditAmount = AmountPaid - selectedPackage.TotalTuiAmnt;
                }
                objStudent.Facilities.Add(objnewfacility);
                objStudent.Facilities.Clear();
                objStudent.Facilities.Add(objnewfacility);
                
                BLL.FeesHandller.calculateInstallments(objnewfacility);

                BLL.StudentHandller.addStudentFacilities(objStudent, objStudent.Facilities, objStudent.BiometricId, 0);




                BLL.UserHandler.createActivity(objStudent.AdmissionNo, DateTime.Now.Date, "Upgrade Package: " + selectedPackage.PackageName + " From " + feeStructure.ToDate + " To " + dtpToMonth.Value + " Because " + txtdiscountReason.Text.ToString(), objStudent.DisplayName, feeStructure.Package.PackageName.ToString(), selectedPackage.PackageName.ToString(), Program.LoggedInUser.UserId, Program.LoggedInUser.BranchId.ToString());


                UICommon.WinForm.showStatus("Package upgraded successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                // this.LoadForm();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LoadForm()
        {
            try
            {
                if (Upgrade == true)
                {
                    AmountPaid = BLL.InstallmentHandler.getAmountPaid(feeStructure.Id);
                    //label8
                    cmbPack.Enabled = true;
                    lblPaid.Visible = true;
                    lblPaidAmnt.Visible = true;
                    lblPaidAmnt.Text = AmountPaid.ToString();

                    if (AmountPaid > 0)
                    {
                        txtdiscountReason.Text = "Paid Amount Rs." + AmountPaid + " is given as Discount";
                    }
                    //populateInstructor();
                    btnSave.Visible = false;

                    btnUpgrade.Visible = true;
                    txtDiscount.Text = AmountPaid.ToString();

                    dtpFromMonth.Value = feeStructure.FromDate;
                    dtpToMonth.Value = feeStructure.FromDate.AddMonths(feeStructure.Package.PackageDuration).AddDays(feeStructure.Package.PackageDurationDays - 1);

                    dtpFromMonth.MinDate = feeStructure.FromDate;
                    dtpToMonth.MinDate = dtpToMonth.Value;
                    populateInstructor();
                    selectedPackage = feeStructure.Package;

                    btnSave.Text = "UPGRADE";
                }
                else
                {
                    txtAmount.Text = feeStructure.Package.TotalTuiAmnt.ToString();
                    txtTotalAmount.Text = feeStructure.Package.TotalTuiAmnt.ToString();
                    //  label8.Text = feeStructure.FacultyName.ToString();
                    cmbPack.Enabled = true;
                    dtpFromMonth.Value = feeStructure.ToDate.AddDays(+1);
                    dtpToMonth.Value = dtpFromMonth.Value.AddMonths(feeStructure.Package.PackageDuration).AddDays(feeStructure.Package.PackageDurationDays);
                    populateInstructor();
                    dtpFromMonth.MinDate = dtpFromMonth.Value;
                    btnSave.Text = "RENEW";
                }

                txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);

                selectedMonths = new List<DateTime>();
                UICommon.FormFactory.formatForm(this);

                id = BLL.StandardHandller.getStandardID(feeStructure.Id, Convert.ToInt16(branchID));
                loadPackages();



                UICommon.WinForm.formatDateTimePicker(dtpFromMonth);
                UICommon.WinForm.formatDateTimePicker(dtpToMonth);

                txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        private void populateInstructor()
        {
            try
            {
                List<Faculty> faculties = FacultyHandler.getFacultyList(WinApp.Program.LoggedInUser.BranchId);
                //cmbInstructor.ValueMember = "FacultyID";
                //cmbInstructor.DisplayMember = "Name";
                //cmbInstructor.DataSource = faculties;
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
        private void loadBatches()
        {
            try
            {


                lstBatches = BLL.StandardHandller.GetBatches(selectedPackage.Standard.Standardid, Program.LoggedInUser.BranchId);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }
        private void InvoiceGenerate(StudentMaster objstudMstr, StudentFacility fees)
        {
            try
            {
                if (SysParam.getValue<bool>(SysParam.Parameters.GENERATE_INVOICE) == true)
                {

                    {
                        try
                        {

                            Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();

                            objFeeData.BranchId = branchID;
                            objFeeData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                            objFeeData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                            objFeeData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                            objFeeData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                            objFeeData.ServiceTax = SysParam.getValue<int>(SysParam.Parameters.SERVICE_TAX);
                            objFeeData.StudentName = objStudent.DisplayName;
                            objFeeData.FatherContactNo = objStudent.ContactNo;
                            Info.Branch obj = new Branch();
                            obj = BLL.BranchHandler.getBranch(Convert.ToInt16(branchID));
                            string Receipt = SysParam.getValue<int>(SysParam.Parameters.FINANCIAL_YEAR).ToString() + '/' + branchID + '/' + obj.InvoiceNo.ToString();
                            objFeeData.ReceiptNo = Receipt;
                            objFeeData.PaymentDate = dtpFromMonth.Value;
                            objFeeData.AdmsnNo = objStudent.AdmisionNo;
                            objFeeData.PackageName = feeStructure.Package.PackageName;
                            objFeeData.TotalFees = feeStructure.Package.TotalFees;
                            objFeeData.OutstandingAmount = feeStructure.Package.PackageCost - feeStructure.Discount;
                            objFeeData.RupeesInWord = Utility.currencyInWords(feeStructure.Package.PackageCost - feeStructure.Discount);
                            objFeeData.SACCode = feeStructure.Package.SACCode;
                            objFeeData.DisCount = feeStructure.Discount;
                            objFeeData.TuitionFees = feeStructure.Package.PackageCost;
                            objFeeData.ServiceTaxNo = Info.SysParam.getValue<String>(SysParam.Parameters.SERVICE_TAX_NO);
                            objFeeData.ClientGSTNo = objStudent.GSTNo;
                            objFeeData.Address = objStudent.Address;
                            objFeeData.ContactNo = objStudent.ContactNo;
                            objFeeData.Email = Info.SysParam.getValue<String>(SysParam.Parameters.EMAIL_ADDRESS);
                            objFeeData.OwnerNo = Info.SysParam.getValue<String>(SysParam.Parameters.OWNER_NOS);
                            objFeeData.MainAdd = Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS);
                            objFeeData.clasContct = Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO);
                            objFeeData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                            objFeeData.stud_photo = objStudent.PhotoURL;
                            objFeeData.RollNo = objStudent.RollNo;

                            objFeeData.Standard = objStudent.Course.Standard.Stream.Name + "-" + objStudent.Course.Standard.StandardName;

                            objFeeData.EmailId = objStudent.EmailID;
                            objFeeData.ParentName = objStudent.ParentName;
                            objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);

                            objFeeData.SirName = Info.SysParam.getValue<String>(SysParam.Parameters.SIR_NAME);


                            objFeeData.CmpnyPanNO = Info.SysParam.getValue<String>(SysParam.Parameters.COMPANY_PAN_NO);
                            objFeeData.CINNO = Info.SysParam.getValue<String>(SysParam.Parameters.CIN_NO);



                            objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                            objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                            objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;


                            if (Math.Sign(objFeeData.OutstandingAmount) == -1)
                            {
                                objFeeData.OutstandingAmount = decimal.Zero;
                            }
                            objFeeData.MembershipNo = objStudent.MembershipNo;


                            objFeeData.CashPayment = objStudent.Fees.CashAmnt + objStudent.Fees.TransferAmount;
                            objFeeData.ChequePayment = objStudent.Fees.ChequeAmnt + objStudent.Fees.PndgChqAmnt;

                            NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                            objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();



                            objFeeData.FatherCntct = objStudent.FatherContactNo;
                            objFeeData.DOB = objStudent.Dob;
                            objFeeData.duration = objStudent.FeesPackage.PackageDuration.ToString();
                            objFeeData.Batch = objStudent.Batch.BatchDesc;

                            objFeeData.Adhar = objStudent.AdharCard;

                            objFeeData.PackageAmount = feeStructure.Package.PackageCost - feeStructure.Discount;

                            objFeeData.TuitionFees = feeStructure.Package.PackageCost;



                            double PackageAmt = Convert.ToDouble(objFeeData.PackageAmount);
                            double nontax = (PackageAmt / 1.18);
                            double cgst = (nontax * 0.09);
                            objFeeData.CGST = cgst.ToString();
                            objFeeData.NonTaxAmount = nontax.ToString();
                            int count = objStudent.Facilities.Count - 1;
                            string stfl = objStudent.Facilities[count].Id.ToString();
                            BLL.FeesHandller.InsertInvoice(Convert.ToInt16(branchID), objFeeData, stfl);
                            PrintingConfig objPrintngConfig = new PrintingConfig();
                            objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                            objPrintngConfig.PrintReport = false;
                            objPrintngConfig.reportType = "INVOICE_REPORT";
                            objPrintngConfig.SaveReport = false;
                            objPrintngConfig.ViewReport = false;
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
                            bgwInvoice.RunWorkerAsync(objFeeData);

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
        private void dtpFromMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                dtpToMonth.Value = dtpFromMonth.Value.AddMonths(feeStructure.Package.PackageDuration).AddDays(feeStructure.Package.PackageDurationDays - 1);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void cmbPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPack.SelectedIndex > -1)
                {
                    int packageId = (cmbPack.SelectedItem as ComboItem).key;
                    if (packageId != -1)
                    {
                        selectedPackage = BLL.FeesPackageHandller.GetPackage(packageId);

                        if (AmountPaid > selectedPackage.TotalTuiAmnt)
                        {
                            txtAmount.Text = selectedPackage.TotalTuiAmnt.ToString();
                            // am getting 18000 ruppess in return
                            // total amount paid = 38000
                            // and selected course amount = 20000 it will add in the discount section
                            txtDiscount.Text = selectedPackage.TotalTuiAmnt.ToString(); // am getting full discount worth 20000
                         //   dtpToMonth.MinDate = dtpFromMonth.Value.AddMonths(selectedPackage.PackageDuration).AddDays(selectedPackage.PackageDurationDays - 1);
                          //  dtpToMonth.Value = dtpFromMonth.Value.AddMonths(selectedPackage.PackageDuration).AddDays(selectedPackage.PackageDurationDays - 1);
                            

                          //  UICommon.WinForm.showStatus("Package can not be downgraded, If you want to change the package please delete existing package and add new one.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                           /// cmbPack.SelectedItem = feeStructure.Package;
                           // return;
                        }else if(AmountPaid.ToString().Equals("0.00"))
                        {
                            UICommon.WinForm.showStatus("Package can not be downgraded, If you want to change the package please delete existing package and add new one.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            cmbPack.SelectedItem = feeStructure.Package;
                            return;

                        }
                        else if(AmountPaid < selectedPackage.TotalTuiAmnt)
                        {
                            txtAmount.Text = selectedPackage.TotalTuiAmnt.ToString();
                            txtDiscount.Text = AmountPaid.ToString();

                        }
                        if (feeStructure.Package.PackageName != selectedPackage.PackageName)
                        {
                            txtdiscountReason.Text = "";
                        }
                        txtAmount.Text = selectedPackage.TotalTuiAmnt.ToString();
                        Decimal discount = 0;
                        if (txtDiscount.Text.Length > 0 && !txtDiscount.Text.Equals(""))
                        {
                            discount = Convert.ToDecimal(txtDiscount.Text);
                        }

                        txtTotalAmount.Text = (selectedPackage.TotalTuiAmnt - discount).ToString();

                        dtpToMonth.MinDate = dtpFromMonth.Value.AddMonths(selectedPackage.PackageDuration).AddDays(selectedPackage.PackageDurationDays - 1);
                        dtpToMonth.Value = dtpFromMonth.Value.AddMonths(selectedPackage.PackageDuration).AddDays(selectedPackage.PackageDurationDays - 1);

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void addPackage()
        {
            try
            {
                StudentFacility objStudentFacility = new StudentFacility();
                objStudentFacility.Package.SubjAmount = selectedPackage.PackageCost;
                objStudentFacility.FromDate = dtpFromMonth.Value;
                objStudent.Facilities.Add(objStudentFacility);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bgwInvoice_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool sendMail = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_INVOICE_MAIL);
                FeeReceiptReportData objFeeReceiptdata = (FeeReceiptReportData)e.Argument;
                BLL.MailHandler.sendInvoiceMail(objFeeReceiptdata, false, sendMail, branchID);
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }



        public bool validateReason()
        {
            try
            {
                if (txtdiscountReason.Text == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Description.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

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



        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPack.Enabled == false)
                {
                    UpgradePackage();

                }


                else
                {
                    if (feeStructure.FacilityName == cmbPack.SelectedItem.ToString())
                    {
                        //  feeStructure.ToDate = dtpToMonth.Value;


                        // validateReason();

                        feeStructure.Reason = txtdiscountReason.Text;
                        DateTime todaysDate = dtpToMonth.Value;
                        string dateString = String.Format("{0:dd/MM/yyyy}", todaysDate);
                        DateTime cdate = feeStructure.ToDate; ;

                        string cd = String.Format("{0:dd/MM/yyyy}", cdate);
                        bool result = BLL.InstallmentHandler.updateInstDtl(dtpFromMonth.Value, dtpToMonth.Value, feeStructure.Id, Program.LoggedInUser.BranchId);
                        BLL.UserHandler.createActivity(objStudent.AdmissionNo, DateTime.Now.Date, "Update Package: " + selectedPackage.PackageName + " From " + cd + " To " + dateString + " Because " + txtdiscountReason.Text.ToString(), objStudent.DisplayName, cd, dateString, Program.LoggedInUser.UserId, Program.LoggedInUser.BranchId.ToString());
                        if (result == true)
                        {
                            UICommon.WinForm.showStatus("Update Successfully !!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                        BLL.InstallmentHandler.insertUpdateFacility(Program.LoggedInUser.BranchId, feeStructure.ToDate, dtpToMonth.Value, objStudent.AdmissionNo, feeStructure.Id, feeStructure.Package.Id);
                        //loadStudent();
                        //  UpdadePackage();





                    }



                    else
                    {
                        decimal creditAmount=0;
                        if (AmountPaid > selectedPackage.TotalTuiAmnt)
                        {
                            creditAmount = AmountPaid - selectedPackage.TotalTuiAmnt;
                        }
                        int result = BLL.StudentHandller.deleteFacility1(feeStructure.Id, Program.LoggedInUser.BranchId, creditAmount);
                        if (result == 1)
                        {
                            UpgradePackage();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal Fees;
                decimal dscnt = 0;

                if (!txtDiscount.Text.Equals(""))
                {
                    dscnt = Convert.ToDecimal(txtDiscount.Text);
                }


                if (dscnt < AmountPaid)
                {
                    UICommon.WinForm.showStatus("Discount can not be less than " + AmountPaid.ToString() + ". As, Rs." + AmountPaid.ToString() + " is already paid.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDiscount.Text = AmountPaid.ToString();
                    txtDiscount.Focus();
                }


                //txtDiscount.Text = Common.Formatter.FormatCurrency(dscnt);
                if (dscnt <= selectedPackage.TotalTuiAmnt)
                {
                    if (selectedPackage == null)
                    {
                        Fees = feeStructure.Package.TotalTuiAmnt - dscnt;
                    }
                    else
                    {
                        Fees = selectedPackage.TotalTuiAmnt - dscnt;
                    }

                    txtTotalAmount.Text = Fees.ToString();
                }
                else
                {

                    txtTotalAmount.Text = Common.Formatter.FormatCurrency(feeStructure.Package.TotalTuiAmnt);
                    txtTotalAmount.Text = txtTotalAmount.Text.ToString();
                    UICommon.WinForm.showStatus("Discount can not be more than the Package Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDiscount.Text = AmountPaid.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtFName_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }
    }
}

