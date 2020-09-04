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
using ClassManager.WinApp.UICommon;


namespace ClassManager.WinApp
{
    public partial class FrmStandardMasterForm : FrmParentForm
    {

        RolePrivilege formPrevileges;
        List<Standard> lstStandards;
        public string sCaption = "Standard Master";
        bool allowStandardChange;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        public FrmStandardMasterForm()
        {
            InitializeComponent();
        }

       
        public bool validateStandard()
        {
            try
            {
                if(cmbSStream.Text == "" || cmbSStream.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Stream Name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtStdName.Focus();
                    return false;
                }
                if (txtStdName.Text.Length == 0|| txtStdName.Text.Trim()=="")
                {
                    UICommon.WinForm.showStatus("Please Enter Course Name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtStdName.Focus();
                    return false;
                }
                else if (txtDuration.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Duration.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDuration.Focus();
                    return false;
                }
                else if (txtDuration.Text.Length > 2)
                {
                    UICommon.WinForm.showStatus("Can not enter large value in duration ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDuration.Focus();
                    return false;
                }
                else if (txtDuration.Text == "0")
                {
                    UICommon.WinForm.showStatus("Duration should be more than 0 months.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtDuration.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //private void btnDelStnd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lstStndrds.SelectedItem != null)
        //        {
        //            if (StandardHandller.removeStandard(((Standard)lstStndrds.SelectedItem).Standardid, Program.LoggedInUser.BranchId))
        //            {

        //                LoadStandards();
        //                UICommon.WinForm.showStatus("course deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }

        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No Course available to delete", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, sCaption, this);

        //    }
        //}

        public void loadfromAddFacilities(int streamIndex, int stdIndex)
        {
            try
            {
                cmbSStream.DataSource = StreamHandller.getStreams(Program.LoggedInUser.BranchId.ToString());
                cmbStandard.DataSource = StandardHandller.getStandard(Program.LoggedInUser.BranchId.ToString());
                cmbSStream.SelectedIndex = streamIndex;
                cmbStandard.SelectedIndex = stdIndex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void StandardMasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPrevileges();

                if (cmbStandard.Items.Count == 0)
                {
                    LoadStandards();
                    AssignEvents();
                    fromTime.CustomFormat = "HH:mm tt";
                    toTime.CustomFormat = "HH:mm tt";
                }

                else
                {
                    //This is done to get StandardID for the selected standard.
                    cmbStandard.ValueMember = "Standardid";
                    cmbStandard.DisplayMember = "StandardName";
                    allowStandardChange = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
                //this.Enabled = false;
            }
            //following code will not show previous date
            // dtpStartDate.MinDate = System.DateTime.Now; //giving provision to create batches 

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
                        btnSaveStd.Visible = false;
                        btnAddBatch.Visible = false;

                    }

                    if (formPrevileges.Delete == false)
                    {
                        btnDelStnd.Visible = false;
                        btnRemoveBatch.Visible = false;
                    }
                    if (formPrevileges.View == false)
                    {
                        btnViewCourse.Visible = false;
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
            txtDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            MinPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }
        private void LoadStandards()
        {
            try
            {
                //string selectedItem = cmbSStream.SelectedItem.ToString();
               
               
                cmbSStream.DataSource = StreamHandller.getStreams(branchID);

                allowStandardChange = false;
                //cmbStandard.DataSource = StandardHandller.getStandard();
                //lstStndrds.DataSource = StandardHandller.getStandard();

                cmbStandard.ValueMember = "Standardid";
                cmbStandard.DisplayMember = "StandardName";

                lstStndrds.ValueMember = "Standardid";
                lstStndrds.DisplayMember = "StandardName";

                if (cmbSStream.Items.Count != 0)
                {
                    //cmbSStream.SelectedItem = selectedItem; 

                    List<Standard> standards = StandardHandller.getStandard(branchID.ToString(), ((cmbSStream.SelectedItem) as Stream).ID.ToString());

                    cmbStandard.DataSource = standards;
                    lstStndrds.DataSource = standards;

                    allowStandardChange = true;
                }
            }
            catch (Exception ex)
            {
                // UICommon.WinForm.showStatus("Error Occured Please Contact Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }

        }


        //private void btnRemoveBatch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lstBatches.SelectedItem != null)
        //        {

        //            if (StandardHandller.removeBatch((Batch)lstBatches.SelectedItem) == true)
        //            {
        //                LoadBatches();
        //                UICommon.WinForm.showStatus("Batch deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //            else
        //            {
        //                UICommon.WinForm.showStatus("Can not delete batch as student exists in this batch", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //        }

        //        else
        //        {
        //            UICommon.WinForm.showStatus("No Batch available to delete", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, sCaption, this);
        //        //UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }


        //}

        //private void btnAddBatch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validate_btnAddBatch())
        //        {


        //            Batch objBatch = new Batch();

        //            objBatch.Name = txtBatch.Text;
        //            objBatch.StandardID = Convert.ToInt32(cmbStandard.SelectedValue);
        //            objBatch.location = txtLocation.Text;
        //            objBatch.StartDate = dtpStartDate.Value;
        //            objBatch.FromTime = fromTime.Value;
        //            objBatch.ToTime = toTime.Value;
        //            objBatch.Branch = new Branch(Program.LoggedInUser.BranchId);

        //            if (StandardHandller.addBatch(objBatch))
        //            {
        //                UICommon.WinForm.showStatus("Batch created successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //                LoadBatches();
        //                txtBatch.Clear();
        //                txtBatch.Select();
        //            }

        //        }
        //    }
        //    catch (Common.Exceptions.RecordAlreadyExistsException ex)
        //    {
        //        UICommon.WinForm.showError(ex, sCaption, this, "The batch \"" + txtBatch.Text + "\" already exists");
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }
        //}

        public bool validate_btnAddSub()
        {
            //if (txtStdName.Text.Length == 0)
            //{
            //    UICommon.WinForm.showStatus("Enter standard name first.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
            //    txtStdName.Select();
            //    return false;
            //}
            //else if (txtStdName.Enabled == true)
            //{
            //    if (lstStndrds.FindStringExact(txtStdName.Text+" "+cmbSStream.Text) != -1)
            //    {
            //        UICommon.WinForm.showStatus("Standard name is already exists in selected stream.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
            //        txtStdName.Select();
            //        return false;
            //    }
            //}

            //if (txtSubjects.Text.Length == 0)
            //{
            //    UICommon.WinForm.showStatus("Enter subject name first.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption,this);
            //    txtSubjects.Select();
            //    return false;
            //}

            //else if (lstSubjcts.Items.Contains(txtSubjects.Text))
            //{
            //    UICommon.WinForm.showStatus("Subject already added in list.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption,this);
            //    txtSubjects.Clear();
            //    txtSubjects.Select();
            //    return false;
            //}
            return true;
        }

        public bool validate_btnAddBatch()
        {
            if (txtBatch.Text.Length == 0||txtBatch.Text.Trim()=="")
            {
                UICommon.WinForm.showStatus("Enter batch name first.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                txtBatch.Select();
                return false;
            }
            else if (lstBatches.Items.Contains(txtBatch.Text))
            {
                UICommon.WinForm.showStatus("Batch already present in selected standard.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                txtBatch.Clear();
                txtBatch.Select();
                return false;
            }
            //else if (txtLocation.Text == "" && txtLocation.Visible == true)
            //{
            //    UICommon.WinForm.showStatus("Please Provide Location", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            //    return false;
            //}


            //Validation is not necessary because they are not essential.

            //else if (fromTime.Visible == true && toTime.Visible == true)
            //{
            //    if (fromTime.Value.ToShortTimeString() == toTime.Value.ToShortTimeString())
            //    {
            //        UICommon.WinForm.showStatus("From time and to time can not be same.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            //        return false;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}


            else
            {
                return true;
            }
        }

        private void cmbStandard_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadBatches();
            label12.Text = "in " + cmbStandard.Text;
            label12.ForeColor = System.Drawing.Color.Navy;
        }

        private void LoadBatches()
        {
            if (allowStandardChange)
            {
                try
                {
                    lstBatches.DataSource = null;
                    lstBatches.DisplayMember = "BatchID";
                    lstBatches.ValueMember = "BatchID";

                    lstBatches.DataSource = StandardHandller.GetBatches(Convert.ToInt32(cmbStandard.SelectedValue), Program.LoggedInUser.BranchId);
                }
                catch (Exception ex)
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

                }
            }
        }

        private void cmdDeleteBatch_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void txtStdName_TextChanged(object sender, EventArgs e)
        {
            btnSaveStd.Enabled = true;
        }

        private void cmbSStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                String stream = (cmbSStream.SelectedItem as Stream).ID.ToString();
                lstStndrds.DataSource = StandardHandller.getStandard(branchID.ToString(), stream);
                cmbStandard.DataSource = StandardHandller.getStandard(branchID.ToString(), stream);
                txtDuration.Text = "";

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

      

        public void clearAll()
        {
            cmbSStream.Text = "";

            txtStdName.Clear();

            txtDuration.Clear();

            //lstStndrds.Items.Clear();
            //lstBatches.Items.Clear();

        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDuration.SelectionLength = 2;
        }

        private void btnViewCourse_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmCourses).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnSaveStd_Click(object sender, EventArgs e)
        {
            try
            {
                //ApplyPrevileges();
                if (validateStandard())
                {
                    Standard objStandard = new Standard();
                    objStandard.StandardName = txtStdName.Text;
                    objStandard.Stream.Name = cmbSStream.Text;
                    objStandard.Branch.BranchId = Program.LoggedInUser.BranchId;

                    //objStandard.SubjectList = string.Join(",", from subject in lstSubjcts.Items.Cast<String>() select subject);
                    objStandard.DurationInMonths = Convert.ToInt32(txtDuration.Text);
                    if (StandardHandller.addStandard(objStandard))
                    {
                        UICommon.WinForm.showStatus("Course Added Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                    LoadStandards();
                    txtStdName.Clear();
                    txtStdName.Enabled = true;
                    txtStdName.Select();
                }
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this, "The standard name \"" + txtStdName.Text + "\" already exists");
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnDelStnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstStndrds.SelectedItem != null)
                {
                    if (StandardHandller.removeStandard(((Standard)lstStndrds.SelectedItem).Standardid, Program.LoggedInUser.BranchId))
                    {

                        LoadStandards();
                        UICommon.WinForm.showStatus("course deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                }
                else
                {
                    UICommon.WinForm.showStatus("No Course available to delete", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Can not delete record as it is used in child tables s_pr_del_standard"))
                {
                    UICommon.WinForm.showStatus("Batch For This Standard Exists or Student For This Standard Exists", sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, sCaption, this);
                }
            }
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate_btnAddBatch())
                {
                    Batch objBatch = new Batch();

                    objBatch.Name = txtBatch.Text;
                    objBatch.StandardID = Convert.ToInt32(cmbStandard.SelectedValue);
                    objBatch.location = txtLocation.Text;
                    objBatch.StartDate = dtpStartDate.Value;
                    objBatch.FromTime = fromTime.Value;
                    objBatch.ToTime = toTime.Value;
                    objBatch.minPercent = (MinPercent.Text)== "" ? 30 : Convert.ToInt32(MinPercent.Text);
                    objBatch.Branch = new Branch(Program.LoggedInUser.BranchId);

                    if (StandardHandller.addBatch(objBatch))
                    {
                        UICommon.WinForm.showStatus("Batch created successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        LoadBatches();
                        txtBatch.Clear();
                        txtBatch.Select();
                        MinPercent.Clear();
                    }

                }
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this, "The batch \"" + txtBatch.Text + "\" already exists");
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnRemoveBatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBatches.SelectedItem != null)
                {

                    if (StandardHandller.removeBatch((Batch)lstBatches.SelectedItem) == true)
                    {
                        LoadBatches();
                        UICommon.WinForm.showStatus("Batch deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Can not delete batch as student exists in this batch", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }

                else
                {
                    UICommon.WinForm.showStatus("No Batch available to delete", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
                //UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSubjectPackageMasterForm objCreatePackage = (FrmSubjectPackageMasterForm)UICommon.FormFactory.GetForm(Forms.FrmSubjectPackageMasterForm);
               
                objCreatePackage.Visible = true;
                this.Close();
                
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        }
    }
}
