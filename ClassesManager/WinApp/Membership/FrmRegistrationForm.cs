using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.BLL;
using System.Configuration;
using System.Threading;
using System.Text.RegularExpressions;
using ClassManager.WinApp.UICommon;


namespace ClassManager.WinApp
{
    public partial class FrmRegistrationForm : FrmParentForm
    {
        const string sCaption = "Registration";

        RolePrivilege formPrevileges;

        bool picture = false;

        public static Info.Student objStudent;
        List<FeeStructure> allOptionalSubjects = new List<FeeStructure>();
        List<FeeStructure> selectedOptionalSubjects = new List<FeeStructure>();
        List<Batch> batches = new List<Batch>();

        List<Info.Enquiry> lstEnquiries;

        public static List<Info.Batch> lstBatches;
        Boolean bAllowIndexChange;
        Info.Enquiry objEnquiry;

        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        public static List<Info.InstallmentDetail> lstStudentInstallment;
        List<Info.StudentFacility> selctedSubjects;
        public static bool isFrmReg;
        private string otp;


      //  private TextBox txtFcontact;
        public FrmRegistrationForm()
        {
            InitializeComponent();
            traslatableMaterialTextfiels = new List<MaterialSkin.Controls.MaterialSingleLineTextField>();
            traslatableMaterialTextfiels.Add(txtMemberShipNo);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {
                AssignEvents();
               
                ofdImg.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";

              
                cmbStudName.Items.Clear();
                lstEnquiries =BLL.EnquiryHandller.GetEnquries(-1, branchId);
                foreach (Enquiry objEnq in lstEnquiries)
                {
                    cmbStudName.Items.Add(new ComboItem(objEnq.EnquiryID, objEnq.Fullname));
                }
                cmbStudName.SelectedIndex = -1;
                cmbSchoolName.DataSource = null;
                cmbSchoolName.DisplayMember = "SCH_NAME";
                cmbSchoolName.DataSource = StandardHandller.getSchoolName();
                pbPhoto.Image = Properties.Resources.img;
                bAllowIndexChange = true;
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                if(appName == "") { txtAdhrCard.Hide(); }
                
                cmbStudName.Select();
                formatForm();
                ApplyPrevileges();

                loadEnquiryReferences();


            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, null);
            }
        }

