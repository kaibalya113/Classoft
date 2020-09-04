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
using System.Data.SqlClient;
using ClassManager.WinApp.UICommon;
namespace ClassManager.WinApp
{
    public partial class FrmAttendanceLog : FrmParentForm
    {
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        DataTable attendenceLogData;
        public const string sCaption = "Import Attendence Log";
       

        public FrmAttendanceLog()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {                
                ofdLogFile.Filter = "Text files (*.TXT)|*.TXT|CSV File (*.CSV)|*.CSV"; ; 
                ofdLogFile.ShowDialog();
                txtFilePath.Text = ofdLogFile.FileName;
            }
            catch (Exception ex)
            {                
                   UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                attendenceLogData = AttendanceHandler.readLog(txtFilePath.Text,Program.LoggedInUser.BranchId);

                ADGVAttendanceLog.DataSource = attendenceLogData;
                foreach (DataGridViewRow adrow in ADGVAttendanceLog.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVAttendanceLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
                    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (AttendanceHandler.uploadAttendenceLog(attendenceLogData) == true)
                {
                    AttendanceHandler.prepareAttendeceFromLog(dtpFromdate.Value, dtpToDate.Value, branchID);
                }

                UICommon.WinForm.showStatus("Data Imported Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
            
        }

        private void FrmAttendanceLog_Load(object sender, EventArgs e)
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpFromdate);
                UICommon.WinForm.formatDateTimePicker(dtpToDate);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void ADGVAttendanceLog_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVAttendanceLog,e);
        }
    }
}
