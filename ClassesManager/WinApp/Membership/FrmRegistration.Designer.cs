namespace ClassManager.WinApp
{
    partial class FrmRegistration
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
            this.btnGenLincence = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cmdRegister = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbRegSMS = new System.Windows.Forms.RadioButton();
            this.rbtRegInternet = new System.Windows.Forms.RadioButton();
            this.txtLicence = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbClearExisting = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGenLincence
            // 
            this.btnGenLincence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenLincence.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenLincence.BackColor = System.Drawing.Color.White;
            this.btnGenLincence.Depth = 0;
            this.btnGenLincence.Location = new System.Drawing.Point(319, 286);
            this.btnGenLincence.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenLincence.Name = "btnGenLincence";
            this.btnGenLincence.Primary = true;
            this.btnGenLincence.Size = new System.Drawing.Size(121, 36);
            this.btnGenLincence.TabIndex = 7;
            this.btnGenLincence.Text = "Get Licence Key";
            this.btnGenLincence.UseVisualStyleBackColor = false;
            this.btnGenLincence.Click += new System.EventHandler(this.btnGenLincence_Click);
            // 
            // cmdRegister
            // 
            this.cmdRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdRegister.BackColor = System.Drawing.Color.White;
            this.cmdRegister.Depth = 0;
            this.cmdRegister.Location = new System.Drawing.Point(319, 426);
            this.cmdRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdRegister.Name = "cmdRegister";
            this.cmdRegister.Primary = true;
            this.cmdRegister.Size = new System.Drawing.Size(121, 33);
            this.cmdRegister.TabIndex = 9;
            this.cmdRegister.Text = "Register";
            this.cmdRegister.UseVisualStyleBackColor = false;
            this.cmdRegister.Click += new System.EventHandler(this.cmdRegister_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(147, 168);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 26);
            this.txtName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(24, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(24, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Register";
            // 
            // rbRegSMS
            // 
            this.rbRegSMS.AutoSize = true;
            this.rbRegSMS.BackColor = System.Drawing.Color.White;
            this.rbRegSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRegSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbRegSMS.Location = new System.Drawing.Point(243, 247);
            this.rbRegSMS.Name = "rbRegSMS";
            this.rbRegSMS.Size = new System.Drawing.Size(62, 24);
            this.rbRegSMS.TabIndex = 6;
            this.rbRegSMS.TabStop = true;
            this.rbRegSMS.Text = "SMS";
            this.rbRegSMS.UseVisualStyleBackColor = false;
            // 
            // rbtRegInternet
            // 
            this.rbtRegInternet.AutoSize = true;
            this.rbtRegInternet.BackColor = System.Drawing.Color.White;
            this.rbtRegInternet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtRegInternet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtRegInternet.Location = new System.Drawing.Point(147, 245);
            this.rbtRegInternet.Name = "rbtRegInternet";
            this.rbtRegInternet.Size = new System.Drawing.Size(72, 24);
            this.rbtRegInternet.TabIndex = 5;
            this.rbtRegInternet.TabStop = true;
            this.rbtRegInternet.Text = "Online";
            this.rbtRegInternet.UseVisualStyleBackColor = false;
            // 
            // txtLicence
            // 
            this.txtLicence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicence.Location = new System.Drawing.Point(136, 350);
            this.txtLicence.Name = "txtLicence";
            this.txtLicence.Size = new System.Drawing.Size(209, 26);
            this.txtLicence.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(40, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Licence";
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Monthly",
            "Yearly"});
            this.cmbType.Location = new System.Drawing.Point(147, 205);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 28);
            this.cmbType.TabIndex = 4;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(147, 128);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(121, 26);
            this.txtContactNo.TabIndex = 2;
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(147, 86);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(209, 26);
            this.txtSerial.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(24, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(24, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contact No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(24, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Serial Key";
            // 
            // rbClearExisting
            // 
            this.rbClearExisting.AutoSize = true;
            this.rbClearExisting.BackColor = System.Drawing.Color.White;
            this.rbClearExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClearExisting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbClearExisting.Location = new System.Drawing.Point(136, 396);
            this.rbClearExisting.Name = "rbClearExisting";
            this.rbClearExisting.Size = new System.Drawing.Size(190, 24);
            this.rbClearExisting.TabIndex = 20;
            this.rbClearExisting.TabStop = true;
            this.rbClearExisting.Text = "Clear Existing Licences";
            this.rbClearExisting.UseVisualStyleBackColor = false;
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(482, 471);
            this.Controls.Add(this.rbClearExisting);
            this.Controls.Add(this.btnGenLincence);
            this.Controls.Add(this.cmdRegister);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbRegSMS);
            this.Controls.Add(this.rbtRegInternet);
            this.Controls.Add(this.txtLicence);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Your Copy";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicence;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtRegInternet;
        private System.Windows.Forms.RadioButton rbRegSMS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialRaisedButton cmdRegister;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenLincence;
        private System.Windows.Forms.RadioButton rbClearExisting;
    }
}
