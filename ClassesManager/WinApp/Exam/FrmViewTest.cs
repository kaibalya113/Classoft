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
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmViewTest : FrmParentForm

    { 

        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        DataTable dtTest;
       
        string sCaption = "ViewTest";
        public FrmViewTest()
        {
            InitializeComponent();
        }
        private void FrmViewTest_Load(object sender, EventArgs e)
        {
            try
            {
                
                populateTest();
                AssignEvents();

                //  Allow = true;

                string alltest = "%";
                ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, DateTime.Now, true);
                formatTestGrid();

                ApplyPrevileges();

               
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex,sCaption,this);
                
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
                        btnNewTest.Visible = false;
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


        private void formatTestGrid()
        {
            try
            {
                //Hide & disable unnecessary columns
                ADGVTestMaster.Columns["TEST_ID"].Visible = false;
               // ADGVTestMaster.Columns["BTCH_NAME"].Visible = false;
                ADGVTestMaster.Columns["STD_ID"].Visible = false;
                ADGVTestMaster.Columns["TEST_BRANCH_ID"].Visible = false;
                ADGVTestMaster.Columns["TEST_STANDARD_ID"].Visible = false;
                if (ADGVTestMaster.Columns.Contains("TEST_STATUS"))
                {
                    ADGVTestMaster.Columns["TEST_STATUS"].Visible = false;
                }

                //Set Column Headers
                ADGVTestMaster.Columns["TEST_NAME"].HeaderText = "Name";
                ADGVTestMaster.Columns["TEST_NAME"].DisplayIndex = 2;


                if (ADGVTestMaster.Columns.Contains("TSUB_DATETIME"))
                {
                    ADGVTestMaster.Columns["TSUB_DATETIME"].HeaderText = "Date";
                }
                if (ADGVTestMaster.Columns.Contains("TEST_DATE"))
                {
                    ADGVTestMaster.Columns["TEST_DATE"].HeaderText = "Date";
                    ADGVTestMaster.Columns["TEST_DATE"].DisplayIndex = 1;
                }
                if (ADGVTestMaster.Columns.Contains("SUBM_NAME"))
                {
                    ADGVTestMaster.Columns["SUBM_NAME"].HeaderText = "Subject";
                }
                if (ADGVTestMaster.Columns.Contains("TSUB_MARKS"))
                {
                    ADGVTestMaster.Columns["TSUB_MARKS"].HeaderText = "Out of Marks";
                }
                if (ADGVTestMaster.Columns.Contains("TEST_TTL_MARKS"))
                {
                    ADGVTestMaster.Columns["TEST_TTL_MARKS"].HeaderText = "Total Marks";
                }
                ADGVTestMaster.Columns["TEST_DESC"].HeaderText = "Description";
                // ADGVTestMaster.Columns["TEST_STATUS"].HeaderText = "Status";
                //set DateFormat
                if (ADGVTestMaster.Columns.Contains("TSUB_DATETIME"))
                {
                    ADGVTestMaster.Columns["TSUB_DATETIME"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                }
                if (ADGVTestMaster.Columns.Contains("TEST_DATE"))
                {
                    ADGVTestMaster.Columns["TEST_DATE"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void AssignEvents()
        {
            ADGVTestMaster.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVTestMaster.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            
        }

        public void populateTest()
        {
            try
            {
                dtTest = TestHandler.getAllTests(branchID, DateTime.Now.Date, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

       
        private void rbnAllTest_CheckedChanged_1(object sender, EventArgs e)
        {
            try
                {
                    if (rbnAllTest.Checked == true)
                    {
                        //string alltest = "%";
                        ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, System.DateTime.Now, true);
                    }

                }
                catch (Exception ex)
                {
                    UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }

        private void rbtnTomorrowTest_CheckedChanged_1(object sender, EventArgs e)
        {
            {
                try
                {
                    if (rbtnTomorrowTest.Checked == true)
                    {
                        ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, (DateTime.Now.AddDays(1).Date), false);
                    }
                }
                catch (Exception ex)
                {
                    UICommon.WinForm.showError(ex, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }
            }
        }

        private void rbtnTodayTest_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodayTest.Checked)
                {

                    // dtTest = new DataTable();
                    ADGVTestMaster.DataSource = BLL.TestHandler.getAllTests(branchID, DateTime.Now.Date,false);
                    
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please contact Support!", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void ADGVTestMaster_RowPostPaint(object  sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVTestMaster,e);
        }

        private void ADGVTestMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.ColumnIndex == 0)
                {
                    if (formPrevileges != null)
                    {
                        if (formPrevileges.Delete == false)
                        {
                            UICommon.WinForm.showStatus("You don't have permission to Update the Test, Please contact admin", sCaption, this);
                            return;
                        }
                    }
                    if (e.RowIndex != -1)
                    {
                        int TestID = (int)ADGVTestMaster.Rows[e.RowIndex].Cells["TEST_ID"].Value;
                        string TestName = ADGVTestMaster.Rows[e.RowIndex].Cells["TEST_NAME"].Value.ToString();
                       
                        FrmUploadMarks form = UICommon.FormFactory.GetForm(UICommon.Forms.FrmUploadMarks, null, false) as FrmUploadMarks;
                        
                        dtTest = BLL.TestHandler.getStudentForTest(TestID);
                      
                        form.setTest(dtTest,TestID,TestName);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);

            }
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {

            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmTestMaster).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void ADGVTestMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ADGVTestMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ADGVTestMaster_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVTestMaster.Rows)
                {
                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;
                }

               ADGVTestMaster.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
 }
    
    


