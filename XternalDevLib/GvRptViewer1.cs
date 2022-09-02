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
    public partial class frmGvRptViewer1 : Form
    {
        DevLib Xlib = new DevLib();
        DataTable dt_Org = new DataTable();
        public frmGvRptViewer1()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(gvList);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmGvRptViewer1()");
            }
        }

        private void frmRptViewer_Load(object sender, EventArgs e)
        {
            try
            {
                dt_Org = (DataTable)gvList.DataSource;
                SetGvSrNo();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmRptViewer_Load()");
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

        private void gvList_Sorted(object sender, EventArgs e)
        {
            SetGvSrNo();
        }

        private void SetGvSrNo()
        {
            try
            {
                for (int i = 0; i < gvList.Rows.Count; i++)
                {
                    gvList.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".SetGvSrNo()");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_Col = new DataTable();
                dt_Col.Columns.Add("ColName");

                for (int i = 0; i < dt_Org.Columns.Count; i++)
                {
                    dt_Col.Rows.Add(dt_Org.Columns[i]);
                }

                frmGvReportFilter fGRF = new frmGvReportFilter();
                fGRF.cbxField.DataSource = dt_Col;
                fGRF.cbxField.DisplayMember = "ColName";
                fGRF.cbxField.ValueMember = "ColName";

                DialogResult dialogResult = fGRF.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string strSearch = "";
                    DataTable dt_Filter = new DataTable();
                    dt_Filter = dt_Org;
                    foreach (DataGridViewRow gvR in fGRF.gvFilter.Rows)
                    {
                        string Conjunction = Convert.ToString(gvR.Cells[0].Value);
                        string Field = Convert.ToString(gvR.Cells[1].Value);
                        string Operator = Convert.ToString(gvR.Cells[2].Value);
                        string Value = Convert.ToString(gvR.Cells[3].Value);

                        if (Conjunction == "WHERE" || Conjunction == "WHERE (")
                        {
                            Conjunction = "";
                        }

                        if (Operator == "Equal To")
                        {
                            Operator = "=";
                            Value = "'" + Value + "'";
                        }
                        else if (Operator == "Not Equal To")
                        {
                            Operator = "<>";
                            Value = "'" + Value + "'";
                        }
                        else if (Operator == "Contains") 
                        {
                            Operator = "Like";
                            Value = "'%" + Value + "%'";
                        }
                        else if (Operator == "Less Than")
                        {
                            Operator = "<";
                        }
                        else if (Operator == "Greater Than")
                        {
                            Operator = ">";
                        }
                        else if (Operator == "Less Than Or Equal To")
                        {
                            Operator = "<=";
                        }
                        else if (Operator == "Greater Than Or Equal To")
                        {
                            Operator = ">=";
                        }
                        else if (Operator == "Is Blank")
                        {
                            Operator = "Is NULL";
                            Value = "";
                        }
                        else if (Operator == "Is Not Blank)")
                        {
                            Operator = "Is Not NULL";
                            Value = "";
                        }

                        strSearch = strSearch + " " + Conjunction + " " + " " + Field + " " + Operator + " " + Value;

                        dt_Filter = dt_Filter.Select(strSearch).CopyToDataTable();
                        SetGvSrNo();
                    }

                    gvList.DataSource = dt_Filter;
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnFilter_Click()");
            }
        }
    }
}
