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
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.Common.Exceptions;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmExamReport : FrmParentForm
    {
        int branchID = Program.LoggedInUser.BranchId;
        DataTable dtTest;
        string sCaption = "ExamReport";
        public FrmExamReport()
        {
            InitializeComponent();
        }

        private void FrmExamReport_Load(object sender, EventArgs e)
        {
            try
            {
                populateOnlyTest(0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void populateOnlyTest(int identifier)
        {

            List<TestMaster> testMasters = TestHandler.getOnlyTests(branchID.ToString(),identifier,-1,"-1","-1");
            cmbTests.Items.Clear();

            Info.ComboItem objAllTest = new Info.ComboItem(-1, "Select Test");
            cmbTests.Items.Add(objAllTest);

            foreach (TestMaster test in testMasters)
            {
                cmbTests.Items.Add(new ComboItem(test.Id, test.TestName, test));
            }

            cmbTests.SelectedIndex = 0;
            cmbTests.SelectedItem = objAllTest;
        }

        private void rbnAllTest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnAllTest.Checked == true)
                {
                    populateOnlyTest(0);
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void rbtnuploadTest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnAllTest.Checked == true)
                {
                    populateOnlyTest(1);
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void rbtnarchievedTest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnAllTest.Checked == true)
                {
                    populateOnlyTest(2);
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                    int testID = (cmbTests.SelectedItem as ComboItem).key;
                    if (testID != 0 && testID != -1)
                    {
                        DataTable dt = TestHandler.getStudentForTest(testID);
                        ADGVTExamReport.DataSource = null;
                        foreach (DataRow dr in dt.Rows)
                        {
                            for (int i = 4; i < dr.ItemArray.Count(); i++)
                            {
                                if (dr[i].ToString().Equals("-1"))
                                {
                                    dr[i] = "A";

                                }
                            }
                        }
                        ADGVTExamReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVTExamReport.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVTExamReport, null);
                }
                else
                {

                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void sndMarksSMS_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSent = false;
                List<Int32> lstAdmsnNo = new List<Int32>();
                DataTable dtStud = new DataTable();
                int testid = Convert.ToInt32((cmbTests.SelectedItem as ComboItem).key);
                string subjectname = (cmbTests.SelectedItem as ComboItem).name;
                if (chkSelectAll.Checked == true)
                {

                    dtStud = BLL.TestHandler.getStudentForSubject(testid);
                    isSent = BLL.NotificationHandler.sendTestSMS(dtStud, subjectname);
                }
                else
                {
                    foreach (DataGridViewRow gvrFees in ADGVTExamReport.Rows)
                    {
                        if (gvrFees.Cells[0].Value != null && (Boolean)gvrFees.Cells[0].Value == true)
                        {
                            lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[3].Value));

                        }
                    }
                    string list = string.Join(",", lstAdmsnNo.ToArray());
                    dtStud = BLL.TestHandler.getSelectedStudentForTest(testid.ToString(), list.ToString());
                    isSent = BLL.NotificationHandler.sendTestSMS(dtStud, subjectname);
                }
               
                if (isSent == true)
                {
                    UICommon.WinForm.showStatus("Message Sent Successfully !!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Message Not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                UICommon.WinForm.setSMSStatus(isSent, sCaption, this);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.WinForm.showSMSError(sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, sCaption, this);
                }
            }
        }

        private void btnDeleteselected_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow gvrFees in ADGVTExamReport.Rows)
                {
                    DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrFees.Cells[0];
                    chckBx.Value = chkSelectAll.Checked;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }
    }
}
