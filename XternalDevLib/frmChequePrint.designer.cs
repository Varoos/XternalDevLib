namespace XternalDevLib
{
    partial class frmChequePrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChequePrint));
            this.cbxCheque = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeaderId = new System.Windows.Forms.Label();
            this.lblVType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxCheque
            // 
            this.cbxCheque.FormattingEnabled = true;
            this.cbxCheque.Location = new System.Drawing.Point(28, 22);
            this.cbxCheque.Name = "cbxCheque";
            this.cbxCheque.Size = new System.Drawing.Size(250, 21);
            this.cbxCheque.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(62, 65);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(143, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeaderId
            // 
            this.lblHeaderId.AutoSize = true;
            this.lblHeaderId.Location = new System.Drawing.Point(243, 90);
            this.lblHeaderId.Name = "lblHeaderId";
            this.lblHeaderId.Size = new System.Drawing.Size(13, 13);
            this.lblHeaderId.TabIndex = 3;
            this.lblHeaderId.Text = "0";
            this.lblHeaderId.Visible = false;
            // 
            // lblVType
            // 
            this.lblVType.AutoSize = true;
            this.lblVType.Location = new System.Drawing.Point(265, 90);
            this.lblVType.Name = "lblVType";
            this.lblVType.Size = new System.Drawing.Size(13, 13);
            this.lblVType.TabIndex = 4;
            this.lblVType.Text = "0";
            this.lblVType.Visible = false;
            // 
            // frmChequePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 112);
            this.Controls.Add(this.lblVType);
            this.Controls.Add(this.lblHeaderId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbxCheque);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChequePrint";
            this.Text = "Cheque Print";
            this.Load += new System.EventHandler(this.frmChequePrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCheque;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblHeaderId;
        public System.Windows.Forms.Label lblVType;
    }
}