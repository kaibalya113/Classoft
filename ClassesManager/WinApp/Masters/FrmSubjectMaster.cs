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
    public partial class FrmSubjectMaster : FrmParentForm
    {
        RolePrivilege formPrevileges;
        SubjectMaster loadedSubject;

        bool allowIndexChange = false;
        string sCaption = " Subject";
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();

        public FrmSubjectMaster()
        {
            InitializeComponent();
        }

        private void SubjectMaster_Load(object sender, EventArgs e)
        {
            try
            {
                UICommon.WinForm.enableButtonOnItemCount(lstFaculty, btnSave);
                populateStream();

                if (cmbStream.Items.Count > 0)
                {
                    populateCourse((cmbStream.SelectedItem as ComboItem).strKey);
                }
                else
                {
                    UICommon.WinForm.showStatus("No courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

                populateFaculty();
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
                    if (formPrevileges.View == false)
                    {
                        BtnViewTimeTable.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void populateFaculty()
        {
            try
            {
                if (cmbFaculty.Items.Count != -1)
                {
                    cmbFaculty.Items.Clear();
                    DataTable dt = FacultyHandler.getFaculties(branchID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbFaculty.Items.Add(new ComboItem(Convert.ToInt32(dr.ItemArray[0]), dr.ItemArray[1].ToString()));
                    }

                    if (dt.Rows.Count > 0)
                    {
                        cmbFaculty.SelectedIndex = 0;
                    }

                }
                else
                {
                    UICommon.WinForm.showStatus("No Faculties available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void populateCourse(string stream = "%")
        {
            try
            {

                if (cmbStream.Items.Count > 0)
                {
                    cmbCourseType.Items.Clear();
                    List<Standard> lstStd = StandardHandller.getStandard(branchID.ToString(), stream);
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbCourseType.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                    }
                    if (lstStd.Count > 0)
                    {
                        cmbCourseType.SelectedIndex = 0;

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {

                    UICommon.WinForm.showStatus("No Streams available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }



            }
            catch (Exception)
            {
                throw;
            }
        }

        private void populateStream()
        {
            try
            {
                List<Stream> lstStream = StreamHandller.getStreams(branchID);

                foreach (Stream objStream in lstStream)
                {
                    cmbStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }

                if (lstStream.Count == 0)
                {
                    UICommon.WinForm.showStatus("No stream available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return;
                }

                if (loadedSubject != null)
                {
                    foreach(ComboItem comboItem in cmbStream.Items)
                    {
                        if(comboItem.key == loadedSubject.Standard.Stream.ID)
                        {
                            cmbStream.SelectedItem = comboItem;
                            cmbStream.Text = comboItem.name;
                        }
                    }

                    cmbStream.SelectedIndex = cmbStream.Items.IndexOf(cmbStream.SelectedItem);
                }
                else
                {
                    cmbStream.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        private void cmbCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChange)
                {
                    // getSubjects();
                }
            }

            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        internal void loadSubject(int? subjectId)
        {
            try
            {
                if (subjectId != null)
                {
                    loadedSubject = StandardHandller.getSubject(subjectId: subjectId, branchid: branchID);

                    txtNames.Text = loadedSubject.SubjName;

                    foreach (Faculty faculty in loadedSubject.teachingFaculties)
                    {
                        lstFaculty.Items.Add(new ComboItem(faculty.FacultyID,faculty.Name));
                    }

                    btnSave.Text = "Update";

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChange)
                {
                    allowIndexChange = false;
                    string stream = (cmbStream.SelectedItem as ComboItem).strKey;
                    populateCourse(stream);
                    //lstSubjects.DataSource = null;
                }
                allowIndexChange = true;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        public bool validate()
        {
            try
            {
                if (txtNames.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Provide subject name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                //UICommon.WinForm.showError(ex, sCaption, this, "Something went wrong, Please Contact support", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void resetfields()
        {
            txtNames.Text = "";
            lstFaculty.Items.Clear();
            cmbFaculty.SelectedIndex = 0;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnklblFaculty_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmFaculty objfaculty = new FrmFaculty();
            UICommon.WinForm.LinkFaclty(objfaculty, cmbFaculty);

        }

        private void BtnViewTimeTable_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmViewSub).Visible = true;
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
                int subjID;
                string message;

                if (txtNames.Text.Length != 0 && txtNames.Text != null || txtNames.Text.Trim() == "")
                {

                    Info.SubjectMaster objSub = new Info.SubjectMaster();
                    objSub.SubjName = txtNames.Text;
                    objSub.Standard.Standardid = Convert.ToInt32((cmbCourseType.SelectedItem as ComboItem).strKey);
                    objSub.BranchID = Convert.ToInt32(branchID);

                    if (btnSave.Text.Equals("Update"))
                    {
                        subjID = StandardHandller.updateSubject(objSub,loadedSubject.SubjId);
                        message = "Subject Updated Successfully";
                    }
                    else
                    {
                        subjID = StandardHandller.createSubject(objSub);
                        message = "Subject Created Successfully";
                    }

                    

                    String lstfaculty = String.Empty;
                    if (lstFaculty.Items.Count != 0)
                    {
                        foreach (ComboItem faculty in lstFaculty.Items)
                        {
                            BLL.StandardHandller.addSubjectFaculty(subjID, faculty.key, Program.LoggedInUser.BranchId);
                        }
                    }
                    UICommon.WinForm.showStatus(message, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    resetfields();
                }
                else
                {
                    UICommon.WinForm.showStatus("Please enter subject name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Record Already Exists from SP s_pr_add_subject_faculty"))
                {
                    UICommon.WinForm.showStatus("Subject " + txtNames.Text + " is already added for Faculty " + (cmbFaculty.SelectedItem as ComboItem).name, sCaption, this);
                    lstFaculty.Items.Clear();
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Subject is Already Added ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void addFaculty_Click(object sender, EventArgs e)
        {
            try
            {

                if (validate())
                {

                    if (!lstFaculty.Items.Contains(cmbFaculty.SelectedItem))

                    {
                        lstFaculty.Items.Add(cmbFaculty.SelectedItem);
                        UICommon.WinForm.enableButtonOnItemCount(lstFaculty, btnSave);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Faculty already selected", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void removeFaculty_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFaculty.Items.Count == 0)
                {
                    UICommon.WinForm.showStatus("No faculty to remove", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    lstFaculty.Items.Remove(lstFaculty.SelectedItem);
                    UICommon.WinForm.enableButtonOnItemCount(lstFaculty, btnSave);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmFaculty objfaculty = new FrmFaculty();
            UICommon.WinForm.LinkFaclty(objfaculty, cmbFaculty);
            objfaculty.Close();
        }

        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFaculty.DisplayMember = "Name";
                cmbFaculty.ValueMember = "FCLT_ID";

                //  String stream = (cmbFaculty.SelectedItem as Faculty).Name.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lstFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
