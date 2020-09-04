namespace ClassManager.WinApp
{
    partial class FrmViewSub
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
            this.ADGViewSubject = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCrtSub = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkShowAllBranch = new System.Windows.Forms.CheckBox();
            this.cmbCrse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStrm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGViewSubject)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ADGViewSubject);
            this.panel2.Location = new System.Drawing.Point(11, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 370);
            this.panel2.TabIndex = 3;
            // 
            // ADGViewSubject
            // 
            this.ADGViewSubject.AllowUserToAddRows = false;
            this.ADGViewSubject.AllowUserToDeleteRows = false;
            this.ADGViewSubject.AllowUserToResizeColumns = false;
            this.ADGViewSubject.AllowUserToResizeRows = false;
            this.ADGViewSubject.AutoGenerateContextFilters = true;
            this.ADGViewSubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGViewSubject.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGViewSubject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGViewSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGViewSubject.DateWithTime = false;
            this.ADGViewSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGViewSubject.Location = new System.Drawing.Point(0, 0);
            this.ADGViewSubject.Name = "ADGViewSubject";
            this.ADGViewSubject.ReadOnly = true;
            this.ADGViewSubject.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ADGViewSubject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGViewSubject.Size = new System.Drawing.Size(892, 370);
            this.ADGViewSubject.TabIndex = 2;
            this.ADGViewSubject.TimeFilter = false;
            this.ADGViewSubject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGViewSubject_CellContentClick);
            this.ADGViewSubject.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGViewSubject_DataBindingComplete);
            this.ADGViewSubject.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGViewSubject_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCrtSub);
            this.panel1.Controls.Add(this.chkShowAllBranch);
            this.panel1.Controls.Add(this.cmbCrse);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbStrm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 115);
            this.panel1.TabIndex = 2;
            // 
            // btnCrtSub
            // 
            this.btnCrtSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrtSub.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCrtSub.BackColor = System.Drawing.Color.White;
            this.btnCrtSub.Depth = 0;
            this.btnCrtSub.Location = new System.Drawing.Point(726, 68);
            this.btnCrtSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCrtSub.Name = "btnCrtSub";
            this.btnCrtSub.Primary = true;
            this.btnCrtSub.Size = new System.Drawing.Size(130, 33);
            this.btnCrtSub.TabIndex = 4;
            this.btnCrtSub.Text = "Create Subject";
            this.btnCrtSub.UseVisualStyleBackColor = false;
            this.btnCrtSub.Click += new System.EventHandler(this.btnCrtSub_Click);
            // 
            // chkShowAllBranch
            // 
            this.chkShowAllBranch.AutoSize = true;
            this.chkShowAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAllBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkShowAllBranch.Location = new System.Drawing.Point(694, 28);
            this.chkShowAllBranch.Name = "chkShowAllBranch";
            this.chkShowAllBranch.Size = new System.Drawing.Size(183, 24);
            this.chkShowAllBranch.TabIndex = 3;
            this.chkShowAllBranch.Text = "View For All Branches";
            this.chkShowAllBranch.UseVisualStyleBackColor = true;
            this.chkShowAllBranch.Visible = false;
            this.chkShowAllBranch.CheckedChanged += new System.EventHandler(this.chkShowAllBranch_CheckedChanged);
            // 
            // cmbCrse
            // 
            this.cmbCrse.BackColor = System.Drawing.Color.White;
            this.cmbCrse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCrse.FormattingEnabled = true;
            this.cmbCrse.Location = new System.Drawing.Point(441, 36);
            this.cmbCrse.Name = "cmbCrse";
            this.cmbCrse.Size = new System.Drawing.Size(175, 24);
            this.cmbCrse.TabIndex = 2;
            this.cmbCrse.SelectedIndexChanged += new System.EventHandler(this.cmbCrse_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(370, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Course : ";
            // 
            // cmbStrm
            // 
            this.cmbStrm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStrm.FormattingEnabled = true;
            this.cmbStrm.Location = new System.Drawing.Point(95, 36);
            this.cmbStrm.Name = "cmbStrm";
            this.cmbStrm.Size = new System.Drawing.Size(194, 24);
            this.cmbStrm.TabIndex = 1;
            this.cmbStrm.SelectedIndexChanged += new System.EventHandler(this.cmbStrm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(26, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stream : ";
            // 
            // FrmViewSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(918, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Faculty-Subjects";
            this.Load += new System.EventHandler(this.ViewSubjects_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGViewSubject)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbStrm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCrse;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView ADGViewSubject;
        private System.Windows.Forms.CheckBox chkShowAllBranch;
        private MaterialSkin.Controls.MaterialRaisedButton btnCrtSub;
    }
}
