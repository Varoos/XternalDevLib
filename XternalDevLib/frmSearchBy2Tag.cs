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
                Xlib.EventLog("btnOk Called");
                btnOk.Text = "Wait...";
                btnOk.Enabled = false;

                DataTable dt_Param = new DataTable();
                dt_Param = GetParameters();

                Xlib.EventLog("Param Count :" + Convert.ToString(dt_Param.Rows.Count));

                for (int i = 0; i < dt_Param.Rows.Count; i++)
                {
                    Xlib.EventLog("RowNo:" + Convert.ToString(dt_Param.Rows[i]["RowNo"]) + "\n\r" +
                                    "Param:" + Convert.ToString(dt_Param.Rows[i]["Param"]) + "\n\r" +
                                    "Value:" + Convert.ToString(dt_Param.Rows[i]["Value"]));
                }

                Xlib.EventLog("ReportName :" + Convert.ToString(lblReportName.Text));
                Xlib.EventLog("xspName :" + Convert.ToString(lblxspName.Text));

                if (Convert.ToString(lblReportName.Text) != "" && Convert.ToString(lblxspName.Text) != "")
                {
                    string XML = Xlib.DataTableToXML(dt_Param);

                    DataSet ds = new DataSet();
                    string error = "";
                    string SQL = " Exec " + lblxspName.Text + " '" + XML + "'";
                    Xlib.EventLog(SQL);
                    ds = Xlib.GetDataSetAPI(SQL, ref error);
                    Xlib.EventLog("ds Count :" + Convert.ToString(ds.Tables.Count));
                    if (ds.Tables.Count > 0)
                    {
                        string[] DSName = new string[ds.Tables.Count];
                        DataTable[] DSValue = new DataTable[ds.Tables.Count];

                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            DSName[i] = "DataSet" + Convert.ToString(i + 1);
                            DSValue[i] = ds.Tables[i];

                            Xlib.EventLog("DSName" + Convert.ToString(i) + " : " + DSName[i]);
                            Xlib.EventLog("DSValue" + Convert.ToString(i) + " Row Count : " + Convert.ToString(DSValue[i].Rows.Count));
                        }
                        Xlib.EventLog("ReportShow");
                        Xlib.ReportShow(Convert.ToString(lblReportName.Text), DSName, DSValue, this.Text, this.MinimizeBox);
                        Xlib.EventLog("ReportShow Completed");
                    }
                    else
                    {
                        Xlib.MsgBox(3);
                    }

                }
                else
                {
                    gvParam.DataSource = dt_Param;
                    DialogResult = DialogResult.OK;
                }

                btnOk.Text = "Ok";
                btnOk.Enabled = true;

                Xlib.EventLog("btnOk Finished");
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

        private DataTable GetParameters()
        {
            DataTable dt_DF = new DataTable();
            dt_DF.Columns.Add("RowNo");
            dt_DF.Columns.Add("Param");
            dt_DF.Columns.Add("Value");
            try
            {
                string iStartDate = Convert.ToString(Xlib.FocusDateToInt(dtpStartDate.Value.ToString("yyyy/MM/dd")));
                string iEndDate = Convert.ToString(Xlib.FocusDateToInt(dtpEndDate.Value.ToString("yyyy/MM/dd")));
                if (dtpEndDate.CustomFormat == "MMM yyyy")        // As On Month
                {
                    dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(Xlib.FocusDateToInt(Xlib.GetFirstDayOfMonth(dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                    dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(Xlib.FocusDateToInt(Xlib.GetLastDayOfMonth(dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                }
                else if (dtpEndDate.CustomFormat == "yyyy")    // As On Year
                {
                    dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(Xlib.FocusDateToInt((Convert.ToString(dtpEndDate.Value.Year) + "/01/01"))));
                    dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(Xlib.FocusDateToInt((Convert.ToString(dtpEndDate.Value.Year) + "/12/31"))));
                }
                else
                {
                    dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                    dt_DF.Rows.Add("2", "iEndDate", iEndDate);
                }

                //List<string> Items = new List<string>();
                var comboBoxes = this.Controls
                      .OfType<ComboBox>()
                      .Where(x => x.Name.StartsWith("cbxTag"));
                //foreach (var objTag in comboBoxes)
                //{

                //}
                for (int i = 0; i < comboBoxes.Count<ComboBox>(); i++)
                {
                    object objTag = Controls.Find("cbxTag" + Convert.ToString(i), true)[0];
                    ComboBox cbxTag = ((ComboBox)objTag);
                    dt_DF.Rows.Add(Convert.ToString(i + 3), "Tag" + Convert.ToString(cbxTag.Tag), Convert.ToString(cbxTag.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".GetParameters()");
            }

            return dt_DF;
        }
    }
}
