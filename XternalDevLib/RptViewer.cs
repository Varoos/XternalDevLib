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
    public partial class frmRptViewer : Form
    {
        public frmRptViewer()
        {
            InitializeComponent();
        }

        private void frmRptViewer_Load(object sender, EventArgs e)
        {

            this.RptViewer.RefreshReport();
        }
    }
}
