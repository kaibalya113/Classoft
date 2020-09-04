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
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmDeleteStudent : FrmParentForm
    {

        RolePrivilege formPrevileges;
        DataTable dt;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        bool AllowIndexPositionChange;
        bool selectAll = false;
        string sCaption = "Delete Student";
        DataView newList;
        DataSet dsDeleteStud;
        public static Info.Student objStudent;
        public FrmDeleteStudent()
        {
            InitializeComponent();
        }

        #region "Form Events"

        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            try
            {
                AllowIndexPositionChange = false;

                //Adding CheckBox Column.
                DataGridViewCheckBoxColumn chckAll = new DataGridViewCheckBoxColumn();
                chckAll.Name = "chckAll";
                chckAll.HeaderText = "Delete";
                chckAll.TrueValue = true;
                chckAll.FalseValue = false;
                chckAll.Selected = false;
                ADGVDeleteStudent.Columns.Insert(0, chckAll);



                cmbStram.Items.Clear();
                Info.ComboItem objAllCource = new ComboItem("%", "ALL");

                cmbStram.Items.Add(objAllCource);

                //Add all in cmbCourseNm
                cmbCourse.Items.Clear();
                Info.ComboItem objAllStd = new ComboItem("%", "ALL");

                cmbCourse.Items.Add(objAllStd);


                //Add all in Batch
                cmbBatch.Items.Clear();
                Info.ComboItem objAllBatch = new ComboItem("%", "ALL");

                cmbBatch.Items.Add(objAllStd);
                List<Info.Stream> lstSTream = BLL.StreamHandller.getStreams(branchID);
                foreach (Info.Stream objStream in lstSTream)
                {
                    cmbStram.Items.Add(new Info.ComboItem(objStream.ID.ToString(), objStream.Name));
                }

                cmbStram.SelectedIndex = 0;
                cmbCourse.SelectedIndex = 0;
                cmbBatch.SelectedIndex = 0;
                AllowIndexPositionChange = true;
                getDeleteStudent();

                //Filter Events.Mohan.(28-July-2017).
                WinForm.AssignFilterEvent(ADGVDeleteStudent);
                ApplyPrevileges();

                if (Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Gym" || Info.SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Dance")
                {
                    lblStream.Text = "Package:";
                    lblCourse.Text = "PackageType:";
                }
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
                        btnDeleteselected.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Dropdown Events"

        private void cmbStram_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    AllowIndexPositionChange = false;
                    if (cmbStram.SelectedIndex != 0)
                    {
                        cmbCourse.Items.Clear();
                        cmbCourse.Items.Add(new Info.ComboItem("%", "All"));
                        String stream = (cmbStram.SelectedItem as Info.ComboItem).strKey;
                        displaycombocrse(stream);


                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new ComboItem("%", "All"));
                        int course = (cmbCourse.SelectedItem as ComboItem).key;
                        displaybtch(course);
                    }
                    else
                    {
                        cmbCourse.Items.Clear();
                        cmbCourse.Items.Add(new Info.ComboItem("%", "All"));
                        cmbCourse.SelectedIndex = 0;

                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new Info.ComboItem("%", "All"));

                        cmbBatch.SelectedIndex = 0;
                    }
                    AllowIndexPositionChange = true;
                    getDeleteStudent();
                }
            }
            catch (Exception exc)
            {
                UICommon.WinForm.showError(exc, "cannot delete the student due to some issue. Contact system admin.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    AllowIndexPositionChange = false;
                    if (cmbCourse.SelectedIndex != 0)
                    {
                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new Info.ComboItem("%", "All"));

                        String sID = ((cmbCourse.SelectedItem as Info.ComboItem).strKey).ToString();
                        displaybtch(Convert.ToInt32(sID));
                        cmbBatch.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbBatch.Items.Clear();
                        cmbBatch.Items.Add(new Info.ComboItem("%", "All"));
                        cmbBatch.SelectedIndex = 0;
                    }
                    getDeleteStudent();
                    AllowIndexPositionChange = true;
                }

            }


            catch (Exception exc)
            {
                UICommon.WinForm.showError(exc, "Error Occured,Contact system admin.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllowIndexPositionChange == true)
                {
                    AllowIndexPositionChange = false;
                    getDeleteStudent();

                    AllowIndexPositionChange = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        #endregion


        #region "Functions"


        public void displaycombostrm()
        {
            try
            {
                List<Info.Stream> lststream = BLL.StreamHandller.getStreams(branchID);
                Info.ComboItem objAll = new Info.ComboItem("%", "All");
                cmbStram.Items.Clear();
                cmbStram.Items.Add(objAll);

                foreach (Info.Stream objStream in lststream)
                {
                    cmbStram.Items.Add(new Info.ComboItem(objStream.ID.ToString(), objStream.Name));
                }
                cmbStram.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void displaycombocrse(string stream = "%")
        {
            try
            {
                cmbCourse.Items.Clear();
                List<Info.Standard> lstStandard = BLL.StandardHandller.getStandard(branchID.ToString(), stream);
                Info.ComboItem objAll = new Info.ComboItem("%", "All");
                cmbCourse.Items.Add(objAll);

                foreach (Info.Standard objStandard in lstStandard)
                {
                    cmbCourse.Items.Add(new Info.ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                }
                cmbCourse.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void displaybtch(int sID = '%')
        {
            try
            {
                List<Info.Batch> lstBatch = BLL.StandardHandller.GetBatches(sID, Program.LoggedInUser.BranchId);
                Info.ComboItem objAll = new Info.ComboItem("%", "All");
                cmbBatch.Items.Clear();
                cmbBatch.Items.Add(objAll);

                foreach (Info.Batch objBatch in lstBatch)
                {
                    cmbBatch.Items.Add(new Info.ComboItem(objBatch.id.ToString(), objBatch.Name));
                }
                cmbBatch.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
            //cmbBatch.Items.Clear();

        }

        private void getDeleteStudent()
        {
            try
            {
                WinForm.AssignFilterEvent(ADGVDeleteStudent);
                newList = null;
                ADGVDeleteStudent.DataSource = null;

                string StreamId = (cmbStram.SelectedItem as Info.ComboItem).strKey;
                string CourseId = (cmbCourse.SelectedItem as Info.ComboItem).strKey;
                string BatchId = (cmbBatch.SelectedItem as Info.ComboItem).strKey;
                string BranchId = branchID;

                dt = BLL.StudentHandller.getActiveStudents(StreamId, CourseId, BatchId, BranchId);
                //ADGVDeleteStudent.DataSource = dt;
                ADGVDeleteStudent.PageSize = 25;
                ADGVDeleteStudent.SetPagedDataSource(dt, bindingNavigator1);
                //DataSet dtallstudent = new DataSet();
                //dtallstudent.Tables.Add(dt);
                dsDeleteStud = new DataSet();
                dsDeleteStud.Tables.Add(dt);
                newList = new DataView(dt);
                loadFee(branchID, newList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Action Events"

        private void loadFee(string branchId, DataView newList = null)
        {
            try
            {


                if (newList == null)
                {
                    newList = new DataView(dt);
                }

                else if (newList.Count > 0)
                {

                    ADGVDeleteStudent.DataSource = newList;
                    ADGVDeleteStudent.SetPagedDataSource((newList.ToTable()), bindingNavigator1);
                }



            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        private void chkbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ADGVDeleteStudent.DataSource != null)
                {
                    ADGVDeleteStudent.DataSource = newList;
                    if (chkbxSelectAll.Checked == true)
                    {
                        selectAll = true;
                        chkbxsoPaidStudent.Checked = false;
                        foreach (DataGridViewRow dgvSelectAll in ADGVDeleteStudent.Rows)
                        {
                            DataGridViewCheckBoxCell dgvchckbxcell = (DataGridViewCheckBoxCell)dgvSelectAll.Cells[0];
                            dgvchckbxcell.Value = true;

                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow dgvUnSelectAll in ADGVDeleteStudent.Rows)
                        {
                            DataGridViewCheckBoxCell dgvchckbxcell = (DataGridViewCheckBoxCell)dgvUnSelectAll.Cells[0];
                            dgvchckbxcell.Value = false;
                        }
                    }
                    selectAll = false;

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkbxsoPaidStudent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {///ADDED BY ASHVINI 4-1-2019
             //FOR proper working
                if (ADGVDeleteStudent.DataSource != null)
                {
                    if (chkbxsoPaidStudent.Checked == true)
                    {
                        chkbxSelectAll.Checked = false;
                        foreach (DataGridViewRow gvrSelectPaid in ADGVDeleteStudent.Rows)
                        {

                            bool chkAll;
                            decimal pendingAmnt = Convert.ToDecimal(gvrSelectPaid.Cells["Outstanding Fees"].Value == System.DBNull.Value ? 0 : gvrSelectPaid.Cells["Outstanding Fees"].Value);

                            if (pendingAmnt == 0)
                            {
                                DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrSelectPaid.Cells[0];
                                chkAll = true;
                                chckBx.Value = chkAll;


                            }
                            else
                            {
                                DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrSelectPaid.Cells[0];
                                chkAll = false; ;
                                chckBx.Value = chkAll;


                            }
                        }
                    }


                    else
                    {
                        bool chk;
                        foreach (DataGridViewRow gvrUnselect in ADGVDeleteStudent.Rows)
                        {
                            DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)gvrUnselect.Cells[0];
                            chk = false;
                            chckBx.Value = chk;
                        }
                    }

                }
                //end by ashvini04-01-2019
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        #endregion

        #region "Gridview Events"

        private void ADGVDeleteStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                ADGVDeleteStudent.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVDeleteStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                ADGVDeleteStudent.Columns[3].ReadOnly = true;
                ADGVDeleteStudent.Columns[3].Width =300;
                ADGVDeleteStudent.Columns[2].HeaderText = Lang.translate("AdmissionNo");
                ADGVDeleteStudent.Columns[1].Visible = false;
                ADGVDeleteStudent.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ADGVDeleteStudent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 0 && selectAll == false)
                {
                    DataGridViewRow selectedRow = ADGVDeleteStudent.Rows[e.RowIndex];

                    DataGridViewCell selectedCell = ADGVDeleteStudent.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    DataGridViewCheckBoxCell dgvChkbx = selectedCell as DataGridViewCheckBoxCell;

                    ADGVDeleteStudent.RefreshEdit();
                    ADGVDeleteStudent.NotifyCurrentCellDirty(true);

                    if (Convert.ToBoolean(dgvChkbx.Value) == true)
                    {
                        decimal outstanding_fees = Convert.ToDecimal(selectedRow.Cells["Outstanding Fees"].Value == System.DBNull.Value ? 0 : selectedRow.Cells["Outstanding Fees"].Value);
                        if (outstanding_fees > 0)
                        {
                            var a = MessageBox.Show("Outstanding fees of " + selectedRow.Cells["Name"].Value.ToString().Trim() + " is " + outstanding_fees + ". Are you sure to select this Member ??", "Confirm select!!", MessageBoxButtons.YesNo);


                            if (a == DialogResult.Yes)
                            {
                                dgvChkbx.Value = false;
                                ADGVDeleteStudent.RefreshEdit();
                                ADGVDeleteStudent.NotifyCurrentCellDirty(true);
                            }
                            else
                            {
                                dgvChkbx.Value = true;
                                ADGVDeleteStudent.RefreshEdit();
                                ADGVDeleteStudent.NotifyCurrentCellDirty(true);
                            }

                        }
                        else
                        {
                            dgvChkbx.Value = true;
                            ADGVDeleteStudent.RefreshEdit();
                            ADGVDeleteStudent.NotifyCurrentCellDirty(true);

                        }

                    }

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        #endregion

        private void ADGVDeleteStudent_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVDeleteStudent, e);
        }

        private void btnDeleteselected_Click(object sender, EventArgs e)
        {
            try
            {
                //int adno;
                List<Int32> lstAdmissionNo = new List<Int32>();
                foreach (DataGridViewRow dgvRow in ADGVDeleteStudent.Rows)
                {
                    if (Convert.ToBoolean(dgvRow.Cells[0].Value) == true)
                    {
                        lstAdmissionNo.Add(Convert.ToInt32(dgvRow.Cells["Admission No"].Value));
                        int adn = Convert.ToInt32(dgvRow.Cells["Admission No"].Value);
                        string name = (dgvRow.Cells["Name"].Value).ToString();
                        string Course = (dgvRow.Cells["Batch Name"].Value).ToString();
                        int outstanding;
                        if (dgvRow.Cells["Outstanding Fees"].Value == DBNull.Value)
                        {
                            outstanding = 0;
                        }
                        else
                        {
                            outstanding = Convert.ToInt32(dgvRow.Cells["Outstanding Fees"].Value);
                        }
                        BLL.UserHandler.createActivity(adn, DateTime.Now.Date, "Deleted Student : " + name + "and Course is " + Course + "and Outstanding is " + outstanding, name, "A", "D", Program.LoggedInUser.UserId.ToString(), Program.LoggedInUser.BranchId.ToString());
                        //UICommon.WinForm.showStatus("Deleted Student Activity is created successfully", null, null);
                    }

                }
                if (lstAdmissionNo.Count != 0)
                {
                    foreach (Int32 admsnNo in lstAdmissionNo)
                    {
                        BLL.StudentHandller.deletestudent(admsnNo);
                        // UICommon.WinForm.showStatus("Deleted Student Activity is created successfully", null, null);
                    }


                }




                else
                {
                    UICommon.WinForm.showStatus("No student  for deletion ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }


                getDeleteStudent();

                selectAll = false;

                ADGVDeleteStudent.Refresh();

            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVDeleteStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ///ADDED BY ASHVINI 4-1-2019
                //for solving issue of not checked single checkbox
                if (e.ColumnIndex == 0 && selectAll == false)
                {
                    DataGridViewRow selectedRow = ADGVDeleteStudent.Rows[e.RowIndex];

                    DataGridViewCell selectedCell = ADGVDeleteStudent.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    DataGridViewCheckBoxCell dgvChkbx = selectedCell as DataGridViewCheckBoxCell;
                    if (dgvChkbx.Value == null)
                    {
                        dgvChkbx.Value = false;
                        dgvChkbx.Value = !(Boolean)dgvChkbx.Value;
                    }
                    else
                    {
                        dgvChkbx.Value = !(Boolean)dgvChkbx.Value;
                    }
                    //end by ashvini04-01-2019

                    if (Convert.ToBoolean(dgvChkbx.Value) == true)
                    {
                        decimal outstanding_fees = Convert.ToDecimal(selectedRow.Cells["Outstanding Fees"].Value == System.DBNull.Value ? 0 : selectedRow.Cells["Outstanding Fees"].Value);
                        if (outstanding_fees > 0)
                        {
                            var a = MessageBox.Show("Outstanding fees of " + selectedRow.Cells["Name"].Value.ToString().Trim() + " is " + outstanding_fees + ". Are you sure to select this Member ??", "Confirm select!!", MessageBoxButtons.YesNo);


                            if (a == DialogResult.Yes)
                            {
                                dgvChkbx.Value = false;
                                ADGVDeleteStudent.RefreshEdit();
                                ADGVDeleteStudent.NotifyCurrentCellDirty(false);
                            }
                            else
                            {
                                dgvChkbx.Value = false;
                                ADGVDeleteStudent.RefreshEdit();
                                ADGVDeleteStudent.NotifyCurrentCellDirty(false);
                            }

                        }
                        else
                        {
                            dgvChkbx.Value = true;
                            ADGVDeleteStudent.RefreshEdit();
                            ADGVDeleteStudent.NotifyCurrentCellDirty(true);

                        }

                    }

                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }
    }
}

