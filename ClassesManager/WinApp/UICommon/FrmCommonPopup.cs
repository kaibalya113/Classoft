using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.Info;

namespace ClassManager.WinApp
{
    public partial class FrmCommonPopup : FrmParentForm
    {
   
        private static FrmCommonPopup myInstance;

        public object dtData;

        public FrmCommonPopup()
        {
            InitializeComponent();
        }

        private void CommonPopup_Load(object sender, EventArgs e)
        {
            try
            {
                WinForm.AssignFilterEvent(ADGVCommonPopup);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, null, this);
            }
        }


        internal static FrmCommonPopup getInstance()
        {
            if (myInstance == null)
            {
                myInstance = new FrmCommonPopup();
            }
            return myInstance;
        }


        public void ViewIns(List<InstallmentDetail> lstInstallment)
        {
            try
            {
                this.Text = "Installments";
                ADGVCommonPopup.DataSource = lstInstallment;
                formatGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Assigns data and display to user
        /// </summary>
        public void showPopup()
        {
            try
            {
                ADGVCommonPopup.DataSource = null;
                ADGVCommonPopup.DataSource = dtData;
                formatGrid();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void formatGrid()
        {
            try
            {
                //Changing Date Format
                ADGVCommonPopup.Columns["InstDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVCommonPopup.Columns["PaymentDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                //Hiding columns
                ADGVCommonPopup.Columns["Id"].Visible = false;
                ADGVCommonPopup.Columns["InstMonth"].Visible = false;
                ADGVCommonPopup.Columns["InstNo"].Visible = false;
                //ADGVCommonPopup.Columns["Discount"].Visible = false;
                ADGVCommonPopup.Columns["TodaysDue"].Visible = false;
                ADGVCommonPopup.Columns["CancelledAmount"].Visible = false;
                ADGVCommonPopup.Columns["Fees"].Visible = false;
                ADGVCommonPopup.Columns["Facility"].Visible = false;

                //Ordeing column positions
                //ADGVCommonPopup.Columns["InstDate"].DisplayIndex =
                ADGVCommonPopup.Columns["InstAmount"].DisplayIndex = 4;
                ADGVCommonPopup.Columns["AmntPaid"].DisplayIndex = 5;
                ADGVCommonPopup.Columns["Discount"].DisplayIndex = 6;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVCommonPopup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
               //ADGVCommonPopup.Columns["InstDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                foreach (DataGridViewRow adrow in ADGVCommonPopup.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

               ADGVCommonPopup.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVCommonPopup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVCommonPopup, e);
        }

        public void bindData(DataTable dt)
        {
            try
            {
                this.Text = "All FollowUps";

                string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                if (name == "Gym")
                {
                    ADGVCommonPopup.DataSource = dt;
                    ADGVCommonPopup.Columns["Remark"].Visible = true;
                   // ADGVCommonPopup.Columns["Field"].Visible = false;
                   // ADGVCommonPopup.Columns["Subjects"].Visible = false;

                    ADGVCommonPopup.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                }
                else
                {
                   
                    ADGVCommonPopup.DataSource = dt;
                    ADGVCommonPopup.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Attendance Changes.Mohan(15-July-2017).
        public void dispAttendanceStudent(string streamid, string stdid, string batchid, DateTime value, string type)
        {
            this.Text = "Attendance";
            btnSave.Visible = true;

            DataGridViewCheckBoxColumn chkPresent = new DataGridViewCheckBoxColumn();
            chkPresent.Name = "chkPresent";
            chkPresent.HeaderText = "Status";
            chkPresent.TrueValue = true;
            chkPresent.FalseValue = false;
            chkPresent.ReadOnly = true;
            chkPresent.Selected = false;
            ADGVCommonPopup.Columns.Insert(0, chkPresent);


            DataGridViewCheckBoxColumn chkHW = new DataGridViewCheckBoxColumn();
            chkHW.Name = "chkHW";
            chkHW.HeaderText = "Homework";
            chkHW.TrueValue = true;
            chkHW.FalseValue = false;
            chkHW.ReadOnly = false;
            chkHW.Selected = false;
            ADGVCommonPopup.Columns.Insert(1, chkHW);


            ADGVCommonPopup.DataSource = BLL.AttendanceHandler.getAttendanceStatus(streamid, stdid, batchid, value, value, Program.LoggedInUser.BranchId.ToString(), "%", type, 0);

            formatGridWhenopenforAttendance(type);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void ADGVCommonPopup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.Text == "Attendance" && btnSave.Visible==true)
                {
                    if (e.RowIndex != -1)
                    {
                        if (FrmAttendanceSheet.isAutomaticBio == false)
                        {
                            string newValue;

                            if (e.ColumnIndex == 0)
                            {

                                DataGridViewCheckBoxCell dgvChckbx = (DataGridViewCheckBoxCell)ADGVCommonPopup.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                dgvChckbx.Value = (Convert.ToBoolean(dgvChckbx.Value));

                                dgvChckbx.TrueValue = true;
                                dgvChckbx.FalseValue = false;
                                bool present = Convert.ToBoolean(dgvChckbx.Selected);

                                if ((Boolean)dgvChckbx.Value == true)
                                {
                                    dgvChckbx.Value = true;
                                    newValue = "P";
                                    ADGVCommonPopup.Rows[e.RowIndex].Cells[6].Value = newValue;

                                }
                                else
                                {
                                    dgvChckbx.Value = false;
                                    newValue = "A";
                                    // ADGVAttendanceSheet.Rows[e.RowIndex].Cells[(chbFaculty.Checked) ? 6 : 6].Value = newValue;
                                    ADGVCommonPopup.Rows[e.RowIndex].Cells[6].Value = newValue;
                                }


                                DataGridViewCheckBoxCell dgvChckbxvalue = (DataGridViewCheckBoxCell)ADGVCommonPopup.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                dgvChckbx.Value = !(Convert.ToBoolean(dgvChckbx.Value));

                                dgvChckbx.TrueValue = true;
                                dgvChckbx.FalseValue = false;

                            }
                        }
                        else
                        {
                            if (e.ColumnIndex == 0)
                            {
                                UICommon.WinForm.showStatus("Can not mark attendence manually", MessageBoxButtons.OK, MessageBoxIcon.Information, "Attendance", this);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, "Attendance", this);
            }
        }

        //Formatting grid when open for attendance.Mohan(16-July-2017) Lappy Time 12:01 AM
        private void formatGridWhenopenforAttendance(string type)
        {
            if (type == "S")
            {
                ADGVCommonPopup.Columns["STRM_NAME"].Visible = false;
                ADGVCommonPopup.Columns["STD_NAME"].Visible = false;
                ADGVCommonPopup.Columns["STRM_ID"].Visible = false;

                ADGVCommonPopup.Columns["BTCH_NAME"].Visible = false;
                ADGVCommonPopup.Columns["btch_id"].Visible = false;
                ADGVCommonPopup.Columns["STMT_FATHER_CONTACT"].Visible = false;
                ADGVCommonPopup.Columns["STD_ID"].Visible = false;
                ADGVCommonPopup.Columns["ATTD_REMARK"].Visible = false;


                //Ordering Columns.
                ADGVCommonPopup.Columns["ATTD_DATE"].DisplayIndex = 2;
                ADGVCommonPopup.Columns["Name"].DisplayIndex = 3;
                ADGVCommonPopup.Columns["ATTD_IN_TIME"].DisplayIndex = 4;
                ADGVCommonPopup.Columns["ATTD_OUT_TIME"].DisplayIndex = 5;
                ADGVCommonPopup.Columns["Total"].DisplayIndex = 6;
            }


            else
            {
                //Making it False, So that Portion Taught can be descripted.Mohan(27-July-2017).
                ADGVCommonPopup.ReadOnly = false;

                //Other Columns Should not be editable.Mohan(27-July-2017).
                ADGVCommonPopup.Columns["ATTD_DATE"].ReadOnly = true;
                ADGVCommonPopup.Columns["ATTD_IN_TIME"].ReadOnly = true;
                ADGVCommonPopup.Columns["ATTD_OUT_TIME"].ReadOnly = true;
                ADGVCommonPopup.Columns["Total"].ReadOnly = true;
                ADGVCommonPopup.Columns["ATTD_STATUS"].ReadOnly = true;
                ADGVCommonPopup.Columns["FCLT_CONTACT_NO"].ReadOnly = true;
                ADGVCommonPopup.Columns["Name"].ReadOnly = true;

                ADGVCommonPopup.Columns["FCLT_CONTACT_NO"].HeaderText = "ContactNo";
                ADGVCommonPopup.Columns["chkHW"].Visible = false;
                ADGVCommonPopup.Columns["ATTD_REMARK"].HeaderText = "Remark";
               

                //Ordering Columns.
                ADGVCommonPopup.Columns["chkPresent"].DisplayIndex = 0;

                ADGVCommonPopup.Columns["ATTD_DATE"].DisplayIndex = 1;

                ADGVCommonPopup.Columns["Name"].DisplayIndex = 2;

                ADGVCommonPopup.Columns["FCLT_CONTACT_NO"].DisplayIndex = 3;

                ADGVCommonPopup.Columns["ATTD_IN_TIME"].DisplayIndex = 4;
                ADGVCommonPopup.Columns["ATTD_OUT_TIME"].DisplayIndex = 5;
                ADGVCommonPopup.Columns["Total"].DisplayIndex = 6;
                //ADGVCommonPopup.Columns["txtRemark"].DisplayIndex = 7;
            }
            //Hiding Columns
            ADGVCommonPopup.Columns["ATTD_ID"].Visible = false;
            ADGVCommonPopup.Columns["ATTD_IS_HOLIDAY"].Visible = false;
            ADGVCommonPopup.Columns["ATTD_ADMISSION_NO"].Visible = false;
          
            //Changing DateFormat.
            ADGVCommonPopup.Columns["ATTD_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            ADGVCommonPopup.Columns["ATTD_IN_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;
            ADGVCommonPopup.Columns["ATTD_OUT_TIME"].DefaultCellStyle = UICommon.WinForm.GridTimeFormat;

            //Changing HeaderText.
            ADGVCommonPopup.Columns["ATTD_IN_TIME"].HeaderText = "InTime";
            ADGVCommonPopup.Columns["ATTD_OUT_TIME"].HeaderText = "OutTime";
            ADGVCommonPopup.Columns["ATTD_DATE"].HeaderText = "Date";
            ADGVCommonPopup.Columns["ATTD_STATUS"].HeaderText = "Attendance";
            
          
        }
    }
}
