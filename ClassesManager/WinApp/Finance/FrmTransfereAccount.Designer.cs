namespace ClassManager.WinApp
{
    partial class FrmTransfereAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDisReason = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblDisReason = new System.Windows.Forms.Label();
            this.cmbToact = new System.Windows.Forms.ComboBox();
            this.btnTrnsfere = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtChequeAmount = new System.Windows.Forms.Label();
            this.lnkAddCheque = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPayStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalance = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmbFromAct = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDisReason);
            this.panel1.Controls.Add(this.lblDisReason);
            this.panel1.Controls.Add(this.cmbToact);
            this.panel1.Controls.Add(this.btnTrnsfere);
            this.panel1.Controls.Add(this.txtChequeAmount);
            this.panel1.Controls.Add(this.lnkAddCheque);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpPayStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Controls.Add(this.cmbFromAct);
            this.panel1.Controls.Add(this.lblBalance);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Location = new System.Drawing.Point(13, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 246);
            this.panel1.TabIndex = 0;
            // 
            // txtDisReason
            // 
            this.txtDisReason.Depth = 0;
            this.txtDisReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisReason.Hint = "";
            this.txtDisReason.Location = new System.Drawing.Point(86, 138);
            this.txtDisReason.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDisReason.Name = "txtDisReason";
            this.txtDisReason.PasswordChar = '\0';
            this.txtDisReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDisReason.SelectedText = "";
            this.txtDisReason.SelectionLength = 0;
            this.txtDisReason.SelectionStart = 0;
            this.txtDisReason.Size = new System.Drawing.Size(216, 23);
            this.txtDisReason.TabIndex = 407;
            this.txtDisReason.TabStop = false;
            this.txtDisReason.UseSystemPasswordChar = false;
            // 
            // lblDisReason
            // 
            this.lblDisReason.AutoSize = true;
            this.lblDisReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblDisReason.Location = new System.Drawing.Point(11, 141);
            this.lblDisReason.Name = "lblDisReason";
            this.lblDisReason.Size = new System.Drawing.Size(69, 20);
            this.lblDisReason.TabIndex = 406;
            this.lblDisReason.Text = "Reason:";
            // 
            // cmbToact
            // 
            this.cmbToact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToact.FormattingEnabled = true;
            this.cmbToact.Items.AddRange(new object[] {
            "CR",
            "DR"});
            this.cmbToact.Location = new System.Drawing.Point(433, 22);
            this.cmbToact.Name = "cmbToact";
            this.cmbToact.Size = new System.Drawing.Size(137, 26);
            this.cmbToact.TabIndex = 2;
            this.cmbToact.SelectedIndexChanged += new System.EventHandler(this.cmbToact_SelectedIndexChanged);
            // 
            // btnTrnsfere
            // 
            this.btnTrnsfere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrnsfere.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTrnsfere.BackColor = System.Drawing.Color.White;
            this.btnTrnsfere.Depth = 0;
            this.btnTrnsfere.Location = new System.Drawing.Point(459, 203);
            this.btnTrnsfere.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTrnsfere.Name = "btnTrnsfere";
            this.btnTrnsfere.Primary = true;
            this.btnTrnsfere.Size = new System.Drawing.Size(85, 33);
            this.btnTrnsfere.TabIndex = 5;
            this.btnTrnsfere.Text = "TRANSFER";
            this.btnTrnsfere.UseVisualStyleBackColor = false;
            this.btnTrnsfere.Click += new System.EventHandler(this.btnViewInstallments_Click);
            // 
            // txtChequeAmount
            // 
            this.txtChequeAmount.AutoSize = true;
            this.txtChequeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.txtChequeAmount.Location = new System.Drawing.Point(143, 188);
            this.txtChequeAmount.Name = "txtChequeAmount";
            this.txtChequeAmount.Size = new System.Drawing.Size(71, 20);
            this.txtChequeAmount.TabIndex = 405;
            this.txtChequeAmount.Text = "Rs 0.00";
            // 
            // lnkAddCheque
            // 
            this.lnkAddCheque.AutoSize = true;
            this.lnkAddCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddCheque.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnkAddCheque.Location = new System.Drawing.Point(12, 190);
            this.lnkAddCheque.Name = "lnkAddCheque";
            this.lnkAddCheque.Size = new System.Drawing.Size(98, 18);
            this.lnkAddCheque.TabIndex = 6;
            this.lnkAddCheque.TabStop = true;
            this.lnkAddCheque.Text = "Add Cheque";
            this.lnkAddCheque.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCheque_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(329, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Date :";
            // 
            // dtpPayStart
            // 
            this.dtpPayStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPayStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPayStart.Location = new System.Drawing.Point(433, 74);
            this.dtpPayStart.Name = "dtpPayStart";
            this.dtpPayStart.Size = new System.Drawing.Size(137, 24);
            this.dtpPayStart.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(329, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "To Account :";
            // 
            // txtBalance
            // 
            this.txtBalance.Depth = 0;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Hint = "Enter Balance";
            this.txtBalance.Location = new System.Drawing.Point(134, 73);
            this.txtBalance.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.PasswordChar = '\0';
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBalance.SelectedText = "";
            this.txtBalance.SelectionLength = 0;
            this.txtBalance.SelectionStart = 0;
            this.txtBalance.Size = new System.Drawing.Size(148, 23);
            this.txtBalance.TabIndex = 3;
            this.txtBalance.TabStop = false;
            this.txtBalance.Text = "0";
            this.txtBalance.UseSystemPasswordChar = false;
            // 
            // cmbFromAct
            // 
            this.cmbFromAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromAct.FormattingEnabled = true;
            this.cmbFromAct.Items.AddRange(new object[] {
            "CR",
            "DR"});
            this.cmbFromAct.Location = new System.Drawing.Point(134, 18);
            this.cmbFromAct.Name = "cmbFromAct";
            this.cmbFromAct.Size = new System.Drawing.Size(148, 26);
            this.cmbFromAct.TabIndex = 1;
            this.cmbFromAct.SelectedIndexChanged += new System.EventHandler(this.cmbFromAct_SelectedIndexChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBalance.Location = new System.Drawing.Point(11, 73);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(73, 20);
            this.lblBalance.TabIndex = 40;
            this.lblBalance.Text = "Amount :";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblType.Location = new System.Drawing.Point(11, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(117, 20);
            this.lblType.TabIndex = 39;
            this.lblType.Text = "From Account :";
            // 
            // FrmTransfereAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 326);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTransfereAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Balance";
            this.Load += new System.EventHandler(this.FrmTransfereAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBalance;
        private System.Windows.Forms.ComboBox cmbFromAct;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPayStart;
        private System.Windows.Forms.Label txtChequeAmount;
        private System.Windows.Forms.LinkLabel lnkAddCheque;
        private MaterialSkin.Controls.MaterialRaisedButton btnTrnsfere;
        private System.Windows.Forms.ComboBox cmbToact;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDisReason;
        private System.Windows.Forms.Label lblDisReason;
    }
}