        private void loadEnquiryReferences()
        {
            try
            {
                string enquiryReferences = SysParam.getValue<string>(SysParam.Parameters.ENQUIRY_SOURCES);

                if (enquiryReferences != null && enquiryReferences.Length > 0)
                {
                    String[] sources = enquiryReferences.Split(',');
                    cmbSource.Items.AddRange(sources);
                }
            }
            catch (Exception)
            {

                throw;
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
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
                        cmdNext.Visible = false;
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


        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpDOB, Common.Formatter.DateFormat);
                UICommon.WinForm.formatDateTimePicker(dtpAdmissionDate, Common.Formatter.DateFormat);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void AssignEvents()
        {

            txtEnquiryNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtAdhrCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
            txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEnquiryNo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Enter enquiry Id", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtEnquiryNo.Text = "";
                }
                else
                {
                    objEnquiry = lstEnquiries.Find(enq => enq.EnquiryID == Convert.ToInt32(txtEnquiryNo.Text));

                    if (objEnquiry == null)
                    {
                        UICommon.WinForm.showStatus("No search found.\n\n Please enter valid enquiry id", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtEnquiryNo.Text = "";
                        txtEnquiryNo.Focus();
                    }

                    else
                    {
                        assignValueToControls(objEnquiry);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void assignValueToControls(Info.Enquiry objEnquiry)
        {
            try
            {
                if(objEnquiry.SchoolName != null)
                {
                    cmbSchoolName.Text = objEnquiry.SchoolName;
                }
                cmbStudName.Text = objEnquiry.Fullname;
                txtAddress.Text = objEnquiry.Addres;
                txtFName.Text = objEnquiry.FName;
                txtMName.Text = objEnquiry.MName;
                txtLName.Text = objEnquiry.LName;
                txtSContact.Text = objEnquiry.ContactNo;
               // dtpDOB.Value = (objEnquiry.DOB != null && objEnquiry.DOB != DateTime.MinValue) ? objEnquiry.DOB : dtpDOB.Value;
                dtpDOB.Value = objEnquiry.DOB;
                txtEmailID.Text = objEnquiry.EmailID;
                txtEnquiryNo.Text = objEnquiry.EnquiryID.ToString();
                cmbSource.Text = objEnquiry.ReferenceBy.ToString();
                if (objEnquiry.parentContact == null)
                {
                    txtFContact.Text = "";
                }
                else
                {
                    txtFContact.Text = objEnquiry.parentContact.ToString();
                }
                txtFFname.Text = objEnquiry.MName.ToString() + " " + objEnquiry.LName.ToString();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        private void cmbStudName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudName.SelectedIndex != -1)
                {
                    if (bAllowIndexChange)
                    {
                        int enquiryId =(cmbStudName.SelectedItem as ComboItem).key;
                        objEnquiry = lstEnquiries.Find(enq => enq.EnquiryID == enquiryId);
                        assignValueToControls(objEnquiry);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmdBrwseImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdImg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pbPhoto.Image = new Bitmap(new Bitmap(ofdImg.FileName), new Size(100, 100));

                    picture = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatePersonalInfo())
                {
                    int biometicId;
                    objStudent = new Student();
                    objStudent.HeathIssue = "";
                    objStudent.Fname = txtFName.Text;
                    objStudent.Mname = txtMName.Text;
                    objStudent.Lname = txtLName.Text;
                    DateTime dateDiff = DateTime.Now.AddYears(-2);
                    if (dateDiff.ToShortDateString().Equals(dtpDOB.Value.ToShortDateString()))
                    {
                        objStudent.Dob = dtpDOB.Value;
                    }
                    else
                    {
                        objStudent.Dob = dtpDOB.Value;
                    }
                    objStudent.Address = txtAddress.Text;
                    objStudent.ContactNo = txtSContact.Text;
                    objStudent.EmailID = txtEmailID.Text;
                    objStudent.Enquiry = new Enquiry(Convert.ToInt32((txtEnquiryNo.Text == "") ? "-1" : txtEnquiryNo.Text));
                    objStudent.FatherName = txtFFname.Text;
                    objStudent.FatherContactNo = txtFContact.Text;
                    objStudent.BiometricId = (Int32.TryParse(txtBiometricId.Text, out biometicId) ? biometicId : -1);
                    objStudent.Gender = ((rbMale.Checked) ? "M" : "F");
                    objStudent.SchoolName = cmbSchoolName.Text;
                    objStudent.ImgPhoto = pbPhoto.Image;
                    objStudent.Source = cmbSource.Text;
                    objStudent.AdmissionDate = dtpAdmissionDate.Value;
                    objStudent.AdharCard = txtAdhrCard.Text;
                    objStudent.Remark = txtRemark.Text;
                    objStudent.EmailID = objStudent.EmailID;
                    objStudent.Branch.BranchId = Program.LoggedInUser.BranchId;
                    objStudent.Batch.id = -1;
                    objStudent.MembershipNo = txtMemberShipNo.Text;
                    //values Passed for Gym
                    objStudent.Height = "";
                    objStudent.BloodGroup = "";
                    objStudent.Weight = "";
                    objStudent.BMI ="";
                    objStudent.GSTNo = "";
                    //
                    // values Passed for Asset 
                    objStudent.Category = "";
                    objStudent.counselor = "";
                    objStudent.Reference = "";
                    //
                    StudentHandller.RegisterStudent(objStudent);
                    var selectPackage = UICommon.WinForm.showStatus("Roll No is : " + objStudent.RollNo + " \nAdmission No: " + objStudent.AdmissionNo + ". \n\nDo you want to add package for " + objStudent.Fname + " ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);

                    bgwRegistrationSMS.RunWorkerAsync(objStudent);

                    //Add facilities screen will open
                    if (selectPackage == DialogResult.Yes)
                    {
                        //Closes the Registeration Form.
                        // this.Close();
                        clearForm();
                        isFrmReg = true;

                        FrmAddFacilities frmAddFacilities = new FrmAddFacilities(objStudent);
                       
                        frmAddFacilities.ShowDialog();
                        lstStudentInstallment = FrmAddFacilities.lstStudentInstallment;
                        selctedSubjects = FrmAddFacilities.selctedSubjects;
                    }
                    else
                    {
                        clearForm();
                    }
                    
                }
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showStatus("Student Already Registered \n Admission No. is :" + objStudent.AdmisionNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
              //  UICommon.WinForm.showStatus("Member Already Registered  \n Admission No. is :" + objStudent.AdmissionNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    //UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    UICommon.WinForm.showSMSError(sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, sCaption, ParentForm);
                }
            }
        }

        private void clearForm()
        {
            txtMemberShipNo.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtEmailID.Text = "";
            txtAddress.Text = "";
            txtSContact.Text = "";
            rbMale.Checked = true;
            rbFemale.Checked = false;
            txtBiometricId.Text = "";
            if (cmbBatch.Items.Count > 1)
            {
                cmbBatch.SelectedIndex = 0;
            }
            txtFFname.Text = "";
            txtFContact.Text = "";
            dtpDOB.Value = DateTime.Now.Date.AddYears(-2);
            dtpAdmissionDate.Value = DateTime.Now.Date;
            pbPhoto.Image = ClassManager.Properties.Resources.img;
            txtAdhrCard.Text = "";
            txtMemberShipNo.Text = "";
            txtRemark.Text = "";
            cmbStudName.Text = "";
            txtEnquiryNo.Text = "";
        }

        public bool validatePersonalInfo()
        {
            try
            {
                if (txtFName.Text.Length == 0 || txtFName.Text.Trim()=="")
                {
                    UICommon.WinForm.showStatus("Please Enter Student FirstName", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtSContact.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter student Contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtSContact.Focus();
                    return false;
                }
                else if (txtFContact.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Father's Contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFContact.Focus();
                    return false;
                }
               
               
                else if (txtSContact.Text.Length != 0 && txtSContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Contact Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtSContact.Focus();
                    return false;
                }

                else if (txtFContact.Text.Length != 0 && txtFContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Contact Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFContact.Focus();
                    return false;
                }

                else if (txtEmailID.Text.Length > 0)
                {
                    bool isEmail = Regex.IsMatch(txtEmailID.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                    if (!isEmail)
                    {
                        UICommon.WinForm.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtEmailID.Focus();
                        return false;
                    }
                    return true;
                }


                else if (txtFFname.Text.Length == 0 || txtFContact.Text.Length == 0 || !picture)
                {
                    
                    return true;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                pbPhoto.Image = Properties.Resources.img;
                picture = false;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void cmdPDReset_Click(object sender, EventArgs e)
        {
            try
            {
                
                txtFName.Clear();
                txtMName.Clear();
                txtLName.Clear();
                txtAddress.Clear();
                txtSContact.Clear();
                txtEmailID.Clear();
                txtAdhrCard.Clear();
                txtFFname.Clear();
                txtFContact.Clear();
                txtMemberShipNo.Clear();
                txtBiometricId.Clear();
                txtRemark.Clear();
                pbPhoto.Image = Properties.Resources.img;
                picture = false;
                txtEnquiryNo.Clear();
                cmbStudName.Text = "";
                cmbStudName.Focus();


            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }



        private void bgwRegistrationSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            //Student objStudent = (Student)e.Argument;
            //MailHandler.sendRegistrationSms(objStudent, objStudent.DisplayName, objStudent.Fees.TotalFees , objStudent.RollNo, objStudent.FatherContactNo);
        }

        private void bgwRegistrationSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Error != null)
            //{
            //MainForm.setStatus("No Internet Connection to Send SMS from " + sCaption);
            //}
            //else
            //{
            //    MainForm.setStatus("Message Sent Successfully from " + sCaption);
            //}
        }

        private void txtFContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtFContact.Text.Length >= 10)

                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    

        private void txtSContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtSContact.Text.Length >= 10)
                {
                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        internal void calcOptionalSubjectFees(List<FeeStructure> allSubjects, List<FeeStructure> selectedSubjects)
        {
            allOptionalSubjects = allSubjects;
            selectedOptionalSubjects = selectedSubjects;
        }

        private void lnkCapture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmCaptureImage capture = new FrmCaptureImage();
                capture.ShowDialog();

                if (capture.capturedImage != null)
                {
                   
                    pbPhoto.Image = capture.capturedImage;

                    pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                   
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
               
            }
        }

        private void cmbStudName_DropDown(object sender, EventArgs e)
        {
            cmbStudName.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void cmbStudName_DropDownClosed(object sender, EventArgs e)
        {
            cmbStudName.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        //private void btnViewAllStudent_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UICommon.FormFactory.GetForm(UICommon.Forms.FrmStudentsReport).Visible = true;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }
        //}

        private void lnkVerify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtSContact.Text.Length != 0 && txtSContact.Text.Length == 10)
                {
                    Random rm = new Random();

                    otp = rm.Next(1000, 9999).ToString();

                    SmsConfig smsConfig = SmsConfig.getSMSConfig();

                    if (Common.Utility.retBoolStatus(MailHandler.sendSMS(smsConfig, otp, txtSContact.Text, false,"VerifyPhoneNoSMS")))
                    {
                        var UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Enter OTP", sCaption, "");
                        if (UserAnswer == otp)
                        {
                            MessageBox.Show("Phone Number Verified", sCaption);
                            lnkVerify.Enabled = false;
                            lnkVerify.Text = "Verified";
                        }
                        else
                        {
                            DialogResult userInput;
                            userInput = userInput = UICommon.WinForm.showStatus("Invalid OTP." + System.Environment.NewLine + "Do You want to Re-Enter?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                            if (userInput == DialogResult.Yes)
                            {
                                while (userInput == DialogResult.Yes)
                                {
                                    UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Re-Enter OTP", sCaption, "");
                                    if (UserAnswer == otp)
                                    {
                                        MessageBox.Show("Phone Number Verified", sCaption);
                                        lnkVerify.Enabled = false;
                                        lnkVerify.Text = "Verified";
                                        break;
                                    }
                                    else
                                    {
                                        userInput = UICommon.WinForm.showStatus("Invalid OTP." + System.Environment.NewLine + "Do You want to Re-Enter?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Number Not Verified." + System.Environment.NewLine + "Check Your Settings or Internet Connection.", sCaption, this);
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Invalid Number.", sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFContact_Click(object sender, EventArgs e)
        {
           
        }

        private void txtAdhrCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (txtAdhrCard.Text.Length >= 12)
                //{
                //    if (e.KeyChar != (char)8)
                //    {
                //        e.Handled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void txtBiometricId_Click(object sender, EventArgs e)
        {

        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAdhrCard_Click(object sender, EventArgs e)
        {

        }
    }
}
