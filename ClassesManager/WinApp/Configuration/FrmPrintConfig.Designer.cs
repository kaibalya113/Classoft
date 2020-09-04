namespace ClassManager.WinApp.Reports
{
    partial class PrintConfig
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
            this.bgwFeesSms = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSendSms = new System.Windows.Forms.CheckBox();
            this.chkSendMail = new System.Windows.Forms.CheckBox();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.cmbRprtTYpe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwFeesSms
            // 
            this.bgwFeesSms.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFeesSms_DoWork);
            this.bgwFeesSms.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFeesSms_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.chkSendSms);
            this.panel1.Controls.Add(this.chkSendMail);
            this.panel1.Controls.Add(this.cmbFormat);
            this.panel1.Controls.Add(this.cmbRprtTYpe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkView);
            this.panel1.Controls.Add(this.chkSave);
            this.panel1.Controls.Add(this.chkPrint);
            this.panel1.Location = new System.Drawing.Point(11, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 252);
            this.panel1.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Image = global::ClassManager.Properties.Resources.printer_with_document;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(285, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 35);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "PRINT";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSendSms
            // 
            this.chkSendSms.AutoSize = true;
            this.chkSendSms.BackColor = System.Drawing.Color.Transparent;
            this.chkSendSms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendSms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSendSms.Location = new System.Drawing.Point(147, 186);
            this.chkSendSms.Name = "chkSendSms";
            this.chkSendSms.Size = new System.Drawing.Size(105, 24);
            this.chkSendSms.TabIndex = 7;
            this.chkSendSms.Text = "Send SMS";
            this.chkSendSms.UseVisualStyleBackColor = false;
            // 
            // chkSendMail
            // 
            this.chkSendMail.AutoSize = true;
            this.chkSendMail.BackColor = System.Drawing.Color.Transparent;
            this.chkSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSendMail.Location = new System.Drawing.Point(6, 186);
            this.chkSendMail.Name = "chkSendMail";
            this.chkSendMail.Size = new System.Drawing.Size(98, 24);
            this.chkSendMail.TabIndex = 6;
            this.chkSendMail.Text = "Send Mail";
            this.chkSendMail.UseVisualStyleBackColor = false;
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.Enabled = false;
            this.cmbFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(148, 121);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(197, 24);
            this.cmbFormat.TabIndex = 5;
            // 
            // cmbRprtTYpe
            // 
            this.cmbRprtTYpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRprtTYpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRprtTYpe.FormattingEnabled = true;
            this.cmbRprtTYpe.Items.AddRange(new object[] {
            "Professional Institute"});
            this.cmbRprtTYpe.Location = new System.Drawing.Point(148, 12);
            this.cmbRprtTYpe.Name = "cmbRprtTYpe";
            this.cmbRprtTYpe.Size = new System.Drawing.Size(197, 24);
            this.cmbRprtTYpe.TabIndex = 1;
            this.cmbRprtTYpe.SelectedIndexChanged += new System.EventHandler(this.cmbRprtTYpe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Receipt Type";
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.BackColor = System.Drawing.Color.Transparent;
            this.chkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkView.Location = new System.Drawing.Point(6, 65);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(121, 24);
            this.chkView.TabIndex = 2;
            this.chkView.Text = "View Receipt";
            this.chkView.UseVisualStyleBackColor = false;
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.BackColor = System.Drawing.Color.Transparent;
            this.chkSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSave.Location = new System.Drawing.Point(6, 120);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(64, 24);
            this.chkSave.TabIndex = 4;
            this.chkSave.Text = "Save";
            this.chkSave.UseVisualStyleBackColor = false;
            this.chkSave.CheckedChanged += new System.EventHandler(this.chkSave_CheckedChanged);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkPrint.Location = new System.Drawing.Point(147, 65);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(119, 24);
            this.chkPrint.TabIndex = 3;
            this.chkPrint.Text = "Print Receipt";
            this.chkPrint.UseVisualStyleBackColor = false;
            this.chkPrint.Visible = false;
            // 
            // PrintConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(409, 345);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "PrintConfig";
            this.Text = "Print Options";
            this.Load += new System.EventHandler(this.PrintConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRprtTYpe;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.CheckBox chkSendMail;
        private System.Windows.Forms.CheckBox chkSendSms;
        private System.ComponentModel.BackgroundWorker bgwFeesSms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
    }
}
