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
using System.Threading;
using ClassManager.WinApp.UICommon;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ClassManager.WinApp.Asset
{
    public partial class FrmEnquiryEntryForm : FrmParentForm
    {

        RolePrivilege formPrevileges;
        const string sCaption = "Enquiry";
        bool status;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        Enquiry objEnquiry = new Enquiry();
        //Declared for Update Enquiry.Mohan(15-July-2017).
        int enquiryid = 0;
        int stdid = 0, streamid = 0;



     //   String StudentNameConvention = Info.SysParam.getValue<string>(SysParam.Parameters.UISTUDENTNAME_CONVENTION);
        public FrmEnquiryEntryForm()
        {
            InitializeComponent();
            //MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //// Configure color schema
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Orange200, Primary.Orange200,
            //    Primary.Orange200, Accent.Orange200,
            //    TextShade.BLACK);
        }

        private void ResetForm(Control control)
        {
            try
            {
                txtFName.Text = "";
                txtLName.Text = "";
                txtMName.Text = "";
                txtFees.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtDescription.Text = "";
                txtEmailID.Text = "";
                cmbRefBy.SelectedIndex = 1;
                cmbStandard.SelectedIndex = 0;
                cmbStream.SelectedIndex = 0;
                txtParentContact.Text = "";
                dtpDOB.Value = DateTime.Now;
                cmbQualification.SelectedIndex = 0;
                cmbField.SelectedIndex = -1;
                txtFees.Text = "";
                txtSubjects.Text = "";
                cmbstatus.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        

        private void EnquiryEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = true;
                if (this.IsMdiChild != true)
                {
                    btnSave.Text = "UPDATE";
                    
                    ApplyPrevileges();
                    AssignEvents();
                    //loadFields();
                    
                }
                else
                {
                    Date();
                    AssignEvents();
                    cmbStream.DataSource = StreamHandller.getStreams(branchID);
                    if (cmbStream.Items.Count > 0)
                    {
                        cmbStream.SelectedIndex = 0;
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No Course Available", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                    cmbstatus.SelectedIndex = 1;

                    cmbRefBy.SelectedIndex = 1;
                    loadFields();
                    txtFName.Focus();
                    ApplyPrevileges();
                    cmbQualification.SelectedIndex = 0;
                    //When open for update.
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void Date()
        {
            dtFollowup.MinDate = DateTime.Now;
            dtpEnquiryDate.Value = DateTime.Now;
            //dtpDOB.MaxDate = DateTime.Now.AddYears(-2);
            dtpDOB.Value = DateTime.Now;
            UICommon.WinForm.formatDateTimePicker(dtpDOB, Common.Formatter.DateFormat);
            UICommon.WinForm.formatDateTimePicker(dtFollowup, Common.Formatter.DateFormat);
            UICommon.WinForm.formatDateTimePicker(dtpEnquiryDate, Common.Formatter.DateFormat);
        }

        /// <summary>
        /// This Function will assign Privileges based on the type of the user logged in.
        /// </summary>
        private void ApplyPrevileges()
        {
            try
            {
                int functionId = Convert.ToInt32(this.Tag.ToString());
            


                formPrevileges=  BLL.UserHandler.loggedInUser.privileges.Where(se => se.FunctionId == functionId).FirstOrDefault();
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
                        btnViewAll.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void loadFields()
        {
            try
            {
                string check = (Info.SysParam.getValue<String>(SysParam.Parameters.FIELDS).ToString());
                if (check == "")
                {
                    cmbField.Visible = false;
                    lblBrnch.Visible = false;
                }
                else
                {
                    string[] items = SysParam.getValue<string>(SysParam.Parameters.FIELDS).Split(',');

                    
                    foreach (String value in items)
                    {
                        cmbField.Items.Add(value);
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
            txtParentContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
            txtMName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.upperCharOnly);
          //  txtFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }

        private bool validate()
        {
            bool isEmail = true;
            try
            {
                if (txtFName.Text.Length == 0 || txtFName.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Student First Name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtFName.Focus();
                    return false;
                }
                else if (txtContact.Text.Length != 0 && txtContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Phone Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon. Information, sCaption, this);
                    txtContact.Focus();
                    return false;
                }

                else if (txtContact.Text.Length == 0||txtContact.Text.Trim()=="")
                {
                    UICommon.WinForm.showStatus("Please fill student contact number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtContact.Focus();
                    return false;
                }
                else if (cmbStandard.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select Course Type", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbStandard.Focus();
                    return false;
                }
                if (txtEmailID.Text.Length != 0)
                {
                    isEmail = Regex.IsMatch(txtEmailID.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                }
                if (!isEmail)
                {
                    UICommon.WinForm.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtEmailID.Focus();
                    return false;
                }
               
                else if (txtParentContact.Text.Length != 0 && txtParentContact.Text.Length != 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Phone Number as length is not equal to 10.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtContact.Focus();
                    return false;
                }
               else if (string.IsNullOrWhiteSpace(txtFees.Text) && txtFees.Text.Length > 0)
                {
                    UICommon.WinForm.showStatus("Enter valid Amount.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtParentContact.Focus();
                    return false;
                }
                else if (dtpDOB.Value.Date > DateTime.Now.Date)
                {
                    UICommon.WinForm.showStatus("Please set Proper birthdate", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtContact.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbStandard.DataSource = null;
                cmbStandard.DataSource = StandardHandller.getStandard(branchID.ToString(),(cmbStream.SelectedItem as Stream).ID.ToString());
                cmbStandard.Text = "";
                cmbStandard.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void bgwekerSendSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            
            Enquiry objEnquiry = (Enquiry)e.Argument;
            bool xyz = MailHandler.sendEnquirySms(objEnquiry.FName + " " + objEnquiry.MName + " " + objEnquiry.LName, objEnquiry.ContactNo, objEnquiry.EnquiryID,objEnquiry.Standard.StandardName, Program.LoggedInUser.BranchName);
            if (xyz)
            {
               UICommon.FormFactory.setMainFormStatus("Send Message from " + sCaption);
               status = true;
            }
            else
            {
                UICommon.FormFactory.setMainFormStatus("Can't send sms " + sCaption);
                status = false;
            }
        }

        private void bgwekerSendSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
            }
            else
            {
                UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
            }

        }


        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {   
            txtContact.SelectionLength = 10;
        }
        
        private void btnViewAll_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmEnquiries frmEnquiries = UICommon.FormFactory.GetForm(UICommon.Forms.FrmEnquiries) as FrmEnquiries;
                frmEnquiries.Visible = true;
                this.Close();
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
                ResetForm(this);
                txtFName.Focus();
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
                  if (btnSave.Text.ToString().Trim() == "SAVE")
                   {
                      if (dtpDOB.Value.Date == DateTime.Now.Date)
                        {
                            var enquiry = UICommon.WinForm.showStatus("Do you want to Save the Birthdate, as it is Today's Date", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                            txtContact.Focus();
                            if (enquiry == DialogResult.Yes)
                            {
                                Branch Branch = new Branch();
                              //  Enquiry objEnquiry = new Enquiry();
                                objEnquiry.FName = txtFName.Text;
                                objEnquiry.MName = txtMName.Text;
                                objEnquiry.LName = txtLName.Text;
                                objEnquiry.Addres = txtAddress.Text;
                                objEnquiry.ContactNo = txtContact.Text;
                                objEnquiry.Standard.Standardid = (cmbStandard.SelectedItem as Standard).Standardid;
                                objEnquiry.EmailID = txtEmailID.Text;
                                objEnquiry.parentContact = txtParentContact.Text;
                                objEnquiry.ReferenceBy = cmbRefBy.Text;
                                objEnquiry.Status = cmbstatus.Text;
                                objEnquiry.EnquiryDate = dtpEnquiryDate.Value;
                                objEnquiry.Batch.id = (cmbBatch.SelectedItem as Batch).id;
                                objEnquiry.Qualification = cmbQualification.SelectedItem.ToString();
                                objEnquiry.Fees = txtFees.Text;
                                objEnquiry.Field = (cmbField.SelectedIndex == -1 ? "NA" : cmbField.SelectedItem.ToString());
                                // objEnquiry.Fees = Convert.ToDecimal((txtFees.Text.Trim()) == "" ? "0" : txtFees.Text);
                                objEnquiry.Subjects = txtSubjects.Text;

                                objEnquiry.Branch.BranchId = Program.LoggedInUser.BranchId;
                                DateTime dateDiff = DateTime.Now;
                                if (dateDiff.ToShortDateString().Equals(dtpDOB.Value.ToShortDateString()))
                                {
                                    objEnquiry.DOB = dtpDOB.Value;
                                }
                                else
                                {
                                    objEnquiry.DOB = dtpDOB.Value;
                                }

                                EnquiryHandller.SaveEnquiry(objEnquiry);

                                Followup objFollowup = new Followup();
                                objFollowup.ReferenceID = objEnquiry.EnquiryID.ToString();
                                objFollowup.FollowupType = Followup.TpyeOfFollowUp.Enquiry.ToString();

                                DateTime dt = dtFollowup.Value.Date;
                                if (dt == System.DateTime.Now.Date && txtDescription.Text == "")
                                {
                                    int addDays = Info.SysParam.getValue<Int32>(SysParam.Parameters.ADD_FOLLWP_DATE);
                                    objFollowup.FollowupDate = dtFollowup.Value.AddDays(addDays);
                                }
                                else
                                {
                                    objFollowup.FollowupDate = dtFollowup.Value;
                                }
                                objFollowup.FollowupDesc = txtDescription.Text;
                                objFollowup.FollowupMediam = Followup.FollowupMedium.Telephonic.ToString();
                                FollowupHandler.SaveFollowup(objFollowup, branchID);
                                UICommon.WinForm.showStatus("Details saved successfully,Enquiry id is:  " + objEnquiry.EnquiryID, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                                ResetForm(this);
                                txtFName.Focus();
                                bgwekerSendSMS.RunWorkerAsync(objEnquiry);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            Branch Branch = new Branch();
                       
                            objEnquiry.FName = txtFName.Text;
                            objEnquiry.MName = txtMName.Text;
                            objEnquiry.LName = txtLName.Text;
                            objEnquiry.Addres = txtAddress.Text;
                            objEnquiry.ContactNo = txtContact.Text;
                            objEnquiry.Standard.Standardid = (cmbStandard.SelectedItem as Standard).Standardid;
                            objEnquiry.EmailID = txtEmailID.Text;
                            objEnquiry.parentContact = txtParentContact.Text;
                            objEnquiry.ReferenceBy = cmbRefBy.Text;
                            objEnquiry.Status = cmbstatus.Text;
                            objEnquiry.EnquiryDate = dtpEnquiryDate.Value;
                            objEnquiry.Batch.id = (cmbBatch.SelectedItem as Batch).id;
                            objEnquiry.Qualification = cmbQualification.SelectedItem.ToString();
                            objEnquiry.Fees = txtFees.Text;
                            objEnquiry.Field = (cmbField.SelectedIndex == -1 ? "NA" : cmbField.SelectedItem.ToString());
                            // objEnquiry.Fees = Convert.ToDecimal((txtFees.Text.Trim()) == "" ? "0" : txtFees.Text);
                            objEnquiry.Subjects = txtSubjects.Text;

                            objEnquiry.Branch.BranchId = Program.LoggedInUser.BranchId;
                            DateTime dateDiff = DateTime.Now;
                            if (dateDiff.ToShortDateString().Equals(dtpDOB.Value.ToShortDateString()))
                            {
                                objEnquiry.DOB = dtpDOB.Value;
                            }
                            else
                            {
                                objEnquiry.DOB = dtpDOB.Value;
                            }

                            EnquiryHandller.SaveEnquiry(objEnquiry);

                            Followup objFollowup = new Followup();
                            objFollowup.ReferenceID = objEnquiry.EnquiryID.ToString();
                            objFollowup.FollowupType = Followup.TpyeOfFollowUp.Enquiry.ToString();

                            DateTime dt = dtFollowup.Value.Date;
                            if (dt == System.DateTime.Now.Date && txtDescription.Text == "")
                            {
                                int addDays = Info.SysParam.getValue<Int32>(SysParam.Parameters.ADD_FOLLWP_DATE);
                                objFollowup.FollowupDate = dtFollowup.Value.AddDays(addDays);
                            }
                            else
                            {
                                objFollowup.FollowupDate = dtFollowup.Value;
                            }
                            objFollowup.FollowupDesc = txtDescription.Text;
                            objFollowup.FollowupMediam = Followup.FollowupMedium.Telephonic.ToString();
                            FollowupHandler.SaveFollowup(objFollowup, branchID);
                            UICommon.WinForm.showStatus("Details saved successfully,Enquiry id is:  " + objEnquiry.EnquiryID, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                            ResetForm(this);
                            txtFName.Focus();
                            bgwekerSendSMS.RunWorkerAsync(objEnquiry);
                        }
                    }

                    else
                    {
                        //BLL.EnquiryHandller.UpdateStatus()
                        Enquiry objEnqUpdate = new Enquiry();
                        objEnqUpdate.FName = txtFName.Text;
                        objEnqUpdate.MName = txtMName.Text;
                        objEnqUpdate.LName = txtLName.Text;
                        objEnqUpdate.Addres = txtAddress.Text;
                        objEnqUpdate.ContactNo = txtContact.Text;
                        objEnqUpdate.Standard.Standardid = (cmbStandard.SelectedItem as Standard).Standardid;
                        objEnqUpdate.EmailID = txtEmailID.Text;
                        objEnqUpdate.parentContact = txtParentContact.Text;
                        objEnqUpdate.ReferenceBy = cmbRefBy.Text;
                        objEnqUpdate.Status = cmbstatus.Text;
                        objEnqUpdate.EnquiryDate = dtpEnquiryDate.Value;
                        objEnqUpdate.Batch.id = (cmbBatch.SelectedItem as Batch).id;
                        objEnqUpdate.Qualification = cmbQualification.SelectedItem.ToString() == null ?  null : cmbQualification.SelectedItem.ToString();

                        objEnqUpdate.Field = (cmbField.SelectedIndex == -1 ? "NA" : cmbField.SelectedItem.ToString());
                        //objEnqUpdate.Fees = Convert.ToDecimal((txtFees.Text.Trim()) == "" ? "0" : txtFees.Text);
                        objEnqUpdate.Fees = txtFees.Text;
                        objEnqUpdate.Subjects = txtSubjects.Text;

                        objEnqUpdate.Branch.BranchId = Program.LoggedInUser.BranchId;
                        DateTime dateDiff = DateTime.Now.AddYears(-2);
                        if (dateDiff.ToShortDateString().Equals(dtpDOB.Value.ToShortDateString()))
                        {
                            objEnqUpdate.DOB = dtpDOB.Value;
                        }
                        else
                        {
                            objEnqUpdate.DOB = dtpDOB.Value;
                        }

                        objEnqUpdate.EnquiryID = enquiryid;
                        BLL.EnquiryHandller.updateEnquiry(objEnqUpdate);
                        WinForm.showStatus("Updated Successfully.", sCaption, this);
                        this.Close();
                        FrmEnquiries objEnq = (FrmEnquiries)UICommon.FormFactory.GetForm(Forms.FrmEnquiries, this, true);
                        objEnq.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Student Already Enquired for Course"))
                {
                    UICommon.WinForm.showStatus("Student Already Enquired for Course", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }


                else if (ex.Message.Equals("Record Already Exists from SP s_pr_create_enquiry"))
                {
                    if(objEnquiry.IsRegistered == true)
                    {
                        UICommon.WinForm.showStatus("Student Already Enquired and Registered \n Enquiry Id :" + objEnquiry.EnquiryID, sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Student Already Enquired \n Enquiry Id :" + objEnquiry.EnquiryID, sCaption, this);
                    }
                   
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

                }
                
            }
            ResetForm(this);
        }

        private void txtParentContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtParentContact.Text.Length >= 10)
            {
                if (e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
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

        private void txtFName_Click(object sender, EventArgs e)
        {

        }

        private void txtMName_Click(object sender, EventArgs e)
        {

        }

        private void txtLName_Click(object sender, EventArgs e)
        {

        }

        private void txtFees_Click(object sender, EventArgs e)
        {

        }

        private void lblBrnch_Click(object sender, EventArgs e)
        {

        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStandard.SelectedIndex > -1)
                {

                    cmbBatch.DataSource = null;
                    cmbBatch.DataSource = StandardHandller.GetBatches((cmbStandard.SelectedItem as Standard).Standardid, Convert.ToInt16(branchID));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Setting Values For Update.(15-July-2017).
        public void setValuesForUpdate(string EnquiryID)
        {
            try
            {
                loadFields();
                DataSet record = BLL.EnquiryHandller.getEnquiry(EnquiryID);

                txtFName.Text = record.Tables[0].Rows[0].ItemArray[1].ToString();
                txtMName.Text = record.Tables[0].Rows[0].ItemArray[2].ToString();
                txtLName.Text = record.Tables[0].Rows[0].ItemArray[3].ToString();
                txtAddress.Text = record.Tables[0].Rows[0].ItemArray[4].ToString();
                txtContact.Text = record.Tables[0].Rows[0].ItemArray[5].ToString();
                txtParentContact.Text = record.Tables[0].Rows[0].ItemArray[16].ToString();
                txtEmailID.Text = record.Tables[0].Rows[0].ItemArray[10].ToString();
                dtpDOB.Value = Convert.ToDateTime(record.Tables[0].Rows[0].ItemArray[15]);
                txtFees.Text = record.Tables[0].Rows[0].ItemArray[18].ToString();
                cmbQualification.Text = record.Tables[0].Rows[0].ItemArray[28].ToString();
                cmbRefBy.Text = record.Tables[0].Rows[0].ItemArray[11].ToString();
                //txtFees.Text = record.Tables[0].Rows[0].ItemArray[4].ToString();
                cmbstatus.SelectedItem= record.Tables[0].Rows[0].ItemArray[20].ToString().Trim();
                dtpEnquiryDate.Value = Convert.ToDateTime(record.Tables[0].Rows[0].ItemArray[9]);
                cmbField.Text = record.Tables[0].Rows[0].ItemArray[17].ToString().Trim();
                //cmbStream.SelectedItem = 
                cmbStream.DataSource = StreamHandller.getStreams(branchID);
                cmbStream.Text = record.Tables[2].Rows[0].ItemArray[1].ToString();
                cmbStandard.DataSource = StandardHandller.getStandard(branchID.ToString(), (cmbStream.SelectedItem as Stream).ID.ToString());
                cmbStandard.Text = record.Tables[0].Rows[0].ItemArray[31].ToString();
                cmbBatch.DataSource = StandardHandller.GetBatches((cmbStandard.SelectedItem as Standard).Standardid , Convert.ToInt16(branchID));
                cmbBatch.Text = record.Tables[3].Rows[0].ItemArray[0].ToString();
                txtSubjects.Text = record.Tables[0].Rows[0].ItemArray[19].ToString();
                enquiryid = Convert.ToInt32(record.Tables[0].Rows[0].ItemArray[0]);
                txtDescription.Text = record.Tables[4].Rows[0].ItemArray[4].ToString();
                btnReset.Visible = false;
                Info.ComboItem objStatus = new Info.ComboItem(3, "Not Interested");
                cmbstatus.Items.Add(objStatus);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
