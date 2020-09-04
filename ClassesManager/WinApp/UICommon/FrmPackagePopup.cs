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
using ClassManager.Info;

namespace ClassManager.WinApp
{
    public partial class FrmPackagePopup : FrmParentForm
    {

        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Student Details";
        static Info.Student objStudent;
        static List<Info.InstallmentDetail> lstStudentInstallment;
        List<InstallmentDetail> lstInstallmentDetails { get; set; }
        public FrmPackagePopup()
        {
            InitializeComponent();
        }

        private void FrmPackagePopup_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetData(Student objStudent)
        {
            try
            {
                ADGVInstDetails.DataSource = BLL.StudentHandller.getFacility(objStudent.AdmissionNo);
                ADGVInstDetails.ReadOnly = true;
                objStudent.Fees = BLL.FeesHandller.getFeesDetails(objStudent.AdmissionNo);

                formatFacilityGrid();

                lblcancelAmt.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(inst => inst.CancelledAmount));
                lbldiscount.Text = Common.Formatter.FormatCurrency(objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount));
                lblTotalFees.Text = Common.Formatter.FormatCurrency(objStudent.Fees.TotalFees);
                lbltotlPaid.Text = Common.Formatter.FormatCurrency(objStudent.Fees.FeesPaid);
                LblPending.Text = Common.Formatter.FormatCurrency((objStudent.Fees.Installments.Sum(ttl => ttl.InstAmount) - objStudent.Fees.Installments.Sum(paid => paid.AmntPaid) - objStudent.Fees.Installments.Sum(dscnt => dscnt.Discount) - objStudent.Fees.Installments.Sum(ins => ins.CancelledAmount)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private void formatFacilityGrid()
        {
            try
            {
                ADGVInstDetails.ReadOnly = true;
                //Hiding Columns.Mohan(2-Dec-2017).
                ADGVInstDetails.Columns["Auto Renew"].Visible = false;
                ADGVInstDetails.Columns["StudFacilityID"].Visible = false;
                ADGVInstDetails.Columns["StreamID"].Visible = false;
                ADGVInstDetails.Columns["Main Package"].Visible = false;
                string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                if (name == "Gym" || name == "Dance")
                {
                    ADGVInstDetails.Columns["From Date"].Visible = true;
                    ADGVInstDetails.Columns["To Date"].HeaderText = "To Date";
                    ADGVInstDetails.Columns["From Date"].ReadOnly = true;
                    ADGVInstDetails.Columns["To Date"].ReadOnly = true;
                    ADGVInstDetails.Columns[1].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                    ADGVInstDetails.Columns[2].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                }
                else
                {
                    ADGVInstDetails.Columns["From Date"].Visible = false;
                    ADGVInstDetails.Columns["To Date"].HeaderText = "Date";
                    ADGVInstDetails.Columns["To Date"].ReadOnly = true;
                    ADGVInstDetails.Columns[2].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                }

                if (ADGVInstDetails.Columns.Contains("Fees"))
                {
                    ADGVInstDetails.Columns["Fees"].HeaderText = "Total Amount";
                    ADGVInstDetails.Columns["Fees"].ReadOnly = true;
                }
                if (ADGVInstDetails.Columns.Contains("Amount_Paid"))
                {
                    ADGVInstDetails.Columns["Amount_Paid"].HeaderText = "Paid Amount";
                    ADGVInstDetails.Columns["Amount_Paid"].ReadOnly = true;
                }
                // ADGVInstDetails.Columns[2].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                //  ADGVInstDetails.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                //Mohan(2-Dec-2017).
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                //  ADGVInstDetails.ReadOnly = true;
                ADGVInstDetails.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lblTotalFees_Click(object sender, EventArgs e)
        {

        }
    }
}
