namespace osuTools
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using osuTools.ExtraMethods;
    namespace Online.ApiV2.Authorization
    {
        public class OsuApiV2Token
        {
            public string TokenType { get; }
            public TimeSpan ExpiresIn { get; }
            public string AccessToken { get; }
            public OsuApiV2Token(JObject json)
            {
                int sec = 0;
                int.TryParse(json["expires_in"].ToString(), out sec);
                TokenType = json["token_type"].ToString();
                if (sec == 0)
                    throw new ArgumentException();
                ExpiresIn = TimeSpan.FromSeconds(sec);
                AccessToken = json["access_token"].ToString();
            }
        }
        public class OsuApiV2Authorization
        {
            public string SecretKey { get; set; }
            public int AppID { get; set; }
            public string AccessScope { get; set; } = "identify public";
            public string RequestMethod { get; set; } = "post";
            public HttpWebRequest Request { get; } = WebRequest.CreateHttp("https://osu.ppy.sh/oauth/token");
            public OsuApiV2Authorization(string secret, int appId)
            {
                SecretKey = secret;
                AppID = appId;
            }
            public OsuApiV2Token GetToken()
            {
                string recvjson = "";
                if (string.IsNullOrEmpty(SecretKey) || AppID == 0)
                    throw new ArgumentNullException();
                Request.Accept = "application/json";
                Request.ContentType = "application/json";
                Request.Method = "post";
                string json = $"{{\"grant_type\":\"client_credentials\",\"client_id\":\"{AppID}\",\"client_secret\":\"{SecretKey}\",\"scope\":\"{AccessScope}\"}}";
                using (var stream = Request.GetRequestStream())
                {
                    byte[] bytes = json.ToBytes(Encoding.ASCII);
                    stream.Write(bytes, 0, bytes.Length);
                }
                using (var response = Request.GetResponse())
                {
                    StreamReader r = new StreamReader(response.GetResponseStream());
                    recvjson = r.ReadToEnd();
                }
                return new OsuApiV2Token((JObject)JsonConvert.DeserializeObject(recvjson));
            }

        }

    }
}