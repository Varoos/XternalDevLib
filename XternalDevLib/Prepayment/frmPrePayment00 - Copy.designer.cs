namespace XternalDevLib
{
    partial class frmPrePayment00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrePayment00));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gbx = new System.Windows.Forms.GroupBox();
            this.pbxEndDate = new System.Windows.Forms.PictureBox();
            this.pbxStartDate = new System.Windows.Forms.PictureBox();
            this.tabList0 = new System.Windows.Forms.TabPage();
            this.gvList0 = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblIdColumnNamePg1 = new System.Windows.Forms.Label();
            this.trv0 = new System.Windows.Forms.TreeView();
            this.lblIdColumnNamePg0 = new System.Windows.Forms.Label();
            this.lblSelectedIdPg0 = new System.Windows.Forms.RichTextBox();
            this.txtSearchPg0 = new System.Windows.Forms.TextBox();
            this.chkAllPg0 = new System.Windows.Forms.CheckBox();
            this.btnSearchPg0 = new System.Windows.Forms.Button();
            this.tabGrid = new System.Windows.Forms.TabControl();
            this.gbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).BeginInit();
            this.tabList0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList0)).BeginInit();
            this.tabGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(105, 60);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(185, 20);
            this.dtpEndDate.TabIndex = 18;
            this.dtpEndDate.Visible = false;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(105, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(185, 20);
            this.dtpStartDate.TabIndex = 17;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.Date_ValueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(8, 64);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(51, 13);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "End Date";
            this.lblEndDate.Visible = false;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(8, 29);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(75, 13);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Posting Month";
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
            this.pbxEndDate.Visible = false;
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
            // tabList0
            // 
            this.tabList0.Controls.Add(this.gvList0);
            this.tabList0.Controls.Add(this.lblIdColumnNamePg1);
            this.tabList0.Controls.Add(this.trv0);
            this.tabList0.Controls.Add(this.lblIdColumnNamePg0);
            this.tabList0.Controls.Add(this.lblSelectedIdPg0);
            this.tabList0.Controls.Add(this.txtSearchPg0);
            this.tabList0.Controls.Add(this.chkAllPg0);
            this.tabList0.Controls.Add(this.btnSearchPg0);
            this.tabList0.Location = new System.Drawing.Point(4, 30);
            this.tabList0.Name = "tabList0";
            this.tabList0.Padding = new System.Windows.Forms.Padding(3);
            this.tabList0.Size = new System.Drawing.Size(734, 496);
            this.tabList0.TabIndex = 0;
            this.tabList0.UseVisualStyleBackColor = true;
            // 
            // gvList0
            // 
            this.gvList0.AllowUserToAddRows = false;
            this.gvList0.AllowUserToDeleteRows = false;
            this.gvList0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.gvList0.Location = new System.Drawing.Point(6, 40);
            this.gvList0.Name = "gvList0";
            this.gvList0.Size = new System.Drawing.Size(710, 455);
            this.gvList0.TabIndex = 5;
            this.gvList0.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListPg0_CellContentClick);
            // 
            // chk
            // 
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.Width = 25;
            // 
            // lblIdColumnNamePg1
            // 
            this.lblIdColumnNamePg1.AutoSize = true;
            this.lblIdColumnNamePg1.Location = new System.Drawing.Point(677, 17);
            this.lblIdColumnNamePg1.Name = "lblIdColumnNamePg1";
            this.lblIdColumnNamePg1.Size = new System.Drawing.Size(0, 13);
            this.lblIdColumnNamePg1.TabIndex = 9;
            this.lblIdColumnNamePg1.Visible = false;
            // 
            // trv0
            // 
            this.trv0.Location = new System.Drawing.Point(6, 42);
            this.trv0.Name = "trv0";
            this.trv0.Size = new System.Drawing.Size(249, 453);
            this.trv0.TabIndex = 0;
            this.trv0.Visible = false;
            // 
            // lblIdColumnNamePg0
            // 
            this.lblIdColumnNamePg0.AutoSize = true;
            this.lblIdColumnNamePg0.Location = new System.Drawing.Point(577, 20);
            this.lblIdColumnNamePg0.Name = "lblIdColumnNamePg0";
            this.lblIdColumnNamePg0.Size = new System.Drawing.Size(0, 13);
            this.lblIdColumnNamePg0.TabIndex = 8;
            this.lblIdColumnNamePg0.Visible = false;
            // 
            // lblSelectedIdPg0
            // 
            this.lblSelectedIdPg0.AutoSize = true;
            this.lblSelectedIdPg0.Location = new System.Drawing.Point(567, 13);
            this.lblSelectedIdPg0.Name = "lblSelectedIdPg0";
            this.lblSelectedIdPg0.Size = new System.Drawing.Size(78, 19);
            this.lblSelectedIdPg0.TabIndex = 7;
            this.lblSelectedIdPg0.Text = "0";
            this.lblSelectedIdPg0.Visible = false;
            // 
            // txtSearchPg0
            // 
            this.txtSearchPg0.Location = new System.Drawing.Point(275, 14);
            this.txtSearchPg0.Name = "txtSearchPg0";
            this.txtSearchPg0.Size = new System.Drawing.Size(170, 20);
            this.txtSearchPg0.TabIndex = 2;
            // 
            // chkAllPg0
            // 
            this.chkAllPg0.AutoSize = true;
            this.chkAllPg0.Location = new System.Drawing.Point(488, 18);
            this.chkAllPg0.Name = "chkAllPg0";
            this.chkAllPg0.Size = new System.Drawing.Size(69, 17);
            this.chkAllPg0.TabIndex = 6;
            this.chkAllPg0.Text = "Select All";
            this.chkAllPg0.UseVisualStyleBackColor = true;
            this.chkAllPg0.CheckedChanged += new System.EventHandler(this.chkAllPg0_CheckedChanged);
            // 
            // btnSearchPg0
            // 
            this.btnSearchPg0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchPg0.BackgroundImage")));
            this.btnSearchPg0.Location = new System.Drawing.Point(443, 13);
            this.btnSearchPg0.Name = "btnSearchPg0";
            this.btnSearchPg0.Size = new System.Drawing.Size(26, 22);
            this.btnSearchPg0.TabIndex = 3;
            this.btnSearchPg0.UseVisualStyleBackColor = true;
            this.btnSearchPg0.Click += new System.EventHandler(this.btnSearchPg0_Click);
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.tabList0);
            this.tabGrid.Location = new System.Drawing.Point(12, 12);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Drawing.Point(10, 7);
            this.tabGrid.SelectedIndex = 0;
            this.tabGrid.Size = new System.Drawing.Size(742, 530);
            this.tabGrid.TabIndex = 23;
            // 
            // frmPrePayment00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 554);
            this.Controls.Add(this.tabGrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrePayment00";
            this.Text = "frmSearchBy1Tag";
            this.Load += new System.EventHandler(this.frmfrmPrePayment00_Load);
            this.gbx.ResumeLayout(false);
            this.gbx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStartDate)).EndInit();
            this.tabList0.ResumeLayout(false);
            this.tabList0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList0)).EndInit();
            this.tabGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dtpEndDate;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        public System.Windows.Forms.Label lblEndDate;
        public System.Windows.Forms.Label lblStartDate;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.GroupBox gbx;
        public System.Windows.Forms.PictureBox pbxStartDate;
        public System.Windows.Forms.PictureBox pbxEndDate;
        public System.Windows.Forms.TabPage tabList0;
        public System.Windows.Forms.DataGridView gvList0;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        public System.Windows.Forms.Label lblIdColumnNamePg1;
        public System.Windows.Forms.TreeView trv0;
        public System.Windows.Forms.Label lblIdColumnNamePg0;
        public System.Windows.Forms.RichTextBox lblSelectedIdPg0;
        public System.Windows.Forms.TextBox txtSearchPg0;
        public System.Windows.Forms.CheckBox chkAllPg0;
        public System.Windows.Forms.Button btnSearchPg0;
        public System.Windows.Forms.TabControl tabGrid;
    }
}