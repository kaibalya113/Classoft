namespace ClassManager.WinApp
{
    partial class FrmAssignPermissions
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ADGVPrivileges = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNew = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkViewAllBranch = new System.Windows.Forms.CheckBox();
            this.chkAllView = new System.Windows.Forms.CheckBox();
            this.chkAllCreate = new System.Windows.Forms.CheckBox();
            this.chkAllModify = new System.Windows.Forms.CheckBox();
            this.chkAllDelete = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVPrivileges)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ADGVPrivileges);
            this.panel2.Location = new System.Drawing.Point(3, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 442);
            this.panel2.TabIndex = 11;
            // 
            // ADGVPrivileges
            // 
            this.ADGVPrivileges.AllowUserToAddRows = false;
            this.ADGVPrivileges.AllowUserToResizeRows = false;
            this.ADGVPrivileges.AutoGenerateContextFilters = true;
            this.ADGVPrivileges.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVPrivileges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVPrivileges.ColumnHeadersHeight = 35;
            this.ADGVPrivileges.DateWithTime = false;
            this.ADGVPrivileges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVPrivileges.Location = new System.Drawing.Point(0, 0);
            this.ADGVPrivileges.Name = "ADGVPrivileges";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVPrivileges.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVPrivileges.RowHeadersWidth = 50;
            this.ADGVPrivileges.Size = new System.Drawing.Size(789, 442);
            this.ADGVPrivileges.TabIndex = 19;
            this.ADGVPrivileges.TimeFilter = true;
            this.ADGVPrivileges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVPrivileges_CellContentClick);
            this.ADGVPrivileges.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVPrivileges_DataBindingComplete);
            this.ADGVPrivileges.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVPrivileges_DataError);
            this.ADGVPrivileges.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVPrivileges_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.chkViewAllBranch);
            this.panel1.Controls.Add(this.chkAllView);
            this.panel1.Controls.Add(this.chkAllCreate);
            this.panel1.Controls.Add(this.chkAllModify);
            this.panel1.Controls.Add(this.chkAllDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbRoles);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 97);
            this.panel1.TabIndex = 6;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Depth = 0;
            this.btnUpdate.Location = new System.Drawing.Point(667, 16);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Primary = true;
            this.btnUpdate.Size = new System.Drawing.Size(82, 33);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNew.BackColor = System.Drawing.Color.Pink;
            this.btnNew.Depth = 0;
            this.btnNew.Location = new System.Drawing.Point(554, 16);
            this.btnNew.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNew.Name = "btnNew";
            this.btnNew.Primary = true;
            this.btnNew.Size = new System.Drawing.Size(82, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New Role";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // chkViewAllBranch
            // 
            this.chkViewAllBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkViewAllBranch.AutoSize = true;
            this.chkViewAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAllBranch.ForeColor = System.Drawing.Color.White;
            this.chkViewAllBranch.Location = new System.Drawing.Point(647, 64);
            this.chkViewAllBranch.Name = "chkViewAllBranch";
            this.chkViewAllBranch.Size = new System.Drawing.Size(15, 14);
            this.chkViewAllBranch.TabIndex = 8;
            this.chkViewAllBranch.UseVisualStyleBackColor = true;
            this.chkViewAllBranch.CheckedChanged += new System.EventHandler(this.chkViewAllBranch_CheckedChanged);
            // 
            // chkAllView
            // 
            this.chkAllView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllView.AutoSize = true;
            this.chkAllView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllView.ForeColor = System.Drawing.Color.White;
            this.chkAllView.Location = new System.Drawing.Point(233, 64);
            this.chkAllView.Name = "chkAllView";
            this.chkAllView.Size = new System.Drawing.Size(15, 14);
            this.chkAllView.TabIndex = 4;
            this.chkAllView.UseVisualStyleBackColor = true;
            this.chkAllView.CheckedChanged += new System.EventHandler(this.chkAllView_CheckedChanged);
            // 
            // chkAllCreate
            // 
            this.chkAllCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllCreate.AutoSize = true;
            this.chkAllCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllCreate.ForeColor = System.Drawing.Color.White;
            this.chkAllCreate.Location = new System.Drawing.Point(554, 64);
            this.chkAllCreate.Name = "chkAllCreate";
            this.chkAllCreate.Size = new System.Drawing.Size(15, 14);
            this.chkAllCreate.TabIndex = 7;
            this.chkAllCreate.UseVisualStyleBackColor = true;
            this.chkAllCreate.CheckedChanged += new System.EventHandler(this.chkAllCreate_CheckedChanged);
            // 
            // chkAllModify
            // 
            this.chkAllModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllModify.AutoSize = true;
            this.chkAllModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllModify.ForeColor = System.Drawing.Color.White;
            this.chkAllModify.Location = new System.Drawing.Point(338, 64);
            this.chkAllModify.Name = "chkAllModify";
            this.chkAllModify.Size = new System.Drawing.Size(15, 14);
            this.chkAllModify.TabIndex = 5;
            this.chkAllModify.UseVisualStyleBackColor = true;
            this.chkAllModify.CheckedChanged += new System.EventHandler(this.chkAllModify_CheckedChanged);
            // 
            // chkAllDelete
            // 
            this.chkAllDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllDelete.AutoSize = true;
            this.chkAllDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDelete.ForeColor = System.Drawing.Color.White;
            this.chkAllDelete.Location = new System.Drawing.Point(447, 64);
            this.chkAllDelete.Name = "chkAllDelete";
            this.chkAllDelete.Size = new System.Drawing.Size(15, 14);
            this.chkAllDelete.TabIndex = 6;
            this.chkAllDelete.UseVisualStyleBackColor = true;
            this.chkAllDelete.CheckedChanged += new System.EventHandler(this.chkAllDelete_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Select All";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(109, 21);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(167, 24);
            this.cmbRoles.TabIndex = 1;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Role";
            // 
            // FrmAssignPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmAssignPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignPermissions";
            this.Load += new System.EventHandler(this.FrmAssignPermissions_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVPrivileges)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView ADGVPrivileges;
        private System.Windows.Forms.CheckBox chkAllView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkViewAllBranch;
        private System.Windows.Forms.CheckBox chkAllCreate;
        private System.Windows.Forms.CheckBox chkAllDelete;
        private System.Windows.Forms.CheckBox chkAllModify;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdate;
        private MaterialSkin.Controls.MaterialRaisedButton btnNew;
    }
}