namespace ClassManager.WinApp
{
    partial class FrmExpenseReport
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
            this.panel13 = new System.Windows.Forms.Panel();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdatePaidExp = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelMaxExp = new System.Windows.Forms.Panel();
            this.lblNameAndAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkDtFilter = new System.Windows.Forms.CheckBox();
            this.cmbViewExpenses = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShowAllBranch = new System.Windows.Forms.CheckBox();
            this.adgvExpsnses = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panelMaxExp.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvExpsnses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.adgvExpsnses);
            this.panel1.Location = new System.Drawing.Point(11, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 534);
            this.panel1.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.btn_saveToPDF);
            this.panel13.Controls.Add(this.btnShow);
            this.panel13.Controls.Add(this.btnSave);
            this.panel13.Controls.Add(this.btnUpdatePaidExp);
            this.panel13.Controls.Add(this.panelMaxExp);
            this.panel13.Controls.Add(this.panel3);
            this.panel13.Controls.Add(this.chkDtFilter);
            this.panel13.Controls.Add(this.cmbViewExpenses);
            this.panel13.Controls.Add(this.label8);
            this.panel13.Controls.Add(this.chkShowAllBranch);
            this.panel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel13.Location = new System.Drawing.Point(931, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(323, 526);
            this.panel13.TabIndex = 34;
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
            this.btn_saveToPDF.Location = new System.Drawing.Point(67, 72);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 399;
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
            this.btnShow.Location = new System.Drawing.Point(87, 331);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(76, 35);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "PRINT";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(72, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnUpdatePaidExp
            // 
            this.btnUpdatePaidExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePaidExp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdatePaidExp.BackColor = System.Drawing.Color.White;
            this.btnUpdatePaidExp.Depth = 0;
            this.btnUpdatePaidExp.Location = new System.Drawing.Point(216, -1);
            this.btnUpdatePaidExp.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdatePaidExp.Name = "btnUpdatePaidExp";
            this.btnUpdatePaidExp.Primary = true;
            this.btnUpdatePaidExp.Size = new System.Drawing.Size(102, 33);
            this.btnUpdatePaidExp.TabIndex = 1;
            this.btnUpdatePaidExp.Text = "Update";
            this.btnUpdatePaidExp.UseVisualStyleBackColor = false;
            this.btnUpdatePaidExp.Visible = false;
            this.btnUpdatePaidExp.Click += new System.EventHandler(this.btnUpdatePaidExp_Click_1);
            // 
            // panelMaxExp
            // 
            this.panelMaxExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaxExp.Controls.Add(this.lblNameAndAmount);
            this.panelMaxExp.Controls.Add(this.label2);
            this.panelMaxExp.Location = new System.Drawing.Point(9, 389);
            this.panelMaxExp.Name = "panelMaxExp";
            this.panelMaxExp.Size = new System.Drawing.Size(236, 104);
            this.panelMaxExp.TabIndex = 31;
            this.panelMaxExp.Visible = false;
            // 
            // lblNameAndAmount
            // 
            this.lblNameAndAmount.AutoSize = true;
            this.lblNameAndAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblNameAndAmount.Location = new System.Drawing.Point(3, 55);
            this.lblNameAndAmount.Name = "lblNameAndAmount";
            this.lblNameAndAmount.Size = new System.Drawing.Size(150, 20);
            this.lblNameAndAmount.TabIndex = 23;
            this.lblNameAndAmount.Text = "Name and Amount :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Max Expense Source :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.dtpToDate);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dtpFromDate);
            this.panel3.Location = new System.Drawing.Point(9, 238);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 87);
            this.panel3.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(9, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "To :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(88, 50);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(189, 26);
            this.dtpToDate.TabIndex = 6;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(9, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(88, 17);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(189, 26);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp_1);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // chkDtFilter
            // 
            this.chkDtFilter.AutoSize = true;
            this.chkDtFilter.Checked = true;
            this.chkDtFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDtFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkDtFilter.Location = new System.Drawing.Point(23, 497);
            this.chkDtFilter.Name = "chkDtFilter";
            this.chkDtFilter.Size = new System.Drawing.Size(102, 24);
            this.chkDtFilter.TabIndex = 3;
            this.chkDtFilter.TabStop = false;
            this.chkDtFilter.Text = "Date Filter";
            this.chkDtFilter.UseVisualStyleBackColor = true;
            this.chkDtFilter.Visible = false;
            this.chkDtFilter.CheckedChanged += new System.EventHandler(this.chkDtFilter_CheckedChanged_1);
            // 
            // cmbViewExpenses
            // 
            this.cmbViewExpenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewExpenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbViewExpenses.FormattingEnabled = true;
            this.cmbViewExpenses.Items.AddRange(new object[] {
            "All Data",
            "Category Wise Data"});
            this.cmbViewExpenses.Location = new System.Drawing.Point(98, 161);
            this.cmbViewExpenses.Name = "cmbViewExpenses";
            this.cmbViewExpenses.Size = new System.Drawing.Size(189, 28);
            this.cmbViewExpenses.TabIndex = 4;
            this.cmbViewExpenses.SelectedIndexChanged += new System.EventHandler(this.cmbViewExpenses_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(4, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "View By :";
            // 
            // chkShowAllBranch
            // 
            this.chkShowAllBranch.AutoSize = true;
            this.chkShowAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAllBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkShowAllBranch.Location = new System.Drawing.Point(17, 111);
            this.chkShowAllBranch.Name = "chkShowAllBranch";
            this.chkShowAllBranch.Size = new System.Drawing.Size(218, 24);
            this.chkShowAllBranch.TabIndex = 3;
            this.chkShowAllBranch.Text = "Show All Branch Expenses";
            this.chkShowAllBranch.UseVisualStyleBackColor = true;
            this.chkShowAllBranch.CheckedChanged += new System.EventHandler(this.chkShowAllBranch_CheckedChanged_1);
            // 
            // adgvExpsnses
            // 
            this.adgvExpsnses.AllowUserToAddRows = false;
            this.adgvExpsnses.AutoGenerateContextFilters = true;
            this.adgvExpsnses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adgvExpsnses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.adgvExpsnses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvExpsnses.DateWithTime = false;
            this.adgvExpsnses.Location = new System.Drawing.Point(3, 3);
            this.adgvExpsnses.Name = "adgvExpsnses";
            this.adgvExpsnses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvExpsnses.Size = new System.Drawing.Size(922, 526);
            this.adgvExpsnses.TabIndex = 33;
            this.adgvExpsnses.TimeFilter = false;
            this.adgvExpsnses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvExpsnses_CellContentClick);
            this.adgvExpsnses.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgvExpsnses_DataBindingComplete_1);
            this.adgvExpsnses.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.adgvExpsnses_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // FrmExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 622);
            this.Controls.Add(this.panel1);
            this.Name = "FrmExpenseReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Report";
            this.Load += new System.EventHandler(this.FrmExpenseReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panelMaxExp.ResumeLayout(false);
            this.panelMaxExp.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvExpsnses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView adgvExpsnses;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnSave;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdatePaidExp;
        private System.Windows.Forms.Panel panelMaxExp;
        private System.Windows.Forms.Label lblNameAndAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox chkDtFilter;
        private System.Windows.Forms.ComboBox cmbViewExpenses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkShowAllBranch;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btn_saveToPDF;
        private System.Windows.Forms.Label label1;
    }
}