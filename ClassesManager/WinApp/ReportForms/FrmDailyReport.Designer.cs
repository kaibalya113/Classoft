namespace ClassManager.WinApp
{
    partial class FrmDailyReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblExpPckg = new System.Windows.Forms.Label();
            this.lblTObeExpPckg = new System.Windows.Forms.Label();
            this.lblTobeExp = new System.Windows.Forms.Label();
            this.lblExpired = new System.Windows.Forms.Label();
            this.lblExpData = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.byCheque = new System.Windows.Forms.Label();
            this.byCash = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblExpnc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOtherIncome = new System.Windows.Forms.Label();
            this.lblFCollectn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ttlprsnt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ttlAbsnt = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblBatchNm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFollwp = new System.Windows.Forms.Label();
            this.lblEnq = new System.Windows.Forms.Label();
            this.lblReg = new System.Windows.Forms.Label();
            this.lblStd = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.btnSMS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.lblExpData);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 441);
            this.panel2.TabIndex = 74;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblExpPckg);
            this.panel6.Controls.Add(this.lblTObeExpPckg);
            this.panel6.Controls.Add(this.lblTobeExp);
            this.panel6.Controls.Add(this.lblExpired);
            this.panel6.Location = new System.Drawing.Point(470, 186);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(378, 85);
            this.panel6.TabIndex = 97;
            this.panel6.Visible = false;
            // 
            // lblExpPckg
            // 
            this.lblExpPckg.AutoSize = true;
            this.lblExpPckg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpPckg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblExpPckg.Location = new System.Drawing.Point(14, 10);
            this.lblExpPckg.Name = "lblExpPckg";
            this.lblExpPckg.Size = new System.Drawing.Size(238, 20);
            this.lblExpPckg.TabIndex = 85;
            this.lblExpPckg.Text = "Members with Expired Package :";
            this.lblExpPckg.Visible = false;
            // 
            // lblTObeExpPckg
            // 
            this.lblTObeExpPckg.AutoSize = true;
            this.lblTObeExpPckg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTObeExpPckg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTObeExpPckg.Location = new System.Drawing.Point(14, 46);
            this.lblTObeExpPckg.Name = "lblTObeExpPckg";
            this.lblTObeExpPckg.Size = new System.Drawing.Size(282, 20);
            this.lblTObeExpPckg.TabIndex = 86;
            this.lblTObeExpPckg.Text = "Members with To be Expired Package :";
            this.lblTObeExpPckg.Visible = false;
            // 
            // lblTobeExp
            // 
            this.lblTobeExp.AutoSize = true;
            this.lblTobeExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTobeExp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTobeExp.Location = new System.Drawing.Point(300, 46);
            this.lblTobeExp.Name = "lblTobeExp";
            this.lblTobeExp.Size = new System.Drawing.Size(54, 20);
            this.lblTobeExp.TabIndex = 88;
            this.lblTobeExp.Text = "Total ";
            this.lblTobeExp.Visible = false;
            // 
            // lblExpired
            // 
            this.lblExpired.AutoSize = true;
            this.lblExpired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblExpired.Location = new System.Drawing.Point(300, 10);
            this.lblExpired.Name = "lblExpired";
            this.lblExpired.Size = new System.Drawing.Size(57, 20);
            this.lblExpired.TabIndex = 87;
            this.lblExpired.Text = "Count";
            this.lblExpired.Visible = false;
            // 
            // lblExpData
            // 
            this.lblExpData.AutoSize = true;
            this.lblExpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblExpData.Location = new System.Drawing.Point(466, 163);
            this.lblExpData.Name = "lblExpData";
            this.lblExpData.Size = new System.Drawing.Size(185, 20);
            this.lblExpData.TabIndex = 96;
            this.lblExpData.Text = "Package Expiry Data :";
            this.lblExpData.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(15, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 20);
            this.label15.TabIndex = 95;
            this.label15.Text = "Income and  Expense:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(31, 328);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 20);
            this.label14.TabIndex = 94;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(466, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 93;
            this.label13.Text = "Attendance :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(15, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(222, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "Enquiry and  Registration :";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.byCheque);
            this.panel5.Controls.Add(this.byCash);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.lblExpnc);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.lblOtherIncome);
            this.panel5.Controls.Add(this.lblFCollectn);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(12, 186);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(390, 188);
            this.panel5.TabIndex = 91;
            // 
            // byCheque
            // 
            this.byCheque.AutoSize = true;
            this.byCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.byCheque.Location = new System.Drawing.Point(179, 161);
            this.byCheque.Name = "byCheque";
            this.byCheque.Size = new System.Drawing.Size(156, 20);
            this.byCheque.TabIndex = 88;
            this.byCheque.Text = "Cheque Collected:";
            // 
            // byCash
            // 
            this.byCash.AutoSize = true;
            this.byCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.byCash.Location = new System.Drawing.Point(181, 123);
            this.byCash.Name = "byCash";
            this.byCash.Size = new System.Drawing.Size(130, 20);
            this.byCash.TabIndex = 87;
            this.byCash.Text = "CashCollected:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(5, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 20);
            this.label11.TabIndex = 86;
            this.label11.Text = "Collection By Cheque :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 73;
            this.label3.Text = "Total Expence :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(3, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 20);
            this.label9.TabIndex = 85;
            this.label9.Text = "Collection By Cash:";
            // 
            // lblExpnc
            // 
            this.lblExpnc.AutoSize = true;
            this.lblExpnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpnc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblExpnc.Location = new System.Drawing.Point(178, 12);
            this.lblExpnc.Name = "lblExpnc";
            this.lblExpnc.Size = new System.Drawing.Size(133, 20);
            this.lblExpnc.TabIndex = 78;
            this.lblExpnc.Text = "Total Expence :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(3, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 79;
            this.label7.Text = "Other Income :";
            // 
            // lblOtherIncome
            // 
            this.lblOtherIncome.AutoSize = true;
            this.lblOtherIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherIncome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOtherIncome.Location = new System.Drawing.Point(178, 48);
            this.lblOtherIncome.Name = "lblOtherIncome";
            this.lblOtherIncome.Size = new System.Drawing.Size(118, 20);
            this.lblOtherIncome.TabIndex = 80;
            this.lblOtherIncome.Text = "Other Income";
            // 
            // lblFCollectn
            // 
            this.lblFCollectn.AutoSize = true;
            this.lblFCollectn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFCollectn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblFCollectn.Location = new System.Drawing.Point(179, 86);
            this.lblFCollectn.Name = "lblFCollectn";
            this.lblFCollectn.Size = new System.Drawing.Size(184, 20);
            this.lblFCollectn.TabIndex = 77;
            this.lblFCollectn.Text = "Total Fees Collected :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 72;
            this.label2.Text = "Total Fees Collected :";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.ttlprsnt);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.ttlAbsnt);
            this.panel4.Location = new System.Drawing.Point(470, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 91);
            this.panel4.TabIndex = 90;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // ttlprsnt
            // 
            this.ttlprsnt.AutoSize = true;
            this.ttlprsnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttlprsnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ttlprsnt.Location = new System.Drawing.Point(209, 51);
            this.ttlprsnt.Name = "ttlprsnt";
            this.ttlprsnt.Size = new System.Drawing.Size(135, 20);
            this.ttlprsnt.TabIndex = 82;
            this.ttlprsnt.Text = "Total Presents :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(14, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 20);
            this.label8.TabIndex = 81;
            this.label8.Text = "Total Members Presents :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(14, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 20);
            this.label10.TabIndex = 83;
            this.label10.Text = "Total Members Absents :";
            // 
            // ttlAbsnt
            // 
            this.ttlAbsnt.AutoSize = true;
            this.ttlAbsnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttlAbsnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ttlAbsnt.Location = new System.Drawing.Point(209, 13);
            this.ttlAbsnt.Name = "ttlAbsnt";
            this.ttlAbsnt.Size = new System.Drawing.Size(130, 20);
            this.ttlAbsnt.TabIndex = 84;
            this.ttlAbsnt.Text = "Total Absents :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblBatchNm);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblFollwp);
            this.panel3.Controls.Add(this.lblEnq);
            this.panel3.Controls.Add(this.lblReg);
            this.panel3.Controls.Add(this.lblStd);
            this.panel3.Location = new System.Drawing.Point(12, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 112);
            this.panel3.TabIndex = 89;
            // 
            // lblBatchNm
            // 
            this.lblBatchNm.AutoSize = true;
            this.lblBatchNm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchNm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBatchNm.Location = new System.Drawing.Point(5, 49);
            this.lblBatchNm.Name = "lblBatchNm";
            this.lblBatchNm.Size = new System.Drawing.Size(128, 20);
            this.lblBatchNm.TabIndex = 70;
            this.lblBatchNm.Text = "No.Of FollowUp :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "No.Of Enquires : ";
            // 
            // lblFollwp
            // 
            this.lblFollwp.AutoSize = true;
            this.lblFollwp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFollwp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblFollwp.Location = new System.Drawing.Point(159, 47);
            this.lblFollwp.Name = "lblFollwp";
            this.lblFollwp.Size = new System.Drawing.Size(144, 20);
            this.lblFollwp.TabIndex = 75;
            this.lblFollwp.Text = "No.Of FollowUp :";
            // 
            // lblEnq
            // 
            this.lblEnq.AutoSize = true;
            this.lblEnq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblEnq.Location = new System.Drawing.Point(159, 11);
            this.lblEnq.Name = "lblEnq";
            this.lblEnq.Size = new System.Drawing.Size(146, 20);
            this.lblEnq.TabIndex = 76;
            this.lblEnq.Text = "No.Of Enquires : ";
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblReg.Location = new System.Drawing.Point(159, 81);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(168, 20);
            this.lblReg.TabIndex = 74;
            this.lblReg.Text = "No.Of Registration :";
            // 
            // lblStd
            // 
            this.lblStd.AutoSize = true;
            this.lblStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStd.Location = new System.Drawing.Point(5, 82);
            this.lblStd.Name = "lblStd";
            this.lblStd.Size = new System.Drawing.Size(148, 20);
            this.lblStd.TabIndex = 69;
            this.lblStd.Text = "No.Of Registration :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGetReport);
            this.panel1.Controls.Add(this.btnSMS);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtPFromDate);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 89);
            this.panel1.TabIndex = 73;
            // 
            // btnGetReport
            // 
            this.btnGetReport.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnGetReport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGetReport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGetReport.FlatAppearance.BorderSize = 0;
            this.btnGetReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetReport.ForeColor = System.Drawing.Color.White;
            this.btnGetReport.Image = global::ClassManager.Properties.Resources.icon_graph;
            this.btnGetReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetReport.Location = new System.Drawing.Point(528, 47);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(98, 35);
            this.btnGetReport.TabIndex = 4;
            this.btnGetReport.Text = "REPORT";
            this.btnGetReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetReport.UseVisualStyleBackColor = false;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // btnSMS
            // 
            this.btnSMS.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSMS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSMS.FlatAppearance.BorderSize = 0;
            this.btnSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSMS.ForeColor = System.Drawing.Color.White;
            this.btnSMS.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSMS.Location = new System.Drawing.Point(632, 47);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(81, 35);
            this.btnSMS.TabIndex = 5;
            this.btnSMS.Text = "SEND";
            this.btnSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMS.UseVisualStyleBackColor = false;
            this.btnSMS.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(610, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 75;
            this.label6.Text = "To Date :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(685, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(115, 22);
            this.dtpToDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(19, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 18);
            this.label4.TabIndex = 74;
            this.label4.Text = "Select Branch :";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(133, 20);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(135, 26);
            this.cmbBranch.TabIndex = 1;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(329, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "From Date :";
            // 
            // dtPFromDate
            // 
            this.dtPFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPFromDate.Location = new System.Drawing.Point(422, 19);
            this.dtPFromDate.Name = "dtPFromDate";
            this.dtPFromDate.Size = new System.Drawing.Size(114, 22);
            this.dtPFromDate.TabIndex = 2;
            // 
            // FrmDailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(914, 642);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmDailyReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyReport";
            this.Load += new System.EventHandler(this.DailyReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtPFromDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBatchNm;
        private System.Windows.Forms.Label lblStd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFCollectn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExpnc;
        private System.Windows.Forms.Label lblFollwp;
        private System.Windows.Forms.Label lblEnq;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOtherIncome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ttlprsnt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label ttlAbsnt;
        private System.Windows.Forms.Label byCheque;
        private System.Windows.Forms.Label byCash;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSMS;
        private System.Windows.Forms.Label lblTobeExp;
        private System.Windows.Forms.Label lblExpired;
        private System.Windows.Forms.Label lblTObeExpPckg;
        private System.Windows.Forms.Label lblExpPckg;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblExpData;
        private System.Windows.Forms.Button btnGetReport;
    }
}