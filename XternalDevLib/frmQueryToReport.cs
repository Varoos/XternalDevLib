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
    public partial class frmQueryToReport : Form
    {
        DevLib Xlib = new DevLib();
        public frmQueryToReport()
        {
            InitializeComponent();

            Xlib.UIDesign(this, "Form");
            Xlib.UIDesign(btnOk, btnOk.GetType().Name);

            DataTable dt = new DataTable();

            dt = Xlib.GetMasterData(3001, "", "", "sName");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
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
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI(txtQuery.Text.Trim());
                Xlib.GridViewReport(dt, "Query Report");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnOk_Click()");
            }
        }
    }
}
