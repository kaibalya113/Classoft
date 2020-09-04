namespace ClassManager.WinApp
{
    partial class FrmPackagesView
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
            this.ADGVPackage = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewPackage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBranchID = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVPackage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ADGVPackage);
            this.panel2.Location = new System.Drawing.Point(13, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 332);
            this.panel2.TabIndex = 1;
            // 
            // ADGVPackage
            // 
            this.ADGVPackage.AllowUserToAddRows = false;
            this.ADGVPackage.AllowUserToDeleteRows = false;
            this.ADGVPackage.AllowUserToResizeRows = false;
            this.ADGVPackage.AutoGenerateContextFilters = true;
            this.ADGVPackage.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVPackage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVPackage.DateWithTime = false;
            this.ADGVPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVPackage.Location = new System.Drawing.Point(0, 0);
            this.ADGVPackage.Name = "ADGVPackage";
            this.ADGVPackage.ReadOnly = true;
            this.ADGVPackage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ADGVPackage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVPackage.Size = new System.Drawing.Size(886, 332);
            this.ADGVPackage.TabIndex = 16;
            this.ADGVPackage.TimeFilter = false;
            this.ADGVPackage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVPackage_CellClick);
            this.ADGVPackage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVPackage_DataBindingComplete);
            this.ADGVPackage.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVPackage_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNewPackage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkBranchID);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(13, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 126);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(394, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewPackage
            // 
            this.btnNewPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPackage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewPackage.BackColor = System.Drawing.Color.White;
            this.btnNewPackage.Depth = 0;
            this.btnNewPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPackage.Location = new System.Drawing.Point(504, 49);
            this.btnNewPackage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewPackage.Name = "btnNewPackage";
            this.btnNewPackage.Primary = true;
            this.btnNewPackage.Size = new System.Drawing.Size(110, 34);
            this.btnNewPackage.TabIndex = 4;
            this.btnNewPackage.Text = "New PAckage";
            this.btnNewPackage.UseVisualStyleBackColor = false;
            this.btnNewPackage.Click += new System.EventHandler(this.btnNewPackage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Filter By :";
            // 
            // chkBranchID
            // 
            this.chkBranchID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBranchID.AutoSize = true;
            this.chkBranchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBranchID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkBranchID.Location = new System.Drawing.Point(404, 6);
            this.chkBranchID.Name = "chkBranchID";
            this.chkBranchID.Size = new System.Drawing.Size(200, 24);
            this.chkBranchID.TabIndex = 2;
            this.chkBranchID.Text = "Show All Branches Data";
            this.chkBranchID.UseVisualStyleBackColor = true;
            this.chkBranchID.CheckedChanged += new System.EventHandler(this.chkBranchID_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(17, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(301, 75);
            this.panel3.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Depth = 0;
            this.textBox1.Hint = "Enter Package Name";
            this.textBox1.Location = new System.Drawing.Point(139, 23);
            this.textBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.Size = new System.Drawing.Size(157, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(3, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 20);
            this.label14.TabIndex = 54;
            this.label14.Text = "Package Name :";
            // 
            // FrmPackagesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 555);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmPackagesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Package";
            this.Load += new System.EventHandler(this.ShowPackage_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVPackage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBranchID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView ADGVPackage;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton btnNewPackage;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox1;
        private System.Windows.Forms.Button btnSave;
    }
}
