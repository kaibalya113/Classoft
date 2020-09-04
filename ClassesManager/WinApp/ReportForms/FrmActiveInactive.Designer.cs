namespace ClassManager.WinApp
{
    partial class FrmActiveInactive
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.grid = new ADGV.AdvancedDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpAttdFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpAttdToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.lblText = new MaterialSkin.Controls.MaterialLabel();
            this.txtFname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSearchby = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(10, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 453);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grid);
            this.panel4.Location = new System.Drawing.Point(3, 107);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(918, 341);
            this.panel4.TabIndex = 14;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoGenerateContextFilters = true;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.DateWithTime = false;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(918, 341);
            this.grid.TabIndex = 9;
            this.grid.TimeFilter = false;
            this.grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grid_DataBindingComplete);
            this.grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_RowPostPaint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_saveToPDF);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpAttdFromDate);
            this.panel2.Controls.Add(this.dtpAttdToDate);
            this.panel2.Controls.Add(this.btnSaveToExcel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblSearchby);
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 98);
            this.panel2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(584, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 428;
            this.label8.Text = "From Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(593, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 429;
            this.label3.Text = "To Date :";
            // 
            // dtpAttdFromDate
            // 
            this.dtpAttdFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAttdFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttdFromDate.Location = new System.Drawing.Point(695, 33);
            this.dtpAttdFromDate.Name = "dtpAttdFromDate";
            this.dtpAttdFromDate.Size = new System.Drawing.Size(100, 22);
            this.dtpAttdFromDate.TabIndex = 426;
            this.dtpAttdFromDate.CloseUp += new System.EventHandler(this.dtpAttdFromDate_CloseUp);
            this.dtpAttdFromDate.ValueChanged += new System.EventHandler(this.dtpAttdFromDate_ValueChanged);
            // 
            // dtpAttdToDate
            // 
            this.dtpAttdToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAttdToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttdToDate.Location = new System.Drawing.Point(695, 61);
            this.dtpAttdToDate.Name = "dtpAttdToDate";
            this.dtpAttdToDate.Size = new System.Drawing.Size(100, 22);
            this.dtpAttdToDate.TabIndex = 427;
            this.dtpAttdToDate.CloseUp += new System.EventHandler(this.dtpAttdToDate_CloseUp);
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveToExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveToExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveToExcel.FlatAppearance.BorderSize = 0;
            this.btnSaveToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToExcel.ForeColor = System.Drawing.Color.White;
            this.btnSaveToExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveToExcel.Location = new System.Drawing.Point(808, 52);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(95, 31);
            this.btnSaveToExcel.TabIndex = 5;
            this.btnSaveToExcel.Text = "SAVE TO";
            this.btnSaveToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.UseVisualStyleBackColor = false;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbFilterBy);
            this.panel3.Controls.Add(this.lblText);
            this.panel3.Controls.Add(this.txtFname);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(7, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 60);
            this.panel3.TabIndex = 66;
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Active and Not Present",
            "Expired and Active"});
            this.cmbFilterBy.Location = new System.Drawing.Point(80, 13);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(200, 24);
            this.cmbFilterBy.TabIndex = 1;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Depth = 0;
            this.lblText.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblText.Location = new System.Drawing.Point(3, 13);
            this.lblText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(71, 19);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Filter By :";
            // 
            // txtFname
            // 
            this.txtFname.Depth = 0;
            this.txtFname.Hint = "Enter Name";
            this.txtFname.Location = new System.Drawing.Point(384, 13);
            this.txtFname.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFname.Name = "txtFname";
            this.txtFname.PasswordChar = '\0';
            this.txtFname.SelectedText = "";
            this.txtFname.SelectionLength = 0;
            this.txtFname.SelectionStart = 0;
            this.txtFname.Size = new System.Drawing.Size(166, 23);
            this.txtFname.TabIndex = 2;
            this.txtFname.UseSystemPasswordChar = false;
            this.txtFname.TextChanged += new System.EventHandler(this.txtFname_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(319, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "Name :";
            // 
            // lblSearchby
            // 
            this.lblSearchby.AutoSize = true;
            this.lblSearchby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblSearchby.Location = new System.Drawing.Point(3, 0);
            this.lblSearchby.Name = "lblSearchby";
            this.lblSearchby.Size = new System.Drawing.Size(101, 20);
            this.lblSearchby.TabIndex = 65;
            this.lblSearchby.Text = "Search By :";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(617, 3);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
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
            this.btn_saveToPDF.Location = new System.Drawing.Point(801, 3);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 372;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // FrmActiveInactive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 543);
            this.Controls.Add(this.panel1);
            this.Name = "FrmActiveInactive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmActiveInactive";
            this.Load += new System.EventHandler(this.FrmActiveInactive_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private MaterialSkin.Controls.MaterialLabel lblText;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFname;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSearchby;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Panel panel4;
        private ADGV.AdvancedDataGridView grid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpAttdFromDate;
        private System.Windows.Forms.DateTimePicker dtpAttdToDate;
        private System.Windows.Forms.Button btn_saveToPDF;
    }
}