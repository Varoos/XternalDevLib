namespace XternalDevLib
{
    partial class frmSearchBy2Tag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchBy2Tag));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbxStartDate = new System.Windows.Forms.PictureBox();
            this.pbxEndDate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(160, 47);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(185, 20);
            this.dtpEndDate.TabIndex = 18;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(160, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(185, 20);
            this.dtpStartDate.TabIndex = 17;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(50, 51);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(51, 13);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(50, 16);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(57, 13);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Start Date";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(200, 174);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(120, 174);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbxStartDate
            // 
            this.pbxStartDate.Image = ((System.Drawing.Image)(resources.GetObject("pbxStartDate.Image")));
            this.pbxStartDate.Location = new System.Drawing.Point(344, 12);
            this.pbxStartDate.Name = "pbxStartDate";
            this.pbxStartDate.Size = new System.Drawing.Size(16, 21);
            this.pbxStartDate.TabIndex = 23;
            this.pbxStartDate.TabStop = false;
            this.pbxStartDate.Click += new System.EventHandler(this.pbxStartDate_Click);
            // 
            // pbxEndDate
            // 
            this.pbxEndDate.Image = ((System.Drawing.Image)(resources.GetObject("pbxEndDate.Image")));
            this.pbxEndDate.Location = new System.Drawing.Point(345, 47);
            this.pbxEndDate.Name = "pbxEndDate";
            this.pbxEndDate.Size = new System.Drawing.Size(16, 21);
            this.pbxEndDate.TabIndex = 24;
            this.pbxEndDate.TabStop = false;
            this.pbxEndDate.Click += new System.EventHandler(this.pbxEndDate_Click);
            // 
            // frmSearchBy2Tag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 245);
            this.Controls.Add(this.pbxEndDate);
            this.Controls.Add(this.pbxStartDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSearchBy2Tag";
            this.Text = "frmSearchBy2Tag";
            this.Load += new System.EventHandler(this.frmSearchBy2Tag_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSearchBy2Tag_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dtpEndDate;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        public System.Windows.Forms.Label lblEndDate;
        public System.Windows.Forms.Label lblStartDate;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.PictureBox pbxStartDate;
        public System.Windows.Forms.PictureBox pbxEndDate;
    }
}