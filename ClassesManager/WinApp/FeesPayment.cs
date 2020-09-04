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
    public partial class FeesPayment : Form
    {
        public FeesPayment()
        {
            InitializeComponent();
        }

        private void FeesPayment_Load(object sender, EventArgs e)
        {
            Style.FormButtonStyle(this);
        }

        private void cmbSName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.charOnly(e);
        }

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.numOnly(e);
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }
    }
}
