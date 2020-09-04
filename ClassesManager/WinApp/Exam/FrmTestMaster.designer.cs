namespace ClassManager.WinApp
{
    partial class FrmTestMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTotalmarks = new System.Windows.Forms.TextBox();
            this.btnUploadMarks = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpUploadMarks = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUploadMarks = new System.Windows.Forms.Label();
            this.cmbTests = new System.Windows.Forms.ComboBox();
            this.sndMarksSMS = new System.Windows.Forms.Button();
            this.ADGVTUploadMarks = new ADGV.AdvancedDataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMarks = new System.Windows.Forms.Label();
            this.txtDescription = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxMarks = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDlt = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddSub = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.CmbSubject = new System.Windows.Forms.ComboBox();
            this.dtTmMarks = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lstBxSelSub = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTstDtls = new System.Windows.Forms.Panel();
            this.btnUploadmrks = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnViewTst = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTUploadMarks)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTstDtls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotalmarks
            // 
            this.txtTotalmarks.Location = new System.Drawing.Point(475, 19);
            this.txtTotalmarks.Name = "txtTotalmarks";
            this.txtTotalmarks.ReadOnly = true;
            this.txtTotalmarks.Size = new System.Drawing.Size(100, 20);
            this.txtTotalmarks.TabIndex = 363;
            this.txtTotalmarks.TextChanged += new System.EventHandler(this.txtTotalmarks_TextChanged);
            // 
            // btnUploadMarks
            // 
            this.btnUploadMarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUploadMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadMarks.Location = new System.Drawing.Point(422, 68);
            this.btnUploadMarks.Name = "btnUploadMarks";
            this.btnUploadMarks.Size = new System.Drawing.Size(64, 32);
            this.btnUploadMarks.TabIndex = 367;
            this.btnUploadMarks.Text = "Save";
            this.btnUploadMarks.UseVisualStyleBackColor = false;
            this.btnUploadMarks.Click += new System.EventHandler(this.btnUploadMarks_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(363, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 362;
            // 
            // dtpUploadMarks
            // 
            this.dtpUploadMarks.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUploadMarks.Location = new System.Drawing.Point(177, 74);
            this.dtpUploadMarks.Name = "dtpUploadMarks";
            this.dtpUploadMarks.Size = new System.Drawing.Size(122, 20);
            this.dtpUploadMarks.TabIndex = 368;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(24, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 360;
            // 
            // lblUploadMarks
            // 
            this.lblUploadMarks.AutoSize = true;
            this.lblUploadMarks.ForeColor = System.Drawing.Color.White;
            this.lblUploadMarks.Location = new System.Drawing.Point(25, 77);
            this.lblUploadMarks.Name = "lblUploadMarks";
            this.lblUploadMarks.Size = new System.Drawing.Size(139, 16);
            this.lblUploadMarks.TabIndex = 369;
            // 
            // cmbTests
            // 
            this.cmbTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTests.FormattingEnabled = true;
            this.cmbTests.Location = new System.Drawing.Point(112, 22);
            this.cmbTests.Name = "cmbTests";
            this.cmbTests.Size = new System.Drawing.Size(150, 21);
            this.cmbTests.TabIndex = 361;
            // 
            // sndMarksSMS
            // 
            this.sndMarksSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.sndMarksSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sndMarksSMS.Location = new System.Drawing.Point(504, 68);
            this.sndMarksSMS.Name = "sndMarksSMS";
            this.sndMarksSMS.Size = new System.Drawing.Size(136, 32);
            this.sndMarksSMS.TabIndex = 370;
            this.sndMarksSMS.Text = "Send Marks SMS";
            this.sndMarksSMS.UseVisualStyleBackColor = false;
            this.sndMarksSMS.Click += new System.EventHandler(this.sndMarksSMS_Click);
            // 
            // ADGVTUploadMarks
            // 
            this.ADGVTUploadMarks.AllowUserToAddRows = false;
            this.ADGVTUploadMarks.AutoGenerateContextFilters = true;
            this.ADGVTUploadMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVTUploadMarks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.ADGVTUploadMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVTUploadMarks.DateWithTime = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ADGVTUploadMarks.DefaultCellStyle = dataGridViewCellStyle11;
            this.ADGVTUploadMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVTUploadMarks.Location = new System.Drawing.Point(0, 0);
            this.ADGVTUploadMarks.Name = "ADGVTUploadMarks";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVTUploadMarks.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.ADGVTUploadMarks.Size = new System.Drawing.Size(647, 272);
            this.ADGVTUploadMarks.TabIndex = 364;
            this.ADGVTUploadMarks.TimeFilter = false;
            this.ADGVTUploadMarks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVTUploadMarks_DataBindingComplete);
            this.ADGVTUploadMarks.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ADGVTUploadMarks_EditingControlShowing);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 66);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(938, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(930, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CreateTests";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pnlTstDtls);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 417);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtMarks);
            this.panel4.Controls.Add(this.txtDescription);
            this.panel4.Controls.Add(this.textBoxMarks);
            this.panel4.Controls.Add(this.txtName);
            this.panel4.Controls.Add(this.materialLabel10);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.btnDlt);
            this.panel4.Controls.Add(this.btnAddSub);
            this.panel4.Controls.Add(this.materialLabel9);
            this.panel4.Controls.Add(this.materialLabel8);
            this.panel4.Controls.Add(this.materialLabel7);
            this.panel4.Controls.Add(this.materialLabel6);
            this.panel4.Controls.Add(this.materialLabel5);
            this.panel4.Controls.Add(this.materialLabel4);
            this.panel4.Controls.Add(this.CmbSubject);
            this.panel4.Controls.Add(this.dtTmMarks);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.lstBxSelSub);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.lblDescription);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(2, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(924, 325);
            this.panel4.TabIndex = 377;
            this.panel4.Visible = false;
            // 
            // txtMarks
            // 
            this.txtMarks.AutoSize = true;
            this.txtMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarks.Location = new System.Drawing.Point(632, 279);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(18, 20);
            this.txtMarks.TabIndex = 383;
            this.txtMarks.Text = "0";
            // 
            // txtDescription
            // 
            this.txtDescription.Depth = 0;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Hint = "Enter Description";
            this.txtDescription.Location = new System.Drawing.Point(477, 63);
            this.txtDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.Size = new System.Drawing.Size(363, 23);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.TabStop = false;
            this.txtDescription.UseSystemPasswordChar = false;
            // 
            // textBoxMarks
            // 
            this.textBoxMarks.Depth = 0;
            this.textBoxMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarks.Hint = "Enter Marks";
            this.textBoxMarks.Location = new System.Drawing.Point(201, 156);
            this.textBoxMarks.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxMarks.Name = "textBoxMarks";
            this.textBoxMarks.PasswordChar = '\0';
            this.textBoxMarks.SelectedText = "";
            this.textBoxMarks.SelectionLength = 0;
            this.textBoxMarks.SelectionStart = 0;
            this.textBoxMarks.Size = new System.Drawing.Size(149, 23);
            this.textBoxMarks.TabIndex = 10;
            this.textBoxMarks.TabStop = false;
            this.textBoxMarks.UseSystemPasswordChar = false;
            // 
            // txtName
            // 
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Hint = "Enter Test Name";
            this.txtName.Location = new System.Drawing.Point(12, 63);
            this.txtName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.Size = new System.Drawing.Size(368, 23);
            this.txtName.TabIndex = 6;
            this.txtName.TabStop = false;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(680, 121);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(128, 19);
            this.materialLabel10.TabIndex = 382;
            this.materialLabel10.Text = "Selected subjects";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(766, 279);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Create Test";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDlt
            // 
            this.btnDlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDlt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDlt.BackColor = System.Drawing.Color.White;
            this.btnDlt.Depth = 0;
            this.btnDlt.Location = new System.Drawing.Point(576, 191);
            this.btnDlt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDlt.Name = "btnDlt";
            this.btnDlt.Primary = true;
            this.btnDlt.Size = new System.Drawing.Size(69, 33);
            this.btnDlt.TabIndex = 13;
            this.btnDlt.Text = "Remove";
            this.btnDlt.UseVisualStyleBackColor = false;
            this.btnDlt.Click += new System.EventHandler(this.btnDlt_Click);
            // 
            // btnAddSub
            // 
            this.btnAddSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSub.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSub.BackColor = System.Drawing.Color.White;
            this.btnAddSub.Depth = 0;
            this.btnAddSub.Location = new System.Drawing.Point(576, 146);
            this.btnAddSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Primary = true;
            this.btnAddSub.Size = new System.Drawing.Size(69, 33);
            this.btnAddSub.TabIndex = 12;
            this.btnAddSub.Text = "Add";
            this.btnAddSub.UseVisualStyleBackColor = false;
            this.btnAddSub.Click += new System.EventHandler(this.btnAddSub_Click);
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(8, 133);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(121, 19);
            this.materialLabel9.TabIndex = 381;
            this.materialLabel9.Text = "Select Subjects :";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(198, 133);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(104, 19);
            this.materialLabel8.TabIndex = 380;
            this.materialLabel8.Text = "Out of Marks :";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(379, 133);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(48, 19);
            this.materialLabel7.TabIndex = 379;
            this.materialLabel7.Text = "Date :";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(528, 279);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(98, 19);
            this.materialLabel6.TabIndex = 378;
            this.materialLabel6.Text = "Total Marks :";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(473, 31);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(55, 19);
            this.materialLabel5.TabIndex = 377;
            this.materialLabel5.Text = "Topic :";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(9, 31);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(91, 19);
            this.materialLabel4.TabIndex = 376;
            this.materialLabel4.Text = "Test Name :";
            // 
            // CmbSubject
            // 
            this.CmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSubject.FormattingEnabled = true;
            this.CmbSubject.Location = new System.Drawing.Point(12, 155);
            this.CmbSubject.Name = "CmbSubject";
            this.CmbSubject.Size = new System.Drawing.Size(149, 28);
            this.CmbSubject.TabIndex = 9;
            // 
            // dtTmMarks
            // 
            this.dtTmMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTmMarks.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTmMarks.Location = new System.Drawing.Point(383, 159);
            this.dtTmMarks.Name = "dtTmMarks";
            this.dtTmMarks.Size = new System.Drawing.Size(145, 26);
            this.dtTmMarks.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(247, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 16);
            this.label14.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(365, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 16);
            this.label15.TabIndex = 2;
            // 
            // lstBxSelSub
            // 
            this.lstBxSelSub.FormattingEnabled = true;
            this.lstBxSelSub.ItemHeight = 16;
            this.lstBxSelSub.Location = new System.Drawing.Point(684, 143);
            this.lstBxSelSub.Name = "lstBxSelSub";
            this.lstBxSelSub.Size = new System.Drawing.Size(195, 100);
            this.lstBxSelSub.TabIndex = 11;
            this.lstBxSelSub.SelectedIndexChanged += new System.EventHandler(this.lstBxSelSub_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(626, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 16);
            this.label13.TabIndex = 369;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(9, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 366;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(202, 12);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 16);
            this.lblDescription.TabIndex = 363;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(380, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 28;
            // 
            // pnlTstDtls
            // 
            this.pnlTstDtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTstDtls.Controls.Add(this.btnUploadmrks);
            this.pnlTstDtls.Controls.Add(this.btnViewTst);
            this.pnlTstDtls.Controls.Add(this.materialLabel3);
            this.pnlTstDtls.Controls.Add(this.materialLabel2);
            this.pnlTstDtls.Controls.Add(this.materialLabel1);
            this.pnlTstDtls.Controls.Add(this.label5);
            this.pnlTstDtls.Controls.Add(this.cmbStream);
            this.pnlTstDtls.Controls.Add(this.label7);
            this.pnlTstDtls.Controls.Add(this.cmbCourseType);
            this.pnlTstDtls.Controls.Add(this.label9);
            this.pnlTstDtls.Controls.Add(this.cmbBatch);
            this.pnlTstDtls.Location = new System.Drawing.Point(0, 2);
            this.pnlTstDtls.Name = "pnlTstDtls";
            this.pnlTstDtls.Size = new System.Drawing.Size(927, 80);
            this.pnlTstDtls.TabIndex = 376;
            // 
            // btnUploadmrks
            // 
            this.btnUploadmrks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadmrks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUploadmrks.BackColor = System.Drawing.Color.White;
            this.btnUploadmrks.Depth = 0;
            this.btnUploadmrks.Location = new System.Drawing.Point(798, 26);
            this.btnUploadmrks.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUploadmrks.Name = "btnUploadmrks";
            this.btnUploadmrks.Primary = true;
            this.btnUploadmrks.Size = new System.Drawing.Size(119, 33);
            this.btnUploadmrks.TabIndex = 5;
            this.btnUploadmrks.Text = "Upload Marks";
            this.btnUploadmrks.UseVisualStyleBackColor = false;
            this.btnUploadmrks.Click += new System.EventHandler(this.btnUploadmrks_Click);
            // 
            // btnViewTst
            // 
            this.btnViewTst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewTst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewTst.BackColor = System.Drawing.Color.White;
            this.btnViewTst.Depth = 0;
            this.btnViewTst.Location = new System.Drawing.Point(694, 26);
            this.btnViewTst.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewTst.Name = "btnViewTst";
            this.btnViewTst.Primary = true;
            this.btnViewTst.Size = new System.Drawing.Size(82, 33);
            this.btnViewTst.TabIndex = 4;
            this.btnViewTst.Text = "View Test";
            this.btnViewTst.UseVisualStyleBackColor = false;
            this.btnViewTst.Click += new System.EventHandler(this.btnViewTst_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(423, 11);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(55, 19);
            this.materialLabel3.TabIndex = 363;
            this.materialLabel3.Text = "Batch :";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(218, 8);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(69, 19);
            this.materialLabel2.TabIndex = 362;
            this.materialLabel2.Text = " Course :";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(10, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 361;
            this.materialLabel1.Text = "Stream :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 23;
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(7, 31);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(193, 28);
            this.cmbStream.TabIndex = 1;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(334, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 25;
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseType.FormattingEnabled = true;
            this.cmbCourseType.Location = new System.Drawing.Point(217, 31);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(193, 28);
            this.cmbCourseType.TabIndex = 2;
            this.cmbCourseType.SelectedIndexChanged += new System.EventHandler(this.cmbCourseType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(449, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 360;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(421, 31);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(193, 28);
            this.cmbBatch.TabIndex = 3;
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            // 
            // FrmTestMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 537);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmTestMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Test";
            this.Load += new System.EventHandler(this.TestMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTUploadMarks)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlTstDtls.ResumeLayout(false);
            this.pnlTstDtls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtTotalmarks;
        private System.Windows.Forms.Button btnUploadMarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpUploadMarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUploadMarks;
        private System.Windows.Forms.ComboBox cmbTests;
        private System.Windows.Forms.Button sndMarksSMS;
        private ADGV.AdvancedDataGridView ADGVTUploadMarks;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox CmbSubject;
        private System.Windows.Forms.DateTimePicker dtTmMarks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lstBxSelSub;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTstDtls;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCourseType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBatch;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialRaisedButton btnDlt;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddSub;
        private MaterialSkin.Controls.MaterialRaisedButton btnViewTst;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDescription;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxMarks;
        private MaterialSkin.Controls.MaterialRaisedButton btnUploadmrks;
        private System.Windows.Forms.Label txtMarks;
    }
}
