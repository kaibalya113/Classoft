namespace ClassManager.WinApp
{
    partial class FrmSubjectMaster
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNames = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnViewTimeTable = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addFaculty = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.removeFaculty = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lnklblFaculty = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lstFaculty = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtNames);
            this.panel2.Controls.Add(this.cmbStream);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbCourseType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 121);
            this.panel2.TabIndex = 365;
            // 
            // txtNames
            // 
            this.txtNames.Depth = 0;
            this.txtNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNames.Hint = "Enter Subject Name";
            this.txtNames.Location = new System.Drawing.Point(141, 70);
            this.txtNames.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNames.Name = "txtNames";
            this.txtNames.PasswordChar = '\0';
            this.txtNames.SelectedText = "";
            this.txtNames.SelectionLength = 0;
            this.txtNames.SelectionStart = 0;
            this.txtNames.Size = new System.Drawing.Size(219, 23);
            this.txtNames.TabIndex = 3;
            this.txtNames.TabStop = false;
            this.txtNames.UseSystemPasswordChar = false;
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(90, 22);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(172, 24);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(15, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Stream :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(364, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Course Type :";
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseType.Location = new System.Drawing.Point(476, 22);
            this.cmbCourseType.MaxDropDownItems = 9;
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(154, 24);
            this.cmbCourseType.TabIndex = 2;
            this.cmbCourseType.SelectedIndexChanged += new System.EventHandler(this.cmbCourseType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(15, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Subject Name :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnViewTimeTable);
            this.panel1.Controls.Add(this.addFaculty);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.removeFaculty);
            this.panel1.Controls.Add(this.lnklblFaculty);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lstFaculty);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbFaculty);
            this.panel1.Location = new System.Drawing.Point(12, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 206);
            this.panel1.TabIndex = 363;
            // 
            // BtnViewTimeTable
            // 
            this.BtnViewTimeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnViewTimeTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnViewTimeTable.BackColor = System.Drawing.Color.White;
            this.BtnViewTimeTable.Depth = 0;
            this.BtnViewTimeTable.Location = new System.Drawing.Point(20, 153);
            this.BtnViewTimeTable.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnViewTimeTable.Name = "BtnViewTimeTable";
            this.BtnViewTimeTable.Primary = true;
            this.BtnViewTimeTable.Size = new System.Drawing.Size(116, 29);
            this.BtnViewTimeTable.TabIndex = 8;
            this.BtnViewTimeTable.Text = "View Subjects";
            this.BtnViewTimeTable.UseVisualStyleBackColor = false;
            this.BtnViewTimeTable.Click += new System.EventHandler(this.BtnViewTimeTable_Click);
            // 
            // addFaculty
            // 
            this.addFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFaculty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addFaculty.BackColor = System.Drawing.Color.White;
            this.addFaculty.Depth = 0;
            this.addFaculty.Location = new System.Drawing.Point(378, 41);
            this.addFaculty.MouseState = MaterialSkin.MouseState.HOVER;
            this.addFaculty.Name = "addFaculty";
            this.addFaculty.Primary = true;
            this.addFaculty.Size = new System.Drawing.Size(66, 33);
            this.addFaculty.TabIndex = 6;
            this.addFaculty.Text = "Add";
            this.addFaculty.UseVisualStyleBackColor = false;
            this.addFaculty.Click += new System.EventHandler(this.addFaculty_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(557, 153);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // removeFaculty
            // 
            this.removeFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFaculty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeFaculty.BackColor = System.Drawing.Color.White;
            this.removeFaculty.Depth = 0;
            this.removeFaculty.Location = new System.Drawing.Point(378, 80);
            this.removeFaculty.MouseState = MaterialSkin.MouseState.HOVER;
            this.removeFaculty.Name = "removeFaculty";
            this.removeFaculty.Primary = true;
            this.removeFaculty.Size = new System.Drawing.Size(66, 31);
            this.removeFaculty.TabIndex = 7;
            this.removeFaculty.Text = "Remove";
            this.removeFaculty.UseVisualStyleBackColor = false;
            this.removeFaculty.Click += new System.EventHandler(this.removeFaculty_Click);
            // 
            // lnklblFaculty
            // 
            this.lnklblFaculty.AutoSize = true;
            this.lnklblFaculty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblFaculty.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lnklblFaculty.Location = new System.Drawing.Point(274, 70);
            this.lnklblFaculty.Name = "lnklblFaculty";
            this.lnklblFaculty.Size = new System.Drawing.Size(90, 19);
            this.lnklblFaculty.TabIndex = 5;
            this.lnklblFaculty.TabStop = true;
            this.lnklblFaculty.Text = "Add Faculty";
            this.lnklblFaculty.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblFaculty_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 20);
            this.label3.TabIndex = 362;
            this.label3.Text = "Add Faculties For subject :";
            // 
            // lstFaculty
            // 
            this.lstFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFaculty.FormattingEnabled = true;
            this.lstFaculty.ItemHeight = 16;
            this.lstFaculty.Location = new System.Drawing.Point(476, 20);
            this.lstFaculty.Name = "lstFaculty";
            this.lstFaculty.Size = new System.Drawing.Size(165, 116);
            this.lstFaculty.TabIndex = 361;
            this.lstFaculty.SelectedIndexChanged += new System.EventHandler(this.lstFaculty_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Faculty :";
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(90, 69);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(162, 24);
            this.cmbFaculty.TabIndex = 4;
            this.cmbFaculty.SelectedIndexChanged += new System.EventHandler(this.cmbFaculty_SelectedIndexChanged);
            // 
            // FrmSubjectMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(693, 435);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSubjectMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Create Subjects";
            this.Load += new System.EventHandler(this.SubjectMaster_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCourseType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.ListBox lstFaculty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnklblFaculty;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRaisedButton BtnViewTimeTable;
        private MaterialSkin.Controls.MaterialRaisedButton addFaculty;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialRaisedButton removeFaculty;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNames;
    }
}
