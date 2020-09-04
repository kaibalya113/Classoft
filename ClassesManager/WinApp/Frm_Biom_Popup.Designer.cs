namespace ClassManager.WinApp
{
    partial class PopUp
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
            this.btnprev = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblOutfees = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPackage = new System.Windows.Forms.Label();
            this.PbPhoto = new System.Windows.Forms.PictureBox();
            this.panelpopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelpopup
            // 
            this.panelpopup.BackColor = System.Drawing.Color.White;
            this.panelpopup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelpopup.Controls.Add(this.btnprev);
            this.panelpopup.Controls.Add(this.btnclose);
            this.panelpopup.Controls.Add(this.lblOutfees);
            this.panelpopup.Controls.Add(this.lblCourse);
            this.panelpopup.Controls.Add(this.lblExpiry);
            this.panelpopup.Controls.Add(this.lblName);
            this.panelpopup.Controls.Add(this.lblPackage);
            this.panelpopup.Controls.Add(this.PbPhoto);
            this.panelpopup.Location = new System.Drawing.Point(8, 70);
            this.panelpopup.Name = "panelpopup";
            this.panelpopup.Size = new System.Drawing.Size(620, 235);
            this.panelpopup.TabIndex = 0;
            // 
            // btnprev
            // 
            this.btnprev.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprev.ForeColor = System.Drawing.Color.White;
            this.btnprev.Location = new System.Drawing.Point(3, 187);
            this.btnprev.Name = "btnprev";
            this.btnprev.Size = new System.Drawing.Size(43, 28);
            this.btnprev.TabIndex = 79;
            this.btnprev.Text = "<<";
            this.btnprev.UseVisualStyleBackColor = false;
            this.btnprev.Visible = false;
            this.btnprev.Click += new System.EventHandler(this.btnprev_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(464, 187);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(45, 28);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = ">>";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Visible = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblOutfees
            // 
            this.lblOutfees.AutoSize = true;
            this.lblOutfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutfees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOutfees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOutfees.Location = new System.Drawing.Point(145, 13);
            this.lblOutfees.Name = "lblOutfees";
            this.lblOutfees.Size = new System.Drawing.Size(140, 20);
            this.lblOutfees.TabIndex = 78;
            this.lblOutfees.Text = "Outstanding Fees:";
            this.lblOutfees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCourse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCourse.Location = new System.Drawing.Point(145, 45);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(87, 20);
            this.lblCourse.TabIndex = 75;
            this.lblCourse.Text = "Packages :";
            this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblExpiry.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblExpiry.Location = new System.Drawing.Point(301, 187);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(18, 20);
            this.lblExpiry.TabIndex = 77;
            this.lblExpiry.Text = "0";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExpiry.Visible = false;
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
            this.lblPackage.Location = new System.Drawing.Point(150, 72);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(0, 20);
            this.lblPackage.TabIndex = 76;
            this.lblPackage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbPhoto
            // 
            this.PbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbPhoto.Location = new System.Drawing.Point(3, 4);
            this.PbPhoto.Name = "PbPhoto";
            this.PbPhoto.Size = new System.Drawing.Size(136, 112);
            this.PbPhoto.TabIndex = 0;
            this.PbPhoto.TabStop = false;
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 313);
            this.Controls.Add(this.panelpopup);
            this.Name = "PopUp";
            this.Text = "PopUp";
            this.Load += new System.EventHandler(this.PopUp_Load);
            this.panelpopup.ResumeLayout(false);
            this.panelpopup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelpopup;
        private System.Windows.Forms.PictureBox PbPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblOutfees;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnprev;
    }
}