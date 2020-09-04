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
using ClassManager.Info;

namespace ClassManager.WinApp
{
    public partial class FrmViewScheduleLect : FrmParentForm
    {
        public FrmViewScheduleLect()
        {
            InitializeComponent();
        }

        private void FrmViewScheduleLect_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetData(Student objStudent)
        {
            try
            {
                ADGVScheduledLect.DataSource = BLL.StudentHandller.getScheduledLect(objStudent.AdmissionNo);
                formatGrid();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void formatGrid()
        {
            try
            {

               // ADGVScheduledLect.Columns["From"].DefaultCellStyle.Format = Common.Formatter.TimeFormat;
               // ADGVScheduledLect.Columns["To"].DefaultCellStyle.Format = Common.Formatter.TimeFormat;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVScheduledLect_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in ADGVScheduledLect.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                ADGVScheduledLect.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ADGVScheduledLect_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                UICommon.WinForm.ADGVSerialNo(ADGVScheduledLect, e);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
