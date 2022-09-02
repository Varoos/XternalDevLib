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
    public partial class TestForm : Form
    {
        DevLib Xlib = new DevLib();
        public TestForm()
        {
            InitializeComponent();

            Xlib.UIDesign(this, "Form");
            Xlib.UIDesign(button1, button1.GetType().Name);
            Xlib.UIDesign(dtpStartDate, dtpStartDate.GetType().Name);
            Xlib.UIDesign(textBox1, textBox1.GetType().Name);
            Xlib.UIDesign(cbxAccount, cbxAccount.GetType().Name);

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            DataTable dt = new DataTable();

            dt = Xlib.GetMasterData(3001, "", "", "sName");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //AutoCompleteStringCollection SC = new AutoCompleteStringCollection();
            //textBox1.AutoCompleteCustomSource  = SC;

            DataTable dtPosts = new DataTable();
            dtPosts = Xlib.GetMasterData(1, "sName + '[' + sCode +']' [Name] ", " (sName like '%" + textBox1.Text + "%' Or sCode like '%" + textBox1.Text + "%')", " sName, sCode");


            ////use LINQ method syntax to pull the Title field from a DT into a string array...
            //string[] postSource = dtPosts
            //                    .AsEnumerable()
            //                    .Select<System.Data.DataRow, String>(x => x.Field<String>("Name"))
            //                    .ToArray();
            //var source = new AutoCompleteStringCollection();
            //source.AddRange(postSource);
            //textBox1.AutoCompleteCustomSource = source;

            string[] postSource = new string[dtPosts.Rows.Count];
            for (int i = 0; i < dtPosts.Rows.Count; i++)
            {
                postSource[i] = Convert.ToString(dtPosts.Rows[i]["Name"]);
            }

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(postSource);
            textBox1.AutoCompleteCustomSource = source;

        }
    }
}
