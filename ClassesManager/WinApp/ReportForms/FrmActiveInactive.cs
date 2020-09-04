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
    public partial class FrmActiveInactive : FrmParentForm
    {
        private static FrmExpiredRenewal myInstance;
        string sCaption = "ActiveInActive";
        DataTable renew;
        string ReportFolder;
        public FrmActiveInactive()
        {
            InitializeComponent();
        }

        private void FrmActiveInactive_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsMdiChild != true)
                {
                }
                else
                {
                    UICommon.WinForm.setDatea(dtpAttdFromDate, dtpAttdToDate);
                    formatForm();
                    WinForm.AssignFilterEvent(grid);
                    onLoadRenew();
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(this.btnSaveToExcel, "Save To Excel");
                    txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                 

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static FrmExpiredRenewal getInstance()
        {
            try
            {
                if(myInstance == null)
            {
                    myInstance = new FrmExpiredRenewal();
                }
                return myInstance;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void formatForm()
        {
            try
            {
                //UICommon.WinForm.formatDateTimePicker(dtpAttdFromDate, Common.Formatter.DateFormat);
                //UICommon.WinForm.formatDateTimePicker(dtpAttdToDate, Common.Formatter.DateFormat);
               //dtpAttdFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
               // dtpAttdToDate.Value = DateTime.Now;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void onLoadRenew()
        {
            try
            {

                cmbFilterBy.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formatDateColumn(DataGridViewColumn column)
        {
            try
            {
                if (grid.Columns.Contains(column))
                {
                    grid.Columns[column.Name].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmbFilterBy.SelectedIndex)
                {
                    case 0:
                       // UICommon.WinForm.setDateforactive(dtpAttdFromDate, dtpAttdToDate);
                      // DateTime dt=new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+15);
                       // dtpAttdToDate.Value = dt;
                        //to.Value = from.Value.AddMonths(1).AddDays(-1);
                        //dtpAttdFromDate.Value = DateTime.Now;
                        renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);

                        bindData(renew, 0);
                        break;

                    case 1:
                        renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);

                        bindData(renew, 1);
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void bindData(DataTable dt, int index)
        {
            try
            {
                grid.DataSource = dt;
                if (index != 2)
                    if(grid.Columns.Contains("Count"))
                    {
                     grid.Columns["Count"].HeaderText = "Present Days";
                    }
                   
                {
                    grid.Columns["packageId"].Visible = false;
                    formatDateColumn(grid.Columns["RenewalDate"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            try
            {
               if (grid.Rows.Count != 0)
                    {
                        Common.ImportExport.ImportToExcel(grid, null);
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

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = grid.DataSource;
                bs.Filter = grid.Columns["Name"].HeaderText.ToString() + " LIKE '%" + txtFname.Text + "%'";
                grid.DataSource = bs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in grid.Rows)
                {
                    DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)dr.Cells[0];
                    chckBx.Value = chkSelectAll.Checked;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (grid.Columns.Contains("AbsentDays"))
                {
                    grid.Columns["AbsentDays"].HeaderText="Present Days";
                }
                formatDateColumn(grid.Columns["Date"]);
                formatDateColumn(grid.Columns["AdmissionDate"]);
                formatDateColumn(grid.Columns["ExpiredOn"]);
               
                if (grid.Columns.Contains("Id"))
                {
                    grid.Columns["Id"].Visible = false;
                }
                if (grid.Columns.Contains("AdmissionNo"))
                {
                    grid.Columns["AdmissionNo"].Visible = false;
                }
                if (grid.Columns.Contains("Admission"))
                {
                    grid.Columns["Admission"].HeaderText = Lang.translate("AdmissionNo");
                }
                grid.Columns["Name"].Width = 150;
                if (grid.Columns.Contains("Package"))
                {
                    grid.Columns["Package"].Width = 120;
                }
                foreach (DataGridViewRow adrow in grid.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(grid, e);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpAttdFromDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if (validateDates())
                {
                    FillGrid();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void FillGrid()
        {
            try
            {
                if (cmbFilterBy.SelectedIndex == 0)
                {
                    renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                   
                    bindData(renew, 0);
                }
                if (cmbFilterBy.SelectedIndex == 1)
                {
                    renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                   
                    bindData(renew, 1);
                }
              
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool validateDates()
        {
            try
            {
                if (dtpAttdToDate.Value < dtpAttdFromDate.Value)
                {
                    WinForm.showStatus("Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    formateLastTabDates();
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
        private void formateLastTabDates()
        {
            try
            {
                WinForm.formatDateTimePicker(dtpAttdFromDate);
                WinForm.formatDateTimePicker(dtpAttdToDate);
                WinForm.setDate(dtpAttdFromDate, dtpAttdToDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpAttdToDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if (validateDates())
                {
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                        renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                      
                        bindData(renew, 0);
                    }
                    if (cmbFilterBy.SelectedIndex == 1)
                    {
                        renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                       
                        bindData(renew, 1);
                    }
                    if (cmbFilterBy.SelectedIndex == 2)
                    {
                        renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 3, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        grid.Columns["chkSMS"].Visible = false;
                        bindData(renew, 2);
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtpAttdFromDate_ValueChanged(object sender, EventArgs e)
        {
            if(dtpAttdFromDate.Value>dtpAttdToDate.Value)
            {
                dtpAttdToDate = dtpAttdFromDate;
            }
        }
        //added by ashvini on 30-03-2019

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            if(cmbFilterBy.SelectedIndex==0)
            
                try
                {
                    renew = BLL.FeesHandller.getActiveExpiredMembers(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);

                    bindData(renew, 0);
                    grid.DataSource = renew;
                    PdfParameters getParameter = new PdfParameters();
                    getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpAttdFromDate.Value);
                    getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpAttdToDate.Value);
                    getParameter.View = "Filter By:- " + cmbFilterBy.SelectedIndex.ToString();
                    getParameter.Footer = "Printed On:-" + DateTime.Now;
                    getParameter.Title = "Inactive Members Report";
                    getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                    getParameter.name = "Enter Name:-" + txtFname.Text;
                    //added by ashvini 4-12-17
                    //in these method get path for saving pdf
                    if (grid.Rows.Count != 0)

                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pathTosave = folderDlg.SelectedPath + "\\Inactive Members Report.PDF";
                            Environment.SpecialFolder root = folderDlg.RootFolder;
                            //added by ashvini 4-12-17
                            //these method is used to get parameters with value and pass them to common 
                            Common.ImportExport.ImportToPDF(grid, pathTosave, getParameter);
                            UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                        }
                    }
                }

                catch (Exception ex)
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }
    //added by ashvini on 30-03-2019
}

