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
    public partial class frmGvRptViewer_Analysys : Form
    {
        DevLib Xlib = new DevLib();
        public frmGvRptViewer_Analysys()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(gvList);
                Xlib.UIDesign(groupBox1);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmGvRptViewer_Analysys()");
            }
        }

        private void frmGvRptViewer_Analysys_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvList.Rows.Count; i++)
                {
                    gvList.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                    gvList.Rows[i].Cells[Convert.ToInt32(gvList.Rows[i].Cells["ColorCellNo"].Value)].Style.BackColor = ColorTranslator.FromHtml("#a45cf5"); 
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmGvRptViewer_Analysys_Load()");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvList.Rows.Count > 0)
                {
                    DataTable dt_Excel = new DataTable();
                    dt_Excel = (DataTable)gvList.DataSource;
                    Xlib.ExportGridToExcel(dt_Excel, DateTime.Now.ToString("yyyyMMdd") + ".xls", true, true);
                }
                else
                {
                    Xlib.MsgBox(3);
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnExportExcel_Click()");
            }
        }
    }
}
