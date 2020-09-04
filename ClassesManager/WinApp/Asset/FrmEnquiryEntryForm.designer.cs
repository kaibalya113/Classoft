﻿namespace ClassManager.WinApp.Asset
{
    partial class FrmEnquiryEntryForm
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
            this.bgwekerSendSMS = new System.ComponentModel.BackgroundWorker();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnViewAll = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtFollowup = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbQualification = new System.Windows.Forms.ComboBox();
            this.txtParentContact = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmailID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSubjects = new System.Windows.Forms.TextBox();
            this.txtContact = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbRefBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.lblBrnch = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEnquiryDate = new System.Windows.Forms.Label();
            this.dtpEnquiryDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.cmbStandard = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwekerSendSMS
            // 
            this.bgwekerSendSMS.WorkerReportsProgress = true;
            this.bgwekerSendSMS.WorkerSupportsCancellation = true;
            this.bgwekerSendSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwekerSendSMS_DoWork);
            this.bgwekerSendSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwekerSendSMS_RunWorkerCompleted);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::ClassManager.Properties.Resources.refresh_arrows_symbol_of_interface;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(672, 648);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 33);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "RESET";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btnSave.Location = new System.Drawing.Point(553, 648);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 33);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "SAVE   ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(2, 528);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Follow Up Details :";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewAll.BackColor = System.Drawing.Color.White;
            this.btnViewAll.Depth = 0;
            this.btnViewAll.Location = new System.Drawing.Point(3, 648);
            this.btnViewAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Primary = true;
            this.btnViewAll.Size = new System.Drawing.Size(139, 36);
            this.btnViewAll.TabIndex = 21;
            this.btnViewAll.Text = "View All Enquiry";
            this.btnViewAll.UseVisualStyleBackColor = false;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(2, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Enquiry Details :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(2, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Personal Details :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cmbstatus);
            this.panel3.Controls.Add(this.txtDescription);
            this.panel3.Controls.Add(this.dtFollowup);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(6, 551);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(788, 91);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(18, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 129;
            this.label2.Text = "Priority :";
            // 
            // cmbstatus
            // 
            this.cmbstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "High",
            "Mid",
            "Low"});
            this.cmbstatus.Location = new System.Drawing.Point(99, 61);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(164, 24);
            this.cmbstatus.TabIndex = 19;
            this.cmbstatus.Tag = "";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(577, 10);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(154, 40);
            this.txtDescription.TabIndex = 18;
            // 
            // dtFollowup
            // 
            this.dtFollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFollowup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFollowup.Location = new System.Drawing.Point(99, 16);
            this.dtFollowup.MinDate = new System.DateTime(2016, 4, 9, 0, 0, 0, 0);
            this.dtFollowup.Name = "dtFollowup";
            this.dtFollowup.Size = new System.Drawing.Size(164, 24);
            this.dtFollowup.TabIndex = 17;
            this.dtFollowup.Value = new System.DateTime(2016, 9, 12, 0, 0, 0, 0);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(465, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Description :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(28, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Date :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.cmbQualification);
            this.panel2.Controls.Add(this.txtParentContact);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtEmailID);
            this.panel2.Controls.Add(this.txtSubjects);
            this.panel2.Controls.Add(this.txtContact);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtLName);
            this.panel2.Controls.Add(this.txtMName);
            this.panel2.Controls.Add(this.txtFName);
            this.panel2.Controls.Add(this.dtpDOB);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.cmbRefBy);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(6, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 285);
            this.panel2.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label18.Location = new System.Drawing.Point(14, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 20);
            this.label18.TabIndex = 134;
            this.label18.Text = "Qualification :";
            // 
            // cmbQualification
            // 
            this.cmbQualification.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbQualification.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQualification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQualification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbQualification.FormattingEnabled = true;
            this.cmbQualification.Items.AddRange(new object[] {
            "SSC",
            "HSC",
            "Diploma",
            "Under Graduate",
            "Graduate",
            "Post Graduate"});
            this.cmbQualification.Location = new System.Drawing.Point(10, 226);
            this.cmbQualification.Name = "cmbQualification";
            this.cmbQualification.Size = new System.Drawing.Size(169, 24);
            this.cmbQualification.TabIndex = 9;
            this.cmbQualification.Tag = "";
            // 
            // txtParentContact
            // 
            this.txtParentContact.Depth = 0;
            this.txtParentContact.Hint = "Enter Parent Contact";
            this.txtParentContact.Location = new System.Drawing.Point(274, 72);
            this.txtParentContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtParentContact.Name = "txtParentContact";
            this.txtParentContact.PasswordChar = '\0';
            this.txtParentContact.SelectedText = "";
            this.txtParentContact.SelectionLength = 0;
            this.txtParentContact.SelectionStart = 0;
            this.txtParentContact.Size = new System.Drawing.Size(164, 23);
            this.txtParentContact.TabIndex = 4;
            this.txtParentContact.TabStop = false;
            this.txtParentContact.UseSystemPasswordChar = false;
            this.txtParentContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParentContact_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(15, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 57;
            this.label1.Text = "DOB :";
            // 
            // txtEmailID
            // 
            this.txtEmailID.Depth = 0;
            this.txtEmailID.Hint = "Enter Email";
            this.txtEmailID.Location = new System.Drawing.Point(533, 72);
            this.txtEmailID.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.PasswordChar = '\0';
            this.txtEmailID.SelectedText = "";
            this.txtEmailID.SelectionLength = 0;
            this.txtEmailID.SelectionStart = 0;
            this.txtEmailID.Size = new System.Drawing.Size(183, 23);
            this.txtEmailID.TabIndex = 5;
            this.txtEmailID.TabStop = false;
            this.txtEmailID.UseSystemPasswordChar = false;
            // 
            // txtSubjects
            // 
            this.txtSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjects.Location = new System.Drawing.Point(274, 219);
            this.txtSubjects.Multiline = true;
            this.txtSubjects.Name = "txtSubjects";
            this.txtSubjects.Size = new System.Drawing.Size(151, 40);
            this.txtSubjects.TabIndex = 10;
            // 
            // txtContact
            // 
            this.txtContact.Depth = 0;
            this.txtContact.Hint = "Enter Contact";
            this.txtContact.Location = new System.Drawing.Point(15, 72);
            this.txtContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.Size = new System.Drawing.Size(164, 23);
            this.txtContact.TabIndex = 3;
            this.txtContact.TabStop = false;
            this.txtContact.UseSystemPasswordChar = false;
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(270, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 20);
            this.label6.TabIndex = 130;
            this.label6.Text = "Previous Computer Knowledge :";
            // 
            // txtLName
            // 
            this.txtLName.Depth = 0;
            this.txtLName.Hint = "Enter Last Name";
            this.txtLName.Location = new System.Drawing.Point(533, 24);
            this.txtLName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLName.Name = "txtLName";
            this.txtLName.PasswordChar = '\0';
            this.txtLName.SelectedText = "";
            this.txtLName.SelectionLength = 0;
            this.txtLName.SelectionStart = 0;
            this.txtLName.Size = new System.Drawing.Size(183, 23);
            this.txtLName.TabIndex = 2;
            this.txtLName.TabStop = false;
            this.txtLName.UseSystemPasswordChar = false;
            this.txtLName.Click += new System.EventHandler(this.txtLName_Click);
            // 
            // txtMName
            // 
            this.txtMName.Depth = 0;
            this.txtMName.Hint = "Enter Middle Name";
            this.txtMName.Location = new System.Drawing.Point(275, 24);
            this.txtMName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMName.Name = "txtMName";
            this.txtMName.PasswordChar = '\0';
            this.txtMName.SelectedText = "";
            this.txtMName.SelectionLength = 0;
            this.txtMName.SelectionStart = 0;
            this.txtMName.Size = new System.Drawing.Size(164, 23);
            this.txtMName.TabIndex = 1;
            this.txtMName.TabStop = false;
            this.txtMName.UseSystemPasswordChar = false;
            this.txtMName.Click += new System.EventHandler(this.txtMName_Click);
            // 
            // txtFName
            // 
            this.txtFName.Depth = 0;
            this.txtFName.Hint = "Enter First Name";
            this.txtFName.Location = new System.Drawing.Point(15, 24);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(164, 23);
            this.txtFName.TabIndex = 0;
            this.txtFName.TabStop = false;
            this.txtFName.UseSystemPasswordChar = false;
            this.txtFName.Click += new System.EventHandler(this.txtFName_Click);
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(15, 149);
            this.dtpDOB.MinDate = new System.DateTime(1909, 12, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(164, 22);
            this.dtpDOB.TabIndex = 6;
            this.dtpDOB.Value = new System.DateTime(2016, 9, 12, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(183, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 20);
            this.label13.TabIndex = 49;
            this.label13.Text = "*";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Location = new System.Drawing.Point(185, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(16, 20);
            this.label34.TabIndex = 2;
            this.label34.Text = "*";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(533, 128);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(183, 44);
            this.txtAddress.TabIndex = 8;
            // 
            // cmbRefBy
            // 
            this.cmbRefBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefBy.FormattingEnabled = true;
            this.cmbRefBy.Items.AddRange(new object[] {
            "Approached By Classes",
            "Friends",
            "Family Member ",
            "Banner",
            "Pamplet",
            "TV Ad\'s",
            "Walkin"});
            this.cmbRefBy.Location = new System.Drawing.Point(275, 148);
            this.cmbRefBy.Name = "cmbRefBy";
            this.cmbRefBy.Size = new System.Drawing.Size(164, 24);
            this.cmbRefBy.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(274, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Reference By :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(530, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbBatch);
            this.panel1.Controls.Add(this.lblBrnch);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbField);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtFees);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblEnquiryDate);
            this.panel1.Controls.Add(this.dtpEnquiryDate);
            this.panel1.Controls.Add(this.cmbStream);
            this.panel1.Controls.Add(this.cmbStandard);
            this.panel1.Location = new System.Drawing.Point(6, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 117);
            this.panel1.TabIndex = 1;
            // 
            // cmbBatch
            // 
            this.cmbBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(632, 14);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(139, 24);
            this.cmbBatch.TabIndex = 13;
            this.cmbBatch.Tag = "";
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            // 
            // lblBrnch
            // 
            this.lblBrnch.AutoSize = true;
            this.lblBrnch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrnch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBrnch.Location = new System.Drawing.Point(268, 60);
            this.lblBrnch.Name = "lblBrnch";
            this.lblBrnch.Size = new System.Drawing.Size(85, 18);
            this.lblBrnch.TabIndex = 127;
            this.lblBrnch.Text = "Counselor :";
            this.lblBrnch.Click += new System.EventHandler(this.lblBrnch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(567, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 131;
            this.label10.Text = "Batch :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(547, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Subjects :";
            this.label3.Visible = false;
            // 
            // cmbField
            // 
            this.cmbField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(359, 60);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(142, 24);
            this.cmbField.TabIndex = 15;
            this.cmbField.Tag = "";
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(506, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 20);
            this.label17.TabIndex = 51;
            this.label17.Text = "*";
            // 
            // txtFees
            // 
            this.txtFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFees.Location = new System.Drawing.Point(632, 62);
            this.txtFees.Multiline = true;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(139, 40);
            this.txtFees.TabIndex = 16;
            this.txtFees.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(231, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 20);
            this.label16.TabIndex = 50;
            this.label16.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(11, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Stream :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(285, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Course :";
            // 
            // lblEnquiryDate
            // 
            this.lblEnquiryDate.AutoSize = true;
            this.lblEnquiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnquiryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblEnquiryDate.Location = new System.Drawing.Point(7, 62);
            this.lblEnquiryDate.Name = "lblEnquiryDate";
            this.lblEnquiryDate.Size = new System.Drawing.Size(73, 18);
            this.lblEnquiryDate.TabIndex = 59;
            this.lblEnquiryDate.Text = "Enq Date:";
            // 
            // dtpEnquiryDate
            // 
            this.dtpEnquiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnquiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnquiryDate.Location = new System.Drawing.Point(86, 62);
            this.dtpEnquiryDate.MinDate = new System.DateTime(1909, 12, 1, 0, 0, 0, 0);
            this.dtpEnquiryDate.Name = "dtpEnquiryDate";
            this.dtpEnquiryDate.Size = new System.Drawing.Size(139, 22);
            this.dtpEnquiryDate.TabIndex = 14;
            this.dtpEnquiryDate.Value = new System.DateTime(2017, 6, 10, 0, 0, 0, 0);
            // 
            // cmbStream
            // 
            this.cmbStream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(86, 16);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(139, 24);
            this.cmbStream.TabIndex = 11;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // cmbStandard
            // 
            this.cmbStandard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStandard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStandard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbStandard.FormattingEnabled = true;
            this.cmbStandard.Location = new System.Drawing.Point(359, 14);
            this.cmbStandard.Name = "cmbStandard";
            this.cmbStandard.Size = new System.Drawing.Size(142, 24);
            this.cmbStandard.TabIndex = 12;
            this.cmbStandard.Tag = "";
            this.cmbStandard.SelectedIndexChanged += new System.EventHandler(this.cmbStandard_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmEnquiryEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 688);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnquiryEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquiry";
            this.Load += new System.EventHandler(this.EnquiryEntryForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStandard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
      
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtFollowup;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker bgwekerSendSMS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
      
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cmbRefBy;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialRaisedButton btnViewAll;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmailID;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtContact;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnquiryDate;
        private System.Windows.Forms.DateTimePicker dtpEnquiryDate;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtParentContact;
        private System.Windows.Forms.TextBox txtSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Label lblBrnch;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbQualification;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label10;
    }
}
