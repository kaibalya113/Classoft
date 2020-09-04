namespace ClassManager.WinApp.Asset
{
    partial class FrmRegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrationForm));
            this.ofdImg = new System.Windows.Forms.OpenFileDialog();
            this.bgwRegistrationSMS = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbRefBy = new System.Windows.Forms.ComboBox();
            this.batchCmb = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbsunday = new System.Windows.Forms.RadioButton();
            this.rbTTS = new System.Windows.Forms.RadioButton();
            this.rbMWF = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFFname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbQualification = new System.Windows.Forms.ComboBox();
            this.txtFContact = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmdPDReset = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.cmdNext = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.cmdBrwseImg = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnViewAllStudent = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtMemberShipNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtRemark = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtAdhrCard = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBiometricId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSContact = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtEmailID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtLName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lnkVerify = new System.Windows.Forms.LinkLabel();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpAdmissionDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lnkCapture = new System.Windows.Forms.LinkLabel();
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtEnquiryNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmbStudName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdImg
            // 
            this.ofdImg.FileName = "ofdImg";
            // 
            // bgwRegistrationSMS
            // 
            this.bgwRegistrationSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistrationSMS_DoWork);
            this.bgwRegistrationSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistrationSMS_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.cmbRefBy);
            this.panel7.Controls.Add(this.batchCmb);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.cmbField);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.cmbCategory);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.txtFFname);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.cmbQualification);
            this.panel7.Controls.Add(this.txtFContact);
            this.panel7.Controls.Add(this.cmdPDReset);
            this.panel7.Controls.Add(this.label33);
            this.panel7.Controls.Add(this.cmdNext);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.cmdBrwseImg);
            this.panel7.Controls.Add(this.btnViewAllStudent);
            this.panel7.Controls.Add(this.txtMemberShipNo);
            this.panel7.Controls.Add(this.txtRemark);
            this.panel7.Controls.Add(this.txtAdhrCard);
            this.panel7.Controls.Add(this.txtBiometricId);
            this.panel7.Controls.Add(this.txtSContact);
            this.panel7.Controls.Add(this.txtEmailID);
            this.panel7.Controls.Add(this.txtLName);
            this.panel7.Controls.Add(this.txtMName);
            this.panel7.Controls.Add(this.txtFName);
            this.panel7.Controls.Add(this.lnkVerify);
            this.panel7.Controls.Add(this.cmbBatch);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.dtpAdmissionDate);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.label28);
            this.panel7.Controls.Add(this.label25);
            this.panel7.Controls.Add(this.lnkCapture);
            this.panel7.Controls.Add(this.lnkClear);
            this.panel7.Controls.Add(this.pbPhoto);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.txtAddress);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.dtpDOB);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Location = new System.Drawing.Point(12, 179);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(846, 474);
            this.panel7.TabIndex = 1;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // cmbRefBy
            // 
            this.cmbRefBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbRefBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRefBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbRefBy.FormattingEnabled = true;
            this.cmbRefBy.Items.AddRange(new object[] {
            "Approached By Classes",
            "Friends",
            "Family Member ",
            "Banner",
            "Pamplet",
            "TV Ad\'s",
            "Walkin"});
            this.cmbRefBy.Location = new System.Drawing.Point(234, 265);
            this.cmbRefBy.Name = "cmbRefBy";
            this.cmbRefBy.Size = new System.Drawing.Size(202, 24);
            this.cmbRefBy.TabIndex = 13;
            this.cmbRefBy.Tag = "";
            // 
            // batchCmb
            // 
            this.batchCmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.batchCmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.batchCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batchCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.batchCmb.FormattingEnabled = true;
            this.batchCmb.Items.AddRange(new object[] {
            "MWF",
            "TTS",
            "Regular Batch",
            "Sunday Special"});
            this.batchCmb.Location = new System.Drawing.Point(234, 306);
            this.batchCmb.Name = "batchCmb";
            this.batchCmb.Size = new System.Drawing.Size(202, 24);
            this.batchCmb.TabIndex = 15;
            this.batchCmb.Tag = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbsunday);
            this.panel3.Controls.Add(this.rbTTS);
            this.panel3.Controls.Add(this.rbMWF);
            this.panel3.Location = new System.Drawing.Point(126, 412);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 38);
            this.panel3.TabIndex = 433;
            this.panel3.Visible = false;
            // 
            // rbsunday
            // 
            this.rbsunday.AutoSize = true;
            this.rbsunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbsunday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbsunday.Location = new System.Drawing.Point(183, 7);
            this.rbsunday.Name = "rbsunday";
            this.rbsunday.Size = new System.Drawing.Size(121, 20);
            this.rbsunday.TabIndex = 425;
            this.rbsunday.Text = "Sunday Special";
            this.rbsunday.UseVisualStyleBackColor = true;
            // 
            // rbTTS
            // 
            this.rbTTS.AutoSize = true;
            this.rbTTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTTS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbTTS.Location = new System.Drawing.Point(125, 7);
            this.rbTTS.Name = "rbTTS";
            this.rbTTS.Size = new System.Drawing.Size(53, 20);
            this.rbTTS.TabIndex = 423;
            this.rbTTS.Text = "TTS";
            this.rbTTS.UseVisualStyleBackColor = true;
            // 
            // rbMWF
            // 
            this.rbMWF.AutoSize = true;
            this.rbMWF.Checked = true;
            this.rbMWF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMWF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbMWF.Location = new System.Drawing.Point(61, 7);
            this.rbMWF.Name = "rbMWF";
            this.rbMWF.Size = new System.Drawing.Size(58, 20);
            this.rbMWF.TabIndex = 422;
            this.rbMWF.TabStop = true;
            this.rbMWF.Text = "MWF";
            this.rbMWF.UseVisualStyleBackColor = true;
            this.rbMWF.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(153, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 432;
            this.label10.Text = "Counselor :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(172, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 424;
            this.label6.Text = "Batch :";
            // 
            // cmbField
            // 
            this.cmbField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(234, 346);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(202, 24);
            this.cmbField.TabIndex = 17;
            this.cmbField.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(523, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 429;
            this.label8.Text = "Category :";
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "School Student",
            "College Student",
            "Post Graduate Student",
            "Govt.Employee",
            "Housewife",
            "Others"});
            this.cmbCategory.Location = new System.Drawing.Point(606, 309);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(219, 24);
            this.cmbCategory.TabIndex = 16;
            this.cmbCategory.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(133, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 427;
            this.label7.Text = "Reference by :";
            // 
            // txtFFname
            // 
            this.txtFFname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFFname.Depth = 0;
            this.txtFFname.Hint = "Parents Name";
            this.txtFFname.Location = new System.Drawing.Point(5, 426);
            this.txtFFname.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFFname.Name = "txtFFname";
            this.txtFFname.PasswordChar = '\0';
            this.txtFFname.SelectedText = "";
            this.txtFFname.SelectionLength = 0;
            this.txtFFname.SelectionStart = 0;
            this.txtFFname.Size = new System.Drawing.Size(288, 23);
            this.txtFFname.TabIndex = 0;
            this.txtFFname.TabStop = false;
            this.txtFFname.UseSystemPasswordChar = false;
            this.txtFFname.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(133, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 421;
            this.label3.Text = "Qualification :";
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
            this.cmbQualification.Location = new System.Drawing.Point(234, 224);
            this.cmbQualification.Name = "cmbQualification";
            this.cmbQualification.Size = new System.Drawing.Size(202, 24);
            this.cmbQualification.TabIndex = 11;
            this.cmbQualification.Tag = "";
            // 
            // txtFContact
            // 
            this.txtFContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFContact.Depth = 0;
            this.txtFContact.Hint = "Secondary Contact No";
            this.txtFContact.Location = new System.Drawing.Point(136, 136);
            this.txtFContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFContact.Name = "txtFContact";
            this.txtFContact.PasswordChar = '\0';
            this.txtFContact.SelectedText = "";
            this.txtFContact.SelectionLength = 0;
            this.txtFContact.SelectionStart = 0;
            this.txtFContact.Size = new System.Drawing.Size(216, 23);
            this.txtFContact.TabIndex = 6;
            this.txtFContact.TabStop = false;
            this.txtFContact.UseSystemPasswordChar = false;
            this.txtFContact.Click += new System.EventHandler(this.txtFContact_Click);
            this.txtFContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFContact_KeyPress);
            // 
            // cmdPDReset
            // 
            this.cmdPDReset.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cmdPDReset.FlatAppearance.BorderSize = 0;
            this.cmdPDReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPDReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPDReset.ForeColor = System.Drawing.Color.White;
            this.cmdPDReset.Image = global::ClassManager.Properties.Resources.refresh_arrows_symbol_of_interface;
            this.cmdPDReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPDReset.Location = new System.Drawing.Point(743, 412);
            this.cmdPDReset.Name = "cmdPDReset";
            this.cmdPDReset.Size = new System.Drawing.Size(86, 33);
            this.cmdPDReset.TabIndex = 419;
            this.cmdPDReset.Text = "RESET";
            this.cmdPDReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPDReset.UseVisualStyleBackColor = false;
            this.cmdPDReset.Click += new System.EventHandler(this.cmdPDReset_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Red;
            this.label33.Location = new System.Drawing.Point(353, 131);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(15, 20);
            this.label33.TabIndex = 47;
            this.label33.Text = "*";
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
            this.cmdNext.Location = new System.Drawing.Point(633, 412);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(95, 33);
            this.cmdNext.TabIndex = 18;
            this.cmdNext.Text = "REGISTER";
            this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNext.UseVisualStyleBackColor = false;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbMale);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.rbFemale);
            this.panel2.Location = new System.Drawing.Point(528, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 33);
            this.panel2.TabIndex = 91;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbMale.Location = new System.Drawing.Point(104, 6);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(56, 20);
            this.rbMale.TabIndex = 9;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(3, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Gender :";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbFemale.Location = new System.Drawing.Point(178, 6);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(72, 20);
            this.rbFemale.TabIndex = 10;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // cmdBrwseImg
            // 
            this.cmdBrwseImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrwseImg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdBrwseImg.Depth = 0;
            this.cmdBrwseImg.Location = new System.Drawing.Point(29, 126);
            this.cmdBrwseImg.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdBrwseImg.Name = "cmdBrwseImg";
            this.cmdBrwseImg.Primary = true;
            this.cmdBrwseImg.Size = new System.Drawing.Size(75, 33);
            this.cmdBrwseImg.TabIndex = 87;
            this.cmdBrwseImg.TabStop = false;
            this.cmdBrwseImg.Text = "Browse";
            this.cmdBrwseImg.UseVisualStyleBackColor = true;
            this.cmdBrwseImg.Click += new System.EventHandler(this.cmdBrwseImg_Click);
            // 
            // btnViewAllStudent
            // 
            this.btnViewAllStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAllStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewAllStudent.Depth = 0;
            this.btnViewAllStudent.Location = new System.Drawing.Point(487, 412);
            this.btnViewAllStudent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewAllStudent.Name = "btnViewAllStudent";
            this.btnViewAllStudent.Primary = true;
            this.btnViewAllStudent.Size = new System.Drawing.Size(127, 33);
            this.btnViewAllStudent.TabIndex = 15;
            this.btnViewAllStudent.TabStop = false;
            this.btnViewAllStudent.Text = "View Students";
            this.btnViewAllStudent.UseVisualStyleBackColor = true;
            this.btnViewAllStudent.Click += new System.EventHandler(this.btnViewAllStudent_Click);
            // 
            // txtMemberShipNo
            // 
            this.txtMemberShipNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemberShipNo.Depth = 0;
            this.txtMemberShipNo.Hint = "Qualification";
            this.txtMemberShipNo.Location = new System.Drawing.Point(108, 425);
            this.txtMemberShipNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMemberShipNo.Name = "txtMemberShipNo";
            this.txtMemberShipNo.PasswordChar = '\0';
            this.txtMemberShipNo.SelectedText = "";
            this.txtMemberShipNo.SelectionLength = 0;
            this.txtMemberShipNo.SelectionStart = 0;
            this.txtMemberShipNo.Size = new System.Drawing.Size(287, 23);
            this.txtMemberShipNo.TabIndex = 9;
            this.txtMemberShipNo.TabStop = false;
            this.txtMemberShipNo.UseSystemPasswordChar = false;
            this.txtMemberShipNo.Visible = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Depth = 0;
            this.txtRemark.Hint = "Remark";
            this.txtRemark.Location = new System.Drawing.Point(2, 425);
            this.txtRemark.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PasswordChar = '\0';
            this.txtRemark.SelectedText = "";
            this.txtRemark.SelectionLength = 0;
            this.txtRemark.SelectionStart = 0;
            this.txtRemark.Size = new System.Drawing.Size(254, 23);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.TabStop = false;
            this.txtRemark.UseSystemPasswordChar = false;
            this.txtRemark.Visible = false;
            // 
            // txtAdhrCard
            // 
            this.txtAdhrCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdhrCard.Depth = 0;
            this.txtAdhrCard.Hint = "Name Of School/College";
            this.txtAdhrCard.Location = new System.Drawing.Point(530, 224);
            this.txtAdhrCard.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAdhrCard.Name = "txtAdhrCard";
            this.txtAdhrCard.PasswordChar = '\0';
            this.txtAdhrCard.SelectedText = "";
            this.txtAdhrCard.SelectionLength = 0;
            this.txtAdhrCard.SelectionStart = 0;
            this.txtAdhrCard.Size = new System.Drawing.Size(300, 23);
            this.txtAdhrCard.TabIndex = 12;
            this.txtAdhrCard.TabStop = false;
            this.txtAdhrCard.UseSystemPasswordChar = false;
            this.txtAdhrCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdhrCard_KeyPress);
            // 
            // txtBiometricId
            // 
            this.txtBiometricId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBiometricId.Depth = 0;
            this.txtBiometricId.Hint = "Biometric Id";
            this.txtBiometricId.Location = new System.Drawing.Point(529, 265);
            this.txtBiometricId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBiometricId.Name = "txtBiometricId";
            this.txtBiometricId.PasswordChar = '\0';
            this.txtBiometricId.SelectedText = "";
            this.txtBiometricId.SelectionLength = 0;
            this.txtBiometricId.SelectionStart = 0;
            this.txtBiometricId.Size = new System.Drawing.Size(300, 23);
            this.txtBiometricId.TabIndex = 14;
            this.txtBiometricId.TabStop = false;
            this.txtBiometricId.UseSystemPasswordChar = false;
            this.txtBiometricId.Click += new System.EventHandler(this.txtBiometricId_Click);
            // 
            // txtSContact
            // 
            this.txtSContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSContact.Depth = 0;
            this.txtSContact.Hint = "Primary Contact No";
            this.txtSContact.Location = new System.Drawing.Point(137, 98);
            this.txtSContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSContact.Name = "txtSContact";
            this.txtSContact.PasswordChar = '\0';
            this.txtSContact.SelectedText = "";
            this.txtSContact.SelectionLength = 0;
            this.txtSContact.SelectionStart = 0;
            this.txtSContact.Size = new System.Drawing.Size(215, 23);
            this.txtSContact.TabIndex = 5;
            this.txtSContact.TabStop = false;
            this.txtSContact.UseSystemPasswordChar = false;
            this.txtSContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSContact_KeyPress);
            // 
            // txtEmailID
            // 
            this.txtEmailID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailID.Depth = 0;
            this.txtEmailID.Hint = "Email Address";
            this.txtEmailID.Location = new System.Drawing.Point(136, 54);
            this.txtEmailID.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.PasswordChar = '\0';
            this.txtEmailID.SelectedText = "";
            this.txtEmailID.SelectionLength = 0;
            this.txtEmailID.SelectionStart = 0;
            this.txtEmailID.Size = new System.Drawing.Size(305, 23);
            this.txtEmailID.TabIndex = 3;
            this.txtEmailID.TabStop = false;
            this.txtEmailID.UseSystemPasswordChar = false;
            // 
            // txtLName
            // 
            this.txtLName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLName.Depth = 0;
            this.txtLName.Hint = "Last Name";
            this.txtLName.Location = new System.Drawing.Point(606, 13);
            this.txtLName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLName.Name = "txtLName";
            this.txtLName.PasswordChar = '\0';
            this.txtLName.SelectedText = "";
            this.txtLName.SelectionLength = 0;
            this.txtLName.SelectionStart = 0;
            this.txtLName.Size = new System.Drawing.Size(220, 23);
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
            this.txtMName.Location = new System.Drawing.Point(378, 13);
            this.txtMName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtMName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMName.Name = "txtMName";
            this.txtMName.PasswordChar = '\0';
            this.txtMName.SelectedText = "";
            this.txtMName.SelectionLength = 0;
            this.txtMName.SelectionStart = 0;
            this.txtMName.Size = new System.Drawing.Size(211, 23);
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
            this.txtFName.Location = new System.Drawing.Point(137, 13);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(215, 23);
            this.txtFName.TabIndex = 0;
            this.txtFName.TabStop = false;
            this.txtFName.UseSystemPasswordChar = false;
            // 
            // lnkVerify
            // 
            this.lnkVerify.AutoSize = true;
            this.lnkVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkVerify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkVerify.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkVerify.Location = new System.Drawing.Point(375, 105);
            this.lnkVerify.Name = "lnkVerify";
            this.lnkVerify.Size = new System.Drawing.Size(42, 16);
            this.lnkVerify.TabIndex = 6;
            this.lnkVerify.TabStop = true;
            this.lnkVerify.Text = "Verify";
            this.lnkVerify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVerify_LinkClicked);
            // 
            // cmbBatch
            // 
            this.cmbBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(53, 425);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(195, 24);
            this.cmbBatch.TabIndex = 16;
            this.cmbBatch.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(6, 434);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 69;
            this.label13.Text = "Batch :";
            this.label13.Visible = false;
            // 
            // dtpAdmissionDate
            // 
            this.dtpAdmissionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAdmissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAdmissionDate.Location = new System.Drawing.Point(249, 187);
            this.dtpAdmissionDate.Name = "dtpAdmissionDate";
            this.dtpAdmissionDate.Size = new System.Drawing.Size(187, 22);
            this.dtpAdmissionDate.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label19.Location = new System.Drawing.Point(134, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 16);
            this.label19.TabIndex = 62;
            this.label19.Text = "Admission Date :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(353, 88);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 20);
            this.label28.TabIndex = 6;
            this.label28.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(353, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 20);
            this.label25.TabIndex = 44;
            this.label25.Text = "*";
            // 
            // lnkCapture
            // 
            this.lnkCapture.AutoSize = true;
            this.lnkCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCapture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkCapture.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkCapture.Location = new System.Drawing.Point(21, 162);
            this.lnkCapture.Name = "lnkCapture";
            this.lnkCapture.Size = new System.Drawing.Size(96, 16);
            this.lnkCapture.TabIndex = 43;
            this.lnkCapture.TabStop = true;
            this.lnkCapture.Text = "Capture image";
            this.lnkCapture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCapture_LinkClicked);
            // 
            // lnkClear
            // 
            this.lnkClear.AutoSize = true;
            this.lnkClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkClear.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkClear.Location = new System.Drawing.Point(26, 188);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(81, 16);
            this.lnkClear.TabIndex = 13;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "Clear Image";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // pbPhoto
            // 
            this.pbPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbPhoto.ErrorImage")));
            this.pbPhoto.Location = new System.Drawing.Point(12, 13);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(109, 108);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 1;
            this.pbPhoto.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(525, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Address :";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(596, 54);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(229, 67);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(525, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Date of Birth :";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(617, 143);
            this.dtpDOB.MaxDate = new System.DateTime(2109, 12, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(208, 22);
            this.dtpDOB.TabIndex = 7;
            this.dtpDOB.Value = new System.DateTime(2016, 9, 22, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Search Enquiry Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(14, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Personal Details ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtEnquiryNo);
            this.panel1.Controls.Add(this.cmbStudName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 53);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::ClassManager.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(726, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 33);
            this.btnSearch.TabIndex = 412;
            this.btnSearch.Text = "SEARCH  ";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEnquiryNo
            // 
            this.txtEnquiryNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnquiryNo.Depth = 0;
            this.txtEnquiryNo.Hint = "Enquiry No";
            this.txtEnquiryNo.Location = new System.Drawing.Point(445, 14);
            this.txtEnquiryNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEnquiryNo.Name = "txtEnquiryNo";
            this.txtEnquiryNo.PasswordChar = '\0';
            this.txtEnquiryNo.SelectedText = "";
            this.txtEnquiryNo.SelectionLength = 0;
            this.txtEnquiryNo.SelectionStart = 0;
            this.txtEnquiryNo.Size = new System.Drawing.Size(250, 23);
            this.txtEnquiryNo.TabIndex = 1;
            this.txtEnquiryNo.TabStop = false;
            this.txtEnquiryNo.UseSystemPasswordChar = false;
            // 
            // cmbStudName
            // 
            this.cmbStudName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStudName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStudName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudName.FormattingEnabled = true;
            this.cmbStudName.Location = new System.Drawing.Point(66, 12);
            this.cmbStudName.Name = "cmbStudName";
            this.cmbStudName.Size = new System.Drawing.Size(308, 24);
            this.cmbStudName.TabIndex = 0;
            this.cmbStudName.SelectedIndexChanged += new System.EventHandler(this.cmbStudName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(403, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name :";
            // 
            // FrmRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 662);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Form";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdImg;
        private System.ComponentModel.BackgroundWorker bgwRegistrationSMS;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        public System.Windows.Forms.DateTimePicker dtpAdmissionDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.LinkLabel lnkCapture;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.LinkLabel lnkClear;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbStudName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel lnkVerify;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEnquiryNo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMemberShipNo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRemark;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAdhrCard;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBiometricId;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSContact;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmailID;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFContact;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFFname;
        private MaterialSkin.Controls.MaterialRaisedButton cmdBrwseImg;
        private MaterialSkin.Controls.MaterialRaisedButton btnViewAllStudent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPDReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbQualification;
        private System.Windows.Forms.RadioButton rbMWF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbTTS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbsunday;
        private System.Windows.Forms.ComboBox cmbRefBy;
        private System.Windows.Forms.ComboBox batchCmb;
    }
}