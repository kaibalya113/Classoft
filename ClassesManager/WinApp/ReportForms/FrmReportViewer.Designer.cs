namespace ClassManager.WinApp
{
    partial class FrmReportViewer
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystlRprtViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystlRprtViewer);
            this.panel1.Location = new System.Drawing.Point(5, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 519);
            this.panel1.TabIndex = 1;
            // 
            // crystlRprtViewer
            // 
            this.crystlRprtViewer.ActiveViewIndex = -1;
            this.crystlRprtViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystlRprtViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystlRprtViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystlRprtViewer.Location = new System.Drawing.Point(0, 0);
            this.crystlRprtViewer.Name = "crystlRprtViewer";
            this.crystlRprtViewer.Size = new System.Drawing.Size(1044, 519);
            this.crystlRprtViewer.TabIndex = 0;
            // 
            // FrmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 595);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.FrmReportViewer_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystlRprtViewer;
    }
}