namespace ClassManager.WinApp
{
    partial class FrmMonthSelector
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
            this.bgwInvoice = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbInstructor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.lblPaidAmnt = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.txtdiscountReason = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTotalAmount = new System.Windows.Forms.Label();
            this.cmbPack = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpToMonth = new System.Windows.Forms.DateTimePicker();
            this.dtpFromMonth = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwInvoice
            // 
            this.bgwInvoice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInvoice_DoWork);
            this.bgwInvoice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwInvoice_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbInstructor);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnUpgrade);
            this.panel1.Controls.Add(this.lblPaidAmnt);
            this.panel1.Controls.Add(this.lblPaid);
            this.panel1.Controls.Add(this.txtdiscountReason);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.txtTotalAmount);
            this.panel1.Controls.Add(this.cmbPack);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpToMonth);
            this.panel1.Controls.Add(this.dtpFromMonth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 251);
            this.panel1.TabIndex = 32;
            // 
            // cmbInstructor
            // 
            this.cmbInstructor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbInstructor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInstructor.FormattingEnabled = true;
            this.cmbInstructor.Location = new System.Drawing.Point(466, 17);
            this.cmbInstructor.Name = "cmbInstructor";
            this.cmbInstructor.Size = new System.Drawing.Size(165, 24);
            this.cmbInstructor.TabIndex = 404;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(379, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 403;
            this.label11.Text = "Instructor :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpgrade.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpgrade.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUpgrade.FlatAppearance.BorderSize = 0;
            this.btnUpgrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpgrade.ForeColor = System.Drawing.Color.White;
            this.btnUpgrade.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpgrade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpgrade.Location = new System.Drawing.Point(558, 216);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(88, 30);
            this.btnUpgrade.TabIndex = 400;
            this.btnUpgrade.Text = "UPGRADE";
            this.btnUpgrade.UseVisualStyleBackColor = false;
            this.btnUpgrade.Visible = false;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // lblPaidAmnt
            // 
            this.lblPaidAmnt.AutoSize = true;
            this.lblPaidAmnt.BackColor = System.Drawing.Color.White;
            this.lblPaidAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPaidAmnt.Location = new System.Drawing.Point(344, 17);
            this.lblPaidAmnt.Name = "lblPaidAmnt";
            this.lblPaidAmnt.Size = new System.Drawing.Size(29, 20);
            this.lblPaidAmnt.TabIndex = 399;
            this.lblPaidAmnt.Text = "00";
            this.lblPaidAmnt.Visible = false;
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.BackColor = System.Drawing.Color.White;
            this.lblPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPaid.Location = new System.Drawing.Point(290, 17);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(48, 20);
            this.lblPaid.TabIndex = 398;
            this.lblPaid.Text = "Paid :";
            this.lblPaid.Visible = false;
            // 
            // txtdiscountReason
            // 
            this.txtdiscountReason.Depth = 0;
            this.txtdiscountReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscountReason.Hint = "Enter Reason for Discount";
            this.txtdiscountReason.Location = new System.Drawing.Point(100, 157);
            this.txtdiscountReason.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtdiscountReason.Name = "txtdiscountReason";
            this.txtdiscountReason.PasswordChar = '\0';
            this.txtdiscountReason.SelectedText = "";
            this.txtdiscountReason.SelectionLength = 0;
            this.txtdiscountReason.SelectionStart = 0;
            this.txtdiscountReason.Size = new System.Drawing.Size(506, 23);
            this.txtdiscountReason.TabIndex = 397;
            this.txtdiscountReason.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(4, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 396;
            this.label5.Text = "Reason     :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(380, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 395;
            this.label3.Text = "Discount   :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Depth = 0;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Hint = "Enter Discount";
            this.txtDiscount.Location = new System.Drawing.Point(493, 107);
            this.txtDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.SelectionLength = 0;
            this.txtDiscount.SelectionStart = 0;
            this.txtDiscount.Size = new System.Drawing.Size(113, 23);
            this.txtDiscount.TabIndex = 394;
            this.txtDiscount.UseSystemPasswordChar = false;
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.AutoSize = true;
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtTotalAmount.Location = new System.Drawing.Point(118, 200);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(29, 20);
            this.txtTotalAmount.TabIndex = 393;
            this.txtTotalAmount.Text = "00";
            // 
            // cmbPack
            // 
            this.cmbPack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPack.Enabled = false;
            this.cmbPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPack.FormattingEnabled = true;
            this.cmbPack.Location = new System.Drawing.Point(72, 13);
            this.cmbPack.Name = "cmbPack";
            this.cmbPack.Size = new System.Drawing.Size(198, 24);
            this.cmbPack.TabIndex = 1;
            this.cmbPack.SelectedIndexChanged += new System.EventHandler(this.cmbPack_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(4, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 391;
            this.label7.Text = "Select :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(435, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "RENEW";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Depth = 0;
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Hint = "Enter Amount";
            this.txtAmount.Location = new System.Drawing.Point(100, 107);
            this.txtAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.Size = new System.Drawing.Size(113, 23);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(4, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Total Payable:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(4, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Amount     :";
            // 
            // dtpToMonth
            // 
            this.dtpToMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToMonth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToMonth.Location = new System.Drawing.Point(484, 56);
            this.dtpToMonth.Name = "dtpToMonth";
            this.dtpToMonth.Size = new System.Drawing.Size(122, 22);
            this.dtpToMonth.TabIndex = 401;
            // 
            // dtpFromMonth
            // 
            this.dtpFromMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromMonth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromMonth.Location = new System.Drawing.Point(100, 58);
            this.dtpFromMonth.Name = "dtpFromMonth";
            this.dtpFromMonth.Size = new System.Drawing.Size(110, 22);
            this.dtpFromMonth.TabIndex = 2;
            this.dtpFromMonth.ValueChanged += new System.EventHandler(this.dtpFromMonth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(380, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Date    :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(4, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date :";
            // 
            // FrmMonthSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(683, 337);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMonthSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Package Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonthSelector_FormClosing);
            this.Load += new System.EventHandler(this.MonthSelector_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromMonth;
        private System.Windows.Forms.DateTimePicker dtpToMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPack;
        private System.Windows.Forms.Label txtTotalAmount;
        private System.ComponentModel.BackgroundWorker bgwInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtdiscountReason;
        private System.Windows.Forms.Label lblPaidAmnt;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbInstructor;
    }
}
