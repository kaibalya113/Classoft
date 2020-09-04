namespace ClassManager.WinApp
{
    partial class FrmOutstandingFees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutstandingFees));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bgwOutstandingSMS = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalOutstanding = new System.Windows.Forms.Label();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.SGOutstFees = new ClassManager.WinApp.UICommon.SuperGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDisc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalCollected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalOtst = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbViewOutstanding = new System.Windows.Forms.ComboBox();
            this.dtpBeforeDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblcrse = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.cmbBtch = new System.Windows.Forms.ComboBox();
            this.lblBatchNm = new System.Windows.Forms.Label();
            this.cmbStdNm = new System.Windows.Forms.ComboBox();
            this.cmbCourseNm = new System.Windows.Forms.ComboBox();
            this.lblstrm = new System.Windows.Forms.Label();
            this.chkAllBranchs = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btn_saveToPDF = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkSendSMS = new System.Windows.Forms.CheckBox();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SGOutstFees)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwOutstandingSMS
            // 
            this.bgwOutstandingSMS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwOutstandingSMS_DoWork);
            this.bgwOutstandingSMS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwOutstandingSMS_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(329, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 401;
            this.label1.Text = "Overall Outstanding :";
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.AutoSize = true;
            this.lblTotalOutstanding.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalOutstanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOutstanding.ForeColor = System.Drawing.Color.White;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(547, 39);
            this.lblTotalOutstanding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(24, 25);
            this.lblTotalOutstanding.TabIndex = 402;
            this.lblTotalOutstanding.Text = "0";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bindingNavigator1);
            this.panel5.Location = new System.Drawing.Point(15, 838);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1521, 34);
            this.panel5.TabIndex = 92;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.bindingNavigator1.Size = new System.Drawing.Size(238, 27);
            this.bindingNavigator1.TabIndex = 92;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SGOutstFees);
            this.panel4.Location = new System.Drawing.Point(15, 318);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1520, 521);
            this.panel4.TabIndex = 91;
            // 
            // SGOutstFees
            // 
            this.SGOutstFees.AllowUserToAddRows = false;
            this.SGOutstFees.AutoGenerateContextFilters = true;
            this.SGOutstFees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SGOutstFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SGOutstFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SGOutstFees.DateWithTime = false;
            this.SGOutstFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SGOutstFees.Location = new System.Drawing.Point(0, 0);
            this.SGOutstFees.Margin = new System.Windows.Forms.Padding(4);
            this.SGOutstFees.Name = "SGOutstFees";
            this.SGOutstFees.PageSize = 10;
            this.SGOutstFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SGOutstFees.Size = new System.Drawing.Size(1520, 521);
            this.SGOutstFees.TabIndex = 87;
            this.SGOutstFees.TimeFilter = false;
            this.SGOutstFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SGOutstFees_CellClick);
            this.SGOutstFees.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.SGOutstFees_DataBindingComplete);
            this.SGOutstFees.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.SGOutstFees_RowPostPaint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblDisc);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblTFees);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblTotalCollected);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblTotalOtst);
            this.panel3.Location = new System.Drawing.Point(15, 215);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1521, 52);
            this.panel3.TabIndex = 90;
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblDisc.Location = new System.Drawing.Point(467, 15);
            this.lblDisc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(24, 25);
            this.lblDisc.TabIndex = 69;
            this.lblDisc.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(363, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 68;
            this.label5.Text = "Discount :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(688, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 63;
            this.label2.Text = "Collected :";
            // 
            // lblTFees
            // 
            this.lblTFees.AutoSize = true;
            this.lblTFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTFees.Location = new System.Drawing.Point(145, 15);
            this.lblTFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTFees.Name = "lblTFees";
            this.lblTFees.Size = new System.Drawing.Size(24, 25);
            this.lblTFees.TabIndex = 73;
            this.lblTFees.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(27, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 25);
            this.label9.TabIndex = 72;
            this.label9.Text = "Total Fees :";
            // 
            // lblTotalCollected
            // 
            this.lblTotalCollected.AutoSize = true;
            this.lblTotalCollected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCollected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTotalCollected.Location = new System.Drawing.Point(796, 15);
            this.lblTotalCollected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCollected.Name = "lblTotalCollected";
            this.lblTotalCollected.Size = new System.Drawing.Size(24, 25);
            this.lblTotalCollected.TabIndex = 65;
            this.lblTotalCollected.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(1051, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 64;
            this.label3.Text = "Outstanding :";
            // 
            // lblTotalOtst
            // 
            this.lblTotalOtst.AutoSize = true;
            this.lblTotalOtst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOtst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTotalOtst.Location = new System.Drawing.Point(1188, 15);
            this.lblTotalOtst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalOtst.Name = "lblTotalOtst";
            this.lblTotalOtst.Size = new System.Drawing.Size(24, 25);
            this.lblTotalOtst.TabIndex = 66;
            this.lblTotalOtst.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCancelled);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbViewOutstanding);
            this.panel1.Controls.Add(this.dtpBeforeDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtFName);
            this.panel1.Controls.Add(this.lblcrse);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbGroup);
            this.panel1.Controls.Add(this.cmbBtch);
            this.panel1.Controls.Add(this.lblBatchNm);
            this.panel1.Controls.Add(this.cmbStdNm);
            this.panel1.Controls.Add(this.cmbCourseNm);
            this.panel1.Controls.Add(this.lblstrm);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1523, 121);
            this.panel1.TabIndex = 1;
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCancelled.Location = new System.Drawing.Point(1191, 65);
            this.lblCancelled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(24, 25);
            this.lblCancelled.TabIndex = 95;
            this.lblCancelled.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(20, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 101;
            this.label4.Text = "Custom :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Location = new System.Drawing.Point(1055, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 25);
            this.label11.TabIndex = 94;
            this.label11.Text = "Cancelled  :";
            // 
            // cmbViewOutstanding
            // 
            this.cmbViewOutstanding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewOutstanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViewOutstanding.FormattingEnabled = true;
            this.cmbViewOutstanding.Items.AddRange(new object[] {
            "All",
            "Only Outstanding"});
            this.cmbViewOutstanding.Location = new System.Drawing.Point(769, 58);
            this.cmbViewOutstanding.Margin = new System.Windows.Forms.Padding(4);
            this.cmbViewOutstanding.Name = "cmbViewOutstanding";
            this.cmbViewOutstanding.Size = new System.Drawing.Size(200, 28);
            this.cmbViewOutstanding.TabIndex = 6;
            this.cmbViewOutstanding.SelectedIndexChanged += new System.EventHandler(this.cmbViewOutstanding_SelectedIndexChanged);
            // 
            // dtpBeforeDate
            // 
            this.dtpBeforeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeforeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeforeDate.Location = new System.Drawing.Point(124, 58);
            this.dtpBeforeDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBeforeDate.Name = "dtpBeforeDate";
            this.dtpBeforeDate.Size = new System.Drawing.Size(207, 26);
            this.dtpBeforeDate.TabIndex = 5;
            this.dtpBeforeDate.CloseUp += new System.EventHandler(this.dtpBeforeDate_CloseUp);
            this.dtpBeforeDate.ValueChanged += new System.EventHandler(this.dtpBeforeDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(684, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 25);
            this.label6.TabIndex = 104;
            this.label6.Text = "View:";
            // 
            // txtFName
            // 
            this.txtFName.Depth = 0;
            this.txtFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFName.Hint = "Enter Name";
            this.txtFName.Location = new System.Drawing.Point(108, 6);
            this.txtFName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFName.Name = "txtFName";
            this.txtFName.PasswordChar = '\0';
            this.txtFName.SelectedText = "";
            this.txtFName.SelectionLength = 0;
            this.txtFName.SelectionStart = 0;
            this.txtFName.Size = new System.Drawing.Size(212, 28);
            this.txtFName.TabIndex = 4;
            this.txtFName.UseSystemPasswordChar = false;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            // 
            // lblcrse
            // 
            this.lblcrse.AutoSize = true;
            this.lblcrse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcrse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblcrse.Location = new System.Drawing.Point(656, 5);
            this.lblcrse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcrse.Name = "lblcrse";
            this.lblcrse.Size = new System.Drawing.Size(87, 25);
            this.lblcrse.TabIndex = 105;
            this.lblcrse.Text = "Course :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label14.Location = new System.Drawing.Point(15, 5);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 25);
            this.label14.TabIndex = 65;
            this.label14.Text = "Name :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(365, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 25);
            this.label7.TabIndex = 106;
            this.label7.Text = "Group By :";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Items.AddRange(new object[] {
            "None",
            "Members",
            "Course",
            "Stream",
            "Batch",
            "Package"});
            this.cmbGroup.Location = new System.Drawing.Point(485, 60);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(157, 28);
            this.cmbGroup.TabIndex = 7;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // cmbBtch
            // 
            this.cmbBtch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBtch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBtch.FormattingEnabled = true;
            this.cmbBtch.Location = new System.Drawing.Point(1131, 6);
            this.cmbBtch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBtch.Name = "cmbBtch";
            this.cmbBtch.Size = new System.Drawing.Size(200, 28);
            this.cmbBtch.TabIndex = 3;
            this.cmbBtch.SelectedIndexChanged += new System.EventHandler(this.cmbBtch_SelectedIndexChanged);
            // 
            // lblBatchNm
            // 
            this.lblBatchNm.AutoSize = true;
            this.lblBatchNm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchNm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBatchNm.Location = new System.Drawing.Point(1055, 7);
            this.lblBatchNm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatchNm.Name = "lblBatchNm";
            this.lblBatchNm.Size = new System.Drawing.Size(73, 25);
            this.lblBatchNm.TabIndex = 63;
            this.lblBatchNm.Text = "Batch :";
            // 
            // cmbStdNm
            // 
            this.cmbStdNm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStdNm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbStdNm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStdNm.FormattingEnabled = true;
            this.cmbStdNm.Items.AddRange(new object[] {
            ""});
            this.cmbStdNm.Location = new System.Drawing.Point(751, 4);
            this.cmbStdNm.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStdNm.Name = "cmbStdNm";
            this.cmbStdNm.Size = new System.Drawing.Size(259, 28);
            this.cmbStdNm.TabIndex = 2;
            this.cmbStdNm.SelectedIndexChanged += new System.EventHandler(this.cmbStdNm_SelectedIndexChanged);
            // 
            // cmbCourseNm
            // 
            this.cmbCourseNm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseNm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCourseNm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseNm.FormattingEnabled = true;
            this.cmbCourseNm.Items.AddRange(new object[] {
            ""});
            this.cmbCourseNm.Location = new System.Drawing.Point(403, 5);
            this.cmbCourseNm.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCourseNm.Name = "cmbCourseNm";
            this.cmbCourseNm.Size = new System.Drawing.Size(229, 28);
            this.cmbCourseNm.TabIndex = 1;
            this.cmbCourseNm.SelectedIndexChanged += new System.EventHandler(this.cmbCourseNm_SelectedIndexChanged);
            // 
            // lblstrm
            // 
            this.lblstrm.AutoSize = true;
            this.lblstrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstrm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblstrm.Location = new System.Drawing.Point(316, 5);
            this.lblstrm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstrm.Name = "lblstrm";
            this.lblstrm.Size = new System.Drawing.Size(86, 25);
            this.lblstrm.TabIndex = 64;
            this.lblstrm.Text = "Stream :";
            // 
            // chkAllBranchs
            // 
            this.chkAllBranchs.AutoSize = true;
            this.chkAllBranchs.BackColor = System.Drawing.Color.Transparent;
            this.chkAllBranchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllBranchs.ForeColor = System.Drawing.Color.White;
            this.chkAllBranchs.Location = new System.Drawing.Point(1321, 39);
            this.chkAllBranchs.Margin = new System.Windows.Forms.Padding(4);
            this.chkAllBranchs.Name = "chkAllBranchs";
            this.chkAllBranchs.Size = new System.Drawing.Size(199, 29);
            this.chkAllBranchs.TabIndex = 94;
            this.chkAllBranchs.TabStop = false;
            this.chkAllBranchs.Text = "Show All Branches";
            this.chkAllBranchs.UseVisualStyleBackColor = false;
            this.chkAllBranchs.CheckedChanged += new System.EventHandler(this.chkAllBranchs_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(969, 32);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 41);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE TO";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnSend.Location = new System.Drawing.Point(1429, 273);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(101, 41);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "SEND";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
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
            this.btn_saveToPDF.Location = new System.Drawing.Point(1132, 32);
            this.btn_saveToPDF.Margin = new System.Windows.Forms.Padding(4);
            this.btn_saveToPDF.Name = "btn_saveToPDF";
            this.btn_saveToPDF.Size = new System.Drawing.Size(151, 41);
            this.btn_saveToPDF.TabIndex = 400;
            this.btn_saveToPDF.Text = "Convert PDF";
            this.btn_saveToPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToPDF.UseVisualStyleBackColor = false;
            this.btn_saveToPDF.Click += new System.EventHandler(this.btn_saveToPDF_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(16, 284);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(121, 29);
            this.chkSelectAll.TabIndex = 8;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkSendSMS
            // 
            this.chkSendSMS.AutoSize = true;
            this.chkSendSMS.BackColor = System.Drawing.Color.Transparent;
            this.chkSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSendSMS.Location = new System.Drawing.Point(1269, 281);
            this.chkSendSMS.Margin = new System.Windows.Forms.Padding(4);
            this.chkSendSMS.Name = "chkSendSMS";
            this.chkSendSMS.Size = new System.Drawing.Size(126, 29);
            this.chkSendSMS.TabIndex = 9;
            this.chkSendSMS.Text = "SendSMS";
            this.chkSendSMS.UseVisualStyleBackColor = false;
            this.chkSendSMS.Visible = false;
            this.chkSendSMS.CheckedChanged += new System.EventHandler(this.chkSendSMS_CheckedChanged);
            // 
            // FrmOutstandingFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 876);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalOutstanding);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkAllBranchs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btn_saveToPDF);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.chkSendSMS);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmOutstandingFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outstanding Fees";
            this.Load += new System.EventHandler(this.FrmOutstandingFees_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SGOutstFees)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbViewOutstanding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBeforeDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblBatchNm;
        private System.Windows.Forms.ComboBox cmbBtch;
        private System.Windows.Forms.Label lblstrm;
        private System.Windows.Forms.ComboBox cmbStdNm;
        private System.Windows.Forms.ComboBox cmbCourseNm;
        private System.Windows.Forms.CheckBox chkAllBranchs;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckBox chkSendSMS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDisc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalCollected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalOtst;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFName;
        private System.ComponentModel.BackgroundWorker bgwOutstandingSMS;
        private UICommon.SuperGrid SGOutstFees;
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblcrse;
        private System.Windows.Forms.Button btn_saveToPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalOutstanding;
    }
}
