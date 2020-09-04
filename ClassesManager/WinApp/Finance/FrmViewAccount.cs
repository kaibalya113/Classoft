using ClassManager.Info;
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

namespace ClassManager.WinApp
{
    public partial class FrmViewAccount : FrmParentForm
    {
        RolePrivilege formPrevileges;

        List<Info.Account> lstaccount;
        string sCaption = "ViewAccount";
        string branchId = Program.LoggedInUser.BranchId.ToString();
        public FrmViewAccount()
        {
            InitializeComponent();
        }
        private void FrmViewAccount_Load(object sender, EventArgs e)
        {
            try
            {
                AddColumn();
                ADGVAccounts.DataSource = WinForm.ToDataTable(BLL.AccountHandller.getAccounts(branchId.ToString()));
                WinForm.AssignFilterEvent(ADGVAccounts);
                ApplyPrevileges();            
                ADGVTransfer.DataSource = BLL.AccountHandller.getTransferAmount(branchId.ToString());

                formatADGVAccounts();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex,sCaption,this);
            }
        }

        private void AddColumn()
        {
            try
            {
                ADGVTransfer.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.deleteBin,

                    Name = "Delete",
                    HeaderText = "Delete"
                });
            }
            catch (Exception ex)
            {

                throw ex ;
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
                formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {

                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdate.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {

                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                    if (formPrevileges.View == false)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       

        private void ADGVAccounts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           // UICommon.WinForm.ADGVSerialNo(ADGVAccounts,e);
        }

        private void formatADGVAccounts()
        {
            try
            {
                ADGVAccounts.ReadOnly = true;
                ADGVAccounts.Columns["Id"].Visible = false;
                ADGVAccounts.Columns["AccountType"].Visible = false;
                ADGVAccounts.Columns["BranchID"].Visible = false;
            if(ADGVAccounts.Columns.Contains("PendingAmount"))
                {
                    ADGVAccounts.Columns["PendingAmount"].DisplayIndex = 3;
                    ADGVAccounts.Columns["PendingAmount"].HeaderText = "Panding Cheque Amount";
                }

               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ADGVAccounts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVAccounts();
                foreach (DataGridViewRow adrow in ADGVAccounts.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVAccounts.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chkBranchID.Checked)
                {
                    branchId = "%";
                }
                else
                {
                    branchId = Program.LoggedInUser.BranchId.ToString();
                }
                ADGVAccounts.DataSource = WinForm.ToDataTable(BLL.AccountHandller.getAccounts(branchId.ToString()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<Info.Account> lstacnt = new List<Info.Account>();
                lstacnt = ADGVAccounts.DataSource as List<Info.Account>;
                foreach (Info.Account objaccount in lstacnt)
                {
                    BLL.AccountHandller.updateAccount(objaccount);
                }
                UICommon.WinForm.showStatus("Account Updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                //ADGVAccounts.DataSource = lstaccount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //For GridView Serial No.Mohan(28-July-2017).
        private void ADGVAccounts_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(ADGVAccounts, e);
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
                    
            }
        }

        private void ADGVAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            FrmCreateAccount frmAccount = UICommon.FormFactory.GetForm(UICommon.Forms.FrmCreateAccount) as FrmCreateAccount;
            frmAccount.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {///ADDED BY ASHVINI 4-1-2019
           //for loading data after transfter
            FrmTransfereAccount frmTransferAccount = new FrmTransfereAccount();
            frmTransferAccount.ShowDialog();

            //FrmTransfereAccount frmTransferAccount = UICommon.FormFactory.GetForm(UICommon.Forms.FrmTransfereAccount) as FrmTransfereAccount;
            //frmTransferAccount.Visible = true;
           
            ADGVTransfer.DataSource = BLL.AccountHandller.getTransferAmount(branchId.ToString());
            //this.Close();
        }
        //end by ashvini 04-01-2019

        private void advancedDataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                WinForm.ADGVSerialNo(ADGVTransfer, e);
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }

        private void ADGVTransfer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatTransfer();
                foreach (DataGridViewRow adrow in ADGVTransfer.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVTransfer.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void formatTransfer()
        {
            try
            {///ADDED BY ASHVINI 4-1-2019
                //FOR proper formatting
                ADGVTransfer.ReadOnly = true;
                ADGVTransfer.Columns["Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                ADGVTransfer.Columns["PDEX_TRANSACTION_ID"].Visible = false;
                ADGVTransfer.Columns["PDEX_ACCNT_ID"].Visible = false;
                if (ADGVTransfer.Columns.Contains("TRNC_REMARK"))
                {
                    ADGVTransfer.Columns["TRNC_REMARK"].HeaderText = "Reason";
                    ADGVTransfer.Columns["TRNC_REMARK"].Width = 140;
                }
                if (ADGVTransfer.Columns.Contains("Amount"))
                {
                    ADGVTransfer.Columns["Amount"].Width = 70;
                }
                if (ADGVTransfer.Columns.Contains("Delete"))
                {
                    ADGVTransfer.Columns["Delete"].Width = 65;
                    ADGVTransfer.Columns["Delete"].ReadOnly = false;
                }

                if (ADGVTransfer.Columns.Contains("Date"))
                {
                    ADGVTransfer.Columns["Date"].Width = 84;
                }

                ADGVTransfer.Columns["Delete"].DisplayIndex = ADGVTransfer.Columns.Count - 1;
            }
            //end by ashvii04-02-2019
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVTransfer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {

                    if (ADGVTransfer.Columns.Contains("Delete") && e.ColumnIndex == ADGVTransfer.Columns["Delete"].Index)
                    {
                        var sure = MessageBox.Show("Do you Want to Delete this Transfer Transaction", sCaption, MessageBoxButtons.YesNo);

                        if (sure == DialogResult.Yes)
                        {
                            //BLL.EnquiryHandller.deleteTranferTrans((Convert.ToInt64(ADGVTransfer.Rows[e.RowIndex].Cells["PDEX_ACCNT_ID"].Value)), branchId, (Convert.ToDecimal(ADGVTransfer.Rows[e.RowIndex].Cells["Amount"].Value)),Convert.ToInt64(ADGVTransfer.Rows[e.RowIndex].Cells["PDEX_TRANSACTION_ID"].Value), (ADGVTransfer.Rows[e.RowIndex].Cells["From Account"].Value).ToString());
                            BLL.EnquiryHandller.deleteTranferTrans((Convert.ToInt64(ADGVTransfer.Rows[e.RowIndex].Cells["PDEX_ACCNT_ID"].Value)), branchId, (Convert.ToDecimal(ADGVTransfer.Rows[e.RowIndex].Cells["Amount"].Value)), Convert.ToInt64(ADGVTransfer.Rows[e.RowIndex].Cells["PDEX_TRANSACTION_ID"].Value), (ADGVTransfer.Rows[e.RowIndex].Cells["From Account"].Value).ToString());  
                            UICommon.WinForm.showStatus("Deleted Sucessfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                            ADGVAccounts.DataSource = WinForm.ToDataTable(BLL.AccountHandller.getAccounts(branchId.ToString()));
                            ADGVTransfer.DataSource = BLL.AccountHandller.getTransferAmount(branchId.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

