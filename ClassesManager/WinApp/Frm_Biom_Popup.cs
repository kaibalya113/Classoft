using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp;
using System.IO;
using ClassManager.WinApp.UICommon;
using WMPLib;

namespace ClassManager.WinApp
{
    public partial class PopUp : FrmParentForm
    {
     List<Student> objstud;
        Student objStudentMaster = new Student();
        Faculty objFaculty = new Faculty();
        DataRow[] ActiveStreamId = null;
        DataRow[] ActiveStream = null;
        System.Collections.ArrayList Package = new System.Collections.ArrayList();
        System.Collections.ArrayList ExpireDate = new System.Collections.ArrayList();
        List<Info.StudentMaster> lstBiometricId;
        int count; int Number;
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        public PopUp()
        {
            InitializeComponent();
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void PopUp_Load(object sender, EventArgs e)
        {
            try

            {
              
               timer.Interval = Info.SysParam.getValue<int>(SysParam.Parameters.POPUP_TIMER);
               timer.Tick += new EventHandler(timer_Tick);
               timer.Start();
            //   playSimpleSound();
             //   System.Media.SystemSounds.Beep.Play();
               
                if(SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) != "" && SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME).ToString() != "Asset" )
                {
                    lblCourse.Text = "Packages :";
                }
                
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void playSimpleSound()
        {


            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = "D:\\Projects\\ClassWise\\classmanager-windows (New-04-Jan )\\BioMonitor\\Resources";
            //player.Play();
            Player.URL = "anydo_popup.mp3";
            Player.controls.play();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            try
            {

                count = count + 1;
                Number = count + 1;
                objStudentMaster = ClassManager.BLL.StudentHandller.getStudentByBioMetric(lstBiometricId[Number].BiometricId,Program.LoggedInUser.BranchId.ToString());
                LoadStudent(objStudentMaster, lstBiometricId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void LoadStudent(Student objStudentMaster, List<StudentMaster> lstBiometric)
        {
            try
            {

                lstBiometricId = lstBiometric;

                string Date = null;
                var Maxdate = Date;
                DataTable dt = ClassManager.BLL.StudentHandller.getFacility(objStudentMaster.AdmissionNo);
                decimal outfees = ClassManager.BLL.FeesHandller.getoutfees(objStudentMaster.AdmissionNo, DateTime.Now);
                lblName.Text = "";
                lblOutfees.Text = "";
                lblPackage.Text = "";

                if (SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() != "" && SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() != "Asset")
                {
                    lblPackage.Font = new Font("Arial", 12, FontStyle.Regular);
                    PbPhoto.Image = null;
                    lblName.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString();
                    lblOutfees.Text = ("Outstanding Payment: " + Common.Formatter.FormatCurrency(outfees)).ToString();
                    if ((objStudentMaster.PhotoURL.ToString()).Contains("\r\n"))
                    {
                        (objStudentMaster.PhotoURL) = (objStudentMaster.PhotoURL.ToString().Replace("\r\n",""));
                    }
                    string path = Path.GetDirectoryName(objStudentMaster.PhotoURL.ToString()).TrimStart()+ "\\";
                    if (SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH).ToString() == path.ToString())
                    {
                        PbPhoto.Image = new Bitmap(new Bitmap(objStudentMaster.PhotoURL.ToString()), new Size(135, 135));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            DateTime date = Convert.ToDateTime(dr["To Date"]).Date;
                            decimal pendingFees = Convert.ToDecimal(dr["Pending"]);
                            // To check whether there is any expired package of same stream having currently active packages.
                            ActiveStreamId = dt.Select("Status='A'"); //and StreamId=" + dr.ItemArray[10].ToString());

                            Maxdate = dt.Compute("Max([To Date])", "Status='E'").ToString();
                            ActiveStream = dt.Select("Status='A'or Status='E'");

                        }

                        if (ActiveStream.Length > 0)
                        {
                            int i = 1;

                            foreach (DataRow dr in ActiveStream)
                            {

                                if (Convert.ToDateTime(dr.ItemArray[2]) < System.DateTime.Now.Date)
                                {

                                    panelpopup.BackColor = Color.DarkSlateGray;
                                    lblPackage.Text += (i + ". " + dr.ItemArray[0] + "  expiry date: " + Common.Formatter.FormatDate(Convert.ToDateTime(dr.ItemArray[2])).ToString()) + "\n";
                                    lblPackage.Font = new Font("microsoft sans serif", 12);
                                    lblPackage.ForeColor = Color.White;
                                    lblOutfees.ForeColor = Color.White;
                                    lblName.ForeColor = Color.White;
                                    lblCourse.ForeColor = Color.White;

                                    playSimpleSound();
                                }
                                else
                                {
                                    lblPackage.Text += (i + ". " + dr.ItemArray[0] + "  expiry date: " + Common.Formatter.FormatDate(Convert.ToDateTime(dr.ItemArray[2])).ToString()) + "\n";
                                }

                                i++;
                            }
                        }

                        else
                        {
                            lblPackage.Text = "No Active Package for the Member.";
                            lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                        }
                    //    string[] TobeDistinct = { "StreamID" };
                    //    DataTable dtDistinct = BLL.NotificationHandler.GetDistinctRecords(dt, TobeDistinct);

                    //    string[] stream = new string[100];
                    //    foreach (DataRow row in dt.Rows)
                    //    {
                    //        DateTime date = Convert.ToDateTime(row["To Date"]).Date;
                    //        decimal pendingFees = Convert.ToDecimal(row["Pending"]);

                    //        if (!row["Status"].Equals("A") && (!row["Status"].Equals("D")))
                    //        {
                    //            foreach (DataRow dr in ActiveStreamId)
                    //            {
                    //                if (dr.ItemArray[10].ToString().Equals(row.ItemArray[10].ToString()))
                    //                {

                    //                }
                    //                else
                    //                {
                    //                    if (Maxdate.Equals(row.ItemArray[2].ToString()))
                    //                    {
                    //                        lblExpiry.Text = (row["Course"] + " has expired on " + date.ToShortDateString()).ToString() + ("\nRs." + pendingFees + " pending\n").ToString();
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }

                    }
                    else
                       {
                            lblPackage.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString() + "does not have any Package";
                            lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                        }
                    }
            
            else
             {
                    lblName.Visible = false;
                    lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblCourse.Visible = false;
                    string path = Path.GetDirectoryName(objStudentMaster.PhotoURL.ToString()) + "\\";

                    if (SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH).ToString() == path.ToString())
                    {
                        PbPhoto.Image = new Bitmap(new Bitmap(objStudentMaster.PhotoURL.ToString()), new Size(135, 135));
                    }
                    lblOutfees.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString() + "\n" + "has CheckedIn.";
                    if (dt.Rows.Count > 0)
                    {
                        lblPackage.Text = ("Outstanding Payment: " + "\n" + Common.Formatter.FormatCurrency(outfees)).ToString();
                    }
                    else
                    { 
                        lblPackage.Text = ("No Course for " + objStudentMaster.Fname.ToString() + objStudentMaster.Lname.ToString());
                    }
                }
        }
            catch (Exception ex)
            {


                throw ex;

            }
        }


