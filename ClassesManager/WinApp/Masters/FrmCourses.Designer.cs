namespace ClassManager.WinApp
{
    partial class FrmCourses
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewCourse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCrseNm = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.chkBranchID = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVCourses = new ADGV.AdvancedDataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnNewCourse);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.chkBranchID);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 129);
            this.panel2.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(398, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewCourse
            // 
            this.btnNewCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCourse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewCourse.BackColor = System.Drawing.Color.White;
            this.btnNewCourse.Depth = 0;
            this.btnNewCourse.Location = new System.Drawing.Point(514, 56);
            this.btnNewCourse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewCourse.Name = "btnNewCourse";
            this.btnNewCourse.Primary = true;
            this.btnNewCourse.Size = new System.Drawing.Size(100, 33);
            this.btnNewCourse.TabIndex = 3;
            this.btnNewCourse.Text = "New Course";
            this.btnNewCourse.UseVisualStyleBackColor = false;
            this.btnNewCourse.Click += new System.EventHandler(this.btnNewCourse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Filter By :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtCrseNm);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(12, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 70);
            this.panel3.TabIndex = 56;
            // 
            // txtCrseNm
            // 
            this.txtCrseNm.Depth = 0;
            this.txtCrseNm.Hint = "Enter Couse Name";
            this.txtCrseNm.Location = new System.Drawing.Point(147, 22);
            this.txtCrseNm.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCrseNm.Name = "txtCrseNm";
            this.txtCrseNm.PasswordChar = '\0';
            this.txtCrseNm.SelectedText = "";
            this.txtCrseNm.SelectionLength = 0;
            this.txtCrseNm.SelectionStart = 0;
            this.txtCrseNm.Size = new System.Drawing.Size(159, 23);
            this.txtCrseNm.TabIndex = 1;
            this.txtCrseNm.TabStop = false;
            this.txtCrseNm.UseSystemPasswordChar = false;
            this.txtCrseNm.TextChanged += new System.EventHandler(this.txtCrseNm_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(19, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 18);
            this.label14.TabIndex = 54;
            this.label14.Text = "Course Name :";
            // 
            // chkBranchID
            // 
            this.chkBranchID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBranchID.AutoSize = true;
            this.chkBranchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBranchID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkBranchID.Location = new System.Drawing.Point(398, 7);
            this.chkBranchID.Name = "chkBranchID";
            this.chkBranchID.Size = new System.Drawing.Size(216, 24);
            this.chkBranchID.TabIndex = 4;
            this.chkBranchID.Text = "Show All Branches Course";
            this.chkBranchID.UseVisualStyleBackColor = true;
            this.chkBranchID.CheckedChanged += new System.EventHandler(this.chkBranchID_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ADGVCourses);
            this.panel1.Location = new System.Drawing.Point(12, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 274);
            this.panel1.TabIndex = 17;
            // 
            // ADGVCourses
            // 
            this.ADGVCourses.AllowUserToAddRows = false;
            this.ADGVCourses.AutoGenerateContextFilters = true;
            this.ADGVCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVCourses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVCourses.DateWithTime = false;
            this.ADGVCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVCourses.Location = new System.Drawing.Point(0, 0);
            this.ADGVCourses.Name = "ADGVCourses";
            this.ADGVCourses.ReadOnly = true;
            this.ADGVCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVCourses.Size = new System.Drawing.Size(636, 274);
            this.ADGVCourses.TabIndex = 16;
            this.ADGVCourses.TimeFilter = false;
            this.ADGVCourses.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVCourses_DataBindingComplete);
            this.ADGVCourses.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVCourses_RowPostPaint);
            // 
            // FrmCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "FrmCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Courses";
            this.Load += new System.EventHandler(this.ShowAllCourses_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


       private System.Windows.Forms.DataGridViewTextBoxColumn courseIdDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn courseTypeDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn courseDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn standardidDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn standardDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn streamDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn subjectListDataGridViewTextBoxColumn;
 
       private System.Windows.Forms.DataGridViewTextBoxColumn couseIdDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
       private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
       private System.Windows.Forms.DataGridViewTextBoxColumn durationInMonthsDataGridViewTextBoxColumn;
       private System.Windows.Forms.Panel panel2;
       private System.Windows.Forms.CheckBox chkBranchID;
       private System.Windows.Forms.Label label1;
       private System.Windows.Forms.Label label14;
       private System.Windows.Forms.Panel panel1;
       private ADGV.AdvancedDataGridView ADGVCourses;
       private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialRaisedButton btnNewCourse;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCrseNm;
        private System.Windows.Forms.Button btnSave;
    }
}
