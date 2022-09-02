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
    public partial class frmMultiSearchGv : Form
    {
        DevLib Xlib = new DevLib();
        DataTable dt_gvListPg0_All = new DataTable();
        DataTable dt_gvListPg1_All = new DataTable();
        public frmMultiSearchGv()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(lblStartDate);
                Xlib.UIDesign(lblEndDate);

                Xlib.UIDesign(dtpStartDate);
                Xlib.UIDesign(dtpEndDate);

                Xlib.UIDesign(btnOk);
                Xlib.UIDesign(btnClose);

               

                SetStyle(ControlStyles.SupportsTransparentBackColor, true);

                //tabMultiSearch.ColorScheme.TabBackground = Color.Transparent;
                //tabMultiSearch.ColorScheme.TabBackground2 = Color.Transparent;
                //tabMultiSearch.BackColor = Color.Transparent;

                

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmMultiSearch()");
            }
        }

        private void frmMultiSearchGv_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmMultiSearchGv_Load()");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnClose_Click()");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                btnOk.Text = "Wait...";
                btnOk.Enabled = false;

                DialogResult = DialogResult.OK;


                btnOk.Text = "Ok";
                btnOk.Enabled = true;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnOk_Click()");
            }
        }

        private void pbxStartDate_Click(object sender, EventArgs e)
        {
            try
            {
                dtpStartDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".pbxStartDate_Click()");
            }
        }

        private void pbxEndDate_Click(object sender, EventArgs e)
        {
            try
            {
                dtpEndDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".pbxEndDate_Click()");
            }
        }

       
    }
}
