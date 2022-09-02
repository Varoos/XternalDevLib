namespace XternalDevLib
{
    partial class frmGvReportFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGvReportFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxConjunction = new System.Windows.Forms.ComboBox();
            this.cbxField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOperator = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gvFilter = new System.Windows.Forms.DataGridView();
            this.Conjunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conjunction";
            // 
            // cbxConjunction
            // 
            this.cbxConjunction.FormattingEnabled = true;
            this.cbxConjunction.Items.AddRange(new object[] {
            "WHERE",
            "WHERE (",
            "AND",
            "AND (",
            ") AND",
            ") AND (",
            "OR",
            "OR (",
            ") OR",
            ") OR ("});
            this.cbxConjunction.Location = new System.Drawing.Point(12, 32);
            this.cbxConjunction.Name = "cbxConjunction";
            this.cbxConjunction.Size = new System.Drawing.Size(121, 21);
            this.cbxConjunction.TabIndex = 1;
            // 
            // cbxField
            // 
            this.cbxField.FormattingEnabled = true;
            this.cbxField.Location = new System.Drawing.Point(143, 32);
            this.cbxField.Name = "cbxField";
            this.cbxField.Size = new System.Drawing.Size(121, 21);
            this.cbxField.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Field";
            // 
            // cbxOperator
            // 
            this.cbxOperator.FormattingEnabled = true;
            this.cbxOperator.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "Contains",
            "Less Than",
            "Greater Than",
            "Less Than Or Equal To",
            "Greater Than Or Equal To",
            "Is Blank",
            "Is Not Blank"});
            this.cbxOperator.Location = new System.Drawing.Point(275, 32);
            this.cbxOperator.Name = "cbxOperator";
            this.cbxOperator.Size = new System.Drawing.Size(121, 21);
            this.cbxOperator.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Value";
            // 
            // gvFilter
            // 
            this.gvFilter.AllowUserToAddRows = false;
            this.gvFilter.AllowUserToOrderColumns = true;
            this.gvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conjunction,
            this.Field,
            this.Operator,
            this.Value});
            this.gvFilter.Location = new System.Drawing.Point(12, 71);
            this.gvFilter.Name = "gvFilter";
            this.gvFilter.ReadOnly = true;
            this.gvFilter.Size = new System.Drawing.Size(618, 157);
            this.gvFilter.TabIndex = 8;
            // 
            // Conjunction
            // 
            this.Conjunction.HeaderText = "Conjunction";
            this.Conjunction.Name = "Conjunction";
            this.Conjunction.ReadOnly = true;
            // 
            // Field
            // 
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            this.Field.ReadOnly = true;
            // 
            // Operator
            // 
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(407, 32);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(128, 20);
            this.txtValue.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(541, 32);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "A";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(604, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "C";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(572, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "S";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmGvReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 243);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.gvFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxConjunction);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGvReportFilter";
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.frmGvReportFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbxConjunction;
        public System.Windows.Forms.ComboBox cbxField;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbxOperator;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView gvFilter;
        public System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conjunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}