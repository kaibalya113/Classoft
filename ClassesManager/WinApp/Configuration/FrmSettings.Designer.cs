namespace ClassManager.WinApp
{
    partial class FrmSettings
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
            this.cmdSyncData = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblCon = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAttendanceUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOpenDeviceMgr = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAutomatic = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSampleSMS = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSendEmail = new System.Windows.Forms.Panel();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.lblEmailText = new System.Windows.Forms.Label();
            this.txtMailBody = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEnterEmail = new System.Windows.Forms.Label();
            this.lblSampleSMS = new System.Windows.Forms.Label();
            this.pnlSendSMS = new System.Windows.Forms.Panel();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.lblEnterText = new System.Windows.Forms.Label();
            this.txtSMSBody = new System.Windows.Forms.TextBox();
            this.txtEnterNo = new System.Windows.Forms.TextBox();
            this.lblEnterNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTobeExpiry = new System.Windows.Forms.CheckBox();
            this.chkExpiry = new System.Windows.Forms.CheckBox();
            this.chkInvoiceMail = new System.Windows.Forms.CheckBox();
            this.chkFeesMail = new System.Windows.Forms.CheckBox();
            this.chkbxsndlectsmsstudent = new System.Windows.Forms.CheckBox();
            this.cmdUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkFeesSMS = new System.Windows.Forms.CheckBox();
            this.chkSndOutstndngFees = new System.Windows.Forms.CheckBox();
            this.chkDailyReports = new System.Windows.Forms.CheckBox();
            this.chkFlwp = new System.Windows.Forms.CheckBox();
            this.chkbxSendDueNotification = new System.Windows.Forms.CheckBox();
            this.chkAnni = new System.Windows.Forms.CheckBox();
            this.chkBday = new System.Windows.Forms.CheckBox();
            this.chkReg = new System.Windows.Forms.CheckBox();
            this.chkbxLectureSMSToFaculty = new System.Windows.Forms.CheckBox();
            this.chkEnq = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkbxSignOUTSMS = new System.Windows.Forms.CheckBox();
            this.chkbxSignINSMS = new System.Windows.Forms.CheckBox();
            this.chkbxSendAbsentSMS = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.grpSampleSMS.SuspendLayout();
            this.pnlSendEmail.SuspendLayout();
            this.pnlSendSMS.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSyncData
            // 
            this.cmdSyncData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSyncData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdSyncData.BackColor = System.Drawing.Color.White;
            this.cmdSyncData.Depth = 0;
            this.cmdSyncData.Location = new System.Drawing.Point(827, 77);
            this.cmdSyncData.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdSyncData.Name = "cmdSyncData";
            this.cmdSyncData.Primary = true;
            this.cmdSyncData.Size = new System.Drawing.Size(94, 33);
            this.cmdSyncData.TabIndex = 23;
            this.cmdSyncData.Text = "Data Sync";
            this.cmdSyncData.UseVisualStyleBackColor = false;
            this.cmdSyncData.Click += new System.EventHandler(this.cmdSyncData_Click);
            // 
            // lblCon
            // 
            this.lblCon.AutoSize = true;
            this.lblCon.BackColor = System.Drawing.Color.White;
            this.lblCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCon.Location = new System.Drawing.Point(176, 82);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(86, 20);
            this.lblCon.TabIndex = 11;
            this.lblCon.Text = "connString";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(9, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Connected database :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnAttendanceUpdate);
            this.groupBox2.Controls.Add(this.btnOpenDeviceMgr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPortNo);
            this.groupBox2.Controls.Add(this.txtDeviceID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkAutomatic);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 541);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 198);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attendance Settings";
            // 
            // btnAttendanceUpdate
            // 
            this.btnAttendanceUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttendanceUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAttendanceUpdate.BackColor = System.Drawing.Color.White;
            this.btnAttendanceUpdate.Depth = 0;
            this.btnAttendanceUpdate.Location = new System.Drawing.Point(213, 137);
            this.btnAttendanceUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAttendanceUpdate.Name = "btnAttendanceUpdate";
            this.btnAttendanceUpdate.Primary = true;
            this.btnAttendanceUpdate.Size = new System.Drawing.Size(73, 33);
            this.btnAttendanceUpdate.TabIndex = 22;
            this.btnAttendanceUpdate.Text = "Update";
            this.btnAttendanceUpdate.UseVisualStyleBackColor = false;
            this.btnAttendanceUpdate.Click += new System.EventHandler(this.btnAttendanceUpdate_Click);
            // 
            // btnOpenDeviceMgr
            // 
            this.btnOpenDeviceMgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDeviceMgr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenDeviceMgr.BackColor = System.Drawing.Color.White;
            this.btnOpenDeviceMgr.Depth = 0;
            this.btnOpenDeviceMgr.Location = new System.Drawing.Point(16, 137);
            this.btnOpenDeviceMgr.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenDeviceMgr.Name = "btnOpenDeviceMgr";
            this.btnOpenDeviceMgr.Primary = true;
            this.btnOpenDeviceMgr.Size = new System.Drawing.Size(173, 33);
            this.btnOpenDeviceMgr.TabIndex = 21;
            this.btnOpenDeviceMgr.Text = "Open Device Manager";
            this.btnOpenDeviceMgr.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(29, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Port No :";
            // 
            // txtPortNo
            // 
            this.txtPortNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPortNo.Location = new System.Drawing.Point(155, 75);
            this.txtPortNo.Multiline = true;
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(131, 25);
            this.txtPortNo.TabIndex = 20;
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceID.Location = new System.Drawing.Point(155, 23);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(131, 26);
            this.txtDeviceID.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(29, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Device IP :";
            // 
            // chkAutomatic
            // 
            this.chkAutomatic.AutoSize = true;
            this.chkAutomatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutomatic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkAutomatic.Location = new System.Drawing.Point(385, 25);
            this.chkAutomatic.Name = "chkAutomatic";
            this.chkAutomatic.Size = new System.Drawing.Size(100, 24);
            this.chkAutomatic.TabIndex = 18;
            this.chkAutomatic.Text = "Automatic";
            this.chkAutomatic.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(176, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 18;
            // 
            // grpSampleSMS
            // 
            this.grpSampleSMS.BackColor = System.Drawing.Color.White;
            this.grpSampleSMS.Controls.Add(this.label2);
            this.grpSampleSMS.Controls.Add(this.pnlSendEmail);
            this.grpSampleSMS.Controls.Add(this.lblSampleSMS);
            this.grpSampleSMS.Controls.Add(this.pnlSendSMS);
            this.grpSampleSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSampleSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.grpSampleSMS.Location = new System.Drawing.Point(538, 112);
            this.grpSampleSMS.Name = "grpSampleSMS";
            this.grpSampleSMS.Size = new System.Drawing.Size(383, 558);
            this.grpSampleSMS.TabIndex = 2;
            this.grpSampleSMS.TabStop = false;
            this.grpSampleSMS.Text = "Testing Sample";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(16, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Send Email";
            // 
            // pnlSendEmail
            // 
            this.pnlSendEmail.BackColor = System.Drawing.Color.White;
            this.pnlSendEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSendEmail.Controls.Add(this.btnSendEmail);
            this.pnlSendEmail.Controls.Add(this.lblEmailText);
            this.pnlSendEmail.Controls.Add(this.txtMailBody);
            this.pnlSendEmail.Controls.Add(this.txtEmail);
            this.pnlSendEmail.Controls.Add(this.lblEnterEmail);
            this.pnlSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSendEmail.Location = new System.Drawing.Point(20, 358);
            this.pnlSendEmail.Name = "pnlSendEmail";
            this.pnlSendEmail.Size = new System.Drawing.Size(351, 187);
            this.pnlSendEmail.TabIndex = 2;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendEmail.FlatAppearance.BorderSize = 0;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.White;
            this.btnSendEmail.Image = global::ClassManager.Properties.Resources.Gmail_Icon;
            this.btnSendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendEmail.Location = new System.Drawing.Point(255, 149);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(77, 28);
            this.btnSendEmail.TabIndex = 29;
            this.btnSendEmail.Text = "SEND";
            this.btnSendEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // lblEmailText
            // 
            this.lblEmailText.AutoSize = true;
            this.lblEmailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblEmailText.Location = new System.Drawing.Point(17, 63);
            this.lblEmailText.Name = "lblEmailText";
            this.lblEmailText.Size = new System.Drawing.Size(90, 20);
            this.lblEmailText.TabIndex = 3;
            this.lblEmailText.Text = "Enter Text :";
            // 
            // txtMailBody
            // 
            this.txtMailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailBody.Location = new System.Drawing.Point(140, 60);
            this.txtMailBody.Multiline = true;
            this.txtMailBody.Name = "txtMailBody";
            this.txtMailBody.Size = new System.Drawing.Size(191, 68);
            this.txtMailBody.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(140, 15);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(191, 22);
            this.txtEmail.TabIndex = 27;
            // 
            // lblEnterEmail
            // 
            this.lblEnterEmail.AutoSize = true;
            this.lblEnterEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblEnterEmail.Location = new System.Drawing.Point(17, 15);
            this.lblEnterEmail.Name = "lblEnterEmail";
            this.lblEnterEmail.Size = new System.Drawing.Size(99, 20);
            this.lblEnterEmail.TabIndex = 0;
            this.lblEnterEmail.Text = "Enter Email :";
            // 
            // lblSampleSMS
            // 
            this.lblSampleSMS.AutoSize = true;
            this.lblSampleSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblSampleSMS.Location = new System.Drawing.Point(16, 54);
            this.lblSampleSMS.Name = "lblSampleSMS";
            this.lblSampleSMS.Size = new System.Drawing.Size(94, 20);
            this.lblSampleSMS.TabIndex = 1;
            this.lblSampleSMS.Text = "Send SMS";
            // 
            // pnlSendSMS
            // 
            this.pnlSendSMS.BackColor = System.Drawing.Color.White;
            this.pnlSendSMS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSendSMS.Controls.Add(this.btnSendSMS);
            this.pnlSendSMS.Controls.Add(this.lblEnterText);
            this.pnlSendSMS.Controls.Add(this.txtSMSBody);
            this.pnlSendSMS.Controls.Add(this.txtEnterNo);
            this.pnlSendSMS.Controls.Add(this.lblEnterNo);
            this.pnlSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSendSMS.Location = new System.Drawing.Point(20, 86);
            this.pnlSendSMS.Name = "pnlSendSMS";
            this.pnlSendSMS.Size = new System.Drawing.Size(351, 215);
            this.pnlSendSMS.TabIndex = 0;
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendSMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendSMS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSendSMS.FlatAppearance.BorderSize = 0;
            this.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSendSMS.ForeColor = System.Drawing.Color.White;
            this.btnSendSMS.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSendSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendSMS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSendSMS.Location = new System.Drawing.Point(255, 166);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(76, 30);
            this.btnSendSMS.TabIndex = 26;
            this.btnSendSMS.Text = "SEND";
            this.btnSendSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendSMS.UseVisualStyleBackColor = false;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // lblEnterText
            // 
            this.lblEnterText.AutoSize = true;
            this.lblEnterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblEnterText.Location = new System.Drawing.Point(17, 51);
            this.lblEnterText.Name = "lblEnterText";
            this.lblEnterText.Size = new System.Drawing.Size(90, 20);
            this.lblEnterText.TabIndex = 3;
            this.lblEnterText.Text = "Enter Text :";
            // 
            // txtSMSBody
            // 
            this.txtSMSBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSMSBody.Location = new System.Drawing.Point(140, 51);
            this.txtSMSBody.Multiline = true;
            this.txtSMSBody.Name = "txtSMSBody";
            this.txtSMSBody.Size = new System.Drawing.Size(191, 88);
            this.txtSMSBody.TabIndex = 25;
            // 
            // txtEnterNo
            // 
            this.txtEnterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnterNo.Location = new System.Drawing.Point(140, 10);
            this.txtEnterNo.Multiline = true;
            this.txtEnterNo.Name = "txtEnterNo";
            this.txtEnterNo.Size = new System.Drawing.Size(191, 22);
            this.txtEnterNo.TabIndex = 24;
            this.txtEnterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnterNo_KeyPress);
            // 
            // lblEnterNo
            // 
            this.lblEnterNo.AutoSize = true;
            this.lblEnterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblEnterNo.Location = new System.Drawing.Point(17, 15);
            this.lblEnterNo.Name = "lblEnterNo";
            this.lblEnterNo.Size = new System.Drawing.Size(116, 20);
            this.lblEnterNo.TabIndex = 0;
            this.lblEnterNo.Text = "Enter Number :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkTobeExpiry);
            this.groupBox1.Controls.Add(this.chkExpiry);
            this.groupBox1.Controls.Add(this.chkInvoiceMail);
            this.groupBox1.Controls.Add(this.chkFeesMail);
            this.groupBox1.Controls.Add(this.chkbxsndlectsmsstudent);
            this.groupBox1.Controls.Add(this.cmdUpdate);
            this.groupBox1.Controls.Add(this.chkFeesSMS);
            this.groupBox1.Controls.Add(this.chkSndOutstndngFees);
            this.groupBox1.Controls.Add(this.chkDailyReports);
            this.groupBox1.Controls.Add(this.chkFlwp);
            this.groupBox1.Controls.Add(this.chkbxSendDueNotification);
            this.groupBox1.Controls.Add(this.chkAnni);
            this.groupBox1.Controls.Add(this.chkBday);
            this.groupBox1.Controls.Add(this.chkReg);
            this.groupBox1.Controls.Add(this.chkbxLectureSMSToFaculty);
            this.groupBox1.Controls.Add(this.chkEnq);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkbxSignOUTSMS);
            this.groupBox1.Controls.Add(this.chkbxSignINSMS);
            this.groupBox1.Controls.Add(this.chkbxSendAbsentSMS);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 423);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkTobeExpiry
            // 
            this.chkTobeExpiry.AutoSize = true;
            this.chkTobeExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTobeExpiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkTobeExpiry.Location = new System.Drawing.Point(265, 310);
            this.chkTobeExpiry.Name = "chkTobeExpiry";
            this.chkTobeExpiry.Size = new System.Drawing.Size(197, 24);
            this.chkTobeExpiry.TabIndex = 22;
            this.chkTobeExpiry.Text = "Send To Be Expiry SMS";
            this.chkTobeExpiry.UseVisualStyleBackColor = true;
            // 
            // chkExpiry
            // 
            this.chkExpiry.AutoSize = true;
            this.chkExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExpiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkExpiry.Location = new System.Drawing.Point(6, 310);
            this.chkExpiry.Name = "chkExpiry";
            this.chkExpiry.Size = new System.Drawing.Size(151, 24);
            this.chkExpiry.TabIndex = 21;
            this.chkExpiry.Text = "Send Expiry SMS";
            this.chkExpiry.UseVisualStyleBackColor = true;
            // 
            // chkInvoiceMail
            // 
            this.chkInvoiceMail.AutoSize = true;
            this.chkInvoiceMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvoiceMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkInvoiceMail.Location = new System.Drawing.Point(265, 158);
            this.chkInvoiceMail.Name = "chkInvoiceMail";
            this.chkInvoiceMail.Size = new System.Drawing.Size(163, 24);
            this.chkInvoiceMail.TabIndex = 10;
            this.chkInvoiceMail.Text = "Send Invoice Email";
            this.chkInvoiceMail.UseVisualStyleBackColor = true;
            // 
            // chkFeesMail
            // 
            this.chkFeesMail.AutoSize = true;
            this.chkFeesMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFeesMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkFeesMail.Location = new System.Drawing.Point(5, 158);
            this.chkFeesMail.Name = "chkFeesMail";
            this.chkFeesMail.Size = new System.Drawing.Size(149, 24);
            this.chkFeesMail.TabIndex = 9;
            this.chkFeesMail.Text = "Send Fees Email";
            this.chkFeesMail.UseVisualStyleBackColor = true;
            // 
            // chkbxsndlectsmsstudent
            // 
            this.chkbxsndlectsmsstudent.AutoSize = true;
            this.chkbxsndlectsmsstudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxsndlectsmsstudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkbxsndlectsmsstudent.Location = new System.Drawing.Point(265, 269);
            this.chkbxsndlectsmsstudent.Name = "chkbxsndlectsmsstudent";
            this.chkbxsndlectsmsstudent.Size = new System.Drawing.Size(246, 24);
            this.chkbxsndlectsmsstudent.TabIndex = 16;
            this.chkbxsndlectsmsstudent.Text = "Send Lecture SMS To Student";
            this.chkbxsndlectsmsstudent.UseVisualStyleBackColor = true;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdUpdate.BackColor = System.Drawing.Color.White;
            this.cmdUpdate.Depth = 0;
            this.cmdUpdate.Location = new System.Drawing.Point(168, 369);
            this.cmdUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Primary = true;
            this.cmdUpdate.Size = new System.Drawing.Size(73, 33);
            this.cmdUpdate.TabIndex = 17;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = false;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // chkFeesSMS
            // 
            this.chkFeesSMS.AutoSize = true;
            this.chkFeesSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFeesSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkFeesSMS.Location = new System.Drawing.Point(6, 122);
            this.chkFeesSMS.Name = "chkFeesSMS";
            this.chkFeesSMS.Size = new System.Drawing.Size(145, 24);
            this.chkFeesSMS.TabIndex = 7;
            this.chkFeesSMS.Text = "Send Fees SMS";
            this.chkFeesSMS.UseVisualStyleBackColor = true;
            // 
            // chkSndOutstndngFees
            // 
            this.chkSndOutstndngFees.AutoSize = true;
            this.chkSndOutstndngFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSndOutstndngFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSndOutstndngFees.Location = new System.Drawing.Point(265, 122);
            this.chkSndOutstndngFees.Name = "chkSndOutstndngFees";
            this.chkSndOutstndngFees.Size = new System.Drawing.Size(236, 24);
            this.chkSndOutstndngFees.TabIndex = 8;
            this.chkSndOutstndngFees.Text = "Send Outstanding Fees SMS";
            this.chkSndOutstndngFees.UseVisualStyleBackColor = true;
            // 
            // chkDailyReports
            // 
            this.chkDailyReports.AutoSize = true;
            this.chkDailyReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDailyReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkDailyReports.Location = new System.Drawing.Point(265, 85);
            this.chkDailyReports.Name = "chkDailyReports";
            this.chkDailyReports.Size = new System.Drawing.Size(204, 24);
            this.chkDailyReports.TabIndex = 6;
            this.chkDailyReports.Text = "Send Daily Reports SMS";
            this.chkDailyReports.UseVisualStyleBackColor = true;
            // 
            // chkFlwp
            // 
            this.chkFlwp.AutoSize = true;
            this.chkFlwp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlwp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkFlwp.Location = new System.Drawing.Point(6, 85);
            this.chkFlwp.Name = "chkFlwp";
            this.chkFlwp.Size = new System.Drawing.Size(183, 24);
            this.chkFlwp.TabIndex = 5;
            this.chkFlwp.Text = "Auto Send Followups ";
            this.chkFlwp.UseVisualStyleBackColor = true;
            // 
            // chkbxSendDueNotification
            // 
            this.chkbxSendDueNotification.AutoSize = true;
            this.chkbxSendDueNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxSendDueNotification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkbxSendDueNotification.Location = new System.Drawing.Point(6, 230);
            this.chkbxSendDueNotification.Name = "chkbxSendDueNotification";
            this.chkbxSendDueNotification.Size = new System.Drawing.Size(183, 24);
            this.chkbxSendDueNotification.TabIndex = 13;
            this.chkbxSendDueNotification.Text = "Send Due Notification";
            this.chkbxSendDueNotification.UseVisualStyleBackColor = true;
            // 
            // chkAnni
            // 
            this.chkAnni.AutoSize = true;
            this.chkAnni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkAnni.Location = new System.Drawing.Point(265, 50);
            this.chkAnni.Name = "chkAnni";
            this.chkAnni.Size = new System.Drawing.Size(220, 24);
            this.chkAnni.TabIndex = 4;
            this.chkAnni.Text = "Auto Send Aniversary SMS";
            this.chkAnni.UseVisualStyleBackColor = true;
            // 
            // chkBday
            // 
            this.chkBday.AutoSize = true;
            this.chkBday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkBday.Location = new System.Drawing.Point(5, 50);
            this.chkBday.Name = "chkBday";
            this.chkBday.Size = new System.Drawing.Size(205, 24);
            this.chkBday.TabIndex = 3;
            this.chkBday.Text = "Auto Send Birthday SMS";
            this.chkBday.UseVisualStyleBackColor = true;
            // 
            // chkReg
            // 
            this.chkReg.AutoSize = true;
            this.chkReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkReg.Location = new System.Drawing.Point(265, 16);
            this.chkReg.Name = "chkReg";
            this.chkReg.Size = new System.Drawing.Size(195, 24);
            this.chkReg.TabIndex = 2;
            this.chkReg.Text = "Send Registration SMS";
            this.chkReg.UseVisualStyleBackColor = true;
            // 
            // chkbxLectureSMSToFaculty
            // 
            this.chkbxLectureSMSToFaculty.AutoSize = true;
            this.chkbxLectureSMSToFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxLectureSMSToFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkbxLectureSMSToFaculty.Location = new System.Drawing.Point(265, 230);
            this.chkbxLectureSMSToFaculty.Name = "chkbxLectureSMSToFaculty";
            this.chkbxLectureSMSToFaculty.Size = new System.Drawing.Size(240, 24);
            this.chkbxLectureSMSToFaculty.TabIndex = 14;
            this.chkbxLectureSMSToFaculty.Text = "Send Lecture SMS To Faculty";
            this.chkbxLectureSMSToFaculty.UseVisualStyleBackColor = true;
            // 
            // chkEnq
            // 
            this.chkEnq.AutoSize = true;
            this.chkEnq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkEnq.Location = new System.Drawing.Point(6, 16);
            this.chkEnq.Name = "chkEnq";
            this.chkEnq.Size = new System.Drawing.Size(158, 24);
            this.chkEnq.TabIndex = 1;
            this.chkEnq.Text = "Sent Enquiry SMS";
            this.chkEnq.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(140, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(487, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 20;
            // 
            // chkbxSignOUTSMS
            // 
            this.chkbxSignOUTSMS.AutoSize = true;
            this.chkbxSignOUTSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxSignOUTSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkbxSignOUTSMS.Location = new System.Drawing.Point(265, 192);
            this.chkbxSignOUTSMS.Name = "chkbxSignOUTSMS";
            this.chkbxSignOUTSMS.Size = new System.Drawing.Size(178, 24);
            this.chkbxSignOUTSMS.TabIndex = 12;
            this.chkbxSignOUTSMS.Text = "Send Sign OUT SMS";
            this.chkbxSignOUTSMS.UseVisualStyleBackColor = true;
            // 
            // chkbxSignINSMS
            // 
            this.chkbxSignINSMS.AutoSize = true;
            this.chkbxSignINSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxSignINSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkbxSignINSMS.Location = new System.Drawing.Point(5, 192);
            this.chkbxSignINSMS.Name = "chkbxSignINSMS";
            this.chkbxSignINSMS.Size = new System.Drawing.Size(161, 24);
            this.chkbxSignINSMS.TabIndex = 11;
            this.chkbxSignINSMS.Text = "Send Sign IN SMS";
            this.chkbxSignINSMS.UseVisualStyleBackColor = true;
            // 
            // chkbxSendAbsentSMS
            // 
            this.chkbxSendAbsentSMS.AutoSize = true;
            this.chkbxSendAbsentSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxSendAbsentSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkbxSendAbsentSMS.Location = new System.Drawing.Point(6, 269);
            this.chkbxSendAbsentSMS.Name = "chkbxSendAbsentSMS";
            this.chkbxSendAbsentSMS.Size = new System.Drawing.Size(160, 24);
            this.chkbxSendAbsentSMS.TabIndex = 15;
            this.chkbxSendAbsentSMS.Text = "Send Absent SMS";
            this.chkbxSendAbsentSMS.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(936, 748);
            this.Controls.Add(this.cmdSyncData);
            this.Controls.Add(this.lblCon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpSampleSMS);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpSampleSMS.ResumeLayout(false);
            this.grpSampleSMS.PerformLayout();
            this.pnlSendEmail.ResumeLayout(false);
            this.pnlSendEmail.PerformLayout();
            this.pnlSendSMS.ResumeLayout(false);
            this.pnlSendSMS.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkBday;
        private System.Windows.Forms.CheckBox chkReg;
        private System.Windows.Forms.CheckBox chkEnq;
        private System.Windows.Forms.CheckBox chkFlwp;
        private System.Windows.Forms.CheckBox chkAnni;
        private System.Windows.Forms.GroupBox grpSampleSMS;
        private System.Windows.Forms.Label lblSampleSMS;
        private System.Windows.Forms.Panel pnlSendSMS;
        private System.Windows.Forms.Label lblEnterText;
        private System.Windows.Forms.TextBox txtSMSBody;
        private System.Windows.Forms.TextBox txtEnterNo;
        private System.Windows.Forms.Label lblEnterNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSendEmail;
        private System.Windows.Forms.Label lblEmailText;
        private System.Windows.Forms.TextBox txtMailBody;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEnterEmail;
        private System.Windows.Forms.CheckBox chkSndOutstndngFees;
        private System.Windows.Forms.CheckBox chkDailyReports;
        private System.Windows.Forms.CheckBox chkFeesSMS;
        private System.Windows.Forms.CheckBox chkbxLectureSMSToFaculty;
        private System.Windows.Forms.CheckBox chkbxSignOUTSMS;
        private System.Windows.Forms.CheckBox chkbxSignINSMS;
        private System.Windows.Forms.CheckBox chkbxSendAbsentSMS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAutomatic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCon;
        private System.Windows.Forms.CheckBox chkbxSendDueNotification;
        private MaterialSkin.Controls.MaterialRaisedButton cmdUpdate;
        private MaterialSkin.Controls.MaterialRaisedButton btnAttendanceUpdate;
        private MaterialSkin.Controls.MaterialRaisedButton btnOpenDeviceMgr;
        private MaterialSkin.Controls.MaterialRaisedButton cmdSyncData;
        private System.Windows.Forms.CheckBox chkbxsndlectsmsstudent;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.CheckBox chkInvoiceMail;
        private System.Windows.Forms.CheckBox chkFeesMail;
        private System.Windows.Forms.CheckBox chkTobeExpiry;
        private System.Windows.Forms.CheckBox chkExpiry;
    }
}
