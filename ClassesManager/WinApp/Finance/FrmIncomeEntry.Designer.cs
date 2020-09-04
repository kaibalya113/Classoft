namespace ClassManager.WinApp
{
    partial class FrmIncomeEntry
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
            this.lblMsgIncm = new System.Windows.Forms.Label();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkAddAccount = new System.Windows.Forms.LinkLabel();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboIndirectExpenses = new System.Windows.Forms.ComboBox();
            this.dateDt = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkDtFilter = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShowAllBranch = new System.Windows.Forms.CheckBox();
            this.cmbViewExpenses = new System.Windows.Forms.ComboBox();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabIncome = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ADGVIncomeDetails = new ADGV.AdvancedDataGridView();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cmdCreateExpence = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdatePaidIncome = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelMaxInc = new System.Windows.Forms.Panel();
            this.lblNameAndAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel12 = new System.Windows.Forms.Panel();
            this.ADGVIncome = new ADGV.AdvancedDataGridView();
            this.tabIncome.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVIncomeDetails)).BeginInit();
            this.panel9.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panelMaxInc.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsgIncm
            // 
            this.lblMsgIncm.AutoSize = true;
            this.lblMsgIncm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgIncm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblMsgIncm.Location = new System.Drawing.Point(18, 0);
            this.lblMsgIncm.Name = "lblMsgIncm";
            this.lblMsgIncm.Size = new System.Drawing.Size(338, 20);
            this.lblMsgIncm.TabIndex = 61;
            this.lblMsgIncm.Text = "Create Income As you don\'t have Income";
            this.lblMsgIncm.Visible = false;
            // 
            // txtIncome
            // 
            this.txtIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncome.Location = new System.Drawing.Point(113, 42);
            this.txtIncome.Multiline = true;
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(243, 54);
            this.txtIncome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(20, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Income :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(18, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 114;
            this.label2.Text = "Account :";
            // 
            // lnkAddAccount
            // 
            this.lnkAddAccount.AutoSize = true;
            this.lnkAddAccount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lnkAddAccount.LinkColor = System.Drawing.Color.Black;
            this.lnkAddAccount.Location = new System.Drawing.Point(771, 461);
            this.lnkAddAccount.Name = "lnkAddAccount";
            this.lnkAddAccount.Size = new System.Drawing.Size(98, 19);
            this.lnkAddAccount.TabIndex = 10;
            this.lnkAddAccount.TabStop = true;
            this.lnkAddAccount.Text = "Add Account";
            this.lnkAddAccount.Visible = false;
            this.lnkAddAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddAccount_LinkClicked);
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(206, 155);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(199, 24);
            this.cmbAccounts.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(18, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 112;
            this.label7.Text = "Payment Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(18, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 111;
            this.label6.Text = "Received From :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(18, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 110;
            this.label5.Text = "Note :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(16, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 109;
            this.label4.Text = "Amount :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 108;
            this.label3.Text = "Income Source :";
            // 
            // comboIndirectExpenses
            // 
            this.comboIndirectExpenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIndirectExpenses.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboIndirectExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboIndirectExpenses.FormattingEnabled = true;
            this.comboIndirectExpenses.Location = new System.Drawing.Point(206, 13);
            this.comboIndirectExpenses.Name = "comboIndirectExpenses";
            this.comboIndirectExpenses.Size = new System.Drawing.Size(199, 24);
            this.comboIndirectExpenses.TabIndex = 0;
            // 
            // dateDt
            // 
            this.dateDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDt.Location = new System.Drawing.Point(206, 254);
            this.dateDt.Name = "dateDt";
            this.dateDt.Size = new System.Drawing.Size(199, 23);
            this.dateDt.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(206, 303);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(199, 77);
            this.txtDescription.TabIndex = 6;
            // 
            // chkDtFilter
            // 
            this.chkDtFilter.AutoSize = true;
            this.chkDtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDtFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkDtFilter.Location = new System.Drawing.Point(598, 215);
            this.chkDtFilter.Name = "chkDtFilter";
            this.chkDtFilter.Size = new System.Drawing.Size(88, 20);
            this.chkDtFilter.TabIndex = 5;
            this.chkDtFilter.Text = "Date Filter";
            this.chkDtFilter.UseVisualStyleBackColor = true;
            this.chkDtFilter.CheckedChanged += new System.EventHandler(this.chkDtFilter_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(594, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 353;
            this.label8.Text = "View By :";
            // 
            // chkShowAllBranch
            // 
            this.chkShowAllBranch.AutoSize = true;
            this.chkShowAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAllBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkShowAllBranch.Location = new System.Drawing.Point(598, 130);
            this.chkShowAllBranch.Name = "chkShowAllBranch";
            this.chkShowAllBranch.Size = new System.Drawing.Size(186, 20);
            this.chkShowAllBranch.TabIndex = 3;
            this.chkShowAllBranch.Text = "Show All Branch Expenses";
            this.chkShowAllBranch.UseVisualStyleBackColor = true;
            this.chkShowAllBranch.CheckedChanged += new System.EventHandler(this.chkShowAllBranch_CheckedChanged);
            // 
            // cmbViewExpenses
            // 
            this.cmbViewExpenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewExpenses.FormattingEnabled = true;
            this.cmbViewExpenses.Items.AddRange(new object[] {
            "All Data",
            "Category Wise Data"});
            this.cmbViewExpenses.Location = new System.Drawing.Point(669, 172);
            this.cmbViewExpenses.Name = "cmbViewExpenses";
            this.cmbViewExpenses.Size = new System.Drawing.Size(146, 24);
            this.cmbViewExpenses.TabIndex = 4;
            this.cmbViewExpenses.SelectedIndexChanged += new System.EventHandler(this.cmbViewExpenses_SelectedIndexChanged);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.tabIncome;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(2, 67);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(914, 50);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // tabIncome
            // 
            this.tabIncome.Controls.Add(this.tabPage4);
            this.tabIncome.Controls.Add(this.tabPage5);
            this.tabIncome.Controls.Add(this.tabPage6);
            this.tabIncome.Depth = 0;
            this.tabIncome.Location = new System.Drawing.Point(8, 123);
            this.tabIncome.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabIncome.Name = "tabIncome";
            this.tabIncome.SelectedIndex = 0;
            this.tabIncome.Size = new System.Drawing.Size(896, 539);
            this.tabIncome.TabIndex = 2;
            this.tabIncome.TabStop = false;
            this.tabIncome.SelectedIndexChanged += new System.EventHandler(this.tabIncome_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(888, 513);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Add Income";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.cmbAccounts);
            this.panel8.Controls.Add(this.dateDt);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.comboIndirectExpenses);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.txtDescription);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(8, 9);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(874, 501);
            this.panel8.TabIndex = 0;
            // 
            // btnUpdt
            // 
            this.btnUpdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdt.BackColor = System.Drawing.Color.White;
            this.btnUpdt.Depth = 0;
            this.btnUpdt.Location = new System.Drawing.Point(248, 447);
            this.btnUpdt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdt.Name = "btnUpdt";
            this.btnUpdt.Primary = true;
            this.btnUpdt.Size = new System.Drawing.Size(112, 33);
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
            this.btnBrowse.Location = new System.Drawing.Point(465, 400);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Primary = true;
            this.btnBrowse.Size = new System.Drawing.Size(82, 33);
            this.btnBrowse.TabIndex = 7;
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
            this.txtPath.Location = new System.Drawing.Point(206, 406);
            this.txtPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.Size = new System.Drawing.Size(199, 23);
            this.txtPath.TabIndex = 8;
            this.txtPath.TabStop = false;
            this.txtPath.UseSystemPasswordChar = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(16, 406);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 20);
            this.label13.TabIndex = 117;
            this.label13.Text = "Attachment Files :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(18, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 20);
            this.label12.TabIndex = 116;
            this.label12.Text = "Payment Mode :";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Items.AddRange(new object[] {
            "BANKTRANSFER",
            "CASH",
            "CHEQUE",
            "CREDITCARD",
            "DD",
            "DEBITCARD",
            "PETY CASH"});
            this.cmbPaymentMode.Location = new System.Drawing.Point(206, 57);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(199, 24);
            this.cmbPaymentMode.TabIndex = 1;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Depth = 0;
            this.txtAmount.Hint = "Enter Amount";
            this.txtAmount.Location = new System.Drawing.Point(206, 201);
            this.txtAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.Size = new System.Drawing.Size(199, 23);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TabStop = false;
            this.txtAmount.UseSystemPasswordChar = false;
            // 
            // txtPaidTo
            // 
            this.txtPaidTo.Depth = 0;
            this.txtPaidTo.Hint = "Enter Customer Name";
            this.txtPaidTo.Location = new System.Drawing.Point(213, 108);
            this.txtPaidTo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPaidTo.Name = "txtPaidTo";
            this.txtPaidTo.PasswordChar = '\0';
            this.txtPaidTo.SelectedText = "";
            this.txtPaidTo.SelectionLength = 0;
            this.txtPaidTo.SelectionStart = 0;
            this.txtPaidTo.Size = new System.Drawing.Size(192, 23);
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
            this.cmdAddExpense.Location = new System.Drawing.Point(248, 447);
            this.cmdAddExpense.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdAddExpense.Name = "cmdAddExpense";
            this.cmdAddExpense.Primary = true;
            this.cmdAddExpense.Size = new System.Drawing.Size(112, 33);
            this.cmdAddExpense.TabIndex = 8;
            this.cmdAddExpense.Text = "Add Income";
            this.cmdAddExpense.UseVisualStyleBackColor = false;
            this.cmdAddExpense.Click += new System.EventHandler(this.cmdAddExpense_Click_1);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel10);
            this.tabPage5.Controls.Add(this.panel9);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(888, 513);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Add Income Source";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.ADGVIncomeDetails);
            this.panel10.Location = new System.Drawing.Point(9, 133);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(864, 362);
            this.panel10.TabIndex = 1;
            // 
            // ADGVIncomeDetails
            // 
            this.ADGVIncomeDetails.AllowUserToAddRows = false;
            this.ADGVIncomeDetails.AutoGenerateContextFilters = true;
            this.ADGVIncomeDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVIncomeDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVIncomeDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVIncomeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVIncomeDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnDelete,
            this.btnUpdate});
            this.ADGVIncomeDetails.DateWithTime = false;
            this.ADGVIncomeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVIncomeDetails.Location = new System.Drawing.Point(0, 0);
            this.ADGVIncomeDetails.Name = "ADGVIncomeDetails";
            this.ADGVIncomeDetails.Size = new System.Drawing.Size(862, 360);
            this.ADGVIncomeDetails.TabIndex = 347;
            this.ADGVIncomeDetails.TimeFilter = false;
            this.ADGVIncomeDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVIncomeDetails_CellContentClick);
            this.ADGVIncomeDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVIncomeDetails_DataBindingComplete);
            this.ADGVIncomeDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVIncomeDetails_DataError);
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.MinimumWidth = 22;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 79;
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
            this.btnUpdate.Width = 84;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.cmdCreateExpence);
            this.panel9.Controls.Add(this.lblMsgIncm);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.txtIncome);
            this.panel9.Location = new System.Drawing.Point(10, 10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(863, 123);
            this.panel9.TabIndex = 0;
            // 
            // cmdCreateExpence
            // 
            this.cmdCreateExpence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreateExpence.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCreateExpence.BackColor = System.Drawing.Color.White;
            this.cmdCreateExpence.Depth = 0;
            this.cmdCreateExpence.Location = new System.Drawing.Point(403, 50);
            this.cmdCreateExpence.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCreateExpence.Name = "cmdCreateExpence";
            this.cmdCreateExpence.Primary = true;
            this.cmdCreateExpence.Size = new System.Drawing.Size(125, 33);
            this.cmdCreateExpence.TabIndex = 2;
            this.cmdCreateExpence.Text = "Create Income";
            this.cmdCreateExpence.UseVisualStyleBackColor = false;
            this.cmdCreateExpence.Click += new System.EventHandler(this.cmdCreateExpence_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel11);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(888, 513);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Income Entry";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.btnSave);
            this.panel11.Controls.Add(this.btnUpdatePaidIncome);
            this.panel11.Controls.Add(this.panelMaxInc);
            this.panel11.Controls.Add(this.panel6);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.chkDtFilter);
            this.panel11.Controls.Add(this.cmbViewExpenses);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Controls.Add(this.chkShowAllBranch);
            this.panel11.Location = new System.Drawing.Point(4, 8);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(873, 486);
            this.panel11.TabIndex = 0;
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
            this.btnSave.Location = new System.Drawing.Point(720, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnUpdatePaidIncome
            // 
            this.btnUpdatePaidIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePaidIncome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdatePaidIncome.BackColor = System.Drawing.Color.White;
            this.btnUpdatePaidIncome.Depth = 0;
            this.btnUpdatePaidIncome.Location = new System.Drawing.Point(616, 34);
            this.btnUpdatePaidIncome.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdatePaidIncome.Name = "btnUpdatePaidIncome";
            this.btnUpdatePaidIncome.Primary = true;
            this.btnUpdatePaidIncome.Size = new System.Drawing.Size(96, 33);
            this.btnUpdatePaidIncome.TabIndex = 1;
            this.btnUpdatePaidIncome.Text = "Update";
            this.btnUpdatePaidIncome.UseVisualStyleBackColor = false;
            this.btnUpdatePaidIncome.Click += new System.EventHandler(this.btnUpdatePaidIncome_Click_1);
            // 
            // panelMaxInc
            // 
            this.panelMaxInc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaxInc.Controls.Add(this.lblNameAndAmount);
            this.panelMaxInc.Controls.Add(this.label11);
            this.panelMaxInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMaxInc.Location = new System.Drawing.Point(598, 364);
            this.panelMaxInc.Name = "panelMaxInc";
            this.panelMaxInc.Size = new System.Drawing.Size(245, 78);
            this.panelMaxInc.TabIndex = 357;
            this.panelMaxInc.Visible = false;
            // 
            // lblNameAndAmount
            // 
            this.lblNameAndAmount.AutoSize = true;
            this.lblNameAndAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblNameAndAmount.Location = new System.Drawing.Point(13, 42);
            this.lblNameAndAmount.Name = "lblNameAndAmount";
            this.lblNameAndAmount.Size = new System.Drawing.Size(137, 19);
            this.lblNameAndAmount.TabIndex = 23;
            this.lblNameAndAmount.Text = "Name and Amount :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(7, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Max Income Source :";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.dtpToDate);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.dtpFromDate);
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(598, 244);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(247, 100);
            this.panel6.TabIndex = 356;
            this.panel6.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(10, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 19);
            this.label10.TabIndex = 30;
            this.label10.Text = "To :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(60, 51);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(135, 22);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.CloseUp += new System.EventHandler(this.dtpToDate_CloseUp);
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(9, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 28;
            this.label9.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(60, 14);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(135, 22);
            this.dtpFromDate.TabIndex = 6;
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.ADGVIncome);
            this.panel12.Location = new System.Drawing.Point(-5, -1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(579, 485);
            this.panel12.TabIndex = 0;
            // 
            // ADGVIncome
            // 
            this.ADGVIncome.AllowUserToAddRows = false;
            this.ADGVIncome.AutoGenerateContextFilters = true;
            this.ADGVIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVIncome.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVIncome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVIncome.DateWithTime = false;
            this.ADGVIncome.Location = new System.Drawing.Point(0, 0);
            this.ADGVIncome.Name = "ADGVIncome";
            this.ADGVIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVIncome.Size = new System.Drawing.Size(576, 485);
            this.ADGVIncome.TabIndex = 10;
            this.ADGVIncome.TimeFilter = false;
            this.ADGVIncome.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVIncome_DataBindingComplete);
            // 
            // FrmIncomeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(919, 666);
            this.Controls.Add(this.tabIncome);
            this.Controls.Add(this.materialTabSelector1);
            this.MaximizeBox = false;
            this.Name = "FrmIncomeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IncomeEntry";
            this.Load += new System.EventHandler(this.IncomeEntry_Load);
            this.tabIncome.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVIncomeDetails)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panelMaxInc.ResumeLayout(false);
            this.panelMaxInc.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVIncome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboIndirectExpenses;
        private System.Windows.Forms.DateTimePicker dateDt;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkShowAllBranch;
        private System.Windows.Forms.ComboBox cmbViewExpenses;
        private System.Windows.Forms.CheckBox chkDtFilter;
        private System.Windows.Forms.LinkLabel lnkAddAccount;
        private System.Windows.Forms.Label lblMsgIncm;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl tabIncome;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TabPage tabPage5;
        private MaterialSkin.Controls.MaterialRaisedButton cmdAddExpense;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private ADGV.AdvancedDataGridView ADGVIncomeDetails;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.DataGridViewButtonColumn btnUpdate;
        private MaterialSkin.Controls.MaterialRaisedButton cmdCreateExpence;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panelMaxInc;
        private System.Windows.Forms.Label lblNameAndAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Panel panel12;
        private ADGV.AdvancedDataGridView ADGVIncome;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdatePaidIncome;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPaidTo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPath;
        private MaterialSkin.Controls.MaterialRaisedButton btnBrowse;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdt;
    }
}
