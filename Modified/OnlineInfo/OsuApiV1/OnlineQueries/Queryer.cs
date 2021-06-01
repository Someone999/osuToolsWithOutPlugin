namespace osuTools.Online.ApiV1.Querier
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Text;
   


    /// <summary>
    /// 在线查询一个或多个谱面
    /// </summary>
    public class OnlineBeatmapQuery
    {
        bool queried = false;
        OnlineBeatmapCollection rec = new OnlineBeatmapCollection();
        public OnlineBeatmapCollection Beatmaps {
            get
            {
                if (!queried)
                {
                    GetResult();
                    queried = true;
                    return rec;
                }
                else return rec;
            }
            private set 
            {
                rec = value;
            } 
        }
        public string OsuApiKey { get; set; }
        public string CreatorUserName { get; set; }
        public int CreatorUserID { get; set; }
        int limit = 100;
        public int Limit { get => limit; set { if (OnlineQueryTools.InRange(0, 500, value)) limit = value; else limit = 100; } }
        public string Hash { get; set; }
        public int BeatmapID { get; set; }
        public int BeatmapSetID { get; set; }
        public DateTime RankedOrLovedSince { get; set; } = new DateTime();
        public bool IncludeConvertedBeatmap { get; set; } = false;
        public OsuGameMode Mode { get; set; } = OsuGameMode.Unkonwn;
        public int Mods { get; set; }
        public Uri UriGenerator()
        {
            if (string.IsNullOrEmpty(OsuApiKey) || string.IsNullOrWhiteSpace(OsuApiKey)) throw new ArgumentException();
            string baseuri = $"https://osu.ppy.sh/api/get_beatmaps?k={OsuApiKey}";
            string id = $"&b={BeatmapID}", setid = $"&s={BeatmapSetID}", incconver = $"&a={(IncludeConvertedBeatmap?1:0)}" ,
                   hash=$"&h={Hash}",mode=$"&m={(int)(Mode)}",lim=$"&limit={Limit}",uname=$"&u={CreatorUserName}&type=string",
                   userid=$"&u={CreatorUserID}&type=id",since=$"&since={RankedOrLovedSince:YYYY-MM-DD}",mods=$"&mods={Mods}";
            StringBuilder builder = new StringBuilder(baseuri);
            builder.Append(string.IsNullOrEmpty(CreatorUserName) ? CreatorUserID == 0 ? "" : userid : uname);
            builder.Append(Limit != 0 ? lim : "");
            builder.Append(!string.IsNullOrEmpty(Hash) ? hash : "");
            builder.Append(Mode != OsuGameMode.Unkonwn ? mode : "");
            builder.Append(Mods != 0 ? mods : "");
            builder.Append(RankedOrLovedSince != new DateTime() ? since : "");
            builder.Append(BeatmapID != 0 ? id : setid);
            builder.Append(IncludeConvertedBeatmap ? incconver : "");
            return new Uri(builder.ToString());           
        }
        void GetResult()
        {
            OnlineBeatmapCollection c = new OnlineBeatmapCollection();
            QueryResult q = OnlineQueryTools.GetResponse(UriGenerator());
            if(q.Results.Count==0)
            {
                c.Failed = true;
                return;
            }
            if (q.Results != null)
                foreach (JObject result in q.Results)
                    c.Beatmaps.Add(new OnlineBeatmap(result));
            Beatmaps = c;
        }


    }
    /// <summary>
    /// 在线查询用户信息
    /// </summary>
    public class OnlineUserQuery
    {
        bool queried = false;
        OnlineUser rec = new OnlineUser();
        public OnlineUser UserInfo
        {
            get
            {
                if (!queried)
                {
                    GetResult();
                    queried = true;
                    return rec;
                }
                else return rec;
            }
            private set
            {
                rec = value;
            }
        }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public OsuGameMode Mode { get; set; } = OsuGameMode.Osu;
        public string OsuApiKey { get; set; }
        public int MaxDaysLastEventBefore { get; set; } = 1;
        public Uri UriGenerator()
        {
            string baseuri = $"https://osu.ppy.sh/api/get_user?k={OsuApiKey}";
            if (UserID == 0 && string.IsNullOrEmpty(UserName))
                throw new ArgumentException();
            string usern = $"&u={UserName}&type=string", userid = $"&u={UserID}&type=id", mode = $"&m={(int)Mode}", eventdays = $"&event_days={MaxDaysLastEventBefore}";
            StringBuilder b = new StringBuilder(baseuri);
            b.Append(UserID == 0 ? usern : userid);
            b.Append(mode);
            b.Append(eventdays);
            return new Uri(b.ToString());
        }
        void GetResult()
        {
            UserInfo = new OnlineUser(OnlineQueryTools.GetResponse(UriGenerator()).Results);
        }
    }
    /// <summary>
    /// 在线查询用户最近的游玩记录
    /// </summary>
    public class OnlineRecentRecordQuery
    {
        bool queried = false;
        public string OsuApiKey { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public OsuGameMode Mode { get; set; } = OsuGameMode.Osu;
        int lim = 10;
        public int Limit
        {
            get => lim;
            set
            {
                if (OnlineQueryTools.InRange(0, 50, value))
                    lim = value;
            }
        }
        OnlineRecentResultCollection res = new OnlineRecentResultCollection();
        public OnlineRecentResultCollection Results
        {
            get
            {
                if (!queried)
                {
                    GetResult();
                    queried = true;
                }
                return res;
            }
            private set
            {
                res = value;
            }
        }
        void GetResult()
        {
            if (UserID == 0)
                if (string.IsNullOrEmpty(UserName))
                    throw new ArgumentException("必须指定用户名或用户ID。");
            string basestr = $"https://osu.ppy.sh/api/get_user_recent?k={OsuApiKey}";
            StringBuilder b = new StringBuilder(basestr);
            b.Append(UserID != 0 ? $"&u={UserID}&type=id&m={(int)Mode}&limit={Limit}" : $"&u={UserName}&type=string&m={(int)Mode}&limit={Limit}");
            QueryResult q = OnlineQueryTools.GetResponse(new Uri(b.ToString()));
            foreach (var json in q.Results)
            {
                res.RecentResults.Add(new RecentOnlineResult(json.ToString(), Mode));
            }

        }
    }
    /// <summary>
    /// 在线查询一个谱面的游玩记录
    /// </summary>
    public class OnlineScoresQuery
    {
        bool queried = false;
        public int BeatmapID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public OsuGameMode Mode { get; set; } = OsuGameMode.Osu;
        public string OsuApiKey { get; set; }
        public int Mods { get; set; } = 0;
        public OnlineScoreCollection res = new OnlineScoreCollection();
        public OnlineScoreCollection Result
        {
            get
            {
                if (!queried)
                {
                    GetResult();
                    queried = true;
                }
                return res;
            }
            private set
            {
                res = value;
            }
        }
        int lim = 50;
        public int Limit
        {
            get => lim;
            set
            {
                if (OnlineQueryTools.InRange(0, 100, value))
                    lim = value;
            }
        }
        void GetResult()
        {
            if (BeatmapID == 0)
                throw new ArgumentException("必须指定谱面ID。");
            string basestr = $"https://osu.ppy.sh/api/get_scores?k={OsuApiKey}";
            StringBuilder b = new StringBuilder(basestr);
            b.Append(UserID != 0 ? $"&u={UserID}" : string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName) ? "" : $"&u={UserName}");
            b.Append($"&b={BeatmapID}");
            b.Append(Mods == 0 ? "" : $"&mods={Mods}");
            b.Append($"&m={(int)Mode}");
            System.Windows.Forms.MessageBox.Show(b.ToString());
            QueryResult q = OnlineQueryTools.GetResponse(new Uri(b.ToString()));
            foreach (var json in q.Results)
            {
                res.Scores.Add(new OnlineScore(json.ToString(),Mode,BeatmapID));
            }

        }
    }
    /// <summary>
    /// 在线查询玩家的最佳记录
    /// </summary>
    public class OnlineUserBestQuery
    {
        bool queried = false;
        public string OsuApiKey { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public OsuGameMode Mode { get; set; } = OsuGameMode.Osu;
        int lim = 10;
        public int Limit
        {
            get => lim;
            set
            {
                if (OnlineQueryTools.InRange(0, 50, value))
                    lim = value;
            }
        }
        OnlineBestRecordCollection res = new OnlineBestRecordCollection();
        public OnlineBestRecordCollection Results
        {
            get
            {
                if (!queried)
                {
                    GetResult();
                    queried = true;
                }
                return res;
            }
            private set
            {
                res = value;
            }
        }
        void GetResult()
        {
            if (UserID == 0)
                if (string.IsNullOrEmpty(UserName))
                    throw new ArgumentException("必须指定用户名或用户ID。");
            string basestr = $"https://osu.ppy.sh/api/get_user_best?k={OsuApiKey}";
            StringBuilder b = new StringBuilder(basestr);
            b.Append(UserID != 0 ? $"&u={UserID}&type=id&m={(int)Mode}" : $"&u={UserName}&type=string&m={(int)Mode}");
            QueryResult q = OnlineQueryTools.GetResponse(new Uri(b.ToString()));
            if(q.Results.Count==0)
            {
                res.Failed = true;
            }
            foreach (var json in q.Results)
            {
                res.Records.Add(new OnlineBestRecord(json.ToString(),Mode));
            }

        }
    }
}