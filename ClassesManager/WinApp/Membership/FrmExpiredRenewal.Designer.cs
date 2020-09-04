namespace ClassManager.WinApp
{
    partial class FrmExpiredRenewal
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
            this.bgwExpiredPackages = new System.ComponentModel.BackgroundWorker();
            this.BtnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.BtnSMS = new System.Windows.Forms.Button();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.lblText = new MaterialSkin.Controls.MaterialLabel();
            this.txtFname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSearchby = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grid = new ADGV.AdvancedDataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtFollowup = new System.Windows.Forms.DateTimePicker();
            this.lblStudName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMediam = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbl_followBy = new System.Windows.Forms.Label();
            this.pnlViewFollowUp = new System.Windows.Forms.Panel();
            this.AdgvViewFolow = new ADGV.AdvancedDataGridView();
            this.cmb_followBy = new System.Windows.Forms.ComboBox();
            this.PanelFollowUp = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlViewFollowUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).BeginInit();
            this.PanelFollowUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwExpiredPackages
            // 
            this.bgwExpiredPackages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExpiredPackages_DoWork);
            this.bgwExpiredPackages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwExpiredPackages_RunWorkerCompleted);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Depth = 0;
            this.BtnCancel.Location = new System.Drawing.Point(1345, 66);
            this.BtnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Primary = true;
            this.BtnCancel.Size = new System.Drawing.Size(40, 24);
            this.BtnCancel.TabIndex = 68;
            this.BtnCancel.TabStop = false;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.grid);
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 489);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSendMail);
            this.panel2.Controls.Add(this.BtnSMS);
            this.panel2.Controls.Add(this.btnSaveToExcel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblSearchby);
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Location = new System.Drawing.Point(12, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 98);
            this.panel2.TabIndex = 12;
            // 
            // btnSendMail
            // 
            this.btnSendMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendMail.FlatAppearance.BorderSize = 0;
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.White;
            this.btnSendMail.Image = global::ClassManager.Properties.Resources.Gmail_Icon;
            this.btnSendMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendMail.Location = new System.Drawing.Point(845, 44);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(77, 28);
            this.btnSendMail.TabIndex = 6;
            this.btnSendMail.Text = "SEND";
            this.btnSendMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMail.UseVisualStyleBackColor = false;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // BtnSMS
            // 
            this.BtnSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSMS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSMS.FlatAppearance.BorderSize = 0;
            this.BtnSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSMS.ForeColor = System.Drawing.Color.White;
            this.BtnSMS.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.BtnSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSMS.Location = new System.Drawing.Point(624, 41);
            this.BtnSMS.Name = "BtnSMS";
            this.BtnSMS.Size = new System.Drawing.Size(82, 31);
            this.BtnSMS.TabIndex = 4;
            this.BtnSMS.Text = "SEND";
            this.BtnSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSMS.UseVisualStyleBackColor = false;
            this.BtnSMS.Click += new System.EventHandler(this.BtnSMS_Click);
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveToExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveToExcel.FlatAppearance.BorderSize = 0;
            this.btnSaveToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToExcel.ForeColor = System.Drawing.Color.White;
            this.btnSaveToExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveToExcel.Location = new System.Drawing.Point(731, 43);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(95, 31);
            this.btnSaveToExcel.TabIndex = 5;
            this.btnSaveToExcel.Text = "SAVE TO";
            this.btnSaveToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.UseVisualStyleBackColor = false;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbFilterBy);
            this.panel3.Controls.Add(this.lblText);
            this.panel3.Controls.Add(this.txtFname);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(9, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 60);
            this.panel3.TabIndex = 66;
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Expired All",
            "Expired Last 30 Days",
            "To Be  Expired",
            "With No Facility"});
            this.cmbFilterBy.Location = new System.Drawing.Point(80, 13);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(236, 24);
            this.cmbFilterBy.TabIndex = 1;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Depth = 0;
            this.lblText.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblText.Location = new System.Drawing.Point(3, 13);
            this.lblText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(71, 19);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Filter By :";
            // 
            // txtFname
            // 
            this.txtFname.Depth = 0;
            this.txtFname.Hint = "Enter Name";
            this.txtFname.Location = new System.Drawing.Point(405, 13);
            this.txtFname.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFname.Name = "txtFname";
            this.txtFname.PasswordChar = '\0';
            this.txtFname.SelectedText = "";
            this.txtFname.SelectionLength = 0;
            this.txtFname.SelectionStart = 0;
            this.txtFname.Size = new System.Drawing.Size(166, 23);
            this.txtFname.TabIndex = 2;
            this.txtFname.UseSystemPasswordChar = false;
            this.txtFname.TextChanged += new System.EventHandler(this.txtFname_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(340, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "Name :";
            // 
            // lblSearchby
            // 
            this.lblSearchby.AutoSize = true;
            this.lblSearchby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblSearchby.Location = new System.Drawing.Point(3, 0);
            this.lblSearchby.Name = "lblSearchby";
            this.lblSearchby.Size = new System.Drawing.Size(101, 20);
            this.lblSearchby.TabIndex = 65;
            this.lblSearchby.Text = "Search By :";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(728, 3);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoGenerateContextFilters = true;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.DateWithTime = false;
            this.grid.Location = new System.Drawing.Point(12, 128);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(938, 358);
            this.grid.TabIndex = 8;
            this.grid.TimeFilter = false;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grid_DataBindingComplete);
            this.grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(24, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Date :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(24, 314);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 63;
            this.label15.Text = "Description :";
            // 
            // dtFollowup
            // 
            this.dtFollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFollowup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFollowup.Location = new System.Drawing.Point(21, 97);
            this.dtFollowup.Name = "dtFollowup";
            this.dtFollowup.Size = new System.Drawing.Size(110, 24);
            this.dtFollowup.TabIndex = 59;
            this.dtFollowup.TabStop = false;
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStudName.Location = new System.Drawing.Point(17, 15);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(53, 20);
            this.lblStudName.TabIndex = 57;
            this.lblStudName.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(24, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "Medium :";
            // 
            // cmbMediam
            // 
            this.cmbMediam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMediam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMediam.FormattingEnabled = true;
            this.cmbMediam.Items.AddRange(new object[] {
            "Telephonic",
            "SMS",
            "Meeting",
            "Email"});
            this.cmbMediam.Location = new System.Drawing.Point(21, 174);
            this.cmbMediam.Name = "cmbMediam";
            this.cmbMediam.Size = new System.Drawing.Size(147, 26);
            this.cmbMediam.TabIndex = 60;
            this.cmbMediam.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(21, 337);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(185, 80);
            this.txtDescription.TabIndex = 65;
            this.txtDescription.Text = "";
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
            this.btnSave.Location = new System.Drawing.Point(64, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 33);
            this.btnSave.TabIndex = 422;
            this.btnSave.Text = "SAVE  ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbl_followBy
            // 
            this.lbl_followBy.AutoSize = true;
            this.lbl_followBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_followBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lbl_followBy.Location = new System.Drawing.Point(24, 229);
            this.lbl_followBy.Name = "lbl_followBy";
            this.lbl_followBy.Size = new System.Drawing.Size(94, 20);
            this.lbl_followBy.TabIndex = 429;
            this.lbl_followBy.Text = "Followup By";
            // 
            // pnlViewFollowUp
            // 
            this.pnlViewFollowUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlViewFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewFollowUp.Controls.Add(this.AdgvViewFolow);
            this.pnlViewFollowUp.Location = new System.Drawing.Point(955, 93);
            this.pnlViewFollowUp.Name = "pnlViewFollowUp";
            this.pnlViewFollowUp.Size = new System.Drawing.Size(369, 489);
            this.pnlViewFollowUp.TabIndex = 431;
            this.pnlViewFollowUp.Visible = false;
            // 
            // AdgvViewFolow
            // 
            this.AdgvViewFolow.AllowUserToAddRows = false;
            this.AdgvViewFolow.AllowUserToDeleteRows = false;
            this.AdgvViewFolow.AutoGenerateContextFilters = true;
            this.AdgvViewFolow.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdgvViewFolow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.AdgvViewFolow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdgvViewFolow.DateWithTime = false;
            this.AdgvViewFolow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdgvViewFolow.Location = new System.Drawing.Point(0, 0);
            this.AdgvViewFolow.Name = "AdgvViewFolow";
            this.AdgvViewFolow.ReadOnly = true;
            this.AdgvViewFolow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AdgvViewFolow.Size = new System.Drawing.Size(367, 487);
            this.AdgvViewFolow.TabIndex = 13;
            this.AdgvViewFolow.TimeFilter = false;
            this.AdgvViewFolow.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AdgvViewFolow_DataBindingComplete_1);
            // 
            // cmb_followBy
            // 
            this.cmb_followBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_followBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_followBy.FormattingEnabled = true;
            this.cmb_followBy.Location = new System.Drawing.Point(21, 252);
            this.cmb_followBy.Name = "cmb_followBy";
            this.cmb_followBy.Size = new System.Drawing.Size(147, 26);
            this.cmb_followBy.TabIndex = 430;
            this.cmb_followBy.TabStop = false;
            // 
            // PanelFollowUp
            // 
            this.PanelFollowUp.BackColor = System.Drawing.Color.White;
            this.PanelFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFollowUp.Controls.Add(this.cmb_followBy);
            this.PanelFollowUp.Controls.Add(this.lbl_followBy);
            this.PanelFollowUp.Controls.Add(this.btnSave);
            this.PanelFollowUp.Controls.Add(this.txtDescription);
            this.PanelFollowUp.Controls.Add(this.cmbMediam);
            this.PanelFollowUp.Controls.Add(this.label1);
            this.PanelFollowUp.Controls.Add(this.lblStudName);
            this.PanelFollowUp.Controls.Add(this.dtFollowup);
            this.PanelFollowUp.Controls.Add(this.label15);
            this.PanelFollowUp.Controls.Add(this.label4);
            this.PanelFollowUp.Location = new System.Drawing.Point(955, 93);
            this.PanelFollowUp.Name = "PanelFollowUp";
            this.PanelFollowUp.Size = new System.Drawing.Size(254, 489);
            this.PanelFollowUp.TabIndex = 21;
            // 
            // FrmExpiredRenewal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 696);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.pnlViewFollowUp);
            this.Controls.Add(this.PanelFollowUp);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmExpiredRenewal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpiredOrRenewal";
            this.Load += new System.EventHandler(this.FrmExpiredRenewal_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlViewFollowUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).EndInit();
            this.PanelFollowUp.ResumeLayout(false);
            this.PanelFollowUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private MaterialSkin.Controls.MaterialLabel lblText;
        private ADGV.AdvancedDataGridView grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.ComponentModel.BackgroundWorker bgwExpiredPackages;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFname;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSearchby;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button BtnSMS;
        private System.Windows.Forms.Button btnSendMail;
        private MaterialSkin.Controls.MaterialRaisedButton BtnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtFollowup;
        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMediam;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbl_followBy;
        private System.Windows.Forms.Panel pnlViewFollowUp;
        private ADGV.AdvancedDataGridView AdgvViewFolow;
        private System.Windows.Forms.ComboBox cmb_followBy;
        private System.Windows.Forms.Panel PanelFollowUp;
    }
}
