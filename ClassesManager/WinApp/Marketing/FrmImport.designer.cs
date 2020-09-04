namespace ClassManager.WinApp
{
	partial class FrmImport
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveCSVFile = new System.Windows.Forms.SaveFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_preView = new ADGV.AdvancedDataGridView();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelPerc = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave_Direct = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFileToImport = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnDownload = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBrowse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_preView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveCSVFile
            // 
            this.saveCSVFile.CheckPathExists = false;
            this.saveCSVFile.DefaultExt = "csv";
            this.saveCSVFile.DereferenceLinks = false;
            this.saveCSVFile.FileName = "ImportData.csv";
            this.saveCSVFile.Title = "SaveFile";
            this.saveCSVFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveCSVFile_FileOk);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dataGridView_preView);
            this.panel3.Controls.Add(this.labelSpeed);
            this.panel3.Controls.Add(this.labelPerc);
            this.panel3.Controls.Add(this.labelDownloaded);
            this.panel3.Controls.Add(this.txtOwner);
            this.panel3.Controls.Add(this.lblOwner);
            this.panel3.Location = new System.Drawing.Point(12, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 405);
            this.panel3.TabIndex = 17;
            // 
            // dataGridView_preView
            // 
            this.dataGridView_preView.AllowUserToAddRows = false;
            this.dataGridView_preView.AllowUserToDeleteRows = false;
            this.dataGridView_preView.AllowUserToResizeColumns = false;
            this.dataGridView_preView.AllowUserToResizeRows = false;
            this.dataGridView_preView.AutoGenerateContextFilters = true;
            this.dataGridView_preView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_preView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_preView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_preView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_preView.DateWithTime = false;
            this.dataGridView_preView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_preView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_preView.Name = "dataGridView_preView";
            this.dataGridView_preView.ReadOnly = true;
            this.dataGridView_preView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_preView.Size = new System.Drawing.Size(624, 405);
            this.dataGridView_preView.TabIndex = 22;
            this.dataGridView_preView.TimeFilter = false;
            this.dataGridView_preView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_preView_DataBindingComplete);
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.labelSpeed.Location = new System.Drawing.Point(263, 371);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(96, 20);
            this.labelSpeed.TabIndex = 21;
            this.labelSpeed.Text = "Table name:";
            this.labelSpeed.Visible = false;
            // 
            // labelPerc
            // 
            this.labelPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPerc.AutoSize = true;
            this.labelPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.labelPerc.Location = new System.Drawing.Point(365, 371);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(96, 20);
            this.labelPerc.TabIndex = 20;
            this.labelPerc.Text = "Table name:";
            this.labelPerc.Visible = false;
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownloaded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.labelDownloaded.Location = new System.Drawing.Point(161, 371);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(96, 20);
            this.labelDownloaded.TabIndex = 19;
            this.labelDownloaded.Text = "Table name:";
            this.labelDownloaded.Visible = false;
            // 
            // txtOwner
            // 
            this.txtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwner.Location = new System.Drawing.Point(68, 371);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(87, 22);
            this.txtOwner.TabIndex = 19;
            this.txtOwner.Text = "dbo";
            this.txtOwner.Visible = false;
            // 
            // lblOwner
            // 
            this.lblOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOwner.AutoSize = true;
            this.lblOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOwner.Location = new System.Drawing.Point(3, 373);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(59, 20);
            this.lblOwner.TabIndex = 17;
            this.lblOwner.Text = "Owner:";
            this.lblOwner.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnSave_Direct);
            this.panel2.Controls.Add(this.txtTableName);
            this.panel2.Controls.Add(this.lblTableName);
            this.panel2.Controls.Add(this.lblProgress);
            this.panel2.Location = new System.Drawing.Point(12, 578);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 47);
            this.panel2.TabIndex = 16;
            // 
            // btnSave_Direct
            // 
            this.btnSave_Direct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave_Direct.FlatAppearance.BorderSize = 0;
            this.btnSave_Direct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave_Direct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave_Direct.ForeColor = System.Drawing.Color.White;
            this.btnSave_Direct.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSave_Direct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave_Direct.Location = new System.Drawing.Point(509, 6);
            this.btnSave_Direct.Name = "btnSave_Direct";
            this.btnSave_Direct.Size = new System.Drawing.Size(88, 33);
            this.btnSave_Direct.TabIndex = 5;
            this.btnSave_Direct.Text = "SAVE  ";
            this.btnSave_Direct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave_Direct.UseVisualStyleBackColor = false;
            this.btnSave_Direct.Click += new System.EventHandler(this.btnSave_Direct_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTableName.Enabled = false;
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableName.Location = new System.Drawing.Point(377, 6);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(107, 22);
            this.txtTableName.TabIndex = 4;
            this.txtTableName.Text = "Marketing";
            this.txtTableName.Visible = false;
            // 
            // lblTableName
            // 
            this.lblTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTableName.Location = new System.Drawing.Point(275, 8);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(96, 20);
            this.lblTableName.TabIndex = 18;
            this.lblTableName.Text = "Table name:";
            this.lblTableName.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(20, -71);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(113, 16);
            this.lblProgress.TabIndex = 15;
            this.lblProgress.Text = "Imported: 0 row(s)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFileToImport);
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 115);
            this.panel1.TabIndex = 15;
            // 
            // txtFileToImport
            // 
            this.txtFileToImport.Depth = 0;
            this.txtFileToImport.Hint = "Enter URL";
            this.txtFileToImport.Location = new System.Drawing.Point(145, 19);
            this.txtFileToImport.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFileToImport.Name = "txtFileToImport";
            this.txtFileToImport.PasswordChar = '\0';
            this.txtFileToImport.SelectedText = "";
            this.txtFileToImport.SelectionLength = 0;
            this.txtFileToImport.SelectionStart = 0;
            this.txtFileToImport.Size = new System.Drawing.Size(320, 23);
            this.txtFileToImport.TabIndex = 1;
            this.txtFileToImport.UseSystemPasswordChar = false;
            this.txtFileToImport.TextChanged += new System.EventHandler(this.tbFile_TextChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDownload.BackColor = System.Drawing.Color.White;
            this.btnDownload.BackgroundImage = global::ClassManager.Properties.Resources.save_file_button;
            this.btnDownload.Depth = 0;
            this.btnDownload.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(422, 49);
            this.btnDownload.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Primary = true;
            this.btnDownload.Size = new System.Drawing.Size(174, 33);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download Sample";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Depth = 0;
            this.btnBrowse.Location = new System.Drawing.Point(521, 9);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Primary = true;
            this.btnBrowse.Size = new System.Drawing.Size(75, 33);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "CSV file to load:";
            // 
            // FrmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(648, 634);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(527, 515);
            this.Name = "FrmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import CSV";
            this.Load += new System.EventHandler(this.FrmImport_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_preView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelPerc;
        private System.Windows.Forms.Label labelDownloaded;
        private System.Windows.Forms.SaveFileDialog saveCSVFile;
        private MaterialSkin.Controls.MaterialRaisedButton btnDownload;
        private MaterialSkin.Controls.MaterialRaisedButton btnBrowse;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFileToImport;
        private ADGV.AdvancedDataGridView dataGridView_preView;
        private System.Windows.Forms.Button btnSave_Direct;
    }
}