        public void LoadFaculty(Faculty objFaculty)
        {
            try
            {
               
                lblName.Visible = false;
                lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                lblOutfees.Text = objFaculty.Name.ToString();
                if (SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "" || SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Asset")
                {
                    lblPackage.Text = "Faculty has CheckedIn.";
                }
                else
                {
                    lblPackage.Text = "Instructor has CheckedIn.";
                }
               
                lblCourse.Visible = false;
                string path = Path.GetDirectoryName(objFaculty.PhotoURL.ToString()) + "\\";

                if (SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH).ToString() == path.ToString())
                {
                    PbPhoto.Image = new Bitmap(new Bitmap(objFaculty.PhotoURL.ToString()), new Size(135, 135));
                }
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnprev_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBiometricId.Count() > 1)
                {
                    ListBox list = new ListBox();
                    list.DataSource = lstBiometricId;
                
                    count = count - 1;

                    Number = count - 1;
                    objStudentMaster = ClassManager.BLL.StudentHandller.getStudentByBioMetric(lstBiometricId[Number].BiometricId,Program.LoggedInUser.BranchId.ToString());
                    LoadStudent(objStudentMaster, lstBiometricId);
                    // FrmDashBoard frmdashbrd = new FrmDashBoard();
                    // frmdashbrd.logAttendence(lstBiometricId[Number].BiometricId.ToString(), 0, 0, 0, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);
                }
                else
                {
                    WinForm.showStatus("No Previous Record to view .", MessageBoxButtons.OK, MessageBoxIcon.Information, null, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
