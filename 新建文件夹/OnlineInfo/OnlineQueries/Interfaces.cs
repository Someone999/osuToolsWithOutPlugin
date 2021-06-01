namespace osuTools
{
    namespace Online
    {
        using System.Collections.Generic;
        public class ScoreOperation
        {
            protected int mscore = 0; protected double mpp = 0.0;
            public int mScore { get => mscore; }
            public double mPP { get => mpp; }
            public static bool operator <(ScoreOperation a, ScoreOperation b)
            {
                return a.mpp < b.mpp;
            }
            public static bool operator >(ScoreOperation a, ScoreOperation b)
            {
                return a.mpp > b.mpp;
            }
            public static bool operator <(ScoreOperation a, RecentOnlineResult b)
            {
                return a.mScore < b.Score;
            }
            public static bool operator >(ScoreOperation a, RecentOnlineResult b)
            {
                return a.mScore > b.Score;
            }
        }
        public interface OnlineInfo<out T> : IEnumerator<T>
        {
            T[] Result { get; }
            void AllParse(OsuApiQuery query);
        }
    }
}