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
using System.Media;
using System.IO;
using WMPLib;

namespace ClassManager.BioMonitor
{


    public partial class FrmBiomPopup : Form
    {
        internal class StackItem
        {
            internal object item { get; private set; }
            internal DateTime dateTime { get; private set; }
            public int checkInStatus { get; private set; }
            public string status { get; private set; }

            public StackItem(object item, DateTime dateTime, int checkInStatus = 0)
            {
                this.item = item;
                this.dateTime = dateTime;
                this.checkInStatus = checkInStatus;

                if (checkInStatus == 1)
                {
                    this.status = "check in";
                }
                else
                {
                    this.status = "check out";
                }
            }
        }


        Student objStudentMaster = new Student();
        Faculty objFaculty = new Faculty();

        System.Collections.ArrayList Package = new System.Collections.ArrayList();
        System.Collections.ArrayList ExpireDate = new System.Collections.ArrayList();

        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        Stack<StackItem> formItems = new Stack<StackItem>();

        static FrmBiomPopup myIntance = new BioMonitor.FrmBiomPopup();

        public FrmBiomPopup()
        {
            InitializeComponent();
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private void PopUp_Load(object sender, EventArgs e)
        {
            try
            {
                Common.Log.LogError("popup screen Load", Common.ErrorLevel.INFORMATION);
                timer.Interval = Info.SysParam.getValue<int>(SysParam.Parameters.POPUP_TIMER);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();

            }
            catch (Exception)
            {
                throw;
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (formItems.Count <= 1)
            {

                this.Close();
                timer.Stop();
            }

            Common.Log.LogError("TimerTick complete", Common.ErrorLevel.INFORMATION);

        }

        private void playSimpleSound()
        {
            Player.URL = "anydo_popup.mp3";
            Player.controls.play();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }


        internal bool LoadStudent(Student objStudentMaster, StackItem stackItem)
        {
            try
            {
                Common.Log.LogError("Called Load Student From Popup Screen ", Common.ErrorLevel.INFORMATION);
                string Date = null;
                var Maxdate = Date;
                bool enableDisableUser = false;

                Student objstud = new Student();
                objstud = ClassManager.BLL.StudentHandller.GetStudent(objStudentMaster.AdmissionNo, null, null, null, SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID));
                string outfees = Common.Formatter.FormatCurrency((objstud.Fees.Installments.Sum(ttl => ttl.InstAmount) - objstud.Fees.Installments.Sum(paid => paid.AmntPaid) - objstud.Fees.Installments.Sum(dscnt => dscnt.Discount) - objstud.Fees.Installments.Sum(ins => ins.CancelledAmount)));

                lblName.Text = "";
                lblOutfees.Text = "";
                lblPackage.Text = "";
                Common.Log.LogError("Checking for the Application Type ", Common.ErrorLevel.INFORMATION);
                if (SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() != "" && SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() != "Asset")
                {
                    Common.Log.LogError("Setting for Font and colur of the screen. ", Common.ErrorLevel.INFORMATION);
                    lblName.Visible = true; ;
                    //Currrent installation is a GymWise
                    lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    PbPhoto.Image = null;
                    Common.Log.LogError("Setting Text for Name.", Common.ErrorLevel.INFORMATION);
                    lblName.Text = objstud.Fname.ToString() + " " + objstud.Lname.ToString();
                    if (SysParam.getValue<bool>(SysParam.Parameters.BIO_SHOW_OUTSTAING_FEES_IN_POPUP) == true)
                    {
                        lblOutfees.Text = "Outstanding Payment: " + outfees;
                    }
                    else
                    {
                        lblOutfees.Text = "";
                    }
                    Common.Log.LogError("Fetching PhotoURL", Common.ErrorLevel.INFORMATION);
                    if ((objstud.PhotoURL.ToString()).Contains("\r\n"))
                    {
                        (objstud.PhotoURL) = (objstud.PhotoURL.ToString().Replace("\r\n", ""));
                    }

                    string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                    string photoPath = photoFolder + "\\" + objstud.PhotoURL.ToString();

                    try
                    {
                        Common.Log.LogError("set Image", Common.ErrorLevel.INFORMATION);
                        PbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                    }
                    catch (Exception ex)
                    {
                        PbPhoto.Image = Properties.Resources.img;
                        Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for member : " + objstud.AdmisionNo, Common.ErrorLevel.INFORMATION);
                    }

                    if (objstud.Facilities.Count > 0)
                    {


                        bool packageExpired = false;

                        List<StudentFacility> studentFacilitiesToConsider = new List<StudentFacility>();
                        studentFacilitiesToConsider.AddRange(objstud.Facilities.Where(f => f.RemindRenewal == true));

                        StudentFacility expiredFacilityToShow = objstud.Facilities.Where(f => f.RemindRenewal == false).Where(facility => facility.Status == "E").OrderByDescending(fac => fac.ToDate).FirstOrDefault();

                        if(expiredFacilityToShow != null)
                        {
                            studentFacilitiesToConsider.Add(expiredFacilityToShow);
                        }

                        

                        List<StudentFacility> activeFacilities = objstud.Facilities.Where(f => f.Status == "A").ToList<StudentFacility>();
                        studentFacilitiesToConsider.AddRange(activeFacilities);

                        if (studentFacilitiesToConsider.Count > 0)
                        {
                            int i = 1;
                            foreach (StudentFacility facility in studentFacilitiesToConsider)
                            {
                                if (facility.ToDate < System.DateTime.Now.Date)
                                {
                                    packageExpired = true;
                                }

                                if ((activeFacilities.Count == 0 && facility.Status == "E") || facility.Status == "A")
                                {
                                    lblPackage.Text += (i + ". " + facility.FacilityName + "  expiry date: " + Common.Formatter.FormatDate(facility.ToDate) + "\n");
                                }

                                i++;
                            }
                        }
                        else
                        {
                            lblPackage.Text = "No Active Package for the Member.";
                            lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                        }

                        //If not active package then disable user
                        if (studentFacilitiesToConsider != null && studentFacilitiesToConsider.Count() == 0)
                        {
                            enableDisableUser = false;
                        }

                        //Common.Log.LogError(Common.Log.Level.INFORMATION, "Checking for Expired Package and Depending change the colour of Screen ");
                        if (packageExpired == true && activeFacilities.Count() == 0)
                        {
                            string color = Info.SysParam.getValue<string>(Info.SysParam.Parameters.BIO_EXP_COLOR);
                            panelpopup.BackColor = Color.FromName(color);

                            //panelpopup.BackColor = color;
                            lblPackage.ForeColor = Color.White;
                            lblOutfees.ForeColor = Color.White;
                            lblName.ForeColor = Color.White;
                            playSimpleSound();
                            packageExpired = false;
                        }
                        else
                        {
                            // panelpopup.BackColor = Color.White;
                            string color = Info.SysParam.getValue<string>(Info.SysParam.Parameters.ACTIVE_PKG_COLOR);

                            try
                            {
                                panelpopup.BackColor = Color.FromName(color);
                            }
                            catch (Exception)
                            {
                                panelpopup.BackColor = Color.FromName("Transparent");
                            }

                            lblPackage.ForeColor = ColorTranslator.FromHtml("#484b68");
                            lblOutfees.ForeColor = ColorTranslator.FromHtml("#484b68");
                            lblName.ForeColor = ColorTranslator.FromHtml("#484b68");
                        }

                    }
                    else
                    {
                        lblPackage.Text = objstud.Fname.ToString() + " " + objstud.Lname.ToString() + " has no Active Packages.";
                        lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    Int32 chekinCount = 0;
                    //added new backend method to get attendence count for checking how many times student punched in


                    btnMachineName.Text = objStudentMaster.checkinMachine;

                    if (objStudentMaster.dailyAttendanceCount > 1)
                    {
                        lblattendencecount.Text = "Member Has Checked in " + objStudentMaster.dailyAttendanceCount + " Times";
                    }
                    else
                    {
                        lblattendencecount.Text = "";
                    }
                }
                else
                {
                    Common.Log.LogError("Started if the Application is the Class ", Common.ErrorLevel.INFORMATION);
                    //Current installation is ClassWise
                    lblName.Visible = false;
                    lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                    string folderPath = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH).ToString();
                    string photoPath = folderPath + "\\" + objstud.PhotoURL;

                    try
                    {
                        Common.Log.LogError("setting the Image ", Common.ErrorLevel.INFORMATION);
                        PbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                    }
                    catch (Exception ex)
                    {
                        PbPhoto.Image = Properties.Resources.img;
                        Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for memeber : " + objStudentMaster.AdmisionNo, Common.ErrorLevel.INFORMATION);
                    }



                    if (objstud.Facilities.Count > 0)
                    {
                        lblOutfees.Text = objstud.Fname.ToString() + " " + objstud.Lname.ToString() + " has " + stackItem.status + ".\nCourse : " + objstud.Course.Standard.StandardName + "\nBatch : " + ( (objstud.Course.Batch != null)? objstud.Course.Batch.Name :" ") + "\n";
                        if (SysParam.getValue<bool>(SysParam.Parameters.BIO_SHOW_OUTSTAING_FEES_IN_POPUP) == true)
                        {
                            lblPackage.Text = "Outstanding Payment: " + outfees;
                        }
                        else
                        {
                            lblPackage.Text = "";
                        }

                    }
                    else
                    {
                        lblOutfees.Text = objstud.Fname.ToString() + " " + objstud.Lname.ToString() + " has " + stackItem.status + ".";
                        lblPackage.Text = ("No Course for " + objstud.Fname.ToString() + objstud.Lname.ToString());
                    }
                }

                lblDateTime.Text = Common.Formatter.FormatDateTime(stackItem.dateTime);
                return enableDisableUser;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw ex;
            }
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            try
            {
                formItems.Pop();
                itemPushed();
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
            }
        }

        internal void LoadFaculty(Faculty objFaculty, StackItem stackItem)
        {
            try
            {
                Common.Log.LogError("Load Faculty for PopScreen ", Common.ErrorLevel.INFORMATION);
                panelpopup.BackColor = Color.White;
                lblPackage.ForeColor = ColorTranslator.FromHtml("#484b68");
                lblOutfees.ForeColor = ColorTranslator.FromHtml("#484b68");
                lblName.ForeColor = ColorTranslator.FromHtml("#484b68");
                lblName.Visible = false;
                lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                lblOutfees.Text = objFaculty.Name.ToString();
                if (SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "" || SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() == "Asset")
                {
                    lblPackage.Text = "Faculty has " + stackItem.status + ".";
                }
                else
                {
                    lblPackage.Text = "Instructor has " + stackItem.status + ".";
                }

                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objFaculty.PhotoURL.ToString();

                try
                {

                    PbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                }
                catch (Exception ex)
                {
                    PbPhoto.Image = Properties.Resources.img;
                    Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for faculty : " + objFaculty.FacultyID, Common.ErrorLevel.INFORMATION);
                }

                lblDateTime.Text = stackItem.dateTime.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static FrmBiomPopup addItem(object item, DateTime dateTime, out bool enableDisableUser, int checkInStatus = 1)
        {
            if (myIntance == null || myIntance.IsDisposed == true)
            {
                myIntance = new FrmBiomPopup();
            }

            myIntance.formItems.Push(new StackItem(item, dateTime, checkInStatus));
            enableDisableUser = myIntance.itemPushed();
            return myIntance;
        }

        private bool itemPushed()
        {
            bool enableDisableUser = true;
            if (formItems.Count == 0)
            {
                btnprev.Visible = false;
                return false;
            }

            StackItem stackItem = formItems.Peek();

            if (formItems.Count > 1)
            {
                btnprev.Visible = true;
                btnprev.Text = "Previous (" + (formItems.Count - 1) + ")";
            }
            else
            {
                btnprev.Text = "Previous";
                btnprev.Visible = false;
            }

            if (stackItem.item is Student)
            {
                enableDisableUser = LoadStudent(stackItem.item as Student, stackItem);
            }
            else if (stackItem.item is Faculty)
            {
                LoadFaculty(stackItem.item as Faculty, stackItem);
            }


            this.TopMost = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
            return enableDisableUser;
        }

    }
}
