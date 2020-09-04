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
using System.Globalization;
using ClassManager.Common.Exceptions;
using ClassManager.WinApp.UICommon;
using ClassManager.WinApp.Reports;
using ClassManager.WinApp.Popups;
using ClassManager.Info.Reporting;

namespace ClassManager.WinApp
{
    public partial class FrmFeesPayment : FrmParentForm
    {
        RolePrivilege formPrevileges;
        public List<PaymentDetails> PayDetails = new List<PaymentDetails>();
        public List<Cheque> Cheques = new List<Cheque>();
        public static FrmFeesPayment myInstance;
        Account cashAccount;
        decimal totalCashAmount, totalChequeAmount, totalFees;
        string branchId = Program.LoggedInUser.BranchId.ToString();
        public Student objStudent;
        public Transaction objTransaction;
        public Info.InstallmentDetail objInstallmentDetails;
        public string sCaption = "Fees Payment";
        private static Info.InstallmentDetail objInstDetails;
        public List<FrmInstallmentDetails> installDetails;
        List<Info.InstallmentDetail> lstInstDetails;
        List<ComboItem> lstStudent = new List<ComboItem>();
        Info.Reporting.FeeReceiptReportData objFeeData = new Info.Reporting.FeeReceiptReportData();
        Boolean isFormClear = false;
        decimal fine, feesPaying;
        private decimal newDiscount;
        public bool considerOnlyFine;
        decimal outstanding;
        private decimal totalOutstanding;

        public StudentFacility facilityToPay { get; private set; }

