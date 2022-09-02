using System;
using System.Data;
using Microsoft.Win32;
using System.Data.SqlClient;
using Focus.TranSettings.DataStructs;
using System.Windows.Forms;
using Focus.Conn;
using Focus.Common.DataStructs;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Xml;
using Focus.Transactions.DataStructs;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
//using Focus.Masters.DataStructs;
using System.Linq;
using System.Data.OleDb;
using System.Windows.Forms;
using XternalDevLib;
using Microsoft.Reporting.WinForms;
using System.Runtime.CompilerServices;


//namespace XternalDevLib
//{
public class DevLib
{
    int ConnTimeOut = 600;
    public SearchByTags[] SearchByTags;
    public MultiSelectTags[] MultiSelectTags;

    #region "Connection To Database"

    public int GetCompanyId()
    {

        int strReturn = 0;

        try
        {
            strReturn = CurrentData.get().CompanyId;
        }
        catch (Exception ex)
        {
            strReturn = 0;
            ErrLog(ex, "DevLib.GetCompanyId()");
        }
        return strReturn;
    }

    private string Default_Company()
    {

        string strReturn = string.Empty;

        try
        {
            string StrCompID = CurrentData.get().CompanyId.ToString();


            /* if (StrCompID == "0")
             {
                 StrCompID = "36";
             }*/

            strReturn = GetDBCodeFromERP("select sCompanyCode from Focus8Erp..tCore_Company_Details where iCompanyId=" + StrCompID + "");
            if (Convert.ToString(strReturn) == "")
            {
                strReturn = GetValueFromRegistry("CompCode");
            }

            /*
            if (Convert.ToInt32(StrCompID) == 36)
                strReturn = "010";
            else if (Convert.ToInt32(StrCompID) == 72)
                strReturn = "020";
            else if (Convert.ToInt32(StrCompID) == 108)
                strReturn = "030";
            else if (Convert.ToInt32(StrCompID) == 144)
                strReturn = "040";
            else if (Convert.ToInt32(StrCompID) == 180)
                strReturn = "050";
            else if (Convert.ToInt32(StrCompID) == 216)
                strReturn = "060";
            else if (Convert.ToInt32(StrCompID) == 252)
                strReturn = "070";
            else if (Convert.ToInt32(StrCompID) == 288)
                strReturn = "080";
            else if (Convert.ToInt32(StrCompID) == 324)
                strReturn = "090";

            else if (Convert.ToInt32(StrCompID) == 360)
                strReturn = "0A0";
            else if (Convert.ToInt32(StrCompID) == 396)
                strReturn = "0B0";
            else if (Convert.ToInt32(StrCompID) == 432)
                strReturn = "0C0";
            else if (Convert.ToInt32(StrCompID) == 468)
                strReturn = "0D0";
            else if (Convert.ToInt32(StrCompID) == 504)
                strReturn = "0E0";
            else if (Convert.ToInt32(StrCompID) == 540)
                strReturn = "0F0";
            else if (Convert.ToInt32(StrCompID) == 576)
                strReturn = "0G0";
            else if (Convert.ToInt32(StrCompID) == 612)
                strReturn = "0H0";
            else if (Convert.ToInt32(StrCompID) == 648)
                strReturn = "0I0";
            else if (Convert.ToInt32(StrCompID) == 684)
                strReturn = "0J0";
            else if (Convert.ToInt32(StrCompID) == 720)
                strReturn = "0K0";
            else if (Convert.ToInt32(StrCompID) == 756)
                strReturn = "0L0";
            else if (Convert.ToInt32(StrCompID) == 792)
                strReturn = "0M0";
            else if (Convert.ToInt32(StrCompID) == 828)
                strReturn = "0N0";
            else if (Convert.ToInt32(StrCompID) == 864)
                strReturn = "0O0";
            else if (Convert.ToInt32(StrCompID) == 900)
                strReturn = "0P0";
            else if (Convert.ToInt32(StrCompID) == 936)
                strReturn = "0Q0";
            else if (Convert.ToInt32(StrCompID) == 972)
                strReturn = "0R0";
            else if (Convert.ToInt32(StrCompID) == 1008)
                strReturn = "0S0";
            else if (Convert.ToInt32(StrCompID) == 1044)
                strReturn = "0T0";
            else if (Convert.ToInt32(StrCompID) == 1080)
                strReturn = "0U0";
            else if (Convert.ToInt32(StrCompID) == 1116)
                strReturn = "0V0";
            else if (Convert.ToInt32(StrCompID) == 1152)
                strReturn = "0W0";
            else if (Convert.ToInt32(StrCompID) == 1188)
                strReturn = "0X0";
            else if (Convert.ToInt32(StrCompID) == 1224)
                strReturn = "0Y0";
            else if (Convert.ToInt32(StrCompID) == 1260)
                strReturn = "0Z0";
            else
                strReturn = GetValueFromRegistry("CompCode");
                */



            //strReturn = "040";
            //Dim strReturn As String = RegValue(Microsoft.Win32.RegistryHive.Users, ".DEFAULT\Software\Focus8", "Compcode", "")
        }
        catch (Exception ex)
        {
            //ErrorLog(ex, "DevLib.Default_Company()");
        }
        return "Focus8" + strReturn;
    }

    private string GetDBCodeFromERP(string strQry)
    {
        string dblReturnVal = "";
        try
        {
            SqlConnection con = new SqlConnection(GetConnectionString_ERP());
            SqlCommand cmd = new SqlCommand(strQry, con);

            cmd.CommandTimeout = ConnTimeOut;
            con.Open();

            SqlDataReader Red = cmd.ExecuteReader();
            while (Red.Read())
            {
                dblReturnVal = Red.GetString(0);
            }

            Red.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDBCodeFromERP(" + strQry + ")");
        }
        return dblReturnVal;

    }

    private string SQLServerName()
    {
        string strReturn = "";
        try
        {
            strReturn = RegValue(RegistryHive.Users, ".DEFAULT\\Software\\Focus8", "SQLServerName", "");
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.SQLServerName()");
        }
        return strReturn;
    }
    private string SQLLoginID()
    {
        string strReturn = "";
        try
        {
            strReturn = RegValue(RegistryHive.Users, ".DEFAULT\\Software\\Focus8", "SQLLoginID", "");
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.SQLLoginID()");
        }
        return strReturn;
    }

    private string SQLPW()
    {
        string strReturn = "";
        try
        {
            strReturn = RegValue(RegistryHive.Users, ".DEFAULT\\Software\\Focus8", "SQLPW", "");
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.SQLPW()");
        }
        return strReturn;
    }

    private string ReportPath()
    {
        string strReturn = "";
        try
        {
            strReturn = RegValue(RegistryHive.Users, ".DEFAULT\\Software\\Focus8", "ReportPath", "");
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ReportPath()");
        }
        return strReturn;
    }

    public string GetValueFromRegistry(string StringName)
    {
        string strReturn = "";
        try
        {
            strReturn = RegValue(RegistryHive.Users, ".DEFAULT\\Software\\Focus8", StringName, "");
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetValueFromRegistry()");
        }
        return strReturn;
    }

    private string GetConnectionString(int ConnNo, string xConnString)
    {
        string ConnStr = "";
        try
        {
            // MessageBox.Show("Server Name=" & SQLServerName() & " Company= " & Default_Company() & " SQL Login=" & SQLLoginID() & " Password=" & SQLPW() & "")
            switch (ConnNo)
            {
                case 1:
                    //ConnStr = "Data Source=" + SQLServerName() + ";Initial Catalog=FocusInterface;" + "UId=" + SQLLoginID() + ";" + "Pwd=" + SQLPW() + "";
                    ConnStr = xConnString;
                    break;
                default:
                    ConnStr = "Data Source=" + SQLServerName() + ";Initial Catalog=" + Default_Company() + ";" + "UId=" + SQLLoginID() + ";" + "Pwd=" + SQLPW() + ";Connection Timeout=900";
                    break;
            }


        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetConnectionString()");
        }
        return ConnStr;
    }

    private string GetConnectionString(string ConnStr)
    {
        string rtnConnStr = "";
        try
        {
            if (ConnStr != "")
            {
                rtnConnStr = ConnStr;
            }
            else
            {
                rtnConnStr = "Data Source=" + SQLServerName() + ";Initial Catalog=" + Default_Company() + ";" + "UId=" + SQLLoginID() + ";" + "Pwd=" + SQLPW() + ";Connection Timeout=900";
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetConnectionString()");
        }
        return rtnConnStr;
    }

    public string GetConnectionString(string Catalog, string DataSource, string UId, string Pwd)
    {
        string rtnConnStr = "";
        try
        {
            rtnConnStr = "Data Source=" + DataSource + ";Initial Catalog=" + Catalog + ";" + "UId=" + UId + ";" + "Pwd=" + Pwd + ";Connection Timeout=900";
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetConnectionString(Catalog=" + Catalog + ",DataSource=" + DataSource + ",UId=" + UId + ",Pwd" + Pwd + ")");
        }
        return rtnConnStr;
    }

    public string TestConn()
    {
        string sqlabc = "";
        try
        {
            sqlabc = GetConnectionString(0, "");
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetConnectionString()");
        }
        return sqlabc;
    }

    private string GetConnectionString_ERP()
    {
        string ConStrERP = "";
        try
        {
            //' COnnection for getting the company code Dynamically
            ConStrERP = "Data Source=" + SQLServerName() + ";Initial Catalog=Focus8Erp;" + "UId=" + SQLLoginID() + ";" + "Pwd=" + SQLPW();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetConnectionString_ERP()");
        }
        return ConStrERP;
    }

    private string RegValue(RegistryHive Hive, string Key, string ValueName, string OptionalByRefErrInfo)
    {
        string sAns = null;
        try
        {
            RegistryKey objParent = default(RegistryKey);
            RegistryKey objSubkey = default(RegistryKey);

            switch (Hive)
            {
                case RegistryHive.ClassesRoot:
                    objParent = Registry.ClassesRoot;
                    break;
                case RegistryHive.CurrentConfig:
                    objParent = Registry.CurrentConfig;
                    break;
                case RegistryHive.CurrentUser:
                    objParent = Registry.CurrentUser;
                    break;
                case RegistryHive.DynData:
                    objParent = Registry.DynData;
                    break;
                case RegistryHive.LocalMachine:
                    objParent = Registry.LocalMachine;
                    break;
                case RegistryHive.PerformanceData:
                    objParent = Registry.PerformanceData;
                    break;
                case RegistryHive.Users:
                    objParent = Registry.Users;

                    break;
            }

            try
            {
                objSubkey = objParent.OpenSubKey(Key);
                //if can't be found, object is not initialized
                if ((objSubkey != null))
                {
                    sAns = Convert.ToString(objSubkey.GetValue(ValueName));
                }


            }
            catch (Exception ex)
            {
                ErrLog(ex, "RegValue-objSubkey");

            }
            finally
            {
                //if no error but value is empty, populate errinfo
                //If ErrInfo = "" And sAns = "" Then
                //    ErrInfo = _
                //       "No value found For requested registry key"
                //End If
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.RegValue(" + Hive + "," + Key + "," + ValueName + "," + OptionalByRefErrInfo + ")");
        }
        return sAns;
    }

    #endregion

    #region "Execute Query and Stored Procedure"

    public DataSet GetDataSetAPI(string strSelQry, ref string error)
    {
        DataSet returnData = new DataSet();
        try
        {

            Output output = null;
            string str = "";
            object[] objArray1 = new object[] { ExternalCallMethods.ExecuteSql, strSelQry, str };
            output = Connection.CallServeRequest(ServiceType.ExternalCall, objArray1);
            returnData = (DataSet)output.ReturnData;
            error = output.Message;

            if (error == "Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.")
            {
                EventLog(error);
                //returnData = GetDataSetByQuery(strSelQry);
                returnData = null;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataSetAPI(" + strSelQry + "  >> Error Message : " + error + " )");
        }
        return returnData;
    }

    public DataTable GetDataTableAPI(string strQry)
    {
        DataTable dt = new DataTable();
        try
        {
            EventLog("GetDataTable - IN");
            EventLog(strQry);
            DataSet ds = new DataSet();
            string error = "";
            ds = GetDataSetAPI(strQry, ref error);
            if (ds != null)
            {
                EventLog(Convert.ToString(ds.Tables.Count));
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    EventLog("DataTable Filled");
                }
                EventLog("SQL Executed Successfuly");
            }
        }
        catch (Exception ex)
        {
            EventLog(ex.ToString());
            ErrLog(ex, "DevLib.GetDataTableAPI(" + strQry + ")");
        }
        EventLog("GetDataTable - OUT");
        return dt;
    }

    public int ExecuteNonQueryAPI(string strSelQry)
    {
        int returnData = 0;
        string error = "";
        try
        {
            EventLog("ExecuteNonQuery - IN");
            EventLog(strSelQry);

            Output output = null;
            object[] objArray1 = new object[] { ExternalCallMethods.ExecuteNonQuery, strSelQry, error };
            output = Connection.CallServeRequest(ServiceType.ExternalCall, objArray1);
            returnData = (int)output.ReturnData;
            error = output.Message;
            EventLog("SQL Executed " + error);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQueryAPI(" + strSelQry + "  >> Error Message : " + error + " )");
        }
        EventLog("ExecuteNonQuery - OUT");
        return returnData;
    }


    /// <summary>
    /// Method to get DataTable from SQL Query
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for Other Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataTable</returns>
    public DataTable GetDataTableByQuery(string strQry, string ConnStr = "")
    {
        EventLog("GetDataTable - IN");
        EventLog(strQry);
        DataTable dt = new DataTable();
        EventLog(ConnStr);
        SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            EventLog("SQL Executed Successfuly");
            da.Fill(dt);
            EventLog("DataTable Fill");

            //dt = GetDataTableAPI(strQry);


        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataTableByQuery(" + strQry + ")");
        }
        finally
        {
            //con.Close();
        }
        EventLog("GetDataTable - OUT");
        return dt;

    }

    /// <summary>
    /// Method to get DataSet from SQL Query
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataSet</returns>
    public DataSet GetDataSetByQuery(string strQry, string ConnStr = "")
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {

            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            string error = "";
            //ds = GetDataSetAPI(strQry, ref error);

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataSetByQuery()");
        }
        finally
        {
            //con.Close();
        }
        return ds;

    }

