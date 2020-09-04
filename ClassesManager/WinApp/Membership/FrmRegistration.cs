using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.Info;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmRegistration : FrmParentForm
    {
        const string sCaption = "Registration";

        public FrmRegistration()
        {
            InitializeComponent();

            txtSerial.Text = Common.FingerPrint.Value();
            txtSerial.Enabled = false;
        }

        private void btnGenLincence_Click(object sender, EventArgs e)
        {
            string licenceData = "S:" + txtSerial.Text + ",C:" + txtContactNo + ",N:" + txtName.Text + ",T:" + cmbType.Text;

            if (rbRegSMS.Checked)
            {
                BLL.MailHandler.sendSMS(Info.SmsConfig.getSMSConfig(), licenceData, Info.SysParam.getValue<string>(Info.SysParam.Parameters.SUPPORT_CONTACT), false, "LicenceSMS");

                UICommon.WinForm.showStatus("You will receive a licence key on your registred contact no \n Registration", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            else
            {
                //send licencedata to php page;
            }
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            if (txtContactNo.Text == "")
            {

                UICommon.WinForm.showStatus("Please enter registred contact no", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            else
            {
                int noOfMonths = 0;
                string keyStatus = Common.FingerPrint.validateLicence(txtContactNo.Text, txtLicence.Text,out noOfMonths);
                if (keyStatus.Equals("E"))
                {
                    UICommon.WinForm.showStatus("Your licence is expired, Please contact our support", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else if (keyStatus.Equals("I"))
                {
                    UICommon.WinForm.showStatus("Invalid licence key, Please provide valid licence key", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
                else
                {
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.REG_CONTACT, txtContactNo.Text);

                    string licenceKey;

                    if(rbClearExisting.Checked == false)
                    {
                        licenceKey = SysParam.getValue<String>(Info.SysParam.Parameters.LICENCE_KEY) + "," + txtLicence.Text;
                    }
                    else
                    {
                        licenceKey = txtLicence.Text;
                    }

                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.LICENCE_KEY, licenceKey);
                    UICommon.WinForm.showStatus("Great.. You have successfully registred your copy, Please login", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    FrmLogin.getInstance().Visible = true;
                    this.Visible = false;
                }
            }
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                string lcnMonth;
                string lcn;
                string Reg = Info.SysParam.getValue<String>(SysParam.Parameters.LICENCE_KEY);
                txtContactNo.Text = Info.SysParam.getValue<String>(Info.SysParam.Parameters.REG_CONTACT);
                if (Reg != "DEMO" && Reg != null && Reg.Length > 0)
                {
                    lcnMonth = (Reg.Substring(2, 2)).ToString();//+ "/" + Reg.Substring(6, 2)
                    int num = int.Parse(lcnMonth);
                    num = num + 1;

                    NumberToMonth.Months months = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), num.ToString());
                    int noOfMonths = 0;
                    string keyStatus = Common.FingerPrint.validateLicence(txtContactNo.Text, Reg,out noOfMonths);
                    if (keyStatus.Equals("E"))
                    {
                        UICommon.WinForm.showStatus("Your licence is expired, Please contact our support", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else if (keyStatus.Equals("I"))
                    {
                        UICommon.WinForm.showStatus("Invalid licence key, Please provide valid licence key", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        lcn = (months + "/" + Reg.Substring(6, 2)).ToString();
                        UICommon.WinForm.showStatus("Software is Already Registered to " + Info.SysParam.getValue<String>(SysParam.Parameters.NAME).ToString() + ", \nNext Renewal on " + lcn, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        FrmLogin.getInstance().Visible = true;
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Register Your Copy", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

            }            
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private delegate void InvokeDelegate();

        private void CancelLoading()
        {    // will cancel loading this form
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BeginInvoke(new InvokeDelegate(CloseThisForm));
        }

        private void CloseThisForm()
        {
            this.Close();
        }
        // NumberToMonth.Months installmonth = (NumberToMonth.Months)Enum.Parse(typeof(Common.NumberToMonth.Months), objTransaction.Month.ToString());
    }
}
