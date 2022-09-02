using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XternalDevLib
{
    public partial class frmGvReportFilter : Form
    {
        DevLib Xlib = new DevLib();

        public frmGvReportFilter()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(cbxConjunction);
                Xlib.UIDesign(cbxField);
                Xlib.UIDesign(cbxOperator);
                Xlib.UIDesign(txtValue);
                Xlib.UIDesign(btnAdd);
                Xlib.UIDesign(btnSearch);
                Xlib.UIDesign(btnClose);
                Xlib.UIDesign(gvFilter);
                Xlib.UIDesign(label1);
                Xlib.UIDesign(label2);
                Xlib.UIDesign(label3);
                Xlib.UIDesign(label4);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmGvReportFilter()");
            }
        }

        private void frmGvReportFilter_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmGvReportFilter_Load()");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Conjunction = Convert.ToString (cbxConjunction.SelectedItem);
                string Field = Convert.ToString(cbxField.SelectedValue);
                string Operator = Convert.ToString(cbxOperator.SelectedItem);
                string Value = txtValue.Text;

                gvFilter.Rows.Add();
                int RNo = gvFilter.Rows.Count-1 ;
                gvFilter.Rows[RNo].Cells["Conjunction"].Value = Conjunction;
                gvFilter.Rows[RNo].Cells["Field"].Value = Field;
                gvFilter.Rows[RNo].Cells["Operator"].Value = Operator;
                gvFilter.Rows[RNo].Cells["Value"].Value = Value;
                


                
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnAdd_Click()");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnSearch_Click()");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnClose_Click()");
            }
        }
    }
}
