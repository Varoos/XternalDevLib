namespace XternalDevLib
{
    partial class UpdateDocNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDocNo));
            this.cbxVoucherType = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxSeprator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTagCode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxVoucherType
            // 
            this.cbxVoucherType.FormattingEnabled = true;
            this.cbxVoucherType.Location = new System.Drawing.Point(104, 36);
            this.cbxVoucherType.Name = "cbxVoucherType";
            this.cbxVoucherType.Size = new System.Drawing.Size(184, 21);
            this.cbxVoucherType.TabIndex = 10;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(90, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Voucher Type";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(171, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxSeprator
            // 
            this.cbxSeprator.FormattingEnabled = true;
            this.cbxSeprator.Items.AddRange(new object[] {
            "-",
            "/"});
            this.cbxSeprator.Location = new System.Drawing.Point(104, 89);
            this.cbxSeprator.Name = "cbxSeprator";
            this.cbxSeprator.Size = new System.Drawing.Size(184, 21);
            this.cbxSeprator.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Seprator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tag Code";
            // 
            // cbxTagCode
            // 
            this.cbxTagCode.FormattingEnabled = true;
            this.cbxTagCode.Items.AddRange(new object[] {
            "FA",
            "Inv"});
            this.cbxTagCode.Location = new System.Drawing.Point(104, 63);
            this.cbxTagCode.Name = "cbxTagCode";
            this.cbxTagCode.Size = new System.Drawing.Size(184, 21);
            this.cbxTagCode.TabIndex = 15;
            // 
            // UpdateDocNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxTagCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSeprator);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxVoucherType);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDocNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateDocNo";
            this.Load += new System.EventHandler(this.UpdateDocNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxVoucherType;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbxSeprator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTagCode;
    }
}