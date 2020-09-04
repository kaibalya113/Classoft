namespace ClassManager.WinApp
{
    partial class FrmOptionalSubject
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
            this.lstofAllSubjects = new System.Windows.Forms.ListBox();
            this.lstofSelectedSubjects = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAddSubject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnRemoveSubject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalFees = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstofAllSubjects
            // 
            this.lstofAllSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstofAllSubjects.FormattingEnabled = true;
            this.lstofAllSubjects.ItemHeight = 16;
            this.lstofAllSubjects.Location = new System.Drawing.Point(14, 19);
            this.lstofAllSubjects.Name = "lstofAllSubjects";
            this.lstofAllSubjects.Size = new System.Drawing.Size(266, 196);
            this.lstofAllSubjects.TabIndex = 0;
            // 
            // lstofSelectedSubjects
            // 
            this.lstofSelectedSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstofSelectedSubjects.FormattingEnabled = true;
            this.lstofSelectedSubjects.ItemHeight = 16;
            this.lstofSelectedSubjects.Location = new System.Drawing.Point(383, 17);
            this.lstofSelectedSubjects.Name = "lstofSelectedSubjects";
            this.lstofSelectedSubjects.Size = new System.Drawing.Size(254, 196);
            this.lstofSelectedSubjects.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(282, 228);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "Total Fees";
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSubject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSubject.BackColor = System.Drawing.Color.White;
            this.btnAddSubject.Depth = 0;
            this.btnAddSubject.Location = new System.Drawing.Point(302, 59);
            this.btnAddSubject.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Primary = true;
            this.btnAddSubject.Size = new System.Drawing.Size(54, 33);
            this.btnAddSubject.TabIndex = 1;
            this.btnAddSubject.Text = "add";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // btnRemoveSubject
            // 
            this.btnRemoveSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSubject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveSubject.BackColor = System.Drawing.Color.White;
            this.btnRemoveSubject.Depth = 0;
            this.btnRemoveSubject.Location = new System.Drawing.Point(302, 107);
            this.btnRemoveSubject.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveSubject.Name = "btnRemoveSubject";
            this.btnRemoveSubject.Primary = true;
            this.btnRemoveSubject.Size = new System.Drawing.Size(54, 33);
            this.btnRemoveSubject.TabIndex = 2;
            this.btnRemoveSubject.Text = "delete";
            this.btnRemoveSubject.UseVisualStyleBackColor = false;
            this.btnRemoveSubject.Click += new System.EventHandler(this.btnRemoveSubject_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtTotalFees);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRemoveSubject);
            this.panel1.Controls.Add(this.btnAddSubject);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lstofSelectedSubjects);
            this.panel1.Controls.Add(this.lstofAllSubjects);
            this.panel1.Location = new System.Drawing.Point(14, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 264);
            this.panel1.TabIndex = 58;
            // 
            // txtTotalFees
            // 
            this.txtTotalFees.Depth = 0;
            this.txtTotalFees.Hint = "Enter Total";
            this.txtTotalFees.Location = new System.Drawing.Point(383, 228);
            this.txtTotalFees.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTotalFees.Name = "txtTotalFees";
            this.txtTotalFees.PasswordChar = '\0';
            this.txtTotalFees.SelectedText = "";
            this.txtTotalFees.SelectionLength = 0;
            this.txtTotalFees.SelectionStart = 0;
            this.txtTotalFees.Size = new System.Drawing.Size(112, 23);
            this.txtTotalFees.TabIndex = 3;
            this.txtTotalFees.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(576, 223);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(61, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmOptionalSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(682, 350);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmOptionalSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionalSubject";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionalSubject_FormClosing);
            this.Load += new System.EventHandler(this.FrmOptionalSubject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstofAllSubjects;
        private System.Windows.Forms.ListBox lstofSelectedSubjects;
        private System.Windows.Forms.Label label14;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddSubject;
        private MaterialSkin.Controls.MaterialRaisedButton btnRemoveSubject;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTotalFees;
    }
}