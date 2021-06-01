namespace osuTools
{
    namespace Online
    {
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using System;
        using System.Collections;
        public class RecentOnlineResultCollection : OnlineInfo<RecentOnlineResult>
        {
            RecentOnlineResult[] results;
            int p = -1;
            public RecentOnlineResult this[int x]
            {
                get => results[x];
            }
            public RecentOnlineResult Current { get => results[p]; }
            object IEnumerator.Current { get => results[p]; }
            public RecentOnlineResult[] Result { get => results; }
            public void Dispose()
            {

            }
            public bool MoveNext()
            {
                if (p < results.Length)
                {
                    p++; return true;
                }
                else return false;
            }
            public void Reset()
            {
                p = -1;
            }
            public RecentOnlineResultCollection()
            {
                Sync.Tools.IO.CurrentIO.Write("OnlineRencentRecords Class");
            }
            public void AllParse(OsuApiQuery query)
            {
                results = new RecentOnlineResult[query.JsonArray.Count];
                if (query.QueryType != OsuApiType.GetRecentRecords)
                {
                    throw new ArgumentException("请用OsuApiType.GetRecentRecords获取最近的记录!");
                }
                var ja = query.Query();

                for (int x = 0; x < ja.Count; x++)
                {
                    try
                    {
                        results[x] = new RecentOnlineResult(ja[x].ToString());
                    }
                    catch
                    {
                        results[x] = new RecentOnlineResult();
                    }
                }
            }
        }
        public partial class RecentOnlineResult
        {
            bool per;
            DateTime d;
            uint
            beatmap_id;
            int score;
            int
            maxcombo,
            count50,
            count100,
            count300,
            countmiss,
            countkatu,
            countgeki,
            perfect,
            user_id;
            string
            date,
            rank;
            public RecentOnlineResult()
            {
                per = false;
                d = DateTime.MinValue;
                beatmap_id = 0;

                score = 0;

                maxcombo = 0;
                count300 = 0;
                count100 = 0;
                count50 = 0;
                countgeki = 0;
                countkatu = 0;
                countmiss = 0;
                perfect = 0;
                user_id = 0;
                date = "0-0-0 0:0:0";
                rank = "?";
            }
            public static bool operator >(RecentOnlineResult a, RecentOnlineResult b)
            {
                return a.score > b.score;
            }
            public static bool operator <(RecentOnlineResult a, RecentOnlineResult b)
            {
                return a.score < b.score;
            }
            public static bool operator >(RecentOnlineResult a, ScoreOperation b)
            {
                return a.score > b.mScore;
            }
            public static bool operator <(RecentOnlineResult a, ScoreOperation b)
            {
                return a.score < b.mScore;
            }
            public RecentOnlineResult(string json)
            {
                var jobj = (JObject)(JsonConvert.DeserializeObject(json));
                int.TryParse(jobj["countgeki"].ToString(), out countgeki);
                int.TryParse(jobj["countkatu"].ToString(), out countkatu);
                int.TryParse(jobj["count300"].ToString(), out count300);
                int.TryParse(jobj["count100"].ToString(), out count100);
                int.TryParse(jobj["count50"].ToString(), out count50);
                int.TryParse(jobj["countmiss"].ToString(), out countmiss);
                int.TryParse(jobj["maxcombo"].ToString(), out maxcombo);
                int.TryParse(jobj["score"].ToString(), out score);
                int.TryParse(jobj["user_id"].ToString(), out user_id);
                int.TryParse(jobj["perfect"].ToString(), out perfect);
                uint.TryParse(jobj["beatmap_id"].ToString(), out beatmap_id);
                date = jobj["date"].ToString();
                rank = jobj["rank"].ToString();
                DateTime.TryParse(date, out d);
                if (perfect == 1)
                {
                    per = true;
                }
                else if (perfect == 0)
                {
                    per = false;
                }
            }

        }
    }
}