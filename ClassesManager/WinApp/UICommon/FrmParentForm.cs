using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.BLL;

namespace ClassManager.WinApp.UICommon
{
    public partial class FrmParentForm :  MaterialSkin.Controls.MaterialForm
    {
        /// <summary>
        /// Functionmaster details for loaded form
        /// </summary>
        public FunctionMaster formDetails;
        Size formSize;
        public List<Label> translatableLabels = new List<Label>();
        public List<MaterialSkin.Controls.MaterialSingleLineTextField> traslatableMaterialTextfiels = new List<MaterialSkin.Controls.MaterialSingleLineTextField>();
        public bool gridViewReadOnly = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmParentForm()
        {
            InitializeComponent();
           
        }

        private void FrmParentForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                formSize = this.Size;

                if (this.Tag != null && this.Tag.ToString() != "") 
                {
                    int functionId = Convert.ToInt32(this.Tag.ToString());
                    formDetails = FormFactory.functionMaster.Where(functionMaster => functionMaster.ID == functionId).FirstOrDefault<FunctionMaster>();

                    if (formDetails != null)
                    {
                        this.Text = Lang.translate(formDetails.Name.Replace("&",""));
                    }
                }
               
                translateFormText();
                formatControls();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private void formatControls()
        {
            foreach(DateTimePicker dateTimePicker in GetAll(this,typeof(DateTimePicker)))
            {
                UICommon.WinForm.formatDateTimePicker(dateTimePicker, Common.Formatter.DateFormat);
            }

            foreach (ADGV.AdvancedDataGridView dataGridView in GetAll(this, typeof(ADGV.AdvancedDataGridView)))
            {
                dataGridView.ReadOnly = gridViewReadOnly;
                dataGridView.RowTemplate.Height = 30;
                dataGridView.RowTemplate.MinimumHeight = 30;

                dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }

            foreach (SuperGrid dataGridView in GetAll(this, typeof(SuperGrid)))
            {
                dataGridView.ReadOnly = gridViewReadOnly;
                dataGridView.RowTemplate.Height = 30;
                dataGridView.RowTemplate.MinimumHeight = 30;

                dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }



        }

        private void translateFormText()
        {
            foreach(Label lbl in translatableLabels)
            {
                lbl.Text = Lang.translate(lbl.Name);
            }

            foreach(MaterialSkin.Controls.MaterialSingleLineTextField textfield in traslatableMaterialTextfiels)
            {
                textfield.Hint = Lang.translate(textfield.Name);
            }
            
        }

        protected  void reloadForm()
        {
            
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
