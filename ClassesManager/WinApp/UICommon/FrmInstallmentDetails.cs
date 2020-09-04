using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmInstallmentDetails : FrmParentForm
    {
        public List<Info.PackageInstallment> objInstallment = new List<Info.PackageInstallment>();
        public const string sCaption = "Installments";
        DateTime startdate = System.DateTime.Now;
        static int numberOfInstallment;

        private  bool isFromPackageView=false;

        public FrmInstallmentDetails()
        {
            InitializeComponent();
        }

        private void Installment_Details_Load(object sender, EventArgs e)
        {
            try
            {
                lstInstallments.DataSource = objInstallment;
                txtTotalInstallment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtInstallmentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtDayGap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        /// <summary>
        /// This function will be called from PackageView Screen.When User clicks Edit button and if that package contains Installments then in that case, this function will be called.
        /// </summary>
        /// <param name = "lstInstallments" ></ param >
        public void bindInstallmentsFromPackageView()
        {
            try
            {
                isFromPackageView = true;
                lstInstallments.DataSource = objInstallment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FrmSubjectPackageMasterForm subjectPackageMasterForm;

        //private void btnAddInst_Click(object sender, EventArgs e)     //By Sayli
        //{
        //    try
        //    {
        //        if (validateForm())
        //        {
        //            if (objInstallment == null)
        //            {
        //                objInstallment = new List<Info.PackageInstallment>();
        //            }

        //            Info.PackageInstallment objPackInstall = new Info.PackageInstallment();
        //            objPackInstall.InstallmentAmount = Convert.ToDecimal(txtInstallmentAmount.Text);
        //            objPackInstall.countofInstallment = objInstallment.Count + 1;
        //            objPackInstall.NoOfMonth = Convert.ToInt32(txtMonth.Text);
        //            objPackInstall.NoOfDays = Convert.ToInt32(txtDayGap.Text);
              
        //            objInstallment.Add(objPackInstall);

        //            isFromPackageView = false;
        //            lstInstallments.DataSource = null;
        //            lstInstallments.DataSource = objInstallment;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Something went wrong please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private bool validateForm()
        {
            try
            {
                if (txtInstallmentAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please enter installment amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (txtDayGap.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please enter no of days", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                return true;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        
        }
       // commented by hemlata (As material skin is used for UI)
        //private void btnRemoveInstallmnent_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lstInstallments.SelectedItem != null)
        //        {
        //            objInstallment.Remove(lstInstallments.SelectedItem as Info.PackageInstallment);
        //            lstInstallments.DataSource = null;
        //            lstInstallments.DataSource = objInstallment;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        //private void btnSaveInstallment_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FrmSubjectPackageMasterForm pkgForm = (FrmSubjectPackageMasterForm)FormFactory.GetForm(Forms.FrmSubjectPackageMasterForm, this, true);
        //        pkgForm.packInstall = objInstallment;
        //        pkgForm.updateFeesInst(pkgForm.packInstall);
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        //private void btnREmove_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        objInstallment.Clear();
        //        lstInstallments.DataSource = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private void txtInstallmentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtInstallmentAmount.SelectionLength = 7;
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMonth.SelectionLength = 2;
        }

        private void txtDayGap_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtDayGap.SelectionLength = 2;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void lstInstallments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFromPackageView == true)
                {
                    Info.PackageInstallment objselectedInstallment = lstInstallments.SelectedItem as Info.PackageInstallment;
                    txtInstallmentAmount.Text = objselectedInstallment.InstallmentAmount.ToString();
                    txtMonth.Text = objselectedInstallment.NoOfMonth.ToString();
                    txtDayGap.Text = objselectedInstallment.NoOfDays.ToString();
                    isFromPackageView = false;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnREmove_Click(object sender, EventArgs e)
        {
            try
            {
                objInstallment.Clear();
                lstInstallments.DataSource = null;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSaveInstallment_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSubjectPackageMasterForm pkgForm = (FrmSubjectPackageMasterForm)FormFactory.GetForm(Forms.FrmSubjectPackageMasterForm,this, true);
            
                pkgForm.packInstall = objInstallment;
                pkgForm.updateFeesInst(pkgForm.packInstall);
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnAddInst_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateForm())
                {
                    if (objInstallment == null)
                    {
                        objInstallment = new List<Info.PackageInstallment>();
                    }

                    Info.PackageInstallment objPackInstall = new Info.PackageInstallment();
                    objPackInstall.InstallmentAmount = Convert.ToDecimal(txtInstallmentAmount.Text);
                    objPackInstall.countofInstallment = objInstallment.Count + 1;
                    objPackInstall.NoOfMonth = Convert.ToInt32(txtMonth.Text);
                    objPackInstall.NoOfDays = Convert.ToInt32(txtDayGap.Text);

                    objInstallment.Add(objPackInstall);

                    isFromPackageView = false;
                    lstInstallments.DataSource = null;
                    lstInstallments.DataSource = objInstallment;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Something went wrong please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnRemoveInstallmnent_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstInstallments.SelectedItem != null)
                {
                    objInstallment.Remove(lstInstallments.SelectedItem as Info.PackageInstallment);
                    lstInstallments.DataSource = null;
                    lstInstallments.DataSource = objInstallment;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
