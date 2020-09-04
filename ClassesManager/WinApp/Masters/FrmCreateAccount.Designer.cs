namespace ClassManager.WinApp
{
    partial class FrmCreateAccount
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
            this.grpCreateAccount = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBalance = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.grpCreateAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCreateAccount
            // 
            this.grpCreateAccount.BackColor = System.Drawing.Color.White;
            this.grpCreateAccount.Controls.Add(this.btnSave);
            this.grpCreateAccount.Controls.Add(this.txtBalance);
            this.grpCreateAccount.Controls.Add(this.txtName);
            this.grpCreateAccount.Controls.Add(this.cmbType);
            this.grpCreateAccount.Controls.Add(this.lblBalance);
            this.grpCreateAccount.Controls.Add(this.lblType);
            this.grpCreateAccount.Controls.Add(this.lblName);
            this.grpCreateAccount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpCreateAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.grpCreateAccount.Location = new System.Drawing.Point(12, 70);
            this.grpCreateAccount.Name = "grpCreateAccount";
            this.grpCreateAccount.Size = new System.Drawing.Size(374, 244);
            this.grpCreateAccount.TabIndex = 34;
            this.grpCreateAccount.TabStop = false;
            this.grpCreateAccount.Text = "CreateAccount";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(113, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.Depth = 0;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Hint = "Enter Balance";
            this.txtBalance.Location = new System.Drawing.Point(133, 87);
            this.txtBalance.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.PasswordChar = '\0';
            this.txtBalance.SelectedText = "";
            this.txtBalance.SelectionLength = 0;
            this.txtBalance.SelectionStart = 0;
            this.txtBalance.Size = new System.Drawing.Size(177, 23);
            this.txtBalance.TabIndex = 2;
            this.txtBalance.TabStop = false;
            this.txtBalance.UseSystemPasswordChar = false;
            // 
            // txtName
            // 
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Hint = "Enter Name";
            this.txtName.Location = new System.Drawing.Point(133, 39);
            this.txtName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.Size = new System.Drawing.Size(181, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TabStop = false;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "CR",
            "DR"});
            this.cmbType.Location = new System.Drawing.Point(133, 141);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(166, 26);
            this.cmbType.TabIndex = 3;
            this.cmbType.Visible = false;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBalance.Location = new System.Drawing.Point(19, 87);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(108, 20);
            this.lblBalance.TabIndex = 34;
            this.lblBalance.Text = "Initial Balance";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblType.Location = new System.Drawing.Point(27, 141);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 33;
            this.lblType.Text = "Type";
            this.lblType.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblName.Location = new System.Drawing.Point(19, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 32;
            this.lblName.Text = "Name";
            // 
            // FrmCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 329);
            this.Controls.Add(this.grpCreateAccount);
            this.MaximizeBox = false;
            this.Name = "FrmCreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateAccount";
            this.Load += new System.EventHandler(this.FrmCreateAccount_Load);
            this.grpCreateAccount.ResumeLayout(false);
            this.grpCreateAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCreateAccount;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBalance;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtName;
        private System.Windows.Forms.Button btnSave;
    }
}