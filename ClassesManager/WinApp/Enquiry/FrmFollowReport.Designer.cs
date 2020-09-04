namespace ClassManager.WinApp
{
    partial class FrmFollowReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFollowReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlViewFollowUp = new System.Windows.Forms.Panel();
            this.AdgvViewFolow = new ADGV.AdvancedDataGridView();
            this.PanelFollowUp = new System.Windows.Forms.Panel();
            this.cmbFollowupBy = new System.Windows.Forms.ComboBox();
            this.btnSaveFollowup = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cmbMediam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStudName = new System.Windows.Forms.Label();
            this.dtFollowup = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblToday = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTomorrow = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ADGVFollowup = new ADGV.AdvancedDataGridView();
            this.panel17 = new System.Windows.Forms.Panel();
            this.lblInactive = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HelpPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbViewFollowUp = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.pnlViewFollowUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).BeginInit();
            this.PanelFollowUp.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVFollowup)).BeginInit();
            this.panel17.SuspendLayout();
            this.HelpPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(683, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Depth = 0;
            this.BtnCancel.Location = new System.Drawing.Point(1281, 68);
            this.BtnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Primary = true;
            this.BtnCancel.Size = new System.Drawing.Size(22, 19);
            this.BtnCancel.TabIndex = 397;
            this.BtnCancel.TabStop = false;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // pnlViewFollowUp
            // 
            this.pnlViewFollowUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlViewFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewFollowUp.Controls.Add(this.AdgvViewFolow);
            this.pnlViewFollowUp.Location = new System.Drawing.Point(964, 89);
            this.pnlViewFollowUp.Name = "pnlViewFollowUp";
            this.pnlViewFollowUp.Size = new System.Drawing.Size(339, 550);
            this.pnlViewFollowUp.TabIndex = 396;
            this.pnlViewFollowUp.Visible = false;
            // 
            // AdgvViewFolow
            // 
            this.AdgvViewFolow.AllowUserToAddRows = false;
            this.AdgvViewFolow.AllowUserToDeleteRows = false;
            this.AdgvViewFolow.AllowUserToResizeColumns = false;
            this.AdgvViewFolow.AllowUserToResizeRows = false;
            this.AdgvViewFolow.AutoGenerateContextFilters = true;
            this.AdgvViewFolow.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdgvViewFolow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AdgvViewFolow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdgvViewFolow.DateWithTime = false;
            this.AdgvViewFolow.Location = new System.Drawing.Point(-2, -1);
            this.AdgvViewFolow.Name = "AdgvViewFolow";
            this.AdgvViewFolow.ReadOnly = true;
            this.AdgvViewFolow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AdgvViewFolow.Size = new System.Drawing.Size(340, 550);
            this.AdgvViewFolow.TabIndex = 4;
            this.AdgvViewFolow.TimeFilter = false;
            this.AdgvViewFolow.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AdgvViewFolow_DataBindingComplete);
            this.AdgvViewFolow.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.AdgvViewFolow_RowPostPaint);
            // 
            // PanelFollowUp
            // 
            this.PanelFollowUp.BackColor = System.Drawing.Color.White;
            this.PanelFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFollowUp.Controls.Add(this.cmbFollowupBy);
            this.PanelFollowUp.Controls.Add(this.btnSaveFollowup);
            this.PanelFollowUp.Controls.Add(this.label9);
            this.PanelFollowUp.Controls.Add(this.txtDescription);
            this.PanelFollowUp.Controls.Add(this.cmbMediam);
            this.PanelFollowUp.Controls.Add(this.label3);
            this.PanelFollowUp.Controls.Add(this.lblStudName);
            this.PanelFollowUp.Controls.Add(this.dtFollowup);
            this.PanelFollowUp.Controls.Add(this.label15);
            this.PanelFollowUp.Controls.Add(this.label5);
            this.PanelFollowUp.Location = new System.Drawing.Point(961, 92);
            this.PanelFollowUp.Name = "PanelFollowUp";
            this.PanelFollowUp.Size = new System.Drawing.Size(321, 547);
            this.PanelFollowUp.TabIndex = 395;
            // 
            // cmbFollowupBy
            // 
            this.cmbFollowupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowupBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFollowupBy.FormattingEnabled = true;
            this.cmbFollowupBy.Location = new System.Drawing.Point(12, 250);
            this.cmbFollowupBy.Name = "cmbFollowupBy";
            this.cmbFollowupBy.Size = new System.Drawing.Size(147, 26);
            this.cmbFollowupBy.TabIndex = 425;
            this.cmbFollowupBy.TabStop = false;
            // 
            // btnSaveFollowup
            // 
            this.btnSaveFollowup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveFollowup.FlatAppearance.BorderSize = 0;
            this.btnSaveFollowup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFollowup.ForeColor = System.Drawing.Color.White;
            this.btnSaveFollowup.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSaveFollowup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFollowup.Location = new System.Drawing.Point(34, 449);
            this.btnSaveFollowup.Name = "btnSaveFollowup";
            this.btnSaveFollowup.Size = new System.Drawing.Size(88, 33);
            this.btnSaveFollowup.TabIndex = 422;
            this.btnSaveFollowup.Text = "SAVE  ";
            this.btnSaveFollowup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveFollowup.UseVisualStyleBackColor = false;
            this.btnSaveFollowup.Click += new System.EventHandler(this.saveFollowup_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(12, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 426;
            this.label9.Text = "Followup By";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(12, 346);
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
            this.cmbMediam.Location = new System.Drawing.Point(12, 165);
            this.cmbMediam.Name = "cmbMediam";
            this.cmbMediam.Size = new System.Drawing.Size(147, 26);
            this.cmbMediam.TabIndex = 60;
            this.cmbMediam.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(11, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Medium :";
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStudName.Location = new System.Drawing.Point(11, 17);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(53, 20);
            this.lblStudName.TabIndex = 57;
            this.lblStudName.Text = "name";
            // 
            // dtFollowup
            // 
            this.dtFollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFollowup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFollowup.Location = new System.Drawing.Point(12, 82);
            this.dtFollowup.Name = "dtFollowup";
            this.dtFollowup.Size = new System.Drawing.Size(110, 24);
            this.dtFollowup.TabIndex = 59;
            this.dtFollowup.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label15.Location = new System.Drawing.Point(12, 311);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 63;
            this.label15.Text = "Description :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Date :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblToday);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(211, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 38);
            this.panel4.TabIndex = 75;
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToday.ForeColor = System.Drawing.Color.White;
            this.lblToday.Location = new System.Drawing.Point(83, 6);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(19, 20);
            this.lblToday.TabIndex = 66;
            this.lblToday.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 65;
            this.label6.Text = "Today\'s :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblTomorrow);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(403, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 38);
            this.panel3.TabIndex = 394;
            // 
            // lblTomorrow
            // 
            this.lblTomorrow.AutoSize = true;
            this.lblTomorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTomorrow.ForeColor = System.Drawing.Color.White;
            this.lblTomorrow.Location = new System.Drawing.Point(104, 6);
            this.lblTomorrow.Name = "lblTomorrow";
            this.lblTomorrow.Size = new System.Drawing.Size(19, 20);
            this.lblTomorrow.TabIndex = 66;
            this.lblTomorrow.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "1 Week :";
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
            this.bindingNavigator1.Location = new System.Drawing.Point(11, 642);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(255, 25);
            this.bindingNavigator1.TabIndex = 393;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.Visible = false;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
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
            this.bindingNavigatorPositionItem.ReadOnly = true;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.ADGVFollowup);
            this.panel1.Location = new System.Drawing.Point(11, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 435);
            this.panel1.TabIndex = 392;
            // 
            // ADGVFollowup
            // 
            this.ADGVFollowup.AllowUserToAddRows = false;
            this.ADGVFollowup.AllowUserToDeleteRows = false;
            this.ADGVFollowup.AutoGenerateContextFilters = true;
            this.ADGVFollowup.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ADGVFollowup.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVFollowup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVFollowup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVFollowup.DateWithTime = false;
            this.ADGVFollowup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVFollowup.EnableHeadersVisualStyles = false;
            this.ADGVFollowup.GridColor = System.Drawing.SystemColors.Control;
            this.ADGVFollowup.Location = new System.Drawing.Point(0, 0);
            this.ADGVFollowup.Name = "ADGVFollowup";
            this.ADGVFollowup.ReadOnly = true;
            this.ADGVFollowup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVFollowup.Size = new System.Drawing.Size(944, 435);
            this.ADGVFollowup.TabIndex = 2;
            this.ADGVFollowup.TimeFilter = false;
            this.ADGVFollowup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVFollowup_CellClick);
            this.ADGVFollowup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVFollowup_CellContentClick);
            this.ADGVFollowup.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVFollowup_DataBindingComplete);
            this.ADGVFollowup.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVFollowup_RowPostPaint);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel17.Controls.Add(this.lblInactive);
            this.panel17.Controls.Add(this.label7);
            this.panel17.Location = new System.Drawing.Point(12, 158);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(172, 38);
            this.panel17.TabIndex = 74;
            // 
            // lblInactive
            // 
            this.lblInactive.AutoSize = true;
            this.lblInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactive.ForeColor = System.Drawing.Color.White;
            this.lblInactive.Location = new System.Drawing.Point(91, 6);
            this.lblInactive.Name = "lblInactive";
            this.lblInactive.Size = new System.Drawing.Size(19, 20);
            this.lblInactive.TabIndex = 66;
            this.lblInactive.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Pending :";
            // 
            // HelpPanel
            // 
            this.HelpPanel.BackColor = System.Drawing.Color.White;
            this.HelpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpPanel.Controls.Add(this.label13);
            this.HelpPanel.Controls.Add(this.label12);
            this.HelpPanel.Controls.Add(this.label8);
            this.HelpPanel.Controls.Add(this.button3);
            this.HelpPanel.Controls.Add(this.button2);
            this.HelpPanel.Controls.Add(this.button1);
            this.HelpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpPanel.Location = new System.Drawing.Point(771, 92);
            this.HelpPanel.Name = "HelpPanel";
            this.HelpPanel.Size = new System.Drawing.Size(184, 107);
            this.HelpPanel.TabIndex = 391;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 16);
            this.label13.TabIndex = 70;
            this.label13.Text = "1 Week Followup";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 16);
            this.label12.TabIndex = 69;
            this.label12.Text = "Pending Followup";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 16);
            this.label8.TabIndex = 68;
            this.label8.Text = "Today\'s Followup";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(213)))), ((int)(((byte)(129)))));
            this.button3.Location = new System.Drawing.Point(3, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 20);
            this.button3.TabIndex = 67;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.button2.Location = new System.Drawing.Point(3, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 66;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.button1.Location = new System.Drawing.Point(3, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 65;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Filter By";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtFName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbViewFollowUp);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(12, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 60);
            this.panel2.TabIndex = 46;
            // 
            // txtFName
            // 
            this.txtFName.Depth = 0;
            this.txtFName.Hint = "Enter Name";
            this.txtFName.Location = new System.Drawing.Point(75, 17);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(212, 23);
            this.txtFName.TabIndex = 1;
            this.txtFName.UseSystemPasswordChar = false;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(313, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "View FollowUp:";
            // 
            // cmbViewFollowUp
            // 
            this.cmbViewFollowUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewFollowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewFollowUp.FormattingEnabled = true;
            this.cmbViewFollowUp.Items.AddRange(new object[] {
            "ALL",
            "Pending Followup",
            "Today\'s Followup",
            "1 Week Followup"});
            this.cmbViewFollowUp.Location = new System.Drawing.Point(504, 17);
            this.cmbViewFollowUp.Name = "cmbViewFollowUp";
            this.cmbViewFollowUp.Size = new System.Drawing.Size(181, 24);
            this.cmbViewFollowUp.TabIndex = 2;
            this.cmbViewFollowUp.SelectedIndexChanged += new System.EventHandler(this.cmbViewFollowUp_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(14, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 20);
            this.label14.TabIndex = 54;
            this.label14.Text = "Name:";
            // 
            // btn_saveToPDF
            // 
            this.btn_saveToPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_saveToPDF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_saveToPDF.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_saveToPDF.FlatAppearance.BorderSize = 0;
            this.btn_saveToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveToPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveToPDF.ForeColor = System.Drawing.Color.White;
            this.btn_saveToPDF.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btn_saveToPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_saveToPDF.Location = new System.Drawing.Point(619, 158);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(113, 33);
            this.btn_saveToPDF.TabIndex = 398;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // FrmFollowReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 788);
            this.Controls.Add(this.btn_saveToPDF);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.pnlViewFollowUp);
            this.Controls.Add(this.PanelFollowUp);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.HelpPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmFollowReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FollowUp Report";
            this.Load += new System.EventHandler(this.FrmFollowReport_Load);
            this.pnlViewFollowUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdgvViewFolow)).EndInit();
            this.PanelFollowUp.ResumeLayout(false);
            this.PanelFollowUp.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVFollowup)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.HelpPanel.ResumeLayout(false);
            this.HelpPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbViewFollowUp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel HelpPanel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView ADGVFollowup;
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
        private System.Windows.Forms.Label lblInactive;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label lblTomorrow;
        private System.Windows.Forms.Panel PanelFollowUp;
        private System.Windows.Forms.Button btnSaveFollowup;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbMediam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.DateTimePicker dtFollowup;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlViewFollowUp;
        private ADGV.AdvancedDataGridView AdgvViewFolow;
        private MaterialSkin.Controls.MaterialRaisedButton BtnCancel;
        private System.Windows.Forms.ComboBox cmbFollowupBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_saveToPDF;
    }
}
