namespace ClassManager.WinApp.UICommon
{
    partial class FrmDetailsTran
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
            this.ADGVInstDetails = new ADGV.AdvancedDataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdmissionTxt = new System.Windows.Forms.Label();
            this.AmountTxt = new System.Windows.Forms.Label();
            this.DateTxt = new System.Windows.Forms.Label();
            this.ModeTxt = new System.Windows.Forms.Label();
            this.PAYTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVInstDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // ADGVInstDetails
            // 
            this.ADGVInstDetails.AllowUserToAddRows = false;
            this.ADGVInstDetails.AllowUserToDeleteRows = false;
            this.ADGVInstDetails.AllowUserToResizeRows = false;
            this.ADGVInstDetails.AutoGenerateContextFilters = true;
            this.ADGVInstDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVInstDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVInstDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVInstDetails.DateWithTime = false;
            this.ADGVInstDetails.Location = new System.Drawing.Point(11, 282);
            this.ADGVInstDetails.Name = "ADGVInstDetails";
            this.ADGVInstDetails.ReadOnly = true;
            this.ADGVInstDetails.Size = new System.Drawing.Size(829, 232);
            this.ADGVInstDetails.TabIndex = 348;
            this.ADGVInstDetails.TimeFilter = false;
            this.ADGVInstDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVInstDetails_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(12, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 352;
            this.label6.Text = "Admission No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(11, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 352;
            this.label3.Text = "Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(382, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 352;
            this.label9.Text = "Mode:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(382, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 20);
            this.label10.TabIndex = 352;
            this.label10.Text = "PAY By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 352;
            this.label1.Text = "Amount :";
            // 
            // AdmissionTxt
            // 
            this.AdmissionTxt.AutoSize = true;
            this.AdmissionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdmissionTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.AdmissionTxt.Location = new System.Drawing.Point(140, 124);
            this.AdmissionTxt.Name = "AdmissionTxt";
            this.AdmissionTxt.Size = new System.Drawing.Size(111, 20);
            this.AdmissionTxt.TabIndex = 352;
            this.AdmissionTxt.Text = "Admission_No";
            // 
            // AmountTxt
            // 
            this.AmountTxt.AutoSize = true;
            this.AmountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.AmountTxt.Location = new System.Drawing.Point(140, 175);
            this.AmountTxt.Name = "AmountTxt";
            this.AmountTxt.Size = new System.Drawing.Size(86, 20);
            this.AmountTxt.TabIndex = 352;
            this.AmountTxt.Text = "AmountTxt";
            // 
            // DateTxt
            // 
            this.DateTxt.AutoSize = true;
            this.DateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.DateTxt.Location = new System.Drawing.Point(140, 228);
            this.DateTxt.Name = "DateTxt";
            this.DateTxt.Size = new System.Drawing.Size(97, 20);
            this.DateTxt.TabIndex = 352;
            this.DateTxt.Text = "Account_No";
            // 
            // ModeTxt
            // 
            this.ModeTxt.AutoSize = true;
            this.ModeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ModeTxt.Location = new System.Drawing.Point(499, 125);
            this.ModeTxt.Name = "ModeTxt";
            this.ModeTxt.Size = new System.Drawing.Size(49, 20);
            this.ModeTxt.TabIndex = 352;
            this.ModeTxt.Text = "Mode";
            // 
            // PAYTxt
            // 
            this.PAYTxt.AutoSize = true;
            this.PAYTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAYTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.PAYTxt.Location = new System.Drawing.Point(499, 175);
            this.PAYTxt.Name = "PAYTxt";
            this.PAYTxt.Size = new System.Drawing.Size(54, 20);
            this.PAYTxt.TabIndex = 352;
            this.PAYTxt.Text = "pay by";
            // 
            // FrmDetailsTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 526);
            this.Controls.Add(this.DateTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PAYTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AmountTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdmissionTxt);
            this.Controls.Add(this.ModeTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ADGVInstDetails);
            this.Name = "FrmDetailsTran";
            this.Text = "FrmDetailsTran";
            this.Load += new System.EventHandler(this.FrmDetailsTran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVInstDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView ADGVInstDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AdmissionTxt;
        private System.Windows.Forms.Label AmountTxt;
        private System.Windows.Forms.Label DateTxt;
        private System.Windows.Forms.Label ModeTxt;
        private System.Windows.Forms.Label PAYTxt;
    }
}