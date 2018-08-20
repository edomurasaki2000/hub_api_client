using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
namespace githubAPI
{
    public class OauthClient
    {
        const string ClientID = "feeac17055caa25a85df";
        const string ClientSecret = "efcb48b02f67ab3c0268a6e4283d14bc42955fbf";
        const string cc = "http://localhost:9999/";

        string code = null;
        System.Threading.ManualResetEvent evt = new System.Threading.ManualResetEvent(false);
        void callback(IAsyncResult ar)
        {
            var http = ar.AsyncState as HttpListener;

            var ctx = http.EndGetContext(ar);
            code = ctx.Request.QueryString["code"];
            ctx.Response.StatusCode = 200;
            var w = new System.IO.StreamWriter(ctx.Response.OutputStream);
            w.Write(code);
            w.Close();
            http.Stop();
            http.Close();
            evt.Set();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TokenResult oauth_authorize()
        {
            var http = new HttpListener();
            http.Prefixes.Add("http://localhost:9999/");
            http.Start();
            http.BeginGetContext(callback, http);
            var url = oauth_authorize_url();
            System.Diagnostics.Process.Start(url.ToString());
            evt.WaitOne();
            return get_oauth_token(code);

        }

        Uri oauth_authorize_url()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("client_id={0}", WebUtility.UrlEncode(ClientID));
            sb.AppendFormat("&scope={0}", WebUtility.UrlEncode("user repo delete_repo"));
            var builder = new UriBuilder("https://github.com/login/oauth/authorize");
            builder.Query = sb.ToString();
            return builder.Uri;
        }
        public TokenResult get_oauth_token(string code)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("client_id={0}", WebUtility.UrlEncode(ClientID));
            sb.AppendFormat("&client_secret={0}", WebUtility.UrlEncode(ClientSecret));
            sb.AppendFormat("&code={0}", WebUtility.UrlEncode(code));
            var url = new Uri("https://github.com/login/oauth/access_token");
            using (var con = new OpenSSL.wapper.SslConnection())
            {

                con.connect(url);
                con.write("POST {0} HTTP/1.1\r\n", url.PathAndQuery);
                con.write("Host: {0}\r\n", url.Host);
                con.write("Accept: application/json\r\n");
                con.write("User-Agent: edomurasaki\r\n");
                con.write("Content-Type: application/x-www-form-urlencoded\r\n");
                con.write("Content-Length: {0}\r\n", sb.Length);
                //  con.write("Authorization: token {0}\r\n", Convert.ToBase64String(Encoding.UTF8.GetBytes("sandbag1963:moonchild250")));


                con.write("\r\n");
                con.write(sb.ToString());
                var ststus = con.getStatusCode(true);

                var col = con.getHeaders();

               
                string json = null;
                if (col.IsTransferEncodingChunked)
                    json = con.getChuckedString();
                else
                    json = con.getString(col.content_Length);
               
                return JsonConvert.DeserializeObject<TokenResult>(json);

            }
        }
    }
}