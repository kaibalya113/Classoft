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

namespace ClassManager.WinApp
{
    public partial class FrmExpiredRenewal : FrmParentForm
    {
        public static Info.Student objStudent;
        private static FrmExpiredRenewal myInstance;
        string sCaption = "ExpiredOrRenewal";
        DataTable renew;
        string ReportFolder;
        int EnquiryId;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        public int AdmissionNo { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmExpiredRenewal()
        {
            InitializeComponent();
        }

        private void FrmExpiredRenewal_Load(object sender, EventArgs e)
        {
            if (this.IsMdiChild != true)
            {
            }
            else
            {
                //hiding at the time of loading form by ashvini
                PanelFollowUp.Visible = false;
                WinForm.AssignFilterEvent(grid);

                newcolumn();
                cmbFilterBy.SelectedIndex = 1;

                //added for popullate cmbFollowupBy combobox
                loadFields();
             
                branchID = Program.LoggedInUser.BranchId.ToString();
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(this.btnSendMail, "Send Mail");
                ToolTip1.SetToolTip(this.BtnSMS, "Send SMS");
                ToolTip1.SetToolTip(this.btnSaveToExcel, "Save To Excel");
                txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                this.Width = 955;
                this.Height = 672;
                AdgvViewFolow.RowTemplate.Height = 30;

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

        private void FormatAdgvViewFolow()
        {
            if (AdgvViewFolow.Columns.Contains("Date"))
            {
                AdgvViewFolow.Columns["Date"].Width = 80;
                AdgvViewFolow.Columns["Date"].HeaderText = "Next Followup";
            }

            if (AdgvViewFolow.Columns.Contains("Medium"))
            {
                AdgvViewFolow.Columns["medium"].Width = 80;
            }

            if (AdgvViewFolow.Columns.Contains("FOLU_CRTD_AT"))
            {
                AdgvViewFolow.Columns["FOLU_CRTD_AT"].Width = 80;
                AdgvViewFolow.Columns["FOLU_CRTD_AT"].HeaderText = "Followup On";
                AdgvViewFolow.Columns["FOLU_CRTD_AT"].DisplayIndex = 4;
            }

            if (AdgvViewFolow.Columns.Contains("FOLU_BY"))
            {
                AdgvViewFolow.Columns["FOLU_BY"].Width = 70;
                AdgvViewFolow.Columns["FOLU_BY"].HeaderText = "Followup By";
            }
            
            if (AdgvViewFolow.Columns.Contains("Description"))
            {
                AdgvViewFolow.Columns["Description"].Width = 200;
            }
            
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {

                    if (grid.Columns.Contains("AdmissionNo"))
                    {
                        AdmissionNo = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["AdmissionNo"].Value));
                    }
                    else
                    {
                        AdmissionNo = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["Admission No"].Value));
                    }

                    
                    if (grid.Columns.Contains("new_followup") && e.ColumnIndex == grid.Columns["new_followup"].Index)
                    {
                        EnquiryId = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["AdmissionNo"].Value));

                        PanelFollowUp.Visible = true;
                        pnlViewFollowUp.Visible = false;
                        AdgvViewFolow.Visible = false;
                        BtnCancel.Visible = false;
                        lblStudName.Text = grid.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                        this.Width = 1156;
                        this.Height = 646;


                    }

                    DataTable dt = null;
                    //added for view followup by ashvini
                    if (grid.Columns.Contains("FollowUps") && e.ColumnIndex == grid.Columns["FollowUps"].Index)
                    {
                        if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                        {
                            //adding column FollwupBy in AdgvViewFolow by Ashvini
                            DataGridViewColumn ColumFolloupBy = new DataGridViewColumn();
                            ColumFolloupBy.HeaderText = "Followup By";
                            ColumFolloupBy.Name = "follo";
                            ColumFolloupBy.Visible = true;
                            ColumFolloupBy.Width = 80;
                            EnquiryId = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["AdmissionNo"].Value));
                            dt = BLL.FollowupHandler.viewFollowUp(EnquiryId);

