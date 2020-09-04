namespace ClassManager.WinApp
{
    partial class FrmFeesPayment
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
            System.Windows.Forms.Label label12;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bwFeeMSG = new System.ComponentModel.BackgroundWorker();
            this.label24 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtAdmissinoNO = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlFeesDetails = new System.Windows.Forms.Panel();
            this.pnlFees = new System.Windows.Forms.Panel();
            this.lnlTotalFees = new System.Windows.Forms.LinkLabel();
            this.lnkUncleared = new System.Windows.Forms.LinkLabel();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cmbCoursePayment = new System.Windows.Forms.ComboBox();
            this.lnkMoreDetails = new System.Windows.Forms.LinkLabel();
            this.lblUncleared = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalOustanding = new System.Windows.Forms.Label();
            this.lblBatch = new System.Windows.Forms.Label();
            this.lblStandard = new System.Windows.Forms.Label();
            this.lblOFees = new System.Windows.Forms.Label();
            this.lblCleared = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblCrse = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTOFees = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPackageCost = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblDiscountGiven = new System.Windows.Forms.Label();
            this.lblFeesPaid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmbReceivedBy = new System.Windows.Forms.ComboBox();
            this.lblReceivedBy = new System.Windows.Forms.Label();
            this.lblNextDue = new System.Windows.Forms.Label();
            this.dtdueDate = new System.Windows.Forms.DateTimePicker();
            this.chkviewRcpt = new System.Windows.Forms.CheckBox();
            this.txtCashAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDiscount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtFine = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtChequeAmount = new System.Windows.Forms.Label();
            this.txtBankAmount = new System.Windows.Forms.Label();
            this.lnkBnkTrnfr = new System.Windows.Forms.LinkLabel();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtActualPaymentAmnt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lnkAddAccount = new System.Windows.Forms.LinkLabel();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtDiscountReason = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panCheque = new System.Windows.Forms.Panel();
            this.ADGVCheques = new ADGV.AdvancedDataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.lnkAddCheque = new System.Windows.Forms.LinkLabel();
            this.lblCashAmount = new System.Windows.Forms.Label();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtAFPaying = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStudName = new ClassManager.WinApp.UICommon.SuggestComboBox();
            label12 = new System.Windows.Forms.Label();
            this.pnlFeesDetails.SuspendLayout();
            this.pnlFees.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVCheques)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            label12.Location = new System.Drawing.Point(3, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(130, 18);
            label12.TabIndex = 88;
            label12.Text = "Payment Details";
            // 
            // bwFeeMSG
            // 
            this.bwFeeMSG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFeeMSG_DoWork);
            this.bwFeeMSG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFeeMSG_RunWorkerCompleted);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label24.Location = new System.Drawing.Point(31, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 18);
            this.label24.TabIndex = 10;
            this.label24.Text = "Name :";
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSearch.FlatAppearance.BorderSize = 0;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.ForeColor = System.Drawing.Color.White;
            this.cmdSearch.Image = global::ClassManager.Properties.Resources.search;
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(734, 72);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(113, 28);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "SEARCH  ";
            this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearch.UseVisualStyleBackColor = false;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtAdmissinoNO
            // 
            this.txtAdmissinoNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdmissinoNO.Depth = 0;
            this.txtAdmissinoNO.Hint = "Enter Admission No.";
            this.txtAdmissinoNO.Location = new System.Drawing.Point(534, 77);
            this.txtAdmissinoNO.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAdmissinoNO.Name = "txtAdmissinoNO";
            this.txtAdmissinoNO.PasswordChar = '\0';
            this.txtAdmissinoNO.SelectedText = "";
            this.txtAdmissinoNO.SelectionLength = 0;
            this.txtAdmissinoNO.SelectionStart = 0;
            this.txtAdmissinoNO.Size = new System.Drawing.Size(170, 23);
            this.txtAdmissinoNO.TabIndex = 2;
            this.txtAdmissinoNO.UseSystemPasswordChar = false;
            this.txtAdmissinoNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdmissinoNO_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(410, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Admission No :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(362, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "OR";
            // 
            // pnlFeesDetails
            // 
            this.pnlFeesDetails.BackColor = System.Drawing.Color.White;
            this.pnlFeesDetails.Controls.Add(this.pnlFees);
            this.pnlFeesDetails.Location = new System.Drawing.Point(11, 116);
            this.pnlFeesDetails.Name = "pnlFeesDetails";
            this.pnlFeesDetails.Size = new System.Drawing.Size(900, 589);
            this.pnlFeesDetails.TabIndex = 90;
            this.pnlFeesDetails.Visible = false;
            // 
            // pnlFees
            // 
            this.pnlFees.BackColor = System.Drawing.Color.White;
            this.pnlFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFees.Controls.Add(this.lnlTotalFees);
            this.pnlFees.Controls.Add(this.lnkUncleared);
            this.pnlFees.Controls.Add(this.lblCourse);
            this.pnlFees.Controls.Add(this.cmbCoursePayment);
            this.pnlFees.Controls.Add(this.lnkMoreDetails);
            this.pnlFees.Controls.Add(this.lblUncleared);
            this.pnlFees.Controls.Add(this.label13);
            this.pnlFees.Controls.Add(this.label10);
            this.pnlFees.Controls.Add(this.lblTotalOustanding);
            this.pnlFees.Controls.Add(this.lblBatch);
            this.pnlFees.Controls.Add(this.lblStandard);
            this.pnlFees.Controls.Add(this.lblOFees);
            this.pnlFees.Controls.Add(this.lblCleared);
            this.pnlFees.Controls.Add(this.label23);
            this.pnlFees.Controls.Add(this.lblCrse);
            this.pnlFees.Controls.Add(this.label5);
            this.pnlFees.Controls.Add(this.label2);
            this.pnlFees.Controls.Add(this.lblTOFees);
            this.pnlFees.Controls.Add(this.lbl);
            this.pnlFees.Controls.Add(this.label8);
            this.pnlFees.Controls.Add(this.lblPackageCost);
            this.pnlFees.Controls.Add(this.label15);
            this.pnlFees.Controls.Add(this.lblDiscountGiven);
            this.pnlFees.Controls.Add(this.lblFeesPaid);
            this.pnlFees.Controls.Add(this.label4);
            this.pnlFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFees.Location = new System.Drawing.Point(3, 3);
            this.pnlFees.Name = "pnlFees";
            this.pnlFees.Size = new System.Drawing.Size(894, 158);
            this.pnlFees.TabIndex = 74;
            // 
            // lnlTotalFees
            // 
            this.lnlTotalFees.AutoSize = true;
            this.lnlTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlTotalFees.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnlTotalFees.Location = new System.Drawing.Point(702, 126);
            this.lnlTotalFees.Name = "lnlTotalFees";
            this.lnlTotalFees.Size = new System.Drawing.Size(157, 16);
            this.lnlTotalFees.TabIndex = 451;
            this.lnlTotalFees.TabStop = true;
            this.lnlTotalFees.Text = "Total Packages Fees";
            this.lnlTotalFees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlTotalFees_LinkClicked);
            // 
            // lnkUncleared
            // 
            this.lnkUncleared.AutoSize = true;
            this.lnkUncleared.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUncleared.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkUncleared.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkUncleared.Location = new System.Drawing.Point(495, 99);
            this.lnkUncleared.Name = "lnkUncleared";
            this.lnkUncleared.Size = new System.Drawing.Size(86, 18);
            this.lnkUncleared.TabIndex = 452;
            this.lnkUncleared.TabStop = true;
            this.lnkUncleared.Text = "UnCleared :";
            this.lnkUncleared.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUncleared_LinkClicked);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.BackColor = System.Drawing.Color.Transparent;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCourse.Location = new System.Drawing.Point(10, 9);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(61, 18);
            this.lblCourse.TabIndex = 454;
            this.lblCourse.Text = "Course:";
            // 
            // cmbCoursePayment
            // 
            this.cmbCoursePayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoursePayment.FormattingEnabled = true;
            this.cmbCoursePayment.Location = new System.Drawing.Point(84, 7);
            this.cmbCoursePayment.Name = "cmbCoursePayment";
            this.cmbCoursePayment.Size = new System.Drawing.Size(338, 24);
            this.cmbCoursePayment.TabIndex = 453;
            this.cmbCoursePayment.SelectedIndexChanged += new System.EventHandler(this.cmbCoursePayment_SelectedIndexChanged);
            // 
            // lnkMoreDetails
            // 
            this.lnkMoreDetails.AutoSize = true;
            this.lnkMoreDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMoreDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkMoreDetails.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkMoreDetails.Location = new System.Drawing.Point(702, 94);
            this.lnkMoreDetails.Name = "lnkMoreDetails";
            this.lnkMoreDetails.Size = new System.Drawing.Size(143, 16);
            this.lnkMoreDetails.TabIndex = 449;
            this.lnkMoreDetails.TabStop = true;
            this.lnkMoreDetails.Text = "Installments Details";
            this.lnkMoreDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMoreDetails_LinkClicked);
            // 
            // lblUncleared
            // 
            this.lblUncleared.AutoSize = true;
            this.lblUncleared.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUncleared.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblUncleared.Location = new System.Drawing.Point(579, 99);
            this.lblUncleared.Name = "lblUncleared";
            this.lblUncleared.Size = new System.Drawing.Size(17, 18);
            this.lblUncleared.TabIndex = 450;
            this.lblUncleared.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-7, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1086, 16);
            this.label13.TabIndex = 443;
            this.label13.Text = "_________________________________________________________________________________" +
    "_________________________________________________________________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(10, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 18);
            this.label10.TabIndex = 94;
            this.label10.Text = "Total Outstanding :";
            // 
            // lblTotalOustanding
            // 
            this.lblTotalOustanding.AutoSize = true;
            this.lblTotalOustanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOustanding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTotalOustanding.Location = new System.Drawing.Point(141, 99);
            this.lblTotalOustanding.Name = "lblTotalOustanding";
            this.lblTotalOustanding.Size = new System.Drawing.Size(17, 18);
            this.lblTotalOustanding.TabIndex = 93;
            this.lblTotalOustanding.Text = "0";
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBatch.Location = new System.Drawing.Point(325, 55);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(40, 18);
            this.lblBatch.TabIndex = 57;
            this.lblBatch.Text = "btch";
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStandard.Location = new System.Drawing.Point(78, 55);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(63, 18);
            this.lblStandard.TabIndex = 55;
            this.lblStandard.Text = "Course";
            // 
            // lblOFees
            // 
            this.lblOFees.AutoSize = true;
            this.lblOFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOFees.Location = new System.Drawing.Point(782, 55);
            this.lblOFees.Name = "lblOFees";
            this.lblOFees.Size = new System.Drawing.Size(17, 18);
            this.lblOFees.TabIndex = 89;
            this.lblOFees.Text = "0";
            // 
            // lblCleared
            // 
            this.lblCleared.AutoSize = true;
            this.lblCleared.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleared.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCleared.Location = new System.Drawing.Point(470, 126);
            this.lblCleared.Name = "lblCleared";
            this.lblCleared.Size = new System.Drawing.Size(74, 18);
            this.lblCleared.TabIndex = 93;
            this.lblCleared.Text = "lblClread";
            this.lblCleared.Visible = false;
            this.lblCleared.Click += new System.EventHandler(this.lblCleared_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label23.Location = new System.Drawing.Point(386, 126);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 18);
            this.label23.TabIndex = 92;
            this.label23.Text = "Cleared :";
            this.label23.Visible = false;
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // lblCrse
            // 
            this.lblCrse.AutoSize = true;
            this.lblCrse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCrse.Location = new System.Drawing.Point(7, 55);
            this.lblCrse.Name = "lblCrse";
            this.lblCrse.Size = new System.Drawing.Size(65, 18);
            this.lblCrse.TabIndex = 51;
            this.lblCrse.Text = "Course :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(242, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 88;
            this.label5.Text = "Payable Today : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(270, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Batch :";
            // 
            // lblTOFees
            // 
            this.lblTOFees.AutoSize = true;
            this.lblTOFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTOFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTOFees.Location = new System.Drawing.Point(371, 99);
            this.lblTOFees.Name = "lblTOFees";
            this.lblTOFees.Size = new System.Drawing.Size(17, 18);
            this.lblTOFees.TabIndex = 85;
            this.lblTOFees.Text = "0";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lbl.Location = new System.Drawing.Point(689, 54);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(95, 18);
            this.lbl.TabIndex = 84;
            this.lbl.Text = "Outstanding :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(458, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 81;
            this.label8.Text = "Total Fees :";
            // 
            // lblPackageCost
            // 
            this.lblPackageCost.AutoSize = true;
            this.lblPackageCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPackageCost.Location = new System.Drawing.Point(544, 14);
            this.lblPackageCost.Name = "lblPackageCost";
            this.lblPackageCost.Size = new System.Drawing.Size(17, 18);
            this.lblPackageCost.TabIndex = 82;
            this.lblPackageCost.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(687, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 18);
            this.label15.TabIndex = 86;
            this.label15.Text = "Discount :";
            // 
            // lblDiscountGiven
            // 
            this.lblDiscountGiven.AutoSize = true;
            this.lblDiscountGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountGiven.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblDiscountGiven.Location = new System.Drawing.Point(760, 14);
            this.lblDiscountGiven.Name = "lblDiscountGiven";
            this.lblDiscountGiven.Size = new System.Drawing.Size(17, 18);
            this.lblDiscountGiven.TabIndex = 87;
            this.lblDiscountGiven.Text = "0";
            // 
            // lblFeesPaid
            // 
            this.lblFeesPaid.AutoSize = true;
            this.lblFeesPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblFeesPaid.Location = new System.Drawing.Point(505, 55);
            this.lblFeesPaid.Name = "lblFeesPaid";
            this.lblFeesPaid.Size = new System.Drawing.Size(17, 18);
            this.lblFeesPaid.TabIndex = 83;
            this.lblFeesPaid.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(463, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 80;
            this.label4.Text = "Paid :";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.linkLabel1);
            this.panel6.Controls.Add(this.cmbReceivedBy);
            this.panel6.Controls.Add(this.lblReceivedBy);
            this.panel6.Controls.Add(this.lblNextDue);
            this.panel6.Controls.Add(this.dtdueDate);
            this.panel6.Controls.Add(this.chkviewRcpt);
            this.panel6.Controls.Add(this.txtCashAmount);
            this.panel6.Controls.Add(this.txtDiscount);
            this.panel6.Controls.Add(this.txtFine);
            this.panel6.Controls.Add(this.txtChequeAmount);
            this.panel6.Controls.Add(this.txtBankAmount);
            this.panel6.Controls.Add(this.lnkBnkTrnfr);
            this.panel6.Controls.Add(this.btnPay);
            this.panel6.Controls.Add(this.btnSubmit);
            this.panel6.Controls.Add(this.cmdReset);
            this.panel6.Controls.Add(this.lblDiscount);
            this.panel6.Controls.Add(this.txtActualPaymentAmnt);
            this.panel6.Controls.Add(this.lnkAddAccount);
            this.panel6.Controls.Add(this.cmbAccount);
            this.panel6.Controls.Add(this.lblAccount);
            this.panel6.Controls.Add(this.txtDiscountReason);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(label12);
            this.panel6.Controls.Add(this.panCheque);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.lnkAddCheque);
            this.panel6.Controls.Add(this.lblCashAmount);
            this.panel6.Controls.Add(this.dtPaymentDate);
            this.panel6.Controls.Add(this.label29);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.txtAFPaying);
            this.panel6.Location = new System.Drawing.Point(11, 283);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(894, 416);
            this.panel6.TabIndex = 75;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.linkLabel1.Location = new System.Drawing.Point(594, 120);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 18);
            this.linkLabel1.TabIndex = 434;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Pay PDC";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // cmbReceivedBy
            // 
            this.cmbReceivedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbReceivedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReceivedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceivedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReceivedBy.FormattingEnabled = true;
            this.cmbReceivedBy.Location = new System.Drawing.Point(421, 248);
            this.cmbReceivedBy.Name = "cmbReceivedBy";
            this.cmbReceivedBy.Size = new System.Drawing.Size(179, 24);
            this.cmbReceivedBy.TabIndex = 432;
            this.cmbReceivedBy.Visible = false;
            // 
            // lblReceivedBy
            // 
            this.lblReceivedBy.AutoSize = true;
            this.lblReceivedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblReceivedBy.Location = new System.Drawing.Point(324, 249);
            this.lblReceivedBy.Name = "lblReceivedBy";
            this.lblReceivedBy.Size = new System.Drawing.Size(90, 18);
            this.lblReceivedBy.TabIndex = 433;
            this.lblReceivedBy.Text = "Received By";
            this.lblReceivedBy.Visible = false;
            // 
            // lblNextDue
            // 
            this.lblNextDue.AutoSize = true;
            this.lblNextDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblNextDue.Location = new System.Drawing.Point(325, 40);
            this.lblNextDue.Name = "lblNextDue";
            this.lblNextDue.Size = new System.Drawing.Size(112, 18);
            this.lblNextDue.TabIndex = 431;
            this.lblNextDue.Text = "Next Due Date :";
            // 
            // dtdueDate
            // 
            this.dtdueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtdueDate.Location = new System.Drawing.Point(440, 37);
            this.dtdueDate.Name = "dtdueDate";
            this.dtdueDate.Size = new System.Drawing.Size(138, 22);
            this.dtdueDate.TabIndex = 430;
            // 
            // chkviewRcpt
            // 
            this.chkviewRcpt.AutoSize = true;
            this.chkviewRcpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkviewRcpt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkviewRcpt.Location = new System.Drawing.Point(764, 200);
            this.chkviewRcpt.Name = "chkviewRcpt";
            this.chkviewRcpt.Size = new System.Drawing.Size(121, 24);
            this.chkviewRcpt.TabIndex = 429;
            this.chkviewRcpt.Text = "View Receipt";
            this.chkviewRcpt.UseVisualStyleBackColor = true;
            this.chkviewRcpt.CheckedChanged += new System.EventHandler(this.chkviewRcpt_CheckedChanged);
            // 
            // txtCashAmount
            // 
            this.txtCashAmount.Depth = 0;
            this.txtCashAmount.Hint = "Enter Cash Amount";
            this.txtCashAmount.Location = new System.Drawing.Point(131, 78);
            this.txtCashAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCashAmount.Name = "txtCashAmount";
            this.txtCashAmount.PasswordChar = '\0';
            this.txtCashAmount.SelectedText = "";
            this.txtCashAmount.SelectionLength = 0;
            this.txtCashAmount.SelectionStart = 0;
            this.txtCashAmount.Size = new System.Drawing.Size(139, 23);
            this.txtCashAmount.TabIndex = 5;
            this.txtCashAmount.TabStop = false;
            this.txtCashAmount.UseSystemPasswordChar = false;
            this.txtCashAmount.TextChanged += new System.EventHandler(this.txtCashAmount_TextChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Depth = 0;
            this.txtDiscount.Hint = "Enter Discount";
            this.txtDiscount.Location = new System.Drawing.Point(131, 195);
            this.txtDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.SelectionLength = 0;
            this.txtDiscount.SelectionStart = 0;
            this.txtDiscount.Size = new System.Drawing.Size(139, 23);
            this.txtDiscount.TabIndex = 8;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.UseSystemPasswordChar = false;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtFine
            // 
            this.txtFine.Depth = 0;
            this.txtFine.Hint = "Enter Fine ";
            this.txtFine.Location = new System.Drawing.Point(131, 120);
            this.txtFine.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFine.Name = "txtFine";
            this.txtFine.PasswordChar = '\0';
            this.txtFine.SelectedText = "";
            this.txtFine.SelectionLength = 0;
            this.txtFine.SelectionStart = 0;
            this.txtFine.Size = new System.Drawing.Size(139, 23);
            this.txtFine.TabIndex = 6;
            this.txtFine.TabStop = false;
            this.txtFine.UseSystemPasswordChar = false;
            this.txtFine.TextChanged += new System.EventHandler(this.txtFine_TextChanged);
            // 
            // txtChequeAmount
            // 
            this.txtChequeAmount.AutoSize = true;
            this.txtChequeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtChequeAmount.Location = new System.Drawing.Point(458, 120);
            this.txtChequeAmount.Name = "txtChequeAmount";
            this.txtChequeAmount.Size = new System.Drawing.Size(66, 18);
            this.txtChequeAmount.TabIndex = 428;
            this.txtChequeAmount.Text = "Rs 0.00";
            this.txtChequeAmount.Visible = false;
            // 
            // txtBankAmount
            // 
            this.txtBankAmount.AutoSize = true;
            this.txtBankAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtBankAmount.Location = new System.Drawing.Point(458, 154);
            this.txtBankAmount.Name = "txtBankAmount";
            this.txtBankAmount.Size = new System.Drawing.Size(66, 18);
            this.txtBankAmount.TabIndex = 427;
            this.txtBankAmount.Text = "Rs 0.00";
            this.txtBankAmount.Visible = false;
            // 
            // lnkBnkTrnfr
            // 
            this.lnkBnkTrnfr.AutoSize = true;
            this.lnkBnkTrnfr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBnkTrnfr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkBnkTrnfr.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkBnkTrnfr.Location = new System.Drawing.Point(324, 152);
            this.lnkBnkTrnfr.Name = "lnkBnkTrnfr";
            this.lnkBnkTrnfr.Size = new System.Drawing.Size(114, 18);
            this.lnkBnkTrnfr.TabIndex = 424;
            this.lnkBnkTrnfr.TabStop = true;
            this.lnkBnkTrnfr.Text = "Bank Transfer";
            this.lnkBnkTrnfr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Image = global::ClassManager.Properties.Resources.rupee_indian;
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(738, 238);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(61, 34);
            this.btnPay.TabIndex = 11;
            this.btnPay.Text = "PAY";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Image = global::ClassManager.Properties.Resources.rupee_indian;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(616, 239);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(116, 33);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "PAY && PRINT";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdReset.FlatAppearance.BorderSize = 0;
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.White;
            this.cmdReset.Image = global::ClassManager.Properties.Resources.refresh_arrows_symbol_of_interface;
            this.cmdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdReset.Location = new System.Drawing.Point(805, 239);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(80, 33);
            this.cmdReset.TabIndex = 13;
            this.cmdReset.Text = "RESET";
            this.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblDiscount.Location = new System.Drawing.Point(4, 200);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(79, 18);
            this.lblDiscount.TabIndex = 324;
            this.lblDiscount.Text = "Discount : ";
            // 
            // txtActualPaymentAmnt
            // 
            this.txtActualPaymentAmnt.Depth = 0;
            this.txtActualPaymentAmnt.Enabled = false;
            this.txtActualPaymentAmnt.Hint = "";
            this.txtActualPaymentAmnt.Location = new System.Drawing.Point(129, 154);
            this.txtActualPaymentAmnt.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtActualPaymentAmnt.Name = "txtActualPaymentAmnt";
            this.txtActualPaymentAmnt.PasswordChar = '\0';
            this.txtActualPaymentAmnt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtActualPaymentAmnt.SelectedText = "";
            this.txtActualPaymentAmnt.SelectionLength = 0;
            this.txtActualPaymentAmnt.SelectionStart = 0;
            this.txtActualPaymentAmnt.Size = new System.Drawing.Size(130, 23);
            this.txtActualPaymentAmnt.TabIndex = 7;
            this.txtActualPaymentAmnt.TabStop = false;
            this.txtActualPaymentAmnt.Text = "0";
            this.txtActualPaymentAmnt.UseSystemPasswordChar = false;
            // 
            // lnkAddAccount
            // 
            this.lnkAddAccount.AutoSize = true;
            this.lnkAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddAccount.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddAccount.Location = new System.Drawing.Point(586, 84);
            this.lnkAddAccount.Name = "lnkAddAccount";
            this.lnkAddAccount.Size = new System.Drawing.Size(102, 18);
            this.lnkAddAccount.TabIndex = 5;
            this.lnkAddAccount.TabStop = true;
            this.lnkAddAccount.Text = "Add Account";
            this.lnkAddAccount.Visible = false;
            this.lnkAddAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddAccount_LinkClicked);
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(397, 78);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(179, 24);
            this.cmbAccount.TabIndex = 4;
            this.cmbAccount.Visible = false;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblAccount.Location = new System.Drawing.Point(325, 79);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(66, 18);
            this.lblAccount.TabIndex = 91;
            this.lblAccount.Text = "Account:";
            this.lblAccount.Visible = false;
            // 
            // txtDiscountReason
            // 
            this.txtDiscountReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountReason.Location = new System.Drawing.Point(421, 189);
            this.txtDiscountReason.Multiline = true;
            this.txtDiscountReason.Name = "txtDiscountReason";
            this.txtDiscountReason.Size = new System.Drawing.Size(172, 45);
            this.txtDiscountReason.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label17.Location = new System.Drawing.Point(324, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 18);
            this.label17.TabIndex = 89;
            this.label17.Text = "Reasons :";
            // 
            // panCheque
            // 
            this.panCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCheque.Controls.Add(this.ADGVCheques);
            this.panCheque.Location = new System.Drawing.Point(8, 278);
            this.panCheque.Name = "panCheque";
            this.panCheque.Size = new System.Drawing.Size(881, 130);
            this.panCheque.TabIndex = 70;
            // 
            // ADGVCheques
            // 
            this.ADGVCheques.AllowUserToAddRows = false;
            this.ADGVCheques.AllowUserToDeleteRows = false;
            this.ADGVCheques.AutoGenerateContextFilters = true;
            this.ADGVCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVCheques.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVCheques.DateWithTime = false;
            this.ADGVCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVCheques.Location = new System.Drawing.Point(0, 0);
            this.ADGVCheques.Name = "ADGVCheques";
            this.ADGVCheques.ReadOnly = true;
            this.ADGVCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVCheques.Size = new System.Drawing.Size(879, 128);
            this.ADGVCheques.TabIndex = 347;
            this.ADGVCheques.TimeFilter = false;
            this.ADGVCheques.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVCheques_CellClick);
            this.ADGVCheques.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVCheques_DataBindingComplete);
            this.ADGVCheques.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVCheques_RowPostPaint);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(6, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 18);
            this.label11.TabIndex = 67;
            this.label11.Text = "Payment Details";
            // 
            // lnkAddCheque
            // 
            this.lnkAddCheque.AutoSize = true;
            this.lnkAddCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddCheque.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddCheque.Location = new System.Drawing.Point(324, 120);
            this.lnkAddCheque.Name = "lnkAddCheque";
            this.lnkAddCheque.Size = new System.Drawing.Size(98, 18);
            this.lnkAddCheque.TabIndex = 67;
            this.lnkAddCheque.TabStop = true;
            this.lnkAddCheque.Text = "Add Cheque";
            this.lnkAddCheque.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCheque_LinkClicked);
            // 
            // lblCashAmount
            // 
            this.lblCashAmount.AutoSize = true;
            this.lblCashAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCashAmount.Location = new System.Drawing.Point(1, 78);
            this.lblCashAmount.Name = "lblCashAmount";
            this.lblCashAmount.Size = new System.Drawing.Size(106, 18);
            this.lblCashAmount.TabIndex = 84;
            this.lblCashAmount.Text = "Cash Amount :";
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPaymentDate.Location = new System.Drawing.Point(129, 37);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(138, 22);
            this.dtPaymentDate.TabIndex = 11;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label29.Location = new System.Drawing.Point(0, 41);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(109, 18);
            this.label29.TabIndex = 80;
            this.label29.Text = "Payment Date :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label22.Location = new System.Drawing.Point(4, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 18);
            this.label22.TabIndex = 68;
            this.label22.Text = "Fine :";
            // 
            // txtAFPaying
            // 
            this.txtAFPaying.AutoSize = true;
            this.txtAFPaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAFPaying.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtAFPaying.Location = new System.Drawing.Point(3, 159);
            this.txtAFPaying.Name = "txtAFPaying";
            this.txtAFPaying.Size = new System.Drawing.Size(111, 18);
            this.txtAFPaying.TabIndex = 56;
            this.txtAFPaying.Text = "Total Payment :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-7, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(931, 13);
            this.label1.TabIndex = 428;
            this.label1.Text = "_________________________________________________________________________________" +
    "_________________________________________________________________________";
            // 
            // cmbStudName
            // 
            this.cmbStudName.DropDownHeight = 90;
            this.cmbStudName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbStudName.FilterRule = null;
            this.cmbStudName.FormattingEnabled = true;
            this.cmbStudName.IntegralHeight = false;
            this.cmbStudName.Location = new System.Drawing.Point(96, 76);
            this.cmbStudName.Name = "cmbStudName";
            this.cmbStudName.PropertySelector = null;
            this.cmbStudName.Size = new System.Drawing.Size(248, 21);
            this.cmbStudName.SuggestBoxHeight = 96;
            this.cmbStudName.SuggestListOrderRule = null;
            this.cmbStudName.TabIndex = 1;
            this.cmbStudName.DropDown += new System.EventHandler(this.cmbStudName_DropDown);
            this.cmbStudName.SelectedIndexChanged += new System.EventHandler(this.cmbStudName_SelectedIndexChanged);
            this.cmbStudName.DropDownClosed += new System.EventHandler(this.cmbStudName_DropDownClosed);
            // 
            // FrmFeesPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 748);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.cmbStudName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlFeesDetails);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtAdmissinoNO);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.MaximizeBox = false;
            this.Name = "FrmFeesPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeesPayment";
            this.Load += new System.EventHandler(this.FrmFeesPayment_Load);
            this.pnlFeesDetails.ResumeLayout(false);
            this.pnlFees.ResumeLayout(false);
            this.pnlFees.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panCheque.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVCheques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlFees;
        private System.Windows.Forms.Label lblCleared;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblOFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFeesPaid;
        private System.Windows.Forms.Label lblDiscountGiven;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPackageCost;
        private System.Windows.Forms.Label lblTOFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.LinkLabel lnkAddAccount;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtDiscountReason;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panCheque;
        private ADGV.AdvancedDataGridView ADGVCheques;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel lnkAddCheque;
        private System.Windows.Forms.Label lblCashAmount;
        public System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label txtAFPaying;
        private System.Windows.Forms.Panel pnlFeesDetails;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAdmissinoNO;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtActualPaymentAmnt;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.Label lblCrse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button btnPay;
        private System.ComponentModel.BackgroundWorker bwFeeMSG;
        private System.Windows.Forms.LinkLabel lnkBnkTrnfr;
        private System.Windows.Forms.Label txtChequeAmount;
        private System.Windows.Forms.Label txtBankAmount;
        private System.Windows.Forms.Label label1;
        private UICommon.SuggestComboBox cmbStudName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCashAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFine;
        private System.Windows.Forms.CheckBox chkviewRcpt;
        private System.Windows.Forms.Label lblNextDue;
        public System.Windows.Forms.DateTimePicker dtdueDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalOustanding;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel lnlTotalFees;
        private System.Windows.Forms.LinkLabel lnkUncleared;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbCoursePayment;
        private System.Windows.Forms.LinkLabel lnkMoreDetails;
        private System.Windows.Forms.Label lblUncleared;
        private System.Windows.Forms.ComboBox cmbReceivedBy;
        private System.Windows.Forms.Label lblReceivedBy;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
