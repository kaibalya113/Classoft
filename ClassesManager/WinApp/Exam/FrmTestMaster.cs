using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.BLL;
using ClassManager.Common.Exceptions;
using System.Globalization;
using ClassManager.WinApp.UICommon;
using System.Text.RegularExpressions;

namespace ClassManager.WinApp
{
    public partial class FrmTestMaster : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "Test";
        Boolean AllowIndexPositionChange;
        DataTable dtTest;
        List<Info.TestSubject> lstAvailableSujects = new List<Info.TestSubject>();
        List<Info.TestSubject> lstSelectedSubjects = new List<Info.TestSubject>();
        
        bool Allow;

        public FrmTestMaster()
        {
            InitializeComponent();
        }

        private void TestMaster_Load(object sender, EventArgs e)
        {
            try
            {
                formatDTP();

                AllowIndexPositionChange = false;
                Allow = false;

                populateFromStream();
                cmbCourseType.Items.Add(new ComboItem(-1, "All"));
                cmbBatch.Items.Add(new ComboItem(-1, "All"));

                cmbBatch.SelectedIndex = 0;
                cmbCourseType.SelectedIndex = 0;
                cmbStream.SelectedIndex = 0;
                AllowIndexPositionChange = true;
                populateTest();
                AssignEvents();

                Allow = true;
                string alltest = "%";
                // ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, DateTime.Now, true);
                //formatTestGrid();
                Allow = false;
                tabControl1.SelectedIndex = 0;
                Allow = true;
                UICommon.WinForm.formatDateTimePicker(dtpUploadMarks);

                UICommon.WinForm.enableButtonOnItemCount(lstBxSelSub, btnSave);
                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
}

        //Formats DTP.Mohan(11-July-2017).
        private void formatDTP()
        {
            try
            {
                WinForm.formatDateTimePicker(dtTmMarks);
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
                       
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnSave.Visible = false;
                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                    if (formPrevileges.View == false)
                    {
                        btnViewTst.Visible = false;
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
            // ADGVTestMaster.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            //ADGVTestMaster.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            textBoxMarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            ADGVTUploadMarks.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVTUploadMarks.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            txtMarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
          
            txtTotalmarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }

        private void cmbStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    AllowIndexPositionChange = false;
                    populateFromCourse(Convert.ToInt32((cmbStream.SelectedItem as ComboItem).strKey));
                    //AllowIndexPositionChange = true;
                }
                AllowIndexPositionChange = true;
                cmbCourseType.SelectedIndex = 0;
                txtMarks.Text = "0";
                //CmbSubject.DataSource = lstAvailableSujects;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (txtMarks.Text.Length != 0 && txtMarks.Text != "")
        //        {
        //            Info.TestMaster objTest = new Info.TestMaster();
        //            objTest.Standard.Standardid = Convert.ToInt32((cmbCourseType.SelectedItem as Info.ComboItem).strKey);
                   
        //            objTest.BranchId = Convert.ToInt32(branchID);
        //            objTest.TestName = txtName.Text;
        //            objTest.Marks = Convert.ToInt32(txtMarks.Text);
        //            objTest.description = txtDescription.Text;
        //            objTest.Batch.id = (cmbBatch.SelectedItem as Info.ComboItem).key;
        //            bool isSuccess = BLL.TestHandler.saveTest(objTest, lstSelectedSubjects);
        //            if (isSuccess == true)
        //            {

        //                UICommon.WinForm.showStatus("Test created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //                txtDescription.Text = "";
        //               // panel4.Visible = false;
        //              //  lstBxSelSub.Items.Clear();
        //               // lstSelectedSubjects.Clear();
                       
        //            }

        //            resetAllFields(this);
        //            //ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, System.DateTime.Now, false);
        //        }
        //        else
        //        {
        //            if (txtName.Text.Length == 0)
        //            {
        //                UICommon.WinForm.showStatus("Please Enter Test Name ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //                txtName.Focus();
        //            }
        //            else if (textBoxMarks.Text == "0" || textBoxMarks.Text == "")
        //            {
        //                UICommon.WinForm.showStatus("Please Enter Marks ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //                textBoxMarks.Focus();
        //            }
        //        }
        //    }
        //    catch(RecordAlreadyExistsException ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Test"+ txtName.Text.ToString()+" already Exist, Please give Another Name", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }

        //}
        public void resetAllFields(Control control)
        {
            try
            {
                AllowIndexPositionChange = false;
                cmbStream.SelectedIndex = 0;
                cmbCourseType.SelectedIndex = 0;
                cmbBatch.SelectedIndex = 0;
                dtTmMarks.Value = DateTime.Now;
                txtMarks.Text = "0";
                txtName.Text = "";
                //lstSelectedSubjects.Clear();
                lstSelectedSubjects.Clear();
                lstBxSelSub.DataSource = null;
                AllowIndexPositionChange = true;
                panel4.Visible = false;

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
                    txtName.Text = cmbCourseType.SelectedItem.ToString() + "-";
                    lstSelectedSubjects.Clear();
                    lstBxSelSub.DataSource = null;
                    textBoxMarks.Text = "";
                    txtMarks.Text = "0";
                    txtDescription.Text = " ";
                    AllowIndexPositionChange = true;

                    populateSubject(sID);
                    //CmbSubject.DataSource = lstAvailableSujects;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        
        private void populateSubject(int stdId)
        {
            try
            {
                CmbSubject.Items.Clear();
                    lstAvailableSujects = BLL.StandardHandller.getSubjectList(Program.LoggedInUser.BranchId, stdId);
                  
                   foreach (TestSubject objtestSubject in lstAvailableSujects)
                    {
                        CmbSubject.Items.Add(new ComboItem(objtestSubject.subjectmaster.SubjId.ToString(),objtestSubject.subjectmaster.SubjName));
                    }
               // CmbSubject.DataSource = lstAvailableSujects;
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

                cmbStream.Items.Add(new ComboItem("-1", "All"));

                foreach (Stream objStream in lstStream)
                {
                    cmbStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
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

        public void populateFromBatch(int stdID = -1)
        {
            cmbBatch.Items.Clear();
            Info.ComboItem objAll = new Info.ComboItem("-1", "ALL");
            cmbBatch.Items.Add(objAll);

            if (stdID != -1)
            {
                List<Batch> lstBtch = StandardHandller.GetBatches(stdID, Program.LoggedInUser.BranchId);
                foreach (Batch objbatch in lstBtch)
                {
                    cmbBatch.Items.Add(new ComboItem(objbatch.id, objbatch.Name));
                }
            }
            cmbBatch.SelectedIndex = 0;
        }


        public  void populateTest()
        {

            //dtTest = new DataTable();
            dtTest = TestHandler.getAllTests(branchID, DateTime.Now.Date, true);
            cmbTests.Items.Clear();

            Info.ComboItem objAllTest = new Info.ComboItem(-1, "Select Test");
            //cmbTest.Items.Add(objAllTest);
            cmbTests.Items.Add(objAllTest);

            foreach (DataRow dr in dtTest.Rows)
            {
                cmbTests.Items.Add(new ComboItem(Convert.ToInt32(dr.ItemArray[0]), dr.ItemArray[1].ToString()));
            }

        }


        private void btnUploadMarks_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVTUploadMarks.Rows.Count != 0)
                {
                    DataTable dtupdatemarks = new DataTable();
                    dtupdatemarks = ADGVTUploadMarks.DataSource as DataTable;
                    int testID, count = 0, obtainmarks, admissionNo;
                    //string rollno;
                    int marks = Convert.ToInt32(txtTotalmarks.Text);
                    foreach (DataGridViewRow dr in ADGVTUploadMarks.Rows)
                    {
                        obtainmarks = Convert.ToInt32(dr.Cells["MarksObtain"].Value);
                        if (dr.Cells["MarksObtain"].Value != DBNull.Value && obtainmarks <= marks)
                        {
                            count++;
                            //rollno = (dr.Cells["RollNo"].Value).ToString();
                            testID = Convert.ToInt32((cmbTests.SelectedItem as ComboItem).key);
                            admissionNo = Convert.ToInt32(dr.Cells["AdmissionNo"].Value);
                            //BLL.TestHandler.UpdateTestMarks(admissionNo, testID, obtainmarks);

                        }
                    }

                    if (count > 0)
                    {
                        UICommon.WinForm.showStatus("Marks Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Please Enter Valid Marks to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    }

                }
                else
                {
                    UICommon.WinForm.showStatus("First upload marks then save records", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Object cannot be cast from DBNull to other types."))
                {

                    UICommon.WinForm.showStatus("Please Enter Valid Marks to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }

        }

       

      /*  private void updateTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTest.SelectedIndex != 0)
                {
                    Info.TestMaster objtestmaster = new Info.TestMaster();
                    // populateTest();
                    objtestmaster.Id = (cmbTest.SelectedItem as ComboItem).key;
                    objtestmaster.Marks = Convert.ToInt32(txtTestMarks.Text);
                    objtestmaster.TestName = (cmbTest.SelectedItem as ComboItem).name;
                    objtestmaster.Date = dtpNewDate.Value;

                    BLL.TestHandler.updateTest(objtestmaster, false);
                    populateTest();
                    UICommon.WinForm.showStatus("Test updated successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, "Test_Master", this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Select Correct Test to Update Details.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbTest.Focus();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, "Test_Master", this);
            }

        }*/

       /* private void deleteTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTest.SelectedIndex != 0)
                {
                    Info.TestMaster objtestmaster = new Info.TestMaster();
                    objtestmaster.Id = (cmbTest.SelectedItem as ComboItem).key;
                    objtestmaster.TestName = cmbTest.Text;
                    objtestmaster.Date = dtpNewDate.Value;
                    objtestmaster.Marks = Convert.ToInt32(txtTestMarks.Text);
                    BLL.TestHandler.updateTest(objtestmaster, true);
                    populateTest();
                    UICommon.WinForm.showStatus("Test deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Select Correct Test to Delete.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbTest.Focus();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error occured while deleting test", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }*/




      /*  private void btnmrkcmpltd_Click(object sender, EventArgs e)
        {
            int testId = ((Info.ComboItem)cmbTest.SelectedItem).key;
            bool isSuccess = BLL.TestHandler.updateStatus(testId);
            if (isSuccess)
            {
                UICommon.WinForm.showStatus("Test Mark as Completed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, DateTime.Now, true);


            }
            else
            {
                UICommon.WinForm.showStatus("Something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }*/
        private void ADGVTUploadMarks_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (ADGVTUploadMarks.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Common.Events.numOnly);

                }
            }
        }

        private void ADGVTUploadMarks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ADGVTUploadMarks.Columns["Name"].ReadOnly = true;
            ADGVTUploadMarks.Columns["TestId"].Visible = false;
            ADGVTUploadMarks.Columns["StreamId"].Visible = false;
            ADGVTUploadMarks.Columns["stdId"].Visible = false;
        }

        private void txtMarks_TextChanged(object sender, EventArgs e)
        {
           // txtMarks.MaxLength = 4;
        }

        private void txtTotalmarks_TextChanged(object sender, EventArgs e)
        {
            txtTotalmarks.MaxLength =4;
        }

        private void sndMarksSMS_Click(object sender, EventArgs e)
        {
            try
            {
                int testid = Convert.ToInt32((cmbTests.SelectedItem as ComboItem).key);
                string subjectname = (cmbTests.SelectedItem as ComboItem).name;
                DataTable dt = BLL.TestHandler.getStudentForTest(testid);
                BLL.NotificationHandler.sendTestSMS(dt, subjectname);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UICommon.WinForm.formatDateTimePicker(dtTmMarks);
        }

        /// <summary>
        /// Following Function will validate the basic Vaildations.
        /// </summary>
        /// <returns></returns>
        private bool valildateAdded()
        {
            try
            {
                if (CmbSubject.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Select Subject.", sCaption, this);
                    UICommon.WinForm.setFocus(CmbSubject);
                    return false;
                }
                else if (txtName.Text.Trim() == "")
                {
                    UICommon.WinForm.showStatus("Please Provide Test Name.", sCaption, this);
                    UICommon.WinForm.setFocus(txtName);
                    return false;
                }
                //if (!Regex.IsMatch(textBoxMarks.Text, @"(0-9)"))
                else if (textBoxMarks.Text == "" || string.IsNullOrWhiteSpace(textBoxMarks.Text) || Convert.ToInt32(textBoxMarks.Text) == 0)
                {
                    UICommon.WinForm.showStatus("Invalid Marks.", sCaption, this);
                    UICommon.WinForm.setFocus(textBoxMarks);
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
      
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (valildateAdded())
        //        {
        //            Info.TestSubject objtestsubject = new Info.TestSubject();

        //            objtestsubject.Marks = decimal.Parse(textBoxMarks.Text);
        //            objtestsubject.Datetime = DateTime.Parse(dtTmMarks.Text);

        //            objtestsubject.subjectmaster = new SubjectMaster((CmbSubject.SelectedItem as ComboItem).name, (CmbSubject.SelectedItem as ComboItem).key);

        //            lstSelectedSubjects.Add(objtestsubject);

        //            lstBxSelSub.DataSource = null;
        //            lstBxSelSub.DataSource = lstSelectedSubjects;


        //            //CmbSubject.DataSource = lstAvailableSujects;
        //           // lstAvailableSujects.Remove(objtestsubject);
        //           // CmbSubject.DataSource = null;
        //           // CmbSubject.DataSource = lstAvailableSujects;
        //            CmbSubject.Items.Remove(CmbSubject.SelectedItem);

        //            txtMarks.Text = Convert.ToString((Convert.ToInt32(txtMarks.Text)) + (Convert.ToInt32(textBoxMarks.Text)));

        //            textBoxMarks.Clear();

        //            UICommon.WinForm.enableButtonOnItemCount(lstBxSelSub, btnSave);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, sCaption, this);
        //    }
        //}

       

        //private void btnDlt_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal marks = (lstBxSelSub.SelectedItem as TestSubject).Marks;
        //        CmbSubject.Items.Add(lstBxSelSub.SelectedItem as TestSubject);
        //      //  lstAvailableSujects.Add(lstBxSelSub.SelectedItem as TestSubject);
        //      //  CmbSubject.DataSource = null;
        //      //  CmbSubject.DataSource = lstAvailableSujects;

        //        lstSelectedSubjects.Remove(lstBxSelSub.SelectedItem as TestSubject);
        //        lstBxSelSub.DataSource = null;
        //        lstBxSelSub.DataSource = lstSelectedSubjects;
             
        //        txtMarks.Text = Convert.ToString((Convert.ToInt32(txtMarks.Text)) - marks);

        //        UICommon.WinForm.enableButtonOnItemCount(lstBxSelSub, btnSave);

              
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, sCaption, this);
        //    }
        //}
     

        private void lstBxSelSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstBxSelSub.SelectionMode = SelectionMode.One;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBatch.Items.Count > 1)
            {
                panel4.Visible = true;
               
            }
        }

        //private void btnViewTst_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UICommon.FormFactory.GetForm(UICommon.Forms.FrmViewTest).Visible = true;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }
        //}

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (valildateAdded())
                {
                    Info.TestSubject objtestsubject = new Info.TestSubject();

                    objtestsubject.Marks = decimal.Parse(textBoxMarks.Text);
                  //  objtestsubject.Datetime = DateTime.Parse(dtTmMarks.Text);
                    objtestsubject.Datetime = dtTmMarks.Value;
                    objtestsubject.subjectmaster = new SubjectMaster((CmbSubject.SelectedItem as ComboItem).name, (CmbSubject.SelectedItem as ComboItem).key);

                    lstSelectedSubjects.Add(objtestsubject);

                    lstBxSelSub.DataSource = null;
                    lstBxSelSub.DataSource = lstSelectedSubjects;
                    
                    //CmbSubject.DataSource = lstAvailableSujects;
                    // lstAvailableSujects.Remove(objtestsubject);
                    // CmbSubject.DataSource = null;
                    // CmbSubject.DataSource = lstAvailableSujects;
                    CmbSubject.Items.Remove(CmbSubject.SelectedItem);

                    txtMarks.Text = Convert.ToString((Convert.ToInt32(txtMarks.Text)) + (Convert.ToInt32(textBoxMarks.Text)));

                    textBoxMarks.Clear();

                    UICommon.WinForm.enableButtonOnItemCount(lstBxSelSub, btnSave);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBxSelSub.Items.Count != 0)
                {
                    decimal marks = (lstBxSelSub.SelectedItem as TestSubject).Marks;


                    TestSubject objtestSubject = lstBxSelSub.SelectedItem as TestSubject;

                    CmbSubject.Items.Add(new ComboItem(objtestSubject.subjectmaster.SubjId.ToString(), objtestSubject.subjectmaster.SubjName));
                    CmbSubject.SelectedIndex = 0;
                    CmbSubject.SelectedItem = CmbSubject.Items[0];


                    lstSelectedSubjects.Remove(lstBxSelSub.SelectedItem as TestSubject);
                    lstBxSelSub.DataSource = null;
                    lstBxSelSub.DataSource = lstSelectedSubjects;

                   

                    txtMarks.Text = Convert.ToString((Convert.ToInt32(txtMarks.Text)) - marks);

                    UICommon.WinForm.enableButtonOnItemCount(lstBxSelSub, btnSave);

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnViewTst_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmViewTest).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarks.Text.Length != 0 && txtMarks.Text != ""  && txtName.Text != "")
                {
                    Info.TestMaster objTest = new Info.TestMaster();
                    objTest.Standard.Standardid = Convert.ToInt32((cmbCourseType.SelectedItem as Info.ComboItem).strKey);
                    objTest.BranchId = Convert.ToInt32(branchID);
                    objTest.TestName = txtName.Text;
                    objTest.Marks = Convert.ToInt32(txtMarks.Text);
                    objTest.description = txtDescription.Text;
                    objTest.Batch.id = (cmbBatch.SelectedItem as Info.ComboItem).key;
                    objTest.Date = dtTmMarks.Value;
                    bool isSuccess = BLL.TestHandler.saveTest(objTest, lstSelectedSubjects);
                    if (isSuccess == true)
                    {

                        UICommon.WinForm.showStatus("Test created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtDescription.Text = "";
                        // panel4.Visible = false;
                        //  lstBxSelSub.Items.Clear();
                        // lstSelectedSubjects.Clear();

                    }

                    resetAllFields(this);
                    //ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, System.DateTime.Now, false);
                }
                else
                {
                    if (txtName.Text.Length == 0)
                    {
                        UICommon.WinForm.showStatus("Please Enter Test Name ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtName.Focus();
                    }
                    else if (textBoxMarks.Text == "0" || textBoxMarks.Text == "")
                    {
                        UICommon.WinForm.showStatus("Please Enter Marks ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        textBoxMarks.Focus();
                    }
                   
                }
            }
            catch (RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showError(ex, "Test" + txtName.Text.ToString() + " already Exist, Please give Another Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnUploadmrks_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUploadMarks objUploadMarks = (FrmUploadMarks)UICommon.FormFactory.GetForm(Forms.FrmUploadMarks);
                objUploadMarks.Visible = true;
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        }
    }
}





