using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Common;
using ClassManager.Info;
using ClassManager.BLL;
using System.Reflection;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmOutstandingFees : FrmParentForm
    {
        RolePrivilege formPrevileges;

        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        const string sCaption = "Outstanding Fees";
        DataTable objAllStdOutstanding;
        DataGridViewCheckBoxColumn chkEmail = new DataGridViewCheckBoxColumn();
        Boolean sAllowIndexChange;
        DataTable dtMembers;
        string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
        DataTable filteredData;


        /// <summary>
        ///  Constructor
        /// </summary>
        public FrmOutstandingFees()
        {
            InitializeComponent();
        }

        private void FrmOutstandingFees_Load(object sender, EventArgs e)
        {
            try
            {
                if (appName == "Gym" || appName == "Dance")
                {
                    lblstrm.Text = "Package";
                    lblcrse.Text = "PackageType";
                    cmbGroup.Items.Clear();
                    cmbGroup.Items.Add("None");
                    cmbGroup.Items.Add("Members");
                    cmbGroup.Items.Add("PackageType");
                    cmbGroup.Items.Add("Package");
                    cmbGroup.Items.Add("Batch");
                    cmbGroup.Items.Add("PackageName");

                }
                UICommon.WinForm.formatDateTimePicker(dtpBeforeDate);
                SGOutstFees.RowTemplate.MinimumHeight = 25;
                SGOutstFees.RowTemplate.Height = 25;
                SGOutstFees.PageSize = 25;

                cmbViewOutstanding.SelectedIndex = 1;
                loadData(branchID, true);
                lblTotalOutstanding.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(objAllStdOutstanding.Compute("Sum([Total Outstanding])", "")));
                ApplyPrevileges();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
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
                        chkAllBranchs.Visible = false;
                    }

                    if (formPrevileges.Modify == false)
                    {

                    }

                    if (formPrevileges.Create == false)
                    {
                        btnSend.Visible = false;
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


        private void loadData(string branchId, bool formLoad = false)
        {
            try
            {
                objAllStdOutstanding = BLL.FeesHandller.getOutstandingFees(branchID, false, System.DateTime.Now);
                AssignEvents();
                RemoveSelectedEvent();


                //ADGVOutstFees.CurrentCell = null;
                sAllowIndexChange = false;

                //Add all in cmbCourseNm
                cmbCourseNm.Items.Clear();
                Info.ComboItem objAllCource = new ComboItem("%", "ALL");

                cmbCourseNm.Items.Add(objAllCource);

                //Add all in cmbCourseNm
                cmbStdNm.Items.Clear();
                Info.ComboItem objAllStd = new ComboItem("%", "ALL");

                cmbStdNm.Items.Add(objAllStd);

                //Add all in Batch
                cmbBtch.Items.Clear();
                Info.ComboItem objAllBatch = new ComboItem("%", "ALL");

                cmbBtch.Items.Add(objAllStd);

                //Add list of items
                List<Stream> lstSTream = StreamHandller.getStreams(branchID);
                foreach (Stream objStream in lstSTream)
                {
                    cmbCourseNm.Items.Add(new ComboItem(objStream.ID.ToString(), objStream.Name));
                }


                //Add Checkbox in datagridview
                DataGridViewCheckBoxColumn chkEmail = new DataGridViewCheckBoxColumn();
                chkEmail.Name = "chkEmail";
                chkEmail.HeaderText = "Send";
                chkEmail.TrueValue = true;
                chkEmail.FalseValue = false;
                chkEmail.ReadOnly = false;
                chkEmail.Selected = false;
                SGOutstFees.Columns.Insert(0, chkEmail);


                AssignSelectedEvent();
                cmbCourseNm.SelectedIndex = 0;
                cmbStdNm.SelectedIndex = 0;
                cmbBtch.SelectedIndex = 0;
                cmbGroup.SelectedIndex = 1;
                cmbViewOutstanding.SelectedIndex = 1;
                sAllowIndexChange = true;

                loadFee(branchId, true, objAllStdOutstanding.AsDataView());


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
                txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.charOnly);
                SGOutstFees.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
                SGOutstFees.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AssignSelectedEvent()
        {
            try
            {
                cmbCourseNm.SelectedIndexChanged += new System.EventHandler(this.cmbCourseNm_SelectedIndexChanged);
                cmbStdNm.SelectedIndexChanged += new System.EventHandler(this.cmbStdNm_SelectedIndexChanged);
                cmbBtch.SelectedIndexChanged += new System.EventHandler(this.cmbBtch_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoveSelectedEvent()
        {
            try
            {
                cmbCourseNm.SelectedIndexChanged -= new System.EventHandler(this.cmbCourseNm_SelectedIndexChanged);
                cmbStdNm.SelectedIndexChanged -= new System.EventHandler(this.cmbStdNm_SelectedIndexChanged);
                cmbBtch.SelectedIndexChanged -= new System.EventHandler(this.cmbBtch_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbCourseNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkSelectAll.Checked = false;
                if (sAllowIndexChange == true)
                {
                    sAllowIndexChange = false;
                    if (cmbCourseNm.SelectedIndex == 0)
                    {
                        cmbStdNm.Items.Clear();
                        cmbStdNm.Items.Add(new ComboItem("%", "ALL"));
                        cmbStdNm.SelectedIndex = 0;

                        cmbBtch.Items.Clear();
                        cmbBtch.Items.Add(new ComboItem("%", "ALL"));
                        cmbBtch.SelectedIndex = 0;
                        sAllowIndexChange = true;
                    }
                    else
                    {

                        String stream = (cmbCourseNm.SelectedItem as ComboItem).strKey;
                        List<Standard> lstStd = StandardHandller.getStandard(branchID.ToString(), stream);

                        //Add all
                        cmbStdNm.Items.Clear();
                        cmbStdNm.Items.Add(new ComboItem("%", "ALL"));

                        //Add comboItem in cmbStdNm
                        foreach (Standard objStandard in lstStd)
                        {
                            cmbStdNm.Items.Add(new ComboItem(objStandard.Standardid.ToString(), objStandard.StandardName));
                        }


                        cmbStdNm.SelectedIndex = 0;
                        cmbBtch.Items.Clear();
                        cmbBtch.Items.Add(new ComboItem("%", "ALL"));
                        cmbBtch.SelectedIndex = 0;

                        sAllowIndexChange = true;
                    }

                    loadFee(branchID, false, objAllStdOutstanding.AsDataView());
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbStdNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkSelectAll.Checked = false;
                if (sAllowIndexChange == true)
                {
                    sAllowIndexChange = false;
                    if (cmbStdNm.SelectedIndex == 0)
                    {
                        cmbBtch.Items.Clear();
                        cmbBtch.Items.Add(new ComboItem("%", "ALL"));
                        cmbBtch.SelectedIndex = 0;
                        sAllowIndexChange = true;
                    }
                    else
                    {

                        String stdID = (cmbStdNm.SelectedItem as ComboItem).strKey.ToString();
                        cmbBtch.DataSource = null;
                        //add all 
                        cmbBtch.Items.Clear();
                        cmbBtch.Items.Add(new ComboItem("%", "ALL"));
                        //Add combo item
                        List<Batch> lstBtch = StandardHandller.GetBatches(Convert.ToInt32(stdID), Program.LoggedInUser.BranchId);
                        foreach (Batch objbatch in lstBtch)
                        {
                            cmbBtch.Items.Add(new ComboItem(objbatch.id.ToString(), objbatch.Name));
                        }
                        //sAllowIndexChange = true;

                        cmbBtch.SelectedIndex = 0;
                        //GetFilterCourse();
                        //loadFee(branchID);
                        sAllowIndexChange = true;
                    }

                    loadFee(branchID, false, objAllStdOutstanding.AsDataView());

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow gvrFees in SGOutstFees.Rows)
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

        private void chkSendSMS_CheckedChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = true;
        }

        private void SGOutstFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (SGOutstFees.Columns.Contains("Name") && e.ColumnIndex == SGOutstFees.Columns["Name"].Index)
                {
                    StudentDetailsParent objStudentDetails = (StudentDetailsParent)FormFactory.GetForm(Forms.FrmStudentDetails, this, true);
                    int adminssion = Convert.ToInt32(SGOutstFees["AdmissionNo", e.RowIndex].Value);
                    objStudentDetails.loadStudent(adminssion);
                    objStudentDetails.ShowDialog();

                }

                if (e.RowIndex != -1)
                {
                    if (SGOutstFees.Columns.Contains("chkEmail") && e.ColumnIndex == SGOutstFees.Columns["chkEmail"].Index)

                    {
                        DataGridViewCheckBoxCell chckBx = (DataGridViewCheckBoxCell)SGOutstFees.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        chckBx.Value = !(Boolean)chckBx.Selected;
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private void calculate(DataView lst)
        {
            try
            {
                if (lst != null)
                {
                    DataTable dt = lst.ToTable();
                    if (dt.Rows.Count != 0)
                    {
                        lblTotalCollected.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Fees Paid])", "")));
                        lblTFees.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Total Fees])", "")));
                        lblTotalOtst.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Total Outstanding])", "")));
                        lblDisc.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Discount])", "")));
                        lblCancelled.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([CancelledAmount])", "")));
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void bgwOutstandingSMS_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Int32> objStudent = (List<Int32>)e.Argument;
            MailHandler.sendOutstandingFeesNotification(objStudent, DateTime.Now, chkSendSMS.Checked, true, Program.LoggedInUser.BranchId);
        }

        private void bgwOutstandingSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Common.Log.LogError(e.Error);
                UICommon.FormFactory.setMainFormStatus("No Internet Connection to Send SMS from " + sCaption);
            }
            else
            {
                btnSend.Enabled = true;
                UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SGOutstFees.DataSource = filteredData;
            if (SGOutstFees.Rows.Count != 0)
            {
                Common.ImportExport.ImportToExcel(SGOutstFees, null);
            }
            else
            {
                UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
        }


        private void loadFee(string branchId, bool formLoad = false, DataView newList = null, String additionalFilters = null)
        {
            try
            {
                DataTable dt = newList.ToTable();
                SGOutstFees.DataSource = null;

                if (newList == null)
                {
                    newList = new DataView(objAllStdOutstanding);
                }

                //Stream filter
                if (cmbCourseNm.SelectedIndex != 0)
                {
                    String strm = (cmbCourseNm.SelectedItem).ToString();
                    newList.RowFilter = "[STRM_NAME] = '" + strm + "'";
                }

                //Standard filter
                if (cmbStdNm.SelectedIndex != 0)
                {
                    String crse = (cmbStdNm.SelectedItem).ToString();
                    newList.RowFilter += " and [STD_NAME] = '" + crse + "'";
                }

                //Batch filter
                if (cmbBtch.SelectedIndex != 0)
                {
                    String btch = (cmbBtch.SelectedItem).ToString();
                    newList.RowFilter += " and [Batch] = '" + btch + "'";
                }

                //Outstanding filter
                if (cmbViewOutstanding.SelectedIndex == 1)
                {
                    if (newList.RowFilter != "")
                    {
                        newList.RowFilter += " and [Total Outstanding]  > 0";
                    }
                    else
                    {
                        newList.RowFilter += " [Total Outstanding]  > 0";
                    }
                }
                // date 
                if(dtpBeforeDate.Value != null)
                {
                    newList.RowFilter += "and  [STAM_ADMISSION_DATE] <= '" + dtpBeforeDate.Value.Date+"'";
                }
                //Additional Filters
                if (additionalFilters != null)
                {
                    newList.RowFilter += " and " + additionalFilters;
                }

                //Grouping
                switch (cmbGroup.SelectedIndex)
                {
                    case 0:
                        SGOutstFees.SetPagedDataSource(newList.ToTable(), bindingNavigator1);
                        filteredData = newList.ToTable();
                        break;
                    case 1:

                        filteredData = WinForm.ToDataTable(newList.ToTable().AsEnumerable()
                                              .GroupBy(r => new { AdmisionNo = r.Field<int>("AdmissionNo"), MembershipNo = r.Field<string>("MembershipNo"), Name = r.Field<string>("Name"), Contact = r.Field<string>("Contact No"), ParentNo = r.Field<string>("Parent No") })
                                              .Select(g => new
                                              {
                                                  AdmissionNo = g.Key.AdmisionNo,
                                                //   MembershipNo = r.Field<int>("MembershipNo"),
                                                MembershipNo = g.Key.MembershipNo,
                                                  Name = g.Key.Name,
                                                  ContactNo = g.Key.Contact,
                                                  ParentNo = g.Key.ParentNo,
                                                  TotalFees = g.Sum(r => r.Field<decimal>("Total Fees")),
                                                  Discount = g.Sum(r => r.Field<decimal>("Discount")),
                                                  FeesPaid = g.Sum(r => r.Field<decimal>("Fees Paid")),
                                                  TodayDue = g.Sum(r => r.Field<decimal>("Today Due")),
                                                  TotalOustanding = g.Sum(r => r.Field<decimal>("Total Outstanding")),
                                              })
                                              .ToList());
                        SGOutstFees.SetPagedDataSource(filteredData, bindingNavigator1);
                        if (dtMembers != null)
                        {
                            filteredData = dtMembers;
                        }
                        // 

                        if (appName == "Gym")
                        {
                            if (SGOutstFees.Columns.Contains("Parent No"))
                            {
                                SGOutstFees.Columns["Parent No"].Visible = false;
                            }
                        }
                        break;
                    case 2:
                        filteredData = WinForm.ToDataTable(newList.ToTable().AsEnumerable()
                                          .GroupBy(r => new { STDID = r.Field<int>("STD_ID"), Course = r.Field<string>("STD_NAME") })
                                          .Select(g => new
                                          {
                                              PackageType = g.Key.Course,
                                              TotalFees = g.Sum(r => r.Field<decimal>("Total Fees")),
                                              Discount = g.Sum(r => r.Field<decimal>("Discount")),
                                              FeesPaid = g.Sum(r => r.Field<decimal>("Fees Paid")),
                                              //  TodayDue = g.Sum(r => r.Field<decimal>("Today Due")),
                                              TotalOustanding = g.Sum(r => r.Field<decimal>("Total Outstanding")),
                                          }).ToList());
                        SGOutstFees.SetPagedDataSource(filteredData, bindingNavigator1);
                        break;
                    case 3:
                        filteredData = WinForm.ToDataTable(newList.ToTable().AsEnumerable()
                                            .GroupBy(r => new { STDID = r.Field<int>("STD_STREAM_ID"), Stream = r.Field<string>("STRM_NAME") })
                                            .Select(g => new
                                            {
                                                Package = g.Key.Stream,
                                                TotalFees = g.Sum(r => r.Field<decimal>("Total Fees")),
                                                Discount = g.Sum(r => r.Field<decimal>("Discount")),
                                                FeesPaid = g.Sum(r => r.Field<decimal>("Fees Paid")),
                                                //  TodayDue = g.Sum(r => r.Field<decimal>("Today Due")),
                                                TotalOustanding = g.Sum(r => r.Field<decimal>("Total Outstanding")),
                                            }).ToList());
                        SGOutstFees.SetPagedDataSource(filteredData, bindingNavigator1);
                        break;
                    case 4:
                        filteredData = WinForm.ToDataTable(newList.ToTable().AsEnumerable()
                                          .GroupBy(r => new { Batch = r.Field<String>("Batch") })
                                          .Select(g => new
                                          {
                                              Batch = g.Key.Batch,

                                              TotalFees = g.Sum(r => r.Field<decimal>("Total Fees")),
                                              Discount = g.Sum(r => r.Field<decimal>("Discount")),
                                              FeesPaid = g.Sum(r => r.Field<decimal>("Fees Paid")),
                                              // TodayDue = g.Sum(r => r.Field<decimal>("Today Due")),
                                              TotalOustanding = g.Sum(r => r.Field<decimal>("Total Outstanding")),
                                          }).ToList());
                        SGOutstFees.SetPagedDataSource(filteredData, bindingNavigator1);
                        break;
                    case 5:
                        filteredData = WinForm.ToDataTable(newList.ToTable().AsEnumerable()
                                          .GroupBy(r => new { FeesPackage = r.Field<String>("Package Name") })
                                          .Select(g => new
                                          {
                                              Package = g.Key.FeesPackage,
                                              TotalFees = g.Sum(r => r.Field<decimal>("Total Fees")),
                                              Discount = g.Sum(r => r.Field<decimal>("Discount")),
                                              FeesPaid = g.Sum(r => r.Field<decimal>("Fees Paid")),
                                              //TodayDue = g.Sum(r => r.Field<decimal>("Today Due")),
                                              TotalOustanding = g.Sum(r => r.Field<decimal>("Total Outstanding")),
                                          })
                                          .ToList());
                        SGOutstFees.SetPagedDataSource(filteredData, bindingNavigator1);
                        break;
                }



                if (cmbViewOutstanding.SelectedIndex == 1 || cmbViewOutstanding.SelectedIndex == 0 || cmbViewOutstanding.SelectedIndex == 2)
                {
                    calculate(newList);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void clearTotal()
        {
            try
            {
                lblTotalCollected.Text = "0";
                lblTotalOtst.Text = "0";
                lblDisc.Text = "0";
                lblTFees.Text = "0";

                lblCancelled.Text = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbBtch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == false)
                {
                    return;
                }
                loadFee(branchID, false, objAllStdOutstanding.AsDataView());
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void formatADGVOutstFeesGrid()
        {
            try
            {
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                SGOutstFees.Columns[0].ReadOnly = false;
                // SGOutstFees.Columns["Roll No"].Visible = false;


                //ADGVOutstFees.Columns[17].Visible = false;
                //if (ADGVOutstFees.Columns.Contains("Branch"))
                //{
                //    ADGVOutstFees.Columns["Branch"].Visible = false;

                if (SGOutstFees.Columns.Contains("Name"))
                {
                    SGOutstFees.Columns["Name"].DisplayIndex = 2;
                    SGOutstFees.Columns["Name"].Width = 200;
                }
                if (SGOutstFees.Columns.Contains("chkEmail"))
                {
                    SGOutstFees.Columns["chkEmail"].Visible = true;
                    SGOutstFees.Columns["chkEmail"].Width = 65;
                }
                if (appName == "Gym")
                {
                    if (SGOutstFees.Columns.Contains("Parent No"))
                    {
                        SGOutstFees.Columns["Parent No"].Visible = false;
                    }

                }
                else
                {
                    if (SGOutstFees.Columns.Contains("Parent No"))
                    {
                        SGOutstFees.Columns["Parent No"].DisplayIndex = 4;
                    }


                }

                if (SGOutstFees.Columns.Contains("STD_ID"))
                {
                    SGOutstFees.Columns["STD_ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("STD_STREAM_ID"))
                {
                    SGOutstFees.Columns["STD_STREAM_ID"].Visible = false;
                }
                if (SGOutstFees.Columns.Contains("STRM_NAME"))
                {
                    SGOutstFees.Columns["STRM_NAME"].HeaderText = "Stream";
                }
                if (SGOutstFees.Columns.Contains("STD_NAME"))
                {
                    SGOutstFees.Columns["STD_NAME"].HeaderText = "Course";
                }
                if (SGOutstFees.Columns.Contains("AdmissionNo"))
                {
                    SGOutstFees.Columns["AdmissionNo"].HeaderText = Lang.translate("AdmissionNo");
                    SGOutstFees.Columns["AdmissionNo"].Width = 50;
                    SGOutstFees.Columns["AdmissionNo"].Visible = false;

                }
                if (SGOutstFees.Columns.Contains("MembershipNo"))
                {
                    SGOutstFees.Columns["MembershipNo"].HeaderText = Lang.translate("AdmissionNo");
                    SGOutstFees.Columns["MembershipNo"].Width = 50;

                }
                if (SGOutstFees.Columns.Contains("ID"))
                {

                    SGOutstFees.Columns["ID"].Width = 50;

                }
                //It will Order Column Sequence if groub by is selected None.
                if (cmbGroup.SelectedIndex == 0)//||(cmbViewOutstanding.SelectedIndex==0||cmbViewOutstanding.SelectedIndex==1||cmbViewOutstanding.SelectedIndex==2))
                {
                    SGOutstFees.Columns["STRM_NAME"].HeaderText = "Stream";
                    SGOutstFees.Columns["STD_NAME"].HeaderText = "Course";
                    SGOutstFees.Columns["chkEmail"].Visible = true;

                    //SGOutstFees.Columns["Roll No"].Visible = false;
                    if (cmbGroup.SelectedIndex == 0 || cmbGroup.SelectedIndex == 1)
                    {
                        if (SGOutstFees.Columns.Contains("Today Due"))
                        {
                            SGOutstFees.Columns["Today Due"].Visible = true;
                            SGOutstFees.Columns["Today Due"].DisplayIndex = 10;
                        }
                        else
                        {
                            SGOutstFees.Columns["Today Due"].Visible = false;
                        }

                    }
                    if (SGOutstFees.Columns.Contains("Admission No"))
                    {
                        SGOutstFees.Columns["Admission No"].Visible = false;
                    }
                    SGOutstFees.Columns["MembershipNo"].DisplayIndex = 2;
                    SGOutstFees.Columns["Contact No"].DisplayIndex = 3;
                    SGOutstFees.Columns["Email ID"].DisplayIndex = 5;
                    SGOutstFees.Columns["Total Fees"].DisplayIndex = 6;
                    SGOutstFees.Columns["Discount"].DisplayIndex = 7;
                    SGOutstFees.Columns["Fees Paid"].DisplayIndex = 8;
                    //  SGOutstFees.Columns["Today Due"].Visible = false;
                    SGOutstFees.Columns["Total Outstanding"].DisplayIndex = 10;
                    SGOutstFees.Columns["Batch"].DisplayIndex = 11;
                    SGOutstFees.Columns["STD_NAME"].DisplayIndex = 12;
                    SGOutstFees.Columns["STRM_NAME"].DisplayIndex = 13;
                    SGOutstFees.Columns["Package Name"].DisplayIndex = 14;
                    SGOutstFees.Columns["Branch"].DisplayIndex = 15;
                }
                else if (cmbGroup.SelectedIndex == 1)
                {
                    SGOutstFees.Columns["chkEmail"].Visible = true;
                    if (SGOutstFees.Columns.Contains("Today Due"))
                    {
                        SGOutstFees.Columns["Today Due"].Visible = false;
                    }
                    //  SGOutstFees.Columns["Roll No"].Visible = false;
                }
                if (cmbGroup.SelectedIndex == 2 || cmbGroup.SelectedIndex == 3 || cmbGroup.SelectedIndex == 4 || cmbGroup.SelectedIndex == 5)
                {
                    SGOutstFees.Columns["chkEmail"].Visible = false;

                }
                if (cmbGroup.SelectedIndex == 1)
                {
                    if (cmbViewOutstanding.SelectedIndex == 0 || cmbViewOutstanding.SelectedIndex == 1 || cmbViewOutstanding.SelectedIndex == 2)
                    {
                        // SGOutstFees.Columns["STRM_NAME"].HeaderText = "Package";
                        // SGOutstFees.Columns["STD_NAME"].HeaderText = "PackageType";
                    }
                }
                for (int i = 1; i < SGOutstFees.Columns.Count; i++)
                {
                    SGOutstFees.Columns[i].ReadOnly = true;
                }

                // if(cmbGroup.SelectedIndex == 1 )  
                // {
                //     SGOutstFees.Columns["Roll No"].Visible = false;
                // }
                // if(cmbViewOutstanding.SelectedIndex == 0)
                // {
                //     SGOutstFees.Columns["Roll No"].Visible = false;
                // }
                //if(cmbViewOutstanding.SelectedIndex == 1)
                // {
                //     SGOutstFees.Columns["Roll No"].Visible = false;
                // }
                if (cmbViewOutstanding.SelectedIndex == 2)
                {
                    //SGOutstFees.Columns["STRM_NAME"].HeaderText = "Package";
                    // SGOutstFees.Columns["STD_NAME"].HeaderText = "PackageType";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void SGOutstFees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVOutstFeesGrid();

                SGOutstFees.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                List<Int32> lstAdmsnNo = new List<Int32>();
                DataTable dtOutstanding = new DataTable();

                if (chkSelectAll.Checked)
                {
                    foreach (DataGridViewRow gvrFees in SGOutstFees.Rows)
                    {
                        lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[1].Value));
                    }
                }
                else
                {
                    foreach (DataGridViewRow gvrFees in SGOutstFees.Rows)
                    {
                        if (gvrFees.Cells[0].Value != null && (Boolean)gvrFees.Cells[0].Value == true)
                        {
                            lstAdmsnNo.Add(Convert.ToInt32(gvrFees.Cells[1].Value));

                        }
                    }
                }
                lstAdmsnNo = lstAdmsnNo.Select(admissionNos => admissionNos).Distinct().ToList();

                if (lstAdmsnNo.Count != 0)
                {
                    btnSend.Enabled = true;
                    bgwOutstandingSMS.RunWorkerAsync(lstAdmsnNo);
                }
                else
                {
                    UICommon.WinForm.showStatus("No Student Selected to send SMS", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this.MdiParent);
                }
            }

            catch (Exception ex)
            {
                if (ex.Message.Equals("The remote name could not be resolved: 'trans.accunityservices.com'"))
                {
                    UICommon.WinForm.showStatus("No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
                else
                {
                    UICommon.WinForm.showError(ex, "Oops something went wrong, Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                }

            }
        }

        private void dtpBeforeDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                string StreamId = (cmbCourseNm.SelectedItem as Info.ComboItem).strKey;
                string CourseId = (cmbStdNm.SelectedItem as Info.ComboItem).strKey;
                string BatchId = (cmbBtch.SelectedItem as Info.ComboItem).strKey;
                DateTime date = dtpBeforeDate.Value;
                objAllStdOutstanding = BLL.FeesHandller.getOutstandingFees(branchID, false, date, StreamId, CourseId, BatchId);
                loadFee(branchID, false, objAllStdOutstanding.AsDataView());
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadFee(branchID, false, objAllStdOutstanding.AsDataView(), string.Format("Name LIKE '%{0}%'", txtFName.Text));
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void cmbViewOutstanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                    loadFee(branchID, false, objAllStdOutstanding.AsDataView());
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                    loadFee(branchID, false, objAllStdOutstanding.AsDataView());
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void SGOutstFees_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(SGOutstFees, e);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void chkAllBranchs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllBranchs.Checked)
                {
                    branchID = "%";
                }
                else
                {
                    branchID = Program.LoggedInUser.BranchId.ToString();
                }

                objAllStdOutstanding = BLL.FeesHandller.getOutstandingFees(branchID, false);
                loadFee(branchID, false, objAllStdOutstanding.AsDataView());
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                PdfParameters getParameter = new PdfParameters();
                getParameter.name = "Name:- " + txtFName.Text.ToString();
                getParameter.Stream = "Stream:- " + cmbStdNm.SelectedItem.ToString();
                getParameter.Course = "Course:- " + cmbCourseNm.SelectedItem.ToString();
                getParameter.Package = "Batch:- " + cmbBtch.SelectedItem.ToString();
                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtpBeforeDate.Value);
                getParameter.att_View = "View:- " + cmbViewOutstanding.SelectedItem.ToString();
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Outstanding Report";
                getParameter.count = "Total Outstanding:-" + lblTotalOtst.Text;
                //  getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                getParameter.GroupBy = "GroupBy:- " + cmbGroup.SelectedItem.ToString();
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (SGOutstFees.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Outstanding Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(SGOutstFees, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void dtpBeforeDate_ValueChanged(object sender, EventArgs e)
        {
            string date = dtpBeforeDate.Text;
            loadFee(branchID, false, objAllStdOutstanding.AsDataView());
        }
    }
}
