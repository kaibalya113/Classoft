namespace ClassManager.WinApp
{
    partial class FrmViewScheduleLect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVScheduledLect = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVScheduledLect)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ADGVScheduledLect);
            this.panel1.Location = new System.Drawing.Point(9, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 235);
            this.panel1.TabIndex = 0;
            // 
            // ADGVScheduledLect
            // 
            this.ADGVScheduledLect.AllowUserToAddRows = false;
            this.ADGVScheduledLect.AllowUserToDeleteRows = false;
            this.ADGVScheduledLect.AllowUserToResizeRows = false;
            this.ADGVScheduledLect.AutoGenerateContextFilters = true;
            this.ADGVScheduledLect.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVScheduledLect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVScheduledLect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVScheduledLect.DateWithTime = false;
            this.ADGVScheduledLect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVScheduledLect.Location = new System.Drawing.Point(0, 0);
            this.ADGVScheduledLect.Name = "ADGVScheduledLect";
            this.ADGVScheduledLect.ReadOnly = true;
            this.ADGVScheduledLect.Size = new System.Drawing.Size(648, 233);
            this.ADGVScheduledLect.TabIndex = 348;
            this.ADGVScheduledLect.TimeFilter = false;
            this.ADGVScheduledLect.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVScheduledLect_DataBindingComplete);
            this.ADGVScheduledLect.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVScheduledLect_RowPostPaint);
            // 
            // FrmViewScheduleLect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 318);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewScheduleLect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmViewScheduleLect_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVScheduledLect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView ADGVScheduledLect;
    }
}