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
    public partial class frmMenuUpdate : Form
    {
        DevLib Xlib = new DevLib();
        public frmMenuUpdate()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(label1);
                Xlib.UIDesign(cbxMenu);
                Xlib.UIDesign(gvList);
                Xlib.UIDesign(btnUpdate);
                Xlib.UIDesign(btnClose);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + "frmMenuUpdate()");
            }
        }

        private void frmMenuUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string SQL = "Select 0 [iMenuId], '' [sMenuName] Union All Select iMenuId [iMenuId], sMenuText [sMenuName] From mCore_Menu Where iMenuId > 90000";
                dt = Xlib.GetDataTableAPI(SQL);

                cbxMenu.DisplayMember = "sMenuName";
                cbxMenu.ValueMember = "iMenuId";
                cbxMenu.DataSource = dt;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + "frmMenuUpdate_Load()");
            }
        }

        private void cbxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string SQL = @"Select l.sDescription  [Language] , ml.sCaption [Caption], ml.sCaption [NewCaption], m.iMenuId [iMenuId], ml.iLanguageId [iLanguageId]
                                From mCore_Menu m
		                                inner join cCore_MenuLanguages ml on ml.iMenuId = m.iMenuId
		                                inner join cCore_LanguageSupported l on l.iLanguageId = ml.iLanguageId 
                                Where m.iMenuId = '" + Convert.ToString(cbxMenu.SelectedValue) + "'";
                dt = Xlib.GetDataTableAPI(SQL);

                gvList.DataSource = dt;

                Xlib.ReadOnlyGVColumns(gvList, new int[] { 2 });

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + "cbxMenu_SelectedIndexChanged()");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL = "";
                foreach (DataGridViewRow gvR in gvList.Rows)
                {
                    string Language = Convert.ToString(gvR.Cells["Language"].FormattedValue);
                    string Caption = Convert.ToString(gvR.Cells["Caption"].FormattedValue);
                    string NewCaption = Convert.ToString(gvR.Cells["NewCaption"].FormattedValue);
                    string iMenuId = Convert.ToString(gvR.Cells["iMenuId"].FormattedValue);
                    string iLanguageId = Convert.ToString(gvR.Cells["iLanguageId"].FormattedValue);

                    if (iLanguageId == "0")
                    {
                        SQL = "Update mCore_Menu Set sMenuText = '" + NewCaption + "' Where iMenuId = '" + iMenuId + "'";
                        Xlib.ExecuteNonQueryAPI(SQL);
                    }

                    SQL = "Update cCore_MenuLanguages Set sCaption = '" + NewCaption + "' Where iMenuId = '" + iMenuId + "' And iLanguageId = '" + iLanguageId + "'";
                    Xlib.ExecuteNonQueryAPI(SQL);
                }

                Xlib.MsgBox(1);
                frmMenuUpdate_Load(null, null);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + "btnUpdate_Click()");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + "btnClose_Click()");
            }
        }

        
    }

}
