namespace ClassManager.WinApp
{
    partial class FrmViewAccount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkBranchID = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ADGVTransfer = new ADGV.AdvancedDataGridView();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVAccounts = new ADGV.AdvancedDataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTransfer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // chkBranchID
            // 
            this.chkBranchID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBranchID.AutoSize = true;
            this.chkBranchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBranchID.ForeColor = System.Drawing.Color.White;
            this.chkBranchID.Location = new System.Drawing.Point(377, 21);
            this.chkBranchID.Name = "chkBranchID";
            this.chkBranchID.Size = new System.Drawing.Size(170, 20);
            this.chkBranchID.TabIndex = 320;
            this.chkBranchID.Text = "Show All Branches Data";
            this.chkBranchID.UseVisualStyleBackColor = true;
            this.chkBranchID.CheckedChanged += new System.EventHandler(this.chkBranchID_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ADGVTransfer);
            this.panel2.Location = new System.Drawing.Point(13, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 238);
            this.panel2.TabIndex = 44;
            // 
            // ADGVTransfer
            // 
            this.ADGVTransfer.AllowUserToAddRows = false;
            this.ADGVTransfer.AllowUserToDeleteRows = false;
            this.ADGVTransfer.AllowUserToResizeColumns = false;
            this.ADGVTransfer.AllowUserToResizeRows = false;
            this.ADGVTransfer.AutoGenerateContextFilters = true;
            this.ADGVTransfer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVTransfer.DateWithTime = false;
            this.ADGVTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVTransfer.Location = new System.Drawing.Point(0, 0);
            this.ADGVTransfer.Name = "ADGVTransfer";
            this.ADGVTransfer.ReadOnly = true;
            this.ADGVTransfer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ADGVTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVTransfer.Size = new System.Drawing.Size(622, 236);
            this.ADGVTransfer.TabIndex = 7;
            this.ADGVTransfer.TimeFilter = false;
            this.ADGVTransfer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVTransfer_CellContentClick);
            this.ADGVTransfer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVTransfer_DataBindingComplete);
            this.ADGVTransfer.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.advancedDataGridView2_RowPostPaint);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.ForeColor = System.Drawing.Color.White;
            this.btnCreateAccount.Image = global::ClassManager.Properties.Resources.bank;
            this.btnCreateAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateAccount.Location = new System.Drawing.Point(539, 76);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(98, 35);
            this.btnCreateAccount.TabIndex = 3;
            this.btnCreateAccount.Text = "CREATE";
            this.btnCreateAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::ClassManager.Properties.Resources.give_money;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(411, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "TRANSFER";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Depth = 0;
            this.btnUpdate.Location = new System.Drawing.Point(458, 28);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Primary = true;
            this.btnUpdate.Size = new System.Drawing.Size(124, 33);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ADGVAccounts);
            this.panel1.Location = new System.Drawing.Point(11, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 174);
            this.panel1.TabIndex = 43;
            // 
            // ADGVAccounts
            // 
            this.ADGVAccounts.AllowUserToAddRows = false;
            this.ADGVAccounts.AllowUserToDeleteRows = false;
            this.ADGVAccounts.AllowUserToResizeColumns = false;
            this.ADGVAccounts.AllowUserToResizeRows = false;
            this.ADGVAccounts.AutoGenerateContextFilters = true;
            this.ADGVAccounts.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVAccounts.DateWithTime = false;
            this.ADGVAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVAccounts.Location = new System.Drawing.Point(0, 0);
            this.ADGVAccounts.Name = "ADGVAccounts";
            this.ADGVAccounts.ReadOnly = true;
            this.ADGVAccounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ADGVAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVAccounts.Size = new System.Drawing.Size(625, 172);
            this.ADGVAccounts.TabIndex = 5;
            this.ADGVAccounts.TimeFilter = false;
            this.ADGVAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVAccounts_CellContentClick);
            this.ADGVAccounts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVAccounts_DataBindingComplete);
            this.ADGVAccounts.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVAccounts_RowPostPaint_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(13, 320);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 20);
            this.label11.TabIndex = 80;
            this.label11.Text = "Transfer Transaction :";
            // 
            // FrmViewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(653, 593);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewAccount";
            this.Load += new System.EventHandler(this.FrmViewAccount_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTransfer)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkBranchID;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdate;
        private ADGV.AdvancedDataGridView ADGVAccounts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView ADGVTransfer;
        private System.Windows.Forms.Label label11;
    }
}
