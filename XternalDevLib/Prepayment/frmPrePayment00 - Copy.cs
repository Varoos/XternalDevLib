using Focus.Common.DataStructs;
using Focus.Transactions.DataStructs;
using Newtonsoft.Json;
using System;
using System.Collections;
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
    public partial class frmPrePayment00 : Form
    {
        DevLib Xlib = new DevLib();
        public frmPrePayment00()
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

                Xlib.UIDesign(gvList0);
                Xlib.UIDesign(txtSearchPg0);
                Xlib.UIDesign(chkAllPg0);

                SetStyle(ControlStyles.SupportsTransparentBackColor, true);

                tabList0.BackColor = ColorTranslator.FromHtml("#d5d9b7");
                tabList0.Text = "TC NO.";

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmUnearnedToEarned()");
            }
        }

        private void frmfrmPrePayment00_Load(object sender, EventArgs e)
        {
            try
            {
                lblIdColumnNamePg0.Text = "iMasterId";
                dtpStartDate.Format = DateTimePickerFormat.Custom;
                dtpStartDate.CustomFormat = "MMM yyyy";
                Load_List0();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmfrmPrePayment00_Load()");
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


                DateTime StartDate = Convert.ToDateTime(dtpStartDate.Value.ToString("yyyy/MM/dd"));
                int iStartDate = Xlib.FocusDateToInt(Xlib.GetFirstDayOfMonth(StartDate).ToString("yyyy/MM/dd"));
                int iEndDate = Xlib.FocusDateToInt(Xlib.GetLastDayOfMonth(StartDate).ToString("yyyy/MM/dd"));
                //int iInvType = Convert.ToInt32(cbxProperty.SelectedValue);


                int PostCount = 0;
                int CheckedCount = 0;
                foreach (DataGridViewRow gvR in gvList0.Rows)
                {
                    Xlib.EventLog("RowsNo: " + Convert.ToString(gvR.Index));
                    if (Convert.ToBoolean(gvR.Cells["chk"].Value))
                    {
                        Xlib.EventLog("chk: True");
                        CheckedCount++;
                        int iMasterId = Convert.ToInt32(gvR.Cells["iMasterId"].Value);
                        //        int NoOfDays = Convert.ToInt32(gvR.Cells["NoOfDays"].Value);
                        //        int TotalDays = Convert.ToInt32(gvR.Cells["TotalDays"].Value);
                        Xlib.EventLog("iMasterId: " + Convert.ToString(iMasterId));
                        Xlib.EventLog("iStartDate: " + Convert.ToString(iStartDate));
                        Xlib.EventLog("iEndDate: " + Convert.ToString(iEndDate));
                        if (PrePayment_Posting(iMasterId, iStartDate, iEndDate))
                        {
                            Xlib.EventLog("Posted: True");
                            PostCount++;
                        }
                    }
                }

                MessageBox.Show(Convert.ToString(PostCount) + " / " + Convert.ToString(CheckedCount) + " Posted", "Message", MessageBoxButtons.OK);
                Load_List0();
            }

            catch (Exception ex)
            {
                btnOk.Text = "Ok";
                btnOk.Enabled = true;
                Xlib.ErrLog(ex, this.Name + ".btnOk_Click()");
            }
            btnOk.Text = "Ok";
            btnOk.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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

        #region MultiSearch Tab0
        private void chkAllPg0_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllPg0.Checked)
                {
                    chkAllPg0.Text = "Unselect All";

                    foreach (DataGridViewRow gvR in gvList0.Rows)
                    {
                        gvR.Cells["chk"].Value = true;
                        lblSelectedIdPg0.Text = lblSelectedIdPg0.Text + "," + gvR.Cells[lblIdColumnNamePg0.Text].Value + "$";
                    }
                }
                else
                {
                    chkAllPg0.Text = "Select All";
                    foreach (DataGridViewRow gvR in gvList0.Rows)
                    {
                        gvR.Cells["chk"].Value = false;
                        lblSelectedIdPg0.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".chkAllPg0_CheckedChanged()");
            }
        }

        private void gvListPg0_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gvList0.Columns[e.ColumnIndex].Name == "chk")
                {
                    DataGridViewRow gvR = gvList0.Rows[e.RowIndex];
                    if (Convert.ToBoolean(((DataGridViewCheckBoxCell)(gvR.Cells["chk"])).EditedFormattedValue))
                    {
                        lblSelectedIdPg0.Text = lblSelectedIdPg0.Text + "," + gvR.Cells[lblIdColumnNamePg0.Text].Value + "$";
                    }
                    else
                    {
                        lblSelectedIdPg0.Text = lblSelectedIdPg0.Text.Replace("," + gvR.Cells[lblIdColumnNamePg0.Text].Value + "$", "");
                    }

                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".gvListPg0_CellContentClick()");
            }
        }

        private void btnSearchPg0_Click(object sender, EventArgs e)
        {
            try
            {
                Load_List0();
                DataTable dt_gvListPg0_All = new DataTable();
                dt_gvListPg0_All = (DataTable)gvList0.DataSource;

                DataTable dt = new DataTable();
                dt = Xlib.DataTable_Search(dt_gvListPg0_All, txtSearchPg0.Text.Trim());
                gvList0.DataSource = dt;
                Xlib.GVRowNo(gvList0);


                string[] SelectedIds = Convert.ToString(lblSelectedIdPg0.Text.Trim()).Replace("$", "").Split(',');
                if (SelectedIds.Length > 0)
                {
                    foreach (DataGridViewRow gvR in gvList0.Rows)
                    {
                        if (SelectedIds.Length > 0)
                        {
                            int numIdx = Array.IndexOf(SelectedIds, Convert.ToString(gvR.Cells[lblIdColumnNamePg0.Text].Value));
                            if (numIdx > -1)
                            {
                                gvR.Cells["chk"].Value = true;

                                List<string> tmp = new List<string>(SelectedIds);
                                tmp.RemoveAt(numIdx);
                                SelectedIds = tmp.ToArray();
                            }
                            if (SelectedIds.Length == 1)
                            {
                                numIdx = Array.IndexOf(SelectedIds, "0");
                                List<string> tmp = new List<string>(SelectedIds);
                                tmp.RemoveAt(numIdx);
                                SelectedIds = tmp.ToArray();
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnSearchPg0_Click()");
            }
        }

        #endregion


        private void Date_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_List0();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".Date_ValueChanged()");
            }
        }

        private void ComBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Load_List0();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".ComBox_SelectedIndexChanged()");
            }
        }

        private void Load_List0()
        {
            try
            {
                DataTable dt = new DataTable();
                DateTime StartDate = Convert.ToDateTime(dtpStartDate.Value.ToString("yyyy/MM/dd"));
                int iStartDate = Xlib.FocusDateToInt(Xlib.GetFirstDayOfMonth(StartDate).ToString("yyyy/MM/dd"));
                int iEndDate = Xlib.FocusDateToInt(Xlib.GetLastDayOfMonth(StartDate).ToString("yyyy/MM/dd"));
                int iProperty = 0;

                try
                {
                }
                catch (Exception e)
                {

                }

                string SQL = " Exec xsp_TCNo_List '" + Convert.ToString(iStartDate) + "','" + Convert.ToString(iEndDate) + "','" + Convert.ToString(iProperty) + "'";
                dt = Xlib.GetDataTableAPI(SQL);
                gvList0.DataSource = dt;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".Load_frmUnearnedToEarned_Grid()");
            }
        }

        private bool PrePayment_Posting(int iMasterId, int iStartDate, int iEndDate)
        {
            bool rtnFlag = false;
            try
            {
                string SQL = " Exec xsp_AmortizationJV_Posting '" + Convert.ToString(iMasterId) + "','" + Convert.ToString(iStartDate) + "','" + Convert.ToString(iEndDate) + "'";
                Xlib.EventLog("SQL: " + SQL);
                DataSet ds = new DataSet();
                string err = "";
                ds = Xlib.GetDataSetAPI(SQL, ref err);
                if (ds.Tables.Count == 2)
                {
                    Xlib.EventLog("Table Count: " + Convert.ToString(ds.Tables.Count));
                    DataTable dt_H = new DataTable();
                    dt_H = ds.Tables[0];
                    if (dt_H.Rows.Count > 0)
                    {
                        Xlib.EventLog("Header Count: " + Convert.ToString(dt_H.Rows.Count));
                        string PostVoucher = "";
                        Hashtable header = new Hashtable();

                        for (int i = 0; i < dt_H.Columns.Count; i++)
                        {
                            string ColumnName = dt_H.Columns[i].ColumnName;
                            Xlib.EventLog(ColumnName + "=" + Convert.ToString(dt_H.Rows[0][i]));
                            if (ColumnName.Contains("*"))
                            {
                                if (ColumnName == "*PostVoucher")
                                {
                                    PostVoucher = Convert.ToString(dt_H.Rows[0][i]);
                                }
                            }
                            else
                            {
                                header.Add(ColumnName, Convert.ToString(dt_H.Rows[0][i]));
                            }
                        }

                        DataTable dt_B = new DataTable();
                        dt_B = ds.Tables[1];
                        if (dt_B.Rows.Count > 0)
                        {
                            Xlib.EventLog("Body Count: " + Convert.ToString(dt_B.Rows.Count));
                            List<Hashtable> body = new List<Hashtable>();
                            int b = 0;
                            foreach (DataRow dr in dt_B.Rows)
                            {
                                Xlib.EventLog("Body: " + Convert.ToString(b++));
                                Hashtable row = new Hashtable();
                                foreach (DataColumn dc in dt_B.Columns)
                                {
                                    string ColName = dc.ColumnName;
                                    Xlib.EventLog(ColName + "=" + Convert.ToString(dr[ColName]));
                                    row.Add(ColName, Convert.ToString(dr[ColName]));
                                }
                                body.Add(row);
                            }

                            PostingData postingData = new PostingData();
                            Xlib.EventLog("postingData.data.Add");
                            postingData.data.Add(new Hashtable { { "Header", header }, { "Body", body } });

                            string sContent = JsonConvert.SerializeObject(postingData);
                            Xlib.EventLog("sContent:" + sContent);

                            Xlib.EventLog("Before response");
                            var response = Focus8API.Post(PostVoucher, sContent, ref err);
                            Xlib.EventLog("After response");

                            if (response != null)
                            {
                                //MessageBox.Show("Response:" + response);
                                Xlib.EventLog("Response not NULL");
                                var responseData = JsonConvert.DeserializeObject<APIResponse.PostResponse>(response);
                                Xlib.EventLog("responseData prepaid");
                                if (Convert.ToBoolean(responseData.data[0]["Posted"]))
                                {
                                    SQL = " Exec xsp_Update_TC_PostedDate '" + iEndDate + "','" + iMasterId + "'";
                                    Xlib.ExecuteNonQueryAPI(SQL);
                                    rtnFlag = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rtnFlag = false;
                Xlib.ErrLog(ex, this.Name + ".Amortization_Posting()");
            }
            return rtnFlag;
        }

    }
}
