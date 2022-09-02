namespace XternalDevLib
{
    partial class frmMultiSearchGv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiSearchGv));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabMultiSearch = new System.Windows.Forms.TabControl();
            this.gbx = new System.Windows.Forms.GroupBox();
            this.pbxEndDate = new System.Windows.Forms.PictureBox();
            this.pbxStartDate = new System.Windows.Forms.PictureBox();
            this.gbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(105, 60);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(185, 20);
            this.dtpEndDate.TabIndex = 18;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(105, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(185, 20);
            this.dtpStartDate.TabIndex = 17;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(8, 64);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(51, 13);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(8, 29);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(57, 13);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Start Date";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(943, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(863, 506);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabMultiSearch
            // 
            this.tabMultiSearch.Location = new System.Drawing.Point(12, 12);
            this.tabMultiSearch.Name = "tabMultiSearch";
            this.tabMultiSearch.Padding = new System.Drawing.Point(10, 7);
            this.tabMultiSearch.SelectedIndex = 0;
            this.tabMultiSearch.Size = new System.Drawing.Size(742, 530);
            this.tabMultiSearch.TabIndex = 23;
            // 
            // gbx
            // 
            this.gbx.Controls.Add(this.pbxEndDate);
            this.gbx.Controls.Add(this.pbxStartDate);
            this.gbx.Controls.Add(this.lblStartDate);
            this.gbx.Controls.Add(this.lblEndDate);
            this.gbx.Controls.Add(this.dtpStartDate);
            this.gbx.Controls.Add(this.dtpEndDate);
            this.gbx.Location = new System.Drawing.Point(760, 28);
            this.gbx.Name = "gbx";
            this.gbx.Size = new System.Drawing.Size(322, 469);
            this.gbx.TabIndex = 24;
            this.gbx.TabStop = false;
            // 
            // pbxEndDate
            // 
            this.pbxEndDate.Image = ((System.Drawing.Image)(resources.GetObject("pbxEndDate.Image")));
            this.pbxEndDate.Location = new System.Drawing.Point(289, 60);
            this.pbxEndDate.Name = "pbxEndDate";
            this.pbxEndDate.Size = new System.Drawing.Size(16, 21);
            this.pbxEndDate.TabIndex = 25;
            this.pbxEndDate.TabStop = false;
            this.pbxEndDate.Click += new System.EventHandler(this.pbxEndDate_Click);
            // 
            // pbxStartDate
            // 
            this.pbxStartDate.Image = ((System.Drawing.Image)(resources.GetObject("pbxStartDate.Image")));
            this.pbxStartDate.Location = new System.Drawing.Point(289, 25);
            this.pbxStartDate.Name = "pbxStartDate";
            this.pbxStartDate.Size = new System.Drawing.Size(16, 21);
            this.pbxStartDate.TabIndex = 24;
            this.pbxStartDate.TabStop = false;
            this.pbxStartDate.Click += new System.EventHandler(this.pbxStartDate_Click);
            // 
            // frmMultiSearchGv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 554);
            this.Controls.Add(this.tabMultiSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMultiSearchGv";
            this.Text = "frmSearchBy1Tag";
            this.Load += new System.EventHandler(this.frmMultiSearchGv_Load);
            this.gbx.ResumeLayout(false);
            this.gbx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dtpEndDate;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        public System.Windows.Forms.Label lblEndDate;
        public System.Windows.Forms.Label lblStartDate;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.TabControl tabMultiSearch;
        public System.Windows.Forms.GroupBox gbx;
        public System.Windows.Forms.PictureBox pbxStartDate;
        public System.Windows.Forms.PictureBox pbxEndDate;
    }
}