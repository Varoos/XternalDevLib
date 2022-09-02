using Focus.Common.DataStructs;
using Focus.Conn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XternalDevLib
{
    public partial class DeleteVoucher : Form
    {
        DevLib Xlib = new DevLib();
        public DeleteVoucher()
        {
            InitializeComponent();
            Load_VoucherType();
        }

        private void Load_VoucherType()
        {
            try
            {
                string SQL = "Select iVoucherType [VTypeId], sName [VType] From cCore_Vouchers_0 Order By sName";
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI(SQL);

                cbxVoucherType.DataSource = dt;
                cbxVoucherType.DisplayMember = "VType";
                cbxVoucherType.ValueMember = "VTypeId";
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Ibrahim.Load_VoucherType()");
            }
        }

        private void cbxVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SQL = @" Select '' [VNo], 0 [HeaderId] Union 
                                Select sVoucherNo [VNo], iHeaderId [HeaderId]  From tCore_Header_0 Where bCancelled = 0 and bSuspended = 0 
                                   and iVoucherType = '" + Convert.ToString(cbxVoucherType.SelectedValue) + "' Order By 1";
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI(SQL);
                cbxVoucherNo.DataSource = dt;
                cbxVoucherNo.DisplayMember = "VNo";
                cbxVoucherNo.ValueMember = "HeaderId";
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Ibrahim.cbxVoucherType_SelectedIndexChanged()");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbxVoucherNo.SelectedValue) == 0)
                {
                    string SQL = @" Select sVoucherNo [VNo], iHeaderId [HeaderId] From tCore_Header_0 Where bCancelled = 0 and bSuspended = 0 
                                   and iVoucherType = '" + Convert.ToString(cbxVoucherType.SelectedValue) + "' Order By sVoucherNo";
                    DataTable dt = new DataTable();
                    dt = Xlib.GetDataTableAPI(SQL);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DeleteVoch(Convert.ToInt32(cbxVoucherType.SelectedValue), Convert.ToString(dt.Rows[i]["VNo"]));
                    }
                }
                else
                {
                    DeleteVoch(Convert.ToInt32(cbxVoucherType.SelectedValue), Convert.ToString(cbxVoucherNo.SelectedText));
                }
                Load_VoucherType();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Ibrahim.btnDelete_Click()");
            }
        }

        private void DeleteVoch(int VoucherType, string DocumentNo)
        {
            try
            {
                Output objDel = Connection.CallServeRequest(ServiceType.Transaction, TransMethods.DeleteVoucher, VoucherType, DocumentNo, 1);
                Xlib.InfoLog(DocumentNo, objDel.Message);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Ibrahim.DeleteVoucher()");
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = "Data Source=HOME\\MSSQLSERVER16;Initial Catalog=Focus8100;" + "UId=sa;" + "Pwd=sql@2014;Connection Timeout=900";
                string exePath = "E:\\FocusSoftNet\\Development\\CRM\\RDK\\Docuemnts\\DynamicFolder\\";
                //(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Ibrahim").Replace("file:\\", "");

                DataTable dt = new DataTable();

                string SQL = "Select sName [Name], sCode [Code] From vCrm_Tenant  Where sName <> ''";

                dt = Xlib.GetDataTableByQuery(SQL,conn);
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {

                    if (Directory.Exists(exePath + "\\Customer\\" + Convert.ToString(dt.Rows[i]["Name"])) == false)
                    {
                        Directory.CreateDirectory(exePath + "\\Customer\\" + Convert.ToString(dt.Rows[i]["Name"]));
                    }
                }


                SQL = "Select  sName [Name], sCode [Code] From vCrm_PMSUnits  Where sName <> ''";

                dt = Xlib.GetDataTableByQuery(SQL, conn);
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {

                    if (Directory.Exists(exePath + "\\Unit\\" + Convert.ToString(dt.Rows[i]["Name"])) == false)
                    {
                        Directory.CreateDirectory(exePath + "\\Unit\\" + Convert.ToString(dt.Rows[i]["Name"]));
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
