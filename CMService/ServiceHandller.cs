using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManager.Info;


namespace ClassManager.CMService
{
    class ServiceHandller
    {
        public static void autoLogin(int branchId)
        {
            User objUser = new User();
            objUser.BranchId = branchId;
            objUser.BranchName = objUser.BranchId.ToString();
            Program.LoggedInUser = objUser;
        }

        internal static void connectBiometric(int branchId)
        {
            BLL.BiometricHandller.connectBiometric(branchId);
        }
    }
}
