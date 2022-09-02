namespace XternalDevLib
{
    partial class frmMultiSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiSearch));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabPg0 = new System.Windows.Forms.TabPage();
            this.lblIdColumnNamePg1 = new System.Windows.Forms.Label();
            this.trv0 = new System.Windows.Forms.TreeView();
            this.lblIdColumnNamePg0 = new System.Windows.Forms.Label();
            this.lblSelectedIdPg0 = new System.Windows.Forms.RichTextBox();
            this.chkAllPg0 = new System.Windows.Forms.CheckBox();
            this.gvListPg0 = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtSearchPg0 = new System.Windows.Forms.TextBox();
            this.btnSearchPg0 = new System.Windows.Forms.Button();
            this.tabMultiSearch = new System.Windows.Forms.TabControl();
            this.tabPg1 = new System.Windows.Forms.TabPage();
            this.trv1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedIdPg1 = new System.Windows.Forms.RichTextBox();
            this.chkAllPg1 = new System.Windows.Forms.CheckBox();
            this.gvListPg1 = new System.Windows.Forms.DataGridView();
            this.chk1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtSearchPg1 = new System.Windows.Forms.TextBox();
            this.btnSearchPg1 = new System.Windows.Forms.Button();
            this.gbx = new System.Windows.Forms.GroupBox();
            this.pbxEndDate = new System.Windows.Forms.PictureBox();
            this.pbxStartDate = new System.Windows.Forms.PictureBox();
            this.tabPg0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvListPg0)).BeginInit();
            this.tabMultiSearch.SuspendLayout();
            this.tabPg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvListPg1)).BeginInit();
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
            // tabPg0
            // 
            this.tabPg0.Controls.Add(this.lblIdColumnNamePg1);
            this.tabPg0.Controls.Add(this.trv0);
            this.tabPg0.Controls.Add(this.lblIdColumnNamePg0);
            this.tabPg0.Controls.Add(this.lblSelectedIdPg0);
            this.tabPg0.Controls.Add(this.chkAllPg0);
            this.tabPg0.Controls.Add(this.gvListPg0);
            this.tabPg0.Controls.Add(this.txtSearchPg0);
            this.tabPg0.Controls.Add(this.btnSearchPg0);
            this.tabPg0.Location = new System.Drawing.Point(4, 30);
            this.tabPg0.Name = "tabPg0";
            this.tabPg0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg0.Size = new System.Drawing.Size(734, 496);
            this.tabPg0.TabIndex = 0;
            this.tabPg0.UseVisualStyleBackColor = true;
            // 
            // lblIdColumnNamePg1
            // 
            this.lblIdColumnNamePg1.AutoSize = true;
            this.lblIdColumnNamePg1.Location = new System.Drawing.Point(649, 17);
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
            this.trv0.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv0_AfterSelect);
            // 
            // lblIdColumnNamePg0
            // 
            this.lblIdColumnNamePg0.AutoSize = true;
            this.lblIdColumnNamePg0.Location = new System.Drawing.Point(564, 20);
            this.lblIdColumnNamePg0.Name = "lblIdColumnNamePg0";
            this.lblIdColumnNamePg0.Size = new System.Drawing.Size(0, 13);
            this.lblIdColumnNamePg0.TabIndex = 8;
            this.lblIdColumnNamePg0.Visible = false;
            // 
            // lblSelectedIdPg0
            // 
            this.lblSelectedIdPg0.AutoSize = true;
            this.lblSelectedIdPg0.Location = new System.Drawing.Point(554, 13);
            this.lblSelectedIdPg0.Name = "lblSelectedIdPg0";
            this.lblSelectedIdPg0.Size = new System.Drawing.Size(78, 19);
            this.lblSelectedIdPg0.TabIndex = 7;
            this.lblSelectedIdPg0.Text = "0";
            this.lblSelectedIdPg0.Visible = false;
            // 
            // chkAllPg0
            // 
            this.chkAllPg0.AutoSize = true;
            this.chkAllPg0.Location = new System.Drawing.Point(475, 18);
            this.chkAllPg0.Name = "chkAllPg0";
            this.chkAllPg0.Size = new System.Drawing.Size(69, 17);
            this.chkAllPg0.TabIndex = 6;
            this.chkAllPg0.Text = "Select All";
            this.chkAllPg0.UseVisualStyleBackColor = true;
            this.chkAllPg0.CheckedChanged += new System.EventHandler(this.chkAllPg0_CheckedChanged);
            // 
            // gvListPg0
            // 
            this.gvListPg0.AllowUserToAddRows = false;
            this.gvListPg0.AllowUserToDeleteRows = false;
            this.gvListPg0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListPg0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.gvListPg0.Location = new System.Drawing.Point(261, 40);
            this.gvListPg0.Name = "gvListPg0";
            this.gvListPg0.Size = new System.Drawing.Size(455, 455);
            this.gvListPg0.TabIndex = 5;
            this.gvListPg0.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListPg0_CellContentClick);
            // 
            // chk
            // 
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.Width = 25;
            // 
            // txtSearchPg0
            // 
            this.txtSearchPg0.Location = new System.Drawing.Point(262, 14);
            this.txtSearchPg0.Name = "txtSearchPg0";
            this.txtSearchPg0.Size = new System.Drawing.Size(170, 20);
            this.txtSearchPg0.TabIndex = 2;
            // 
            // btnSearchPg0
            // 
            this.btnSearchPg0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchPg0.BackgroundImage")));
            this.btnSearchPg0.Location = new System.Drawing.Point(430, 13);
            this.btnSearchPg0.Name = "btnSearchPg0";
            this.btnSearchPg0.Size = new System.Drawing.Size(26, 22);
            this.btnSearchPg0.TabIndex = 3;
            this.btnSearchPg0.UseVisualStyleBackColor = true;
            this.btnSearchPg0.Click += new System.EventHandler(this.btnSearchPg0_Click);
            // 
            // tabMultiSearch
            // 
            this.tabMultiSearch.Controls.Add(this.tabPg0);
            this.tabMultiSearch.Controls.Add(this.tabPg1);
            this.tabMultiSearch.Location = new System.Drawing.Point(12, 12);
            this.tabMultiSearch.Name = "tabMultiSearch";
            this.tabMultiSearch.Padding = new System.Drawing.Point(10, 7);
            this.tabMultiSearch.SelectedIndex = 0;
            this.tabMultiSearch.Size = new System.Drawing.Size(742, 530);
            this.tabMultiSearch.TabIndex = 23;
            // 
            // tabPg1
            // 
            this.tabPg1.Controls.Add(this.trv1);
            this.tabPg1.Controls.Add(this.label1);
            this.tabPg1.Controls.Add(this.lblSelectedIdPg1);
            this.tabPg1.Controls.Add(this.chkAllPg1);
            this.tabPg1.Controls.Add(this.gvListPg1);
            this.tabPg1.Controls.Add(this.txtSearchPg1);
            this.tabPg1.Controls.Add(this.btnSearchPg1);
            this.tabPg1.Location = new System.Drawing.Point(4, 30);
            this.tabPg1.Name = "tabPg1";
            this.tabPg1.Size = new System.Drawing.Size(734, 496);
            this.tabPg1.TabIndex = 0;
            this.tabPg1.UseVisualStyleBackColor = true;
            // 
            // trv1
            // 
            this.trv1.Location = new System.Drawing.Point(6, 42);
            this.trv1.Name = "trv1";
            this.trv1.Size = new System.Drawing.Size(249, 453);
            this.trv1.TabIndex = 9;
            this.trv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv1_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            this.label1.Visible = false;
            // 
            // lblSelectedIdPg1
            // 
            this.lblSelectedIdPg1.AutoSize = true;
            this.lblSelectedIdPg1.Location = new System.Drawing.Point(554, 13);
            this.lblSelectedIdPg1.Name = "lblSelectedIdPg1";
            this.lblSelectedIdPg1.Size = new System.Drawing.Size(78, 19);
            this.lblSelectedIdPg1.TabIndex = 14;
            this.lblSelectedIdPg1.Text = "0";
            this.lblSelectedIdPg1.Visible = false;
            // 
            // chkAllPg1
            // 
            this.chkAllPg1.AutoSize = true;
            this.chkAllPg1.Location = new System.Drawing.Point(475, 18);
            this.chkAllPg1.Name = "chkAllPg1";
            this.chkAllPg1.Size = new System.Drawing.Size(69, 17);
            this.chkAllPg1.TabIndex = 13;
            this.chkAllPg1.Text = "Select All";
            this.chkAllPg1.UseVisualStyleBackColor = true;
            this.chkAllPg1.CheckedChanged += new System.EventHandler(this.chkAllPg1_CheckedChanged);
            // 
            // gvListPg1
            // 
            this.gvListPg1.AllowUserToAddRows = false;
            this.gvListPg1.AllowUserToDeleteRows = false;
            this.gvListPg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListPg1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk1});
            this.gvListPg1.Location = new System.Drawing.Point(261, 40);
            this.gvListPg1.Name = "gvListPg1";
            this.gvListPg1.Size = new System.Drawing.Size(466, 455);
            this.gvListPg1.TabIndex = 12;
            this.gvListPg1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListPg1_CellContentClick);
            // 
            // chk1
            // 
            this.chk1.HeaderText = "";
            this.chk1.Name = "chk1";
            this.chk1.Width = 25;
            // 
            // txtSearchPg1
            // 
            this.txtSearchPg1.Location = new System.Drawing.Point(262, 14);
            this.txtSearchPg1.Name = "txtSearchPg1";
            this.txtSearchPg1.Size = new System.Drawing.Size(170, 20);
            this.txtSearchPg1.TabIndex = 10;
            // 
            // btnSearchPg1
            // 
            this.btnSearchPg1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchPg1.BackgroundImage")));
            this.btnSearchPg1.Location = new System.Drawing.Point(430, 13);
            this.btnSearchPg1.Name = "btnSearchPg1";
            this.btnSearchPg1.Size = new System.Drawing.Size(26, 22);
            this.btnSearchPg1.TabIndex = 11;
            this.btnSearchPg1.UseVisualStyleBackColor = true;
            this.btnSearchPg1.Click += new System.EventHandler(this.btnSearchPg1_Click);
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
            // frmMultiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 554);
            this.Controls.Add(this.tabMultiSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMultiSearch";
            this.Text = "frmSearchBy1Tag";
            this.Load += new System.EventHandler(this.frmMultiSearch_Load);
            this.tabPg0.ResumeLayout(false);
            this.tabPg0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvListPg0)).EndInit();
            this.tabMultiSearch.ResumeLayout(false);
            this.tabPg1.ResumeLayout(false);
            this.tabPg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvListPg1)).EndInit();
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
        public System.Windows.Forms.DataGridView gvListPg0;
        public System.Windows.Forms.CheckBox chkAllPg0;
        public System.Windows.Forms.TabPage tabPg0;
        public System.Windows.Forms.TabControl tabMultiSearch;
        public System.Windows.Forms.TextBox txtSearchPg0;
        public System.Windows.Forms.Button btnSearchPg0;
        public System.Windows.Forms.Label lblIdColumnNamePg0;
        public System.Windows.Forms.RichTextBox lblSelectedIdPg0;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        public System.Windows.Forms.GroupBox gbx;
        public System.Windows.Forms.PictureBox pbxStartDate;
        public System.Windows.Forms.PictureBox pbxEndDate;
        public System.Windows.Forms.TreeView trv0;
        public System.Windows.Forms.TreeView trv1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox lblSelectedIdPg1;
        public System.Windows.Forms.CheckBox chkAllPg1;
        public System.Windows.Forms.DataGridView gvListPg1;
        public System.Windows.Forms.TextBox txtSearchPg1;
        public System.Windows.Forms.Button btnSearchPg1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk1;
        public System.Windows.Forms.Label lblIdColumnNamePg1;
        public System.Windows.Forms.TabPage tabPg1;
    }
}