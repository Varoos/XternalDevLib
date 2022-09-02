using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//using Microsoft.SqlServer.management;
//using Microsoft.SqlServer.Management.NotificationServices;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Smo.Agent;
//using Microsoft.SqlServer.Management.Smo.Broker;
//using Microsoft.SqlServer.Management.Smo.Mail;
//using Microsoft.SqlServer.Management.Smo.RegisteredServers;
//using Microsoft.SqlServer.Management.Smo.Wmi;
//using Microsoft.SqlServer.Management.Trace;


namespace XternalDevLib
{
    public partial class frmRestoreBAK : Form
    {
        DevLib Xlib = new DevLib();
        public frmRestoreBAK()
        {
            InitializeComponent();
        }

        private void frmRestoreBAK_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".frmRestoreBAK_Load()");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Backup File |*.bak";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string sql = "Alter Database BOQ SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    sql += "Restore Database BOQ FROM DISK ='" + openFileDialog1.FileName + "' WITH REPLACE;";

                    System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=.; Initial Catalog=BOQ;Integrated Security=True");
                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, con);

                    con.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Database Recovered Successfully!");
                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnOk_Click()");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, this.Name + ".btnClose_Click()");
            }
        }
    }
}
