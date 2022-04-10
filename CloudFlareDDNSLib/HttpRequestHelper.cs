using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace CloudFlareDDNSLib
{
    public class HttpRequestHelper
    {
        /// <summary>
        /// 发送HTTP POST请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="requestEncoding">字符编码</param>
        /// <param name="postDataCollection">POST数据集合</param>
        /// <param name="readResponse">是否读取响应信息，若不需要响应，则返回空字符串</param>
        /// <returns>HTTP请求响应信息</returns>
        public static string SendHttpPost(string url,
            Encoding requestEncoding,
            NameValueCollection postDataCollection,
            bool readResponse)
        {
            string rt = string.Empty;

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";

            //int timeout = 2000000;
            //request.Timeout = timeout;
            //request.ReadWriteTimeout = timeout;
            //request.KeepAlive = false;
            //request.AllowAutoRedirect = false;
            //request.ServicePoint.Expect100Continue = false;
            //request.ServicePoint.MaxIdleTime = timeout;
            //request.ServicePoint.ConnectionLeaseTimeout = -1;

            //request.ContentType = "application/x-www-form-urlencoded";
            if (postDataCollection != null)
            {
                if (postDataCollection.Count > 0)
                {
                    StringBuilder buffer = new StringBuilder();
                    int idx = 0;
                    foreach (var key in postDataCollection.AllKeys)
                    {
                        buffer.AppendFormat("{0}={1}", key, postDataCollection[key]);
                        if (idx < postDataCollection.Count - 1)
                        {
                            buffer.Append("&");
                        }
                        idx++;
                    }

                    if (requestEncoding == null)
                    {
                        requestEncoding = Encoding.Default;
                    }

                    string postDataStr = buffer.ToString();
                    byte[] data = requestEncoding.GetBytes(postDataStr);
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                        //stream.Close();
                    }
                }
            }

            if (!readResponse)
            {
                return rt;
            }

            using (var rsp = request.GetResponse() as HttpWebResponse)
            {
                using (var rspStream = rsp.GetResponseStream())
                {
                    int readLen = 0;
                    var tmpBuffer = new byte[1024];
                    var dataHolder = new List<byte>();

                    do
                    {
                        readLen = rspStream.Read(tmpBuffer, 0, tmpBuffer.Length);
                        dataHolder.AddRange(tmpBuffer.Take(readLen));
                    }
                    while (readLen > 0);

                    var postData = dataHolder.ToArray();
                    Encoding rspEncoding = null;
                    try
                    {
                        rspEncoding = Encoding.GetEncoding(rsp.ContentEncoding);
                    }
                    catch
                    {
                        rspEncoding = Encoding.Default;
                    }
                    rt = rspEncoding.GetString(postData);
                }
            }

            return rt;
        }


        public static string SendHttpPost(string url, byte[] data, bool readResponse, ICredentials cdl = null)
        {
            string rt = string.Empty;
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
            request.Method = "POST";
            if (cdl != null)
            {
                request.Credentials = cdl;
            }

            if (data != null)
            {
                if (data.Length > 0)
                {
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
            }

            if (!readResponse)
            {
                return rt;
            }

            using (var rsp = request.GetResponse() as HttpWebResponse)
            {
                using (var rspStream = rsp.GetResponseStream())
                {
                    int readLen = 0;
                    var tmpBuffer = new byte[1024];
                    var dataHolder = new List<byte>();

                    do
                    {
                        readLen = rspStream.Read(tmpBuffer, 0, tmpBuffer.Length);
                        dataHolder.AddRange(tmpBuffer.Take(readLen));
                    }
                    while (readLen > 0);

                    var postData = dataHolder.ToArray();
                    Encoding rspEncoding = null;
                    try
                    {
                        rspEncoding = Encoding.GetEncoding(rsp.ContentEncoding);
                    }
                    catch
                    {
                        rspEncoding = Encoding.Default;
                    }
                    rt = rspEncoding.GetString(postData);
                }
            }

            return rt;
        }

        public static string Get(string url,
                NameValueCollection dataCollection = null,
                WebHeaderCollection headerCol = null,
                Encoding defaultRspEncoding = null,
                bool readResponse = true,
                string contentType = "application/json")
        {
            string rt = string.Empty;

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            if (dataCollection != null)
            {
                if (dataCollection.Count > 0)
                {
                    StringBuilder buffer = new StringBuilder();
                    int idx = 0;
                    foreach (var key in dataCollection.AllKeys)
                    {
                        buffer.AppendFormat("{0}={1}", key, dataCollection[key]);
                        if (idx < dataCollection.Count - 1)
                        {
                            buffer.Append("&");
                        }
                        idx++;
                    }

                    string getDataEx = buffer.ToString();
                    if (!url.EndsWith("&"))
                    {
                        url += "&";
                    }

                    url += buffer.ToString();
                }
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }

            if (headerCol != null)
            {
                if (headerCol.Count > 0)
                {
                    request.Headers = headerCol;
                }
            }

            if (!readResponse)
            {
                return rt;
            }

            using (var rsp = request.GetResponse() as HttpWebResponse)
            {
                using (var rspStream = rsp.GetResponseStream())
                {
                    int readLen = 0;
                    var tmpBuffer = new byte[1024];
                    var dataHolder = new List<byte>();

                    do
                    {
                        readLen = rspStream.Read(tmpBuffer, 0, tmpBuffer.Length);
                        dataHolder.AddRange(tmpBuffer.Take(readLen));
                    }
                    while (readLen > 0);

                    var postData = dataHolder.ToArray();
                    Encoding rspEncoding = null;
                    try
                    {
                        rspEncoding = Encoding.GetEncoding(rsp.ContentEncoding);
                    }
                    catch
                    {
                        rspEncoding = defaultRspEncoding == null ? Encoding.Default : defaultRspEncoding;
                    }
                    rt = rspEncoding.GetString(postData);
                }
            }

            return rt;
        }

        public static string Put(string url,
           Encoding requestEncoding = null,
           NameValueCollection postDataCollection = null,
           WebHeaderCollection headerCol = null,
           Encoding defaultRspEncoding = null,
           bool readResponse = true,
           string contentType = "application/json")
        {
            byte[] putData = null;
            if (postDataCollection != null)
            {
                if (postDataCollection.Count > 0)
                {
                    StringBuilder buffer = new StringBuilder();
                    int idx = 0;
                    foreach (var key in postDataCollection.AllKeys)
                    {
                        buffer.AppendFormat("{0}={1}", key, postDataCollection[key]);
                        if (idx < postDataCollection.Count - 1)
                        {
                            buffer.Append("&");
                        }
                        idx++;
                    }

                    if (requestEncoding == null)
                    {
                        requestEncoding = Encoding.Default;
                    }

                    string postDataStr = buffer.ToString();
                    putData = requestEncoding.GetBytes(postDataStr);
                }
            }

            return Put(url, putData, headerCol);
        }

        public static string Put(string url,
           Encoding requestEncoding = null,
           string putDataStr = null,
           WebHeaderCollection headerCol = null,
           Encoding defaultRspEncoding = null,
           bool readResponse = true,
           string contentType = "application/json")
        {
            byte[] putData = null;
            if (putDataStr != null)
            {
                if (putDataStr.Length > 0)
                {
                    if (requestEncoding == null)
                    {
                        requestEncoding = Encoding.Default;
                    }

                    putData = requestEncoding.GetBytes(putDataStr);
                }
            }

            return Put(url, putData, headerCol);
        }

        public static string Put(string url,
            byte[] putData = null,
            WebHeaderCollection headerCol = null,
            Encoding defaultRspEncoding = null,
            bool readResponse = true,
            string contentType = "application/json")
        {
            string rt = string.Empty;

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "PUT";

            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }

            if (headerCol != null)
            {
                if (headerCol.Count > 0)
                {
                    request.Headers = headerCol;
                }
            }

            if (putData != null)
            {
                if (putData.Length > 0)
                {
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(putData, 0, putData.Length);
                    }
                }
            }

            if (!readResponse)
            {
                return rt;
            }

            using (var rsp = request.GetResponse() as HttpWebResponse)
            {
                using (var rspStream = rsp.GetResponseStream())
                {
                    int readLen = 0;
                    var tmpBuffer = new byte[1024];
                    var dataHolder = new List<byte>();

                    do
                    {
                        readLen = rspStream.Read(tmpBuffer, 0, tmpBuffer.Length);
                        dataHolder.AddRange(tmpBuffer.Take(readLen));
                    }
                    while (readLen > 0);

                    var postData = dataHolder.ToArray();
                    Encoding rspEncoding = null;
                    try
                    {
                        rspEncoding = Encoding.GetEncoding(rsp.ContentEncoding);
                    }
                    catch
                    {
                        rspEncoding = defaultRspEncoding == null ? Encoding.Default : defaultRspEncoding;
                    }
                    rt = rspEncoding.GetString(postData);
                }
            }

            return rt;
        }

    }
}
