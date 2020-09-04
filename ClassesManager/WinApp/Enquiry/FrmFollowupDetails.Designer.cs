namespace ClassManager.WinApp
{
    partial class FrmFollowupDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.lblGropBy = new System.Windows.Forms.Label();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbViewFollowUp = new System.Windows.Forms.ComboBox();
            this.dtFrmDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ADGVFollowupDetails = new ADGV.AdvancedDataGridView();
            this.SGView = new ClassManager.WinApp.UICommon.SuperGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVFollowupDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SGView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 68);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.SGView);
            this.splitContainer1.Panel2.Controls.Add(this.ADGVFollowupDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1044, 543);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbGroupBy);
            this.panel2.Controls.Add(this.lblGropBy);
            this.panel2.Controls.Add(this.btn_saveToPDF);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dtToDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbViewFollowUp);
            this.panel2.Controls.Add(this.dtFrmDate);
            this.panel2.Location = new System.Drawing.Point(12, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 60);
            this.panel2.TabIndex = 45;
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Items.AddRange(new object[] {
            "Counselor"});
            this.cmbGroupBy.Location = new System.Drawing.Point(736, 22);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(137, 28);
            this.cmbGroupBy.TabIndex = 371;
            this.cmbGroupBy.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy_SelectedIndexChanged);
            // 
            // lblGropBy
            // 
            this.lblGropBy.AutoSize = true;
            this.lblGropBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGropBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblGropBy.Location = new System.Drawing.Point(633, 21);
            this.lblGropBy.Name = "lblGropBy";
            this.lblGropBy.Size = new System.Drawing.Size(84, 20);
            this.lblGropBy.TabIndex = 372;
            this.lblGropBy.Text = "Group By :";
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
            this.btn_saveToPDF.Location = new System.Drawing.Point(894, 19);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 370;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(162, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 70;
            this.label5.Text = "To :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(8, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 71;
            this.label9.Text = "From :";
            // 
            // dtToDate
            // 
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(203, 20);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(108, 22);
            this.dtToDate.TabIndex = 4;
            this.dtToDate.CloseUp += new System.EventHandler(this.dtToDate_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(327, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "View FollowUp:";
            // 
            // cmbViewFollowUp
            // 
            this.cmbViewFollowUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewFollowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewFollowUp.FormattingEnabled = true;
            this.cmbViewFollowUp.Location = new System.Drawing.Point(450, 20);
            this.cmbViewFollowUp.Name = "cmbViewFollowUp";
            this.cmbViewFollowUp.Size = new System.Drawing.Size(156, 24);
            this.cmbViewFollowUp.TabIndex = 2;
            this.cmbViewFollowUp.SelectedIndexChanged += new System.EventHandler(this.cmbViewFollowUp_SelectedIndexChanged);
            // 
            // dtFrmDate
            // 
            this.dtFrmDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrmDate.Location = new System.Drawing.Point(68, 22);
            this.dtFrmDate.Name = "dtFrmDate";
            this.dtFrmDate.Size = new System.Drawing.Size(88, 22);
            this.dtFrmDate.TabIndex = 3;
            this.dtFrmDate.CloseUp += new System.EventHandler(this.dtFrmDate_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Filter By";
            // 
            // ADGVFollowupDetails
            // 
            this.ADGVFollowupDetails.AllowUserToAddRows = false;
            this.ADGVFollowupDetails.AllowUserToDeleteRows = false;
            this.ADGVFollowupDetails.AllowUserToResizeRows = false;
            this.ADGVFollowupDetails.AutoGenerateContextFilters = true;
            this.ADGVFollowupDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVFollowupDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ADGVFollowupDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVFollowupDetails.DateWithTime = false;
            this.ADGVFollowupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVFollowupDetails.EnableHeadersVisualStyles = false;
            this.ADGVFollowupDetails.GridColor = System.Drawing.SystemColors.Control;
            this.ADGVFollowupDetails.Location = new System.Drawing.Point(0, 0);
            this.ADGVFollowupDetails.Name = "ADGVFollowupDetails";
            this.ADGVFollowupDetails.ReadOnly = true;
            this.ADGVFollowupDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVFollowupDetails.Size = new System.Drawing.Size(1042, 439);
            this.ADGVFollowupDetails.TabIndex = 1;
            this.ADGVFollowupDetails.TimeFilter = false;
            this.ADGVFollowupDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVFollowupDetails_CellContentClick);
            // 
            // SGView
            // 
            this.SGView.AllowUserToAddRows = false;
            this.SGView.AutoGenerateContextFilters = true;
            this.SGView.BackgroundColor = System.Drawing.Color.White;
            this.SGView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SGView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SGView.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SGView.DefaultCellStyle = dataGridViewCellStyle2;
            this.SGView.Location = new System.Drawing.Point(616, 0);
            this.SGView.Name = "SGView";
            this.SGView.PageSize = 10;
            this.SGView.ReadOnly = true;
            this.SGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SGView.Size = new System.Drawing.Size(423, 330);
            this.SGView.TabIndex = 6;
            this.SGView.TimeFilter = false;
            this.SGView.Visible = false;
            // 
            // FrmFollowupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1158, 623);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmFollowupDetails";
            this.Text = "FrmFollowupDetails";
            this.Load += new System.EventHandler(this.FrmFollowupDetails_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVFollowupDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SGView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbViewFollowUp;
        private System.Windows.Forms.Label label1;
        private ADGV.AdvancedDataGridView ADGVFollowupDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFrmDate;
        private System.Windows.Forms.Button btn_saveToPDF;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.Label lblGropBy;
        private UICommon.SuperGrid SGView;
    }
}
