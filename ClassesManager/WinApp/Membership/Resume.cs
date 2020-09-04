using ClassManager.WinApp.UICommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassManager.WinApp.Membership
{
    public partial class Resume : FrmParentForm
    {
        public Resume()
        {
            InitializeComponent();
        }

        private void Resume_Load(object sender, EventArgs e)
        {
           // this.showFile();
        }

        internal void showFile(string resume)
        {
            axAcroPDF1.src = resume;
        }
    }
}