        public FrmFeesPayment()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            try
            {
                cmbCoursePayment.Items.Clear();
                if (cmdSearch.Text == "Search")
                {
                    ADGVCheques.DataSource = null;
                    btnSubmit.Enabled = true;
                }

                if (txtAdmissinoNO.Text == "" && cmbStudName.Text == "")
                {
                    UICommon.WinForm.showStatus("Enter valid Name or Admission No", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    if (cmdSearch.Text.Equals("New Payment"))
                    {
                        pnlFeesDetails.Visible = false;
                        pnlFees.Visible = true;
                        ClearForm();
                    }
                    else
                    {
                        if (txtAdmissinoNO.Text != "")
                        {
                            LoadPaymentDetails(Convert.ToInt32(txtAdmissinoNO.Text));
                        }
                        else
                        {
                            if (cmbStudName.Text.Length != 0)
                            {
                                LoadPaymentDetails((cmbStudName.SelectedItem as ComboItem).key);
                            }
                        }
                    }
                }
            }
            catch (NoFeesException ex)
            {
                UICommon.WinForm.showStatus("No Fees Details Found for " + objStudent.Fname, sCaption, this);
                pnlFeesDetails.Visible = false;
                ClearForm();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "No such Record,Data Fetching Failed", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                pnlFeesDetails.Visible = false;
                ClearForm();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {

                    PayFees();

                    // print report direct

                    PrintingConfig objPrintngConfig = new PrintingConfig();
                    Boolean viewReport = Info.SysParam.getValue<Boolean>(SysParam.Parameters.VIEW_RECEIPT);
                    objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                    objPrintngConfig.PrintReport = SysParam.getValue<bool>(SysParam.Parameters.AUTO_PRINT_RECEIPT);
                    objPrintngConfig.reportType = "FEE_RECEIPT";
                    objPrintngConfig.SaveReport = false;
                    objPrintngConfig.ViewReport = viewReport;
                    if (SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE).Equals("FEE_RECEIPT"))
                    {
                        objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "FEE_RECEIPT");
                    }
                    else
                    {
                        objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE_RECEIPT");
                    }
                    objPrintngConfig.exportFileName = "Fee_Receipt_" + objStudent.AdmissionNo + "_" + objTransaction.ReceiptNo.Replace(@"/", "-");
                    objPrintngConfig.sendSMS = true;
                    objPrintngConfig.sendEmail = true;
                    FrmReportViewer frmRprtViewer = new FrmReportViewer();
                    frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
                    FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;
                    UICommon.FormFactory.setMainFormStatus("Sending Feespayment Message");
                    bwFeeMSG.RunWorkerAsync(objFeeReportData);
                    isFormClear = false;
                    ClearForm();
                    cmdSearch.Text = "SEARCH";
                    txtAdmissinoNO.Enabled = true;
                    cmbStudName.Enabled = true;
                    cmdSearch.Enabled = true;
                    pnlFeesDetails.Visible = false;
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


        private void PayFees()
        {
            try
            {
                decimal serviceTaxPercentage = Info.SysParam.getValue<decimal>(SysParam.Parameters.SERVICE_TAX);
                objStudent.Fees.FineAmount = Convert.ToDecimal(txtFine.Text == "" ? "0.00" : txtFine.Text);
                objStudent.Fees.CashAmnt = totalCashAmount;
                objStudent.Fees.TransferAmount = totalFees;
                objStudent.Fees.ChequeAmnt = Cheques.Where(chq => chq.Status == Cheque.ChequeStatus.CLRD).Sum(chq => chq.Amount);
                objStudent.Fees.PndgChqAmnt = Cheques.Where(chq => chq.Status == Cheque.ChequeStatus.PDNG).Sum(chq => chq.Amount);
                objStudent.Fees.FeesPaid = objStudent.Fees.ChequeAmnt + objStudent.Fees.CashAmnt + objStudent.Fees.PndgChqAmnt + objStudent.Fees.TransferAmount;
                objStudent.Fees.FeesDiscount = Convert.ToDecimal(txtDiscount.Text == "" ? "0.00" : txtDiscount.Text);
                objTransaction = new Transaction();
                objTransaction.AcadYear = objStudent.Fees.AcadYear;
                objTransaction.AdmisionNo = objStudent.Fees.AdmissionNo;
                objTransaction.Amount = objStudent.Fees.FeesPaid + objStudent.Fees.FineAmount;
                objTransaction.Fine = objStudent.Fees.FineAmount;
                objTransaction.ReceivedBy = Program.LoggedInUser.UserId;
                objTransaction.RollNo = objStudent.RollNo;
                objTransaction.Cheques = Cheques;
                objTransaction.ServiceTax = objTransaction.Amount * (serviceTaxPercentage / 100);
                objTransaction.ServiceTaxPercentage = serviceTaxPercentage;
                objTransaction.BankTransfer = PayDetails;
                objTransaction.PaymentDate = dtPaymentDate.Value;
                objTransaction.CashAmount = objStudent.Fees.CashAmnt;
                objTransaction.TransferAmount = objStudent.Fees.TransferAmount;
                objTransaction.CashAccount = cashAccount;
                objTransaction.ReceiptNo = "";
                objTransaction.ReceivedBy = cmbReceivedBy.Text;
                objTransaction.Facility = this.facilityToPay;
               
                //Payment being done for multiple courses
                if (totalCashAmount + totalChequeAmount + totalFees > objStudent.Fees.TotalOutstanding)
                {
                    objTransaction.PaymentPackage = null;
                }
                else
                {
                    objTransaction.PaymentPackage = (cmbCoursePayment.SelectedItem as ComboItem).objectValue as StudentFacility;
                }



                if (txtCashAmount.Text != "" && txtCashAmount.Text != "0")
                {
                    objTransaction.PaymentMode = PaymentMode.CASH;
                }
                if (txtChequeAmount.Text != "" && txtChequeAmount.Text != "Rs 0.00")
                {
                    objTransaction.PaymentMode = PaymentMode.CHEQUE;
                }
                if (txtBankAmount.Text != "" && txtBankAmount.Text != "Rs 0.00")
                {
                    objTransaction.PaymentMode = PaymentMode.BANKTRANSFER;
                }

                BLL.FeesHandller.PayFees(objStudent.Fees, objTransaction, Program.LoggedInUser.BranchId);


                if (objStudent.Fees.FeesDiscount > 0)
                {
                    BLL.UserHandler.createActivity(objStudent.AdmissionNo, DateTime.Now.Date, "Discount Given: " + txtDiscount.Text + " reason for discount " + txtDiscountReason.Text.ToString(), objStudent.DisplayName, "0", txtDiscount.Text, Program.LoggedInUser.UserId.ToString(), Program.LoggedInUser.BranchId.ToString());
                }

                if (dtdueDate.Value.Date >= DateTime.Now.Date && outstanding > 0 && ClassManager.Properties.Settings.Default.NextDueInFeesPayment == true)
                {
                    Followup objFollowup = new Followup();
                    objFollowup.ReferenceID = objStudent.AdmisionNo.ToString();
                    objFollowup.FollowupType = Followup.TpyeOfFollowUp.OutstandingDue.ToString();
                    objFollowup.FollowupDate = dtdueDate.Value;

                    objFollowup.FollowupDesc = objStudent.Fname + " " + objStudent.Mname + " " + objStudent.Lname + " " + objStudent.ContactNo + " " + lblOFees.Text + " ";
                    objFollowup.FollowupMediam = "System";
                    objFollowup.FollowupBy = Program.LoggedInUser.UserId;

                    FollowupHandler.SaveFollowup(objFollowup, branchId);
                }
                UICommon.WinForm.showStatus("Fees paid successfully, Receipt no is : " + objTransaction.ReceiptNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                btnPay.Enabled = false;
                btnSubmit.Enabled = false;
                objTransaction.PaymentPackage = (cmbCoursePayment.SelectedItem as ComboItem).objectValue as StudentFacility;

                objFeeData = new FeeReceiptReportData();
                objFeeData.BranchId = objStudent.Branch.BranchName.ToString();
                objFeeData.PaymentDate = dtPaymentDate.Value;
                objFeeData.ReceiptNo = objTransaction.ReceiptNo;
                objFeeData.RollNo = objStudent.RollNo;
                objFeeData.RupeesInWord = Utility.currencyInWords(objTransaction.Amount);
                objFeeData.ServiceTax = objTransaction.ServiceTax;
                objFeeData.StudentName = objStudent.Fname + ' ' + objStudent.Mname + ' ' + objStudent.Lname;
                objFeeData.FatherContactNo = objStudent.ContactNo;
                objFeeData.EmailId = objStudent.EmailID;
                objFeeData.FinalAmount = objStudent.Fees.TotalFees - Convert.ToDecimal(lblDiscountGiven.Text);
                objFeeData.ParentName = objStudent.ParentName;
                objFeeData.TaxPercentage = Info.SysParam.getValue<float>(SysParam.Parameters.SERVICE_TAX);
                objFeeData.TotalFees = objTransaction.Amount;
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
                objFeeData.BranchAddress = Info.SysParam.getValue<String>(SysParam.Parameters.SW_BRANCH_NAME);
                objFeeData.PackageAmount = objStudent.Fees.TotalFees;
                objFeeData.InstallDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);

                // DataTable dtInstDetails = BLL.InstallmentHandler.getInsdDetails(branchId.ToString(), objStudent.Fees.FeesId);
                objFeeData.InstMonth = objStudent.Fees.MonthPaidStatus;
                objFeeData.PaymentDetails = objStudent.Fees.MonthPaidStatus;

                //DataTable dtTransaction = BLL.FeesHandller.getTransactionReprint(objTransaction.TrancID.ToString());

                objFeeData.StartDate = objTransaction.PaymentPackage.FromDate;
                objFeeData.EndDate = objTransaction.PaymentPackage.ToDate;

                //  objFeeData.EndDate = Convert.ToDateTime(dtTransaction.Rows[0].ItemArray[34].ToString());

                if (SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).Equals(""))
                {
                    objFeeData.Standard = objTransaction.PaymentPackage.Package.Standard.StandardName;
                }
                else
                {
                    objFeeData.Standard = objTransaction.PaymentPackage.Package.Standard.Stream.Name;
                }

                if (ClassManager.Properties.Settings.Default.ShowBatchInReceipt == true)
                {
                    objFeeData.Standard += "/" + objTransaction.PaymentPackage.Package.PackageName;
                }

                objFeeData.PackageName = objTransaction.PaymentPackage.Package.PackageName;

                // lblTotalOustanding
                try
                {
                    if (Info.SysParam.getValue<String>(SysParam.Parameters.CUMMULATIVE_PAYMENT).Equals("True"))
                    {
                        objFeeData.OutstandingAmount = Convert.ToDecimal(lblTotalOustanding.Text);
                    }
                    else
                    {
                        objFeeData.OutstandingAmount = Convert.ToDecimal(lblOFees.Text);
                    }
                }
                catch(Exception ex)
                {

                }

                
                  
              //  objFeeData.OutstandingAmount = Convert.ToDecimal(lblTotalOustanding.Text);
                if (Math.Sign(objFeeData.OutstandingAmount) == -1)
                {
                    objFeeData.OutstandingAmount = decimal.Zero;
                }
                objFeeData.MembershipNo = objStudent.MembershipNo;

                objFeeData.TuitionFees = objTransaction.PaymentPackage.Amount;
                objFeeData.Cheques = objTransaction.Cheques;
                objFeeData.PaymentMode = objTransaction.PaymentMode.ToString();
                objFeeData.BankTransfer = objTransaction.BankTransfer;
                objFeeData.FineAmount = objTransaction.Fine;
                objFeeData.TransactionId = objTransaction.TrancID;
                objFeeData.FeesId = objStudent.Fees.FeesId;//added for etech on 30-03-2019
                objFeeData.CashPayment = objStudent.Fees.CashAmnt;
                objFeeData.ChequePayment = objStudent.Fees.ChequeAmnt + objStudent.Fees.PndgChqAmnt;
                objFeeData.AdmsnNo = objTransaction.AdmisionNo;
                objFeeData.TotalAmount = objStudent.Fees.TotalFees;//added for etech on 30-03-2019

                NumberToMonth.Months installmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objTransaction.Month.ToString());
                NumberToMonth.Months lastinstallmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objStudent.Fees.LastMonthPaid.ToString());
                objFeeData.InstallmentMonths = installmonth.ToString();
                objFeeData.LastInstallmentMonth = lastinstallmonth.ToString();
                objFeeData.AdmsnNo = objStudent.AdmisionNo;
                objFeeData.Address = objStudent.Address;
                objFeeData.ContactNo = objStudent.ContactNo;
                objFeeData.FatherCntct = objStudent.FatherContactNo;
                objFeeData.DOB = objStudent.Dob;
                objFeeData.duration = objStudent.FeesPackage.PackageDuration.ToString();
                objFeeData.Batch = objStudent.Course.Batch.Name;
                objFeeData.stud_photo = objStudent.PhotoURL;
                objFeeData.Adhar = objStudent.AdharCard;
                objFeeData.TotalOutstanding = Convert.ToDecimal(lblTotalOustanding.Text);
                objFeeData.ReceivedBy = objTransaction.ReceivedBy;
                objFeeData.FatherContactNo = objStudent.FatherContactNo;

                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).Equals("Asset"))
                {
                    objFeeData.BatchDays = objStudent.Remark;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cmdReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                pnlFeesDetails.Visible = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Something went wrong, Please contact suppport", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void FrmFeesPayment_Load(object sender, EventArgs e)
        {
            try
            {
                List<Account> lstAcc = new List<Account>();
                lstAcc = BLL.AccountHandller.getAccounts(branchId);
                cmbAccount.DataSource = lstAcc;
                foreach (var list in lstAcc)
                {
                    if (list.AccountName.ToLower().Equals("cash"))
                    {
                        cashAccount = list;
                        if (cashAccount != null)
                        {
                            cmbAccount.SelectedItem = cashAccount;
                        }
                    }
                }

                formatForm();

                if (this.IsMdiChild != true)
                {
                    cmbStudName.Text = objStudent.DisplayName;
                }
                else
                {
                    ClearForm();
                    List<ComboItem> lstStudentDetails = new List<ComboItem>();

                    lstStudentDetails.Add(new ComboItem(-1, "Select Member"));

                    lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(Program.LoggedInUser.BranchId.ToString()));
                    //cmbStudName.SelectedIndex = 0;
                    cmbStudName.DataSource = new List<Student>();
                    cmbStudName.DisplayMember = "name";
                    cmbStudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);
                    cmbStudName.DataSource = lstStudentDetails;
                    if (objStudent == null)
                    {
                        cmbStudName.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbStudName.Text = objStudent.DisplayName;
                    }
                    //Get only CR Accounts 12:00AM 08/01/2017
                    //List<Account> lstAcc = new List<Account>();
                    //lstAcc = BLL.AccountHandller.getAccounts(branchId);
                    //cmbAccount.DataSource = lstAcc;

                    //cashAccount = lstAcc.Where(account => account.AccountName == "Cash").FirstOrDefault<Account>();

                    //if (cashAccount != null)
                    //{
                    //    cmbAccount.SelectedItem = cashAccount;
                    //}


                    //cmbAccount.DataSource = lstAcc.Where(acc => acc.AccountType == "CR").ToList();

                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    btnDelete.HeaderText = "Remove";
                    btnDelete.DefaultCellStyle.NullValue = "Remove";
                    btnDelete.Name = "btnDelete";
                    btnDelete.Text = "Remove";
                    ADGVCheques.Columns.Insert(0, btnDelete);
                    AssignEvents();
                    formatForm();
                    isFormClear = false;
                    if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Gym")
                    {
                        lblCrse.Text = "Package:";
                        lblCourse.Text = "Package:";
                    }
                    txtChequeAmount.Visible = true;
                    txtBankAmount.Visible = true;
                }

                if (ClassManager.Properties.Settings.Default.NextDueInFeesPayment == false)
                {
                    lblNextDue.Visible = false;
                    dtdueDate.Visible = false;
                }

                loadPaymentUsers();


            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void loadPaymentUsers()
        {
            try
            {
                string users = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
                Boolean showReceivedBy = ClassManager.Properties.Settings.Default.ShowReceivedBy;
                if (showReceivedBy == true)
                {
                    if (users == "")
                    {
                        cmbReceivedBy.Visible = false;
                        lblReceivedBy.Visible = false;
                    }
                    else
                    {
                        string[] items = users.Split(',');
                        cmbReceivedBy.Visible = true;
                        lblReceivedBy.Visible = true;

                        foreach (String value in items)
                        {
                            cmbReceivedBy.Items.Add(value);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
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
                        btnSubmit.Visible = false;
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

        internal void payFacilityAmount(StudentFacility objFacility)
        {

        }

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtdueDate);
                UICommon.WinForm.formatDateTimePicker(dtPaymentDate);
                ADGVCheques.DefaultCellStyle.ForeColor = Color.Black;

                chkviewRcpt.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.VIEW_RECEIPT);

                if (ClassManager.Properties.Settings.Default.ShowCash == false)
                {
                    txtCashAmount.Visible = false;
                    cmbAccount.Visible = false;

                    lblAccount.Visible = false;
                    lblCashAmount.Visible = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RemoveEvents()
        {
            try
            {
                txtFine.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);

                txtCashAmount.TextChanged -= new System.EventHandler(this.txtCashAmount_TextChanged);
                txtChequeAmount.TextChanged -= new System.EventHandler(this.txtChequeAmount_TextChanged);
                txtBankAmount.TextChanged -= new System.EventHandler(this.txtBankAmount_TextChanged);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void AssignEvents()
        {
            try
            {
                txtFine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtCashAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtChequeAmount.TextChanged += new System.EventHandler(this.txtChequeAmount_TextChanged);
                txtCashAmount.TextChanged += new System.EventHandler(this.txtCashAmount_TextChanged);
                txtAdmissinoNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtBankAmount.TextChanged += new System.EventHandler(this.txtBankAmount_TextChanged);
                //cmbStudName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool validate()
        {
            try
            {

                outstanding = Convert.ToDecimal(lblOFees.Text);

                bool isExceeding = false;
                if (SysParam.getValue<bool>(SysParam.Parameters.CUMMULATIVE_PAYMENT) == true)
                {
                    isExceeding = (totalCashAmount + totalFees + totalChequeAmount) > totalOutstanding;
                }
                else
                {
                    isExceeding = (totalCashAmount + totalFees + totalChequeAmount) > objStudent.Fees.TotalOutstanding;
                }

                if (isExceeding)
                {
                    UICommon.WinForm.showStatus("Discount and Current paying amount  is more the outstanding fees.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (txtActualPaymentAmnt.Text == "")
                {
                    txtActualPaymentAmnt.Text = "0";
                    if (Convert.ToInt32(txtActualPaymentAmnt.Text) <= 0)
                    {
                        UICommon.WinForm.showStatus("Please enter amount.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    }
                    return false;
                }
                else if (Convert.ToInt32(txtActualPaymentAmnt.Text) <= 0)
                {
                    UICommon.WinForm.showStatus("Please enter amount.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (cmbAccount.Items.Count == 0)
                {
                    UICommon.WinForm.showStatus("Please Create Account.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (dtdueDate.Value <= DateTime.Now && outstanding > 0 && ClassManager.Properties.Settings.Default.NextDueInFeesPayment == true)
                {
                    UICommon.WinForm.showStatus("Please select Next Due Date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtdueDate.Focus();
                    return false;
                }
                else if(cmbReceivedBy.Items.Count > 0 && cmbReceivedBy.Text == "")
                {
                    UICommon.WinForm.showStatus("Please mention fees receiving person name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbReceivedBy.Focus();
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



        /// <summary>
        /// This method is called from registration form to show fees payment for student
        /// </summary>
        /// <param name="objStudent"></param>
        /// <param name="objFacility"></param>
        /// <returns></returns>
        public bool LoadFeeDetailsFromRegistration(Student objStudent, StudentFacility objFacility = null)
        {
            try
            {

                LoadPaymentDetails(objStudent.AdmissionNo, objFacility);

                if (objFacility != null)
                {
                    this.Text = "Payment for " + objFacility.FacilityName + ". Outstanding amount " + objFacility.Pending;
                    this.facilityToPay = objFacility;
                }

                cmbStudName.Text = objStudent.DisplayName;
                cmbStudName.Enabled = false;

                isFormClear = true;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void LoadPaymentDetails(int admissionNo, StudentFacility objFacility = null)
        {
            try
            {
                if (cashAccount != null)
                {
                    cmbAccount.SelectedItem = cashAccount;
                }

                objStudent = StudentHandller.GetStudent(admissionNo, null, null, null, Program.LoggedInUser.BranchId);

                if (objStudent == null)
                {
                    UICommon.WinForm.showStatus("Please enter proper admission number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    pnlFeesDetails.Visible = false;
                }
                else
                {
                    cmdSearch.Text = "New Payment";
                    txtAdmissinoNO.Enabled = false;
                    cmbStudName.Enabled = false;
                    //lstInstDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                    this.Text = objStudent.DisplayName;

                    if (objStudent.Courses.Count == 0)
                    {
                        UICommon.WinForm.showStatus("No Package for " + objStudent.DisplayName + ", Please Add Package", sCaption, this);
                        FrmAddFacilities frmAddfacilities = new FrmAddFacilities(objStudent);
                        frmAddfacilities.ShowDialog(this);
                    }
                    else
                    {
                        loadCourses(objStudent, objFacility);
                        LoadDetails((cmbCoursePayment.Items[0] as ComboItem).objectValue as StudentFacility);
                        //LoadPDCDetails(objStudent.AdmisionNo);
                    }
                }
            }
            catch (NoFeesException ex)
            {
                UICommon.WinForm.showStatus("No outstanding fees for " + objStudent.Fname, sCaption, this);
                pnlFeesDetails.Visible = false;
                //ClearForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    /**    private void LoadPDCDetails(int admisionNo)
        {
            try
            {
                List<Info.Cheque> pdcs =  BLL.ChequeHandler.getPDC(admisionNo);
                if(pdcs.Count > 0)
                {
                    linkLabel1.Visible = true;
                    objStudent.PDCs = pdcs;
                   
                }
                else
                {
                    linkLabel1.Visible = true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }**/

        private void LoadDetails(StudentFacility selectedFacility)
        {
            try
            {
                lblStandard.Text = selectedFacility.Package.Standard.StandardName;
                lblBatch.Text = selectedFacility.Batch.Name;
                lblPackageCost.Text = selectedFacility.Amount.ToString();
                cmbStudName.Text = objStudent.DisplayName;
                txtFine.Text = "0";

                lblFeesPaid.Text = selectedFacility.Amount_Paid.ToString();
                lblDiscountGiven.Text = selectedFacility.Discount.ToString();

                totalOutstanding = (objStudent.Fees.TotalFees - (objStudent.Fees.FeesPaid + objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) + objStudent.Fees.Installments.Sum(cancelled => cancelled.CancelledAmount)));

                lblTotalOustanding.Text = totalOutstanding.ToString();
                objStudent.Fees.OutstandingAsOfDate = FeesHandller.getOutstngAsofDate(objStudent.AdmissionNo, DateTime.Now);


                lblTOFees.Text = Math.Max(0, objStudent.Fees.OutstandingAsOfDate).ToString();
                lblOFees.Text = selectedFacility.OutstandingFees.ToString();

                objStudent.Fees.TotalOutstanding = selectedFacility.OutstandingFees;

                lblCleared.Text = Convert.ToString(objStudent.Fees.FeesPaid - objStudent.Fees.PndgChqAmnt);
                lblUncleared.Text = Convert.ToString(objStudent.Fees.PndgChqAmnt);
                if (Math.Sign(objStudent.Fees.PndgChqAmnt) == -1)
                {
                    lblUncleared.Text = "0.00";
                }
                pnlFeesDetails.Visible = true;
                btnPay.Enabled = true;
                btnSubmit.Enabled = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void loadCourses(Student objStudent, StudentFacility payingFacility)
        {
            try
            {
                this.cmbCoursePayment.SelectedIndexChanged -= new System.EventHandler(this.cmbCoursePayment_SelectedIndexChanged);
                cmbCoursePayment.Items.Clear();

                foreach (StudentFacility facility in objStudent.Facilities.OrderBy(facility => facility.FromDate).ToList<StudentFacility>())
                {
                    List<InstallmentDetail> facilityInstallaments = objStudent.Fees.Installments.Where(inst => inst.Facility.Id == facility.Id).ToList<InstallmentDetail>();

                    Decimal facilityOutstanding = facilityInstallaments.Sum(amount => amount.InstAmount) - (facilityInstallaments.Sum(canceled => canceled.CancelledAmount) + facilityInstallaments.Sum(paid => paid.AmntPaid) + facilityInstallaments.Sum(discnt => discnt.Discount));
                    if (facilityOutstanding > 0)
                    {
                        facility.OutstandingFees = facilityOutstanding;
                        facility.Discount = facilityInstallaments.Sum(discnt => discnt.Discount);
                        facility.Batch = StudentHandller.getFacilityBatch(objStudent.AdmisionNo, facility.Id);
                        facility.Amount_Paid = facilityInstallaments.Sum(paid => paid.AmntPaid);
                        cmbCoursePayment.Items.Add(new ComboItem(facility.Id, facility.FacilityName + " (Balance fees :" + facilityOutstanding.ToString() + ")", facility));
                    }
                }

                if (cmbCoursePayment.Items.Count > 0)
                {

                    this.cmbCoursePayment.SelectedIndexChanged += new System.EventHandler(this.cmbCoursePayment_SelectedIndexChanged);
                    if (payingFacility != null)
                    {
                        for (int i = 0; i < cmbCoursePayment.Items.Count; i++)
                        {
                            if ((cmbCoursePayment.Items[i] as ComboItem).key == payingFacility.Id)
                            {
                                cmbCoursePayment.SelectedIndex = i;
                                break;
                            }
                        }
                    }else
                    {
                        cmbCoursePayment.SelectedIndex = 0;
                    }
                }
                else
                {
                    throw new NoFeesException("No Outstading fees.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void cmbStudName_DropDown(object sender, EventArgs e)
        {
            try
            {
                //cmbStudName.AutoCompleteMode = AutoCompleteMode.None;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmbStudName_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                // cmbStudName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                considerOnlyFine = false;
                decimal cashAmount;
                if (txtCashAmount.Text.Length == 0)
                {
                    cashAmount = 0;
                }
                else
                {
                    cashAmount = Convert.ToDecimal(txtCashAmount.Text);
                }

                bool amountExceeds = false;
                if (SysParam.getValue<bool>(SysParam.Parameters.CUMMULATIVE_PAYMENT) == false)
                {
                    amountExceeds = objStudent != null && cashAmount + totalChequeAmount + Convert.ToDecimal(txtDiscount.Text == "" ? "0" : txtDiscount.Text) > objStudent.Fees.TotalOutstanding;

                }
                else
                {
                    amountExceeds = cashAmount + totalChequeAmount + Convert.ToDecimal(txtDiscount.Text == "" ? "0" : txtDiscount.Text) > totalOutstanding;
                }
                if (amountExceeds)
                {
                    UICommon.WinForm.showStatus("Payment can not be greater than total outstanding fees" + ".", sCaption, this);
                    txtCashAmount.Text = "0";
                }
                else
                {
                    totalCashAmount = cashAmount;
                }
                setOutstanding();

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

                    if (result == DialogResult.OK && FrmChequePopup.objCheque != null)
                    {
                        decimal chequeAmount = Cheques.Sum(chq => chq.Amount) + FrmChequePopup.objCheque.Amount;

                        bool amountExceeds = false;
                        if (SysParam.getValue<bool>(SysParam.Parameters.CUMMULATIVE_PAYMENT) == false)
                        {
                            amountExceeds = (chequeAmount + totalFees + totalCashAmount + Convert.ToDecimal(txtDiscount.Text == "" ? "0" : txtDiscount.Text) > objStudent.Fees.TotalOutstanding);
                        }
                        else
                        {
                            amountExceeds = (chequeAmount + totalFees + totalCashAmount + Convert.ToDecimal(txtDiscount.Text == "" ? "0" : txtDiscount.Text) > totalOutstanding);
                        }

                        if (amountExceeds)
                        {
                            if (MessageBox.Show("Cheque amount exceeds outstanding fees, Do you want to continue?", "Add Cheque", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                            {
                                totalChequeAmount = chequeAmount;
                                Cheques.Add(FrmChequePopup.objCheque);
                                ADGVCheques.DataSource = null;
                                ADGVCheques.DataSource = Cheques;
                                formatChequeGrid();
                                txtChequeAmount.Text = totalChequeAmount.ToString();
                                setOutstanding();
                                break;
                            }
                            else
                            {
                                result = FrmChequePopup.getInstance().ShowDialog();
                            }
                        }
                        else
                        {
                            totalChequeAmount = chequeAmount;
                            Cheques.Add(FrmChequePopup.objCheque);

                            ADGVCheques.DataSource = null;
                            ADGVCheques.DataSource = Cheques;

                            formatChequeGrid();
                            txtChequeAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalChequeAmount.ToString()));
                            setOutstanding();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formatChequeGrid()
        {
            try
            {
                ADGVCheques.Columns["BounceCharges"].Visible = false;
                ADGVCheques.Columns["BranchID"].Visible = false;
                ADGVCheques.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void formatgrid()
        {
            ADGVCheques.Columns["BranchID"].Visible = false;
            ADGVCheques.Columns["Details"].Visible = false;
            ADGVCheques.Columns["ToAcc"].Visible = false;
        }
        private void lnkMoreDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //if (lstInstDetails.Count != 0)
                //{
                FrmCommonPopup objPopup = (FrmCommonPopup)UICommon.FormFactory.GetForm(Forms.FrmCommonPopup, this, true);
                lstInstDetails = BLL.InstallmentHandler.getInstallmentDetails(objStudent.Fees.FeesId);
                objPopup.ViewIns(lstInstDetails);
                objPopup.Visible = true;
                //}
                //else
                //{
                //    UICommon.WinForm.showStatus("There is no installment details. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                //}

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            try
            {
                considerOnlyFine = true;
                decimal fineAmount;

                if (txtFine.Text.Length == 0 && txtFine.Text != "")
                {
                    fineAmount = 0;
                }
                else
                {
                    fineAmount = Convert.ToDecimal(txtFine.Text);
                }

                fine = fineAmount;
                setOutstanding();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void lnkAddAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmCreateAccount objCreateAccount = new FrmCreateAccount();
                UICommon.WinForm.openForm(objCreateAccount, cmbAccount);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVCheques_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVCheques, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmbStudName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToInt16(Keys.Enter))
                {
                    if (cmbStudName.Text.Length != 0)
                    {
                        LoadPaymentDetails((cmbStudName.SelectedItem as ComboItem).key);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                considerOnlyFine = false;
                setOutstanding();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void txtBankAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                considerOnlyFine = false;
                setOutstanding();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (totalChequeAmount > 0)
                        {
                            totalChequeAmount = totalChequeAmount - Cheques[e.RowIndex].Amount;
                            txtChequeAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalChequeAmount.ToString()));
                            Cheques.RemoveAt(e.RowIndex);
                            setOutstanding();
                            ADGVCheques.DataSource = null;
                            ADGVCheques.DataSource = Cheques;
                            formatChequeGrid();
                        }
                        else
                        {
                            if (totalFees > 0)
                            {
                                totalFees = totalFees - PayDetails[e.RowIndex].Amount;
                                txtBankAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalFees.ToString()));
                                PayDetails.RemoveAt(e.RowIndex);
                                setOutstanding();
                                ADGVCheques.DataSource = null;
                                ADGVCheques.DataSource = PayDetails;
                                formatgrid();
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

        private void ClearForm()
        {
            if (isFormClear == false)
            {
                RemoveEvents();

                //Clear Search Details
                cmbStudName.Text = "Select Member";
                txtAdmissinoNO.Text = "";


                //Clear payment details

                txtFine.Text = "0";
                txtActualPaymentAmnt.Text = "0";
                txtCashAmount.Text = "0";
                txtChequeAmount.Text = "Rs 0.00";
                txtActualPaymentAmnt.Text = "0";
                txtDiscount.Text = "";

                //clear fees details

                lblOFees.Text = "0";
                this.Text = "";
                lblStandard.Text = "";
                lblPackageCost.Text = "0";
                lblFeesPaid.Text = "0";
                lblTOFees.Text = "0";
                lblDiscountGiven.Text = "0";
                lblBatch.Text = "";
                lblCleared.Text = "";
                lblUncleared.Text = "";
                txtDiscountReason.Text = "";
                dtPaymentDate.Value = DateTime.Now;
                dtdueDate.Value = DateTime.Now;
                AssignEvents();
                cmdSearch.Text = "SEARCH";

                txtAdmissinoNO.Select();
                txtAdmissinoNO.Enabled = true;
                cmbStudName.Enabled = true;

                txtBankAmount.Text = "Rs 0.00";
                Cheques = new List<Cheque>();
                ADGVCheques.DataSource = null;

                totalChequeAmount = 0;
                totalCashAmount = 0;
                totalFees = 0;
                cmbStudName.SelectedIndex = -1;
            }
        }

        //Mohan(11-July-2017).
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                setOutstanding();

                if (objStudent != null && Convert.ToDecimal(txtCashAmount.Text == "" ? "0" : txtCashAmount.Text) + totalChequeAmount + fine + Convert.ToDecimal(txtDiscount.Text == "" ? "0" : txtDiscount.Text) > objStudent.Fees.TotalOutstanding)
                {
                    UICommon.WinForm.showStatus("Discount can not be greater than total outstanding fees" + ".", sCaption, this);
                    txtDiscount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }

        }

        private void cmbStudName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudName.SelectedIndex > 0 && cmbStudName.SelectedItem != null)
                {
                    LoadPaymentDetails((cmbStudName.SelectedItem as ComboItem).key);
                }
            }
            catch (NoFeesException ex)
            {
                UICommon.WinForm.showStatus("No outstanding fees for " + objStudent.Fname, sCaption, this);
                pnlFeesDetails.Visible = false;
                //ClearForm();
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void txtAdmissinoNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar.ToString() != "A")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (txtAdmissinoNO.Text.Length >= 10)
                {
                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVCheques_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVCheques.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVCheques.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    PayFees();
                    PrintingConfig objPrintngConfig = new PrintingConfig();
                    objPrintngConfig.exportFormat = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                    Boolean autoPrintReceipt = SysParam.getValue<Boolean>(SysParam.Parameters.AUTO_PRINT_RECEIPT);
                    objPrintngConfig.PrintReport = autoPrintReceipt;
                    objPrintngConfig.reportType = "FEE_RECEIPT";
                    objPrintngConfig.SaveReport = false;
                    objPrintngConfig.ViewReport = false;
                    if (SysParam.getValue<string>(SysParam.Parameters.FEE_RECEIPT_TYPE) == "FEE_RECEIPT")
                    {
                        objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "FEE_RECEIPT");
                    }
                    else
                    {
                        objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), "INVOICE_RECEIPT");
                    }
                    objPrintngConfig.exportFileName = "Fee_Receipt_" + objStudent.AdmissionNo + "_" + objTransaction.ReceiptNo.Replace(@"/", "-");
                    objPrintngConfig.sendSMS = true;
                    objPrintngConfig.sendEmail = true;
                    FrmReportViewer frmRprtViewer = new FrmReportViewer();
                    frmRprtViewer.viewReport(objPrintngConfig.ReportName, objFeeData, objPrintngConfig, false);
                    FeeReceiptReportData objFeeReportData = objFeeData as FeeReceiptReportData;
                    UICommon.FormFactory.setMainFormStatus("Sending Fees Payment Message");
                    bwFeeMSG.RunWorkerAsync(objFeeReportData);
                    isFormClear = false;
                    ClearForm();
                    cmdSearch.Text = "SEARCH";
                    txtAdmissinoNO.Enabled = true;
                    cmbStudName.Enabled = true;
                    cmdSearch.Enabled = true;
                    pnlFeesDetails.Visible = false;
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

        private void bwFeeMSG_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool sendMail = (SysParam.getValue<bool>(SysParam.Parameters.SEND_FEES_MAIL));

                FeeReceiptReportData objFeeReceiptdata = (FeeReceiptReportData)e.Argument;
                MailHandler.sendFeesPayment(objFeeReceiptdata, true, sendMail, Program.LoggedInUser.BranchName);
            }

            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void bwFeeMSG_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    UICommon.FormFactory.setMainFormStatus(e.Error.Message);
                }
                else
                {
                    UICommon.FormFactory.setMainFormStatus("Message Sent Successfully");
                }

            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
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
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void lnkUncleared_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void chkviewRcpt_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.VIEW_RECEIPT, chkviewRcpt.Checked.ToString(), Convert.ToInt32(branchId));
                chkviewRcpt.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.VIEW_RECEIPT);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmbCoursePayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDetails((cmbCoursePayment.SelectedItem as ComboItem).objectValue as StudentFacility);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void lblCleared_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Info.Cheque> lst = objStudent.PDCs;
           
        //    DialogResult result = FrmPDCCheque.getInstance().ShowDialog();
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmBankTransfer form = new FrmBankTransfer();
                FrmBankTransfer.objStudentMaster = objStudent;
                // form.setName(objStudent);
                DialogResult result = FrmBankTransfer.getform().ShowDialog();

                PayDetails.Clear();
                while (result != DialogResult.Cancel)
                {
                    if (result == DialogResult.OK && FrmBankTransfer.objDetails != null)
                    {
                        decimal Amount = FrmBankTransfer.objDetails.Amount + PayDetails.Sum(amt => amt.Amount);
                        if (Amount + totalCashAmount + totalChequeAmount > objStudent.Fees.TotalOutstanding)
                        {
                            if (MessageBox.Show("Amount exceeds outstanding fees, Do you want to continue?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                            {

                                totalFees = Amount;
                                PayDetails.Add(FrmBankTransfer.objDetails);
                                ADGVCheques.DataSource = PayDetails;

                                formatgrid();
                                txtBankAmount.Text = totalFees.ToString();
                                setOutstanding();
                                break;
                            }
                            else
                            {
                                result = FrmBankTransfer.getform().ShowDialog();
                            }

                        }

                        else
                        {
                            totalFees = Amount;
                            PayDetails.Add(FrmBankTransfer.objDetails);
                            // ADGVCheques.DataSource = null;
                            if (ADGVCheques.Rows.Count == 0)
                            {
                                ADGVCheques.DataSource = PayDetails;
                            }
                            else
                            {
                                ADGVCheques.DataSource = PayDetails;
                            }
                            formatgrid();
                            txtBankAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalFees.ToString()));
                            setOutstanding();
                            break;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void setOutstanding(bool considerOnlyNewDiscount = false)
        {
            try
            {
                if (considerOnlyNewDiscount == false)
                {
                    txtActualPaymentAmnt.Text = (totalCashAmount + totalChequeAmount + fine + totalFees).ToString();

                    feesPaying = totalCashAmount + totalChequeAmount + totalFees;
                    if (considerOnlyFine == false)
                    {
                        lblTOFees.Text = (objStudent.Fees.OutstandingAsOfDate - feesPaying - Convert.ToInt32(txtDiscount.Text == "" ? "0" : txtDiscount.Text)).ToString();
                        lblTotalOustanding.Text = (totalOutstanding - feesPaying - Convert.ToInt32(txtDiscount.Text == "" ? "0" : txtDiscount.Text)).ToString();
                        lblOFees.Text = Math.Max(0, ((objStudent.Fees.TotalOutstanding) - feesPaying - Convert.ToInt32(txtDiscount.Text == "" ? "0" : txtDiscount.Text))).ToString();
                    }
                }
                else
                {
                    if (considerOnlyFine == false)
                    {
                        lblTOFees.Text = ((objStudent.Fees.OutstandingAsOfDate + objStudent.Fees.FeesDiscount) - newDiscount).ToString();
                        lblTotalOustanding.Text = ((totalOutstanding + objStudent.Fees.FeesDiscount) - newDiscount).ToString();
                        lblOFees.Text = Math.Max(0, ((objStudent.Fees.TotalOutstanding + objStudent.Fees.FeesDiscount) - newDiscount)).ToString();
                    }
                }
                if (Math.Sign(Convert.ToDecimal(lblTOFees.Text)) == -1)
                {
                    lblTOFees.Text = "0.00 ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmbStudName.Enabled = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
    }
}


