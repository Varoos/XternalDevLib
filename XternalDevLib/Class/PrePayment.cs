using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XternalDevLib
{
    class PrePayment
    {

        DevLib Xlib = new DevLib();
        DBEntity DB = new DBEntity();
        public void PrePayment00()
        {
            try
            {
                DB.xf_DateAdd();
                DB.xf_AmortizationCalculation();
                DB.xsp_PrePayment_List();
                DB.xsp_PrePayment_Posting();
                DB.xsp_Update_PrePayment_PostedDate();

                frmPrePayment00 frm = new frmPrePayment00();
                frm.Text = "Pre-Payment";
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Triggers.PrePayment00()");
            }
        }

    }
}
