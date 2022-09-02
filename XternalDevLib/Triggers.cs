using Focus.Common.DataStructs;
using Focus.Transactions.DataStructs;
using Focus.TranSettings.DataStructs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XternalDevLib
{
    public class Triggers
    {
        DevLib Xlib = new DevLib();

        public void TestFunction(Transaction objTrans, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            //DataTable dt = new DataTable();
            //dt = Xlib.GetVoucherBodyData(3328);
            MessageBox.Show(Xlib.TestConn());
        }
        public void TestForm()
        {
            TestForm frm = new TestForm();
            frm.Show();
        }

        public void MenuUpdate()
        {
            try
            {
                frmMenuUpdate frm = new frmMenuUpdate();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Triggers.MenuUpdate()");
            }
        }

        public void ChequePrint(Transaction objTrans, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            try
            {
                frmChequePrint f = new frmChequePrint();
                f.lblHeaderId.Text = Convert.ToString(objTrans.Header.HeaderId);
                f.lblVType.Text = Convert.ToString(objTrans.Header.VoucherType);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Triggers.ChequePrint()");
            }
        }

        public void IbrahimForm()
        {
            DeleteVoucher frm = new DeleteVoucher();
            frm.Show();
        }


        public bool IbrahimStruct(Transaction T, VWVoucherSettings objSettings, int iField, String strFieldName, int iRowindex)
        {
            try
            {
                string FileName = Convert.ToString(T.Header.VoucherType);
                string VoucherType = Xlib.ExecuteScalar("Select iVoucherType & 0XFF00 From cCore_Vouchers_0 Where iVoucherType = " + FileName);

                //if (VoucherType == "4608") // 4608 = Bank Receipt
                //{
                //    PostingStruct_Type1(T, FileName);
                //}
                //else
                //{
                //    PostingStruct_Others(T, FileName);
                //}
                PostingStruct_Final(T, VoucherType, FileName);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.PostingStruct()");
            }
            return true;
        }
        private void PostingStruct_Type1(Transaction T, string FileName)
        {
            try
            {
                Xlib.PostVoucherStrust(FileName, "");
                Xlib.PostVoucherStrust(FileName, "Transaction objTr = new Transaction();");

                Xlib.PostVoucherStrust(FileName, "#region Header");
                Xlib.PostVoucherStrust(FileName, "int VoucherName = " + FileName + ";             /// ");
                Xlib.PostVoucherStrust(FileName, "string DocNo = \"\";               /// ");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.VoucherType = VoucherName;             ///cCore_Vouchers_0");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.DocNo = DocNo;             ///DocumentNo");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.Date = new Date(Convert.ToInt32(\"YYYY\"), Convert.ToInt32(\"MM\"), Convert.ToInt32(\"DD\"), CalendarType.Gregorean);              ///DocumentDate");
                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "#region Header Extra");

                int he = T.HeaderExtra.Length;
                if (he > 0)
                {
                    Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra = new IdNamePair[" + Convert.ToString(he) + "];");
                    Xlib.PostVoucherStrust(FileName, "int z = -1;");
                    int LAY_HDR = Convert.ToInt32(VTFIELDFLAG.LAY_HDR);
                    for (int i = 0; i < he; i++)
                    {
                        Xlib.PostVoucherStrust(FileName, "z++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z] = new IdNamePair();                ///sNarration");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z].ID = " + Convert.ToString(T.HeaderExtra[i].ID - LAY_HDR) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z].Tag = Convert.ToString(\"\");");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                }
                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "#region Body");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData = new TransBody[BodyRowCount];");
                Xlib.PostVoucherStrust(FileName, "//Body For Loop Start");

                Xlib.PostVoucherStrust(FileName, "#region BodyData");

                Xlib.PostVoucherStrust(FileName, "int i = 0;");
                //for (int i = 0; i < T.BodyData.Length; i++)
                {
                    int i = 0;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i] = new TransBody();");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Code = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].Code) + ");             ///Account1");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Book = " + Convert.ToString(T.BodyData[i].Book) + ";             ///Account2");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].FATag = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].FATag) + ");               ///FATag");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].InvTag = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].InvTag) + ");               ///InvTag");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].DueDate = new Date(Convert.ToInt32(\"YYYY\"), Convert.ToInt32(\"MM\"), Convert.ToInt32(\"DD\"), CalendarType.Gregorean);              ///DocumentDueDate");

                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].OriginalAmounts[0] = Convert.ToDecimal(" + T.BodyData[i].OriginalAmounts[0] + ");               ///Debit Amount");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].OriginalAmounts[1] = Convert.ToDecimal(" + T.BodyData[i].OriginalAmounts[1] + ");               ///Credit Amount");

                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Tags");

                    int Tags = T.BodyData[i].Tags.Length;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags = new IdNamePair[" + Convert.ToString(Tags) + "];");
                    Xlib.PostVoucherStrust(FileName, "int y = -1;");
                    int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                    for (int j = 0; j < Tags; j++)
                    {
                        Xlib.PostVoucherStrust(FileName, "y++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y] = new IdNamePair();               ///");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y].ID = " + Convert.ToString(T.BodyData[i].Tags[j].ID - LAY_BODY) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y].Tag = Convert.ToInt32(\"\");      //");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                    Xlib.PostVoucherStrust(FileName, "#endregion");


                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Extra");

                    int be = T.BodyData[i].BodyExtra.Length;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra = new IdNamePair[" + Convert.ToString(be) + "];");
                    Xlib.PostVoucherStrust(FileName, "int k = -1;");
                    //int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                    for (int j = 0; j < be; j++)
                    {
                        Xlib.PostVoucherStrust(FileName, "k++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[j].BodyExtra[k] = new IdNamePair();               ///");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[j].BodyExtra[k].ID = " + Convert.ToString(T.BodyData[i].BodyExtra[j].ID - LAY_BODY) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[j].BodyExtra[k].Tag = Convert.ToString(\"\");      //");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                    Xlib.PostVoucherStrust(FileName, "#endregion");

                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Bill Wise Reference");

                    if (Convert.ToString(T.BodyData[i].BillwiseData) != "")
                    {
                        int BWR = T.BodyData[i].BillwiseData.Length;
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData = new BillAdjustment[" + Convert.ToString(BWR) + "];");
                        Xlib.PostVoucherStrust(FileName, "int r = -1;");
                        //int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                        for (int j = 0; j < be; j++)
                        {
                            Xlib.PostVoucherStrust(FileName, "r++;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r] = new BillAdjustment();");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].sReference = \"\";");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iBodyId = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iRefType = (byte)0; //0 - new, 1 - onaccount,2–adjust");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iRef = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iCode = objTr.BodyData[j].Book;  //iBook;");

                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iAccount = objTr.BodyData[j].Code;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].dDueDate = objTr.BodyData[j].DueDate;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iProduct = objTr.BodyData[j].Sales.Product;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iLocalCurrencyId = 7;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDLocalConversionRate = 1;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDLocalCurrency = Convert.ToDecimal(Gross);");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mNativeCurrency = Convert.ToDecimal(Gross);");

                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iCurrencyId = 7;       //  Defaultcurrency;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDBaseCurrency = Convert.ToDecimal(Gross);      //dAmount + fAllJVSum;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDBillCurrency = Convert.ToDecimal(Gross);      //dAmount + fAllJVSum;");
                            Xlib.PostVoucherStrust(FileName, "////objTr.BodyData[j].BillwiseData[r].iMasterTypeId = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDConversionRate = 1;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].NegetiveAmount = !FConvert.IsItNegative(objTr.Header.VoucherType);");
                            Xlib.PostVoucherStrust(FileName, "");
                        }
                        Xlib.PostVoucherStrust(FileName, "#endregion");
                    }
                }

                Xlib.PostVoucherStrust(FileName, "#endregion");

                Xlib.PostVoucherStrust(FileName, "//Body For Loop End");

                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "Output objReturn = Connection.CallServeRequest(ServiceType.Transaction, TransMethods.PostVoucher, objTr, 1);");
                Xlib.PostVoucherStrust(FileName, "if (objReturn != null)");
                Xlib.PostVoucherStrust(FileName, "{");
                Xlib.PostVoucherStrust(FileName, "if ((objReturn.ReturnData as VoucherPostStatus).Posted)");
                Xlib.PostVoucherStrust(FileName, "{");
                Xlib.PostVoucherStrust(FileName, "}");
                Xlib.PostVoucherStrust(FileName, "}");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.PostingStruct_Others()");
            }
        }

        private void PostingStruct_Others(Transaction T, string FileName)
        {
            try
            {
                Xlib.PostVoucherStrust(FileName, "");
                Xlib.PostVoucherStrust(FileName, "Transaction objTr = new Transaction();");

                Xlib.PostVoucherStrust(FileName, "#region Header");
                Xlib.PostVoucherStrust(FileName, "int VoucherName = " + FileName + ";             /// ");
                Xlib.PostVoucherStrust(FileName, "string DocNo = \"\";               /// ");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.VoucherType = VoucherName;             ///cCore_Vouchers_0");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.DocNo = DocNo;             ///DocumentNo");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.Date = new Date(Convert.ToInt32(\"YYYY\"), Convert.ToInt32(\"MM\"), Convert.ToInt32(\"DD\"), CalendarType.Gregorean);              ///DocumentDate");
                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "#region Header Extra");

                int he = T.HeaderExtra.Length;
                if (he > 0)
                {
                    Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra = new IdNamePair[" + Convert.ToString(he) + "];");
                    Xlib.PostVoucherStrust(FileName, "int z = -1;");
                    int LAY_HDR = Convert.ToInt32(VTFIELDFLAG.LAY_HDR);
                    for (int i = 0; i < he; i++)
                    {
                        Xlib.PostVoucherStrust(FileName, "z++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z] = new IdNamePair();                ///" + Xlib.ExecuteScalar("Select sFieldName From cCore_VoucherFields_0 Where iFieldId = " + Convert.ToString(T.HeaderExtra[i].ID - LAY_HDR) + "") + "");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z].ID = " + Convert.ToString(T.HeaderExtra[i].ID - LAY_HDR) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z].Tag = Convert.ToString(\"\");");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                }
                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "#region Body");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData = new TransBody[BodyRowCount];");
                Xlib.PostVoucherStrust(FileName, "//Body For Loop Start");

                Xlib.PostVoucherStrust(FileName, "#region BodyData");

                Xlib.PostVoucherStrust(FileName, "int i = 0;");
                //for (int i = 0; i < T.BodyData.Length; i++)
                {
                    int i = 0;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i] = new TransBody();");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Code = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].Code) + ");             ///Account1");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Book = " + Convert.ToString(T.BodyData[i].Book) + ";             ///Account2");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].FATag = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].FATag) + ");               ///FATag");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].InvTag = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].InvTag) + ");               ///InvTag");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].DueDate = new Date(Convert.ToInt32(\"YYYY\"), Convert.ToInt32(\"MM\"), Convert.ToInt32(\"DD\"), CalendarType.Gregorean);              ///DocumentDueDate");

                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Tags");

                    int Tags = T.BodyData[i].Tags.Length;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags = new IdNamePair[" + Convert.ToString(Tags) + "];");
                    Xlib.PostVoucherStrust(FileName, "int y = -1;");
                    int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                    for (int j = 0; j < Tags; j++)
                    {
                        Xlib.PostVoucherStrust(FileName, "y++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y] = new IdNamePair();               ///" + Xlib.ExecuteScalar("Select sMasterName From cCore_MasterDef Where iMasterTypeId = " + Convert.ToString(T.BodyData[i].Tags[j].ID) + "") + "");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y].ID = " + Convert.ToString(T.BodyData[i].Tags[j].ID) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y].Tag = Convert.ToInt32(\"\");      //");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                    Xlib.PostVoucherStrust(FileName, "#endregion");


                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Extra");

                    int be = T.BodyData[i].BodyExtra.Length;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra = new IdNamePair[" + Convert.ToString(be) + "];");
                    Xlib.PostVoucherStrust(FileName, "int k = -1;");
                    //int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                    for (int j = 0; j < be; j++)
                    {
                        Xlib.PostVoucherStrust(FileName, "k++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra[k] = new IdNamePair();               ///" + Xlib.ExecuteScalar("Select sFieldName From cCore_VoucherFields_0 Where iFieldId = " + Convert.ToString(T.BodyData[i].BodyExtra[j].ID - LAY_BODY) + "") + "");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra[k].ID = " + Convert.ToString(T.BodyData[i].BodyExtra[j].ID - LAY_BODY) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra[k].Tag = Convert.ToString(\"\");      //");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                    Xlib.PostVoucherStrust(FileName, "#endregion");


                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Sales");

                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales = new TransSales();");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Product = Convert.ToInt32(\"ProductId\");        // ");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Unit = Convert.ToInt32(\"UnitId\");        // ");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Quantity = Convert.ToDecimal(\"QUANTITY\");");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.OrigRate = Convert.ToDecimal(\"RATE\");");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Rate = Convert.ToDecimal(\"RATE\");");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Gross = Convert.ToDecimal(\"Gross\");");
                    Xlib.PostVoucherStrust(FileName, "#endregion");


                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Bill Wise Reference");

                    if (Convert.ToString(T.BodyData[i].BillwiseData) != "")
                    {
                        int BWR = T.BodyData[i].BillwiseData.Length;
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData = new BillAdjustment[" + Convert.ToString(BWR) + "];");
                        Xlib.PostVoucherStrust(FileName, "int r = -1;");
                        //int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                        for (int j = 0; j < be; j++)
                        {
                            Xlib.PostVoucherStrust(FileName, "r++;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r] = new BillAdjustment();");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].sReference = \"\";");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iBodyId = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iRefType = (byte)0; //0 - new, 1 - onaccount,2–adjust");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iRef = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iCode = objTr.BodyData[j].Book;  //iBook;");

                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iAccount = objTr.BodyData[j].Code;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].dDueDate = objTr.BodyData[j].DueDate;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iProduct = objTr.BodyData[j].Sales.Product;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iLocalCurrencyId = 7;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDLocalConversionRate = 1;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDLocalCurrency = Convert.ToDecimal(Gross);");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mNativeCurrency = Convert.ToDecimal(Gross);");

                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iCurrencyId = 7;       //  Defaultcurrency;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDBaseCurrency = Convert.ToDecimal(Gross);      //dAmount + fAllJVSum;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDBillCurrency = Convert.ToDecimal(Gross);      //dAmount + fAllJVSum;");
                            Xlib.PostVoucherStrust(FileName, "////objTr.BodyData[j].BillwiseData[r].iMasterTypeId = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDConversionRate = 1;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].NegetiveAmount = !FConvert.IsItNegative(objTr.Header.VoucherType);");
                            Xlib.PostVoucherStrust(FileName, "");
                        }
                        Xlib.PostVoucherStrust(FileName, "#endregion");
                    }
                }

                Xlib.PostVoucherStrust(FileName, "#endregion");

                Xlib.PostVoucherStrust(FileName, "//Body For Loop End");

                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "if (Xlib.PostVoucher(objTr))");
                Xlib.PostVoucherStrust(FileName, "{");
                Xlib.PostVoucherStrust(FileName, "}");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.PostingStruct_Others()");
            }
        }


        private void PostingStruct_Final(Transaction T, string VoucherType, string FileName)
        {
            try
            {
                Xlib.PostVoucherStrust(FileName, "");
                Xlib.PostVoucherStrust(FileName, "Transaction objTr = new Transaction();");

                Xlib.PostVoucherStrust(FileName, "#region Header");
                Xlib.PostVoucherStrust(FileName, "int VoucherName = " + FileName + ";             /// ");
                Xlib.PostVoucherStrust(FileName, "string DocNo = \"\";               /// ");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.VoucherType = VoucherName;             ///cCore_Vouchers_0");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.DocNo = DocNo;             ///DocumentNo");
                Xlib.PostVoucherStrust(FileName, "objTr.Header.Date = new Date(Convert.ToInt32(\"YYYY\"), Convert.ToInt32(\"MM\"), Convert.ToInt32(\"DD\"), CalendarType.Gregorean);              ///DocumentDate");
                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "#region Header Extra");

                int he = T.HeaderExtra.Length;
                if (he > 0)
                {
                    Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra = new IdNamePair[" + Convert.ToString(he) + "];");
                    Xlib.PostVoucherStrust(FileName, "int z = -1;");
                    int LAY_HDR = Convert.ToInt32(VTFIELDFLAG.LAY_HDR);
                    for (int i = 0; i < he; i++)
                    {
                        Xlib.PostVoucherStrust(FileName, "z++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z] = new IdNamePair();                ///" + Xlib.ExecuteScalar("Select sFieldName From cCore_VoucherFields_0 Where iFieldId = " + Convert.ToString(T.HeaderExtra[i].ID - LAY_HDR) + "") + "");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z].ID = " + Convert.ToString(T.HeaderExtra[i].ID - LAY_HDR) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.HeaderExtra[z].Tag = Convert.ToString(\"\");");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                }
                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "#region Body");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData = new TransBody[BodyRowCount];");
                Xlib.PostVoucherStrust(FileName, "//Body For Loop Start");

                Xlib.PostVoucherStrust(FileName, "#region BodyData");

                Xlib.PostVoucherStrust(FileName, "int i = 0;");
                //for (int i = 0; i < T.BodyData.Length; i++)
                {
                    int i = 0;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i] = new TransBody();");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Code = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].Code) + ");             ///Account1");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Book = " + Convert.ToString(T.BodyData[i].Book) + ";             ///Account2");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].FATag = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].FATag) + ");               ///FATag");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].InvTag = Convert.ToInt32(" + Convert.ToString(T.BodyData[i].InvTag) + ");               ///InvTag");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].DueDate = new Date(Convert.ToInt32(\"YYYY\"), Convert.ToInt32(\"MM\"), Convert.ToInt32(\"DD\"), CalendarType.Gregorean);              ///DocumentDueDate");

                    if (VoucherType == "8704"    //Journal Entries
                        )
                    {
                        BodyDataAmount_Struct(FileName);
                    }
                    else if (VoucherType == "3584"  //Non-Standard Journal Entries
                        )
                    {
                        BodyDataAmount2_Struct(FileName);
                    }

                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Tags");

                    int Tags = T.BodyData[i].Tags.Length;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags = new IdNamePair[" + Convert.ToString(Tags) + "];");
                    Xlib.PostVoucherStrust(FileName, "int y = -1;");
                    int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                    for (int j = 0; j < Tags; j++)
                    {
                        Xlib.PostVoucherStrust(FileName, "y++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y] = new IdNamePair();               ///" + Xlib.ExecuteScalar("Select sMasterName From cCore_MasterDef Where iMasterTypeId = " + Convert.ToString(T.BodyData[i].Tags[j].ID) + "") + "");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y].ID = " + Convert.ToString(T.BodyData[i].Tags[j].ID) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Tags[y].Tag = Convert.ToInt32(\"\");      //");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                    Xlib.PostVoucherStrust(FileName, "#endregion");


                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Extra");

                    int be = T.BodyData[i].BodyExtra.Length;
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra = new IdNamePair[" + Convert.ToString(be) + "];");
                    Xlib.PostVoucherStrust(FileName, "int k = -1;");
                    //int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                    for (int j = 0; j < be; j++)
                    {
                        Xlib.PostVoucherStrust(FileName, "k++;");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra[k] = new IdNamePair();               ///" + Xlib.ExecuteScalar("Select sFieldName From cCore_VoucherFields_0 Where iFieldId = " + Convert.ToString(T.BodyData[i].BodyExtra[j].ID - LAY_BODY) + "") + "");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra[k].ID = " + Convert.ToString(T.BodyData[i].BodyExtra[j].ID - LAY_BODY) + ";");
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BodyExtra[k].Tag = Convert.ToString(\"\");      //");
                        Xlib.PostVoucherStrust(FileName, "");
                    }
                    Xlib.PostVoucherStrust(FileName, "#endregion");

                    if (VoucherType == "1024" ||   //Receipts from production
                        VoucherType == "1280" ||   //Material Receipt Notes
                        VoucherType == "1536" ||   //Job Work Receipts
                        VoucherType == "1792" ||   //Sales Returns
                        VoucherType == "2048" ||   //Excesses in Stocks
                        VoucherType == "2304" ||   //Purchases Quotations
                        VoucherType == "256" ||   //Opening Balances
                        VoucherType == "2560" ||   //Purchases Orders
                        VoucherType == "2816" ||   //Production Process
                        VoucherType == "3072" ||   //Stock Transfers
                        VoucherType == "3328" ||   //Cash Sales //Sales Invoices
                        VoucherType == "3840" ||   //Debit Notes
                        VoucherType == "4096" ||   //Credit Notes
                        VoucherType == "4608" ||   //Receipts
                        VoucherType == "4864" ||   //Payments
                        VoucherType == "512" ||   //Opening Stocks
                        VoucherType == "5120" ||   //Petty Cash
                        VoucherType == "5376" ||   //Shortages in Stock
                        VoucherType == "5632" ||   //Sales Orders
                        VoucherType == "5888" ||   //Post-Dated Receipts
                        VoucherType == "6144" ||   //Delivery Notes
                        VoucherType == "6400" ||   //Purchases Returns
                        VoucherType == "6656" ||   //Issues to Production
                        VoucherType == "6912" ||   //Job Work Issues
                        VoucherType == "7168" ||   //Post-Dated Payments
                        VoucherType == "7424" ||   //Sales Quotations
                        VoucherType == "768" ||   //Purchases Vouchers
                        VoucherType == "7680" ||   //Job Order
                        VoucherType == "7936" ||   //Material Requisition
                        VoucherType == "8192" ||   //Request For Quote
                        VoucherType == "8448"    //Forex JV
                        )
                    {
                        BodyDataSales_Struct(FileName);
                    }
                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Sales");

                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales = new TransSales();");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Product = Convert.ToInt32(\"ProductId\");        // ");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Unit = Convert.ToInt32(\"UnitId\");        // ");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Quantity = Convert.ToDecimal(\"QUANTITY\");");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.OrigRate = Convert.ToDecimal(\"RATE\");");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Rate = Convert.ToDecimal(\"RATE\");");
                    Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Gross = Convert.ToDecimal(\"Gross\");");
                    Xlib.PostVoucherStrust(FileName, "#endregion");


                    Xlib.PostVoucherStrust(FileName, "");
                    Xlib.PostVoucherStrust(FileName, "#region BodyData Bill Wise Reference");

                    if (Convert.ToString(T.BodyData[i].BillwiseData) != "")
                    {
                        int BWR = T.BodyData[i].BillwiseData.Length;
                        Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData = new BillAdjustment[" + Convert.ToString(BWR) + "];");
                        Xlib.PostVoucherStrust(FileName, "int r = -1;");
                        //int LAY_BODY = Convert.ToInt32(VTFIELDFLAG.LAY_BODY);
                        for (int j = 0; j < be; j++)
                        {
                            Xlib.PostVoucherStrust(FileName, "r++;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r] = new BillAdjustment();");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].sReference = \"\";");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iBodyId = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iRefType = (byte)0; //0 - new, 1 - onaccount,2–adjust");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iRef = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iCode = objTr.BodyData[j].Book;  //iBook;");

                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iAccount = objTr.BodyData[j].Code;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].dDueDate = objTr.BodyData[j].DueDate;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iProduct = objTr.BodyData[j].Sales.Product;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iLocalCurrencyId = 7;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDLocalConversionRate = 1;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDLocalCurrency = Convert.ToDecimal(Gross);");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mNativeCurrency = Convert.ToDecimal(Gross);");

                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].iCurrencyId = 7;       //  Defaultcurrency;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDBaseCurrency = Convert.ToDecimal(Gross);      //dAmount + fAllJVSum;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDBillCurrency = Convert.ToDecimal(Gross);      //dAmount + fAllJVSum;");
                            Xlib.PostVoucherStrust(FileName, "////objTr.BodyData[j].BillwiseData[r].iMasterTypeId = 0;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].mBATDConversionRate = 1;");
                            Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].BillwiseData[r].NegetiveAmount = !FConvert.IsItNegative(objTr.Header.VoucherType);");
                            Xlib.PostVoucherStrust(FileName, "");
                        }
                        Xlib.PostVoucherStrust(FileName, "#endregion");
                    }
                }

                Xlib.PostVoucherStrust(FileName, "#endregion");

                Xlib.PostVoucherStrust(FileName, "//Body For Loop End");

                Xlib.PostVoucherStrust(FileName, "#endregion");
                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "");

                Xlib.PostVoucherStrust(FileName, "if (Xlib.PostVoucher(objTr))");
                Xlib.PostVoucherStrust(FileName, "{");
                Xlib.PostVoucherStrust(FileName, "}");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.PostingStruct_Others()");
            }
        }


        protected void BodyDataSales_Struct(string FileName)
        {
            try
            {
                Xlib.PostVoucherStrust(FileName, "");
                Xlib.PostVoucherStrust(FileName, "#region BodyData Sales");

                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales = new TransSales();");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Product = Convert.ToInt32(\"ProductId\");        // ");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Unit = Convert.ToInt32(\"UnitId\");        // ");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Quantity = Convert.ToDecimal(\"QUANTITY\");");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.OrigRate = Convert.ToDecimal(\"RATE\");");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Rate = Convert.ToDecimal(\"RATE\");");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Sales.Gross = Convert.ToDecimal(\"Gross\");");
                Xlib.PostVoucherStrust(FileName, "#endregion");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.BodyDataSales_Struct()");
            }
        }

        protected void BodyDataAmount_Struct(string FileName)
        {
            try
            {
                Xlib.PostVoucherStrust(FileName, "");
                //Xlib.PostVoucherStrust(FileName, "#region BodyData Amounts");

                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Amounts[0] = Math.Abs(Convert.ToDecimal(0));");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].OriginalAmounts[0] = Convert.ToDecimal(0);");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].OriginalAmounts[1] = -1 * Convert.ToDecimal(0);");
                //Xlib.PostVoucherStrust(FileName, "#endregion");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.BodyDataAmount_Struct()");
            }
        }

        protected void BodyDataAmount2_Struct(string FileName)
        {
            try
            {
                Xlib.PostVoucherStrust(FileName, "");
                //Xlib.PostVoucherStrust(FileName, "#region BodyData Amounts");

                Xlib.PostVoucherStrust(FileName, "int dtRNo = -1;                   //Note: put it before BodyData loop");
                Xlib.PostVoucherStrust(FileName, "dtRNo++;");
                Xlib.PostVoucherStrust(FileName, "if (i % 2 > 0){dtRNo--;}");
                Xlib.PostVoucherStrust(FileName, "int Account = Convert.ToInt32(dt.Rows[dtRNo][ControlAC_Dr]);");
                Xlib.PostVoucherStrust(FileName, "decimal PostingAmount = Convert.ToDecimal(dt.Rows[dtRNo][Amount]);");
                Xlib.PostVoucherStrust(FileName, "if (i % 2 > 0)");
                Xlib.PostVoucherStrust(FileName, "{");
                Xlib.PostVoucherStrust(FileName, " Account = Convert.ToInt32(dt.Rows[dtRNo][AC_Cr]);");
                Xlib.PostVoucherStrust(FileName, "PostingAmount = PostingAmount * (-1);");
                Xlib.PostVoucherStrust(FileName, "}");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Code = Account;");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].Amounts[0] = -1 * Math.Abs(PostingAmount);");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].OriginalAmounts[0] = -1 * PostingAmount;");
                Xlib.PostVoucherStrust(FileName, "objTr.BodyData[i].OriginalAmounts[1] = PostingAmount;");
                //Xlib.PostVoucherStrust(FileName, "#endregion");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.BodyDataAmount_Struct()");
            }
        }

        public void UpdateDocNo()
        {
            UpdateDocNo frm = new UpdateDocNo();
            frm.ShowDialog();
        }

        public void DeleteVoucher()
        {
            frmDelete frm = new frmDelete();
            frm.ShowDialog();
        }

        public void ReportTest()
        {
            DataTable dt = new DataTable();

            string SQL = "Select Top(50) iHeaderId,iDate,iVoucherType,sVoucherNo  From tCore_Header_0 ";
            dt = Xlib.GetDataTableAPI(SQL);

            //Xlib.GridViewReport(dt, "Test Report");
            string FilePath = Xlib.ReportShow("Test.rdl", new string[] { "DataSet1" }, new DataTable[] { dt }, "TestForm", 2);

            Xlib.SendEmail("", "", new string[] { "prabhat@focussoftnet.com" }, new string[] { }, new string[] { }, "Say YO...", "Say Yo .... Bro...", new string[] { FilePath }, "", 0);





        }

        public void DefaultFormTest()
        {
            try
            {
                SearchByTags[] searchByTags = new SearchByTags[12];

                int i = -1;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 2;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 0;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 2;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 0;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 2;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 0;


                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 2;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 2;

                i++;
                searchByTags[i] = new SearchByTags();
                searchByTags[i].TagId = 1;
                searchByTags[i].UseQuery = false;
                searchByTags[i].Display = 0;


                //MultiSelectTags[] multiSelectTags = new MultiSelectTags[1];

                //int j = -1;

                //j++;
                //multiSelectTags[j] = new MultiSelectTags();
                //multiSelectTags[j].TagId = 1;
                //multiSelectTags[j].UseQuery = false;

                //Xlib.DefaultFormSearchByTags("my Form Title", multiSelectTags, searchByTags);

                //Xlib.DefaultFormSearchByTags("my Form Title", searchByTags,0);

                Xlib.DefaultFormDateOnly("Test", 0);


            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.DefaultFormTest");
            }
        }

        public void DefaultFormTest2()
        {
            try
            {
                MultiSelectTags[] multiSelectTags = new MultiSelectTags[2];

                int x = -1;

                x++;
                multiSelectTags[x] = new MultiSelectTags();
                multiSelectTags[x].TagId = 1;
                multiSelectTags[x].UseQuery = false;

                x++;
                multiSelectTags[x] = new MultiSelectTags();
                multiSelectTags[x].TagId = 5;
                multiSelectTags[x].UseQuery = false;


                SearchByTags[] searchByTags = new SearchByTags[1];


                int y = -1;

                y++;
                searchByTags[y] = new SearchByTags();
                searchByTags[y].TagId = 4;
                searchByTags[y].UseQuery = false;
                searchByTags[y].Display = 2;

                string sXML = "";
                sXML = Xlib.DefaultFormSearchByTags_xml("Stock Movement Report", multiSelectTags, searchByTags, 0, 1);

                Xlib.Loading(true);
                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI("Exec xsp_MFS_Report2'" + sXML + "'");

                if (dt.Rows.Count > 0)
                {
                    //Xlib.ReportShow("Customer_Cumalative_Statement.rdl", new string[] { "DataSet1" }, new DataTable[] { dt }, "Customer Cumalative Statement");
                }
                else
                {
                    //Xlib.MsgBox(3);
                }

                Xlib.Loading(false);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.DefaultFormTest");
            }
        }

        public void DefaultFormTest3()
        {
            try
            {

                string SQL = "";
                DataTable dt_DF = new DataTable();

                MultiSelectTags[] multiSelectTags = new MultiSelectTags[1];

                int x = -1;

                SQL = "Exec xsp_TCNo_List";
                x++;
                multiSelectTags[x] = new MultiSelectTags();
                multiSelectTags[x].UseQuery = true;
                multiSelectTags[x].Query = SQL;
                multiSelectTags[x].TagLabel = "TC No.";
                multiSelectTags[x].IdColumnName = "iMasterId";
                multiSelectTags[x].TagId = 0;

                SearchByTags[] searchByTags = new SearchByTags[0];

                dt_DF = Xlib.DefaultFormSearchByTags("Amortization Posting", multiSelectTags, searchByTags, 2);


            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Triggers.DefaultFormTest3()");
            }
        }

        public void Product_Bin_WH_Wise()
        {
            try
            {
                DataTable dt_DForm = new DataTable();

                MultiSelectTags[] multiSelectTags = new MultiSelectTags[1];

                int x = -1;

                x++;
                multiSelectTags[x] = new MultiSelectTags();
                multiSelectTags[x].TagId = 12;
                multiSelectTags[x].UseQuery = false;

                SearchByTags[] searchByTags = new SearchByTags[1];

                int y = -1;

                y++;
                searchByTags[y] = new SearchByTags();
                searchByTags[y].TagId = 4;
                searchByTags[y].UseQuery = false;
                searchByTags[y].Display = 2;


                dt_DForm = Xlib.DefaultFormSearchByTags("Product Bin & Warehouse Wise", multiSelectTags, searchByTags);

                string sBinsId = Xlib.DataTable_Select(dt_DForm, "MultiSelectTag12");
                string sWHId = Xlib.DataTable_Select(dt_DForm, "Tag4");

                DataTable dt = new DataTable();
                dt = Xlib.GetDataTableAPI("Exec xsp_Product_Bin_WH 0,0,'0'");
                Xlib.GridViewReport(dt, "Product Bin & Warehouse Wise");
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.Product_Bin_WH_Wise()");
            }
        }

        public void QueryToGrid_Report()
        {
            try
            {
                frmQueryToReport f = new frmQueryToReport();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Trigger.QueryToGrid_Report()");
            }
        }

        public void Beat_Year_Ago_Sales_Test()
        {
            try
            {
                SearchByTags[] searchByTags = new SearchByTags[1];

                int i = -1;

                i++;
                searchByTags[0] = new SearchByTags();
                searchByTags[0].UseQuery = false;
                searchByTags[0].TagId = 1100;

                DataTable dt_DF = new DataTable();
                dt_DF = Xlib.DefaultFormSearchByTags("Beat Year Ago Sales", searchByTags, 0, "Beat_Year_Ago_Sales.rdl", "xsp_Beat_Year_Ago_Sales", true);

                //string iStartDate = Xlib.DataTable_Select(dt_DF, "iStartDate");
                //string iEndDate = Xlib.DataTable_Select(dt_DF, "iEndDate");
                //string sOutlet = Xlib.DataTable_Select(dt_DF, "Tag1100");

                //DataTable dt = new DataTable();
                //dt = Xlib.GetDataTableAPI(" Exec xsp_Beat_Year_Ago_Sales '" + iStartDate + "','" + iEndDate + "', '" + sOutlet + "'");
                //Xlib.ReportShow("Beat_Year_Ago_Sales.rdl", new string[] { "DataSet1" }, new DataTable[] { dt }, "Beat Year Ago Sales", true);


            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "Triggers.Beat_Year_Ago_Sales()");
            }
        }


        public void ReportBuilder2016()
        {
            try
            {
                DataTable dt = new DataTable();
                string SQL = "Select Top (10) iMasterId, sName, sCode From mCore_Account";
                dt = Xlib.GetDataTableAPI(SQL);

                Xlib.ReportShow("Test.rdl", new string[] { "DataSet1" }, new DataTable[] { dt }, "Report Title", true);
            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "2016ReportBuilder");
            }
        }

    }
}
