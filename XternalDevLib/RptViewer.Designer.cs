namespace XternalDevLib
{
    partial class frmRptViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptViewer));
            this.RptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblPrint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RptViewer
            // 
            this.RptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptViewer.Location = new System.Drawing.Point(0, 0);
            this.RptViewer.Name = "RptViewer";
            this.RptViewer.Size = new System.Drawing.Size(1327, 624);
            this.RptViewer.TabIndex = 0;
            // 
            // lblPrint
            // 
            this.lblPrint.AutoSize = true;
            this.lblPrint.Location = new System.Drawing.Point(1116, 41);
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Size = new System.Drawing.Size(13, 13);
            this.lblPrint.TabIndex = 1;
            this.lblPrint.Text = "0";
            this.lblPrint.Visible = false;
            // 
            // frmRptViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 624);
            this.Controls.Add(this.lblPrint);
            this.Controls.Add(this.RptViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRptViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.frmRptViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer RptViewer;
        public System.Windows.Forms.Label lblPrint;
    }
}