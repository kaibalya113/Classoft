namespace ClassManager.WinApp
{
    partial class FrmManual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVManual = new ADGV.AdvancedDataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Get = new System.Windows.Forms.DataGridViewLinkColumn();
            this.savePDF = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVManual)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ADGVManual);
            this.panel1.Location = new System.Drawing.Point(10, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 285);
            this.panel1.TabIndex = 1;
            // 
            // ADGVManual
            // 
            this.ADGVManual.AllowUserToAddRows = false;
            this.ADGVManual.AllowUserToDeleteRows = false;
            this.ADGVManual.AllowUserToResizeColumns = false;
            this.ADGVManual.AllowUserToResizeRows = false;
            this.ADGVManual.AutoGenerateContextFilters = true;
            this.ADGVManual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVManual.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVManual.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVManual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVManual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.File,
            this.Get});
            this.ADGVManual.DateWithTime = false;
            this.ADGVManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVManual.EnableHeadersVisualStyles = false;
            this.ADGVManual.GridColor = System.Drawing.SystemColors.Control;
            this.ADGVManual.Location = new System.Drawing.Point(0, 0);
            this.ADGVManual.Name = "ADGVManual";
            this.ADGVManual.ReadOnly = true;
            this.ADGVManual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ADGVManual.Size = new System.Drawing.Size(581, 285);
            this.ADGVManual.TabIndex = 2;
            this.ADGVManual.TimeFilter = false;
            this.ADGVManual.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVManual_CellClick);
            // 
            // SrNo
            // 
            this.SrNo.HeaderText = "Sr.No";
            this.SrNo.MinimumWidth = 22;
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            this.SrNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SrNo.Width = 72;
            // 
            // File
            // 
            this.File.HeaderText = "File";
            this.File.MinimumWidth = 22;
            this.File.Name = "File";
            this.File.ReadOnly = true;
            this.File.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.File.Width = 59;
            // 
            // Get
            // 
            dataGridViewCellStyle2.NullValue = "Download";
            this.Get.DefaultCellStyle = dataGridViewCellStyle2;
            this.Get.HeaderText = "Get";
            this.Get.MinimumWidth = 22;
            this.Get.Name = "Get";
            this.Get.ReadOnly = true;
            this.Get.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Get.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Get.Width = 57;
            // 
            // savePDF
            // 
            this.savePDF.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // FrmManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 372);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual";
            this.Load += new System.EventHandler(this.FrmManual_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVManual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView ADGVManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewLinkColumn Get;
        private System.Windows.Forms.SaveFileDialog savePDF;
    }
}