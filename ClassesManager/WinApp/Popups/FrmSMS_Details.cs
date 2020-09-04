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
using ClassManager.Common;

namespace ClassManager.WinApp
{
     public partial class FrmSMS_Details : FrmParentForm
    {
        string sCaption = "SMS Details";
        string branchId = Program.LoggedInUser.BranchId.ToString();
        DataTable dtSMS; DataView newList;
        DataTable objAllStdOutstanding;
        DataSet dsAllOutstanding;
        public FrmSMS_Details()
        {
            InitializeComponent();
        }

        private void FrmSMS_Details_Load(object sender, EventArgs e)
        {
            try
            {
                AddColumns();
                WinForm.AssignFilterEvent(ADGVSMS);
                formatDate();
                LoadData(true);
                BalanceSMS();
            }
            catch(Exception  ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private  void AddColumns()
        {
            try
            {
                ADGVSMS.Columns.Add(new DataGridViewImageColumn()

                {
                    Image = Properties.Resources.icon,
                    Name = "Resend",
                    HeaderText = "Resend"
                });

            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this, null, MessageBoxButtons.OK);
            }
        }
        private void BalanceSMS()
        {
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {

                    StringBuilder tempUrl;
                    tempUrl= new StringBuilder("http://trans.accunityservices.com/api/checkbalance.php?user=:SMS_USERNAME&pass=:SMS_PASSWORD");
                    tempUrl.Replace(":SMS_USERNAME", Info.SysParam.getValue<string>(Info.SysParam.Parameters.SMS_USERNAME));
                    tempUrl.Replace(":SMS_PASSWORD", Info.SysParam.getValue<string>(Info.SysParam.Parameters.SMS_PASSWORD));
                    string result = string.Empty;

                    try
                    {
                        result = client.DownloadString(tempUrl.ToString());
                        lblBlnceMsg.Text = result.ToString();
                        if(Convert.ToInt32(result) < 0)
                        {
                            lblBlnceMsg.ForeColor = Color.Red;
                        }
                    }

                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void formatDate()
        {
            try
            {
                dtpFrmDt.Value = DateTime.Now;
                dtpToDt.Value = DateTime.Now;
                UICommon.WinForm.formatDateTimePicker(dtpFrmDt);
                UICommon.WinForm.formatDateTimePicker(dtpToDt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           }

        private void dtpFrmDt_CloseUp(object sender, EventArgs e)
        {
            try
            {
                LoadData(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtpToDt_CloseUp(object sender, EventArgs e)
        {
            try
            {
                LoadData(false);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       
        private void LoadData(bool formLoad = false)
        {
            try
            {
                ADGVSMS.Visible = true;
               
                if (dtpFrmDt.Value <= dtpToDt.Value)
                { Events();
                    newList = null;
                  
                    ADGVSMS.DataSource = null;

                   DateTime Fromdate = dtpFrmDt.Value;
                    DateTime Todate = dtpToDt.Value;

                   objAllStdOutstanding= BLL.NotificationHandler.GetSMSdetails(branchId,(Fromdate),(Todate));
                 //   ADGVSMS.DataSource = dtSMS;
                    ADGVSMS.PageSize = 25;
                    ADGVSMS.SetPagedDataSource(objAllStdOutstanding, bindingNavigator1);
                    dsAllOutstanding = new DataSet();
                    dsAllOutstanding.Tables.Add(objAllStdOutstanding);
                    newList = new DataView(objAllStdOutstanding);
                    if (newList == null)
                    {
                        newList = new DataView(objAllStdOutstanding);
                    }

                    else if (newList.Count == 0)
                    {
                      foreach(DataRow dr in objAllStdOutstanding.Rows)
                        {
                            ADGVSMS.DataSource = dr;
                        }
                    }
                    else
                    {
                        ADGVSMS.DataSource = newList;
                        ADGVSMS.SetPagedDataSource((newList.ToTable()), bindingNavigator1);
                    }

                    Count(objAllStdOutstanding);
                    FormatGrid();
                    foreach (DataGridViewRow adrow in ADGVSMS.Rows)
                    {

                        adrow.Height = 30;
                        adrow.MinimumHeight = 30;
                    this.ADGVSMS.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
                    }

                  
                 
                }
                else
                {
                    UICommon.WinForm.showStatus("From Date Cannot be Greater", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void Events()
        {
           ADGVSMS.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
           ADGVSMS.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        private void Count(DataTable objall)
        {
            try
            {
                DataView dataView = objall.AsDataView();
               
                lblNum.Text = (from DataRow dRow in dataView.ToTable().Rows
                               select dRow["SMSD_ID"]).Distinct().Count().ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVSMS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                FormatGrid();
                foreach (DataGridViewRow adrow in ADGVSMS.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVSMS.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FormatGrid()
        {
            try
            {
                ADGVSMS.Columns["SMSD_ID"].HeaderText = "ID";
                ADGVSMS.Columns["SMSD_ID"].ReadOnly = true;
                ADGVSMS.Columns["SMSD_TO_MOBILE"].HeaderText = "Mobile No";
                ADGVSMS.Columns["SMSD_TO_MOBILE"].ReadOnly = true;
                ADGVSMS.Columns["SMSD_TO_EMAIL"].HeaderText = "Email Address";
                ADGVSMS.Columns["SMSD_TO_EMAIL"].ReadOnly = true;
                ADGVSMS.Columns["SMSD_BODY"].HeaderText = "Message Body";
                ADGVSMS.Columns["SMSD_BODY"].ReadOnly = true;
                ADGVSMS.Columns["SMSD_SENT_TIME"].HeaderText = "Sent Date";
                ADGVSMS.Columns["SMSD_TYPE"].Visible = false ;
                ADGVSMS.Columns["SMSD_SENT_STATUS"].HeaderText = "Status";
                ADGVSMS.Columns["Resend"].DisplayIndex = ADGVSMS.Columns.Count - 1;
                ADGVSMS.Columns["SMSD_BODY"].Width = 190;
                ADGVSMS.Columns["SMSD_TO_EMAIL"].Width = 130;
                ADGVSMS.Columns["Resend"].Width = 70;
                ADGVSMS.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
                // ADGVSMS.Columns["SMSD_SENT_TIME"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVSMS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            WinApp.UICommon.WinForm.ADGVSerialNo(ADGVSMS, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ADGVSMS.DataSource = objAllStdOutstanding;
                if (ADGVSMS.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVSMS, null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

     
        private void ADGVSMS_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               ADGVSMS.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
                if (ADGVSMS.Columns.Contains("Resend") && e.ColumnIndex == ADGVSMS.Columns["Resend"].Index)
                {
                    if (e.RowIndex != -1)
                    {
                        string MsgBody = (ADGVSMS.Rows[e.RowIndex].Cells["SMSD_BODY"].Value).ToString();
                        string ContactNo = (ADGVSMS.Rows[e.RowIndex].Cells["SMSD_TO_MOBILE"].Value).ToString();
                        if (ContactNo != "")
                        {
                            Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();
                            bool sendSMS = BLL.MailHandler.sendSMS(smsConfig, MsgBody.ToString(), ContactNo, true, "ResendSMS", true);
                            if (sendSMS)
                            {
                                UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
                            }
                            else
                            {
                                UICommon.FormFactory.setMainFormStatus("Message Sending Failed from " + sCaption);

                            }
                        }
                        else
                        {
                            
                            List<string> listEmail = new List<string>();
                            string eMail = (ADGVSMS.Rows[e.RowIndex].Cells["SMSD_TO_EMAIL"].Value).ToString();
                            listEmail.Add(eMail);
                            bool sendStatus = BLL.MailHandler.sendEmail( MsgBody.ToString(), listEmail, null, null);
                            if (sendStatus)
                            {
                                UICommon.FormFactory.setMainFormStatus("Email Sent Successfully from " + sCaption);
                            }
                            else
                            {
                                UICommon.FormFactory.setMainFormStatus("Email Sending Failed from " + sCaption);

                            }
                        }
                        LoadData(false);
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this, null, MessageBoxButtons.OK);
            }

        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();


                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFrmDt.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDt.Value);
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                
                getParameter.Title = "SMS Details Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ADGVSMS.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\SMS_details_Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(ADGVSMS, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
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

