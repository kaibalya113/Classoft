namespace ClassManager.WinApp
{
    partial class FrmOutstandingDueFollowup
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbViewFollowUp = new System.Windows.Forms.ComboBox();
            this.ADGVDueFollowup = new ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVDueFollowup)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 349;
            this.label2.Text = "View FollowUp:";
            // 
            // cmbViewFollowUp
            // 
            this.cmbViewFollowUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewFollowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewFollowUp.FormattingEnabled = true;
            this.cmbViewFollowUp.Items.AddRange(new object[] {
            "Today\'s Due",
            "Pending Due",
            "Next 1 Week Due"});
            this.cmbViewFollowUp.Location = new System.Drawing.Point(149, 82);
            this.cmbViewFollowUp.Name = "cmbViewFollowUp";
            this.cmbViewFollowUp.Size = new System.Drawing.Size(168, 24);
            this.cmbViewFollowUp.TabIndex = 348;
            this.cmbViewFollowUp.SelectedIndexChanged += new System.EventHandler(this.cmbViewFollowUp_SelectedIndexChanged);
            // 
            // ADGVDueFollowup
            // 
            this.ADGVDueFollowup.AllowUserToAddRows = false;
            this.ADGVDueFollowup.AllowUserToDeleteRows = false;
            this.ADGVDueFollowup.AllowUserToResizeRows = false;
            this.ADGVDueFollowup.AutoGenerateContextFilters = true;
            this.ADGVDueFollowup.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVDueFollowup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVDueFollowup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVDueFollowup.DateWithTime = false;
            this.ADGVDueFollowup.EnableHeadersVisualStyles = false;
            this.ADGVDueFollowup.GridColor = System.Drawing.SystemColors.Control;
            this.ADGVDueFollowup.Location = new System.Drawing.Point(16, 113);
            this.ADGVDueFollowup.Name = "ADGVDueFollowup";
            this.ADGVDueFollowup.ReadOnly = true;
            this.ADGVDueFollowup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVDueFollowup.Size = new System.Drawing.Size(1011, 439);
            this.ADGVDueFollowup.TabIndex = 350;
            this.ADGVDueFollowup.TimeFilter = false;
            this.ADGVDueFollowup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVDueFollowup_CellContentClick);
            // 
            // FrmOutstandingDueFollowup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 585);
            this.Controls.Add(this.ADGVDueFollowup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbViewFollowUp);
            this.Name = "FrmOutstandingDueFollowup";
            this.Text = "Outstanding Due Reminders";
            this.Load += new System.EventHandler(this.FrmOutstandingDueFollowup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVDueFollowup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbViewFollowUp;
        private ADGV.AdvancedDataGridView ADGVDueFollowup;
    }
}