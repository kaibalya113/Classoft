using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassesManager.Common;
using ClassesManager.Info;
using ClassesManager.BLL;
using System.Configuration;
using System.Threading;
using System.Text.RegularExpressions;

namespace ClassesManager.WinApp
{
    public partial class UpdateStudentDetails: Form
    {
        const string sCaption = "Update Student Details";
        bool picture = false;
        DialogResult dialogResult = new DialogResult();
        List<Info.Enquiry> lstEnquiries;
        List<Info.Standard> lstStandards;
        public static Info.Standard selectedStandard;
       // List<Info.FeeStructure> lstFeeStructure;
        public static List<Info.Batch> lstBatches;
        List<Info.FeesPackage> lstPackage;
        int currentIndex = 0;
        Boolean sAllowIndexChange;
        Boolean bAllowIndexChange;
        Info.Student objStudent;
        StudentMaster ObjStudentMaster;

        
        public static FeesPackage feePackage;
        public static int selectedStartDate;
        private static List<Info.InstallmentDetails> lstStudentInstallment;
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        public UpdateStudentDetails()
        {
            InitializeComponent();
        }
        List<Student> lstStudent;
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {


                clearform();

                AssignEvents();

                ofdImg.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";

                lstStandards = StandardHandller.getStandard("");
                lstStudent = StudentHandller.AllRegistered(branchId);
                cmbStudName.DisplayMember = "StudentName";
                cmbStudName.ValueMember = "rollNo";

                cmbStandards.ValueMember = "Standardid";
                cmbStandards.DisplayMember = "DisplayName";


                cmbCourse.DisplayMember = "CLG_NAME";

                bAllowIndexChange = false;

                cmbStudName.DataSource = lstStudent;
                cmbStandards.DataSource = lstStandards;


                cmbCourse.DataSource = StreamHandller.getStreams(branchId);
                cmbbCourse.DataSource = cmbCourse.DataSource;
                //cmbCourse.DataSource = StreamHandller.getStreams(branchId);
                //cmbbCourse.DataSource = cmbCourse.DataSource;
             
                sAllowIndexChange = false;
                
                pbPhoto.Image = Properties.Resources.img;
                

                cmbStudName.Text = "";
                bAllowIndexChange = true;
               
                cmbStudName.Select();
                sAllowIndexChange = true;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AssignEvents()
        {

            txtRollNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            
            txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text.Length == 0)
                {
                    UICommon.Common.showStatus("Enter Roll No", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtRollNo.Text = "";
                }
                objStudent = lstStudent.Find(enq => enq.RollNo.Equals(txtRollNo.Text));

                if (objStudent == null)
                {
                    UICommon.Common.showStatus("No search found.\n\n Please enter valid Roll No", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption,this);
                    txtRollNo.Text = "";
                    txtRollNo.Focus();
                }

                else
                {
                    assignValueToControls(objStudent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private void assignValueToControls(Info.Student objStudent)
        {
            try
            {
               
                txtAddress.Text = objStudent.Address;
                txtFName.Text = objStudent.FName;
                txtMName.Text = objStudent.MName;
                txtLName.Text = objStudent.LName;
                txtSContact.Text = objStudent.PhnNo;
                txtEmailID.Text = objStudent.MailId;
                cmbCourse.Text = objStudent.Standard.Stream;
                cmbStandards.Text = objStudent.Standard.StandardName;
                txtFContact.Text = objStudent.FPhnNo;
                dtpDOB.Text = objStudent.birtDate.ToShortDateString();
                txtBiometricId.Text = objStudent.biometricId.ToString();
                cmbBatch.Text = objStudent.BatchID;
                txtFFname.Text = objStudent.ParentName;

                if (objStudent.Gender == "F")
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;
                }
                //cmbbCourse.Text = objStudent.Stream;
                //cmbbStd.Text = objStudent.Stadard;
               // cmbStandards.Text = 
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbStudName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bAllowIndexChange)
                {
                    txtRollNo.Text = cmbStudName.SelectedValue.ToString();
                 //  assignValueToControls(objStudent);
                }
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {

                if (validatePersonalInfo())
                {
                    int biometicId;
                    ObjStudentMaster = new StudentMaster();

                    ObjStudentMaster.Fname = txtFName.Text;
                    ObjStudentMaster.Mname = txtMName.Text;
                    ObjStudentMaster.Lname = txtLName.Text;
                    ObjStudentMaster.Dob = dtpDOB.Value;
                    ObjStudentMaster.Address = txtAddress.Text;
                    ObjStudentMaster.ContactNo = txtSContact.Text;
                    ObjStudentMaster.EmailID = txtEmailID.Text;
                    ObjStudentMaster.RollNo = txtRollNo.Text;
                    ObjStudentMaster.FatherName = txtFFname.Text;
                    ObjStudentMaster.FatherContactNo = txtFContact.Text;

                    ObjStudentMaster.biometricId = (Int32.TryParse(txtBiometricId.Text, out biometicId) ? biometicId : -1);
                    ObjStudentMaster.Gender = ((rbMale.Checked) ? "M" : "F");

                    ObjStudentMaster.ImgPhoto = pbPhoto.Image;

                    ObjStudentMaster.AdmissionStandard = (Standard)ObjStudentMaster.AdmissionStandard;


                    lstBatches = StandardHandller.GetBatches(((Standard)cmbStandards.SelectedItem).Standardid);
                    if (lstBatches.Count == 0)
                    {
                        UICommon.Common.showStatus("No Batches for selected standard", MessageBoxButtons.OK, MessageBoxIcon.Information, "Batch Not Available", this);
                        return;
                    }

                    lstPackage = FeesPackageHandller.GetPackage(((Standard)cmbStandards.SelectedItem).Standardid);


                    if (lstPackage.Count == 0)
                    {
                        UICommon.Common.showStatus("No Packages for selected standard", MessageBoxButtons.OK, MessageBoxIcon.Information, "Package Not Available", this);
                        return;
                    }

                    cmbBatch.DisplayMember = "BatchID";
                    cmbBatch.ValueMember = "BatchID";

                   
                    cmbbStd.DisplayMember = "StandardName";
                    cmbbStd.ValueMember = "StandardID";
                    bAllowIndexChange = false;
                    cmbBatch.DataSource = lstBatches;
                    lblName.Text = ObjStudentMaster.Fname + " " + ObjStudentMaster.Mname + " " + ObjStudentMaster.Lname;
                    bAllowIndexChange = true;
                    feePackage = lstPackage[0];
                    feesCal(feePackage.PackageType);
                    cmbbCourse.SelectedIndex = cmbCourse.SelectedIndex;
                    cmbbStd.SelectedIndex = cmbStandards.SelectedIndex;
                    tabMain.SelectedIndex = 1;
                    setPaymentStartDate();
                    //for next tab
                    cmbbBatch.DisplayMember = "BatchID";
                    cmbbBatch.ValueMember = "BatchID";
                    cmbbBatch.DataSource = lstBatches;

                }
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        
      
       
      
       
        private void cmdCalcFees_Click(object sender, EventArgs e)
        {
            //if (cmbPakacges.Text.Length == 0)
            //{
            //    cmdCalcFees.Enabled =false;

            //}
            //try
            //{
            //    decimal totalFees = 0,tuitionFees=0;
            //    if (cmbPaymentOptn.Text.Equals("lump sum"))
            //    {
            //        totalFees = totalFees + ((FeesPackage)(cmbPakacges.SelectedItem)).LumsumAmount;

            //        tuitionFees = totalFees - ((((FeesPackage)(cmbPakacges.SelectedItem)).RegstAmt) + (((FeesPackage)(cmbPakacges.SelectedItem)).MisclnAmnt));
            //        foreach (FeeStructure objFeeStructure in lstOptionalSubs.Items)
            //        {
            //            totalFees = totalFees + objFeeStructure.LumsumAmt;
                        
            //        }
            //        lblTuition.Text = tuitionFees.ToString();
            //    }
            //    else //if (cmbPaymentOptn.Text.Equals("Installment"))
            //    {
            //        totalFees = totalFees + ((FeesPackage)(cmbPakacges.SelectedItem)).InstllAmnt;
            //        tuitionFees = totalFees - ((((FeesPackage)(cmbPakacges.SelectedItem)).RegstAmt) + (((FeesPackage)(cmbPakacges.SelectedItem)).MisclnAmnt));
            //        foreach (FeeStructure objFeeStructure in lstOptionalSubs.Items)
            //        {
            //            totalFees = totalFees + objFeeStructure.InstallmentAmt;
            //        }
            //        lblTuition.Text = tuitionFees.ToString();
            //    }

            //    txtTotalFees.Text = totalFees.ToString();
                
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {

        }
        
    
     
       
        public bool validatePersonalInfo()
        {
            try
            {

                if (txtFName.Text.Length == 0)
                {
                    UICommon.Common.showStatus("Please fill student first name.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtFContact.Text.Length == 0)
                {
                    UICommon.Common.showStatus("Please fill Father's contact number.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    txtFContact.Focus();
                    return false;
                }
                ////else if (txtLName.Text.Length == 0)
                //{
                //    UICommon.Common.showStatus("Please fill student last name.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
                //    txtLName.Focus();
                //    return false;
                ////}
                //else if (txtAddress.Text.Length == 0)
                //{
                //    UICommon.Common.showStatus("Please fill addresss.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
                //    txtAddress.Focus();
                //    return false;
                //}
                else if (txtSContact.Text.Length != 0 && txtSContact.Text.Length != 10)
                {
                    UICommon.Common.showStatus("Please Enter Valid Contact Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    txtSContact.Focus();
                    return false;
                }

                else if (txtFContact.Text.Length != 0 && txtFContact.Text.Length != 10)
                {
                    UICommon.Common.showStatus("Please Enter Valid Contact Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    txtFContact.Focus();
                    return false;
                }
                else if (txtSContact.Text.Length == 0)
                {
                    UICommon.Common.showStatus("Please fill student contact number.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    txtSContact.Focus();
                    return false;
                }
                else if (txtEmailID.Text.Length > 0)
                {
                    bool isEmail = Regex.IsMatch(txtEmailID.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                    if (!isEmail)
                    {
                        UICommon.Common.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                        txtEmailID.Focus();
                        return false;
                    }
                    return true;
                }
                else if (cmbStandards.SelectedIndex == -1)
                {
                    UICommon.Common.showStatus("Please select Course Type", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                    cmbStandards.Focus();
                    return false;
                }

                else if (txtFFname.Text.Length == 0 || txtFContact.Text.Length == 0 || !picture)
                {
                    //if ((txtFFname.Text.Length == 0 || txtFContact.Text.Length == 0 && !picture))
                    //{
                    //    dialogResult = MessageBox.Show("Parent details are not fully filled and also haven't select the student photo. Click 'YES' to proceed or 'No' to stay on form.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //}
                    //    //This is commented bcoz no need of validation.
                    ////else if (!picture)
                    ////{
                    ////    dialogResult = MessageBox.Show("You haven't added student photo. Click 'YES' to proceed or 'No' to stay on form.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    ////}
                    //else
                    //{
                    //    dialogResult = MessageBox.Show("Parent details are not fully filled. Click 'YES' to proceed or 'No' to stay on form.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //}
                    //if (dialogResult == DialogResult.Yes)
                    //    return true;
                    //else if (dialogResult == DialogResult.No)
                    //    return false;
                    return true;
                }
                return true;
                     }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdQBack_Click(object sender, EventArgs e)
        {
            try
            {
               tabMain.SelectedIndex = 0;
               currentIndex = 1;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdCBack_Click(object sender, EventArgs e)
        {

        }

        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                pbPhoto.Image = Properties.Resources.img;
                picture = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdPDReset_Click(object sender, EventArgs e)
        {            
            try
            {

                if (txtFContact.Text.Length != 0)
                {
                    Student objStud = lstStudent.Find(enq => enq.RollNo.Equals(txtRollNo.Text));
                    Decimal pendingAmnt = BLL.StudentHandller.deactivateStudent(objStud.AdmissionNo, false);
                    var confirmResult = MessageBox.Show("Pending Amount is :" + pendingAmnt + "  Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        BLL.StudentHandller.deactivateStudent(objStud.AdmissionNo, true);
                        UICommon.Common.showStatus("Student deleted successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                        clearform();
                    }
                    else
                    {
                        BLL.StudentHandller.deactivateStudent(objStud.AdmissionNo, false);
                        UICommon.Common.showStatus("Student record saved as it is.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                        clearform();
                    }
                }
                else
                {
                    UICommon.Common.showStatus("Select particular student", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void clearform()
        {
            txtRollNo.Text = "";
            cmbStudName.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtEmailID.Text = "";
            txtAddress.Text = "";
            txtSContact.Text = "";
            txtBiometricId.Text = "";
            cmbBatch.Text = "";
            cmbCourse.Text = "";
            cmbStandards.Text = "";
            txtFFname.Text = "";
            txtFContact.Text = "";
        }

       

        private void cmdCSPReset_Click(object sender, EventArgs e)
        {

        }

        public bool validateRegisterInfo()
        {
            try
            {
                if (cmbBatch.Text.Length == 0)
                {
                    UICommon.Common.showStatus("Select Batch.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
                    //cmdCalcFees.Select();
                    return false;
                }
             

                lstBatches = StandardHandller.GetBatches(ObjStudentMaster.AdmissionStandard.Standardid);
                if (lstBatches.Count == 0)
                {
                    UICommon.Common.showStatus("No Batches for selected standard", MessageBoxButtons.OK, MessageBoxIcon.Information, "Batch Not Available", this);
                    return false;
                }

                lstPackage = FeesPackageHandller.GetPackage(ObjStudentMaster.AdmissionStandard.Standardid);


                if (lstPackage.Count == 0)
                {
                    UICommon.Common.showStatus("No Packages for selected standard", MessageBoxButtons.OK, MessageBoxIcon.Information, "Package Not Available", this);
                    return false;
                }

                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = currentIndex;
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmbCollegeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStandards.DataSource = null;
            String stream = cmbCourse.SelectedValue.ToString();
            cmbStandards.DataSource = StandardHandller.getStandard(stream);
        }

      

       
        private void btViewInstallment_Click(object sender, EventArgs e)
        {
            UICommon.FormFactory.GetForm("StudentInstallment", this.MdiParent).Visible = true;   
        }

        

        private void cmbStandards_SelectedIndexChanged(object sender, EventArgs e)
        {
                 
        }
       
      
      
        public static void setInstallments(List<Info.InstallmentDetails> lstStudent)
        {
            
            lstStudentInstallment = lstStudent;

            
        }

        private void cmbbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            String stream = cmbbCourse.SelectedValue.ToString();
            cmbbStd.DataSource = StandardHandller.getStandard(stream);


            if (ObjStudentMaster != null)
            {
                lstBatches = StandardHandller.GetBatches(((Standard)cmbStandards.SelectedItem).Standardid);

                lstPackage = FeesPackageHandller.GetPackage(((Standard)cmbStandards.SelectedItem).Standardid);
            }

        }

        private void cmbbStd_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (sAllowIndexChange == true)
                {


                    lstPackage = FeesPackageHandller.GetPackage(Convert.ToInt32(cmbbStd.SelectedValue));

                    if (lstPackage.Count == 0)
                    {
                        UICommon.Common.showStatus("No Packages for selected standard", MessageBoxButtons.OK, MessageBoxIcon.Information, "Package Not Available", this);
                        return;
                    }
                    Standard std = (Standard)cmbbStd.SelectedItem;
                    ObjStudentMaster.AdmissionStandard = std;

                    //cmbBatch.DataSource = StandardHandller.GetBatches(std.Standardid);

                    cmbbBatch.DataSource = StandardHandller.GetBatches(std.Standardid);
                    feePackage = lstPackage[0];
                    feesCal(feePackage.PackageType);
                    selectedStandard = cmbStandards.SelectedItem as Info.Standard;
                }
            }
            catch (Exception ex)
            {
                UICommon.Common.showError(ex, "Something went wrong, Please fill student detail first", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPaymentStartDate();
        }
        public void setPaymentStartDate()
        {
            DateTime admissiondate, batchDate;
            admissiondate = Convert.ToDateTime(System.DateTime.Now.Date.ToString());
            batchDate = Convert.ToDateTime((((Batch)cmbBatch.SelectedItem).StartDate).ToString());

            if (admissiondate > batchDate)
            {
                dtpPaymentStartDt.Text = admissiondate.ToString();
                dtpPaymentStartDt.Enabled = false;
                rbtnAdmissionDate.Checked = true;
            }
            else
            {
                dtpPaymentStartDt.Text = batchDate.ToString();
                dtpPaymentStartDt.Enabled = false;
                rbtnBatchDate.Checked = true;
            }
        }

        private void rbtnBatchDate_CheckedChanged(object sender, EventArgs e)
        {

            dtpPaymentStartDt.Enabled = false;
            dtpPaymentStartDt.Text = (((Batch)cmbBatch.SelectedItem).StartDate).ToString();
            selectedStartDate = 1;
        }

        private void rbtnAdmissionDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPaymentStartDt.Enabled = false;
            dtpPaymentStartDt.Text = System.DateTime.Now.Date.ToString();
            selectedStartDate = 2;
            
        }

        private void rbtnCustom_CheckedChanged(object sender, EventArgs e)
        {
            dtpPaymentStartDt.Enabled = true;
            selectedStartDate = 3;
        }

        private void chkPayLumsum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPayLumsum.Checked)
            {
                feesCal(PackageType.LUMPSUM);
                txtTotalFees.Enabled = true;
                feePackage.LumsumAmount = Convert.ToDecimal(txtTotalFees.Text);
            }
            else
            {
                feesCal(feePackage.PackageType);
                txtTotalFees.Enabled = false;
            }
        }
        public void feesCal(PackageType packageType)
        {


            txtPackName.Text = feePackage.PackageName;
            txtPaymntOptn.Text = feePackage.PackageType.ToString();
            lblRegstAmnt.Text = feePackage.RegistrationAmount.ToString();
            lblMiscAmnt.Text = feePackage.MiscAmount.ToString();


            switch (packageType)
            {
                case PackageType.LUMPSUM:
                    lblInstAmnt.Text = feePackage.LumsumAmount.ToString();
                    txtTotalFees.Text = (feePackage.LumsumAmount).ToString();

                    break;
                case PackageType.INSTALLMENT:
                    lblInstAmnt.Text = feePackage.TotalTuiAmnt.ToString();
                    txtTotalFees.Text = feePackage.PackageCost.ToString();

                    break;
                default:
                    lblInstAmnt.Text = feePackage.RecurAmnt.ToString();
                    txtTotalFees.Text = feePackage.PackageCost.ToString();

                    break;

            }
        }

        private void btViewInstallment_Click_1(object sender, EventArgs e)
        {
            UICommon.FormFactory.GetForm("StudentInstallment", this.MdiParent).Visible = true;   
        }

        private void cmdRegister_Click_1(object sender, EventArgs e)
        {


            Student objStudent = new Student();
            try
            {

                if (validateRegisterInfo())
                {

                    Common.Log.LogError("Validation done", ErrorLevel.INFORMATION);
                    Fees objFees = new Fees();
                    objFees.PaymentType = txtPaymntOptn.Text.Substring(0, 1);

                    objFees.TotalFees = feePackage.PackageCost;
                    objFees.RegAmnt = feePackage.RegistrationAmount;
                    objFees.MiscAmnt = feePackage.MiscAmount;
                    objFees.FeesDiscount = Convert.ToDecimal(txtDiscount.Text);
                    objFees.TuitionAmnt = objFees.TotalFees - objFees.RegAmnt - objFees.MiscAmnt;
                    objFees.DiscountReason = txtDiscountReasond.Text;

                    objStudent.BatchID = cmbbBatch.SelectedItem.ToString();
                    objStudent.PackageID = feePackage.PackageID;
                    objStudent.Standard = ObjStudentMaster.AdmissionStandard;
                    objStudent.StudentName = ObjStudentMaster.Fname + " " + ObjStudentMaster.Mname + " " + ObjStudentMaster.Lname;

                    objStudent.MailId = ObjStudentMaster.EmailID;
                    objStudent.BranchID = Program.LoggedInUser.BranchId;

                    objStudent.PhnNo = ObjStudentMaster.ContactNo;
                    objStudent.biometricId = ObjStudentMaster.biometricId;


                    if (lstStudentInstallment == null)
                    {
                        viewInstallmentDetails();
                    }

                    StudentHandller.updateStudent(ObjStudentMaster, objStudent, objFees, lstStudentInstallment);
                    // update student


                    objFees.AdmissionNo = ObjStudentMaster.AdmissionNo;
                    objStudent.TotalFees = objFees.TotalFees;

                    UICommon.Common.showStatus("Roll No is : " + objStudent.RollNo + " \nAdmission No: " + objStudent.AdmissionNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                   // MainForm.setStatus("Sending Message from " + sCaption);
                    //bgwRegistrationSMS.RunWorkerAsync(objStudent);

                    FeesPaymentForm frmFeePayment = UICommon.FormFactory.GetForm("FeesPaymentForm", UICommon.FormFactory.GetForm("MainForm", null, "A") as MainForm) as FeesPaymentForm;


                    frmFeePayment.LoadFeeDetailsFromRegistration(objStudent, objFees);




                    frmFeePayment.Visible = true;


                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Student Already Registered for Course"))
                {
                    UICommon.Common.showStatus("Student Already Register for Course and Batch" + objStudent.RollNo, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return;
                }
                else if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.Common.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
                else
                    throw ex;

            }
        }

        public List<Info.InstallmentDetails> viewInstallmentDetails()
        {
            switch (UpdateStudentDetails.selectedStartDate)
            {
                case 1: rbtnBatchDate.Checked = true; break;
                case 2: rbtnAdmissionDate.Checked = true; break;
                case 3: rbtnCustom.Checked = true; break;
            }

            //dtpPaymentStartDt.Value = RegistrationForm.dtpPaymentStartDt.Value;

            int instDuration = 0;



            string Package_Type = UpdateStudentDetails.feePackage.PackageType.ToString();
            Standard std = (Standard)cmbStandards.SelectedItem;
            int package_Duration = std.DurationInMonths;
            lstStudentInstallment = new List<Info.InstallmentDetails>();
            int installNo = 1;
            string status = "NP";
            switch (Package_Type)
            {

                case "INSTALLMENT":

                    List<PackageInstallment> lstPack = UpdateStudentDetails.feePackage.packInstmnts;
                    foreach (Info.PackageInstallment installDetails in lstPack)
                    {
                        Info.InstallmentDetails objInstDetails = new Info.InstallmentDetails();
                        objInstDetails.InstMonth = dtpPaymentStartDt.Value.AddDays(instDuration).Month;
                        string installDate = dtpPaymentStartDt.Value.AddDays(instDuration).ToString();

                        instDuration = instDuration + installDetails.InstallmentDuration;

                        objInstDetails.InstNo = installNo++;
                        objInstDetails.InstDate = Convert.ToDateTime(installDate);
                        objInstDetails.InstAmount = installDetails.InstallmentAmount;
                        objInstDetails.Status = status;
                        lstStudentInstallment.Add(objInstDetails);

                    }
                    break;
                case "MONTHLY":

                    for (int i = 0; i < package_Duration; i++)
                    {
                        Info.InstallmentDetails objInstDetails = new Info.InstallmentDetails();

                        string installDate = dtpPaymentStartDt.Value.AddMonths(i).ToString();
                        objInstDetails.InstMonth = dtpPaymentStartDt.Value.AddMonths(i).Month;
                        objInstDetails.InstNo = installNo++;
                        objInstDetails.Status = status;
                        objInstDetails.InstDate = Convert.ToDateTime(installDate);
                        objInstDetails.InstAmount = UpdateStudentDetails.feePackage.RecurAmnt;
                        lstStudentInstallment.Add(objInstDetails);
                    }
                    break;
                case "QUARTERLY":
                    for (int i = 0; i < package_Duration; i = i + 3)
                    {
                        Info.InstallmentDetails objInstDetails = new Info.InstallmentDetails();
                        objInstDetails.InstMonth = dtpPaymentStartDt.Value.AddMonths(i).Month;
                        string installDate = dtpPaymentStartDt.Value.AddMonths(i).ToString();
                        objInstDetails.InstNo = installNo++;
                        objInstDetails.InstDate = Convert.ToDateTime(installDate);
                        objInstDetails.InstAmount = UpdateStudentDetails.feePackage.RecurAmnt;
                        objInstDetails.Status = status;
                        lstStudentInstallment.Add(objInstDetails);
                    }


                    break;
                case "HALF_YEARLY":
                    for (int i = 0; i < package_Duration; i = i + 6)
                    {
                        Info.InstallmentDetails objInstDetails = new Info.InstallmentDetails();

                        string installDate = dtpPaymentStartDt.Value.AddDays(i).ToString();
                        objInstDetails.InstNo = installNo++;
                        objInstDetails.InstMonth = dtpPaymentStartDt.Value.AddMonths(i).Month;
                        objInstDetails.InstDate = Convert.ToDateTime(installDate);
                        objInstDetails.InstAmount = UpdateStudentDetails.feePackage.RecurAmnt;
                        objInstDetails.Status = status;
                        lstStudentInstallment.Add(objInstDetails);
                    }

                    break;

            }
            return lstStudentInstallment;

        }

  
      
    }
}
