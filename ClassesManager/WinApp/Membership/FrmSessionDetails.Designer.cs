namespace ClassManager.WinApp
{
    partial class FrmSessionDetails
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
            this.panel28 = new System.Windows.Forms.Panel();
            this.memberslist = new System.Windows.Forms.ComboBox();
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.dtpAttdToDate = new System.Windows.Forms.DateTimePicker();
            this.btnFind = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpAttdFromDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel28
            // 
            this.panel28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel28.Controls.Add(this.memberslist);
            this.panel28.Controls.Add(this.cmbStream);
            this.panel28.Controls.Add(this.dtpAttdToDate);
            this.panel28.Controls.Add(this.btnFind);
            this.panel28.Controls.Add(this.label8);
            this.panel28.Controls.Add(this.label2);
            this.panel28.Controls.Add(this.label1);
            this.panel28.Controls.Add(this.label3);
            this.panel28.Controls.Add(this.dtpAttdFromDate);
            this.panel28.Location = new System.Drawing.Point(3, 65);
            this.panel28.Margin = new System.Windows.Forms.Padding(4);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(268, 484);
            this.panel28.TabIndex = 1;
            // 
            // memberslist
            // 
            this.memberslist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memberslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberslist.FormattingEnabled = true;
            this.memberslist.Location = new System.Drawing.Point(9, 244);
            this.memberslist.Margin = new System.Windows.Forms.Padding(4);
            this.memberslist.Name = "memberslist";
            this.memberslist.Size = new System.Drawing.Size(199, 32);
            this.memberslist.TabIndex = 409;
            this.memberslist.SelectedIndexChanged += new System.EventHandler(this.cmbStream1_SelectedIndexChanged);
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(9, 147);
            this.cmbStream.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(199, 32);
            this.cmbStream.TabIndex = 409;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // dtpAttdToDate
            // 
            this.dtpAttdToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAttdToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttdToDate.Location = new System.Drawing.Point(126, 24);
            this.dtpAttdToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAttdToDate.Name = "dtpAttdToDate";
            this.dtpAttdToDate.Size = new System.Drawing.Size(132, 26);
            this.dtpAttdToDate.TabIndex = 8;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.Depth = 0;
            this.btnFind.Location = new System.Drawing.Point(49, 418);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFind.Name = "btnFind";
            this.btnFind.Primary = true;
            this.btnFind.Size = new System.Drawing.Size(149, 41);
            this.btnFind.TabIndex = 408;
            this.btnFind.Text = "Search";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label8.Location = new System.Drawing.Point(4, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "From Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(4, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Members :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(9, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Instructure :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(4, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "To Date :";
            // 
            // dtpAttdFromDate
            // 
            this.dtpAttdFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAttdFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttdFromDate.Location = new System.Drawing.Point(126, 73);
            this.dtpAttdFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAttdFromDate.Name = "dtpAttdFromDate";
            this.dtpAttdFromDate.Size = new System.Drawing.Size(132, 26);
            this.dtpAttdFromDate.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(269, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(765, 484);
            this.dataGridView1.TabIndex = 0;
            // 
            // FrmSessionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 556);
            this.Controls.Add(this.panel28);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmSessionDetails";
            this.Text = "Member Details";
            this.Load += new System.EventHandler(this.FrmSessionDetails_Load);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel28;
        private MaterialSkin.Controls.MaterialRaisedButton btnFind;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpAttdFromDate;
        private System.Windows.Forms.DateTimePicker dtpAttdToDate;
        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.ComboBox memberslist;
    }
}