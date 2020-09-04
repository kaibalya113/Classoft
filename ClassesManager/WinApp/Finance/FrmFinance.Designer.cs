namespace ClassManager.WinApp
{
    partial class FrmFinance
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdSaveExpense = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ADGVExpense = new ADGV.AdvancedDataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExpenseMail = new System.Windows.Forms.Button();
            this.cmdSaveIncome = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ADGVFeesColl = new ADGV.AdvancedDataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMailIncome = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.chkBranchID = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblProfLoss = new System.Windows.Forms.Label();
            this.lblPL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFCOLL = new System.Windows.Forms.Label();
            this.lblTotalExpence = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVExpense)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVFeesColl)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(9, 157);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.cmdSaveExpense);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.btnExpenseMail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.cmdSaveIncome);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.btnMailIncome);
            this.splitContainer1.Size = new System.Drawing.Size(1267, 381);
            this.splitContainer1.SplitterDistance = 651;
            this.splitContainer1.TabIndex = 325;
            // 
            // cmdSaveExpense
            // 
            this.cmdSaveExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSaveExpense.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSaveExpense.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cmdSaveExpense.FlatAppearance.BorderSize = 0;
            this.cmdSaveExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaveExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveExpense.ForeColor = System.Drawing.Color.White;
            this.cmdSaveExpense.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.cmdSaveExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveExpense.Location = new System.Drawing.Point(550, 3);
            this.cmdSaveExpense.Name = "cmdSaveExpense";
            this.cmdSaveExpense.Size = new System.Drawing.Size(95, 28);
            this.cmdSaveExpense.TabIndex = 4;
            this.cmdSaveExpense.Text = "SAVE TO";
            this.cmdSaveExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveExpense.UseVisualStyleBackColor = false;
            this.cmdSaveExpense.Click += new System.EventHandler(this.cmdSaveExpense_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ADGVExpense);
            this.panel3.Location = new System.Drawing.Point(3, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(643, 338);
            this.panel3.TabIndex = 347;
            // 
            // ADGVExpense
            // 
            this.ADGVExpense.AllowUserToAddRows = false;
            this.ADGVExpense.AllowUserToDeleteRows = false;
            this.ADGVExpense.AllowUserToResizeRows = false;
            this.ADGVExpense.AutoGenerateContextFilters = true;
            this.ADGVExpense.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVExpense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVExpense.DateWithTime = false;
            this.ADGVExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVExpense.Location = new System.Drawing.Point(0, 0);
            this.ADGVExpense.Name = "ADGVExpense";
            this.ADGVExpense.ReadOnly = true;
            this.ADGVExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVExpense.Size = new System.Drawing.Size(641, 336);
            this.ADGVExpense.TabIndex = 345;
            this.ADGVExpense.TimeFilter = false;
            this.ADGVExpense.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVExpense_DataBindingComplete);
            this.ADGVExpense.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVExpense_RowPostPaint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(4, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 308;
            this.label8.Text = "Expense Details :";
            // 
            // btnExpenseMail
            // 
            this.btnExpenseMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExpenseMail.FlatAppearance.BorderSize = 0;
            this.btnExpenseMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenseMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseMail.ForeColor = System.Drawing.Color.White;
            this.btnExpenseMail.Image = global::ClassManager.Properties.Resources.Gmail_Icon;
            this.btnExpenseMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpenseMail.Location = new System.Drawing.Point(455, 3);
            this.btnExpenseMail.Name = "btnExpenseMail";
            this.btnExpenseMail.Size = new System.Drawing.Size(77, 28);
            this.btnExpenseMail.TabIndex = 3;
            this.btnExpenseMail.Text = "SEND";
            this.btnExpenseMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpenseMail.UseVisualStyleBackColor = false;
            this.btnExpenseMail.Click += new System.EventHandler(this.btnExpenseMail_Click);
            // 
            // cmdSaveIncome
            // 
            this.cmdSaveIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSaveIncome.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSaveIncome.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cmdSaveIncome.FlatAppearance.BorderSize = 0;
            this.cmdSaveIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaveIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveIncome.ForeColor = System.Drawing.Color.White;
            this.cmdSaveIncome.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.cmdSaveIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveIncome.Location = new System.Drawing.Point(496, 0);
            this.cmdSaveIncome.Name = "cmdSaveIncome";
            this.cmdSaveIncome.Size = new System.Drawing.Size(95, 33);
            this.cmdSaveIncome.TabIndex = 6;
            this.cmdSaveIncome.Text = "SAVE TO";
            this.cmdSaveIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveIncome.UseVisualStyleBackColor = false;
            this.cmdSaveIncome.Click += new System.EventHandler(this.cmdSaveIncome_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.ADGVFeesColl);
            this.panel6.Location = new System.Drawing.Point(3, 35);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(603, 337);
            this.panel6.TabIndex = 347;
            // 
            // ADGVFeesColl
            // 
            this.ADGVFeesColl.AllowUserToAddRows = false;
            this.ADGVFeesColl.AllowUserToDeleteRows = false;
            this.ADGVFeesColl.AllowUserToResizeRows = false;
            this.ADGVFeesColl.AutoGenerateContextFilters = true;
            this.ADGVFeesColl.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVFeesColl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVFeesColl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVFeesColl.DateWithTime = false;
            this.ADGVFeesColl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVFeesColl.Location = new System.Drawing.Point(0, 0);
            this.ADGVFeesColl.Name = "ADGVFeesColl";
            this.ADGVFeesColl.ReadOnly = true;
            this.ADGVFeesColl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVFeesColl.Size = new System.Drawing.Size(601, 335);
            this.ADGVFeesColl.TabIndex = 345;
            this.ADGVFeesColl.TimeFilter = false;
            this.ADGVFeesColl.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVFeesColl_DataBindingComplete_1);
            this.ADGVFeesColl.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVFeesColl_RowPostPaint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 20);
            this.label9.TabIndex = 309;
            this.label9.Text = "Income Details :";
            // 
            // btnMailIncome
            // 
            this.btnMailIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMailIncome.FlatAppearance.BorderSize = 0;
            this.btnMailIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMailIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMailIncome.ForeColor = System.Drawing.Color.White;
            this.btnMailIncome.Image = global::ClassManager.Properties.Resources.Gmail_Icon;
            this.btnMailIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMailIncome.Location = new System.Drawing.Point(415, 1);
            this.btnMailIncome.Name = "btnMailIncome";
            this.btnMailIncome.Size = new System.Drawing.Size(75, 33);
            this.btnMailIncome.TabIndex = 5;
            this.btnMailIncome.Text = "SEND";
            this.btnMailIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMailIncome.UseVisualStyleBackColor = false;
            this.btnMailIncome.Click += new System.EventHandler(this.btnMailExpense_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.chkBranchID);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dtpFromdate);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.dtpDate);
            this.panel4.Location = new System.Drawing.Point(9, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1267, 78);
            this.panel4.TabIndex = 316;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(4, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 317;
            this.label7.Text = "Search By :";
            // 
            // chkBranchID
            // 
            this.chkBranchID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBranchID.AutoSize = true;
            this.chkBranchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBranchID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkBranchID.Location = new System.Drawing.Point(945, 7);
            this.chkBranchID.Name = "chkBranchID";
            this.chkBranchID.Size = new System.Drawing.Size(200, 24);
            this.chkBranchID.TabIndex = 7;
            this.chkBranchID.Text = "Show All Branches Data";
            this.chkBranchID.UseVisualStyleBackColor = true;
            this.chkBranchID.Click += new System.EventHandler(this.chkBranchID_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(29, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 322;
            this.label6.Text = "From Date :";
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromdate.Location = new System.Drawing.Point(128, 37);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Size = new System.Drawing.Size(145, 24);
            this.dtpFromdate.TabIndex = 1;
            this.dtpFromdate.Value = new System.DateTime(2016, 11, 1, 0, 0, 0, 0);
            this.dtpFromdate.CloseUp += new System.EventHandler(this.dtpFromdate_CloseUp);
            this.dtpFromdate.ValueChanged += new System.EventHandler(this.dtpFromdate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(359, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 320;
            this.label5.Text = "To Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(439, 37);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(136, 24);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Value = new System.DateTime(2017, 1, 2, 0, 0, 0, 0);
            this.dtpDate.CloseUp += new System.EventHandler(this.dtpDate_CloseUp);
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblProfLoss
            // 
            this.lblProfLoss.AutoSize = true;
            this.lblProfLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfLoss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblProfLoss.Location = new System.Drawing.Point(972, 16);
            this.lblProfLoss.Name = "lblProfLoss";
            this.lblProfLoss.Size = new System.Drawing.Size(100, 20);
            this.lblProfLoss.TabIndex = 320;
            this.lblProfLoss.Text = "Profit / Loss :";
            // 
            // lblPL
            // 
            this.lblPL.AutoSize = true;
            this.lblPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPL.Location = new System.Drawing.Point(1073, 16);
            this.lblPL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPL.Name = "lblPL";
            this.lblPL.Size = new System.Drawing.Size(94, 20);
            this.lblPL.TabIndex = 321;
            this.lblPL.Text = "proft / loss";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(521, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 307;
            this.label1.Text = "Total Collection :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 308;
            this.label3.Text = "Total Expence :";
            // 
            // lblFCOLL
            // 
            this.lblFCOLL.AutoSize = true;
            this.lblFCOLL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFCOLL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblFCOLL.Location = new System.Drawing.Point(644, 16);
            this.lblFCOLL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFCOLL.Name = "lblFCOLL";
            this.lblFCOLL.Size = new System.Drawing.Size(72, 20);
            this.lblFCOLL.TabIndex = 318;
            this.lblFCOLL.Text = "tFeeCol";
            // 
            // lblTotalExpence
            // 
            this.lblTotalExpence.AutoSize = true;
            this.lblTotalExpence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTotalExpence.Location = new System.Drawing.Point(121, 16);
            this.lblTotalExpence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalExpence.Name = "lblTotalExpence";
            this.lblTotalExpence.Size = new System.Drawing.Size(54, 20);
            this.lblTotalExpence.TabIndex = 319;
            this.lblTotalExpence.Text = "tExpc";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.lblProfLoss);
            this.panel5.Controls.Add(this.lblPL);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.lblTotalExpence);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.lblFCOLL);
            this.panel5.Location = new System.Drawing.Point(9, 544);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1267, 53);
            this.panel5.TabIndex = 324;
            // 
            // FrmFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1283, 605);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Name = "FrmFinance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profit_OR_Loss";
            this.Load += new System.EventHandler(this.Profit_OR_Loss_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVExpense)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVFeesColl)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProfLoss;
        private System.Windows.Forms.Label lblPL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFCOLL;
        private System.Windows.Forms.Label lblTotalExpence;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chkBranchID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFromdate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ADGV.AdvancedDataGridView ADGVFeesColl;
        private System.Windows.Forms.Label label8;
        private ADGV.AdvancedDataGridView ADGVExpense;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnExpenseMail;
        private System.Windows.Forms.Button btnMailIncome;
        private System.Windows.Forms.Button cmdSaveExpense;
        private System.Windows.Forms.Button cmdSaveIncome;
        private System.Windows.Forms.Panel panel5;
    }
}
