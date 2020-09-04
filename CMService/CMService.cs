using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.CMService
{
    public partial class CMService : ServiceBase
    {
        public const string LOGFILENAME = "CMService";
        public static int branchId;

        public CMService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                branchId = Convert.ToInt32(ClassManager.Properties.Settings.Default.BranchId);
                ServiceHandller.autoLogin(branchId);
                ServiceHandller.connectBiometric(branchId);
            }
            catch (Exception ex)
            {
                ClassManager.Common.Log.LogError(ex, "CMService");
                ClassManager.Common.Log.LogError(Common.Log.Level.FATAL, "Existing Service", LOGFILENAME);
                this.Stop();
            }
            
        }

        protected override void OnStop()
        {
            try
            {
                BLL.BiometricHandller.disconnectDevice();
                ClassManager.Common.Log.LogError(Common.Log.Level.INFORMATION, "Service Stopped", LOGFILENAME);
            }
            catch (Exception ex)
            {
                ClassManager.Common.Log.LogError(ex, "CMService");
                ClassManager.Common.Log.LogError(Common.Log.Level.FATAL, "Existing Service", LOGFILENAME);
            }
        }
    }
}
