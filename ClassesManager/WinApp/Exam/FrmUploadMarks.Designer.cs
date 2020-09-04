namespace ClassManager.WinApp
{
    partial class FrmUploadMarks
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
            this.ADGVTUploadMarks = new ADGV.AdvancedDataGridView();
            this.panelupld = new System.Windows.Forms.Panel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.btnArchieve = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.sndMarksSMS = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.chkAbsentStudent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTests = new System.Windows.Forms.ComboBox();
            this.chbRemark = new System.Windows.Forms.CheckBox();
            this.btnUploadExcl = new System.Windows.Forms.Button();
            this.bgwUploadMarkSMS = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTUploadMarks)).BeginInit();
            this.panelupld.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ADGVTUploadMarks);
            this.panel1.Location = new System.Drawing.Point(12, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 456);
            this.panel1.TabIndex = 344;
            // 
            // ADGVTUploadMarks
            // 
            this.ADGVTUploadMarks.AllowUserToAddRows = false;
            this.ADGVTUploadMarks.AutoGenerateContextFilters = true;
            this.ADGVTUploadMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVTUploadMarks.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVTUploadMarks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVTUploadMarks.ColumnHeadersHeight = 24;
            this.ADGVTUploadMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ADGVTUploadMarks.DateWithTime = false;
            this.ADGVTUploadMarks.Location = new System.Drawing.Point(0, 0);
            this.ADGVTUploadMarks.Name = "ADGVTUploadMarks";
            this.ADGVTUploadMarks.Size = new System.Drawing.Size(1073, 456);
            this.ADGVTUploadMarks.TabIndex = 343;
            this.ADGVTUploadMarks.TimeFilter = false;
            this.ADGVTUploadMarks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVTUploadMarks_CellContentClick);
            this.ADGVTUploadMarks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVTUploadMarks_DataBindingComplete);
            this.ADGVTUploadMarks.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ADGVTUploadMarks_EditingControlShowing);
            this.ADGVTUploadMarks.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVTUploadMarks_RowPostPaint);
            // 
            // panelupld
            // 
            this.panelupld.BackColor = System.Drawing.Color.White;
            this.panelupld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelupld.Controls.Add(this.materialLabel3);
            this.panelupld.Controls.Add(this.materialLabel2);
            this.panelupld.Controls.Add(this.materialLabel1);
            this.panelupld.Controls.Add(this.cmbStream);
            this.panelupld.Controls.Add(this.cmbCourseType);
            this.panelupld.Controls.Add(this.cmbBatch);
            this.panelupld.Controls.Add(this.btnArchieve);
            this.panelupld.Controls.Add(this.chkSelectAll);
            this.panelupld.Controls.Add(this.sndMarksSMS);
            this.panelupld.Controls.Add(this.btnSave);
            this.panelupld.Controls.Add(this.btnSaveExcel);
            this.panelupld.Controls.Add(this.chkAbsentStudent);
            this.panelupld.Controls.Add(this.label1);
            this.panelupld.Controls.Add(this.cmbTests);
            this.panelupld.Location = new System.Drawing.Point(12, 77);
            this.panelupld.Name = "panelupld";
            this.panelupld.Size = new System.Drawing.Size(1073, 157);
            this.panelupld.TabIndex = 0;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(805, 18);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(55, 19);
            this.materialLabel3.TabIndex = 369;
            this.materialLabel3.Text = "Batch :";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(422, 18);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(69, 19);
            this.materialLabel2.TabIndex = 368;
            this.materialLabel2.Text = " Course :";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(11, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 367;
            this.materialLabel1.Text = "Stream :";
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(82, 14);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(173, 28);
            this.cmbStream.TabIndex = 364;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseType.FormattingEnabled = true;
            this.cmbCourseType.Location = new System.Drawing.Point(523, 14);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(168, 28);
            this.cmbCourseType.TabIndex = 365;
            this.cmbCourseType.SelectedIndexChanged += new System.EventHandler(this.cmbCourseType_SelectedIndexChanged);
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(892, 18);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(157, 28);
            this.cmbBatch.TabIndex = 366;
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            // 
            // btnArchieve
            // 
            this.btnArchieve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnArchieve.FlatAppearance.BorderSize = 0;
            this.btnArchieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchieve.ForeColor = System.Drawing.Color.White;
            this.btnArchieve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchieve.Location = new System.Drawing.Point(507, 66);
            this.btnArchieve.Name = "btnArchieve";
            this.btnArchieve.Size = new System.Drawing.Size(113, 31);
            this.btnArchieve.TabIndex = 10;
            this.btnArchieve.Text = "Mark Completed";
            this.btnArchieve.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchieve.UseVisualStyleBackColor = false;
            this.btnArchieve.Click += new System.EventHandler(this.btnArchieve_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(7, 128);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
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
            this.sndMarksSMS.Location = new System.Drawing.Point(967, 121);
            this.sndMarksSMS.Name = "sndMarksSMS";
            this.sndMarksSMS.Size = new System.Drawing.Size(82, 31);
            this.sndMarksSMS.TabIndex = 4;
            this.sndMarksSMS.Text = "SEND";
            this.sndMarksSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sndMarksSMS.UseVisualStyleBackColor = false;
            this.sndMarksSMS.Click += new System.EventHandler(this.sndMarksSMS_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(767, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 31);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE   ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnSaveExcel.Location = new System.Drawing.Point(866, 121);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(95, 31);
            this.btnSaveExcel.TabIndex = 3;
            this.btnSaveExcel.Text = "SAVE TO";
            this.btnSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveExcel.UseVisualStyleBackColor = false;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // chkAbsentStudent
            // 
            this.chkAbsentStudent.AutoSize = true;
            this.chkAbsentStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAbsentStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkAbsentStudent.Location = new System.Drawing.Point(111, 128);
            this.chkAbsentStudent.Name = "chkAbsentStudent";
            this.chkAbsentStudent.Size = new System.Drawing.Size(100, 24);
            this.chkAbsentStudent.TabIndex = 5;
            this.chkAbsentStudent.Text = "Absent All";
            this.chkAbsentStudent.UseVisualStyleBackColor = true;
            this.chkAbsentStudent.CheckedChanged += new System.EventHandler(this.chkAbsentStudent_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Test :";
            // 
            // cmbTests
            // 
            this.cmbTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTests.FormattingEnabled = true;
            this.cmbTests.Location = new System.Drawing.Point(111, 70);
            this.cmbTests.Name = "cmbTests";
            this.cmbTests.Size = new System.Drawing.Size(264, 23);
            this.cmbTests.TabIndex = 1;
            this.cmbTests.SelectedIndexChanged += new System.EventHandler(this.cmbTests_SelectedIndexChanged);
            // 
            // chbRemark
            // 
            this.chbRemark.AutoSize = true;
            this.chbRemark.Checked = true;
            this.chbRemark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chbRemark.Location = new System.Drawing.Point(710, 110);
            this.chbRemark.Name = "chbRemark";
            this.chbRemark.Size = new System.Drawing.Size(36, 24);
            this.chbRemark.TabIndex = 6;
            this.chbRemark.Text = "k";
            this.chbRemark.UseVisualStyleBackColor = true;
            this.chbRemark.Visible = false;
            // 
            // btnUploadExcl
            // 
            this.btnUploadExcl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUploadExcl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadExcl.Location = new System.Drawing.Point(721, 144);
            this.btnUploadExcl.Name = "btnUploadExcl";
            this.btnUploadExcl.Size = new System.Drawing.Size(11, 18);
            this.btnUploadExcl.TabIndex = 7;
            this.btnUploadExcl.Text = "Upload Excel";
            this.btnUploadExcl.UseVisualStyleBackColor = false;
            this.btnUploadExcl.Visible = false;
            // 
            // bgwUploadMarkSMS
            // 
            this.bgwUploadMarkSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUploadMarkSMS_DoWork);
            this.bgwUploadMarkSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUploadMarkSMS_RunWorkerCompleted);
            // 
            // FrmUploadMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1254, 705);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelupld);
            this.Controls.Add(this.chbRemark);
            this.Controls.Add(this.btnUploadExcl);
            this.Name = "FrmUploadMarks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UploadMarks";
            this.Load += new System.EventHandler(this.FrmUploadMarks_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTUploadMarks)).EndInit();
            this.panelupld.ResumeLayout(false);
            this.panelupld.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelupld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTests;
        private System.Windows.Forms.Button btnUploadExcl;
        private ADGV.AdvancedDataGridView ADGVTUploadMarks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbRemark;
        private System.Windows.Forms.CheckBox chkAbsentStudent;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button sndMarksSMS;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.ComponentModel.BackgroundWorker bgwUploadMarkSMS;
        private System.Windows.Forms.Button btnArchieve;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.ComboBox cmbCourseType;
        private System.Windows.Forms.ComboBox cmbBatch;
    }
}
