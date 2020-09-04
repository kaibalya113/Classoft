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
using ClassManager.BLL;
using System.Globalization;
using System.IO;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmExpiryReport : FrmParentForm
    {
        private static FrmExpiredRenewal myInstance;
        string sCaption = "ExpiredOrRenewal";
        DataTable renew;
        string ReportFolder;
        public FrmExpiryReport()
        {
            InitializeComponent();
        }

        private void FrmExpiryReport_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsMdiChild != true)
                {
                }
                else
                {
                    WinForm.AssignFilterEvent(grid);
                    formatForm();
                    onLoadRenew();
                    
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(this.btnSendMail, "Send Mail");
                    ToolTip1.SetToolTip(this.BtnSMS, "Send SMS");
                    ToolTip1.SetToolTip(this.btnSaveToExcel, "Save To Excel");
                    txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                    //To get the message from template in text box .
                    txtMarketingMessage.Text = TemplateHandler.getTemplateByType("ARVERTISESMS");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal static FrmExpiredRenewal getInstance()
        {
            if (myInstance == null)
            {
                myInstance = new FrmExpiredRenewal();
            }
            return myInstance;
        }


        public void onLoadRenew()
        {
            try
            {

                cmbFilterBy.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Remove a Column if exists.Mohan(15-July-2017).
        private void removeifexist(DataGridViewColumn column)
        {
            if (grid.Columns.Contains(column))
            {
                grid.Columns.Remove(column);
            }
        }

        //To Format Date of a Column if Exists.Mohan(15-July-2017).
        private void formatDateColumn(DataGridViewColumn column)
        {
            if (grid.Columns.Contains(column))
            {
                grid.Columns[column.Name].DefaultCellStyle.Format = Common.Formatter.DateFormat;
            }
        }
        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpAttdFromDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpAttdToDate, Common.Formatter.DateFormat);
               
                dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                dtpAttdToDate.Value = DateTime.Now;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RenewButton()
        {
            try
            {
                grid.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.calendar,

                    Name = "Renew",
                    HeaderText = "Renew"
                });
                grid.Columns["Renew"].DisplayIndex = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void checkBoxSMS()
        {
            try
            {
                grid.Columns.Clear();
                DataGridViewCheckBoxColumn chkSMS = new DataGridViewCheckBoxColumn();
                chkSMS.Name = "chkSMS";
                chkSMS.HeaderText = "Send";
                chkSMS.TrueValue = true;
                chkSMS.FalseValue = false;
                chkSMS.Selected = false;
                grid.Columns.Insert(0, chkSMS);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void newcolumn()

        {

            checkBoxSMS();

            RenewButton();

            if (cmbFilterBy.SelectedIndex == 0)
            {

                grid.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.deleteBin,

                    Name = "Delete",
                    HeaderText = "Delete"
                });

            }
        }
        //code changed by ashvini for proper filter on 30-03-2019
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                switch (cmbFilterBy.SelectedIndex)
                {
                    case 0:
                        //dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                        //dtpAttdToDate.Value = DateTime.Now;
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0,null,null);
                        newcolumn();
                        bindData(renew, 0);
                        break;
                    case 1:
                        UICommon.WinForm.setDateE(dtpAttdFromDate , dtpAttdToDate);
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        newcolumn();
                        bindData(renew, 1);
                        break;

                    case 2:
                    
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 2,null,null);
                        newcolumn();
                        bindData(renew, 2);
                        grid.Columns["chkSMS"].Visible = true;
                        break;

                    case 3:
                        dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                        dtpAttdToDate.Value = DateTime.Now;
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(),4, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        if (grid.Columns.Contains("chkSMS"))
                        {
                            grid.Columns["chkSMS"].Visible = false;
                        }
                      //  grid.Columns["chkSMS"].Visible = false;
                        bindData(renew, 3);
                        break;
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, "Renewal/Expired", this);
            }
        }
        //end by ashvni on 30-03-2019

        public void bindData(DataTable dt, int index)
        {
            try
            {
                if (grid.Columns.Contains("startdate"))
                {
                    grid.Columns["startdate"].HeaderText = "Start Date";

                }
               
                grid.DataSource = dt;
                if (index == 3)
                {
                    if (grid.Columns.Contains("Count"))
                    {
                        grid.Columns["Count"].HeaderText = "Present Days";
                    }
                    formatDateColumn(grid.Columns["RenewalDate"]);

                }
                if (index != 3)
                {
              if( grid.Columns.Contains("start"))
                    {   grid.Columns["start"].HeaderText = "Start Date";}
                  
                if(grid.Columns.Contains("packageId"))
                    {
                    grid.Columns["packageId"].Visible = false;
                    }
                
                    formatDateColumn(grid.Columns["RenewalDate"]);
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

        private void BtnSMS_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtselectedrow = new DataTable();
                if (cmbFilterBy.SelectedIndex < 3)
                    if (chkSelectAll.Checked)
                    {

                        bgwExpiredPackages.RunWorkerAsync(renew);
                    }
                    else
                    {
                        DataTable dt = ((DataTable)grid.DataSource).Clone();
                        foreach (DataGridViewRow row in grid.Rows)
                        {

                            if (row.Cells[0].Value != null && (Boolean)row.Cells[0].Value == true)
                            {

                                if (cmbFilterBy.SelectedIndex == 0)
                                {
                                    string[] Columns = { "AdmissionNo", "Name", "ContactNo", "Package", "ExpiredOn" };
                                    dt.ImportRow(((DataTable)grid.DataSource).Rows[row.Index]);
                                    dtselectedrow = dt.DefaultView.ToTable(true, Columns);

                                }
                                else if(cmbFilterBy.SelectedIndex==1)
                                {
                                    string[] Columns = { "AdmissionNo", "Name", "ContactNo", "Package", "ExpiredOn" };
                                    dt.ImportRow(((DataTable)grid.DataSource).Rows[row.Index]);
                                    dtselectedrow = dt.DefaultView.ToTable(true, Columns);
                                }
                                else
                                {
                                    string[] Columns = { "AdmissionNo", "Name", "ContactNo", "Package", "RenewalDate","ExpiredOn" };
                                    dt.ImportRow(((DataTable)grid.DataSource).Rows[row.Index]);
                                    dtselectedrow = dt.DefaultView.ToTable(true, Columns);
                                }

                            }

                        }
                        bgwExpiredPackages.RunWorkerAsync(dtselectedrow);
                    }


                if (renew.Rows.Count == 0)
                {

                    UICommon.WinForm.showStatus("No Member Selected to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }

            }
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cmbFilterBy.SelectedIndex;

               
                    if (grid.Rows.Count != 0)
                    {
                        Common.ImportExport.ImportToExcel(grid, null);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                
                //if (index == 1)
                //{
                //    Savelast30ExpExcel();
                //}
                //if (index == 2)
                //{
                //    SaveTobeExpExcel();
                //}
                //if (index == 0)
                //{
                //    SaveExpiredExcel();
                //}
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        public void SaveTobeExpExcel()
        {
            try
            {
                if (grid.Rows.Count != 0)
                {
                    removeifexist(grid.Columns["Renew"]);
                    removeifexist(grid.Columns["chkSMS"]);
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired"))
                    {
                        DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                        Di.Delete(true);
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                    }
                    else
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                    }

                    ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired\\Members of ToBeExpired Package -" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                    Common.ImportExport.ImportToExcel(grid, ReportFolder);
                }

                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                grid.DataSource = null;
                FillGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Savelast30ExpExcel()
        {
            try
            {
                if (grid.Rows.Count != 0)
                {
                    removeifexist(grid.Columns["Renew"]);
                    removeifexist(grid.Columns["chkSMS"]);
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Last30DaysExpired"))
                    {
                        DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                        Di.Delete(true);
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Last30DaysExpired");
                    }
                    else
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Last30DaysExpired");
                    }

                    ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Last30DaysExpired\\MembersofLast30DaysExpiredPackage-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xlxs");
                    Common.ImportExport.ImportToExcel(grid, ReportFolder);
                }

                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                grid.DataSource = null;
                FillGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void SaveExpiredExcel()
        {
            try
            {
                if (grid.Rows.Count != 0)
                {
                    removeifexist(grid.Columns["Renew"]);
                    removeifexist(grid.Columns["chkSMS"]);
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired"))
                    {
                        DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired");
                        Di.Delete(true);
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired");
                    }
                    else
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired");
                    }

                    ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired\\Members with Expired Package -" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                    Common.ImportExport.ImportToExcel(grid, ReportFolder);
                }

                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                
               // checkBoxSMS();
               // RenewButton();
                grid.DataSource = null;
                FillGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                SendMail();
            }

            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        public void SendMail()
        {
            try
            {

                bool sentMail = false;
                string ReportFolder = "";
                int index = cmbFilterBy.SelectedIndex;
                string subject;
                List<string> attachment = new List<string>();
                if (index == 1)
                {
                    if (grid.Rows.Count != 0)
                    {
                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired"))
                        {
                            DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                            Di.Delete(true);
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                        }
                        else
                        {
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired");
                        }

                        ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\ToBeExpired\\Members with ToBeExpired Packages-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                        Common.ImportExport.ImportToExcel(grid, ReportFolder);
                        subject = "Details of Members with To Be Expired Package";
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("As there are No records to Save,\n Mail Cannot be send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }

                if (index == 0)
                {
                    if (grid.Rows.Count != 0)
                    {
                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired"))
                        {
                            DirectoryInfo Di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired");
                            Di.Delete(true);
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired");
                        }
                        else
                        {
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired");
                        }

                        ReportFolder = (AppDomain.CurrentDomain.BaseDirectory + "ExpiredRenewal\\Expired\\Members with Expired Packages-" + (DateTime.Now.ToShortDateString().Replace(@"/", "")) + ".Xls");
                        Common.ImportExport.ImportToExcel(grid, ReportFolder);
                        subject = "Details of Members with Expired Packages";
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("As there are No records to Save,\n Mail Cannot be send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }

                attachment.Add(ReportFolder);

                
                string emailbody = "Please find the Attachment given below :";
                List<string> EmailId = new List<string>();
                EmailId.Add(Info.SysParam.getValue<string>(SysParam.Parameters.EMAIL_ADDRESS));

                sentMail = MailHandler.sendEmail( emailbody, EmailId, "Details of Members Packages", attachment);
                if (sentMail == true)
                {
                    UICommon.WinForm.showStatus("Mail Sent Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Mail not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    List<Info.StudentFacility> facility;
                    //StudentFacility objFacility = new StudentFacility();
                    Info.Student objStudent = new Student();
                    DataGridViewRow selectedRow = grid.Rows[e.RowIndex];
                    DataGridViewCheckBoxCell chckBx = new DataGridViewCheckBoxCell();

                    if (e.ColumnIndex == 0)
                    {
                        foreach (DataGridViewRow row in grid.SelectedRows)
                        {
                            chckBx = (DataGridViewCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            if (chckBx.Value == null)
                            {
                                chckBx.Value = false;
                                chckBx.Value = !(Boolean)chckBx.Value;
                            }
                            else
                            {
                                chckBx.Value = !(Boolean)chckBx.Value;
                            }
                        }
                    }

                    if (cmbFilterBy.SelectedIndex != 2)
                    {
                        if (e.ColumnIndex == grid.Columns["Renew"].Index)
                        {

                            objStudent = BLL.StudentHandller.GetStudent(Convert.ToInt32(selectedRow.Cells["AdmissionNo"].Value), "0", "0", 0, Program.LoggedInUser.BranchId);

                            int studfacilityID = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                            string facilityName = selectedRow.Cells["Package"].Value.ToString();

                            foreach (StudentFacility objFacility in objStudent.Facilities)
                            {
                                if (objFacility.Id == studfacilityID)
                                {
                                    if (FrmStudentDetails.checkPackageType(objFacility))
                                    {
                                        objFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
                                        objFacility.Student.RollNo = objStudent.RollNo;
                                        FrmMonthSelector frmMnthSelector = new FrmMonthSelector(objStudent);
                                        frmMnthSelector.feeStructure = objFacility;
                                        var res = frmMnthSelector.ShowDialog();
                                        if (res == DialogResult.Cancel)
                                        {
                                            return;
                                        }
                                        UICommon.WinForm.showStatus(objStudent.DisplayName + "'s Facility " + facilityName + " Renewed Successfully", sCaption, this);
                                        break;

                                    }

                                }
                            }
                            grid.DataSource = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), cmbFilterBy.SelectedIndex);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if(cmbFilterBy.SelectedIndex!=3)
                {
                   if (grid.Columns.Contains("chkSMS"))
              {

                    grid.Columns["chkSMS"].Visible = true;
                    grid.Columns["chkSMS"].ReadOnly = false;
                }
                }
            
                if(grid.Columns.Contains("Start"))
                {
                    grid.Columns["Start"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                }
                if (grid.Columns.Contains("StartDate"))
                {
                    grid.Columns["StartDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                }
                grid.ReadOnly = true;
                formatDateColumn(grid.Columns["Date"]);
                formatDateColumn(grid.Columns["AdmissionDate"]);
                formatDateColumn(grid.Columns["ExpiredOn"]);

                if (cmbFilterBy.Visible == true && cmbFilterBy.SelectedIndex == 2)
                {
                  
                    removeifexist(grid.Columns["Renew"]);
                    removeifexist(grid.Columns["Delete"]);
                    // grid.Columns[1].Visible = false;
                }
                if (cmbFilterBy.SelectedIndex == 0 && grid.Columns.Contains("Delete"))
                {
                    if (grid.Columns.Contains("Renew"))
                    {
                        grid.Columns["Renew"].DisplayIndex = 1;
                        grid.Columns["Renew"].ReadOnly = false;
                    }
                    removeifexist(grid.Columns["Delete"]);
                }
                if (grid.Columns.Contains("Id"))
                {
                    grid.Columns["Id"].Visible = false;
                }
                if (grid.Columns.Contains("AdmissionNo"))
                {
                    grid.Columns["AdmissionNo"].Visible = false;
                }
                if (grid.Columns.Contains("Id1"))
                {
                    grid.Columns["Id1"].Visible = true;
                    grid.Columns["Id1"].HeaderText = "ID";
                }
                if ((cmbFilterBy.SelectedIndex == 1 && grid.Columns.Contains("Renew")))
                {
                    if (grid.Columns.Contains("Renew"))
                    {
                        grid.Columns["Renew"].DisplayIndex = 1;
                        grid.Columns["Renew"].ReadOnly = false;
                    }
                    // removeifexist(grid.Columns["Renew"]);
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
            catch (Exception)
            {

                throw;
            }
        }

        private void bgwExpiredPackages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
                }
                else
                {


                    BtnSMS.Enabled = true;
                    UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void bgwExpiredPackages_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable Dt = (DataTable)e.Argument;
                MailHandler.SendExpiredPackagesSMS(Dt, Program.LoggedInUser.BranchId);
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

        private void dtpAttdToDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if (validateDates())
                {
                    if (cmbFilterBy.SelectedIndex == 0)
                    {
                    //    dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                    //    dtpAttdToDate.Value = DateTime.Now;
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        newcolumn();
                        bindData(renew, 0);
                    }
                    if (cmbFilterBy.SelectedIndex == 1)
                    {
                        //UICommon.WinForm.setDateE(dtpAttdFromDate, dtpAttdToDate);
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(),1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        newcolumn();
                        bindData(renew, 1);
                    }
                    if (cmbFilterBy.SelectedIndex ==2)
                    {
                        //dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                        //dtpAttdToDate.Value = DateTime.Now;
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(),2, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                        newcolumn();
                        bindData(renew, 2);
                    }
                    if (cmbFilterBy.SelectedIndex == 3)
                    {

                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 4, dtpAttdFromDate.Value, dtpAttdToDate.Value);

                        grid.Columns["chkSMS"].Visible = false;
                        bindData(renew, 3);
                    }

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
                    //dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                    //dtpAttdToDate.Value = DateTime.Now;
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    newcolumn();
                    bindData(renew, 0);
                }
                if (cmbFilterBy.SelectedIndex == 1)
                {
                   // UICommon.WinForm.setDateE(dtpAttdFromDate, dtpAttdToDate);
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    newcolumn();
                    bindData(renew, 1);
                }
                if (cmbFilterBy.SelectedIndex == 2)
                {
                    //dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                    //dtpAttdToDate.Value = DateTime.Now;
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 2, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    grid.Columns["chkSMS"].Visible = false;
                    bindData(renew, 2);
                }
                if (cmbFilterBy.SelectedIndex == 3)
                {

                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 4, dtpAttdFromDate.Value, dtpAttdToDate.Value);

                    grid.Columns["chkSMS"].Visible = false;
                    bindData(renew, 3);
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

      

        private void btnUpdateMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarketingMessage.Text.Trim() != "")
                {
                    if (TemplateHandler.updateTemplatesByType("ARVERTISESMS", txtMarketingMessage.Text))
                    {
                        UICommon.WinForm.showStatus("Marketing Message Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Enter Message to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnAdSend_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtselectedrow = new DataTable();
                if (cmbFilterBy.SelectedIndex < 2)
                    if (chkSelectAll.Checked)
                    {

                        bgwExpiredPackages.RunWorkerAsync(renew);
                    }
                    else
                    {
                        DataTable dt = ((DataTable)grid.DataSource).Clone();
                        foreach (DataGridViewRow row in grid.Rows)
                        {

                            if (row.Cells[0].Value != null && (Boolean)row.Cells[0].Value == true)
                            {

                                if (cmbFilterBy.SelectedIndex == 0)
                                {
                                    string[] Columns = { "AdmissionNo", "Name", "ContactNo", "Package", "ExpiredOn" };
                                    dt.ImportRow(((DataTable)grid.DataSource).Rows[row.Index]);
                                    dtselectedrow = dt.DefaultView.ToTable(true, Columns);

                                }
                                else
                                {
                                    string[] Columns = { "AdmissionNo", "Name", "ContactNo", "Package", "RenewalDate" };
                                    dt.ImportRow(((DataTable)grid.DataSource).Rows[row.Index]);
                                    dtselectedrow = dt.DefaultView.ToTable(true, Columns);
                                }

                            }

                        }
                        bgwExpiredPackages.RunWorkerAsync(dtselectedrow);
                    }


                if (renew.Rows.Count == 0)
                {

                    UICommon.WinForm.showStatus("No Member Selected to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }

            }
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbFilterBy.SelectedIndex == 0)
                {

                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    newcolumn();
                    bindData(renew, 0);
                    grid.DataSource = renew;

                }
                else if (cmbFilterBy.SelectedIndex == 1)
                {
                    //  UICommon.WinForm.setDateE(dtpAttdFromDate, dtpAttdToDate);
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    newcolumn();
                    bindData(renew, 1);
                    grid.DataSource = renew;
                }

                else if (cmbFilterBy.SelectedIndex == 2)
                {
                    //dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
                    //dtpAttdToDate.Value = DateTime.Now;
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 3, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    if(grid.Columns.Contains("chkSMS"))
                    {
                        grid.Columns["chkSMS"].Visible = false;
                    }
                   
                    bindData(renew, 2);
                    grid.DataSource = renew;
                }
                else
                {


                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 4, dtpAttdFromDate.Value, dtpAttdToDate.Value);

                    if (grid.Columns.Contains("chkSMS"))
                    {
                        grid.Columns["chkSMS"].Visible = false;
                    }
                    bindData(renew, 3);



                }

                PdfParameters getParameter = new PdfParameters();
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpAttdFromDate.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpAttdToDate.Value);
                getParameter.View = "Filter By:- " + cmbFilterBy.SelectedIndex.ToString();
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Expiry Report";
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
                        string pathTosave = folderDlg.SelectedPath + "\\Expiry Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(grid, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }

                }

                else
                {
                    UICommon.WinForm.showStatus("No Records", null, null);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //added by ashvini on 30-03-2019 on date filter 
        private void dtpAttdToDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtf = dtpAttdFromDate.Value;
            DateTime dtt = dtpAttdToDate.Value;
          //  UICommon.WinForm.setDateE(dtpAttdFromDate, dtpAttdToDate);
            dtpAttdFromDate.Value = dtf;
            dtpAttdToDate.Value = dtt;

            try
            {
                if (cmbFilterBy.SelectedIndex == 0)
                {
                   
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    newcolumn();
                    bindData(renew, 0);
                }
                if (cmbFilterBy.SelectedIndex == 1)
                {
                  
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    newcolumn();
                    bindData(renew, 1);
                }
                if (cmbFilterBy.SelectedIndex == 2)
                {
                   
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 2, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    grid.Columns["chkSMS"].Visible = true;
                    bindData(renew, 2);
                    newcolumn();
                }
                if(cmbFilterBy.SelectedIndex==3)
                {
                   
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 4, dtpAttdFromDate.Value, dtpAttdToDate.Value);
                    if(grid.Columns.Contains("chkSMS"))
                    {
               grid.Columns["chkSMS"].Visible = false;
                    }
              
                    bindData(renew, 3);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //end by ashvini on 30-03-2019
    }
}
