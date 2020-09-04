//added by ashvini on 08-02-2019 for displaying activity report

using ClassManager.BLL;
using ClassManager.Common;
using ClassManager.WinApp.UICommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassManager.WinApp
{
    public partial class FrmActivityDetails :FrmParentForm
    {
        string sCaption = "Activity Details";
        public static Info.Student objStudent;
        public FrmActivityDetails()
        {
            InitializeComponent();
        }

        private void FrmActivityDetails_Load(object sender, EventArgs e)
       {
            try
            {
             
                // objStudent = StudentHandller.GetStudent(null, null, null, null, Program.LoggedInUser.BranchId);
               
                UICommon.WinForm.setDate(dtpReceiptFrmDate , dtpReceiptToDate);
               
            
                    ActivityGrid.DataSource = BLL.StudentHandller.GetActivitityReport(dtpReceiptFrmDate.Value,dtpReceiptToDate.Value, Program.LoggedInUser.BranchId.ToString());

                    FormatActivityGrid();
                AssignEvents();
                

       
            }






            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void AssignEvents()
        {
          
            ActivityGrid.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ActivityGrid.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        private void formatDTP()
        {
            try
            {
                WinForm.formatDateTimePicker(dtpReceiptFrmDate);
                WinForm.formatDateTimePicker(dtpReceiptToDate
                    
              );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FormatActivityGrid()
        {
        
            try
            {

                ActivityGrid.ReadOnly = true;
                if (ActivityGrid.Columns.Contains("ACT_ADMISSIONNO"))
                {
                    ActivityGrid.Columns["ACT_ADMISSIONNO"].Visible = false;
                    
                }
                if (ActivityGrid.Columns.Contains("ACT_USER"))
                {
                    ActivityGrid.Columns["ACT_USER"].HeaderText = "Name";
                    ActivityGrid.Columns["ACT_USER"].Width = 200;
                    ActivityGrid.Columns["ACT_USER"].DisplayIndex = 1;
                }
                if (ActivityGrid.Columns.Contains("ACT_LOGIN_USER"))
                {
                    ActivityGrid.Columns["ACT_LOGIN_USER"].HeaderText = "Activity By";
                    ActivityGrid.Columns["ACT_LOGIN_USER"].Width = 80;
                    ActivityGrid.Columns["ACT_LOGIN_USER"].DisplayIndex = 2;
                }
                if (ActivityGrid.Columns.Contains("ACT_OLD_VALUE"))
                {
                    ActivityGrid.Columns["ACT_OLD_VALUE"].HeaderText = "Old Value";
                    ActivityGrid.Columns["ACT_OLD_VALUE"].Width = 100;
                    ActivityGrid.Columns["ACT_OLD_VALUE"].DisplayIndex = 3;
                }
                if (ActivityGrid.Columns.Contains("ACT_NEW_VALUE"))
                {
                    ActivityGrid.Columns["ACT_NEW_VALUE"].HeaderText = "New Value";
                    ActivityGrid.Columns["ACT_NEW_VALUE"].Width = 100;
                    ActivityGrid.Columns["ACT_NEW_VALUE"].DisplayIndex = 4;
                }
                if (ActivityGrid.Columns.Contains("ACT_DESC"))
                {
                    ActivityGrid.Columns["ACT_DESC"].HeaderText = "Remark";
                    ActivityGrid.Columns["ACT_DESC"].Width = 250;
                    ActivityGrid.Columns["ACT_DESC"].DisplayIndex = 5;
                }

                ActivityGrid.Columns["ACT_DATE"].HeaderText = "Date";
                ActivityGrid.Columns["ACT_DATE"].DisplayIndex = 0;
              
                ActivityGrid.Columns["ACT_DESC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ActivityGrid.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void ActivityGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActShow_Click(object sender, EventArgs e)
        {
            try
            {
                // objStudent = StudentHandller.GetStudent(null, null, null, null, Program.LoggedInUser.BranchId);
                UICommon.WinForm.setDate(dtpReceiptFrmDate, dtpReceiptToDate);
                if (dtpReceiptFrmDate.Value<=dtpReceiptToDate.Value)
                {
                    ActivityGrid.DataSource = BLL.StudentHandller.GetActivitityReport(dtpReceiptFrmDate.Value, dtpReceiptToDate.Value, Program.LoggedInUser.BranchId.ToString());

                    FormatActivityGrid();
                }

                else
                {
                    UICommon.WinForm.showStatus("FromDate cannot be Greater than Todate", null, null);
                    dtpReceiptFrmDate.Value = dtpReceiptToDate.Value;

                }
            }






            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void dtpReceiptToDate_CloseUp(object sender, EventArgs e)
        {
            UICommon.WinForm.setDate(dtpReceiptFrmDate, dtpReceiptToDate);
            ActivityGrid.DataSource = BLL.StudentHandller.GetActivitityReport(dtpReceiptFrmDate.Value, dtpReceiptToDate.Value, Program.LoggedInUser.BranchId.ToString());

            FormatActivityGrid();
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ActivityGrid.DataSource = BLL.StudentHandller.GetActivitityReport(dtpReceiptFrmDate.Value, dtpReceiptToDate.Value, Program.LoggedInUser.BranchId.ToString());

                FormatActivityGrid();
                PdfParameters getParameter = new PdfParameters();


                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpReceiptFrmDate.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpReceiptToDate.Value);
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Activity Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ActivityGrid.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Activity Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(ActivityGrid, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
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
                ActivityGrid.DataSource = BLL.StudentHandller.GetActivitityReport(dtpReceiptFrmDate.Value, dtpReceiptToDate.Value, Program.LoggedInUser.BranchId.ToString());

                FormatActivityGrid();
                if (ActivityGrid.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ActivityGrid, null);
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

//end by ashvini on 08-02-2019