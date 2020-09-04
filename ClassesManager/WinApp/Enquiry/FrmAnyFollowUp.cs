using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmAnyFollowUp : FrmParentForm
    {
        string sCaption = "AnyFollowUp";
        int branchID = Program.LoggedInUser.BranchId;
        Info.RolePrivilege formPrevileges;
        Student objStudent;
     //   String StudentNameConvention = Info.SysParam.getValue<string>(SysParam.Parameters.UISTUDENTNAME_CONVENTION);

        public FrmAnyFollowUp()
        {
            InitializeComponent();
        }

        private void FrmAnyFollowUp_Load(object sender, EventArgs e)
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtFollowupDate);
                fillcmbType();
                cmbMediam.SelectedIndex = 0;
               cmbType.SelectedIndex = 2;
                //ApplyPrevileges();
                loadFields();
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
                    //if (formPrevileges.AllBranches == false)
                    //{
                    //    chkShowAllBranch.Visible = false;
                    //}

                    //if (formPrevileges.Modify == false)
                    //{
                    //    btnUpdatePaidExp.Visible = false;
                    //}

                    if (formPrevileges.Create == false)
                    {
                        //cmdCreateExpence.Visible = false;
                        //cmdAddExpense.Visible = false;
                        //tabPCreateExpense.Hide();
                        btnSave.Visible = false;
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

        private bool validateForm()
        {
            try
            {
                if (cmbType.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select type of the FollowUp", sCaption, this);
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

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validateForm())
        //        {

        //            Followup objFollowup = new Followup();
        //            objFollowup.ReferenceID = objStudent.AdmissionNo.ToString();
        //            // objFollowup.FollowupType = cmbType.SelectedText.ToString();
        //            objFollowup.FollowupType = cmbType.SelectedItem.ToString();
        //            objFollowup.FollowupDate = dtFollowupDate.Value;
        //            objFollowup.FollowupDesc = txtDescription.Text;
        //            objFollowup.FollowupMediam = cmbMediam.Text;

        //            FollowupHandler.saveAnyFollowup(objFollowup, branchID);

        //            UICommon.WinForm.showStatus("Folloup created successfully", "Folloup", this);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        UICommon.WinForm.showError(ex, sCaption, this);
        //    }
        //}

        public void setValue(Student objStudent)
        {
            try
            {
                this.objStudent = objStudent;
                lblStudName.Text = objStudent.DisplayName;
                lblStandard.Text = objStudent.Course.Standard.ToString();
                lblPhnNo.Text = objStudent.ContactNo;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void loadFields()
        {

            string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
            if (check == "")
            {
                cmbFollowby.Visible = false;

            }
            else
            {
                string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');


                foreach (String value in items)
                {
                    cmbFollowby.Items.Add(value);
                }
            }
        }
        public void fillcmbType()
        {
            string app = (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString());

            if (app == "Gym" || app == "Dance")
            {
                cmbType.Items.Insert(0, "Attendance");
                cmbType.Items.Insert(1, "Outstanding");
                cmbType.Items.Insert(2, "Renewals");
            }
            if (app == "Asset" || app == "")
            {
                cmbType.Items.Insert(0, "Attendance");
                cmbType.Items.Insert(1, "Outstanding");
                cmbType.Items.Insert(2, "Academic");
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (validateForm())
                {

                    Followup objFollowup = new Followup();
                    objFollowup.ReferenceID = objStudent.AdmissionNo.ToString();
                    // objFollowup.FollowupType = cmbType.SelectedText.ToString();
                    objFollowup.FollowupType = cmbType.SelectedItem.ToString();
                    objFollowup.FollowupDate = dtFollowupDate.Value;
                    objFollowup.FollowupDesc = txtDescription.Text;
                    objFollowup.FollowupMediam = cmbMediam.Text;
                    objFollowup.FollowupBy = (cmbFollowby.SelectedIndex == -1 ? "NA" : cmbFollowby.SelectedItem.ToString());
                    FollowupHandler.saveAnyFollowup(objFollowup, branchID);

                    UICommon.WinForm.showStatus("Followup created successfully", "Folloup", this);

                    cmbMediam.SelectedIndex = 0;
                    cmbType.SelectedIndex = 2;
                    txtDescription.Text = "";
                    // objFollowup.Close();
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }


    }
}
