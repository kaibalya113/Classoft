using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info.Reporting;
using ClassManager.BLL;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp.Reports
{
    public partial class PrintConfig : FrmParentForm
    {
        public static PrintConfig myInstance;
        public string reportName;
        public IReportData reportData;
        public string fileName;
        public string sCaption = "Print Receipt";

        //variable declared to identify whether the receipt is reprinted or not.
        bool isDuplicate;

        public PrintConfig()
        {
            InitializeComponent();
        }
        
        public static void viewDialog(IReportData reportData, string reportName, string fileName, bool isReprint = false)
        {
            myInstance = new PrintConfig();

            myInstance.cmbFormat.Items.Add(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            myInstance.cmbFormat.Items.Add(CrystalDecisions.Shared.ExportFormatType.CharacterSeparatedValues);
            myInstance.cmbFormat.Items.Add(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook);
            myInstance.cmbFormat.Items.Add(CrystalDecisions.Shared.ExportFormatType.WordForWindows);

            myInstance.cmbRprtTYpe.Items.Clear();


            String[] ReceiptTypes = Info.SysParam.getValue<String>(Info.SysParam.Parameters.FEE_RECEIPT_TYPE).Split(',');

            if (reportName == "FEE_RECEIPT_PRO")
            {
                foreach (String receipTtype in ReceiptTypes)
                {
                    myInstance.cmbRprtTYpe.Items.Add(receipTtype);
                }
            }
            else
            {
                myInstance.cmbRprtTYpe.Items.Add(reportName);
            }

            if (isReprint == true)
            {
              
                myInstance.chkSendMail.Checked = false;
                myInstance.chkSendSms.Checked = false;
                myInstance.isDuplicate = true;
                myInstance.fileName = fileName;
                myInstance.chkView.Checked = true;
                myInstance.reportData = reportData;
                myInstance.cmbFormat.SelectedIndex = 0;
                myInstance.cmbRprtTYpe.SelectedIndex = 0;
                myInstance.btnOk.Focus();
                myInstance.ShowDialog();
            }
            else
            {
                myInstance.fileName = fileName;
                myInstance.chkView.Checked = true;
                myInstance.chkSendSms.Checked = false;
                myInstance.chkSendMail.Checked = true;
                myInstance.reportData = reportData;
                myInstance.cmbFormat.SelectedIndex = 0;
                myInstance.cmbRprtTYpe.SelectedIndex = 0;
                myInstance.btnOk.Focus();
                myInstance.ShowDialog();
            }

          
          
        }
        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSave.Checked)
            {
                cmbFormat.Enabled = true;
            }
            else
            {
                cmbFormat.Enabled = false;
            }
        }

     

        private void bgwFeesSms_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                FeeReceiptReportData objFeeReceiptdata = (FeeReceiptReportData)e.Argument;
                MailHandler.sendFeesPayment(objFeeReceiptdata, chkSendSms.Checked, chkSendMail.Checked,Program.LoggedInUser.BranchName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bgwFeesSms_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UICommon.FormFactory.setMainFormStatus(e.Error.Message);
            }
            else
            {
                UICommon.FormFactory.setMainFormStatus("Message Sent Successfully");
            }
            //if (e.Cancelled==false)
            //{
            //    UICommon.FormFactory.setMainFormStatus("Message not sent");
            //}

            this.Visible = false;
            this.Close();
        }

       

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                PrintingConfig objPrintngConfig = new PrintingConfig();
                objPrintngConfig.exportFormat = (cmbFormat.Text.Equals(string.Empty)) ? CrystalDecisions.Shared.ExportFormatType.PortableDocFormat : (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), cmbFormat.Text);
                objPrintngConfig.PrintReport = chkPrint.Checked;
                objPrintngConfig.reportType = cmbRprtTYpe.Text;
                objPrintngConfig.SaveReport = chkSave.Checked;
                objPrintngConfig.ViewReport = chkView.Checked;
                objPrintngConfig.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), cmbRprtTYpe.Text);
                objPrintngConfig.exportFileName = myInstance.fileName;
                objPrintngConfig.sendSMS = chkSendSms.Checked;
                objPrintngConfig.sendEmail = chkSendMail.Checked;

                
                FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
                frmRprtViewer.viewReport(objPrintngConfig.ReportName, reportData, objPrintngConfig, isDuplicate);
                FeeReceiptReportData objFeeReportData = reportData as FeeReceiptReportData;
                UICommon.FormFactory.setMainFormStatus("Sending Feespayment Message");
                bgwFeesSms.RunWorkerAsync(objFeeReportData);

                this.Close();


            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void PrintConfig_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void cmbRprtTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
