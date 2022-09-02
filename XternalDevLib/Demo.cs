using Focus.Transactions.DataStructs;
using Focus.TranSettings.DataStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XternalDevLib
{
    class Demo
    {
        DevLib Xlib = new DevLib();
        public void ALD_SalesQuot_Print(Transaction objTrans, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            try
            {
                string HeaderId = Convert.ToString(objTrans.Header.HeaderId);
                DataTable dt = new DataTable();
                string SQL = " Exec xsp_Sales_Quotation_Print '" + HeaderId + "'";
                dt = Xlib.GetDataTableAPI(SQL);
                Xlib.ReportShow("Sales_Quotation_Print1.rdl", new string[] { "DataSet1" }, new DataTable[] { dt }, "Sales Quotation Print");


            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Demo.ALD_SalesQuot_Print()");
            }
        }

        public void ALD_SalesQuot_Print1(Transaction objTrans, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            try
            {
                string HeaderId = Convert.ToString(objTrans.Header.HeaderId);
                DataTable dt = new DataTable();
                string SQL = " Exec xsp_Sales_Quotation_Print '" + HeaderId + "'";
                dt = Xlib.GetDataTableAPI(SQL);
                Xlib.ReportShow("Sales_Quotation_Print.rdl", new string[] { "DataSet1" }, new DataTable[] { dt }, "Sales Quotation Print");


            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Demo.ALD_SalesQuot_Print()");
            }
        }



        public void ALD_ProductQuery()
        {
            try
            {
                SearchByTags[] searchByTag = new SearchByTags[9];

                int t = -1;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3011;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3016;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3031;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3039;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3013;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3028;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3009;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3012;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;

                t++;
                searchByTag[t] = new SearchByTags();
                searchByTag[t].TagId = 3027;
                searchByTag[t].UseQuery = false;
                searchByTag[t].Display = 3;



                Xlib.DefaultFormDetailedMultiGVRpt("Ibrahim", searchByTag, "xsp_ProductSearch", -1, true);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Demo.ALD_ProductQuery()");
            }
        }

    }
}
