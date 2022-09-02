namespace XternalDevLib
{
    partial class frmDetailedMultiGvRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedMultiGvRpt));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbxEndDate = new System.Windows.Forms.PictureBox();
            this.pbxStartDate = new System.Windows.Forms.PictureBox();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.gbx = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).BeginInit();
            this.gbTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.gbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(110, 58);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(185, 20);
            this.dtpEndDate.TabIndex = 18;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(110, 23);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(185, 20);
            this.dtpStartDate.TabIndex = 17;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(9, 62);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(51, 13);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(9, 27);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(57, 13);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Start Date";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(965, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(885, 493);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbxEndDate
            // 
            this.pbxEndDate.Image = ((System.Drawing.Image)(resources.GetObject("pbxEndDate.Image")));
            this.pbxEndDate.Location = new System.Drawing.Point(294, 58);
            this.pbxEndDate.Name = "pbxEndDate";
            this.pbxEndDate.Size = new System.Drawing.Size(16, 21);
            this.pbxEndDate.TabIndex = 25;
            this.pbxEndDate.TabStop = false;
            this.pbxEndDate.Click += new System.EventHandler(this.pbxEndDate_Click);
            // 
            // pbxStartDate
            // 
            this.pbxStartDate.Image = ((System.Drawing.Image)(resources.GetObject("pbxStartDate.Image")));
            this.pbxStartDate.Location = new System.Drawing.Point(294, 23);
            this.pbxStartDate.Name = "pbxStartDate";
            this.pbxStartDate.Size = new System.Drawing.Size(16, 21);
            this.pbxStartDate.TabIndex = 24;
            this.pbxStartDate.TabStop = false;
            this.pbxStartDate.Click += new System.EventHandler(this.pbxStartDate_Click);
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.gvList);
            this.gbTitle.Location = new System.Drawing.Point(12, 12);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(742, 504);
            this.gbTitle.TabIndex = 25;
            this.gbTitle.TabStop = false;
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.gvList.Location = new System.Drawing.Point(16, 16);
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            this.gvList.Size = new System.Drawing.Size(712, 474);
            this.gvList.TabIndex = 0;
            this.gvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellContentClick);
            this.gvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellDoubleClick);
            // 
            // gbx
            // 
            this.gbx.AutoScroll = true;
            this.gbx.Controls.Add(this.pbxEndDate);
            this.gbx.Controls.Add(this.lblStartDate);
            this.gbx.Controls.Add(this.pbxStartDate);
            this.gbx.Controls.Add(this.dtpEndDate);
            this.gbx.Controls.Add(this.dtpStartDate);
            this.gbx.Controls.Add(this.lblEndDate);
            this.gbx.Location = new System.Drawing.Point(760, 12);
            this.gbx.Name = "gbx";
            this.gbx.Size = new System.Drawing.Size(327, 457);
            this.gbx.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(804, 493);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(804, 470);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(69, 17);
            this.chkAll.TabIndex = 28;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chk
            // 
            this.chk.HeaderText = "Select";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 50;
            // 
            // frmDetailedMultiGvRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 561);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbx);
            this.Controls.Add(this.gbTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedMultiGvRpt";
            this.Text = "frmDetailedMultiGvRpt";
            this.Load += new System.EventHandler(this.frmDetailedMultiGvRpt_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmDetailedMultiGvRpt_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).EndInit();
            this.gbTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.gbx.ResumeLayout(false);
            this.gbx.PerformLayout();
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
        public System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.DataGridView gvList;
        public System.Windows.Forms.Panel gbx;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
    }
}