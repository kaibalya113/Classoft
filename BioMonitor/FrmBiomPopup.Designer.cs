namespace ClassManager.BioMonitor
{
    partial class FrmBiomPopup
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
            this.panelpopup = new System.Windows.Forms.Panel();
            this.lblOutfees = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPackage = new System.Windows.Forms.Label();
            this.PbPhoto = new System.Windows.Forms.PictureBox();
            this.btnprev = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblattendencecount = new System.Windows.Forms.Label();
            this.btnMachineName = new System.Windows.Forms.Button();
            this.panelpopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelpopup
            // 
            this.panelpopup.AutoScroll = true;
            this.panelpopup.BackColor = System.Drawing.Color.Transparent;
            this.panelpopup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelpopup.Controls.Add(this.btnMachineName);
            this.panelpopup.Controls.Add(this.lblOutfees);
            this.panelpopup.Controls.Add(this.lblName);
            this.panelpopup.Controls.Add(this.lblPackage);
            this.panelpopup.Controls.Add(this.PbPhoto);
            this.panelpopup.Location = new System.Drawing.Point(8, 12);
            this.panelpopup.Name = "panelpopup";
            this.panelpopup.Size = new System.Drawing.Size(594, 228);
            this.panelpopup.TabIndex = 0;
            // 
            // lblOutfees
            // 
            this.lblOutfees.AutoSize = true;
            this.lblOutfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutfees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOutfees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOutfees.Location = new System.Drawing.Point(145, 13);
            this.lblOutfees.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblOutfees.Name = "lblOutfees";
            this.lblOutfees.Size = new System.Drawing.Size(0, 20);
            this.lblOutfees.TabIndex = 78;
            this.lblOutfees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(-1, 119);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 20);
            this.lblName.TabIndex = 74;
            this.lblName.Text = "Name :";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblPackage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPackage.Location = new System.Drawing.Point(145, 76);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(79, 20);
            this.lblPackage.TabIndex = 76;
            this.lblPackage.Text = "Packages";
            this.lblPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PbPhoto
            // 
            this.PbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbPhoto.Location = new System.Drawing.Point(3, 4);
            this.PbPhoto.Name = "PbPhoto";
            this.PbPhoto.Size = new System.Drawing.Size(127, 112);
            this.PbPhoto.TabIndex = 0;
            this.PbPhoto.TabStop = false;
            // 
            // btnprev
            // 
            this.btnprev.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprev.ForeColor = System.Drawing.Color.White;
            this.btnprev.Location = new System.Drawing.Point(501, 255);
            this.btnprev.Name = "btnprev";
            this.btnprev.Size = new System.Drawing.Size(101, 28);
            this.btnprev.TabIndex = 79;
            this.btnprev.Text = "Previous";
            this.btnprev.UseVisualStyleBackColor = false;
            this.btnprev.Click += new System.EventHandler(this.btnprev_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(13, 255);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(0, 13);
            this.lblDateTime.TabIndex = 81;
            // 
            // lblattendencecount
            // 
            this.lblattendencecount.AutoSize = true;
            this.lblattendencecount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblattendencecount.Location = new System.Drawing.Point(219, 253);
            this.lblattendencecount.Name = "lblattendencecount";
            this.lblattendencecount.Size = new System.Drawing.Size(0, 20);
            this.lblattendencecount.TabIndex = 82;
            // 
            // btnMachineName
            // 
            this.btnMachineName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnMachineName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMachineName.ForeColor = System.Drawing.Color.White;
            this.btnMachineName.Location = new System.Drawing.Point(432, 5);
            this.btnMachineName.Name = "btnMachineName";
            this.btnMachineName.Size = new System.Drawing.Size(148, 28);
            this.btnMachineName.TabIndex = 83;
            this.btnMachineName.UseVisualStyleBackColor = false;
            // 
            // FrmBiomPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 296);
            this.Controls.Add(this.lblattendencecount);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.btnprev);
            this.Controls.Add(this.panelpopup);
            this.Name = "FrmBiomPopup";
            this.Text = "BioMonitor";
            this.Load += new System.EventHandler(this.PopUp_Load);
            this.panelpopup.ResumeLayout(false);
            this.panelpopup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelpopup;
        private System.Windows.Forms.PictureBox PbPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOutfees;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Button btnprev;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblattendencecount;
        private System.Windows.Forms.Button btnMachineName;
    }
}