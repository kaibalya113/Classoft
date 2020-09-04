using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace ClassManager.BioMonitor
{
    public partial class Config : Form
    {
        public static Config configForm;
        public Config()
        {
            InitializeComponent();
        }



        public static Config getInstance()
        {
            if (configForm == null || configForm.IsDisposed)
                configForm = new Config();
            return configForm;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb = ClassManager.BLL.DBHandller.getConnectionStringBuilder();
                txtIniCat.Text = sb.InitialCatalog;
                txtUsername.Text = sb.UserID;
                txtPassword.Text = sb.Password;
                txtIP.Text = sb.DataSource;


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();
                conBuilder.InitialCatalog = txtIniCat.Text;
                conBuilder.DataSource = txtIP.Text;
                conBuilder.UserID = txtUsername.Text;
                conBuilder.Password = txtPassword.Text;

                if (BLL.DBHandller.checkDBConnectivity(conBuilder))
                {
                    ClassManager.BLL.DBHandller.saveDBConfig(conBuilder);
                    MessageBox.Show("Settings updated successfully", "Configuration");
                }
                else
                {
                    MessageBox.Show("Invalid Setting", "Configuration");
                }

                RTEventsMain objnew = new RTEventsMain();
                objnew.Visible = true;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while writing configuration, Please Contact Support", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

