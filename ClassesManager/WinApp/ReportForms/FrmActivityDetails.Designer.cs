namespace ClassManager.WinApp
{
    partial class FrmActivityDetails
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
            this.ActivityGrid = new ADGV.AdvancedDataGridView();
            this.label31 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpReceiptToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReceiptFrmDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.ActShow = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActivityGrid
            // 
            this.ActivityGrid.AllowUserToAddRows = false;
            this.ActivityGrid.AllowUserToDeleteRows = false;
            this.ActivityGrid.AutoGenerateContextFilters = true;
            this.ActivityGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ActivityGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ActivityGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActivityGrid.DateWithTime = false;
            this.ActivityGrid.Location = new System.Drawing.Point(8, 132);
            this.ActivityGrid.Name = "ActivityGrid";
            this.ActivityGrid.ReadOnly = true;
            this.ActivityGrid.Size = new System.Drawing.Size(1029, 343);
            this.ActivityGrid.TabIndex = 347;
            this.ActivityGrid.TimeFilter = false;
            this.ActivityGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActivityGrid_CellContentClick);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label31.Location = new System.Drawing.Point(290, 13);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 20);
            this.label31.TabIndex = 365;
            this.label31.Text = "To Date :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(24, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 20);
            this.label13.TabIndex = 364;
            this.label13.Text = "From Date :";
            // 
            // dtpReceiptToDate
            // 
            this.dtpReceiptToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceiptToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceiptToDate.Location = new System.Drawing.Point(380, 11);
            this.dtpReceiptToDate.Name = "dtpReceiptToDate";
            this.dtpReceiptToDate.Size = new System.Drawing.Size(113, 22);
            this.dtpReceiptToDate.TabIndex = 367;
            this.dtpReceiptToDate.TabStop = false;
            this.dtpReceiptToDate.CloseUp += new System.EventHandler(this.dtpReceiptToDate_CloseUp);
            // 
            // dtpReceiptFrmDate
            // 
            this.dtpReceiptFrmDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceiptFrmDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceiptFrmDate.Location = new System.Drawing.Point(133, 11);
            this.dtpReceiptFrmDate.Name = "dtpReceiptFrmDate";
            this.dtpReceiptFrmDate.Size = new System.Drawing.Size(111, 22);
            this.dtpReceiptFrmDate.TabIndex = 366;
            this.dtpReceiptFrmDate.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btn_saveToPDF);
            this.panel1.Controls.Add(this.ActShow);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dtpReceiptToDate);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.dtpReceiptFrmDate);
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 47);
            this.panel1.TabIndex = 368;
            // 
            // btn_saveToPDF
            // 
            this.btn_saveToPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_saveToPDF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_saveToPDF.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_saveToPDF.FlatAppearance.BorderSize = 0;
            this.btn_saveToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveToPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveToPDF.ForeColor = System.Drawing.Color.White;
            this.btn_saveToPDF.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btn_saveToPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_saveToPDF.Location = new System.Drawing.Point(605, 8);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 369;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // ActShow
            // 
            this.ActShow.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ActShow.FlatAppearance.BorderSize = 0;
            this.ActShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActShow.ForeColor = System.Drawing.Color.White;
            this.ActShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ActShow.Location = new System.Drawing.Point(511, 8);
            this.ActShow.Name = "ActShow";
            this.ActShow.Size = new System.Drawing.Size(61, 33);
            this.ActShow.TabIndex = 368;
            this.ActShow.Text = "SHOW";
            this.ActShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ActShow.UseVisualStyleBackColor = false;
            this.ActShow.Click += new System.EventHandler(this.ActShow_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(738, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 33);
            this.btnExcel.TabIndex = 370;
            this.btnExcel.Text = "SAVE TO";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmActivityDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ActivityGrid);
            this.Name = "FrmActivityDetails";
            this.Text = "FrmActivityDetails";
            this.Load += new System.EventHandler(this.FrmActivityDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActivityGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView ActivityGrid;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpReceiptToDate;
        private System.Windows.Forms.DateTimePicker dtpReceiptFrmDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ActShow;
        private System.Windows.Forms.Button btn_saveToPDF;
        private System.Windows.Forms.Button btnExcel;
    }
}