                            PanelFollowUp.Visible = false;
                            pnlViewFollowUp.Visible = true;
                            AdgvViewFolow.Visible = true;
                            BtnCancel.Visible = true;
                            this.Width = 1301;
                            this.Height = 672;

                            AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                            dt = BLL.FollowupHandler.viewFollowUp(EnquiryId);
                            AdgvViewFolow.DataSource = dt;
                            FormatAdgvViewFolow();
                        }

                    }


                    List<StudentFacility> facility;

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
                    
                    if (cmbFilterBy.SelectedIndex == 0 || cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 2)
                    {
                        if (grid.Columns.Contains("Name") && e.ColumnIndex == grid.Columns["Name"].Index)
                        {
                            StudentDetailsParent objstudent = (StudentDetailsParent)UICommon.FormFactory.GetForm(Forms.FrmStudentDetails, this, true);
                            objstudent.loadStudent(AdmissionNo);
                            objstudent.ShowDialog();
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
                                        FrmMonthSelector frmMnthSelector = new FrmMonthSelector(objStudent, objFacility,false);
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
                        
                        else if (e.ColumnIndex == grid.Columns["Delete"].Index)
                        {
                            foreach (DataGridViewRow facilty in grid.Rows)
                            {
                                if (facilty.Cells[1].Selected)
                                {

                                    var result = UICommon.WinForm.showStatus("Do You Want Delete this Package?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                                    if (result == DialogResult.Yes)
                                    {
                                        int studfacilityID = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                                        deleteFacilty(studfacilityID);
                                        grid.DataSource = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        //added for delete facility by ashvini
        private void deleteFacilty(int studFacID)
        {
            int returnCode = BLL.StudentHandller.deleteFacility(studFacID, Program.LoggedInUser.BranchId);

            if (returnCode == 1)
            {
                UICommon.WinForm.showStatus("Package Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            else
            {
                UICommon.WinForm.showStatus("Error occured while deleting package", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

        public void AddColumns()
        {
            try
            {
                grid.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.calendar,

                    Name = "Renew",
                    HeaderText = "Renew"
                });
                // added  column in gridview 
                grid.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.eye,
                    Name = "FollowUps",
                    HeaderText = "View FollowUp"

                });
                // added  column in gridview 
                grid.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.Add,
                    Name = "new_followup",
                    HeaderText = "Add FollowUp"
                });
                grid.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.deleteBin,

                    Name = "Delete",
                    HeaderText = "Delete"
                });

                // grid.Columns["Renew"].DisplayIndex = 1;
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
                grid.Columns["chkSMS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void newcolumn()

        {
            //code changed by ashvini 10-12
            checkBoxSMS();
            AddColumns();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                switch (cmbFilterBy.SelectedIndex)
                {
                    case 0:
                        newcolumn();
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);

                        bindData(renew, 0);

                        break;

                    case 1:
                        newcolumn();
                        DateTime dt = DateTime.Now.Date;
                        DateTime dtt = DateTime.Today.AddDays(-30);
                        renew = BLL.FeesHandller.getRenewalOn(Program.LoggedInUser.BranchId.ToString(), 1, dtt, dt);

                        bindData(renew, 1);
                        break;
                    case 2:
                        newcolumn();

                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 2);

                        bindData(renew, 2);
                        break;

                    case 3:
                        renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 3);
                        if (grid.Columns.Contains("chkSMS"))
                        { grid.Columns["chkSMS"].Visible = false; }
                        bindData(renew, 3);
                        break;
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, "Renewal/Expired", this);
            }
        }

        private void FillGrid()
        {
            try
            {
                if (cmbFilterBy.SelectedIndex == 0)
                {

                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);
                    newcolumn();
                    bindData(renew, 0);
                }
                if (cmbFilterBy.SelectedIndex == 1)
                {

                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1);

                    bindData(renew, 1);
                }
                if (cmbFilterBy.SelectedIndex == 2)
                {
                    renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 2);
                    grid.Columns["chkSMS"].Visible = false;
                    bindData(renew, 2);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Expired()
        {
            renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);
            newcolumn();
            bindData(renew, 0);
        }
        public void TobeExpired()
        {
            renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1);
            newcolumn();
            bindData(renew, 1);
        }
        public void bindData(DataTable dt, int index)
        {
            try
            {
                grid.DataSource = dt;
                if (grid.Columns.Contains("start"))
                {
                    grid.Columns["start"].HeaderText = "Start";
                }
                if (grid.Columns.Contains("end_date"))
                {
                    grid.Columns["end_date"].HeaderText = "End";
                }

                if (index != 3)
                {
                    grid.Columns["packageId"].Visible = false;
                    UICommon.WinForm.formatDateColumn(grid, "RenewalDate");
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
                UICommon.WinForm.formatDateColumn(grid, "Date");
                UICommon.WinForm.formatDateColumn(grid, "Start");
                UICommon.WinForm.formatDateColumn(grid, "AdmissionDate");
                UICommon.WinForm.formatDateColumn(grid, "ExpiredOn");


                if (cmbFilterBy.Visible == true && (cmbFilterBy.SelectedIndex == 2 || cmbFilterBy.SelectedIndex == 3))
                {
                    removeifexist(grid.Columns["Renew"]);
                    removeifexist(grid.Columns["Delete"]);
                }

                if (cmbFilterBy.SelectedIndex == 0 && grid.Columns.Contains("Delete"))
                {
                    if (grid.Columns.Contains("Renew"))
                    {
                        grid.Columns["Renew"].DisplayIndex = 1;
                        grid.Columns["Renew"].HeaderText = "Renew";
                        grid.Columns["Renew"].Width = 70;
                    }
                }
                if (grid.Columns.Contains("AdmissionNo1"))
                {
                    grid.Columns["AdmissionNo1"].HeaderText = Lang.translate("AdmissionNo");
                }
                if (grid.Columns.Contains("Id"))
                {
                    grid.Columns["Id"].Visible = false;
                    grid.Columns["Id"].Width = 30;
                }
                if (grid.Columns.Contains("AdmissionNo"))
                {
                    grid.Columns["AdmissionNo"].Visible = true;
                }
                if (grid.Columns.Contains("ID1"))
                {
                    grid.Columns["ID1"].HeaderText = Lang.translate("AdmissionNo");
                    grid.Columns["ID1"].Visible = false;
                }

                if (cmbFilterBy.SelectedIndex == 1)
                {
                    if (grid.Columns.Contains("Delete"))
                    {
                        grid.Columns["Delete"].Visible = true;
                    }

                }

                if ((cmbFilterBy.SelectedIndex == 1 && grid.Columns.Contains("Renew")))
                {
                    if (grid.Columns.Contains("Renew"))
                    {
                        grid.Columns["Renew"].DisplayIndex = 1;
                        grid.Columns["Renew"].HeaderText = "Renew";
                        grid.Columns["Renew"].Width = 80;
                    }
                }


                if (cmbFilterBy.SelectedIndex != 3)
                {

                    if (grid.Columns.Contains("FollowUps"))
                    {
                        grid.Columns["FollowUps"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["FollowUps"].HeaderText = "Followups";
                        grid.Columns["FollowUps"].DisplayIndex = 9;
                    }

                    if (grid.Columns.Contains("new_followup"))
                    {
                        grid.Columns["new_followup"].HeaderText = "Add Followup";
                        grid.Columns["new_followup"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["new_followup"].DisplayIndex = 10;
                    }

                    if (grid.Columns.Contains("AdmissionNo"))
                    {
                        grid.Columns["AdmissionNo"].HeaderText = Lang.translate("AdmissionNo");
                        grid.Columns["AdmissionNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["AdmissionNo"].DisplayIndex = 2;
                        grid.Columns["AdmissionNo"].ReadOnly = true;
                    }

                    if (grid.Columns.Contains("ContactNo"))
                    {
                        grid.Columns["ContactNo"].HeaderText = "Contact";
                        grid.Columns["ContactNo"].Width = 100;
                        grid.Columns["ContactNo"].DisplayIndex = 4;
                        grid.Columns["ContactNo"].ReadOnly = true;
                    }

                    if (grid.Columns.Contains("Package"))
                    {
                        grid.Columns["Package"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["Package"].DisplayIndex = 5;
                        grid.Columns["Package"].ReadOnly = true;
                    }

                    if (grid.Columns.Contains("RenewalDate"))
                    {
                        grid.Columns["RenewalDate"].HeaderText = "Renewal";
                        grid.Columns["RenewalDate"].Width = 85;
                        grid.Columns["RenewalDate"].DisplayIndex = 8;
                        grid.Columns["RenewalDate"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("ExpiredOn"))
                    {
                        grid.Columns["ExpiredOn"].HeaderText = "Expired";
                        grid.Columns["ExpiredOn"].Width = 85;
                        grid.Columns["ExpiredOn"].DisplayIndex = 8;
                        grid.Columns["ExpiredOn"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("Outstanding Fees"))
                    {
                        grid.Columns["Outstanding Fees"].HeaderText = "Pending";
                        grid.Columns["Outstanding Fees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["Outstanding Fees"].DisplayIndex = 6;
                        grid.Columns["Outstanding Fees"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("Start"))
                    {
                        grid.Columns["Start"].HeaderText = "Start";
                        grid.Columns["Start"].Width = 90;
                        grid.Columns["Start"].DisplayIndex = 7;
                        grid.Columns["Start"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("Name"))
                    {
                        grid.Columns["Name"].Width = 200;
                        grid.Columns["Name"].ReadOnly = true;
                        grid.Columns["Name"].DisplayIndex = 3;
                    }
                    

                    if (grid.Columns.Contains("ID1"))
                    {
                        grid.Columns["ID1"].HeaderText = Lang.translate("AdmissionNo");
                        grid.Columns["ID1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["ID1"].DisplayIndex = 2;
                        grid.Columns["ID1"].ReadOnly = true;
                    }
                   
                }


                if (cmbFilterBy.SelectedIndex == 2)
                {
                    if (grid.Columns.Contains("Start"))
                    {
                        grid.Columns["Start"].HeaderText = "Start";
                        grid.Columns["Start"].Width = 90;
                        grid.Columns["Start"].DisplayIndex = 7;
                        grid.Columns["Start"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("RenewalDate"))
                    {
                        grid.Columns["RenewalDate"].HeaderText = "Renewal";
                        grid.Columns["RenewalDate"].Width = 85;
                        grid.Columns["RenewalDate"].DisplayIndex = 8;
                        grid.Columns["RenewalDate"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("FollowUps"))
                    {
                        grid.Columns["FollowUps"].Width = 85;
                        grid.Columns["FollowUps"].HeaderText = "Followups";
                        grid.Columns["FollowUps"].DisplayIndex = 9;
                    }

                    if (grid.Columns.Contains("new_followup"))
                    {
                        grid.Columns["new_followup"].HeaderText = "Add Followup";
                        grid.Columns["new_followup"].Width = 85;
                        grid.Columns["new_followup"].DisplayIndex = 10;
                    }

                }
                if (cmbFilterBy.SelectedIndex == 3)
                {
                    removeifexist(grid.Columns["new_followup"]);
                    removeifexist(grid.Columns["FollowUps"]);


                    if (grid.Columns.Contains("AdmissionNo"))
                    {
                        grid.Columns["AdmissionNo"].HeaderText = Lang.translate("AdmissionNo");
                        grid.Columns["AdmissionNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["AdmissionNo"].DisplayIndex = 0;
                        grid.Columns["AdmissionNo"].ReadOnly = true;
                    }


                    if (grid.Columns.Contains("Name"))
                    {
                        grid.Columns["Name"].Width = 250;
                        grid.Columns["Name"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("ContactNo"))
                    {
                        grid.Columns["ContactNo"].HeaderText = "Contact";
                        grid.Columns["ContactNo"].Width = 100;
                        grid.Columns["ContactNo"].ReadOnly = true;
                    }
                    if (grid.Columns.Contains("AdmissionDate"))
                    {
                        grid.Columns["AdmissionDate"].HeaderText = "Admission Date";
                        grid.Columns["AdmissionDate"].Width = 100;
                        grid.Columns["AdmissionDate"].DisplayIndex = 3;
                        grid.Columns["AdmissionDate"].ReadOnly = true;
                    }

                }

                if (cmbFilterBy.SelectedIndex == 0 || cmbFilterBy.SelectedIndex == 1)
                {
                    if (grid.Columns.Contains("Delete"))
                    {
                        grid.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grid.Columns["Delete"].DisplayIndex = 11;


                    }

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

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cmbFilterBy.SelectedIndex;

                if (index == 2)
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
                if (index == 1)
                {
                    SaveTobeExpExcel();
                }
                if (index == 0)
                {
                    SaveExpiredExcel();
                }
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
                grid.DataSource = null;
                FillGrid();
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
                                else if (cmbFilterBy.SelectedIndex == 1)
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

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = grid.DataSource;
                bs.Filter = grid.Columns["Name"].HeaderText.ToString() + " LIKE '%" + txtFname.Text + "%'";
                grid.DataSource = bs;
            }
            catch (Exception)
            {

                throw;
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
        //added for populate cmbFollowby combobox by ashvini
        private void loadFields()
        {

            string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
            if (check == "")
            {
                cmb_followBy.Visible = false;

            }
            else
            {
                string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                foreach (String value in items)
                {
                    cmb_followBy.Items.Add(value);
                }
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
        private bool validateFollowupDetails()
        {
            try
            {

                if (dtFollowup.Value.ToShortDateString() == System.DateTime.Now.ToShortDateString())
                {
                    UICommon.WinForm.showStatus("Next Followup-Date Should be greater than todays date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtFollowup.Focus();
                    return false;
                }
                else if (cmbMediam.SelectedItem == null)
                {
                    UICommon.WinForm.showStatus("Select Medium for followup", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbMediam.Focus();
                    return false;
                }
                else if (cmb_followBy.SelectedItem == null)
                {
                    UICommon.WinForm.showStatus("Select FollowpupBy for followup", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmb_followBy.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        // added for clearing filled new followup form
        private void clearall()
        {
            try
            {
                cmbMediam.Text = "";
                txtDescription.Clear();
                dtFollowup.Value = DateTime.Now;
                cmb_followBy.Text = "";
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        // added for saving new followup by ashvini
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFollowupDetails())
                {
                    Followup objFollowup = new Followup();
                    objFollowup.ReferenceID = EnquiryId.ToString();
                    objFollowup.FollowupType = "Renewals";
                    objFollowup.FollowupDate = dtFollowup.Value;
                    objFollowup.FollowupDesc = txtDescription.Text;
                    objFollowup.FollowupMediam = cmbMediam.Text;
                    //Addded by ashwini for adding followup by field
                    objFollowup.FollowupBy = (cmb_followBy.SelectedIndex == -1 ? "NA" : cmb_followBy.SelectedItem.ToString());
                    BLL.FollowupHandler.SaveFollowup(objFollowup, branchID);

                    Enquiry objEnquiry = new Enquiry();

                    UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearall();
                    PanelFollowUp.Visible = false;
                    this.Width = 956;
                    this.Height = 646;

                    //BindingSource bs = new BindingSource();
                    //bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(.ToString(), -1);
                    //bs.Filter = "ENQ_IS_REGISTERED = 'No' and Priority<>'Not Interested'";
                    //DataTable dt = (bs.List as DataView).ToTable(); ;
                    //SGStudents.PageSize = 25;
                    //SGStudents.SetPagedDataSource(dt, bindingNavigator1);

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        // added to bind data with grid
        private void AdgvViewFolow_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                FormatAdgvViewFolow();
                AdgvViewFolow.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                AdgvViewFolow.Columns[1].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                AdgvViewFolow.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            }
            catch (Exception)
            {

                throw;
            }
        }
        // closing the AdgvViewFolow grid
        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            try
            {
                BtnCancel.Visible = false;
                pnlViewFollowUp.Visible = false;
                AdgvViewFolow.Visible = false;
                this.Width = 962;
                this.Height = 646;

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
