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
using System.Configuration;
using ClassManager.WinApp.UICommon;
namespace ClassManager.WinApp
{
    public partial class FrmStudentInstallments : FrmParentForm
    {
        bool changeInstallmentRow = false;

        string sCaption = "Student Installment Details";
        public List<Info.InstallmentDetail> installments;
        decimal totalAmount, newAmount, newDiscount;

        Info.InstallmentDetail selectedInstallment;
        public Student objStudent;
        List<FeeStructure> lstFacility;
        bool allowIndexChange = false;
        public decimal discount;
        public bool isCustom;
        StudentFacility objStuddentFacility;

        public FrmStudentInstallments()
        {
            InitializeComponent();
        }

        public void setInstallments(StudentFacility objFacility, bool fromRegistration = true)
        {
            try
            {

                changeInstallmentRow = false;   //newly added 07/01/2017
                objStuddentFacility = objFacility;

                if (fromRegistration == true && (objFacility.Installments == null || objFacility.Installments.Count == 0))
                {
                    objStuddentFacility.Installments = BLL.FeesHandller.calculateInstallments(objFacility);
                }

                this.installments = objStuddentFacility.Installments.Clone<Info.InstallmentDetail>() as List<Info.InstallmentDetail>;
                this.totalAmount = this.installments.Sum(inst => inst.InstAmount);

                assignDatasource();
                btnDelete.Visible = false;
                btnModify.Visible = false;
                lblOrgDiscount.Text = installments.Sum(inst => inst.Discount).ToString();
                lblOrgFees.Text = objStuddentFacility.Package.PackageCost.ToString(); //installments.Sum(inst => inst.InstAmount).ToString();

                formatForm();
                FormatStudentInstGrid();

                if (fromRegistration == false)
                {
                    btnReset.Visible = false;
                    lblOrgFees.Text = installments.Sum(inst => inst.InstAmount).ToString();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtpInstallmentDate, Common.Formatter.DateFormat);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FormatStudentInstGrid()
        {
            try
            {
                if (ADGVInstallaments.Columns.Contains("InstID"))
                {
                    ADGVInstallaments.Columns["InstID"].Visible = false;
                }
                if (ADGVInstallaments.Columns.Contains("FeesID"))
                {
                    ADGVInstallaments.Columns["FeesID"].Visible = false;
                }
                if (ADGVInstallaments.Columns.Contains("Id"))
                {
                    ADGVInstallaments.Columns["Id"].Visible = false;
                }
                if (ADGVInstallaments.Columns.Contains("CancelledAmount"))
                {
                    ADGVInstallaments.Columns["CancelledAmount"].Visible = false;
                }
                if (ADGVInstallaments.Columns.Contains("Fees"))
                {
                    ADGVInstallaments.Columns["Fees"].Visible = false;
                }
                if (ADGVInstallaments.Columns.Contains("Facility"))
                {
                    ADGVInstallaments.Columns["Facility"].Visible = false;
                }

                ADGVInstallaments.Columns["InstMonth"].Visible = false;
                ADGVInstallaments.Columns["InstNo"].Visible = false;
                ADGVInstallaments.Columns["PaymentDate"].Visible = false;
                ADGVInstallaments.Columns["TodaysDue"].Visible = false;
                ADGVInstallaments.Columns["TodaysDue"].Visible = false;

                ADGVInstallaments.Columns["InstDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVInstallaments.Columns["PaymentDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVInstallaments.Columns["InstAmount"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;
                ADGVInstallaments.Columns["Discount"].DefaultCellStyle = UICommon.WinForm.GridCurrencyFormat;

                ADGVInstallaments.Columns["InstDate"].ReadOnly = true;
                ADGVInstallaments.Columns["PaymentDate"].ReadOnly = true;
                ADGVInstallaments.Columns["InstAmount"].ReadOnly = true;
                ADGVInstallaments.Columns["Discount"].ReadOnly = true;

                ADGVInstallaments.Columns["InstDate"].DisplayIndex = 0;
                ADGVInstallaments.Columns["PaymentDate"].DisplayIndex = 1;
                ADGVInstallaments.Columns["InstAmount"].DisplayIndex = 2;
                ADGVInstallaments.Columns["Fees"].DisplayIndex = 3;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void assignDatasource()
        {

            changeInstallmentRow = false;
            ADGVInstallaments.DataSource = null;
            ADGVInstallaments.DataSource = installments;
            changeInstallmentRow = true;

            lblTotalDiscount.Text = installments.Sum(inst => inst.Discount).ToString();
            lblFees.Text = (installments.Sum(inst => inst.InstAmount)).ToString();
            FormatStudentInstGrid();
        }


        private void StudentInstallment_Load(object sender, EventArgs e)
        {
            try
            {

                txtInstallmentAmount.Text = "0";
                txtDiscount.Text = "0";
                allowIndexChange = true;
                panelInstallDetails.Visible = true;
                changeInstallmentRow = true;

                if (ADGVInstallaments.CurrentRow != null)
                {
                    selectedInstallment = installments[ADGVInstallaments.CurrentRow.Index];

                    txtInstallmentAmount.Text = selectedInstallment.InstAmount.ToString();
                    txtDiscount.Text = selectedInstallment.Discount.ToString();

                    if (selectedInstallment.InstDate == null)
                    {
                        dtpInstallmentDate.Value = DateTime.Now;
                    }
                    else
                    {
                        dtpInstallmentDate.Value = selectedInstallment.InstDate;
                    }


                    txtDiscription.Text = selectedInstallment.Description;
                }





                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                ToolTip1.SetToolTip(this.btnModify, "Modify");
                ToolTip1.SetToolTip(this.btnDelete, "Delete");
                ToolTip1.SetToolTip(this.btnReset, "Reset");
                ToolTip1.SetToolTip(this.btnSave, "Save");
                ToolTip1.SetToolTip(this.btnCreate, "Add");

            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChange)
                {
                    decimal instAmnt, discount;
                    if (Decimal.TryParse(txtInstallmentAmount.Text, out instAmnt) == false)
                    {
                        instAmnt = 0;
                        txtInstallmentAmount.Text = instAmnt.ToString();
                    }
                    if (Decimal.TryParse(txtDiscount.Text, out discount) == false)
                    {
                        discount = 0;
                        txtDiscount.Text = discount.ToString();
                    }

                    if (discount > instAmnt)
                    {
                        UICommon.WinForm.showStatus("Discount can't be greater than installment amount. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtDiscount.Text = 0.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void StudentInstallment_FormClosed(object sender, FormClosedEventArgs e)
        {
            // this.Close();StudentInstallment
        }
        private void txtInstallmentAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChange)
                {
                    if (txtInstallmentAmount.Text.Length == 0)
                    {
                        txtInstallmentAmount.Text = "0";
                    }

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        private void txtNewDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChange)
                {
                    decimal instAmnt, discount;
                    instAmnt = Convert.ToDecimal(txtInstallmentAmount.Text);
                    discount = Convert.ToDecimal(txtDiscount.Text);
                    if (txtDiscount.Text.Length == 0)
                    {
                        txtDiscount.Text = "0";
                    }
                    else
                    {
                        if (discount > instAmnt)
                        {
                            UICommon.WinForm.showStatus("Discount can't be greater than installment amount. ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            txtDiscount.Text = selectedInstallment.Discount.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVInstallaments_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (changeInstallmentRow)
                {

                    if (ADGVInstallaments.Rows.Count > 0)
                    {
                        btnModify.Enabled = true;
                        panelInstallDetails.Visible = true;

                        selectedInstallment = installments[ADGVInstallaments.CurrentRow.Index];

                        if (selectedInstallment.InstAmount == selectedInstallment.AmntPaid)
                        {
                            lblStatus.Text = "Can't modify installment, As payment for this installment is already done.";
                            btnDelete.Enabled = false;
                            btnModify.Enabled = false;
                        }
                        else if (selectedInstallment.AmntPaid > 0)
                        {
                            lblStatus.Text = "You won't be able to delete this installment, Can be modified.";
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            lblStatus.Text = "";
                            btnDelete.Enabled = true;
                            btnModify.Enabled = true;
                        }

                        txtInstallmentAmount.Text = selectedInstallment.InstAmount.ToString();
                        txtDiscount.Text = selectedInstallment.Discount.ToString();

                        if (selectedInstallment.InstDate == null)
                        {
                            dtpInstallmentDate.Value = DateTime.Now;
                        }
                        else
                        {
                            dtpInstallmentDate.Value = selectedInstallment.InstDate;
                        }


                        txtDiscription.Text = selectedInstallment.Description;
                        allowIndexChange = true;
                        btnDelete.Visible = true;
                        btnModify.Visible = true;
                    }
                    else
                    {
                        panelInstallDetails.Visible = false;
                        btnDelete.Visible = false;
                        btnModify.Visible = false;

                    }
                    btnCreate.Text = "Add New";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void ADGVInstallaments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //changeInstallmentRow = true;  //newly added 07/01/2017
                foreach (DataGridViewRow adrow in ADGVInstallaments.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVInstallaments.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVInstallaments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVInstallaments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVInstallaments, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                installments.Remove(selectedInstallment);
                //selectedInstallment = installments[ADGVInstallaments.CurrentRow.Index - 1];
                assignDatasource();
                this.DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal Discount = Convert.ToDecimal((txtDiscount.Text) == "" ? "0" : (txtDiscount.Text));
                Decimal amount = Convert.ToDecimal(txtInstallmentAmount.Text == "" ? "0" : txtInstallmentAmount.Text);

                if (amount < selectedInstallment.AmntPaid)
                {
                    lblStatus.Text = "Installment amount can not be less than amount paid. Rs. " + selectedInstallment.AmntPaid + " is already paid.";
                    return;
                }
                else
                {
                    lblStatus.Text = "";
                }


                if (amount > 0)
                {
                    if (Discount <= amount)
                    {
                        selectedInstallment.Discount = Convert.ToDecimal((txtDiscount.Text) == "" ? "0" : (txtDiscount.Text));
                        selectedInstallment.InstAmount = Convert.ToDecimal(txtInstallmentAmount.Text == "" ? "0" : (txtInstallmentAmount.Text));
                        selectedInstallment.InstDate = dtpInstallmentDate.Value;
                        selectedInstallment.Description = txtDiscription.Text;
                        discount = selectedInstallment.Discount;
                        assignDatasource();
                        changeInstallmentRow = true;

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Discount cannot be greater than Amount.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }

                else
                {
                    UICommon.WinForm.showStatus("Please Enter Amount.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
            finally
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCreate.Text.Equals("Add New"))
                {
                    txtDiscount.Text = "0";
                    txtInstallmentAmount.Text = "0";

                    txtDiscription.Text = "";
                    btnCreate.Text = "ADD";
                    btnModify.Enabled = false;
                }
                else
                {
                    Info.InstallmentDetail newInstallment = new Info.InstallmentDetail();
                    newInstallment.InstAmount = Convert.ToDecimal((txtInstallmentAmount.Text) == "" ? "0" : (txtInstallmentAmount.Text));
                    newInstallment.InstDate = dtpInstallmentDate.Value;
                    newInstallment.Discount = Convert.ToDecimal((txtDiscount.Text) == "" ? "0" : (txtDiscount.Text));
                    newInstallment.InstMonth = newInstallment.InstDate.Month;
                    newInstallment.Description = txtDiscription.Text;
                    newInstallment.Status = "NP";

                    if (newInstallment.InstAmount == 0)
                    {
                        UICommon.WinForm.showStatus("Installment amount should be greater than 0.", sCaption, this);
                        return;
                    }

                    installments.Add(newInstallment);
                    assignDatasource();
                    btnCreate.Text = "Add New";
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
            finally
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void FrmStudentInstallments_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                newAmount = installments.Sum(inst => inst.InstAmount);
                newDiscount = installments.Sum(inst => inst.Discount);
                decimal adjustedfees = (installments.Sum(inst => inst.InstAmount) - installments.Sum(dscnt => dscnt.Discount));

                if (newAmount > totalAmount)
                {
                    DialogResult result = UICommon.WinForm.showStatus("Increase Total Fees Amount? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, sCaption, this);
                    if (result == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
                objStuddentFacility.Installments = installments;
                objStuddentFacility.Package.SubjAmount = objStuddentFacility.Installments.Sum(inst => inst.InstAmount);
                objStuddentFacility.Discount = objStuddentFacility.Installments.Sum(inst => inst.Discount);
                objStuddentFacility.Amount = objStuddentFacility.Installments.Sum(inst => inst.InstAmount);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                objStuddentFacility.Installments.Clear();
                objStuddentFacility.Discount = 0;

                setInstallments(objStuddentFacility);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong please contact system Admin. ", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }


    }
}
