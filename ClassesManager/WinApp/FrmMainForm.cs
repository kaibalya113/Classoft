using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ClassManager.BLL;
using ClassManager.WinApp;

namespace ClassManager.WinApp
{
    public partial class FrmMainForm : Form
    {

        public string sCaption = "Class Manager";
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();

        public FrmMainForm()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

        public FrmMainForm(string LoginType)
        {
            InitializeComponent();

        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        //This method syncs the data
        public static void syncData()
        {
            try
            {
                int branchId = SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID);
                //Import All data
                //DBSyncService.Program.Main(new string[] { "sync", branchId.ToString() });

                //Reset SW_BRANCH_ID
                BLL.SystemParameterHandler.updateSysParam(Info.SysParam.Parameters.SW_BRANCH_ID, branchId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string branchName = WinApp.Program.LoggedInUser.BranchName;

                createMenus();
                string Reg = Info.SysParam.getValue<String>(SysParam.Parameters.LICENCE_KEY);
                if (Reg == "DEMO")
                {
                    this.Text = "DEMO Version :" + Info.SysParam.getValue<String>(SysParam.Parameters.APP_NAME) + " " + Info.SysParam.getValue<String>(SysParam.Parameters.NAME) + " " + Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS) + " BranchName : " + branchName;
                    // this.Font = new Font("Microsoft Sans Serif", 12);

                }
                else
                {
                    this.Text = "REGISTERED :" + Info.SysParam.getValue<String>(SysParam.Parameters.APP_NAME) + " " + Info.SysParam.getValue<String>(SysParam.Parameters.NAME) + " " + Info.SysParam.getValue<String>(SysParam.Parameters.ADDRESS) + " BranchName : " + branchName;
                    // this.Font = new Font("Microsoft Sans Serif", 12);
                }
                tslblUserName.Text = BLL.UserHandler.loggedInUser.UserId + "@" + BLL.UserHandler.loggedInUser.BranchName;
                tslblBranch.Text = "Branch :" + SysParam.getValue<string>(SysParam.Parameters.SW_BRANCH_NAME);
                tslblDate.Text = DateTime.Now.ToString(Common.Formatter.DateFormat);


                //Check Configuartion Paths in SystemParameter. Mohan(05-july-2017).
                checkPaths();
                disoutDueOnload();
                //Loads followup on Load only.
                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) != "Asset")
                {
                    // Dashboard();
                    dispollowupsonload();
                    if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == "Gym" || Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == "Dance")
                    {
                        dispRenewalonLoad();
                    }
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        /// <summary>
        /// Check Paths. Mohan(05-July-2017.)
        /// </summary>
        private void checkPaths()
        {
            try
            {
                StringBuilder popup = new StringBuilder();

                //Fetching Database Name.
                SqlConnectionStringBuilder connPath = BLL.DBHandller.getConnectionStringBuilder();
                string Database = connPath["Database"] as string;

                //Variable to identify Server is in LOCAL or in REMOTE Machine.
                string mode = SysParam.getValue<string>(SysParam.Parameters.APP_RUNNING_MODE);

                if (mode == "REMOTE")
                {
                    popup.Append("Warning :" + System.Environment.NewLine + "Please Provide Valid ");
                    try
                    {
                        this.BackgroundImage = new Bitmap(Info.SysParam.getValue<String>(SysParam.Parameters.MAIN_FORM_IMAGE));
                    }
                    catch (Exception ex)
                    {
                        popup.Append("Main Screen Image, ");
                    }

                    if (!Directory.Exists(MappedDriveResolver.GetUNCPath(SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH))))
                    {
                        popup.Append("Photo Path, ");
                    }

                    if (!File.Exists(MappedDriveResolver.GetUNCPath(SysParam.getValue<string>(SysParam.Parameters.LOGO_PATH))))
                    {
                        popup.Append("Logo Path, ");
                    }

                    if (!Directory.Exists(MappedDriveResolver.GetUNCPath(SysParam.getValue<string>(SysParam.Parameters.DB_BACKUP_PATH))))
                    {
                        popup.Append("DB_BACK_UP Path.");
                    }

                    if (SysParam.getValue<string>(SysParam.Parameters.DB_NAME) != Database)
                    {
                        if (popup.Length != 32)
                        {
                            popup.Clear();
                            popup.Append("Warning :");
                        }
                        popup.Append(Environment.NewLine + Environment.NewLine + "Invalid Database Name in SystemParameter.");
                    }
                }

                else if (mode == "LOCAL")
                {
                    popup.Append("Warning :" + System.Environment.NewLine + "Please Provide Valid ");
                    try
                    {
                        this.BackgroundImage = new Bitmap(Info.SysParam.getValue<String>(SysParam.Parameters.MAIN_FORM_IMAGE));
                    }
                    catch (Exception ex)
                    {
                        popup.Append("Main Screen Image, ");
                    }

                    if (!Directory.Exists(SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH)))
                    {
                        popup.Append("Photo Path, ");
                    }

                    if (!File.Exists(SysParam.getValue<string>(SysParam.Parameters.LOGO_PATH)))
                    {
                        popup.Append("Logo Path, ");
                    }

                    if (!Directory.Exists(SysParam.getValue<string>(SysParam.Parameters.DB_BACKUP_PATH)))
                    {
                        popup.Append("DB_BACK_UP Path.");
                    }

                    if (SysParam.getValue<string>(SysParam.Parameters.DB_NAME) != Database)
                    {
                        if (popup.Length != 32)
                        {
                            popup.Clear();
                            popup.Append("Warning :");
                        }
                        popup.Append(Environment.NewLine + Environment.NewLine + "Invalid Database Name in SystemParameter.");
                    }
                }
                if (popup.Length != 32)
                {
                    UICommon.WinForm.showStatus(popup.ToString(), sCaption, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //This Part is to show All FollowUps on Load only.
        private void dispRenewalonLoad()
        {
            try
            {
                DataTable renewexp;
                DataTable renewTobeExp;
                renewexp = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 0);
                renewTobeExp = BLL.FeesHandller.getRenewalOnLoad(Program.LoggedInUser.BranchId.ToString(), 1);
                if (renewexp.Rows.Count != 0 || renewTobeExp.Rows.Count != 0)
                {
                    FrmExpiredRenewal objexpire = (FrmExpiredRenewal)UICommon.FormFactory.GetForm(Forms.FrmExpiredRenewal, this.MdiParent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void disoutDueOnload()
        {
            try
            {   
                if (FrmOutstandingDueFollowup.chooseView() != -1)
                {
                    FrmOutstandingDueFollowup objpopup = (FrmOutstandingDueFollowup)UICommon.FormFactory.GetForm(Forms.FrmOutstandingDueFollowup, this.MdiParent);
                    objpopup.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void dispollowupsonload()
        {
            try
            {

                DataTable dt = FollowupHandler.getFolloups(Program.LoggedInUser.BranchId.ToString(), BLL.DBHandller.getMinSQLDate(), System.DateTime.Now.AddDays(-1));
                if (dt.Rows.Count > 0)
                {
                    FrmFollowReport objpopup = (FrmFollowReport)UICommon.FormFactory.GetForm(Forms.FrmFollowReport, this.MdiParent);
                    objpopup.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Dashboard()
        {
            try
            {
                FrmDashBoard objpopup = (FrmDashBoard)UICommon.FormFactory.GetForm(Forms.FrmDashBoard, this.MdiParent);
                objpopup.Visible = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void createMenus()
        {

            foreach (FunctionMaster objFunction in FormFactory.functionMaster.Where(function => function.LevelIndicator == "M").OrderBy(function => function.GroupSeqno).ToList<FunctionMaster>())
            {
                if (Program.LoggedInUser.privileges.Any(prv => prv.FunctionId == objFunction.ID && prv.View == true))
                {

                    if (objFunction.LevelIndicator != "L" && FormFactory.functionMaster.Count(fun => fun.ParentId == objFunction.ID) > 0)
                    {

                        ToolStripMenuItem menuItem = new ToolStripMenuItem();
                        menuItem.Name = objFunction.Name;
                        menuItem.Text = Lang.translate(objFunction.Name);
                        menuItem.Tag = new String[] { objFunction.FormClass, objFunction.ID.ToString(), objFunction.FormAssembly, objFunction.ParentId.ToString(), objFunction.AppName };

                        if (objFunction.LevelIndicator.Equals("M"))
                        {
                            menuItem.Click += new EventHandler(menuItem_Click);
                        }

                        Keys shortcutKey;
                        if (Enum.TryParse<Keys>(objFunction.ShortcutKey, out shortcutKey) == true)
                        {
                            // menuItem.ShortcutKeys = Keys.E;
                        }
                        createSubMenu(objFunction, menuItem);
                        mainMenu.Items.Add(menuItem);
                    }
                }
            }

            //createHelpMenu();
        }

        private void createHelpMenu()
        {
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";

            mainMenu.Items.Add(helpToolStripMenuItem);
        }

        private void createSubMenu(FunctionMaster parentFunction, ToolStripMenuItem parentMenu)
        {
            foreach (FunctionMaster objFunction in FormFactory.functionMaster.Where(function => function.ParentId == parentFunction.ID).OrderBy(function => function.GroupSeqno).ToList<FunctionMaster>())
            {
                if (Program.LoggedInUser.privileges.Any(prv => prv.FunctionId == objFunction.ID && prv.View == true))
                {

                    //if (objFunction.LevelIndicator != "L" && FormFactory.functionMaster.Count(fun => fun.ParentId == objFunction.ID) > 0)
                    //{

                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = objFunction.Name;
                    menuItem.Tag = new String[] { objFunction.FormClass, objFunction.ID.ToString(), objFunction.FormAssembly, objFunction.ParentId.ToString(), objFunction.AppName };
                    menuItem.Text = Lang.translate(objFunction.Name);


                    if (objFunction.LevelIndicator.Equals("L"))
                    {
                        menuItem.Click += new EventHandler(menuItem_Click);
                    }

                    Keys shortcutKey;
                    if (Enum.TryParse<Keys>(objFunction.ShortcutKey, out shortcutKey) == true)
                    {
                        // menuItem.ShortcutKeys = Keys.E;
                    }

                    createSubMenu(objFunction, menuItem);
                    parentMenu.DropDownItems.Add(menuItem);
                    //}
                }
            }
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms requestedForm;
                string[] formDetails = (string[])((sender as ToolStripMenuItem).Tag);
                string AppName = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);

                if (formDetails[4] == "Free" && AppName == "Free")
                {
                    if (Enum.TryParse<Forms>(formDetails[0], out requestedForm) == true)
                    {
                        Form formToShow = FormFactory.GetForm(requestedForm, this, false, formDetails[2].Split(','), formDetails[4]);

                        formToShow.Tag = formDetails[1];
                        formToShow.Visible = true;

                    }

                }

                else if (formDetails[4] == null && (AppName == "Gym" || AppName == "" || AppName == "Dance" || AppName == "Asset"))
                {
                    if (Enum.TryParse<Forms>(formDetails[0], out requestedForm) == true)
                    {
                        Form formToShow = FormFactory.GetForm(requestedForm, this, false, formDetails[2].Split(','), formDetails[4]);

                        formToShow.Tag = formDetails[1];
                        formToShow.TopMost = true;

                        formToShow.Show();

                        if (formToShow == null)
                        {
                            //filterForm = new FilterForm();
                            formToShow.FormClosed += delegate { formToShow = null; };
                            formToShow.Show();
                        }
                        else
                        {
                            formToShow.WindowState = FormWindowState.Normal;
                            formToShow.Focus();
                        }



                    }

                }

                else
                {

                    UICommon.WinForm.showStatus("Requested form cannot be displayed,As You Are Not Registered Member.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {
                WinForm.checkInternetConnection(ex, sCaption, null);
                //UICommon.WinForm.showError(ex, sCaption, this);
            }

        }
        private void bgwekerSendSMS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                UICommon.WinForm.showStatus("Error occured sending SMS \n\n" + e.Error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this.MdiParent);
            }
            else
            {
                UICommon.WinForm.showStatus("SMS send", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.R: FormFactory.GetForm(UICommon.Forms.FrmRegistrationForm, this).Visible = true; return true;
                case Keys.Alt | Keys.D: FormFactory.GetForm(UICommon.Forms.FrmStudentDetails, this).Visible = true; return true;
                case Keys.Alt | Keys.P: FormFactory.GetForm(UICommon.Forms.FrmFeesPayment, this).Visible = true; return true;
                case Keys.Alt | Keys.O: FormFactory.GetForm(UICommon.Forms.FrmOutstandingFees, this).Visible = true; return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        internal void setStatus(string status)
        {
            if (status.Contains("Message") && status.Contains("Sent"))
            {
                lbltoViewSMSReport.Visible = true;
            }
            else
            {
                lbltoViewSMSReport.Visible = false;
            }
            this.lblMessageProgress.Text = status;
        }

        private void FrmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {




                if (BLL.DBHandller.backUpDB())
                {
                    UICommon.WinForm.showStatus("Backup Done Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, "BackUp Status", this);
                }

                //Sync Changes with gitlab

                //syncData();


            }
            catch (Exception ex)
            {
                //UICommon.WinForm.showError(ex, sCaption, this, "Could not complete backup, Please contact support");
            }
            finally
            {
                FrmLogin.getInstance().Visible = true;
            }
        }

        private void ExpenseExcelSave()
        {

        }
        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Click To View")
            {
                Commongrid objSMSReport = (Commongrid)UICommon.FormFactory.GetForm(Forms.Commongrid, this, false);
                objSMSReport.Text = "Report";
                objSMSReport.bindSMSReport(MailHandler.smsReport);
                objSMSReport.Visible = true;
            }
        }




    }
}