    /// <summary>
    /// Method to get DataSet from SQL Query
    /// </summary>
    /// <param name="spName">SQL Procedure Name</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataSet</returns>
    public DataTable GetDataTableByStoredProcedure(string spName, string ConnStr = "")
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataTableByStoredProcedure(" + spName + ")");
        }
        finally
        {
            con.Close();
        }
        return dt;

    }

    /// <summary>
    /// Method to get DataSet from SQL Query
    /// </summary>
    /// <param name="spName">SQL Procedure Name</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataSet</returns>
    public DataTable GetDataTableByStoredProcedure(string spName, string[] Param, string[] Value, string ConnStr = "")
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);

            for (int i = 0; i < Param.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + Param[i], Value[i]);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataTableByStoredProcedure(" + spName + ")");
        }
        finally
        {
            con.Close();
        }
        return dt;

    }

    /// <summary>
    /// Return first row first cell data
    /// </summary>
    /// <param name="spName">Procedure Name</param>
    /// <param name="Param">Parameter as string array</param>
    /// <param name="Value">Value as string array</param>
    /// <param name="ConnStr">Optional connection string other then loged in session</param>
    /// <returns>Return first row first cell data</returns>
    public string GetScalarValueByStoredProcedure(string spName, string[] Param, string[] Value, string ConnStr = "")
    {
        string Result = "";
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);

            for (int i = 0; i < Param.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + Param[i], Value[i]);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Result = Convert.ToString(dt.Rows[0][0]);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetScalarValueByStoredProcedure(" + spName + ")");
        }
        finally
        {
            con.Close();
        }
        return Result;

    }

    /// <summary>
    /// Method to Execute SQL Query
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>0 or 1</returns>
    public int ExecuteNonQuery(string strQry, string ConnStr = "")
    {

        int result = 0;
        //SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            //SqlCommand cmd = new SqlCommand(strQry, con);
            //cmd.CommandTimeout = ConnTimeOut;
            //con.Open();
            //result = cmd.ExecuteNonQuery();

            string error = "";
            result = ExecuteNonQueryAPI(strQry);

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQuery(" + strQry + ")");
        }
        finally
        {
            //con.Close();
        }

        return result;
    }

    /// <summary>
    /// Method to Execute SQL Query using XML parameter
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>0 or 1</returns>
    public int ExecuteNonQueryXML(string spName, string Param, XmlNode xmlValue, string ConnStr = "")
    {

        int result = 0;
        SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);

            SqlParameter param = new SqlParameter("@" + Param, SqlDbType.Xml);
            param.Value = xmlValue.InnerXml;        //new SqlXml(xmlValue.InnerXml);
            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            result = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQueryXML()");
        }
        finally
        {
            con.Close();
        }

        return result;
    }

    /// <summary>
    /// Method to Execute SQL Query for Scalar Value
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>First Row First Column Value as String</returns>
    public string ExecuteScalar(string strQry, string ConnStr = "")
    {

        object result = "";
        //SqlConnection con = new SqlConnection(GetConnectionString(ConnStr));

        try
        {
            //SqlCommand cmd = new SqlCommand(strQry, con);
            //cmd.CommandTimeout = ConnTimeOut;
            //con.Open();
            //result = (object)cmd.ExecuteScalar();

            DataTable dt = new DataTable();
            dt = GetDataTableAPI(strQry);
            if (dt.Rows.Count > 0)
            {
                result = (object)dt.Rows[0][0];
            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQuery(" + strQry + ")");
        }
        finally
        {
            //con.Close();
        }

        return Convert.ToString(result);
    }


    #region Use For Connection TimeOut Issue

    public DataTable GetDataFromFocus(string strQry)
    {
        DataTable dt = new DataTable();
        try
        {
            EventLog("GetDataFromFocus - IN");
            EventLog(strQry);
            DataSet ds = new DataSet();
            string error = "";
            string compcode = Default_Company().Replace("Focus8", "");
            ds = GetSetFromFocus(strQry, compcode, ref error);
            if (ds != null)
            {
                EventLog(Convert.ToString(ds.Tables.Count));
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    EventLog("DataTable Filled");
                }
                EventLog("SQL Executed Successfuly");
            }
        }
        catch (Exception ex)
        {
            EventLog(ex.ToString());
            ErrLog(ex, "DevLib.GetDataFromFocus(" + strQry + ")");
        }
        EventLog("GetDataFromFocus - OUT");
        return dt;
    }

    public DataSet GetSetFromFocus(string strSelQry, string compcode, ref string error)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(getFocusConnectionString(compcode));
        try
        {
            SqlDataAdapter da = null;
            con.Open();
            SqlCommand command = new SqlCommand(strSelQry, con);
            command.CommandTimeout = 0;
            da = new SqlDataAdapter(command);
            da.Fill(ds);
        }
        catch (Exception e)
        {
            error = e.Message.ToString();
            con.Close();
        }
        finally
        {
            con.Close();
        }
        return ds;
    }

    public void GetexecuteFromFocus(string strSelQry, string compcode, ref string error)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(getFocusConnectionString(compcode));
        try
        {
            SqlDataAdapter da = null;

            con.Open();
            //SqlCommand cmd = new SqlCommand(strSelQry, con);
            //cmd.ExecuteNonQuery();
            //con.Close();

            SqlCommand command = new SqlCommand(strSelQry, con);
            command.CommandTimeout = 0;
            da = new SqlDataAdapter(command);
            da.Fill(ds);
            //return ds;
        }
        catch (Exception e)
        {
            error = e.Message.ToString();
            con.Close();
            //return ds;
        }
        finally
        {
            con.Close();
        }
    }

    public static string getFocusConnectionString(string compcode)
    {
        string pathlocation = System.AppDomain.CurrentDomain.BaseDirectory + "XMLFILES\\DBConfig.xml"; ;
        XmlDocument doc = new XmlDocument();
        doc.Load(pathlocation);
        XmlNode node = doc.DocumentElement.SelectSingleNode("Database/Data_Source");
        string strServer = node.InnerText;
        node = doc.DocumentElement.SelectSingleNode("Database/Initial_Catalog");
        string strDatabase = node.InnerText;
        strDatabase = strDatabase + compcode;

        node = doc.DocumentElement.SelectSingleNode("Database/User_Id");
        string strUserId = node.InnerText;
        node = doc.DocumentElement.SelectSingleNode("Database/Password");
        string strPassword = node.InnerText;
        return "Data Source=" + strServer + ";Initial Catalog=" + strDatabase + ";UId=" + strUserId + ";Pwd=" + strPassword + ";Connect Timeout=0;";


        //XmlDocument xmlDoc = new XmlDocument();
        //string strFileName = "";
        //strFileName = System.AppDomain.CurrentDomain.BaseDirectory + "XMLFILES\\DBConfig.xml";

    }


    public String getCompanyCode(int value)
    {
        char[] base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        String returnValue = "";
        while (value != 0)
        {
            returnValue = base36Chars[value % 36] + returnValue;
            value /= 36;
        }
        return (returnValue.Trim().Length == 2 ? "0" + returnValue : returnValue);
    }

    #endregion


    #region OldCode


    /*
    /// <summary>
    /// Method to get DataTable from SQL Query
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for Other Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataTable</returns>
    public DataTable GetDataTableByQuery(string strQry, int ExtConn = 0, string xConnString = "")
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {
            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataTableByQuery(" + strQry + ")");
        }
        finally
        {
            con.Close();
        }
        return dt;

    }

    /// <summary>
    /// Method to get DataSet from SQL Query
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataSet</returns>
    public DataSet GetDataSetByQuery(string strQry, int ExtConn = 0, string xConnString = "")
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {

            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataSetByQuery()");
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    /// <summary>
    /// Method to get DataSet from SQL Query
    /// </summary>
    /// <param name="spName">SQL Procedure Name</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataSet</returns>
    public DataTable GetDataTableByStoredProcedure(string spName, int ExtConn = 0, string xConnString = "")
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataTableByStoredProcedure(" + spName + ")");
        }
        finally
        {
            con.Close();
        }
        return dt;

    }

    /// <summary>
    /// Method to get DataSet from SQL Query
    /// </summary>
    /// <param name="spName">SQL Procedure Name</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>Return DataSet</returns>
    public DataTable GetDataTableByStoredProcedure(string spName, string[] Param, string[] Value, int ExtConn = 0, string xConnString = "")
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);

            for (int i = 0; i < Param.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + Param[i], Value[i]);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetDataTableByStoredProcedure(" + spName + ")");
        }
        finally
        {
            con.Close();
        }
        return dt;

    }

    /// <summary>
    /// Method to Execute SQL Query
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>0 or 1</returns>
    public int ExecuteNonQuery(string strQry, int ExtConn = 0, string xConnString = "")
    {

        int result = 0;
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {
            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            result = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQuery(" + strQry + ")");
        }
        finally
        {
            con.Close();
        }

        return result;
    }

    /// <summary>
    /// Method to Execute SQL Query using XML parameter
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>0 or 1</returns>
    public int ExecuteNonQueryXML(string spName, string Param, XmlNode xmlValue, int ExtConn = 0, string xConnString = "")
    {

        int result = 0;
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {
            SqlCommand cmd = new SqlCommand(spName, con);

            SqlParameter param = new SqlParameter("@" + Param, SqlDbType.Xml);
            param.Value = xmlValue.InnerXml;        //new SqlXml(xmlValue.InnerXml);
            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            result = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQueryXML()");
        }
        finally
        {
            con.Close();
        }

        return result;
    }

    /// <summary>
    /// Method to Execute SQL Query for Scalar Value
    /// </summary>
    /// <param name="strQry">SQL Query</param>
    /// <param name="ExtConn">Optional Parameter Default Value = 0 for Focus8 Connection and Value = 1 for External Database Connection</param>
    /// <param name="xConnString">if ExtConn = 1 then pass Other Database Connection as (Data Source=SQL_SERVER_NAME;Initial Catalog=DATABASE_NAME;UId=SQL_USER_NAME;Pwd=SQL_PASSWORD;) </param>
    /// <returns>First Row First Column Value as String</returns>
    public string ExecuteScalar(string strQry, int ExtConn = 0, string xConnString = "")
    {

        object result = "";
        SqlConnection con = new SqlConnection(GetConnectionString(ExtConn, xConnString));

        try
        {
            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            result = (object)cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ExecuteNonQuery(" + strQry + ")");
        }
        finally
        {
            con.Close();
        }

        return Convert.ToString(result);
    }


    */

    #endregion

    public int InsertIntoTable(string TableName, string[] Columns, string[] Values, string ConnStr = "")
    {
        int result = 0;
        try
        {
            if (Columns.Length == Values.Length)
            {
                string strSQL = "";
                string strCol = "";
                string strVal = "";

                if (Columns.Length > 0)
                {
                    for (int i = 0; i < Columns.Length; i++)
                    {
                        if (i > 0)
                        {
                            strCol = strCol + "," + Convert.ToString(Columns[i]);
                            strVal = strVal + ",'" + Convert.ToString(Values[i]) + "'";
                        }
                        else
                        {
                            strCol = Convert.ToString(Columns[i]);
                            strVal = "'" + Convert.ToString(Values[i]) + "'";
                        }
                    }
                }

                strSQL = "Insert Into " + TableName + " (" + strCol + ") Values (" + strVal + ")";

                result = ExecuteNonQuery(strSQL, ConnStr);
            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "InsertIntoTable(TableName=" + TableName + ", Columns.Length=" + Columns.Length + ", Values.Length=" + Values.Length + ")");
        }

        return result;
    }

    public int InsertIntoTableGetScopeIdentity(string TableName, string[] Columns, string[] Values, string ConnStr = "")
    {
        int result = 0;
        try
        {
            if (Columns.Length == Values.Length)
            {
                string strSQL = "";
                string strCol = "";
                string strVal = "";

                if (Columns.Length > 0)
                {
                    for (int i = 0; i < Columns.Length; i++)
                    {
                        if (i > 0)
                        {
                            strCol = strCol + "," + Convert.ToString(Columns[i]);
                            strVal = strVal + ",'" + Convert.ToString(Values[i]) + "'";
                        }
                        else
                        {
                            strCol = Convert.ToString(Columns[i]);
                            strVal = "'" + Convert.ToString(Values[i]) + "'";
                        }
                    }
                }

                strSQL = "Insert Into " + TableName + " (" + strCol + ") Values (" + strVal + ")  SELECT SCOPE_IDENTITY()";

                DataTable dt = new DataTable();
                dt = GetDataTableByQuery(strSQL, ConnStr);
                if (dt.Rows.Count > 0)
                {
                    result = Convert.ToInt32(dt.Rows[0][0]);
                }
            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "InsertIntoTable(TableName=" + TableName + ", Columns.Length=" + Columns.Length + ", Values.Length=" + Values.Length + ")");
        }

        return result;
    }

    public int UpdateTable(string TableName, string[] Columns, string[] Values, string[] CondCol, string[] Cond, string[] CondVal, string ConnStr = "")
    {
        int result = 0;
        try
        {
            if (Columns.Length == Values.Length && CondCol.Length == CondVal.Length && CondCol.Length == Cond.Length)
            {
                string strSQL = "";
                string strSet = "";
                string strCond = " 1 = 1 ";

                if (Columns.Length > 0)
                {
                    for (int i = 0; i < Columns.Length; i++)
                    {
                        if (i > 0)
                        {
                            strSet = strSet + " , " + Convert.ToString(Columns[i]) + " = '" + Convert.ToString(Values[i]) + "'";
                        }
                        else
                        {
                            strSet = " " + Convert.ToString(Columns[i]) + " = '" + Convert.ToString(Values[i]) + "'";
                        }
                    }

                    for (int i = 0; i < CondVal.Length; i++)
                    {
                        strCond = strCond + " " + Convert.ToString(Cond[i]) + "  " + Convert.ToString(CondCol[i]) + " = '" + Convert.ToString(CondVal[i]) + "'";
                    }
                }

                strSQL = " Update " + TableName + " Set " + strSet + " Where " + strCond + " ";

                result = ExecuteNonQuery(strSQL, ConnStr);
            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "InsertIntoTable(TableName=" + TableName + ", Columns.Length=" + Columns.Length + ", Values.Length=" + Values.Length + ", CondCol.Length=" + CondCol.Length + ", Cond.Length=" + Cond.Length + ", CondVal.Length=" + CondVal.Length + ")");
        }

        return result;
    }

    public int DeleteFromTable(string TableName, string[] CondCol, string[] Cond, string[] CondVal, string ConnStr = "")
    {
        int result = 0;
        try
        {
            if (CondCol.Length == CondVal.Length && CondCol.Length == Cond.Length)
            {
                string strSQL = "";
                string strCond = " 1 = 1 ";

                if (CondCol.Length > 0)
                {
                    for (int i = 0; i < CondVal.Length; i++)
                    {
                        strCond = strCond + " " + Convert.ToString(Cond[i]) + "  " + Convert.ToString(CondCol[i]) + " = '" + Convert.ToString(CondVal[i]) + "'";
                    }
                }

                strSQL = " Delete From " + TableName + " Where " + strCond + " ";

                result = ExecuteNonQuery(strSQL, ConnStr);
            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "InsertIntoTable(TableName=" + TableName + ", CondCol.Length=" + CondCol.Length + ", = " + ", Cond.Length=" + Cond.Length + ", CondVal.Length=" + CondVal.Length + ")");
        }

        return result;
    }

    public string GetExternalSettingValue(int MasterId)
    {

        object result = "";
        string strQry = "Select sValue From xcCore_ExternalSetting Where iMasterId = " + Convert.ToString(MasterId);
        SqlConnection con = new SqlConnection(GetConnectionString(0, ""));

        try
        {
            SqlCommand cmd = new SqlCommand(strQry, con);
            cmd.CommandTimeout = ConnTimeOut;
            con.Open();
            result = (object)cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExternalSettingValue(" + strQry + ")");
        }
        finally
        {
            con.Close();
        }

        return Convert.ToString(result);
    }

    #endregion

    #region .Net Controls


    public class ComboBoxItem
    {
        public string Value;
        public string Text;

        public ComboBoxItem(string val, string text)
        {
            Value = val;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    /// <summary>
    /// Hide number of column(s) specified from right to left
    /// </summary>
    public void HideGVLastColumns(DataGridView GV, int NoOfCol)
    {
        try
        {
            if (GV.Columns.Count >= NoOfCol)
            {
                int ColNo;

                for (int i = 0; i < NoOfCol; i++)
                {
                    ColNo = GV.Columns.Count - i;
                    GV.Columns[ColNo - 1].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.HideGVLastColumns()");
        }
    }

    /// <summary>
    /// Make specified columns "Invisiable"
    /// </summary>
    public void HideGVLastColumns(DataGridView GV, int[] ColNo)
    {
        try
        {
            if (GV.Columns.Count > 0)
            {

                for (int i = 0; i <= GV.Columns.Count - 1; i++)
                {
                    if (Array.IndexOf(ColNo, (i)) != -1)
                    {
                        GV.Columns[i].Visible = false;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.HideGVLastColumns()");
        }
    }

    /// <summary>
    /// Make all columns "ReadOnly" accept specified column
    /// </summary>
    public void ReadOnlyGVColumns(DataGridView GV, int[] ColNo)
    {
        try
        {
            if (GV.Columns.Count > 0)
            {

                for (int i = 0; i <= GV.Columns.Count - 1; i++)
                {
                    if (Array.IndexOf(ColNo, (i)) == -1)
                    {
                        GV.Columns[i].ReadOnly = true;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.HideGVLastColumns()");
        }
    }

    public void GVRowNo(DataGridView GV)
    {
        try
        {
            for (int i = 0; i < GV.Rows.Count; i++)
            {
                GV.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GVRowNo()");
        }
    }


    /// <summary>
    /// <para>Use to set tabs on KeyDown or PreviewKeyDown event</para>
    /// </summary>
    /// <param name="KeyCode">e.KeyCode</param>
    /// <param name="CurrentControl">sender</param>
    /// <param name="NextControl">Next Control Name</param>
    /// <param name="PrevControl">Prev Control Name</param>
    /// <remarks>Next Control -- Right Arrow / Enter and Prev Control -- Left Arrow</remarks>
    public void EvenForTab(Keys KeyCode, object CurrentControl, object NextControl, object PrevControl)
    {
        try
        {
            if (CurrentControl != null)
            {
                string CurCtr = CurrentControl.GetType().Name;

                if (CurCtr == "TextBox" || CurCtr == "DateTimePicker")
                {
                    if (KeyCode == Keys.Enter)
                    {
                        TabFocus(NextControl);
                    }
                    else if (KeyCode == Keys.Left)
                    {
                        TabFocus(PrevControl);
                    }
                }
                if (CurCtr == "Button")
                {
                    if (KeyCode == Keys.Right)
                    {
                        TabFocus(NextControl);
                    }
                    else if (KeyCode == Keys.Left)
                    {
                        TabFocus(PrevControl);
                    }
                }
                else
                {
                    if (KeyCode == Keys.Right || KeyCode == Keys.Enter)
                    {
                        TabFocus(NextControl);
                    }
                    else if (KeyCode == Keys.Left)
                    {
                        TabFocus(PrevControl);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.EvenForTab()");
        }
    }
    private void TabFocus(object FocusControl)
    {
        try
        {
            if (FocusControl != null)
            {
                string Ctrl = FocusControl.GetType().Name;
                switch (Ctrl)
                {
                    case "Button":
                        ((Button)FocusControl).Focus();
                        break;
                    case "TextBox":
                        ((TextBox)FocusControl).Focus();
                        break;
                    case "ComboBox":
                        ((ComboBox)FocusControl).Focus();
                        break;
                    case "DateTimePicker":
                        ((DateTimePicker)FocusControl).Focus();
                        break;
                    case "RadioButton":
                        ((RadioButton)FocusControl).Focus();
                        break;
                    case "DataGridView":
                        ((DataGridView)FocusControl).Focus();
                        break;
                    case "CheckBox":
                        ((CheckBox)FocusControl).Focus();
                        break;

                        //default:
                        //    Console.WriteLine("Default case");
                        //    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.TabFocus()");
        }
    }


    public void OnEnterExpandDropdown(object sender, EventArgs e)
    {
        try
        {
            (sender as ComboBox).DroppedDown = true;
            (sender as ComboBox).AutoCompleteMode = AutoCompleteMode.Suggest;
            (sender as ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.combo_Enter()");
        }

    }

    public void ComboBoxProperties(ComboBox CBX)
    {
        try
        {
            CBX.DropDownStyle = ComboBoxStyle.DropDown;
            CBX.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CBX.AutoCompleteSource = AutoCompleteSource.ListItems;
            CBX.FlatStyle = FlatStyle.System;
            CBX.FormattingEnabled = true;
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ComboBoxProperties()");
        }
    }

    public void LoadComboBox(ComboBox CXB, int MasterTypeId, int DisplayColID, int MasterTableId = 0)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt_Mst = new DataTable();
            string strSQL = "";
            if (MasterTableId != 0)
            {
                dt_Mst = GetDataTableByQuery("Select md.DisplayName as DisplayCol, m.TableName as TableName  From xt_MasterTable m inner join xt_MasterTable_Display md on m.MasterTableID= md.MasterTableID and m.MasterTableID  = " + Convert.ToString(MasterTableId) + " and md.F2ID = " + Convert.ToString(DisplayColID), "");
            }
            else
            {
                dt_Mst = GetDataTableByQuery("Select md.DisplayName as DisplayCol, m.TableName as TableName  From xt_MasterTable m inner join xt_MasterTable_Display md on m.MasterTableID= md.MasterTableID and m.iMasterTypeID= " + Convert.ToString(MasterTypeId) + " and md.F2ID = " + Convert.ToString(DisplayColID), "");
            }
            if (dt_Mst.Rows.Count > 0)
            {
                strSQL = "Select a.iMasterId as ID, " + Convert.ToString(dt_Mst.Rows[0]["DisplayCol"]) + " as Name From " + Convert.ToString(dt_Mst.Rows[0]["TableName"]);

                dt = GetDataTableByQuery(strSQL, "");

                if (dt.Rows.Count > 0)
                {
                    CXB.ValueMember = "ID";
                    CXB.DisplayMember = "Name";
                    CXB.DataSource = dt;
                }
            }
            else
            {
                CXB.DataSource = null;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.LoadComboBox()");
        }

    }

    public int LoadComboBox(ComboBox CXB, int MasterTypeId, int DisplayColID, Keys KeyCode, int MasterTableId = 0)
    {
        try
        {
            if (KeyCode == Keys.F2)
            {
                DataTable dt = new DataTable();
                if (MasterTableId != 0)
                {
                    dt = GetDataTableByQuery("Select F2ID From xt_MasterTable m inner join xt_MasterTable_Display md on m.MasterTableID= md.MasterTableID and m.MasterTableID = " + Convert.ToString(MasterTableId) + " and md.F2ID = " + Convert.ToString(DisplayColID + 1), "");
                }
                else
                {
                    dt = GetDataTableByQuery("Select F2ID From xt_MasterTable m inner join xt_MasterTable_Display md on m.MasterTableID= md.MasterTableID and m.iMasterTypeID = " + Convert.ToString(MasterTypeId) + " and md.F2ID = " + Convert.ToString(DisplayColID + 1), "");
                }
                if (dt.Rows.Count > 0)
                {
                    DisplayColID = Convert.ToInt32(dt.Rows[0]["F2ID"]);
                }
                else
                {
                    DisplayColID = 0;
                }

                LoadComboBox(CXB, MasterTypeId, DisplayColID, MasterTableId);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.LoadComboBox()");
        }

        return DisplayColID;
    }



    public int MasterSearch(int MasterTypeID, int SelectedValue)
    {
        try
        {
            //MasterSearch f = new MasterSearch();
            //f.lblMasterTypeId.Text = Convert.ToString(MasterTypeID);
            //f.lblReturnID.Text = Convert.ToString(SelectedValue);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    SelectedValue = Convert.ToInt32(f.lblReturnID.Text);
            //}
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.MasterSearch()");
        }
        return SelectedValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="CBX">ComboBox Name</param>
    /// <param name="MasterName">
    /// mCore_JobNumber = "JobNo", 
    /// mPay_Employee = "Employee", 
    /// mCore_JobStatus = "JobStatus", 
    /// mCore_Product = "Product", 
    /// mCore_ProductionDepartment = "ProductionDepartment", 
    /// mPos_Outlet = "Outlet"
    /// </param>
    public void LoadSearchComboBox(ComboBox CBX, string MasterName)
    {
        try
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            if (MasterName == "JobNo")
            {
                strSQL = "Select iMasterId as ID, sName as Name From mCore_JobNumber Where iStatus <> 5 and iMasterId > 0 Union Select 0 as ID, '' as Name  Order BY Name";
            }
            else if (MasterName == "Employee")
            {
                strSQL = "Select iMasterId as ID, sName as Name From mPay_Employee Where iStatus <> 5 and iMasterId > 0 Union Select 0 as ID, '' as Name  Order BY Name";
            }
            else if (MasterName == "JobStatus")
            {
                strSQL = "Select iMasterId as ID, sName as Name From mCore_JobStatus Where iMasterId in (Select sValue From xcCore_ExternalSetting ) and iStatus <> 5 and iMasterId > 0 Union Select 0 as ID, '' as Name  Order BY Name";
            }
            else if (MasterName == "Product")
            {
                strSQL = "Select iMasterId as ID, sCode + ' [' + sName + ']' as Name From mCore_Product Where iStatus <> 5 and iMasterId > 0 Union Select 0 as ID, '' as Name  Order BY Name";
            }
            else if (MasterName == "ProductionDepartment")
            {
                strSQL = "Select iMasterId as ID, sName as Name From mCore_ProductionDepartment Where iStatus <> 5 and iMasterId > 0 Union Select 0 as ID, '' as Name  Order BY Name";
            }
            else if (MasterName == "Outlet")
            {
                strSQL = "Select iMasterId as ID, sCode + ' [' + sName + ']' as Name From mPos_Outlet Where iStatus <> 5 and iMasterId > 0 Union Select 0 as ID, '' as Name  Order BY Name";
            }

            dt = GetDataTableAPI(strSQL);

            if (dt.Rows.Count > 0)
            {
                CBX.ValueMember = "ID";
                CBX.DisplayMember = "Name";
                CBX.DataSource = dt;
            }
            else
            {
                CBX.DataSource = null;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.LoadJobNo()");
        }
    }

    #endregion

    #region Common


    #endregion

    #region Validations

    /// <summary>
    /// Expire date validation
    /// </summary>
    /// <param name="ExpDt">yyyyMMdd</param>
    /// <returns>Returns false if current date is greater then ExpDt </returns>
    public bool ContactAdmin(object ObjControl, int ExpDt)
    {
        bool flg = true;
        try
        {
            if (Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) > ExpDt)
            {
                flg = false;
                Form frm = ((Form)ObjControl);
                MsgBox(999);
                frm.Close();
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ContactAdmin()");
        }
        return flg;
    }

    //public bool IsInteger(KeyPressEventArgs e)
    //{
    //    bool Handled = true;
    //    try
    //    {
    //        if ((e.KeyChar) == 8 || (e.KeyChar) == 13 || (e.KeyChar) == 9)
    //            Handled = false;
    //        else if ((e.KeyChar) >= 48 && (e.KeyChar) <= 57)
    //            Handled = false;
    //        else
    //            MessageBox.Show("Invalid Number", "Information", MessageBoxButtons.OK);
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrLog(ex, "IsInteger()");
    //    }
    //    return Handled;

    //}
    public bool IsInteger(Keys KeyCode)
    {
        KeysConverter kc = new KeysConverter();
        string key = kc.ConvertToString(KeyCode);

        return ValidateIntegerValue(key);
    }
    public bool IsInteger(char KeyChar)
    {

        return ValidateIntegerValue(Convert.ToString(KeyChar));
    }


    private bool ValidateIntegerValue(string key)
    {
        bool Handled = true;
        try
        {
            char e = Convert.ToChar(key);

            if (e == 8 || e == 13 || e == 9)
                Handled = false;
            else if (e >= 48 && e <= 57)
                Handled = false;
            else
                MessageBox.Show("Invalid Number", "Information", MessageBoxButtons.OK);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "IsInteger()");
        }
        return Handled;

    }


    /// <summary>
    /// This function validate and returns a bool value
    /// </summary>
    /// <param name="value">string value to Validate</param>
    /// <param name="Type"> "i" for Integer / d for Decimal</param>
    /// <returns>bool</returns>
    public bool ValidateString(string value, char Type)
    {
        bool Handled = true;
        try
        {
            switch (Type)
            {
                case 'i':
                    {
                        int result;
                        Handled = (int.TryParse(value, out result));
                        break;
                    }

                case 'd':
                    {
                        decimal result;
                        Handled = (decimal.TryParse(value, out result));
                        break;
                    }
                case 't':
                    {
                        DateTime result;
                        Handled = (DateTime.TryParse(value, out result));
                        break;
                    }

                default:
                    break;
            }

            if (Handled == false)
            {
                MessageBox.Show("Invalid value", "Information", MessageBoxButtons.OK);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "ValidateString()");
        }
        return Handled;

    }

    public bool ValidateComboBox(ComboBox CXB, string TableName, string LabelText)
    {
        bool flg = false;
        try
        {
            string MasterID = ExecuteScalar("Select iMasterId From " + TableName + " Where iMasterId = " + Convert.ToString(CXB.SelectedValue), "");
            if (MasterID != "")
            {
                if (Convert.ToInt32(MasterID) > 0)
                {
                    flg = true;
                }
            }

            if (!flg)
            {
                MessageBox.Show("Invalid " + LabelText, "Information", MessageBoxButtons.OK);
                CXB.Focus();
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ValidateComboBox()");
        }
        return flg;
    }

    #endregion

    #region Security
    public int LoggedInUserId = Convert.ToInt32(System.Windows.Application.Current.Properties["UserId"]);
    public string LoggedInUserName = Convert.ToString(System.Windows.Application.Current.Properties["UserName"]);

    #endregion

    #region Focus Development
    public string GetNextVoucherNo(int VoucherType)
    {
        string DocumentNo = "";
        try
        {
            SeriesValues objSeriesVals = new SeriesValues();
            Output objReturnDoc = Connection.CallServeRequest(ServiceType.Transaction, TransMethods.GetNewVoucherNo, VoucherType, objSeriesVals);
            if (objReturnDoc.ReturnData != null && Convert.ToString(objReturnDoc.ReturnData) != "Object reference not set to an instance of an object.")
            {
                DocumentNo = objReturnDoc.ReturnData.ToString();
            }
            else
            {
                DocumentNo = "1";
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetNextVoucherNo(VoucherType=" + Convert.ToString(VoucherType) + ")");
        }

        return DocumentNo;

    }

    public string GetNextVoucherNoTagWise(int VoucherType, string TagCode, string Seprator)
    {
        string DocumentNo = "1";
        try
        {
            string DocNo = ExecuteScalar("Select  Replace(sVoucherNo,'" + TagCode + Seprator + "','') as VoucherNo From tCore_Header_0 Where iVoucherType = " + Convert.ToString(VoucherType) + " and sVoucherNo like '" + TagCode + Seprator + "%' Order BY  Cast(Replace(sVoucherNo,'" + TagCode + Seprator + "','') as int) Desc", "");
            if (DocNo != "")
            {
                DocNo = Regex.Replace(DocNo, "[A-Za-z-]", "");
                DocNo = Regex.Replace(DocNo, "/", "");
                if (ValidateString(DocNo, 'i'))
                {
                    DocumentNo = Convert.ToString(Convert.ToInt32(DocNo) + 1);
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetNextVoucherNoOutletWise(string TagCode)");
        }
        return TagCode + Seprator + DocumentNo;
    }

    public string GetNextVoucherNoTagWise(int VoucherType, string TagCode, string Seprator1, string Seprator2)
    {
        string DocumentNo = "1";
        try
        {
            string DocNo = ExecuteScalar("Select REPLACE(Replace(sVoucherNo, '" + TagCode + Seprator1 + "', ''), SUBSTRING(Replace(sVoucherNo, '" + TagCode + Seprator1 + "', ''), CHARINDEX('" + Seprator2 + "', Replace(sVoucherNo, '" + TagCode + Seprator1 + "', ''), 0), Len(sVoucherNo)), '') as VoucherNo From tCore_Header_0 Where iVoucherType = " + Convert.ToString(VoucherType) + " and sVoucherNo like '" + TagCode + Seprator1 + "%' Order BY Cast(Replace(sVoucherNo,'" + TagCode + Seprator1 + "','') as int) Desc", "");
            if (DocNo != "")
            {
                DocNo = Regex.Replace(DocNo, "[A-Za-z-]", "");
                DocNo = Regex.Replace(DocNo, "/", "");
                if (ValidateString(DocNo, 'i'))
                {
                    DocumentNo = Convert.ToString(Convert.ToInt32(DocNo) + 1);
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetNextVoucherNoOutletWise(string TagCode)");
        }
        return TagCode + Seprator1 + DocumentNo;
    }


    public bool IsVoucherNoExist(int VoucherType, string DocumentNo)
    {
        bool Flag = false;
        try
        {
            string SQL = "Select Count(1) [VocCount] From tCore_Header_0 Where iVoucherType = " + Convert.ToString(VoucherType) + " and sVoucherNo = '" + DocumentNo + "'";
            DataTable dt = new DataTable();
            dt = GetDataTableAPI(SQL);
            if (Convert.ToInt32(dt.Rows[0]["VocCount"]) > 0)
            {
                Flag = true;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.IsVoucherNoExist(string TagCode)");
        }

        return Flag;
    }


    public int TimeToInt(string Time)
    {
        int result = 0;
        try
        {
            Time = ExecuteScalar("Select dbo.fCore_TimeToInt('" + Time + "') as t", "");
            result = Convert.ToInt32(Time);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.TimeToInt();");
        }
        return result;
    }

    /// <summary>
    /// Focus Int to Date
    /// </summary>
    /// <param name="Date"></param>
    /// <returns>Date</returns>
    public DateTime FocusIntToDate(int Date)
    {
        DateTime result = Convert.ToDateTime("1900-01-01");
        try
        {
            string var;
            var = ExecuteScalar("Select dbo.IntToDate(" + Convert.ToString(Date) + ")", "");
            result = Convert.ToDateTime(var);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.TimeToInt();");
        }
        return result;
    }

    /// <summary>
    /// Focus Date to Int
    /// </summary>
    /// <param name="Date" description="string format 'yyyy-MM-dd'"></param>
    /// <returns></returns>
    public int FocusDateToInt(string Date)
    {
        int result = 0;
        try
        {
            string var;
            var = ExecuteScalar("Select dbo.DateToInt('" + Convert.ToString(Date) + "')", "");
            result = Convert.ToInt32(var);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.FocusDateToInt();");
        }
        return result;
    }

    public DateTime FocusIntToTime(int Time)
    {
        DateTime result = Convert.ToDateTime("1900-01-01");
        try
        {
            string var;
            var = ExecuteScalar("Select dbo.fCore_IntToTime(" + Convert.ToString(Time) + ")", "");
            result = DateTime.ParseExact(var, "HH:mm:ss", CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.TimeToInt();");
        }
        return result;
    }

    /// <summary>
    /// Focus BigInt to Date
    /// </summary>
    /// <param name="Date"></param>
    /// <returns>Date</returns>
    public DateTime FocusBigIntToDate(int Date)
    {
        DateTime result = Convert.ToDateTime("1900-01-01");
        try
        {
            string var;
            var = ExecuteScalar("Select dbo.fCore_IntToDateTime(" + Convert.ToString(Date) + ")", "");
            result = Convert.ToDateTime(var);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.TimeToInt();");
        }
        return result;
    }

    /// <summary>
    /// Focus Date to BigInt
    /// </summary>
    /// <param name="Date" description="string format 'yyyy-MM-dd'"></param>
    /// <returns></returns>
    public int FocusDateToBigInt(string Date)
    {
        int result = 0;
        try
        {
            string var;
            var = ExecuteScalar("Select dbo.fCore_DateTimeToInt('" + Convert.ToString(Date) + "')", "");
            result = Convert.ToInt32(var);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.FocusDateToInt();");
        }
        return result;
    }

    /// <summary>
    /// Get Company Account Date
    /// </summary>
    /// <returns>DateTime</returns>
    public DateTime GetAccountingDate()
    {
        DateTime result = DateTime.Now;
        try
        {
            string var;
            var = ExecuteScalar("Select Top (1) dbo.IntToDate(iAccountingDate) From tCore_Company_Details", "");
            if (var != "")
            {
                result = Convert.ToDateTime(var);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.FocusDateToInt();");
        }
        return result;
    }


    /// <summary>
    /// Get Company Account Date
    /// </summary>
    /// <returns>Integer</returns>
    public int GetAccountingDate_Int()
    {
        int result = 0;
        try
        {
            string var;
            var = ExecuteScalar("Select Top (1) iAccountingDate From tCore_Company_Details", "");
            if (var != "")
            {
                result = Convert.ToInt32(var);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.FocusDateToInt();");
        }
        return result;
    }

    public DateTime GetLastDayOfMonth(DateTime dtp)
    {
        DateTime dDate = new DateTime();
        try
        {
            dDate = new DateTime(dtp.Year, dtp.Month, 1);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetLastDayOfMonth()");
        }
        return (dDate.AddMonths(1).AddDays(-1));
    }
    public DateTime GetLastDayOfMonth(int dtp)
    {
        DateTime dDate = new DateTime();
        try
        {
            dDate = new DateTime(FocusIntToDate(dtp).Year, FocusIntToDate(dtp).Month, 1);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetLastDayOfMonth()");
        }
        return (dDate.AddMonths(1).AddDays(-1));
    }

    public DateTime GetFirstDayOfMonth(DateTime dtp)
    {
        DateTime dDate = new DateTime();
        try
        {
            dDate = new DateTime(dtp.Year, dtp.Month, 1);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetLastDayOfMonth()");
        }
        return dDate;
    }
    public DateTime GetFirstDayOfMonth(int dtp)
    {
        DateTime dDate = new DateTime();
        try
        {
            dDate = new DateTime(FocusIntToDate(dtp).Year, FocusIntToDate(dtp).Month, 1);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetLastDayOfMonth()");
        }
        return dDate;
    }

    public int GetNoOfMonth(DateTime Date1, DateTime Date2)
    {
        int Result = 0;
        try
        {
            Result = ((Date2.Year - Date1.Year) * 12) + Date2.Month - Date1.Month + 1;
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetNoOfMonth();");
            Result = 0;
        }
        finally
        { }
        return Result;
    }

    /// <summary>
    /// GetTagPosition
    /// </summary>
    /// <param name="iMastertypeId">cCore_MasterDef</param>
    /// <param name="BodyExtra">objTrans.BodyData[0].BodyExtra</param>
    /// <returns></returns>
    public int GetTagPosition(int iMastertypeId, IdNamePair[] BodyExtra)
    {
        int TagPosition = 0;
        try
        {
            for (int i = 0; i < BodyExtra.Length; i++)
            {
                if (BodyExtra[i].ID == iMastertypeId)
                {
                    TagPosition = i;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetTagPosition()");
        }
        return TagPosition;
    }

    /// <summary>
    /// GetExtraFieldPositionBody
    /// </summary>
    /// <param name="iFieldId">cCore_VoucherFields_0</param>
    /// <param name="BodyExtra">objTrans.BodyData[0].BodyExtra</param>
    /// <returns></returns>
    public int GetExtraFieldPositionBody(int iFieldId, IdNamePair[] BodyExtra)
    {
        int Position = 0;
        try
        {
            for (int i = 0; i < BodyExtra.Length; i++)
            {
                if (BodyExtra[i].ID == iFieldId + Convert.ToInt32(VTFIELDFLAG.LAY_BODY))
                {
                    Position = i;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldPositionBody()");
        }
        return Position;
    }

    /// <summary>
    /// GetExtraFieldPositionBody
    /// </summary>
    /// <param name="Name">Field Caption(objTrans.BodyData[0].BodyExtra[0].Name)</param>
    /// <param name="BodyExtra">objTrans.BodyData[0].BodyExtra</param>
    /// <returns></returns>
    public int GetExtraFieldPositionBody(string Name, IdNamePair[] BodyExtra)
    {
        int Position = 0;
        try
        {
            for (int i = 0; i < BodyExtra.Length; i++)
            {
                if (BodyExtra[i].Name == Name)
                {
                    Position = i;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldPositionBody()");
        }
        return Position;
    }



    /// <summary>
    /// GetExtraFieldPositionHeader
    /// </summary>
    /// <param name="iFieldId">cCore_VoucherFields_0</param>
    /// <param name="HeaderExtra">objTrans.BodyData[0].BodyExtra</param>
    /// <returns></returns>
    public int GetExtraFieldPositionHeader(int iFieldId, IdNamePair[] HeaderExtra)
    {
        int Position = 0;
        try
        {
            for (int i = 0; i < HeaderExtra.Length; i++)
            {
                if (HeaderExtra[i].ID == iFieldId + Convert.ToInt32(VTFIELDFLAG.LAY_HDR))
                {
                    Position = i;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldPositionHeader()");
        }
        return Position;
    }

    /// <summary>
    /// GetExtraFieldPositionHeader
    /// </summary>
    /// <param name="Name">Field Caption(objTrans.HeaderExtra[0].Name)</param>
    /// <param name="HeaderExtra">objTrans.BodyData[0].BodyExtra</param>
    /// <returns></returns>
    public int GetExtraFieldPositionHeader(string Name, IdNamePair[] HeaderExtra)
    {
        int Position = 0;
        try
        {
            for (int i = 0; i < HeaderExtra.Length; i++)
            {
                if (HeaderExtra[i].Name == Name)
                {
                    Position = i;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldPositionHeader()");
        }
        return Position;
    }

    public object GetExtraFieldValueHeader(int iFieldId, IdNamePair[] HeaderExtra)
    {
        object TagValue = 0;
        try
        {
            int Position = GetExtraFieldPositionHeader(iFieldId, HeaderExtra);
            TagValue = HeaderExtra[Position].Tag;
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldValueHeader()");
        }
        return TagValue;
    }

    public object GetExtraFieldValueHeader(string Name, IdNamePair[] HeaderExtra)
    {
        object TagValue = 0;
        try
        {
            int Position = GetExtraFieldPositionHeader(Name, HeaderExtra);
            TagValue = HeaderExtra[Position].Tag;
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldValueHeader()");
        }
        return TagValue;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="iMastertypeId">cCore_MasterDef</param>
    /// <param name="BodyData">objTrans.BodyData</param>
    /// <param name="RowIndex">RowIndex</param>
    /// <returns></returns>
    public int GetTagValue(int iMastertypeId, TransBody[] BodyData, int RowIndex)
    {
        int TagValue = 0;

        try
        {
            int TagPosition = GetTagPosition(iMastertypeId, BodyData[RowIndex].Tags);
            TagValue = Convert.ToInt32(BodyData[RowIndex].Tags[TagPosition].Tag);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetTagValue()");
        }
        return TagValue;
    }

    /// <summary>
    /// GetExtraFieldValueBody
    /// </summary>
    /// <param name="iFieldId">cCore_VoucherFields_0</param>
    /// <param name="BodyData">objTrans.BodyData</param>
    /// <param name="RowIndex">RowIndex</param>
    /// <returns></returns>
    public object GetExtraFieldValueBody(int iFieldId, TransBody[] BodyData, int RowIndex)
    {
        object TagValue = 0;

        try
        {
            int Position = GetExtraFieldPositionBody(iFieldId, BodyData[RowIndex].BodyExtra);
            TagValue = BodyData[RowIndex].BodyExtra[Position].Tag;
        }
        catch (Exception ex)
        {
            TagValue = 0;
            ErrLog(ex, "DevLib.GetExtraFieldValueBody()");
        }
        return TagValue;
    }

    /// <summary>
    /// SetExtraFieldValueBody
    /// </summary>
    /// <param name="iFieldId">cCore_VoucherFields_0</param>
    /// <param name="BodyData">objTrans.BodyData</param>
    /// <param name="RowIndex">RowIndex</param>
    /// <param name="Value">Value</param>
    /// <returns></returns>
    public bool SetExtraFieldValueBody(int iFieldId, TransBody[] BodyData, int RowIndex, object Value)
    {
        bool rtnFlg = true;

        try
        {
            int Position = GetExtraFieldPositionBody(iFieldId, BodyData[RowIndex].BodyExtra);
            BodyData[RowIndex].BodyExtra[Position].Tag = Value;
        }
        catch (Exception ex)
        {
            rtnFlg = false;
            ErrLog(ex, "DevLib.SetExtraFieldValueBody()");

        }
        return rtnFlg;
    }

    /// <summary>
    /// GetExtraFieldValueScreen
    /// </summary>
    /// <param name="iFieldId">cCore_VoucherScreenFields_0</param> 
    /// <param name="ScreenData">objTrans.BodyData[iRowindex].Sales.ScreenData</param>
    /// <param name="RowIndex">iRowindex</param>
    /// <param name="Return">0=Value, 1=Input</param>
    /// <returns></returns>
    public decimal GetExtraFieldValueScreen(int iFieldId, ScreenData[] ScreenData, int RowIndex, int Return = 0)
    {
        decimal rtnValue = 0;

        try
        {
            for (int i = 0; i < ScreenData.Length; i++)
            {
                if (ScreenData[i].FieldId == iFieldId + Convert.ToInt32(VTFIELDFLAG.SCR_BODY))
                {
                    if (Return == 1)
                    {
                        rtnValue = ScreenData[i].Input;
                    }
                    else
                    {
                        rtnValue = ScreenData[i].Value;
                    }
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldValueScreen()");
        }
        return rtnValue;
    }

    public int GetExtraFieldPositionScreen(int iFieldId, ScreenData[] ScreenData, int RowIndex)
    {
        int Position = 0;

        try
        {
            for (int i = 0; i < ScreenData.Length; i++)
            {
                if (ScreenData[i].FieldId == iFieldId + Convert.ToInt32(VTFIELDFLAG.SCR_BODY))
                {
                    Position = i;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetExtraFieldPositionScreen()");
        }
        return Position;
    }

    /// <summary>
    /// Get all data of a specific voucher
    /// </summary>
    /// <param name="VoucherType">VoucherType</param>
    /// <param name="VoucherNo">VoucherNo</param>
    /// <returns>DataSet</returns>
    public DataTable GetVoucherHeaderData(int VoucherType, int HeaderId = 0, string VoucherNo = "0")
    {
        DataTable dt = new DataTable();
        string Query = "";
        try
        {
            Query = @"Select * From tCore_Header_0 h left join tCore_HeaderData" + Convert.ToString(VoucherType) + "_0 he on h.iHeaderId = he.iHeaderId " +
                    " Where  h.iVoucherType = " + Convert.ToString(VoucherType) + " and h.bCancelled = 0 and h.bSuspended = 0 " +
                    " and(h.iHeaderId = '" + Convert.ToString(HeaderId) + "' Or '0' = '" + Convert.ToString(HeaderId) + "')" +
                    " and(h.sVoucherNo like '%" + Convert.ToString(VoucherNo) + "%' Or '0' = '" + Convert.ToString(VoucherNo) + "')";

            dt = GetDataTableAPI(Query);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetVoucherData(" + Query + ")");
        }
        return dt;
    }

    public DataTable GetVoucherBodyData(int VoucherType, string HeaderId = "0", string VoucherNo = "0")
    {
        DataTable dt = new DataTable();
        string Query = "";
        try
        {
            string MasterColumns = "";
            string MasterTables = "";

            DataTable dt_Master = new DataTable();
            dt_Master = GetVoucherTags(VoucherType);

            if (dt_Master.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Master.Rows.Count; i++)
                {
                    string MasterType, MasterTable, MasterName;
                    MasterType = Convert.ToString(dt_Master.Rows[i]["MasterType"]);
                    MasterTable = Convert.ToString(dt_Master.Rows[i]["MasterTable"]);
                    MasterName = Convert.ToString(dt_Master.Rows[i]["MasterName"]);

                    if (MasterName == "FaTag" || MasterName == "InvTag")
                    {
                        MasterType = MasterName;
                    }
                    MasterColumns = MasterColumns +
                                @", " + MasterName + ".iMasterId [" + MasterName + "Id], " + MasterName + ".sName [" + MasterName + "Name], " + MasterName + ".sCode [" + MasterName + "Code] ";
                    MasterTables = MasterTables +
                                @" left join tCore_Data_Tags_0 t" + MasterType + " with (noLock) on t" + MasterType + ".iBodyId = d.iBodyId and t" + MasterType + ".iTagId = " + Convert.ToString(dt_Master.Rows[i]["MasterType"]) + " " +
                                @" left join " + MasterTable + "  " + MasterName + " with (noLock) on " + MasterName + ".iMasterId = t" + MasterType + ".iTagValue ";

                }
            }

            Query = "Select d.*, de.* , AcCode.sName [AcCodeName], AcCode.sCode [AcCodeCode], AcBookNo.sName [AcBookNoName], AcBookNo.sCode [AcBookNoCode] " + MasterColumns +
                    "    From tCore_Data_0 d with (nolock) left join tCore_Data" + Convert.ToString(VoucherType) + "_0 de with (nolock) on d.iBodyId = de.iBodyId " +
                    "            inner join vmCore_Account AcCode with (nolock) on d.iFaTag = AcCode.iMasterId inner join vmCore_Account AcBookNo with (nolock) on d.iInvTag = AcBookNo.iMasterId " +
                    "          " + MasterTables +
                    "    Where (d.iHeaderId in (" + HeaderId + ") Or 0 = " + HeaderId + ")";

            dt = GetDataTableAPI(Query);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetVoucherData(" + Query + ")");
        }
        return dt;
    }


    private string GetTableNameOfTag(int iMasterTypeId)
    {
        string TableName = "";
        try
        {
            string Query = "";
            //Query = @"Select 'vm' + sModule +'_' + sMasterName [TableName] From cCore_MasterDef Where iMasterTypeId = " + Convert.ToString(iMasterTypeId);
            Query = @"Select 'v' + sModule +'_' + sMasterName [TableName] From cCore_MasterDef Where iMasterTypeId = " + Convert.ToString(iMasterTypeId);

            TableName = ExecuteScalar(Query, "");

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetTableNameOfTag()");
        }
        return TableName;
    }

    private string GetNameOfTag(int iMasterTypeId)
    {
        string TableName = "";
        try
        {
            string Query = "";
            Query = @"Select sMasterName [TableName] From cCore_MasterDef Where iMasterTypeId = " + Convert.ToString(iMasterTypeId);

            TableName = ExecuteScalar(Query, "");

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetNameOfTag()");
        }
        return TableName;
    }

    private DataTable GetVoucherTags(int VoucherType)
    {
        DataTable dt = new DataTable();
        try
        {
            string Query = "";
            Query = @"Declare @t_VoucherTags Table (RowNo int Primary key identity(1,1), MasterType int, MasterTable varchar(250), MasterName varchar(250))

                        Insert Into @t_VoucherTags
                        Select iValue [MasterType]
		                        , (Select 'vm' + sModule + '_' + sMasterName From cCore_MasterDef Where iMasterTypeId = iValue)
		                        , 'FaTag' [TagName] 
                        From cCore_PreferenceVal_0 Where iCategory = 0 and iFieldId = 0

                        Insert Into @t_VoucherTags
                        Select iValue [MasterType]
		                        , (Select 'vm' + sModule + '_' + sMasterName From cCore_MasterDef Where iMasterTypeId = iValue)
		                        , 'InvTag' [TagName] 
                        From cCore_PreferenceVal_0 Where iCategory = 0 and iFieldId = 1

                        Insert Into @t_VoucherTags
                        Select iMasterType [MasterType]
	                        , (Select 'vm' + sModule + '_' + sMasterName From cCore_MasterDef Where iMasterTypeId = iMasterType)
	                        , (Select sMasterName From cCore_MasterDef Where iMasterTypeId = iMasterType) 
                        From cCore_VoucherMasters_0 where iVoucherType = " + Convert.ToString(VoucherType) + " " +
                    " Select * From @t_VoucherTags ";

            dt = GetDataTableAPI(Query);

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetTableNameOfTag()");
        }
        return dt;
    }

    public string GetMasterData(int iMasterTypeId, string Column, string Condition)
    {
        string Result = "";
        try
        {
            DataTable dt = new DataTable();
            string Query = @"Select " + Column +
                            " From " + GetTableNameOfTag(iMasterTypeId) + " Where iStatus <> 5 and " + Condition;
            dt = GetDataTableAPI(Query);
            if (dt.Rows.Count > 0)
            {
                Result = Convert.ToString(dt.Rows[0][0]);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetMasterData()");
            Result = "";
        }
        return Result;
    }

    public DataTable GetMasterData(int iMasterTypeId, string Column = "", string Condition = "", string OrderBy = "")
    {
        DataTable dt = new DataTable();
        try
        {
            if (Column != "")
            {
                Column = ", " + Column;
            }
            if (Condition != "")
            {
                Condition = " and " + Condition;
            }
            if (OrderBy != "")
            {
                OrderBy = " Order By " + OrderBy;
            }

            string Query = @"Select *, sName + Case When sCode <> '' Then '[ ' + sCode + ' ]' else '' end [NameCode]
                                    , sCode + Case When sName <> '' Then '[ ' + sName + ' ]' else '' end [CodeName] " + Column +
                            " From " + GetTableNameOfTag(iMasterTypeId) + " Where iStatus <> 5 " + Condition + " " + OrderBy;
            dt = GetDataTableAPI(Query);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetMasterData()");
        }
        return dt;
    }

    public DataTable GetMasterDataForComboBox(int iMasterTypeId, string Column, string Condition = "")
    {
        DataTable dt = new DataTable();
        try
        {

            if (Condition != "")
            {
                Condition = " and " + Condition;
            }

            string Query = @"Select " + Column +
                            " From " + GetTableNameOfTag(iMasterTypeId) + " Where iStatus <> 5 " + Condition + " Order By 2";
            dt = GetDataTableAPI(Query);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetMasterDataForComboBox()");
        }
        return dt;
    }

    /// <summary>
    /// This function return default Base, Purchase and Sales unit of a product with conversion details.
    /// </summary>
    /// <param name="ProductId">"" for All, "iMasterId", for 1 Product, "iMasterId1,iMasterId2,iMasterId3" for multiple Product </param>
    /// <returns>DataTable</returns>
    public DataTable GetProductDefaultUnitConversion(string ProductId, string ConnStr = "")
    {
        DataTable dt = new DataTable();
        try
        {
            string Cond = "";
            if (ProductId != "")
            {
                Cond = " Where p.iMasterId in (" + ProductId + ")";
            }

            string Query = @"Select  p.iMasterId
		                            , p.sName
		                            , p.sCode
		                            , p.iDefaultBaseUnit 
		                            , p.iDefaultBaseUnitName 
		                            , 1 [XFactorBaseUnit] 
		                            , p.iDefaultSalesUnit 
		                            , p.iDefaultSalesUnitName 
		                            , IsNull(xfs.fXFactor, 1) [XFactorSalesUnit] 
		                            , IsNull(xfs.iUnitConversionId, 0) [UnitConversionId_S] 
		                            , p.iDefaultPurchaseUnit 
		                            , p.iDefaultPurchaseUnitName 
		                            , IsNull(xfp.fXFactor, 1) [XFactorPurchaseUnit] 
		                            , IsNull(xfp.iUnitConversionId, 0) [UnitConversionId_P] 
                            From vmCore_Product p 
		                            left join mCore_UnitConversion xfs with (nolock) on xfs.iProductId = p.iMasterId 
					                            and xfs.iBaseUnitId = p.iDefaultBaseUnit and xfs.iUnitId = p.iDefaultSalesUnit
		                            left join mCore_UnitConversion xfp with (nolock) on xfp.iProductId = p.iMasterId 
					                            and xfp.iBaseUnitId = p.iDefaultBaseUnit and xfp.iUnitId = p.iDefaultPurchaseUnit" + " " + Cond;
            dt = GetDataTableAPI(Query);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetProductDefaultUnitConversion(ProductId = " + ProductId + ", ConnStr = " + ConnStr + ")");
        }
        return dt;
    }

    public bool PostVoucher(Transaction objTr)
    {
        bool Result = false;
        try
        {
            DebugLog();
            Output objReturn = Connection.CallServeRequest(ServiceType.Transaction, TransMethods.PostVoucher, objTr, 1);
            if (objReturn != null)
            {
                DebugLog();
                Result = (objReturn.ReturnData as VoucherPostStatus).Posted;
                if (!Result)
                {
                    //MessageBox.Show(objReturn.ToString());

                    EventLog("Header >> VoucherType >> " + Convert.ToString(objTr.Header.VoucherType));
                    EventLog("Header >> DocNo >> " + Convert.ToString(objTr.Header.DocNo));
                    EventLog("Header >> Date >> " + Convert.ToString(objTr.Header.Date));

                    EventLog("HeaderExtra >> Count >> " + Convert.ToString(objTr.HeaderExtra.Length));
                    for (int i = 0; i < objTr.HeaderExtra.Length; i++)
                    {
                        if (objTr.HeaderExtra[i] != null)
                        {
                            EventLog("HeaderExtra >> " + Convert.ToString(objTr.HeaderExtra[i].ID) + " >> " + Convert.ToString(objTr.HeaderExtra[i].Tag));
                        }
                        else
                        {
                            EventLog("HeaderExtra >> Null Object >> " + Convert.ToString(i));
                        }
                    }
                    EventLog("BodyData >> Count >> " + Convert.ToString(objTr.BodyData.Length));
                    //foreach (TransBody bodyData in objTr.BodyData)
                    for (int b = 0; b < objTr.BodyData.Length; b++)
                    {
                        TransBody bodyData = objTr.BodyData[b];

                        if (bodyData != null)
                        {
                            EventLog("BodyData >> Code >> " + Convert.ToString(bodyData.Code));
                            EventLog("BodyData >> Book >> " + Convert.ToString(bodyData.Book));
                            EventLog("BodyData >> FATag >> " + Convert.ToString(bodyData.FATag));
                            EventLog("BodyData >> InvTag >> " + Convert.ToString(bodyData.InvTag));
                            EventLog("BodyData >> DueDate >> " + Convert.ToString(bodyData.DueDate));
                            EventLog("BodyData >> Amounts[0] >> " + Convert.ToString(bodyData.Amounts[0]));
                            EventLog("BodyData >> OriginalAmounts[0] >> " + Convert.ToString(bodyData.OriginalAmounts[0]));
                            EventLog("BodyData >> OriginalAmounts[1] >> " + Convert.ToString(bodyData.OriginalAmounts[1]));

                            for (int i = 0; i < bodyData.Tags.Length; i++)
                            {
                                if (bodyData.Tags[i] != null)
                                {
                                    EventLog("BodyData-Tags >> " + Convert.ToString(bodyData.Tags[i].ID) + " >> " + Convert.ToString(bodyData.Tags[i].Tag));
                                }
                                else
                                {
                                    EventLog("BodyData-Tags >> Null Object >> " + Convert.ToString(i));
                                }
                            }

                            for (int i = 0; i < bodyData.BodyExtra.Length; i++)
                            {
                                if (bodyData.BodyExtra[i] != null)
                                {
                                    EventLog("BodyData-BodyExtra >> " + Convert.ToString(bodyData.BodyExtra[i].ID) + " >> " + Convert.ToString(bodyData.BodyExtra[i].Tag));
                                }
                                else
                                {
                                    EventLog("BodyData-BodyExtra >> Null Object >> " + Convert.ToString(i));
                                }
                            }

                            if (bodyData.Sales != null)
                            {
                                EventLog("BodyData-Sales >> Product >>" + Convert.ToString(bodyData.Sales.Product));
                                EventLog("BodyData-Sales >> Unit >>" + Convert.ToString(bodyData.Sales.Unit));
                                EventLog("BodyData-Sales >> Quantity >>" + Convert.ToString(bodyData.Sales.Quantity));
                                EventLog("BodyData-Sales >> OrigRate >>" + Convert.ToString(bodyData.Sales.OrigRate));
                                EventLog("BodyData-Sales >> Rate >>" + Convert.ToString(bodyData.Sales.Rate));
                                EventLog("BodyData-Sales >> Gross >>" + Convert.ToString(bodyData.Sales.Gross));

                                for (int j = 0; j < bodyData.Sales.ScreenData.Length; j++)
                                {
                                    if (bodyData.Sales.ScreenData[j] != null)
                                    {
                                        EventLog("BodyData-ScreenData (Input) >> " + Convert.ToString(bodyData.Sales.ScreenData[j].FieldId) + " >> " + Convert.ToString(bodyData.Sales.ScreenData[j].Input));
                                        EventLog("BodyData-ScreenData (Value) >> " + Convert.ToString(bodyData.Sales.ScreenData[j].FieldId) + " >> " + Convert.ToString(bodyData.Sales.ScreenData[j].Value));
                                    }
                                    else
                                    {
                                        EventLog("BodyData-ScreenData >> Null Object >> " + Convert.ToString(j));
                                    }
                                }
                            }
                            else
                            {
                                EventLog("BodyData-Sales >> Null Object");
                            }
                        }
                        else
                        {
                            EventLog("BodyData >> Null Object >> " + Convert.ToString(b));
                        }
                    }



                    DebugLog();
                    string msg = Convert.ToString(objReturn.Message);
                    if (msg == "")
                    {
                        try
                        {
                            msg = Convert.ToString(((VoucherPostStatus)objReturn.ReturnData).Messages[0]);
                        }
                        catch
                        {

                        }
                    }
                    InfoLog("PostVoucher >> Status:" + Convert.ToString(objReturn.Status), "Message:" + msg + " , Detailed Message:" + (objReturn.ReturnData as VoucherPostStatus).Messages);
                }
                else
                {
                    DebugLog();
                }
            }
            else
            {
                InfoLog("PostVoucher", "OutPut object return NULL");
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.PostVoucher()");
            Result = false;
        }
        return Result;
    }

    public Output PostVoucher_Object(Transaction objTr)
    {
        Output objReturn = new Output();
        bool Result = false;
        try
        {
            objReturn = Connection.CallServeRequest(ServiceType.Transaction, TransMethods.PostVoucher, objTr, 1);
            if (objReturn != null)
            {
                Result = (objReturn.ReturnData as VoucherPostStatus).Posted;
                if (!Result)
                {
                    string msg = Convert.ToString(objReturn.Message);
                    if (msg == "")
                    {
                        try
                        {
                            msg = Convert.ToString(((VoucherPostStatus)objReturn.ReturnData).Messages[0]);
                        }
                        catch
                        {

                        }
                    }
                    InfoLog("PostVoucher >> Status:" + Convert.ToString(objReturn.Status), "Message:" + msg + " , Detailed Message:" + (objReturn.ReturnData as VoucherPostStatus).Messages);
                }
                else
                {

                }
            }
            else
            {
                InfoLog("PostVoucher", "OutPut object return NULL");
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.PostVoucher()");
            Result = false;
        }
        return objReturn;
    }

    public bool DeleteVoucher(int VoucherType, string DocumentNo)
    {
        bool Result = false;
        try
        {
            if (VoucherExist(VoucherType, DocumentNo))
            {
                Output objDel = Connection.CallServeRequest(ServiceType.Transaction, TransMethods.DeleteVoucher, VoucherType, DocumentNo, 1);
                if (objDel != null)
                {
                    Result = (objDel.ReturnData as VoucherDeleteStatus).Deleted;
                    if (!Result)
                    {
                        string msg = Convert.ToString(objDel.Message);
                        if (msg == "")
                        {
                            try
                            {
                                msg = Convert.ToString(((VoucherPostStatus)objDel.ReturnData).Messages[0]);
                            }
                            catch
                            {

                            }
                        }
                        InfoLog("DeleteVoucher >> Status:" + Convert.ToString(objDel.Status), "Message:" + msg + " , Detailed Message:" + (objDel.ReturnData as VoucherPostStatus).Messages);
                    }
                    else
                    {

                    }
                }
                else
                {
                    InfoLog("DeleteVoucher", "OutPut object return NULL");
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.DeleteVoucher()");
            Result = false;
        }
        return Result;
    }


    public bool VoucherExist(int VoucherType, string DocumentNo)
    {
        bool Result = false;
        try
        {
            if (GetHeaderId(VoucherType, DocumentNo) > 0)
            {
                Result = true;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.VoucherExist()");
            Result = false;
        }

        return Result;
    }

    public int GetHeaderId(int VoucherType, string DocumentNo)
    {
        int Result = 0;
        try
        {
            string HId = ExecuteScalar("Select iHeaderId From tCore_Header_0 h Where h.iVoucherType = " + Convert.ToString(VoucherType) + " and h.bCancelled = 0 and h.bSuspended = 0 and sVoucherNo = '" + DocumentNo + "'");

            if (HId != "")
            {
                Result = Convert.ToInt32(HId);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetHeaderId()");
            Result = 0;
        }

        return Result;
    }

    /// <summary>
    ///     Add new record in any Master
    /// </summary>
    /// <param name="MasterTypeId">MasterTypeId</param>
    /// <param name="Code">Code</param>
    /// <param name="Name">Name</param>
    /// <param name="IsGroup">Group</param>
    /// <param name="TreeId">Tree(put "0")</param>
    /// <param name="MasterId">MasterId(put "0")</param>
    /// <param name="ExtField">Extra Fields Name</param>
    /// <param name="ExtFieldVal">Extra Fields Values</param>
    /// <returns>Return New MasterId Inserted or "0" if error occurred</returns>
    public int AddDataInMasterTag(int MasterTypeId, string Code, string Name, bool IsGroup, int ParentId, int MasterId, string[] ExtField, string[] ExtFieldVal)
    {
        int NewMasterId = 0;
        try
        {
            string ExistingId = GetMasterData(MasterTypeId, "iMasterId", " sCode = '" + Code + "'");
            if (ExistingId == "")
            {
                string strError = string.Empty;
                var objMasterAPI = new Focus.Masters.DataStructs.MasterAPI();
                objMasterAPI.Code = Code;
                objMasterAPI.Name = Name;
                objMasterAPI.MasterTypeId = MasterTypeId;       //cCore_MasterDef
                objMasterAPI.IsGroup = IsGroup;
                objMasterAPI.TreeId = 0;
                objMasterAPI.ParentId = ParentId;
                objMasterAPI.MasterId = MasterId; //MasterId


                if (ExtField.Length > 0)
                {
                    if (ExtField.Length == ExtFieldVal.Length)
                    {
                        var objMAPIDataRow = new Focus.Masters.DataStructs.MAPIDataRow();
                        for (int i = 0; i < ExtField.Length - 1; i++)
                        {
                            objMAPIDataRow.AddField(Convert.ToString(ExtField[i]), Convert.ToString(ExtFieldVal[i]));
                        }
                        objMasterAPI.HeaderData.AddRow(objMAPIDataRow);
                    }
                }

                Output objOutput = Connection.CallServeRequest(ServiceType.Masters, MastersMethods.SaveMasterAPI, objMasterAPI, strError);
                NewMasterId = Convert.ToInt32(objOutput.ReturnData);
            }
            else
            {
                NewMasterId = Convert.ToInt32(ExistingId);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.AddDataInMasterTag()");
        }

        return NewMasterId;
    }

    #endregion

    #region FocusXternal

    private void FocusXternalSetting()
    {
        try
        {
            if (ExecuteScalar("SELECT name FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[xcCore_FocusXternal]') AND type in (N'U')", "") == "")
            {
                string SQL = @"CREATE TABLE [dbo].[xcCore_FocusXternal](
	                                    [iMasterId] [int] IDENTITY(1,1) NOT NULL,
	                                    [iFocusXternalId] [int] NOT NULL,
	                                    [sField0] [varchar](250) NULL,
	                                    [sField1] [varchar](250) NULL,
	                                    [sField2] [varchar](250) NULL,
	                                    [sField3] [varchar](250) NULL,
	                                    [sField4] [varchar](250) NULL,
                                     CONSTRAINT [PK_xcCore_FocusXternal] PRIMARY KEY CLUSTERED 
                                    (
	                                    [iMasterId] ASC
                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                    ) ON [PRIMARY]";
                ExecuteNonQuery(SQL, "");
            }
        }
        catch (Exception ex)
        {

            ErrLog(ex, "DevLib.FocusXternalSetting()");
        }
    }

    public int GetFocusXternalId(string FunName)
    {
        FocusXternalSetting();
        int Id = 0;
        try
        {
            switch (FunName)
            {
                case "NextSerialNo":
                    Id = 1;
                    break;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GetFocusXternalId(" + FunName + ")");
        }
        return Id;
    }
    #endregion

    #region Crystal Report 
    public string SQLServer()
    {
        return SQLServerName();
    }
    public string SQLUserName()
    {
        return SQLLoginID();
    }
    public string SQLPassword()
    {
        return SQLPW();
    }
    public string DefaultCompany()
    {
        return Default_Company();
    }
    public string ReportsFolder()
    {
        return ReportPath();
    }
    #endregion

    #region MS Report

    /// <summary>
    /// Show RDL Report
    /// </summary>
    /// <param name="RptViewer">Report Viewer</param>
    /// <param name="ReportName">Report Name</param>
    /// <param name="DSNmae">DataSet Name</param>
    /// <param name="DSValue">Result DataTable</param>
    public void ReportShow(ReportViewer RptViewer, string ReportName, string DSNmae, DataTable DSValue)       //, string[] ParamName, string ParamValue
    {
        try
        {
            // frmRptViewer f = new frmRptViewer();

            RptViewer.Reset();
            RptViewer.LocalReport.DataSources.Clear(); //clear report
                                                       //reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc
            RptViewer.LocalReport.ReportPath = ReportPath() + ReportName;


            //ReportParameterCollection reportParameters = new ReportParameterCollection();
            //if (ParamName.Length == ParamValue.Length && ParamName.Length > 0)
            //{
            //    for (int i = 0; i < ParamName.Length; i++)
            //    {
            //        reportParameters.Add(new ReportParameter(Convert.ToString(ParamName[i]), Convert.ToString(ParamValue[i])));
            //    }
            //}

            //f.RptViewer.LocalReport.SetParameters(reportParameters);

            ReportDataSource dataset = new ReportDataSource(DSNmae, DSValue); // set the datasource
            RptViewer.LocalReport.DataSources.Add(dataset);

            RptViewer.LocalReport.Refresh();
            RptViewer.RefreshReport(); // refresh report


            ////////////////////////////////////////////////

            //reportViewer1.Reset();
            //reportViewer1.LocalReport.ReportPath = "";     // Server.MapPath("Report1.rdlc");
            //ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getData());
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1. DataBindings();
            //reportViewer1.LocalReport.Refresh();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ReportShow()");
        }
    }

    /// <summary>
    /// Show RDL Report
    /// </summary>
    /// <param name="RptViewer">Report Viewer</param>
    /// <param name="ReportName">Report Name</param>
    /// <param name="DSNmae">DataSet Name Array</param>
    /// <param name="DSValue">Result DataTable Array</param>
    public void ReportShow(ReportViewer RptViewer, string ReportName, string[] DSNmae, DataTable[] DSValue)       //, string[] ParamName, string ParamValue
    {
        try
        {


            RptViewer.Reset();
            RptViewer.LocalReport.DataSources.Clear(); //clear report
                                                       //reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc
            RptViewer.LocalReport.ReportPath = ReportPath() + ReportName;

            if (DSNmae.Length == DSValue.Length)
            {
                for (int i = 0; i < DSNmae.Length; i++)
                {
                    ReportDataSource dataset = new ReportDataSource(DSNmae[i], DSValue[i]); // set the datasource
                    RptViewer.LocalReport.DataSources.Add(dataset);
                }
            }
            RptViewer.LocalReport.Refresh();
            //RptViewer.RefreshReport(); // refresh report
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ReportShow()");
        }
    }

    /// <summary>
    /// Show RDL Report
    /// </summary>
    /// <param name="RptViewer">Report Viewer</param>
    /// <param name="ReportName">Report Name</param>
    /// <param name="DSNmae">DataSet Name Array</param>
    /// <param name="DSValue">Result DataTable Array</param>
    /// <param name="ParamName">Parameter Name Array</param>
    /// <param name="ParamValue">Parameter Value Array</param>
    public void ReportShow(ReportViewer RptViewer, string ReportName, string DSNmae, DataTable DSValue, string[] ParamName, string[] ParamValue)
    {
        try
        {
            // frmRptViewer f = new frmRptViewer();

            RptViewer.Reset();
            RptViewer.LocalReport.DataSources.Clear(); //clear report
                                                       //reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc
            RptViewer.LocalReport.ReportPath = ReportPath() + ReportName;


            ReportParameterCollection reportParameters = new ReportParameterCollection();
            if (ParamName.Length == ParamValue.Length && ParamName.Length > 0)
            {
                for (int i = 0; i < ParamName.Length; i++)
                {
                    reportParameters.Add(new ReportParameter(Convert.ToString(ParamName[i]), Convert.ToString(ParamValue[i])));
                }
            }

            RptViewer.LocalReport.SetParameters(reportParameters);

            ReportDataSource dataset = new ReportDataSource(DSNmae, DSValue); // set the datasource
            RptViewer.LocalReport.DataSources.Add(dataset);

            RptViewer.LocalReport.Refresh();
            RptViewer.RefreshReport(); // refresh report


            ////////////////////////////////////////////////

            //reportViewer1.Reset();
            //reportViewer1.LocalReport.ReportPath = "";     // Server.MapPath("Report1.rdlc");
            //ReportDataSource rds = new ReportDataSource("dsNewDataSet_Table", getData());
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1. DataBindings();
            //reportViewer1.LocalReport.Refresh();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ReportShow()");
        }
    }


    /// <summary>
    /// Show RDL Report
    /// </summary>
    /// <param name="RptViewer">Report Viewer</param>
    /// <param name="ReportName">Report Name</param>
    /// <param name="DSNmae">DataSet Name Array</param>
    /// <param name="DSValue">Result DataTable Array</param>
    /// <param name="Title">From Title</param>
    public void ReportShow(string ReportName, string[] DSNmae, DataTable[] DSValue, string Title, bool MinimizeOption = false)       //, string[] ParamName, string ParamValue
    {
        try
        {
            frmRptViewer f = new frmRptViewer();

            f.RptViewer.Reset();
            f.RptViewer.LocalReport.DataSources.Clear(); //clear report
                                                         //reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc
            f.RptViewer.LocalReport.ReportPath = ReportPath() + ReportName;

            if (DSNmae.Length == DSValue.Length)
            {
                for (int i = 0; i < DSNmae.Length; i++)
                {
                    ReportDataSource dataset = new ReportDataSource(DSNmae[i], DSValue[i]); // set the datasource
                    f.RptViewer.LocalReport.DataSources.Add(dataset);
                }
            }
            f.RptViewer.LocalReport.Refresh();
            f.RptViewer.RefreshReport(); // refresh report
            f.Text = Title;
            f.MinimizeBox = MinimizeOption;

            if (MinimizeOption)
            {

                f.Show();
            }
            else
            {
                f.ShowDialog();
            }


        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.ReportShow()");
        }
    }

    /// <summary>
    /// Show RDL Report
    /// </summary>
    /// <param name="RptViewer">Report Viewer</param>
    /// <param name="ReportName">Report Name</param>
    /// <param name="DSNmae">DataSet Name Array</param>
    /// <param name="DSValue">Result DataTable Array</param>
    /// <param name="Title">From Title</param>
    /// <param name="ExportTo">0=Wrd, 1=Excel, 2=PDF</param>
    public string ReportShow(string ReportName, string[] DSNmae, DataTable[] DSValue, string FileName, int ExportTo)       //, string[] ParamName, string ParamValue
    {
        string rtnFilePath = "";
        try
        {
            ReportViewer RptViewer = new ReportViewer();

            RptViewer.Reset();
            RptViewer.LocalReport.DataSources.Clear(); //clear report
                                                       //reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc
            RptViewer.LocalReport.ReportPath = ReportPath() + ReportName;

            if (DSNmae.Length == DSValue.Length)
            {
                for (int i = 0; i < DSNmae.Length; i++)
                {
                    ReportDataSource dataset = new ReportDataSource(DSNmae[i], DSValue[i]); // set the datasource
                    RptViewer.LocalReport.DataSources.Add(dataset);
                }
            }
            RptViewer.LocalReport.Refresh();
            RptViewer.RefreshReport(); // refresh report

            ////////////////////////////////////////////

            RptViewer.RefreshReport();
            rtnFilePath = ExportToFile(FileName, ExportTo, RptViewer);

            ////////////////////////////////////////////

        }
        catch (Exception ex)
        {
            rtnFilePath = "";
            ErrLog(ex, "DevLib.ReportShow()");
        }
        return rtnFilePath;
    }


    private string ExportToFile(string FileName, int ExportTo, ReportViewer reportViewer)
    {
        string rtnFilePath = "";
        try
        {
            var x = reportViewer.LocalReport.ListRenderingExtensions();
            RenderingExtension render_ = null;
            string ext = "pdf";

            switch (ExportTo)
            {
                case 0:     //"word":
                    render_ = x[5];
                    ext = "doc";
                    break;
                case 1:      //"excel":
                    render_ = x[1];
                    ext = "xls";
                    break;
                case 2:      //"pdf":
                    render_ = x[3];
                    ext = "pdf";
                    break;
            }
            if (render_ != null)
            {
                //var DialogResult = reportViewer.ExportDialog(render_);
                //if (DialogResult == DialogResult.OK)
                //MessageBox.Show("Done!");


                var bytes = reportViewer.LocalReport.Render(ext);
                string dirExp = ReportPath() + "Export\\";

                if (!Directory.Exists(dirExp))
                {
                    Directory.CreateDirectory(dirExp);
                }

                rtnFilePath = dirExp + FileName + "." + ext;
                var path = string.Format(rtnFilePath, ext);
                File.WriteAllBytes(path, bytes);
            }
        }
        catch (Exception ex)
        {
            rtnFilePath = "";
            ErrLog(ex, "DevLib.ExportToFile");
        }
        return rtnFilePath;
    }


    #endregion

    #region DATASET HELPER
    public bool IsEqualValue(object A, object B)
    {
        // Compares two values to see if they are equal. Also compares DBNULL.Value.           
        if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
            return true;
        if (A == DBNull.Value || B == DBNull.Value) //  only one is BNull.Value
            return false;
        return (A.Equals(B));  // value type standard comparison
    }
    public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
    {
        // Create a Datatable â€“ datatype same as FieldName
        DataTable dt = new DataTable(SourceTable.TableName);
        dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
        // Loop each row & compare each value with one another
        // Add it to datatable if the values are mismatch
        object LastValue = null;
        foreach (DataRow dr in SourceTable.Select("", FieldName))
        {
            if (LastValue == null || !(IsEqualValue(LastValue, dr[FieldName])))
            {
                LastValue = dr[FieldName];
                dt.Rows.Add(new object[] { LastValue });
            }
        }
        return dt;
    }
    #endregion

    #region Screen Based Rport (Grid View Report)

    /// <summary>
    /// Show Tabular Type Report
    /// </summary>
    /// <param name="dt"> DataTable with finilized values</param>
    /// <param name="Title">Screen Title</param>
    public void GridViewReport(DataTable dt, string Title)
    {
        try
        {
            frmGvRptViewer1 f = new frmGvRptViewer1();
            f.gvList.DataSource = dt;

            f.Text = Title;

            int height = 0;
            foreach (DataGridViewRow row in f.gvList.Rows)
            {
                height += row.Height;
            }
            height += f.gvList.ColumnHeadersHeight;

            int width = 0;
            foreach (DataGridViewColumn col in f.gvList.Columns)
            {
                width += col.Width;
            }
            width += f.gvList.RowHeadersWidth;

            if (height > 500)
            {
                height = 500;
            }
            if (width > 1200)
            {
                width = 1200;
            }

            if (height < 150)
            {
                height = 150;
            }
            f.gvList.ClientSize = new Size(width + 2, height + 2);

            f.Size = new Size(width + 50, height + 150);
            f.btnExportExcel.Location = new Point(f.Width - 70, 12);
            f.btnFilter.Location = new Point(f.Width - 100, 12);

            f.ShowDialog();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.frmGvRptViewer1()");
        }
    }




    public void GridViewReportAnalysis(DataTable dt, string Title, int[] CellNo, Char Type, int ShowDialog = 0)
    {
        try
        {
            frmGvRptViewer_Analysys f = new frmGvRptViewer_Analysys();
            dt = DataTableAnalysis(dt, CellNo, Type);
            f.gvList.DataSource = dt;
            HideGVLastColumns(f.gvList, new int[] { f.gvList.ColumnCount - 1 });

            f.Text = Title;
            if (ShowDialog == 1)
            {
                f.Show();
                f.MinimizeBox = true;
                f.BringToFront();
                f.TopMost = true;
            }
            else
            {
                f.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.GridViewReportAnalysis()");
        }
    }

    public DataTable DataTableAnalysis(DataTable dt, int[] CellNo, Char Type)
    {
        try
        {
            dt.Columns.Add("ColorCellNo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (Type == 'L')
                {
                    int CellId = -1;
                    int ColorCellId = -1;
                    decimal CellVal = 0;

                    for (int j = 0; j < CellNo.Length; j++)
                    {
                        CellId = CellNo[j] - 1;
                        if (j == 0)
                        {
                            CellVal = Convert.ToDecimal(dr[CellId]);
                            ColorCellId = CellId;
                        }
                        else
                        {
                            if (Convert.ToDecimal(dr[CellId]) < CellVal)
                            {
                                CellVal = Convert.ToDecimal(dr[CellId]);
                                ColorCellId = CellId;
                            }
                        }
                    }
                    dt.Rows[i]["ColorCellNo"] = ColorCellId;
                }
                else
                {
                    int CellId = -1;
                    int ColorCellId = -1;
                    decimal CellVal = 0;

                    for (int j = 0; j < CellNo.Length; j++)
                    {
                        CellId = CellNo[j] - 1;
                        if (j == 0)
                        {
                            CellVal = Convert.ToDecimal(dr[CellId]);
                            ColorCellId = CellId;
                        }
                        else
                        {
                            if (Convert.ToDecimal(dr[CellId]) > CellVal)
                            {
                                CellVal = Convert.ToDecimal(dr[CellId]);
                                ColorCellId = CellId;
                            }
                        }
                    }
                    dt.Rows[i]["ColorCellNo"] = ColorCellId;
                }
            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.DataTableAnalysis()");
        }

        return dt;
    }


    #endregion

    #region Focus8 Design
    /// <summary>
    /// This methiod is used to design external screen as Focus8 design.
    /// Current design is available for below mention controls:
    /// 1. Form
    /// 2. Button
    /// 3. ComboBox
    /// </summary>
    /// <param name="ObjControl">For Form design pass 'this', for other controls pass control name</param>
    /// <param name="ObjType">For Form design pass 'Form', for other controls pass 'controlname.GetType().Name'</param>
    public void UIDesign(object ObjControl, string ObjType)
    {
        try
        {
            if (ObjControl != null)
            {

                //string CtrlName = ObjControl.GetType().Name;
                string CtrlName = ObjType;
                switch (CtrlName)
                {
                    case "Form":
                        Form frm = ((Form)ObjControl);
                        frm.MinimizeBox = false;
                        frm.MaximizeBox = false;
                        //frm.BackColor = ColorTranslator.FromHtml("#d0d2a9");
                        frm.BackColor = ColorTranslator.FromHtml("#d5d9b7");
                        frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        //frm.FormBorderStyle = FormBorderStyle.None;     // Hide TitleBar
                        //frm.Icon =
                        //frm.PreviewKeyDown = new PreviewKeyDownEventHandler(Form_KeyDown)
                        break;

                    case "Button":
                        Button btn = ((Button)ObjControl);
                        btn.BackColor = ColorTranslator.FromHtml("#faf9f6");
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        //btn.Tag = btn.Text;
                        break;

                    case "ComboBox":
                        ComboBox cbx = ((ComboBox)ObjControl);
                        cbx.DropDownStyle = ComboBoxStyle.DropDown;
                        cbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cbx.FlatStyle = FlatStyle.Flat;
                        cbx.FormattingEnabled = true;
                        break;

                    case "TextBox":
                        TextBox txt = ((TextBox)ObjControl);
                        txt.BorderStyle = BorderStyle.FixedSingle;
                        //txt.DropDownStyle = ComboBoxStyle.DropDown;
                        ////txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        ////txt.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //txt.FlatStyle = FlatStyle.Flat;
                        //txt.FormattingEnabled = true;
                        break;

                    case "MaskedTextBox":
                        MaskedTextBox mtxt = ((MaskedTextBox)ObjControl);
                        mtxt.BorderStyle = BorderStyle.FixedSingle;
                        //txt.DropDownStyle = ComboBoxStyle.DropDown;
                        ////txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        ////txt.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //txt.FlatStyle = FlatStyle.Flat;
                        //txt.FormattingEnabled = true;
                        break;

                    case "DateTimePicker":
                        DateTimePicker dtp = ((DateTimePicker)ObjControl);
                        dtp.Format = DateTimePickerFormat.Custom;
                        dtp.CustomFormat = "dd/MM/yyyy";
                        dtp.CalendarFont = new Font("Tahoma", 10F, FontStyle.Italic, GraphicsUnit.Point, ((Byte)(0)));
                        dtp.CalendarForeColor = Color.Black;
                        dtp.CalendarMonthBackground = Color.White;
                        dtp.CalendarTitleBackColor = Color.LightGray;
                        dtp.CalendarTitleForeColor = Color.Black;
                        dtp.CalendarTrailingForeColor = Color.Gray;
                        //dtp.StyleChanged = FlatStyle.Flat;
                        break;

                    case "DataGridView":
                        DataGridView gv = ((DataGridView)ObjControl);
                        gv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                        gv.ColumnHeadersHeight = 25;

                        gv.RowTemplate.Height = 25;
                        gv.RowTemplate.DefaultCellStyle.BackColor = Color.White;
                        gv.BackgroundColor = ColorTranslator.FromHtml("#ffffff");

                        gv.CellEnter += new DataGridViewCellEventHandler(gv_CellEnter);

                        break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.UIDesign()");
        }
    }

    public void UIDesign(object ObjControl)
    {
        try
        {
            UIDesign(ObjControl, ObjControl.GetType().Name);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.UIDesign()");
        }
    }

    private void gv_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            DataGridView gv = ((DataGridView)sender);

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                gv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                if (e.RowIndex == i)
                {
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }


        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.gv_CellEnter()");
        }
    }


    public void WaitStart(object ObjControl)
    {
        try
        {
            if (ObjControl != null)
            {
                string CtrlName = ObjControl.GetType().Name;
                switch (CtrlName)
                {
                    case "Button":
                        Button btn = ((Button)ObjControl);
                        btn.BackColor = ColorTranslator.FromHtml("#faf9f6");
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;

                        btn.Tag = btn.Text;
                        btn.Enabled = false;
                        btn.Text = "Wait...";
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.WaitStart()");
        }
    }

    public void WaitEnd(object ObjControl)
    {
        try
        {
            if (ObjControl != null)
            {
                string CtrlName = ObjControl.GetType().Name;
                switch (CtrlName)
                {
                    case "Button":
                        Button btn = ((Button)ObjControl);
                        btn.BackColor = ColorTranslator.FromHtml("#faf9f6");
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;

                        btn.Enabled = true;
                        btn.Text = Convert.ToString(btn.Tag);
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.WaitEnd()");
        }
    }

    //private void Form_KeyDown(object sender, KeyEventArgs e)
    //{
    //    if (e.KeyCode == Keys.Escape)
    //    {
    //        this.Close();
    //    }
    //}


    #endregion

    #region Messages

    /// <summary>
    /// Custom Message Box
    /// </summary>
    /// <param name="msgType">
    /// <para>0-Failed, 1-Success, 2-Error, 3-Record Not Found, 4-Delete Confirmation (Yes/No), 5-Print Confirmation (Yes/No)
    /// 91-Asterisk, 92-Error, 93-Exclamation, 94-Hand, 95-Information, 96-None, 97-Question, 98-Stop, 99-Warning, </para></param>
    /// <param name="strMessage">Optional, Display given string</param>
    /// <returns></returns>
    /*
    public void MsgBox(int msgType, string strMessage = "")
    {
        try
        {

            if (strMessage == "")
            {
                switch (msgType)
                {
                    case 0:
                        strMessage = "Failed";
                        break;
                    case 1:
                        strMessage = "Successful";
                        break;
                    case 2:
                        strMessage = "Error Occurred";
                        break;
                    case 3:
                        strMessage = "Record Not Found";
                        break;
                    case 4:
                        strMessage = "Are You Sure You Want To Delete";
                        break;
                    case 999:
                        strMessage = "Stopped Working, Contact System Administrator";
                        break;
                }
            }

            switch (msgType)
            {
                case 0:
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 1:
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 4:
                    MessageBox.Show(strMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    break;
                case 91:
                    MessageBox.Show(strMessage, "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case 92:
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 93:
                    MessageBox.Show(strMessage, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 94:
                    MessageBox.Show(strMessage, "Hand", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case 95:
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 96:
                    MessageBox.Show(strMessage, "None", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;
                case 97:
                    MessageBox.Show(strMessage, "Question", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;
                case 98:
                    MessageBox.Show(strMessage, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case 99:
                    MessageBox.Show(strMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 999:
                    MessageBox.Show(strMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:

                    break;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.MsgBox()");
        }
    }
    */

    /// <summary>
    /// Custom Message Box
    /// </summary>
    /// <param name="msgType">
    /// <para>0-Failed, 1-Success, 2-Error, 3-Record Not Found, 4-Delete Confirmation (Yes/No), 5-Print Confirmation (Yes/No)
    /// 91-Asterisk, 92-Error, 93-Exclamation, 94-Hand, 95-Information, 96-None, 97-Question, 98-Stop, 99-Warning, </para></param>
    /// <param name="strMessage">Optional, Display given string</param>
    /// <returns></returns>
    public DialogResult MsgBox(int msgType, string strMessage = "", string strTitle = "")
    {
        DialogResult Result = DialogResult.OK;
        try
        {

            if (strMessage == "")
            {
                switch (msgType)
                {
                    case 0:
                        strMessage = "Failed";
                        break;
                    case 1:
                        strMessage = "Successful";
                        break;
                    case 2:
                        strMessage = "Error Occurred";
                        break;
                    case 3:
                        strMessage = "Record Not Found";
                        break;
                    case 4:
                        strMessage = "Are You Sure You Want To Delete";
                        break;
                    case 5:
                        strMessage = "Are You Sure You Want To Print";
                        break;
                    case 999:
                        strMessage = "Stopped Working, Contact System Administrator";
                        break;
                }
            }

            if (strTitle == "")
            {
                switch (msgType)
                {
                    case 0:
                        strTitle = "Failed";
                        break;
                    case 1:
                        strTitle = "Successful";
                        break;
                    case 2:
                        strTitle = "Error";
                        break;
                    case 3:
                        strTitle = "Information";
                        break;
                    case 4:
                        strTitle = "Delete";
                        break;
                    case 5:
                        strTitle = "Print";
                        break;
                    case 999:
                        strTitle = "Stopped Working";
                        break;
                }
            }

            switch (msgType)
            {
                case 0:
                    //Result = MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Exclamation, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 1:
                    //Result = MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Info, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 2:
                    //Result = MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Error, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 3:
                    //Result = MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Exclamation, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 4:
                    //Result = MessageBox.Show(strMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.YesNo, CustomMsgBox.Icon.Warning, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 5:
                    //Result = MessageBox.Show(strMessage, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.YesNo, CustomMsgBox.Icon.Exclamation, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 91:
                    //MessageBox.Show(strMessage, "Asterisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Exclamation, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 92:
                    //Result = MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Error, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 93:
                    //Result = MessageBox.Show(strMessage, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Exclamation, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 94:
                    //Result = MessageBox.Show(strMessage, "Hand", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Shield, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 95:
                    //Result = MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Info, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 96:
                    //Result = MessageBox.Show(strMessage, "None", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Error, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 97:
                    //Result = MessageBox.Show(strMessage, "Question", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Question, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 98:
                    //Result = MessageBox.Show(strMessage, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Shield, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 99:
                    //Result = MessageBox.Show(strMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Warning, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                case 999:
                    //Result = MessageBox.Show(strMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Result = CustomMsgBox.Show(strMessage, strTitle, CustomMsgBox.Buttons.OK, CustomMsgBox.Icon.Warning, CustomMsgBox.AnimateStyle.FadeIn);
                    break;
                default:
                    Result = DialogResult.OK;
                    break;
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.MsgBox()");
        }
        return Result;
    }

    #endregion

    #region Email
    /// <summary>
    /// Send Email
    /// </summary>
    /// <param name="From">From EmailID, set "" to get value from Preferences </param>
    /// <param name="Password">Password of From Email ID, set "" to get value from Preferences</param>
    /// <param name="To">To Email ID [string array]</param>
    /// <param name="Cc">Cc Email ID [string array]</param>
    /// <param name="Bcc">BCc Email ID [string array]</param>
    /// <param name="Subject">Subject</param>
    /// <param name="Body">Body</param>
    /// <param name="Attachment">Attachment give physical path [string array]</param>
    /// <param name="SMPT_Host">SMPT Host, set "" to get value from Preferences </param>
    /// <param name="SMPT_Port">SMPT Port, set 0 to get value from Preferences </param>
    /// <returns>Return True or False, Boolean value</returns>
    public bool SendEmail(string From, string Password, string[] To, string[] Cc, string[] Bcc, string Subject, string Body, string[] Attachment, string SMPT_Host, int SMPT_Port)
    {
        bool RtnFlag = true;
        try
        {
            if (SMPT_Port == 0)
            {
                SMPT_Port = 587;
            }
            if (SMPT_Host == "")
            {
                SMPT_Host = ExecuteScalar("Select sValue From cCore_PreferenceText_0 Where iCategory = 13 and iFieldId = 0");
            }

            if (SMPT_Host == "")
            {
                MsgBox(0, "SMTP Address not defined");
                return false;
            }

            if (From == "")
            {
                From = ExecuteScalar("Select sValue From cCore_PreferenceText_0 Where iCategory = 13 and iFieldId = 1");
            }
            if (Password == "")
            {
                Password = ExecuteScalar("Select sValue From cCore_PreferenceText_0 Where iCategory = 13 and iFieldId = 2");
            }

            // '''''''''''''''''''''''''''''''''''''''''Sending Mail''''''''''''''''''''''''''''''''
            // sendMail()

            MailMessage mail = new MailMessage();


            mail.From = new MailAddress(From);

            if (To.Length == 0)
            {
                MsgBox(0, "To Email ID not defined");
                return false;
            }

            foreach (string s in To)
            {
                if (s.Trim() != "")
                {
                    mail.To.Add(new MailAddress(s));
                }
            }

            foreach (string s in Cc)
            {
                if (s.Trim() != "")
                {
                    mail.CC.Add(new MailAddress(s));
                }
            }

            foreach (string s in Bcc)
            {
                if (s.Trim() != "")
                {
                    mail.Bcc.Add(new MailAddress(s));
                }
            }

            // ''''''''''''''''''''''''''''''Email Subject''''''''''''''''''''''''''''''''''''''''
            if ((Subject == ""))
            {
                mail.Subject = " ";
            }
            else
            {
                mail.Subject = Subject;
            }

            // ''''''''''''''''''''''''''''''Email Body''''''''''''''''''''''''''''''''''''''''

            if (Body == "")
            {
                mail.Body = " ";
            }
            else
            {
                mail.Body = Body;
            }

            // ''''''''''''''''''''''''''''''Email Attachment'''''''''''''''''''''''''
            foreach (string s in Attachment)
            {
                if (s != "")
                {
                    mail.Attachments.Add(new Attachment(s));
                }
            }


            using (SmtpClient mailClient = new SmtpClient())
            {
                mailClient.Host = SMPT_Host;
                mailClient.Port = SMPT_Port;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = new NetworkCredential(From, Password);
                mailClient.EnableSsl = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mailClient.Send(mail);
            }

            //SmtpClient mailClient = new SmtpClient();
            //mailClient.Host = SMPT_Host;
            //mailClient.Port = SMPT_Port;
            //mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //mailClient.UseDefaultCredentials = false;
            //mailClient.Credentials = new NetworkCredential(From, Password);
            //mailClient.EnableSsl = true;
            //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //mailClient.Send(mail);
            //mail.Dispose();

        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.SendEmail");
            RtnFlag = false;
        }
        return RtnFlag;
    }
    #endregion

    #region Export Options

    public void ExportGridToExcel(DataGridView GV, String fileName, bool Header, bool openAfter)
    {

        try
        {
            //for (int i = GV.Columns.Count - 1; i >= 0; i--)
            //{
            //    if (GV.Columns[i].Visible == false)
            //    {
            //        GV.Columns.Remove(GV.Columns[i]);
            //    }
            //}

            //export a DataTable to Excel
            DialogResult retry = DialogResult.Retry;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data").Replace("file:\\", "");
            if (Directory.Exists(exePath) == false)
            {
                Directory.CreateDirectory(exePath);
            }

            while (retry == DialogResult.Retry)
            {
                try
                {
                    using (XternalDevLib.ExcelWriter writer = new XternalDevLib.ExcelWriter(exePath + "\\" + fileName))
                    {
                        writer.WriteStartDocument();

                        // Write the worksheet contents
                        writer.WriteStartWorksheet("Sheet1");

                        //Write header row
                        if (Header)
                        {
                            writer.WriteStartRow();
                            foreach (DataGridViewColumn col in GV.Columns)
                            {
                                if (col.Visible)
                                    writer.WriteExcelUnstyledCell(col.HeaderText);
                            }
                            writer.WriteEndRow();
                        }

                        //write data
                        foreach (DataGridViewRow row in GV.Rows)
                        {
                            writer.WriteStartRow();
                            foreach (DataGridViewCell o in row.Cells)
                            {
                                if (o.Visible)
                                {
                                    if (Convert.IsDBNull(o.Value) || o.Value == null)
                                    {
                                        writer.WriteExcelUnstyledCell(String.Empty);
                                    }
                                    else
                                    {
                                        if (o.ValueType.Name == "Decimal")
                                        {
                                            writer.WriteExcelStyledCell(o.FormattedValue, XternalDevLib.ExcelWriter.CellStyle.Number);
                                        }
                                        else
                                        {
                                            writer.WriteExcelAutoStyledCell(o.Value);
                                        }
                                    }
                                }
                            }
                            writer.WriteEndRow();
                        }

                        // Close up the document
                        writer.WriteEndWorksheet();
                        writer.WriteEndDocument();
                        writer.Close();
                        if (openAfter)
                        {
                            openFileDialog.FileName = exePath + "\\" + fileName;
                            ////openFileDialog.ShowDialog();
                            //openFileDialog.OpenFile();

                            Process.Start(openFileDialog.FileName);
                        }
                        retry = DialogResult.Cancel;

                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "ExportGridToExcel()");
        }
    }

    public void ExportGridToExcel(DataTable dtExp, String fileName, bool Header, bool openAfter)

    {

        try
        {

            //export a DataTable to Excel
            DialogResult retry = DialogResult.Retry;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data").Replace("file:\\", "");
            if (Directory.Exists(exePath) == false)
            {
                Directory.CreateDirectory(exePath);
            }

            while (retry == DialogResult.Retry)
            {
                try
                {
                    using (XternalDevLib.ExcelWriter writer = new XternalDevLib.ExcelWriter(exePath + "\\" + fileName))
                    {
                        writer.WriteStartDocument();

                        // Write the worksheet contents
                        writer.WriteStartWorksheet("Sheet1");

                        //Write header row
                        if (Header)
                        {
                            writer.WriteStartRow();
                            for (int col = 0; col < dtExp.Columns.Count; col++)
                            {
                                writer.WriteExcelUnstyledCell(dtExp.Columns[col].ColumnName);
                            }
                            writer.WriteEndRow();
                        }

                        //write data
                        for (int row = 0; row < dtExp.Rows.Count; row++)
                        //foreach (DataGridViewRow row in GV.Rows)
                        {
                            writer.WriteStartRow();
                            for (int o = 0; o < dtExp.Columns.Count; o++)
                            //foreach (DataGridViewCell o in row.Cells)
                            {
                                //if (o.Visible)
                                {
                                    if (Convert.IsDBNull(dtExp.Rows[row][o]) || dtExp.Rows[row][o] == null)
                                    {
                                        writer.WriteExcelUnstyledCell(String.Empty);
                                    }
                                    else
                                    {
                                        //if (o.ValueType.Name == "Decimal")
                                        //{
                                        //    writer.WriteExcelStyledCell(o.FormattedValue, XternalDevLib.ExcelWriter.CellStyle.Number);
                                        //}
                                        //else
                                        //{
                                        writer.WriteExcelAutoStyledCell(Convert.ToString(dtExp.Rows[row][o]));
                                        //}
                                    }
                                }
                            }
                            writer.WriteEndRow();
                        }

                        // Close up the document
                        writer.WriteEndWorksheet();
                        writer.WriteEndDocument();
                        writer.Close();
                        if (openAfter)
                        {
                            openFileDialog.FileName = exePath + "\\" + fileName;
                            ////openFileDialog.ShowDialog();
                            //openFileDialog.OpenFile();

                            Process.Start(openFileDialog.FileName);
                        }
                        retry = DialogResult.Cancel;

                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "ExportGridToExcel()");
        }
    }

    public DataTable ExcelToDataTable(string FilePath, string Extension, string isHDR)
    {
        DataTable dt = new DataTable();
        try
        {
            EventLog("ExcelToDataTable -- IN");
            string conStr = "";
            EventLog("Extension: " + Extension);
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0;HDR={1};IMEX=1\\;'";
                    break;
                case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 8.0;HDR={1};IMEX=1\\;'";
                    break;
            }
            EventLog("Conn Str: " + conStr);

            conStr = String.Format(conStr, FilePath, isHDR);
            EventLog("String.Format");
            OleDbConnection connExcel = new OleDbConnection(conStr);
            EventLog("OleDbConnection");
            OleDbCommand cmdExcel = new OleDbCommand();
            EventLog("OleDbCommand");
            OleDbDataAdapter oda = new OleDbDataAdapter();
            EventLog("OleDbDataAdapter");

            cmdExcel.Connection = connExcel;
            EventLog("cmdExcel.Connection");

            //Get the name of First Sheet
            EventLog("State" + connExcel.State.ToString());
            if (connExcel.State.ToString() == "Open")
            {
                EventLog("Close Connection");
                connExcel.Close();
            }
            EventLog("Open New Connection");
            connExcel.Open();
            EventLog("ExcelSchema");
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            EventLog("ExcelSchema Loaded");
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            EventLog("SheetName: " + SheetName);
            EventLog("Closing Connection");
            connExcel.Close();


            //Read Data from First Sheet
            EventLog("Read Data");
            EventLog("Open New Connection");
            connExcel.Open();
            EventLog("CommandText");
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            EventLog(cmdExcel.CommandText);
            oda.SelectCommand = cmdExcel;
            EventLog("SelectCommand");
            EventLog("dt.Fill");
            oda.Fill(dt);
            EventLog("Closing Connection");
            connExcel.Close();
            EventLog("ExcelToDataTable -- OUT");

            ////Bind Data to GridView
            //GridView1.Caption = Path.GetFileName(FilePath);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }
        catch (Exception ex)
        {
            EventLog("catch Exception: " + Convert.ToString(ex));
            ErrLog(ex, "DevLib.ExcelToDataTable()");
        }
        return dt;
    }

    #endregion


    #region Default Forms

    /// <summary>
    /// Screen with Only Date Search
    /// </summary>
    /// <param name="Title">Screen Title</param>
    /// <param name="DisplayFormat">0="dd/MM/yyyy, 1= MMM yyyy"</param>
    /// <returns>return DataTable with Selected Date</returns>
    public DataTable DefaultFormDateOnly(string Title, int DisplayFormat = 0)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {
            frmDate f = new frmDate();
            f.Text = Title;
            if (DisplayFormat == 1)
            {
                f.dtpStartDate.CustomFormat = "MMM yyyy";
            }

            DialogResult dialogResult = f.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string sDate = Convert.ToString(FocusDateToInt(f.dtpStartDate.Value.ToString("yyyy/MM/dd")));
                dt_DF.Rows.Add("1", "iStartDate", sDate);
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormDateOnly()");
        }
        return dt_DF;
    }

    // <summary>
    /// Search Screen
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <returns></returns>
    public DataTable DefaultFormSearchByTags(string ScreenTitle, SearchByTags[] Tag, bool Date = false, bool DateRange = true)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {

            //if (Tag.Length == 1)
            {
                frmSearchBy1Tag f = new frmSearchBy1Tag();
                f.Text = ScreenTitle;
                int frmHeight = 0;
                for (int i = 0; i < Tag.Length; i++)
                {

                    ComboBox cbx = new ComboBox();
                    cbx.Location = new System.Drawing.Point(160, (35 * i) + 82);
                    cbx.Width = 200;
                    cbx.Name = "cbxTag" + Convert.ToString(i);
                    UIDesign(cbx);
                    f.Controls.Add(cbx);

                    Label lbl = new Label();
                    lbl.Location = new System.Drawing.Point(50, (35 * i) + 82);
                    lbl.Width = 200;
                    lbl.Name = "lbl" + Convert.ToString(i);
                    if (Convert.ToString(Tag[i].TagLabel) == null)
                    {
                        lbl.Text = GetNameOfTag(Tag[i].TagId);
                    }
                    else
                    {
                        lbl.Text = Convert.ToString(Tag[i].TagLabel);
                    }
                    UIDesign(lbl);
                    f.Controls.Add(lbl);

                    frmHeight = (35 * i);


                    DataTable dt_Tag = new DataTable();
                    if (Tag[i].UseQuery)
                    {
                        dt_Tag = GetDataTableAPI(Tag[i].Query);
                    }
                    else
                    {
                        string column = " iMasterId [ValueMember], sCode [DisplayMember] ";

                        if (Tag[i].Display == 1)
                        {
                            column = " iMasterId [ValueMember], sName [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 2)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sCode, ' [ ', sName, ' ]') Else '' End  [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 3)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sName, ' [ ', sCode, ' ]') Else '' End  [DisplayMember] ";
                        }

                        string Cond = " bGroup = 0 ";
                        if (Tag[i].Display == 0)
                        {
                            Cond = " bGroup = 0 ";
                        }
                        else if (Tag[i].Display == 1)
                        {
                            Cond = " bGroup = 1 ";
                        }
                        else if (Tag[i].Display == 2)
                        {
                            Cond = "";
                        }


                        dt_Tag = GetMasterDataForComboBox(Tag[i].TagId, column, Cond);

                    }

                    cbx.DisplayMember = "DisplayMember";
                    cbx.ValueMember = "ValueMember";
                    cbx.DataSource = dt_Tag;

                }

                f.btnOk.Location = new Point(120, frmHeight + 130);
                f.btnClose.Location = new Point(200, frmHeight + 130);
                f.Height = frmHeight + 230;

                DialogResult dialogResult = f.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string iStartDate = Convert.ToString(FocusDateToInt(f.dtpStartDate.Value.ToString("yyyy/MM/dd")));
                    dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                    string iEndDate = Convert.ToString(FocusDateToInt(f.dtpEndDate.Value.ToString("yyyy/MM/dd")));
                    dt_DF.Rows.Add("2", "iEndDate", iEndDate);

                    for (int i = 0; i < Tag.Length; i++)
                    {
                        object objTag = f.Controls.Find("cbxTag" + Convert.ToString(i), true)[0];
                        ComboBox cbxTag = ((ComboBox)objTag);

                        dt_DF.Rows.Add(Convert.ToString(i + 3), "Tag" + Convert.ToString(Tag[i].TagId), Convert.ToString(cbxTag.SelectedValue));
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormDateOnly()");
        }
        finally
        {

        }
        return dt_DF;
    }



    /// <summary>
    /// Search Screen
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <param name="DateRange">Default Value = 0, 0 = DateRange, 1 = As On Date, 2 = As On Month, 3 = As On Year, -1 = Hide Date </param>
    /// <returns>DataTable</returns>

    public DataTable DefaultFormSearchByTags(string ScreenTitle, SearchByTags[] Tag, int DateRange = 0, string ReportName = "", string ProcedureName = "", bool MinimizeOption = true)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {

            //if (Tag.Length == 1)
            {
                frmSearchBy2Tag f = new frmSearchBy2Tag();
                f.Text = ScreenTitle;
                int frmHeight = 0;

                #region Date Fields

                f.dtpStartDate.Value = GetAccountingDate();
                if (DateRange == 0)             // DateRange
                {
                    f.dtpStartDate.Enabled = true;
                    f.pbxStartDate.Enabled = true;
                }
                else if (DateRange == 1)        // As On Date
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                }
                else if (DateRange == 2)        // As On Month
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                    f.dtpEndDate.CustomFormat = "MMM yyyy";
                }
                else if (DateRange == 3)        // As On Year
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                    f.dtpEndDate.CustomFormat = "yyyy";
                }
                else if (DateRange == -1)
                {

                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;

                    f.dtpEndDate.Enabled = false;
                    f.pbxEndDate.Enabled = false;

                    f.lblStartDate.Visible = false;
                    f.dtpStartDate.Visible = false;
                    f.pbxStartDate.Visible = false;

                    f.lblEndDate.Visible = false;
                    f.dtpEndDate.Visible = false;
                    f.pbxEndDate.Visible = false;
                }

                #endregion

                #region Single Selection ComboBox

                for (int i = 0; i < Tag.Length; i++)
                {
                    ComboBox cbx = new ComboBox();
                    cbx.Location = new System.Drawing.Point(160, (35 * i) + 82);
                    cbx.Width = 200;
                    cbx.Name = "cbxTag" + Convert.ToString(i);
                    cbx.Tag = Tag[i].TagId;
                    UIDesign(cbx);
                    f.Controls.Add(cbx);

                    Label lbl = new Label();
                    lbl.Location = new System.Drawing.Point(50, (35 * i) + 82);
                    lbl.Width = 200;
                    lbl.Name = "lbl" + Convert.ToString(i);
                    if (Convert.ToString(Tag[i].TagLabel) == null)
                    {
                        lbl.Text = GetNameOfTag(Tag[i].TagId);
                    }
                    else
                    {
                        lbl.Text = Convert.ToString(Tag[i].TagLabel);
                    }
                    UIDesign(lbl);
                    f.Controls.Add(lbl);

                    frmHeight = (35 * i);


                    DataTable dt_Tag = new DataTable();
                    if (Tag[i].UseQuery)
                    {
                        dt_Tag = GetDataTableAPI(Tag[i].Query);
                    }
                    else
                    {
                        string column = " iMasterId [ValueMember], sCode [DisplayMember] ";

                        if (Tag[i].Display == 1)
                        {
                            column = " iMasterId [ValueMember], sName [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 2)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sCode, ' [ ', sName, ' ]') Else '' End  [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 3)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sName, ' [ ', sCode, ' ]') Else '' End  [DisplayMember] ";
                        }

                        string Cond = " bGroup = 0 ";
                        if (Tag[i].ItemType == 0)
                        {
                            Cond = " bGroup = 0 ";
                        }
                        else if (Tag[i].ItemType == 1)
                        {
                            Cond = " bGroup = 1 ";
                        }
                        else if (Tag[i].ItemType == 2)
                        {
                            Cond = "";
                        }


                        dt_Tag = GetMasterDataForComboBox(Tag[i].TagId, column, Cond);

                    }

                    cbx.DisplayMember = "DisplayMember";
                    cbx.ValueMember = "ValueMember";
                    cbx.DataSource = dt_Tag;

                }

                #endregion

                #region Dynamic Form Size

                f.btnOk.Location = new Point(120, frmHeight + 130);
                f.btnClose.Location = new Point(200, frmHeight + 130);
                f.Height = frmHeight + 230;

                #endregion


                if (Convert.ToString(ReportName) != "" && Convert.ToString(ProcedureName) != "")
                {
                    f.lblReportName.Text = Convert.ToString(ReportName);
                    f.lblxspName.Text = Convert.ToString(ProcedureName);
                    f.MinimizeBox = MinimizeOption;
                    f.Show();
                }
                else
                {
                    DialogResult dialogResult = f.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        dt_DF = (DataTable)f.gvParam.DataSource;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormDateOnly()");
        }
        finally
        {

        }
        return dt_DF;
    }



    /// <summary>
    /// Search Screen
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <param name="DateRange">Default Value = 0, 0 = DateRange, 1 = As On Date, 2 = As On Month, 3 = As On Year, -1 = Hide Date </param>
    /// <returns>DataTable</returns>

    public DataTable DefaultFormSearchByTags(string ScreenTitle, SearchByTags[] Tag, int DateRange = 0)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {

            //if (Tag.Length == 1)
            {
                frmSearchBy2Tag f = new frmSearchBy2Tag();
                f.Text = ScreenTitle;
                int frmHeight = 0;

                #region Date Fields

                f.dtpStartDate.Value = GetAccountingDate();
                if (DateRange == 0)             // DateRange
                {
                    f.dtpStartDate.Enabled = true;
                    f.pbxStartDate.Enabled = true;
                }
                else if (DateRange == 1)        // As On Date
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                }
                else if (DateRange == 2)        // As On Month
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                    f.dtpEndDate.CustomFormat = "MMM yyyy";
                }
                else if (DateRange == 3)        // As On Year
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                    f.dtpEndDate.CustomFormat = "yyyy";
                }
                else if (DateRange == -1)
                {

                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;

                    f.dtpEndDate.Enabled = false;
                    f.pbxEndDate.Enabled = false;

                    f.lblStartDate.Visible = false;
                    f.dtpStartDate.Visible = false;
                    f.pbxStartDate.Visible = false;

                    f.lblEndDate.Visible = false;
                    f.dtpEndDate.Visible = false;
                    f.pbxEndDate.Visible = false;
                }

                #endregion

                #region Single Selection ComboBox

                for (int i = 0; i < Tag.Length; i++)
                {
                    ComboBox cbx = new ComboBox();
                    cbx.Location = new System.Drawing.Point(160, (35 * i) + 82);
                    cbx.Width = 200;
                    cbx.Name = "cbxTag" + Convert.ToString(i);
                    UIDesign(cbx);
                    f.Controls.Add(cbx);

                    Label lbl = new Label();
                    lbl.Location = new System.Drawing.Point(50, (35 * i) + 82);
                    lbl.Width = 200;
                    lbl.Name = "lbl" + Convert.ToString(i);
                    if (Convert.ToString(Tag[i].TagLabel) == null)
                    {
                        lbl.Text = GetNameOfTag(Tag[i].TagId);
                    }
                    else
                    {
                        lbl.Text = Convert.ToString(Tag[i].TagLabel);
                    }
                    UIDesign(lbl);
                    f.Controls.Add(lbl);

                    frmHeight = (35 * i);


                    DataTable dt_Tag = new DataTable();
                    if (Tag[i].UseQuery)
                    {
                        dt_Tag = GetDataTableAPI(Tag[i].Query);
                    }
                    else
                    {
                        string column = " iMasterId [ValueMember], sCode [DisplayMember] ";

                        if (Tag[i].Display == 1)
                        {
                            column = " iMasterId [ValueMember], sName [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 2)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sCode, ' [ ', sName, ' ]') Else '' End  [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 3)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sName, ' [ ', sCode, ' ]') Else '' End  [DisplayMember] ";
                        }

                        string Cond = " bGroup = 0 ";
                        if (Tag[i].ItemType == 0)
                        {
                            Cond = " bGroup = 0 ";
                        }
                        else if (Tag[i].ItemType == 1)
                        {
                            Cond = " bGroup = 1 ";
                        }
                        else if (Tag[i].ItemType == 2)
                        {
                            Cond = "";
                        }


                        dt_Tag = GetMasterDataForComboBox(Tag[i].TagId, column, Cond);

                    }

                    cbx.DisplayMember = "DisplayMember";
                    cbx.ValueMember = "ValueMember";
                    cbx.DataSource = dt_Tag;

                }

                #endregion

                #region Dynamic Form Size

                f.btnOk.Location = new Point(120, frmHeight + 130);
                f.btnClose.Location = new Point(200, frmHeight + 130);
                f.Height = frmHeight + 230;

                #endregion


                DialogResult dialogResult = f.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    dt_DF = (DataTable)f.gvParam.DataSource;

                    /*
                    string iStartDate = Convert.ToString(FocusDateToInt(f.dtpStartDate.Value.ToString("yyyy/MM/dd")));
                    string iEndDate = Convert.ToString(FocusDateToInt(f.dtpEndDate.Value.ToString("yyyy/MM/dd")));
                    if (DateRange == 2)        // As On Month
                    {
                        dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt(GetFirstDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                        dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt(GetLastDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                    }
                    else if (DateRange == 3)    // As On Year
                    {
                        dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/01/01"))));
                        dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/12/31"))));
                    }
                    else
                    {
                        dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                        dt_DF.Rows.Add("2", "iEndDate", iEndDate);
                    }


                    for (int i = 0; i < Tag.Length; i++)
                    {
                        object objTag = f.Controls.Find("cbxTag" + Convert.ToString(i), true)[0];
                        ComboBox cbxTag = ((ComboBox)objTag);
                        dt_DF.Rows.Add(Convert.ToString(i + 3), "Tag" + Convert.ToString(Tag[i].TagId), Convert.ToString(cbxTag.SelectedValue));
                    }
                    */
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormDateOnly()");
        }
        finally
        {

        }
        return dt_DF;
    }

    /// <summary>
    /// Search Screen
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="multiSelect">MultiSelectTags Array</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <param name="DateRange">Default Value = 0, 0 = DateRange, 1 = As On Date, 2 = As On Month, 3 = As On Year, -1 = Hide Date </param>
    /// <returns>DataTable</returns>
    public DataTable DefaultFormSearchByTags(string ScreenTitle, MultiSelectTags[] multiSelect, SearchByTags[] Tag, int DateRange = 0)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {
            frmMultiSearch f = new frmMultiSearch();
            f.Text = ScreenTitle;

            #region Date Fields

            f.dtpStartDate.Value = GetAccountingDate();
            if (DateRange == 0)             // DateRange
            {
                f.dtpStartDate.Enabled = true;
                f.pbxStartDate.Enabled = true;
            }
            else if (DateRange == 1)        // As On Date
            {
                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;
            }
            else if (DateRange == 2)        // As On Month
            {
                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;
                f.dtpEndDate.CustomFormat = "MMM yyyy";
            }
            else if (DateRange == 3)        // As On Year
            {
                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;
                f.dtpEndDate.CustomFormat = "yyyy";
            }
            else if (DateRange == -1)
            {

                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;

                f.dtpEndDate.Enabled = false;
                f.pbxEndDate.Enabled = false;

                f.lblStartDate.Visible = false;
                f.dtpStartDate.Visible = false;
                f.pbxStartDate.Visible = false;

                f.lblEndDate.Visible = false;
                f.dtpEndDate.Visible = false;
                f.pbxEndDate.Visible = false;
            }

            #endregion

            #region Multi Selection ComboBox
            f.tabMultiSearch.TabPages.Remove(f.tabPg0);
            f.tabMultiSearch.TabPages.Remove(f.tabPg1);
            for (int i = 0; i < multiSelect.Length; i++)
            {
                DataTable dt_Tag = new DataTable();
                #region Tab0
                if (i == 0)
                {
                    f.tabMultiSearch.TabPages.Add(f.tabPg0);
                    if (multiSelect[i].TagId > 0)
                    {
                        if (Convert.ToString(multiSelect[i].TagLabel) == null)
                        {
                            f.tabPg0.Text = GetNameOfTag(multiSelect[i].TagId);
                            f.tabPg0.Tag = multiSelect[i].TagId;
                        }
                        else
                        {
                            f.tabPg0.Text = Convert.ToString(multiSelect[i].TagLabel);
                        }


                        if (multiSelect[i].UseQuery)
                        {
                            dt_Tag = GetDataTableAPI(multiSelect[i].Query);
                            f.lblIdColumnNamePg0.Text = multiSelect[i].IdColumnName;

                            TreeNode tv = new TreeNode();
                            tv.Text = Convert.ToString(multiSelect[i].TagLabel);
                            tv.Tag = "-1";
                            f.trv0.Nodes.Add(tv);
                        }
                        else
                        {
                            TreeNode tv = new TreeNode();
                            tv.Text = GetNameOfTag(multiSelect[i].TagId);
                            f.trv0.Nodes.Add("0", GetNameOfTag(multiSelect[i].TagId));

                            string column = " sName [Name], sCode [Code], iMasterId [iMasterId] ";
                            f.lblIdColumnNamePg0.Text = "iMasterId";

                            string Cond = " iMasterId > 0 and bGroup = 0 ";
                            if (multiSelect[i].ItemType == 0)
                            {
                                Cond = " iMasterId > 0 and bGroup = 0 ";
                            }
                            else if (multiSelect[i].ItemType == 1)
                            {
                                Cond = " iMasterId > 0 and bGroup = 1 ";
                            }
                            else if (multiSelect[i].ItemType == 2)
                            {
                                Cond = "";
                            }
                            dt_Tag = GetMasterDataForComboBox(multiSelect[i].TagId, column, Cond);
                        }

                    }
                    else
                    {
                        if (multiSelect[i].UseQuery)
                        {
                            f.tabPg0.Text = "Search";
                            dt_Tag = GetDataTableAPI(multiSelect[i].Query);
                            f.lblIdColumnNamePg0.Text = multiSelect[i].IdColumnName;
                        }
                    }

                    if (dt_Tag.Rows.Count > 0)
                    {
                        f.gvListPg0.DataSource = dt_Tag;
                        ReadOnlyGVColumns(f.gvListPg0, new int[] { 0 });
                        //GVRowNo(f.gvListPg0);
                    }
                }
                #endregion

                #region Tab1
                else if (i == 1)
                {
                    f.tabMultiSearch.TabPages.Add(f.tabPg1);
                    if (multiSelect[i].TagId > 0)
                    {
                        if (Convert.ToString(multiSelect[i].TagLabel) == null)
                        {
                            f.tabPg1.Text = GetNameOfTag(multiSelect[i].TagId);
                            f.tabPg1.Tag = multiSelect[i].TagId;
                        }
                        else
                        {
                            f.tabPg1.Text = Convert.ToString(multiSelect[i].TagLabel);
                        }


                        if (multiSelect[i].UseQuery)
                        {
                            dt_Tag = GetDataTableAPI(multiSelect[i].Query);
                            f.lblIdColumnNamePg1.Text = multiSelect[i].IdColumnName;

                            TreeNode tv = new TreeNode();
                            tv.Text = Convert.ToString(multiSelect[i].TagLabel);
                            tv.Tag = "-1";
                            f.trv1.Nodes.Add(tv);
                        }
                        else
                        {
                            TreeNode tv = new TreeNode();
                            tv.Text = GetNameOfTag(multiSelect[i].TagId);
                            f.trv1.Nodes.Add("0", GetNameOfTag(multiSelect[i].TagId));

                            string column = " sName [Name], sCode [Code], iMasterId [iMasterId] ";
                            f.lblIdColumnNamePg1.Text = "iMasterId";

                            string Cond = " iMasterId > 0 and bGroup = 0 ";
                            if (multiSelect[i].ItemType == 0)
                            {
                                Cond = " iMasterId > 0 and bGroup = 0 ";
                            }
                            else if (multiSelect[i].ItemType == 1)
                            {
                                Cond = " iMasterId > 0 and bGroup = 1 ";
                            }
                            else if (multiSelect[i].ItemType == 2)
                            {
                                Cond = "";
                            }
                            dt_Tag = GetMasterDataForComboBox(multiSelect[i].TagId, column, Cond);
                        }

                    }
                    else
                    {
                        if (multiSelect[i].UseQuery)
                        {
                            f.tabPg0.Text = "Search";
                            dt_Tag = GetDataTableAPI(multiSelect[i].Query);
                            f.lblIdColumnNamePg1.Text = multiSelect[i].IdColumnName;
                        }
                    }

                    if (dt_Tag.Rows.Count > 0)
                    {
                        f.gvListPg1.DataSource = dt_Tag;
                        ReadOnlyGVColumns(f.gvListPg1, new int[] { 0 });
                        //GVRowNo(f.gvListPg1);
                    }
                }
                #endregion
            }

            #endregion

            #region Single Selection ComboBox

            for (int i = 0; i < Tag.Length; i++)
            {

                ComboBox cbx = new ComboBox();
                cbx.Location = new System.Drawing.Point(105, (35 * i) + 95);
                cbx.Width = 200;
                cbx.Name = "cbxTag" + Convert.ToString(i);
                cbx.BringToFront();
                UIDesign(cbx);
                f.gbx.Controls.Add(cbx);

                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(8, (35 * i) + 99);
                lbl.Width = 200;
                lbl.Name = "lbl" + Convert.ToString(i);
                if (Convert.ToString(Tag[i].TagLabel) == null)
                {
                    lbl.Text = GetNameOfTag(Tag[i].TagId);
                }
                else
                {
                    lbl.Text = Convert.ToString(Tag[i].TagLabel);
                }
                lbl.BringToFront();
                UIDesign(lbl);
                f.gbx.Controls.Add(lbl);

                DataTable dt_Tag = new DataTable();
                if (Tag[i].UseQuery)
                {
                    dt_Tag = GetDataTableAPI(Tag[i].Query);
                }
                else
                {
                    string column = " iMasterId [ValueMember], sCode [DisplayMember] ";

                    if (Tag[i].Display == 1)
                    {
                        column = " iMasterId [ValueMember], sName [DisplayMember] ";
                    }
                    else if (Tag[i].Display == 2)
                    {
                        column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sCode, ' [ ', sName, ' ]') Else '' End  [DisplayMember] ";
                    }
                    else if (Tag[i].Display == 3)
                    {
                        column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sName, ' [ ', sCode, ' ]') Else '' End  [DisplayMember] ";
                    }

                    string Cond = " bGroup = 0 ";
                    if (Tag[i].ItemType == 0)
                    {
                        Cond = " bGroup = 0 ";
                    }
                    else if (Tag[i].ItemType == 1)
                    {
                        Cond = " bGroup = 1 ";
                    }
                    else if (Tag[i].ItemType == 2)
                    {
                        Cond = "";
                    }


                    dt_Tag = GetMasterDataForComboBox(Tag[i].TagId, column, Cond);

                }

                cbx.DisplayMember = "DisplayMember";
                cbx.ValueMember = "ValueMember";
                cbx.DataSource = dt_Tag;
            }

            #endregion


            DialogResult dialogResult = f.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string iStartDate = Convert.ToString(FocusDateToInt(f.dtpStartDate.Value.ToString("yyyy/MM/dd")));
                string iEndDate = Convert.ToString(FocusDateToInt(f.dtpEndDate.Value.ToString("yyyy/MM/dd")));

                if (DateRange == 2)        // As On Month
                {
                    dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt(GetFirstDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                    dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt(GetLastDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                }
                else if (DateRange == 3)    // As On Year
                {
                    dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/01/01"))));
                    dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/12/31"))));
                }
                else
                {
                    dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                    dt_DF.Rows.Add("2", "iEndDate", iEndDate);
                }



                for (int i = 0; i < multiSelect.Length; i++)
                {
                    if (i == 0)
                    {
                        dt_DF.Rows.Add(Convert.ToString(i + 3), "MultiSelectTag" + Convert.ToString(multiSelect[i].TagId), Convert.ToString(f.lblSelectedIdPg0.Text.Trim()).Replace("$", ""));
                    }
                    else if (i == 1)
                    {
                        dt_DF.Rows.Add(Convert.ToString(i + 3), "MultiSelectTag" + Convert.ToString(multiSelect[i].TagId), Convert.ToString(f.lblSelectedIdPg1.Text.Trim()).Replace("$", ""));
                    }

                }

                for (int i = 0; i < Tag.Length; i++)
                {
                    object objTag = f.Controls.Find("cbxTag" + Convert.ToString(i), true)[0];
                    ComboBox cbxTag = ((ComboBox)objTag);
                    dt_DF.Rows.Add(Convert.ToString(i + multiSelect.Length + 3), "Tag" + Convert.ToString(Tag[i].TagId), Convert.ToString(cbxTag.SelectedValue));
                }

            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormDateOnly()");
        }
        finally
        {

        }
        return dt_DF;
    }

    /// <summary>
    /// Search Screen
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="multiSelect">MultiSelectTags Array</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <param name="DateRange">Default Value = 0, 0 = DateRange, 1 = As On Date, 2 = As On Month, 3 = As On Year, -1 = Hide Date </param>
    /// <returns>DataTable</returns>
    public DataTable DefaultFormSearchByTagsGv(string ScreenTitle, MultiSelectTags[] multiSelect, SearchByTags[] Tag, int DateRange = 0)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {
            frmMultiSearchGv f = new frmMultiSearchGv();
            f.Text = ScreenTitle;

            #region Date Fields

            f.dtpStartDate.Value = GetAccountingDate();
            if (DateRange == 0)             // DateRange
            {
                f.dtpStartDate.Enabled = true;
                f.pbxStartDate.Enabled = true;
            }
            else if (DateRange == 1)        // As On Date
            {
                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;
            }
            else if (DateRange == 2)        // As On Month
            {
                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;
                f.dtpEndDate.CustomFormat = "MMM yyyy";
            }
            else if (DateRange == 3)        // As On Year
            {
                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;
                f.dtpEndDate.CustomFormat = "yyyy";
            }
            else if (DateRange == -1)
            {

                f.dtpStartDate.Enabled = false;
                f.pbxStartDate.Enabled = false;

                f.dtpEndDate.Enabled = false;
                f.pbxEndDate.Enabled = false;

                f.lblStartDate.Visible = false;
                f.dtpStartDate.Visible = false;
                f.pbxStartDate.Visible = false;

                f.lblEndDate.Visible = false;
                f.dtpEndDate.Visible = false;
                f.pbxEndDate.Visible = false;
            }

            #endregion

            #region Multi Selection ComboBox

            for (int i = 0; i < multiSelect.Length; i++)
            {
                string index = Convert.ToString(i);
                DataTable dt_Tag = new DataTable();
                TabPage tabPg = new TabPage();
                tabPg.BackColor = ColorTranslator.FromHtml("#d5d9b7");
                tabPg.Name = "tabPg" + index;
                if (multiSelect[i].TagId > 0)
                {
                    tabPg.Text = GetNameOfTag(multiSelect[i].TagId);
                    tabPg.Tag = multiSelect[i].TagId;
                }
                else
                {
                    tabPg.Text = Convert.ToString(multiSelect[i].TagLabel);
                }

                #region Hidden Field
                #region TagId TextBox

                TextBox hdnSelected = new TextBox();
                hdnSelected.Name = "hdnTagId" + index;
                hdnSelected.Tag = index;
                hdnSelected.Multiline = true;
                hdnSelected.Text = "0";
                hdnSelected.Visible = false;
                hdnSelected.Location = new Point(50, 10);

                UIDesign(hdnSelected);
                tabPg.Controls.Add(hdnSelected);

                #endregion
                #endregion

                #region Search TextBox

                TextBox txtSearch = new TextBox();
                txtSearch.Name = "txtSearch" + index;
                txtSearch.Tag = index;
                txtSearch.Width = 250;
                txtSearch.Location = new Point(10, 10);

                // now bind it with textchanged event
                txtSearch.TextChanged += txtSearch_TextChanged;

                txtSearch.LostFocus += txtSearch_LostFocus;

                UIDesign(txtSearch);
                tabPg.Controls.Add(txtSearch);

                #endregion

                #region Group

                CheckBox chkGroup = new CheckBox();
                chkGroup.Name = "chkGroup" + index;
                chkGroup.Tag = index;
                chkGroup.Text = "Group";
                chkGroup.Location = new Point(280, 10);

                // now bind it with CheckedChanged event
                chkGroup.CheckedChanged += chkGroup_CheckedChanged;


                UIDesign(chkGroup);
                tabPg.Controls.Add(chkGroup);

                #endregion


                #region Orignal DataGridView 

                DataGridView gvOrignal = new DataGridView();
                gvOrignal.Name = "gvOrignal" + index;
                gvOrignal.Location = new Point(10, 15);
                gvOrignal.Visible = false;

                gvOrignal.AllowUserToAddRows = false;
                gvOrignal.AllowUserToDeleteRows = false;

                DataTable dt_gv = new DataTable();
                if (multiSelect[i].UseQuery)
                {
                    chkGroup.Checked = false;
                    chkGroup.Enabled = false;
                    dt_gv = GetDataTableAPI(multiSelect[i].Query);
                }
                else
                {
                    chkGroup.Checked = false;
                    if (multiSelect[i].ItemType == 1)
                    {
                        chkGroup.Checked = true;
                    }
                    dt_gv = MultiTag_DataTable(multiSelect[i].TagId, multiSelect[i].ItemType);

                }

                if (dt_gv.Rows.Count > 0)
                {
                    gvOrignal.DataSource = dt_gv;
                    ReadOnlyGVColumns(gvOrignal, new int[] { 0 });
                    //GVRowNo(f.gvListPg0);
                }

                UIDesign(gvOrignal);
                tabPg.Controls.Add(gvOrignal);

                #endregion

                #region Search DataGridView

                DataGridView gvSearch = new DataGridView();
                gvSearch.Name = "gvSearch" + index;
                gvSearch.Tag = index;
                gvSearch.Location = new Point(10, 30);
                gvSearch.Visible = false;

                gvSearch.Width = dt_gv.Columns.Count * 100;

                gvSearch.AllowUserToAddRows = false;
                gvSearch.AllowUserToDeleteRows = false;

                gvSearch.CellDoubleClick += gvSearch_CellDoubleClick;
                gvSearch.Leave += gvSearch_Leave;

                UIDesign(gvSearch);
                tabPg.Controls.Add(gvSearch);
                #endregion

                #region Selected DataGridView

                DataGridView gvSelected = new DataGridView();
                gvSelected.Name = "gvSelected" + index;
                gvSelected.Location = new Point(10, 40);
                gvSelected.Width = 720;

                gvSelected.AllowUserToAddRows = false;
                //gvSelected.AllowUserToDeleteRows = false;


                gvSelected.DataSource = dt_gv.Clone();
                //gvSelected.DataSource = null;


                UIDesign(gvSelected);
                tabPg.Controls.Add(gvSelected);
                #endregion


                f.tabMultiSearch.TabPages.Add(tabPg);
            }

            #endregion

            #region Single Selection ComboBox

            for (int i = 0; i < Tag.Length; i++)
            {

                ComboBox cbx = new ComboBox();
                cbx.Location = new System.Drawing.Point(105, (35 * i) + 95);
                cbx.Width = 200;
                cbx.Name = "cbxTag" + Convert.ToString(i);
                cbx.BringToFront();
                UIDesign(cbx);
                f.gbx.Controls.Add(cbx);

                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(8, (35 * i) + 99);
                lbl.Width = 200;
                lbl.Name = "lbl" + Convert.ToString(i);
                if (Convert.ToString(Tag[i].TagLabel) == null)
                {
                    lbl.Text = GetNameOfTag(Tag[i].TagId);
                }
                else
                {
                    lbl.Text = Convert.ToString(Tag[i].TagLabel);
                }
                lbl.BringToFront();
                UIDesign(lbl);
                f.gbx.Controls.Add(lbl);

                DataTable dt_Tag = new DataTable();
                if (Tag[i].UseQuery)
                {
                    dt_Tag = GetDataTableAPI(Tag[i].Query);
                }
                else
                {
                    string column = " iMasterId [ValueMember], sCode [DisplayMember] ";

                    if (Tag[i].Display == 1)
                    {
                        column = " iMasterId [ValueMember], sName [DisplayMember] ";
                    }
                    else if (Tag[i].Display == 2)
                    {
                        column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sCode, ' [ ', sName, ' ]') Else '' End  [DisplayMember] ";
                    }
                    else if (Tag[i].Display == 3)
                    {
                        column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sName, ' [ ', sCode, ' ]') Else '' End  [DisplayMember] ";
                    }

                    string Cond = " bGroup = 0 ";
                    if (Tag[i].ItemType == 0)
                    {
                        Cond = " bGroup = 0 ";
                    }
                    else if (Tag[i].ItemType == 1)
                    {
                        Cond = " bGroup = 1 ";
                    }
                    else if (Tag[i].ItemType == 2)
                    {
                        Cond = "";
                    }


                    dt_Tag = GetMasterDataForComboBox(Tag[i].TagId, column, Cond);

                }

                cbx.DisplayMember = "DisplayMember";
                cbx.ValueMember = "ValueMember";
                cbx.DataSource = dt_Tag;
            }

            #endregion


            DialogResult dialogResult = f.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string iStartDate = Convert.ToString(FocusDateToInt(f.dtpStartDate.Value.ToString("yyyy/MM/dd")));
                string iEndDate = Convert.ToString(FocusDateToInt(f.dtpEndDate.Value.ToString("yyyy/MM/dd")));

                if (DateRange == 2)        // As On Month
                {
                    dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt(GetFirstDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                    dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt(GetLastDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                }
                else if (DateRange == 3)    // As On Year
                {
                    dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/01/01"))));
                    dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/12/31"))));
                }
                else
                {
                    dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                    dt_DF.Rows.Add("2", "iEndDate", iEndDate);
                }



                string strGroup = "";
                string strNode = "";
                for (int i = 0; i < multiSelect.Length; i++)
                {
                    strNode = "0";
                    strGroup = "0";
                    object objgvSelected = f.tabMultiSearch.Controls.Find("gvSelected" + Convert.ToString(i), true)[0];

                    DataGridView gvSelected = (DataGridView)objgvSelected;
                    DataTable dt_Sel = new DataTable();
                    dt_Sel = (DataTable)gvSelected.DataSource;
                    if (dt_Sel.Rows.Count > 0)
                    {
                        object objchkGroup = f.tabMultiSearch.Controls.Find("chkGroup" + Convert.ToString(i), true)[0];
                        CheckBox chkGroup = (CheckBox)objchkGroup;
                        if (chkGroup.Enabled)
                        {
                            for (int r = 0; r < dt_Sel.Rows.Count; r++)
                            {
                                if (Convert.ToString(dt_Sel.Rows[r]["Group"]) == "0")
                                {
                                    strNode = strNode + "," + Convert.ToString(dt_Sel.Rows[r]["iMasterId"]);
                                }
                                else
                                {
                                    strGroup = strGroup + "," + Convert.ToString(dt_Sel.Rows[r]["iMasterId"]);
                                }
                            }
                        }
                        else
                        {
                            for (int r = 0; r < dt_Sel.Rows.Count; r++)
                            {
                                strNode = strNode + "," + Convert.ToString(dt_Sel.Rows[r][dt_Sel.Columns.Count - 1]);
                            }
                        }
                    }

                    dt_DF.Rows.Add(Convert.ToString(i + 3), "MultiSelectTag" + Convert.ToString(multiSelect[i].TagId) + "_Node", strNode);
                    dt_DF.Rows.Add(Convert.ToString(i + 3), "MultiSelectTag" + Convert.ToString(multiSelect[i].TagId) + "_Group", strGroup);

                    //if (i == 0)
                    //{
                    //    dt_DF.Rows.Add(Convert.ToString(i + 3), "MultiSelectTag" + Convert.ToString(multiSelect[i].TagId), Convert.ToString(f.lblSelectedIdPg0.Text.Trim()).Replace("$", ""));
                    //}
                    //else if (i == 1)
                    //{
                    //    dt_DF.Rows.Add(Convert.ToString(i + 3), "MultiSelectTag" + Convert.ToString(multiSelect[i].TagId), Convert.ToString(f.lblSelectedIdPg1.Text.Trim()).Replace("$", ""));
                    //}

                }


                for (int i = 0; i < Tag.Length; i++)
                {
                    object objTag = f.Controls.Find("cbxTag" + Convert.ToString(i), true)[0];
                    ComboBox cbxTag = ((ComboBox)objTag);
                    dt_DF.Rows.Add(Convert.ToString(i + multiSelect.Length + 3), "Tag" + Convert.ToString(Tag[i].TagId), Convert.ToString(cbxTag.SelectedValue));
                }

            }

        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormSearchByTagsGv()");
        }
        finally
        {

        }
        return dt_DF;
    }







    public DataTable DefaultFormDetailedMultiGVRpt(string ScreenTitle, SearchByTags[] Tag, string ProcedureName, int DateRange = 0, bool SelectOption = false)
    {
        DataTable dt_DF = new DataTable();
        dt_DF.Columns.Add("RowNo");
        dt_DF.Columns.Add("Param");
        dt_DF.Columns.Add("Value");
        try
        {

            //if (Tag.Length == 1)
            {
                frmDetailedMultiGvRpt f = new frmDetailedMultiGvRpt();
                f.Text = ScreenTitle;
                f.btnSearch.Tag = ProcedureName;
                f.chkAll.Visible = SelectOption;

                int frmHeight = 0;

                #region Date Fields

                int YLoc1 = 95;
                int YLoc2 = 99;

                f.dtpStartDate.Value = GetAccountingDate();
                if (DateRange == 0)             // DateRange
                {
                    f.dtpStartDate.Enabled = true;
                    f.pbxStartDate.Enabled = true;
                }
                else if (DateRange == 1)        // As On Date
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                }
                else if (DateRange == 2)        // As On Month
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                    f.dtpEndDate.CustomFormat = "MMM yyyy";
                }
                else if (DateRange == 3)        // As On Year
                {
                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;
                    f.dtpEndDate.CustomFormat = "yyyy";
                }
                else if (DateRange == -1)
                {

                    f.dtpStartDate.Enabled = false;
                    f.pbxStartDate.Enabled = false;

                    f.dtpEndDate.Enabled = false;
                    f.pbxEndDate.Enabled = false;

                    f.lblStartDate.Visible = false;
                    f.dtpStartDate.Visible = false;
                    f.pbxStartDate.Visible = false;

                    f.lblEndDate.Visible = false;
                    f.dtpEndDate.Visible = false;
                    f.pbxEndDate.Visible = false;

                    YLoc1 = 25;
                    YLoc2 = 29;
                }

                #endregion

                #region Single Selection ComboBox

                for (int i = 0; i < Tag.Length; i++)
                {
                    ComboBox cbx = new ComboBox();
                    cbx.Location = new System.Drawing.Point(105, (35 * i) + YLoc1);
                    cbx.Width = 200;
                    cbx.Tag = Tag[i].TagId;
                    cbx.Name = "cbxTag" + Convert.ToString(i);

                    cbx.SelectedIndexChanged += new System.EventHandler(f.cbx_SelectedValueChanged);

                    cbx.BringToFront();
                    UIDesign(cbx);
                    f.gbx.Controls.Add(cbx);

                    Label lbl = new Label();
                    lbl.Location = new System.Drawing.Point(8, (35 * i) + YLoc2);
                    lbl.Width = 200;
                    lbl.Name = "lbl" + Convert.ToString(i);
                    lbl.BringToFront();
                    if (Convert.ToString(Tag[i].TagLabel) == null)
                    {
                        lbl.Text = GetNameOfTag(Tag[i].TagId);
                    }
                    else
                    {
                        lbl.Text = Convert.ToString(Tag[i].TagLabel);
                    }
                    UIDesign(lbl);
                    f.gbx.Controls.Add(lbl);

                    frmHeight = (35 * i);


                    DataTable dt_Tag = new DataTable();
                    if (Tag[i].UseQuery)
                    {
                        dt_Tag = GetDataTableAPI(Tag[i].Query);
                    }
                    else
                    {
                        string column = " iMasterId [ValueMember], sCode [DisplayMember] ";

                        if (Tag[i].Display == 1)
                        {
                            column = " iMasterId [ValueMember], sName [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 2)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sCode, ' [ ', sName, ' ]') Else '' End  [DisplayMember] ";
                        }
                        else if (Tag[i].Display == 3)
                        {
                            column = " iMasterId [ValueMember], Case When iMasterId > 0 Then CONCAT(sName, ' [ ', sCode, ' ]') Else '' End  [DisplayMember] ";
                        }

                        string Cond = " bGroup = 0 ";
                        if (Tag[i].ItemType == 0)
                        {
                            Cond = " bGroup = 0 ";
                        }
                        else if (Tag[i].ItemType == 1)
                        {
                            Cond = " bGroup = 1 ";
                        }
                        else if (Tag[i].ItemType == 2)
                        {
                            Cond = "";
                        }


                        dt_Tag = GetMasterDataForComboBox(Tag[i].TagId, column, Cond);

                    }

                    cbx.DisplayMember = "DisplayMember";
                    cbx.ValueMember = "ValueMember";
                    cbx.DataSource = dt_Tag;

                }

                #endregion

                #region Dynamic Form Size

                //f.btnOk.Location = new Point(120, frmHeight + 130);
                //f.btnClose.Location = new Point(200, frmHeight + 130);
                //f.Height = frmHeight + 230;

                #endregion


                f.ShowDialog();


                /*
                DialogResult dialogResult = f.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string iStartDate = Convert.ToString(FocusDateToInt(f.dtpStartDate.Value.ToString("yyyy/MM/dd")));
                    string iEndDate = Convert.ToString(FocusDateToInt(f.dtpEndDate.Value.ToString("yyyy/MM/dd")));
                    if (DateRange == 2)        // As On Month
                    {
                        dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt(GetFirstDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                        dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt(GetLastDayOfMonth(f.dtpEndDate.Value).ToString("yyyy/MM/dd"))));
                    }
                    else if (DateRange == 3)    // As On Year
                    {
                        dt_DF.Rows.Add("1", "iStartDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/01/01"))));
                        dt_DF.Rows.Add("2", "iEndDate", Convert.ToString(FocusDateToInt((Convert.ToString(f.dtpEndDate.Value.Year) + "/12/31"))));
                    }
                    else
                    {
                        dt_DF.Rows.Add("1", "iStartDate", iStartDate);
                        dt_DF.Rows.Add("2", "iEndDate", iEndDate);
                    }


                    for (int i = 0; i < Tag.Length; i++)
                    {
                        object objTag = f.Controls.Find("cbxTag" + Convert.ToString(i), true)[0];
                        ComboBox cbxTag = ((ComboBox)objTag);
                        dt_DF.Rows.Add(Convert.ToString(i + 3), "Tag" + Convert.ToString(Tag[i].TagId), Convert.ToString(cbxTag.SelectedValue));
                    }
                }

                */
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DefaultFormDateOnly()");
        }
        finally
        {

        }
        return dt_DF;
    }

    private void cbx_SelectedValueChanged(object sender, EventArgs e)
    {
        //Do something here.
    }










    private DataTable MultiTag_DataTable(int TagId, int ItemType)
    {
        DataTable dt_MT = new DataTable();
        try
        {
            string column = " sName [Name], sCode [Code], Convert(int,bGroup) [Group], iMasterId [iMasterId] ";
            string Cond = " iMasterId > 0 and bGroup = 0 ";

            if (ItemType == 0)
            {
                Cond = " iMasterId > 0 and bGroup = 0 ";
            }
            else if (ItemType == 1)
            {
                Cond = " iMasterId > 0 and bGroup = 1 ";
            }
            else if (ItemType == 2)
            {
                Cond = "";
            }
            dt_MT = GetMasterDataForComboBox(TagId, column, Cond);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.MultiTag_DataTable()");
        }
        return dt_MT;
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //frmMultiSearchGv f = new frmMultiSearchGv();

            TextBox txtSearch = (TextBox)sender;
            string Name = txtSearch.Name;
            string Index = Convert.ToString(txtSearch.Tag);
            string Text = txtSearch.Text;

            string tabPg_Name = "tabPg" + Index;

            string txtSearch_Name = "txtSearch" + Index;
            string gvOrignal_Name = "gvOrignal" + Index;
            string gvSearch_Name = "gvSearch" + Index;

            DataTable dt_Org = new DataTable();

            Control tabPg = ((Control)sender).Parent;

            foreach (Control ctl in tabPg.Controls)
            {
                if (ctl.Name == gvOrignal_Name)
                {
                    DataGridView gvOrignal = (DataGridView)ctl;
                    dt_Org = (DataTable)gvOrignal.DataSource;
                }
                else if (ctl.Name == gvSearch_Name)
                {
                    DataGridView gvSearch = (DataGridView)ctl;
                    gvSearch.Visible = true;
                    DataTable dt_Srh = new DataTable();

                    if (Text.Trim() != "")
                    {
                        dt_Srh = DataTable_Search(dt_Org, Text.Trim());
                    }
                    else
                    {
                        dt_Srh = dt_Org;
                    }
                    gvSearch.DataSource = dt_Srh;


                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.txtSearch_TextChanged()");
        }
    }

    private void chkGroup_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkGroup = (CheckBox)sender;
            string Name = chkGroup.Name;
            string Index = Convert.ToString(chkGroup.Tag);

            Control tabPg = ((Control)sender).Parent;

            int TagId = Convert.ToInt32(tabPg.Tag);
            int ItemType = 0;
            if (chkGroup.Checked)
            {
                ItemType = 1;
            }

            DataTable dt_gv = new DataTable();
            dt_gv = MultiTag_DataTable(TagId, ItemType);

            string tabPg_Name = "tabPg" + Index;

            string txtSearch_Name = "txtSearch" + Index;
            string gvOrignal_Name = "gvOrignal" + Index;
            string gvSearch_Name = "gvSearch" + Index;

            foreach (Control ctl in tabPg.Controls)
            {
                if (ctl.Name == gvOrignal_Name)
                {
                    DataGridView gvOrignal = (DataGridView)ctl;
                    gvOrignal.DataSource = dt_gv;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.txtSearch_TextChanged()");
        }
    }

    private void txtSearch_LostFocus(object sender, EventArgs e)
    {
        try
        {
            TextBox txtSearch = (TextBox)sender;
            string Index = Convert.ToString(txtSearch.Tag);
            //txtSearch.Text = "";
            string gvSearch_Name = "gvSearch" + Index;

            Control tabPg = ((Control)sender).Parent;
            //foreach (Control ctl in tabPg.Controls)
            //{
            //    if (ctl.Name == gvSearch_Name)
            //    {
            //        DataGridView gvSearch = (DataGridView)ctl;
            //        gvSearch.Visible = false;

            //    }
            //}
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.txtSearch_LostFocus()");
        }
    }

    private void gvSearch_CellDoubleClick(object sender, EventArgs e)
    {
        try
        {
            DataGridView gvSearch = (DataGridView)sender;
            string Index = Convert.ToString(gvSearch.Tag);
            DataGridViewRow gvR = new DataGridViewRow();
            gvR = gvSearch.Rows[((DataGridViewCellEventArgs)e).RowIndex];
            DataTable dt_1 = new DataTable();
            string gvSelected_Name = "gvSelected" + Index;

            DataRow row = (gvR.DataBoundItem as DataRowView).Row;


            Control tabPg = ((Control)sender).Parent;
            foreach (Control ctl in tabPg.Controls)
            {
                if (ctl.Name == gvSelected_Name)
                {
                    DataGridView gvSelected = (DataGridView)ctl;

                    dt_1 = ((DataTable)(gvSelected.DataSource)).Clone();

                    dt_1.Rows.Add(row.ItemArray);

                    if (gvSelected.Rows.Count > 0)
                    {
                        dt_1.Merge((DataTable)(gvSelected.DataSource));
                    }

                    gvSelected.DataSource = dt_1;
                }
            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.gvSearch_CellDoubleClick()");
        }
    }

    private void gvSearch_Leave(object sender, EventArgs e)
    {
        try
        {
            DataGridView gvSearch = (DataGridView)sender;

            gvSearch.Visible = false;
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.gvSearch_Leave()");
        }
    }

    /// <summary>
    /// Search Screen
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <param name="DateRange">Default Value = 0, 0 = DateRange, 1 = As On Date, 2 = As On Month, 3 = As On Year, -1 = Hide Date </param>
    /// <returns>string in XML Format</returns>
    public string DefaultFormSearchByTags_xml(string ScreenTitle, SearchByTags[] Tag, int DateRange = 0)
    {
        string Result = "";
        try
        {
            DataTable dt = new DataTable();
            dt = DefaultFormSearchByTags(ScreenTitle, Tag, DateRange);

            Result = "<xml>";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RowNo = ""; string Param = ""; string Value = "";
                    RowNo = "RowNo" + Convert.ToString(dt.Rows[i]["RowNo"]);
                    Param = Convert.ToString(dt.Rows[i]["Param"]);
                    Value = Convert.ToString(dt.Rows[i]["Value"]);

                    Result = Result + "<" + RowNo + "><" + Param + ">" + Value + "</" + Param + "></" + RowNo + ">";
                }
            }
            Result = Result + "</xml>";
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.DefaultFormSearchByTags_xml()");
        }
        return Result;
    }

    /// <summary>
    /// Search Screen 
    /// </summary>
    /// <param name="ScreenTitle">Screen Title</param>
    /// <param name="multiSelect">MultiSelectTags Array</param>
    /// <param name="Tag">SearchByTags Array</param>
    /// <param name="DateRange">Default Value = 0, 0 = DateRange, 1 = As On Date, 2 = As On Month, 3 = As On Year, -1 = Hide Date </param>
    /// /// <param name="SearchType">Default Value = 0, 0 = Tree View Search, 1 = Grid View Search </param>
    /// <returns>string in XML Format</returns>
    public string DefaultFormSearchByTags_xml(string ScreenTitle, MultiSelectTags[] multiSelect, SearchByTags[] Tag, int DateRange = 0, int SearchType = 0)
    {
        string Result = "";
        try
        {
            DataTable dt = new DataTable();
            if (SearchType == 1)
            {
                dt = DefaultFormSearchByTagsGv(ScreenTitle, multiSelect, Tag, DateRange);
            }
            else
            {
                dt = DefaultFormSearchByTags(ScreenTitle, multiSelect, Tag, DateRange);
            }

            Result = "<xml>";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RowNo = ""; string Param = ""; string Value = "";
                    RowNo = "RowNo" + Convert.ToString(dt.Rows[i]["RowNo"]);
                    Param = Convert.ToString(dt.Rows[i]["Param"]);
                    Value = Convert.ToString(dt.Rows[i]["Value"]);

                    Result = Result + "<" + RowNo + "><" + Param + ">" + Value + "</" + Param + "></" + RowNo + ">";
                }
            }
            Result = Result + "</xml>";
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.DefaultFormSearchByTags_xml()");
        }
        return Result;
    }


    public string DataTableToXML(DataTable dt)
    {
        string Result = "";
        try
        {
            Result = "<xml>";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RowNo = ""; string Param = ""; string Value = "";
                    RowNo = "RowNo" + Convert.ToString(dt.Rows[i]["RowNo"]);
                    Param = Convert.ToString(dt.Rows[i]["Param"]);
                    Value = Convert.ToString(dt.Rows[i]["Value"]);

                    Result = Result + "<" + RowNo + "><" + Param + ">" + Value + "</" + Param + "></" + RowNo + ">";
                }
            }
            Result = Result + "</xml>";
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.DataTableToXML()");
        }
        return Result;
    }

    public void Loading(bool bFlag)
    {
        try
        {
            if (bFlag)
            {
                frmLoading f = new frmLoading();
                f.ShowDialog();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DevLib.Loading()");
        }
    }


    #endregion

    #region DataTable
    /// <summary>
    /// This can be used for Search screen only
    /// </summary>
    /// <param name="dtSelect">DataTable</param>
    /// <param name="Param">Value</param>
    /// <returns></returns>
    public string DataTable_Select(DataTable dtSelect, string Param)
    {
        string Result = "";
        try
        {
            DataRow dr;
            dr = dtSelect.Select("Param Like '" + Param + "'")[0];
            Result = Convert.ToString(dr.ItemArray[2]);
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DataTable_Select()");
        }
        return Result;
    }

    /// <summary>
    /// This Function can be used for generic DataTable.Select option
    /// </summary>
    /// <param name="Cond">"ColName = 'Value'"</param>
    /// <param name="dtSelect">DataTable</param>
    /// <returns></returns>
    public DataTable DataTable_Select(string Cond, DataTable dtSelect)
    {
        DataTable Result = new DataTable();
        try
        {
            DataView view = new DataView(dtSelect);
            DataView dv = dtSelect.DefaultView;
            dv.RowFilter = Cond;
            Result = dv.ToTable();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DataTable_Select()");
        }
        return Result;
    }

    public DataTable DataTable_Search(DataTable dtSelect, string SearchKey)
    {
        DataTable Result = new DataTable();
        //Result = dtSelect.Clone();
        try
        {
            string Search = "";

            string[] Columns = new string[dtSelect.Columns.Count];

            for (int i = 0; i < dtSelect.Columns.Count; i++)
            {
                if ((dtSelect.Columns[i].DataType).FullName == "System.String")
                {
                    if (Search == "")
                    {
                        Search = Search + " " + dtSelect.Columns[i].ColumnName + " Like '%" + SearchKey + "%' ";
                    }
                    else
                    {
                        Search = Search + " OR " + dtSelect.Columns[i].ColumnName + " Like '%" + SearchKey + "%' ";
                    }
                }
            }

            DataView view = new DataView(dtSelect);
            DataView dv = dtSelect.DefaultView;
            dv.RowFilter = Search;
            Result = dv.ToTable();


            /*
            for (int i = 0; i < GV.Columns.Count; i++)
            {
                //if ((dtSelect.Columns[i].DataType).FullName == "System.String")
                if(GV.Columns[i].Name != "chk")
                {
                    if (Search == "")
                    {
                        Search = Search + " " + GV.Columns[i].Name + " Like '%" + SearchKey + "%' ";
                    }
                    else
                    {
                        Search = Search + " OR " + GV.Columns[i].Name + " Like '%" + SearchKey + "%' ";
                    }
                }
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = GV.DataSource;
            bs.Filter = Search;
            Result = ((DataSet)bs.DataSource).Tables[bs.DataMember];
            */
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DataTable_Select()");
        }
        return Result;
    }

    public DataTable DataTable_Search_Equal(DataTable dtSelect, string SearchKey)
    {
        DataTable Result = new DataTable();
        //Result = dtSelect.Clone();
        try
        {
            string Search = "";

            string[] Columns = new string[dtSelect.Columns.Count];

            for (int i = 0; i < dtSelect.Columns.Count; i++)
            {
                if ((dtSelect.Columns[i].DataType).FullName == "System.String")
                {
                    if (Search == "")
                    {
                        Search = Search + " " + dtSelect.Columns[i].ColumnName + " Like '" + SearchKey + "' ";
                    }
                    else
                    {
                        Search = Search + " OR " + dtSelect.Columns[i].ColumnName + " Like '" + SearchKey + "' ";
                    }
                }
            }

            DataView view = new DataView(dtSelect);
            DataView dv = dtSelect.DefaultView;
            dv.RowFilter = Search;
            Result = dv.ToTable();
        }
        catch (Exception ex)
        {
            ErrLog(ex, "Triggers.DataTable_Search_Equal()");
        }
        return Result;
    }

    #endregion

    #region Error Log
    /// <summary> 
    /// This method will create Log file with Error Description, log file Path 'C drive Focus8 folder Log folder Log_Date.txt file'
    /// </summary>
    /// <param name="Err">Exception</param>
    /// <param name="Details">Description</param>
    /// <returns></returns>
    public bool ErrLog(Exception Err, string Details)
    {
        string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");


        if (Directory.Exists(exePath) == false)
        {
            Directory.CreateDirectory(exePath);
        }

        string curFile = exePath + "\\" + "Log_" + Default_Company() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        using (StreamWriter w = File.AppendText(exePath + "\\" + "Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            w.WriteLine("Exception -----------------------------------------");
            w.WriteLine(DateTime.Now);
            w.WriteLine("TargetSite  ----------------------------------------");
            w.WriteLine(Err.TargetSite.ReflectedType.FullName + "." + Err.TargetSite.Name);
            w.WriteLine("Details  ----------------------------------------");
            w.WriteLine(Details);
            w.WriteLine(Err.TargetSite.ToString());
            w.WriteLine("Message ----------------------------------------");
            w.WriteLine(Convert.ToString(Err.Message));
            w.WriteLine("Exception --------------------------------------");
            w.WriteLine(Convert.ToString(Err.InnerException));
            w.WriteLine("Data -------------------------------------------");
            w.WriteLine(Convert.ToString(Err.Data));
            w.WriteLine("Help -------------------------------------------");
            w.WriteLine(Convert.ToString(Err.HelpLink));
            w.WriteLine("========================================================================================");
            w.WriteLine("========================================================================================");

        }

        using (StreamReader r = File.OpenText(exePath + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            DumpLog(r);
        }
        return true;
    }


    public void DumpLog(StreamReader r)
    {
        string line = null;
        line = r.ReadLine();
        while ((line != null))
        {
            Console.WriteLine(line);
            line = r.ReadLine();
        }

    }

    /// <summary>
    /// This function can be used to debug
    /// </summary>
    /// <param name="Info">calling Function / Method / Event name</param>
    /// <param name="Details">description</param>
    /// <returns></returns>
    public bool InfoLog(string Info, string Details)
    {
        try
        {


            string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");


            if (Directory.Exists(exePath) == false)
            {
                Directory.CreateDirectory(exePath);

            }

            string curFile = exePath + "\\" + "Log_" + Default_Company() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            using (StreamWriter w = File.AppendText(exePath + "\\" + "Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
            {
                w.WriteLine("Method / Function -----------------------------------------");
                w.WriteLine(DateTime.Now);
                w.WriteLine(Convert.ToString(Info));
                w.WriteLine("Information ----------------------------------------");
                w.WriteLine(Details);
                w.WriteLine("========================================================================================");
                w.WriteLine("========================================================================================");

            }

            using (StreamReader r = File.OpenText(exePath + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
            {
                DumpLog(r);
            }
        }
        catch (Exception ex)
        {


        }
        return true;
    }

    /// <summary>
    /// Create Log file for Infomation / Validation
    /// </summary>
    /// <param name="LogString">Details</param>
    /// <param name="LogFileName">File Name</param>
    /// <returns></returns>
    public bool WriteLog(string LogString, string LogFileName)
    {
        string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");


        if (Directory.Exists(exePath) == false)
        {
            Directory.CreateDirectory(exePath);
        }

        string curFile = exePath + "\\" + LogFileName + ".txt";

        using (StreamWriter w = File.AppendText(exePath + "\\" + LogFileName + ".txt"))
        {
            w.WriteLine(Convert.ToString(LogString));
        }

        using (StreamReader r = File.OpenText(exePath + LogFileName + ".txt"))
        {
            DumpLog(r);
        }
        return true;
    }

    public bool EventLog(string Comment, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string Member = null)
    {
        //string exePath = Path.GetTempPath();
        string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");

        if (Directory.Exists(exePath) == false)
        {
            Directory.CreateDirectory(exePath);
        }


        string curFile = exePath + "\\" + "EventLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        using (StreamWriter w = File.AppendText(exePath + "\\" + "EventLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            w.WriteLine(DateTime.Now + " >> " + Convert.ToString(Member) + " >> " + Convert.ToString(lineNumber) + " >> " + Convert.ToString(Comment));
        }

        using (StreamReader r = File.OpenText(exePath + "\\EventLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            DumpLog(r);
        }
        return true;
    }

    /// <summary>
    /// This method will create Log file with Error Description, log file Path 'C drive Focus8 folder Log folder AutoPostingLog_Date.txt file'
    /// </summary>
    /// <param name="Details">Focus8 Error Description</param>
    /// <returns></returns>
    public bool ErrLog(string Details)
    {
        string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");


        if (Directory.Exists(exePath) == false)
        {
            Directory.CreateDirectory(exePath);

        }

        string curFile = exePath + "\\" + "AutoPostingLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        using (StreamWriter w = File.AppendText(exePath + "\\" + "AutoPostingLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {


            w.WriteLine("========================================================================================");
            w.WriteLine(DateTime.Now);
            w.WriteLine(Details);
            w.WriteLine("========================================================================================");


        }

        using (StreamReader r = File.OpenText(exePath + "\\AutoPostingLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            DumpLog(r);
        }
        return true;
    }


    /// <summary>
    /// Function to debug, this function give you line number and called member name in log file
    /// </summary>
    /// <param name="Msg"></param>
    /// <param name="lineNumber"></param>
    /// <param name="Member"></param>
    /// <returns></returns>
    public bool DebugLog(string Msg = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string Member = null)
    {
        try
        {
            if (GetValueFromRegistry("Debug") == "1")
            {

                string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");

                if (Directory.Exists(exePath) == false)
                {
                    Directory.CreateDirectory(exePath);

                }

                using (StreamWriter w = File.AppendText(exePath + "\\" + "DebugLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
                {
                    if (Convert.ToString(Msg) != "")
                    {
                        w.WriteLine("Message >> " + Convert.ToString(Msg));
                    }
                    w.WriteLine("Date Time >> " + Convert.ToString(DateTime.Now));
                    w.WriteLine("Method / Function >> " + Convert.ToString(Member));
                    w.WriteLine("Line No. >> " + Convert.ToString(lineNumber));

                }

                using (StreamReader r = File.OpenText(exePath + "\\DebugLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
                {
                    DumpLog(r);
                }
            }
        }
        catch (Exception ex)
        {


        }
        return true;
    }

    public bool PostVoucherStrust(string FileName, string Struct)
    {
        string exePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Log").Replace("file:\\", "");


        if (Directory.Exists(exePath) == false)
        {
            Directory.CreateDirectory(exePath);

        }

        string curFile = exePath + "\\" + FileName + "_" + Default_Company() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        using (StreamWriter w = File.AppendText(exePath + "\\" + FileName + "_" + Default_Company() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            w.WriteLine(Struct);
        }

        using (StreamReader r = File.OpenText(exePath + "\\" + FileName + "_" + Default_Company() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"))
        {
            DumpLog(r);
        }
        return true;
    }

    #endregion


    #region CRM

    ///API Transid Long to Short conversion method:
    public int getAPITransIdToInt(ulong iAPITransId, int iType)
    {
        int iTransId = 0;
        if (iAPITransId > 0)
        {
            if (iType == 0) //For TransId --Ranges from 1 to 2147483647
                iTransId = (int)(iAPITransId & 0x7FFFFFFF);
            else if (iType == 1) //For Location Id --Ranges from 1 to 32767
                iTransId = (int)((iAPITransId & 0XFFFF0000000L) / 2147483648L);
            else //For Moduule Id //Ranges from 1 to 131071
                iTransId = (int)((iAPITransId & ((0xFFFFC00000000000L))) / 70368744177664L);
        }
        return iTransId;
    }


    ///shor to long method
    public ulong getAPITransId(int iTransId, int iModuleType, int iLocationId)
    {
        ulong lAPITransId = 0;
        if (iTransId == 0)
            return (ulong)iTransId;
        if (iLocationId == 0)
            iLocationId = 1;
        lAPITransId = (ulong)(((iModuleType * 70368744177664L) | (iLocationId * 2147483648L) | iTransId));
        return lAPITransId;
    }

    public string GetAPIJsonFormat(string strJson)
    {
        string APIJson = strJson;
        try
        {
            //APIJson.Replace("[{", "");
            //APIJson.Replace("]", "");

            APIJson = Regex.Replace(APIJson, "[\\[\\]]", string.Empty);
            APIJson = Regex.Replace(APIJson, @"[\[\]]", string.Empty);

            APIJson = "[" + APIJson + "]";
        }
        catch (Exception ex)
        {
            ErrLog(ex, "DAL.GetAPIJsonFormat()");
        }
        return APIJson;
    }

    private const string INDENT_STRING = "";
    public string FormatJson(string json)
    {

        int indentation = 0;
        int quoteCount = 0;
        var result =
            from ch in json
            let quotes = ch == '"' ? quoteCount++ : quoteCount
            let lineBreak = ch == ',' && quotes % 2 == 0 ? ch + Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, indentation)) : null
            let openChar = ch == '{' || ch == '[' ? ch + Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, ++indentation)) : ch.ToString()
            let closeChar = ch == '}' || ch == ']' ? Environment.NewLine + String.Concat(Enumerable.Repeat(INDENT_STRING, --indentation)) + ch : ch.ToString()
            select lineBreak == null
                        ? openChar.Length > 1
                            ? openChar
                            : closeChar
                        : lineBreak;

        return String.Concat(result);
    }

    #endregion

}
#region DataGridView Header Merged Cell

public class HMergedCell : DataGridViewTextBoxCell
{
    private int m_nLeftColumn = 0;
    private int m_nRightColumn = 0;

    /// <summary>
    /// Column Index of the left-most cell to be merged.
    /// This cell controls the merged text.
    /// </summary>
    public int LeftColumn
    {
        get
        {
            return m_nLeftColumn;
        }
        set
        {
            m_nLeftColumn = value;
        }
    }

    /// <summary>
    /// Column Index of the right-most cell to be merged
    /// </summary>
    public int RightColumn
    {
        get
        {
            return m_nRightColumn;
        }
        set
        {
            m_nRightColumn = value;
        }
    }

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        try
        {
            int mergeindex = ColumnIndex - m_nLeftColumn;
            int i;
            int nWidth;
            int nWidthLeft;
            string strText;

            Pen pen = new Pen(Brushes.Black);

            // Draw the background
            graphics.FillRectangle(new SolidBrush(SystemColors.Control), cellBounds);

            // Draw the separator for rows
            graphics.DrawLine(new Pen(new SolidBrush(SystemColors.ControlDark)), cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);

            // Draw the right vertical line for the cell
            if (ColumnIndex == m_nRightColumn)
                graphics.DrawLine(new Pen(new SolidBrush(SystemColors.ControlDark)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);

            // Draw the text
            RectangleF rectDest = RectangleF.Empty;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisCharacter;

            // Determine the total width of the merged cell
            nWidth = 0;
            for (i = m_nLeftColumn; i <= m_nRightColumn; i++)
                nWidth += this.OwningRow.Cells[i].Size.Width;

            // Determine the width before the current cell.
            nWidthLeft = 0;
            for (i = m_nLeftColumn; i < ColumnIndex; i++)
                nWidthLeft += this.OwningRow.Cells[i].Size.Width;

            // Retrieve the text to be displayed
            strText = this.OwningRow.Cells[m_nLeftColumn].Value.ToString();

            rectDest = new RectangleF(cellBounds.Left - nWidthLeft, cellBounds.Top, nWidth, cellBounds.Height);
            graphics.DrawString(strText, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, rectDest, sf);
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.ToString());
        }
    }
}

#endregion
//}
