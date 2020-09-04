using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using ClassManager.Info.Reporting;
using ClassManager.WinApp.UICommon;
using ClassManager.Common;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using ClassManager.Info;
using static ClassManager.Info.SysParam;

namespace ClassManager.WinApp
{
    public partial class FrmReportViewer : FrmParentForm
    {
        string DocumentFolder = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmReportViewer()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Views the report.
        /// </summary>
        /// <param name="report"></param>
        /// <param name="reportData"></param>
        /// <param name="printConfig"></param>
        /// <param name="isReceiptReprint"></param>
        public void viewReport(Info.Reports report, IReportData reportData, PrintingConfig printConfig, bool isReceiptReprint = false)
        {
            try
            {
                Common.Log.LogError("ViewReport", Common.ErrorLevel.INFORMATION);
                ReportDocument cryRpt = new ReportDocument();
                FeeReceiptReportData feeRprtData = new FeeReceiptReportData();

                SqlConnectionStringBuilder connectionString = BLL.DBHandller.getConnectionStringBuilder();

                switch (report)
                {
                    case Info.Reports.FEE_RECEIPT_PRO:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\FEE_RECEIPT_PRO.rpt");
                        feeRprtData = reportData as FeeReceiptReportData;
                        DateTime paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        NumberToMonth.Months paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.ReceiptNo == null ? "" : feeRprtData.ReceiptNo);
                        if (isReceiptReprint)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Duplicate");
                        }
                        else
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "");
                        }
                        if (feeRprtData.ReceiptNo == null)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Cumulative Receipt");
                        }
                        cryRpt.SetParameterValue("fineAmount", Formatter.FormatCurrency(feeRprtData.FineAmount));
                        cryRpt.SetParameterValue("txtBankName", (feeRprtData.BankName == null) ? "" : feeRprtData.BankName);
                        cryRpt.SetParameterValue("txtChequeDate", (feeRprtData.ChequeDate == null) ? "" : Formatter.FormatDate(feeRprtData.ChequeDate.Value));
                        cryRpt.SetParameterValue("txtChequeNo", (feeRprtData.ChequeNo == null) ? "" : feeRprtData.ChequeNo);
                        cryRpt.SetParameterValue("txtRollNo", (feeRprtData.RollNo == null) ? "" : feeRprtData.RollNo);
                        cryRpt.SetParameterValue("txtRupeesInWord", feeRprtData.RupeesInWord);
                        cryRpt.SetParameterValue("txtStandard", feeRprtData.Standard);
                        cryRpt.SetParameterValue("txtStudentName", feeRprtData.StudentName);
                        cryRpt.SetParameterValue("txtAmountPaid", Formatter.FormatCurrency(feeRprtData.AmountPaid));
                        cryRpt.SetParameterValue("txtTaxPercentage", Formatter.FormatPercentage(feeRprtData.TaxPercentage));
                        cryRpt.SetParameterValue("txtTuitionFees", Formatter.FormatCurrency(feeRprtData.TuitionFees));
                        cryRpt.SetParameterValue("txtClassName", feeRprtData.ClassName);
                        cryRpt.SetParameterValue("txtClassAddress", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("logo", feeRprtData.Logo);
                        cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate));
                        cryRpt.SetParameterValue("txtPaymentMonth", paymentMonth.ToString());
                        cryRpt.SetParameterValue("Classes_Sub_Name", feeRprtData.ClassSubName);
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("txtOutstandingAmount", Common.Formatter.FormatCurrency(feeRprtData.OutstandingAmount));
                        cryRpt.SetParameterValue("txtMemberShipNo", (feeRprtData.MembershipNo == null) ? "" : feeRprtData.MembershipNo);
                        cryRpt.SetParameterValue("txtCashAmount", Common.Formatter.FormatCurrency(feeRprtData.CashPayment));
                        cryRpt.SetParameterValue("txtChequeAmount", feeRprtData.getBankTansferDetails());
                        cryRpt.SetParameterValue("Class_Contact", feeRprtData.clasContct);
                        cryRpt.SetParameterValue("Transaction_ID", feeRprtData.TransactionId);

                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);

                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\Receipt\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\Receipt-" + feeRprtData.ReceiptNo.Replace(@"/", "") + "-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";

                        break;


                    case Info.Reports.FEE_RECEIPT:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\FEE_RECEIPT.rpt");
                        Common.Log.LogError("opening Fee receipt", Common.ErrorLevel.INFORMATION);
                        feeRprtData = reportData as FeeReceiptReportData;
                        paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.ReceiptNo == null ? "" : feeRprtData.ReceiptNo);

                        if (isReceiptReprint)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Duplicate");
                        }
                        else
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "");
                        }
                        if (feeRprtData.ReceiptNo == null)
                        {
                            feeRprtData.ReceiptNo = feeRprtData.AdmsnNo.ToString();
                            cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.AdmsnNo);
                            cryRpt.SetParameterValue("txtIsDuplicate", "Cumulative Receipt");
                        }
                        try
                        {
                            cryRpt.SetParameterValue("FinalAmount", feeRprtData.FinalAmount);//added for monark fitness by ashvini on 8--2019
                        }
                        catch (Exception ex) { }

                        try
                        {
                            cryRpt.SetParameterValue("TotalFees", feeRprtData.TotalAmount);//added for monark fitness by ashvini on 8--2019
                        }
                        catch (Exception ex) { }
                        //cryRpt.SetParameterValue("txtTotAmount", feeRprtData.TotalAmount);

                        try
                        {
                            cryRpt.SetParameterValue("Fees_ID", feeRprtData.FeesId);
                        }
                        catch (Exception ex)
                        {
                        }


                        try
                        {
                            cryRpt.SetParameterValue("ReceivedBy", feeRprtData.ReceivedBy);
                        }
                        catch (Exception ex)
                        {
                        }

                        try
                        {
                            cryRpt.SetParameterValue("applicationType", Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME));
                        }
                        catch (Exception ex)
                        {
                            
                        }

                        cryRpt.SetParameterValue("fineAmount", feeRprtData.FineAmount);
                        cryRpt.SetParameterValue("txtBankName", (feeRprtData.BankName == null) ? "" : feeRprtData.BankName);
                        cryRpt.SetParameterValue("txtChequeDate", (feeRprtData.ChequeDate == null) ? "" : Formatter.FormatDate(feeRprtData.ChequeDate.Value));
                        cryRpt.SetParameterValue("txtChequeNo", (feeRprtData.ChequeNo == null) ? "" : feeRprtData.ChequeNo);
                        cryRpt.SetParameterValue("txtRollNo", (feeRprtData.RollNo == null) ? feeRprtData.AdmsnNo.ToString() : feeRprtData.RollNo);
                        cryRpt.SetParameterValue("txtRupeesInWord", feeRprtData.RupeesInWord);
                        cryRpt.SetParameterValue("txtStandard", feeRprtData.Standard);
                        cryRpt.SetParameterValue("txtStudentName", feeRprtData.StudentName);
                        cryRpt.SetParameterValue("txtAmountPaid", Formatter.FormatCurrency(feeRprtData.TotalFees));
                        cryRpt.SetParameterValue("txtTaxPercentage", Formatter.FormatPercentage(feeRprtData.TaxPercentage));
                        cryRpt.SetParameterValue("txtTuitionFees", Formatter.FormatCurrency(feeRprtData.TuitionFees));
                        cryRpt.SetParameterValue("txtClassName", feeRprtData.ClassName);
                        cryRpt.SetParameterValue("txtClassAddress", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("logo", feeRprtData.Logo);
                        

                        if (feeRprtData.minDate < feeRprtData.FromDate)
                        {
                            cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.FromDate) + " To " + (Formatter.FormatDate(feeRprtData.PaymentDate)));
                        }
                        else
                        {

                            cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate));
                        }

                        cryRpt.SetParameterValue("txtPaymentMonth", paymentMonth.ToString());
                        cryRpt.SetParameterValue("Classes_Sub_Name", feeRprtData.ClassSubName);
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("txtOutstandingAmount", Common.Formatter.FormatCurrency(feeRprtData.OutstandingAmount));
                        cryRpt.SetParameterValue("txtMemberShipNo", (feeRprtData.MembershipNo == null) ? "" : feeRprtData.MembershipNo);
                        cryRpt.SetParameterValue("txtCashAmount", Common.Formatter.FormatCurrency(feeRprtData.CashPayment));
                        cryRpt.SetParameterValue("txtChequeAmount", feeRprtData.getBankTansferDetails());
                        cryRpt.SetParameterValue("Class_Contact", feeRprtData.clasContct);
                        if (ClassManager.Properties.Settings.Default.PutDurationInReceiptNote == true)
                        {
                            try
                            {
                                feeRprtData.ClassNote = Lang.translate("validity_from") + " " + Common.Formatter.FormatDate(feeRprtData.StartDate.Value) + " " + Lang.translate("validity_to") + " " + Common.Formatter.FormatDate(feeRprtData.EndDate.Value) + "\n" + feeRprtData.ClassNote;
                                cryRpt.SetParameterValue("txtNote", feeRprtData.ClassNote);
                            }catch(Exception ex) { }
                            
                        }

                        cryRpt.SetParameterValue("lblBatch", Lang.translate("Batch"));

                        if (ClassManager.Properties.Settings.Default.ShowBatchInReceipt == true)
                        {
                            cryRpt.SetParameterValue("txtBatch", (feeRprtData.Batch == null) ? "" : feeRprtData.Batch);//changed by ashvni on 30-03-2019 for resolvini issue when batch is null in cumulative receipt
                            cryRpt.SetParameterValue("txtBatchLabel", Lang.translate("Batch :"));
                        }
                        else
                        {
                            cryRpt.SetParameterValue("txtBatch", (feeRprtData.PackageName == null) ? "" : feeRprtData.PackageName);
                            cryRpt.SetParameterValue("txtBatchLabel", "Program :");
                        }
                        try
                        {
                            cryRpt.SetParameterValue("FinalFees", feeRprtData.FinalAmount);
                        }
                        catch (Exception ex)
                        {
                        }

                        try
                        {
                            cryRpt.SetParameterValue("ContactNo", feeRprtData.ContactNo);
                        }
                        catch (Exception)
                        {

                            
                        }

                        try
                        {
                            cryRpt.SetParameterValue("FatherContactNo", feeRprtData.FatherContactNo);
                        }
                        catch (Exception)
                        {

                           
                        }

                        cryRpt.SetParameterValue("txtNote", (feeRprtData.ClassNote == null) ? "" : feeRprtData.ClassNote);

                        cryRpt.SetParameterValue("Transaction_ID", feeRprtData.TransactionId);
                        cryRpt.SetParameterValue("showBalance", ClassManager.Properties.Settings.Default.ShowBalanceInReceipt);
                        cryRpt.SetParameterValue("printDualReceipt", ClassManager.Properties.Settings.Default.DualReceipt);
                        cryRpt.SetParameterValue("showCash", ClassManager.Properties.Settings.Default.ShowCash);


                        if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == Common.Constants.ASSET_APP_TYPE && feeRprtData.BatchDays != null)
                        {
                            cryRpt.SetParameterValue("txtBatchDays", (feeRprtData.BatchDays == null) ? "" : feeRprtData.BatchDays);
                        }

                        if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == "")
                        {
                            cryRpt.SetParameterValue("txtApType", Lang.translate("Course: "));
                        }
                        else
                        {
                            cryRpt.SetParameterValue("txtApType", Lang.translate("Package: "));
                        }



                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);

                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\Receipt\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\Receipt-" + feeRprtData.ReceiptNo.Replace(@"/", "") + "-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";
                        break;

                    case Info.Reports.INVOICE_RECEIPT:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\INVOICE_RECEIPT.rpt");
                        feeRprtData = reportData as FeeReceiptReportData;
                        paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("txtClassName", feeRprtData.ClassName);
                        cryRpt.SetParameterValue("txtServiceTaxNo", feeRprtData.ServiceTaxNo);
                        cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate));
                        cryRpt.SetParameterValue("txtStudentName", feeRprtData.StudentName);
                        cryRpt.SetParameterValue("logo", feeRprtData.Logo);
                        cryRpt.SetParameterValue("Class_note", feeRprtData.ClassNote);
                        cryRpt.SetParameterValue("txtAdmisionNo", feeRprtData.AdmsnNo);
                        cryRpt.SetParameterValue("txtPackageName", feeRprtData.Standard);
                        cryRpt.SetParameterValue("txtOutstandingAmount", feeRprtData.OutstandingAmount);
                        cryRpt.SetParameterValue("txtAmountPaid", (feeRprtData.TotalFees));
                        cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.ReceiptNo == null ? "" : feeRprtData.ReceiptNo);
                        cryRpt.SetParameterValue("Total_Fees", (feeRprtData.PackageAmount));
                        cryRpt.SetParameterValue("Branch_Add", (feeRprtData.BranchAddress));
                        cryRpt.SetParameterValue("txtMemberShipNo", (feeRprtData.MembershipNo));
                        cryRpt.SetParameterValue("Classes_Sub_Name", (feeRprtData.ClassSubName));
                        cryRpt.SetParameterValue("txtRupeesInWord", feeRprtData.RupeesInWord);
                        cryRpt.SetParameterValue("txtEnd", feeRprtData.EndDate);
                        cryRpt.SetParameterValue("txtStart", feeRprtData.StartDate);
                        cryRpt.SetParameterValue("Class_Contact", feeRprtData.clasContct);
                        cryRpt.SetDatabaseLogon(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\InvoiceReceipt\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\InvoiceReceipt-" + feeRprtData.ReceiptNo.Replace(@"/", "") + "-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";

                        break;




                    case Info.Reports.INVOICE:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\INVOICE.rpt");
                        feeRprtData = reportData as FeeReceiptReportData;
                        paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("txtClassName", feeRprtData.ClassName);
                        cryRpt.SetParameterValue("txtServiceTaxNo", feeRprtData.ServiceTaxNo);
                        cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate));
                        cryRpt.SetParameterValue("txtStudentName", feeRprtData.StudentName);
                        cryRpt.SetParameterValue("logo", feeRprtData.Logo);
                        cryRpt.SetParameterValue("Class_note", feeRprtData.ClassNote);
                        cryRpt.SetParameterValue("txtAdmisionNo", feeRprtData.AdmsnNo);
                        cryRpt.SetParameterValue("txtPackageName", feeRprtData.PackageName.ToString());
                        cryRpt.SetParameterValue("txtOutstandingAmount", feeRprtData.OutstandingAmount);
                        cryRpt.SetParameterValue("txtAmountPaid", (feeRprtData.TotalFees));
                        cryRpt.SetParameterValue("txtSAC", (feeRprtData.SACCode));
                        cryRpt.SetParameterValue("txtPackageAmount", (feeRprtData.PackageAmount));
                        cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.ReceiptNo == null ? "" : feeRprtData.ReceiptNo);
                        cryRpt.SetDatabaseLogon(connectionString.UserID, connectionString.Password, connectionString.DataSource, connectionString.InitialCatalog);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\Invoice\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\Invoice-" + feeRprtData.ReceiptNo.Replace(@"/", "") + "-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";

                        break;



                    case Info.Reports.FEE_RECEIPT_2:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\FEE_RECEIPT_2.rpt");
                        feeRprtData = reportData as FeeReceiptReportData;
                        paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.ReceiptNo == null ? "" : feeRprtData.ReceiptNo);

                        if (isReceiptReprint && feeRprtData.ReceiptNo != null)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Duplicate");
                        }
                        else if (feeRprtData.ReceiptNo == null)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Cumulative Receipt");
                        }
                        else
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "");
                        }
                        cryRpt.SetParameterValue("fineAmount", Formatter.FormatCurrency(feeRprtData.FineAmount));
                        cryRpt.SetParameterValue("txtRollNo", (feeRprtData.RollNo == null) ? "" : feeRprtData.RollNo);
                        cryRpt.SetParameterValue("txtRupeesInWord", feeRprtData.RupeesInWord);
                        cryRpt.SetParameterValue("txtServiceTax", Formatter.FormatCurrency(feeRprtData.ServiceTax));
                        cryRpt.SetParameterValue("txtStandard", feeRprtData.Standard);
                        cryRpt.SetParameterValue("txtStudentName", feeRprtData.StudentName);
                        cryRpt.SetParameterValue("txtTaxPercentage", Formatter.FormatPercentage(feeRprtData.TaxPercentage));
                        cryRpt.SetParameterValue("txtAmountPaid", feeRprtData.TotalFees);
                        cryRpt.SetParameterValue("txtTuitionFees", Formatter.FormatCurrency(feeRprtData.TuitionFees));
                        cryRpt.SetParameterValue("txtSirName", feeRprtData.SirName);
                        cryRpt.SetParameterValue("txtClassName", feeRprtData.ClassName);
                        cryRpt.SetParameterValue("logo", feeRprtData.Logo);
                        cryRpt.SetParameterValue("txtServiceTaxNo", feeRprtData.ServiceTaxNo);
                        cryRpt.SetParameterValue("txtPanNo", feeRprtData.CmpnyPanNO);
                        cryRpt.SetParameterValue("CINNO", feeRprtData.CINNO);
                        cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate));
                        cryRpt.SetParameterValue("txtPaymentMonth", paymentMonth.ToString());
                        cryRpt.SetParameterValue("txtOutstandingAmount", Formatter.FormatCurrency(feeRprtData.OutstandingAmount));
                        cryRpt.SetParameterValue("txtMemberShipNo", feeRprtData.MembershipNo);
                        cryRpt.SetParameterValue("txtCashAmount", Formatter.FormatCurrency(feeRprtData.CashPayment));
                        cryRpt.SetParameterValue("txtChequeAmount", Formatter.FormatCurrency(feeRprtData.ChequePayment));
                        cryRpt.SetParameterValue("Transaction_ID", feeRprtData.TransactionId);
                        cryRpt.SetParameterValue("Classes_Sub_Name", feeRprtData.ClassSubName);
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("Class_Contact", feeRprtData.clasContct);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        break;


                    case Info.Reports.INVOICE_REPORT:
                        cryRpt = new ReportDocument();
                        Common.Log.LogError(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\INVOICE_REPORT.rpt", Common.ErrorLevel.INFORMATION);
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\INVOICE_REPORT.rpt");

                        feeRprtData = reportData as FeeReceiptReportData;
                        paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("txtReceiptNo", feeRprtData.ReceiptNo == null ? "" : feeRprtData.ReceiptNo);
                        cryRpt.SetParameterValue("txtClassName", feeRprtData.ClassName);
                        cryRpt.SetParameterValue("SubClassName", feeRprtData.ClassSubName);

                        if (isReceiptReprint && feeRprtData.ReceiptNo != null)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Duplicate");
                        }
                        else if (feeRprtData.ReceiptNo == null)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Cumulative Receipt");
                        }

                        cryRpt.SetParameterValue("CINNO", feeRprtData.CINNO);
                        cryRpt.SetParameterValue("txtClassAddress", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("txtStudentName", feeRprtData.StudentName);
                        cryRpt.SetParameterValue("txtRupeesInWord", feeRprtData.RupeesInWord);
                        cryRpt.SetParameterValue("txtRollNo", (feeRprtData.RollNo == null) ? "" : feeRprtData.RollNo);
                        cryRpt.SetParameterValue("txtStandard", (feeRprtData.Standard == null) ? feeRprtData.PackageName : feeRprtData.Standard);
                        cryRpt.SetParameterValue("txtCashAmount", Formatter.FormatCurrency(feeRprtData.CashPayment));
                        cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate.Date));
                        cryRpt.SetParameterValue("txtPanNo", feeRprtData.CmpnyPanNO);
                        cryRpt.SetParameterValue("txtServiceTaxNo", feeRprtData.ServiceTaxNo);
                        cryRpt.SetParameterValue("txtPaymentDetails", (feeRprtData.PaymentDetails == null) ? "" : feeRprtData.PaymentDetails.ToString());
                        cryRpt.SetParameterValue("txtAmountPaid", (feeRprtData.TotalFees));
                        cryRpt.SetParameterValue("txtServiceTax", Formatter.FormatCurrency(feeRprtData.ServiceTax));
                        cryRpt.SetParameterValue("txtPaymentMonth", paymentMonth.ToString());
                        cryRpt.SetParameterValue("txtTuitionFees", feeRprtData.TuitionFees);
                        cryRpt.SetParameterValue("logo", feeRprtData.Logo);
                        cryRpt.SetParameterValue("txtOutstandingAmount", feeRprtData.OutstandingAmount);
                        cryRpt.SetParameterValue("txtMemberShipNo", (feeRprtData.MembershipNo == null) ? "" : feeRprtData.MembershipNo);
                        cryRpt.SetParameterValue("txtSubClassName", feeRprtData.ClassSubName);
                        cryRpt.SetParameterValue("txtChequeAmount", Formatter.FormatCurrency(feeRprtData.ChequePayment));
                        cryRpt.SetParameterValue("fineAmount", Formatter.FormatCurrency(feeRprtData.FineAmount));
                        cryRpt.SetParameterValue("Transaction_ID", feeRprtData.TransactionId);
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("Class_Contact", feeRprtData.clasContct);
                        cryRpt.SetParameterValue("txtStudContact", feeRprtData.ContactNo);
                        cryRpt.SetParameterValue("txtPaymentDate", Formatter.FormatDate(feeRprtData.PaymentDate.Date));
                        cryRpt.SetParameterValue("txtAdmisionNo", feeRprtData.AdmsnNo);
                        cryRpt.SetParameterValue("txtPackageName", feeRprtData.PackageName);
                        cryRpt.SetParameterValue("txtPackageAmount", feeRprtData.PackageAmount);
                        cryRpt.SetParameterValue("txtSAC", (feeRprtData.SACCode == null) ? "999293" : feeRprtData.SACCode);
                        cryRpt.SetParameterValue("txtDiscount", feeRprtData.DisCount.ToString());
                        cryRpt.SetParameterValue("txtActualPackgeAmount", feeRprtData.TuitionFees);
                        cryRpt.SetParameterValue("txtGSTNo",SysParam.getValue<string>(Parameters.GST_NO));
                        if (ClassManager.Properties.Settings.Default.PutDurationInReceiptNote == true && feeRprtData.StartDate != null && feeRprtData.EndDate != null)
                        {
                            feeRprtData.ClassNote = Lang.translate("validity_from") + " " + Common.Formatter.FormatDate(feeRprtData.StartDate.Value) + " " + Lang.translate("validity_to") + " " + Common.Formatter.FormatDate(feeRprtData.EndDate.Value) + "\n" + feeRprtData.ClassNote;
                            cryRpt.SetParameterValue("txtNote", feeRprtData.ClassNote);
                        }
                        StringBuilder Address = new StringBuilder(feeRprtData.Address);
                        Address.Append("-Maharashtra").Append(".");
                        feeRprtData.Address = Address.ToString();
                        cryRpt.SetParameterValue("txtAddress", feeRprtData.Address);
                        cryRpt.SetParameterValue("txtParentName", feeRprtData.ParentName);
                        cryRpt.SetParameterValue("Classes_Sub_Name", feeRprtData.ClassSubName);
                        cryRpt.SetParameterValue("txtAmountPaid", feeRprtData.AmountPaid);
                        cryRpt.SetParameterValue("FACILITY_ID", feeRprtData.FacilityId);


                        if (isReceiptReprint)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Duplicate");
                        }
                        else
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "");
                        }
                        if (feeRprtData.ReceiptNo == null)
                        {
                            cryRpt.SetParameterValue("txtIsDuplicate", "Cumulative Receipt");
                        }

                        if (cryRpt.DataSourceConnections != null && cryRpt.DataSourceConnections.Count > 0)
                        {
                            cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        }
                        else
                        {
                            cryRpt.SetDatabaseLogon(connectionString.UserID, connectionString.Password, connectionString.DataSource, connectionString.InitialCatalog);
                        }

                        //cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\InvoiceReport\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\InvoiceReport-" + feeRprtData.ReceiptNo.Replace(@"/", "") + "-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";

                        break;

                    case Info.Reports.FIN_EXPENSE:
                        CommonReportData commonRprtData;
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\FIN_EXPENSE.rpt");
                        commonRprtData = reportData as CommonReportData;
                        cryRpt.SetParameterValue("Classes_Name", commonRprtData.ClassName);
                        cryRpt.SetParameterValue("Classes_Sub_Name", commonRprtData.ClassSubName);
                        cryRpt.SetParameterValue("Classes_Full_Address", commonRprtData.ClassAddress);
                        cryRpt.SetParameterValue("Classes_Note", commonRprtData.ClassNote);
                        cryRpt.SetParameterValue("FROM_DATE", commonRprtData.FromDate);
                        cryRpt.SetParameterValue("TO_DATE", commonRprtData.ToDate);
                        cryRpt.SetParameterValue("Logo", commonRprtData.Logo);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        ClassManager.Common.Log.LogError(connectionString.DataSource, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.InitialCatalog, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.UserID, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.Password, Common.ErrorLevel.INFORMATION);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\ExpenseReport\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\ExpenseReport.pdf";

                        break;



                    case Info.Reports.FIN_INCOME:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\FIN_INCOME.rpt");
                        commonRprtData = reportData as CommonReportData;
                        cryRpt.SetParameterValue("Classes_Name", commonRprtData.ClassName);
                        cryRpt.SetParameterValue("Classes_Sub_Name", commonRprtData.ClassSubName);
                        cryRpt.SetParameterValue("Classes_Full_Address", commonRprtData.ClassAddress);
                        cryRpt.SetParameterValue("FROM_DATE", commonRprtData.FromDate);
                        cryRpt.SetParameterValue("TO_DATE", commonRprtData.ToDate);
                        cryRpt.SetParameterValue("Logo", commonRprtData.Logo);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        ClassManager.Common.Log.LogError(connectionString.DataSource, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.InitialCatalog, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.UserID, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.Password, Common.ErrorLevel.INFORMATION);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\IncomeReport\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\IncomeReport.pdf";

                        break;


                    case Info.Reports.LECTURE:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\LECTURE.rpt");
                        commonRprtData = reportData as CommonReportData;
                        cryRpt.SetParameterValue("Classes_Name", commonRprtData.ClassName);
                        cryRpt.SetParameterValue("Classes_Sub_Name", commonRprtData.ClassSubName);
                        cryRpt.SetParameterValue("Classes_Full_Address", commonRprtData.ClassAddress);
                        cryRpt.SetParameterValue("From_Date", commonRprtData.FromDate);
                        cryRpt.SetParameterValue("To_date", commonRprtData.ToDate);
                        cryRpt.SetParameterValue("Logo", commonRprtData.Logo);
                        if (commonRprtData.Std == "%")
                        {
                            commonRprtData.Std = "'%'";
                        }
                        if (commonRprtData.Batch == "%")
                        {
                            commonRprtData.Batch = "'%'";
                        }
                        cryRpt.SetParameterValue("Std_Id", commonRprtData.Std);
                        cryRpt.SetParameterValue("Batch_Id", commonRprtData.Batch);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        ClassManager.Common.Log.LogError(connectionString.DataSource, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.InitialCatalog, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.UserID, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.Password, Common.ErrorLevel.INFORMATION);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "TimeTable\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\TimeTable.pdf";

                        break;


                    case Info.Reports.EXAM_WISE_REPORT:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\EXAM_WISE_REPORT.rpt");
                        commonRprtData = reportData as CommonReportData;
                        cryRpt.SetParameterValue("Class_Name", commonRprtData.ClassName);
                        cryRpt.SetParameterValue("Class_Adress", commonRprtData.ClassAddress);
                        cryRpt.SetParameterValue("FromDate", commonRprtData.FromDate);
                        cryRpt.SetParameterValue("ToDate", commonRprtData.ToDate);
                        cryRpt.SetParameterValue("Logo", commonRprtData.Logo);
                        cryRpt.SetParameterValue("Name", commonRprtData.Name);
                        cryRpt.SetParameterValue("AdmissionNo", commonRprtData.Roll);
                        cryRpt.SetParameterValue("Std", commonRprtData.Std);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        ClassManager.Common.Log.LogError(connectionString.DataSource, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.InitialCatalog, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.UserID, Common.ErrorLevel.INFORMATION);
                        ClassManager.Common.Log.LogError(connectionString.Password, Common.ErrorLevel.INFORMATION);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "ExamwiseReport\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\ExamwiseReport-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";

                        break;



                    case Info.Reports.SUB_WISE_REPORT:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\SUB_WISE_REPORT.rpt");
                        commonRprtData = reportData as CommonReportData;
                        cryRpt.SetParameterValue("Class_Name", commonRprtData.ClassName);
                        cryRpt.SetParameterValue("Class_Adress", commonRprtData.ClassAddress);
                        cryRpt.SetParameterValue("FromDate", commonRprtData.FromDate);
                        cryRpt.SetParameterValue("ToDate", commonRprtData.ToDate);
                        cryRpt.SetParameterValue("Logo", commonRprtData.Logo);
                        cryRpt.SetParameterValue("Name", commonRprtData.Name);
                        cryRpt.SetParameterValue("AdmissionNo", commonRprtData.Roll);
                        cryRpt.SetParameterValue("Std", commonRprtData.Std);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "SubwiseReport\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\SubwiseReport-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";

                        break;


                    case Info.Reports.FEE_RECEIPT_PRO_REL:
                        cryRpt = new ReportDocument();
                        cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + "WinApp\\Reports\\FEE_RECEIPT_PRO_REL.rpt");
                        feeRprtData = reportData as FeeReceiptReportData;
                        paymentDate = Convert.ToDateTime(feeRprtData.PaymentDate);
                        paymentMonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), (paymentDate.Month).ToString());
                        cryRpt.SetParameterValue("txtServiceTaxNo", feeRprtData.ServiceTaxNo);
                        cryRpt.SetParameterValue("txtRupeesInWord", feeRprtData.RupeesInWord);
                        cryRpt.SetParameterValue("TRANS_ID", feeRprtData.TransactionId);
                        cryRpt.SetParameterValue("admision_no", feeRprtData.AdmsnNo);
                        cryRpt.SetParameterValue("txtOutstandingAmount", feeRprtData.OutstandingAmount);
                        cryRpt.SetParameterValue("Classes_Full_Address", feeRprtData.ClassAddress);
                        cryRpt.SetParameterValue("Owner", feeRprtData.OwnerNo);
                        cryRpt.SetParameterValue("ClsCntct", feeRprtData.clasContct);
                        cryRpt.SetParameterValue("Email", feeRprtData.Email);
                        cryRpt.SetParameterValue("MainAdd", feeRprtData.MainAdd);
                        cryRpt.SetParameterValue("Classes_Note", feeRprtData.ClassNote);
                        cryRpt.SetParameterValue("Studnt_photo", feeRprtData.stud_photo);
                        cryRpt.DataSourceConnections[0].SetConnection(connectionString.DataSource, connectionString.InitialCatalog, connectionString.UserID, connectionString.Password);
                        DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\Receipt\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + "\\Receipt-" + feeRprtData.ReceiptNo.Replace(@"/", "") + "-" + feeRprtData.StudentName + "-" + feeRprtData.AdmsnNo + ".pdf";
                        break;
                    default: throw new Exception("Invalid report name");
                }

                saveFileDialog.FileName = printConfig.exportFileName + ".pdf";
                saveFileDialog.Filter = "Portable Doc Format|*.pdf";

                //Export report

                if (DocumentFolder == null || DocumentFolder.Equals("") == true)
                {
                    DocumentFolder = Info.SysParam.getValue<String>(SysParam.Parameters.DOCUMENT_PATH) + "\\General\\" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + report + ".pdf";
                }

                try
                {
                    new FileInfo(DocumentFolder).Directory.Create();

                }
                catch (Exception ex)
                {
                    DocumentFolder = AppDomain.CurrentDomain.BaseDirectory + "Prints\\" + (DateTime.Now.ToShortDateString().Replace(@"/", ""))+ (DateTime.Now.ToShortTimeString().Replace(@"/", "").Replace(@":", "")) + report + ".pdf";
                    new FileInfo(DocumentFolder).Directory.Create();

                }

                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, DocumentFolder);

                crystlRprtViewer.ReportSource = cryRpt;
                crystlRprtViewer.Refresh();

                feeRprtData.attachments = new List<string>();
                if (printConfig.PrintReport)
                {
                    cryRpt.PrintToPrinter(1, false, 0, 0);
                }

                if (printConfig.sendEmail)
                {
                    Common.Log.LogError(" sendMail Start", Common.ErrorLevel.INFORMATION);
                    feeRprtData.attachments.Add(DocumentFolder);
                    Common.Log.LogError("sendmail complete", Common.ErrorLevel.INFORMATION);
                }

                if (printConfig.SaveReport)
                {
                    Common.Log.LogError("savereport start", Common.ErrorLevel.INFORMATION);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(DocumentFolder, saveFileDialog.FileName, true);
                    }
                    Common.Log.LogError("savereport complete", Common.ErrorLevel.INFORMATION);
                }

                if (printConfig.ViewReport)
                {
                    Common.Log.LogError("viewreport start", Common.ErrorLevel.INFORMATION);
                    this.Visible = true;
                    Common.Log.LogError("viewreport complete", Common.ErrorLevel.INFORMATION);
                }

            }


            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);


                if (ex.Message.Equals("Load report failed.") || ex.InnerException.Equals("The Report Application Server failed"))
                {
                    UICommon.WinForm.showStatus("Crystal Report is not install or Target Directory doesn't contains the Report.", "ViewReport", this);
                }
                else
                {
                    String innerMessage = (ex.InnerException != null)
                        ? ex.InnerException.Message
                        : "";
                    throw ex;
                }
            }
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
