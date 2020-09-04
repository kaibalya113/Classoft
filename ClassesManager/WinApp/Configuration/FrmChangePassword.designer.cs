namespace ClassManager.WinApp
{
    partial class FrmChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNewPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtOldPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmdChangePassword = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.txtOldPassword);
            this.panel1.Controls.Add(this.cmdChangePassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 231);
            this.panel1.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Depth = 0;
            this.txtNewPassword.Hint = "Enter NewPassword";
            this.txtNewPassword.Location = new System.Drawing.Point(202, 88);
            this.txtNewPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '\0';
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.SelectionLength = 0;
            this.txtNewPassword.SelectionStart = 0;
            this.txtNewPassword.Size = new System.Drawing.Size(201, 23);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.TabStop = false;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Depth = 0;
            this.txtOldPassword.Hint = "Enter OldPassword";
            this.txtOldPassword.Location = new System.Drawing.Point(202, 24);
            this.txtOldPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '\0';
            this.txtOldPassword.SelectedText = "";
            this.txtOldPassword.SelectionLength = 0;
            this.txtOldPassword.SelectionStart = 0;
            this.txtOldPassword.Size = new System.Drawing.Size(197, 23);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.TabStop = false;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // cmdChangePassword
            // 
            this.cmdChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdChangePassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdChangePassword.BackColor = System.Drawing.Color.White;
            this.cmdChangePassword.Depth = 0;
            this.cmdChangePassword.Location = new System.Drawing.Point(141, 145);
            this.cmdChangePassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdChangePassword.Name = "cmdChangePassword";
            this.cmdChangePassword.Primary = true;
            this.cmdChangePassword.Size = new System.Drawing.Size(145, 46);
            this.cmdChangePassword.TabIndex = 3;
            this.cmdChangePassword.Text = "Change Password";
            this.cmdChangePassword.UseVisualStyleBackColor = false;
            this.cmdChangePassword.Click += new System.EventHandler(this.cmdChangePassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(36, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password :";
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(483, 297);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton cmdChangePassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNewPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOldPassword;
    }
}
