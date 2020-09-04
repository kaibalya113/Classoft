namespace ClassManager.WinApp
{
    partial class FrmAccount
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
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabview = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkBranchID = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVAccounts = new System.Windows.Forms.DataGridView();
            this.tabcreate = new System.Windows.Forms.TabPage();
            this.grpCreateAccount = new System.Windows.Forms.GroupBox();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabview.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAccounts)).BeginInit();
            this.tabcreate.SuspendLayout();
            this.grpCreateAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabview);
            this.materialTabControl1.Controls.Add(this.tabcreate);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(4, 130);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(600, 301);
            this.materialTabControl1.TabIndex = 2;
            // 
            // tabview
            // 
            this.tabview.Controls.Add(this.panel2);
            this.tabview.Controls.Add(this.panel1);
            this.tabview.Location = new System.Drawing.Point(4, 22);
            this.tabview.Name = "tabview";
            this.tabview.Padding = new System.Windows.Forms.Padding(3);
            this.tabview.Size = new System.Drawing.Size(592, 275);
            this.tabview.TabIndex = 0;
            this.tabview.Text = "View";
            this.tabview.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.chkBranchID);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 56);
            this.panel2.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Depth = 0;
            this.button1.Location = new System.Drawing.Point(10, 8);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Primary = true;
            this.button1.Size = new System.Drawing.Size(82, 33);
            this.button1.TabIndex = 320;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkBranchID
            // 
            this.chkBranchID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBranchID.AutoSize = true;
            this.chkBranchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBranchID.Location = new System.Drawing.Point(407, 15);
            this.chkBranchID.Name = "chkBranchID";
            this.chkBranchID.Size = new System.Drawing.Size(170, 20);
            this.chkBranchID.TabIndex = 319;
            this.chkBranchID.Text = "Show All Branches Data";
            this.chkBranchID.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ADGVAccounts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 204);
            this.panel1.TabIndex = 41;
            // 
            // ADGVAccounts
            // 
            this.ADGVAccounts.BackgroundColor = System.Drawing.Color.White;
            this.ADGVAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVAccounts.Location = new System.Drawing.Point(0, 0);
            this.ADGVAccounts.Name = "ADGVAccounts";
            this.ADGVAccounts.Size = new System.Drawing.Size(586, 204);
            this.ADGVAccounts.TabIndex = 0;
            // 
            // tabcreate
            // 
            this.tabcreate.Controls.Add(this.grpCreateAccount);
            this.tabcreate.Location = new System.Drawing.Point(4, 22);
            this.tabcreate.Name = "tabcreate";
            this.tabcreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabcreate.Size = new System.Drawing.Size(592, 275);
            this.tabcreate.TabIndex = 1;
            this.tabcreate.Text = "Create";
            this.tabcreate.UseVisualStyleBackColor = true;
            // 
            // grpCreateAccount
            // 
            this.grpCreateAccount.BackColor = System.Drawing.Color.White;
            this.grpCreateAccount.Controls.Add(this.btnSave);
            this.grpCreateAccount.Controls.Add(this.cmbType);
            this.grpCreateAccount.Controls.Add(this.txtName);
            this.grpCreateAccount.Controls.Add(this.txtBalance);
            this.grpCreateAccount.Controls.Add(this.lblBalance);
            this.grpCreateAccount.Controls.Add(this.lblType);
            this.grpCreateAccount.Controls.Add(this.lblName);
            this.grpCreateAccount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpCreateAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.grpCreateAccount.Location = new System.Drawing.Point(35, 6);
            this.grpCreateAccount.Name = "grpCreateAccount";
            this.grpCreateAccount.Size = new System.Drawing.Size(524, 263);
            this.grpCreateAccount.TabIndex = 34;
            this.grpCreateAccount.TabStop = false;
            this.grpCreateAccount.Text = "CreateAccount";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(407, 194);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "CR",
            "DR"});
            this.cmbType.Location = new System.Drawing.Point(123, 136);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(166, 26);
            this.cmbType.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 26);
            this.txtName.TabIndex = 1;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(123, 82);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(166, 26);
            this.txtBalance.TabIndex = 2;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBalance.Location = new System.Drawing.Point(19, 84);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(95, 18);
            this.lblBalance.TabIndex = 34;
            this.lblBalance.Text = "Initial Balance";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblType.Location = new System.Drawing.Point(19, 136);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(38, 18);
            this.lblType.TabIndex = 33;
            this.lblType.Text = "Type";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblName.Location = new System.Drawing.Point(19, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 18);
            this.lblName.TabIndex = 32;
            this.lblName.Text = "Name";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BackColor = System.Drawing.Color.White;
            this.materialTabSelector1.BaseTabControl = null;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.ForeColor = System.Drawing.Color.White;
            this.materialTabSelector1.Location = new System.Drawing.Point(4, 66);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(600, 58);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "CREATE";
            // 
            // FrmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(609, 447);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.MaximizeBox = false;
            this.Name = "FrmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account";
            this.Load += new System.EventHandler(this.FrmAccount_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabview.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAccounts)).EndInit();
            this.tabcreate.ResumeLayout(false);
            this.grpCreateAccount.ResumeLayout(false);
            this.grpCreateAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabview;
        private System.Windows.Forms.TabPage tabcreate;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRaisedButton button1;
        private System.Windows.Forms.CheckBox chkBranchID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ADGVAccounts;
        private System.Windows.Forms.GroupBox grpCreateAccount;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
    }
}