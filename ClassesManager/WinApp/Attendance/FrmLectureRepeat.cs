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

namespace ClassManager.WinApp
{
    public partial class FrmLectureRepeat : FrmParentForm
    {
        string sCaption = "Repeat Lecture";
        public FrmLectureRepeat()
        {
            InitializeComponent();
        }

        private void FrmLectureRepeat_Load(object sender, EventArgs e)
        {
            try
            {
                WinForm.formatDateTimePicker(dtpDate);
            }
            catch(Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }
        
        public string whichchecked()
        {
            if (rbtnDaily.Checked)
            {
                return "Daily";
            }
            else if (rbtnWeekly.Checked)
            {
                return "Weekly";
            }
            else if (rbtnMonthly.Checked)
            {
                return "Monthly";
            }
            else
            {
                return null;
            }
        }
        public DateTime tillToRepeat()
        {
            return dtpDate.Value;
        }
        private void formatDTP()
        {
            WinForm.formatDateTimePicker(dtpDate);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
