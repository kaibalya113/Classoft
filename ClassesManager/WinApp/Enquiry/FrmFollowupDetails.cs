//display folowupdetails of fees,attendence,enquiry,expired packages in enquiry menu by ashvini 25-01-2019

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
using ClassManager.BLL;
using ClassManager.Common;

namespace ClassManager.WinApp
{
    public partial class FrmFollowupDetails : FrmParentForm
    {
        string sCaption = "Followup Details";
        string AppName = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        public FrmFollowupDetails()
        {
            InitializeComponent();
        }

        private void cmbViewFollowUp_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ADGVFollowupDetails.Columns.Contains("View"))
                {
                    ADGVFollowupDetails.Columns.Remove("View");
                }
                UICommon.WinForm.setDate(dtFrmDate, dtToDate);
             
            
                if (cmbViewFollowUp.SelectedIndex == 0 || cmbViewFollowUp.SelectedIndex == 1 || cmbViewFollowUp.SelectedIndex == 2 || cmbViewFollowUp.SelectedIndex == 3 || cmbViewFollowUp.SelectedIndex == 4)

                {
                    ADGVFollowupDetails.DataSource = BLL.FollowupHandler.getFollowUpDetails(branchID, dtFrmDate.Value,dtToDate.Value, cmbViewFollowUp.SelectedIndex);
                    formatfollowGrid();
                }

            }
                      
               
            
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void fillcmbType()
        {
            string app = (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString());

            if (app == "Gym" || app == "Dance")
            {
                cmbViewFollowUp.Items.Insert(0, "ALL");
                cmbViewFollowUp.Items.Insert(1, "Attendance");
                cmbViewFollowUp.Items.Insert(2, "OutstandingDue");
                cmbViewFollowUp.Items.Insert(3, "Renewals");
                cmbViewFollowUp.Items.Insert(4, "Enquiry");
            }
            if (app == "Asset" || app == "")
            {
                cmbViewFollowUp.Items.Insert(0, "ALL");          
                cmbViewFollowUp.Items.Insert(1, "Attendance");
                cmbViewFollowUp.Items.Insert(2, "OutstandingDue");
                cmbViewFollowUp.Items.Insert(3, "Academic");
                cmbViewFollowUp.Items.Insert(4, "Enquiry");
            }
        }


        public void formatfollowGrid()
        {
            ADGVFollowupDetails.ReadOnly = true;
            ADGVFollowupDetails.Columns["Next Followup"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            ADGVFollowupDetails.Columns["Followup On"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            ADGVFollowupDetails.Columns["Description"].Width = 400;
            if (ADGVFollowupDetails.Columns.Contains("ID"))
            {
                ADGVFollowupDetails.Columns["ID"].Visible = false;
            }
            {
               
                if (AppName == "Gym")
                {
                    if (ADGVFollowupDetails.Columns.Contains("Father Contact"))
                    {
                        ADGVFollowupDetails.Columns["Father Contact"].Visible = false;
                    }
                    if(ADGVFollowupDetails.Columns.Contains("Column1")){
                        ADGVFollowupDetails.Columns["Column1"].HeaderText = "Status";
                    }



                }
            }
        }
        private void FrmFollowupDetails_Load(object sender, EventArgs e)
        {
            SGView.Visible = false;
            fillcmbType();
            cmbViewFollowUp.SelectedIndex = 0;
           // DateTime fromdate = dtFrmDate.Value.AddDays(-15);
           // DateTime toDate = dtFrmDate.Value.AddDays(15);
            ADGVFollowupDetails.DataSource = BLL.FollowupHandler.getFollowUpDetails(branchID, dtFrmDate.Value.AddDays(-15), dtFrmDate.Value.AddDays(15), cmbViewFollowUp.SelectedIndex);
            formatfollowGrid();
        }

        private void dtToDate_CloseUp(object sender, EventArgs e)
        {
            ADGVFollowupDetails.DataSource = BLL.FollowupHandler.getFollowUpDetails(branchID, dtFrmDate.Value, dtToDate.Value, cmbViewFollowUp.SelectedIndex);
            formatfollowGrid();

        }

        private void dtFrmDate_CloseUp(object sender, EventArgs e)
        {
            ADGVFollowupDetails.DataSource = BLL.FollowupHandler.getFollowUpDetails(branchID, dtFrmDate.Value, dtToDate.Value, cmbViewFollowUp.SelectedIndex);
            formatfollowGrid();
        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {

                PdfParameters getParameter = new PdfParameters();


                getParameter.FromDate = "FromDate:- " + Common.Formatter.FormatDate(dtFrmDate.Value);
                getParameter.ToDate = "ToDate:- " + Common.Formatter.FormatDate(dtToDate.Value);
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Followup Details Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;
                getParameter.count = "Followup Count:- "+ ADGVFollowupDetails.Rows.Count;
                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (ADGVFollowupDetails.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Followup Details Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        Common.ImportExport.ImportToPDF(ADGVFollowupDetails, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void ADGVFollowupDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SGView.ReadOnly = true;
            DataTable dt = null;
            //    //added by ashvini for displaying data like courese, name,contactno ... on 31-01-2019
            if (ADGVFollowupDetails.Columns.Contains("View") && e.ColumnIndex == ADGVFollowupDetails.Columns["View"].Index)
            {

                if (ADGVFollowupDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
                {

                    switch (cmbGroupBy.SelectedIndex)
                    {

                        case 0:
                            {
                                string status;

                                string con = (ADGVFollowupDetails.Rows[e.RowIndex].Cells["Counselor"].Value).ToString();
                                status = cmbViewFollowUp.SelectedItem.ToString();
                                int identifier = cmbViewFollowUp.SelectedIndex;
                                dt = BLL.StudentHandller.getStudentsByGroupBycouncellor(identifier, con, status);




                                SGView.Visible = true;
                                SGView.DataSource = dt;
                                //                    formatViewGrid();
                                //                    SGStudents.Width = 400;
                                //                    SGStudents.Height = 397;

                                //                    //  formatGrid(1);
                                break;

                            }
                       
                    }

                }
            }
        }

        private void cmbGroupBy_SelectedIndexChanged(object sender, EventArgs e)

        {
            SGView.Visible = true;
            cmbGroupBy.SelectedIndex = 0;

            SGView.Visible = false;
            if (ADGVFollowupDetails.Columns.Contains("View"))
            {
               ADGVFollowupDetails.Columns["View"].Visible = true;

            }
            else
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                lnk.Name = "View";
                lnk.HeaderText = "View Members";
                lnk.DefaultCellStyle.NullValue = "View";
                ADGVFollowupDetails.Columns.Insert(2, lnk);
            }
            DataTable dtfollowup = BLL.FollowupHandler.getFollowUpDetails(branchID, dtFrmDate.Value, dtToDate.Value, cmbViewFollowUp.SelectedIndex);
            formatfollowGrid();
            if (cmbViewFollowUp.SelectedIndex==2 && cmbGroupBy.SelectedIndex==0)
            {
                DataTable stream = WinForm.ToDataTable(dtfollowup.DefaultView.ToTable().AsEnumerable()
                                           .GroupBy(r => new { Counselor = r.Field<string>("Followup By") })
                                           .Select(g => new
                                           {
                                               Counselor = g.Key.Counselor,

                                               Count = g.Count()
                                               
                                            
                                           })
                                             .ToList());

                ADGVFollowupDetails.DataSource = stream;

            }
            if (cmbViewFollowUp.SelectedIndex == 1 && cmbGroupBy.SelectedIndex == 0)
            {
                DataTable stream = WinForm.ToDataTable(dtfollowup.DefaultView.ToTable().AsEnumerable()
                                           .GroupBy(r => new { Counselor = r.Field<string>("Followup By") })
                                           .Select(g => new
                                           {
                                               Counselor = g.Key.Counselor,

                                               Count = g.Count()


                                           })
                                             .ToList());

                ADGVFollowupDetails.DataSource = stream;

            }
            if (cmbViewFollowUp.SelectedIndex == 3 && cmbGroupBy.SelectedIndex == 0)
            {
                DataTable stream = WinForm.ToDataTable(dtfollowup.DefaultView.ToTable().AsEnumerable()
                                           .GroupBy(r => new { Counselor = r.Field<string>("Followup By") })
                                           .Select(g => new
                                           {
                                               Counselor = g.Key.Counselor,

                                               Count = g.Count()


                                           })
                                             .ToList());

                ADGVFollowupDetails.DataSource = stream;

            }
            if (cmbViewFollowUp.SelectedIndex == 4 && cmbGroupBy.SelectedIndex == 0)
            {
                DataTable stream = WinForm.ToDataTable(dtfollowup.DefaultView.ToTable().AsEnumerable()
                                           .GroupBy(r => new { Counselor = r.Field<string>("Followup By") })
                                           .Select(g => new
                                           {
                                               Counselor = g.Key.Counselor,

                                               Count = g.Count()


                                           })
                                             .ToList());

                ADGVFollowupDetails.DataSource = stream;

            }

        }

        }
    }


//end by ashvini 25-01-2019
