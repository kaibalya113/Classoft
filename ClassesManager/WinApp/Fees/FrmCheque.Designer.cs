namespace ClassManager.WinApp
{
    partial class FrmCheque
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
            this.panCheque = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtBounceCharges = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBranch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtChequeNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBank = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbChequeStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCheque = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.StudName = new ClassManager.WinApp.UICommon.SuggestComboBox();
            this.panCheque.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCheque
            // 
            this.panCheque.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panCheque.BackColor = System.Drawing.Color.White;
            this.panCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCheque.Controls.Add(this.StudName);
            this.panCheque.Controls.Add(this.label28);
            this.panCheque.Controls.Add(this.btnSave);
            this.panCheque.Controls.Add(this.txtBounceCharges);
            this.panCheque.Controls.Add(this.txtAmount);
            this.panCheque.Controls.Add(this.txtBranch);
            this.panCheque.Controls.Add(this.txtChequeNo);
            this.panCheque.Controls.Add(this.txtBank);
            this.panCheque.Controls.Add(this.label3);
            this.panCheque.Controls.Add(this.label2);
            this.panCheque.Controls.Add(this.cmbChequeStatus);
            this.panCheque.Controls.Add(this.label1);
            this.panCheque.Controls.Add(this.dtpCheque);
            this.panCheque.Controls.Add(this.label21);
            this.panCheque.Controls.Add(this.label20);
            this.panCheque.Controls.Add(this.label19);
            this.panCheque.Controls.Add(this.label18);
            this.panCheque.Location = new System.Drawing.Point(6, 24);
            this.panCheque.Name = "panCheque";
            this.panCheque.Size = new System.Drawing.Size(695, 236);
            this.panCheque.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label28.Location = new System.Drawing.Point(5, 3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 20);
            this.label28.TabIndex = 427;
            this.label28.Text = "Name :";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(291, 176);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(82, 33);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBounceCharges
            // 
            this.txtBounceCharges.Depth = 0;
            this.txtBounceCharges.Hint = "";
            this.txtBounceCharges.Location = new System.Drawing.Point(505, 134);
            this.txtBounceCharges.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBounceCharges.Name = "txtBounceCharges";
            this.txtBounceCharges.PasswordChar = '\0';
            this.txtBounceCharges.SelectedText = "";
            this.txtBounceCharges.SelectionLength = 0;
            this.txtBounceCharges.SelectionStart = 0;
            this.txtBounceCharges.Size = new System.Drawing.Size(175, 23);
            this.txtBounceCharges.TabIndex = 8;
            this.txtBounceCharges.TabStop = false;
            this.txtBounceCharges.Text = "0";
            this.txtBounceCharges.UseSystemPasswordChar = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Depth = 0;
            this.txtAmount.Hint = "Enter Amount";
            this.txtAmount.Location = new System.Drawing.Point(505, 93);
            this.txtAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.Size = new System.Drawing.Size(174, 23);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.TabStop = false;
            this.txtAmount.UseSystemPasswordChar = false;
            // 
            // txtBranch
            // 
            this.txtBranch.Depth = 0;
            this.txtBranch.Hint = "Enter Branch";
            this.txtBranch.Location = new System.Drawing.Point(505, 10);
            this.txtBranch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.PasswordChar = '\0';
            this.txtBranch.SelectedText = "";
            this.txtBranch.SelectionLength = 0;
            this.txtBranch.SelectionStart = 0;
            this.txtBranch.Size = new System.Drawing.Size(167, 23);
            this.txtBranch.TabIndex = 2;
            this.txtBranch.TabStop = false;
            this.txtBranch.UseSystemPasswordChar = false;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Depth = 0;
            this.txtChequeNo.Hint = "Enter Cheque No.";
            this.txtChequeNo.Location = new System.Drawing.Point(142, 93);
            this.txtChequeNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.PasswordChar = '\0';
            this.txtChequeNo.SelectedText = "";
            this.txtChequeNo.SelectionLength = 0;
            this.txtChequeNo.SelectionStart = 0;
            this.txtChequeNo.Size = new System.Drawing.Size(211, 23);
            this.txtChequeNo.TabIndex = 3;
            this.txtChequeNo.TabStop = false;
            this.txtChequeNo.UseSystemPasswordChar = false;
            // 
            // txtBank
            // 
            this.txtBank.Depth = 0;
            this.txtBank.Hint = "Enter Bank Name";
            this.txtBank.Location = new System.Drawing.Point(136, 48);
            this.txtBank.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBank.Name = "txtBank";
            this.txtBank.PasswordChar = '\0';
            this.txtBank.SelectedText = "";
            this.txtBank.SelectionLength = 0;
            this.txtBank.SelectionStart = 0;
            this.txtBank.Size = new System.Drawing.Size(217, 23);
            this.txtBank.TabIndex = 1;
            this.txtBank.TabStop = false;
            this.txtBank.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(363, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 74;
            this.label3.Text = "Bounce Charges :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(368, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 72;
            this.label2.Text = "Amount :";
            // 
            // cmbChequeStatus
            // 
            this.cmbChequeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChequeStatus.FormattingEnabled = true;
            this.cmbChequeStatus.Items.AddRange(new object[] {
            "PDC"});
            this.cmbChequeStatus.Location = new System.Drawing.Point(123, 139);
            this.cmbChequeStatus.Name = "cmbChequeStatus";
            this.cmbChequeStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbChequeStatus.TabIndex = 5;
            this.cmbChequeStatus.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(5, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Status";
            // 
            // dtpCheque
            // 
            this.dtpCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheque.Location = new System.Drawing.Point(507, 49);
            this.dtpCheque.Name = "dtpCheque";
            this.dtpCheque.Size = new System.Drawing.Size(165, 22);
            this.dtpCheque.TabIndex = 4;
            this.dtpCheque.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label21.Location = new System.Drawing.Point(368, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 20);
            this.label21.TabIndex = 22;
            this.label21.Text = "Cheque Date :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label20.Location = new System.Drawing.Point(3, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 20);
            this.label20.TabIndex = 20;
            this.label20.Text = "Cheque Number :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label19.Location = new System.Drawing.Point(368, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 20);
            this.label19.TabIndex = 18;
            this.label19.Text = "Branch :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label18.Location = new System.Drawing.Point(5, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 20);
            this.label18.TabIndex = 16;
            this.label18.Text = "Bank Name :";
            // 
            // StudName
            // 
            this.StudName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.StudName.FilterRule = null;
            this.StudName.FormattingEnabled = true;
            this.StudName.Location = new System.Drawing.Point(95, 5);
            this.StudName.Name = "StudName";
            this.StudName.PropertySelector = null;
            this.StudName.Size = new System.Drawing.Size(258, 32);
            this.StudName.SuggestBoxHeight = 96;
            this.StudName.SuggestListOrderRule = null;
            this.StudName.TabIndex = 431;
            this.StudName.SelectedIndexChanged += new System.EventHandler(this.StudName_SelectedIndexChanged);
            // 
            // FrmCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 270);
            this.Controls.Add(this.panCheque);
            this.Name = "FrmCheque";
            this.Text = "Cheque";
            this.Load += new System.EventHandler(this.FrmCheque_Load);
            this.panCheque.ResumeLayout(false);
            this.panCheque.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panCheque;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBounceCharges;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBranch;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtChequeNo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbChequeStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCheque;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label28;
        private UICommon.SuggestComboBox StudName;
    }
}