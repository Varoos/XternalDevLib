namespace XternalDevLib
{
    partial class ExternalDevList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalDevList));
            this.btnRestoreBAK = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnRestoreBAK
            // 
            this.btnRestoreBAK.AutoSize = true;
            this.btnRestoreBAK.Location = new System.Drawing.Point(34, 27);
            this.btnRestoreBAK.Name = "btnRestoreBAK";
            this.btnRestoreBAK.Size = new System.Drawing.Size(69, 13);
            this.btnRestoreBAK.TabIndex = 0;
            this.btnRestoreBAK.TabStop = true;
            this.btnRestoreBAK.Text = "Restore .bak";
            this.btnRestoreBAK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRestoreBAK_LinkClicked);
            // 
            // ExternalDevList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 510);
            this.Controls.Add(this.btnRestoreBAK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExternalDevList";
            this.Text = "External Development List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnRestoreBAK;
    }
}