namespace ClassManager.WinApp
{
    partial class FrmExpiredRenewal
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
            this.bgwExpiredPackages = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.BtnSMS = new System.Windows.Forms.Button();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.lblText = new MaterialSkin.Controls.MaterialLabel();
            this.txtFname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSearchby = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grid = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwExpiredPackages
            // 
            this.bgwExpiredPackages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExpiredPackages_DoWork);
            this.bgwExpiredPackages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwExpiredPackages_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.grid);
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 466);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSendMail);
            this.panel2.Controls.Add(this.BtnSMS);
            this.panel2.Controls.Add(this.btnSaveToExcel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblSearchby);
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Location = new System.Drawing.Point(12, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 98);
            this.panel2.TabIndex = 12;
            // 
            // btnSendMail
            // 
            this.btnSendMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendMail.FlatAppearance.BorderSize = 0;
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.White;
            this.btnSendMail.Image = global::ClassManager.Properties.Resources.Gmail_Icon;
            this.btnSendMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendMail.Location = new System.Drawing.Point(845, 44);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(77, 28);
            this.btnSendMail.TabIndex = 423;
            this.btnSendMail.Text = "SEND";
            this.btnSendMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMail.UseVisualStyleBackColor = false;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // BtnSMS
            // 
            this.BtnSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSMS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSMS.FlatAppearance.BorderSize = 0;
            this.BtnSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSMS.ForeColor = System.Drawing.Color.White;
            this.BtnSMS.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.BtnSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSMS.Location = new System.Drawing.Point(624, 41);
            this.BtnSMS.Name = "BtnSMS";
            this.BtnSMS.Size = new System.Drawing.Size(82, 31);
            this.BtnSMS.TabIndex = 385;
            this.BtnSMS.Text = "SEND";
            this.BtnSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSMS.UseVisualStyleBackColor = false;
            this.BtnSMS.Click += new System.EventHandler(this.BtnSMS_Click);
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveToExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveToExcel.FlatAppearance.BorderSize = 0;
            this.btnSaveToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToExcel.ForeColor = System.Drawing.Color.White;
            this.btnSaveToExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveToExcel.Location = new System.Drawing.Point(731, 43);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(95, 31);
            this.btnSaveToExcel.TabIndex = 387;
            this.btnSaveToExcel.Text = "SAVE TO";
            this.btnSaveToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.UseVisualStyleBackColor = false;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbFilterBy);
            this.panel3.Controls.Add(this.lblText);
            this.panel3.Controls.Add(this.txtFname);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(9, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 60);
            this.panel3.TabIndex = 66;
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Expired",
            "To Be  Expire",
            "With No Facility"});
            this.cmbFilterBy.Location = new System.Drawing.Point(80, 13);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(236, 24);
            this.cmbFilterBy.TabIndex = 6;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Depth = 0;
            this.lblText.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblText.Location = new System.Drawing.Point(3, 13);
            this.lblText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(71, 19);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Filter By :";
            // 
            // txtFname
            // 
            this.txtFname.Depth = 0;
            this.txtFname.Hint = "Enter Name";
            this.txtFname.Location = new System.Drawing.Point(405, 13);
            this.txtFname.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFname.Name = "txtFname";
            this.txtFname.PasswordChar = '\0';
            this.txtFname.SelectedText = "";
            this.txtFname.SelectionLength = 0;
            this.txtFname.SelectionStart = 0;
            this.txtFname.Size = new System.Drawing.Size(166, 23);
            this.txtFname.TabIndex = 55;
            this.txtFname.TabStop = false;
            this.txtFname.UseSystemPasswordChar = false;
            this.txtFname.TextChanged += new System.EventHandler(this.txtFname_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(340, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "Name :";
            // 
            // lblSearchby
            // 
            this.lblSearchby.AutoSize = true;
            this.lblSearchby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblSearchby.Location = new System.Drawing.Point(3, 0);
            this.lblSearchby.Name = "lblSearchby";
            this.lblSearchby.Size = new System.Drawing.Size(101, 20);
            this.lblSearchby.TabIndex = 65;
            this.lblSearchby.Text = "Search By :";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(728, 3);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 11;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoGenerateContextFilters = true;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.DateWithTime = false;
            this.grid.Location = new System.Drawing.Point(13, 107);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(932, 354);
            this.grid.TabIndex = 8;
            this.grid.TimeFilter = false;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grid_DataBindingComplete);
            this.grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // FrmExpiredRenewal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 566);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmExpiredRenewal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpiredOrRenewal";
            this.Load += new System.EventHandler(this.FrmExpiredRenewal_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private MaterialSkin.Controls.MaterialLabel lblText;
        private ADGV.AdvancedDataGridView grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.ComponentModel.BackgroundWorker bgwExpiredPackages;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFname;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSearchby;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button BtnSMS;
        private System.Windows.Forms.Button btnSendMail;
    }
}