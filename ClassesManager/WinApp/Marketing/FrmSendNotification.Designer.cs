namespace ClassManager.WinApp
{
    partial class FrmSendNotification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bgwekerSendBtchWiseSMS = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ADGVData = new ADGV.AdvancedDataGridView();
            this.panelBatchWise = new System.Windows.Forms.Panel();
            this.sendBatchwiseSMS = new System.Windows.Forms.Button();
            this.lblBatchWiseSMS = new System.Windows.Forms.Label();
            this.txtBatchWiseSMS = new System.Windows.Forms.TextBox();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblStream = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlndvsl = new System.Windows.Forms.Panel();
            this.btnSendIndividual = new System.Windows.Forms.Button();
            this.txtPhnNo = new System.Windows.Forms.TextBox();
            this.lblCNo = new System.Windows.Forms.Label();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSend = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNotificationDate = new System.Windows.Forms.DateTimePicker();
            this.chkBrnchId = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVData)).BeginInit();
            this.panelBatchWise.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlndvsl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panelBatchWise);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 531);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ADGVData);
            this.panel4.Location = new System.Drawing.Point(240, 122);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(810, 405);
            this.panel4.TabIndex = 19;
            // 
            // ADGVData
            // 
            this.ADGVData.AllowUserToAddRows = false;
            this.ADGVData.AllowUserToDeleteRows = false;
            this.ADGVData.AllowUserToResizeRows = false;
            this.ADGVData.AutoGenerateContextFilters = true;
            this.ADGVData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVData.DateWithTime = false;
            this.ADGVData.Location = new System.Drawing.Point(0, 0);
            this.ADGVData.Name = "ADGVData";
            this.ADGVData.ReadOnly = true;
            this.ADGVData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ADGVData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVData.Size = new System.Drawing.Size(810, 394);
            this.ADGVData.TabIndex = 4;
            this.ADGVData.TimeFilter = false;
            this.ADGVData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVData_CellContentClick);
            this.ADGVData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVData_DataBindingComplete);
            this.ADGVData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVData_RowPostPaint);
            // 
            // panelBatchWise
            // 
            this.panelBatchWise.BackColor = System.Drawing.Color.White;
            this.panelBatchWise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBatchWise.Controls.Add(this.sendBatchwiseSMS);
            this.panelBatchWise.Controls.Add(this.lblBatchWiseSMS);
            this.panelBatchWise.Controls.Add(this.txtBatchWiseSMS);
            this.panelBatchWise.Controls.Add(this.cmbBatch);
            this.panelBatchWise.Controls.Add(this.lblBatch);
            this.panelBatchWise.Controls.Add(this.cmbCourse);
            this.panelBatchWise.Controls.Add(this.cmbStream);
            this.panelBatchWise.Controls.Add(this.lblCourse);
            this.panelBatchWise.Controls.Add(this.lblStream);
            this.panelBatchWise.Location = new System.Drawing.Point(6, 125);
            this.panelBatchWise.Name = "panelBatchWise";
            this.panelBatchWise.Size = new System.Drawing.Size(228, 391);
            this.panelBatchWise.TabIndex = 18;
            this.panelBatchWise.Visible = false;
            // 
            // sendBatchwiseSMS
            // 
            this.sendBatchwiseSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sendBatchwiseSMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sendBatchwiseSMS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sendBatchwiseSMS.FlatAppearance.BorderSize = 0;
            this.sendBatchwiseSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendBatchwiseSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.sendBatchwiseSMS.ForeColor = System.Drawing.Color.White;
            this.sendBatchwiseSMS.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.sendBatchwiseSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sendBatchwiseSMS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sendBatchwiseSMS.Location = new System.Drawing.Point(68, 348);
            this.sendBatchwiseSMS.Name = "sendBatchwiseSMS";
            this.sendBatchwiseSMS.Size = new System.Drawing.Size(76, 30);
            this.sendBatchwiseSMS.TabIndex = 9;
            this.sendBatchwiseSMS.Text = "SEND";
            this.sendBatchwiseSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendBatchwiseSMS.UseVisualStyleBackColor = false;
            this.sendBatchwiseSMS.Click += new System.EventHandler(this.sendBatchwiseSMS_Click);
            // 
            // lblBatchWiseSMS
            // 
            this.lblBatchWiseSMS.AutoSize = true;
            this.lblBatchWiseSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchWiseSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBatchWiseSMS.Location = new System.Drawing.Point(19, 214);
            this.lblBatchWiseSMS.Name = "lblBatchWiseSMS";
            this.lblBatchWiseSMS.Size = new System.Drawing.Size(82, 20);
            this.lblBatchWiseSMS.TabIndex = 16;
            this.lblBatchWiseSMS.Text = "Message :";
            // 
            // txtBatchWiseSMS
            // 
            this.txtBatchWiseSMS.Location = new System.Drawing.Point(23, 237);
            this.txtBatchWiseSMS.Multiline = true;
            this.txtBatchWiseSMS.Name = "txtBatchWiseSMS";
            this.txtBatchWiseSMS.Size = new System.Drawing.Size(174, 83);
            this.txtBatchWiseSMS.TabIndex = 8;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(23, 168);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(121, 21);
            this.cmbBatch.TabIndex = 7;
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblBatch.Location = new System.Drawing.Point(20, 149);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(59, 20);
            this.lblBatch.TabIndex = 13;
            this.lblBatch.Text = "Batch :";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(23, 98);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(121, 21);
            this.cmbCourse.TabIndex = 6;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(23, 38);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(121, 21);
            this.cmbStream.TabIndex = 5;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCourse.Location = new System.Drawing.Point(20, 79);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(68, 20);
            this.lblCourse.TabIndex = 9;
            this.lblCourse.Text = "Course :";
            // 
            // lblStream
            // 
            this.lblStream.AutoSize = true;
            this.lblStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblStream.Location = new System.Drawing.Point(20, 13);
            this.lblStream.Name = "lblStream";
            this.lblStream.Size = new System.Drawing.Size(69, 20);
            this.lblStream.TabIndex = 7;
            this.lblStream.Text = "Stream :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlndvsl);
            this.panel3.Location = new System.Drawing.Point(3, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 405);
            this.panel3.TabIndex = 17;
            // 
            // pnlndvsl
            // 
            this.pnlndvsl.BackColor = System.Drawing.Color.White;
            this.pnlndvsl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlndvsl.Controls.Add(this.btnSendIndividual);
            this.pnlndvsl.Controls.Add(this.txtPhnNo);
            this.pnlndvsl.Controls.Add(this.lblCNo);
            this.pnlndvsl.Controls.Add(this.txtNotice);
            this.pnlndvsl.Controls.Add(this.lblMsg);
            this.pnlndvsl.Location = new System.Drawing.Point(13, 3);
            this.pnlndvsl.Name = "pnlndvsl";
            this.pnlndvsl.Size = new System.Drawing.Size(211, 391);
            this.pnlndvsl.TabIndex = 3;
            // 
            // btnSendIndividual
            // 
            this.btnSendIndividual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendIndividual.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendIndividual.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSendIndividual.FlatAppearance.BorderSize = 0;
            this.btnSendIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSendIndividual.ForeColor = System.Drawing.Color.White;
            this.btnSendIndividual.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSendIndividual.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendIndividual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSendIndividual.Location = new System.Drawing.Point(58, 270);
            this.btnSendIndividual.Name = "btnSendIndividual";
            this.btnSendIndividual.Size = new System.Drawing.Size(76, 30);
            this.btnSendIndividual.TabIndex = 390;
            this.btnSendIndividual.Text = "SEND";
            this.btnSendIndividual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendIndividual.UseVisualStyleBackColor = false;
            this.btnSendIndividual.Click += new System.EventHandler(this.btnSendIndividual_Click);
            // 
            // txtPhnNo
            // 
            this.txtPhnNo.Location = new System.Drawing.Point(6, 193);
            this.txtPhnNo.Multiline = true;
            this.txtPhnNo.Name = "txtPhnNo";
            this.txtPhnNo.Size = new System.Drawing.Size(156, 26);
            this.txtPhnNo.TabIndex = 10;
            this.txtPhnNo.TabStop = false;
            this.txtPhnNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhnNo_KeyPress);
            // 
            // lblCNo
            // 
            this.lblCNo.AutoSize = true;
            this.lblCNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblCNo.Location = new System.Drawing.Point(20, 170);
            this.lblCNo.Name = "lblCNo";
            this.lblCNo.Size = new System.Drawing.Size(97, 20);
            this.lblCNo.TabIndex = 9;
            this.lblCNo.Text = "Contact No :";
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(6, 39);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(188, 80);
            this.txtNotice.TabIndex = 8;
            this.txtNotice.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblMsg.Location = new System.Drawing.Point(20, 10);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(82, 20);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "Message :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Controls.Add(this.btnSaveExcel);
            this.panel2.Controls.Add(this.lblToDate);
            this.panel2.Controls.Add(this.dtpToDate);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpNotificationDate);
            this.panel2.Controls.Add(this.chkBrnchId);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbType);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 113);
            this.panel2.TabIndex = 14;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Location = new System.Drawing.Point(308, 74);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(98, 24);
            this.chkSelectAll.TabIndex = 17;
            this.chkSelectAll.TabStop = false;
            this.chkSelectAll.Text = "Select All ";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveExcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveExcel.FlatAppearance.BorderSize = 0;
            this.btnSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveExcel.ForeColor = System.Drawing.Color.White;
            this.btnSaveExcel.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.btnSaveExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveExcel.Location = new System.Drawing.Point(655, 67);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(95, 31);
            this.btnSaveExcel.TabIndex = 16;
            this.btnSaveExcel.Text = "SAVE TO";
            this.btnSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveExcel.UseVisualStyleBackColor = false;
            this.btnSaveExcel.Visible = false;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblToDate.Location = new System.Drawing.Point(29, 69);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(35, 20);
            this.lblToDate.TabIndex = 15;
            this.lblToDate.Text = "To :";
            this.lblToDate.Visible = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(87, 69);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(113, 22);
            this.dtpToDate.TabIndex = 14;
            this.dtpToDate.Visible = false;
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
            this.btnSend.Location = new System.Drawing.Point(665, 25);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 30);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "SEND";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label10.Location = new System.Drawing.Point(-1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Select :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(29, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "From :";
            // 
            // dtpNotificationDate
            // 
            this.dtpNotificationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNotificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNotificationDate.Location = new System.Drawing.Point(87, 32);
            this.dtpNotificationDate.Name = "dtpNotificationDate";
            this.dtpNotificationDate.Size = new System.Drawing.Size(113, 22);
            this.dtpNotificationDate.TabIndex = 1;
            this.dtpNotificationDate.CloseUp += new System.EventHandler(this.dtpNotificationDate_CloseUp);
            // 
            // chkBrnchId
            // 
            this.chkBrnchId.AutoSize = true;
            this.chkBrnchId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBrnchId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkBrnchId.Location = new System.Drawing.Point(832, 17);
            this.chkBrnchId.Name = "chkBrnchId";
            this.chkBrnchId.Size = new System.Drawing.Size(200, 24);
            this.chkBrnchId.TabIndex = 4;
            this.chkBrnchId.Text = "Show All Branches Data";
            this.chkBrnchId.UseVisualStyleBackColor = true;
            this.chkBrnchId.CheckedChanged += new System.EventHandler(this.chkBrnchId_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(304, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Message Type :";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "BirthDay",
            "Anniversary",
            "Followup Sms",
            "Before Outstanding Date",
            "Individual",
            "Absent Message",
            "BatchWise"});
            this.cmbType.Location = new System.Drawing.Point(430, 29);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(185, 24);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // FrmSendNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1072, 602);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSendNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Notification";
            this.Load += new System.EventHandler(this.SendNotification_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVData)).EndInit();
            this.panelBatchWise.ResumeLayout(false);
            this.panelBatchWise.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlndvsl.ResumeLayout(false);
            this.pnlndvsl.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwekerSendBtchWiseSMS;
        private System.Windows.Forms.Panel pnlndvsl;
        private System.Windows.Forms.TextBox txtPhnNo;
        private System.Windows.Forms.Label lblCNo;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNotificationDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkBrnchId;
        private ADGV.AdvancedDataGridView ADGVData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelBatchWise;
        private System.Windows.Forms.Label lblBatchWiseSMS;
        private System.Windows.Forms.TextBox txtBatchWiseSMS;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblStream;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button sendBatchwiseSMS;
        private System.Windows.Forms.Button btnSendIndividual;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}
