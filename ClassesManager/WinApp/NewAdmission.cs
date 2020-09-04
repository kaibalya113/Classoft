using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HerambCoachingClasses.Common;
using HerambCoachingClasses.BLL;


namespace HerambCoachingClasses.WinApp
{
    public partial class NewAdmission : Form
    {
        List<Info.Enquiry> lstEnquiries;
        Boolean bAllowIndexChange;
        Info.Enquiry objEnquiry;
        string sCaption = "New Admission";


        public NewAdmission()
        {
            InitializeComponent();

            txtHSCMarks.KeyPress += new KeyPressEventHandler(upperCharOnly);

        }

        #region "Validation"
        private void upperCharOnly(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtSContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtFFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtMFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtFMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtMMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtFLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtMLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void txtFOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtMOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtMContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtFContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void btnPhoto_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnPhoto_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }


        private void btnReset_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnReset1_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnReset1_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void txtSCCCollegeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtHSCCollegeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtTYCollegeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtSCCYear1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtHSCYear1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtTYYear1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtSCCYear2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtHSCYear2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtTYYear2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtSCCMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtHSCMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtTYMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnRemove_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnRemove_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        public void validateMarks(object sender, KeyEventArgs e)
        {
            try
            {
                int value = Convert.ToInt32((sender as TextBox).Text);
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Please enter Valid Marks.");
                    (sender as TextBox).Text = "";
                }
            }
            catch { }
        }

        private void txtSCCMarks_KeyUp(object sender, KeyEventArgs e)
        {
            validateMarks(sender as Control, e);
        }

        private void txtHSCMarks_KeyUp(object sender, KeyEventArgs e)
        {
            validateMarks(sender as Control, e);
        }

        private void txtTYMarks_KeyUp(object sender, KeyEventArgs e)
        {
            validateMarks(sender as Control, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClsCommon.ClearSpace(this);
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            ClsCommon.ClearSpace(this);
        }
        #endregion

        private void NewAdmission_Load(object sender, EventArgs e)
        {
            Style.FormButtonStyle(this);

            try
            {
                lstEnquiries = EnquiryHandller.GetEnquries(-1);

                cmbStudName.ValueMember = "EnquiryID";
                cmbStudName.DisplayMember = "FullName";

                bAllowIndexChange = false;
                cmbStudName.DataSource = lstEnquiries;

                cmbStudName.Text = "";
                bAllowIndexChange = true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                objEnquiry = lstEnquiries.Find(enq => enq.EnquiryID == Convert.ToInt32(txtEnquiryNo.Text));


                if (objEnquiry == null)
                {
                    UICommon.Common.showStatus("Invalid enquiry Id", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption);
                    txtEnquiryNo.Text = "";

                }
                else
                {
                    assignValueToControls(lstEnquiries.ElementAt(0));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void assignValueToControls(Info.Enquiry objEnquiry)
        {
            txtAddress.Text = objEnquiry.Addres;
            txtFName.Text = objEnquiry.FName;
            txtMName.Text = objEnquiry.MName;
            txtLName.Text = objEnquiry.LName;
            txtSContact.Text = objEnquiry.ContactNo;
        }

        private void cmbStudName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bAllowIndexChange)
            {

                int enquiryId = Convert.ToInt32(cmbStudName.SelectedValue);

                objEnquiry = lstEnquiries.Find(enq => enq.EnquiryID == enquiryId);
                assignValueToControls(objEnquiry);
            }


        }

    }
}
