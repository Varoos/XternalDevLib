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
    public partial class frmSearchBy1Tag : Form
    {
        DevLib Xlib = new DevLib();
        public frmSearchBy1Tag()
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
                Xlib.ErrLog(ex, this.Name + ".frmSearchBy1Tag()");
            }
        }

        private void frmSearchBy1Tag_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmSearchBy1Tag_Load()");
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
    }
}
