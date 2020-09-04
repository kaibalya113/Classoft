namespace ClassManager.WinApp
{
    partial class FrmImportRegistration
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
            this.lblPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnUpload = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnRegister = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnValidate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkAssignCourse = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.adgvDataToImport = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDataToImport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPath.Location = new System.Drawing.Point(16, 34);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(90, 20);
            this.lblPath.TabIndex = 325;
            this.lblPath.Text = "File Path :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(9, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 554);
            this.panel1.TabIndex = 328;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.btnUpload);
            this.panel3.Controls.Add(this.btnRegister);
            this.panel3.Controls.Add(this.btnValidate);
            this.panel3.Controls.Add(this.chkAssignCourse);
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.lblPath);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 104);
            this.panel3.TabIndex = 398;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Depth = 0;
            this.txtPath.Enabled = false;
            this.txtPath.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtPath.Hint = "";
            this.txtPath.Location = new System.Drawing.Point(112, 36);
            this.txtPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.Size = new System.Drawing.Size(241, 23);
            this.txtPath.TabIndex = 1;
            this.txtPath.UseSystemPasswordChar = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpload.BackColor = System.Drawing.Color.White;
            this.btnUpload.Depth = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(373, 50);
            this.btnUpload.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Primary = true;
            this.btnUpload.Size = new System.Drawing.Size(82, 34);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.Depth = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(641, 48);
            this.btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Primary = true;
            this.btnRegister.Size = new System.Drawing.Size(103, 36);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register all";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnValidate.BackColor = System.Drawing.Color.White;
            this.btnValidate.Depth = 0;
            this.btnValidate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.Location = new System.Drawing.Point(475, 25);
            this.btnValidate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Primary = true;
            this.btnValidate.Size = new System.Drawing.Size(82, 34);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // chkAssignCourse
            // 
            this.chkAssignCourse.AutoSize = true;
            this.chkAssignCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAssignCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkAssignCourse.Location = new System.Drawing.Point(625, 11);
            this.chkAssignCourse.Name = "chkAssignCourse";
            this.chkAssignCourse.Size = new System.Drawing.Size(144, 24);
            this.chkAssignCourse.TabIndex = 5;
            this.chkAssignCourse.Text = "Assign Course";
            this.chkAssignCourse.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Depth = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(373, 6);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Primary = true;
            this.btnBrowse.Size = new System.Drawing.Size(82, 33);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.adgvDataToImport);
            this.panel2.Location = new System.Drawing.Point(3, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 436);
            this.panel2.TabIndex = 332;
            // 
            // adgvDataToImport
            // 
            this.adgvDataToImport.AllowUserToAddRows = false;
            this.adgvDataToImport.AllowUserToOrderColumns = true;
            this.adgvDataToImport.AutoGenerateContextFilters = true;
            this.adgvDataToImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adgvDataToImport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.adgvDataToImport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adgvDataToImport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.adgvDataToImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvDataToImport.DateWithTime = false;
            this.adgvDataToImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvDataToImport.Location = new System.Drawing.Point(0, 0);
            this.adgvDataToImport.Name = "adgvDataToImport";
            this.adgvDataToImport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.adgvDataToImport.Size = new System.Drawing.Size(954, 436);
            this.adgvDataToImport.TabIndex = 328;
            this.adgvDataToImport.TimeFilter = false;
            this.adgvDataToImport.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgvDataToImport_DataBindingComplete);
            // 
            // FrmImportRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(980, 635);
            this.Controls.Add(this.panel1);
            this.Name = "FrmImportRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportStudent";
            this.Load += new System.EventHandler(this.FrmSMImportRegistration_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvDataToImport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView adgvDataToImport;
        private System.Windows.Forms.CheckBox chkAssignCourse;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnRegister;
        private MaterialSkin.Controls.MaterialRaisedButton btnValidate;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpload;
        private MaterialSkin.Controls.MaterialRaisedButton btnBrowse;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPath;
    }
}
