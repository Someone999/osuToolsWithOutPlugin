namespace osuTools
{
    namespace Online
    {
        public class OsuApiType
        {
            string Type;
            System.Uri u;
            public static OsuApiType GetUserInfomation = new OsuApiType("get_user");
            public static OsuApiType GetBestRecords = new OsuApiType("get_user_best");
            public static OsuApiType GetRecentRecords = new OsuApiType("get_user_recent");
            public static OsuApiType GetBeatmaps = new OsuApiType("get_beatmaps");
            public static OsuApiType GetBeatmapBestRecords = new OsuApiType("get_user_best");
            public static OsuApiType GetScores = new OsuApiType("get_scores");

            private OsuApiType(string type)
            {

                //if (type == "get_user" || type == "get_user_best" || type == "get_user_recent" || type == "get_beatmaps"||type!= "get_scores")
                {
                    Type = type;
                }
                /*else
                {
                    throw new System.FormatException("无法获取\"" + type + "\"的信息");
                }*/
            }
            public override string ToString()
            {
                return Type;
            }
        }
    }
}