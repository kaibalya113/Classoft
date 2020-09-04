namespace ClassManager.WinApp
{
    partial class FrmCollegeMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtClgName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAddClg = new System.Windows.Forms.Button();
            this.grdClgs = new System.Windows.Forms.DataGridView();
            this.txtStandards = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdClgs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "College Name";
            // 
            // txtClgName
            // 
            this.txtClgName.Location = new System.Drawing.Point(105, 21);
            this.txtClgName.Name = "txtClgName";
            this.txtClgName.Size = new System.Drawing.Size(329, 20);
            this.txtClgName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Existing Colleges";
            // 
            // cmdAddClg
            // 
            this.cmdAddClg.Location = new System.Drawing.Point(359, 101);
            this.cmdAddClg.Name = "cmdAddClg";
            this.cmdAddClg.Size = new System.Drawing.Size(75, 23);
            this.cmdAddClg.TabIndex = 3;
            this.cmdAddClg.Text = "Add College";
            this.cmdAddClg.UseVisualStyleBackColor = true;
            this.cmdAddClg.Click += new System.EventHandler(this.cmdAddClg_Click);
            // 
            // grdClgs
            // 
            this.grdClgs.AllowUserToAddRows = false;
            this.grdClgs.AllowUserToDeleteRows = false;
            this.grdClgs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdClgs.BackgroundColor = System.Drawing.Color.White;
            this.grdClgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdClgs.Location = new System.Drawing.Point(12, 169);
            this.grdClgs.Name = "grdClgs";
            this.grdClgs.ReadOnly = true;
            this.grdClgs.Size = new System.Drawing.Size(422, 150);
            this.grdClgs.TabIndex = 4;
            // 
            // txtStandards
            // 
            this.txtStandards.Location = new System.Drawing.Point(105, 59);
            this.txtStandards.Name = "txtStandards";
            this.txtStandards.Size = new System.Drawing.Size(329, 20);
            this.txtStandards.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Standards";
            // 
            // FrmCollegeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 332);
            this.Controls.Add(this.txtStandards);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grdClgs);
            this.Controls.Add(this.cmdAddClg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClgName);
            this.Controls.Add(this.label1);
            this.Name = "FrmCollegeMaster";
            this.Text = "CollegeMaster";
            this.Load += new System.EventHandler(this.CollegeMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdClgs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClgName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAddClg;
        private System.Windows.Forms.DataGridView grdClgs;
        private System.Windows.Forms.TextBox txtStandards;
        private System.Windows.Forms.Label label3;
    }
}
