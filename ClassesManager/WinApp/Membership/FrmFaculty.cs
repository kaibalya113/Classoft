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
using System.Text.RegularExpressions;
using ClassManager.WinApp.UICommon;
using System.IO;

namespace ClassManager.WinApp
{
    public partial class FrmFaculty : FrmParentForm
    {
        RolePrivilege formPrevileges;

        const string sCaption = "Faculty form";
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        bool picture = false;
        bool allowsIndexChange = true;
        int FacultyId = 0;
        public FrmFaculty()
        {
            InitializeComponent();
        }


        public void clearAll()
        {
            txtFName.Text = "";
            txtContact.Text = "";
            txtBiometricId.Text = "";
            txtAddress.Text = "";
            txtBiometricId.Text = "";
            txtEmailID.Text = "";
            txtResume.Text = "";
            txtPancard.Text = "";
            txtAdharNo.Text = "";
            txtQualification.Text = "";
            pbPhoto.Image = ClassManager.Properties.Resources.img;
            // lstCourseType.ClearSelected();
            //lstCourseType.Items.Clear();
        }
        public bool validate()
        {
            bool Email = true;
            try
            {
                if (txtEmailID.Text.Length != 0)
                {
                    Email = Regex.IsMatch(txtEmailID.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                }
                if (!Email)
                {
                    UICommon.WinForm.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtEmailID.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(txtFName.Text) && txtFName.Text.Length > 0)
                {
                    UICommon.WinForm.showStatus("Please Enter valid Faculty name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtFName.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Faculty name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtContact.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please fill faculty contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtContact.Focus();
                    return false;
                }
                else if (txtContact.Text.Length != 10)
                {

                    UICommon.WinForm.showStatus("Invalid Contact Number.", sCaption, this);
                    txtContact.Focus();
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
        public void resetAllFields(Control control)
        {
            try
            {
                foreach (Control c in control.Controls)
                {
                    var textBox = c as TextBox;
                    var comboBox = c as ComboBox;
                    var listBox = c as ListBox;
                    if (textBox != null)
                        (textBox).Clear();

                    if (comboBox != null)
                    {
                        comboBox.SelectedIndex = -1;
                        comboBox.Text = "";
                    }
                    if (listBox != null)
                    {
                        listBox.SelectedItem = -1;
                        listBox.Text = "";

                    }
                    if (c.HasChildren)
                        resetAllFields(c);
                }
            }
            catch (Exception)

            { throw; }
        }
        public void showStatus(string message, MessageBoxButtons button, MessageBoxIcon icon)
        {
            MessageBox.Show(message, sCaption, button, icon);
        }

        private void Faculty_Load(object sender, EventArgs e)
        {
            try
            {
               // this.TopMost = true;
                if (this.IsMdiChild != true)
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnReset.Visible = false;
                    ApplyPrevileges();
                    AssignEvents();
                    cmbBranch.DataSource = BranchHandler.getBranches();
                }
                else
                {
                    txtFName.Focus();
                    AssignEvents();
                    //cmbStream.DataSource = StreamHandller.getStreams(branchID);
                    ofdImg.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";
                    cmbBranch.ValueMember = "BranchID";
                    cmbBranch.DisplayMember = "Name";

                    cmbBranch.DataSource = BranchHandler.getBranches();
                    allowsIndexChange = false;

                    //resetAllFields(this);
                    clearAll();
                    allowsIndexChange = true;
                   // dtDob.MaxDate = DateTime.Now.AddYears(-20);
                    UICommon.WinForm.formatDateTimePicker(dtDob, Common.Formatter.DateFormat);
                    //ApplyPrevileges();
                    pbPhoto.Image = Properties.Resources.img;
                    if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Gym")
                    {
                        btnViewFaculties.Text = "VIEW INSTRUCTOR";
                    }
                }
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
                    if (formPrevileges.Create == false)
                    {
                        btnSave.Visible = false;
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
            txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtBiometricId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);

        }






        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtContact.SelectionLength = 10;
        }

        private void btnViewFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFaculties).Visible = true;
                this.Close();
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
                if (validate())
                {

                    Info.Faculty objFaculty = new Info.Faculty();

                    objFaculty.Name = txtFName.Text;
                    objFaculty.Address = txtAddress.Text;
                    objFaculty.ContactNo = txtContact.Text;
                    objFaculty.EmailId = txtEmailID.Text;
                    //objFaculty.CourseList = string.Join(",", from Courses in lstCourseType.Items.Cast<string>() select Courses);                  
                    // objFaculty.StreamName = cmbStream.Text;
                    objFaculty.branchId = Program.LoggedInUser.BranchId;
                    objFaculty.Pancard = txtPancard.Text.ToString();
                    objFaculty.AdharCard = txtAdharNo.Text.ToString();
                    objFaculty.Qualification = txtQualification.Text.ToString();
                    
                    objFaculty.ImgPhoto = pbPhoto.Image;
                    objFaculty.biometricId = (txtBiometricId.Text.Length == 0) ? -1 : Convert.ToInt32(txtBiometricId.Text);
                    objFaculty.DOb = dtDob.Value;
                    //saving file 
                    string savePath = SysParam.getValue<string>(SysParam.Parameters.RESUME);
                    string file = txtResume.Text.ToString();
                    string filePath = txtResume.Text.ToString();
                    filePath = Path.GetFileName(filePath);
                    filePath = filePath + "_"+ objFaculty.FacultyID;

                    savePath += Path.GetFileName(filePath);
                    
                    //csvFilePath.FileName.ToString();
                    File.Copy(file, savePath);
                    objFaculty.Resume = savePath;
                    FacultyHandler.saveFaculty(objFaculty);
                    UICommon.WinForm.showStatus("Details saved successfully,Faculty Id is:  " + objFaculty.FacultyID, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    //   resetAllFields(this);

                    clearAll();
                    //lstCourseType.ClearSelected();
                    txtFName.Focus();
                }
            }
            catch (ClassManager.Common.Exceptions.RecordAlreadyExistsException Exception)
            {
                UICommon.WinForm.showStatus("Faculty already registrered", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);

             }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            try
            {
                //   resetAllFields(this);
                clearAll();
                txtFName.Focus();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void txtContact_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (txtContact.Text.Length >= 10)
            {
                if (e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtBiometricId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBiometricId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtBiometricId.Text.Length >= 10)
                {
                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtBiometricId_Click(object sender, EventArgs e)
        {

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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog csvFilePath = new OpenFileDialog();
                csvFilePath.InitialDirectory = Application.ExecutablePath.ToString();

                csvFilePath.RestoreDirectory = true;
                
                string savePath = SysParam.getValue<string>(SysParam.Parameters.RESUME);


               // dd
                if (csvFilePath.ShowDialog() == DialogResult.OK)
                {
                   // Info.Faculty objFaculty = new Info.Faculty();
                    String fileName = csvFilePath.FileName;
                 //   string name = Path.GetFileName(fileName);
                  //  name = name+"_"+ objFaculty.FacultyID;

                   // savePath += Path.GetFileName(fileName);

                    txtResume.Text = csvFilePath.FileName.ToString();
                        //csvFilePath.FileName.ToString();
                  //  File.Copy(fileName, savePath);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        //When Pressed on Edit button to Edit Fauclty (it bring back the particular faculty Details)
        public void setValuesForUpdate(int FacId)
        {
            try
            {
                Info.Faculty objFaculty = new Info.Faculty();
                objFaculty = BLL.FacultyHandler.getFacultiesByID(FacId, Convert.ToInt16(branchID));

                txtFName.Text = objFaculty.Name;
                txtContact.Text = objFaculty.ContactNo;
                txtAddress.Text = objFaculty.Address;
                txtBiometricId.Text = objFaculty.BiometricId.ToString();
                txtPancard.Text = objFaculty.Pancard.ToString();
                txtAdharNo.Text = objFaculty.AdharCard.ToString();
                txtEmailID.Text = objFaculty.EmailId.ToString();
                txtQualification.Text = objFaculty.Qualification.ToString();
                if(objFaculty.Resume == null || objFaculty.Resume == "")
                {
                    txtResume.Text = "";
                }
                else
                {
                    txtResume.Text = objFaculty.Resume.ToString();
                }
              
                dtDob.Value = objFaculty.DOb;
                cmbBranch.DataSource = BranchHandler.getBranches();
                List<Branch> lst = new List<Branch>();
                lst = BranchHandler.getBranches(objFaculty.branchId.ToString());
                cmbBranch.Text = lst.ToString();
                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objFaculty.PhotoURL.ToString();
                try
                {
                    pbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(100, 100));
                }
                catch (Exception ex)
                {
                    pbPhoto.Image = Properties.Resources.img;
                }

                FacultyId = FacId;
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
                if (validate())
                {
                    Info.Faculty objFaculty = new Info.Faculty();
      
                    objFaculty.Name = txtFName.Text;
                    objFaculty.Address = txtAddress.Text;
                    objFaculty.ContactNo = txtContact.Text;
                    objFaculty.EmailId = txtEmailID.Text;
                    objFaculty.branchId = Program.LoggedInUser.BranchId;
                    objFaculty.Pancard = txtPancard.Text.ToString();
                    objFaculty.AdharCard = txtAdharNo.Text.ToString();
                    objFaculty.Qualification = txtQualification.Text.ToString();
                   // objFaculty.Resume = txtResume.Text.ToString();
                    objFaculty.ImgPhoto = pbPhoto.Image;
                    //string savePath = SysParam.getValue<string>(SysParam.Parameters.RESUME);

                    //String fileName = txtResume.Text;
                    //savePath += fileName;
                    //FileUpload1.SaveAs(Server.MapPath(savePath));


                    objFaculty.BiometricId = Convert.ToInt64(txtBiometricId.Text);
                    objFaculty.DOb = dtDob.Value;
                    objFaculty.FacultyID = (FacultyId);
                    //saving file 
                    string savePath = SysParam.getValue<string>(SysParam.Parameters.RESUME);
                    string file = txtResume.Text.ToString();
                    string filePath = txtResume.Text.ToString();
                    filePath = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filePath);
                    filePath = filePath.Split('.')[0].Trim();
                    filePath = filePath + "_" + objFaculty.FacultyID+""+ext;

                    savePath += Path.GetFileName(filePath);

                    //csvFilePath.FileName.ToString();
                    //File.Copy(file, savePath);
                    //objFaculty.Resume = savePath;
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

                    FacultyHandler.updatefacultyPersnlDtl(objFaculty);
                    UICommon.WinForm.showStatus("Details Updated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    this.Close();
                    //FrmFaculties objFac = (FrmFaculties)UICommon.FormFactory.GetForm(Forms.FrmFaculties, this, true);
                    //objFac.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void txtResume_Click(object sender, EventArgs e)
        {

        }
    }
}
