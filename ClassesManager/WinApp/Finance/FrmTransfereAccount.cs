using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
using ClassManager.WinApp.Popups;

namespace ClassManager.WinApp
{
    public partial class FrmTransfereAccount : FrmParentForm
    {
        const string sCaption = "Transfer Account";
        int branchID = WinApp.Program.LoggedInUser.BranchId;
        public List<Cheque> Cheques = new List<Cheque>();
        decimal totalChequeAmount;
        Account cashAccount;
        Account fromacc; Account Toaccount;
        decimal amount;
        public FrmTransfereAccount()
        {
            InitializeComponent();
        }

        private void FrmTransfereAccount_Load(object sender, EventArgs e)
        {
            try
            {
                List<Account> lstFromAcc = new List<Account>();
                lstFromAcc = BLL.AccountHandller.getAccounts(branchID.ToString());
                cmbFromAct.DataSource = lstFromAcc;
                cashAccount = lstFromAcc.Where(account => account.AccountName == "CASH").FirstOrDefault<Account>();
                if (cashAccount != null)
                {
                    cmbFromAct.SelectedItem = cashAccount;
                }


                List<Account> lstToAcc = new List<Account>();
                lstToAcc = BLL.AccountHandller.getAccounts(branchID.ToString());
                cmbToact.DataSource = lstToAcc;
                cashAccount = lstToAcc.Where(account => account.AccountName == "CASH").FirstOrDefault<Account>();
                if (cashAccount != null)
                {
                    cmbToact.SelectedItem = cashAccount;
                }
                formatDTP();
                fromacc = cmbFromAct.SelectedItem as Account;
                //Toaccount = cmbToact.SelectedItem as Account;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        private void formatDTP()
        {
            UICommon.WinForm.formatDateTimePicker(dtpPayStart);
        }

        private void lnkAddCheque_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                DialogResult result = FrmChequePopup.getInstance().ShowDialog();
                while (result != DialogResult.Cancel)
                {
                    Cheques.Clear();
                    if (result == DialogResult.OK && FrmChequePopup.objCheque != null)
                    {

                        decimal chequeAmount = FrmChequePopup.objCheque.Amount;
                        totalChequeAmount = chequeAmount;

                        Cheques.Add(FrmChequePopup.objCheque);

                        txtChequeAmount.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(totalChequeAmount.ToString()));


                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnViewInstallments_Click(object sender, EventArgs e)
        {
            try
            {
                if (vaildate())
                {
                    Transaction objtransaction = new Transaction();
                    objtransaction.Date = dtpPayStart.Value.Date;
                    objtransaction.Amount = Convert.ToDecimal(txtBalance.Text) + Cheques.Sum(chq => chq.Amount);
                    objtransaction.CashAmount = Convert.ToDecimal(txtBalance.Text);
                    objtransaction.Cheques = Cheques;
                    ///ADDED BY ASHVINI 4-1-2019
             //FOR adding value of reason
                    objtransaction.reason = txtDisReason.Text;
                    //end by ashvini

                    decimal ChequeAmount = Cheques.Sum(chq => chq.Amount);
                    if (txtBalance.Text != "0" && amount > 0)
                    {
                        objtransaction.PaymentMode = PaymentMode.CASH;
                    }
                    else
                    {
                        objtransaction.PaymentMode = PaymentMode.CHEQUE;
                    }

                    fromacc = cmbFromAct.SelectedItem as Account;
                    Toaccount = cmbToact.SelectedItem as Account;

                    BLL.AccountHandller.TransferAmount(branchID, fromacc, Toaccount, objtransaction, ChequeAmount);
                    UICommon.WinForm.showStatus("Balance Transfered successfully of Rs." + (objtransaction.Amount + ChequeAmount) + " from Account " + fromacc.AccountName + " To Account " + Toaccount.AccountName, MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    ClearForm();
                    //this.Close();
                   
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }
        public bool vaildate()
        {
            try
            {
                amount = Convert.ToDecimal(txtBalance.Text);
                if (txtBalance.Text.Trim() == "" && amount > 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Valid Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtBalance.Focus();
                    return false;
                }
                if (cmbFromAct.SelectedIndex == cmbToact.SelectedIndex)
                {
                    UICommon.WinForm.showStatus("Please Select Proper Account To Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbFromAct.Focus();
                    return false;
                }
                decimal BalanceAmount = fromacc.Balance;
                if (BalanceAmount < amount)
                {
                    UICommon.WinForm.showStatus("Transfer Amount is Greater than the Balance Amount in Account, Please Enter Valid Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbFromAct.Focus();
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
        private void ClearForm()
        {
            try
            {
                cmbFromAct.SelectedIndex = 0;
                cmbToact.SelectedIndex = 0;
                txtBalance.Text = "0";
                dtpPayStart.Value = DateTime.Now;
                txtChequeAmount.Text = "Rs.0.00";

                ///ADDED BY ASHVINI 4-1-2019
             //FOR making reason field blank after submission
                txtDisReason.Text = "";
              //end by ashvini
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void cmbToact_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Toaccount = cmbToact.SelectedItem as Account;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void cmbFromAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fromacc = cmbFromAct.SelectedItem as Account;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
    }







}
