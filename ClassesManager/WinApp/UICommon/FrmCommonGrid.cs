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
using ClassManager.Info;

namespace ClassManager.WinApp
{
    public partial class Commongrid : FrmParentForm
    {

        private static Commongrid myInstance;
        private string sCaption = "Common";

       
        public Commongrid()
        {
            InitializeComponent();
        }
        


        private void FrmCommonGrid_Load(object sender, EventArgs e)
        {
            AssignFilterEvent();


        }

        //Assigning Filter Events.Mohan(28-July-2017).
        private void AssignFilterEvent()
        {
            grid.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            grid.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }


        internal static Commongrid getInstance()
        {
            if (myInstance == null)
            {
                myInstance = new Commongrid();
            }
            return myInstance;
        }
        public void bindData(DataTable dt)
        {
            try
            {
                grid.DataSource = dt;
                foreach (DataGridViewRow adrow in grid.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

               grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
              // grid.Columns["Date"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
            //try
            //{
            //    formatDateColumn(grid.Columns["Date"]);
            //    formatDateColumn(grid.Columns["AdmissionDate"]);
            //    formatDateColumn(grid.Columns["ExpiredOn"]);

            //    if (cmbFilterBy.Visible == true && cmbFilterBy.SelectedIndex == 2)
            //    {
            //        removeifexist(grid.Columns["Renew"]);
            //        removeifexist(grid.Columns["Delete"]);
            //    }
            //    if (cmbFilterBy.SelectedIndex == 0 && grid.Columns.Contains("Delete"))
            //    {
            //        removeifexist(grid.Columns["Delete"]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    UICommon.WinForm.showError(ex, sCaption, this);
            //}
        //}

        ////To Remove a Column if exists.Mohan(15-July-2017).
        //private void removeifexist(DataGridViewColumn column)
        //{
        //    if (grid.Columns.Contains(column))
        //    {
        //        grid.Columns.Remove(column);
        //    }
        //}

        ////To Format Date of a Column if Exists.Mohan(15-July-2017).
        //private void formatDateColumn(DataGridViewColumn column)
        //{
        //    if (grid.Columns.Contains(column))
        //    {
        //        grid.Columns[column.Name].DefaultCellStyle.Format = Common.Formatter.DateFormat;
        //    }
        //}

        public void formatGrid(int identifier)
        {
            try
            {
                //Hiding Columns.
                switch (identifier)
                {
                    case 1:
                        grid.Columns["STRM_ID"].Visible = false;
                        break;
                    case 2:
                        grid.Columns["STD_ID"].Visible = false;
                        break;
                    case 3:
                        grid.Columns["BTCH_ID"].Visible = false;
                        break;
                    case 4:
                        grid.Columns["FPKG_ID"].Visible = false;
                        break;
                }

                //Changing HeaderTeaxt.
                grid.Columns["STMT_CONTACT_NO"].HeaderText = "ContactNo";
                grid.Columns["STMT_ADDRESS"].HeaderText = "Address";
                //grid.Columns["FPKG_PACKAGE_NAME"].HeaderText = "Package";

                if (grid.Columns.Contains(""))
                {
                    grid.Columns[""].Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setForm(string filterBy, string filterName)
        {
            try
            {
                this.Text = "Members of " + filterBy + " " + filterName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(grid, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }


        public void bindSMSReport(DataTable record)
        {
            if(record.Rows.Count>0)
            {
                grid.DataSource = record;
                foreach (DataGridViewRow adrow in grid.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
                grid.Columns["Date"].DefaultCellStyle.Format = Common.Formatter.DateFormat;
                grid.Columns["Date"].DefaultCellStyle = WinForm.GridDateFormat;
                //record.Rows.Clear();
            }           
        }


        public void settext(string Name)
        {
            try
            {
                this.Text = "FollowUp of  " + Name;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);

            }
        }
        //public void newcolumn()
        //{

        //    DataGridViewButtonColumn newRenew = new DataGridViewButtonColumn();
        //    newRenew.Name = "Renew";
        //    newRenew.Text = "Renew";
        //    newRenew.HeaderText = "Renew";
        //    newRenew.DefaultCellStyle.NullValue = "Renew";

        //    int columnIndex = 0;

        //    if (grid.Columns["Renew"] == null)
        //    {
        //        grid.Columns.Insert(columnIndex, newRenew);
        //    }


        //    if (cmbFilterBy.SelectedIndex != 0)
        //    {
        //        DataGridViewButtonColumn BtnDlt = new DataGridViewButtonColumn();
        //        BtnDlt.Name = "Delete";
        //        BtnDlt.Text = "Delete";
        //        BtnDlt.HeaderText = "Delete";
        //        BtnDlt.DefaultCellStyle.NullValue = "Delete";
        //        int column = 1;

        //        if (grid.Columns["Delete"] == null)
        //        {
        //            grid.Columns.Insert(column, BtnDlt);
        //        }
        //    }
        //}

        //private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {

        //        List<Info.StudentFacility> facility;
        //        //StudentFacility objFacility = new StudentFacility();
        //        Info.Student objStudent = new Student();
             
        //        DataGridViewRow selectedRow = grid.Rows[e.RowIndex];
        //        if (e.ColumnIndex == grid.Columns["Renew"].Index)
        //        {

        //            objStudent = BLL.StudentHandller.GetStudent(Convert.ToInt32(selectedRow.Cells[1].Value), "0", "0", 0, Program.LoggedInUser.BranchId);

        //            int studfacilityID = Convert.ToInt32(selectedRow.Cells[6].Value);
        //            //string fac = selectedRow.Cells[5].Value.ToString();
        //           foreach (StudentFacility objFacility in objStudent.Facilities)
        //            {
        //                if (objFacility.Id == studfacilityID)
        //                {
        //                    if (FrmStudentDetails.checkPackageType(objFacility))
        //                    {
        //                        objFacility.Student = new Student(objStudent.Fees, objStudent.AdmissionNo);
        //                        objFacility.Student.RollNo = objStudent.RollNo;
        //                        FrmMonthSelector frmMnthSelector = new FrmMonthSelector();
        //                        frmMnthSelector.feeStructure = objFacility;
        //                        frmMnthSelector.ShowDialog();
        //                        break;
        //                    }
        //                }
        //           }
                   
        //        }
        //        else if (e.ColumnIndex == grid.Columns["Delete"].Index)
        //        {
        //            objStudent = BLL.StudentHandller.GetStudent(Convert.ToInt32(selectedRow.Cells[2].Value), "0", "0", 0, Program.LoggedInUser.BranchId);
        //            Int32 AdmsnNo = objStudent.AdmissionNo;

        //            BLL.StudentHandller.DeactivateStudent(AdmsnNo);
                   
        //            selectedRow.DefaultCellStyle.BackColor = Color.LightGray;
        //            selectedRow.Frozen = true;
                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        //throw ex;
        //    }

        //}

        //public void onLoadRenew()
        //{
        //    try
        //    {
        //        this.Text = "Expired/Renewal";
        //        lblText.Visible = true;
        //        cmbFilterBy.Visible = true;
        //        cmbFilterBy.SelectedIndex = 1;
               
        //        //DataTable renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), cmbFilterBy.SelectedIndex);
        //        //newcolumn();
        //        //bindData(renew);
        //        this.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable renew;
        //        switch (cmbFilterBy.SelectedIndex)
        //        {
        //            case 0:
        //                renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);
        //                newcolumn();
        //                bindData(renew);
        //                break;

        //            case 1:
        //                renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1);
        //                newcolumn();
        //                bindData(renew);
        //                break;

        //            case 2:
        //                renew = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 2);
        //                //newcolumn();
        //                bindData(renew);
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WinForm.showError(ex, "Renewal/Expired", this);
        //    }
        //}
    }
}
