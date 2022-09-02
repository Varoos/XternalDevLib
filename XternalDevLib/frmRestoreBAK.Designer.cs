namespace XternalDevLib
{
    partial class frmRestoreBAK
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnExisting = new System.Windows.Forms.RadioButton();
            this.rbtnNew = new System.Windows.Forms.RadioButton();
            this.lblDataBse = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnNew);
            this.groupBox1.Controls.Add(this.rbtnExisting);
            this.groupBox1.Location = new System.Drawing.Point(70, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 36);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbtnExisting
            // 
            this.rbtnExisting.AutoSize = true;
            this.rbtnExisting.Location = new System.Drawing.Point(58, 9);
            this.rbtnExisting.Name = "rbtnExisting";
            this.rbtnExisting.Size = new System.Drawing.Size(62, 17);
            this.rbtnExisting.TabIndex = 0;
            this.rbtnExisting.TabStop = true;
            this.rbtnExisting.Text = "Existing";
            this.rbtnExisting.UseVisualStyleBackColor = true;
            // 
            // rbtnNew
            // 
            this.rbtnNew.AutoSize = true;
            this.rbtnNew.Location = new System.Drawing.Point(6, 9);
            this.rbtnNew.Name = "rbtnNew";
            this.rbtnNew.Size = new System.Drawing.Size(46, 17);
            this.rbtnNew.TabIndex = 1;
            this.rbtnNew.TabStop = true;
            this.rbtnNew.Text = "New";
            this.rbtnNew.UseVisualStyleBackColor = true;
            // 
            // lblDataBse
            // 
            this.lblDataBse.AutoSize = true;
            this.lblDataBse.Location = new System.Drawing.Point(15, 61);
            this.lblDataBse.Name = "lblDataBse";
            this.lblDataBse.Size = new System.Drawing.Size(53, 13);
            this.lblDataBse.TabIndex = 1;
            this.lblDataBse.Text = "DataBase";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(116, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Company Code";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(60, 179);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(141, 179);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRestoreBAK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 231);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblDataBse);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRestoreBAK";
            this.Text = "frmRestoreBAK";
            this.Load += new System.EventHandler(this.frmRestoreBAK_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnNew;
        private System.Windows.Forms.RadioButton rbtnExisting;
        private System.Windows.Forms.Label lblDataBse;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
    }
}