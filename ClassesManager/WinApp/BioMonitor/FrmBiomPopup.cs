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

            public StackItem(object item, DateTime dateTime,int checkInStatus = 0)
            {
                this.item = item;
                this.dateTime = dateTime;
                this.checkInStatus = checkInStatus;

                if(checkInStatus == 0)
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
                Common.Log.LogError(Common.Log.Level.INFORMATION, "popup screen Load");
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

            Common.Log.LogError(Common.Log.Level.INFORMATION, "TimerTick complete");

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
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Called Load Student From Popup Screen ");
                string Date = null;
                var Maxdate = Date;
                bool enableDisableUser = false;

                DataTable studentFacilities = ClassManager.BLL.StudentHandller.getFacility(objStudentMaster.AdmissionNo);
                Student objstud = new Student();
                objstud = ClassManager.BLL.StudentHandller.GetStudent(objStudentMaster.AdmissionNo, null, null, null, SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID));
                string outfees = Common.Formatter.FormatCurrency((objstud.Fees.Installments.Sum(ttl => ttl.InstAmount) - objstud.Fees.Installments.Sum(paid => paid.AmntPaid) - objstud.Fees.Installments.Sum(dscnt => dscnt.Discount) - objstud.Fees.Installments.Sum(ins => ins.CancelledAmount)));
                objStudentMaster.Courses = BLL.StudentHandller.getCourses(objStudentMaster.AdmissionNo);
                if (objStudentMaster.Courses != null && objStudentMaster.Courses.Count > 0)
                {
                    objStudentMaster.Course = objStudentMaster.Courses[0];
                }

                lblName.Text = "";
                lblOutfees.Text = "";
                lblPackage.Text = "";
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Checking for the Application Type ");
                if (SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() != "" && SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToString() != "Asset")
                {
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Setting for Font and colur of the screen. ");
                    lblName.Visible = true; ;
                    //Currrent installation is a GymWise
                    lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    PbPhoto.Image = null;
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Setting Text for Name.");
                    lblName.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString();
                    if (SysParam.getValue<bool>(SysParam.Parameters.BIO_SHOW_OUTSTAING_FEES_IN_POPUP) == true)
                    {
                        lblOutfees.Text = "Outstanding Payment: " + outfees;
                    }
                    else
                    {
                        lblOutfees.Text = "";
                    }
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Fetching PhotoURL");
                    if ((objStudentMaster.PhotoURL.ToString()).Contains("\r\n"))
                    {
                        (objStudentMaster.PhotoURL) = (objStudentMaster.PhotoURL.ToString().Replace("\r\n", ""));
                    }

                    string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                    string photoPath = photoFolder + "\\" + objStudentMaster.PhotoURL.ToString();

                    try
                    {
                        Common.Log.LogError(Common.Log.Level.INFORMATION, "set Image");
                        PbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                    }
                    catch (Exception ex)
                    {
                        PbPhoto.Image = ClassManager.Properties.Resources.img;
                        Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for member : " + objStudentMaster.AdmisionNo, Common.ErrorLevel.INFORMATION);
                    }

                    if (studentFacilities.Rows.Count > 0)
                    {
                        

                        bool packageExpired = false;
                        DataRow[] drAddedPackages = studentFacilities.Select("Status='A'or Status='E'");
                        DataRow[] drActivePackages = studentFacilities.Select("Status='A'");

                        if (drAddedPackages.Length > 0)
                        {
                            int i = 1;
                            foreach (DataRow dr in drAddedPackages)
                            {
                                if (Convert.ToDateTime(dr.ItemArray[2]) < System.DateTime.Now.Date)
                                {
                                    packageExpired = true;
                                }
                                Common.Log.LogError(Common.Log.Level.INFORMATION, "setting Package Text.. ");
                                lblPackage.Text += (i + ". " + dr.ItemArray[0] + "  expiry date: " + Common.Formatter.FormatDate(Convert.ToDateTime(dr.ItemArray[2])).ToString()) + "\n";
                                i++;
                            }
                        }
                        else
                        {
                            lblPackage.Text = "No Active Package for the Member.";
                            lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                        }

                        //If not active package then disable user
                        if(drActivePackages != null && drActivePackages.Count() == 0)
                        {
                            enableDisableUser = false;
                        }

                        //Common.Log.LogError(Common.Log.Level.INFORMATION, "Checking for Expired Package and Depending change the colour of Screen ");
                        if (packageExpired == true & drActivePackages.Count()==0)
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
                            string color = Info.SysParam.getValue<string>(Info.SysParam.Parameters.ACTIVE_PKG_COLOR);


                            panelpopup.BackColor = Color.FromName(color);
                           // panelpopup.BackColor = Color.White;
                            lblPackage.ForeColor = ColorTranslator.FromHtml("#484b68");
                            lblOutfees.ForeColor = ColorTranslator.FromHtml("#484b68");
                            lblName.ForeColor = ColorTranslator.FromHtml("#484b68");
                        }

                    }
                    else
                    {
                        lblPackage.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString() + " has no more Active Packages.";
                        lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
                else
                {
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Started if the Application is the Class ");
                    //Current installation is ClassWise
                    lblName.Visible = false;
                    lblPackage.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblOutfees.Font = new Font("Arial", 12, FontStyle.Bold);
                    string folderPath = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH).ToString();
                    string photoPath = folderPath + "\\" + objStudentMaster.PhotoURL;

                    try
                    {
                        Common.Log.LogError(Common.Log.Level.INFORMATION, "setting the Image ");
                        PbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                    }
                    catch (Exception ex)

                    {

                        PbPhoto.Image = ClassManager.Properties.Resources.img;
                        Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for memeber : " + objStudentMaster.AdmisionNo, Common.ErrorLevel.INFORMATION);
                    }



                    if (studentFacilities.Rows.Count > 0)
                    {
                        lblOutfees.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString() + " has "+stackItem.status + ".\nCourse : " + objStudentMaster.Course.Standard.StandardName + "\nBatch : " + objStudentMaster.Course.Batch.Name + "\n";
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
                        lblOutfees.Text = objStudentMaster.Fname.ToString() + " " + objStudentMaster.Lname.ToString() + " has "+ stackItem.status + ".";
                        lblPackage.Text = ("No Course for " + objStudentMaster.Fname.ToString() + objStudentMaster.Lname.ToString());
                    }
                }

                lblDateTime.Text =   Common.Formatter.FormatDateTime(stackItem.dateTime);
                return enableDisableUser;
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
                Common.Log.LogError(Common.Log.Level.INFORMATION, "Load Faculty for PopScreen ");
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
                    lblPackage.Text = "Faculty has "+ stackItem.checkInStatus + ".";
                }
                else
                {
                    lblPackage.Text = "Instructor has " + stackItem.checkInStatus + ".";
                }

                string photoFolder = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);
                string photoPath = photoFolder + "\\" + objFaculty.PhotoURL.ToString();

                try
                {

                    PbPhoto.Image = new Bitmap(new Bitmap(photoPath), new Size(135, 135));
                }
                catch (Exception ex)
                {
                    PbPhoto.Image = ClassManager.Properties.Resources.img;
                    Common.Log.LogError("Photo doesnot exists at path " + photoPath + " for faculty : " + objFaculty.FacultyID, Common.ErrorLevel.INFORMATION);
                }

                lblDateTime.Text = stackItem.dateTime.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static FrmBiomPopup addItem(object item, DateTime dateTime,out bool enableDisableUser, int checkInStatus = 1)
        {
            if (myIntance == null || myIntance.IsDisposed == true)
            {
                myIntance = new FrmBiomPopup();
            }

            myIntance.formItems.Push(new StackItem(item, dateTime,checkInStatus));
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
