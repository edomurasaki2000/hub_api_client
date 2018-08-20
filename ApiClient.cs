using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSSL.wapper;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace githubAPI
{
    public class ApiClient
    {
        public string access_token { get; set; }
        public string user_agent { get; set; }

        public ApiClient(string access_token, string user_agent)
        {
            this.access_token = access_token;
            this.user_agent = user_agent;
        }
        public T GET<T>(Uri url, WebHeaderCollection exHeaders = null)
        {
            using (var con = new OpenSSL.wapper.SslConnection())
            {
                con.connect(url);
                con.write("GET {0} HTTP/1.1\r\n", url.PathAndQuery);
                con.write("Accept: application/vnd.github.v3+json\r\n");
                con.write("User-Agent: {0}\r\n", user_agent);
                con.write("Authorization: token {0}\r\n", access_token);
                con.write("Host: {0}\r\n", url.Host);
                con.write("\r\n");
                var c = con.getStatusCode(false);
                var col = con.getHeaders();

                string j = null;
                if (col.IsTransferEncodingChunked)
                    j = con.getChuckedString();
                else
                    j = con.getString(col.content_Length);

                if (c != HttpStatusCode.OK)
                    throw new APIErrorExcption(c, JsonConvert.DeserializeObject<Result>(j));
                return JsonConvert.DeserializeObject<T>(j);
            }
        }
        public UserResult user()
        {

            return GET<UserResult>(new Uri("https://api.github.com/user"));
        }
        public Repo[] repos()
        {
            return GET<Repo[]>(new Uri("https://api.github.com/user/repos"));
        }
        public Repo[] repositories()
        {
            return GET<Repo[]>(new Uri("https://api.github.com/repositories"));
        }
        public Repo Get(string user, string repo)
        {
            return GET<Repo>(new Uri(string.Format(
                 "https://api.github.com/repos/{0}/{1}", user, repo)));
        }
        public void Delete(string owner,string repo)
        {
            var url = new Uri(string.Format("https://api.github.com/repos/{0}/{1}", owner, repo));
            var con = new OpenSSL.wapper.SslConnection();
            con.connect(url);
            con.write("DELETE {0} HTTP/1.1\r\n", url.PathAndQuery);
            con.write("Accept: application/vnd.github.v3+json\r\n");
            con.write("User-Agent: {0}\r\n", user_agent);
            con.write("Authorization: token {0}\r\n", access_token);
            
            con.write("Host: {0}\r\n", url.Host);
            con.write("\r\n");
             
            var c = con.getStatusCode(false);
            var col = con.getHeaders();
            string j = null;
            if (col.IsTransferEncodingChunked)
                j = con.getChuckedString();
            else
                j = con.getString(col.content_Length);

            if (c != HttpStatusCode.NoContent)
                throw new APIErrorExcption(c, JsonConvert.DeserializeObject<Result>(j));
          
        }
         public Repo Create()
        {
            var jobj = new JObject(new JProperty("name", new JValue("test1")),
                new JProperty("description", new JValue("this is test description"))
                );
            var url = new Uri("https://api.github.com/user/repos");
            var con = new OpenSSL.wapper.SslConnection();
            con.connect(url);
            con.write("POST {0} HTTP/1.1\r\n", url.PathAndQuery);
            con.write("Accept: application/vnd.github.v3+json\r\n");
            con.write("User-Agent: {0}\r\n", user_agent);
            con.write("Authorization: token {0}\r\n", access_token);
            con.write("Content-Type: application/json\r\n");
            con.write("Content-Length: {0}\r\n", jobj.ToString().Length);
            con.write("Host: {0}\r\n", url.Host);
            con.write("\r\n");
            con.write(jobj.ToString());
            var c = con.getStatusCode(false);
            var col = con.getHeaders();
            string j = null;
            if (col.IsTransferEncodingChunked)
                j = con.getChuckedString();
            else
                j = con.getString(col.content_Length);

            if (c != HttpStatusCode.Created)
                throw new APIErrorExcption(c, JsonConvert.DeserializeObject<Result>(j));
            return JsonConvert.DeserializeObject<Repo>(j);
         }
    
        public Repo Edit(string user, string repo)
        {
            var jobj = new JObject(new JProperty("name", new JValue(repo)),
                new JProperty("description", new JValue("this is test description"))
                );
            var url = new Uri(string.Format("https://api.github.com/repos/{0}/{1}",
                user, repo));
            var con = new OpenSSL.wapper.SslConnection();
            con.connect(url);
            con.write("PATCH {0} HTTP/1.1\r\n", url.PathAndQuery);
            con.write("Accept: application/vnd.github.v3+json\r\n");
            con.write("User-Agent: {0}\r\n", user_agent);
            con.write("Authorization: token {0}\r\n", access_token);
            con.write("Content-Type: application/json\r\n");
            con.write("Content-Length: {0}\r\n", jobj.ToString().Length);
            con.write("Host: {0}\r\n", url.Host);
            con.write("\r\n");
            con.write(jobj.ToString());
            var c = con.getStatusCode(false);
            var col = con.getHeaders();
            string j = null;
            if (col.IsTransferEncodingChunked)
                j = con.getChuckedString();
            else
                j = con.getString(col.content_Length);

            if (c != HttpStatusCode.OK)
                throw new APIErrorExcption(c, JsonConvert.DeserializeObject<Result>(j));
            return JsonConvert.DeserializeObject<Repo>(j);
        }
    }
}