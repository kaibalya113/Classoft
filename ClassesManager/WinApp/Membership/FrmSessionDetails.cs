using ClassManager.BLL;
using ClassManager.Info;
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
    public partial class FrmSessionDetails : FrmParentForm
    {
        Info.Faculty objFaculty;
        //Program.LoggedInUser.BranchId
        public FrmSessionDetails()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

               
                if(memberslist.Items != null)
                {

                }else
                {
                    memberslist.Items.Clear();
                    //if instructor is selected then this function will call. or show 
                    // load packages based on instructor
                    
                }
                if (cmbStream.SelectedIndex >= 0)
                {
                    int id = ((ClassManager.Info.ComboItem)cmbStream.SelectedItem).key;
                    // mmebers error showing 0 id for every one
                    List<Info.Student> dt = BLL.FacultyHandler.getMembers(id);
                    // memberslist.DataSource = dt;

                    //  List<Faculty> lstFclt = StreamHandller.getFaculty(Program.LoggedInUser.BranchId);
                    foreach (Info.Student objStudnet in dt)
                    {
                        int id1 = objStudnet.AdmisionNo;
                        int no = objStudnet.AdmissionNo;
                        string n = objStudnet.MembershipNo;
                        memberslist.Items.Add(new ComboItem(objStudnet.AdmissionNo, objStudnet.Fname + " " + objStudnet.Mname + " " + objStudnet.Lname));
                    }

                }
                // DataTable dt = BLL.FacultyHandler.getFacultyProgram(txtMbrsNo.Text); ; 
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
              //  UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void filterData()
        {
            try
            {
                dataGridView1.DataSource = null;


                // DataTable dtFeesCollection = WinForm.ToDataTable(FeesHandller.getFeesCollectionReport(branchID, Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate)));
                //ADGVFeesReport.DataSource = dtFeesCollection;
                // calculateProfLoss(dtFeesCollection);
                //LoadData();
                int? faculty=0;
                int? member = 0;
                int selectedFaculty;
                int selectedmembers;
                
                try
                {
                    selectedFaculty = Convert.ToInt32(cmbStream.SelectedValue);
                  //  selectedFaculty = ((ClassManager.Info.ComboItem)cmbStream.SelectedItem).key;
                   
                         //((cmbInstructor.SelectedItem as ComboItem).key);
                         //((ClassManager.Info.ComboItem)cmbInstructor.SelectedItem).key;
                         //Convert.ToInt32(cmbInstructor.SelectedValue).;
                    if (selectedFaculty != 0)
                    {
                        faculty = selectedFaculty;
                    }

                }
                catch(Exception ex)
                {

                }
                try
                {
                     selectedmembers = ((ClassManager.Info.ComboItem)memberslist.SelectedItem).key;
                  //  memberslist.DataSource
                    if (selectedmembers != 0)
                    {
                        member = selectedmembers;
                    }
                }
                catch (Exception ex)
                {

                }
                
                string Fromdate = dtpAttdToDate.Value.ToShortDateString();
                string Todate = dtpAttdFromDate.Value.ToShortDateString();
                string student = "";
                int branchID = Program.LoggedInUser.BranchId;
                
                DataTable dtFeesCollections = StreamHandller.getSeesionslist(branchID.ToString(), dtpAttdFromDate.Value, dtpAttdToDate.Value, member, faculty);
                BindingSource bs = new BindingSource();
              //  bs.DataSource = dtFeesCollections;
                
                dataGridView1.DataSource = dtFeesCollections;
                formatview();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void formatview()
        {
            try
            {
                dataGridView1.Columns["SESSION_ID"].HeaderText = "ID";
                dataGridView1.Columns["INSTRUCTOR_ID"].HeaderText = "Instructor ID";
                dataGridView1.Columns["MEMBER_ID"].HeaderText = "Member ID";
                dataGridView1.Columns["DATE"].HeaderText = "Date";
                dataGridView1.Columns["DATETIME"].HeaderText = "Date Time";
                dataGridView1.Columns["PACKAGE_ID"].HeaderText = "Package ID";
                dataGridView1.Columns["REMARRK"].HeaderText = "Remark";
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    //    try
    //        {
    //            if (objFaculty != null)
    //            {
    //                txtPaidTo.Text = objFaculty.Name;
    //               // comboIndirectExpenses.Name = "salary";

    //            }
    //            reloadExpense();
    //comboIndirectExpenses.SelectedIndex = 1;
    //            // isFormClear = true;
    //            //  return true;
    //        }

        private void LoadFaculty()
        {
            try
            {
                cmbStream.Items.Clear();
              //  cmbStream.Items.Add(new ComboItem("-1", "All"));lka
            //  Faculty is done 
                    List<Faculty> lstFclt = StreamHandller.getFaculty(Program.LoggedInUser.BranchId);
                    foreach (Info.Faculty objFaculty in lstFclt)
                    {
                        cmbStream.Items.Add(new ComboItem(objFaculty.FacultyID.ToString(), objFaculty.Name));
                    }
                
             //   LoadBatches(-1);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FrmSessionDetails_Load(object sender, EventArgs e)
        {
            //  cmbStream.Items.Add(new ComboItem(-1, "All"));
            // cmbStream.SelectedIndex = 0;
            // load student sessions
            if (this.IsMdiChild != true)
            {
                // showCurrentFacultyDetails(objFaculty);
                if (cmbStream.SelectedIndex >= 0)
                {
                    int id = Convert.ToInt32(cmbStream.SelectedValue);
                    // mmebers error showing 0 id for every one
                    List<Info.Student> dt = BLL.FacultyHandler.getMembers(id);
                    // memberslist.DataSource = dt;

                    //  List<Faculty> lstFclt = StreamHandller.getFaculty(Program.LoggedInUser.BranchId);
                    foreach (Info.Student objStudnet in dt)
                    {
                        int id1 = objStudnet.AdmisionNo;
                        int no = objStudnet.AdmissionNo;
                        string n = objStudnet.MembershipNo;
                        memberslist.Items.Add(new ComboItem(objStudnet.AdmissionNo, objStudnet.Fname + " " + objStudnet.Mname + " " + objStudnet.Lname));
                    }

                }else
                {
                    filterData();
                }
               
            }
            else
            {
                //loadSingleFaculty(info.Faculty objFaculty);
               
                LoadFaculty();
                DataTable dt = StreamHandller.getSeesions(Program.LoggedInUser.BranchId);
                dataGridView1.DataSource = dt;
                formatSessionGrid();

            }
        }
        private void formatSessionGrid()
        {
            try
            {
               
                dataGridView1.Columns["FacilityName"].HeaderText = "Facility";
                dataGridView1.Columns["STFL_PACKAGE_ID"].Visible = false;
                dataGridView1.Columns["STFL_ADMISSION_NO"].Visible = false;

               



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cmbStream1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            filterData();
        }

        internal void showCurrentFacultyDetails(Faculty objFaculty)
        {
            loadSingleFaculty(objFaculty);
        }

        private void loadSingleFaculty(Faculty objFaculty)
        {
            try
            {
                cmbStream.Items.Clear();
               
                List<Faculty> lstFclt = StreamHandller.getFacultyByID(objFaculty.FacultyID);
                //foreach (Info.Faculty objFaculty1 in lstFclt)
                //{
                //    cmbStream.Items.Add(new ComboItem(objFaculty1.FacultyID.ToString(), objFaculty1.Name));

                //}
                //cmbStream.SelectedIndex = -1;
                // cmbStream1_SelectedIndexChanged();
                cmbStream.ValueMember = "FacultyID";
                cmbStream.DisplayMember = "Name";
               // cmbStream.ValueMember = "ID";
                cmbStream.DataSource = lstFclt;
                int id = objFaculty.FacultyID;
                DataTable dt = StreamHandller.getSeesionsById(id);
                dataGridView1.DataSource = dt;
                //formatSessionGrid();
                formatview();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
