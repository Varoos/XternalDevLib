using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XternalDevLib

{
    static class Focus8API
    {
        //DevLib Xlib = new DevLib();

        public static string Post(string VoucherName, string data, ref string err)
        {
            DevLib Xlib = new DevLib();
            try
            {
                string url = Xlib.BaseUrl() + "Transactions/Vouchers/" + VoucherName;
                string sessionId = Xlib.SessionId;

                Xlib.EventLog("url:" + url);
                Xlib.EventLog("data:" + data);
                Xlib.EventLog("sessionId:" + sessionId);

                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers.Add("fSessionId", sessionId);
                    client.Headers.Add("Content-Type", "application/json");
                    client.Timeout = 10 * 60 * 1000;
                    var response = client.UploadString(url, data);
                    Xlib.EventLog("response:" + Convert.ToString(response));
                    return response;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                Xlib.EventLog("err:" + err);
                return null;
            }


        }

        public static string DeleteVoucher(string VoucherName, string VoucherNo, string sessionId, ref string err)
        {
            DevLib Xlib = new DevLib();
            try
            {
                string sUrl = "";       // Xlib.urlVocDelete + VoucherName + "/" + VoucherNo;
                Xlib.EventLog("sUrl:" + sUrl);
                Xlib.EventLog("VoucherNo:" + VoucherNo);
                Xlib.EventLog("sessionId:" + sessionId);

                using (var client = new WebClientDel())
                {
                    client.Headers.Add("fSessionId", sessionId);
                    client.Headers.Add("Content-Type", "application/json");
                    //HashData objHashResponse = new HashData();
                    string strResponse = client.UploadString(sUrl, "DELETE", "");
                    //objHashResponse = JsonConvert.DeserializeObject<HashData>(strResponse);
                    var responseData = JsonConvert.DeserializeObject<APIResponse.PostResponse>(strResponse);
                    return strResponse;

                }
            }
            catch (Exception e)
            {
                err = e.Message;
                Xlib.EventLog("err:" + err);
                return null;
            }


        }

        internal static string Get(string url, string sessionId, ref string err)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers.Add("fSessionId", sessionId);
                    //client.Headers.Add("Content-Type", "application/json");
                    var response = client.DownloadString(url);
                    return response;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return null;
            }

        }
    }


    public class PostingData
    {
        public PostingData()
        {
            data = new List<Hashtable>();
        }
        public List<Hashtable> data { get; set; }

    }

    public class CustomData
    {
        public CustomData()
        {
            data = new List<Hashtable>();
        }
        public List<Hashtable> data { get; set; }
        public string url { get; set; }
        public int result { get; set; }
        public string message { get; set; }

    }


    public class DeleteVoucherResult
    {
        public object arrTransIds { get; set; }
        public int lResult { get; set; }
        public object sValue { get; set; }
    }

    public class RootObject2
    {
        public DeleteVoucherResult DeleteVoucherResult { get; set; }
    }

    public class WebClient : System.Net.WebClient
    {
        public int Timeout { get; set; }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest lWebRequest = base.GetWebRequest(uri);
            lWebRequest.Timeout = Timeout;
            ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
            return lWebRequest;
        }
    }

    public class WebClientDel : System.Net.WebClient
    {
        //public int Timeout { get; set; }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest lWebRequest = base.GetWebRequest(uri);
            //lWebRequest.Timeout = Timeout;
            //((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
            return lWebRequest;
        }
    }


    #region Common Response Class

    public class ScalarResult
    {
        public bool Status { get; set; }
        public string Error { get; set; }
        public string Data { get; set; }
    }

    public class Data2Result
    {
        public bool Status { get; set; }
        public string Error { get; set; }
        public string Data0 { get; set; }
        public string Data1 { get; set; }
    }

    public class APIResponse
    {
        public class Data
        {
            public List<Hashtable> Body { get; set; }
            public Hashtable Header { get; set; }
            public List<Hashtable> Footer { get; set; }
        }

        public class Response
        {
            public string url { get; set; }
            public List<Data> data { get; set; }
            public int result { get; set; }
            public string message { get; set; }
        }
        public class PostResponse
        {
            public string url { get; set; }
            public List<Hashtable> data { get; set; }
            public int result { get; set; }
            public string message { get; set; }
        }
    }

    #endregion
}
