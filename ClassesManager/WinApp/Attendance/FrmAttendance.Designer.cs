namespace ClassManager.WinApp
{
    partial class FrmAttendance
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ADGVAttendance = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewAttd = new System.Windows.Forms.Button();
            this.btnSaveToDatabase = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbLecture = new System.Windows.Forms.ComboBox();
            this.lblLecture = new System.Windows.Forms.Label();
            this.chbFaculty = new System.Windows.Forms.CheckBox();
            this.lblStream = new System.Windows.Forms.Label();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.lblcrse = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpmarkfor = new System.Windows.Forms.DateTimePicker();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAttendance)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Location = new System.Drawing.Point(2, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(810, 625);
            this.panel5.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ADGVAttendance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 455);
            this.panel2.TabIndex = 349;
            // 
            // ADGVAttendance
            // 
            this.ADGVAttendance.AllowUserToAddRows = false;
            this.ADGVAttendance.AllowUserToDeleteRows = false;
            this.ADGVAttendance.AutoGenerateContextFilters = true;
            this.ADGVAttendance.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVAttendance.DateWithTime = false;
            this.ADGVAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVAttendance.Location = new System.Drawing.Point(0, 0);
            this.ADGVAttendance.Name = "ADGVAttendance";
            this.ADGVAttendance.ReadOnly = true;
            this.ADGVAttendance.Size = new System.Drawing.Size(808, 455);
            this.ADGVAttendance.TabIndex = 347;
            this.ADGVAttendance.TimeFilter = false;
            this.ADGVAttendance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVAttendance_CellClick);
            this.ADGVAttendance.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVAttendance_CellValueChanged);
            this.ADGVAttendance.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVAttendance_DataBindingComplete);
            this.ADGVAttendance.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVAttendance_DataError);
            this.ADGVAttendance.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVAttendance_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnViewAttd);
            this.panel1.Controls.Add(this.btnSaveToDatabase);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cmbLecture);
            this.panel1.Controls.Add(this.lblLecture);
            this.panel1.Controls.Add(this.chbFaculty);
            this.panel1.Controls.Add(this.lblStream);
            this.panel1.Controls.Add(this.cmbStream);
            this.panel1.Controls.Add(this.cmbCourseType);
            this.panel1.Controls.Add(this.lblcrse);
            this.panel1.Controls.Add(this.cmbBatch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dtpmarkfor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 168);
            this.panel1.TabIndex = 348;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtFName);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(9, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 53);
            this.panel3.TabIndex = 424;
            // 
            // txtFName
            // 
            this.txtFName.Depth = 0;
            this.txtFName.Hint = "Enter Name";
            this.txtFName.Location = new System.Drawing.Point(76, 13);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(212, 23);
            this.txtFName.TabIndex = 7;
            this.txtFName.UseSystemPasswordChar = false;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(15, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 20);
            this.label14.TabIndex = 423;
            this.label14.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 421;
            this.label2.Text = "Stream :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(332, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 420;
            this.label1.Text = "Course:";
            // 
            // btnViewAttd
            // 
            this.btnViewAttd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnViewAttd.FlatAppearance.BorderSize = 0;
            this.btnViewAttd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAttd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAttd.ForeColor = System.Drawing.Color.White;
            this.btnViewAttd.Image = global::ClassManager.Properties.Resources.students_teacher_and_blackboard;
            this.btnViewAttd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAttd.Location = new System.Drawing.Point(715, 119);
            this.btnViewAttd.Name = "btnViewAttd";
            this.btnViewAttd.Size = new System.Drawing.Size(83, 31);
            this.btnViewAttd.TabIndex = 10;
            this.btnViewAttd.Text = "VIEW";
            this.btnViewAttd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewAttd.UseVisualStyleBackColor = false;
            this.btnViewAttd.Click += new System.EventHandler(this.btnViewAttd_Click);
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveToDatabase.FlatAppearance.BorderSize = 0;
            this.btnSaveToDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToDatabase.ForeColor = System.Drawing.Color.White;
            this.btnSaveToDatabase.Image = global::ClassManager.Properties.Resources.icon_mark;
            this.btnSaveToDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToDatabase.Location = new System.Drawing.Point(526, 118);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(74, 32);
            this.btnSaveToDatabase.TabIndex = 8;
            this.btnSaveToDatabase.Text = "MARK";
            this.btnSaveToDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveToDatabase.UseVisualStyleBackColor = false;
            this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
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
            this.btnSave.Location = new System.Drawing.Point(616, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbLecture
            // 
            this.cmbLecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLecture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLecture.FormattingEnabled = true;
            this.cmbLecture.Items.AddRange(new object[] {
            "Full Day"});
            this.cmbLecture.Location = new System.Drawing.Point(408, 63);
            this.cmbLecture.Name = "cmbLecture";
            this.cmbLecture.Size = new System.Drawing.Size(272, 24);
            this.cmbLecture.TabIndex = 5;
            // 
            // lblLecture
            // 
            this.lblLecture.AutoSize = true;
            this.lblLecture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblLecture.Location = new System.Drawing.Point(324, 67);
            this.lblLecture.Name = "lblLecture";
            this.lblLecture.Size = new System.Drawing.Size(71, 20);
            this.lblLecture.TabIndex = 358;
            this.lblLecture.Text = "Lecture :";
            // 
            // chbFaculty
            // 
            this.chbFaculty.AutoSize = true;
            this.chbFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chbFaculty.Location = new System.Drawing.Point(709, 68);
            this.chbFaculty.Name = "chbFaculty";
            this.chbFaculty.Size = new System.Drawing.Size(96, 24);
            this.chbFaculty.TabIndex = 6;
            this.chbFaculty.Text = "Instructor";
            this.chbFaculty.UseVisualStyleBackColor = true;
            this.chbFaculty.CheckedChanged += new System.EventHandler(this.chbFaculty_CheckedChanged);
            // 
            // lblStream
            // 
            this.lblStream.AutoSize = true;
            this.lblStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStream.Location = new System.Drawing.Point(12, 21);
            this.lblStream.Name = "lblStream";
            this.lblStream.Size = new System.Drawing.Size(79, 20);
            this.lblStream.TabIndex = 351;
            this.lblStream.Text = "Package :";
            this.lblStream.Visible = false;
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(100, 17);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(139, 26);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseType.FormattingEnabled = true;
            this.cmbCourseType.Location = new System.Drawing.Point(408, 17);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(133, 24);
            this.cmbCourseType.TabIndex = 2;
            this.cmbCourseType.SelectedIndexChanged += new System.EventHandler(this.cmbCourseType_SelectedIndexChanged);
            // 
            // lblcrse
            // 
            this.lblcrse.AutoSize = true;
            this.lblcrse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcrse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblcrse.Location = new System.Drawing.Point(289, 19);
            this.lblcrse.Name = "lblcrse";
            this.lblcrse.Size = new System.Drawing.Size(113, 20);
            this.lblcrse.TabIndex = 353;
            this.lblcrse.Text = "PackageType :";
            this.lblcrse.Visible = false;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(653, 20);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(139, 24);
            this.cmbBatch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(588, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 355;
            this.label3.Text = "Batch :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(33, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 20);
            this.label13.TabIndex = 349;
            this.label13.Text = "Date :";
            // 
            // dtpmarkfor
            // 
            this.dtpmarkfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpmarkfor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpmarkfor.Location = new System.Drawing.Point(100, 67);
            this.dtpmarkfor.Name = "dtpmarkfor";
            this.dtpmarkfor.Size = new System.Drawing.Size(139, 22);
            this.dtpmarkfor.TabIndex = 4;
            this.dtpmarkfor.CloseUp += new System.EventHandler(this.dtpmarkfor_CloseUp);
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 703);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.Name = "FrmAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mark";
            this.Load += new System.EventHandler(this.FrmAttendance_Load);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAttendance)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private ADGV.AdvancedDataGridView ADGVAttendance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbLecture;
        private System.Windows.Forms.Label lblLecture;
        private System.Windows.Forms.CheckBox chbFaculty;
        private System.Windows.Forms.Label lblStream;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.ComboBox cmbCourseType;
        private System.Windows.Forms.Label lblcrse;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpmarkfor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveToDatabase;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnViewAttd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private System.Windows.Forms.Label label14;
    }
}
