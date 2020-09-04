using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.BLL;
using System.Configuration;
using System.Threading;
using System.Text.RegularExpressions;
using ClassManager.WinApp.UICommon;
using ClassManager.WinApp.Reports;
using ClassManager.WinApp.Popups;
using ClassManager.Common;
using ClassManager.Info.Reporting;


namespace ClassManager.WinApp.Gym
{
    public partial class FrmQuickAdmission : FrmParentForm
    {
        const string sCaption = "Registration";
        RolePrivilege formPrevileges;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        bool sAllowIndexChange = true;
        Account cashAccount;
        public static FeesPackage selectedPackage;
        private List<Batch> lstBatches;
        public static Decimal facilitiesTotalFees = 0;
        public static bool isLumpSum;
        public decimal discount { get; set; }
        List<FeesPackage> lstPackage;
        decimal totalCashAmount, totalChequeAmount,totalFees;
        public List<Cheque> Cheques = new List<Cheque>();
        public List<PaymentDetails> PayDetails = new List<PaymentDetails>();
        public Student objStudent;
        int admsNo;
        int duration;
         Student obj = new Student();

        public Transaction objTransaction;
        public FrmQuickAdmission()
        {
            InitializeComponent();
        }

        private void FrmQuickAdmission_Load(object sender, EventArgs e)
        {
            try
            {
                dtPaymentDate.Value = DateTime.Now;
                dtpDOB.MaxDate = DateTime.Now;
                dtpToDate.Value = DateTime.Now;
                formatForm();
                ApplyPrevileges();
                AssignEvents();
                List<Account> lstAcc = new List<Account>();
                lstAcc = BLL.AccountHandller.getAccounts(branchID);
                cmbAccount.DataSource = lstAcc;

                cashAccount = lstAcc.Where(account => account.AccountName == "CASH").FirstOrDefault<Account>();

                if (cashAccount != null)
                {
                    cmbAccount.SelectedItem = cashAccount;
                }
                populateStream();
                if (cmbStream.Items.Count > 0)
                {
                    cmbStream.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No streams available.", sCaption, this);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> duplicateRecords = new List<int>();
                if (validatePersonalInfo())
                {

                    int biometicId;
                    objStudent = new Student();

                    objStudent.Fname = txtFName.Text;
                    objStudent.Mname = txtMName.Text;
                    objStudent.Lname = txtLName.Text;
                    DateTime dateDiff = DateTime.Now.AddYears(-2);
                    if (dateDiff.ToShortDateString().Equals(dtpDOB.Value.ToShortDateString()))
                    {
                        objStudent.Dob = DateTime.MinValue;
                    }
                    else
                    {
                        objStudent.Dob = dtpDOB.Value;
                    }
                    objStudent.Address = txtAddress.Text;
                    objStudent.ContactNo = txtSContact.Text;
                    objStudent.EmailID = txtEmailID.Text;
                    objStudent.Enquiry = new Enquiry(Convert.ToInt32("-1"));

                    objStudent.FatherName = "";
                    objStudent.FatherContactNo = "";
                    objStudent.AdharCard = "";

                    objStudent.BloodGroup = txtBldGrp.Text;
                    objStudent.Weight = txtWght.Text;
                    objStudent.BMI = txtBMI.Text;
                    objStudent.Height = txtHeight.Text;

                    objStudent.AdmissionDate = dtpAdmissionDate.Value;
                    objStudent.BiometricId = (Int32.TryParse(txtBiometricId.Text, out biometicId) ? biometicId : -1);
                    objStudent.Gender = ((rbMale.Checked) ? "M" : "F");

                    objStudent.Remark = "";
                    objStudent.EmailID = objStudent.EmailID;
                    objStudent.Branch.BranchId = Program.LoggedInUser.BranchId;
                    objStudent.Batch.id = -1;
                    objStudent.MembershipNo = txtMemberShipNo.Text;

                    objStudent.GSTNo = "";
                    objStudent.Category = "";
                    objStudent.counselor = "";
                    objStudent.Reference = "";

                    try
                    {
                        BLL.StudentHandller.RegisterStudent(objStudent);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("Record Already Exists from SP s_pr_register_student"))
                        {
                            UICommon.WinForm.showStatus("Member Already Registered  \n Admission No. is :" + objStudent.AdmissionNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            clearForm();
                            duplicateRecords.Add(objStudent.AdmisionNo);
                        }

                    }
                    if (duplicateRecords.Count == 0)
                    {
                        foreach (FeesPackage objFeePackage in BLL.FeesPackageHandller.getStandardPackages((cmbStd.SelectedItem as ComboItem).key, Program.LoggedInUser.BranchId))
                        {

                            if (objFeePackage.PackageName == cmbPack.SelectedItem.ToString())
                            {

                                if (objStudent.AdmissionNo != 0)
                                {
                                    StudentFacility objNewFacility = new StudentFacility();
                                    if (objFeePackage.PackageType == PackageType.INSTALLMENT)
                                    {
                                        FeesPackage lstPackageInstallments = BLL.FeesPackageHandller.GetPackage(objFeePackage.Id);
                                        objNewFacility.Package = lstPackageInstallments;
                                    }
                                    else
                                    {
                                        objNewFacility.Package = objFeePackage;
                                    }

                                    objNewFacility.FromDate = dtpAdmissionDate.Value;
                                    objNewFacility.Package.IsLumSum = false;
                                    objNewFacility.AdmissionDate = dtpAdmissionDate.Value;
                                    objNewFacility.ToDate = dtpToDate.Value;

                                    if ((txtDiscount.Text) == "")
                                    {
                                        objNewFacility.Discount = 0;
                                    }
                                    else
                                    {
                                        objNewFacility.Discount = Convert.ToDecimal(txtDiscount.Text);
                                    }
                                    objNewFacility.RenewDiscount = false;
                                    objNewFacility.Student = objStudent;
                                    objNewFacility.Student.Batch = new Batch();
                                    objNewFacility.Student.Batch.id = (cmbBatches.SelectedItem as Batch).id;
                                    objNewFacility.FacilityName = objFeePackage.PackageName;
                                    objNewFacility.Amount = objFeePackage.PackageCost;
                                    objStudent.Facilities.Add(objNewFacility);

                                    BLL.FeesHandller.calculateInstallments(objNewFacility);
                                }
                            }
                        }


                        if (objStudent.Facilities.Count > 0)
                        {
                            BLL.StudentHandller.addStudentFacilities(objStudent, objStudent.Facilities,0,0);
                        }
                        admsNo = objStudent.AdmisionNo;

                        obj = BLL.StudentHandller.GetStudent(admsNo, null, null, null, Program.LoggedInUser.BranchId);
                        objStudent.Fees.FeesId = obj.Fees.FeesId;
                        objStudent.Fees.AdmissionNo = objStudent.AdmissionNo;

                        try
                        {
                            // if (txtCashAmount.Text != "" || txtChequeAmount.Text != "" || txtActualPaymentAmnt.Text != "")
                            decimal Cash = Convert.ToDecimal(txtCashAmount.Text);
                            if ((txtCashAmount.Text != "0.00" && Cash > 0) || txtChequeAmount.Text != "Rs 0.00" || txtBankAmount.Text != "Rs 0.00")
                            {
                                decimal serviceTaxPercentage = Info.SysParam.getValue<decimal>(SysParam.Parameters.SERVICE_TAX);

                                objStudent.Fees.FineAmount = Convert.ToDecimal("0.00");
                                objStudent.Fees.CashAmnt = Convert.ToDecimal(txtCashAmount.Text == "" ? "0.00" : txtCashAmount.Text);
                                objStudent.Fees.ChequeAmnt = Cheques.Where(chq => chq.Status == Cheque.ChequeStatus.CLRD).Sum(chq => chq.Amount);
                                objStudent.Fees.PndgChqAmnt = Cheques.Where(chq => chq.Status == Cheque.ChequeStatus.PDNG).Sum(chq => chq.Amount);
                                objStudent.Fees.TransferAmount = totalFees;
                                objStudent.Fees.FeesPaid = objStudent.Fees.ChequeAmnt + objStudent.Fees.CashAmnt + objStudent.Fees.PndgChqAmnt + objStudent.Fees.TransferAmount;

                                objStudent.Fees.FeesDiscount = Convert.ToDecimal(txtDiscount.Text == "" ? "0.00" : txtDiscount.Text);
                                objStudent.Fees.TotalOutstanding = obj.Fees.TotalFees - (objStudent.Fees.FeesPaid + obj.Fees.Installments.Sum(dscnt => dscnt.Discount) + obj.Fees.Installments.Sum(cancelled => cancelled.CancelledAmount));


                                objTransaction = new Transaction();
                                objTransaction.AcadYear = objStudent.Fees.AcadYear;
                                objTransaction.AdmisionNo = objStudent.AdmissionNo;
                                objTransaction.Amount = objStudent.Fees.FeesPaid + obj.Fees.FineAmount;
                                objTransaction.Fine = objStudent.Fees.FineAmount;
                                objTransaction.ReceivedBy = Program.LoggedInUser.UserId;
                                objTransaction.RollNo = objStudent.RollNo;
                                objTransaction.Cheques = Cheques;
                                objTransaction.BankTransfer = PayDetails;
                                objTransaction.TransferAmount = objStudent.Fees.TransferAmount;
                                objTransaction.ServiceTax = objTransaction.Amount * (serviceTaxPercentage / 100);
                                objTransaction.ServiceTaxPercentage = serviceTaxPercentage;
                                objTransaction.PaymentDate = dtPaymentDate.Value;
                                objTransaction.CashAmount = objStudent.Fees.CashAmnt;
                                objTransaction.CashAccount = cmbAccount.SelectedItem as Account;
                                objTransaction.ReceiptNo = "";
                                if (txtCashAmount.Text != "0.00" && txtBankAmount.Text == "Rs 0.00")
                                {
                                    objTransaction.PaymentMode = PaymentMode.CASH;
                                }
                                if (txtChequeAmount.Text != "Rs 0.00")
                                {
                                    objTransaction.PaymentMode = PaymentMode.CHEQUE;
                                }
                                if (txtBankAmount.Text != "Rs 0.00" && txtCashAmount.Text == "0.00")
                                {
                                    objTransaction.PaymentMode = PaymentMode.BANKTRANSFER;
                                }
                                BLL.FeesHandller.PayFees(objStudent.Fees, objTransaction, Program.LoggedInUser.BranchId);

                                UICommon.WinForm.showStatus("Member Registered Successfully \n Admission No. is :" + objStudent.AdmissionNo + "\n Fees paid successfully, Receipt no is : " + objTransaction.ReceiptNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);




                                Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
                                objFeeData.BranchId = obj.Branch.BranchName.ToString();
                                objFeeData.PaymentDate = dtPaymentDate.Value;
                                objFeeData.ReceiptNo = objTransaction.ReceiptNo;
                                objFeeData.RollNo = objStudent.RollNo;
                                objFeeData.RupeesInWord = Utility.currencyInWords(objTransaction.Amount);
                                objFeeData.ServiceTax = objTransaction.ServiceTax;
                                objFeeData.Standard = obj.Course.Standard.Stream.Name + "-" + obj.Course.Standard;
                                objFeeData.StudentName = obj.DisplayName;
                                objFeeData.FatherContactNo = obj.ContactNo;
                                objFeeData.EmailId = obj.EmailID;
                                objFeeData.ParentName = obj.ParentName;
                                objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);
                                objFeeData.TotalFees = objTransaction.Amount;
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
                                objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(obj.Fees.FeesId);
                                objFeeData.InstMonth = obj.Fees.MonthPaidStatus;
                                objFeeData.PaymentDetails = obj.Fees.MonthPaidStatus;
                                objFeeData.OutstandingAmount = objStudent.Fees.TotalOutstanding;

                                if (Math.Sign(objFeeData.OutstandingAmount) == -1)
                                {
                                    objFeeData.OutstandingAmount = decimal.Zero;
                                }
                                objFeeData.MembershipNo = obj.MembershipNo;

                                objFeeData.TuitionFees = obj.Fees.TuitionAmnt - objFeeData.ServiceTax;
                                objFeeData.Cheques = objTransaction.Cheques;
                                objFeeData.PaymentMode = objTransaction.PaymentMode.ToString();

                                objFeeData.FineAmount = objTransaction.Fine;
                                objFeeData.TransactionId = objTransaction.TrancID;

                                objFeeData.CashPayment = objStudent.Fees.CashAmnt + objStudent.Fees.TransferAmount;
                                objFeeData.ChequePayment = obj.Fees.ChequeAmnt + objStudent.Fees.PndgChqAmnt;
                                objFeeData.AdmsnNo = objTransaction.AdmisionNo;

                                NumberToMonth.Months installmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objTransaction.Month.ToString());
                                NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                                objFeeData.InstallmentMonths = installmonth.ToString();
                                objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();

                                objFeeData.Address = obj.Address;
                                objFeeData.ContactNo = obj.ContactNo;
                                objFeeData.FatherCntct = obj.FatherContactNo;
                                objFeeData.DOB = obj.Dob;
                                objFeeData.duration = objStudent.FeesPackage.PackageDuration.ToString();
                                objFeeData.Batch = obj.Batch.BatchDesc;
                                objFeeData.stud_photo = obj.PhotoURL;
                                objFeeData.Adhar = obj.AdharCard;

                                // Reports.PrintConfig.viewDialog(objFeeData, "FEE_RECEIPT_PRO", "Fee_Receipt_" + objStudent.AdmissionNo + "_" + objTransaction.ReceiptNo.Replace(@"/", "-"));

                                PrintingConfig objPrintngConfig = new PrintingConfig();
                                objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                                objPrintngConfig.PrintReport = false;
                                objPrintngConfig.reportType = "FEE_RECEIPT";
                                objPrintngConfig.SaveReport = false;
                                objPrintngConfig.ViewReport = false;
                                objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "FEE_RECEIPT");
                                objPrintngConfig.exportFileName = "Fee_Receipt_" + objStudent.AdmissionNo + "_" + objTransaction.ReceiptNo.Replace(@"/", "-");
                                objPrintngConfig.sendSMS = true;
                                objPrintngConfig.sendEmail = true;


                                FrmReportViewer frmRprtViewer = new FrmReportViewer();
                                frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
                                FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;
                                UICommon.FormFactory.setMainFormStatus("Sending Message");
                              //  bgwkSendReg.RunWorkerAsync(objStudent);
                                this.Close();


                                clearForm();
                            }

                            else
                            {
                                UICommon.WinForm.showStatus("Member Registered Successfully \n Admission No. is :" + objStudent.AdmissionNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                                clearForm();
                            }

                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Equals("Income Entry of Fees is not available"))
                            {
                                UICommon.WinForm.showStatus("Please Make Income Entry for Fees", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                            }
                            else
                            {
                                UICommon.WinForm.showError(ex, "Something wrong while paying fees", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                            }
                        }

                    }

                    if (duplicateRecords.Count == 0)
                    {
                       bgwkSendReg.RunWorkerAsync(objStudent);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        private void clearForm()
        {
            txtMemberShipNo.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtEmailID.Text = "";
            txtAddress.Text = "";
            txtSContact.Text = "";
            rbMale.Checked = true;
            rbFemale.Checked = false;
            txtBiometricId.Text = "";
            txtActualPaymentAmnt.Text = "Rs 0.00";
            txtPayable.Text = "00";
            txtDiscount.Text = "0";
            txtTotalDiscount.Text = "00";
            dtpDOB.Value = DateTime.Now.Date.AddYears(-2);
            dtpAdmissionDate.Value = DateTime.Now.Date;
            txtBankAmount.Text = "Rs 0.00";
            txtBldGrp.Text = "";
            cmbPack.Text = "";
            txtHeight.Clear();
            txtWght.Clear();
           
            txtBMI.Text = "";
            txtBldGrp.Text = "";
            txtBiometricId.Text = "";
         
            cmbStd.Text = "";
            cmbBatches.Text = "";
            txtChequeAmount.Text = "Rs 0.00";
            dtpToDate.Value = DateTime.Now.Date;
            dtPaymentDate.Value = DateTime.Now.Date;
            cmbPack.SelectedIndex = 0;
            cmbStd.SelectedIndex = 0;
            cmbBatches.SelectedIndex = 0;
           // txtCashAmount.Hint = "Enter Cash Amount";
            txtCashAmount.Text = "";
        }

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpDOB, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtPaymentDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpToDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpAdmissionDate, Common.Formatter.DateFormat);
                txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
                txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
                txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
                txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               // txtWght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               txtCashAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool validatePersonalInfo()
        {
            try
            {

                if (txtFName.Text.Length == 0 || txtFName.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Enter FirstName", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtSContact.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtSContact.Focus();
                    return false;
                }
               
                else if (txtSContact.Text.Length != 0 && txtSContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Contact Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtSContact.Focus();
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
                else if (cmbStd.Items.Count ==0)
                {
                    UICommon.WinForm.showStatus("Please Create Package.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                   
                    return false;
                }
               
                else if (cmbBatches.Items.Count == 0)
                {
                    UICommon.WinForm.showStatus("Please Create Batch.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    return false;
                }
                else if (cmbPack.Items.Count == 1)
                {
                   // UICommon.WinForm.showStatus("Please Create Packages.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    loadPackages();
                    return false;
                }
                else if (cmbPack.SelectedIndex == 0)
                {
                    UICommon.WinForm.showStatus("Please Select Package.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    return false;
                }
                if ((txtCashAmount.Text) == "")
                {
                    txtCashAmount.Text = "0.00";
                }
                else if ((Convert.ToDecimal(txtCashAmount.Text.Trim())) > (Convert.ToDecimal(selectedPackage.PackageCost))) 
                {
                    
                        UICommon.WinForm.showStatus("Amount is Greater than the Fees", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtCashAmount.Focus();
                        return false;
                   
                   
                }

               
               
                return true;
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

        private void AssignEvents()
        {
            try
            {
                txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
                txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
                txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
                txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtWght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtCashAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               // txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtBiometricId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
              private void ApplyPrevileges()
        {
            try
            {
                int functionId = Convert.ToInt32(this.Tag.ToString());
               
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
                        cmdNext.Visible = false;
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
        private void populateCourse(string stream = "%")
        {
            try
            {

                if (cmbStd.Items.Count != -1)
                {
                    cmbStd.Items.Clear();
                    List<Standard> lstStd = StandardHandller.getStandard(branchID.ToString(), stream);
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbStd.Items.Add(new ComboItem(objStandard.Standardid, objStandard.StandardName));
                    }
                    cmbStd.SelectedIndex = 0;
                }
                else
                {
                    UICommon.WinForm.showStatus("No package available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

                cmbPack.SelectedIndex =1;


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

                    else
                    {
                        sAllowIndexChange = false;
                        txtDiscount.Text = "0";
                        int packageId = (cmbPack.SelectedItem as ComboItem).key;
                        if (packageId != -1)
                        {
                            selectedPackage = FeesPackageHandller.GetPackage(packageId);
                            getPackageCost(isLumpSum);
                             duration = selectedPackage.PackageDuration;
                            dtpAdmissionDate.Value = DateTime.Now;
                            dtpToDate.Value = DateTime.Now.AddMonths(+duration);
                           
                            dtpToDate.Value = dtpToDate.Value.AddDays(-1);


                           if (selectedPackage.AutoRenew == true)
                            {
                                chkOnetimeDiscount.Checked = true;
                                chkOnetimeDiscount.Visible = true;
                            }
                            decimal PayFees = selectedPackage.PackageCost;
                            decimal Discount= selectedPackage.Discount;
                            txtPayable.Text = Common.Formatter.FormatCurrency(PayFees);
                            txtTotalDiscount.Text = Common.Formatter.FormatCurrency(Discount);
                        }
                        else
                        {
                            selectedPackage = null;
                            txtPayable.Text = " Rs.0.00";
                            txtTotalDiscount.Text = " Rs.0.00";
                        }
                        sAllowIndexChange = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
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
                   
                    var createPackage = UICommon.WinForm.showStatus("No Package Available." + System.Environment.NewLine + "Do you want to create Package for " + (cmbStd.SelectedItem as ComboItem).name + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (createPackage == DialogResult.Yes)
                    {
                        FrmSubjectPackageMasterForm objMasterForm = new FrmSubjectPackageMasterForm();
                        objMasterForm.loadfromAddFacilities(cmbStd.SelectedIndex);
                        objMasterForm.ShowDialog();
                        lstPackage = FeesPackageHandller.getStandardPackages((cmbStd.SelectedItem as ComboItem).key, UserHandler.loggedInUser.BranchId);
                        
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
        private void createBatchifEmpty()
        {
            try
            {
            
                var createBatch = UICommon.WinForm.showStatus("No Batch Available." + System.Environment.NewLine + "Do you want to create Batch for " + (cmbStd.SelectedItem as ComboItem).name + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                if (createBatch == DialogResult.Yes)
                {
                    FrmStandardMasterForm objMasterForm = (FrmStandardMasterForm)UICommon.FormFactory.GetForm(Forms.FrmStandardMasterForm, this, true);
                    objMasterForm.loadfromAddFacilities(-1, cmbStd.SelectedIndex);
                    objMasterForm.ShowDialog();
                    lstBatches = StandardHandller.GetBatches((cmbStd.SelectedItem as ComboItem).key, UserHandler.loggedInUser.BranchId);
                    cmbBatches.DataSource = lstBatches;
                  
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

            if (selectedPackage.PackageType == PackageType.INSTALLMENT || selectedPackage.PackageType == PackageType.ONE_TIME)
            {
               
            }
            else
            {
               
            }
           
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbStd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange==true)
                {
                    sAllowIndexChange = false;
                    loadPackages();
                    loadBatches();
                    sAllowIndexChange = true;
                    if (cmbPack.Items.Count > 0)
                    {
                        cmbPack.SelectedIndex =1;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
       {
           try
            {
                decimal dscnt = Convert.ToDecimal(txtDiscount.Text);
                txtTotalDiscount.Text = Common.Formatter.FormatCurrency(dscnt);
                decimal Fees = selectedPackage.PackageCost - Convert.ToDecimal(txtDiscount.Text);
                 txtPayable.Text = Common.Formatter.FormatCurrency(Fees);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                double weight;
                double height;
                double BMI;
                if (txtHeight.Text == "")
                {
                    txtBMI.Text = "";
                }
               else if (txtHeight.Text.Length != 0 && txtWght.Text.Length != 0)
                {
                    if (txtHeight.Text == ".")
                    {
                        UICommon.WinForm.showStatus("Please Enter Value", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        weight = Convert.ToDouble(txtWght.Text);
                        height = Convert.ToDouble(txtHeight.Text);
                        BMI = Convert.ToDouble(weight / (height * height));
                      
                        BMI = System.Math.Round(BMI, 2);
                        txtBMI.Text = BMI.ToString();
                        txtBMI.Enabled = false;
                    }

                }
                else
                {
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lnkAddCheque_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
               
                DialogResult result = FrmChequePopup.getInstance().ShowDialog();
                while (result != DialogResult.Cancel)
                {
                    Cheques.Clear();
                    if (result == DialogResult.OK && FrmChequePopup.objCheque != null)
                    {
                        // decimal chequeAmount = Cheques.Sum(chq => chq.Amount) + FrmChequePopup.objCheque.Amount;
                        decimal chequeAmount =  FrmChequePopup.objCheque.Amount;
                        totalChequeAmount = chequeAmount;
                        
                            Cheques.Add(FrmChequePopup.objCheque);
                          
                            txtChequeAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalChequeAmount.ToString()));
                        if (txtActualPaymentAmnt.Text == "Rs 0.00")
                        {
                            txtActualPaymentAmnt.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalChequeAmount.ToString()));
                        }
                        else
                        {
                            txtActualPaymentAmnt.Text = (Convert.ToDecimal(txtActualPaymentAmnt.Text) + totalChequeAmount).ToString();
                        }
                       
                            break;
                        }
                    }
                }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCashAmount.Text != "")
                {
                    txtActualPaymentAmnt.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(txtCashAmount.Text.ToString()));
                }
                else
                {
                    txtActualPaymentAmnt.Text = "Rs 0.00";
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex,sCaption,this);
            }
        }

        private void txtBldGrp_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtSContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (txtSContact.Text.Length >= 10)
                {
                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtpAdmissionDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                dtpToDate.Value = dtpAdmissionDate.Value.AddMonths(+duration);

                dtpToDate.Value = dtpToDate.Value.AddDays(-1);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtpAdmissionDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                dtpToDate.Value = dtpAdmissionDate.Value.AddMonths(+duration);

                dtpToDate.Value = dtpToDate.Value.AddDays(-1);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtCashAmount_Click(object sender, EventArgs e)
        {

        }

        private void bgwkSendReg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               
                objStudent = (Student)e.Argument;
                MailHandler.sendRegistrationSms(objStudent, objStudent.DisplayName, objStudent.Fees.TotalFees, objStudent.RollNo, objStudent.ContactNo, Program.LoggedInUser.BranchName);
            }

            catch (Exception)
            {

                throw;
            }
        }

        private void bgwkSendReg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bgwkSendReg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            catch (Exception)
            {

                throw;
            }
        }

        private void txtCashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == (char)8)
                {
                    e.Handled =false;
                }
                else
                {
                    e.Handled = false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        private void txtWght_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double weight;
                double height;
                double BMI;
                if (txtHeight.Text == "")
                {
                    txtBMI.Text = "";
                }
                else if (txtHeight.Text.Length != 0 && txtWght.Text.Length != 0)
                {
                    if (txtHeight.Text == ".")
                    {
                        UICommon.WinForm.showStatus("Please Enter Weight", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        weight = Convert.ToDouble(txtWght.Text);
                        height = Convert.ToDouble(txtHeight.Text);
                        BMI = Convert.ToDouble(weight / (height * height));
                        //String.Format("{0:0.00}", BMI.ToString());
                        BMI = System.Math.Round(BMI, 2);
                        txtBMI.Text = BMI.ToString();
                        txtBMI.Enabled = false;
                    }

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

        private void lnkBnkTrnfr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult result = FrmBankTransfer.getform().ShowDialog();
                while (result != DialogResult.Cancel)
                {
                   PayDetails.Clear();
                    if (result == DialogResult.OK && FrmBankTransfer.objDetails != null)
                    {
                        // decimal chequeAmount = Cheques.Sum(chq => chq.Amount) + FrmChequePopup.objCheque.Amount;
                        decimal Amount = FrmBankTransfer.objDetails.Amount;
                       totalFees = Amount;

                        PayDetails.Add(FrmBankTransfer.objDetails);

                        txtBankAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalFees.ToString()));
                        if (txtActualPaymentAmnt.Text == "")
                        {
                            txtActualPaymentAmnt.Text = totalFees.ToString();
                        }
                        else
                        {
                            txtActualPaymentAmnt.Text = (Convert.ToDecimal(txtActualPaymentAmnt.Text) + totalChequeAmount+totalFees).ToString();
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }

        private void setOutstanding(bool considerOnlyNewDiscount = false)
        {
            try
            {
                if (considerOnlyNewDiscount == false)
                {
                    objStudent.Fees.TotalOutstanding = objStudent.FeesPackage.TotalFees;
                    txtActualPaymentAmnt.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal((totalCashAmount + totalChequeAmount).ToString()));
                 
                   decimal feesPaying = totalCashAmount + totalChequeAmount;
                    objStudent.Fees.TotalOutstanding = (objStudent.Fees.TotalOutstanding) - feesPaying;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

