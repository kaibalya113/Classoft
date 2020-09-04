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
    public partial class FrmViewSub : FrmParentForm
    {

        RolePrivilege formPrevileges;


        string sCaption = "View Faculty-Subjects ";
        string BranchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        Boolean allowIndexChnge;
        bool allow;
        DataTable dtSub;

        /// <summary>
        /// 
        /// </summary>
        public FrmViewSub()
        {
            InitializeComponent();
        }


        private void ViewSubjects_Load(object sender, EventArgs e)
        {
            try
            {
                addColumn();
                if (chkShowAllBranch.Checked)
                {
                    BranchId = "%";
                }
                else
                {
                    BranchId = Program.LoggedInUser.BranchId.ToString();
                }
                allowIndexChnge = false;
                allow = false;
                getstream();

                if (cmbStrm.Items.Count > 0)
                {
                    GetCourse((cmbStrm.SelectedItem as ComboItem).strKey);
                }
                else
                {
                    UICommon.WinForm.showStatus("No courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                if (cmbCrse.Items.Count > 0)
                {
                    cmbCrse.SelectedIndex = 0;
                }
                allowIndexChnge = true;
                AsignEvent();
                allow = true;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void addColumn()
        {
            ADGViewSubject.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.deleteBin,
                Name = "btnDelete",
                HeaderText = "Delete"
            });

            ADGViewSubject.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.upgrade,
                Name = "btnUpdate",
                HeaderText = "Update"
            });
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
                        btnCrtSub.Visible = false;

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

        private void AsignEvent()
        {
            ADGViewSubject.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGViewSubject.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        private void getstream()
        {
            try
            {
                List<Stream> lstStream = StreamHandller.getStreams(BranchId);

                foreach (Stream objStream in lstStream)
                {
                    cmbStrm.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }
                if (lstStream.Count > 0)
                {
                    cmbStrm.SelectedIndex = 0;
                }

                else
                {
                    UICommon.WinForm.showStatus("No stream available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void GetCourse(string stream = "%")
        {
            try
            {

                if (cmbStrm.Items.Count > 0)
                {
                    cmbCrse.Items.Clear();
                    List<Standard> lstStd = StandardHandller.getStandard(BranchId.ToString(), stream);
                    foreach (Standard objStandard in lstStd)
                    {
                        cmbCrse.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                    }
                    if (lstStd.Count > 0)
                    {
                        cmbCrse.SelectedIndex = 0;

                    }
                    else
                    {
                        UICommon.WinForm.showStatus("No courses available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    }
                }
                else
                {

                    UICommon.WinForm.showStatus("No Streams available ", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbStrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (allowIndexChnge == true)
                {
                    allowIndexChnge = false;
                    string stream = (cmbStrm.SelectedItem as ComboItem).strKey;
                    allowIndexChnge = true;
                    GetCourse(stream);

                    //lstSubjects.DataSource = null;
                }
                allowIndexChnge = true;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void cmbCrse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadSubjects();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        private void FormatGrid()
        {
            ADGViewSubject.Columns["SUBM_NAME"].HeaderText = "Subject";
            ADGViewSubject.Columns["SUBM_NAME"].DisplayIndex = 2;
            ADGViewSubject.Columns["FCLT_NAME"].HeaderText = "Faculty";
            ADGViewSubject.Columns["FCLT_CONTACT_NO"].HeaderText = "Contact";
            ADGViewSubject.Columns["STD_NAME"].HeaderText = "Course";
            ADGViewSubject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ADGViewSubject.Columns["SUBM_ID"].Visible = false;
            ADGViewSubject.Columns["SUBF_ID"].Visible = false;
            ADGViewSubject.ReadOnly = true;
        }

        private void ADGViewSubject_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGViewSubject, e);
        }

        private void ADGViewSubject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatGrid();
            foreach (DataGridViewRow adrow in ADGViewSubject.Rows)
            {
                adrow.Height = 30;
                adrow.MinimumHeight = 30;
            }

            ADGViewSubject.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
        }

        private void chkShowAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllBranch.Checked)
            {
                BranchId = "%";
            }
            else
            {
                BranchId = Program.LoggedInUser.BranchId.ToString();
            }
            int sID = ((cmbCrse.SelectedItem as Info.ComboItem).key);
            DataTable dtSub = FacultyHandler.GetAllSubjects(sID, BranchId);
            ADGViewSubject.DataSource = null;
            ADGViewSubject.DataSource = dtSub;

        }

        private void btnCrtSub_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmSubjectMaster).Visible = true;
                // this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGViewSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ADGViewSubject.Columns["btnDelete"].Index)
                {
                    if (MessageBox.Show("Are you sure you want to delete the subject", sCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        StandardHandller.DeleteSubject(Convert.ToInt32(ADGViewSubject.Rows[e.RowIndex].Cells["SUBM_ID"].Value), Program.LoggedInUser.BranchId);
                        UICommon.WinForm.showMessage("Subject Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                        loadSubjects();
                    }
                    
                }
                else if (e.ColumnIndex == ADGViewSubject.Columns["btnUpdate"].Index)
                {
                    int? subjectId = ADGViewSubject.Rows[e.RowIndex].Cells["SUBM_ID"].Value as Int32?;
                    FrmSubjectMaster frmSubjectMaster = FormFactory.GetForm(Forms.FrmSubjectMaster) as FrmSubjectMaster;
                    frmSubjectMaster.loadSubject(subjectId);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void loadSubjects()
        {
            try
            {
                int sID = ((cmbCrse.SelectedItem as Info.ComboItem).key);
                if (allowIndexChnge == true)
                {
                    allowIndexChnge = false;
                    DataTable dtSub = FacultyHandler.GetAllSubjects(sID, BranchId);
                    ADGViewSubject.DataSource = null;
                    ADGViewSubject.DataSource = dtSub;
                    allowIndexChnge = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

