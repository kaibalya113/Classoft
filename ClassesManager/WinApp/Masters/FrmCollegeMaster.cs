using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassManager.WinApp
{
    public partial class FrmCollegeMaster : Form
    {
        DataTable dtColleges;
        const string sCaption = "College Master";

        public FrmCollegeMaster()
        {
            InitializeComponent();
        }

        private void CollegeMaster_Load(object sender, EventArgs e)
        {
            try
            {
               loadColleges();
            }
            catch (Exception)
            {
                UICommon.WinForm.showStatus("Error occured loading colleges.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
                this.Enabled = false;
            }
        }

        private void loadColleges()
        {
            dtColleges = BLL.StandardHandller.GetCollegeName();

            grdClgs.DataSource = dtColleges;
        }

        private void cmdAddClg_Click(object sender, EventArgs e)
        {

            if (dtColleges.Select("CLG_NAME='" + txtClgName.Text + "'").Count() > 0)
            {
                UICommon.WinForm.showStatus("College already exists.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            else
            {
                if (BLL.StandardHandller.addCollege(txtClgName.Text, txtStandards.Text) == true)
                {
                    UICommon.WinForm.showStatus("College added successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    loadColleges();
                }

            }
        }
    }
}
