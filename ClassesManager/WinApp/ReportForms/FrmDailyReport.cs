using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.BLL;
using ClassManager.Info;

namespace ClassManager.WinApp
{
    public partial class FrmDailyReport :FrmParentForm
    {
        Info.DailyReport totalCount;
        string sCaption = "Daily Report ";
        public FrmDailyReport()
        {
            InitializeComponent();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            showDetails();
            //clearForm();
        }

        private void DailyReport_Load(object sender, EventArgs e)
         { try
            {
                clearForm();

                //Formats DateTimePicker.
                formatDTP();

                cmbBranch.DisplayMember = "Name";
                cmbBranch.ValueMember = "BranchID";

                populateBranch();

                //Will set the Start and End Date.
                WinForm.setDate(dtPFromDate, dtpToDate);

                //Display Data
                showDetails();
                if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME) == "Gym")
                {
                    lblExpData.Visible = true;
                    lblTObeExpPckg.Visible =true;
                    lblExpPckg.Visible = true;
                    lblExpired.Visible = true;
                    lblTobeExp.Visible = true;
                    panel6.Visible = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
}
        /// <summary>
        /// Formats DateTimPicker.
        /// </summary>
        private void formatDTP()
        {
            try
            {
                WinForm.formatDateTimePicker(dtPFromDate);
                WinForm.formatDateTimePicker(dtpToDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void populateBranch()
        {
            cmbBranch.Items.Clear();
            
            cmbBranch.Items.Add(new Info.ComboItem("%", "ALL"));
            List<Info.Branch> lstBranch= BLL.BranchHandler.getBranches();
            foreach (Info.Branch branch in lstBranch)
            {
                cmbBranch.Items.Add(new Info.ComboItem(branch.BranchId.ToString(),branch.BranchName));
            }
            cmbBranch.SelectedIndex = 1;
        }

        public void clearForm()
        {
            lblEnq.Text = "0";
            lblReg.Text = "0";
            lblFollwp.Text = "0";
            lblFCollectn.Text = "0";
            lblExpnc.Text = "0";
            lblOtherIncome.Text = "0";
            ttlprsnt.Text = "0";
            ttlAbsnt.Text = "0";
        }
        /// <summary>
        /// Will fetch the data from the Back-End.
        /// </summary>
        private void showDetails()
        {
            try
            {
                Info.DailyReport totalCount = BLL.NotificationHandler.getDailyReport(dtPFromDate.Value, dtpToDate.Value, (((Info.ComboItem)cmbBranch.SelectedItem).strKey));
                lblEnq.Text = totalCount.NoOfEnq.ToString();
                lblReg.Text = totalCount.NoOfReg.ToString();
                lblFollwp.Text = totalCount.NoOfFollwp.ToString();
                lblFCollectn.Text = Common.Formatter.FormatCurrency(totalCount.TotalCollected);
                lblExpnc.Text = Common.Formatter.FormatCurrency(totalCount.TotalExpence);
                lblOtherIncome.Text = Common.Formatter.FormatCurrency(totalCount.OtherIncome);
                ttlprsnt.Text = totalCount.TotalPresents.ToString();
                ttlAbsnt.Text = totalCount.TotalAbsents.ToString();
                byCash.Text = Common.Formatter.FormatCurrency(totalCount.Bycash);
                byCheque.Text = Common.Formatter.FormatCurrency(totalCount.ByCheque);
                lblTobeExp.Text = totalCount.TobeExpiredPackage.ToString();
                lblExpired.Text = totalCount.ExpiredPackage.ToString();
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex,"", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        //private void btnGetReport_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        showDetails();
        //    }
        //    catch (Exception ex)
        //    {
        //            UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }       
        //}

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                showDetails();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Info.DailyReport totalCount = BLL.NotificationHandler.getDailyReport(dtPFromDate.Value, dtpToDate.Value, (((Info.ComboItem)cmbBranch.SelectedItem).strKey));
                BLL.NotificationHandler.sendTotalCountOfToday(totalCount, (((Info.ComboItem)cmbBranch.SelectedItem).name));
             }
            catch (Exception)
            {

                throw;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
