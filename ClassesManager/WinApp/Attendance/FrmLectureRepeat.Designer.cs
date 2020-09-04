namespace ClassManager.WinApp
{
    partial class FrmLectureRepeat
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
            this.rbtnDaily = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnWeekly = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnMonthly = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnSave = new MaterialSkin.Controls.MaterialFlatButton();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // rbtnDaily
            // 
            this.rbtnDaily.AutoSize = true;
            this.rbtnDaily.Depth = 0;
            this.rbtnDaily.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnDaily.Location = new System.Drawing.Point(95, 80);
            this.rbtnDaily.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnDaily.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnDaily.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnDaily.Name = "rbtnDaily";
            this.rbtnDaily.Ripple = true;
            this.rbtnDaily.Size = new System.Drawing.Size(59, 30);
            this.rbtnDaily.TabIndex = 0;
            this.rbtnDaily.TabStop = true;
            this.rbtnDaily.Text = "Daily";
            this.rbtnDaily.UseVisualStyleBackColor = true;
            // 
            // rbtnWeekly
            // 
            this.rbtnWeekly.AutoSize = true;
            this.rbtnWeekly.Depth = 0;
            this.rbtnWeekly.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnWeekly.Location = new System.Drawing.Point(95, 120);
            this.rbtnWeekly.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnWeekly.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnWeekly.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnWeekly.Name = "rbtnWeekly";
            this.rbtnWeekly.Ripple = true;
            this.rbtnWeekly.Size = new System.Drawing.Size(73, 30);
            this.rbtnWeekly.TabIndex = 1;
            this.rbtnWeekly.TabStop = true;
            this.rbtnWeekly.Text = "Weekly";
            this.rbtnWeekly.UseVisualStyleBackColor = true;
            // 
            // rbtnMonthly
            // 
            this.rbtnMonthly.AutoSize = true;
            this.rbtnMonthly.Depth = 0;
            this.rbtnMonthly.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnMonthly.Location = new System.Drawing.Point(95, 159);
            this.rbtnMonthly.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnMonthly.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnMonthly.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnMonthly.Name = "rbtnMonthly";
            this.rbtnMonthly.Ripple = true;
            this.rbtnMonthly.Size = new System.Drawing.Size(79, 30);
            this.rbtnMonthly.TabIndex = 2;
            this.rbtnMonthly.TabStop = true;
            this.rbtnMonthly.Text = "Monthly";
            this.rbtnMonthly.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(95, 239);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = false;
            this.btnSave.Size = new System.Drawing.Size(30, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(95, 210);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(95, 20);
            this.dtpDate.TabIndex = 3;
            // 
            // FrmLectureRepeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 300);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbtnMonthly);
            this.Controls.Add(this.rbtnWeekly);
            this.Controls.Add(this.rbtnDaily);
            this.MaximizeBox = false;
            this.Name = "FrmLectureRepeat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repeat";
            this.Load += new System.EventHandler(this.FrmLectureRepeat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRadioButton rbtnDaily;
        private MaterialSkin.Controls.MaterialRadioButton rbtnWeekly;
        private MaterialSkin.Controls.MaterialRadioButton rbtnMonthly;
        private MaterialSkin.Controls.MaterialFlatButton btnSave;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}
