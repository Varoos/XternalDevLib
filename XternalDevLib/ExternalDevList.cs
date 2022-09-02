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
    public partial class ExternalDevList : Form
    {
        DevLib Xlib = new DevLib();
        public ExternalDevList()
        {
            InitializeComponent();
        }

        private void btnRestoreBAK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnRestoreBAK_LinkClicked()");
            }
        }
    }
}
