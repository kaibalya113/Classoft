using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmViewDeleteFacilities : FrmParentForm
    {
        string sCaption = "View Deleted Facilities";
        string branch = Program.LoggedInUser.BranchId.ToString();
        public FrmViewDeleteFacilities()
        {
            InitializeComponent();
        }

        private void FrmViewDeleteFacilities_Load(object sender, EventArgs e)
        {
             try
            {
                ADGVDeletePack.ReadOnly = true;
                   DataTable dt = BLL.PackageInstHandller.getDeleteFacility(branch);
                ADGVDeletePack.DataSource = dt;
                if (ADGVDeletePack.Rows.Count > 0)
                { lblCnclFees.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([CancelledFee])", ""))); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVDeletePack_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ADGVDeletePack.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            foreach (DataGridViewRow adrow in ADGVDeletePack.Rows)
            {

                adrow.Height = 30;
                adrow.MinimumHeight = 30;

            }

            ADGVDeletePack.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
               
                PdfParameters getParameter = new PdfParameters();


                getParameter.count = "Total Cancelled Amount:- " + lblCnclFees.Text;
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Deleted Packages Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ADGVDeletePack.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Deleted Packages Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(ADGVDeletePack, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }

                }
                else
                {
                    WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        
    }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (ADGVDeletePack.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVDeletePack, null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
