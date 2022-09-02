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
    public partial class frmDate : Form
    {
        DevLib Xlib = new DevLib();

        public frmDate()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(label1);
                Xlib.UIDesign(dtpStartDate);
                Xlib.UIDesign(btnOk);
                Xlib.UIDesign(btnClose);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "frmDate.frmDate()");
            }
        }

        private void frmDate_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "frmDate.frmDate()");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "frmDate.frmDate()");
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
                Xlib.ErrLog(ex, "frmDate.frmDate()");
            }
        }
    }
}
