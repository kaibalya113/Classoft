using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmFaculties : FrmParentForm
    {


        Info.RolePrivilege formPrevileges;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        string sCaption = "All faculties details";
        public FrmFaculties()
        {
            InitializeComponent();
        }

        private void ShowAllFaculties_Load(object sender, EventArgs e)
        {
            try
            {
                if (chkBranchID.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();
                }
                AddColumn();
                ADGVFaculties.DataSource = BLL.FacultyHandler.showAllFaculties(branchID);
                AssignEvents();
               
                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
}

        private void AddColumn()
        {
            ADGVFaculties.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.eye,
                Name = "ViewFile",
                HeaderText = "View"
            });

            ADGVFaculties.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.Edit,
                Name = "Edit",
                HeaderText = "Edit"
            });
            ADGVFaculties.Columns.Add(new DataGridViewImageColumn()

            {
                Image = Properties.Resources.deleteBin,
                Name = "Delete",
                HeaderText = "Delete"
            });
        }
        /// <summary>
        /// This Function will assign Privileges based on the type of the user logged in.
        /// </summary>
        private void ApplyPrevileges()
        {
            try
            {
                if (this.Tag != null)
                {
                    int functionId = Convert.ToInt32(this.Tag.ToString());
                    formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                    if (formPrevileges != null)
                    {
                        if (formPrevileges.AllBranches == false)
                        {
                            chkBranchID.Visible = false;
                        }

                        if (formPrevileges.Modify == false)
                        {
                            btnSaveChanges.Visible = false;
                        }

                        if (formPrevileges.Create == false)
                        {
                            BtnNewInstructor.Visible = false;
                        }

                        if (formPrevileges.Delete == false)
                        {

                        }
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
            ADGVFaculties.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVFaculties.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
      {
            try
            {                
                BindingSource bs = new BindingSource();
                bs.DataSource = ADGVFaculties.DataSource;
                bs.Filter = ADGVFaculties.Columns["Name"].HeaderText.ToString() + " LIKE '%" + txtName.Text.ToString() + "%'";
                ADGVFaculties.DataSource = bs.DataSource;
            }
            catch (Exception ex)
            {   
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

    

        private void txtCourse_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ADGVFaculties.DataSource;
                bs.Filter = ADGVFaculties.Columns[6].HeaderText.ToString() + " LIKE '%" + txtCourse.Text.ToString() + "%'";
                ADGVFaculties.DataSource = bs;

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
                if (chkBranchID.Checked) //&& ADGVFaculties.RowCount != 0)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();
                }
                ADGVFaculties.DataSource = BLL.FacultyHandler.showAllFaculties(branchID);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
     

        private void ADGVFaculties_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatFacultyViewGrid();

                foreach (DataGridViewRow adrow in ADGVFaculties.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

               ADGVFaculties.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        public void formatFacultyViewGrid()
        {
            try
            {
                //Setting ReadOnly property(Cell text can be edit or not)
                ADGVFaculties.Columns["FCLT_ID"].ReadOnly = true;
                ADGVFaculties.Columns["BRCH_ID"].ReadOnly = true;
                //ADGVFaculties.Columns["BIOM_BIOMETRIC_ID"].ReadOnly = true;
              
                //Hiding Columns.
                ADGVFaculties.Columns["BRCH_ID"].Visible = false;
                
                //Setting Column Name

                ADGVFaculties.Columns["FCLT_ID"].HeaderText = "ID";
                ADGVFaculties.Columns["FCLT_ID"].ReadOnly = true;
                ADGVFaculties.Columns["BIOM_BIOMETRIC_ID"].HeaderText = "Biometric No";
                ADGVFaculties.Columns["FCLT_CONTACT_NO"].HeaderText = "Contact No";
                ADGVFaculties.Columns["FCLT_EMAIL_ID"].HeaderText = "Email ID";
                ADGVFaculties.Columns["FCLT_ADDRESS"].HeaderText = "Address";
                ADGVFaculties.Columns["BRCH_NAME"].HeaderText = "Branch Name";
                ADGVFaculties.Columns["FCLT_DOB"].HeaderText = "DOB";
                ADGVFaculties.Columns["FCLT_QUALIFICATION"].HeaderText = "Qualification";
                ADGVFaculties.Columns["FCLT_ADHARCARD_NO"].HeaderText = "AadharCard No";
                ADGVFaculties.Columns["FCLT_PANCARD_NO"].HeaderText = "PanCard no";

                ADGVFaculties.Columns["BIOM_BIOMETRIC_ID"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_CONTACT_NO"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_EMAIL_ID"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_ADDRESS"].ReadOnly = true;
                ADGVFaculties.Columns["BRCH_NAME"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_DOB"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_QUALIFICATION"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_ADHARCARD_NO"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_PANCARD_NO"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_RESUME"].Visible = false;
                ADGVFaculties.Columns["BRCH_NAME"].Visible = false;
                ADGVFaculties.Columns["FCLT_ID"].Visible = false;

                ADGVFaculties.Columns["Name"].DisplayIndex = 1;
                ADGVFaculties.Columns["Name"].ReadOnly = true;
                ADGVFaculties.Columns["FCLT_CONTACT_NO"].DisplayIndex = 2;
                ADGVFaculties.Columns["FCLT_ADDRESS"].DisplayIndex = 3;
                ADGVFaculties.Columns["FCLT_QUALIFICATION"].DisplayIndex = 4;
                ADGVFaculties.Columns["FCLT_EMAIL_ID"].DisplayIndex = 5;
                ADGVFaculties.Columns["FCLT_DOB"].DisplayIndex = 6;
                ADGVFaculties.Columns["BIOM_BIOMETRIC_ID"].DisplayIndex = 7;
                ADGVFaculties.Columns["FCLT_ADHARCARD_NO"].DisplayIndex = 8;
                ADGVFaculties.Columns["FCLT_PANCARD_NO"].DisplayIndex = 9;
              
                ADGVFaculties.Columns["ViewFile"].DisplayIndex = ADGVFaculties.Columns.Count - 2;
                ADGVFaculties.Columns["Edit"].DisplayIndex = ADGVFaculties.Columns.Count - 3;
                ADGVFaculties.Columns["Delete"].DisplayIndex = ADGVFaculties.Columns.Count - 1;

                ADGVFaculties.Columns["Delete"].Width = 70;
                ADGVFaculties.Columns["Edit"].Width = 60;
                ADGVFaculties.Columns["ViewFile"].Width = 70;
                ADGVFaculties.Columns["FCLT_DOB"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
            }

            catch (Exception ex)
            {

                throw ex;
            }
          
        }
       
        private void ADGVFaculties_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVFaculties, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void BtnNewInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFaculty).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ADGVFaculties.DataSource as DataTable;
                Info.Faculty objFaculty = new Info.Faculty();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRows in dt.Rows)
                    {
                        objFaculty.ContactNo = dtRows["FCLT_CONTACT_NO"].ToString();
                        objFaculty.Name = dtRows["Name"].ToString();
                        if ((dtRows["FCLT_DOB"].ToString() == DBNull.Value.ToString()))
                        {
                            objFaculty.DOb = DateTime.Now.AddYears(-20);
                            //objFaculty.FacultyID = Convert.ToInt32(dtRows["ID"]); ------We should not allow to update this ID because join is performed 
                        }
                        else
                        {
                            objFaculty.DOb = Convert.ToDateTime(dtRows["FCLT_DOB"]);
                        }
                    
                        objFaculty.EmailId = dtRows["FCLT_EMAIL_ID"].ToString();
                        objFaculty.Address = dtRows["FCLT_ADDRESS"].ToString();
                        objFaculty.FacultyID = Convert.ToInt32(dtRows["FCLT_ID"]);
                        objFaculty.biometricId = Convert.ToInt32(dtRows["BIOM_BIOMETRIC_ID"]);
                        objFaculty.branchId = Convert.ToInt32(dtRows["BRCH_ID"]);
                         objFaculty.Pancard = Convert.ToString(dtRows["FCLT_PANCARD_NO"]);
                        objFaculty.Qualification = (dtRows["FCLT_QUALIFICATION"].ToString());
                        objFaculty.AdharCard = dtRows["FCLT_ADHARCARD_NO"].ToString();
                        BLL.FacultyHandler.updatefacultyPersnlDtl(objFaculty);
                    }
                    if (objFaculty != null)
                    {
                        UICommon.WinForm.showStatus("Facutly Details Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    else
                    {
                        UICommon.WinForm.showStatus("Failed to Update Details", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                    ADGVFaculties.DataSource = null;
                    //ADGVFaculties.DataSource = BLL.FacultyHandler.getFaculties(branchID);--- These two methods are same(Fetch Faculty Data)
                    ADGVFaculties.DataSource = BLL.FacultyHandler.showAllFaculties(branchID);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVFaculties.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVFaculties,null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void ADGVFaculties_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var row = ADGVFaculties.Rows[e.RowIndex];
            if (null != row)
            {
                var cell = row.Cells[e.ColumnIndex];
                if (null != cell)
                {
                    object value = cell.Value;
                    if (null != value)
                    {
                        // Do your test here in combination with columnindex etc
                    }
                }
            }
        }

        private void ADGVFaculties_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                (ADGVFaculties.Columns[7] as DataGridViewTextBoxColumn).MaxInputLength = 10;
                 e.Control.KeyPress += new KeyPressEventHandler(ADGVFaculties_KeyPress);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVFaculties_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                (ADGVFaculties.Columns[2] as DataGridViewTextBoxColumn).MaxInputLength = 10;

                if (ADGVFaculties.CurrentCell.ColumnIndex == ADGVFaculties.Columns[2].Index)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVFaculties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ADGVFaculties.Columns["ViewFile"].Index)
                    {
                        string filename = (ADGVFaculties.Rows[e.RowIndex].Cells["FCLT_RESUME"].Value).ToString();
                        if (filename != null && filename != "")
                        {
                            System.Diagnostics.Process.Start(filename);
                        }
                        else
                        {
                            UICommon.WinForm.showStatus("No Attachment to View", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        }
                    }

                    else if (ADGVFaculties.Columns.Contains("Edit") && e.ColumnIndex == ADGVFaculties.Columns["Edit"].Index)
                    {
                            FrmFaculty FacultyUpdate = (FrmFaculty)UICommon.FormFactory.GetForm(Forms.FrmFaculty, this, true);
                            FacultyUpdate.setValuesForUpdate(Convert.ToInt32(ADGVFaculties.Rows[e.RowIndex].Cells["FCLT_ID"].Value));
                            FacultyUpdate.ShowDialog();
                           ADGVFaculties.DataSource = BLL.FacultyHandler.showAllFaculties(branchID);

                    }
                    else if (ADGVFaculties.Columns.Contains("Delete") && e.ColumnIndex == ADGVFaculties.Columns["Delete"].Index)
                    {
                        var sure = MessageBox.Show("Do you Want to Delete " + ADGVFaculties.Rows[e.RowIndex].Cells["Name"].Value.ToString().Trim(),"Details",MessageBoxButtons.YesNo);
                      
                        if (sure == DialogResult.Yes)
                        {
                            BLL.FacultyHandler.Deletefaculty((Convert.ToInt32(ADGVFaculties.Rows[e.RowIndex].Cells["FCLT_ID"].Value)), ADGVFaculties.Rows[e.RowIndex].Cells["Name"].Value.ToString(), ADGVFaculties.Rows[e.RowIndex].Cells["FCLT_CONTACT_NO"].Value.ToString(), Convert.ToInt32(branchID));
                            UICommon.WinForm.showStatus("Deleted Sucessfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            ADGVFaculties.DataSource = BLL.FacultyHandler.showAllFaculties(branchID);
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
