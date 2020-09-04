using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.Info;

namespace ClassManager.BioMonitor
{
    public partial class Login : Form
    {
        string sCaption = "Login";
        public static int Branch_Id;

        public Login()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)        
        {
            int no_login = ClassManager.Info.SysParam.getValue<Int32>(SysParam.Parameters.NO_OF_LOGINS);        
            if (no_login > 0)
            {
                if (loginUser() == true)
                {
                    RTEventsMain eventForm = new RTEventsMain();
                    this.Visible = false;
                    eventForm.Visible = true;
                }
               
            }
            else
            {
                MessageBox.Show("Trial expired.");
            }
        }

        private bool loginUser()
        {
            try
            {

                if (txtUsername.Text.Length == 0 && txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("Please enter username and password.");
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    return false;
                }
                else
                {
                 
                    User objUser = new User();

                    objUser = ClassManager.BLL.LoginHandller.LoginUser(txtUsername.Text, txtPassword.Text.ToString(), SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID));

                    if (objUser == null)
                    {
                        MessageBox.Show("Invalid Username or Password");
                        txtPassword.Text = "";
                        txtPassword.Focus();
                        return false;
                    }
                    else
                    {   
                        objUser.BranchId =  ((ClassManager.Info.Branch)cmbBranch.SelectedItem).BranchId;
                        objUser.BranchName = cmbBranch.Text;
                        Program.LoggedInUser = objUser;
                        return true;

                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Following error occured\n\n" + ex.Message + "\n\nPlease contact System Admin if problem persists", "Error has Occured");
                return false;
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = Color.FromArgb(52, 75, 104);
                this.Text = "Class Manager";

                cmbBranch.DisplayMember = "Name";
                cmbBranch.ValueMember = "BranchId";
                cmbBranch.DataSource = ClassManager.BLL.BranchHandler.getBranches();

                ClassManager.Info.Branch currentBranch = ClassManager.BLL.BranchHandler.getBranch(SysParam.getValue<int>(SysParam.Parameters.SW_BRANCH_ID));
                cmbBranch.Text = currentBranch.BranchName;

                if (SysParam.getValue<bool>(SysParam.Parameters.ALLOW_BRANCH_SELECTION))
                {
                    cmbBranch.Enabled = true;
                }
                else
                {
                    cmbBranch.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Something went wrong, Please contact support", "BioMonitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Configure Database Properly", "BioMonitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {  
                Application.Exit();
            }
            catch (Exception )
            {
                throw;
            }
        }

        private void linkConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           if (txtUsername.Text.Length == 0 && txtPassword.Text.Length == 0)
           {
               MessageBox.Show("Please enter username and password.");
           }         
 

           else if(txtUsername.Text == "SystemAdmin" && txtPassword.Text == "satylaxman")
           
            {
                Config conf = Config.getInstance();
                conf.Visible = true;
            }
        }
        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginUser();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        
    }
}
