namespace ClassManager.WinApp
{
    partial class FrmViewDeleteFacilities
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
            this.ADGVDeletePack = new ADGV.AdvancedDataGridView();
            this.lblCnclFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVDeletePack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ADGVDeletePack);
            this.panel1.Location = new System.Drawing.Point(14, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 303);
            this.panel1.TabIndex = 0;
            // 
            // ADGVDeletePack
            // 
            this.ADGVDeletePack.AllowUserToAddRows = false;
            this.ADGVDeletePack.AllowUserToDeleteRows = false;
            this.ADGVDeletePack.AllowUserToResizeColumns = false;
            this.ADGVDeletePack.AllowUserToResizeRows = false;
            this.ADGVDeletePack.AutoGenerateContextFilters = true;
            this.ADGVDeletePack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVDeletePack.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVDeletePack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVDeletePack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVDeletePack.DateWithTime = false;
            this.ADGVDeletePack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVDeletePack.Location = new System.Drawing.Point(0, 0);
            this.ADGVDeletePack.Name = "ADGVDeletePack";
            this.ADGVDeletePack.ReadOnly = true;
            this.ADGVDeletePack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ADGVDeletePack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVDeletePack.Size = new System.Drawing.Size(733, 301);
            this.ADGVDeletePack.TabIndex = 3;
            this.ADGVDeletePack.TimeFilter = false;
            this.ADGVDeletePack.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVDeletePack_DataBindingComplete);
            // 
            // lblCnclFees
            // 
            this.lblCnclFees.AutoSize = true;
            this.lblCnclFees.BackColor = System.Drawing.Color.White;
            this.lblCnclFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnclFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCnclFees.Location = new System.Drawing.Point(395, 87);
            this.lblCnclFees.Name = "lblCnclFees";
            this.lblCnclFees.Size = new System.Drawing.Size(19, 20);
            this.lblCnclFees.TabIndex = 75;
            this.lblCnclFees.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(203, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 20);
            this.label9.TabIndex = 74;
            this.label9.Text = "Total Cancelled Amount :";
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
            this.btnExcel.Location = new System.Drawing.Point(572, 87);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 33);
            this.btnExcel.TabIndex = 372;
            this.btnExcel.Text = "SAVE TO";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            this.btn_saveToPDF.Location = new System.Drawing.Point(673, 87);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 371;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // FrmViewDeleteFacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 442);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btn_saveToPDF);
            this.Controls.Add(this.lblCnclFees);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewDeleteFacilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deleted Packages";
            this.Load += new System.EventHandler(this.FrmViewDeleteFacilities_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVDeletePack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView ADGVDeletePack;
        private System.Windows.Forms.Label lblCnclFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btn_saveToPDF;
    }
}