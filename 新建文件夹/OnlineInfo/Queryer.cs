namespace osuTools.Online
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class OsuApiQuery
    {
        JArray arr;
        Uri i;
        public Uri QueryUri { get => i; }
        public JArray JsonArray { get => arr; }
        OsuApiType t;
        public OsuApiType QueryType { get => t; set => t = value; }
        OsuGameMode m = OsuGameMode.Osu;
        public OsuGameMode Mode { get => m; set => m = value; }
        string apikey;
        string user;
        public string UserName { get => user; set => user = value; }
        public string ApiKey { get => apikey; set { if (value.Length < 40 || value.Length > 40) { apikey = ""; throw new FormatException("请输入正确的ApiKey!"); } else apikey = value; } }
        int beatmapid = -2;
        public int BeatmapID { get => beatmapid; set { if (value == -1) { beatmapid = 0; } else { beatmapid = value; } } }
        public OsuApiQuery(JArray j)
        {
            arr = j;
        }
        public OsuApiQuery()
        {

        }
        public JArray Query()
        {
            try
            {
                string temp = $"http://osu.ppy.sh/api/{t.ToString()}?k={ApiKey}";

                if (apikey == "")
                {
                    System.Windows.Forms.MessageBox.Show("请先设置ApiKey!", "未设置ApiKey", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return null;
                }
                apikey = ApiKey;
                if (t == OsuApiType.GetUserInfomation || t == OsuApiType.GetRecentRecords || t == OsuApiType.GetBestRecords || t == OsuApiType.GetScores)
                {
                    if (UserName == "")
                    {
                        System.Windows.Forms.MessageBox.Show("需要用户名!", "未输入用户名", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        if (t == OsuApiType.GetScores)
                        {
                            if (beatmapid == -2)
                            {
                                System.Windows.Forms.MessageBox.Show("需要谱面ID!", "未输入谱面ID", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                return null;
                            }
                            user = UserName;
                            beatmapid = BeatmapID;
                            temp += $"&u={UserName}&b={beatmapid}&m={m.ToIntMode()}";
                        }
                        else
                        {
                            user = UserName;
                            temp += ($"&u={UserName}&m={m.ToIntMode()}");
                        }

                    }
                }
                Uri u = new Uri(temp.ToString());
                i = u;
                if (u == null||i==null)
                {
                    throw new NullReferenceException("未能生成Uri");
                }
                Sync.Tools.IO.CurrentIO.Write("Connecting...");
                System.Net.Http.HttpClient c = new System.Net.Http.HttpClient();
                Sync.Tools.IO.CurrentIO.Write("Downloading data...");
                string js = c.GetStringAsync(u).Result;
                Sync.Tools.IO.CurrentIO.Write("Processing data...");
                JArray jarr = (JArray)JsonConvert.DeserializeObject(js);
                arr = jarr;
                if (jarr.Count == 0)
                {
                    throw new osuToolsException.OnlineQueryFailed($"请检查网络是否通顺并检查用户名({UserName})是否正确。");
                }
                return jarr;
            }
            catch (Exception c)
            {
                Sync.Tools.IO.CurrentIO.WriteColor($"查询失败:{c.Message}", ConsoleColor.Red);
                return new JArray();
            }

        }
    }
}