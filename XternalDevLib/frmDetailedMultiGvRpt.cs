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
    public partial class frmDetailedMultiGvRpt : Form
    {
        DevLib Xlib = new DevLib();
        DataTable dt_gvListPg0_All = new DataTable();
        DataTable dt_gvListPg1_All = new DataTable();
        bool frmLoaded = false;
        public int TagDisplay = -1;
        public frmDetailedMultiGvRpt()
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
                Xlib.UIDesign(btnSearch);
                Xlib.UIDesign(chkAll);


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

        private void frmDetailedMultiGvRpt_Load(object sender, EventArgs e)
        {
            try
            {
                frmLoaded = true;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvList_Load();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnSearch_Click()");
            }
        }

        private void gvList_Load()
        {

            try
            {
                if (btnSearch.Tag != "")
                {
                    DataTable dt_DF = new DataTable();
                    dt_DF.Columns.Add("RowNo");
                    dt_DF.Columns.Add("Param");
                    dt_DF.Columns.Add("Value");

                    string iStartDate = Convert.ToString(Xlib.FocusDateToInt(dtpStartDate.Value.ToString("yyyy/MM/dd")));
                    string iEndDate = Convert.ToString(Xlib.FocusDateToInt(dtpEndDate.Value.ToString("yyyy/MM/dd")));
                    dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                    dt_DF.Rows.Add("2", "iEndDate", iEndDate);


                    List<string> Items = new List<string>();
                    var comboBoxes = gbx.Controls
                          .OfType<ComboBox>()
                          .Where(x => x.Name.StartsWith("cbx"));

                    int r = 3;
                    foreach (ComboBox cbxTag in comboBoxes)
                    {
                        string RowNo = Convert.ToString(r++);
                        string Param = "Tag" + Convert.ToString(cbxTag.Tag);
                        string Value = Convert.ToString(cbxTag.SelectedValue);      // + " Or 1=1 ";

                        dt_DF.Rows.Add(RowNo, Param, Value);

                        //foreach (var cmbitem in cmbBox.Items)
                        //{
                        //    Items.Add(cmbitem.ToString());
                        //}
                    }


                    string Result = "";
                    Result = "<xml>";
                    if (dt_DF.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_DF.Rows.Count; i++)
                        {
                            string RowNo = ""; string Param = ""; string Value = "";
                            RowNo = "RowNo" + Convert.ToString(dt_DF.Rows[i]["RowNo"]);
                            Param = Convert.ToString(dt_DF.Rows[i]["Param"]);
                            Value = Convert.ToString(dt_DF.Rows[i]["Value"]);

                            Result = Result + "<" + RowNo + "><" + Param + ">" + Value + "</" + Param + "></" + RowNo + ">";
                        }
                    }
                    Result = Result + "</xml>";

                    DataTable dt = new DataTable();
                    dt = Xlib.GetDataTableAPI(" Exec " + btnSearch.Tag + " '" + Result + "'");

                    gvList.DataSource = dt;

                    if (chkAll.Visible)
                    {
                        gvList.Columns["chk"].Visible = chkAll.Visible;
                        gvList.Columns["chk"].ReadOnly = false;
                    }
                    for (int i = 0; i < gvList.Columns.Count; i++)
                    {
                        if (gvList.Columns[i].Name == "DoubleClick")
                        {
                            gvList.Columns[i].Visible = false;
                            break;
                        }
                    }

                }
                else
                {
                    Xlib.MsgBox(92, "Procedure Name Not Defined");
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".gvList_Load()");
            }
        }


        public void cbx_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (frmLoaded)
                {
                    gvList_Load();
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".cbx_SelectedValueChanged()");
            }
        }

        private void frmDetailedMultiGvRpt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                TagDisplay++;
                if (TagDisplay > 3)
                {
                    TagDisplay = 0;
                }





            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".cbx_SelectedValueChanged()");
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow gvR in gvList.Rows)
                {
                    gvR.Cells["chk"].Value = chkAll.Checked;
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".chkAll_CheckedChanged()");
            }
        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                if (col == 0)
                {
                    if (gvList.Columns["chk"].Visible)
                    {
                        gvList.Rows[row].Cells[col].Value = !Convert.ToBoolean(gvList.Rows[row].Cells[col].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".gvList_CellContentClick()");
            }
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                int ColCnt = gvList.Columns.Count;
                for (int i = 0; i < ColCnt; i++)
                {
                    if (gvList.Columns[i].Name == "DoubleClick")
                    {
                        string SQL = Convert.ToString(gvList.Rows[row].Cells[i].Value);
                        DataTable dt = new DataTable();
                        dt = Xlib.GetDataTableAPI(" Exec " + SQL);
                        Xlib.GridViewReport(dt, "Details");
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".gvList_CellDoubleClick()");
            }
        }
    }
}
