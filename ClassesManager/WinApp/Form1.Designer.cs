namespace ClassManager.WinApp
{
    partial class Form1
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
            this.panel22 = new System.Windows.Forms.Panel();
            this.txtRollNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label20 = new System.Windows.Forms.Label();
            this.panel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.White;
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel22.Controls.Add(this.txtRollNo);
            this.panel22.Controls.Add(this.label20);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(1071, 23);
            this.panel22.TabIndex = 379;
            // 
            // txtRollNo
            // 
            this.txtRollNo.Depth = 0;
            this.txtRollNo.Hint = "Roll No";
            this.txtRollNo.Location = new System.Drawing.Point(566, -1);
            this.txtRollNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.PasswordChar = '\0';
            this.txtRollNo.SelectedText = "";
            this.txtRollNo.SelectionLength = 0;
            this.txtRollNo.SelectionStart = 0;
            this.txtRollNo.Size = new System.Drawing.Size(182, 23);
            this.txtRollNo.TabIndex = 405;
            this.txtRollNo.TabStop = false;
            this.txtRollNo.UseSystemPasswordChar = false;
            this.txtRollNo.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label20.Location = new System.Drawing.Point(455, -1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 20);
            this.label20.TabIndex = 404;
            this.label20.Text = "Roll No. :";
            this.label20.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 549);
            this.Controls.Add(this.panel22);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel22;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRollNo;
        private System.Windows.Forms.Label label20;
    }
}