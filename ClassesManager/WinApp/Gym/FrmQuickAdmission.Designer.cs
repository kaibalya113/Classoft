namespace ClassManager.WinApp.Gym
{
    partial class FrmQuickAdmission
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
            this.bgwkSendReg = new System.ComponentModel.BackgroundWorker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtActualPaymentAmnt = new System.Windows.Forms.Label();
            this.txtBankAmount = new System.Windows.Forms.Label();
            this.txtChequeAmount = new System.Windows.Forms.Label();
            this.cmdNext = new System.Windows.Forms.Button();
            this.lnkBnkTrnfr = new System.Windows.Forms.LinkLabel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAFPaying = new System.Windows.Forms.Label();
            this.lnkAddCheque = new System.Windows.Forms.LinkLabel();
            this.txtCashAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblAccount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.txtDiscount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPayable = new System.Windows.Forms.Label();
            this.txtTotalDiscount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.chkOnetimeDiscount = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPack = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAdmissionDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbBatches = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.txtSContact = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtHeight = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBiometricId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtBMI = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtWght = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemberShipNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBldGrp = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmailID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtLName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label25 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwkSendReg
            // 
            this.bgwkSendReg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwkSendReg_DoWork);
            this.bgwkSendReg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwkSendReg_ProgressChanged);
            this.bgwkSendReg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwkSendReg_RunWorkerCompleted);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtActualPaymentAmnt);
            this.panel4.Controls.Add(this.txtBankAmount);
            this.panel4.Controls.Add(this.txtChequeAmount);
            this.panel4.Controls.Add(this.cmdNext);
            this.panel4.Controls.Add(this.lnkBnkTrnfr);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.txtAFPaying);
            this.panel4.Controls.Add(this.lnkAddCheque);
            this.panel4.Controls.Add(this.txtCashAmount);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.cmbAccount);
            this.panel4.Controls.Add(this.dtPaymentDate);
            this.panel4.Controls.Add(this.lblAccount);
            this.panel4.Location = new System.Drawing.Point(10, 490);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(967, 154);
            this.panel4.TabIndex = 2;
            // 
            // txtActualPaymentAmnt
            // 
            this.txtActualPaymentAmnt.AutoSize = true;
            this.txtActualPaymentAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualPaymentAmnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtActualPaymentAmnt.Location = new System.Drawing.Point(769, 81);
            this.txtActualPaymentAmnt.Name = "txtActualPaymentAmnt";
            this.txtActualPaymentAmnt.Size = new System.Drawing.Size(71, 20);
            this.txtActualPaymentAmnt.TabIndex = 426;
            this.txtActualPaymentAmnt.Text = "Rs 0.00";
            // 
            // txtBankAmount
            // 
            this.txtBankAmount.AutoSize = true;
            this.txtBankAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtBankAmount.Location = new System.Drawing.Point(500, 80);
            this.txtBankAmount.Name = "txtBankAmount";
            this.txtBankAmount.Size = new System.Drawing.Size(71, 20);
            this.txtBankAmount.TabIndex = 402;
            this.txtBankAmount.Text = "Rs 0.00";
            // 
            // txtChequeAmount
            // 
            this.txtChequeAmount.AutoSize = true;
            this.txtChequeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtChequeAmount.Location = new System.Drawing.Point(150, 86);
            this.txtChequeAmount.Name = "txtChequeAmount";
            this.txtChequeAmount.Size = new System.Drawing.Size(71, 20);
            this.txtChequeAmount.TabIndex = 403;
            this.txtChequeAmount.Text = "Rs 0.00";
            // 
            // cmdNext
            // 
            this.cmdNext.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cmdNext.FlatAppearance.BorderSize = 0;
            this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNext.ForeColor = System.Drawing.Color.White;
            this.cmdNext.Image = global::ClassManager.Properties.Resources.check_form;
            this.cmdNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNext.Location = new System.Drawing.Point(861, 116);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(95, 33);
            this.cmdNext.TabIndex = 19;
            this.cmdNext.Text = "REGISTER";
            this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNext.UseVisualStyleBackColor = false;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // lnkBnkTrnfr
            // 
            this.lnkBnkTrnfr.AutoSize = true;
            this.lnkBnkTrnfr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBnkTrnfr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkBnkTrnfr.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkBnkTrnfr.Location = new System.Drawing.Point(380, 82);
            this.lnkBnkTrnfr.Name = "lnkBnkTrnfr";
            this.lnkBnkTrnfr.Size = new System.Drawing.Size(114, 18);
            this.lnkBnkTrnfr.TabIndex = 425;
            this.lnkBnkTrnfr.TabStop = true;
            this.lnkBnkTrnfr.Text = "Bank Transfer";
            this.lnkBnkTrnfr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBnkTrnfr_LinkClicked);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label18.Location = new System.Drawing.Point(8, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Payment Details :";
            // 
            // txtAFPaying
            // 
            this.txtAFPaying.AutoSize = true;
            this.txtAFPaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAFPaying.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtAFPaying.Location = new System.Drawing.Point(645, 80);
            this.txtAFPaying.Name = "txtAFPaying";
            this.txtAFPaying.Size = new System.Drawing.Size(118, 20);
            this.txtAFPaying.TabIndex = 399;
            this.txtAFPaying.Text = "Total Payment :";
            // 
            // lnkAddCheque
            // 
            this.lnkAddCheque.AutoSize = true;
            this.lnkAddCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddCheque.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddCheque.Location = new System.Drawing.Point(22, 86);
            this.lnkAddCheque.Name = "lnkAddCheque";
            this.lnkAddCheque.Size = new System.Drawing.Size(98, 18);
            this.lnkAddCheque.TabIndex = 396;
            this.lnkAddCheque.TabStop = true;
            this.lnkAddCheque.Text = "Add Cheque";
            this.lnkAddCheque.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCheque_LinkClicked);
            // 
            // txtCashAmount
            // 
            this.txtCashAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashAmount.Depth = 0;
            this.txtCashAmount.Hint = "Enter Cash Amount";
            this.txtCashAmount.Location = new System.Drawing.Point(383, 36);
            this.txtCashAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCashAmount.Name = "txtCashAmount";
            this.txtCashAmount.PasswordChar = '\0';
            this.txtCashAmount.SelectedText = "";
            this.txtCashAmount.SelectionLength = 0;
            this.txtCashAmount.SelectionStart = 0;
            this.txtCashAmount.Size = new System.Drawing.Size(150, 23);
            this.txtCashAmount.TabIndex = 17;
            this.txtCashAmount.TabStop = false;
            this.txtCashAmount.UseSystemPasswordChar = false;
            this.txtCashAmount.Click += new System.EventHandler(this.txtCashAmount_Click);
            this.txtCashAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashAmount_KeyPress);
            this.txtCashAmount.TextChanged += new System.EventHandler(this.txtCashAmount_TextChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label29.Location = new System.Drawing.Point(645, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(118, 20);
            this.label29.TabIndex = 391;
            this.label29.Text = "Payment Date :";
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(154, 38);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(151, 24);
            this.cmbAccount.TabIndex = 16;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPaymentDate.Location = new System.Drawing.Point(769, 34);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(138, 22);
            this.dtPaymentDate.TabIndex = 18;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.BackColor = System.Drawing.Color.White;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblAccount.Location = new System.Drawing.Point(6, 39);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(142, 20);
            this.lblAccount.TabIndex = 393;
            this.lblAccount.Text = "Payment Account :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cmbStream);
            this.panel3.Controls.Add(this.txtDiscount);
            this.panel3.Controls.Add(this.txtPayable);
            this.panel3.Controls.Add(this.txtTotalDiscount);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.dtpToDate);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.chkOnetimeDiscount);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cmbPack);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbStd);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtpAdmissionDate);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(10, 349);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(966, 135);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(279, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 399;
            this.label13.Text = "PackageType :";
            // 
            // cmbStream
            // 
            this.cmbStream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(104, 20);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(147, 24);
            this.cmbStream.TabIndex = 13;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Depth = 0;
            this.txtDiscount.Hint = "";
            this.txtDiscount.Location = new System.Drawing.Point(685, 59);
            this.txtDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.SelectionLength = 0;
            this.txtDiscount.SelectionStart = 0;
            this.txtDiscount.Size = new System.Drawing.Size(166, 23);
            this.txtDiscount.TabIndex = 15;
            this.txtDiscount.Text = "0";
            this.txtDiscount.UseSystemPasswordChar = false;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtPayable
            // 
            this.txtPayable.AutoSize = true;
            this.txtPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtPayable.Location = new System.Drawing.Point(805, 98);
            this.txtPayable.Name = "txtPayable";
            this.txtPayable.Size = new System.Drawing.Size(29, 20);
            this.txtPayable.TabIndex = 7;
            this.txtPayable.Text = "00";
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.AutoSize = true;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtTotalDiscount.Location = new System.Drawing.Point(606, 98);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(29, 20);
            this.txtTotalDiscount.TabIndex = 6;
            this.txtTotalDiscount.Text = "00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label16.Location = new System.Drawing.Point(707, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 20);
            this.label16.TabIndex = 397;
            this.label16.Text = "Total Fees :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label17.Location = new System.Drawing.Point(491, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 20);
            this.label17.TabIndex = 396;
            this.label17.Text = "Total Discount :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(383, 61);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(138, 22);
            this.dtpToDate.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(279, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 20);
            this.label15.TabIndex = 389;
            this.label15.Text = "To Date :";
            // 
            // chkOnetimeDiscount
            // 
            this.chkOnetimeDiscount.AutoSize = true;
            this.chkOnetimeDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnetimeDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkOnetimeDiscount.Location = new System.Drawing.Point(841, 19);
            this.chkOnetimeDiscount.Name = "chkOnetimeDiscount";
            this.chkOnetimeDiscount.Size = new System.Drawing.Size(115, 24);
            this.chkOnetimeDiscount.TabIndex = 387;
            this.chkOnetimeDiscount.TabStop = false;
            this.chkOnetimeDiscount.Text = "AutoRenwal";
            this.chkOnetimeDiscount.UseVisualStyleBackColor = true;
            this.chkOnetimeDiscount.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(562, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 386;
            this.label7.Text = "Discount :";
            // 
            // cmbPack
            // 
            this.cmbPack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPack.FormattingEnabled = true;
            this.cmbPack.Location = new System.Drawing.Point(685, 17);
            this.cmbPack.Name = "cmbPack";
            this.cmbPack.Size = new System.Drawing.Size(149, 24);
            this.cmbPack.TabIndex = 2;
            this.cmbPack.TabStop = false;
            this.cmbPack.SelectedIndexChanged += new System.EventHandler(this.cmbPack_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(562, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "PackageName:";
            // 
            // cmbStd
            // 
            this.cmbStd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStd.FormattingEnabled = true;
            this.cmbStd.Location = new System.Drawing.Point(398, 17);
            this.cmbStd.Name = "cmbStd";
            this.cmbStd.Size = new System.Drawing.Size(147, 24);
            this.cmbStd.TabIndex = 0;
            this.cmbStd.TabStop = false;
            this.cmbStd.SelectedIndexChanged += new System.EventHandler(this.cmbStd_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Package:";
            // 
            // dtpAdmissionDate
            // 
            this.dtpAdmissionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAdmissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAdmissionDate.Location = new System.Drawing.Point(104, 64);
            this.dtpAdmissionDate.Name = "dtpAdmissionDate";
            this.dtpAdmissionDate.Size = new System.Drawing.Size(147, 22);
            this.dtpAdmissionDate.TabIndex = 3;
            this.dtpAdmissionDate.ValueChanged += new System.EventHandler(this.dtpAdmissionDate_ValueChanged);
            this.dtpAdmissionDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpAdmissionDate_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label19.Location = new System.Drawing.Point(6, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 20);
            this.label19.TabIndex = 108;
            this.label19.Text = "From Date :";
            // 
            // cmbBatches
            // 
            this.cmbBatches.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBatches.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatches.FormattingEnabled = true;
            this.cmbBatches.Location = new System.Drawing.Point(790, 3);
            this.cmbBatches.Name = "cmbBatches";
            this.cmbBatches.Size = new System.Drawing.Size(138, 24);
            this.cmbBatches.TabIndex = 1;
            this.cmbBatches.TabStop = false;
            this.cmbBatches.Visible = false;
            this.cmbBatches.SelectedIndexChanged += new System.EventHandler(this.cmbBatches_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label20.Location = new System.Drawing.Point(711, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 20);
            this.label20.TabIndex = 401;
            this.label20.Text = "Batch :";
            this.label20.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbBatches);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtSContact);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.txtBiometricId);
            this.panel1.Controls.Add(this.lblHeight);
            this.panel1.Controls.Add(this.txtBMI);
            this.panel1.Controls.Add(this.txtWght);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMemberShipNo);
            this.panel1.Controls.Add(this.txtBldGrp);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtpDOB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEmailID);
            this.panel1.Controls.Add(this.txtLName);
            this.panel1.Controls.Add(this.txtMName);
            this.panel1.Controls.Add(this.txtFName);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Location = new System.Drawing.Point(10, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 272);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(235, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 122;
            this.label1.Text = "*";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbMale);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.rbFemale);
            this.panel2.Location = new System.Drawing.Point(539, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 33);
            this.panel2.TabIndex = 8;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbMale.Location = new System.Drawing.Point(73, 5);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(61, 24);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(3, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Gender :";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbFemale.Location = new System.Drawing.Point(136, 5);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(80, 24);
            this.rbFemale.TabIndex = 9;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // txtSContact
            // 
            this.txtSContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSContact.Depth = 0;
            this.txtSContact.Hint = "Contact No";
            this.txtSContact.Location = new System.Drawing.Point(12, 82);
            this.txtSContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSContact.Name = "txtSContact";
            this.txtSContact.PasswordChar = '\0';
            this.txtSContact.SelectedText = "";
            this.txtSContact.SelectionLength = 0;
            this.txtSContact.SelectionStart = 0;
            this.txtSContact.Size = new System.Drawing.Size(217, 23);
            this.txtSContact.TabIndex = 3;
            this.txtSContact.UseSystemPasswordChar = false;
            this.txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSContact_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(256, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 120;
            this.label9.Text = "Address :";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(260, 101);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(229, 52);
            this.txtAddress.TabIndex = 4;
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Depth = 0;
            this.txtHeight.Hint = " Enter Height";
            this.txtHeight.Location = new System.Drawing.Point(431, 186);
            this.txtHeight.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.PasswordChar = '\0';
            this.txtHeight.SelectedText = "";
            this.txtHeight.SelectionLength = 0;
            this.txtHeight.SelectionStart = 0;
            this.txtHeight.Size = new System.Drawing.Size(179, 23);
            this.txtHeight.TabIndex = 8;
            this.txtHeight.TabStop = false;
            this.txtHeight.UseSystemPasswordChar = false;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtBiometricId
            // 
            this.txtBiometricId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBiometricId.Depth = 0;
            this.txtBiometricId.Hint = "Biometric Id";
            this.txtBiometricId.Location = new System.Drawing.Point(431, 229);
            this.txtBiometricId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBiometricId.Name = "txtBiometricId";
            this.txtBiometricId.PasswordChar = '\0';
            this.txtBiometricId.SelectedText = "";
            this.txtBiometricId.SelectionLength = 0;
            this.txtBiometricId.SelectionStart = 0;
            this.txtBiometricId.Size = new System.Drawing.Size(183, 23);
            this.txtBiometricId.TabIndex = 11;
            this.txtBiometricId.TabStop = false;
            this.txtBiometricId.UseSystemPasswordChar = false;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblHeight.Location = new System.Drawing.Point(324, 186);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(64, 20);
            this.lblHeight.TabIndex = 116;
            this.lblHeight.Text = "Height :";
            // 
            // txtBMI
            // 
            this.txtBMI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBMI.Depth = 0;
            this.txtBMI.Enabled = false;
            this.txtBMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBMI.Hint = "BMI";
            this.txtBMI.Location = new System.Drawing.Point(767, 190);
            this.txtBMI.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBMI.Name = "txtBMI";
            this.txtBMI.PasswordChar = '\0';
            this.txtBMI.SelectedText = "";
            this.txtBMI.SelectionLength = 0;
            this.txtBMI.SelectionStart = 0;
            this.txtBMI.Size = new System.Drawing.Size(161, 23);
            this.txtBMI.TabIndex = 9;
            this.txtBMI.TabStop = false;
            this.txtBMI.UseSystemPasswordChar = false;
            // 
            // txtWght
            // 
            this.txtWght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWght.Depth = 0;
            this.txtWght.Hint = " Enter Weight";
            this.txtWght.Location = new System.Drawing.Point(110, 186);
            this.txtWght.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtWght.Name = "txtWght";
            this.txtWght.PasswordChar = '\0';
            this.txtWght.SelectedText = "";
            this.txtWght.SelectionLength = 0;
            this.txtWght.SelectionStart = 0;
            this.txtWght.Size = new System.Drawing.Size(124, 23);
            this.txtWght.TabIndex = 7;
            this.txtWght.TabStop = false;
            this.txtWght.UseSystemPasswordChar = false;
            this.txtWght.TextChanged += new System.EventHandler(this.txtWght_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(3, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "Weight :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(628, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 112;
            this.label10.Text = "BMI :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(626, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 111;
            this.label8.Text = "Membership No. :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(324, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 110;
            this.label6.Text = "Biometric Id :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(0, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 109;
            this.label3.Text = "BloodGroup :";
            // 
            // txtMemberShipNo
            // 
            this.txtMemberShipNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemberShipNo.Depth = 0;
            this.txtMemberShipNo.Hint = "MemberShip No";
            this.txtMemberShipNo.Location = new System.Drawing.Point(768, 233);
            this.txtMemberShipNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMemberShipNo.Name = "txtMemberShipNo";
            this.txtMemberShipNo.PasswordChar = '\0';
            this.txtMemberShipNo.SelectedText = "";
            this.txtMemberShipNo.SelectionLength = 0;
            this.txtMemberShipNo.SelectionStart = 0;
            this.txtMemberShipNo.Size = new System.Drawing.Size(170, 23);
            this.txtMemberShipNo.TabIndex = 12;
            this.txtMemberShipNo.TabStop = false;
            this.txtMemberShipNo.UseSystemPasswordChar = false;
            // 
            // txtBldGrp
            // 
            this.txtBldGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBldGrp.Depth = 0;
            this.txtBldGrp.Hint = "Blood Group";
            this.txtBldGrp.Location = new System.Drawing.Point(110, 233);
            this.txtBldGrp.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBldGrp.Name = "txtBldGrp";
            this.txtBldGrp.PasswordChar = '\0';
            this.txtBldGrp.SelectedText = "";
            this.txtBldGrp.SelectionLength = 0;
            this.txtBldGrp.SelectionStart = 0;
            this.txtBldGrp.Size = new System.Drawing.Size(124, 23);
            this.txtBldGrp.TabIndex = 10;
            this.txtBldGrp.TabStop = false;
            this.txtBldGrp.UseSystemPasswordChar = false;
            this.txtBldGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBldGrp_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(535, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 107;
            this.label11.Text = "Date of Birth :";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(649, 83);
            this.dtpDOB.MaxDate = new System.DateTime(2109, 12, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(134, 22);
            this.dtpDOB.TabIndex = 5;
            this.dtpDOB.Value = new System.DateTime(2016, 9, 22, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Personal Details :";
            // 
            // txtEmailID
            // 
            this.txtEmailID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailID.Depth = 0;
            this.txtEmailID.Hint = "Email Address";
            this.txtEmailID.Location = new System.Drawing.Point(12, 130);
            this.txtEmailID.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.PasswordChar = '\0';
            this.txtEmailID.SelectedText = "";
            this.txtEmailID.SelectionLength = 0;
            this.txtEmailID.SelectionStart = 0;
            this.txtEmailID.Size = new System.Drawing.Size(214, 23);
            this.txtEmailID.TabIndex = 6;
            this.txtEmailID.TabStop = false;
            this.txtEmailID.UseSystemPasswordChar = false;
            // 
            // txtLName
            // 
            this.txtLName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLName.Depth = 0;
            this.txtLName.Hint = "Last Name";
            this.txtLName.Location = new System.Drawing.Point(539, 35);
            this.txtLName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLName.Name = "txtLName";
            this.txtLName.PasswordChar = '\0';
            this.txtLName.SelectedText = "";
            this.txtLName.SelectionLength = 0;
            this.txtLName.SelectionStart = 0;
            this.txtLName.Size = new System.Drawing.Size(209, 23);
            this.txtLName.TabIndex = 2;
            this.txtLName.TabStop = false;
            this.txtLName.UseSystemPasswordChar = false;
            // 
            // txtMName
            // 
            this.txtMName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMName.Depth = 0;
            this.txtMName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMName.Hint = "Middle Name";
            this.txtMName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMName.Location = new System.Drawing.Point(275, 35);
            this.txtMName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtMName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMName.Name = "txtMName";
            this.txtMName.PasswordChar = '\0';
            this.txtMName.SelectedText = "";
            this.txtMName.SelectionLength = 0;
            this.txtMName.SelectionStart = 0;
            this.txtMName.Size = new System.Drawing.Size(214, 23);
            this.txtMName.TabIndex = 1;
            this.txtMName.TabStop = false;
            this.txtMName.UseSystemPasswordChar = false;
            // 
            // txtFName
            // 
            this.txtFName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFName.Depth = 0;
            this.txtFName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtFName.Hint = "First Name";
            this.txtFName.Location = new System.Drawing.Point(16, 35);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(214, 23);
            this.txtFName.TabIndex = 0;
            this.txtFName.TabStop = false;
            this.txtFName.UseSystemPasswordChar = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(236, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 20);
            this.label25.TabIndex = 49;
            this.label25.Text = "*";
            // 
            // FrmQuickAdmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 653);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQuickAdmission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Form";
            this.Load += new System.EventHandler(this.FrmQuickAdmission_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmailID;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtHeight;
        private System.Windows.Forms.Label lblHeight;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBMI;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtWght;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMemberShipNo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBldGrp;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBiometricId;
        public System.Windows.Forms.DateTimePicker dtpAdmissionDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbFemale;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSContact;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbStd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblAccount;
        public System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCashAmount;
        private System.Windows.Forms.LinkLabel lnkAddCheque;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkOnetimeDiscount;
        private System.Windows.Forms.Label txtPayable;
        private System.Windows.Forms.Label txtTotalDiscount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label txtAFPaying;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbBatches;
        private System.Windows.Forms.Label label20;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscount;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.LinkLabel lnkBnkTrnfr;
        private System.ComponentModel.BackgroundWorker bgwkSendReg;
        private System.Windows.Forms.Label txtBankAmount;
        private System.Windows.Forms.Label txtChequeAmount;
        private System.Windows.Forms.Label txtActualPaymentAmnt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbStream;
    }
}