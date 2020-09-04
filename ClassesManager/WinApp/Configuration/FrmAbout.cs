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
using System.Diagnostics;

namespace ClassManager.WinApp
{
    public partial class FrmAbout : FrmParentForm
    {

        string sCaption = "About Us";
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            try
            {
                lblAboutUs.Text = "     Accunity Services (Insteel Group of Company), specialized in providing innovative web solution \n to its elaborative customer base. Mobile App Development, Web Application Development,\n Email Marketing and Website development in mumbai are some of the verticals we specialize in.\n\n     We have earned the pride of being leading web solution provider in India and our clients and\n our work speak for us. Business needs can be met only when technology is in sync with service.\n\n    At Accunity Services we provide multi-dimensional IT services that would cater to high-end \n internet strategy, software development and design solutions for corporate clients all across \n the globe.";
                lblAboutUs.MaximumSize = new Size(1000, 0);
                lblAboutUs.AutoSize = true;
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
        
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void lnkUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("www.web.accunityservices.com");
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
