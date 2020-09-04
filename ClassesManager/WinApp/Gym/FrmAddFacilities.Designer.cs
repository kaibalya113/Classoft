namespace ClassManager.WinApp.Gym
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
            this.cmbbCourse = new System.Windows.Forms.ComboBox();
            this.bgwStudRegistred = new System.ComponentModel.BackgroundWorker();
            this.ttpCommon = new System.Windows.Forms.ToolTip(this.components);
            this.dtExpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPayStart = new System.Windows.Forms.DateTimePicker();
            this.chkOnetimeDiscount = new System.Windows.Forms.CheckBox();
            this.dtpAdmissionDt = new System.Windows.Forms.DateTimePicker();
            this.pnlFacilitiesDtls = new System.Windows.Forms.Panel();
            this.pnlPkgDtls = new System.Windows.Forms.Panel();
            this.cmbSelectedPackages = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtDiscount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPayable = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackgCost = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLumsum = new System.Windows.Forms.CheckBox();
            this.btnAddPackage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlFacilities = new System.Windows.Forms.Panel();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.btnViewInstallments = new System.Windows.Forms.Button();
            this.btnRemoveSubject = new System.Windows.Forms.Button();
            this.txtRollNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.txtTotalDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdPackageFacilities = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBatches = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPack = new System.Windows.Forms.ComboBox();
            this.cmbStd = new System.Windows.Forms.ComboBox();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bgwInvoice = new System.ComponentModel.BackgroundWorker();
            this.cmbInstructor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlFacilitiesDtls.SuspendLayout();
            this.pnlPkgDtls.SuspendLayout();
            this.pnlFacilities.SuspendLayout();
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
            // dtExpDate
            // 
            this.dtExpDate.Enabled = false;
            this.dtExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpDate.Location = new System.Drawing.Point(409, 140);
            this.dtExpDate.Name = "dtExpDate";
            this.dtExpDate.Size = new System.Drawing.Size(181, 22);
            this.dtExpDate.TabIndex = 8;
            this.ttpCommon.SetToolTip(this.dtExpDate, "Date from which fees should be collected");
            this.dtExpDate.ValueChanged += new System.EventHandler(this.dtExpDate_ValueChanged);
            // 
            // dtpPayStart
            // 
            this.dtpPayStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPayStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPayStart.Location = new System.Drawing.Point(99, 138);
            this.dtpPayStart.Name = "dtpPayStart";
            this.dtpPayStart.Size = new System.Drawing.Size(164, 22);
            this.dtpPayStart.TabIndex = 7;
            this.ttpCommon.SetToolTip(this.dtpPayStart, "Date from which fees should be collected");
            this.dtpPayStart.ValueChanged += new System.EventHandler(this.dtpPayStart_ValueChanged);
            // 
            // chkOnetimeDiscount
            // 
            this.chkOnetimeDiscount.AutoSize = true;
            this.chkOnetimeDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnetimeDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkOnetimeDiscount.Location = new System.Drawing.Point(293, 24);
            this.chkOnetimeDiscount.Name = "chkOnetimeDiscount";
            this.chkOnetimeDiscount.Size = new System.Drawing.Size(96, 24);
            this.chkOnetimeDiscount.TabIndex = 6;
            this.chkOnetimeDiscount.TabStop = false;
            this.chkOnetimeDiscount.Text = "One Time";
            this.ttpCommon.SetToolTip(this.chkOnetimeDiscount, "Discound will be applicable only once in case of Monthly,Quartly or Half Yearly c" +
        "ourses");
            this.chkOnetimeDiscount.UseVisualStyleBackColor = true;
            this.chkOnetimeDiscount.Visible = false;
            // 
            // dtpAdmissionDt
            // 
            this.dtpAdmissionDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAdmissionDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdmissionDt.Location = new System.Drawing.Point(11, 3);
            this.dtpAdmissionDt.Name = "dtpAdmissionDt";
            this.dtpAdmissionDt.Size = new System.Drawing.Size(114, 22);
            this.dtpAdmissionDt.TabIndex = 10;
            this.dtpAdmissionDt.TabStop = false;
            this.ttpCommon.SetToolTip(this.dtpAdmissionDt, "Date when this course is taken by student");
            this.dtpAdmissionDt.Visible = false;
            // 
            // pnlFacilitiesDtls
            // 
            this.pnlFacilitiesDtls.BackColor = System.Drawing.Color.White;
            this.pnlFacilitiesDtls.Controls.Add(this.pnlPkgDtls);
            this.pnlFacilitiesDtls.Controls.Add(this.btnAddPackage);
            this.pnlFacilitiesDtls.Controls.Add(this.pnlFacilities);
            this.pnlFacilitiesDtls.Location = new System.Drawing.Point(12, 173);
            this.pnlFacilitiesDtls.Name = "pnlFacilitiesDtls";
            this.pnlFacilitiesDtls.Size = new System.Drawing.Size(608, 261);
            this.pnlFacilitiesDtls.TabIndex = 51;
            // 
            // pnlPkgDtls
            // 
            this.pnlPkgDtls.BackColor = System.Drawing.Color.White;
            this.pnlPkgDtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPkgDtls.Controls.Add(this.cmbSelectedPackages);
            this.pnlPkgDtls.Controls.Add(this.btnSave);
            this.pnlPkgDtls.Controls.Add(this.label10);
            this.pnlPkgDtls.Controls.Add(this.txtReason);
            this.pnlPkgDtls.Controls.Add(this.lblReason);
            this.pnlPkgDtls.Controls.Add(this.txtDiscount);
            this.pnlPkgDtls.Controls.Add(this.dtExpDate);
            this.pnlPkgDtls.Controls.Add(this.txtPayable);
            this.pnlPkgDtls.Controls.Add(this.label20);
            this.pnlPkgDtls.Controls.Add(this.label13);
            this.pnlPkgDtls.Controls.Add(this.label2);
            this.pnlPkgDtls.Controls.Add(this.txtPackgCost);
            this.pnlPkgDtls.Controls.Add(this.dtpPayStart);
            this.pnlPkgDtls.Controls.Add(this.label6);
            this.pnlPkgDtls.Controls.Add(this.label1);
            this.pnlPkgDtls.Controls.Add(this.chkLumsum);
            this.pnlPkgDtls.Location = new System.Drawing.Point(0, 0);
            this.pnlPkgDtls.Name = "pnlPkgDtls";
            this.pnlPkgDtls.Size = new System.Drawing.Size(639, 253);
            this.pnlPkgDtls.TabIndex = 390;
            // 
            // cmbSelectedPackages
            // 
            this.cmbSelectedPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelectedPackages.FormattingEnabled = true;
            this.cmbSelectedPackages.ItemHeight = 16;
            this.cmbSelectedPackages.Location = new System.Drawing.Point(199, 18);
            this.cmbSelectedPackages.Name = "cmbSelectedPackages";
            this.cmbSelectedPackages.Size = new System.Drawing.Size(181, 20);
            this.cmbSelectedPackages.TabIndex = 4;
            this.cmbSelectedPackages.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(264, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 33);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "ADD";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(3, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 403;
            this.label10.Text = "Discount :";
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Location = new System.Drawing.Point(409, 72);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(181, 47);
            this.txtReason.TabIndex = 6;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblReason.Location = new System.Drawing.Point(309, 85);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(73, 20);
            this.lblReason.TabIndex = 394;
            this.lblReason.Text = "Reason :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Depth = 0;
            this.txtDiscount.Hint = "Enter Discount";
            this.txtDiscount.Location = new System.Drawing.Point(99, 85);
            this.txtDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.SelectionLength = 0;
            this.txtDiscount.SelectionStart = 0;
            this.txtDiscount.Size = new System.Drawing.Size(164, 23);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.UseSystemPasswordChar = false;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged_1);
            // 
            // txtPayable
            // 
            this.txtPayable.AutoSize = true;
            this.txtPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtPayable.Location = new System.Drawing.Point(125, 194);
            this.txtPayable.Name = "txtPayable";
            this.txtPayable.Size = new System.Drawing.Size(29, 20);
            this.txtPayable.TabIndex = 395;
            this.txtPayable.Text = "00";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label20.Location = new System.Drawing.Point(301, 140);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 20);
            this.label20.TabIndex = 395;
            this.label20.Text = " Expiry Date :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(7, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 393;
            this.label13.Text = "Total Payable :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(2, 0);
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
            this.txtPackgCost.Location = new System.Drawing.Point(123, 35);
            this.txtPackgCost.Name = "txtPackgCost";
            this.txtPackgCost.Size = new System.Drawing.Size(41, 18);
            this.txtPackgCost.TabIndex = 387;
            this.txtPackgCost.Text = "cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(2, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 383;
            this.label6.Text = "Start Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 382;
            this.label1.Text = "Package Cost :";
            // 
            // chkLumsum
            // 
            this.chkLumsum.AutoSize = true;
            this.chkLumsum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLumsum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkLumsum.Location = new System.Drawing.Point(380, 14);
            this.chkLumsum.Name = "chkLumsum";
            this.chkLumsum.Size = new System.Drawing.Size(131, 24);
            this.chkLumsum.TabIndex = 4;
            this.chkLumsum.TabStop = false;
            this.chkLumsum.Text = "Pay LumpSum";
            this.chkLumsum.UseVisualStyleBackColor = true;
            this.chkLumsum.Visible = false;
            this.chkLumsum.CheckedChanged += new System.EventHandler(this.chkLumsum_CheckedChanged);
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPackage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddPackage.BackColor = System.Drawing.Color.White;
            this.btnAddPackage.Depth = 0;
            this.btnAddPackage.Location = new System.Drawing.Point(160, 21);
            this.btnAddPackage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Primary = true;
            this.btnAddPackage.Size = new System.Drawing.Size(114, 33);
            this.btnAddPackage.TabIndex = 10;
            this.btnAddPackage.TabStop = false;
            this.btnAddPackage.Text = "Add Packages";
            this.btnAddPackage.UseVisualStyleBackColor = false;
            this.btnAddPackage.Visible = false;
            this.btnAddPackage.Click += new System.EventHandler(this.btnAddPackage_Click);
            // 
            // pnlFacilities
            // 
            this.pnlFacilities.BackColor = System.Drawing.Color.White;
            this.pnlFacilities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFacilities.Controls.Add(this.cmbDiscount);
            this.pnlFacilities.Controls.Add(this.btnViewInstallments);
            this.pnlFacilities.Controls.Add(this.btnRemoveSubject);
            this.pnlFacilities.Controls.Add(this.txtRollNo);
            this.pnlFacilities.Controls.Add(this.btnAddSubject);
            this.pnlFacilities.Controls.Add(this.txtTotalDiscount);
            this.pnlFacilities.Controls.Add(this.label9);
            this.pnlFacilities.Controls.Add(this.label14);
            this.pnlFacilities.Controls.Add(this.cmdPackageFacilities);
            this.pnlFacilities.Controls.Add(this.label15);
            this.pnlFacilities.Controls.Add(this.label12);
            this.pnlFacilities.Controls.Add(this.cmbBatches);
            this.pnlFacilities.Controls.Add(this.chkOnetimeDiscount);
            this.pnlFacilities.Controls.Add(this.label5);
            this.pnlFacilities.Controls.Add(this.dtpAdmissionDt);
            this.pnlFacilities.Controls.Add(this.label11);
            this.pnlFacilities.Location = new System.Drawing.Point(361, 21);
            this.pnlFacilities.Name = "pnlFacilities";
            this.pnlFacilities.Size = new System.Drawing.Size(390, 37);
            this.pnlFacilities.TabIndex = 389;
            this.pnlFacilities.Visible = false;
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDiscount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Items.AddRange(new object[] {
            "Discount Only on Registration",
            "Discount On Each Payment"});
            this.cmbDiscount.Location = new System.Drawing.Point(203, 3);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(171, 24);
            this.cmbDiscount.TabIndex = 401;
            this.cmbDiscount.TabStop = false;
            this.cmbDiscount.Visible = false;
            // 
            // btnViewInstallments
            // 
            this.btnViewInstallments.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnViewInstallments.FlatAppearance.BorderSize = 0;
            this.btnViewInstallments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewInstallments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInstallments.ForeColor = System.Drawing.Color.White;
            this.btnViewInstallments.Image = global::ClassManager.Properties.Resources.time_is_money;
            this.btnViewInstallments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewInstallments.Location = new System.Drawing.Point(223, -7);
            this.btnViewInstallments.Name = "btnViewInstallments";
            this.btnViewInstallments.Size = new System.Drawing.Size(136, 36);
            this.btnViewInstallments.TabIndex = 417;
            this.btnViewInstallments.Text = "INSTALLMENTS";
            this.btnViewInstallments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewInstallments.UseVisualStyleBackColor = false;
            this.btnViewInstallments.Visible = false;
            this.btnViewInstallments.Click += new System.EventHandler(this.btnViewInstallments_Click);
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
            this.btnRemoveSubject.Location = new System.Drawing.Point(155, -4);
            this.btnRemoveSubject.Name = "btnRemoveSubject";
            this.btnRemoveSubject.Size = new System.Drawing.Size(112, 36);
            this.btnRemoveSubject.TabIndex = 416;
            this.btnRemoveSubject.Text = "REMOVE   ";
            this.btnRemoveSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveSubject.UseVisualStyleBackColor = false;
            this.btnRemoveSubject.Visible = false;
            this.btnRemoveSubject.Click += new System.EventHandler(this.btnRemoveSubject_Click);
            // 
            // txtRollNo
            // 
            this.txtRollNo.Depth = 0;
            this.txtRollNo.Hint = "Enter Locker No.";
            this.txtRollNo.Location = new System.Drawing.Point(30, 6);
            this.txtRollNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.PasswordChar = '\0';
            this.txtRollNo.SelectedText = "";
            this.txtRollNo.SelectionLength = 0;
            this.txtRollNo.SelectionStart = 0;
            this.txtRollNo.Size = new System.Drawing.Size(139, 23);
            this.txtRollNo.TabIndex = 402;
            this.txtRollNo.TabStop = false;
            this.txtRollNo.UseSystemPasswordChar = false;
            this.txtRollNo.Visible = false;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddSubject.FlatAppearance.BorderSize = 0;
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Image = global::ClassManager.Properties.Resources.checked_files;
            this.btnAddSubject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSubject.Location = new System.Drawing.Point(292, 54);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(82, 36);
            this.btnAddSubject.TabIndex = 417;
            this.btnAddSubject.Text = "ADD";
            this.btnAddSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.AutoSize = true;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtTotalDiscount.Location = new System.Drawing.Point(129, 5);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(29, 20);
            this.txtTotalDiscount.TabIndex = 394;
            this.txtTotalDiscount.Text = "00";
            this.txtTotalDiscount.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(7, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 20);
            this.label9.TabIndex = 370;
            this.label9.Text = "Select facilities :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(11, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 20);
            this.label14.TabIndex = 391;
            this.label14.Text = "Total Discount :";
            this.label14.Visible = false;
            // 
            // cmdPackageFacilities
            // 
            this.cmdPackageFacilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPackageFacilities.FormattingEnabled = true;
            this.cmdPackageFacilities.ItemHeight = 16;
            this.cmdPackageFacilities.Location = new System.Drawing.Point(11, 35);
            this.cmdPackageFacilities.Name = "cmdPackageFacilities";
            this.cmdPackageFacilities.Size = new System.Drawing.Size(188, 84);
            this.cmdPackageFacilities.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(49, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 377;
            this.label15.Text = "Locker No. :";
            this.label15.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(26, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 375;
            this.label12.Text = "Batch";
            this.label12.Visible = false;
            // 
            // cmbBatches
            // 
            this.cmbBatches.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBatches.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatches.FormattingEnabled = true;
            this.cmbBatches.Location = new System.Drawing.Point(5, 5);
            this.cmbBatches.Name = "cmbBatches";
            this.cmbBatches.Size = new System.Drawing.Size(160, 24);
            this.cmbBatches.TabIndex = 7;
            this.cmbBatches.TabStop = false;
            this.cmbBatches.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(273, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Package Name:";
            this.label5.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(26, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 385;
            this.label11.Text = "Admission Date :";
            this.label11.Visible = false;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.cmbInstructor);
            this.pnlDetails.Controls.Add(this.label8);
            this.pnlDetails.Controls.Add(this.label7);
            this.pnlDetails.Controls.Add(this.cmbPack);
            this.pnlDetails.Controls.Add(this.cmbStd);
            this.pnlDetails.Controls.Add(this.cmbStream);
            this.pnlDetails.Controls.Add(this.label4);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Location = new System.Drawing.Point(12, 78);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(644, 89);
            this.pnlDetails.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(4, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Package Name:";
            // 
            // cmbPack
            // 
            this.cmbPack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPack.FormattingEnabled = true;
            this.cmbPack.Location = new System.Drawing.Point(131, 57);
            this.cmbPack.Name = "cmbPack";
            this.cmbPack.Size = new System.Drawing.Size(164, 24);
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
            this.cmbStd.Location = new System.Drawing.Point(431, 14);
            this.cmbStd.Name = "cmbStd";
            this.cmbStd.Size = new System.Drawing.Size(197, 24);
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
            this.cmbStream.Location = new System.Drawing.Point(131, 14);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(164, 24);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Package :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(314, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Package Type:";
            // 
            // bgwInvoice
            // 
            this.bgwInvoice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInvoice_DoWork);
            this.bgwInvoice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwInvoice_RunWorkerCompleted);
            // 
            // cmbInstructor
            // 
            this.cmbInstructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbInstructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInstructor.FormattingEnabled = true;
            this.cmbInstructor.Location = new System.Drawing.Point(431, 55);
            this.cmbInstructor.Name = "cmbInstructor";
            this.cmbInstructor.Size = new System.Drawing.Size(197, 24);
            this.cmbInstructor.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(314, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Instructor:";
            // 
            // FrmAddFacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(667, 451);
            this.Controls.Add(this.pnlFacilitiesDtls);
            this.Controls.Add(this.pnlDetails);
            this.Name = "FrmAddFacilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFacilities";
            this.Load += new System.EventHandler(this.AddFacilities_Load);
            this.pnlFacilitiesDtls.ResumeLayout(false);
            this.pnlPkgDtls.ResumeLayout(false);
            this.pnlPkgDtls.PerformLayout();
            this.pnlFacilities.ResumeLayout(false);
            this.pnlFacilities.PerformLayout();
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
        private System.Windows.Forms.Label txtPayable;
        private System.Windows.Forms.Label txtTotalDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlPkgDtls;
        private System.Windows.Forms.ComboBox cmbPack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtPackgCost;
        private System.Windows.Forms.ComboBox cmbBatches;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkOnetimeDiscount;
        private System.Windows.Forms.DateTimePicker dtpAdmissionDt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpPayStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLumsum;
        private System.Windows.Forms.Panel pnlFacilities;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox cmdPackageFacilities;
        private System.Windows.Forms.ToolTip ttpCommon;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddPackage;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemoveSubject;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnViewInstallments;
        private System.Windows.Forms.DateTimePicker dtExpDate;
        private System.Windows.Forms.Label label20;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscount;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRollNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox cmbSelectedPackages;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker bgwInvoice;
        private System.Windows.Forms.ComboBox cmbInstructor;
        private System.Windows.Forms.Label label8;
    }
}
