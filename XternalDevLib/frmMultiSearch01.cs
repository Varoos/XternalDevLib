using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CureMedical
{
    public partial class frmSupManuReportcs : Form
    {
        DevLib Xlib = new DevLib();
        public frmSupManuReportcs()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(lblRptNo);
                Xlib.UIDesign(btnOk);
                Xlib.UIDesign(btnClose);
                Xlib.UIDesign(chkAll);
                Xlib.UIDesign(gvList);
                Xlib.UIDesign(btnSearch);
                Xlib.UIDesign(txtSearch);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmSupManuReportcs()");
            }
        }

        private void frmSupManuReportcs_Load(object sender, EventArgs e)
        {
            try
            {
                gvList_Load();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmSupManuReportcs_Load()");
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    chkAll.Text = "Unselect All";

                    foreach (DataGridViewRow gvR in gvList.Rows)
                    {
                        gvR.Cells["chk"].Value = true;
                    }
                }
                else
                {
                    chkAll.Text = "Select All";
                    foreach (DataGridViewRow gvR in gvList.Rows)
                    {
                        gvR.Cells["chk"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".chkAll_CheckedChanged()");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                btnOk.Text = "Wait...";
                btnOk.Enabled = false;

                string sMasterId = "0";
                foreach (DataGridViewRow gvR in gvList.Rows)
                {
                    if (Convert.ToBoolean(gvR.Cells["chk"].Value))
                    {
                        sMasterId = sMasterId + "," + Convert.ToString(gvR.Cells["iMasterId"].Value);
                    }
                }

                if (sMasterId != "0")
                {
                    //frmRptViewer frm = new frmRptViewer();
                    //if (lblRptNo.Text == "0")
                    //{
                    //    frm.Text = "Supplier Wise Rebate Report";
                    //}
                    //else if (lblRptNo.Text == "1")
                    //{
                    //    frm.Text = "Manufacturer Wise Rebate Report";
                    //}
                    //else if (lblRptNo.Text == "2")
                    //{
                    //    frm.Text = "Supplier Wise Rebate Detailed Report";
                    //}
                    //else if (lblRptNo.Text == "3")
                    //{
                    //    frm.Text = "Manufacturer Wise Rebate Detailed Report";
                    //}
                    //frm.lblRtpNo.Text = lblRptNo.Text;
                    //frm.lblMasteIds.Text = sMasterId;
                    //frm.dtpStartDate.Value = dtpStartDate.Value;
                    //frm.dtpEndDate.Value = dtpEndDate.Value;
                    //frm.ShowDialog();
                }
                else
                {
                    Xlib.MsgBox(3);
                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnOk_Click()");
                btnOk.Text = "Ok";
                btnOk.Enabled = true;
            }
            btnOk.Text = "Ok";
            btnOk.Enabled = true;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                chkAll.Text = "Select All";
                chkAll.Checked = false;
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
                string sSearch = txtSearch.Text.Trim() + "%";

                if (lblRptNo.Text == "0" || lblRptNo.Text == "2")
                {
                    DataTable dt = new DataTable();
                    dt = Xlib.GetDataTableAPI("Exec xsp_SupplierList '" + sSearch + "'");
                    gvList.DataSource = dt;
                    Xlib.ReadOnlyGVColumns(gvList, new int[] { 0 });
                    Xlib.HideGVLastColumns(gvList, 1);
                    Xlib.GVRowNo(gvList);
                    gvList.Columns[0].Width = 30;
                    gvList.Columns[0].HeaderText = "";
                }
                else if (lblRptNo.Text == "1" || lblRptNo.Text == "3")
                {
                    DataTable dt = new DataTable();
                    dt = Xlib.GetDataTableAPI("Exec xsp_ManufacturersList1 '" + sSearch + "'");
                    gvList.DataSource = dt;
                    Xlib.ReadOnlyGVColumns(gvList, new int[] { 0 });
                    Xlib.HideGVLastColumns(gvList, 1);
                    Xlib.GVRowNo(gvList);
                    gvList.Columns[0].Width = 30;
                    gvList.Columns[0].HeaderText = "";
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".gvList_Load()");
            }
        }
    }
}
