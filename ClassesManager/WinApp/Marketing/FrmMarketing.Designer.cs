namespace ClassManager.WinApp
{
    partial class FrmMarketing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarketing));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSendSms = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtnTrans = new System.Windows.Forms.RadioButton();
            this.rbtnPromo = new System.Windows.Forms.RadioButton();
            this.btnUpdateMessage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMarketingMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBranchID = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbViewMaketingData = new System.Windows.Forms.ComboBox();
            this.cmbCourseNm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ADGVMarketing = new ADGV.AdvancedDataGridView();
            this.bgwMarketingSms = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVMarketing)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.btnSendSms);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.rbtnTrans);
            this.splitContainer1.Panel1.Controls.Add(this.rbtnPromo);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdateMessage);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.chkBranchID);
            this.splitContainer1.Panel1.Controls.Add(this.chkSelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ADGVMarketing);
            // 
            // btnSendSms
            // 
            this.btnSendSms.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSendSms.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendSms.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSendSms.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSendSms, "btnSendSms");
            this.btnSendSms.ForeColor = System.Drawing.Color.White;
            this.btnSendSms.Image = global::ClassManager.Properties.Resources.icon_sms;
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.UseVisualStyleBackColor = false;
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::ClassManager.Properties.Resources.icon_excel;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtnTrans
            // 
            resources.ApplyResources(this.rbtnTrans, "rbtnTrans");
            this.rbtnTrans.Checked = true;
            this.rbtnTrans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtnTrans.Name = "rbtnTrans";
            this.rbtnTrans.TabStop = true;
            this.rbtnTrans.UseVisualStyleBackColor = true;
            this.rbtnTrans.CheckedChanged += new System.EventHandler(this.rbtnTrans_CheckedChanged);
            // 
            // rbtnPromo
            // 
            resources.ApplyResources(this.rbtnPromo, "rbtnPromo");
            this.rbtnPromo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.rbtnPromo.Name = "rbtnPromo";
            this.rbtnPromo.TabStop = true;
            this.rbtnPromo.UseVisualStyleBackColor = true;
            this.rbtnPromo.CheckedChanged += new System.EventHandler(this.rbtnPromo_CheckedChanged);
            // 
            // btnUpdateMessage
            // 
            resources.ApplyResources(this.btnUpdateMessage, "btnUpdateMessage");
            this.btnUpdateMessage.BackColor = System.Drawing.Color.White;
            this.btnUpdateMessage.Depth = 0;
            this.btnUpdateMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdateMessage.Name = "btnUpdateMessage";
            this.btnUpdateMessage.Primary = true;
            this.btnUpdateMessage.UseVisualStyleBackColor = false;
            this.btnUpdateMessage.Click += new System.EventHandler(this.btnUpdateMessage_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtMarketingMessage);
            this.panel2.Controls.Add(this.label4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // txtMarketingMessage
            // 
            resources.ApplyResources(this.txtMarketingMessage, "txtMarketingMessage");
            this.txtMarketingMessage.Name = "txtMarketingMessage";
            this.txtMarketingMessage.TextChanged += new System.EventHandler(this.txtMarketingMessage_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label4.Name = "label4";
            // 
            // chkBranchID
            // 
            resources.ApplyResources(this.chkBranchID, "chkBranchID");
            this.chkBranchID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkBranchID.Name = "chkBranchID";
            this.chkBranchID.TabStop = false;
            this.chkBranchID.UseVisualStyleBackColor = true;
            this.chkBranchID.CheckedChanged += new System.EventHandler(this.chkBranchID_CheckedChanged);
            // 
            // chkSelectAll
            // 
            resources.ApplyResources(this.chkSelectAll, "chkSelectAll");
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label11.Name = "label11";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbViewMaketingData);
            this.panel1.Controls.Add(this.cmbCourseNm);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label2.Name = "label2";
            // 
            // cmbViewMaketingData
            // 
            this.cmbViewMaketingData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewMaketingData.FormattingEnabled = true;
            this.cmbViewMaketingData.Items.AddRange(new object[] {
            resources.GetString("cmbViewMaketingData.Items"),
            resources.GetString("cmbViewMaketingData.Items1"),
            resources.GetString("cmbViewMaketingData.Items2"),
            resources.GetString("cmbViewMaketingData.Items3")});
            resources.ApplyResources(this.cmbViewMaketingData, "cmbViewMaketingData");
            this.cmbViewMaketingData.Name = "cmbViewMaketingData";
            this.cmbViewMaketingData.SelectedIndexChanged += new System.EventHandler(this.cmbViewMaketingData_SelectedIndexChanged);
            // 
            // cmbCourseNm
            // 
            this.cmbCourseNm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseNm.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCourseNm, "cmbCourseNm");
            this.cmbCourseNm.Name = "cmbCourseNm";
            this.cmbCourseNm.SelectedIndexChanged += new System.EventHandler(this.cmbCourseNm_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(75)))), ((int)(((byte)(104)))));
            this.label1.Name = "label1";
            // 
            // ADGVMarketing
            // 
            this.ADGVMarketing.AllowUserToAddRows = false;
            this.ADGVMarketing.AllowUserToDeleteRows = false;
            this.ADGVMarketing.AllowUserToResizeRows = false;
            this.ADGVMarketing.AutoGenerateContextFilters = true;
            this.ADGVMarketing.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ADGVMarketing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ADGVMarketing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ADGVMarketing.DateWithTime = false;
            resources.ApplyResources(this.ADGVMarketing, "ADGVMarketing");
            this.ADGVMarketing.Name = "ADGVMarketing";
            this.ADGVMarketing.ReadOnly = true;
            this.ADGVMarketing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ADGVMarketing.TimeFilter = false;
            this.ADGVMarketing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarketing_CellClick);
            this.ADGVMarketing.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ADGVMarketing_DataBindingComplete);
            this.ADGVMarketing.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ADGVMarketing_RowPostPaint);
            // 
            // bgwMarketingSms
            // 
            this.bgwMarketingSms.WorkerReportsProgress = true;
            this.bgwMarketingSms.WorkerSupportsCancellation = true;
            this.bgwMarketingSms.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMarketingSms_DoWork);
            this.bgwMarketingSms.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMarketingSms_RunWorkerCompleted);
            // 
            // FrmMarketing
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "FrmMarketing";
            this.Load += new System.EventHandler(this.Marketing_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADGVMarketing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBranchID;
        private System.Windows.Forms.ComboBox cmbCourseNm;
        private System.Windows.Forms.ComboBox cmbViewMaketingData;
        private System.Windows.Forms.Label label2;
        private ADGV.AdvancedDataGridView ADGVMarketing;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdateMessage;
        private System.Windows.Forms.TextBox txtMarketingMessage;
        private System.ComponentModel.BackgroundWorker bgwMarketingSms;
        private System.Windows.Forms.RadioButton rbtnTrans;
        private System.Windows.Forms.RadioButton rbtnPromo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSendSms;
    }
}
