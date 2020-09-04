using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HerambCoachingClasses.Common;

namespace HerambCoachingClasses.WinApp
{
    public partial class EnquiryRegister : Form
    {
        public EnquiryRegister()
        {
            InitializeComponent();
        }

        private void EnquiryRegister_Load(object sender, EventArgs e)
        {
            Style.FormButtonStyle(this);
        }

        private void txtSName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.upperCharOnly(e);
        }

        private void btnReload_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnReload_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }


        public void load_Enquiries()
        {
            try
            {

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


    }
}
