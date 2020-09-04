using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.Info;
using System.Threading;

namespace ClassManager.BioMonitor
{
    static class Program
    {
        public static User LoggedInUser;

        //Mohan(05-Dec-2017).
        static Mutex mutex = new Mutex(false, "BioMonitor");
        //Mohan(05-Dec-2017).

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()


        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                MessageBox.Show("Application is already Running!", "BioMonitor", MessageBoxButtons.OK);
                return;
            }
            try
            {
                runApp();
            }
            finally { mutex.ReleaseMutex(); }
            //Mohan(05-Dec-2017).
        }

        public static void runApp()
        {
            try
            {
                BLL.SystemParameterHandler.loadSystemParameter();
                BLL.TemplateHandler.loadTemplates();
                autoLogin();
                Application.Run(new RTEventsMain());

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                Application.Run(new Login());
            }
        }


        public static void autoLogin()
        {     
            User objUser = new User();
            objUser.BranchId = ClassManager.Info.SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID);
            objUser.BranchName = objUser.BranchId.ToString();
            Program.LoggedInUser = objUser;
        }

        public static void exit()
        {
            Application.Exit();
        }
    }
}
