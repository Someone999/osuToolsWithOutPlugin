namespace osuTools
{
    namespace Online
    {
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using System;
        using System.Collections;
        public class OnlineBestResultCollection : OnlineInfo<OnlineBestResult>
        {
            OnlineBestResult[] Records = new OnlineBestResult[100];
            public OnlineBestResult[] Result { get => Records; }
            object IEnumerator.Current { get => Result[po]; }
            public OnlineBestResult this[int x]
            {
                get => Result[x];
            }
            int po = -1;
            public bool MoveNext()
            {
                if (po < Records.Length)
                {
                    po++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public OnlineBestResult Current
            {
                get => Records[po];
            }
            public void Reset()
            {
                po = -1;
            }
            public void Dispose()
            {

            }
            public OnlineBestResultCollection()
            {
                Sync.Tools.IO.CurrentIO.Write("OnlinneBestRecords Class");
            }
            public void AllParse(OsuApiQuery query)
            {
                if (query.QueryType != OsuApiType.GetBestRecords)
                {
                    throw new ArgumentException("请使用OsuApiType.GetBestRecords来获取最佳纪录!");
                }
                var j = query.Query();
                for (int zx = 0; zx < j.Count; zx++)
                {
                    try
                    {
                        Result[zx] = new OnlineBestResult(j[zx].ToString());
                    }
                    catch
                    {
                        this.Records[zx] = new OnlineBestResult();
                    }

                }
            }
        }

        public partial class OnlineBestResult : ScoreOperation
        {
            bool per;
            DateTime d;
            uint
            beatmap_id,
            score_id;
            double pp;
            int
            score,
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
            public OnlineBestResult()
            {
                per = false;
                d = DateTime.MinValue;
                beatmap_id = 0;
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
            public OnlineBestResult(string json)
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
                mscore = score;
                mpp = pp;
            }

        }
    }
}