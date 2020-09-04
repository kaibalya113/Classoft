namespace ClassManager.WinApp
{
    partial class FrmIncomeReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVIncome = new ADGV.AdvancedDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnUpdatePaidIncome = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkShowAllBranch = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbViewExpenses = new System.Windows.Forms.ComboBox();
            this.panelMaxInc = new System.Windows.Forms.Panel();
            this.lblNameAndAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkDtFilter = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVIncome)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelMaxInc.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ADGVIncome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 541);
            this.panel1.TabIndex = 0;
            // 
            // ADGVIncome
            // 
            this.ADGVIncome.AllowUserToAddRows = false;
            this.ADGVIncome.AutoGenerateContextFilters = true;
            this.ADGVIncome.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVIncome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVIncome.DateWithTime = false;
            this.ADGVIncome.Location = new System.Drawing.Point(3, 3);
            this.ADGVIncome.Name = "ADGVIncome";
            this.ADGVIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVIncome.Size = new System.Drawing.Size(974, 532);
            this.ADGVIncome.TabIndex = 11;
            this.ADGVIncome.TimeFilter = false;
            this.ADGVIncome.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVIncome_CellContentClick);
            this.ADGVIncome.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVIncome_DataBindingComplete);
            this.ADGVIncome.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVIncome_RowPostPaint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_saveToPDF);
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.btnUpdatePaidIncome);
            this.panel2.Controls.Add(this.chkShowAllBranch);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbViewExpenses);
            this.panel2.Controls.Add(this.panelMaxInc);
            this.panel2.Controls.Add(this.chkDtFilter);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(983, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 532);
            this.panel2.TabIndex = 399;
            // 
            // btn_saveToPDF
            // 
            this.btn_saveToPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_saveToPDF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_saveToPDF.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_saveToPDF.FlatAppearance.BorderSize = 0;
            this.btn_saveToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveToPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveToPDF.ForeColor = System.Drawing.Color.White;
            this.btn_saveToPDF.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btn_saveToPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_saveToPDF.Location = new System.Drawing.Point(71, 85);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 398;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Image = global::ClassManager.Properties.Resources.printer_with_document;
            this.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShow.Location = new System.Drawing.Point(85, 345);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(76, 35);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "PRINT";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnUpdatePaidIncome
            // 
            this.btnUpdatePaidIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePaidIncome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdatePaidIncome.BackColor = System.Drawing.Color.White;
            this.btnUpdatePaidIncome.Depth = 0;
            this.btnUpdatePaidIncome.Location = new System.Drawing.Point(71, 3);
            this.btnUpdatePaidIncome.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdatePaidIncome.Name = "btnUpdatePaidIncome";
            this.btnUpdatePaidIncome.Primary = true;
            this.btnUpdatePaidIncome.Size = new System.Drawing.Size(96, 33);
            this.btnUpdatePaidIncome.TabIndex = 1;
            this.btnUpdatePaidIncome.Text = "Update";
            this.btnUpdatePaidIncome.UseVisualStyleBackColor = false;
            this.btnUpdatePaidIncome.Visible = false;
            this.btnUpdatePaidIncome.Click += new System.EventHandler(this.btnUpdatePaidIncome_Click);
            // 
            // chkShowAllBranch
            // 
            this.chkShowAllBranch.AutoSize = true;
            this.chkShowAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAllBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkShowAllBranch.Location = new System.Drawing.Point(26, 118);
            this.chkShowAllBranch.Name = "chkShowAllBranch";
            this.chkShowAllBranch.Size = new System.Drawing.Size(186, 20);
            this.chkShowAllBranch.TabIndex = 3;
            this.chkShowAllBranch.Text = "Show All Branch Expenses";
            this.chkShowAllBranch.UseVisualStyleBackColor = true;
            this.chkShowAllBranch.CheckedChanged += new System.EventHandler(this.chkShowAllBranch_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(71, 46);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(18, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 394;
            this.label8.Text = "View By :";
            // 
            // cmbViewExpenses
            // 
            this.cmbViewExpenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewExpenses.FormattingEnabled = true;
            this.cmbViewExpenses.Items.AddRange(new object[] {
            "All Data",
            "Category Wise Data"});
            this.cmbViewExpenses.Location = new System.Drawing.Point(85, 163);
            this.cmbViewExpenses.Name = "cmbViewExpenses";
            this.cmbViewExpenses.Size = new System.Drawing.Size(186, 24);
            this.cmbViewExpenses.TabIndex = 4;
            this.cmbViewExpenses.SelectedIndexChanged += new System.EventHandler(this.cmbViewExpenses_SelectedIndexChanged);
            // 
            // panelMaxInc
            // 
            this.panelMaxInc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaxInc.Controls.Add(this.lblNameAndAmount);
            this.panelMaxInc.Controls.Add(this.label11);
            this.panelMaxInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMaxInc.Location = new System.Drawing.Point(6, 410);
            this.panelMaxInc.Name = "panelMaxInc";
            this.panelMaxInc.Size = new System.Drawing.Size(235, 78);
            this.panelMaxInc.TabIndex = 397;
            this.panelMaxInc.Visible = false;
            // 
            // lblNameAndAmount
            // 
            this.lblNameAndAmount.AutoSize = true;
            this.lblNameAndAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblNameAndAmount.Location = new System.Drawing.Point(9, 47);
            this.lblNameAndAmount.Name = "lblNameAndAmount";
            this.lblNameAndAmount.Size = new System.Drawing.Size(137, 19);
            this.lblNameAndAmount.TabIndex = 23;
            this.lblNameAndAmount.Text = "Name and Amount :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(3, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Max Income Source :";
            // 
            // chkDtFilter
            // 
            this.chkDtFilter.AutoSize = true;
            this.chkDtFilter.Checked = true;
            this.chkDtFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDtFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkDtFilter.Location = new System.Drawing.Point(65, 507);
            this.chkDtFilter.Name = "chkDtFilter";
            this.chkDtFilter.Size = new System.Drawing.Size(88, 20);
            this.chkDtFilter.TabIndex = 395;
            this.chkDtFilter.TabStop = false;
            this.chkDtFilter.Text = "Date Filter";
            this.chkDtFilter.UseVisualStyleBackColor = true;
            this.chkDtFilter.Visible = false;
            this.chkDtFilter.CheckedChanged += new System.EventHandler(this.chkDtFilter_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.dtpToDate);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.dtpFromDate);
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(6, 235);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(281, 89);
            this.panel6.TabIndex = 396;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(10, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 19);
            this.label10.TabIndex = 30;
            this.label10.Text = "To :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(80, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(184, 22);
            this.dtpToDate.TabIndex = 6;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(9, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 28;
            this.label9.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(78, 15);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(186, 22);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 400;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // FrmIncomeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 633);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIncomeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income Report";
            this.Load += new System.EventHandler(this.FrmIncomeReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVIncome)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMaxInc.ResumeLayout(false);
            this.panelMaxInc.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView ADGVIncome;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdatePaidIncome;
        private System.Windows.Forms.CheckBox chkShowAllBranch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbViewExpenses;
        private System.Windows.Forms.Panel panelMaxInc;
        private System.Windows.Forms.Label lblNameAndAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkDtFilter;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btn_saveToPDF;
        private System.Windows.Forms.Label label1;
    }
}
