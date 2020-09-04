namespace ClassManager.WinApp
{
    partial class FrmAttendanceSheet
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
            this.bgwSMS = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ADGVAttendanceSheet = new ADGV.AdvancedDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblHours = new System.Windows.Forms.Label();
            this.btnInstructorAttendance = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.attdgrbBy = new System.Windows.Forms.ComboBox();
            this.totalPrsnt = new System.Windows.Forms.Label();
            this.totalAbsnt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPackage = new System.Windows.Forms.Label();
            this.lblpaktype = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbLecture = new System.Windows.Forms.ComboBox();
            this.lblLecture = new System.Windows.Forms.Label();
            this.lblstream = new System.Windows.Forms.Label();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.dtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.chkViewAbsent = new System.Windows.Forms.CheckBox();
            this.chbFaculty = new System.Windows.Forms.CheckBox();
            this.chkAllBranch = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblcrse = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAttendanceSheet)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwSMS
            // 
            this.bgwSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSMS_DoWork);
            this.bgwSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSMS_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ADGVAttendanceSheet);
            this.panel2.Location = new System.Drawing.Point(248, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 485);
            this.panel2.TabIndex = 323;
            // 
            // ADGVAttendanceSheet
            // 
            this.ADGVAttendanceSheet.AllowUserToAddRows = false;
            this.ADGVAttendanceSheet.AllowUserToResizeRows = false;
            this.ADGVAttendanceSheet.AutoGenerateContextFilters = true;
            this.ADGVAttendanceSheet.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVAttendanceSheet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVAttendanceSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVAttendanceSheet.DateWithTime = false;
            this.ADGVAttendanceSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVAttendanceSheet.Location = new System.Drawing.Point(0, 0);
            this.ADGVAttendanceSheet.Name = "ADGVAttendanceSheet";
            this.ADGVAttendanceSheet.ReadOnly = true;
            this.ADGVAttendanceSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVAttendanceSheet.Size = new System.Drawing.Size(831, 485);
            this.ADGVAttendanceSheet.TabIndex = 1;
            this.ADGVAttendanceSheet.TimeFilter = false;
            this.ADGVAttendanceSheet.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVAttendanceSheet_DataBindingComplete);
            this.ADGVAttendanceSheet.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVAttendanceSheet_RowPostPaint_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblHours);
            this.panel4.Controls.Add(this.btnInstructorAttendance);
            this.panel4.Controls.Add(this.label40);
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.attdgrbBy);
            this.panel4.Controls.Add(this.totalPrsnt);
            this.panel4.Controls.Add(this.totalAbsnt);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(4, 217);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 485);
            this.panel4.TabIndex = 322;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblHours.Location = new System.Drawing.Point(149, 180);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(19, 20);
            this.lblHours.TabIndex = 409;
            this.lblHours.Text = "0";
            // 
            // btnInstructorAttendance
            // 
            this.btnInstructorAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInstructorAttendance.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnInstructorAttendance.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInstructorAttendance.FlatAppearance.BorderSize = 0;
            this.btnInstructorAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstructorAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructorAttendance.ForeColor = System.Drawing.Color.White;
            this.btnInstructorAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInstructorAttendance.Location = new System.Drawing.Point(26, 324);
            this.btnInstructorAttendance.Name = "btnInstructorAttendance";
            this.btnInstructorAttendance.Size = new System.Drawing.Size(184, 33);
            this.btnInstructorAttendance.TabIndex = 14;
            this.btnInstructorAttendance.Text = "INSTRUCTOR ATTENDANCE";
            this.btnInstructorAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstructorAttendance.UseVisualStyleBackColor = false;
            this.btnInstructorAttendance.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label40.Location = new System.Drawing.Point(12, 180);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(112, 20);
            this.label40.TabIndex = 408;
            this.label40.Text = "Total Hours :";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.Location = new System.Drawing.Point(73, 274);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 33);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "SEND";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
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
            this.btnSave.Location = new System.Drawing.Point(73, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(-1, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 20);
            this.label12.TabIndex = 335;
            this.label12.Text = "Group By :";
            this.label12.Visible = false;
            // 
            // attdgrbBy
            // 
            this.attdgrbBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attdgrbBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attdgrbBy.FormattingEnabled = true;
            this.attdgrbBy.Items.AddRange(new object[] {
            "Stream",
            "Course",
            "Batch"});
            this.attdgrbBy.Location = new System.Drawing.Point(94, 43);
            this.attdgrbBy.Name = "attdgrbBy";
            this.attdgrbBy.Size = new System.Drawing.Size(139, 24);
            this.attdgrbBy.TabIndex = 11;
            this.attdgrbBy.Visible = false;
            this.attdgrbBy.SelectedIndexChanged += new System.EventHandler(this.attdgrbBy_SelectedIndexChanged);
            // 
            // totalPrsnt
            // 
            this.totalPrsnt.AutoSize = true;
            this.totalPrsnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrsnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.totalPrsnt.Location = new System.Drawing.Point(148, 104);
            this.totalPrsnt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPrsnt.Name = "totalPrsnt";
            this.totalPrsnt.Size = new System.Drawing.Size(19, 20);
            this.totalPrsnt.TabIndex = 334;
            this.totalPrsnt.Text = "0";
            // 
            // totalAbsnt
            // 
            this.totalAbsnt.AutoSize = true;
            this.totalAbsnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAbsnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.totalAbsnt.Location = new System.Drawing.Point(148, 145);
            this.totalAbsnt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalAbsnt.Name = "totalAbsnt";
            this.totalAbsnt.Size = new System.Drawing.Size(19, 20);
            this.totalAbsnt.TabIndex = 333;
            this.totalAbsnt.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(10, 145);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 20);
            this.label10.TabIndex = 332;
            this.label10.Text = "Avg Absents :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(12, 104);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 331;
            this.label9.Text = "Avg Presents :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 147);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblPackage);
            this.panel3.Controls.Add(this.lblpaktype);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.cmbLecture);
            this.panel3.Controls.Add(this.lblLecture);
            this.panel3.Controls.Add(this.lblstream);
            this.panel3.Controls.Add(this.cmbStream);
            this.panel3.Controls.Add(this.dtpFromdate);
            this.panel3.Controls.Add(this.chkViewAbsent);
            this.panel3.Controls.Add(this.chbFaculty);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtpToDate);
            this.panel3.Controls.Add(this.cmbCourseType);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblcrse);
            this.panel3.Controls.Add(this.cmbBatch);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1078, 145);
            this.panel3.TabIndex = 78;
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPackage.Location = new System.Drawing.Point(4, 22);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(79, 20);
            this.lblPackage.TabIndex = 416;
            this.lblPackage.Text = "Package :";
            this.lblPackage.Visible = false;
            // 
            // lblpaktype
            // 
            this.lblpaktype.AutoSize = true;
            this.lblpaktype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaktype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblpaktype.Location = new System.Drawing.Point(326, 24);
            this.lblpaktype.Name = "lblpaktype";
            this.lblpaktype.Size = new System.Drawing.Size(113, 20);
            this.lblpaktype.TabIndex = 415;
            this.lblpaktype.Text = "PackageType :";
            this.lblpaktype.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::ClassManager.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(960, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 33);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "SEARCH   ";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbLecture
            // 
            this.cmbLecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLecture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLecture.FormattingEnabled = true;
            this.cmbLecture.Location = new System.Drawing.Point(376, 110);
            this.cmbLecture.Name = "cmbLecture";
            this.cmbLecture.Size = new System.Drawing.Size(288, 24);
            this.cmbLecture.TabIndex = 9;
            this.cmbLecture.SelectedIndexChanged += new System.EventHandler(this.cmbLecture_SelectedIndexChanged);
            // 
            // lblLecture
            // 
            this.lblLecture.AutoSize = true;
            this.lblLecture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblLecture.Location = new System.Drawing.Point(297, 110);
            this.lblLecture.Name = "lblLecture";
            this.lblLecture.Size = new System.Drawing.Size(71, 20);
            this.lblLecture.TabIndex = 339;
            this.lblLecture.Text = "Lecture :";
            // 
            // lblstream
            // 
            this.lblstream.AutoSize = true;
            this.lblstream.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblstream.Location = new System.Drawing.Point(4, 18);
            this.lblstream.Name = "lblstream";
            this.lblstream.Size = new System.Drawing.Size(69, 20);
            this.lblstream.TabIndex = 2;
            this.lblstream.Text = "Stream :";
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(88, 16);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(203, 26);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromdate.Location = new System.Drawing.Point(88, 75);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Size = new System.Drawing.Size(138, 22);
            this.dtpFromdate.TabIndex = 5;
            this.dtpFromdate.CloseUp += new System.EventHandler(this.dtpFromdate_CloseUp);
            // 
            // chkViewAbsent
            // 
            this.chkViewAbsent.AutoSize = true;
            this.chkViewAbsent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAbsent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkViewAbsent.Location = new System.Drawing.Point(131, 110);
            this.chkViewAbsent.Name = "chkViewAbsent";
            this.chkViewAbsent.Size = new System.Drawing.Size(114, 24);
            this.chkViewAbsent.TabIndex = 7;
            this.chkViewAbsent.Text = "Absent Only";
            this.chkViewAbsent.UseVisualStyleBackColor = true;
            this.chkViewAbsent.CheckedChanged += new System.EventHandler(this.chkViewAbsent_CheckedChanged);
            // 
            // chbFaculty
            // 
            this.chbFaculty.AutoSize = true;
            this.chbFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chbFaculty.Location = new System.Drawing.Point(29, 110);
            this.chbFaculty.Name = "chbFaculty";
            this.chbFaculty.Size = new System.Drawing.Size(96, 24);
            this.chbFaculty.TabIndex = 8;
            this.chbFaculty.Text = "Instructor";
            this.chbFaculty.UseVisualStyleBackColor = true;
            this.chbFaculty.CheckedChanged += new System.EventHandler(this.chbFaculty_CheckedChanged);
            // 
            // chkAllBranch
            // 
            this.chkAllBranch.AutoSize = true;
            this.chkAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllBranch.ForeColor = System.Drawing.Color.White;
            this.chkAllBranch.Location = new System.Drawing.Point(865, 35);
            this.chkAllBranch.Name = "chkAllBranch";
            this.chkAllBranch.Size = new System.Drawing.Size(200, 24);
            this.chkAllBranch.TabIndex = 4;
            this.chkAllBranch.Text = "Show All Branches Data";
            this.chkAllBranch.UseVisualStyleBackColor = true;
            this.chkAllBranch.CheckedChanged += new System.EventHandler(this.chkBranchID_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(28, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "From :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(376, 75);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 22);
            this.dtpToDate.TabIndex = 6;
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseType.FormattingEnabled = true;
            this.cmbCourseType.Location = new System.Drawing.Point(447, 20);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(188, 24);
            this.cmbCourseType.TabIndex = 2;
            this.cmbCourseType.SelectedIndexChanged += new System.EventHandler(this.cmbCourseType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(334, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "To :";
            // 
            // lblcrse
            // 
            this.lblcrse.AutoSize = true;
            this.lblcrse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcrse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblcrse.Location = new System.Drawing.Point(373, 24);
            this.lblcrse.Name = "lblcrse";
            this.lblcrse.Size = new System.Drawing.Size(68, 20);
            this.lblcrse.TabIndex = 3;
            this.lblcrse.Text = "Course :";
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(723, 20);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(177, 24);
            this.cmbBatch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(658, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Batch :";
            // 
            // FrmAttendanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1090, 710);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkAllBranch);
            this.MaximizeBox = false;
            this.Name = "FrmAttendanceSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttendanceSheet_FormClosing);
            this.Load += new System.EventHandler(this.AttendanceSheet_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVAttendanceSheet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblstream;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.ComboBox cmbCourseType;
        private System.Windows.Forms.Label lblcrse;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFromdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.CheckBox chkViewAbsent;
        private ADGV.AdvancedDataGridView ADGVAttendance;
        private ADGV.AdvancedDataGridView ADGVAttendanceSheet;
        private System.Windows.Forms.CheckBox chbFaculty;
        private System.Windows.Forms.CheckBox chkAllBranch;
        private System.ComponentModel.BackgroundWorker bgwSMS;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label totalPrsnt;
        private System.Windows.Forms.Label totalAbsnt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox attdgrbBy;
        private System.Windows.Forms.ComboBox cmbLecture;
        private System.Windows.Forms.Label lblLecture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Label lblpaktype;
        private System.Windows.Forms.Button btnInstructorAttendance;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label label40;
    }
}
