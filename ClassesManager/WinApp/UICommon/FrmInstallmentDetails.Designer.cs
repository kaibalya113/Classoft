namespace ClassManager.WinApp
{
    partial class FrmInstallmentDetails
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDuration = new System.Windows.Forms.TextBox();
            this.txtTotalInstallment = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveInstallment = new System.Windows.Forms.Button();
            this.txtDayGap = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMonth = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtInstallmentAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnREmove = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnRemoveInstallmnent = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddInst = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lstInstallments = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTotalDuration);
            this.panel1.Controls.Add(this.txtTotalInstallment);
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 76);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Total Duration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(332, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Total Installment Amount";
            // 
            // txtTotalDuration
            // 
            this.txtTotalDuration.Enabled = false;
            this.txtTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDuration.Location = new System.Drawing.Point(174, 28);
            this.txtTotalDuration.Name = "txtTotalDuration";
            this.txtTotalDuration.Size = new System.Drawing.Size(108, 23);
            this.txtTotalDuration.TabIndex = 41;
            // 
            // txtTotalInstallment
            // 
            this.txtTotalInstallment.Enabled = false;
            this.txtTotalInstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalInstallment.Location = new System.Drawing.Point(522, 34);
            this.txtTotalInstallment.Name = "txtTotalInstallment";
            this.txtTotalInstallment.Size = new System.Drawing.Size(100, 23);
            this.txtTotalInstallment.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSaveInstallment);
            this.panel2.Controls.Add(this.txtDayGap);
            this.panel2.Controls.Add(this.txtMonth);
            this.panel2.Controls.Add(this.txtInstallmentAmount);
            this.panel2.Controls.Add(this.btnREmove);
            this.panel2.Controls.Add(this.btnRemoveInstallmnent);
            this.panel2.Controls.Add(this.btnAddInst);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lstInstallments);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 265);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSaveInstallment
            // 
            this.btnSaveInstallment.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveInstallment.FlatAppearance.BorderSize = 0;
            this.btnSaveInstallment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveInstallment.ForeColor = System.Drawing.Color.White;
            this.btnSaveInstallment.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSaveInstallment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveInstallment.Location = new System.Drawing.Point(540, 207);
            this.btnSaveInstallment.Name = "btnSaveInstallment";
            this.btnSaveInstallment.Size = new System.Drawing.Size(92, 33);
            this.btnSaveInstallment.TabIndex = 7;
            this.btnSaveInstallment.Text = "SAVE  ";
            this.btnSaveInstallment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveInstallment.UseVisualStyleBackColor = false;
            this.btnSaveInstallment.Click += new System.EventHandler(this.btnSaveInstallment_Click);
            // 
            // txtDayGap
            // 
            this.txtDayGap.Depth = 0;
            this.txtDayGap.Hint = "Enter Days";
            this.txtDayGap.Location = new System.Drawing.Point(168, 111);
            this.txtDayGap.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDayGap.Name = "txtDayGap";
            this.txtDayGap.PasswordChar = '\0';
            this.txtDayGap.SelectedText = "";
            this.txtDayGap.SelectionLength = 0;
            this.txtDayGap.SelectionStart = 0;
            this.txtDayGap.Size = new System.Drawing.Size(115, 23);
            this.txtDayGap.TabIndex = 3;
            this.txtDayGap.UseSystemPasswordChar = false;
            // 
            // txtMonth
            // 
            this.txtMonth.Depth = 0;
            this.txtMonth.Hint = "Enter Months";
            this.txtMonth.Location = new System.Drawing.Point(168, 72);
            this.txtMonth.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.PasswordChar = '\0';
            this.txtMonth.SelectedText = "";
            this.txtMonth.SelectionLength = 0;
            this.txtMonth.SelectionStart = 0;
            this.txtMonth.Size = new System.Drawing.Size(112, 23);
            this.txtMonth.TabIndex = 2;
            this.txtMonth.UseSystemPasswordChar = false;
            // 
            // txtInstallmentAmount
            // 
            this.txtInstallmentAmount.Depth = 0;
            this.txtInstallmentAmount.Hint = "Enter Amount";
            this.txtInstallmentAmount.Location = new System.Drawing.Point(168, 34);
            this.txtInstallmentAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtInstallmentAmount.Name = "txtInstallmentAmount";
            this.txtInstallmentAmount.PasswordChar = '\0';
            this.txtInstallmentAmount.SelectedText = "";
            this.txtInstallmentAmount.SelectionLength = 0;
            this.txtInstallmentAmount.SelectionStart = 0;
            this.txtInstallmentAmount.Size = new System.Drawing.Size(112, 23);
            this.txtInstallmentAmount.TabIndex = 1;
            this.txtInstallmentAmount.UseSystemPasswordChar = false;
            // 
            // btnREmove
            // 
            this.btnREmove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnREmove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnREmove.BackColor = System.Drawing.Color.White;
            this.btnREmove.Depth = 0;
            this.btnREmove.Location = new System.Drawing.Point(397, 205);
            this.btnREmove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnREmove.Name = "btnREmove";
            this.btnREmove.Primary = true;
            this.btnREmove.Size = new System.Drawing.Size(109, 35);
            this.btnREmove.TabIndex = 6;
            this.btnREmove.Text = "Remove All";
            this.btnREmove.UseVisualStyleBackColor = false;
            this.btnREmove.Click += new System.EventHandler(this.btnREmove_Click);
            // 
            // btnRemoveInstallmnent
            // 
            this.btnRemoveInstallmnent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveInstallmnent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveInstallmnent.BackColor = System.Drawing.Color.White;
            this.btnRemoveInstallmnent.Depth = 0;
            this.btnRemoveInstallmnent.Location = new System.Drawing.Point(324, 100);
            this.btnRemoveInstallmnent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveInstallmnent.Name = "btnRemoveInstallmnent";
            this.btnRemoveInstallmnent.Primary = true;
            this.btnRemoveInstallmnent.Size = new System.Drawing.Size(55, 35);
            this.btnRemoveInstallmnent.TabIndex = 5;
            this.btnRemoveInstallmnent.Text = "delete";
            this.btnRemoveInstallmnent.UseVisualStyleBackColor = false;
            this.btnRemoveInstallmnent.Click += new System.EventHandler(this.btnRemoveInstallmnent_Click);
            // 
            // btnAddInst
            // 
            this.btnAddInst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddInst.BackColor = System.Drawing.Color.White;
            this.btnAddInst.Depth = 0;
            this.btnAddInst.Location = new System.Drawing.Point(324, 53);
            this.btnAddInst.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddInst.Name = "btnAddInst";
            this.btnAddInst.Primary = true;
            this.btnAddInst.Size = new System.Drawing.Size(55, 35);
            this.btnAddInst.TabIndex = 4;
            this.btnAddInst.Text = "add";
            this.btnAddInst.UseVisualStyleBackColor = false;
            this.btnAddInst.Click += new System.EventHandler(this.btnAddInst_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "No. of Months :";
            // 
            // lstInstallments
            // 
            this.lstInstallments.FormattingEnabled = true;
            this.lstInstallments.Location = new System.Drawing.Point(385, 34);
            this.lstInstallments.Name = "lstInstallments";
            this.lstInstallments.Size = new System.Drawing.Size(247, 147);
            this.lstInstallments.TabIndex = 37;
            this.lstInstallments.SelectedIndexChanged += new System.EventHandler(this.lstInstallments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Installment Amount :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "No. of days :";
            // 
            // FrmInstallmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(673, 334);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmInstallmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installment_Details";
            this.Load += new System.EventHandler(this.Installment_Details_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstInstallments;
        private System.Windows.Forms.TextBox txtTotalInstallment;
        private System.Windows.Forms.TextBox txtTotalDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialRaisedButton btnREmove;
        private MaterialSkin.Controls.MaterialRaisedButton btnRemoveInstallmnent;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddInst;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMonth;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtInstallmentAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDayGap;
        private System.Windows.Forms.Button btnSaveInstallment;
    }
}
