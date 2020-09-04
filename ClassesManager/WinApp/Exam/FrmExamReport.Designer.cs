namespace ClassManager.WinApp
{
    partial class FrmExamReport
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
            this.ADGVTExamReport = new ADGV.AdvancedDataGridView();
            this.rbtnuploadTest = new System.Windows.Forms.RadioButton();
            this.rbtnarchievedTest = new System.Windows.Forms.RadioButton();
            this.rbnAllTest = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sndMarksSMS = new System.Windows.Forms.Button();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTests = new System.Windows.Forms.ComboBox();
            this.btnDeleteselected = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTExamReport)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ADGVTExamReport);
            this.panel1.Location = new System.Drawing.Point(9, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 428);
            this.panel1.TabIndex = 0;
            // 
            // ADGVTExamReport
            // 
            this.ADGVTExamReport.AllowUserToAddRows = false;
            this.ADGVTExamReport.AutoGenerateContextFilters = true;
            this.ADGVTExamReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVTExamReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVTExamReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVTExamReport.ColumnHeadersHeight = 24;
            this.ADGVTExamReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ADGVTExamReport.DateWithTime = false;
            this.ADGVTExamReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVTExamReport.Location = new System.Drawing.Point(0, 0);
            this.ADGVTExamReport.Name = "ADGVTExamReport";
            this.ADGVTExamReport.Size = new System.Drawing.Size(832, 428);
            this.ADGVTExamReport.TabIndex = 390;
            this.ADGVTExamReport.TimeFilter = false;
            // 
            // rbtnuploadTest
            // 
            this.rbtnuploadTest.AutoSize = true;
            this.rbtnuploadTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnuploadTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtnuploadTest.Location = new System.Drawing.Point(356, 7);
            this.rbtnuploadTest.Name = "rbtnuploadTest";
            this.rbtnuploadTest.Size = new System.Drawing.Size(113, 24);
            this.rbtnuploadTest.TabIndex = 5;
            this.rbtnuploadTest.TabStop = true;
            this.rbtnuploadTest.Text = "Upload Test";
            this.rbtnuploadTest.UseVisualStyleBackColor = true;
            this.rbtnuploadTest.CheckedChanged += new System.EventHandler(this.rbtnuploadTest_CheckedChanged);
            // 
            // rbtnarchievedTest
            // 
            this.rbtnarchievedTest.AutoSize = true;
            this.rbtnarchievedTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnarchievedTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtnarchievedTest.Location = new System.Drawing.Point(679, 7);
            this.rbtnarchievedTest.Name = "rbtnarchievedTest";
            this.rbtnarchievedTest.Size = new System.Drawing.Size(132, 24);
            this.rbtnarchievedTest.TabIndex = 6;
            this.rbtnarchievedTest.TabStop = true;
            this.rbtnarchievedTest.Text = "Archieved Test";
            this.rbtnarchievedTest.UseVisualStyleBackColor = true;
            this.rbtnarchievedTest.CheckedChanged += new System.EventHandler(this.rbtnarchievedTest_CheckedChanged);
            // 
            // rbnAllTest
            // 
            this.rbnAllTest.AutoSize = true;
            this.rbnAllTest.Checked = true;
            this.rbnAllTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnAllTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbnAllTest.Location = new System.Drawing.Point(12, 7);
            this.rbnAllTest.Name = "rbnAllTest";
            this.rbnAllTest.Size = new System.Drawing.Size(123, 24);
            this.rbnAllTest.TabIndex = 4;
            this.rbnAllTest.TabStop = true;
            this.rbnAllTest.Text = "Show All Test";
            this.rbnAllTest.UseVisualStyleBackColor = true;
            this.rbnAllTest.CheckedChanged += new System.EventHandler(this.rbnAllTest_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbtnuploadTest);
            this.panel2.Controls.Add(this.rbtnarchievedTest);
            this.panel2.Controls.Add(this.rbnAllTest);
            this.panel2.Location = new System.Drawing.Point(9, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 39);
            this.panel2.TabIndex = 1;
            // 
            // sndMarksSMS
            // 
            this.sndMarksSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sndMarksSMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sndMarksSMS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sndMarksSMS.FlatAppearance.BorderSize = 0;
            this.sndMarksSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sndMarksSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sndMarksSMS.ForeColor = System.Drawing.Color.White;
            this.sndMarksSMS.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.sndMarksSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sndMarksSMS.Location = new System.Drawing.Point(681, 120);
            this.sndMarksSMS.Name = "sndMarksSMS";
            this.sndMarksSMS.Size = new System.Drawing.Size(82, 35);
            this.sndMarksSMS.TabIndex = 9;
            this.sndMarksSMS.Text = "SEND";
            this.sndMarksSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sndMarksSMS.UseVisualStyleBackColor = false;
            this.sndMarksSMS.Click += new System.EventHandler(this.sndMarksSMS_Click);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveExcel.FlatAppearance.BorderSize = 0;
            this.btnSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveExcel.ForeColor = System.Drawing.Color.White;
            this.btnSaveExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSaveExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveExcel.Location = new System.Drawing.Point(498, 119);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(95, 37);
            this.btnSaveExcel.TabIndex = 8;
            this.btnSaveExcel.Text = "SAVE TO";
            this.btnSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveExcel.UseVisualStyleBackColor = false;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(12, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Test :";
            // 
            // cmbTests
            // 
            this.cmbTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTests.FormattingEnabled = true;
            this.cmbTests.Location = new System.Drawing.Point(115, 127);
            this.cmbTests.Name = "cmbTests";
            this.cmbTests.Size = new System.Drawing.Size(228, 26);
            this.cmbTests.TabIndex = 6;
            this.cmbTests.SelectedIndexChanged += new System.EventHandler(this.cmbTests_SelectedIndexChanged);
            // 
            // btnDeleteselected
            // 
            this.btnDeleteselected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteselected.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteselected.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteselected.FlatAppearance.BorderSize = 0;
            this.btnDeleteselected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteselected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteselected.ForeColor = System.Drawing.Color.White;
            this.btnDeleteselected.Image = global::ClassManager.Properties.Resources.icon_delete;
            this.btnDeleteselected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteselected.Location = new System.Drawing.Point(769, 120);
            this.btnDeleteselected.Name = "btnDeleteselected";
            this.btnDeleteselected.Size = new System.Drawing.Size(70, 37);
            this.btnDeleteselected.TabIndex = 10;
            this.btnDeleteselected.Text = "TEST";
            this.btnDeleteselected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteselected.UseVisualStyleBackColor = false;
            this.btnDeleteselected.Click += new System.EventHandler(this.btnDeleteselected_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::ClassManager.Properties.Resources.printer_with_document;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(599, 120);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(76, 35);
            this.btnPrint.TabIndex = 389;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.White;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(381, 133);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 390;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // FrmExamReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 616);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDeleteselected);
            this.Controls.Add(this.sndMarksSMS);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTests);
            this.Name = "FrmExamReport";
            this.Text = "FrmExamReport";
            this.Load += new System.EventHandler(this.FrmExamReport_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTExamReport)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnuploadTest;
        private System.Windows.Forms.RadioButton rbtnarchievedTest;
        private System.Windows.Forms.RadioButton rbnAllTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button sndMarksSMS;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTests;
        private System.Windows.Forms.Button btnDeleteselected;
        private System.Windows.Forms.Button btnPrint;
        private ADGV.AdvancedDataGridView ADGVTExamReport;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}