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
using System.Configuration;
using System.Text.RegularExpressions;
using ClassManager.Info.Reporting;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using System.Collections;
using ClassManager.WinApp.Reports;
using ClassManager.WinApp.UICommon;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace ClassManager.WinApp
{
    public partial class FrmDashBoard : FrmParentForm
    {
        string sCaption = "DashBoard";
        string branchID = Program.LoggedInUser.BranchId.ToString();
        string ISReg = "%";
        string IsActive = "%";
        string[] name = {"Gym"};
        string appname = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
        Info.Student objstudent;
       public List<Info.StudentMaster> lstBiometricId = new List<Info.StudentMaster>();
        public FrmDashBoard()
        {
            InitializeComponent();


        }



        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            try
           {
                if(appname == "Gym" || appname == "Dance")
                {
                    pnlFollowup.Visible = false;
                    lnkTotal.Text = "Total Members";
                    lnkAttdReport.Text = "Present Members";
                    btnSearch.Text = "View Members";
                }
                else
                {
                    pnlFollowup.Visible = true;
                    lnkTotal.Text = "Total Students";
                    lnkAttdReport.Text = "Present Students";
                    btnSearch.Text = "View Students";
                }
                lblClassName.Text = SysParam.getValue<string>(SysParam.Parameters.NAME);
             
                List<ComboItem> lstStudentDetails = new List<ComboItem>();
                lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(branchID));
                studSearch.DataSource = new List<Student>();
                studSearch.DisplayMember = "name";
                studSearch.DataSource = lstStudentDetails;
                studSearch.SelectedIndex = -1;
                studSearch.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);
               
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(this.btnMrkAttd, "Mark Attendance");
                getOutstandingFees();
                loadBarChart();
                LoadChartOutstanding();
                LoadChartExpense();
                LoadchartEnqStatusCount();
                LoadcoursewiseEnquiry();
                LoadExpirePackageMembers();
                LoadToBeExpirePackageMembers();
                getExpiredTotal();
                getTodayFollowup();
                //LoadFollowupChart();
                getcount();
                getAttendence();
                LoadAttdCount();

                // pbLogo.Image = new Bitmap(new Bitmap(SysParam.getValue<string>(SysParam.Parameters.LOGO_PATH)), new Size(100, 100));
                txtBioMetricId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void getcount()
        {
            try
            {
                DataTable dtStudent = BLL.StudentHandller.getAllStudents(Convert.ToString(branchID));
                DataView students = dtStudent.AsDataView();
                students.RowFilter = "([STMT_DEACTIVATED] IN ('NO','YES'))";
                lblTotal.Text = (from DataRow dRow in students.ToTable().Rows
                                 select dRow["STMT_ADMISSION_NO"]).Distinct().Count().ToString();
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void getAttendence()
        {
            try
            {
                DataTable toStoreDataGlobally = BLL.AttendanceHandler.getAttendanceStatus("-1", "-1", "-1", DateTime.Now, DateTime.Now, Program.LoggedInUser.BranchId.ToString(), "%", "S", 0);
                lblPresent.Text = (toStoreDataGlobally).Compute("Count(ATTD_ADMISSION_NO)", "ATTD_STATUS='P'").ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void getOutstandingFees()
        {
            try
            {
                DataTable objOutstanding = BLL.FeesHandller.getOutstandingFees(branchID, true ,System.DateTime.Now);
                DataSet dsOutstanding = new DataSet();
                dsOutstanding.Tables.Add(objOutstanding);
                DataView newList = new DataView(objOutstanding);
                newList.RowFilter = "[Total Outstanding]  > 0";
                DataTable dt = newList.ToTable();
                if (dt.Rows.Count > 0)
                {
                    lblOutstndFees.Text = Common.Formatter.FormatCurrency(Convert.ToDecimal(dt.Compute("Sum([Total Outstanding])", ""))).ToString();
                }
                else
                {
                    lblOutstndFees.Text = ("Rs.0.00");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void getTodayFollowup()
        {
            try
            {
                DataTable dtFollowup = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), BLL.DBHandller.getMaxSQLDate());
                DataView Followup = dtFollowup.AsDataView();
                Followup.RowFilter = " FollowupDate  = #" +  Common.Formatter.FormatDate( DateTime.Now) + "#";
                lblFollowup.Text = (from DataRow dRow in Followup.ToTable().Rows
                                    select dRow["ENQ_ID"]).Distinct().Count().ToString();


              //  Followup.RowFilter = " FollowupDate <= #" + DateTime.Now.ToShortDateString() + "#";
               // lblMisedFolup.Text = (from DataRow dRow in Followup.ToTable().Rows
                                  //  select dRow["ENQ_ID"]).Distinct().Count().ToString();



                Followup.RowFilter = "([ENQ_STATUS] <> 'Not Interested') and FollowupDate < #" + Common.Formatter.FormatDate(DateTime.Now) + "#";
                lblMisedFolup.Text = (from DataRow dRow in Followup.ToTable().Rows
                                    select dRow["ENQ_ID"]).Distinct().Count().ToString();


                DataTable dt = FollowupHandler.getFolloups(branchID, System.DateTime.MinValue, System.DateTime.Now);
                DataView TodayFollowup = dt.AsDataView();
                lstFollowup.View = View.Details;
                lstFollowup.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lstFollowup.Items.Clear();
                foreach (DataRow row in TodayFollowup.ToTable().Rows)
                {
                    ListViewItem lvi = new ListViewItem(row[1].ToString());
                    lvi.SubItems.Add(row[2].ToString());
                    lvi.SubItems.Add(row[3].ToString());
                    lvi.SubItems.Add(row[5].ToString());
                    lvi.SubItems.Add(row[4].ToString());

                    lstFollowup.Items.Add(lvi);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void loadBarChart()
        {
            try
            {

                DataTable dtcrse = StreamHandller.getStandardCount(branchID,IsActive);
                Title yourTitle = new Title();
                chartcourse.Titles.Clear();
                chartcourse.Series.Clear();
                chartcourse.Palette = ChartColorPalette.BrightPastel;
                chartcourse.BackColor = Color.White;
                if (appname == "Gym" || appname == "Dance")
                {
                    yourTitle = new Title("Total Members", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                }
                else
                {
                    yourTitle = new Title("Total Students", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                }
               chartcourse.Titles.Add(yourTitle);
                chartcourse.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartcourse.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtcrse.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow plotting in dtcrse.Select("Column1 = ' " + dr.ItemArray[1].ToString() + "' and STD_NAME = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chartcourse.Invalidate();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void LoadFollowupChart()
        {
            try
            {
                DataTable dtfollowup = FollowupHandler.getFolloups(branchID, BLL.DBHandller.getMinSQLDate(), BLL.DBHandller.getMaxSQLDate());
                DataView dtView = dtfollowup.AsDataView();
                string All= (from DataRow dRow in dtView.ToTable().Rows
                               select dRow["ENQ_ID"]).Distinct().Count().ToString();


                //Pending Followup
                dtView.RowFilter = " FollowupDate <= #" + Common.Formatter.FormatDate(DateTime.Now) + "#";
                string Pending = (from DataRow dRow in dtView.ToTable().Rows
                                    select dRow["ENQ_ID"]).Distinct().Count().ToString();

                //Todays Followups
                dtView.RowFilter = " FollowupDate  = #" + Common.Formatter.FormatDate(DateTime.Now) + "#";
               string Today   =  (from DataRow dRow in dtView.ToTable().Rows
                                 select dRow["ENQ_ID"]).Distinct().Count().ToString();

                

                Title yourTitle = new Title();
                chrtFollowup.Titles.Clear();
                chrtFollowup.Series.Clear();
                chrtFollowup.Palette = ChartColorPalette.BrightPastel;
                chrtFollowup.BackColor = Color.White;
                yourTitle = new Title("Total FollowUp", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                chrtFollowup.Titles.Add(yourTitle);
                chrtFollowup.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chrtFollowup.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtfollowup.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow plotting in dtfollowup.Select("Column1 = ' " + dr.ItemArray[1].ToString() + "' and STD_NAME = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chrtFollowup.Invalidate();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        private void LoadAttdCount()
        {
            try
            {

                DataTable dtAttd = AttendanceHandler.getAttdCount(branchID);
                Title yourTitle = new Title();
                chrtattendacne.Titles.Clear();
                chrtattendacne.Series.Clear();
                chrtattendacne.Palette = ChartColorPalette.BrightPastel;
                chrtattendacne.BackColor = Color.White;
                if (appname == "Gym" || appname == "Dance")
                {
                    yourTitle = new Title("Total Present Members", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                }
                else
                {
                    yourTitle = new Title("Total Present Students", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                }
               
                chrtattendacne.Titles.Add(yourTitle);
                chrtattendacne.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chrtattendacne.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtAttd.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow plotting in dtAttd.Select("Count = ' " + dr.ItemArray[1].ToString() + "' and Name = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chrtattendacne.Invalidate();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LoadExpirePackageMembers()
        {
            try
            {
                DataTable dtExpired = StudentHandller.GetExpiredPackageCount(branchID, 0);
                Title Expiry = new Title();
                chartExpire.Titles.Clear();
                chartExpire.Series.Clear();
                chartExpire.Palette = ChartColorPalette.BrightPastel;
                chartExpire.BackColor = Color.White;
                Expiry = new Title("Expired Package Members", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                chartExpire.Titles.Add(Expiry);
                chartExpire.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartExpire.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtExpired.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow plotting in dtExpired.Select("TOTAL = ' " + dr.ItemArray[1].ToString() + "' and NAME = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chartExpire.Invalidate();
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void LoadToBeExpirePackageMembers()
        {
            try
            {
                DataTable dtExpired = StudentHandller.GetExpiredPackageCount(branchID, 1);
                Title Title = new Title();
                chartTobeExpire.Titles.Clear();
                chartTobeExpire.Series.Clear();
                chartTobeExpire.Palette = ChartColorPalette.BrightPastel;
                chartTobeExpire.BackColor = Color.White;
                Title = new Title("To Be Expired Package Members", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                chartTobeExpire.Titles.Add(Title);
                chartTobeExpire.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartTobeExpire.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtExpired.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow plotting in dtExpired.Select("TOTAL = ' " + dr.ItemArray[1].ToString() + "' and MONTH = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chartTobeExpire.Invalidate();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadChartOutstanding()
        {
            try
            {

                DataTable dtOutFees = FeesHandller.CourseWiseOutstanding(branchID);
               Title Outstnding = new Title();
                chartOutstanding.Titles.Clear();
                chartOutstanding.Series.Clear();
                chartOutstanding.Palette = ChartColorPalette.BrightPastel;
                chartOutstanding.BackColor = Color.White;
                if (appname == "")
                {
                    Outstnding = new Title("Coursewise Outstanding", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                }
                else
                {
                    Outstnding = new Title("Packagewise Outstanding", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                }
                chartOutstanding.Titles.Add(Outstnding);
                chartOutstanding.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartOutstanding.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtOutFees.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow drOut in dtOutFees.Select("[Total Outstanding] = ' " + dr.ItemArray[1].ToString() + "' and STD_NAME = '" + dr.ItemArray[0] + "'"))
                    {
                       
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString() + " ("+ dr.ItemArray[1].ToString()+")";
                        i++;
                        
                    }
                }
                chartOutstanding.Invalidate();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LoadChartExpense()
        {
            try
            {
                DataTable dtExpense = ExpenseHandler.getCategoryWiseCollection(true, branchID);
                Title titleExpense = new Title();
                chartExpense.Titles.Clear();
                chartExpense.Series.Clear();
                chartExpense.Palette = ChartColorPalette.BrightPastel;
                chartExpense.BackColor = Color.White;
                titleExpense = new Title("CategoryWise Expenses", Docking.Top, new Font("Verdana", 12,FontStyle.Bold), Color.Black);
                chartExpense.Titles.Add(titleExpense);
                chartExpense.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartExpense.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtExpense.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow drOut in dtExpense.Select("[Total] = ' " + dr.ItemArray[1].ToString() + "' and [Expense] = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString() + "(" + dr.ItemArray[1].ToString()+")";
                       // series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chartExpense.Invalidate();
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void LoadchartEnqStatusCount()
        {
            try
            {
                DataTable dtEnq = EnquiryHandller.GetEnquiryStatusCount(branchID);
                Title titleEnquire = new Title();
                chartEnquiryStatus.Titles.Clear();
                chartEnquiryStatus.Series.Clear();
                chartEnquiryStatus.Palette = ChartColorPalette.BrightPastel;
                chartEnquiryStatus.BackColor = Color.White;
                titleEnquire = new Title("PriorityWise Enquiry Count", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                chartEnquiryStatus.Titles.Add(titleEnquire);
                chartEnquiryStatus.ChartAreas[0].BackColor = Color.Transparent;
                Color[] myPieColors = { Color.Red,Color.Yellow, Color.Green};
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartEnquiryStatus.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtEnq.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow drOut in dtEnq.Select("[Count] = ' " + dr.ItemArray[1].ToString() + "' and [Status] = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chartEnquiryStatus.Invalidate();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadcoursewiseEnquiry()
        {
            try
            {
               
                DataTable dtEnq = EnquiryHandller.CourseWiseEnquiry(branchID,ISReg);
                Title titleExpense = new Title();
                chartCourseWise.Titles.Clear();
                chartCourseWise.Series.Clear();
                chartCourseWise.Palette = ChartColorPalette.BrightPastel;
                chartCourseWise.BackColor = Color.White;
                titleExpense = new Title("CourseWise Enquiry Count", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
                chartCourseWise.Titles.Add(titleExpense);
                chartCourseWise.ChartAreas[0].BackColor = Color.Transparent;
                Color[] myPieColors = { Color.Red, Color.Yellow, Color.Green };
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                chartCourseWise.Series.Add(series1);

                int i = 0;
                foreach (DataRow dr in dtEnq.Rows)
                {
                    series1.Points.Add(Convert.ToDouble(dr.ItemArray[1].ToString()));

                    foreach (DataRow drOut in dtEnq.Select("[Count] = ' " + dr.ItemArray[1].ToString() + "' and STD_NAME = '" + dr.ItemArray[0] + "'"))
                    {
                        series1.Points[i].AxisLabel = dr.ItemArray[1].ToString();
                        series1.Points[i].LegendText = dr.ItemArray[0].ToString();
                        i++;
                    }
                }
                chartCourseWise.Invalidate();
                //pnlCoursewiseEnq.Controls.Add(chartCourseWise);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void getExpiredTotal()
        {
            try
            {
                DataTable expired = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);
                DataView dataView = expired.AsDataView();
                //lblExpiredMembers.Text = (from DataRow dRow in dataView.ToTable().Rows
                //                          select dRow["AdmissionNo"]).Count().ToString();


                DataTable TobeExp = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1);
                DataView dtTobeExp = TobeExp.AsDataView();
              //  lblToBeExpire.Text = (from DataRow dRow in dtTobeExp.ToTable().Rows
                                   //   select dRow["AdmissionNo"]).Count().ToString();

                lstExpireStudent.View = View.Details;
               // lstExpireStudent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lstExpireStudent.Items.Clear();
                foreach (DataRow row in dataView.ToTable().Rows)
                {
                    ListViewItem lvi = new ListViewItem(row[1].ToString());
                    lvi.SubItems.Add(row[2].ToString());
                    lvi.SubItems.Add(row[3].ToString());
                    lvi.SubItems.Add(row[4].ToString());
                    lvi.SubItems.Add(row[6].ToString());

                    lstExpireStudent.Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void pbLogo_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            try
            {
                if (appname == "Gym" || appname == "Dance")
                {
                    //WinApp.Gym.FrmEnquiryEntryForm objpopup = (WinApp.Gym.FrmEnquiryEntryForm)UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm, null,true, name, null);
                    //objpopup.Visible = true;
                    UICommon.FormFactory.GetForm(UICommon.Forms.FrmEnquiryEntryForm,null,false,name,null).Visible = true;
                  
                }
                else
                {
                    UICommon.FormFactory.GetForm(Forms.FrmEnquiryEntryForm).Visible = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (appname== "Gym" || appname == "Dance")
                {

                    UICommon.FormFactory.GetForm(Forms.FrmRegistrationForm, this, true, name, null).Visible = true;
                }
                else
                {
                    UICommon.FormFactory.GetForm(Forms.FrmRegistrationForm, this, true).Visible = true;
                
            }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void btnFees_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFeesPayment).Visible = true;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void btnExpire_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmExpiredRenewal).Visible = true;

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmAttendance).Visible = true;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void lnkOutstdndFees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (appname == "Gym" || appname == "Dance")
                {
                    UICommon.FormFactory.GetForm(Forms.FrmViewOutstanding, this, true, name, null).Visible = true;
                }
                else
                {
                    UICommon.FormFactory.GetForm(Forms.FrmViewOutstanding, this, true, null, null).Visible = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void lnkExpMembers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmExpiredRenewal).Visible = true;
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmExpiredRenewal).Visible = true;
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void lnkTodayfollowup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowUpVew).Visible = true;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void lnkTotal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (appname == "Gym" || appname == "Dance")
                {
                    UICommon.FormFactory.GetForm(Forms.FrmStudent, this, true, name, null).Visible = true;
                }
                else
                {
                    UICommon.FormFactory.GetForm(Forms.FrmStudent, this, true, null, null).Visible = true;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                ControlPaint.DrawBorder(e.Graphics, this.panel17.ClientRectangle, Color.PowderBlue, ButtonBorderStyle.None);
                Graphics g = e.Graphics;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (appname == "Gym" || appname=="Dance")
                {
                   
                    if (studSearch.SelectedIndex != -1)
                    {
                        string[] Application = { "Gym" };
                       WinApp.Gym.FrmStudentDetails  objstudent = (WinApp.Gym.FrmStudentDetails)UICommon.FormFactory.GetForm(Forms.FrmStudentDetails, this, true, Application, null) ;
                       // FrmStudentDetails objstudent = (FrmStudentDetails)UICommon.FormFactory.GetForm(Forms.FrmStudentDetails, this, true,Application, null);
                       objstudent.loadStudent((studSearch.SelectedItem as ComboItem).key);
                       objstudent.ShowDialog();
                        studSearch.Text = "";
                    }

                    else
                    {
                        UICommon.WinForm.showStatus("Select the Name", sCaption, this);
                    }
                }
                else
                {
                    if (studSearch.SelectedIndex != -1)
                    {

                        FrmStudentDetails objstudent = (FrmStudentDetails)UICommon.FormFactory.GetForm(Forms.FrmStudentDetails, this, true);
                        objstudent.loadStudent((studSearch.SelectedItem as ComboItem).key);
                        objstudent.ShowDialog();
                        studSearch.Text = "";
                    }

                    else
                    {
                        UICommon.WinForm.showStatus("Select the Name", sCaption, this);
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           // txtBioMetricId.TabStop = true;
           // txtBioMetricId.Focus();
        }

        private void cmbStudName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void btnOverall_Click(object sender, EventArgs e)
        {
            try
            {
                ISReg = "%";
                LoadcoursewiseEnquiry();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            try
            {
                ISReg = "0";
                LoadcoursewiseEnquiry();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            try
            {
                ISReg = "1";
                LoadcoursewiseEnquiry();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            try
            {
                IsActive = "NO";
                loadBarChart();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnStudAll_Click(object sender, EventArgs e)
        {
            try
            {
                IsActive = "%";
                loadBarChart();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chartEnquiryStatus_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnFollowup_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFollowReport).Visible = true;
            }
            catch(Exception ex)
            {

            }
        }

        private void lnkAttdReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmAttendanceSheet).Visible = true;

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void dispollowupsonload()
        {
            try
            {
                DataTable todaysFollowup = BLL.FollowupHandler.getFollowUpsOnLoad(Program.LoggedInUser.BranchId.ToString());
                if (todaysFollowup.Rows.Count > 0)
                {
                    FrmCommonPopup objpopup = (FrmCommonPopup)UICommon.FormFactory.GetForm(Forms.FrmCommonPopup, this.MdiParent);
                    objpopup.bindData(todaysFollowup);
                    objpopup.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lnkFollowup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmFollowReport objpopup = (FrmFollowReport)UICommon.FormFactory.GetForm(Forms.FrmFollowReport, this.MdiParent);
                objpopup.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnPayfees_Click(object sender, EventArgs e)
        {
            try
            {
                if (studSearch.SelectedIndex != -1)
                {
                    LoadStudent((studSearch.SelectedItem as ComboItem).key);
                    FrmFeesPayment objFees = (FrmFeesPayment)UICommon.FormFactory.GetForm(Forms.FrmFeesPayment);
                    objFees.LoadFeeDetailsFromRegistration(objstudent);
                    objFees.Visible = true;

                    studSearch.Text = "";
                }

                else
                {
                    UICommon.WinForm.showStatus("Select the Name", sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void LoadStudent(int Admission)
        {
            try
            {
                objstudent = BLL.StudentHandller.GetStudent(Admission, null, null, null, Program.LoggedInUser.BranchId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAttd_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (txtBioMetricId.Text != "" || txtBioMetricId.Text.Length > 0)
                {
                    logAttendence(txtBioMetricId.Text.ToString(), 0, 0, 0, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);
                    txtBioMetricId.Text = "";
                }

                else
                {
                    UICommon.WinForm.showStatus("Enter BiometricId", sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void logAttendence(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                

                int enrollmentNo = Convert.ToInt32(sEnrollNumber);
                Int32 isChekin = 0;

                DateTime timePunchIn = new DateTime();
                try
                {
                    timePunchIn = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);
                    int sendSMS;
                    isChekin = ClassManager.BLL.AttendanceHandler.logAttendence(enrollmentNo, SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID), timePunchIn,"ClassManager",out sendSMS);
                }
                catch (Exception ex)
                {

                }

                List<Student> objstud = new List<Student>();
                Student objStudentMaster = new Student();
                Faculty objFaculty = new Faculty();
                try
                {
                    objStudentMaster = ClassManager.BLL.StudentHandller.getStudentByBioMetric(enrollmentNo,Program.LoggedInUser.BranchId.ToString());
                    bool enableDisablUser;
                    if (objStudentMaster != null)
                    {
                        DataTable dt = ClassManager.BLL.StudentHandller.getFacility(objStudentMaster.AdmissionNo);
                        StringBuilder displaypopup = new StringBuilder();
                        
                        BioMonitor.FrmBiomPopup.addItem(objStudentMaster, timePunchIn,out enableDisablUser, isChekin);
                       
                    }
                    else
                    {
                        objFaculty = BLL.FacultyHandler.getFacultiesByID(enrollmentNo, Program.LoggedInUser.BranchId);
                        if (objFaculty != null)
                        {
                          BioMonitor.FrmBiomPopup.addItem(objFaculty, timePunchIn, out enableDisablUser,isChekin);
                           
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                if (objStudentMaster == null && objFaculty == null)
                {
                    UICommon.WinForm.showStatus("Not a valid member",MessageBoxButtons.OK,MessageBoxIcon.Warning,this.sCaption,this);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showStatus("Not a valid member", MessageBoxButtons.OK, MessageBoxIcon.Error, this.sCaption, this);
                Common.Log.LogError("logAttendence(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)", Common.ErrorLevel.ERROR, ex);
            }

        }

        private void txtBioMetricId_KeyPress(object sender, KeyPressEventArgs e)

        {

            if (txtBioMetricId.Text.Length >= 10)
            {
                if (e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;

                if (txtBioMetricId.Text != "" || txtBioMetricId.Text.Length > 0)
                {
                    logAttendence(txtBioMetricId.Text.ToString(), 0, 0, 0, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);
                    txtBioMetricId.Text = "";
                    txtBioMetricId.Focus();
                    
                }
                else
                {
                    UICommon.WinForm.showStatus("Enter BiometricId", sCaption, this);
                }
            }
                
        }

        private void txtBioMetricId_Click(object sender, EventArgs e)
        {
           
        }

        private void chrtFollowup_Click(object sender, EventArgs e)
        {

        }
    }
}
