namespace ClassManager.WinApp
{
    partial class FrmPackagePopup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVInstDetails = new ADGV.AdvancedDataGridView();
            this.lbltotlPaid = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.lbldiscount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblPending = new System.Windows.Forms.Label();
            this.lblcancelAmt = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVInstDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ADGVInstDetails);
            this.panel1.Location = new System.Drawing.Point(12, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 235);
            this.panel1.TabIndex = 348;
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
            this.ADGVInstDetails.Location = new System.Drawing.Point(3, 0);
            this.ADGVInstDetails.Name = "ADGVInstDetails";
            this.ADGVInstDetails.ReadOnly = true;
            this.ADGVInstDetails.Size = new System.Drawing.Size(829, 232);
            this.ADGVInstDetails.TabIndex = 347;
            this.ADGVInstDetails.TimeFilter = false;
            this.ADGVInstDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVInstDetails_DataBindingComplete);
            // 
            // lbltotlPaid
            // 
            this.lbltotlPaid.AutoSize = true;
            this.lbltotlPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotlPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lbltotlPaid.Location = new System.Drawing.Point(592, 79);
            this.lbltotlPaid.Name = "lbltotlPaid";
            this.lbltotlPaid.Size = new System.Drawing.Size(74, 18);
            this.lbltotlPaid.TabIndex = 398;
            this.lbltotlPaid.Text = "totalPaid";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label65.Location = new System.Drawing.Point(484, 79);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(80, 18);
            this.label65.TabIndex = 397;
            this.label65.Text = "Total paid :";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTotalFees.Location = new System.Drawing.Point(297, 79);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(73, 18);
            this.lblTotalFees.TabIndex = 396;
            this.lblTotalFees.Text = "totalfees";
            this.lblTotalFees.Click += new System.EventHandler(this.lblTotalFees_Click);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label67.Location = new System.Drawing.Point(186, 79);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(86, 18);
            this.label67.TabIndex = 395;
            this.label67.Text = "Total Fees :";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label61.Location = new System.Drawing.Point(186, 114);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(112, 18);
            this.label61.TabIndex = 395;
            this.label61.Text = "Total Discount :";
            // 
            // lbldiscount
            // 
            this.lbldiscount.AutoSize = true;
            this.lbldiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lbldiscount.Location = new System.Drawing.Point(297, 114);
            this.lbldiscount.Name = "lbldiscount";
            this.lbldiscount.Size = new System.Drawing.Size(72, 18);
            this.lbldiscount.TabIndex = 394;
            this.lbldiscount.Text = "discount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(484, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 400;
            this.label1.Text = "Total Pending:";
            // 
            // LblPending
            // 
            this.LblPending.AutoSize = true;
            this.LblPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.LblPending.Location = new System.Drawing.Point(592, 114);
            this.LblPending.Name = "LblPending";
            this.LblPending.Size = new System.Drawing.Size(68, 18);
            this.LblPending.TabIndex = 399;
            this.LblPending.Text = "Pending";
            // 
            // lblcancelAmt
            // 
            this.lblcancelAmt.AutoSize = true;
            this.lblcancelAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcancelAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblcancelAmt.Location = new System.Drawing.Point(284, 154);
            this.lblcancelAmt.Name = "lblcancelAmt";
            this.lblcancelAmt.Size = new System.Drawing.Size(85, 18);
            this.lblcancelAmt.TabIndex = 399;
            this.lblcancelAmt.Text = "cncldFees";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label59.Location = new System.Drawing.Point(191, 154);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(81, 18);
            this.label59.TabIndex = 398;
            this.label59.Text = "Cancelled :";
            // 
            // FrmPackagePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 429);
            this.Controls.Add(this.lblcancelAmt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.LblPending);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.lbldiscount);
            this.Controls.Add(this.lbltotlPaid);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.lblTotalFees);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmPackagePopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPackagePopup_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVInstDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView ADGVInstDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltotlPaid;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label lbldiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblPending;
        private System.Windows.Forms.Label lblcancelAmt;
        private System.Windows.Forms.Label label59;
    }
}