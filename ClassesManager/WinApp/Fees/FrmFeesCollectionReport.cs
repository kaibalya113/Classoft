using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.Common;
using ClassManager.Info;
using ClassManager.BLL;

namespace ClassManager.WinApp
{
    public partial class FrmFeesCollectionReport : FrmParentForm
    {
        Info.RolePrivilege formPrevileges;
        bool allowIndexChange = false;
        bool considerOnlyDate = false;
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        List<Info.FeesCollRpt> lstFeesColl;
        Boolean sAllowIndexChange;
        Boolean allowFees;
        DataTable dtFees;
        DataTable dtFeesCollections;
        string sCaption = "Fees Collection Report";

        public FrmFeesCollectionReport()
        {
            InitializeComponent();
        }

        public void FeesCollectionReport_Load(object sender, EventArgs e)
        {
            populateStream();
            try
            {
                ADGVFeesReport.ReadOnly = true;
                Formatdate();

                sAllowIndexChange = false;

                sAllowIndexChange = true;
                allowFees = true;

                //if (comStream.SelectedIndex == -1)
                //{
                //    comStream.Items.Clear();
                //    populateStream();
                //    comCourse.Items.Clear();
                //}


                dtFees = WinForm.ToDataTable(FeesHandller.getFeesCollectionReport(branchID.ToString(), dtpFromDate.Value, dtpToDate.Value));

                ADGVFeesReport.DataSource = dtFees;
                AssignEvents();
                calculateProfLoss(dtFees);
                WinForm.AssignFilterEvent(ADGVFeesReport);

                //  comStream.Items.Add(new ComboItem("0", "All"));
                cmbType.SelectedIndex = 0;

                sAllowIndexChange = true;
                ApplyPrevileges();

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }
        private void AssignEvents()
        {


            ADGVFeesReport.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVFeesReport.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);

            calculateProfLoss();

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
                        chkBranchID.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {

                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private void Formatdate()
        {
            try
            {

                UICommon.WinForm.formatDateTimePicker(dtpFromDate);
                UICommon.WinForm.formatDateTimePicker(dtpToDate);
                UICommon.WinForm.setDate(dtpFromDate, dtpToDate);
            }
            catch (Exception ex)
            {

                //  throw ex;
            }

        }

        private void calculateProfLoss(DataTable dt = null)
        {
            try
            {
                DataTable uniqueTransactions = ADGVFeesReport.DataSource as DataTable;



                Decimal cash = uniqueTransactions.AsEnumerable()
                    .Where(y => y.Field<String>("Mode") == "CASH")
                    .Sum(x => x.Field<decimal>("FeesPaid"));

                LblCashAmnt.Text = Common.Formatter.FormatCurrency(cash);

                Decimal other = uniqueTransactions.AsEnumerable()
                    .Where(y => y.Field<String>("Mode") != "CASH")
                    .Sum(x => x.Field<decimal>("FeesPaid"));

                lblChq.Text = Common.Formatter.FormatCurrency(other);

                Decimal total = uniqueTransactions.AsEnumerable()
                    .Sum(x => x.Field<decimal>("FeesPaid"));

                lblTotalAmount.Text = Common.Formatter.FormatCurrency(total);

            }
            catch (Exception ex)
            {
                //  throw ex;
            }
        }


        public void chkBranchID_CheckedChanged(object sender, EventArgs e)
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

                DataTable dtFees = WinForm.ToDataTable(FeesHandller.getFeesCollectionReport(branchID, dtpFromDate.Value, dtpToDate.Value));

                calculateProfLoss(dtFees);
                ADGVFeesReport.DataSource = dtFees;
            }
            catch (Exception ex)
            {
                //  UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        public void ADGVFeesReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {


                //Hiding Columns
                ADGVFeesReport.Columns["Year"].Visible = false;
                ADGVFeesReport.Columns["Month"].Visible = false;
                ADGVFeesReport.Columns["Day"].Visible = false;
                ADGVFeesReport.Columns["Stream"].Visible = false;
                ADGVFeesReport.Columns["Standard"].Visible = false;
                ADGVFeesReport.Columns["Batch"].Visible = false;
                ADGVFeesReport.Columns["BranchId"].Visible = false;
                ADGVFeesReport.Columns["BranchName"].Visible = false;
                ADGVFeesReport.Columns["BranchIdStr"].Visible = false;
                //ADGVFeesReport.Columns["AdmissionNo"].Visible = false;
                ADGVFeesReport.Columns["RollNo"].Visible = false;
                ADGVFeesReport.Columns["TransactionAmt"].Visible = false;
                ADGVFeesReport.Columns["CashAmount"].Visible = false;
                ADGVFeesReport.Columns["OtherAmount"].Visible = false;
                ADGVFeesReport.Columns["ISRENEW"].Visible = false;


                //Formatting Date
                ADGVFeesReport.Columns["PaymentDate"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                formatFeesGrid();

                foreach (DataGridViewRow adrow in ADGVFeesReport.Rows)
                {
                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;
                }

                ADGVFeesReport.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                // throw ex;
            }
        }



        public void ADGVFeesReport_FilterStringChanged(object sender, EventArgs e)
        {

        }

        private void dtpdate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                filterData();

                //LoadData();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void ADGVFeesReport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVFeesReport, e);
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            try
            {

                //   LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadData()
        {
            try
            {
                ADGVFeesReport.DataSource = null;

                string Fromdate = dtpFromDate.Value.ToShortDateString();
                string Todate = dtpToDate.Value.ToShortDateString();
                DataTable dtFeesCollection = WinForm.ToDataTable(FeesHandller.getFeesCollectionReport(branchID, Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate)));
                ADGVFeesReport.DataSource = dtFeesCollection;
                calculateProfLoss(dtFeesCollection);

            }
            catch (Exception ex)
            {
                //  UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void ADGVFeesReport_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (ADGVFeesReport.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVFeesReport, null);
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



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filterData();

            populateCourse((comStream.SelectedItem as ComboItem).strKey);

            if (comCourse.Items.Count > 0)
            {
                comCourse.SelectedIndex = 0;
            }
            comPackage.Items.Clear();
            comPackage.Items.Add(new ComboItem("0", "All"));

            comPackage.SelectedItem = comPackage.Items[0];



            //  filterData();


        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterData();
        }




        private void ADGVFeesReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblCashAmnt_Click(object sender, EventArgs e)
        {

        }

        private void alldemo(int streamId = -1)
        {
            if (streamId == -1)
            {
                comStream.Items.Add(new ComboItem("0", "All"));

                // comboBox2.Items.Clear();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                populatePackage(Convert.ToInt32((comCourse.SelectedItem as ComboItem).strKey));

                if (comPackage.Items.Count > 0)
                {
                    comPackage.SelectedIndex = 0;

                }

                //  filterData();

            }

            catch (Exception ex)
            {

                //   UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        public void formatFeesGrid()
        {
            try
            {//adding columns in fees    ADGVFeesReport griedview

                ADGVFeesReport.Columns["AdmissionNo"].HeaderText = "ID";
                ADGVFeesReport.Columns["Name"].HeaderText = "Name";
                ADGVFeesReport.Columns["FeesPaid"].HeaderText = "Amount";
                ADGVFeesReport.Columns["ReceiptNo"].HeaderText = "Receipt No";
                ADGVFeesReport.Columns["PaymentDate"].HeaderText = "Date";
                ADGVFeesReport.Columns["Mode"].HeaderText = "Mode";

                //
                string AppType = SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                if (AppType.Equals("") || AppType.Equals("Asset"))
                {
                    ADGVFeesReport.Columns["StreamName"].HeaderText = "Stream";
                    ADGVFeesReport.Columns["CourseName"].HeaderText = "Standard";
                    ADGVFeesReport.Columns["PackageName"].HeaderText = "Package";
                }
                else
                {
                    ADGVFeesReport.Columns["StreamName"].HeaderText = "Activity";
                    ADGVFeesReport.Columns["CourseName"].HeaderText = "PackageType";
                    ADGVFeesReport.Columns["PackageName"].HeaderText = "PackageName";
                }

                ADGVFeesReport.Columns["AdmissionNo"].DisplayIndex = 1;
                ADGVFeesReport.Columns["Name"].DisplayIndex = 2;
                ADGVFeesReport.Columns["FeesPaid"].DisplayIndex = 3;
                ADGVFeesReport.Columns["ReceiptNo"].DisplayIndex = 4;
                ADGVFeesReport.Columns["PaymentDate"].DisplayIndex = 5;
                ADGVFeesReport.Columns["Mode"].DisplayIndex = 6;
                ADGVFeesReport.Columns["StreamName"].DisplayIndex = 7;
                ADGVFeesReport.Columns["CourseName"].DisplayIndex = 8;
                ADGVFeesReport.Columns["PackageName"].DisplayIndex = 9;
                ADGVFeesReport.Columns["AdmissionNo"].Width = 60;
                ADGVFeesReport.Columns["Name"].Width = 150;
                ADGVFeesReport.Columns["FeesPaid"].Width = 95;
                ADGVFeesReport.Columns["ReceiptNo"].Width = 150;
                ADGVFeesReport.Columns["PaymentDate"].Width = 100;
                ADGVFeesReport.Columns["Mode"].Width = 80;
                ADGVFeesReport.Columns["StreamName"].Width = 115;
                ADGVFeesReport.Columns["CourseName"].Width = 150;
                ADGVFeesReport.Columns["PackageName"].Width = 150;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void filterData()
        {
            try
            {
                ADGVFeesReport.DataSource = null;


                // DataTable dtFeesCollection = WinForm.ToDataTable(FeesHandller.getFeesCollectionReport(branchID, Convert.ToDateTime(Fromdate), Convert.ToDateTime(Todate)));
                //ADGVFeesReport.DataSource = dtFeesCollection;
                // calculateProfLoss(dtFeesCollection);
                //LoadData();
                String selectedStream = comStream.SelectedItem.ToString();
                String selectedcourse = comCourse.SelectedItem.ToString();

                String selectedPackage = comPackage.SelectedItem.ToString();
                string Fromdate = dtpFromDate.Value.ToShortDateString();
                string Todate = dtpToDate.Value.ToShortDateString();
                string student = "";
                try
                {
                    student = cmbType.SelectedItem.ToString();
                    if (student.ToLower().Equals("renewed"))
                    {
                        student = "True";
                    }
                    else if (student.ToLower().Equals("new"))
                    {
                        student = "False";
                    }
                    else
                    {
                        student = "";
                    }

                } catch(Exception ex)
                {

                }
                
               // if(student.Contains)
                DataTable dtFeesCollections = WinForm.ToDataTable(FeesHandller.getFeesCollectionReport(branchID.ToString(), dtpFromDate.Value, dtpToDate.Value));
                BindingSource bs = new BindingSource();
                bs.DataSource = dtFeesCollections;
                calculateProfLoss(dtFeesCollections);

                if (comStream.SelectedIndex == 0)
                {
                   // comboBox1.Visible = true;
                   // label6.Visible = true;
                    if (student != "" && student != null)
                    {
                        bool myBool = bool.Parse(student);

                        bs.Filter = " ISRENEW = '" + myBool + "'";
                        //  calculateProfLoss(dtFeesCollections);


                        ADGVFeesReport.DataSource = (bs.List as DataView).ToTable();
                        calculateProfLoss();
                    }
                    else
                    {
                        ADGVFeesReport.DataSource = dtFeesCollections;
                        calculateProfLoss(dtFeesCollections);
                    }
                        

                }
                 else
                {
                    try { 
                    if (student != "" && student != null)
                    {
                        bool myBool = bool.Parse(student);
                        //  bs.Filter = " StreamName = '" + selectedStream + "'";
                        bs.Filter = " StreamName = '" + selectedStream + "'and ISRENEW = '" + myBool + "'";
                    }else
                    {
                        bs.Filter = " StreamName = '" + selectedStream + "'";
                    }
                    }catch(Exception ex)
                    {

                    }


                  //  comboBox1.Visible = false;
                   // label6.Visible = false;
                    // calculateProfLoss(dtFeesCollections);
                    if (comCourse.SelectedIndex != 0)
                    {
                        bs.Filter = "CourseName = '" + selectedcourse + "'";
                        //calculateProfLoss(dtFeesCollections);
                        if (comPackage.SelectedIndex != 0)
                        {
                            bs.Filter = " PackageName= '" + selectedPackage + "'";
                            //  calculateProfLoss(dtFeesCollections);
                        }

                    }
                    

                    ADGVFeesReport.DataSource = (bs.List as DataView).ToTable();
                    calculateProfLoss();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ComStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpToDate.Value > dtpFromDate.Value)
            {



            }
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                dtpFromDate.Value = dtpToDate.Value;
            }

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value < dtpToDate.Value)
            {

            }
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                dtpFromDate.Value = dtpToDate.Value;

            }
        }
        private void populateStream()
        {
            try
            {
                //   alldemo();

                List<Stream> lstStream = StreamHandller.getStreams(branchID);

                //Add items in cmbStream
               // comboBox1.Items.Add(new ComboItem("0", "All"));

                comStream.Items.Add(new ComboItem("0", "All"));
                comStream.SelectedItem = comStream.Items[0];
                foreach (Stream objStream in lstStream)
                {
                    comStream.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }
                //comStream.Items.Add(new ComboItem("0", "All"));
                //comCourse.Items.Add(new ComboItem("0", "All"));
                //comPackage.Items.Add(new ComboItem("0", "All"));

                //comCourse.SelectedItem = comCourse.Items[0];
                //comPackage.SelectedItem = comPackage.Items[0];


            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void populatePackage(int standardId)
        {
            try
            {

                if (comCourse.Items.Count > 0)
                {
                    comPackage.Items.Clear();
                    List<FeesPackage> lstPackages = FeesPackageHandller.getStandardPackages(standardId, Convert.ToInt32(branchID));
                    comPackage.Items.Add("All");
                    comPackage.SelectedItem = comPackage.Items[0];
                    foreach (FeesPackage objFeesPackage in lstPackages)
                    {
                        comPackage.Items.Add(new ComboItem(objFeesPackage.Id.ToString(), objFeesPackage.PackageName));
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }


        }


        private void populateCourse(string stream = "%")
        {
            try
            {

                if (comStream.Items.Count > 0)
                {
                    comCourse.Items.Clear();
                    List<Standard> lstStd = StandardHandller.getStandard(branchID.ToString(), stream);
                    comCourse.Items.Add("All");
                    comCourse.SelectedItem = comCourse.Items[0];


                    foreach (Standard objStandard in lstStd)
                    {
                        comCourse.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }


        }
        private void comPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterData();
        }

        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
            filterData();
        }
        //added by ashvini 4-12-17
        //these event  is used to export gridview data into pdf 
        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {    //added by ashvini 4-12-17
                 //these parameters are used to get values for parameters 

                PdfParameters getParameter = new PdfParameters();
                getParameter.Course = "Course:- " + comCourse.SelectedItem.ToString();
                getParameter.Package = "Package:- " + comPackage.SelectedItem.ToString();
                getParameter.Stream = "Stream:- " + comStream.SelectedItem.ToString();
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpFromDate.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtpToDate.Value);
                getParameter.count = "Total Collection:-" + lblTotalAmount.Text;
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "fees collection Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ADGVFeesReport.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Fees Collection Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(ADGVFeesReport, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

       
        //end by ashvini
    }
}
