namespace ClassManager.WinApp
{
    partial class FrmViewOutstanding
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewOutstanding));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bgwOutstandingSMS = new System.ComponentModel.BackgroundWorker();
            this.BtnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlFolloupGrid = new System.Windows.Forms.Panel();
            this.AdgvViewFolow = new ADGV.AdvancedDataGridView();
            this.PanelFollowUp = new System.Windows.Forms.Panel();
            this.cmbFollowpby = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cmbMediam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStudName = new System.Windows.Forms.Label();
            this.dtFollowup = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFrmDte = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtToDte = new System.Windows.Forms.DateTimePicker();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalOtst = new System.Windows.Forms.Label();
            this.chkApplyDateFilter = new System.Windows.Forms.CheckBox();
            this.SGOutstFees = new ClassManager.WinApp.UICommon.SuperGrid();
            this.NewFollowUp = new System.Windows.Forms.DataGridViewImageColumn();
            this.View = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlFolloupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).BeginInit();
            this.PanelFollowUp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SGOutstFees)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwOutstandingSMS
            // 
            this.bgwOutstandingSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwOutstandingSMS_DoWork);
            this.bgwOutstandingSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwOutstandingSMS_RunWorkerCompleted);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Depth = 0;
            this.BtnCancel.Location = new System.Drawing.Point(1253, 64);
            this.BtnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Primary = true;
            this.BtnCancel.Size = new System.Drawing.Size(40, 24);
            this.BtnCancel.TabIndex = 69;
            this.BtnCancel.TabStop = false;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click_1);
            // 
            // pnlFolloupGrid
            // 
            this.pnlFolloupGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlFolloupGrid.Controls.Add(this.AdgvViewFolow);
            this.pnlFolloupGrid.Location = new System.Drawing.Point(845, 75);
            this.pnlFolloupGrid.Name = "pnlFolloupGrid";
            this.pnlFolloupGrid.Size = new System.Drawing.Size(340, 549);
            this.pnlFolloupGrid.TabIndex = 392;
            this.pnlFolloupGrid.Visible = false;
            // 
            // AdgvViewFolow
            // 
            this.AdgvViewFolow.AllowUserToAddRows = false;
            this.AdgvViewFolow.AllowUserToDeleteRows = false;
            this.AdgvViewFolow.AllowUserToResizeColumns = false;
            this.AdgvViewFolow.AllowUserToResizeRows = false;
            this.AdgvViewFolow.AutoGenerateContextFilters = true;
            this.AdgvViewFolow.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdgvViewFolow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AdgvViewFolow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdgvViewFolow.DateWithTime = false;
            this.AdgvViewFolow.Location = new System.Drawing.Point(0, 0);
            this.AdgvViewFolow.Name = "AdgvViewFolow";
            this.AdgvViewFolow.ReadOnly = true;
            this.AdgvViewFolow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AdgvViewFolow.Size = new System.Drawing.Size(337, 549);
            this.AdgvViewFolow.TabIndex = 4;
            this.AdgvViewFolow.TimeFilter = false;
            this.AdgvViewFolow.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AdgvViewFolow_DataBindingComplete);
            this.AdgvViewFolow.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.AdgvViewFolow_RowPostPaint);
            // 
            // PanelFollowUp
            // 
            this.PanelFollowUp.BackColor = System.Drawing.Color.White;
            this.PanelFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFollowUp.Controls.Add(this.cmbFollowpby);
            this.PanelFollowUp.Controls.Add(this.label9);
            this.PanelFollowUp.Controls.Add(this.btnSave);
            this.PanelFollowUp.Controls.Add(this.txtDescription);
            this.PanelFollowUp.Controls.Add(this.cmbMediam);
            this.PanelFollowUp.Controls.Add(this.label2);
            this.PanelFollowUp.Controls.Add(this.lblStudName);
            this.PanelFollowUp.Controls.Add(this.dtFollowup);
            this.PanelFollowUp.Controls.Add(this.label3);
            this.PanelFollowUp.Controls.Add(this.label5);
            this.PanelFollowUp.Location = new System.Drawing.Point(841, 75);
            this.PanelFollowUp.Name = "PanelFollowUp";
            this.PanelFollowUp.Size = new System.Drawing.Size(272, 549);
            this.PanelFollowUp.TabIndex = 25;
            // 
            // cmbFollowpby
            // 
            this.cmbFollowpby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowpby.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFollowpby.FormattingEnabled = true;
            this.cmbFollowpby.Location = new System.Drawing.Point(11, 295);
            this.cmbFollowpby.Name = "cmbFollowpby";
            this.cmbFollowpby.Size = new System.Drawing.Size(185, 26);
            this.cmbFollowpby.TabIndex = 427;
            this.cmbFollowpby.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(13, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 428;
            this.label9.Text = "Followup By";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(32, 494);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 33);
            this.btnSave.TabIndex = 422;
            this.btnSave.Text = "SAVE  ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSaveFollowup_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(14, 376);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(185, 80);
            this.txtDescription.TabIndex = 65;
            this.txtDescription.Text = "";
            // 
            // cmbMediam
            // 
            this.cmbMediam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMediam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMediam.FormattingEnabled = true;
            this.cmbMediam.Items.AddRange(new object[] {
            "Telephonic",
            "SMS",
            "Meeting",
            "Email"});
            this.cmbMediam.Location = new System.Drawing.Point(11, 200);
            this.cmbMediam.Name = "cmbMediam";
            this.cmbMediam.Size = new System.Drawing.Size(185, 26);
            this.cmbMediam.TabIndex = 60;
            this.cmbMediam.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(10, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Medium :";
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStudName.Location = new System.Drawing.Point(10, 27);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(53, 20);
            this.lblStudName.TabIndex = 57;
            this.lblStudName.Text = "name";
            // 
            // dtFollowup
            // 
            this.dtFollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFollowup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFollowup.Location = new System.Drawing.Point(11, 116);
            this.dtFollowup.Name = "dtFollowup";
            this.dtFollowup.Size = new System.Drawing.Size(110, 24);
            this.dtFollowup.TabIndex = 59;
            this.dtFollowup.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(10, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 63;
            this.label3.Text = "Description :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(10, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtFrmDte);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtToDte);
            this.panel1.Controls.Add(this.btn_saveToPDF);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.txtFName);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.chkSelectAll);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(11, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 549);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(339, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 413;
            this.label4.Text = "From Date :";
            // 
            // dtFrmDte
            // 
            this.dtFrmDte.Enabled = false;
            this.dtFrmDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrmDte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrmDte.Location = new System.Drawing.Point(434, 59);
            this.dtFrmDte.Name = "dtFrmDte";
            this.dtFrmDte.Size = new System.Drawing.Size(140, 22);
            this.dtFrmDte.TabIndex = 411;
            this.dtFrmDte.CloseUp += new System.EventHandler(this.dtFrmDte_CloseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(590, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 414;
            this.label6.Text = "To Date :";
            // 
            // dtToDte
            // 
            this.dtToDte.Enabled = false;
            this.dtToDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDte.Location = new System.Drawing.Point(666, 59);
            this.dtToDte.Name = "dtToDte";
            this.dtToDte.Size = new System.Drawing.Size(143, 22);
            this.dtToDte.TabIndex = 412;
            this.dtToDte.CloseUp += new System.EventHandler(this.dtToDte_CloseUp);
            // 
            // btn_saveToPDF
            // 
            this.btn_saveToPDF.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_saveToPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_saveToPDF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_saveToPDF.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_saveToPDF.FlatAppearance.BorderSize = 0;
            this.btn_saveToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveToPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveToPDF.ForeColor = System.Drawing.Color.White;
            this.btn_saveToPDF.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btn_saveToPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_saveToPDF.Location = new System.Drawing.Point(590, 5);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 410;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(724, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 33);
            this.btnExcel.TabIndex = 91;
            this.btnExcel.Text = "SAVE TO";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtFName
            // 
            this.txtFName.Depth = 0;
            this.txtFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFName.Hint = "Enter Name";
            this.txtFName.Location = new System.Drawing.Point(88, 61);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(197, 23);
            this.txtFName.TabIndex = 4;
            this.txtFName.TabStop = false;
            this.txtFName.UseSystemPasswordChar = false;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(8, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 20);
            this.label14.TabIndex = 65;
            this.label14.Text = "Name :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bindingNavigator1);
            this.panel5.Location = new System.Drawing.Point(4, 512);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1060, 28);
            this.panel5.TabIndex = 93;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(209, 25);
            this.bindingNavigator1.TabIndex = 92;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(7, 13);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 389;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSend.Location = new System.Drawing.Point(107, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 33);
            this.btnSend.TabIndex = 388;
            this.btnSend.Text = "SEND";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkApplyDateFilter);
            this.panel3.Controls.Add(this.SGOutstFees);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(822, 547);
            this.panel3.TabIndex = 107;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel17.Controls.Add(this.label1);
            this.panel17.Controls.Add(this.lblTotalOtst);
            this.panel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel17.ForeColor = System.Drawing.Color.White;
            this.panel17.Location = new System.Drawing.Point(343, 26);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(321, 33);
            this.panel17.TabIndex = 391;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 108;
            this.label1.Text = "Total Outstanding :";
            // 
            // lblTotalOtst
            // 
            this.lblTotalOtst.AutoSize = true;
            this.lblTotalOtst.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOtst.ForeColor = System.Drawing.Color.White;
            this.lblTotalOtst.Location = new System.Drawing.Point(160, 5);
            this.lblTotalOtst.Name = "lblTotalOtst";
            this.lblTotalOtst.Size = new System.Drawing.Size(17, 18);
            this.lblTotalOtst.TabIndex = 109;
            this.lblTotalOtst.Text = "0";
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApplyDateFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkApplyDateFilter.Location = new System.Drawing.Point(343, 29);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(91, 20);
            this.chkApplyDateFilter.TabIndex = 89;
            this.chkApplyDateFilter.Text = "Date Fillter";
            this.chkApplyDateFilter.UseVisualStyleBackColor = true;
            this.chkApplyDateFilter.CheckedChanged += new System.EventHandler(this.chkApplyDateFilter_CheckedChanged);
            // 
            // SGOutstFees
            // 
            this.SGOutstFees.AllowUserToAddRows = false;
            this.SGOutstFees.AutoGenerateContextFilters = true;
            this.SGOutstFees.BackgroundColor = System.Drawing.Color.White;
            this.SGOutstFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SGOutstFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.SGOutstFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SGOutstFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewFollowUp,
            this.View});
            this.SGOutstFees.DateWithTime = false;
            this.SGOutstFees.Location = new System.Drawing.Point(7, 90);
            this.SGOutstFees.Name = "SGOutstFees";
            this.SGOutstFees.PageSize = 10;
            this.SGOutstFees.ReadOnly = true;
            this.SGOutstFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SGOutstFees.Size = new System.Drawing.Size(806, 416);
            this.SGOutstFees.TabIndex = 88;
            this.SGOutstFees.TimeFilter = false;
            this.SGOutstFees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SGOutstFees_CellClick);
            this.SGOutstFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SGOutstFees_CellContentClick);
            this.SGOutstFees.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.SGOutstFees_DataBindingComplete);
            this.SGOutstFees.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.SGOutstFees_RowPostPaint);
            // 
            // NewFollowUp
            // 
            this.NewFollowUp.HeaderText = "New";
            this.NewFollowUp.Image = global::ClassManager.Properties.Resources.calendar;
            this.NewFollowUp.MinimumWidth = 22;
            this.NewFollowUp.Name = "NewFollowUp";
            this.NewFollowUp.ReadOnly = true;
            this.NewFollowUp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // View
            // 
            this.View.HeaderText = "View";
            this.View.Image = global::ClassManager.Properties.Resources.eye;
            this.View.MinimumWidth = 22;
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FrmViewOutstanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1292, 683);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.pnlFolloupGrid);
            this.Controls.Add(this.PanelFollowUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel17);
            this.Name = "FrmViewOutstanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outstanding Fees";
            this.Load += new System.EventHandler(this.FrmViewOutstanding_Load);
            this.pnlFolloupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).EndInit();
            this.PanelFollowUp.ResumeLayout(false);
            this.PanelFollowUp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SGOutstFees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalOtst;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private UICommon.SuperGrid SGOutstFees;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.ComponentModel.BackgroundWorker bgwOutstandingSMS;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.DataGridViewImageColumn NewFollowUp;
        private System.Windows.Forms.DataGridViewImageColumn View;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFollowup;
        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMediam;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFollowpby;
        private System.Windows.Forms.Panel PanelFollowUp;
        private System.Windows.Forms.Panel pnlFolloupGrid;
        private ADGV.AdvancedDataGridView AdgvViewFolow;
        private System.Windows.Forms.Button btn_saveToPDF;
        private MaterialSkin.Controls.MaterialRaisedButton BtnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFrmDte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtToDte;
        private System.Windows.Forms.CheckBox chkApplyDateFilter;
    }
}
