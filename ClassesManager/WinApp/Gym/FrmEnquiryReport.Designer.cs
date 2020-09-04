﻿namespace ClassManager.WinApp.Gym
{
    partial class FrmEnquiryReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnquiryReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlViewFollowUp = new System.Windows.Forms.Panel();
            this.AdgvViewFolow = new ADGV.AdvancedDataGridView();
            this.PanelFollowUp = new System.Windows.Forms.Panel();
            this.cmb_followBy = new System.Windows.Forms.ComboBox();
            this.lbl_followBy = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cmbMediam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStudName = new System.Windows.Forms.Label();
            this.dtFollowup = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInactive = new System.Windows.Forms.Label();
            this.HelpPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lnkHelp = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SGStudents = new ClassManager.WinApp.UICommon.SuperGrid();
            this.SbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewEnquiry = new System.Windows.Forms.Button();
            this.txtCourseName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmbViewEnquiry = new System.Windows.Forms.ComboBox();
            this.txtFname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlViewFollowUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).BeginInit();
            this.PanelFollowUp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel17.SuspendLayout();
            this.HelpPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SGStudents)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Image";
            this.dataGridViewImageColumn1.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.dataGridViewImageColumn1.MinimumWidth = 22;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewImageColumn1.Width = 80;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Depth = 0;
            this.BtnCancel.Location = new System.Drawing.Point(1267, 69);
            this.BtnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Primary = true;
            this.BtnCancel.Size = new System.Drawing.Size(22, 24);
            this.BtnCancel.TabIndex = 67;
            this.BtnCancel.TabStop = false;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // pnlViewFollowUp
            // 
            this.pnlViewFollowUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlViewFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewFollowUp.Controls.Add(this.AdgvViewFolow);
            this.pnlViewFollowUp.Location = new System.Drawing.Point(956, 90);
            this.pnlViewFollowUp.Name = "pnlViewFollowUp";
            this.pnlViewFollowUp.Size = new System.Drawing.Size(337, 514);
            this.pnlViewFollowUp.TabIndex = 21;
            this.pnlViewFollowUp.Visible = false;
            // 
            // AdgvViewFolow
            // 
            this.AdgvViewFolow.AllowUserToAddRows = false;
            this.AdgvViewFolow.AllowUserToDeleteRows = false;
            this.AdgvViewFolow.AutoGenerateContextFilters = true;
            this.AdgvViewFolow.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdgvViewFolow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AdgvViewFolow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdgvViewFolow.DateWithTime = false;
            this.AdgvViewFolow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdgvViewFolow.Location = new System.Drawing.Point(0, 0);
            this.AdgvViewFolow.Name = "AdgvViewFolow";
            this.AdgvViewFolow.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdgvViewFolow.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.AdgvViewFolow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AdgvViewFolow.Size = new System.Drawing.Size(335, 512);
            this.AdgvViewFolow.TabIndex = 4;
            this.AdgvViewFolow.TimeFilter = false;
            this.AdgvViewFolow.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AdgvViewFolow_DataBindingComplete);
            this.AdgvViewFolow.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.AdgvViewFolow_RowPostPaint);
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
            this.PanelFollowUp.Location = new System.Drawing.Point(956, 98);
            this.PanelFollowUp.Name = "PanelFollowUp";
            this.PanelFollowUp.Size = new System.Drawing.Size(241, 506);
            this.PanelFollowUp.TabIndex = 20;
            // 
            // cmb_followBy
            // 
            this.cmb_followBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_followBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_followBy.FormattingEnabled = true;
            this.cmb_followBy.Location = new System.Drawing.Point(8, 247);
            this.cmb_followBy.Name = "cmb_followBy";
            this.cmb_followBy.Size = new System.Drawing.Size(147, 26);
            this.cmb_followBy.TabIndex = 430;
            this.cmb_followBy.TabStop = false;
            // 
            // lbl_followBy
            // 
            this.lbl_followBy.AutoSize = true;
            this.lbl_followBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_followBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lbl_followBy.Location = new System.Drawing.Point(11, 224);
            this.lbl_followBy.Name = "lbl_followBy";
            this.lbl_followBy.Size = new System.Drawing.Size(94, 20);
            this.lbl_followBy.TabIndex = 429;
            this.lbl_followBy.Text = "Followup By";
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
            this.btnSave.Location = new System.Drawing.Point(30, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 33);
            this.btnSave.TabIndex = 422;
            this.btnSave.Text = "SAVE  ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSaveFollowp_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(15, 347);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(185, 80);
            this.txtDescription.TabIndex = 65;
            this.txtDescription.Text = "";
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
            this.cmbMediam.Location = new System.Drawing.Point(8, 158);
            this.cmbMediam.Name = "cmbMediam";
            this.cmbMediam.Size = new System.Drawing.Size(147, 26);
            this.cmbMediam.TabIndex = 60;
            this.cmbMediam.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(8, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "Medium :";
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStudName.Location = new System.Drawing.Point(3, 17);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(53, 20);
            this.lblStudName.TabIndex = 57;
            this.lblStudName.Text = "name";
            // 
            // dtFollowup
            // 
            this.dtFollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFollowup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFollowup.Location = new System.Drawing.Point(8, 80);
            this.dtFollowup.Name = "dtFollowup";
            this.dtFollowup.Size = new System.Drawing.Size(110, 24);
            this.dtFollowup.TabIndex = 59;
            this.dtFollowup.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(11, 315);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 63;
            this.label15.Text = "Description :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_saveToPDF);
            this.panel1.Controls.Add(this.panel17);
            this.panel1.Controls.Add(this.HelpPanel);
            this.panel1.Controls.Add(this.lnkHelp);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 521);
            this.panel1.TabIndex = 0;
            // 
            // btn_saveToPDF
            // 
            this.btn_saveToPDF.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_saveToPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_saveToPDF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_saveToPDF.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_saveToPDF.FlatAppearance.BorderSize = 0;
            this.btn_saveToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveToPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveToPDF.ForeColor = System.Drawing.Color.White;
            this.btn_saveToPDF.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btn_saveToPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_saveToPDF.Location = new System.Drawing.Point(295, 68);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 412;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel17.Controls.Add(this.label7);
            this.panel17.Controls.Add(this.lblInactive);
            this.panel17.Location = new System.Drawing.Point(18, 62);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(167, 38);
            this.panel17.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Pending :";
            // 
            // lblInactive
            // 
            this.lblInactive.AutoSize = true;
            this.lblInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactive.ForeColor = System.Drawing.Color.White;
            this.lblInactive.Location = new System.Drawing.Point(97, 7);
            this.lblInactive.Name = "lblInactive";
            this.lblInactive.Size = new System.Drawing.Size(19, 20);
            this.lblInactive.TabIndex = 66;
            this.lblInactive.Text = "0";
            // 
            // HelpPanel
            // 
            this.HelpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpPanel.Controls.Add(this.label13);
            this.HelpPanel.Controls.Add(this.label12);
            this.HelpPanel.Controls.Add(this.label8);
            this.HelpPanel.Controls.Add(this.button3);
            this.HelpPanel.Controls.Add(this.button2);
            this.HelpPanel.Controls.Add(this.button1);
            this.HelpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpPanel.Location = new System.Drawing.Point(656, 62);
            this.HelpPanel.Name = "HelpPanel";
            this.HelpPanel.Size = new System.Drawing.Size(274, 38);
            this.HelpPanel.TabIndex = 68;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(224, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 16);
            this.label13.TabIndex = 70;
            this.label13.Text = "Low ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(131, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 16);
            this.label12.TabIndex = 69;
            this.label12.Text = "Mid ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 68;
            this.label8.Text = "High ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(213)))), ((int)(((byte)(129)))));
            this.button3.Location = new System.Drawing.Point(193, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 20);
            this.button3.TabIndex = 67;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.button2.Location = new System.Drawing.Point(100, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 66;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.button1.Location = new System.Drawing.Point(13, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 65;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lnkHelp
            // 
            this.lnkHelp.AutoSize = true;
            this.lnkHelp.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkHelp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkHelp.Location = new System.Drawing.Point(605, 65);
            this.lnkHelp.Name = "lnkHelp";
            this.lnkHelp.Size = new System.Drawing.Size(28, 33);
            this.lnkHelp.TabIndex = 67;
            this.lnkHelp.TabStop = true;
            this.lnkHelp.Text = "?";
            this.lnkHelp.Visible = false;
            this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHelp_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bindingNavigator1);
            this.panel3.Controls.Add(this.SGStudents);
            this.panel3.Location = new System.Drawing.Point(3, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(927, 410);
            this.panel3.TabIndex = 71;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(15, 377);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(209, 25);
            this.bindingNavigator1.TabIndex = 70;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.ReadOnly = true;
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SGStudents
            // 
            this.SGStudents.AllowUserToAddRows = false;
            this.SGStudents.AllowUserToDeleteRows = false;
            this.SGStudents.AutoGenerateContextFilters = true;
            this.SGStudents.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SGStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SGStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SGStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SbtnEdit,
            this.EditImage});
            this.SGStudents.DateWithTime = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SGStudents.DefaultCellStyle = dataGridViewCellStyle5;
            this.SGStudents.Location = new System.Drawing.Point(0, 0);
            this.SGStudents.Name = "SGStudents";
            this.SGStudents.PageSize = 10;
            this.SGStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SGStudents.Size = new System.Drawing.Size(924, 410);
            this.SGStudents.TabIndex = 5;
            this.SGStudents.TimeFilter = false;
            this.SGStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SGStudents_CellClick);
            this.SGStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SGStudents_CellContentClick);
            this.SGStudents.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.SGStudents_DataBindingComplete);
            this.SGStudents.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.SGStudents_DataError);
            this.SGStudents.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.SGStudents_RowPostPaint);
            // 
            // SbtnEdit
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "Edit";
            this.SbtnEdit.DefaultCellStyle = dataGridViewCellStyle4;
            this.SbtnEdit.HeaderText = "Edit";
            this.SbtnEdit.MinimumWidth = 22;
            this.SbtnEdit.Name = "SbtnEdit";
            this.SbtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SbtnEdit.Width = 80;
            // 
            // EditImage
            // 
            this.EditImage.HeaderText = "Edit";
            this.EditImage.Image = global::ClassManager.Properties.Resources.Edit;
            this.EditImage.MinimumWidth = 22;
            this.EditImage.Name = "EditImage";
            this.EditImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.EditImage.Width = 80;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNewEnquiry);
            this.panel2.Controls.Add(this.txtCourseName);
            this.panel2.Controls.Add(this.cmbViewEnquiry);
            this.panel2.Controls.Add(this.txtFname);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 52);
            this.panel2.TabIndex = 70;
            // 
            // btnNewEnquiry
            // 
            this.btnNewEnquiry.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnNewEnquiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEnquiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEnquiry.ForeColor = System.Drawing.Color.White;
            this.btnNewEnquiry.Image = global::ClassManager.Properties.Resources.speech_bubble_with_question_mark;
            this.btnNewEnquiry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewEnquiry.Location = new System.Drawing.Point(784, 5);
            this.btnNewEnquiry.Name = "btnNewEnquiry";
            this.btnNewEnquiry.Size = new System.Drawing.Size(138, 42);
            this.btnNewEnquiry.TabIndex = 74;
            this.btnNewEnquiry.Text = "New Enquiry";
            this.btnNewEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewEnquiry.UseVisualStyleBackColor = false;
            this.btnNewEnquiry.Click += new System.EventHandler(this.btnNewEnquiry_Click);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Depth = 0;
            this.txtCourseName.Hint = "Package Name";
            this.txtCourseName.Location = new System.Drawing.Point(326, 18);
            this.txtCourseName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.PasswordChar = '\0';
            this.txtCourseName.SelectedText = "";
            this.txtCourseName.SelectionLength = 0;
            this.txtCourseName.SelectionStart = 0;
            this.txtCourseName.Size = new System.Drawing.Size(126, 23);
            this.txtCourseName.TabIndex = 63;
            this.txtCourseName.TabStop = false;
            this.txtCourseName.UseSystemPasswordChar = false;
            this.txtCourseName.TextChanged += new System.EventHandler(this.txtCourseName_TextChanged);
            // 
            // cmbViewEnquiry
            // 
            this.cmbViewEnquiry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewEnquiry.FormattingEnabled = true;
            this.cmbViewEnquiry.Items.AddRange(new object[] {
            "ALL",
            "Pending",
            "Confirm",
            "High",
            "Mid",
            "Low",
            "Not Interested"});
            this.cmbViewEnquiry.Location = new System.Drawing.Point(615, 18);
            this.cmbViewEnquiry.Name = "cmbViewEnquiry";
            this.cmbViewEnquiry.Size = new System.Drawing.Size(122, 21);
            this.cmbViewEnquiry.TabIndex = 64;
            this.cmbViewEnquiry.TabStop = false;
            this.cmbViewEnquiry.SelectedIndexChanged += new System.EventHandler(this.cmbViewEnquiry_SelectedIndexChanged);
            // 
            // txtFname
            // 
            this.txtFname.Depth = 0;
            this.txtFname.Hint = "Enter Name";
            this.txtFname.Location = new System.Drawing.Point(75, 19);
            this.txtFname.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFname.Name = "txtFname";
            this.txtFname.PasswordChar = '\0';
            this.txtFname.SelectedText = "";
            this.txtFname.SelectionLength = 0;
            this.txtFname.SelectionStart = 0;
            this.txtFname.Size = new System.Drawing.Size(140, 23);
            this.txtFname.TabIndex = 62;
            this.txtFname.TabStop = false;
            this.txtFname.UseSystemPasswordChar = false;
            this.txtFname.TextChanged += new System.EventHandler(this.txtFname_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(197, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "OR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(558, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 69;
            this.label6.Text = "View :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(10, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 66;
            this.label14.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(252, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Package :";
            // 
            // FrmEnquiryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 683);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.pnlViewFollowUp);
            this.Controls.Add(this.PanelFollowUp);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEnquiryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquiry ";
            this.Load += new System.EventHandler(this.FrmEnquiryReport_Load);
            this.pnlViewFollowUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).EndInit();
            this.PanelFollowUp.ResumeLayout(false);
            this.PanelFollowUp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.HelpPanel.ResumeLayout(false);
            this.HelpPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SGStudents)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCourseName;
        private System.Windows.Forms.ComboBox cmbViewEnquiry;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInactive;
        private UICommon.SuperGrid SGStudents;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel HelpPanel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel lnkHelp;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel PanelFollowUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbMediam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.DateTimePicker dtFollowup;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlViewFollowUp;
        private MaterialSkin.Controls.MaterialRaisedButton BtnCancel;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNewEnquiry;
        private System.Windows.Forms.Label lbl_followBy;

        private System.Windows.Forms.DataGridViewButtonColumn SbtnEdit;
        private System.Windows.Forms.DataGridViewImageColumn EditImage;
        private System.Windows.Forms.ComboBox cmb_followBy;
        private ADGV.AdvancedDataGridView AdgvViewFolow;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_saveToPDF;
    }
}
