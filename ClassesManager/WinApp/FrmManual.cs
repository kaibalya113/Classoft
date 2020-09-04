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
using System.IO;
using System.Xml.Linq;

namespace ClassManager.WinApp
{
    public partial class FrmManual : FrmParentForm
    {
        string sCaption = "Manual";
        public FrmManual()
        {
            InitializeComponent();
        }

        private void FrmManual_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }

        }

        private void BindGrid()
        {
            try
            {
                string filename = Path.GetFileName(AppDomain.CurrentDomain.BaseDirectory + "Manual\\HelpManual.pdf");
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(ADGVManual, "1", filename, "Download");
                ADGVManual.Rows.Add(row);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AssignEvents()
        {
        }
        List<string> pdfFiles = new List<string>();
        private void ADGVManual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    //SaveFileDialog savePDF = new SaveFileDialog();
                    //savePDF.CheckFileExists = true;
                    //savePDF.AddExtension = true;
                    //savePDF.Filter = "PDF files (*.pdf)|*.pdf";

                    //if (savePDF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    pdfFiles = new List<string>();
                    //    foreach (string fileName in savePDF.FileNames)
                    //        pdfFiles.Add(fileName);
                    //}
                    savePDF.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string name = savePDF.FileName;
                System.IO.File.Copy(AppDomain.CurrentDomain.BaseDirectory + "Manual\\HelpManual.pdf", name);
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }

        }
    }
}
