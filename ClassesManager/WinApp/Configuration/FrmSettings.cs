using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
namespace ClassManager.WinApp
{
    public partial class FrmSettings : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string sCaption = "Settings";
        string changeParam;
        bool value;
        public FrmSettings()
        {
            InitializeComponent();
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                AssignEvents();
                lblCon.Text = BLL.DBHandller.getConnectionDescription();
                assignOriginalSettings();

                txtDeviceID.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_IP;
                txtPortNo.Text = ClassManager.Common.Properties.Settings.Default.MACHINE_PORT;


                if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME) == "Gym")
                {
                    chkbxSendAbsentSMS.Visible = false;
                    chkbxSignINSMS.Visible = false;
                    chkbxSignOUTSMS.Visible = false;
                    chkbxLectureSMSToFaculty.Visible = false;
                    chkbxSendDueNotification.Visible = false;
                    chkbxsndlectsmsstudent.Visible = false;
                }
            }
            catch(Exception ex)
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {

                    }

                    if (formPrevileges.Modify == false)
                    {
                        cmdUpdate.Visible = false;
                        btnAttendanceUpdate.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {

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


        private void assignOriginalSettings()
        {
            try
            {
                chkEnq.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_ENQ_SMS);
                chkBday.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_BDAY_SMS);
                chkAnni.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_ANNI_SMS);
                chkbxLectureSMSToFaculty.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_LECTURE_SCHEDULE_SMS_FACULTY);
                chkbxSendAbsentSMS.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_ABSENT_SMS);
                chkbxSignINSMS.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_SIGN_IN_SMS);
                chkbxSignOUTSMS.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_SIGN_OUT_SMS);
                chkDailyReports.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_DAILYREPORTS_SMS);
                chkFlwp.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_FOLLOWPUP_SMS);
                chkReg.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_REG_SMS);
                chkSndOutstndngFees.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_OUTSTANDINGFEES_SMS);
                chkFeesSMS.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_FEES_SMS);
                chkbxSendDueNotification.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_DUE_NOTIFICATION);
                chkbxsndlectsmsstudent.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_LECTURESMS_STUDENT);
                chkExpiry.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_EXPIRY_MSG);
                chkTobeExpiry.Checked = SysParam.getValue<Boolean>(SysParam.Parameters.SEND_TOBE_EXPIRY_MSG);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void AssignEvents()
        {
            txtEnterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtPortNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);

        }
        public bool validateEmail()
        {
            if (txtEmail.Text.Length > 0)
            {
                bool isEmail = Regex.IsMatch(txtEmail.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                if (!isEmail)
                {
                    UICommon.WinForm.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtEmail.Focus();
                    return false;
                }
                return true;
            }
            return true;
        }

        //private void cmdUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_ENQ_SMS, chkEnq.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_REG_SMS, chkReg.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_BDAY_SMS, chkBday.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_ANNI_SMS, chkAnni.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_FOLLOWPUP_SMS, chkFlwp.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_DAILYREPORTS_SMS, chkDailyReports.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_OUTSTANDINGFEES_SMS, chkSndOutstndngFees.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_FEES_SMS, chkFeesSMS.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_ABSENT_SMS, chkbxSendAbsentSMS.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_LECTURE_SCHEDULE_SMS_FACULTY, chkbxLectureSMSToFaculty.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_SIGN_IN_SMS, chkbxSignINSMS.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_SIGN_OUT_SMS, chkbxSignOUTSMS.Checked.ToString());
        //        BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_DUE_NOTIFICATION, chkbxSendDueNotification.Checked.ToString());

        //        UICommon.WinForm.showStatus("Settings Updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }

        //}

        private void txtEnterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEnterNo.MaxLength = 10;
        }
        private bool validateSMSPanel()
        {
            try
            {

                if (txtEnterNo.Text.Length < 10)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Number", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                if (txtSMSBody.Text.Length == 0  || txtSMSBody.Text == "")
                {
                    UICommon.WinForm.showStatus("Please Enter Message", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
        //private void btnSendSMS_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validateSMSPanel())
        //        {

        //            bool success = BLL.TestingSampleHandler.sendSampleSMS(txtEnterNo.Text, true, txtSMSBody.Text);
        //            UICommon.WinForm.dispSMSMessage(success, sCaption, this);
        //            txtEnterNo.Text = "";
        //            txtSMSBody.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
        //        {
        //            //UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            UICommon.WinForm.showSMSError(sCaption, this);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //        }
        //    }
        //}
        private bool validateEmailPanel()
        {
            try
            {
                bool isEmail = false;
                isEmail = Regex.IsMatch(txtEmail.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                if (txtEmail.Text.Length == 0 || txtMailBody.Text.Length == 0 || !isEmail)
                {
                    UICommon.WinForm.showStatus("Enter valid Email-ID and Message properly", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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
        //private void btnSendEmail_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (validateEmailPanel())
        //        {
        //            {
        //                bool isSent = BLL.TestingSampleHandler.sendSampleEmail(txtEmail.Text, true, txtMailBody.Text);
        //                UICommon.WinForm.dispMailMessage(isSent, sCaption, this);
        //                clearForm();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Equals("This property is not supported for protocols that do not use URI."))
        //        {
        //            UICommon.WinForm.showStatus("Invalid Email ID.", sCaption, this);
        //        }
        //        else if (ex.Message.EndsWith("which was not supplied."))
        //        {
        //            UICommon.WinForm.showError(ex, sCaption, this);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showError(ex, sCaption, this);
        //        }
        //    }
        //}
        private void clearForm()
        {
            txtMailBody.Text = "";
            txtEmail.Text = "";
        }
        private void btnOpenDeviceMgr_Click(object sender, EventArgs e)
        {
            //RTEventsMain objRtEvents = new RTEventsMain();
            //objRtEvents.Visible = true;
        }

        //private void btnAttendanceUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validateInfo())
        //        {

        //            BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.IS_AUTOMATIC, chkAutomatic.Checked.ToString());
        //            BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.DEVICE_ID, txtDeviceID.Text);
        //            BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.DEVICE_PORT_NO, txtPortNo.Text);
        //            UICommon.WinForm.showStatus("Settings Updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            txtDeviceID.Text = "";
        //            txtPortNo.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;

        //    }
        //}

        private bool validateInfo()
        {
            if (txtDeviceID.Text.Length == 0)
            {
                UICommon.WinForm.showStatus("Please enter Device ID ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;

            }
            else if (txtPortNo.Text.Length == 0)
            {
                UICommon.WinForm.showStatus("Please enter Port No ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            else
            {
                return true;
            }
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            assignOriginalSettings();
        }

        

        private void cmdUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_ENQ_SMS, chkEnq.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_REG_SMS, chkReg.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_BDAY_SMS, chkBday.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_ANNI_SMS, chkAnni.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_FOLLOWPUP_SMS, chkFlwp.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_DAILYREPORTS_SMS, chkDailyReports.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_OUTSTANDINGFEES_SMS, chkSndOutstndngFees.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_FEES_SMS, chkFeesSMS.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_ABSENT_SMS, chkbxSendAbsentSMS.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_LECTURE_SCHEDULE_SMS_FACULTY, chkbxLectureSMSToFaculty.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_SIGN_IN_SMS, chkbxSignINSMS.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_SIGN_OUT_SMS, chkbxSignOUTSMS.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_DUE_NOTIFICATION, chkbxSendDueNotification.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_LECTURESMS_STUDENT, chkbxsndlectsmsstudent.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_FEES_MAIL, chkFeesMail.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_TOBE_EXPIRY_MSG, chkTobeExpiry.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_EXPIRY_MSG, chkExpiry.Checked.ToString());
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SEND_INVOICE_MAIL, chkInvoiceMail.Checked.ToString());


                UICommon.WinForm.showStatus("Settings Updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

       
        private void btnAttendanceUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateInfo())
                {

                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.IS_AUTOMATIC, chkAutomatic.Checked.ToString());
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.DEVICE_ID, txtDeviceID.Text);
                    BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.DEVICE_PORT_NO, txtPortNo.Text);


                    ClassManager.Common.Properties.Settings.Default.MACHINE_IP = txtDeviceID.Text;
                    ClassManager.Common.Properties.Settings.Default.MACHINE_PORT = txtPortNo.Text;

                    ClassManager.Common.Properties.Settings.Default.Save();
                    UICommon.WinForm.showStatus("Settings Updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        private void cmdSyncData_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.setMainFormStatus("Data Sync in progress");
                FrmMainForm.syncData();
                UICommon.WinForm.showStatus("Data sync completed successfully", "Data Sync", this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Sync Data", this, "Unable to complete backup, Please conact support");
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateSMSPanel())
                {

                    bool success = BLL.TestingSampleHandler.sendSampleSMS(txtEnterNo.Text, true, txtSMSBody.Text);
                    UICommon.WinForm.dispSMSMessage(success, sCaption, this);
                    txtEnterNo.Text = "";
                    txtSMSBody.Text = "";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    //UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    UICommon.WinForm.showSMSError(sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateEmailPanel())
                {
                    {
                        bool isSent = BLL.TestingSampleHandler.sendSampleEmail(txtEmail.Text, true, txtMailBody.Text);
                        UICommon.WinForm.dispMailMessage(isSent, sCaption, this);
                        clearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("This property is not supported for protocols that do not use URI."))
                {
                    UICommon.WinForm.showStatus("Invalid Email ID.", sCaption, this);
                }
                else if (ex.Message.EndsWith("which was not supplied."))
                {
                    UICommon.WinForm.showError(ex, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, sCaption, this);
                }
            }
        }
		    
	}
}
