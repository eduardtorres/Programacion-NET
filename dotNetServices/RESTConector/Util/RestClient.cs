using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RESTConector.Util
{
    public class RestClient
    {

        public async Task<string> MakePatchRequest(string requestUrlApi, string JSONRequest, SecurityProtocolType securityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192,
            String authorizationHeader = null, WebHeaderCollection headers = null, Func<HttpWebResponse, bool> isValidResponse = null)
        {
            return await MakeRequest(requestUrlApi, JSONRequest, "PATCH", "application/json", -1, securityProtocol, authorizationHeader, headers, isValidResponse);
        }
        public async Task<string> MakePostRequest(string requestUrlApi, string JSONRequest, SecurityProtocolType securityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192,
            String authorizationHeader = null, WebHeaderCollection headers = null, Func<HttpWebResponse, bool> isValidResponse = null)
        {
            return await MakeRequest(requestUrlApi, JSONRequest, "POST", "application/json", -1, securityProtocol, authorizationHeader, headers, isValidResponse);
        }
        public async Task<string> MakePutRequest(string requestUrlApi, string JSONRequest, SecurityProtocolType securityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192,
            String authorizationHeader = null, WebHeaderCollection headers = null, Func<HttpWebResponse, bool> isValidResponse = null)
        {
            return await MakeRequest(requestUrlApi, JSONRequest, "PUT", "application/json", -1, securityProtocol, authorizationHeader, headers, isValidResponse);
        }
        public async Task<string> MakeGetRequest(string requestUrlApi, string JSONRequest, SecurityProtocolType securityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192,
            String authorizationHeader = null, WebHeaderCollection headers = null, Func<HttpWebResponse, bool> isValidResponse = null)
        {
            return await MakeRequest(requestUrlApi, JSONRequest, "GET", "application/json", -1, securityProtocol, authorizationHeader, headers, isValidResponse);
        }

        public async Task<string> MakeRequest(string requestUrlApi, string JSONRequest, string JSONmethod, string JSONContentType, int msTimeOut,
                    SecurityProtocolType securityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192,
                    String authorizationHeader = null, WebHeaderCollection headers = null,
                    Func<HttpWebResponse, bool> isValidResponse = null)
        {

            return await Task.Run(() => { 

            isValidResponse ??= (HttpWebResponse response) =>
            {
                return response.StatusCode == HttpStatusCode.OK;
            };

            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
             X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

            ServicePointManager.SecurityProtocol = securityProtocol;
            HttpWebRequest request = WebRequest.Create(requestUrlApi) as HttpWebRequest;
            string strsb;
            if (msTimeOut >= 0)
            {
                request.Timeout = msTimeOut;
                request.ReadWriteTimeout = msTimeOut;
            }
            request.Method = JSONmethod;
            request.ContentType = JSONContentType;
            if (headers != null)
            {
                request.Headers = headers;
            }
            if (authorizationHeader != null)
            {
                request.Headers.Add("Authorization", authorizationHeader);
            }

            if (!String.IsNullOrEmpty(JSONRequest))
            {
                string sb = JSONRequest;
                Byte[] bt = Encoding.UTF8.GetBytes(sb);
                Stream st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (!isValidResponse(response))
                {
                    throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                }
                Stream stream1 = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream1);
                strsb = sr.ReadToEnd();
            }

            return strsb;

            });
        }

    }
}
