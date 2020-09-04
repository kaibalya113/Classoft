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
    public partial class FrmFollowUp :  FrmParentForm
    {

        RolePrivilege formPrevileges;

       public List<Info.Enquiry> lstEnquiries;
      
      
        public Student objStudent;
        public Enquiry objEnq;
        Boolean bAllowIndexChange;
        public Followup objFollow;
        public Fees objFees;
        public string sCaption = "NewFollowup";
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        public FrmFollowUp()
        {
            InitializeComponent();
        }

        private void NewFollowUp_Load(object sender, EventArgs e)
        {
            try
            {
                if (objEnq == null && objFollow == null)
                {
                    loadDetails();
                    bAllowIndexChange = true;

                    ApplyPrevileges();

                }
                formatForm();
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
                UICommon.WinForm.formatDateTimePicker(dtFollowup, Common.Formatter.DateFormat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadDetails(string branchID= null)
        {
            try
            {
                lstEnquiries = EnquiryHandller.GetEnquries(-1, branchId);

                cmbStudName.ValueMember = "EnquiryID";
                cmbStudName.DisplayMember = "FullName";

                cmbStudName.DataSource = lstEnquiries;

                //following code is for do not put previous date
                dtFollowup.MinDate = System.DateTime.Now.AddDays(1); //it show error while retriving previous details 

                txtEnquiryNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEnquiryNo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter enquiry Id", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtEnquiryNo.Focus();
                    panel3.Visible = true;
                    clearall();
                   
                }
                else
                {
                    objEnq = lstEnquiries.Find(enq => enq.EnquiryID == Convert.ToInt32(txtEnquiryNo.Text));
                    objFollow = FollowupHandler.getFollowup(branchId, objEnq.EnquiryID.ToString()).FirstOrDefault();
                    if (objEnq == null || objFollow == null)
                    {
                        UICommon.WinForm.showStatus("No search found.\n\n Please enter valid enquiry id", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtEnquiryNo.Text = "";
                        txtEnquiryNo.Focus();
                        panel3.Visible = true;
                    }
                    else
                    {
                        objFollow = EnquiryHandller.getLatestFollowup(objEnq.EnquiryID);
                        assignValueToControls(objEnq, objFollow);
                        panel3.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
            }

        }


        private void assignValueToControls(Info.Enquiry objEnquiry, Info.Followup objFol)
        {
            try
            {
                txtEnquiryNo.Text = objEnquiry.EnquiryID.ToString();
                lblStudName.Text = objEnquiry.Fullname.ToString();
                lblStandard.Text = objEnquiry.Standard.StandardName;
                lblPhnNo.Text = objEnquiry.ContactNo.ToString();
                //label4.Text = objFollow.FollowupDesc.ToString();
                if (objFol != null)
                {
                  
                    lblPrevDesc.Text = (objFollow.FollowupDesc.ToString()) == "" ? "will call" : (objFollow.FollowupDesc.ToString());
                    lblPrevFDt.Text = objFol.FollowupDate.ToString(Common.Formatter.DateFormat);
                    cmbMediam.Text = objFol.FollowupMediam.ToString();
                }
                else
                {
                    lblPrevDesc.Text = "";
                    lblPrevFDt.Text = "";
                    cmbMediam.Text = "";

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
        //        if (validateFollowupDetails())
        //        {
        //            Followup objFollowup = new Followup();
        //            objFollowup.ReferenceID = txtEnquiryNo.Text;
        //            objFollowup.FollowupType = txtType.Text;
        //            objFollowup.FollowupDate = dtFollowup.Value;
        //            objFollowup.FollowupDesc = txtDescription.Text;
        //            objFollowup.FollowupMediam = cmbMediam.Text;
                   
        //            FollowupHandler.SaveFollowup(objFollowup, branchId);

        //            Enquiry objEnquiry = new Enquiry();
        //            objEnquiry.FName = lblStudName.Text;
        //            objEnquiry.Standard.StandardName = lblStandard.Text;
        //            objEnquiry.ContactNo = lblPhnNo.Text;
        //            objEnquiry.EnquiryID = Convert.ToInt32(txtEnquiryNo.Text);

        //            UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            clearall();

        //            if (this.Modal)
        //            {
        //                this.Close();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }

        //}


        public bool validateFollowupDetails()
        {
            try
            {
                if (txtEnquiryNo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter enquiry Id", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                    txtEnquiryNo.Focus();
                    return false;
                }
                else if (dtFollowup.Value.ToShortDateString()==System.DateTime.Now.ToShortDateString())
                {
                    UICommon.WinForm.showStatus("Next Followup-Date Should be greater than todays date", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    dtFollowup.Focus();
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


        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        clearall();
        //        panel3.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
           
        //}


        public void clearall()
        {
            try
            {
                cmbMediam.Text = "";

                txtDescription.Clear();
                txtEnquiryNo.Clear();
                lblPrevDesc.Text = "";
                lblPrevFDt.Text = "";
                lblStudName.Text = "";
                lblStandard.Text = "";
                lblPhnNo.Text = "";
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        private void txtEnquiryNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string refcID = txtEnquiryNo.Text;
                if (refcID.Length > 0)
                {
                    // lstFollo = FollowupHandler.getFollowup(branchId, refcID);
                }
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
                //if (bAllowIndexChange && ! this.Modal)
                if(bAllowIndexChange)
                {
                   // bAllowIndexChange = false;
                    int enquiryId = Convert.ToInt32(cmbStudName.SelectedValue);
                    txtEnquiryNo.Text = enquiryId.ToString();
                    setEnquiry(enquiryId,branchId);
                    //bAllowIndexChange = false;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        public void setEnquiry(int enquiryId, string branchID)
        {
            try
            {
                if (lstEnquiries == null || lstEnquiries.Count < 1)
                {
                    loadDetails(branchID);
                }

                objEnq = lstEnquiries.Find(enq => enq.EnquiryID == enquiryId);
                objFollow = FollowupHandler.getFollowup(branchID, enquiryId.ToString()).FirstOrDefault();
                //bAllowIndexChange = false;
                cmbStudName.SelectedItem = objEnq;
                //cmbStudName.Enabled = false;
                cmbStudName.Enabled = true;
                assignValueToControls(objEnq, objFollow);
                panel3.Visible = true;
                bAllowIndexChange = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //private void btnViewFollow_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUpVew).Visible = true;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }
        //}

        private void btnViewFollow_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUpVew).Visible = true;
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
                if (validateFollowupDetails())
                {
                    Followup objFollowup = new Followup();
                    objFollowup.ReferenceID = txtEnquiryNo.Text;
                    objFollowup.FollowupType = txtType.Text;
                    objFollowup.FollowupDate = dtFollowup.Value;
                    objFollowup.FollowupDesc = txtDescription.Text;
                    objFollowup.FollowupMediam = cmbMediam.Text;

                    FollowupHandler.SaveFollowup(objFollowup, branchId);

                    Enquiry objEnquiry = new Enquiry();
                    objEnquiry.FName = lblStudName.Text;
                    objEnquiry.Standard.StandardName = lblStandard.Text;
                    objEnquiry.ContactNo = lblPhnNo.Text;
                    objEnquiry.EnquiryID = Convert.ToInt32(txtEnquiryNo.Text);

                    UICommon.WinForm.showStatus("Details saved successfully  ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    clearall();

                    if (this.Modal)
                    {
                        this.Close();
                    }

                }
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
                clearall();
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
