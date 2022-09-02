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
    public partial class frmSearchBy2Tag : Form
    {
        DevLib Xlib = new DevLib();
        public frmSearchBy2Tag()
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
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmSearchBy2Tag()");
            }
        }

        private void frmSearchBy2Tag_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmSearchBy2Tag_Load()");
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

        private void frmSearchBy2Tag_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
