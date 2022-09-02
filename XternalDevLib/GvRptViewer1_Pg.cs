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
    public partial class frmGvRptViewer1_Pg : Form
    {
        DevLib Xlib = new DevLib();
        int PageSize = 50;
        public frmGvRptViewer1_Pg()
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
                Xlib.ErrLog(ex, this.Name + ".frmGvRptViewer1()");
            }
        }

        private void frmGvRptViewer1_Pg_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvList.Rows.Count; i++)
                {
                    gvList.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                }

                //for (int i = 0; i < gvMain.Columns.Count; i++)
                //{
                //    gvList.Columns.Add(gvMain.Columns[i].Name, gvMain.Columns[i].HeaderText);
                //}

                btnFirst_Click(null, null);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmGvRptViewer1_Pg_Load()");
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

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                gvList.Rows.Clear();
                int CurrPage = Convert.ToInt32(txtCurrPage.Text);
                for (int i = CurrPage; i < CurrPage * PageSize; i++)
                {
                    DataGridViewRow gvRow = gvMain.Rows[i];
                    try
                    {
                        gvList.Rows.Add(1);
                        for (int j = 0; j < gvRow.Cells.Count; j++)
                        {

                        }
                    }
                    catch (Exception ex1)
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnFirst_Click()");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnLast_Click()");
            }
        }

        private void btnPrew_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnPrew_Click()");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnNext_Click()");
            }
        }
    }
}
