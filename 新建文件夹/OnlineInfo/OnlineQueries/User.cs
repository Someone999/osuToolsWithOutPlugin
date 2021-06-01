namespace osuTools
{
    namespace Online
    {
        using System;
        using Newtonsoft.Json.Linq;
        public partial class OnlineUser
        {

            int user_id = 0;
            string username = "", join_date = "0-0-0 0:0:0";
            int playcount = 0;
            double ranked_score = 0.0, total_score = 0.0;
            int pp_rank = 0;
            double
            level = 0.0,
            pp_raw = 0.0,
            accuracy = 0.0;
            int
            count_rank_ss = 0,
            count_rank_ssh = 0,
            count_rank_s = 0,
            count_rank_sh = 0,
            count_rank_a = 0;
            string country = "";
            int
            total_seconds_played = 0,
            pp_country_rank = 0;
            DateTime t = new DateTime();
            OsuGameMode mode;
            public OnlineUser()
            {

            }
            public OnlineUser(OsuApiQuery query)
            {
                mode = query.Mode;
                Sync.Tools.IO.CurrentIO.Write("OnlineUserInfo Class");
                if (query.QueryType != OsuApiType.GetUserInfomation)
                {
                    throw new ArgumentException("请使用OsuApiType.GetUserInformation来获取用户信息!");
                }
                JArray jarr = query.Query();
                var jobj = jarr[0];
                int.TryParse(jobj["user_id"].ToString(), out user_id);
                int.TryParse(jobj["playcount"].ToString(), out playcount);
                int.TryParse(jobj["pp_rank"].ToString(), out pp_rank);
                int.TryParse(jobj["count_rank_ss"].ToString(), out count_rank_ss);
                int.TryParse(jobj["count_rank_ssh"].ToString(), out count_rank_ssh);
                int.TryParse(jobj["count_rank_s"].ToString(), out count_rank_s);
                int.TryParse(jobj["count_rank_sh"].ToString(), out count_rank_sh);
                int.TryParse(jobj["total_seconds_played"].ToString(), out total_seconds_played);
                int.TryParse(jobj["pp_country_rank"].ToString(), out pp_country_rank);
                double.TryParse(jobj["ranked_score"].ToString(), out ranked_score);
                double.TryParse(jobj["total_score"].ToString(), out total_score);
                double.TryParse(jobj["pp_raw"].ToString(), out pp_raw);
                double.TryParse(jobj["level"].ToString(), out level);
                double.TryParse(jobj["accuracy"].ToString(), out accuracy);
                username = jobj["username"].ToString();
                join_date = jobj["join_date"].ToString();
                country = jobj["country"].ToString();
                DateTime.TryParse(join_date, out t);
            }
            public override string ToString()
            {
                string temp;
                DateTime j = new DateTime((DateTime.Now.Ticks - t.Ticks - DateTime.MinValue.Ticks));
                temp = $"UserName:{UserName}(ID:{UserID})\nMode:{mode.ToString()} pp:{PP}\nGlobal Rank:{GlobalRank} Country Rank:{CountryRank}\n" +
                       $"Silver SS:{SSHCount} SS:{SSCount} Silver S:{SHCount} S:{SCount} A:{ACount}\n" +
                       $"Accuracy:{accuracy.ToString("f2")}% Total Score:{TotalScore} Ranked Score:{ranked_score}\n" +
                       $"Play Count{PlayCount}({$"{GameTime.Days}d {GameTime.Hours}:{GameTime.Minutes}:{GameTime.Seconds})"} Level:{level}\n" +
                       $"From {country}\nJoin at {JoinDate.ToString()}(Joined for {$"{j.Year}y{j.Month}mon{j.Day}d {j.Hour}h{j.Minute}m{j.Second}s"})\n";
                return temp;
            }

        }
    }
}