using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.Membership;
using ClassManager.WinApp.UICommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassManager.WinApp
{
    public partial class FrmInstructorDetails : FrmParentForm
    {
        bool bAllowIndexChange = false;
        string sCaption = "Faculty Details";
        RolePrivilege formPrevileges;
        List<ComboItem> lstInstructorDetails = new List<ComboItem>();
        public static Info.Faculty objFaculty;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        public FrmInstructorDetails()
        {
            InitializeComponent();
        }

        private void FrmInstructorDetails_Load(object sender, EventArgs e)
        {
            try
            {
                branchID = Program.LoggedInUser.BranchId.ToString();
                lstInstructorDetails.Add(new ComboItem(-1, "Select Member"));
                lstInstructorDetails.AddRange(BLL.FacultyHandler.getFacultList(branchID));
                StudName.DataSource = new List<Faculty>();
                StudName.DisplayMember = "name";
                StudName.DataSource = lstInstructorDetails;

                // then you have to set the PropertySelector like this:
                StudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);
                if (this.IsMdiChild != true)
                {
                    ApplyPrevileges();
                    StudName.Text = objFaculty.Name;
                }
                else
                {
                    materialTabSelector1.BaseTabControl = tabMain;

                    DataGridViewCheckBoxColumn isFollowpClosed = new DataGridViewCheckBoxColumn();
                    isFollowpClosed.Name = "chkbxisClosed";
                    isFollowpClosed.HeaderText = "Close";
                   
                    ofdImage.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";
                    dtpDOB.MaxDate = DateTime.Now.AddYears(-2);
                    
                    List<ComboItem> lstBatch = new List<ComboItem>();

                    assignValidationEvents();
                    AssignEvents();
                    clearForm();
                   
                    
                   // lnlTotalFees.Visible = true;
                    //lnklblviewHistory.Visible = true;
                    tabMain.Visible = false;
                    formatForm();
                    
                    ApplyPrevileges();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if ( StudName.SelectedIndex > 0 && StudName.SelectedItem != null)
                {
                    loadFaculty((StudName.SelectedItem as ComboItem).key);

                    tabMain.SelectedIndex = 3;
                    //Doubtfull
                    {

                       // showExamDetails();
                        //cmbTests.DisplayMember = "TestName";
                        //cmbTests.ValueMember = "TestId";
                        //populateOnlyTest();
                    }
                    //Doubtfull
                }
                //panelReceipt.Height = 316;
                //panelReceipt.Width = 841;
                //ADGVReceipt.Height = 316;
                //ADGVReceipt.Width = 841;
                //panelInvoiceGenerate.Visible = false;
                //ADGVInvoice.Visible = false;
            }
            catch (Exception ex)
            {
              //  UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        public  void loadFaculty(int admissionNo = -1)
        {
            try
            {
                if (admissionNo == -1)
                {
                    admissionNo = (objFaculty != null) ? objFaculty.FacultyID : -1;
                }

                if (admissionNo == -1)
                {
                    throw new Common.Exceptions.RecordNotFoundException("Student details not exists");
                }


                objFaculty = BLL.FacultyHandler.getFacultiesByID(admissionNo, Program.LoggedInUser.BranchId);
                populateData();
                ApplyPrevileges();
            }
            catch (Exception ex)
            {

               // UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        private void populateData()
        {
            try
            {
                clearForm();

                if (objFaculty == null)
                {
                    tabMain.Visible = false;
                  //  UICommon.WinForm.showStatus("No search found.\n\n Please enter valid Contact No", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    
                    txtContctNo.Text = "";
                    txtContctNo.Focus();

                }
                else
                {
                    //  addColumns();

                    StudName.Text = objFaculty.Name;
                    //cmdBrwseImg.Visible = true;
                   // assignValueToControls(objFaculty);
                    tabMain.Visible = true;
                    tabMain.SelectedIndex = 0;
                  

                    showPersonnelDetails(objFaculty);
                    
                    ApplyPrevileges();
                  
                    // displaying package tab when StudName.selectedIndexChange
                    tabMain.SelectedIndex = 3;

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void showPersonnelDetails(Info.Faculty objFaculty)
        {
            try
            {
                txtMbrsNo.Text = objFaculty.FacultyID.ToString();
                txtAddress.Text = objFaculty.Address;
                txtFName.Text = objFaculty.Name;
                txtBiometric.Text = objFaculty.BiometricId.ToString();
                txtNewContact.Text = objFaculty.ContactNo;
                txtEmailID.Text = objFaculty.EmailId;
                lblSName.Text = objFaculty.Name;
                lblAdmissionNo.Text = objFaculty.FacultyID.ToString();
                txtBloodgrp.Text = objFaculty.Pancard;
                lblMmbrNo.Text = objFaculty.FacultyID.ToString();
                adharcardtxt.Text = objFaculty.AdharCard.ToString();
                //txtWght.Text = objFaculty.;
                //txtBMI.Text = objFaculty.BMI;
                if(objFaculty.AddressProof == null)
                {
                    materialSingleLineTextField1.Text = "";
                }else
                {
                    materialSingleLineTextField1.Text = objFaculty.AddressProof.ToString();
                }
               if(objFaculty.IDPROOF == null)
                {
                    txtID.Text = "";
                }else
                {
                    txtID.Text = objFaculty.IDPROOF.ToString();
                }
                
                if (objFaculty.Resume == null || objFaculty.Resume == "")
                {
                    txtResume.Text = "";
                }
                else
                {
                    txtResume.Text = objFaculty.Resume.ToString();
                }
                qualificationbox.Text = objFaculty.Qualification.ToString();
                txtBiometric.Text = objFaculty.BiometricId.ToString();
                //txtBMI.Text = objStudent.FatherContactNo;
                if (objFaculty.DOb != null && (objFaculty.DOb >= dtpDOB.MinDate && objFaculty.DOb <= dtpDOB.MaxDate))
                {
                    dtpDOB.Value = objFaculty.DOb;
                }
               // lblAdmsnDate.Text = Common.Formatter.FormatDate(objFaculty.);
                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objFaculty.PhotoURL.ToString();

                try
                {

                    pbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                }
                catch (Exception ex)
                {
                    pbPhoto.Image = Properties.Resources.img;
                    Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for member : " + objFaculty.FacultyID, Common.ErrorLevel.INFORMATION);
                }
                // txtBloodgrp.Text = objStudent.FatherName;


                //GetBatch();
                //cmbBatch.Text = "";
                //cmbBatch.Items.Clear();
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpAttdFromDate, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpAttdToDate, Common.Formatter.DateFormat);
                //UICommon.WinForm.formatDateTimePicker(dtpReceiptToDate, Common.Formatter.DateFormat);
                //UICommon.WinForm.formatDateTimePicker(dtpReceiptFrmDate, Common.Formatter.DateFormat);

                dtpAttdFromDate.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void AssignEvents()
        {

           

            ADGVAttendance.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVAttendance.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVInstDetails.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVInstDetails.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            ADGVStudentFacility.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVStudentFacility.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        private void clearForm()
        {
            lblAdmissionNo.Text = "";
            txtContctNo.Text = "";
            txtAddress.Text = "";
            txtFName.Text = "";
            
            txtNewContact.Text = "";
            txtEmailID.Text = "";
            lblSName.Text = "";
            
            //txtBMI.Text = "";
            dtpDOB.Text = "";
           // lblAdmsnDate.Text = "";
           
            txtBloodgrp.Text = "";
            pbPhoto.Image = Properties.Resources.img;
           
            //lblPayStartDate.Text = "";
            //lblTotalFees.Text = "";
            //lblTotalFees.Text = "";
            //lblPendingFees.Text = "";
            lblMmbrNo.Text = "";
          
            ADGVAttendance.DataSource = null;
            ADGVInstDetails.DataSource = null;
            ADGVStudentFacility.DataSource = null;
           
            txtMbrsNo.Text = "";
            // cmbStud.SelectedIndex = 0;

        }
        private void assignValidationEvents()
        {
            txtContctNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            //txtBMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtNewContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
           // txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            //txtWght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
           // txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            // txtBloodgrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            // txtheight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }

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
                        btnUpdate.Visible = false;
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                        ADGVStudentFacility.Columns["btnEdit"].Visible = false;
                        ADGVStudentFacility.Columns["btnUpgrade"].Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                      
                        btnPayFees.Visible = false;
                       
                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                    if (formPrevileges.View == false)
                    {
                        ADGVStudentFacility.Columns["btnDelete"].Visible = false;
                        ADGVStudentFacility.Columns["btnEdit"].Visible = false;
                        ADGVStudentFacility.Columns["btnUpgrade"].Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Save"].Index && dataGridView1.Columns.Contains("Save")) // ADGVReceipt.Columns.Contains("Cancel")
                {

                    string inTime = dataGridView1.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].Value.ToString();

                    int instructureID = objFaculty.FacultyID;
                    string studentID = dataGridView1.Rows[e.RowIndex].Cells["STFL_ADMISSION_NO"].Value.ToString();

                    string date = dataGridView1.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].Value.ToString();
                    if(date == "")
                    {
                        date = DateTime.Now.ToString("yyyy-MM-dd");
                    }else
                    {

                    }
                    DateTime date11 = DateTime.Parse(date);
                    string date1 = date11.Date.ToString("yyyy-MM-dd");
                    string packageID = dataGridView1.Rows[e.RowIndex].Cells["STFL_PACKAGE_ID"].Value.ToString();
                    bool mark = true;
                    string datetime = dataGridView1.Rows[e.RowIndex].Cells["ATTD_IN_TIME"].Value.ToString();
                    if (datetime == "")
                    {
                        datetime = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else
                    {

                    }
                    DateTime dateTIme = DateTime.Parse(datetime);
                    string remark = null;
                    DataTable dt = BLL.FacultyHandler.checkFacultyStatus(packageID, instructureID, studentID, date1, dateTIme, remark, mark);
                    if (dt.Rows.Count > 0)
                    {
                        UICommon.WinForm.showMessage("This Member already marked for today.", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);

                    }
                    else
                    {
                        BLL.FacultyHandler.updateFacultyStatus(packageID, instructureID, studentID, date1, dateTIme, remark, mark);
                        UICommon.WinForm.showMessage("This Member has been marked Sucessfully for today.", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                        loadFaculty(objFaculty.FacultyID);
                    }


                }
            }catch(Exception ex)
            {
                throw ex;
            }
           
            


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabMain.SelectedIndex == 3)
                {
                    DataTable dt = BLL.FacultyHandler.getFacultyProgram(txtMbrsNo.Text);
                    dataGridView1.DataSource = dt;
                    formatFacultyGrid();
                    //if (dt.Rows.Count == 0)
                    //{
                    //    button7.Visible = false;
                    //}
                    //int count = dt.Rows.Count;
                }
                else if (tabMain.SelectedIndex == 1)
                {
                    // DataTable dt = BLL.FacultyHandler.getFacultySalary(txtMbrsNo.Text);

                    // decimal slry = Convert.ToDecimal(dt.Rows[0][0]);

                    DataTable dt = BLL.FacultyHandler.getFacultySalary(txtFName.Text);
                    salarytable.DataSource = dt;
                    formatSalaryGrid();

                } else if (tabMain.SelectedIndex == 2)
                {
                    DataTable dt = BLL.FacultyHandler.getFacultyAttendance(txtMbrsNo.Text);
                    attendance.DataSource = dt;
                    formatFaculty();
                }
            }
            catch(Exception ex)
            {

            }
            
        }
        private void formatSalaryGrid()
        {
            try
            {

                salarytable.Columns["PaymentMode"].HeaderText = "PaymentMode";

                // width
                salarytable.Columns["Date"].Width = 200;
                salarytable.Columns["Amount"].Width = 150;
                salarytable.Columns["Mode"].Width = 150;
                salarytable.Columns["PaymentMode"].Width = 150;

                salarytable.Columns["Description"].Width = 150;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        private void formatFaculty()
        {
            try
            {
                attendance.Columns["ATTD_DATE"].HeaderText = "Date";

                attendance.Columns["time"].HeaderText = "In Time";

                attendance.Columns["time1"].HeaderText = "Out Time";
                attendance.Columns["TotalTime"].HeaderText = "Total Time";
                attendance.Columns["ATTD_BIOMETRIC_ID"].Visible = false;
                attendance.Columns["ATTD_STATUS"].HeaderText = "Status";

                // width
                attendance.Columns["ATTD_DATE"].Width = 200;
                attendance.Columns["time"].Width = 150;
                attendance.Columns["time1"].Width = 150;
                attendance.Columns["TotalTime"].Width = 150;

                attendance.Columns["ATTD_STATUS"].Width = 150;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void formatFacultyGrid()
        {
            try
            {
                if (!dataGridView1.Columns.Contains("save"))
                {

                    dataGridView1.Columns.Add(new DataGridViewImageColumn()
                    {
                        Image = Properties.Resources.Add,
                        Name = "Save",
                        HeaderText = "Save Session"
                    });
                }




                //Changing HeaderText
              //  dataGridView1.Columns["Id"].HeaderText = "ID";
                dataGridView1.Columns["FacilityName"].HeaderText = "Facility";
                dataGridView1.Columns["STFL_PACKAGE_ID"].Visible = false;
                dataGridView1.Columns["STFL_ADMISSION_NO"].Visible = false;
                //  dataGridView1.Columns["FCLT_MARK_SESSION"].HeaderText = "MARK";
                //_SESSION, ATTD_IN_TIME
                dataGridView1.Columns["STMT_FNAME"].HeaderText = "Name";
                dataGridView1.Columns["ATTD_IN_TIME"].HeaderText = "IN TIME";

                // width
                dataGridView1.Columns["FacilityName"].Width = 200;
                dataGridView1.Columns["STMT_FNAME"].Width = 150;
                dataGridView1.Columns["STFL_PACKAGE_ID"].Width = 150;
                dataGridView1.Columns["STFL_ADMISSION_NO"].Width = 150;
                //   dataGridView1.Columns["FCLT_MARK_SESSION"].Width = 150;
                dataGridView1.Columns["Save"].DisplayIndex = 0;
                dataGridView1.Columns["ATTD_IN_TIME"].Width = 150;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                    Info.Faculty objFaculty = new Info.Faculty();

                    objFaculty.Name = txtFName.Text;
                    objFaculty.Address = txtAddress.Text;
                    objFaculty.ContactNo = txtNewContact.Text;
                    objFaculty.EmailId = txtEmailID.Text;
                    objFaculty.branchId = Program.LoggedInUser.BranchId;
                    objFaculty.Pancard = txtBloodgrp.Text.ToString();
                    objFaculty.AdharCard = adharcardtxt.Text.ToString();
                    objFaculty.Qualification = qualificationbox.Text.ToString();
                //saving file 
                string savePath = SysParam.getValue<string>(SysParam.Parameters.RESUME);
                bool exists = System.IO.Directory.Exists(savePath);
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }
                    
                string file = txtResume.Text.ToString();
                string filePath = txtResume.Text.ToString();
                filePath = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filePath);
                filePath = filePath.Split('.')[0].Trim();
                filePath = filePath + "_" + objFaculty.Name + "" + ext;

                savePath += Path.GetFileName(filePath);

                //csvFilePath.FileName.ToString();
                if (file != "")
                {
                    if (!File.Exists(savePath))
                    {
                        File.Copy(file, savePath);
                        objFaculty.Resume = savePath;
                    }
                    else
                    {
                        objFaculty.Resume = savePath;
                    }
                }else
                {
                    objFaculty.Resume = null;
                }

                // save Address proof
                string saveAddress = SysParam.getValue<string>(SysParam.Parameters.ADDRESS_PROOF);
                bool exists1 = System.IO.Directory.Exists(saveAddress);
                if (!exists1)
                {
                    System.IO.Directory.CreateDirectory(saveAddress);
                }
                string address = materialSingleLineTextField1.Text;
                string addressPath = materialSingleLineTextField1.Text.ToString();
                addressPath = Path.GetFileName(addressPath);
                string fileext = Path.GetExtension(addressPath);
                addressPath = addressPath.Split('.')[0].Trim();
                addressPath = addressPath + "_" + objFaculty.Name + "" + fileext;

                saveAddress += Path.GetFileName(addressPath);

                //csvFilePath.FileName.ToString();
                if (address != "")
                {
                    if (!File.Exists(saveAddress))
                    {
                        File.Copy(address, saveAddress);
                        objFaculty.AddressProof = saveAddress;
                    }
                    else { objFaculty.AddressProof = saveAddress; }
                }
                else
                {
                    objFaculty.AddressProof = null;
                }
               
                // save ID proof
                string saveID = SysParam.getValue<string>(SysParam.Parameters.ADDRESS_PROOF);
                bool exists11 = System.IO.Directory.Exists(saveID);
                if (!exists11)
                {
                    System.IO.Directory.CreateDirectory(saveID);
                }
                string id = txtID.Text;
                string idPath = txtID.Text.ToString();
                idPath = Path.GetFileName(idPath);
                string fileext1 = Path.GetExtension(idPath);
                idPath = idPath.Split('.')[0].Trim();
                idPath = idPath + "_" + objFaculty.Name + "" + fileext1;

                saveID += Path.GetFileName(idPath);

                //csvFilePath.FileName.ToString();
                if (id != "")
                {

                    if (!File.Exists(saveID))
                    {
                        File.Copy(id, saveID);
                        objFaculty.IDPROOF = saveID;

                    }
                    else
                    { objFaculty.IDPROOF = saveID; }
                }else
                {
                    objFaculty.IDPROOF = null;
                }
                objFaculty.ImgPhoto = pbPhoto.Image;

                    objFaculty.BiometricId = Convert.ToInt64(txtBiometric.Text);
                    objFaculty.DOb = dtpDOB.Value;
                    objFaculty.FacultyID = Int32.Parse(txtMbrsNo.Text);
               
                FacultyHandler.updatefacultyPersnlDtl(objFaculty);
                    UICommon.WinForm.showStatus("Details Updated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                // this.Close();
                loadFaculty(objFaculty.FacultyID);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            objFaculty.Name = txtFName.Text;
            //  FrmExpenses 
            string[] name = { "Gym" };

            FrmExpenses objExpence = (FrmExpenses)UICommon.FormFactory.GetForm(Forms.FrmExpenses, this, true, name, null);
            objExpence.loadValuesForUpdate(objFaculty);
            objExpence.ShowDialog();
           
           // v
                            
            //BindingSource bs = new BindingSource();
            //bs.DataSource = BLL.EnquiryHandller.GetAllEnquries(branchID.ToString(), -1);
            //cmbViewEnquiry.SelectedIndex = 1;
            //SGStudents.SetPagedDataSource((bs.List as DataView).ToTable(), bindingNavigator1);

            this.Visible = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog csvFilePath = new OpenFileDialog();
                csvFilePath.InitialDirectory = Application.ExecutablePath.ToString();

                csvFilePath.RestoreDirectory = true;
                if (csvFilePath.ShowDialog() == DialogResult.OK)
                {
                    txtResume.Text = csvFilePath.FileName.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdmissionNo.Text != "")
                {
                    Int32 admissionNo = 0;
                    if (Int32.TryParse(txtAdmissionNo.Text, out admissionNo))
                    {
                        objFaculty = FacultyHandler.getFacultiesByID(admissionNo, Program.LoggedInUser.BranchId);
                    }

                    if (objFaculty == null)
                    {
                        objFaculty = FacultyHandler.getFacultiesByID( Program.LoggedInUser.BranchId, admissionNo);
                    }
                }
               

                populateData();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                clearForm();
                tabMain.Visible = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                //this.button4.Text = objFaculty.Resume;
               if(objFaculty.Resume != null)
                {
                    Resume objResume = new Resume();
                    objResume.showFile(objFaculty.Resume);
                    objResume.ShowDialog();
                }else
                {
                    this.button4.Visible = false;
                }
                

            

        }
        private void button5_Click(object sender, EventArgs e)
        {

            //this.button4.Text = objFaculty.Resume;
            if (objFaculty.AddressProof != null)
            {
                Resume objResume = new Resume();
                objResume.showFile(objFaculty.AddressProof);
                objResume.ShowDialog();
            }
            else
            {
                this.button5.Visible = false;
            }




        }
        private void button6_Click(object sender, EventArgs e)
        {

            //this.button4.Text = objFaculty.Resume;
            if (objFaculty.IDPROOF != null)
            {
                Resume objResume = new Resume();
                objResume.showFile(objFaculty.IDPROOF);
                objResume.ShowDialog();
            }
            else
            {
                this.button6.Visible = false;
            }




        }
        private void btnAddress_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog csvFilePath = new OpenFileDialog();
                csvFilePath.InitialDirectory = Application.ExecutablePath.ToString();

                csvFilePath.RestoreDirectory = true;
                if (csvFilePath.ShowDialog() == DialogResult.OK)
                {
                    materialSingleLineTextField1.Text = csvFilePath.FileName.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog csvFilePath = new OpenFileDialog();
                csvFilePath.InitialDirectory = Application.ExecutablePath.ToString();

                csvFilePath.RestoreDirectory = true;
                if (csvFilePath.ShowDialog() == DialogResult.OK)
                {
                    txtID.Text = csvFilePath.FileName.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dataGridView1.DataSource as DataTable;
            foreach (DataRow dtRows in dt.Rows)
            {
                bool mark = (bool)dtRows["FCLT_MARK_SESSION"];
                if (mark == true)
                {
                    string inTime = dtRows["ATTD_IN_TIME"].ToString();
                    int instructureID = objFaculty.FacultyID;
                    string studentID = dtRows["STFL_ADMISSION_NO"].ToString();
                    DateTime date = (DateTime)dtRows["ATTD_IN_TIME"];//only date
                    string date1 = date.Date.ToString("yyyy-MM-dd");
                    string packageID = dtRows["STFL_PACKAGE_ID"].ToString();
                    // date1 = DateTime.Parse(date1); Common.Formatter.formatTime(outTime)
                    DateTime dateTIme = (DateTime)dtRows["ATTD_IN_TIME"];
                    string remark = null;
                    BLL.FacultyHandler.updateFacultyStatus(packageID, instructureID, studentID,  date1, dateTIme, remark, mark);
                   
                }


            }
            UICommon.WinForm.showStatus("Details Updated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            loadFaculty(objFaculty.FacultyID);
        }
       
        private void button8_Click(object sender, EventArgs e)
        {
            objFaculty.Name = txtFName.Text;
            //  FrmExpenses 
            string[] name = { "Gym" };
           
            FrmSessionDetails objExpence = (FrmSessionDetails)UICommon.FormFactory.GetForm(Forms.FrmSessionDetails, this, true, name, null);
            objExpence.showCurrentFacultyDetails(objFaculty);
            //new FrmSessionDetails();
            //(FrmSessionDetails)UICommon.FormFactory.GetForm(Forms.FrmSessionDetails, this, true, name, null);
            //  objExpence.loadValuesForUpdate(objFaculty);
            //objExpence. 
            objExpence.ShowDialog();
        }

        private void ADGVStudentFacility_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
