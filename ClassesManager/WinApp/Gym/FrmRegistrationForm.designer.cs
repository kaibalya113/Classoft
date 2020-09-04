namespace ClassManager.WinApp.Gym
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
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.lblsrc = new System.Windows.Forms.Label();
            this.txtHeathIssue = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblhIssue = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtGSTno = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmdPDReset = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.txtHeight = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblHeight = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.txtBMI = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtWght = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMembershipNo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBrwseImg = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtMemberShipNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtRemark = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBldGrp = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
            this.panel7.Controls.Add(this.cmbSource);
            this.panel7.Controls.Add(this.lblsrc);
            this.panel7.Controls.Add(this.txtHeathIssue);
            this.panel7.Controls.Add(this.lblhIssue);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.txtGSTno);
            this.panel7.Controls.Add(this.cmdPDReset);
            this.panel7.Controls.Add(this.cmdNext);
            this.panel7.Controls.Add(this.txtHeight);
            this.panel7.Controls.Add(this.lblHeight);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.txtBMI);
            this.panel7.Controls.Add(this.txtWght);
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.lblMembershipNo);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.cmdBrwseImg);
            this.panel7.Controls.Add(this.txtMemberShipNo);
            this.panel7.Controls.Add(this.txtRemark);
            this.panel7.Controls.Add(this.txtBldGrp);
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
            this.panel7.Location = new System.Drawing.Point(13, 181);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(858, 462);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // cmbSource
            // 
            this.cmbSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Items.AddRange(new object[] {
            "Friends",
            "Family Member ",
            "Banner",
            "Pamplet",
            "TV Ad\'s",
            "Walkin",
            "Just Dial",
            "Google Business",
            "Facebook",
            "NewsPaper Ad\'s"});
            this.cmbSource.Location = new System.Drawing.Point(609, 303);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(190, 24);
            this.cmbSource.TabIndex = 422;
            // 
            // lblsrc
            // 
            this.lblsrc.AutoSize = true;
            this.lblsrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsrc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblsrc.Location = new System.Drawing.Point(485, 311);
            this.lblsrc.Name = "lblsrc";
            this.lblsrc.Size = new System.Drawing.Size(54, 16);
            this.lblsrc.TabIndex = 423;
            this.lblsrc.Text = "Source:";
            // 
            // txtHeathIssue
            // 
            this.txtHeathIssue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeathIssue.Depth = 0;
            this.txtHeathIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeathIssue.Hint = "Health Issue";
            this.txtHeathIssue.Location = new System.Drawing.Point(292, 330);
            this.txtHeathIssue.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtHeathIssue.Name = "txtHeathIssue";
            this.txtHeathIssue.PasswordChar = '\0';
            this.txtHeathIssue.SelectedText = "";
            this.txtHeathIssue.SelectionLength = 0;
            this.txtHeathIssue.SelectionStart = 0;
            this.txtHeathIssue.Size = new System.Drawing.Size(171, 23);
            this.txtHeathIssue.TabIndex = 11;
            this.txtHeathIssue.TabStop = false;
            this.txtHeathIssue.UseSystemPasswordChar = false;
            // 
            // lblhIssue
            // 
            this.lblhIssue.AutoSize = true;
            this.lblhIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblhIssue.Location = new System.Drawing.Point(161, 337);
            this.lblhIssue.Name = "lblhIssue";
            this.lblhIssue.Size = new System.Drawing.Size(95, 16);
            this.lblhIssue.TabIndex = 421;
            this.lblhIssue.Text = "Health Issues :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(160, 376);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 16);
            this.label15.TabIndex = 420;
            this.label15.Text = "GST No. :";
            // 
            // txtGSTno
            // 
            this.txtGSTno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGSTno.Depth = 0;
            this.txtGSTno.Hint = "Enter GST No.";
            this.txtGSTno.Location = new System.Drawing.Point(292, 369);
            this.txtGSTno.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtGSTno.Name = "txtGSTno";
            this.txtGSTno.PasswordChar = '\0';
            this.txtGSTno.SelectedText = "";
            this.txtGSTno.SelectionLength = 0;
            this.txtGSTno.SelectionStart = 0;
            this.txtGSTno.Size = new System.Drawing.Size(171, 23);
            this.txtGSTno.TabIndex = 12;
            this.txtGSTno.TabStop = false;
            this.txtGSTno.UseSystemPasswordChar = false;
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
            this.cmdPDReset.Location = new System.Drawing.Point(767, 419);
            this.cmdPDReset.Name = "cmdPDReset";
            this.cmdPDReset.Size = new System.Drawing.Size(86, 33);
            this.cmdPDReset.TabIndex = 21;
            this.cmdPDReset.Text = "RESET";
            this.cmdPDReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPDReset.UseVisualStyleBackColor = false;
            this.cmdPDReset.Click += new System.EventHandler(this.cmdPDReset_Click);
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
            this.cmdNext.Location = new System.Drawing.Point(654, 419);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(95, 33);
            this.cmdNext.TabIndex = 20;
            this.cmdNext.Text = "REGISTER";
            this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNext.UseVisualStyleBackColor = false;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Depth = 0;
            this.txtHeight.Hint = " Enter Height";
            this.txtHeight.Location = new System.Drawing.Point(292, 251);
            this.txtHeight.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.PasswordChar = '\0';
            this.txtHeight.SelectedText = "";
            this.txtHeight.SelectionLength = 0;
            this.txtHeight.SelectionStart = 0;
            this.txtHeight.Size = new System.Drawing.Size(171, 23);
            this.txtHeight.TabIndex = 10;
            this.txtHeight.TabStop = false;
            this.txtHeight.UseSystemPasswordChar = false;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblHeight.Location = new System.Drawing.Point(161, 251);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(115, 16);
            this.lblHeight.TabIndex = 100;
            this.lblHeight.Text = "Height (in meters):";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbMale);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.rbFemale);
            this.panel2.Location = new System.Drawing.Point(482, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 33);
            this.panel2.TabIndex = 99;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbMale.Location = new System.Drawing.Point(87, 3);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(56, 20);
            this.rbMale.TabIndex = 6;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(22, 5);
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
            this.rbFemale.Location = new System.Drawing.Point(149, 3);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(72, 20);
            this.rbFemale.TabIndex = 8;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // txtBMI
            // 
            this.txtBMI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBMI.Depth = 0;
            this.txtBMI.Enabled = false;
            this.txtBMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBMI.Hint = "BMI";
            this.txtBMI.Location = new System.Drawing.Point(292, 292);
            this.txtBMI.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBMI.Name = "txtBMI";
            this.txtBMI.PasswordChar = '\0';
            this.txtBMI.SelectedText = "";
            this.txtBMI.SelectionLength = 0;
            this.txtBMI.SelectionStart = 0;
            this.txtBMI.Size = new System.Drawing.Size(171, 23);
            this.txtBMI.TabIndex = 10;
            this.txtBMI.TabStop = false;
            this.txtBMI.UseSystemPasswordChar = false;
            // 
            // txtWght
            // 
            this.txtWght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWght.Depth = 0;
            this.txtWght.Hint = " Enter Weight";
            this.txtWght.Location = new System.Drawing.Point(292, 211);
            this.txtWght.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtWght.Name = "txtWght";
            this.txtWght.PasswordChar = '\0';
            this.txtWght.SelectedText = "";
            this.txtWght.SelectionLength = 0;
            this.txtWght.SelectionStart = 0;
            this.txtWght.Size = new System.Drawing.Size(171, 23);
            this.txtWght.TabIndex = 9;
            this.txtWght.TabStop = false;
            this.txtWght.UseSystemPasswordChar = false;
            this.txtWght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWght_KeyPress);
            this.txtWght.TextChanged += new System.EventHandler(this.txtWght_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(161, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 16);
            this.label14.TabIndex = 96;
            this.label14.Text = "Weight (in kg) :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(161, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 16);
            this.label10.TabIndex = 95;
            this.label10.Text = "BMI :";
            // 
            // lblMembershipNo
            // 
            this.lblMembershipNo.AutoSize = true;
            this.lblMembershipNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembershipNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblMembershipNo.Location = new System.Drawing.Point(485, 352);
            this.lblMembershipNo.Name = "lblMembershipNo";
            this.lblMembershipNo.Size = new System.Drawing.Size(113, 16);
            this.lblMembershipNo.TabIndex = 94;
            this.lblMembershipNo.Text = "Membership No. :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(485, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 93;
            this.label7.Text = "Remark :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(485, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 92;
            this.label6.Text = "Biometric Id :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(485, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 91;
            this.label3.Text = "BloodGroup :";
            // 
            // cmdBrwseImg
            // 
            this.cmdBrwseImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrwseImg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdBrwseImg.Depth = 0;
            this.cmdBrwseImg.Location = new System.Drawing.Point(24, 127);
            this.cmdBrwseImg.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdBrwseImg.Name = "cmdBrwseImg";
            this.cmdBrwseImg.Primary = true;
            this.cmdBrwseImg.Size = new System.Drawing.Size(75, 33);
            this.cmdBrwseImg.TabIndex = 18;
            this.cmdBrwseImg.TabStop = false;
            this.cmdBrwseImg.Text = "Browse";
            this.cmdBrwseImg.UseVisualStyleBackColor = true;
            this.cmdBrwseImg.Click += new System.EventHandler(this.cmdBrwseImg_Click);
            // 
            // txtMemberShipNo
            // 
            this.txtMemberShipNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemberShipNo.Depth = 0;
            this.txtMemberShipNo.Hint = "MemberShip No";
            this.txtMemberShipNo.Location = new System.Drawing.Point(618, 352);
            this.txtMemberShipNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMemberShipNo.Name = "txtMemberShipNo";
            this.txtMemberShipNo.PasswordChar = '\0';
            this.txtMemberShipNo.SelectedText = "";
            this.txtMemberShipNo.SelectionLength = 0;
            this.txtMemberShipNo.SelectionStart = 0;
            this.txtMemberShipNo.Size = new System.Drawing.Size(196, 23);
            this.txtMemberShipNo.TabIndex = 15;
            this.txtMemberShipNo.TabStop = false;
            this.txtMemberShipNo.UseSystemPasswordChar = false;
            this.txtMemberShipNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberShipNo_KeyPress);
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Depth = 0;
            this.txtRemark.Hint = "Remark";
            this.txtRemark.Location = new System.Drawing.Point(618, 383);
            this.txtRemark.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PasswordChar = '\0';
            this.txtRemark.SelectedText = "";
            this.txtRemark.SelectionLength = 0;
            this.txtRemark.SelectionStart = 0;
            this.txtRemark.Size = new System.Drawing.Size(195, 23);
            this.txtRemark.TabIndex = 16;
            this.txtRemark.TabStop = false;
            this.txtRemark.UseSystemPasswordChar = false;
            // 
            // txtBldGrp
            // 
            this.txtBldGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBldGrp.Depth = 0;
            this.txtBldGrp.Hint = "Blood Group";
            this.txtBldGrp.Location = new System.Drawing.Point(609, 213);
            this.txtBldGrp.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBldGrp.Name = "txtBldGrp";
            this.txtBldGrp.PasswordChar = '\0';
            this.txtBldGrp.SelectedText = "";
            this.txtBldGrp.SelectionLength = 0;
            this.txtBldGrp.SelectionStart = 0;
            this.txtBldGrp.Size = new System.Drawing.Size(199, 23);
            this.txtBldGrp.TabIndex = 13;
            this.txtBldGrp.TabStop = false;
            this.txtBldGrp.UseSystemPasswordChar = false;
            this.txtBldGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBldGrp_KeyPress);
            // 
            // txtBiometricId
            // 
            this.txtBiometricId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBiometricId.Depth = 0;
            this.txtBiometricId.Hint = "Biometric Id";
            this.txtBiometricId.Location = new System.Drawing.Point(610, 256);
            this.txtBiometricId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBiometricId.Name = "txtBiometricId";
            this.txtBiometricId.PasswordChar = '\0';
            this.txtBiometricId.SelectedText = "";
            this.txtBiometricId.SelectionLength = 0;
            this.txtBiometricId.SelectionStart = 0;
            this.txtBiometricId.Size = new System.Drawing.Size(198, 23);
            this.txtBiometricId.TabIndex = 14;
            this.txtBiometricId.TabStop = false;
            this.txtBiometricId.UseSystemPasswordChar = false;
            this.txtBiometricId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBiometricId_KeyPress);
            // 
            // txtSContact
            // 
            this.txtSContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSContact.Depth = 0;
            this.txtSContact.Hint = "Contact No";
            this.txtSContact.Location = new System.Drawing.Point(488, 83);
            this.txtSContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSContact.Name = "txtSContact";
            this.txtSContact.PasswordChar = '\0';
            this.txtSContact.SelectedText = "";
            this.txtSContact.SelectionLength = 0;
            this.txtSContact.SelectionStart = 0;
            this.txtSContact.Size = new System.Drawing.Size(261, 23);
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
            this.txtEmailID.Location = new System.Drawing.Point(164, 122);
            this.txtEmailID.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.PasswordChar = '\0';
            this.txtEmailID.SelectedText = "";
            this.txtEmailID.SelectionLength = 0;
            this.txtEmailID.SelectionStart = 0;
            this.txtEmailID.Size = new System.Drawing.Size(261, 23);
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
            this.txtLName.Location = new System.Drawing.Point(164, 83);
            this.txtLName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLName.Name = "txtLName";
            this.txtLName.PasswordChar = '\0';
            this.txtLName.SelectedText = "";
            this.txtLName.SelectionLength = 0;
            this.txtLName.SelectionStart = 0;
            this.txtLName.Size = new System.Drawing.Size(261, 23);
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
            this.txtMName.Location = new System.Drawing.Point(164, 45);
            this.txtMName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtMName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMName.Name = "txtMName";
            this.txtMName.PasswordChar = '\0';
            this.txtMName.SelectedText = "";
            this.txtMName.SelectionLength = 0;
            this.txtMName.SelectionStart = 0;
            this.txtMName.Size = new System.Drawing.Size(261, 23);
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
            this.txtFName.Location = new System.Drawing.Point(164, 7);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(261, 23);
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
            this.lnkVerify.Location = new System.Drawing.Point(786, 80);
            this.lnkVerify.Name = "lnkVerify";
            this.lnkVerify.Size = new System.Drawing.Size(42, 16);
            this.lnkVerify.TabIndex = 11;
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
            this.cmbBatch.Location = new System.Drawing.Point(116, 433);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(190, 24);
            this.cmbBatch.TabIndex = 16;
            this.cmbBatch.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(24, 436);
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
            this.dtpAdmissionDate.Location = new System.Drawing.Point(609, 165);
            this.dtpAdmissionDate.Name = "dtpAdmissionDate";
            this.dtpAdmissionDate.Size = new System.Drawing.Size(157, 22);
            this.dtpAdmissionDate.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label19.Location = new System.Drawing.Point(485, 167);
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
            this.label28.Location = new System.Drawing.Point(765, 83);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 20);
            this.label28.TabIndex = 46;
            this.label28.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(431, 9);
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
            this.lnkCapture.Location = new System.Drawing.Point(13, 171);
            this.lnkCapture.Name = "lnkCapture";
            this.lnkCapture.Size = new System.Drawing.Size(96, 16);
            this.lnkCapture.TabIndex = 19;
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
            this.lnkClear.Location = new System.Drawing.Point(18, 197);
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
            this.label9.Location = new System.Drawing.Point(479, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Address :";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(550, 13);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(199, 51);
            this.txtAddress.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(160, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Date of Birth :";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(252, 167);
            this.dtpDOB.MaxDate = new System.DateTime(2109, 12, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(157, 22);
            this.dtpDOB.TabIndex = 7;
            this.dtpDOB.Value = new System.DateTime(2016, 9, 22, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(13, 68);
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
            this.label5.Location = new System.Drawing.Point(13, 156);
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
            this.panel1.Location = new System.Drawing.Point(11, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 53);
            this.panel1.TabIndex = 26;
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
            this.btnSearch.Location = new System.Drawing.Point(736, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 33);
            this.btnSearch.TabIndex = 412;
            this.btnSearch.Text = "SEARCH   ";
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
            this.txtEnquiryNo.Size = new System.Drawing.Size(262, 23);
            this.txtEnquiryNo.TabIndex = 2;
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
            this.cmbStudName.TabIndex = 1;
            this.cmbStudName.SelectedIndexChanged += new System.EventHandler(this.cmbStudName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(380, 15);
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
            this.ClientSize = new System.Drawing.Size(886, 656);
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
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBldGrp;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBiometricId;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSContact;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmailID;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMName;
        private MaterialSkin.Controls.MaterialRaisedButton cmdBrwseImg;

        private System.Windows.Forms.Label lblMembershipNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBMI;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtWght;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPDReset;
        private System.Windows.Forms.Label label15;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtGSTno;
        private System.Windows.Forms.Label lblhIssue;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtHeathIssue;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label lblsrc;
    }
}