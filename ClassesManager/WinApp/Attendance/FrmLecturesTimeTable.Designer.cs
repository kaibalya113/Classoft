namespace ClassManager.WinApp
{
    partial class FrmLecturesTimeTable
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
            this.tabLecture = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ADGVLectureDetails = new ADGV.AdvancedDataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowLect = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnReset = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ADGVLectures = new ADGV.AdvancedDataGridView();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAdd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnShow = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cmbBtch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toTime = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.fromTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStrm = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.dtpLect = new System.Windows.Forms.DateTimePicker();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubj = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblfaculty = new System.Windows.Forms.Label();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.bgwLectureSMS = new System.ComponentModel.BackgroundWorker();
            this.tabLecture.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVLectureDetails)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVLectures)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLecture
            // 
            this.tabLecture.Controls.Add(this.tabPage3);
            this.tabLecture.Controls.Add(this.tabPage4);
            this.tabLecture.Depth = 0;
            this.tabLecture.Location = new System.Drawing.Point(3, 115);
            this.tabLecture.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabLecture.Name = "tabLecture";
            this.tabLecture.SelectedIndex = 0;
            this.tabLecture.Size = new System.Drawing.Size(1029, 544);
            this.tabLecture.TabIndex = 5;
            this.tabLecture.SelectedIndexChanged += new System.EventHandler(this.tabLecture_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel8);
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1021, 518);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Lectures";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.ADGVLectureDetails);
            this.panel8.Location = new System.Drawing.Point(4, 177);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1012, 335);
            this.panel8.TabIndex = 1;
            // 
            // ADGVLectureDetails
            // 
            this.ADGVLectureDetails.AllowUserToAddRows = false;
            this.ADGVLectureDetails.AutoGenerateContextFilters = true;
            this.ADGVLectureDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVLectureDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVLectureDetails.ColumnHeadersHeight = 24;
            this.ADGVLectureDetails.DateWithTime = false;
            this.ADGVLectureDetails.Location = new System.Drawing.Point(0, -1);
            this.ADGVLectureDetails.Name = "ADGVLectureDetails";
            this.ADGVLectureDetails.ReadOnly = true;
            this.ADGVLectureDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVLectureDetails.Size = new System.Drawing.Size(1011, 333);
            this.ADGVLectureDetails.TabIndex = 21;
            this.ADGVLectureDetails.TimeFilter = true;
            this.ADGVLectureDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVLectureDetails_DataBindingComplete);
            this.ADGVLectureDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVLectureDetails_DataError);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.materialRaisedButton1);
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Controls.Add(this.btnRepeat);
            this.panel6.Controls.Add(this.btnSend);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.btnShowLect);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.dtpFrom);
            this.panel6.Controls.Add(this.cmbBatch);
            this.panel6.Controls.Add(this.dtpTo);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.cmbStream);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.cmbCourseType);
            this.panel6.Location = new System.Drawing.Point(6, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1010, 168);
            this.panel6.TabIndex = 0;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.BackColor = System.Drawing.Color.White;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(456, 119);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(121, 33);
            this.materialRaisedButton1.TabIndex = 389;
            this.materialRaisedButton1.Text = "Update";
            this.materialRaisedButton1.UseVisualStyleBackColor = false;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
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
            this.btnPrint.Location = new System.Drawing.Point(929, 115);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(76, 35);
            this.btnPrint.TabIndex = 388;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRepeat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRepeat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRepeat.FlatAppearance.BorderSize = 0;
            this.btnRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepeat.ForeColor = System.Drawing.Color.White;
            this.btnRepeat.Image = global::ClassManager.Properties.Resources.repeat;
            this.btnRepeat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepeat.Location = new System.Drawing.Point(720, 119);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(90, 31);
            this.btnRepeat.TabIndex = 7;
            this.btnRepeat.Text = "REPEAT";
            this.btnRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepeat.UseVisualStyleBackColor = false;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.Location = new System.Drawing.Point(827, 117);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 33);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "SEND";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(716, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 387;
            this.label3.Text = "Batch :";
            // 
            // btnShowLect
            // 
            this.btnShowLect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowLect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowLect.BackColor = System.Drawing.Color.White;
            this.btnShowLect.Depth = 0;
            this.btnShowLect.Location = new System.Drawing.Point(593, 119);
            this.btnShowLect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShowLect.Name = "btnShowLect";
            this.btnShowLect.Primary = true;
            this.btnShowLect.Size = new System.Drawing.Size(112, 32);
            this.btnShowLect.TabIndex = 6;
            this.btnShowLect.Text = "Show Lecture";
            this.btnShowLect.UseVisualStyleBackColor = false;
            this.btnShowLect.Click += new System.EventHandler(this.btnShowLect_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(542, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 20);
            this.label15.TabIndex = 95;
            this.label15.Text = "To :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(297, 74);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(155, 22);
            this.dtpFrom.TabIndex = 4;
            this.dtpFrom.Value = new System.DateTime(2017, 1, 14, 0, 0, 0, 0);
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(788, 19);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(148, 24);
            this.cmbBatch.TabIndex = 3;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(620, 70);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(145, 22);
            this.dtpTo.TabIndex = 5;
            this.dtpTo.Value = new System.DateTime(2017, 1, 14, 0, 0, 0, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label16.Location = new System.Drawing.Point(196, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 20);
            this.label16.TabIndex = 88;
            this.label16.Text = "From :";
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(83, 19);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(155, 24);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "Stream :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(373, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "Course :";
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseType.FormattingEnabled = true;
            this.cmbCourseType.Location = new System.Drawing.Point(456, 19);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(149, 24);
            this.cmbCourseType.TabIndex = 2;
            this.cmbCourseType.SelectedIndexChanged += new System.EventHandler(this.cmbCourseType_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel11);
            this.tabPage4.Controls.Add(this.panel10);
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1021, 518);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Create Lectures";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.btnSave);
            this.panel11.Controls.Add(this.btnReset);
            this.panel11.Location = new System.Drawing.Point(3, 455);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1015, 54);
            this.panel11.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(749, 11);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(112, 33);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Depth = 0;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(880, 11);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Primary = true;
            this.btnReset.Size = new System.Drawing.Size(112, 33);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.ADGVLectures);
            this.panel10.Location = new System.Drawing.Point(3, 155);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1022, 294);
            this.panel10.TabIndex = 1;
            // 
            // ADGVLectures
            // 
            this.ADGVLectures.AllowUserToAddRows = false;
            this.ADGVLectures.AllowUserToResizeColumns = false;
            this.ADGVLectures.AllowUserToResizeRows = false;
            this.ADGVLectures.AutoGenerateContextFilters = true;
            this.ADGVLectures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVLectures.BackgroundColor = System.Drawing.Color.White;
            this.ADGVLectures.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVLectures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVLectures.ColumnHeadersHeight = 24;
            this.ADGVLectures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnDelete});
            this.ADGVLectures.DateWithTime = false;
            this.ADGVLectures.Location = new System.Drawing.Point(-3, 0);
            this.ADGVLectures.Name = "ADGVLectures";
            this.ADGVLectures.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ADGVLectures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVLectures.Size = new System.Drawing.Size(1021, 294);
            this.ADGVLectures.TabIndex = 22;
            this.ADGVLectures.TimeFilter = true;
            this.ADGVLectures.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVLectures_CellContentClick);
            this.ADGVLectures.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVLectures_DataBindingComplete);
            this.ADGVLectures.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVLectures_DataError);
            this.ADGVLectures.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVLectures_RowPostPaint);
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.MinimumWidth = 22;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.btnDelete.Text = "Delete";
            this.btnDelete.ToolTipText = "Delete";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 79;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.txtAddress);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Controls.Add(this.btnAdd);
            this.panel9.Controls.Add(this.btnShow);
            this.panel9.Controls.Add(this.cmbBtch);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.toTime);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.fromTime);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.cmbStrm);
            this.panel9.Controls.Add(this.cmbCourse);
            this.panel9.Controls.Add(this.dtpLect);
            this.panel9.Controls.Add(this.lblSubject);
            this.panel9.Controls.Add(this.cmbSubj);
            this.panel9.Controls.Add(this.label14);
            this.panel9.Controls.Add(this.cmbFaculty);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.lblfaculty);
            this.panel9.Location = new System.Drawing.Point(4, 7);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1011, 142);
            this.panel9.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(678, 46);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(182, 48);
            this.txtAddress.TabIndex = 94;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(550, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 18);
            this.label10.TabIndex = 93;
            this.label10.Text = "Expected Portion:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Depth = 0;
            this.btnAdd.Location = new System.Drawing.Point(876, 10);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Primary = true;
            this.btnAdd.Size = new System.Drawing.Size(121, 33);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShow.BackColor = System.Drawing.Color.White;
            this.btnShow.Depth = 0;
            this.btnShow.Location = new System.Drawing.Point(876, 91);
            this.btnShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShow.Name = "btnShow";
            this.btnShow.Primary = true;
            this.btnShow.Size = new System.Drawing.Size(121, 33);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "Show Lectures";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cmbBtch
            // 
            this.cmbBtch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBtch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBtch.FormattingEnabled = true;
            this.cmbBtch.Location = new System.Drawing.Point(614, 9);
            this.cmbBtch.Name = "cmbBtch";
            this.cmbBtch.Size = new System.Drawing.Size(121, 24);
            this.cmbBtch.TabIndex = 3;
            this.cmbBtch.SelectedIndexChanged += new System.EventHandler(this.cmbBtch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(549, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 90;
            this.label8.Text = "Batch :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(5, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 86;
            this.label11.Text = "Stream :";
            // 
            // toTime
            // 
            this.toTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toTime.Location = new System.Drawing.Point(594, 102);
            this.toTime.Name = "toTime";
            this.toTime.ShowUpDown = true;
            this.toTime.Size = new System.Drawing.Size(119, 22);
            this.toTime.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 86;
            this.label9.Text = "Stream :";
            // 
            // fromTime
            // 
            this.fromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromTime.Location = new System.Drawing.Point(366, 100);
            this.fromTime.Name = "fromTime";
            this.fromTime.ShowUpDown = true;
            this.fromTime.Size = new System.Drawing.Size(147, 22);
            this.fromTime.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(549, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 81;
            this.label6.Text = "To  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(282, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 88;
            this.label2.Text = "Course :";
            // 
            // cmbStrm
            // 
            this.cmbStrm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStrm.FormattingEnabled = true;
            this.cmbStrm.Location = new System.Drawing.Point(97, 10);
            this.cmbStrm.Name = "cmbStrm";
            this.cmbStrm.Size = new System.Drawing.Size(156, 24);
            this.cmbStrm.TabIndex = 1;
            this.cmbStrm.SelectedIndexChanged += new System.EventHandler(this.cmbStrm_SelectedIndexChanged);
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(366, 9);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(147, 24);
            this.cmbCourse.TabIndex = 2;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // dtpLect
            // 
            this.dtpLect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLect.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLect.Location = new System.Drawing.Point(97, 102);
            this.dtpLect.Name = "dtpLect";
            this.dtpLect.Size = new System.Drawing.Size(156, 22);
            this.dtpLect.TabIndex = 6;
            this.dtpLect.CloseUp += new System.EventHandler(this.dtpLect_CloseUp);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblSubject.Location = new System.Drawing.Point(5, 57);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(71, 20);
            this.lblSubject.TabIndex = 68;
            this.lblSubject.Text = "Subject :";
            this.lblSubject.Visible = false;
            // 
            // cmbSubj
            // 
            this.cmbSubj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubj.FormattingEnabled = true;
            this.cmbSubj.Location = new System.Drawing.Point(97, 55);
            this.cmbSubj.Name = "cmbSubj";
            this.cmbSubj.Size = new System.Drawing.Size(156, 24);
            this.cmbSubj.TabIndex = 4;
            this.cmbSubj.Visible = false;
            this.cmbSubj.SelectedIndexChanged += new System.EventHandler(this.cmbSubj_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(5, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 20);
            this.label14.TabIndex = 85;
            this.label14.Text = "Date :";
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.ItemHeight = 16;
            this.cmbFaculty.Location = new System.Drawing.Point(366, 53);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(147, 24);
            this.cmbFaculty.TabIndex = 5;
            this.cmbFaculty.Visible = false;
            this.cmbFaculty.SelectedIndexChanged += new System.EventHandler(this.cmbFaculty_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(282, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Faculty :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(282, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "From :";
            // 
            // lblfaculty
            // 
            this.lblfaculty.AutoSize = true;
            this.lblfaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfaculty.ForeColor = System.Drawing.Color.White;
            this.lblfaculty.Location = new System.Drawing.Point(611, 48);
            this.lblfaculty.Name = "lblfaculty";
            this.lblfaculty.Size = new System.Drawing.Size(61, 17);
            this.lblfaculty.TabIndex = 66;
            this.lblfaculty.Text = "Faculty :";
            this.lblfaculty.Visible = false;
            this.lblfaculty.Click += new System.EventHandler(this.lblfaculty_Click);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.tabLecture;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(2, 65);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1030, 44);
            this.materialTabSelector1.TabIndex = 4;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // bgwLectureSMS
            // 
            this.bgwLectureSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLectureSMS_RunWorkerCompleted);
            // 
            // FrmLecturesTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1035, 665);
            this.Controls.Add(this.tabLecture);
            this.Controls.Add(this.materialTabSelector1);
            this.MaximizeBox = false;
            this.Name = "FrmLecturesTimeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeTable";
            this.Load += new System.EventHandler(this.LecturesTimeTable_Load);
            this.tabLecture.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVLectureDetails)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVLectures)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cmbCourseType;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.DateTimePicker fromTime;
        private System.Windows.Forms.DateTimePicker dtpLect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBtch;
        private System.Windows.Forms.ComboBox cmbStrm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubj;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl tabLecture;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel8;
        private ADGV.AdvancedDataGridView ADGVLectureDetails;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private ADGV.AdvancedDataGridView ADGVLectures;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker toTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton btnShowLect;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialRaisedButton btnReset;
        private MaterialSkin.Controls.MaterialRaisedButton btnAdd;
        private MaterialSkin.Controls.MaterialRaisedButton btnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnRepeat;
        private System.ComponentModel.BackgroundWorker bgwLectureSMS;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblfaculty;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}
