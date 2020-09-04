namespace ClassManager.WinApp
{
    partial class FrmStudentInstallments
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ADGVInstallaments = new ADGV.AdvancedDataGridView();
            this.lblInstallment = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panelInstallDetails = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDiscription = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDiscount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtInstallmentAmount = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInstallmentDate = new System.Windows.Forms.DateTimePicker();
            this.Date = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblOrgDiscount = new System.Windows.Forms.Label();
            this.lblOrgFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVInstallaments)).BeginInit();
            this.panel7.SuspendLayout();
            this.panelInstallDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 465);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.lblInstallment);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(925, 462);
            this.panel5.TabIndex = 74;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ADGVInstallaments);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 334);
            this.panel3.TabIndex = 76;
            // 
            // ADGVInstallaments
            // 
            this.ADGVInstallaments.AllowUserToAddRows = false;
            this.ADGVInstallaments.AllowUserToDeleteRows = false;
            this.ADGVInstallaments.AllowUserToOrderColumns = true;
            this.ADGVInstallaments.AllowUserToResizeRows = false;
            this.ADGVInstallaments.AutoGenerateContextFilters = true;
            this.ADGVInstallaments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVInstallaments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVInstallaments.ColumnHeadersHeight = 24;
            this.ADGVInstallaments.DateWithTime = false;
            this.ADGVInstallaments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVInstallaments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ADGVInstallaments.Location = new System.Drawing.Point(0, 0);
            this.ADGVInstallaments.Name = "ADGVInstallaments";
            this.ADGVInstallaments.ReadOnly = true;
            this.ADGVInstallaments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVInstallaments.Size = new System.Drawing.Size(480, 332);
            this.ADGVInstallaments.TabIndex = 77;
            this.ADGVInstallaments.TimeFilter = false;
            this.ADGVInstallaments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVInstallaments_DataBindingComplete);
            this.ADGVInstallaments.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVInstallaments_DataError);
            this.ADGVInstallaments.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVInstallaments_RowPostPaint);
            this.ADGVInstallaments.SelectionChanged += new System.EventHandler(this.ADGVInstallaments_SelectionChanged);
            // 
            // lblInstallment
            // 
            this.lblInstallment.AutoSize = true;
            this.lblInstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblInstallment.Location = new System.Drawing.Point(515, 12);
            this.lblInstallment.Name = "lblInstallment";
            this.lblInstallment.Size = new System.Drawing.Size(140, 20);
            this.lblInstallment.TabIndex = 73;
            this.lblInstallment.Text = "Installment Details";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.panelInstallDetails);
            this.panel7.Location = new System.Drawing.Point(500, 21);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(410, 324);
            this.panel7.TabIndex = 75;
            // 
            // panelInstallDetails
            // 
            this.panelInstallDetails.BackColor = System.Drawing.Color.White;
            this.panelInstallDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInstallDetails.Controls.Add(this.lblStatus);
            this.panelInstallDetails.Controls.Add(this.btnCreate);
            this.panelInstallDetails.Controls.Add(this.btnModify);
            this.panelInstallDetails.Controls.Add(this.btnDelete);
            this.panelInstallDetails.Controls.Add(this.txtDiscription);
            this.panelInstallDetails.Controls.Add(this.txtDiscount);
            this.panelInstallDetails.Controls.Add(this.txtInstallmentAmount);
            this.panelInstallDetails.Controls.Add(this.label6);
            this.panelInstallDetails.Controls.Add(this.label4);
            this.panelInstallDetails.Controls.Add(this.dtpInstallmentDate);
            this.panelInstallDetails.Controls.Add(this.Date);
            this.panelInstallDetails.Controls.Add(this.label8);
            this.panelInstallDetails.Location = new System.Drawing.Point(3, 14);
            this.panelInstallDetails.Name = "panelInstallDetails";
            this.panelInstallDetails.Size = new System.Drawing.Size(404, 307);
            this.panelInstallDetails.TabIndex = 76;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(12, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 87;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Image = global::ClassManager.Properties.Resources.checked_files;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(272, 260);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 35);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "ADD";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnModify.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.Image = global::ClassManager.Properties.Resources.signing_the_contract;
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.Location = new System.Drawing.Point(149, 260);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(91, 35);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "MODIFY";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::ClassManager.Properties.Resources.icon_delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(27, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDiscription
            // 
            this.txtDiscription.Depth = 0;
            this.txtDiscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscription.Hint = "Enter Remark";
            this.txtDiscription.Location = new System.Drawing.Point(149, 210);
            this.txtDiscription.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.PasswordChar = '\0';
            this.txtDiscription.SelectedText = "";
            this.txtDiscription.SelectionLength = 0;
            this.txtDiscription.SelectionStart = 0;
            this.txtDiscription.Size = new System.Drawing.Size(188, 23);
            this.txtDiscription.TabIndex = 4;
            this.txtDiscription.UseSystemPasswordChar = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Depth = 0;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Hint = "Enter Discount";
            this.txtDiscount.Location = new System.Drawing.Point(149, 106);
            this.txtDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.SelectionLength = 0;
            this.txtDiscount.SelectionStart = 0;
            this.txtDiscount.Size = new System.Drawing.Size(190, 23);
            this.txtDiscount.TabIndex = 2;
            this.txtDiscount.UseSystemPasswordChar = false;
            // 
            // txtInstallmentAmount
            // 
            this.txtInstallmentAmount.Depth = 0;
            this.txtInstallmentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallmentAmount.Hint = "Enter Amount";
            this.txtInstallmentAmount.Location = new System.Drawing.Point(149, 57);
            this.txtInstallmentAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtInstallmentAmount.Name = "txtInstallmentAmount";
            this.txtInstallmentAmount.PasswordChar = '\0';
            this.txtInstallmentAmount.SelectedText = "";
            this.txtInstallmentAmount.SelectionLength = 0;
            this.txtInstallmentAmount.SelectionStart = 0;
            this.txtInstallmentAmount.Size = new System.Drawing.Size(190, 23);
            this.txtInstallmentAmount.TabIndex = 1;
            this.txtInstallmentAmount.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.Location = new System.Drawing.Point(67, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 86;
            this.label6.Text = "Remark :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(57, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "Discount :";
            // 
            // dtpInstallmentDate
            // 
            this.dtpInstallmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInstallmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInstallmentDate.Location = new System.Drawing.Point(149, 157);
            this.dtpInstallmentDate.Name = "dtpInstallmentDate";
            this.dtpInstallmentDate.Size = new System.Drawing.Size(134, 22);
            this.dtpInstallmentDate.TabIndex = 3;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.Date.Location = new System.Drawing.Point(6, 157);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(134, 20);
            this.Date.TabIndex = 74;
            this.Date.Text = "Installment Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(69, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 72;
            this.label8.Text = "Amount :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.lblOrgDiscount);
            this.panel2.Controls.Add(this.lblOrgFees);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblTotalDiscount);
            this.panel2.Controls.Add(this.lblFees);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Location = new System.Drawing.Point(12, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 95);
            this.panel2.TabIndex = 1;
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
            this.btnSave.Image = global::ClassManager.Properties.Resources.save_file_button;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(726, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 35);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::ClassManager.Properties.Resources.refresh_arrows_symbol_of_interface;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(591, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 35);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "RESET";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblOrgDiscount
            // 
            this.lblOrgDiscount.AutoSize = true;
            this.lblOrgDiscount.BackColor = System.Drawing.Color.White;
            this.lblOrgDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrgDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOrgDiscount.Location = new System.Drawing.Point(92, 49);
            this.lblOrgDiscount.Name = "lblOrgDiscount";
            this.lblOrgDiscount.Size = new System.Drawing.Size(45, 20);
            this.lblOrgDiscount.TabIndex = 96;
            this.lblOrgDiscount.Text = "total";
            // 
            // lblOrgFees
            // 
            this.lblOrgFees.AutoSize = true;
            this.lblOrgFees.BackColor = System.Drawing.Color.White;
            this.lblOrgFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrgFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblOrgFees.Location = new System.Drawing.Point(92, 17);
            this.lblOrgFees.Name = "lblOrgFees";
            this.lblOrgFees.Size = new System.Drawing.Size(45, 20);
            this.lblOrgFees.TabIndex = 95;
            this.lblOrgFees.Text = "total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label7.Location = new System.Drawing.Point(11, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 94;
            this.label7.Text = "Discount : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label9.Location = new System.Drawing.Point(33, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 93;
            this.label9.Text = "Fees :";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.BackColor = System.Drawing.Color.White;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblTotalDiscount.Location = new System.Drawing.Point(346, 58);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(45, 20);
            this.lblTotalDiscount.TabIndex = 92;
            this.lblTotalDiscount.Text = "total";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.BackColor = System.Drawing.Color.White;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblFees.Location = new System.Drawing.Point(346, 26);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(45, 20);
            this.lblFees.TabIndex = 91;
            this.lblFees.Text = "total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(225, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 90;
            this.label2.Text = "New Discount :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(252, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 89;
            this.label1.Text = "New Fees :";
            // 
            // FrmStudentInstallments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(949, 546);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmStudentInstallments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Installments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStudentInstallments_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentInstallment_FormClosed);
            this.Load += new System.EventHandler(this.StudentInstallment_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVInstallaments)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panelInstallDetails.ResumeLayout(false);
            this.panelInstallDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panelInstallDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInstallmentDate;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInstallment;
        private System.Windows.Forms.Panel panel3;
        private ADGV.AdvancedDataGridView ADGVInstallaments;
        private System.Windows.Forms.Label lblOrgDiscount;
        private System.Windows.Forms.Label lblOrgFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtInstallmentAmount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscount;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDiscription;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblStatus;
    }
}
