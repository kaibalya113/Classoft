using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmHolidayMaster : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Holiday";
        public FrmHolidayMaster()
        {
            InitializeComponent();
        }

        public bool validate()
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Enter Holiday Name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtName.Text = "";
                    txtName.Focus();
                    return false;
                }
                else if (dtpfrmDate.Value > dtpToDte.Value)
                {
                    UICommon.WinForm.showStatus("Please Select Proper Date. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtpfrmDate.Focus();
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
       // private void btnSave_Click(object sender, EventArgs e)
      //  {

        //    try
        //    {

        //        if (validate())
        //        {
        //            Info.Holiday objHoldy = new Info.Holiday();

        //            objHoldy.Name = txtName.Text;
        //            objHoldy.Fromdate = dtpfrmDate.Value;
        //            objHoldy.Todate = dtpToDte.Value;
        //            BLL.HolidayHandler.createHoliday(objHoldy, Program.LoggedInUser.BranchId);
        //            clear();

        //            UICommon.WinForm.showStatus("Holiday Created Successfuly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            ADGVHoliday.DataSource = BLL.HolidayHandler.getHolidays(branchId);

        //        }
        //        //else
        //        //{
        //        //    UICommon.WinForm.showStatus("Something went wrong, please contact support.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        //}
        //    }

        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Equals("Can not create holiday with same name and same date"))
        //        {
        //            UICommon.WinForm.showStatus("Can not create holiday with same name and same date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            return;
        //        }

        //        else
        //        {
        //            UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //        }
        //    }
        //}
        public void clear()
        {
            txtName.Text = "";
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
        }

        private void HolidayMaster_Load(object sender, EventArgs e)
        {try
            {
                //Formatting DatetimePicker
                UICommon.WinForm.formatDateTimePicker(dtpfrmDate);
                UICommon.WinForm.formatDateTimePicker(dtpToDte);

                ADGVHoliday.DataSource = BLL.HolidayHandler.getHolidays(branchId);
                AssignEvents();
                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
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
                        btnSave.Visible = false;
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



        private void AssignEvents()
        {
            ADGVHoliday.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVHoliday.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        private void ADGVHoliday_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVHoliday,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (validate())
                {
                    Info.Holiday objHoldy = new Info.Holiday();

                    objHoldy.Name = txtName.Text;
                    objHoldy.Fromdate = dtpfrmDate.Value;
                    objHoldy.Todate = dtpToDte.Value;
                    BLL.HolidayHandler.createHoliday(objHoldy, Program.LoggedInUser.BranchId);
                    clear();

                    UICommon.WinForm.showStatus("Holiday Created Successfuly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    ADGVHoliday.DataSource = BLL.HolidayHandler.getHolidays(branchId);

                }
                //else
                //{
                //    UICommon.WinForm.showStatus("Something went wrong, please contact support.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                //}
            }

            catch (Exception ex)
            {
                if (ex.Message.Equals("Record Already Exists from SP s_pr_create_Holiday"))
                {
                    UICommon.WinForm.showStatus("There is already Holiday from " + dtpfrmDate.Value.ToString("dd-MMM-yyyy") + " to " + dtpToDte.Value.ToString("dd-MMM-yyyy"), MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

                else if (ex.Message.Equals("Can not create holiday with same name and same date"))
                {
                    UICommon.WinForm.showStatus("Can not create holiday with same name and same date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return;
                }
                //else if ()
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void formatGrid()
        {
            ADGVHoliday.Columns["HOLM_ID"].Visible = false;
            ADGVHoliday.Columns["HOLM_BRANCH_ID"].Visible = false;
            ADGVHoliday.Columns["HOLM_UPDT_AT"].Visible = false;
            ADGVHoliday.Columns["HOLM_UPDAT_BY"].Visible = false;
            ADGVHoliday.Columns["HOLM_DLTD_AT"].Visible = false;
            ADGVHoliday.Columns["HOLM_DLTD_BY"].Visible = false;
            ADGVHoliday.Columns["HOLM_CRTD_AT"].Visible = false;
            ADGVHoliday.Columns["HOLM_CRTD_BY"].Visible = false;
            ADGVHoliday.Columns["ID"].Visible = false;
            
            ADGVHoliday.Columns["HOLM_NAME"].HeaderText = "Name";
            ADGVHoliday.Columns["HOLM_FROM_DATE"].HeaderText = "From";
            ADGVHoliday.Columns["HOLM_TO_DATE"].HeaderText = "To";

            ADGVHoliday.Columns["HOLM_NAME"].DisplayIndex = 0;
            ADGVHoliday.Columns["HOLM_FROM_DATE"].DisplayIndex = 1;
            ADGVHoliday.Columns["HOLM_TO_DATE"].DisplayIndex = 2;
            
            ADGVHoliday.Columns["HOLM_FROM_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            ADGVHoliday.Columns["HOLM_TO_DATE"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

        }

        private void ADGVHoliday_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            formatGrid();
            foreach (DataGridViewRow adrow in ADGVHoliday.Rows)
            {

                adrow.Height = 30;
                adrow.MinimumHeight = 30;

            }

            ADGVHoliday.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
        }
    }
}
