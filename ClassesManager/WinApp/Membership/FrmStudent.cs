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
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmStudent : FrmParentForm
    {
        private bool considerGroupBy = true;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Show All Student";
        RolePrivilege formPrevileges;

        private int identifier;
        string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
        DataTable dtStudent;
        int pageIndex = 1;
        int PageSize = 20;
        public FrmStudent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Formats DateTimePicker
        /// </summary>
        private void formatDTP()
        {
            try
            {
                WinForm.formatDateTimePicker(dtpFrom);
                WinForm.formatDateTimePicker(dtpTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Disable search box. Hence it should be disable when user is selecting Stream, Course etc. in groupby combobox.
        /// </summary>
        private void enableSearchTxtBx()
        {
            try
            {
                if (cmbGroupBy.SelectedIndex != 0)
                {
                    txtFName.Enabled = true;
                }
                else
                {
                    txtFName.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ShowAllStudent_Load(object sender, EventArgs e)
        {
            try
            {

                SGStudents.RowTemplate.MinimumHeight = 25;
                SGStudents.RowTemplate.Height = 25;
                hide();
                if (chkAllBranch.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();
                }

                formatDTP();
                cbFilterByDate.Checked = false;
                dtStudent = BLL.StudentHandller.getAllStudents(Convert.ToString(branchID));
                getcount(dtStudent);
                SGStudents.PageSize = 25;
                SGStudents.SetPagedDataSource(dtStudent, bindingNavigator1);

                //cmdViewStudent.SelectedIndex = 0;

                AssignEvents();
                fillcmbGroupBy();
                //selectedindex would be 1 which is Student(Group By)
                cmbGroupBy.SelectedIndex = 0;
                cmdViewStudent.SelectedIndex = 0;
                UICommon.WinForm.setDate(dtpFrom, dtpTo);
                btnSaveViewToExcel.Visible = false;
                BtnViewSave.Visible = false;
                ApplyPrevileges();
                if (appName == "Gym" || appName == "Dance")
                {
                    materialLabel1.Text = "Active Package Count";
                }
                if (appName == "Asset" || appName == "")
                {
                    materialLabel1.Text = "Student Count";
                }
                //cmdViewStudent.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }

        }
        public void hide()

        {
            if (appName == "Gym" || appName == "Dance")
            {
                cmdViewStudent.Items.Insert(0, "All Members");

                cmdViewStudent.Items.Insert(1, "Active");
                cmdViewStudent.Items.Insert(2, "Incative");

            }
            if (appName == "Asset" || appName == "")
            {
                cmdViewStudent.Items.Insert(0, "All Members");

                cmdViewStudent.Items.Insert(1, "Active");
                cmdViewStudent.Items.Insert(2, "Inactive");
            }

        }
        public void fillcmbGroupBy()
        {
            // string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
            if (appName == "Gym" || appName == "Dance")
            {
                //  cmbGroupBy.Items.Insert(0, "None");
                cmbGroupBy.Items.Insert(0, "Members");
                cmbGroupBy.Items.Insert(1, "Package");
                cmbGroupBy.Items.Insert(2, "PackageType");
                cmbGroupBy.Items.Insert(3, "Batch");
                cmbGroupBy.Items.Insert(4, "PackageName");
                cmbGroupBy.Items.Insert(5, "Gender");
            }
            if (appName == "Asset" || appName == "")
            {
                //  cmbGroupBy.Items.Insert(0, "None");
                cmbGroupBy.Items.Insert(0, "Students");
                cmbGroupBy.Items.Insert(1, "Stream");
                cmbGroupBy.Items.Insert(2, "Course");
                cmbGroupBy.Items.Insert(3, "Batch");
                cmbGroupBy.Items.Insert(4, "Package");
                cmbGroupBy.Items.Insert(5, "Gender");
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
                        chkAllBranch.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {

                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                    if (formPrevileges.View == false)
                    {
                        showBtn.Visible = false;
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
            try
            {
                txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                SGStudents.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
                SGStudents.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Formats the student details grid
        /// </summary>
        public void formatviewallStudentgrid()
        {
            if (considerGroupBy)
            {
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                switch (cmbGroupBy.SelectedIndex)
                {

                    case 0:
                        //removing columns
                        removeColumn();
                        //Format DateMemner
                        if (SGStudents.Columns.Contains("AdmissionDate"))
                        {
                            SGStudents.Columns["AdmissionDate"].DefaultCellStyle = WinForm.GridDateFormat;
                        }
                        if (SGStudents.Columns.Contains("Email_Address"))
                        {
                            SGStudents.Columns["Email_Address"].HeaderText = "Email Address";
                        }
                        else
                        {
                             commonFormat();
                        }
                        break;
                    case 1:

                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGStudents.Columns.Contains("Package"))
                            {
                                SGStudents.Columns["Package"].HeaderText = "Package";
                                SGStudents.Columns["Package"].DisplayIndex = 0;

                            }



                        }
                        else
                        {
                            if (SGStudents.Columns.Contains("Package"))
                            {
                                SGStudents.Columns["Package"].HeaderText = "Stream";
                                SGStudents.Columns["Package"].DisplayIndex = 0;
                                SGStudents.Columns["Package"].Width = 70;

                            }
                        }

                        hideColumn();
                        addcolumns();
                        orderColumn();
                        break;
                    case 2:
                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGStudents.Columns.Contains("PackageType"))
                            {
                                SGStudents.Columns["PackageType"].HeaderText = "PackageType";
                                SGStudents.Columns["PackageType"].DisplayIndex = 0;
                            }

                        }
                        else
                        {
                            if (SGStudents.Columns.Contains("PackageType"))
                            {
                                SGStudents.Columns["PackageType"].HeaderText = "Course";
                                SGStudents.Columns["PackageType"].DisplayIndex = 0;
                            }
                        }
                        hideColumn();
                        addcolumns();
                        orderColumn();
                        break;

                    case 3:
                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGStudents.Columns.Contains("Batch"))
                            {

                                SGStudents.Columns["Batch"].HeaderText = "Batch";
                                SGStudents.Columns["Batch"].DisplayIndex = 0;
                            }
                        }

                        else
                        {
                            if (SGStudents.Columns.Contains("Batch"))
                            {
                                SGStudents.Columns["Batch"].HeaderText = "Batch";
                                SGStudents.Columns["Batch"].DisplayIndex = 0;
                            }
                        }
                        hideColumn();
                        addcolumns();
                        orderColumn();
                        break;

                    case 4:
                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGStudents.Columns.Contains("PackageName"))
                            {
                                SGStudents.Columns["PackageName"].HeaderText = "PackageName";
                                SGStudents.Columns["PackageName"].DisplayIndex = 0;
                            }
                        }
                        else
                        {
                            if (SGStudents.Columns.Contains("PackageName"))
                            {
                                SGStudents.Columns["PackageName"].HeaderText = "Package";
                                SGStudents.Columns["PackageName"].DisplayIndex = 0;
                            }
                        }
                        hideColumn();
                        addcolumns();
                        orderColumn();
                        break;
                    case 5:
                        if (appName == "Gym" || appName == "Dance")
                        {


                            if (SGStudents.Columns.Contains("Gender"))
                            {
                                SGStudents.Columns["Gender"].DisplayIndex = 0;
                            }
                        }
                        else
                        {
                            if (SGStudents.Columns.Contains("Gender"))
                            {

                                SGStudents.Columns["Gender"].DisplayIndex = 0;
                            }
                        }

                        addcolumns();
                        hideColumn();
                        orderColumn();
                        break;
                }
            }
            else
            {
                commonFormat();
            }

            if (SGStudents.Columns.Contains("Expired On"))
            {
                SGStudents.Columns["Expired On"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            }

        }
        /// <summary>
        /// It will hide the column "ID".
        /// </summary>
        private void hideColumn()
        {
            try
            {
                if (SGStudents.Columns.Contains("Email Addres"))
                {
                    SGStudents.Columns["Email Addres"].Visible = false;
                }
                if (SGStudents.Columns.Contains("active"))
                {
                    SGStudents.Columns["active"].Visible = false;
                }

                if (SGStudents.Columns.Contains("ID"))
                {
                    SGStudents.Columns["ID"].Visible = false;
                }
                if (SGView.Columns.Contains("start"))
                {
                    SGView.Columns["start"].Visible = false;
                }

                if (SGView.Columns.Contains("end_date"))
                {
                    SGView.Columns["end_date"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void commonFormat()


        {
            try
            {


                //remove columns
                removeColumn();
                if (SGStudents.Columns.Contains("STAM_ADMISSION_NO"))
                {
                    SGStudents.Columns["STAM_ADMISSION_NO"].Visible = false;

                }
                if (SGStudents.Columns.Contains("Source"))
                {
                    SGStudents.Columns["Source"].DisplayIndex = 6;
                    SGStudents.Columns["Source"].Width = 160;
                }
                if (SGStudents.Columns.Contains("STMT_GENDER"))
                {
                    SGStudents.Columns["STMT_GENDER"].Visible = false;

                }
                if (SGStudents.Columns.Contains("STFL_STATUS"))
                {
                    SGStudents.Columns["STFL_STATUS"].Visible = false;

                }
                if (SGStudents.Columns.Contains("STAM_IS_ACTIVE"))
                {
                    SGStudents.Columns["STAM_IS_ACTIVE"].Visible = false;

                }
                //Set Column Headers

                if (SGStudents.Columns.Contains("STMT_ADMISSION_NO"))
                {
                    SGStudents.Columns["STMT_ADMISSION_NO"].HeaderText = "Id";
                    SGStudents.Columns["STMT_ADMISSION_NO"].Width = 50;
                    SGStudents.Columns["STMT_ADMISSION_NO"].DisplayIndex = 0;
                }
                if (appName == "Gym" || appName == "Dance")
                {
                    if (SGStudents.Columns.Contains("STMT_FATHER_CONTACT"))
                    {
                        SGStudents.Columns["STMT_FATHER_CONTACT"].Visible = false;

                    }
                }
                else
                {
                    if (SGStudents.Columns.Contains("STMT_FATHER_CONTACT"))
                    {
                        SGStudents.Columns["STMT_FATHER_CONTACT"].DisplayIndex = 3;
                        SGStudents.Columns["STMT_FATHER_CONTACT"].HeaderText = "Father Contact";
                    }


                }

                if (SGStudents.Columns.Contains("Email_Address"))
                {
                    SGStudents.Columns["Email_Address"].HeaderText = "Email Address";
                }
                if (SGStudents.Columns.Contains("STMT_EMAIL_ID"))
                {
                    SGStudents.Columns["STMT_EMAIL_ID"].HeaderText = "Email Address";
                    SGStudents.Columns["STMT_EMAIL_ID"].Visible = true;
                    SGStudents.Columns["STMT_EMAIL_ID"].DisplayIndex = 6;
                }

                if (SGStudents.Columns.Contains("STMT_MEMSHIP_NO"))
                {
                    SGStudents.Columns["STMT_MEMSHIP_NO"].HeaderText = "id";
                    SGStudents.Columns["STMT_MEMSHIP_NO"].Visible = true;
                }
                if (SGStudents.Columns.Contains("STMT_REMARK"))
                {
                    SGStudents.Columns["STMT_REMARK"].HeaderText = "Remark";
                    SGStudents.Columns["STMT_REMARK"].Visible = true;
                }
                if (SGStudents.Columns.Contains("STAM_ROLL_NO"))
                {
                    SGStudents.Columns["STAM_ROLL_NO"].HeaderText = "Roll No";
                }
                if (SGStudents.Columns.Contains("STMT_ADMISSION_DATE"))
                {
                    SGStudents.Columns["STMT_ADMISSION_DATE"].HeaderText = "Joining Date";
                    SGStudents.Columns["STMT_ADMISSION_DATE"].Width = 130;
                    SGStudents.Columns["STMT_ADMISSION_DATE"].DisplayIndex = 5;
                    SGStudents.Columns["STMT_ADMISSION_DATE"].DefaultCellStyle = WinForm.GridDateFormat;

                }

                if (SGStudents.Columns.Contains("STRM_NAME"))
                {
                    SGStudents.Columns["STRM_NAME"].HeaderText = "Activity";
                    SGStudents.Columns["STRM_NAME"].DisplayIndex = 5;
                    SGStudents.Columns["STRM_NAME"].Width = 150;
                }
                if (SGStudents.Columns.Contains("AdmissionDate"))
                {
                    SGStudents.Columns["AdmissionDate"].HeaderText = "Joining Date";
                    SGStudents.Columns["AdmissionDate"].Width = 130;
                    SGStudents.Columns["AdmissionDate"].DisplayIndex = 4;
                    SGStudents.Columns["AdmissionDate"].DefaultCellStyle = WinForm.GridDateFormat;

                }
                SGStudents.Columns["NAME"].HeaderText = "Name";
                //   SGStudents.Columns["STRM_NAME"].HeaderText = "Activity";

                if (SGStudents.Columns.Contains("STMT_CONTACT_NO"))
                {
                    SGStudents.Columns["STMT_CONTACT_NO"].HeaderText = "Contact No";
                    SGStudents.Columns["STMT_CONTACT_NO"].Width = 100;
                    SGStudents.Columns["STMT_CONTACT_NO"].DisplayIndex = 2;
                }
                if (SGStudents.Columns.Contains("STMT_ADDRESS"))
                {
                    SGStudents.Columns["STMT_ADDRESS"].HeaderText = "Address";
                    SGStudents.Columns["STMT_ADDRESS"].Width = 200;
                    SGStudents.Columns["STMT_ADDRESS"].DisplayIndex = 5;
                }
                if (SGStudents.Columns.Contains("STD_NAME"))
                {
                    SGStudents.Columns["STD_NAME"].HeaderText = "PackageType";
                    SGStudents.Columns["STD_NAME"].Visible = false;
                }
                //  SGStudents.Columns["STMT_CONTACT_NO"].HeaderText = "Contact No";
                // SGStudents.Columns["STMT_ADDRESS"].HeaderText = "Address";
                // SGStudents.Columns["STD_NAME"].HeaderText = "PackageType";
                if (SGStudents.Columns.Contains("STD_NAME"))
                {
                    SGStudents.Columns["STD_NAME"].HeaderText = "PackageType";
                    SGStudents.Columns["STD_NAME"].Visible = false;
                }
                if (SGStudents.Columns.Contains("STMT_DEACTIVATED"))
                {
                    SGStudents.Columns["STMT_DEACTIVATED"].HeaderText = "Deactivated";
                    SGStudents.Columns["STMT_DEACTIVATED"].Visible = false;
                }
                if (SGStudents.Columns.Contains("BTCH_NAME"))
                {
                    SGStudents.Columns["BTCH_NAME"].HeaderText = "Batch";
                    SGStudents.Columns["BRCH_NAME"].Visible = false;

                }
                if (SGStudents.Columns.Contains("FPKG_PACKAGE_NAME"))
                {
                    SGStudents.Columns["FPKG_PACKAGE_NAME"].HeaderText = "Package";
                    SGStudents.Columns["FPKG_PACKAGE_NAME"].Visible = false;
                    SGStudents.Columns["FPKG_PACKAGE_NAME"].Width = 150;
                    SGStudents.Columns["FPKG_PACKAGE_NAME"].DisplayIndex = 6;

                }
                // SGStudents.Columns["BTCH_NAME"].HeaderText = "Batch";

                if (SGStudents.Columns.Contains("Start"))
                {
                    SGStudents.Columns["Start"].Visible = false;
                }

                if (SGStudents.Columns.Contains("end_date"))
                {
                    SGStudents.Columns["end_date"].Visible = false;
                }
                //Width

                SGStudents.Columns["NAME"].Width = 250;

                //  SGStudents.Columns["STMT_ADMISSION_DATE"].Width = 130;
                // SGStudents.Columns["FPKG_PACKAGE_NAME"].Width = 150;



                //Format Columns
                //   SGStudents.Columns["STMT_ADMISSION_DATE"].DefaultCellStyle = WinForm.GridDateFormat;

                //Ordering Column Position
                //     SGStudents.Columns["STMT_ADMISSION_NO"].DisplayIndex = 1;
                SGStudents.Columns["NAME"].DisplayIndex = 1;
                // SGStudents.Columns["STMT_CONTACT_NO"].DisplayIndex = 3;
                // SGStudents.Columns["STRM_NAME"].DisplayIndex = 5;
                //     SGStudents.Columns["FPKG_PACKAGE_NAME"].DisplayIndex = 6;

                //   SGStudents.Columns["STMT_ADDRESS"].DisplayIndex = 8;



                if (SGStudents.Columns.Contains("STD_NAME1"))
                {
                    SGStudents.Columns["STD_NAME1"].Visible = false;
                }


                //Hiding Columns
                if (SGStudents.Columns.Contains("STRM_ID"))
                {
                    // SGStudents.Columns["BTCH_ID"].Visible = false;
                    SGStudents.Columns["STRM_ID"].Visible = false;

                }
                if (SGStudents.Columns.Contains("STD_ID"))
                {


                    SGStudents.Columns["STD_ID"].Visible = false;

                }
                if (SGStudents.Columns.Contains("FPKG_ID"))
                {

                    SGStudents.Columns["FPKG_ID"].Visible = false;
                }
                if (SGStudents.Columns.Contains("BTCH_ID"))
                {
                    SGStudents.Columns["BTCH_ID"].Visible = false;

                }
                if (SGStudents.Columns.Contains("STMT_BRANCH_ID"))
                {
                    SGStudents.Columns["STMT_BRANCH_ID"].Visible = false;

                }


                // SGStudents.Columns["STAM_ROLL_NO"].Visible = false;
                //  SGStudents.Columns["STMT_FATHER_CONTACT"].Visible = false;
                // SGStudents.Columns["STMT_BRANCH_ID"].Visible = false;

                //  SGStudents.Columns["BTCH_NAME"].Visible = false;
                //SGStudents.Columns["STMT_MEMSHIP_NO"].Visible = false;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void orderColumn()
        {
            try
            {
                if (SGStudents.Columns.Contains("View"))
                {
                    //  SGStudents.Columns["Count"].DisplayIndex = 1;
                    SGStudents.Columns["View"].DisplayIndex = 2;
                }
                //else
                //{
                //    ADGVStudent.Columns["Count"].DisplayIndex = 1;
                //    ADGVStudent.Columns["View"].DisplayIndex = 2;
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void removeColumn()
        {
            try
            {
                if (SGStudents.Columns.Contains("STMT_GENDER"))
                {
                    SGStudents.Columns["STMT_GENDER"].Visible = false;

                }
                if (SGStudents.Columns.Contains("active"))
                {
                    SGStudents.Columns["active"].Visible = false;
                }
                if (SGStudents.Columns.Contains("STAM_IS_ACTIVE"))
                {
                    SGStudents.Columns["STAM_IS_ACTIVE"].Visible = false;

                }
                if (SGStudents.Columns.Contains("STMT_EMAIL_ID"))
                {
                    SGStudents.Columns["STMT_EMAIL_ID"].Visible = false;

                }
                if (SGStudents.Columns.Contains("STMT_EMAIL_ID1"))
                {
                    SGStudents.Columns["STMT_EMAIL_ID1"].Visible = false;

                }
                if (SGStudents.Columns.Contains("View"))
                {
                    SGStudents.Columns.Remove("View");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void getcount(DataTable dtStudent)
        {
            try
            {
                DataView dataView = dtStudent.AsDataView();
                dataView.RowFilter = "([STMT_DEACTIVATED] IN ('No') AND  [active_packages] > 0) ";
                //dataView.RowFilter = "([STMT_DEACTIVATED] IN ('No'))";
                txtAct.Text = (from DataRow dRow in dataView.ToTable().Rows
                               select dRow["STMT_MEMSHIP_NO"]
                                  ).Distinct().Count().ToString();


                dataView.RowFilter = "([active_packages] = 0) ";
                txtDel.Text = (from DataRow dRow in dataView.ToTable().Rows
                               select dRow["STMT_MEMSHIP_NO"]).Distinct().Count().ToString();

                dataView.RowFilter = "([STMT_DEACTIVATED] IN ('NO','YES'))";
                txtAll.Text = (from DataRow dRow in dataView.ToTable().Rows
                               select dRow["STMT_MEMSHIP_NO"]).Distinct().Count().ToString();
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // dtStudent = BLL.StudentHandller.getAllStudents(Convert.ToString(branchID));
                BindingSource bs = new BindingSource();
                bs.DataSource = dtStudent;
                bs.Filter = string.Format("Name LIKE '%{0}%'", txtFName.Text);
                SGStudents.DataSource = bs;

            }
            catch (Exception ex)
            {
                WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void cmdViewStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IndexSelection(cmbGroupBy.SelectedIndex);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void SGStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatviewallStudentgrid();
                foreach (DataGridViewRow row in SGStudents.Rows)
                {

                    row.Height = 30;
                    row.MinimumHeight = 30;
                }
                SGStudents.RowTemplate.Resizable = DataGridViewTriState.True;
                SGStudents.RowTemplate.Height = 80;
                SGStudents.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }

        }
        private void addcolumns()
        {
            try
            {
                if (!SGStudents.Columns.Contains("View"))
                {
                    DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                    lnk.Name = "View";
                    lnk.HeaderText = "View Members";
                    lnk.DefaultCellStyle.NullValue = "View";
                    SGStudents.Columns.Insert(2, lnk);

                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }
        private void cmbGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IndexSelection(cmbGroupBy.SelectedIndex);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }
        private void IndexSelection(int index)
        {
            try
            {
                if (chkAllBranch.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();
                }

                //Enable name search box
                enableSearchTxtBx();
                DataTable filteredStudents = filterStudents(cmdViewStudent.SelectedIndex);
                considerGroupBy = true;

                switch (cmbGroupBy.SelectedIndex)
                {
                    case 0:
                        DataTable students = WinForm.ToDataTable(filteredStudents.AsEnumerable()
                                .GroupBy(r => new
                                {
                                    //AdmissionNo = r.Field<int>("STMT_MEMSHIP_NO"),
                                    Name = r.Field<string>("Name"),
                                    FatherContact = r.Field<string>("STMT_FATHER_CONTACT"),
                                    isDeactivated = r.Field<string>("STMT_DEACTIVATED"),
                                    contact = r.Field<string>("STMT_CONTACT_NO"),
                                    Address = r.Field<string>("STMT_ADDRESS"),
                                    Email_Address = r.Field<string>("STMT_EMAIL_ID"),
                                    Membership = r.Field<string>("STMT_MEMSHIP_NO"),
                                    Remark = r.Field<string>("STMT_REMARK")
                                })
                                .Select(g => new
                                {
                                   // AdmissionNo = g.Key.AdmissionNo,
                                    Name = g.Key.Name,
                                    AdmissionDate = g.Min(r => r.Field<DateTime>("STMT_ADMISSION_DATE")),
                                    Contact = g.Key.contact,
                                    FatherContact = g.Key.FatherContact,
                                    Address = g.Key.Address,
                                    Email_Address = g.Key.Email_Address,
                                    Deactivated = g.Key.isDeactivated,
                                    MembershipNo = g.Key.Membership,
                                    Remarks = g.Key.Remark
                                })
                                .ToList());

                        SGStudents.DataSource = students;
                        SGStudents.SetPagedDataSource(students, bindingNavigator1);
                        memberGrifFormat();
                        break;
                    case 1:
                        DataTable stream = filteredStudents.AsDataView().ToTable(true, new string[] { "STMT_MEMSHIP_NO", "STRM_NAME", "STRM_ID" });

                        stream = WinForm.ToDataTable(stream.AsEnumerable()
                        .GroupBy(r => new
                        {
                            Package = r.Field<string>("STRM_NAME"),
                            ID = r.Field<int>("STRM_ID")
                        })
                        .Select(g => new
                        {
                            Package = g.Key.Package,
                            ID = g.Key.ID,
                            Count = g.Count()
                        })
                        .ToList());

                        SGStudents.DataSource = stream;
                        SGStudents.SetPagedDataSource(stream, bindingNavigator1);
                        SGStudents.Columns["Package"].Width = 200;
                        break;

                    case 2:
                        DataTable std = filteredStudents.AsDataView().ToTable(true, new string[] { "STMT_MEMSHIP_NO", "STD_NAME", "STD_ID" });

                        std = WinForm.ToDataTable(std.AsEnumerable()
                        .GroupBy(r => new
                        {
                            PackageType = r.Field<string>("STD_NAME"),
                            ID = r.Field<int>("STD_ID")
                        })
                        .Select(g => new
                        {
                            PackageType = g.Key.PackageType,
                            ID = g.Key.ID,
                            Count = g.Count()
                        }).ToList());

                        SGStudents.DataSource = std;
                        SGStudents.SetPagedDataSource(std, bindingNavigator1);
                        SGStudents.Columns["PackageType"].Width = 200;  
                        break;
                    case 3:
                        DataTable batch = filteredStudents.AsDataView().ToTable(true, new string[] { "STMT_MEMSHIP_NO", "BTCH_NAME", "BTCH_ID" });
                        batch = WinForm.ToDataTable(filteredStudents.AsEnumerable()
                        .GroupBy(r => new
                        {
                            Batch = r.Field<string>("BTCH_NAME"),
                            ID = r.Field<int>("BTCH_ID")
                        })
                        .Select(g => new
                        {
                            Batch = g.Key.Batch,
                            ID = g.Key.ID,
                            Count = g.Distinct().Count()
                        })
                        .ToList());
                        SGStudents.DataSource = batch;
                        SGStudents.SetPagedDataSource(batch, bindingNavigator1);
                        SGStudents.Columns["Batch"].Width = 200;
                        
                        break;

                    case 4:
                        DataTable package = WinForm.ToDataTable(filteredStudents.AsEnumerable()
                        .GroupBy(r => new
                        {
                            FeesPackage = r.Field<String>("FPKG_PACKAGE_NAME"),
                            ID = r.Field<int>("FPKG_ID"),
                        })
                        .Select(g => new
                        {
                            PackageName = g.Key.FeesPackage,
                            ID = g.Key.ID,
                            Count = g.Count()
                        })
                        .ToList());

                        SGStudents.DataSource = package;
                        SGStudents.SetPagedDataSource(package, bindingNavigator1);
                        SGStudents.Columns["PackageName"].Width = 200;
                        break;
                    case 5:
                        DataTable dt = filteredStudents.AsDataView().ToTable(true, new string[] { "STMT_GENDER", "STMT_MEMSHIP_NO" });
                        SGStudents.DataSource = WinForm.ToDataTable(dt.AsEnumerable()
                       .GroupBy(r => new
                       {
                           Gender = r.Field<String>("STMT_GENDER")
                       })
                       .Select(g => new
                       {
                           Gender = g.Key.Gender,
                           Count = g.Count()
                       })
                       .ToList());

                        SGStudents.Columns["Gender"].Width = 70;
                        break;

                }

                btnSaveViewToExcel.Visible = false;
                BtnViewSave.Visible = false;
                SGView.Visible = false;
                SGStudents.Width = 1062;
                SGStudents.Height = 402;

            }
            catch (Exception)
            {
                throw;
            }
        }
        private DataTable filterStudents(int studentsFilterComboIndex)
        {
            DataView dvStudents = dtStudent.AsDataView();
            switch (studentsFilterComboIndex)
            {
                case 0: return dtStudent;

                case 1:
                    dvStudents.RowFilter = "STMT_DEACTIVATED = 'No' and active_packages > 0";
                    return dvStudents.ToTable();

                case 2:
                    dvStudents.RowFilter = "STMT_DEACTIVATED = 'No' and active_packages = 0";
                    return dvStudents.ToTable();

                case 3:
                    dvStudents.RowFilter = "STAM_IS_ACTIVE='False'";
                    return dvStudents.ToTable();

                default: return dtStudent;

            }
        }
        private void memberGrifFormat()
        {
            SGStudents.Columns["MembershipNo"].HeaderText = "Id";


            SGStudents.Columns["MembershipNo"].DisplayIndex = 1;

           // SGStudents.Columns["MembershipNo"].DisplayIndex = 2;
            //SGStudents.Columns["MembershipNo"].HeaderText = Lang.translate("Membership_No");
            SGStudents.Columns["Name"].DisplayIndex = 2;
            SGStudents.Columns["Name"].Width = 250;

            SGStudents.Columns["Contact"].DisplayIndex = 3;
            SGStudents.Columns["Contact"].Width = 100;

            SGStudents.Columns["AdmissionDate"].HeaderText = "Joining Date";
            SGStudents.Columns["AdmissionDate"].DisplayIndex = 4;
            SGStudents.Columns["AdmissionDate"].Width = 130;

            SGStudents.Columns["Address"].DisplayIndex = 5;
            SGStudents.Columns["Address"].Width = 250;
            SGStudents.Columns["Remarks"].DisplayIndex = 6;
            SGStudents.Columns["Remarks"].Width = 250;
            if (appName == "Gym" || appName == "Dance")
            {
                if (SGStudents.Columns.Contains("FatherContact"))
                {
                    SGStudents.Columns["FatherContact"].Visible = false;

                }
            }
            else
            {
                if (SGStudents.Columns.Contains("FatherContact"))
                {
                    SGStudents.Columns["FatherContact"].Visible = true;
                    SGStudents.Columns["FatherContact"].HeaderText = "Father Contact";
                }


            }
            SGStudents.Columns["MembershipNo"].Visible = true;
            SGStudents.Columns["Deactivated"].Visible = false;
            if (SGStudents.Columns.Contains("Email Addres"))
            {
                SGStudents.Columns["Email Addres"].Visible = true;
            }
        }
        private void SGStudents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(SGStudents, e);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }
        private void SGStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1)
                {
                    DataTable dt = null;
                    string strmid = "%", stdid = "%", batchid = "%", packageid = "%";

                    if (SGStudents.Columns.Contains("View") && e.ColumnIndex == SGStudents.Columns["View"].Index)
                    {
                        string[] selectedColumns;
                        DataView dvStudents;

                        if (SGStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                        {
                            dt = filterStudents(cmdViewStudent.SelectedIndex);
                            DataTable data = dt;
                            switch (cmbGroupBy.SelectedIndex)
                            {
                                case 1:
                                    strmid = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ID"].Value).ToString();
                                    

                                    selectedColumns = new string[] { "Name","STMT_CONTACT_NO","STMT_FATHER_CONTACT","STMT_ADDRESS" };
                                    dvStudents = dt.AsDataView();
                                
                                    dvStudents.RowFilter = "STRM_ID = "+strmid;
                                    data = dvStudents.ToTable(true,selectedColumns);

                                    btnSaveViewToExcel.Visible = true;
                                    BtnViewSave.Visible = true;
                                    SGView.Visible = true;
                                    SGView.DataSource = data;

                                    SGStudents.Width = 526;
                                    SGStudents.Height = 402;
                                    formatGrid(1);
                                    break;
                                case 2:
                                    stdid = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ID"].Value).ToString();

                                    selectedColumns = new string[] { "Name", "STMT_CONTACT_NO", "STMT_FATHER_CONTACT", "STMT_ADDRESS" };
                                    dvStudents = dt.AsDataView();

                                    dvStudents.RowFilter = "STD_ID = " + stdid;
                                    data = dvStudents.ToTable(true, selectedColumns);

                                    SGView.Visible = true;
                                    SGView.DataSource = data;

                                    SGStudents.Width = 526;
                                    SGStudents.Height = 402;
                                    formatGrid(2);
                                    break;
                                case 3:

                                    batchid = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ID"].Value).ToString();

                                    selectedColumns = new string[] { "Name", "STMT_CONTACT_NO", "STMT_FATHER_CONTACT", "STMT_ADDRESS" };
                                    dvStudents = dt.AsDataView();

                                    dvStudents.RowFilter = "BTCH_ID = " + batchid;
                                    data = dvStudents.ToTable(true, selectedColumns);

                                    SGView.Visible = true;
                                    SGView.DataSource = data;
                                    

                                    SGStudents.Width = 526;
                                    SGStudents.Height = 402;
                                    formatGrid(3);
                                    break;
                                case 4:
                                    packageid = Convert.ToInt32(SGStudents.Rows[e.RowIndex].Cells["ID"].Value).ToString();

                                    selectedColumns = new string[] { "Name", "STMT_CONTACT_NO", "STMT_FATHER_CONTACT", "STMT_ADDRESS" };
                                    dvStudents = dt.AsDataView();

                                    dvStudents.RowFilter = "FPKG_ID = " + packageid;
                                    data = dvStudents.ToTable(true, selectedColumns);

                                    BtnViewSave.Visible = true;
                                    btnSaveViewToExcel.Visible = true;
                                    SGView.Visible = true;
                                    SGView.DataSource = data;

                                    SGStudents.Width = 526;
                                    SGStudents.Height = 402;
                                    formatGrid(4);
                                    break;
                                case 5:

                                    string g = SGStudents.Rows[e.RowIndex].Cells["Gender"].Value.ToString();

                                    selectedColumns = new string[] { "Name", "STMT_CONTACT_NO", "STMT_FATHER_CONTACT", "STMT_ADDRESS" };
                                    dvStudents = dt.AsDataView();

                                    dvStudents.RowFilter = "STMT_GENDER = '" + g+"'";
                                    data = dvStudents.ToTable(true, selectedColumns);

                                    SGView.Visible = true;
                                    SGView.DataSource = data;

                                    BtnViewSave.Visible = true;
                                    btnSaveViewToExcel.Visible = true;
                                    SGView.Visible = true;

                                    SGStudents.Width = 526;
                                    SGStudents.Height = 402;
                                    formatGrid(4);
                                    break;
                            }
                            BtnViewSave.Visible = true;
                            btnSaveViewToExcel.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        private void formatGrid(int identifier)
        {
            try
            {
                //Hiding Columns.

                //Hiding Columns.
                switch (identifier)
                {
                    case 1:

                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGView.Columns.Contains("Package"))
                            {
                                SGView.Columns["Package"].HeaderText = Lang.translate("Package");
                            }

                        }
                        else
                        {
                            if (SGView.Columns.Contains("Package"))
                            {
                                SGView.Columns["Package"].HeaderText = Lang.translate("Stream");
                            }
                        }
                        if (SGView.Columns.Contains("STRM_ID"))
                        {
                            SGView.Columns["STRM_ID"].Visible = false;
                        }
                        if (SGView.Columns.Contains("STMT_DEACTIVATED"))
                        {
                            SGView.Columns["STMT_DEACTIVATED"].Visible = false;
                        }

                        break;
                    case 2:

                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGView.Columns.Contains("Package"))
                            {
                                SGView.Columns["Package"].HeaderText = Lang.translate("PackageType");
                            }
                        }
                        else
                        {
                            if (SGView.Columns.Contains("Package"))
                            {
                                SGView.Columns["Package"].HeaderText = Lang.translate("Course");
                            }
                        }

                        if (SGView.Columns.Contains("STMT_DEACTIVATED"))
                        {
                            SGView.Columns["STMT_DEACTIVATED"].Visible = false;
                        }

                        if (SGView.Columns.Contains("STD_ID"))
                        {
                            SGView.Columns["STD_ID"].Visible = false;
                        }
                        break;
                    case 3:
                        if (SGView.Columns.Contains("BTCH_ID"))
                        {
                            SGView.Columns["BTCH_ID"].Visible = false;
                        }
                        if (SGView.Columns.Contains("Package"))
                        {
                            SGView.Columns["Package"].HeaderText = Lang.translate("Batch");
                        }

                        if (SGView.Columns.Contains("STMT_DEACTIVATED"))
                        {
                            SGView.Columns["STMT_DEACTIVATED"].Visible = false;
                        }
                        break;
                    case 4:
                        if (appName == "Gym" || appName == "Dance")
                        {
                            if (SGView.Columns.Contains("Package"))
                            {
                                SGView.Columns["Package"].HeaderText = Lang.translate("PackageName");
                            }
                        }
                        else
                        {
                            if (SGView.Columns.Contains("Package"))
                            {
                                SGView.Columns["Package"].HeaderText = Lang.translate("Package");
                            }

                        }

                        if (SGView.Columns.Contains("FPKG_ID"))
                        {
                            SGView.Columns["FPKG_ID"].Visible = false;
                        }
                        if (SGView.Columns.Contains("Start Date"))
                        {
                            SGView.Columns[6].DefaultCellStyle = UICommon.WinForm.GridDateFormat;

                        }
                        if (SGView.Columns.Contains(" To Date"))
                        {
                            SGView.Columns[" To Date"].HeaderText = "End Date";
                            SGView.Columns[7].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                        }

                        if (SGView.Columns.Contains("start"))
                        {
                            SGView.Columns["start"].HeaderText = "Start Date";
                        }

                        if (SGView.Columns.Contains("end_date"))
                        {
                            SGView.Columns["end_date"].HeaderText = "End Date";
                        }
                        break;
                }
                if (SGView.Columns.Contains("STAM_IS_ACTIVE"))
                {
                    SGView.Columns["STAM_IS_ACTIVE"].Visible = false;

                }
                //Changing HeaderTeaxt.
                if (SGView.Columns.Contains("STMT_CONTACT_NO"))
                {
                    SGView.Columns["STMT_CONTACT_NO"].HeaderText = "Contact No";
                }
                //  SGView.Columns["STMT_CONTACT_NO"].HeaderText = "Contact No";
                if (SGView.Columns.Contains("STMT_ADDRESS"))
                {
                    SGView.Columns["STMT_ADDRESS"].HeaderText = "Address";
                    SGView.Columns["STMT_ADDRESS"].Width = 120;

                }
                //  SGView.Columns["STMT_ADDRESS"].HeaderText = "Address";
                if (SGView.Columns.Contains("Name"))
                {
                    SGView.Columns["Name"].Width = 120;
                }



                //grid.Columns["FPKG_PACKAGE_NAME"].HeaderText = "Package";

                if (appName == "Gym" || appName == "Dance")
                {
                    if (SGView.Columns.Contains("Father Contact"))
                    {
                        SGView.Columns["Father Contact"].Visible = false;

                    }
                }
                else
                {
                    if (SGView.Columns.Contains("Father Contact"))
                    {
                        SGView.Columns["Father Contact"].Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void chkAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllBranch.Checked)
            {
                branchID = "%";
            }
            else
            {
                branchID = Program.LoggedInUser.BranchId.ToString();
            }
            dtStudent = BLL.StudentHandller.getAllStudents(Convert.ToString(branchID));
            SGStudents.DataSource = dtStudent;
            getcount(dtStudent);
            AssignEvents();
            cmbGroupBy.SelectedIndex = 0;
            UICommon.WinForm.setDate(dtpFrom, dtpTo);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmbGroupBy.SelectedIndex = 0;
                if (cmdViewStudent.SelectedIndex == 0)
                {
                    SGView.Visible = false;


                    DataTable dt = WinForm.ToDataTable(dtStudent.DefaultView.ToTable().AsEnumerable()
                                    .GroupBy(r => new { AdmissionNo = r.Field<int>("STMT_ADMISSION_NO"), Name = r.Field<string>("Name"), FatherContact = r.Field<string>("STMT_FATHER_CONTACT"), contact = r.Field<string>("STMT_CONTACT_NO"), Address = r.Field<string>("STMT_ADDRESS"), Email_Address = r.Field<string>("STMT_EMAIL_ID"), Source = r.Field<string>("Source") })
                                    .Select(g => new
                                    {
                                        STMT_ADMISSION_NO = g.Key.AdmissionNo,
                                        Name = g.Key.Name,
                                        // STAM_IS_ACTIVE = g.Key.active,
                                        AdmissionDate = g.Min(r => r.Field<DateTime>("STMT_ADMISSION_DATE")),
                                        STMT_CONTACT_NO = g.Key.contact,
                                        STMT_FATHER_CONTACT = g.Key.FatherContact,
                                        STMT_ADDRESS = g.Key.Address,
                                        STMT_EMAIL_ID = g.Key.Email_Address,
                                        Source = g.Key.Source,
                                        // Deactivated = g.Key.isDeactivated,
                                        //   MembershipNo = g.Key.Membership

                                    })
                                .ToList());
                    SGStudents.DataSource = dt;
                    formatviewallStudentgrid();
                    //  SGStudents.SetPagedDataSource(dt, bindingNavigator1);

                }
                else if (cmdViewStudent.SelectedIndex == 1)
                {
                    SGView.Visible = false;

                    DataTable dta = WinForm.ToDataTable(dtStudent.DefaultView.ToTable().AsEnumerable()
                                    .GroupBy(r => new { AdmissionNo = r.Field<int>("STMT_ADMISSION_NO"), isDeactivated = r.Field<string>("STMT_DEACTIVATED"), Name = r.Field<string>("Name"), FatherContact = r.Field<string>("STMT_FATHER_CONTACT"), contact = r.Field<string>("STMT_CONTACT_NO"), Address = r.Field<string>("STMT_ADDRESS"), active = r.Field<bool>("STAM_IS_ACTIVE"), Email_Address = r.Field<string>("STMT_EMAIL_ID"), Source = r.Field<string>("Source") })
                                    .Select(g => new
                                    {
                                        STMT_DEACTIVATED = g.Key.isDeactivated,
                                        STMT_ADMISSION_NO = g.Key.AdmissionNo,
                                        Name = g.Key.Name,
                                        STAM_IS_ACTIVE = g.Key.active,
                                        AdmissionDate = g.Min(r => r.Field<DateTime>("STMT_ADMISSION_DATE")),
                                        STMT_CONTACT_NO = g.Key.contact,
                                        STMT_FATHER_CONTACT = g.Key.FatherContact,
                                        STMT_ADDRESS = g.Key.Address,
                                        STMT_EMAIL_ID = g.Key.Email_Address,
                                        Source = g.Key.Source,
                                        // Deactivated = g.Key.isDeactivated,
                                        //   MembershipNo = g.Key.Membership

                                    }).Where(stud => stud.STMT_DEACTIVATED == ((cmdViewStudent.SelectedIndex == 2) ? "Yes" : "No") & stud.STAM_IS_ACTIVE != ((cmdViewStudent.SelectedIndex == 3)))
                                    .ToList());
                    SGStudents.DataSource = dta;
                    formatviewallStudentgrid();
                    //  SGStudents.SetPagedDataSource(dta, bindingNavigator1);
                }
                else if (cmdViewStudent.SelectedIndex == 2)
                {
                    SGView.Visible = false;
                    DataTable dtd = WinForm.ToDataTable(dtStudent.DefaultView.ToTable().AsEnumerable()
                                    .GroupBy(r => new { AdmissionNo = r.Field<int>("STMT_ADMISSION_NO"), isDeactivated = r.Field<string>("STMT_DEACTIVATED"), Name = r.Field<string>("Name"), FatherContact = r.Field<string>("STMT_FATHER_CONTACT"), contact = r.Field<string>("STMT_CONTACT_NO"), Address = r.Field<string>("STMT_ADDRESS"), Email_Address = r.Field<string>("STMT_EMAIL_ID"), Source = r.Field<string>("Source") })
                                    .Select(g => new
                                    {
                                        STMT_ADMISSION_NO = g.Key.AdmissionNo,
                                        Name = g.Key.Name,
                                        //    STAM_IS_ACTIVE = g.Key.active,
                                        AdmissionDate = g.Min(r => r.Field<DateTime>("STMT_ADMISSION_DATE")),
                                        STMT_CONTACT_NO = g.Key.contact,
                                        STMT_FATHER_CONTACT = g.Key.FatherContact,
                                        STMT_ADDRESS = g.Key.Address,
                                        STMT_EMAIL_ID = g.Key.Email_Address,
                                        STMT_DEACTIVATED = g.Key.isDeactivated,
                                        //   MembershipNo = g.Key.Membership
                                        Source = g.Key.Source,
                                    }).Where(stud => stud.STMT_DEACTIVATED == "Yes")
                                    .ToList());
                    SGStudents.DataSource = dtd;
                    formatviewallStudentgrid();
                    //  SGStudents.SetPagedDataSource(dtd, bindingNavigator1);

                }
                else if (cmdViewStudent.SelectedIndex == 3)
                {
                    SGView.Visible = false;

                    DataTable dte = WinForm.ToDataTable(dtStudent.DefaultView.ToTable().AsEnumerable()
                                    .GroupBy(r => new { AdmissionNo = r.Field<int>("STFL_ADMISSION_NO"), Name = r.Field<string>("Name"), FatherContact = r.Field<string>("STMT_FATHER_CONTACT"), contact = r.Field<string>("STMT_CONTACT_NO"), Address = r.Field<string>("STMT_ADDRESS"), active = r.Field<bool>("STAM_IS_ACTIVE"), Email_Address = r.Field<string>("STMT_EMAIL_ID"), Source = r.Field<string>("Source") })
                                    .Select(g => new
                                    {
                                        STMT_ADMISSION_NO = g.Key.AdmissionNo,
                                        Name = g.Key.Name,
                                        STAM_IS_ACTIVE = g.Key.active,
                                        AdmissionDate = g.Min(r => r.Field<DateTime>("STMT_ADMISSION_DATE")),
                                        STMT_CONTACT_NO = g.Key.contact,
                                        STMT_FATHER_CONTACT = g.Key.FatherContact,
                                        STMT_ADDRESS = g.Key.Address,
                                        STMT_EMAIL_ID = g.Key.Email_Address,
                                        Source = g.Key.Source
                                    }).Where(stud => stud.STAM_IS_ACTIVE == (cmdViewStudent.SelectedIndex == 2))
                                    .ToList());
                    SGStudents.DataSource = dte;
                    formatviewallStudentgrid();
                    //     SGStudents.SetPagedDataSource(dte, bindingNavigator1);

                }
                else
                {
                    if (cmbGroupBy.SelectedIndex == 0 || cmbGroupBy.SelectedIndex == 1 || cmbGroupBy.SelectedIndex == 2 || cmbGroupBy.SelectedIndex == 3 || cmbGroupBy.SelectedIndex == 4 || cmbGroupBy.SelectedIndex == 5)
                    {

                    }
                }

                //   SGStudents.SetPagedDataSource(dte, bindingNavigator1);






                // formatviewallStudentgrid();
                //    SGStudents.DataSource = dt;


                if (SGStudents.Rows.Count != 0)
                {

                    //    //  SGStudents.DataSource = dtStudent;

                    //  SGStudents.DataSource = SGStudents;
                    Common.ImportExport.ImportToExcel(SGStudents, null);


                    //  IndexSelection(cmbGroupBy.SelectedIndex);

                }


                else
                {
                    WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        private void btnNewRegistration_Click(object sender, EventArgs e)
        {
            try
            {

                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                string[] assmbly = { appName };
                FormFactory.GetForm(Forms.FrmRegistrationForm, null, false, assmbly).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        private void showBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dtbyDate = dtStudent.DefaultView.ToTable();
                dtbyDate = BLL.StudentHandller.getAllStudents(Convert.ToString(branchID), dtpFrom.Value, dtpTo.Value);
                considerGroupBy = false;
                SGStudents.DataSource = dtbyDate;
                considerGroupBy = true;
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SGView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if(SGView.Columns.Contains("STMT_FATHER_CONTACT"))
                {
                    SGView.Columns["STMT_FATHER_CONTACT"].HeaderText = "Father Contact";
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }

        }
        private void SGView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(SGStudents, e);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnSaveViewToExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (SGView.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(SGView, null);
                }
                else
                {
                    WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFName.Text.ToString();
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpTo.Value);
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFrom.Value);
                getParameter.View = "View:- " + cmdViewStudent.SelectedItem.ToString();
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Member Report";
                getParameter.BranchName = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                getParameter.GroupBy = "GroupBy:- " + cmbGroupBy.SelectedItem.ToString();
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (SGStudents.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Member Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(SGStudents, pathTosave, getParameter);
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

        private void BtnViewSave_Click(object sender, EventArgs e)
        {
            try
            {
                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFName.Text.ToString();
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpTo.Value);
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFrom.Value);
                getParameter.View = "View:- " + cmdViewStudent.SelectedItem.ToString();
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Member Report";
                getParameter.BranchName = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                getParameter.GroupBy = "GroupBy:- " + cmbGroupBy.SelectedItem.ToString();
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (SGView.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Member Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(SGView, pathTosave, getParameter);
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

                WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
    }
}



