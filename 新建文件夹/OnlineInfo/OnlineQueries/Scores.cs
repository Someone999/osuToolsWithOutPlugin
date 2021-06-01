namespace osuTools
{
    namespace Online
    {
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using System;
        using System.Collections;
        public class OnlineScoreCollection : OnlineInfo<OnlineScore>
        {
            OnlineScore[] r;
            int enumpos = -1;
            public OnlineScore bs;
            public OnlineScore BestScore { get => bs; }
            public void Dispose()
            {

            }
            public OnlineScore Current { get => r[enumpos]; }
            object IEnumerator.Current { get => r[enumpos]; }
            public OnlineScore[] Result { get => r; }
            public bool MoveNext()
            {
                if (enumpos < r.Length)
                {
                    enumpos++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset()
            {
                enumpos = -1;
            }
            public void AllParse(OsuApiQuery q)
            {
                r = new OnlineScore[q.JsonArray.Count];
                if (q.QueryType != OsuApiType.GetScores)
                {
                    throw new ArgumentException("请用OsuApiType.GetScores获取分数记录!");
                }
                var ja = q.Query();

                for (int x = 0; x < ja.Count; x++)
                {

                    try
                    {
                        r[x] = new OnlineScore(ja[x].ToString());
                    }
                    catch
                    {
                       
                        r[x] = new OnlineScore();
                    }
                }
            }

        }
        public partial class OnlineScore : ScoreOperation
        {
            bool per, rep;
            DateTime d;
            uint
            score_id;
            int score, replay_available;
            double pp;
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

            public OnlineScore()
            {
                replay_available = 0;
                per = false;
                d = DateTime.MinValue;
                rep = false;
                score_id = 0;
                score = 0;
                pp = 0.0;
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
            public OnlineScore(string json)
            {
                try
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
                    int.TryParse(jobj["replay_available"].ToString(), out replay_available);
                    uint.TryParse(jobj["score_id"].ToString(), out score_id);
                    double.TryParse(jobj["pp"].ToString(), out pp);
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
                    if (replay_available == 1)
                    {
                        rep = true;
                    }
                    else
                    {
                        rep = false;
                    }
                    mpp = pp;
                    mscore = score;
                }
                catch
                {
                    replay_available = 0;
                    per = false;
                    d = DateTime.MinValue;
                    rep = false;
                    score_id = 0;
                    score = 0;
                    pp = 0.0;
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
            }
        }
    }
}