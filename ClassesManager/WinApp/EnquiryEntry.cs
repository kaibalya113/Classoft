using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HerambCoachingClasses.Common;
using HerambCoachingClasses.Info;
using HerambCoachingClasses.BLL;

namespace HerambCoachingClasses.WinApp
{
    public partial class EnquiryEntry : Form
    {
        const string sCaption = "Enquiry";
        public EnquiryEntry()
        {
            InitializeComponent();
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

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void txtMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtMarks_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int value = Convert.ToInt32((sender as TextBox).Text);
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Please enter Valid Marks.");
                    txtMarks.Text = "";
                }
            }
            catch { }
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClsCommon.ClearSpace(this);
        }

        private void btnReset_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void EnquiryEntry_Load(object sender, EventArgs e)
        {
            Style.FormButtonStyle(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Enquiry objEnquiry = new Enquiry();
                objEnquiry.Addres = txtAddress.Text;
                objEnquiry.ClgName = cmbCollege.Text;
                objEnquiry.ContactNo = txtContact.Text;
                objEnquiry.FName = txtFName.Text;
                objEnquiry.LName = txtLName.Text;
                objEnquiry.LstYerMarks = Convert.ToSingle(txtMarks.Text);
                objEnquiry.MName = txtMName.Text;
                objEnquiry.Stadard = cmbStandard.Text;
                objEnquiry.Stream = cmbStream.Text;

                EnquiryHandller.SaveEnquiry(objEnquiry);

                showStatus("Details saved successfully, Enquiry id is " + objEnquiry.EnquiryID, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                showStatus("Error occured while saving enquiry details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void showStatus(string message, MessageBoxButtons button, MessageBoxIcon icon)
        {
            MessageBox.Show(message, sCaption, button, icon);
        }





    }
}
