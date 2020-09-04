namespace ClassManager.WinApp
{
    partial class FrmStandardMasterForm
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
            this.btnCreatePackage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnViewCourse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MinPercent = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLocation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBatch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnRemoveBatch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddBatch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.toTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.fromTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStandard = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstBatches = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDuration = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtStdName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnDelStnd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSaveStd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSStream = new System.Windows.Forms.ComboBox();
            this.lstStndrds = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePackage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreatePackage.BackColor = System.Drawing.Color.White;
            this.btnCreatePackage.Depth = 0;
            this.btnCreatePackage.Location = new System.Drawing.Point(176, 560);
            this.btnCreatePackage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Primary = true;
            this.btnCreatePackage.Size = new System.Drawing.Size(134, 33);
            this.btnCreatePackage.TabIndex = 16;
            this.btnCreatePackage.Text = "Create Package";
            this.btnCreatePackage.UseVisualStyleBackColor = false;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // btnViewCourse
            // 
            this.btnViewCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewCourse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewCourse.BackColor = System.Drawing.Color.White;
            this.btnViewCourse.Depth = 0;
            this.btnViewCourse.Location = new System.Drawing.Point(42, 560);
            this.btnViewCourse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewCourse.Name = "btnViewCourse";
            this.btnViewCourse.Primary = true;
            this.btnViewCourse.Size = new System.Drawing.Size(112, 33);
            this.btnViewCourse.TabIndex = 15;
            this.btnViewCourse.Text = "View Course";
            this.btnViewCourse.UseVisualStyleBackColor = false;
            this.btnViewCourse.Click += new System.EventHandler(this.btnViewCourse_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label12.Location = new System.Drawing.Point(199, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.MinPercent);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtLocation);
            this.panel2.Controls.Add(this.txtBatch);
            this.panel2.Controls.Add(this.btnRemoveBatch);
            this.panel2.Controls.Add(this.btnAddBatch);
            this.panel2.Controls.Add(this.toTime);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.fromTime);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dtpStartDate);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbStandard);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lstBatches);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(15, 344);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 210);
            this.panel2.TabIndex = 5;
            // 
            // MinPercent
            // 
            this.MinPercent.Depth = 0;
            this.MinPercent.Hint = "Enter Minimum Percent";
            this.MinPercent.Location = new System.Drawing.Point(154, 93);
            this.MinPercent.MouseState = MaterialSkin.MouseState.HOVER;
            this.MinPercent.Name = "MinPercent";
            this.MinPercent.PasswordChar = '\0';
            this.MinPercent.SelectedText = "";
            this.MinPercent.SelectionLength = 0;
            this.MinPercent.SelectionStart = 0;
            this.MinPercent.Size = new System.Drawing.Size(168, 23);
            this.MinPercent.TabIndex = 8;
            this.MinPercent.TabStop = false;
            this.MinPercent.UseSystemPasswordChar = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label13.Location = new System.Drawing.Point(7, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 20);
            this.label13.TabIndex = 38;
            this.label13.Text = "Batch Percent :";
            // 
            // txtLocation
            // 
            this.txtLocation.Depth = 0;
            this.txtLocation.Hint = "Enter Location";
            this.txtLocation.Location = new System.Drawing.Point(153, 128);
            this.txtLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PasswordChar = '\0';
            this.txtLocation.SelectedText = "";
            this.txtLocation.SelectionLength = 0;
            this.txtLocation.SelectionStart = 0;
            this.txtLocation.Size = new System.Drawing.Size(168, 23);
            this.txtLocation.TabIndex = 9;
            this.txtLocation.TabStop = false;
            this.txtLocation.UseSystemPasswordChar = false;
            // 
            // txtBatch
            // 
            this.txtBatch.Depth = 0;
            this.txtBatch.Hint = "Enter Batch";
            this.txtBatch.Location = new System.Drawing.Point(153, 58);
            this.txtBatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.PasswordChar = '\0';
            this.txtBatch.SelectedText = "";
            this.txtBatch.SelectionLength = 0;
            this.txtBatch.SelectionStart = 0;
            this.txtBatch.Size = new System.Drawing.Size(168, 23);
            this.txtBatch.TabIndex = 7;
            this.txtBatch.TabStop = false;
            this.txtBatch.UseSystemPasswordChar = false;
            // 
            // btnRemoveBatch
            // 
            this.btnRemoveBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveBatch.BackColor = System.Drawing.Color.White;
            this.btnRemoveBatch.Depth = 0;
            this.btnRemoveBatch.Location = new System.Drawing.Point(383, 71);
            this.btnRemoveBatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveBatch.Name = "btnRemoveBatch";
            this.btnRemoveBatch.Primary = true;
            this.btnRemoveBatch.Size = new System.Drawing.Size(77, 33);
            this.btnRemoveBatch.TabIndex = 13;
            this.btnRemoveBatch.Text = "delete";
            this.btnRemoveBatch.UseVisualStyleBackColor = false;
            this.btnRemoveBatch.Click += new System.EventHandler(this.btnRemoveBatch_Click);
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddBatch.BackColor = System.Drawing.Color.White;
            this.btnAddBatch.Depth = 0;
            this.btnAddBatch.Location = new System.Drawing.Point(383, 32);
            this.btnAddBatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Primary = true;
            this.btnAddBatch.Size = new System.Drawing.Size(77, 33);
            this.btnAddBatch.TabIndex = 12;
            this.btnAddBatch.Text = "add";
            this.btnAddBatch.UseVisualStyleBackColor = false;
            this.btnAddBatch.Click += new System.EventHandler(this.btnAddBatch_Click);
            // 
            // toTime
            // 
            this.toTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.toTime.Location = new System.Drawing.Point(318, 161);
            this.toTime.Name = "toTime";
            this.toTime.ShowUpDown = true;
            this.toTime.Size = new System.Drawing.Size(97, 22);
            this.toTime.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(243, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "To time :";
            // 
            // fromTime
            // 
            this.fromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.fromTime.Location = new System.Drawing.Point(101, 164);
            this.fromTime.Name = "fromTime";
            this.fromTime.ShowUpDown = true;
            this.fromTime.Size = new System.Drawing.Size(105, 22);
            this.fromTime.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(7, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "From time :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(634, 144);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(91, 22);
            this.dtpStartDate.TabIndex = 14;
            this.dtpStartDate.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(7, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Location  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(517, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Start Date :";
            this.label5.Visible = false;
            // 
            // cmbStandard
            // 
            this.cmbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStandard.FormattingEnabled = true;
            this.cmbStandard.Location = new System.Drawing.Point(153, 23);
            this.cmbStandard.Name = "cmbStandard";
            this.cmbStandard.Size = new System.Drawing.Size(168, 24);
            this.cmbStandard.TabIndex = 6;
            this.cmbStandard.SelectedIndexChanged += new System.EventHandler(this.cmbStandard_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Course Type :";
            // 
            // lstBatches
            // 
            this.lstBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBatches.FormattingEnabled = true;
            this.lstBatches.HorizontalScrollbar = true;
            this.lstBatches.ItemHeight = 16;
            this.lstBatches.Location = new System.Drawing.Point(501, 16);
            this.lstBatches.Name = "lstBatches";
            this.lstBatches.Size = new System.Drawing.Size(238, 100);
            this.lstBatches.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Batch Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(11, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Add / Delete Batch(s)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(11, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(252, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Add Stream with Course type :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtDuration);
            this.panel4.Controls.Add(this.txtStdName);
            this.panel4.Controls.Add(this.btnDelStnd);
            this.panel4.Controls.Add(this.btnSaveStd);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cmbSStream);
            this.panel4.Controls.Add(this.lstStndrds);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 91);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(760, 168);
            this.panel4.TabIndex = 3;
            // 
            // txtDuration
            // 
            this.txtDuration.Depth = 0;
            this.txtDuration.Hint = "Enter Duration";
            this.txtDuration.Location = new System.Drawing.Point(156, 111);
            this.txtDuration.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.PasswordChar = '\0';
            this.txtDuration.SelectedText = "";
            this.txtDuration.SelectionLength = 0;
            this.txtDuration.SelectionStart = 0;
            this.txtDuration.Size = new System.Drawing.Size(197, 23);
            this.txtDuration.TabIndex = 3;
            this.txtDuration.TabStop = false;
            this.txtDuration.UseSystemPasswordChar = false;
            // 
            // txtStdName
            // 
            this.txtStdName.Depth = 0;
            this.txtStdName.Hint = "Enter Course Type";
            this.txtStdName.Location = new System.Drawing.Point(157, 55);
            this.txtStdName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtStdName.Name = "txtStdName";
            this.txtStdName.PasswordChar = '\0';
            this.txtStdName.SelectedText = "";
            this.txtStdName.SelectionLength = 0;
            this.txtStdName.SelectionStart = 0;
            this.txtStdName.Size = new System.Drawing.Size(198, 23);
            this.txtStdName.TabIndex = 2;
            this.txtStdName.TabStop = false;
            this.txtStdName.UseSystemPasswordChar = false;
            // 
            // btnDelStnd
            // 
            this.btnDelStnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelStnd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelStnd.BackColor = System.Drawing.Color.White;
            this.btnDelStnd.Depth = 0;
            this.btnDelStnd.Location = new System.Drawing.Point(390, 75);
            this.btnDelStnd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelStnd.Name = "btnDelStnd";
            this.btnDelStnd.Primary = true;
            this.btnDelStnd.Size = new System.Drawing.Size(73, 33);
            this.btnDelStnd.TabIndex = 5;
            this.btnDelStnd.Text = "Delete";
            this.btnDelStnd.UseVisualStyleBackColor = false;
            this.btnDelStnd.Click += new System.EventHandler(this.btnDelStnd_Click);
            // 
            // btnSaveStd
            // 
            this.btnSaveStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveStd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveStd.BackColor = System.Drawing.Color.White;
            this.btnSaveStd.Depth = 0;
            this.btnSaveStd.Location = new System.Drawing.Point(390, 36);
            this.btnSaveStd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveStd.Name = "btnSaveStd";
            this.btnSaveStd.Primary = true;
            this.btnSaveStd.Size = new System.Drawing.Size(73, 33);
            this.btnSaveStd.TabIndex = 4;
            this.btnSaveStd.Text = "Add";
            this.btnSaveStd.UseVisualStyleBackColor = false;
            this.btnSaveStd.Click += new System.EventHandler(this.btnSaveStd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(35, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 40);
            this.label3.TabIndex = 31;
            this.label3.Text = "Duration :\r\n(in Months)";
            // 
            // cmbSStream
            // 
            this.cmbSStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSStream.FormattingEnabled = true;
            this.cmbSStream.Location = new System.Drawing.Point(156, 18);
            this.cmbSStream.Name = "cmbSStream";
            this.cmbSStream.Size = new System.Drawing.Size(199, 24);
            this.cmbSStream.TabIndex = 1;
            this.cmbSStream.SelectedIndexChanged += new System.EventHandler(this.cmbSStream_SelectedIndexChanged);
            // 
            // lstStndrds
            // 
            this.lstStndrds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStndrds.FormattingEnabled = true;
            this.lstStndrds.HorizontalScrollbar = true;
            this.lstStndrds.ItemHeight = 16;
            this.lstStndrds.Location = new System.Drawing.Point(504, 18);
            this.lstStndrds.Name = "lstStndrds";
            this.lstStndrds.Size = new System.Drawing.Size(238, 116);
            this.lstStndrds.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(35, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Course Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(35, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stream Name :";
            // 
            // FrmStandardMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(805, 631);
            this.Controls.Add(this.btnCreatePackage);
            this.Controls.Add(this.btnViewCourse);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStandardMasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Master";
            this.Load += new System.EventHandler(this.StandardMasterForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstBatches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstStndrds;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbStandard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSStream;
        private System.Windows.Forms.Label label9;
         private System.Windows.Forms.ListBox lstAdmission;
         private System.Windows.Forms.Label label3;
         private System.Windows.Forms.DateTimePicker dtpStartDate;
         private System.Windows.Forms.Label label5;
         private System.Windows.Forms.Label label7;
         private System.Windows.Forms.DateTimePicker toTime;
         private System.Windows.Forms.Label label10;
         private System.Windows.Forms.DateTimePicker fromTime;
         private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private MaterialSkin.Controls.MaterialRaisedButton btnRemoveBatch;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddBatch;
        private MaterialSkin.Controls.MaterialRaisedButton btnDelStnd;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveStd;
        private MaterialSkin.Controls.MaterialRaisedButton btnViewCourse;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtStdName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLocation;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBatch;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDuration;
        private MaterialSkin.Controls.MaterialRaisedButton btnCreatePackage;
        private MaterialSkin.Controls.MaterialSingleLineTextField MinPercent;
        private System.Windows.Forms.Label label13;
    }
}
