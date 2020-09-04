namespace ClassManager.WinApp
{
    partial class FrmAddFacilities
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbbCourse = new System.Windows.Forms.ComboBox();
            this.bgwStudRegistred = new System.ComponentModel.BackgroundWorker();
            this.ttpCommon = new System.Windows.Forms.ToolTip(this.components);
            this.dtpPayStrt = new System.Windows.Forms.DateTimePicker();
            this.dtpPayStart = new System.Windows.Forms.DateTimePicker();
            this.dtpAdmissionDt = new System.Windows.Forms.DateTimePicker();
            this.chkOnetimeDiscount = new System.Windows.Forms.CheckBox();
            this.dtExpDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFacilitiesDtls = new System.Windows.Forms.Panel();
            this.pnlFinalCourses = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemoveSubject = new System.Windows.Forms.Button();
            this.btnViewInstallments = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtPayable = new System.Windows.Forms.Label();
            this.txtTotalDiscount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbSelectedPackages = new System.Windows.Forms.ListBox();
            this.pnlPkgDtls = new System.Windows.Forms.Panel();
            this.txtReason = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.btnScheduleLect = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtLectureCount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBiometricId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRollNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDiscount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.btnAddPackage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackgCost = new System.Windows.Forms.Label();
            this.cmbBatches = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLecture = new System.Windows.Forms.Panel();
            this.btnLectSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ADGVLecture = new ADGV.AdvancedDataGridView();
            this.btnLectureAdd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ToTime = new System.Windows.Forms.DateTimePicker();
            this.fromTime = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.cmbPack = new System.Windows.Forms.ComboBox();
            this.cmbStd = new System.Windows.Forms.ComboBox();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFacilitiesDtls.SuspendLayout();
            this.pnlFinalCourses.SuspendLayout();
            this.pnlPkgDtls.SuspendLayout();
            this.pnlLecture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVLecture)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbbCourse
            // 
            this.cmbbCourse.AccessibleDescription = "";
            this.cmbbCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbbCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbCourse.FormattingEnabled = true;
            this.cmbbCourse.Location = new System.Drawing.Point(121, 16);
            this.cmbbCourse.Name = "cmbbCourse";
            this.cmbbCourse.Size = new System.Drawing.Size(185, 24);
            this.cmbbCourse.TabIndex = 38;
            // 
            // bgwStudRegistred
            // 
            this.bgwStudRegistred.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwStudRegistred_DoWork);
            this.bgwStudRegistred.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwStudRegistred_RunWorkerCompleted);
            // 
            // dtpPayStrt
            // 
            this.dtpPayStrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPayStrt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPayStrt.Location = new System.Drawing.Point(145, 111);
            this.dtpPayStrt.Name = "dtpPayStrt";
            this.dtpPayStrt.Size = new System.Drawing.Size(114, 22);
            this.dtpPayStrt.TabIndex = 11;
            this.ttpCommon.SetToolTip(this.dtpPayStrt, "Fees collection start date");
            this.dtpPayStrt.ValueChanged += new System.EventHandler(this.dtpPayStart_ValueChanged);
            // 
            // dtpPayStart
            // 
            this.dtpPayStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPayStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPayStart.Location = new System.Drawing.Point(147, 147);
            this.dtpPayStart.Name = "dtpPayStart";
            this.dtpPayStart.Size = new System.Drawing.Size(113, 22);
            this.dtpPayStart.TabIndex = 8;
            this.dtpPayStart.TabStop = false;
            this.ttpCommon.SetToolTip(this.dtpPayStart, "Date from which fees should be collected");
            this.dtpPayStart.Visible = false;
            this.dtpPayStart.ValueChanged += new System.EventHandler(this.dtpPayStart_ValueChanged);
            // 
            // dtpAdmissionDt
            // 
            this.dtpAdmissionDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAdmissionDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdmissionDt.Location = new System.Drawing.Point(145, 74);
            this.dtpAdmissionDt.Name = "dtpAdmissionDt";
            this.dtpAdmissionDt.Size = new System.Drawing.Size(114, 22);
            this.dtpAdmissionDt.TabIndex = 10;
            this.ttpCommon.SetToolTip(this.dtpAdmissionDt, "Date when this course is taken by student");
            this.dtpAdmissionDt.ValueChanged += new System.EventHandler(this.dtpAdmissionDt_ValueChanged);
            // 
            // chkOnetimeDiscount
            // 
            this.chkOnetimeDiscount.AutoSize = true;
            this.chkOnetimeDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnetimeDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkOnetimeDiscount.Location = new System.Drawing.Point(730, 50);
            this.chkOnetimeDiscount.Name = "chkOnetimeDiscount";
            this.chkOnetimeDiscount.Size = new System.Drawing.Size(96, 24);
            this.chkOnetimeDiscount.TabIndex = 4;
            this.chkOnetimeDiscount.Text = "One Time";
            this.ttpCommon.SetToolTip(this.chkOnetimeDiscount, "Discound will be applicable only once in case of Monthly,Quartly or Half Yearly c" +
        "ourses");
            this.chkOnetimeDiscount.UseVisualStyleBackColor = true;
            this.chkOnetimeDiscount.Visible = false;
            // 
            // dtExpDate
            // 
            this.dtExpDate.Enabled = false;
            this.dtExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpDate.Location = new System.Drawing.Point(146, 147);
            this.dtExpDate.Name = "dtExpDate";
            this.dtExpDate.Size = new System.Drawing.Size(114, 22);
            this.dtExpDate.TabIndex = 13;
            this.dtExpDate.Visible = false;
            // 
            // pnlFacilitiesDtls
            // 
            this.pnlFacilitiesDtls.BackColor = System.Drawing.Color.White;
            this.pnlFacilitiesDtls.Controls.Add(this.pnlFinalCourses);
            this.pnlFacilitiesDtls.Controls.Add(this.pnlPkgDtls);
            this.pnlFacilitiesDtls.Location = new System.Drawing.Point(14, 177);
            this.pnlFacilitiesDtls.Name = "pnlFacilitiesDtls";
            this.pnlFacilitiesDtls.Size = new System.Drawing.Size(855, 242);
            this.pnlFacilitiesDtls.TabIndex = 51;
            // 
            // pnlFinalCourses
            // 
            this.pnlFinalCourses.BackColor = System.Drawing.Color.White;
            this.pnlFinalCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFinalCourses.Controls.Add(this.btnSave);
            this.pnlFinalCourses.Controls.Add(this.btnRemoveSubject);
            this.pnlFinalCourses.Controls.Add(this.btnViewInstallments);
            this.pnlFinalCourses.Controls.Add(this.txtPayable);
            this.pnlFinalCourses.Controls.Add(this.txtTotalDiscount);
            this.pnlFinalCourses.Controls.Add(this.label13);
            this.pnlFinalCourses.Controls.Add(this.label8);
            this.pnlFinalCourses.Controls.Add(this.label14);
            this.pnlFinalCourses.Controls.Add(this.cmbSelectedPackages);
            this.pnlFinalCourses.Location = new System.Drawing.Point(522, 3);
            this.pnlFinalCourses.Name = "pnlFinalCourses";
            this.pnlFinalCourses.Size = new System.Drawing.Size(325, 232);
            this.pnlFinalCourses.TabIndex = 391;
            this.pnlFinalCourses.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFinalCourses_Paint);
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
            this.btnSave.Location = new System.Drawing.Point(206, 194);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 33);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "SAVE      ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemoveSubject
            // 
            this.btnRemoveSubject.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRemoveSubject.FlatAppearance.BorderSize = 0;
            this.btnRemoveSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSubject.ForeColor = System.Drawing.Color.White;
            this.btnRemoveSubject.Image = global::ClassManager.Properties.Resources.folder_remove_button;
            this.btnRemoveSubject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveSubject.Location = new System.Drawing.Point(207, 23);
            this.btnRemoveSubject.Name = "btnRemoveSubject";
            this.btnRemoveSubject.Size = new System.Drawing.Size(112, 33);
            this.btnRemoveSubject.TabIndex = 20;
            this.btnRemoveSubject.Text = "REMOVE   ";
            this.btnRemoveSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveSubject.UseVisualStyleBackColor = false;
            this.btnRemoveSubject.Click += new System.EventHandler(this.btnRemoveSubject_Click);
            // 
            // btnViewInstallments
            // 
            this.btnViewInstallments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewInstallments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewInstallments.BackColor = System.Drawing.Color.White;
            this.btnViewInstallments.Depth = 0;
            this.btnViewInstallments.Location = new System.Drawing.Point(207, 72);
            this.btnViewInstallments.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewInstallments.Name = "btnViewInstallments";
            this.btnViewInstallments.Primary = true;
            this.btnViewInstallments.Size = new System.Drawing.Size(112, 33);
            this.btnViewInstallments.TabIndex = 21;
            this.btnViewInstallments.Text = "Installments";
            this.btnViewInstallments.UseVisualStyleBackColor = false;
            this.btnViewInstallments.Click += new System.EventHandler(this.btnViewInstallments_Click);
            // 
            // txtPayable
            // 
            this.txtPayable.AutoSize = true;
            this.txtPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtPayable.Location = new System.Drawing.Point(125, 163);
            this.txtPayable.Name = "txtPayable";
            this.txtPayable.Size = new System.Drawing.Size(29, 20);
            this.txtPayable.TabIndex = 395;
            this.txtPayable.Text = "00";
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.AutoSize = true;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtTotalDiscount.Location = new System.Drawing.Point(125, 124);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(29, 20);
            this.txtTotalDiscount.TabIndex = 394;
            this.txtTotalDiscount.Text = "00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(4, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 393;
            this.label13.Text = "Fees Payable :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(4, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 392;
            this.label8.Text = "Courses Selected";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(4, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 20);
            this.label14.TabIndex = 391;
            this.label14.Text = "Total Discount :";
            // 
            // cmbSelectedPackages
            // 
            this.cmbSelectedPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelectedPackages.FormattingEnabled = true;
            this.cmbSelectedPackages.ItemHeight = 16;
            this.cmbSelectedPackages.Location = new System.Drawing.Point(7, 25);
            this.cmbSelectedPackages.Name = "cmbSelectedPackages";
            this.cmbSelectedPackages.Size = new System.Drawing.Size(181, 84);
            this.cmbSelectedPackages.TabIndex = 19;
            this.cmbSelectedPackages.Click += new System.EventHandler(this.cmbSelectedPackages_Click);
            // 
            // pnlPkgDtls
            // 
            this.pnlPkgDtls.BackColor = System.Drawing.Color.White;
            this.pnlPkgDtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPkgDtls.Controls.Add(this.txtReason);
            this.pnlPkgDtls.Controls.Add(this.label7);
            this.pnlPkgDtls.Controls.Add(this.btnScheduleLect);
            this.pnlPkgDtls.Controls.Add(this.txtLectureCount);
            this.pnlPkgDtls.Controls.Add(this.txtBiometricId);
            this.pnlPkgDtls.Controls.Add(this.dtpPayStrt);
            this.pnlPkgDtls.Controls.Add(this.label10);
            this.pnlPkgDtls.Controls.Add(this.txtRollNo);
            this.pnlPkgDtls.Controls.Add(this.txtDiscount);
            this.pnlPkgDtls.Controls.Add(this.dtExpDate);
            this.pnlPkgDtls.Controls.Add(this.lblExpDate);
            this.pnlPkgDtls.Controls.Add(this.btnAddPackage);
            this.pnlPkgDtls.Controls.Add(this.label6);
            this.pnlPkgDtls.Controls.Add(this.dtpPayStart);
            this.pnlPkgDtls.Controls.Add(this.label2);
            this.pnlPkgDtls.Controls.Add(this.txtPackgCost);
            this.pnlPkgDtls.Controls.Add(this.cmbBatches);
            this.pnlPkgDtls.Controls.Add(this.dtpAdmissionDt);
            this.pnlPkgDtls.Controls.Add(this.label11);
            this.pnlPkgDtls.Controls.Add(this.label1);
            this.pnlPkgDtls.Location = new System.Drawing.Point(3, 3);
            this.pnlPkgDtls.Name = "pnlPkgDtls";
            this.pnlPkgDtls.Size = new System.Drawing.Size(515, 232);
            this.pnlPkgDtls.TabIndex = 390;
            this.pnlPkgDtls.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPkgDtls_Paint);
            // 
            // txtReason
            // 
            this.txtReason.Depth = 0;
            this.txtReason.Hint = "Discount Reason";
            this.txtReason.Location = new System.Drawing.Point(384, 29);
            this.txtReason.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtReason.Name = "txtReason";
            this.txtReason.PasswordChar = '\0';
            this.txtReason.SelectedText = "";
            this.txtReason.SelectionLength = 0;
            this.txtReason.SelectionStart = 0;
            this.txtReason.Size = new System.Drawing.Size(116, 23);
            this.txtReason.TabIndex = 408;
            this.txtReason.TabStop = false;
            this.txtReason.UseSystemPasswordChar = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(273, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 407;
            this.label7.Text = "Batch :";
            // 
            // btnScheduleLect
            // 
            this.btnScheduleLect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScheduleLect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScheduleLect.BackColor = System.Drawing.Color.White;
            this.btnScheduleLect.Depth = 0;
            this.btnScheduleLect.Location = new System.Drawing.Point(236, 192);
            this.btnScheduleLect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnScheduleLect.Name = "btnScheduleLect";
            this.btnScheduleLect.Primary = true;
            this.btnScheduleLect.Size = new System.Drawing.Size(146, 33);
            this.btnScheduleLect.TabIndex = 16;
            this.btnScheduleLect.Text = "Schedule Sessions";
            this.btnScheduleLect.UseVisualStyleBackColor = false;
            this.btnScheduleLect.Visible = false;
            this.btnScheduleLect.Click += new System.EventHandler(this.btnScheduleLect_Click);
            // 
            // txtLectureCount
            // 
            this.txtLectureCount.Depth = 0;
            this.txtLectureCount.Hint = "No of Lectures";
            this.txtLectureCount.Location = new System.Drawing.Point(277, 145);
            this.txtLectureCount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLectureCount.Name = "txtLectureCount";
            this.txtLectureCount.PasswordChar = '\0';
            this.txtLectureCount.SelectedText = "";
            this.txtLectureCount.SelectionLength = 0;
            this.txtLectureCount.SelectionStart = 0;
            this.txtLectureCount.Size = new System.Drawing.Size(190, 23);
            this.txtLectureCount.TabIndex = 14;
            this.txtLectureCount.TabStop = false;
            this.txtLectureCount.UseSystemPasswordChar = false;
            this.txtLectureCount.Visible = false;
            // 
            // txtBiometricId
            // 
            this.txtBiometricId.Depth = 0;
            this.txtBiometricId.Hint = "Enter Biometric ID";
            this.txtBiometricId.Location = new System.Drawing.Point(277, 109);
            this.txtBiometricId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBiometricId.Name = "txtBiometricId";
            this.txtBiometricId.PasswordChar = '\0';
            this.txtBiometricId.SelectedText = "";
            this.txtBiometricId.SelectionLength = 0;
            this.txtBiometricId.SelectionStart = 0;
            this.txtBiometricId.Size = new System.Drawing.Size(190, 23);
            this.txtBiometricId.TabIndex = 12;
            this.txtBiometricId.TabStop = false;
            this.txtBiometricId.UseSystemPasswordChar = false;
            this.txtBiometricId.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(5, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 20);
            this.label10.TabIndex = 403;
            this.label10.Text = "Fees Start Date :";
            // 
            // txtRollNo
            // 
            this.txtRollNo.Depth = 0;
            this.txtRollNo.Hint = "Enter Roll No";
            this.txtRollNo.Location = new System.Drawing.Point(145, 29);
            this.txtRollNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.PasswordChar = '\0';
            this.txtRollNo.SelectedText = "";
            this.txtRollNo.SelectionLength = 0;
            this.txtRollNo.SelectionStart = 0;
            this.txtRollNo.Size = new System.Drawing.Size(115, 23);
            this.txtRollNo.TabIndex = 9;
            this.txtRollNo.UseSystemPasswordChar = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Depth = 0;
            this.txtDiscount.Hint = "Enter Discount";
            this.txtDiscount.Location = new System.Drawing.Point(269, 29);
            this.txtDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.SelectionLength = 0;
            this.txtDiscount.SelectionStart = 0;
            this.txtDiscount.Size = new System.Drawing.Size(104, 23);
            this.txtDiscount.TabIndex = 399;
            this.txtDiscount.UseSystemPasswordChar = false;
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblExpDate.Location = new System.Drawing.Point(5, 145);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(85, 20);
            this.lblExpDate.TabIndex = 397;
            this.lblExpDate.Text = "End Date :";
            this.lblExpDate.Visible = false;
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPackage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddPackage.BackColor = System.Drawing.Color.White;
            this.btnAddPackage.Depth = 0;
            this.btnAddPackage.Location = new System.Drawing.Point(391, 192);
            this.btnAddPackage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Primary = true;
            this.btnAddPackage.Size = new System.Drawing.Size(113, 33);
            this.btnAddPackage.TabIndex = 15;
            this.btnAddPackage.Text = "Add Packages";
            this.btnAddPackage.UseVisualStyleBackColor = false;
            this.btnAddPackage.Click += new System.EventHandler(this.btnAddPackage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(5, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 383;
            this.label6.Text = "Start Date :";
            this.label6.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 388;
            this.label2.Text = "Details";
            // 
            // txtPackgCost
            // 
            this.txtPackgCost.AutoSize = true;
            this.txtPackgCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackgCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtPackgCost.Location = new System.Drawing.Point(50, 32);
            this.txtPackgCost.Name = "txtPackgCost";
            this.txtPackgCost.Size = new System.Drawing.Size(41, 18);
            this.txtPackgCost.TabIndex = 387;
            this.txtPackgCost.Text = "cost";
            // 
            // cmbBatches
            // 
            this.cmbBatches.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBatches.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatches.FormattingEnabled = true;
            this.cmbBatches.Location = new System.Drawing.Point(335, 70);
            this.cmbBatches.Name = "cmbBatches";
            this.cmbBatches.Size = new System.Drawing.Size(160, 24);
            this.cmbBatches.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(5, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 385;
            this.label11.Text = "Admission Date :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 382;
            this.label1.Text = "Cost :";
            // 
            // pnlLecture
            // 
            this.pnlLecture.BackColor = System.Drawing.Color.White;
            this.pnlLecture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLecture.Controls.Add(this.btnLectSave);
            this.pnlLecture.Controls.Add(this.ADGVLecture);
            this.pnlLecture.Controls.Add(this.btnLectureAdd);
            this.pnlLecture.Controls.Add(this.ToTime);
            this.pnlLecture.Controls.Add(this.fromTime);
            this.pnlLecture.Controls.Add(this.label25);
            this.pnlLecture.Controls.Add(this.label24);
            this.pnlLecture.Controls.Add(this.label23);
            this.pnlLecture.Controls.Add(this.cmbDay);
            this.pnlLecture.Location = new System.Drawing.Point(17, 419);
            this.pnlLecture.Name = "pnlLecture";
            this.pnlLecture.Size = new System.Drawing.Size(515, 219);
            this.pnlLecture.TabIndex = 389;
            this.pnlLecture.Visible = false;
            // 
            // btnLectSave
            // 
            this.btnLectSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLectSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLectSave.BackColor = System.Drawing.Color.White;
            this.btnLectSave.Depth = 0;
            this.btnLectSave.Location = new System.Drawing.Point(453, 26);
            this.btnLectSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLectSave.Name = "btnLectSave";
            this.btnLectSave.Primary = true;
            this.btnLectSave.Size = new System.Drawing.Size(51, 33);
            this.btnLectSave.TabIndex = 349;
            this.btnLectSave.TabStop = false;
            this.btnLectSave.Text = "Save";
            this.btnLectSave.UseVisualStyleBackColor = false;
            this.btnLectSave.Visible = false;
            this.btnLectSave.Click += new System.EventHandler(this.btnLectSave_Click);
            // 
            // ADGVLecture
            // 
            this.ADGVLecture.AllowUserToAddRows = false;
            this.ADGVLecture.AllowUserToDeleteRows = false;
            this.ADGVLecture.AutoGenerateContextFilters = true;
            this.ADGVLecture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVLecture.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVLecture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVLecture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVLecture.DateWithTime = false;
            this.ADGVLecture.Location = new System.Drawing.Point(13, 73);
            this.ADGVLecture.Name = "ADGVLecture";
            this.ADGVLecture.ReadOnly = true;
            this.ADGVLecture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVLecture.Size = new System.Drawing.Size(487, 134);
            this.ADGVLecture.TabIndex = 348;
            this.ADGVLecture.TimeFilter = false;
            this.ADGVLecture.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVLecture_CellClick);
            this.ADGVLecture.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVLecture_DataBindingComplete);
            // 
            // btnLectureAdd
            // 
            this.btnLectureAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLectureAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLectureAdd.BackColor = System.Drawing.Color.White;
            this.btnLectureAdd.Depth = 0;
            this.btnLectureAdd.Location = new System.Drawing.Point(391, 26);
            this.btnLectureAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLectureAdd.Name = "btnLectureAdd";
            this.btnLectureAdd.Primary = true;
            this.btnLectureAdd.Size = new System.Drawing.Size(51, 33);
            this.btnLectureAdd.TabIndex = 41;
            this.btnLectureAdd.TabStop = false;
            this.btnLectureAdd.Text = "Add";
            this.btnLectureAdd.UseVisualStyleBackColor = false;
            this.btnLectureAdd.Click += new System.EventHandler(this.btnLectureAdd_Click);
            // 
            // ToTime
            // 
            this.ToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToTime.Location = new System.Drawing.Point(284, 37);
            this.ToTime.Name = "ToTime";
            this.ToTime.ShowUpDown = true;
            this.ToTime.Size = new System.Drawing.Size(98, 22);
            this.ToTime.TabIndex = 40;
            this.ToTime.TabStop = false;
            // 
            // fromTime
            // 
            this.fromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromTime.Location = new System.Drawing.Point(160, 37);
            this.fromTime.Name = "fromTime";
            this.fromTime.ShowUpDown = true;
            this.fromTime.Size = new System.Drawing.Size(98, 22);
            this.fromTime.TabIndex = 39;
            this.fromTime.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label25.Location = new System.Drawing.Point(163, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 20);
            this.label25.TabIndex = 38;
            this.label25.Text = "From :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label24.Location = new System.Drawing.Point(287, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 20);
            this.label24.TabIndex = 37;
            this.label24.Text = "To :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label23.Location = new System.Drawing.Point(15, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 20);
            this.label23.TabIndex = 36;
            this.label23.Text = "Day :";
            // 
            // cmbDay
            // 
            this.cmbDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbDay.Location = new System.Drawing.Point(13, 35);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(139, 24);
            this.cmbDay.TabIndex = 3;
            this.cmbDay.TabStop = false;
            this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.cmbDay_SelectedIndexChanged);
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.cmbPack);
            this.pnlDetails.Controls.Add(this.cmbStd);
            this.pnlDetails.Controls.Add(this.cmbStream);
            this.pnlDetails.Controls.Add(this.label4);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Controls.Add(this.chkOnetimeDiscount);
            this.pnlDetails.Location = new System.Drawing.Point(17, 78);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(844, 93);
            this.pnlDetails.TabIndex = 50;
            // 
            // cmbPack
            // 
            this.cmbPack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPack.FormattingEnabled = true;
            this.cmbPack.Location = new System.Drawing.Point(111, 46);
            this.cmbPack.Name = "cmbPack";
            this.cmbPack.Size = new System.Drawing.Size(200, 28);
            this.cmbPack.TabIndex = 3;
            this.cmbPack.SelectedIndexChanged += new System.EventHandler(this.cmbPack_SelectedIndexChanged);
            // 
            // cmbStd
            // 
            this.cmbStd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStd.FormattingEnabled = true;
            this.cmbStd.Location = new System.Drawing.Point(513, 11);
            this.cmbStd.Name = "cmbStd";
            this.cmbStd.Size = new System.Drawing.Size(182, 24);
            this.cmbStd.TabIndex = 2;
            this.cmbStd.SelectedIndexChanged += new System.EventHandler(this.cmbStd_SelectedIndexChanged);
            // 
            // cmbStream
            // 
            this.cmbStream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(111, 11);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(200, 24);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(27, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Stream :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(427, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Course :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(27, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Package :";
            // 
            // FrmAddFacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(877, 647);
            this.Controls.Add(this.pnlFacilitiesDtls);
            this.Controls.Add(this.pnlLecture);
            this.Controls.Add(this.pnlDetails);
            this.MaximizeBox = false;
            this.Name = "FrmAddFacilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFacilities";
            this.Load += new System.EventHandler(this.AddFacilities_Load);
            this.pnlFacilitiesDtls.ResumeLayout(false);
            this.pnlFinalCourses.ResumeLayout(false);
            this.pnlFinalCourses.PerformLayout();
            this.pnlPkgDtls.ResumeLayout(false);
            this.pnlPkgDtls.PerformLayout();
            this.pnlLecture.ResumeLayout(false);
            this.pnlLecture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVLecture)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.ComboBox cmbbCourse;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStd;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.ComponentModel.BackgroundWorker bgwStudRegistred;
        private System.Windows.Forms.Panel pnlFacilitiesDtls;
        private System.Windows.Forms.Panel pnlFinalCourses;
        private System.Windows.Forms.Label txtPayable;
        private System.Windows.Forms.Label txtTotalDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox cmbSelectedPackages;
        private System.Windows.Forms.Panel pnlPkgDtls;
        private System.Windows.Forms.ComboBox cmbPack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtPackgCost;
        private System.Windows.Forms.ComboBox cmbBatches;
        private System.Windows.Forms.CheckBox chkOnetimeDiscount;
        private System.Windows.Forms.DateTimePicker dtpAdmissionDt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpPayStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLecture;
        private System.Windows.Forms.ToolTip ttpCommon;
        private MaterialSkin.Controls.MaterialRaisedButton btnViewInstallments;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddPackage;
        private System.Windows.Forms.Button btnRemoveSubject;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtExpDate;
        private System.Windows.Forms.Label lblExpDate;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRollNo;
        private System.Windows.Forms.DateTimePicker dtpPayStrt;
        private System.Windows.Forms.Label label10;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLectureCount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBiometricId;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker ToTime;
        private System.Windows.Forms.DateTimePicker fromTime;
        private MaterialSkin.Controls.MaterialRaisedButton btnLectureAdd;
        private MaterialSkin.Controls.MaterialRaisedButton btnLectSave;
        private ADGV.AdvancedDataGridView ADGVLecture;
        private MaterialSkin.Controls.MaterialRaisedButton btnScheduleLect;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtReason;
    }
}