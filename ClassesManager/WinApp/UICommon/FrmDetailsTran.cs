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

namespace ClassManager.WinApp.UICommon
{
    public partial class FrmDetailsTran : FrmParentForm
    {
        public FrmDetailsTran()
        {
            InitializeComponent();
        }
        public void SetData(string transID)
        {
            try
            {

                //   ADGVInstDetails.DataSource = BLL.FeesHandller.getTransaction(transID);
                DataTable dt = BLL.FeesHandller.getTransaction(transID);
                ADGVInstDetails.DataSource = BLL.FeesHandller.getCheque(transID);
                ADGVInstDetails.ReadOnly = true;
                formatFacilityGrid();
                //foreach(DataRowView dt in ADGVInstDetails.DataSource)
                //{

                //                }
                AdmissionTxt.Text = dt.Rows[0]["TRNC_ADMISSION_NO"].ToString();
                ModeTxt.Text = dt.Rows[0]["TRNC_PAYMENT_MODE"].ToString();
                DateTxt.Text = dt.Rows[0]["TRNC_DATE"].ToString();
                AmountTxt.Text = dt.Rows[0]["TRNC_AMOUNT"].ToString();
                // if()
                // PAYTxt.Text = dt.Rows[0]["PD_REFERANCE_NO"].ToString();
                PAYTxt.Visible = false;
                label10.Visible = false;
                if (ADGVInstDetails.Rows.Count > 0){}
                else
                {
                    ADGVInstDetails.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void formatFacilityGrid()
        {
            try
            {
                ADGVInstDetails.ReadOnly = true;
                
                if (ADGVInstDetails.Columns.Contains("CHQ_ID"))
                {
                    ADGVInstDetails.Columns["CHQ_ID"].HeaderText = "iID ";
                    ADGVInstDetails.Columns["CHQ_ID"].Visible = false;
                    AdmissionTxt.Text = ADGVInstDetails.Columns["CHQ_ID"].ToString();
                    
                }

                if (ADGVInstDetails.Columns.Contains("CHQ_NO"))
                {
                    ADGVInstDetails.Columns["CHQ_NO"].HeaderText = "NO ";
                    ADGVInstDetails.Columns["CHQ_NO"].ReadOnly = true;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_DATE"))
                {
                    ADGVInstDetails.Columns["CHQ_DATE"].HeaderText = "DATE";
                    ADGVInstDetails.Columns["CHQ_DATE"].ReadOnly = true;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_BANK_NAME"))
                {
                    ADGVInstDetails.Columns["CHQ_BANK_NAME"].HeaderText = "BANK NAME";
                    ADGVInstDetails.Columns["CHQ_BANK_NAME"].ReadOnly = true;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_BANK_BRANCH"))
                {
                    ADGVInstDetails.Columns["CHQ_BANK_BRANCH"].HeaderText = "BRANCH";
                    ADGVInstDetails.Columns["CHQ_BANK_BRANCH"].ReadOnly = true;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_BOUNCE_CHARGES"))
                {
                    ADGVInstDetails.Columns["CHQ_BOUNCE_CHARGES"].HeaderText = "BOUNCE CHARGES";
                    ADGVInstDetails.Columns["CHQ_BOUNCE_CHARGES"].ReadOnly = true;
                    ADGVInstDetails.Columns["CHQ_BOUNCE_CHARGES"].Width = 200;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_AMOUNT"))
                {
                    ADGVInstDetails.Columns["CHQ_AMOUNT"].HeaderText = "AMOUNT";
                    ADGVInstDetails.Columns["CHQ_AMOUNT"].ReadOnly = true;
                  //  ADGVInstDetails.Columns["CHQ_AMOUNT"].Width = 200;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_STATUS"))
                {
                    ADGVInstDetails.Columns["CHQ_STATUS"].HeaderText = "STATUS";
                    ADGVInstDetails.Columns["CHQ_STATUS"].ReadOnly = true;
                 //   ADGVInstDetails.Columns["CHQ_STATUS"].Width = 200;
                }
                if (ADGVInstDetails.Columns.Contains("CHQ_CRTD_AT"))
                {
                    ADGVInstDetails.Columns["CHQ_CRTD_AT"].HeaderText = "CREATED";
                    ADGVInstDetails.Columns["CHQ_CRTD_AT"].ReadOnly = true;
                 //   ADGVInstDetails.Columns["CHQ_CRTD_AT"].Width = 200;
                }
                // ADGVInstDetails.Columns[2].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                //  ADGVInstDetails.Columns[0].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
                //Mohan(2-Dec-2017).
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmDetailsTran_Load(object sender, EventArgs e)
        {
           // SetData();
          
        }

       

        private void ADGVInstDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.ReadOnly = true;
        }

       
    }
}