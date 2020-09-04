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
using ClassManager.WinApp.Popups;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmViewCheques : FrmParentForm
    {

        RolePrivilege formPrevileges;

        string sCaption = "View Cheques";
        Info.Cheque selectedCheque;
        //List<Cheque> lstCheque;
        DataTable dtCheques;
        DataTable dtFilter;
        int BranchID = Program.LoggedInUser.BranchId;

        public FrmViewCheques()
        {
            InitializeComponent();
        }

        private void FrmViewCheques_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewLinkColumn lnkselect = new DataGridViewLinkColumn();
                lnkselect.Name = "selectall";
                lnkselect.HeaderText = "Clear Cheque";
                lnkselect.Text = "Mark Clear";
                lnkselect.DefaultCellStyle.NullValue = "Mark Clear";
                lnkselect.Selected = false;
                lnkselect.Width = 70;
                lnkselect.DefaultCellStyle.BackColor = Color.White;
                lnkselect.DefaultCellStyle.ForeColor = Color.LightCoral;
                
                //lnkselect.ReadOnly = false;
                ADGViewCheques.Columns.Insert(0, lnkselect);


                DataGridViewLinkColumn lnkEdit = new DataGridViewLinkColumn();
                lnkEdit.Name = "btnEdit";
                lnkEdit.HeaderText = "Edit";
                lnkEdit.Text = "Edit";
                lnkEdit.Width = 40;
                lnkEdit.DefaultCellStyle.NullValue = "Edit";
                ADGViewCheques.Columns.Insert(1, lnkEdit);


                //lnkEdit.DefaultCellStyle.BackColor = Color.FromName("Window");
                lnkEdit.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                lnkEdit.DefaultCellStyle.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                lnkEdit.DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
                lnkEdit.DefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);

                //Format DateTimpicker.
                formatDTP();

                dtCheques = new DataTable();
                
                dtCheques = BLL.ChequeHandler.getAllCheques(Program.LoggedInUser.BranchId);
                ADGViewCheques.DataSource = dtCheques;

                WinForm.AssignFilterEvent(ADGViewCheques); 
            
            }
          
                catch (Exception ex)
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
                formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {

                    }

                    if (formPrevileges.Modify == false)
                    {
                        
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



        private void assignValues()
        {
            try
            {
               decimal clearAmount = Convert.ToDecimal((((DataTable)ADGViewCheques.DataSource).Compute("Sum(CHQ_AMOUNT)", "CHQ_STATUS='CLRD'").ToString() == "") ? "0" : ((DataTable)ADGViewCheques.DataSource).Compute("Sum(CHQ_AMOUNT)", "CHQ_STATUS = 'CLRD'").ToString());
                lblclrAmnt.Text = Common.Formatter.FormatCurrency(clearAmount);
                decimal unclearAmount= Convert.ToDecimal((((DataTable)ADGViewCheques.DataSource).Compute("Sum(CHQ_AMOUNT)", "CHQ_STATUS='PDNG'").ToString() == "") ? "0" : ((DataTable)ADGViewCheques.DataSource).Compute("Sum(CHQ_AMOUNT)", "CHQ_STATUS = 'PDNG'").ToString());
                lblUnclrAmnt.Text = Common.Formatter.FormatCurrency(unclearAmount);
               decimal pending= Convert.ToDecimal(((DataTable)ADGViewCheques.DataSource).Compute("Count(CHQ_ID)", "CHQ_STATUS='PDNG'").ToString());
                totalCheq.Text = pending.ToString();
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
                BLL.ChequeHandler.UpdateCheque(selectedCheque);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGViewCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ChequeID = (int)ADGViewCheques.Rows[e.RowIndex].Cells[2].Value;
                if (e.ColumnIndex == 1)
                {
                    if (ADGViewCheques.Rows[e.RowIndex].Cells["CHQ_STATUS"].Value.ToString() == "CLRD")
                    {
                        UICommon.WinForm.showStatus("Cleared cheque cannot be edited.", sCaption, this);
                    }

                    else
                    {
                        FrmChequePopup form = FrmChequePopup.getInstance();
                        selectedCheque = BLL.ChequeHandler.getCheque(ChequeID);
                        form.setCheque(selectedCheque);
                        dtCheques = BLL.ChequeHandler.getAllCheques(Program.LoggedInUser.BranchId);
                        ADGViewCheques.DataSource = dtCheques;
                    }
                }

                else if (e.ColumnIndex == 0)
                {
                    if (ADGViewCheques.Rows[e.RowIndex].Cells["CHQ_STATUS"].Value.ToString() == "CLRD")
                    {
                        UICommon.WinForm.showStatus("Cheque is alredy Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        if (formPrevileges != null)
                        {
                            if (formPrevileges.Delete == false)
                            {
                                UICommon.WinForm.showStatus("You don't have permission to Update the Status, Please contact admin", sCaption, this);
                                return;
                            }
                        }
                        if (BLL.ChequeHandler.UpdateChequeStatus(ChequeID))
                        {
                           dtCheques = BLL.ChequeHandler.getAllCheques(BranchID);
                            ADGViewCheques.DataSource = dtCheques;
                              
                            UICommon.WinForm.showStatus("Cheque Cleared.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Index was out of range.Must be non - negative and less than the size of the collection.\r\nParameter name: index"))
                {
                    MessageBox.Show("Please Click on row");
                }
            }
        }

        //private void btnMarkClear_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int i = 0;
        //        foreach (DataGridViewRow dr in ADGVViewCheques.Rows)
        //        {
                    
        //            if (Convert.ToBoolean(dr.Cells[0].Value) == true)
        //            {
        //                var selectedCheque = ADGVViewCheques.Rows[i];
        //                var cheque = (Cheque)selectedCheque.DataBoundItem;
        //                BLL.ChequeHandler.UpdateChequeStatus(cheque.Id);
        //            }
        //            i++;
        //        }
    
            //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public void formatChequeGrid()
        {
            try
            {
                //Changing Date Format
                ADGViewCheques.Columns["CHQ_DATE"].DefaultCellStyle= UICommon.WinForm.GridDateFormat;


                //Changing Hedertext
                ADGViewCheques.Columns["CHQ_NO"].HeaderText = "ChequeNo";
                ADGViewCheques.Columns["STMT_FNAME"].HeaderText = "Name";
                ADGViewCheques.Columns["STMT_FNAME"].ReadOnly = true;
                ADGViewCheques.Columns["CHQ_DATE"].HeaderText = "Date";
                ADGViewCheques.Columns["CHQ_NO"].HeaderText = "ChequeNo";
                ADGViewCheques.Columns["CHQ_DATE"].ReadOnly = true;
                ADGViewCheques.Columns["CHQ_NO"].ReadOnly = true;
                ADGViewCheques.Columns["CHQ_AMOUNT"].HeaderText = "Amount";
                ADGViewCheques.Columns["CHQ_STATUS"].HeaderText = "Status";
                ADGViewCheques.Columns["ACT_NAME"].HeaderText = "Account";

                ADGViewCheques.Columns["CHQ_BANK_NAME"].HeaderText = "Bank";
                ADGViewCheques.Columns["CHQ_BANK_BRANCH"].HeaderText = "BankBranch";

                ADGViewCheques.Columns["CHQ_AMOUNT"].ReadOnly = true;
                ADGViewCheques.Columns["CHQ_STATUS"].ReadOnly = true;
                ADGViewCheques.Columns["ACT_NAME"].ReadOnly = true;

                ADGViewCheques.Columns["CHQ_BANK_NAME"].ReadOnly = true;
                ADGViewCheques.Columns["CHQ_BANK_BRANCH"].ReadOnly = true;
                //Hiding Column
                ADGViewCheques.Columns["CHQ_ID"].Visible = false;

                //If cheque is cleared then it should not be Mark Clear instead Cleared only.
                foreach (DataGridViewRow dr in ADGViewCheques.Rows)
                {
                    if (Convert.ToString(dr.Cells["CHQ_STATUS"].Value) == "CLRD")
                    {
                        dr.Cells[0].Value = "Cleared";
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGViewCheques_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatChequeGrid();
                assignValues();
                foreach (DataGridViewRow adrow in ADGViewCheques.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGViewCheques.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Format DateTimePicker.
        /// </summary>
        private void formatDTP()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtFrmDte);
                UICommon.WinForm.formatDateTimePicker(dtToDte);
                UICommon.WinForm.setDate(dtFrmDte, dtToDte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void chkpdngcheq_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkpdngcheq.Checked == true)
                {
                    if (ADGViewCheques.Rows.Count > 0)
                    {
                        ADGViewCheques.DataSource = dtCheques.Select("CHQ_STATUS='PDNG'").CopyToDataTable();
                    }
                }
                else
                {

                    ADGViewCheques.DataSource = dtCheques;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The source contains no DataRows."))
                {
                    UICommon.WinForm.showStatus("No Pending Cheques.", sCaption, this);
                    chkpdngcheq.Checked = false;
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error has occured, please contact support.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void dtFrmDte_CloseUp(object sender, EventArgs e)
        {
            try
            {
                assignDataTableToGrid();
                dtToDte.MinDate = dtFrmDte.Value;
                //dtToDte.Value = dtFrmDte.Value;
                dtFilter = ((DataTable)ADGViewCheques.DataSource).Select(string.Format("CHQ_DATE >= #{0}# AND CHQ_DATE <= #{1}#", Common.Formatter.FormatDate(dtFrmDte.Value), Common.Formatter.FormatDate(dtToDte.Value))).CopyToDataTable();
                ADGViewCheques.DataSource = dtFilter;
            }

            catch (Exception ex)
            {
                if (ex.Message.Equals("The source contains no DataRows."))
                {
                    ADGViewCheques.DataSource = null;
                    assignZeroValue();
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error has occured, please contact support.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }
        /// <summary>
        /// This function will assign a DataSource(DataTable) to Gridview only if it is null.
        /// </summary>
         private void  assignDataTableToGrid()
        {
            try
            {
                if (ADGViewCheques.DataSource == null)
                {
                    ADGViewCheques.DataSource = dtCheques;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This function will be called when after filter if we get Exception Message like "The source contains no DataRows.". The Textboxes Text should get Zero.
        /// </summary>
        private void assignZeroValue()
        {
            try
            {
                if (ADGViewCheques.DataSource == null)
                {
                    lblclrAmnt.Text = "0";
                    lblUnclrAmnt.Text = "0";
                    totalCheq.Text = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dtToDte_CloseUp(object sender, EventArgs e)
        {
            try
            {
                assignDataTableToGrid();
                dtFilter = ((DataTable)ADGViewCheques.DataSource).Select(string.Format("CHQ_DATE >= #{0}# AND CHQ_DATE <= #{1}#", Common.Formatter.FormatDate(dtFrmDte.Value), Common.Formatter.FormatDate(dtToDte.Value))).CopyToDataTable();
                ADGViewCheques.DataSource = dtFilter;
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The source contains no DataRows."))
                {
                    ADGViewCheques.DataSource = null;
                    assignZeroValue();
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error has occured, please contact support.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void ADGViewCheques_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGViewCheques, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error has occured, please contact support.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
    }
}
