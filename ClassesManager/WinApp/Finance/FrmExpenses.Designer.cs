namespace ClassManager.WinApp
{
    partial class FrmExpenses
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
            this.tabExpense = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPCreateExpense = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnUpdt = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBrowse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtPath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.txtAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPaidTo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmdAddExpense = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lnkAddAccount = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.dateDt = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboIndirectExpenses = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabCreateExpenseHead = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.ADGVExpDetails = new ADGV.AdvancedDataGridView();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmdCreateExpence = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpense = new System.Windows.Forms.TextBox();
            this.tabExpenseView = new System.Windows.Forms.TabPage();
            this.panel12 = new System.Windows.Forms.Panel();
            this.adgvExpsnses = new ADGV.AdvancedDataGridView();
            this.panel13 = new System.Windows.Forms.Panel();
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
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabExpense.SuspendLayout();
            this.tabPCreateExpense.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabCreateExpenseHead.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVExpDetails)).BeginInit();
            this.panel10.SuspendLayout();
            this.tabExpenseView.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvExpsnses)).BeginInit();
            this.panel13.SuspendLayout();
            this.panelMaxExp.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabExpense
            // 
            this.tabExpense.Controls.Add(this.tabPCreateExpense);
            this.tabExpense.Controls.Add(this.tabCreateExpenseHead);
            this.tabExpense.Controls.Add(this.tabExpenseView);
            this.tabExpense.Depth = 0;
            this.tabExpense.Location = new System.Drawing.Point(1, 146);
            this.tabExpense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabExpense.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabExpense.Name = "tabExpense";
            this.tabExpense.SelectedIndex = 0;
            this.tabExpense.Size = new System.Drawing.Size(1284, 668);
            this.tabExpense.TabIndex = 3;
            this.tabExpense.TabStop = false;
            this.tabExpense.SelectedIndexChanged += new System.EventHandler(this.tabExpense_SelectedIndexChanged);
            // 
            // tabPCreateExpense
            // 
            this.tabPCreateExpense.Controls.Add(this.panel8);
            this.tabPCreateExpense.Location = new System.Drawing.Point(4, 25);
            this.tabPCreateExpense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPCreateExpense.Name = "tabPCreateExpense";
            this.tabPCreateExpense.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPCreateExpense.Size = new System.Drawing.Size(1276, 639);
            this.tabPCreateExpense.TabIndex = 0;
            this.tabPCreateExpense.Text = "Add Expenses";
            this.tabPCreateExpense.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnUpdt);
            this.panel8.Controls.Add(this.btnBrowse);
            this.panel8.Controls.Add(this.txtPath);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.cmbPaymentMode);
            this.panel8.Controls.Add(this.txtAmount);
            this.panel8.Controls.Add(this.txtPaidTo);
            this.panel8.Controls.Add(this.cmdAddExpense);
            this.panel8.Controls.Add(this.lnkAddAccount);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.cmbAccounts);
            this.panel8.Controls.Add(this.dateDt);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.comboIndirectExpenses);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.txtDescription);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(13, 11);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1251, 621);
            this.panel8.TabIndex = 0;
            // 
            // btnUpdt
            // 
            this.btnUpdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdt.BackColor = System.Drawing.Color.White;
            this.btnUpdt.Depth = 0;
            this.btnUpdt.Location = new System.Drawing.Point(301, 567);
            this.btnUpdt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdt.Name = "btnUpdt";
            this.btnUpdt.Primary = true;
            this.btnUpdt.Size = new System.Drawing.Size(149, 41);
            this.btnUpdt.TabIndex = 9;
            this.btnUpdt.Text = "Update";
            this.btnUpdt.UseVisualStyleBackColor = false;
            this.btnUpdt.Visible = false;
            this.btnUpdt.Click += new System.EventHandler(this.btnUpdt_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Depth = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(600, 518);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Primary = true;
            this.btnBrowse.Size = new System.Drawing.Size(109, 41);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Depth = 0;
            this.txtPath.Enabled = false;
            this.txtPath.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtPath.Hint = "File Path";
            this.txtPath.Location = new System.Drawing.Point(244, 518);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.Size = new System.Drawing.Size(265, 28);
            this.txtPath.TabIndex = 7;
            this.txtPath.UseSystemPasswordChar = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(20, 518);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(168, 25);
            this.label13.TabIndex = 400;
            this.label13.Text = "Attachment Files :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(23, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 25);
            this.label12.TabIndex = 118;
            this.label12.Text = "Payment Mode :";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Items.AddRange(new object[] {
            "CASH",
            "CHEQUE",
            "BANKTRANSFER",
            "DD",
            "CREDITCARD",
            "DEBITCARD"});
            this.cmbPaymentMode.Location = new System.Drawing.Point(244, 73);
            this.cmbPaymentMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(264, 28);
            this.cmbPaymentMode.TabIndex = 1;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Depth = 0;
            this.txtAmount.Hint = "Enter Amount";
            this.txtAmount.Location = new System.Drawing.Point(241, 256);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.Size = new System.Drawing.Size(264, 28);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TabStop = false;
            this.txtAmount.UseSystemPasswordChar = false;
            // 
            // txtPaidTo
            // 
            this.txtPaidTo.Depth = 0;
            this.txtPaidTo.Hint = "Enter Paid To";
            this.txtPaidTo.Location = new System.Drawing.Point(243, 129);
            this.txtPaidTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaidTo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPaidTo.Name = "txtPaidTo";
            this.txtPaidTo.PasswordChar = '\0';
            this.txtPaidTo.SelectedText = "";
            this.txtPaidTo.SelectionLength = 0;
            this.txtPaidTo.SelectionStart = 0;
            this.txtPaidTo.Size = new System.Drawing.Size(264, 28);
            this.txtPaidTo.TabIndex = 2;
            this.txtPaidTo.TabStop = false;
            this.txtPaidTo.UseSystemPasswordChar = false;
            // 
            // cmdAddExpense
            // 
            this.cmdAddExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddExpense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdAddExpense.BackColor = System.Drawing.Color.White;
            this.cmdAddExpense.Depth = 0;
            this.cmdAddExpense.Location = new System.Drawing.Point(301, 567);
            this.cmdAddExpense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddExpense.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdAddExpense.Name = "cmdAddExpense";
            this.cmdAddExpense.Primary = true;
            this.cmdAddExpense.Size = new System.Drawing.Size(149, 41);
            this.cmdAddExpense.TabIndex = 8;
            this.cmdAddExpense.Text = "Add Expense";
            this.cmdAddExpense.UseVisualStyleBackColor = false;
            this.cmdAddExpense.Click += new System.EventHandler(this.cmdAddExpense_Click);
            // 
            // lnkAddAccount
            // 
            this.lnkAddAccount.AutoSize = true;
            this.lnkAddAccount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddAccount.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(8)))));
            this.lnkAddAccount.Location = new System.Drawing.Point(1101, 585);
            this.lnkAddAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAddAccount.Name = "lnkAddAccount";
            this.lnkAddAccount.Size = new System.Drawing.Size(117, 24);
            this.lnkAddAccount.TabIndex = 10;
            this.lnkAddAccount.TabStop = true;
            this.lnkAddAccount.Text = "Add Account";
            this.lnkAddAccount.Visible = false;
            this.lnkAddAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddAccount_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(24, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 23);
            this.label3.TabIndex = 76;
            this.label3.Text = "Expense Source";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(247, 193);
            this.cmbAccounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(261, 28);
            this.cmbAccounts.TabIndex = 3;
            // 
            // dateDt
            // 
            this.dateDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDt.Location = new System.Drawing.Point(240, 316);
            this.dateDt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateDt.Name = "dateDt";
            this.dateDt.Size = new System.Drawing.Size(261, 26);
            this.dateDt.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(25, 193);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 25);
            this.label11.TabIndex = 116;
            this.label11.Text = "Account :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(20, 319);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 25);
            this.label7.TabIndex = 84;
            this.label7.Text = "Payment Date :";
            // 
            // comboIndirectExpenses
            // 
            this.comboIndirectExpenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIndirectExpenses.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboIndirectExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboIndirectExpenses.FormattingEnabled = true;
            this.comboIndirectExpenses.Location = new System.Drawing.Point(244, 18);
            this.comboIndirectExpenses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboIndirectExpenses.Name = "comboIndirectExpenses";
            this.comboIndirectExpenses.Size = new System.Drawing.Size(261, 28);
            this.comboIndirectExpenses.TabIndex = 0;
            this.comboIndirectExpenses.SelectedIndexChanged += new System.EventHandler(this.comboIndirectExpenses_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(20, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 78;
            this.label4.Text = "Amount :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(24, 383);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 25);
            this.label5.TabIndex = 79;
            this.label5.Text = "Note :";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(239, 384);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(266, 102);
            this.txtDescription.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(24, 133);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 80;
            this.label6.Text = "Paid To :";
            // 
            // tabCreateExpenseHead
            // 
            this.tabCreateExpenseHead.Controls.Add(this.panel9);
            this.tabCreateExpenseHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCreateExpenseHead.Location = new System.Drawing.Point(4, 25);
            this.tabCreateExpenseHead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCreateExpenseHead.Name = "tabCreateExpenseHead";
            this.tabCreateExpenseHead.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCreateExpenseHead.Size = new System.Drawing.Size(1276, 639);
            this.tabCreateExpenseHead.TabIndex = 1;
            this.tabCreateExpenseHead.Text = "Add Expense Source";
            this.tabCreateExpenseHead.UseVisualStyleBackColor = true;
            this.tabCreateExpenseHead.Click += new System.EventHandler(this.tabCreateExpenseHead_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(8, 11);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1257, 621);
            this.panel9.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.ADGVExpDetails);
            this.panel11.Location = new System.Drawing.Point(13, 175);
            this.panel11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1229, 443);
            this.panel11.TabIndex = 1;
            // 
            // ADGVExpDetails
            // 
            this.ADGVExpDetails.AllowUserToAddRows = false;
            this.ADGVExpDetails.AutoGenerateContextFilters = true;
            this.ADGVExpDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVExpDetails.BackgroundColor = System.Drawing.Color.White;
            this.ADGVExpDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVExpDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnDelete,
            this.btnUpdate});
            this.ADGVExpDetails.DateWithTime = false;
            this.ADGVExpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVExpDetails.Location = new System.Drawing.Point(0, 0);
            this.ADGVExpDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ADGVExpDetails.Name = "ADGVExpDetails";
            this.ADGVExpDetails.Size = new System.Drawing.Size(1227, 441);
            this.ADGVExpDetails.TabIndex = 350;
            this.ADGVExpDetails.TimeFilter = false;
            this.ADGVExpDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVExpDetails_CellContentClick);
            this.ADGVExpDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVExpDetails_DataBindingComplete);
            this.ADGVExpDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVExpDetails_DataError);
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.MinimumWidth = 22;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 93;
            // 
            // btnUpdate
            // 
            this.btnUpdate.HeaderText = "Update";
            this.btnUpdate.MinimumWidth = 22;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseColumnTextForButtonValue = true;
            this.btnUpdate.Width = 99;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.cmdCreateExpence);
            this.panel10.Controls.Add(this.lblMsg);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.txtExpense);
            this.panel10.Location = new System.Drawing.Point(13, 10);
            this.panel10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1229, 151);
            this.panel10.TabIndex = 0;
            // 
            // cmdCreateExpence
            // 
            this.cmdCreateExpence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreateExpence.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCreateExpence.BackColor = System.Drawing.Color.White;
            this.cmdCreateExpence.Depth = 0;
            this.cmdCreateExpence.Location = new System.Drawing.Point(499, 70);
            this.cmdCreateExpence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCreateExpence.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCreateExpence.Name = "cmdCreateExpence";
            this.cmdCreateExpence.Primary = true;
            this.cmdCreateExpence.Size = new System.Drawing.Size(168, 41);
            this.cmdCreateExpence.TabIndex = 2;
            this.cmdCreateExpence.Text = "Create Expense";
            this.cmdCreateExpence.UseVisualStyleBackColor = false;
            this.cmdCreateExpence.Click += new System.EventHandler(this.cmdCreateExpence_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblMsg.Location = new System.Drawing.Point(4, 17);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(436, 25);
            this.lblMsg.TabIndex = 58;
            this.lblMsg.Text = "Create Expense As you don\'t have Expense";
            this.lblMsg.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(4, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "Expense :";
            // 
            // txtExpense
            // 
            this.txtExpense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpense.Location = new System.Drawing.Point(129, 62);
            this.txtExpense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExpense.Multiline = true;
            this.txtExpense.Name = "txtExpense";
            this.txtExpense.Size = new System.Drawing.Size(309, 68);
            this.txtExpense.TabIndex = 1;
            // 
            // tabExpenseView
            // 
            this.tabExpenseView.Controls.Add(this.panel12);
            this.tabExpenseView.Location = new System.Drawing.Point(4, 25);
            this.tabExpenseView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabExpenseView.Name = "tabExpenseView";
            this.tabExpenseView.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabExpenseView.Size = new System.Drawing.Size(1276, 639);
            this.tabExpenseView.TabIndex = 2;
            this.tabExpenseView.Text = " Create Expenses Category";
            this.tabExpenseView.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.adgvExpsnses);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Location = new System.Drawing.Point(11, 11);
            this.panel12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1249, 604);
            this.panel12.TabIndex = 0;
            // 
            // adgvExpsnses
            // 
            this.adgvExpsnses.AllowUserToAddRows = false;
            this.adgvExpsnses.AutoGenerateContextFilters = true;
            this.adgvExpsnses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.adgvExpsnses.Location = new System.Drawing.Point(-1, -1);
            this.adgvExpsnses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.adgvExpsnses.Name = "adgvExpsnses";
            this.adgvExpsnses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgvExpsnses.Size = new System.Drawing.Size(813, 599);
            this.adgvExpsnses.TabIndex = 32;
            this.adgvExpsnses.TimeFilter = false;
            this.adgvExpsnses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvExpsnses_CellContentClick);
            this.adgvExpsnses.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgvExpsnses_DataBindingComplete);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnSave);
            this.panel13.Controls.Add(this.btnUpdatePaidExp);
            this.panel13.Controls.Add(this.panelMaxExp);
            this.panel13.Controls.Add(this.panel3);
            this.panel13.Controls.Add(this.chkDtFilter);
            this.panel13.Controls.Add(this.cmbViewExpenses);
            this.panel13.Controls.Add(this.label8);
            this.panel13.Controls.Add(this.chkShowAllBranch);
            this.panel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel13.Location = new System.Drawing.Point(820, 4);
            this.panel13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(423, 594);
            this.panel13.TabIndex = 0;
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
            this.btnSave.Location = new System.Drawing.Point(219, 37);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 41);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdatePaidExp
            // 
            this.btnUpdatePaidExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePaidExp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdatePaidExp.BackColor = System.Drawing.Color.White;
            this.btnUpdatePaidExp.Depth = 0;
            this.btnUpdatePaidExp.Location = new System.Drawing.Point(65, 37);
            this.btnUpdatePaidExp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdatePaidExp.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdatePaidExp.Name = "btnUpdatePaidExp";
            this.btnUpdatePaidExp.Primary = true;
            this.btnUpdatePaidExp.Size = new System.Drawing.Size(136, 41);
            this.btnUpdatePaidExp.TabIndex = 1;
            this.btnUpdatePaidExp.Text = "Update";
            this.btnUpdatePaidExp.UseVisualStyleBackColor = false;
            this.btnUpdatePaidExp.Click += new System.EventHandler(this.btnUpdatePaidExp_Click);
            // 
            // panelMaxExp
            // 
            this.panelMaxExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaxExp.Controls.Add(this.lblNameAndAmount);
            this.panelMaxExp.Controls.Add(this.label2);
            this.panelMaxExp.Location = new System.Drawing.Point(31, 450);
            this.panelMaxExp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMaxExp.Name = "panelMaxExp";
            this.panelMaxExp.Size = new System.Drawing.Size(373, 128);
            this.panelMaxExp.TabIndex = 31;
            this.panelMaxExp.Visible = false;
            // 
            // lblNameAndAmount
            // 
            this.lblNameAndAmount.AutoSize = true;
            this.lblNameAndAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblNameAndAmount.Location = new System.Drawing.Point(28, 50);
            this.lblNameAndAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameAndAmount.Name = "lblNameAndAmount";
            this.lblNameAndAmount.Size = new System.Drawing.Size(186, 25);
            this.lblNameAndAmount.TabIndex = 23;
            this.lblNameAndAmount.Text = "Name and Amount :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(36, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
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
            this.panel3.Location = new System.Drawing.Point(31, 293);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 126);
            this.panel3.TabIndex = 30;
            this.panel3.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(12, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 25);
            this.label10.TabIndex = 30;
            this.label10.Text = "To :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(147, 62);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(145, 30);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.CloseUp += new System.EventHandler(this.dtpToDate_CloseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 25);
            this.label9.TabIndex = 28;
            this.label9.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(147, 21);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(145, 30);
            this.dtpFromDate.TabIndex = 6;
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged_1);
            // 
            // chkDtFilter
            // 
            this.chkDtFilter.AutoSize = true;
            this.chkDtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDtFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkDtFilter.Location = new System.Drawing.Point(31, 245);
            this.chkDtFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDtFilter.Name = "chkDtFilter";
            this.chkDtFilter.Size = new System.Drawing.Size(122, 29);
            this.chkDtFilter.TabIndex = 5;
            this.chkDtFilter.Text = "Date Filter";
            this.chkDtFilter.UseVisualStyleBackColor = true;
            this.chkDtFilter.CheckedChanged += new System.EventHandler(this.chkDtFilter_CheckedChanged);
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
            this.cmbViewExpenses.Location = new System.Drawing.Point(151, 174);
            this.cmbViewExpenses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbViewExpenses.Name = "cmbViewExpenses";
            this.cmbViewExpenses.Size = new System.Drawing.Size(193, 33);
            this.cmbViewExpenses.TabIndex = 4;
            this.cmbViewExpenses.SelectedIndexChanged += new System.EventHandler(this.cmbViewExpenses_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(25, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 25);
            this.label8.TabIndex = 27;
            this.label8.Text = "View By :";
            // 
            // chkShowAllBranch
            // 
            this.chkShowAllBranch.AutoSize = true;
            this.chkShowAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAllBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkShowAllBranch.Location = new System.Drawing.Point(49, 107);
            this.chkShowAllBranch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShowAllBranch.Name = "chkShowAllBranch";
            this.chkShowAllBranch.Size = new System.Drawing.Size(270, 29);
            this.chkShowAllBranch.TabIndex = 3;
            this.chkShowAllBranch.Text = "Show All Branch Expenses";
            this.chkShowAllBranch.UseVisualStyleBackColor = true;
            this.chkShowAllBranch.CheckedChanged += new System.EventHandler(this.chkShowAllBranch_CheckedChanged);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.tabExpense;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 80);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1285, 60);
            this.materialTabSelector1.TabIndex = 2;
            this.materialTabSelector1.Text = "materialTabSelector1";
            this.materialTabSelector1.Click += new System.EventHandler(this.materialTabSelector1_Click);
            // 
            // FrmExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 818);
            this.Controls.Add(this.tabExpense);
            this.Controls.Add(this.materialTabSelector1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.Name = "FrmExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses";
            this.Load += new System.EventHandler(this.Expenses_Load);
            this.tabExpense.ResumeLayout(false);
            this.tabPCreateExpense.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabCreateExpenseHead.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVExpDetails)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tabExpenseView.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgvExpsnses)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panelMaxExp.ResumeLayout(false);
            this.panelMaxExp.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateDt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboIndirectExpenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbViewExpenses;
        private System.Windows.Forms.CheckBox chkShowAllBranch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDtFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.LinkLabel lnkAddAccount;
        private System.Windows.Forms.Label lblMsg;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl tabExpense;
        private System.Windows.Forms.TabPage tabPCreateExpense;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TabPage tabCreateExpenseHead;
        private MaterialSkin.Controls.MaterialRaisedButton cmdAddExpense;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private ADGV.AdvancedDataGridView ADGVExpDetails;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.DataGridViewButtonColumn btnUpdate;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TabPage tabExpenseView;
        private System.Windows.Forms.Panel panel12;
        private ADGV.AdvancedDataGridView adgvExpsnses;
        private System.Windows.Forms.Panel panel13;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdatePaidExp;
        private System.Windows.Forms.Panel panelMaxExp;
        private System.Windows.Forms.Label lblNameAndAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private MaterialSkin.Controls.MaterialRaisedButton cmdCreateExpence;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPaidTo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPath;
        private System.Windows.Forms.Label label13;
        private MaterialSkin.Controls.MaterialRaisedButton btnBrowse;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdt;
    }
}
