namespace ClassManager.WinApp
{
    partial class FrmViewCheques
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ADGViewCheques = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFrmDte = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtToDte = new System.Windows.Forms.DateTimePicker();
            this.chkpdngcheq = new System.Windows.Forms.CheckBox();
            this.totalCheq = new System.Windows.Forms.Label();
            this.lblUnclrAmnt = new System.Windows.Forms.Label();
            this.lblclrAmnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGViewCheques)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ADGViewCheques);
            this.panel3.Location = new System.Drawing.Point(312, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 398);
            this.panel3.TabIndex = 2;
            // 
            // ADGViewCheques
            // 
            this.ADGViewCheques.AllowUserToAddRows = false;
            this.ADGViewCheques.AllowUserToDeleteRows = false;
            this.ADGViewCheques.AutoGenerateContextFilters = true;
            this.ADGViewCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ADGViewCheques.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ADGViewCheques.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGViewCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGViewCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ADGViewCheques.DateWithTime = false;
            this.ADGViewCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGViewCheques.Location = new System.Drawing.Point(0, 0);
            this.ADGViewCheques.Name = "ADGViewCheques";
            this.ADGViewCheques.ReadOnly = true;
            this.ADGViewCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGViewCheques.Size = new System.Drawing.Size(801, 396);
            this.ADGViewCheques.TabIndex = 2;
            this.ADGViewCheques.TimeFilter = false;
            this.ADGViewCheques.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGViewCheques_CellClick);
            this.ADGViewCheques.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGViewCheques_DataBindingComplete);
            this.ADGViewCheques.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGViewCheques_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chkpdngcheq);
            this.panel1.Controls.Add(this.totalCheq);
            this.panel1.Controls.Add(this.lblUnclrAmnt);
            this.panel1.Controls.Add(this.lblclrAmnt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 398);
            this.panel1.TabIndex = 76;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtFrmDte);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtToDte);
            this.panel2.Location = new System.Drawing.Point(9, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 136);
            this.panel2.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 84;
            this.label6.Text = "Date Filter :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(3, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 77;
            this.label5.Text = "From Date :";
            // 
            // dtFrmDte
            // 
            this.dtFrmDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrmDte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrmDte.Location = new System.Drawing.Point(102, 40);
            this.dtFrmDte.Name = "dtFrmDte";
            this.dtFrmDte.Size = new System.Drawing.Size(140, 22);
            this.dtFrmDte.TabIndex = 1;
            this.dtFrmDte.CloseUp += new System.EventHandler(this.dtFrmDte_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "To Date :";
            // 
            // dtToDte
            // 
            this.dtToDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDte.Location = new System.Drawing.Point(99, 87);
            this.dtToDte.Name = "dtToDte";
            this.dtToDte.Size = new System.Drawing.Size(143, 22);
            this.dtToDte.TabIndex = 2;
            this.dtToDte.CloseUp += new System.EventHandler(this.dtToDte_CloseUp);
            // 
            // chkpdngcheq
            // 
            this.chkpdngcheq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkpdngcheq.AutoSize = true;
            this.chkpdngcheq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkpdngcheq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkpdngcheq.Location = new System.Drawing.Point(9, 303);
            this.chkpdngcheq.Name = "chkpdngcheq";
            this.chkpdngcheq.Size = new System.Drawing.Size(198, 24);
            this.chkpdngcheq.TabIndex = 3;
            this.chkpdngcheq.Text = "Show Pending Cheques";
            this.chkpdngcheq.UseVisualStyleBackColor = true;
            this.chkpdngcheq.CheckedChanged += new System.EventHandler(this.chkpdngcheq_CheckedChanged);
            // 
            // totalCheq
            // 
            this.totalCheq.AutoSize = true;
            this.totalCheq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCheq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.totalCheq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.totalCheq.Location = new System.Drawing.Point(154, 247);
            this.totalCheq.Name = "totalCheq";
            this.totalCheq.Size = new System.Drawing.Size(19, 20);
            this.totalCheq.TabIndex = 82;
            this.totalCheq.Text = "0";
            // 
            // lblUnclrAmnt
            // 
            this.lblUnclrAmnt.AutoSize = true;
            this.lblUnclrAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnclrAmnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblUnclrAmnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUnclrAmnt.Location = new System.Drawing.Point(154, 56);
            this.lblUnclrAmnt.Name = "lblUnclrAmnt";
            this.lblUnclrAmnt.Size = new System.Drawing.Size(19, 20);
            this.lblUnclrAmnt.TabIndex = 81;
            this.lblUnclrAmnt.Text = "0";
            // 
            // lblclrAmnt
            // 
            this.lblclrAmnt.AutoSize = true;
            this.lblclrAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclrAmnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.lblclrAmnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblclrAmnt.Location = new System.Drawing.Point(154, 16);
            this.lblclrAmnt.Name = "lblclrAmnt";
            this.lblclrAmnt.Size = new System.Drawing.Size(19, 20);
            this.lblclrAmnt.TabIndex = 80;
            this.lblclrAmnt.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(5, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 75;
            this.label2.Text = "Cleared Amount :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "Uncleared Amount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(5, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 73;
            this.label4.Text = "Pending Cheques :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmViewCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1127, 489);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewCheques";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Cheques";
            this.Load += new System.EventHandler(this.FrmViewCheques_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGViewCheques)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel3;
        private ADGV.AdvancedDataGridView ADGViewCheques;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtToDte;
        private System.Windows.Forms.DateTimePicker dtFrmDte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalCheq;
        private System.Windows.Forms.Label lblUnclrAmnt;
        private System.Windows.Forms.Label lblclrAmnt;
        private System.Windows.Forms.CheckBox chkpdngcheq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
    }
}
