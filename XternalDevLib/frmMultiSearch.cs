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
    public partial class frmMultiSearch : Form
    {
        DevLib Xlib = new DevLib();
        DataTable dt_gvListPg0_All = new DataTable();
        DataTable dt_gvListPg1_All = new DataTable();
        public frmMultiSearch()
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

                Xlib.UIDesign(gvListPg0);
                Xlib.UIDesign(txtSearchPg0);
                Xlib.UIDesign(chkAllPg0);

                Xlib.UIDesign(gvListPg1);
                Xlib.UIDesign(txtSearchPg1);
                Xlib.UIDesign(chkAllPg1);

                SetStyle(ControlStyles.SupportsTransparentBackColor, true);

                //tabMultiSearch.ColorScheme.TabBackground = Color.Transparent;
                //tabMultiSearch.ColorScheme.TabBackground2 = Color.Transparent;
                //tabMultiSearch.BackColor = Color.Transparent;

                tabPg0.BackColor = ColorTranslator.FromHtml("#d5d9b7");
                tabPg1.BackColor = ColorTranslator.FromHtml("#d5d9b7");

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmMultiSearch()");
            }
        }

        private void frmMultiSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dt_gvListPg0_All = (DataTable)gvListPg0.DataSource;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmMultiSearch_Load()");
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


                btnOk.Enabled = true;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnOk_Click()");
            }
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

                    foreach (DataGridViewRow gvR in gvListPg0.Rows)
                    {
                        gvR.Cells["chk"].Value = true;
                        lblSelectedIdPg0.Text = lblSelectedIdPg0.Text + "," + gvR.Cells[lblIdColumnNamePg0.Text].Value + "$";
                    }
                }
                else
                {
                    chkAllPg0.Text = "Select All";
                    foreach (DataGridViewRow gvR in gvListPg0.Rows)
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

                if (gvListPg0.Columns[e.ColumnIndex].Name == "chk")
                {
                    DataGridViewRow gvR = gvListPg0.Rows[e.RowIndex];
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
                DataTable dt = new DataTable();
                dt = Xlib.DataTable_Search(dt_gvListPg0_All, txtSearchPg0.Text.Trim());
                gvListPg0.DataSource = dt;
                Xlib.GVRowNo(gvListPg0);


                string[] SelectedIds = Convert.ToString(lblSelectedIdPg0.Text.Trim()).Replace("$", "").Split(',');
                if (SelectedIds.Length > 0)
                {
                    foreach (DataGridViewRow gvR in gvListPg0.Rows)
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

        private void trv0_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int Tag = Convert.ToInt32(e.Node.Name);
                if (Tag > -1)
                {
                    int Index = e.Node.Index;
                    string NodeName = e.Node.Name;

                    string SQL = @"Select Distinct a.sName[Name], a.sCode[Code], a.iMasterId[iMasterId]
                                From vCore_" + tabPg0.Text + " a With(ReadUncommitted) inner join mCore_" + tabPg0.Text + "TreeDetails b With(ReadUncommitted) on a.iMasterId = b.iMasterId " +
                                   " Where a.iMasterId > 0 And  IsNull(b.iParentId,0) = " + Convert.ToString(Tag);

                    DataTable dt_Grp = new DataTable();
                    dt_Grp = Xlib.GetDataTableAPI(SQL + " And a.bGroup = 1");

                    //TreeNode tv = new TreeNode();
                    if (trv0.SelectedNode != null)
                    {
                        //trv0.Nodes[NodeName].Nodes.Clear();
                        trv0.SelectedNode.Nodes.Clear();
                    }
                    for (int i = 0; i < dt_Grp.Rows.Count; i++)
                    {
                        //TreeNode tv1 = new TreeNode();
                        string Text = Convert.ToString(dt_Grp.Rows[i]["Name"]);
                        string Key = Convert.ToString(dt_Grp.Rows[i]["iMasterId"]);
                        //trv0.Nodes[NodeName].Nodes.Add(Key, Text);
                        //tv.Nodes.Add(Key, Text);
                        if (trv0.Nodes[NodeName] != null)
                        {
                            trv0.Nodes[NodeName].Nodes.Add(Key, Text);
                        }
                        else
                        {
                            trv0.SelectedNode.Nodes.Add(Key, Text);
                        }
                    }


                    if (NodeName == "0")
                    {
                        SQL = @"Select a.sName [Name], a.sCode [Code], a.iMasterId [iMasterId] 
                            From vCore_" + tabPg0.Text + " a with (ReadUncommitted) Where a.iMasterId > 0 And a.bGroup = 0";
                    }
                    else
                    {

                        SQL = @"Select a.sName [Name], a.sCode [Code], a.iMasterId [iMasterId] 
                            From dbo.fCore_Get" + tabPg0.Text + "Hierarchy(" + NodeName + ",0) b inner join vCore_" + tabPg0.Text + " a with (ReadUncommitted) on a.iMasterId = b.iMasterid and a.bGroup = 0";
                    }


                    DataTable dt_Tag = new DataTable();
                    dt_Tag = Xlib.GetDataTableAPI(SQL);
                    gvListPg0.DataSource = dt_Tag;
                    //Xlib.GVRowNo(gvListPg0);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".trv0_AfterSelect()");
            }
        }

        #endregion

        #region MultiSearch Tab1

        private void btnSearchPg1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Xlib.DataTable_Search(dt_gvListPg1_All, txtSearchPg1.Text.Trim());
                gvListPg1.DataSource = dt;
                Xlib.GVRowNo(gvListPg1);


                string[] SelectedIds = Convert.ToString(lblSelectedIdPg1.Text.Trim()).Replace("$", "").Split(',');
                if (SelectedIds.Length > 0)
                {
                    foreach (DataGridViewRow gvR in gvListPg1.Rows)
                    {
                        if (SelectedIds.Length > 0)
                        {
                            int numIdx = Array.IndexOf(SelectedIds, Convert.ToString(gvR.Cells[lblIdColumnNamePg1.Text].Value));
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
                Xlib.ErrLog(ex, this.Name + ".btnSearchPg1_Click()");
            }
        }

        private void gvListPg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gvListPg1.Columns[e.ColumnIndex].Name == "chk1")
                {
                    DataGridViewRow gvR = gvListPg1.Rows[e.RowIndex];
                    if (Convert.ToBoolean(((DataGridViewCheckBoxCell)(gvR.Cells["chk1"])).EditedFormattedValue))
                    {
                        lblSelectedIdPg1.Text = lblSelectedIdPg1.Text + "," + gvR.Cells[lblIdColumnNamePg1.Text].Value + "$";
                    }
                    else
                    {
                        lblSelectedIdPg1.Text = lblSelectedIdPg1.Text.Replace("," + gvR.Cells[lblIdColumnNamePg1.Text].Value + "$", "");
                    }

                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".gvListPg1_CellContentClick()");
            }
        }

        private void chkAllPg1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllPg1.Checked)
                {
                    chkAllPg1.Text = "Unselect All";

                    foreach (DataGridViewRow gvR in gvListPg1.Rows)
                    {
                        gvR.Cells["chk1"].Value = true;
                        lblSelectedIdPg1.Text = lblSelectedIdPg1.Text + "," + gvR.Cells[lblIdColumnNamePg1.Text].Value + "$";
                    }
                }
                else
                {
                    chkAllPg1.Text = "Select All";
                    foreach (DataGridViewRow gvR in gvListPg1.Rows)
                    {
                        gvR.Cells["chk1"].Value = false;
                        lblSelectedIdPg1.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".chkAllPg1_CheckedChanged()");
            }
        }

        private void trv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int Tag = Convert.ToInt32(e.Node.Name);
                if (Tag > -1)
                {
                    int Index = e.Node.Index;
                    string NodeName = e.Node.Name;

                    string SQL = @"Select Distinct a.sName[Name], a.sCode[Code], a.iMasterId[iMasterId]
                                From vCore_" + tabPg1.Text + " a With(ReadUncommitted) inner join mCore_" + tabPg1.Text + "TreeDetails b With(ReadUncommitted) on a.iMasterId = b.iMasterId " +
                                   " Where a.iMasterId > 0 And  IsNull(b.iParentId,0) = " + Convert.ToString(Tag);

                    DataTable dt_Grp = new DataTable();
                    dt_Grp = Xlib.GetDataTableAPI(SQL + " And a.bGroup = 1");

                    //TreeNode tv = new TreeNode();
                    if (trv1.SelectedNode != null)
                    {
                        //trv1.Nodes[NodeName].Nodes.Clear();
                        trv1.SelectedNode.Nodes.Clear();
                    }
                    for (int i = 0; i < dt_Grp.Rows.Count; i++)
                    {
                        //TreeNode tv1 = new TreeNode();
                        string Text = Convert.ToString(dt_Grp.Rows[i]["Name"]);
                        string Key = Convert.ToString(dt_Grp.Rows[i]["iMasterId"]);
                        //trv1.Nodes[NodeName].Nodes.Add(Key, Text);
                        //tv.Nodes.Add(Key, Text);
                        if (trv1.Nodes[NodeName] != null)
                        {
                            trv1.Nodes[NodeName].Nodes.Add(Key, Text);
                        }
                        else
                        {
                            trv1.SelectedNode.Nodes.Add(Key, Text);
                        }
                    }


                    if (NodeName == "0")
                    {
                        SQL = @"Select a.sName [Name], a.sCode [Code], a.iMasterId [iMasterId] 
                            From vCore_" + tabPg1.Text + " a with (ReadUncommitted) Where a.iMasterId > 0 And a.bGroup = 0";
                    }
                    else
                    {

                        SQL = @"Select a.sName [Name], a.sCode [Code], a.iMasterId [iMasterId] 
                            From dbo.fCore_Get" + tabPg1.Text + "Hierarchy(" + NodeName + ",0) b inner join vCore_" + tabPg1.Text + " a with (ReadUncommitted) on a.iMasterId = b.iMasterid and a.bGroup = 0";
                    }


                    DataTable dt_Tag = new DataTable();
                    dt_Tag = Xlib.GetDataTableAPI(SQL);
                    gvListPg1.DataSource = dt_Tag;
                    //Xlib.GVRowNo(gvListPg1);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".trv1_AfterSelect()");
            }
        }


        #endregion

    }
}
