namespace ClassManager.WinApp
{
    partial class FrmViewTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ADGVTestMaster = new ADGV.AdvancedDataGridView();
            this.ClmUpdt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewTest = new MaterialSkin.Controls.MaterialRaisedButton();
            this.rbtnTodayTest = new System.Windows.Forms.RadioButton();
            this.rbtnTomorrowTest = new System.Windows.Forms.RadioButton();
            this.rbnAllTest = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTestMaster)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ADGVTestMaster);
            this.panel2.Location = new System.Drawing.Point(8, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 403);
            this.panel2.TabIndex = 344;
            // 
            // ADGVTestMaster
            // 
            this.ADGVTestMaster.AllowUserToAddRows = false;
            this.ADGVTestMaster.AutoGenerateContextFilters = true;
            this.ADGVTestMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ADGVTestMaster.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVTestMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVTestMaster.ColumnHeadersHeight = 24;
            this.ADGVTestMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ADGVTestMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmUpdt});
            this.ADGVTestMaster.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = "Update";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ADGVTestMaster.DefaultCellStyle = dataGridViewCellStyle2;
            this.ADGVTestMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADGVTestMaster.Location = new System.Drawing.Point(0, 0);
            this.ADGVTestMaster.Name = "ADGVTestMaster";
            this.ADGVTestMaster.ReadOnly = true;
            this.ADGVTestMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVTestMaster.Size = new System.Drawing.Size(1011, 401);
            this.ADGVTestMaster.TabIndex = 342;
            this.ADGVTestMaster.TimeFilter = false;
            this.ADGVTestMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVTestMaster_CellClick);
            this.ADGVTestMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ADGVTestMaster_CellContentClick);
            this.ADGVTestMaster.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVTestMaster_DataBindingComplete);
            this.ADGVTestMaster.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ADGVTestMaster_DataError);
            this.ADGVTestMaster.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVTestMaster_RowPostPaint);
            // 
            // ClmUpdt
            // 
            this.ClmUpdt.HeaderText = "Update";
            this.ClmUpdt.MinimumWidth = 22;
            this.ClmUpdt.Name = "ClmUpdt";
            this.ClmUpdt.ReadOnly = true;
            this.ClmUpdt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ClmUpdt.Width = 84;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnNewTest);
            this.panel1.Controls.Add(this.rbtnTodayTest);
            this.panel1.Controls.Add(this.rbtnTomorrowTest);
            this.panel1.Controls.Add(this.rbnAllTest);
            this.panel1.Location = new System.Drawing.Point(9, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 82);
            this.panel1.TabIndex = 343;
            // 
            // btnNewTest
            // 
            this.btnNewTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewTest.BackColor = System.Drawing.Color.White;
            this.btnNewTest.Depth = 0;
            this.btnNewTest.Location = new System.Drawing.Point(894, 20);
            this.btnNewTest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.Primary = true;
            this.btnNewTest.Size = new System.Drawing.Size(103, 32);
            this.btnNewTest.TabIndex = 4;
            this.btnNewTest.Text = "Create Test";
            this.btnNewTest.UseVisualStyleBackColor = false;
            this.btnNewTest.Click += new System.EventHandler(this.btnNewTest_Click);
            // 
            // rbtnTodayTest
            // 
            this.rbtnTodayTest.AutoSize = true;
            this.rbtnTodayTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodayTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtnTodayTest.Location = new System.Drawing.Point(260, 20);
            this.rbtnTodayTest.Name = "rbtnTodayTest";
            this.rbtnTodayTest.Size = new System.Drawing.Size(142, 24);
            this.rbtnTodayTest.TabIndex = 2;
            this.rbtnTodayTest.TabStop = true;
            this.rbtnTodayTest.Text = "Upcoming Tests";
            this.rbtnTodayTest.UseVisualStyleBackColor = true;
            this.rbtnTodayTest.CheckedChanged += new System.EventHandler(this.rbtnTodayTest_CheckedChanged_1);
            // 
            // rbtnTomorrowTest
            // 
            this.rbtnTomorrowTest.AutoSize = true;
            this.rbtnTomorrowTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTomorrowTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtnTomorrowTest.Location = new System.Drawing.Point(516, 20);
            this.rbtnTomorrowTest.Name = "rbtnTomorrowTest";
            this.rbtnTomorrowTest.Size = new System.Drawing.Size(98, 24);
            this.rbtnTomorrowTest.TabIndex = 3;
            this.rbtnTomorrowTest.TabStop = true;
            this.rbtnTomorrowTest.Text = "Past  Test";
            this.rbtnTomorrowTest.UseVisualStyleBackColor = true;
            this.rbtnTomorrowTest.CheckedChanged += new System.EventHandler(this.rbtnTomorrowTest_CheckedChanged_1);
            // 
            // rbnAllTest
            // 
            this.rbnAllTest.AutoSize = true;
            this.rbnAllTest.Checked = true;
            this.rbnAllTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnAllTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbnAllTest.Location = new System.Drawing.Point(13, 23);
            this.rbnAllTest.Name = "rbnAllTest";
            this.rbnAllTest.Size = new System.Drawing.Size(123, 24);
            this.rbnAllTest.TabIndex = 1;
            this.rbnAllTest.TabStop = true;
            this.rbnAllTest.Text = "Show All Test";
            this.rbnAllTest.UseVisualStyleBackColor = true;
            this.rbnAllTest.CheckedChanged += new System.EventHandler(this.rbnAllTest_CheckedChanged_1);
            // 
            // FrmViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1032, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewTest";
            this.Load += new System.EventHandler(this.FrmViewTest_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ADGVTestMaster)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbnAllTest;
        private System.Windows.Forms.RadioButton rbtnTomorrowTest;
        private System.Windows.Forms.RadioButton rbtnTodayTest;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView ADGVTestMaster;
        private System.Windows.Forms.DataGridViewButtonColumn ClmUpdt;
        private MaterialSkin.Controls.MaterialRaisedButton btnNewTest;
    }
}
