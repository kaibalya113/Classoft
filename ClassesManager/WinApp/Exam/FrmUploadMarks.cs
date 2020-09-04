using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.Common.Exceptions;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmUploadMarks : FrmParentForm
    {

        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        private static FrmUploadMarks GetInstance;
        public static DataTable dt = null;
        string sCaption = "UploadMarks";
        DataTable dtTest;
        public bool isAdd = false;
        Boolean AllowIndexPositionChange;
        bool Allow; bool addColumn = false;
        public FrmUploadMarks()
        {
            InitializeComponent();
        }

        private void FrmUploadMarks_Load(object sender, EventArgs e)
        {
            try
            {

                AllowIndexPositionChange = false;
                Allow = false;

                populateFromStream();

                cmbCourseType.Items.Add(new ComboItem(-1, "All"));
                cmbBatch.Items.Add(new ComboItem(-1, "All"));

                cmbCourseType.SelectedIndex = 0;
                cmbBatch.SelectedIndex = 0;

                AllowIndexPositionChange = true;



                cmbTests.DisplayMember = "TestName";
                cmbTests.ValueMember = "TestId";
                populateOnlyTest();
                AssignEvents();
                addcolumn();
                Allow = true;

                string alltest = "%";
                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        private void addcolumn()
        {
            try
            {
                if (addColumn == false)
                {

                    addColumn = true;
                    DataGridViewCheckBoxColumn chck = new DataGridViewCheckBoxColumn();
                    chck.Name = "chck";
                    chck.HeaderText = "Mark Absent";
                    chck.TrueValue = true;
                    chck.FalseValue = false;
                    chck.ReadOnly = false;
                    chck.Selected = false;
                    ADGVTUploadMarks.Columns.Insert(0, chck);

                    DataGridViewCheckBoxColumn chkSMS = new DataGridViewCheckBoxColumn();
                    chkSMS.Name = "chkSMS";
                    chkSMS.HeaderText = "Send";
                    chkSMS.TrueValue = true;
                    chkSMS.FalseValue = false;
                    chkSMS.ReadOnly = false;
                    chkSMS.Selected = false;
                    ADGVTUploadMarks.Columns.Insert(0, chkSMS);
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
                        btnSave.Visible = false;
                        sndMarksSMS.Visible = false;
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

        private void AssignEvents()
        {
            try
            {
                ADGVTUploadMarks.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
                ADGVTUploadMarks.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Allow == true)
                {
                    int testID = (cmbTests.SelectedItem as ComboItem).key;
                    if (testID != 0 && testID != -1)
                    {
                        DataTable dt = TestHandler.getStudentForTest(testID);

                        TestMaster test = (cmbTests.SelectedItem as ComboItem).objectValue as TestMaster;

                        this.Text = "Upload Marks " + test.TestName + " (" + Common.Formatter.FormatDate(test.Date) + ")";
                        ADGVTUploadMarks.DataSource = null;
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
                        ADGVTUploadMarks.DataSource = dt;

                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void populateOnlyTest()
        {
            if (!isAdd)

            {
                List<TestMaster> testMasters = TestHandler.getOnlyTests(branchID, 1, (cmbStream.SelectedItem as ComboItem).key, (cmbCourseType.SelectedItem as ComboItem).key.ToString(), (cmbBatch.SelectedItem as ComboItem).key.ToString());
                cmbTests.Items.Clear();

                Info.ComboItem objAllTest = new Info.ComboItem(-1, "Select Test");
                cmbTests.Items.Add(objAllTest);

                foreach (TestMaster test in testMasters)
                {
                    cmbTests.Items.Add(new ComboItem(test.Id, test.TestName,test));
                }

                cmbTests.SelectedIndex = 0;
                cmbTests.SelectedItem = objAllTest;
            }
        }
        internal static FrmUploadMarks getInstance()
        {
            if (GetInstance == null)
            {
                GetInstance = new FrmUploadMarks();
            }

            return GetInstance;
        }
        public void setTest(DataTable dtTest, int TestId, string testName)
        {
            try
            {

                addcolumn();
                ADGVTUploadMarks.DataSource = null;
                ADGVTUploadMarks.DataSource = dtTest;

                cmbTests.Items.Clear();

                cmbTests.Items.Add(new Info.ComboItem(TestId, testName));
                cmbTests.SelectedIndex = 0;
                cmbTests.Enabled = false;
                dt = dtTest;
                isAdd = true;


                this.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSaveExcl_Click(object sender, EventArgs e)
        {

        }

        private void ADGVTUploadMarks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                FormatADGVUploadMarks();
                foreach (DataGridViewRow adrow in ADGVTUploadMarks.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVTUploadMarks.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVTUploadMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void FormatADGVUploadMarks()
        {
            try
            {
                //Changing HeaderText.
                if (ADGVTUploadMarks.Columns.Contains("STMT_ADMISSION_NO"))
                {
                    ADGVTUploadMarks.Columns["STMT_ADMISSION_NO"].HeaderText = "AdmissionNo.";
                    ADGVTUploadMarks.Columns["STMT_ADMISSION_NO"].ReadOnly = true;
                }
                if (ADGVTUploadMarks.Columns.Contains("STMT_FATHER_CONTACT"))
                {
                    ADGVTUploadMarks.Columns["STMT_FATHER_CONTACT"].HeaderText = "FatherContact";
                    ADGVTUploadMarks.Columns["STMT_FATHER_CONTACT"].ReadOnly = true;
                }

                if (ADGVTUploadMarks.Columns.Contains("StudentName"))
                {
                    ADGVTUploadMarks.Columns["StudentName"].ReadOnly = true;
                }

                //Making it Non-Editable.Mohan(27-July-2017).



                //ADGVTUploadMarks.Columns["STMT_FATHER_CONTACT"].ReadOnly = true;


                if (ADGVTUploadMarks.Columns.Contains("chck"))
                {
                    ADGVTUploadMarks.Columns["chck"].Visible = false;
                }
                if (ADGVTUploadMarks.Columns.Contains("STTD_REMARK"))
                {
                    ADGVTUploadMarks.Columns["STTD_REMARK"].DisplayIndex = ADGVTUploadMarks.Columns.Count - 1;
                    ADGVTUploadMarks.Columns["STTD_REMARK"].HeaderText = "Remark";
                }

                //Hiding Columns.


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVTUploadMarks_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVTUploadMarks, e);
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (ADGVTUploadMarks.Rows.Count != 0)
                {

                    DataTable dt = ADGVTUploadMarks.DataSource as DataTable;
                    int rtn = 0;
                    int AdmsnNo, TestId, i, j;
                    string Marks, Remark, Mark;

                    // string subName="";

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[0] != null && dr[0].ToString() != "0")
                        {
                            Marks = "";
                            AdmsnNo = (Convert.ToInt32(dr[1]));
                            Remark = (dr[3]).ToString();
                            TestId = (cmbTests.SelectedItem as ComboItem).key;

                            for (i = 4; i < dr.ItemArray.Count(); i++)
                            {
                                Mark = (dr[i].ToString());


                                if (dr[i].ToString().Trim() == "")
                                {
                                    Mark = "-2";
                                    Marks += (Mark + ",");
                                }
                                if (dr[i].ToString().Trim() == "A")
                                {
                                    Mark = "-1";

                                }
                                if (dr[i].ToString().Trim() != "")
                                {

                                    Marks += (Mark + ",");
                                }

                            }
                            rtn = BLL.TestHandler.UpdateTestMarks(TestId, AdmsnNo, Marks, branchID, Remark);
                        }
                    }


                    if (rtn == 1)
                    {
                        UICommon.WinForm.showStatus("Marks updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Error occured while updating.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }

                }
                else
                {
                    UICommon.WinForm.showStatus("No Records To Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
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
                    foreach (DataGridViewRow gvrFees in ADGVTUploadMarks.Rows)
                    {
                        if (gvrFees.Cells[0].Value != null && (Boolean)gvrFees.Cells[0].Value == true)
                        {
                            lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[3].Value));

                        }
                    }

                    if (lstAdmsnNo.Count == 0)
                    {
                        if (WinForm.showStatus("No student selected to send marks, Do you want to send marks to all students? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, sCaption, this) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow gvrFees in ADGVTUploadMarks.Rows)
                            {
                                lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[3].Value));
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    string list = string.Join(",", lstAdmsnNo.ToArray());

                    dtStud = BLL.TestHandler.getSelectedStudentForTest(testid.ToString(), list.ToString());
                    isSent = BLL.NotificationHandler.sendTestSMS(dtStud, subjectname);
                }
                // bgwUploadMarkSMS(testid, dtStud);
                if (isSent == true)
                {
                    UICommon.WinForm.showStatus("Messages sent successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Messages not sent to some of the students. It might have already sent. Please check SMS report for more details.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVTUploadMarks.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVTUploadMarks, null);
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



        void ADGVTUploadMarks_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int colIndex = ADGVTUploadMarks.CurrentCell.ColumnIndex;

                DataGridViewTextBoxEditingControl txtMarks;

                if (sender is DataGridViewTextBoxEditingControl)
                {
                    txtMarks = sender as DataGridViewTextBoxEditingControl;


                    if (ADGVTUploadMarks.Columns[colIndex].HeaderText != "Remark")
                    {

                        if (e.KeyChar == 45 && txtMarks.Text.Length == 0)
                        {
                            return;
                        }

                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            if (e.KeyChar != 65)
                            {
                                e.Handled = true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }





        private void chkAbsentStudent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAbsentStudent.Checked)
                {
                    foreach (DataGridViewRow assignA in ADGVTUploadMarks.Rows)
                    {
                        foreach (DataGridViewCell singleCell in assignA.Cells)
                        {
                            int columnIndex = singleCell.ColumnIndex;

                            switch (columnIndex)
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                default:
                                    if (singleCell.Value.ToString().Trim() == string.Empty)
                                    {
                                        singleCell.Value = "A";
                                    }
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow assignA in ADGVTUploadMarks.Rows)
                    {
                        foreach (DataGridViewCell singleCell in assignA.Cells)
                        {
                            int columnIndex = singleCell.ColumnIndex;
                            switch (columnIndex)
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;

                                default:
                                    if (singleCell.Value.ToString().Trim() == "A")
                                    {
                                        singleCell.Value = System.DBNull.Value;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow gvrFees in ADGVTUploadMarks.Rows)
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

        private void bgwUploadMarkSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void bgwUploadMarkSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnArchieve_Click(object sender, EventArgs e)
        {
            try
            {
                var Result = MessageBox.Show("Do you want to Archieve this Test?", sCaption, MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    int testid = Convert.ToInt32((cmbTests.SelectedItem as ComboItem).key);
                    bool Done = BLL.TestHandler.updateTestMaster(testid, Convert.ToInt32(branchID));
                    if (Done == true)
                    {
                        UICommon.WinForm.showStatus("Successful !!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    ADGVTUploadMarks.DataSource = null;
                    addcolumn();
                    populateOnlyTest();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void populateFromStream()
        {
            try
            {
                List<Stream> lstStream = StreamHandller.getStreams(branchID);

                cmbStream.Items.Add(new ComboItem("-1", "Select Stream"));

                foreach (Stream objStream in lstStream)
                {
                    cmbStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }

                if (cmbStream.Items.Count > 0)
                {
                    cmbStream.SelectedIndex = 0;
                }

            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public void populateFromCourse(int streamId = -1)
        {
            try
            {

                cmbCourseType.Items.Clear();
                cmbCourseType.Items.Add(new ComboItem("-1", "All"));
                if (streamId != -1)
                {
                    List<Standard> lstStd = StreamHandller.getStandards(Program.LoggedInUser.BranchId, streamId);
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbCourseType.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                    }
                }

                populateFromBatch(-1);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void populateFromBatch(int stdID = -1)
        {

            AllowIndexPositionChange = false;
            cmbBatch.Items.Clear();
            Info.ComboItem objAll = new Info.ComboItem("-1", "All");
            cmbBatch.Items.Add(objAll);

            if (stdID != -1)
            {
                List<Batch> lstBtch = StandardHandller.GetBatches(stdID, Program.LoggedInUser.BranchId);
                foreach (Batch objbatch in lstBtch)
                {
                    cmbBatch.Items.Add(new ComboItem(objbatch.id, objbatch.Name));
                }
            }
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    AllowIndexPositionChange = false;
                    populateFromCourse(Convert.ToInt32((cmbStream.SelectedItem as ComboItem).strKey));
                    AllowIndexPositionChange = true;
                    cmbCourseType.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbCourseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    AllowIndexPositionChange = false;
                    int sID = ((cmbCourseType.SelectedItem as Info.ComboItem).key);
                    populateFromBatch(sID);
                    AllowIndexPositionChange = true;
                    cmbBatch.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    populateOnlyTest();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
    }
}
