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
    public partial class UpdateDocNo : Form
    {
        DevLib Xlib = new DevLib();
        public UpdateDocNo()
        {
            InitializeComponent();
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".UpdateDocNo()");
            }
        }

        private void UpdateDocNo_Load(object sender, EventArgs e)
        {
            try
            {
                VoucherType_Load();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".UpdateDocNo_Load()");
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
                Xlib.ErrLog(ex, this.Name + ".btnClose_Click()");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL = @"Select sVoucherNo
		                                , (Select Top(1) sCode From vPos_Outlet inner join tCore_Data_0 on tCore_Data_0.iFaTag = vPos_Outlet.iMasterId Where tCore_Data_0.iHeaderId = tCore_Header_0.iHeaderId ) [TagCode]
		                                , iHeaderId [iHeaderId]
                                From tCore_Header_0 
                                Where bCancelled = 0 and bSuspended = 0 and iVoucherType = '" + Convert.ToString(cbxVoucherType.SelectedValue) + "'";

                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI(SQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string TagCode = Convert.ToString(dt.Rows[i]["TagCode"]);
                    string HeaderId = Convert.ToString(dt.Rows[i]["iHeaderId"]);
                    string Seprator = Convert.ToString(cbxSeprator.Text);
                    string NewDoc = "";

                    NewDoc = Xlib.GetNextVoucherNoTagWise(Convert.ToInt32(cbxVoucherType.SelectedValue), TagCode, Seprator);
                    if (Convert.ToString(NewDoc).Trim() != "")
                    {
                        Xlib.ExecuteNonQuery("Update tCore_Header_0 Set sVoucherNo = '" + NewDoc + "' Where iHeaderId = '" + HeaderId + "'");
                    }

                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnUpdate_Click()");
            }
        }

        private void VoucherType_Load()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI("Select iVoucherType [iVoucherType], sName [sName] From cCore_Vouchers_0 Order By sName");

                cbxVoucherType.ValueMember = "iVoucherType";
                cbxVoucherType.DisplayMember = "sName";
                cbxVoucherType.DataSource = dt;
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".VoucherType_Load()");
            }
        }
    }
}
