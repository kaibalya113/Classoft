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

namespace ClassManager.WinApp.Popups
{
    public partial class FrmHelpForm : FrmParentForm
    {

        string sCaption = "HelpDesk";
        private static FrmHelpForm Instance;
        int branchId = WinApp.Program.LoggedInUser.BranchId;
        public FrmHelpForm()
        {
            InitializeComponent();
        }
        internal static FrmHelpForm MyInstance()
        {
            if (Instance == null)
            {
                Instance = new FrmHelpForm();
            }

            return Instance;
        }
        private void Frm_Help_Form_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
