using Focus.Transactions.DataStructs;
using Focus.TranSettings.DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XternalDevLib
{
    class GermanExpert
    {
        DevLib Xlib = new DevLib();
        public bool JR_Issue_Update(Transaction objTrans, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            bool rtnFlag = true;
            try
            {

                int iJobOrder = Convert.ToInt32(Xlib.GetTagValue(3005, objTrans.BodyData, iRowindex));
                if(iJobOrder > 0)
                {
                    Xlib.ExecuteNonQueryAPI("Exec xsp_Update_JobRequest_Issue '" + Convert.ToString(iJobOrder) + "'");
                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog("GermanExpert.JR_Issue_Update()");
            }

            return rtnFlag;
        }

        public bool JR_Return_Update(Transaction objTrans, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            bool rtnFlag = true;
            try
            {

                int iJobOrder = Convert.ToInt32(Xlib.GetTagValue(3005, objTrans.BodyData, iRowindex));
                if (iJobOrder > 0)
                {
                    Xlib.ExecuteNonQueryAPI("Exec xsp_Update_JobRequest_Return '" + Convert.ToString(iJobOrder) + "'");
                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog("GermanExpert.JR_Return_Update()");
            }

            return rtnFlag;
        }

    }
}
