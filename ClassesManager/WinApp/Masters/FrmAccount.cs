using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using System.Net;
using ClassManager.WinApp.UICommon;
using ClassManager.BLL;


namespace ClassManager.WinApp
{
   public partial class FrmAccount :FrmParentForm
    {
     
        string sCaption = "Account";
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        public FrmAccount()
        {
            InitializeComponent();
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Info.Account objaccount = new Info.Account();
        //        objaccount.AccountName = txtName.Text;
        //        objaccount.Balance = Convert.ToDecimal(txtBalance.Text);
        //        objaccount.AccountType= Convert.ToString(cmbType.SelectedItem) ;
        //        objaccount.BranchID = branchID.ToString();
        //        BLL.AccountHandller.createAccount(objaccount);
        //        UICommon.WinForm.showStatus("Account created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        clearform();
        //        ADGVAccounts.DataSource = BLL.AccountHandller.getAccounts(branchID.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex);
        //        UICommon.WinForm.showStatus("Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //    }   
        //}

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            try
            {

                List<Info.Account> lstaccount = new List<Info.Account>();
                int branchid = Program.LoggedInUser.BranchId;
                lstaccount = BLL.AccountHandller.getAccounts(branchid.ToString());
                ADGVAccounts.DataSource = lstaccount;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        public void clearform()
        {
            txtName.Text = "";
            txtBalance.Text = "";
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<Info.Account> lstacnt = new List<Info.Account>();
        //        lstacnt = ADGVAccounts.DataSource as List<Info.Account>;
        //        foreach (Info.Account objaccount in lstacnt)
        //        {
        //            BLL.AccountHandller.updateAccount(objaccount);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex);
        //        throw ex;
        //    }
     //}

        private void ADGVAccounts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
          //  UICommon.WinForm.ADGVSerialNo(ADGVAccounts,e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                List<Info.Account> lstacnt = new List<Info.Account>();
                lstacnt = ADGVAccounts.DataSource as List<Info.Account>;
                foreach (Info.Account objaccount in lstacnt)
                {
                    BLL.AccountHandller.updateAccount(objaccount);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                Info.Account objaccount = new Info.Account();
                objaccount.AccountName = txtName.Text;
                objaccount.Balance = Convert.ToDecimal(txtBalance.Text);
                objaccount.AccountType = Convert.ToString(cmbType.SelectedItem);
                objaccount.BranchID = branchID.ToString();
                BLL.AccountHandller.createAccount(objaccount);
                UICommon.WinForm.showStatus("Account created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                clearform();
                ADGVAccounts.DataSource = BLL.AccountHandller.getAccounts(branchID.ToString());
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showStatus("Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
        }
    }

       
    }

