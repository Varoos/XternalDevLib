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
    public partial class frmChequePrint : Form
    {
        DevLib Xlib = new DevLib();
        public frmChequePrint()
        {
            InitializeComponent();
            try
            {
                Xlib.UIDesign(this, "Form");
                Xlib.UIDesign(cbxCheque);
                Xlib.UIDesign(btnOk);
                Xlib.UIDesign(btnClose);
            }
            catch (Exception Ex)
            {
                Xlib.ErrLog(Ex, this.Name + ".frmChequePrint()");
            }
        }

        private void frmChequePrint_Load(object sender, EventArgs e)
        {
            try
            {
                List_Load();
            }
            catch (Exception Ex)
            {
                Xlib.ErrLog(Ex, this.Name + ".frmChequePrint_Load()");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string iHeaderId = lblHeaderId.Text.Trim();
                string iVType = lblVType.Text.Trim();
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI(" Exec xsp_Cheque_Print " + iHeaderId + "," + iVType);
                if (cbxCheque.Text != "")
                {
                    Xlib.ReportShow(Convert.ToString(cbxCheque.SelectedValue), new string[] { "DataSet1" }, new DataTable[] { dt }, "Cheque Print");
                    btnClose_Click(null, null);
                }
                else
                {
                    Xlib.MsgBox(99, "Select Cheque");
                    cbxCheque.Focus();
                }

            }
            catch (Exception Ex)
            {
                Xlib.ErrLog(Ex, this.Name + ".btnOk_Click()");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception Ex)
            {
                Xlib.ErrLog(Ex, this.Name + ".btnClose_Click()");
            }
        }

        private void List_Load()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI(" Exec xsp_Cheque_List ");

                cbxCheque.DisplayMember = "DisplayMember";
                cbxCheque.ValueMember = "ValueMember";
                cbxCheque.DataSource = dt;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".List_Load()");
            }
        }

    }
}
