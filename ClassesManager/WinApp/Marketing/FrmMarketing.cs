using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Common;
using ClassManager.Info;
using ClassManager.BLL;
using ClassManager.WinApp.UICommon;
using System.Text.RegularExpressions;

namespace ClassManager.WinApp
{
    public partial class FrmMarketing : FrmParentForm
    {

        RolePrivilege formPrevileges;
        string messageBody;
        int branchID = WinApp.Program.LoggedInUser.BranchId;
        string studType = "%";
        const string sCaption = "CRM";
        DataGridViewCheckBoxColumn chkEmail = new DataGridViewCheckBoxColumn();
        
        List<Info.Marketing> marketing;
       
        public FrmMarketing()
        {
            InitializeComponent();
        }

        private void Marketing_Load(object sender, EventArgs e)
        {
            try
            {
                ADGVMarketing.CurrentCell = null;
                
                DataGridViewCheckBoxColumn chkEmail = new DataGridViewCheckBoxColumn();
                chkEmail.Name = "chkEmail";
                chkEmail.HeaderText = "Send SMS";
                chkEmail.TrueValue = true;
                chkEmail.FalseValue = false;

                ADGVMarketing.Columns.Insert(0, chkEmail);


                marketing = BLL.MarketingHandler.getGroup(studType, Program.LoggedInUser.BranchId.ToString());
                var value = (from Info.Marketing dr in marketing
                             select (dr.Group)).Distinct().ToArray();

                if (value.Count() > 0 && value[0] != null)
                {
                    cmbCourseNm.ValueMember = "Stream";
                    cmbCourseNm.DisplayMember = "Stream";
                    cmbCourseNm.DataSource = value;
                }

                ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable(marketing);
                txtMarketingMessage.Text = TemplateHandler.getTemplateByType("ARVERTISESMS");
               // txtMarketingMessage.ScrollToCaret();
                cmbViewMaketingData.SelectedIndex = 0;
                AssignEvents();
                ApplyPrevileges();
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
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {
                        chkBranchID.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {
                        btnUpdateMessage.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnSendSms.Visible = false;
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


        private void AssignEvents()
        {
            ADGVMarketing.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVMarketing.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }


        //private void btnSendSms_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
                
        //        List<Int32> lstMid = new List<Int32>();
        //        if (chkSelectAll.Checked)
        //        {
        //            foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
        //            {
        //                lstMid.Add(Convert.ToInt32(gvrMarketing.Cells[1].Value));
        //            }
        //        }
        //        else
        //        {
        //            foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
        //            {
        //                if ((Boolean)gvrMarketing.Cells[0].Value == true)
        //                {
        //                    lstMid.Add(Convert.ToInt32(gvrMarketing.Cells[1].Value));
        //                }
        //            }
        //        }

        //        List<Info.Marketing> seletedStudents = marketing.Where(objMarketing => lstMid.Contains(objMarketing.Id)).ToList<Info.Marketing>();
        //        if (seletedStudents.Count != 0)
        //        {
        //            UICommon.FormFactory.setMainFormStatus("Sending Marketing Message");
        //            bgwMarketingSms.RunWorkerAsync(seletedStudents);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No Student Selected to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
        //        }
        //        txtMarketingMessage.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private void chkSelectAll_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void dgvMarketing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)ADGVMarketing.Rows[e.RowIndex].Cells[e.ColumnIndex];
                chckBx.Value = !(Boolean)chckBx.Value;
            }
        }

        private void dgvMarketing_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
            {
                gvrMarketing.Cells[0] = new DataGridViewCheckBoxCell();
                gvrMarketing.Cells[0].Value = false;
            }
        }


        private void btnSearchByStream_Click(object sender, EventArgs e)
        {
            
           
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
                {
                    DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrMarketing.Cells[0];

                    chckBx.Value = chkSelectAll.Checked;
                }
            }
            catch ( Exception ex)
            {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
           
        }

        


        private void cmbCourseNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ADGVMarketing.DataSource != null)
            {
                ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable((marketing).Where(ObjMarketing => ObjMarketing.Group == cmbCourseNm.SelectedValue.ToString()).ToList<Info.Marketing>());
            }
        }

       
        private void dgvMarketing_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow gvrFees in ADGVMarketing.Rows)
            {
                gvrFees.Cells[0] = new DataGridViewCheckBoxCell();
                gvrFees.Cells[0].Value = false;
            }
        }

        private void bgwMarketingSms_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Info.Marketing> objStudent = (List<Info.Marketing>)e.Argument;
            
            MailHandler.sendAdvertiseSms(objStudent, true,rbtnTrans.Checked==true? true:false, messageBody);
           
        }


        private void bgwMarketingSms_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
            }
            else
            {

                UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
            }
       

        }
        
        private void ADGVMarketing_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            { 
                foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
                {
                    DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrMarketing.Cells[0];

                    chckBx.Value = chkSelectAll.Checked;
                }

                ADGVMarketing.Columns["Id"].Visible = false;
                ADGVMarketing.Columns["StudType"].Visible = false;

                foreach (DataGridViewRow adrow in ADGVMarketing.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVMarketing.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private void cmbCourseNm_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbViewMaketingData.SelectedIndex == 1)
                {
                    ADGVMarketing.DataSource = null;
                    studType = "ENQ";
                    marketing = BLL.MarketingHandler.getGroup(studType);
                }
                else if (cmbViewMaketingData.SelectedIndex == 2)
                {
                    studType = "REG";
                    ADGVMarketing.DataSource = null;
                    marketing = BLL.MarketingHandler.getGroup(studType);
                }

                else if (cmbViewMaketingData.SelectedIndex == 2)
                {
                    studType = "MARKT";
                    ADGVMarketing.DataSource = null;
                    marketing = BLL.MarketingHandler.getGroup(studType);

                }
                else if (cmbViewMaketingData.SelectedIndex == 2)
                {
                    studType = "%";
                    ADGVMarketing.DataSource = null;
                    marketing = BLL.MarketingHandler.getGroup(studType);

                }
                List<Info.Marketing> newList = marketing.Where(m => (m.Group == cmbCourseNm.Text)).ToList<Info.Marketing>();
                ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable(newList);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private void cmbViewMaketingData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbViewMaketingData.SelectedIndex == 0)
                {
                    studType = "%";

                    cmbCourseNm.DisplayMember = "Stream";
                    cmbCourseNm.ValueMember = "Stream";
                    marketing = BLL.MarketingHandler.getGroup(studType, Program.LoggedInUser.BranchId.ToString());
                    var value = (from Info.Marketing dr in marketing
                                 select (dr.Group)).Distinct().ToArray();

                    cmbCourseNm.DataSource = value;

                    ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable(marketing);
                }
                else if (cmbViewMaketingData.SelectedIndex == 1)
                {
                    studType = "ENQ";

                    cmbCourseNm.DisplayMember = "Stream";
                    cmbCourseNm.ValueMember = "Stream";
                    marketing = BLL.MarketingHandler.getGroup(studType);

                    var value = (from Info.Marketing dr in marketing

                                 select (dr.Group)).Distinct().ToArray();

                    cmbCourseNm.DataSource = value;

                    ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable(marketing);
                }
                else if (cmbViewMaketingData.SelectedIndex == 2)
                {
                    studType = "REG";

                    cmbCourseNm.DisplayMember = "Stream";
                    cmbCourseNm.ValueMember = "Stream";
                    marketing = BLL.MarketingHandler.getGroup(studType);
                    var value = (from Info.Marketing dr in marketing

                                 select (dr.Group)).Distinct().ToArray();
                    cmbCourseNm.DataSource = value;

                    ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable(marketing);

                }
                else if (cmbViewMaketingData.SelectedIndex == 3)
                {
                    studType = "MARKT";

                    cmbCourseNm.DisplayMember = "Stream";
                    cmbCourseNm.ValueMember = "Stream";
                    marketing = BLL.MarketingHandler.getGroup(studType);
                    var value = (from Info.Marketing dr in marketing

                                 select (dr.Group)).Distinct().ToArray();
                    cmbCourseNm.DataSource = value;
                    ADGVMarketing.DataSource = WinApp.UICommon.WinForm.ToDataTable(marketing);

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVMarketing_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVMarketing,e);
        }


        private void btnSendSms_Click(object sender, EventArgs e)
        {
            try
            {
                List<Int32> lstMid = new List<Int32>();
                if (txtMarketingMessage.Text.Length != 0 && txtMarketingMessage.Text != "")
                {
                   
                    if (chkSelectAll.Checked)
                    {
                        foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
                        {
                            lstMid.Add(Convert.ToInt32(gvrMarketing.Cells[1].Value));
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow gvrMarketing in ADGVMarketing.Rows)
                        {
                            if ((Boolean)gvrMarketing.Cells[0].Value == true)
                            {
                                lstMid.Add(Convert.ToInt32(gvrMarketing.Cells[1].Value));
                            }
                        }
                    }

                    List<Info.Marketing> seletedStudents = marketing.Where(objMarketing => lstMid.Contains(objMarketing.Id)).ToList<Info.Marketing>();
                    if (seletedStudents.Count != 0)
                    {
                        UICommon.FormFactory.setMainFormStatus("Sending Marketing Message");
                      // bgwMarketingSms.RunWorkerAsync(seletedStudents);
                      UICommon.WinForm.setSMSStatus(sendMarketingSMS(seletedStudents),sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No Student Selected to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
                        return;
                    }
                    txtMarketingMessage.Text = "";
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Enter Text To Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
                    return;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private bool sendMarketingSMS(List<Info.Marketing> students)
        {
           return MailHandler.sendAdvertiseSms(students, true, rbtnTrans.Checked == true ? true : false, txtMarketingMessage.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVMarketing.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVMarketing,null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                   UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnUpdateMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarketingMessage.Text.Trim() != "")
                {
                    if (TemplateHandler.updateTemplatesByType("ARVERTISESMS", txtMarketingMessage.Text))
                    {
                        UICommon.WinForm.showStatus("Marketing Message Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Enter Message to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkBranchID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBranchID.Checked)
                {
                    ADGVMarketing.DataSource = WinForm.ToDataTable(MarketingHandler.getGroup("%", "%"));
                }
                else
                {
                    ADGVMarketing.DataSource = WinForm.ToDataTable(MarketingHandler.getGroup("%", Program.LoggedInUser.BranchId.ToString()));
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        //Checking for the Following words that are not allowed while sending Transactional SMS.Mohan(29-July-2017).
        private void checkWordsForTransaction()
        {
            try
            {
                StringBuilder popUp = new StringBuilder("");
                messageBody = "";
                btnSendSms.Enabled = true;
                if (rbtnTrans.Checked)
                {
                    messageBody = "";
                    btnSendSms.Enabled = true;
                    string[] wordsnotAllowed = new string[] { "free", "stocks sms", "vote", "election", "win", "discount", "offer", "profit", "admission", "registration" };
                    //foreach(string check in wordsnotAllowed)
                    //{
                    if (wordsnotAllowed.Any(c => txtMarketingMessage.Text.IndexOf(c.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {

                        foreach (string word in wordsnotAllowed)
                        {
                            if (txtMarketingMessage.Text.Contains(word))
                            {
                                if (popUp != null||popUp.ToString()=="")
                                {
                                    popUp.Append(word);
                                }
                                else
                                {
                                    popUp.Append(", ");
                                    popUp.Append(word);
                                }
                            }
                        }
                        // UICommon.WinForm.showStatus("Your MessageBody should not contain the following Words while sending Transaction SMS : " + Environment.NewLine + string.Join(", ", wordsnotAllowed), sCaption, this);
                        UICommon.WinForm.showStatus("Your MessageBody contains the following words which are not allowed for sending Transactional SMS : " + popUp, sCaption, this);
                        btnSendSms.Enabled = false;
                        return;
                    }
                    //}
                    messageBody = txtMarketingMessage.Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Check for the words that are not allowed while sending Transaction Message.Mohan.(29-July-2017)
        private void txtMarketingMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkWordsForTransaction();
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void rbtnPromo_CheckedChanged(object sender, EventArgs e)
        {
            checkWordsForTransaction();
        }

        private void rbtnTrans_CheckedChanged(object sender, EventArgs e)
        {
            //checkWordsForTransaction();
        }
    }
}
