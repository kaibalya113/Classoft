using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.BLL;

namespace ClassManager.WinApp
{
    public partial class FrmUserParameters : FrmParentForm
    {
        string sCaption = "Parameter";
        int branchId = WinApp.Program.LoggedInUser.BranchId;
        public FrmUserParameters()
        {
            InitializeComponent();
        }

        private void FrmUserParameters_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDetails();
                LoadBrnch();
                AssignEvents();
            }
            catch(Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

      private void LoadDetails()
      {
            try
            {
                DataTable dt = SystemParameterHandler.getUserParam();
               
                
                txtCIN.Text = dt.Rows[0].ItemArray[1].ToString();
                txtPanNo.Text = dt.Rows[1].ItemArray[1].ToString();
                txtEmailSign.Text = dt.Rows[3].ItemArray[1].ToString();
                txtExpense.Text = dt.Rows[5].ItemArray[1].ToString();
               txtFees.Text = dt.Rows[6].ItemArray[1].ToString();
                txtOwnerNo.Text = dt.Rows[7].ItemArray[1].ToString();
                 txtServiceTaxPer.Text = dt.Rows[8].ItemArray[1].ToString();
                txtServiceTaxNo.Text = dt.Rows[9].ItemArray[1].ToString();
              txtClassFullAdd.Text= dt.Rows[4].ItemArray[1].ToString();
                txtSirName.Text = dt.Rows[10].ItemArray[1].ToString();
              txtSMTPPasswrd.Text = dt.Rows[11].ItemArray[1].ToString();
              txtSMTPUsername.Text = dt.Rows[12].ItemArray[1].ToString();
               // txtSMTPPasswrd.Text = dt.Rows[11].ItemArray[1].ToString();
              //  txtSMTPUsername.Text = dt.Rows[12].ItemArray[1].ToString();
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
      }
        private void AssignEvents()
        {
            try
            {
               txtClassCont.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               txtOwnerNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               txtSirName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                txtPanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               txtFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
               txtExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtServiceTaxPer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtCIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtServiceTaxNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadBrnch()
        {
            try
            {
                DataTable dbr = SystemParameterHandler.getBrnchParam(branchId);

                txtSubName.Text = dbr.Rows[0].ItemArray[1].ToString();
                txtClassAddress.Text = dbr.Rows[1].ItemArray[1].ToString();
                txtClassCont.Text = dbr.Rows[2].ItemArray[1].ToString();
                txtClassNote.Text = dbr.Rows[3].ItemArray[1].ToString();
                txtMainImage.Text = dbr.Rows[4].ItemArray[1].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Info.SysParam objsys = new Info.SysParam();
                bool value = false;
                if (validate())
                {
                    objsys.PRM_Name = Info.SysParam.Parameters.CIN_NO.ToString();
                    objsys.PRM_Value = txtCIN.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.FULL_ADDRESS.ToString();
                    objsys.PRM_Value = txtClassFullAdd.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.EMAIL_ADDRESS.ToString();
                    objsys.PRM_Value = txtClassEmail.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.COMPANY_PAN_NO.ToString();
                    objsys.PRM_Value = txtPanNo.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.EMAIL_SIGNATURE_FEES.ToString();
                    objsys.PRM_Value = txtEmailSign.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.NOTIFY_EXPENSE.ToString();
                    objsys.PRM_Value = txtExpense.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.NOTIFY_FEES_RECEIPT.ToString();
                    objsys.PRM_Value = txtFees.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.OWNER_NOS.ToString();
                    objsys.PRM_Value = txtOwnerNo.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    //objsys.PRM_Name = Info.SysParam.Parameters.SENDER_EMAIL.ToString();
                    //objsys.PRM_Value = txtEmailSender.Text.ToString();
                    //value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.SERVICE_TAX.ToString();
                    objsys.PRM_Value = txtServiceTaxPer.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.SERVICE_TAX_NO.ToString();
                    objsys.PRM_Value = txtServiceTaxNo.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.SIR_NAME.ToString();
                    objsys.PRM_Value = txtSirName.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.SMTP_USERNAME.ToString();
                    objsys.PRM_Value = txtSMTPUsername.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);


                    objsys.PRM_Name = Info.SysParam.Parameters.SMTP_PASSWORD.ToString();
                    objsys.PRM_Value = txtSMTPPasswrd.Text.ToString();
                    value = BLL.SystemParameterHandler.updateSystemParam(objsys);

                    objsys.PRM_Name = Info.SysParam.Parameters.SUB_NAME.ToString();
                    objsys.PRM_Value = txtSubName.Text.ToString();
                    value = BLL.SystemParameterHandler.updateBranchParam(objsys, branchId);

                    objsys.PRM_Name = Info.SysParam.Parameters.ADDRESS.ToString();
                    objsys.PRM_Value = txtClassAddress.Text.ToString();
                    value = BLL.SystemParameterHandler.updateBranchParam(objsys, branchId);

                    objsys.PRM_Name = Info.SysParam.Parameters.CONTACT_NO.ToString();
                    objsys.PRM_Value = txtClassCont.Text.ToString();
                    value = BLL.SystemParameterHandler.updateBranchParam(objsys, branchId);

                    objsys.PRM_Name = Info.SysParam.Parameters.NOTE.ToString();
                    objsys.PRM_Value = txtClassNote.Text.ToString();
                    value = BLL.SystemParameterHandler.updateBranchParam(objsys, branchId);

                    objsys.PRM_Name = Info.SysParam.Parameters.MAIN_FORM_IMAGE.ToString();
                    objsys.PRM_Value = txtMainImage.Text.ToString();
                    value = BLL.SystemParameterHandler.updateBranchParam(objsys, branchId);

                    UICommon.WinForm.showStatus("Parameters Updated SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }
           
          private bool validate()
        {
            try
            {
                if (txtClassAddress.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Invalid Class Address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtClassAddress.Focus();
                    return false;
                }


                else if (txtClassCont.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Invalid Contact Number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtClassCont.Focus();
                    return false;
                }
                else if (txtOwnerNo.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Invalid Contact Number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtOwnerNo.Focus();
                    return false;
                }

                else if (txtMainImage.Text.Trim() == "")
                {

                    UICommon.WinForm.showStatus("Invalid Image Path", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtMainImage.Focus();
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

        private void txtClassCont_KeyPress(object sender, KeyPressEventArgs e)
        {
             
            try
            {
                if (txtClassCont.Text.Length >= 10)
                {
                    if (e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        
    }

        private void txtOwnerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtOwnerNo.Text.Length >= 10)
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

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtFees.Text.Length >= 10)
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

        private void txtExpense_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtExpense.Text.Length >= 10)
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
    }
}
