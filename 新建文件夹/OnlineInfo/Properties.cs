namespace osuTools
{
    using System;
   namespace Online
    {
        
        partial class OnlineBeatmap
        {
            public int BeatmapSetID { get => beatmapset_id; }
            public int BeatmapID { get => beatmap_id; }
            public int Approved { get => approved; }
            public int TotalLength { get => total_length; }
            public int HitLength { get => hit_length; }
            public string Version { get => version; }
            public double CS { get => diff_size; }
            public string MD5 { get => file_md5; }
            public double OD { get => diff_overall; }
            public double AR { get => diff_approach; }
            public double HP { get => diff_drain; }
            public int Circle { get => count_normal; }
            public OsuGameMode Mode { get => new osuTools.OsuGameMode(mode); }
            public int Spinner { get => count_spinner; }
            public int Slider { get => count_slider; }
            public DateTime SubmitDate
            {
                get
                {
                    DateTime dt;
                    DateTime.TryParse(submit_date, out dt);
                    return dt;
                }
            }
            public DateTime ApprovedDate
            {
                get
                {
                    DateTime dt;
                    DateTime.TryParse(approved_date, out dt);
                    return dt;
                }
            }
            public DateTime LastUpdateDate
            {
                get
                {
                    DateTime dt;
                    DateTime.TryParse(last_update, out dt);
                    return dt;
                }
            }
            public string Artist { get => artist; }
            public string Title { get => title; }
            public string Creator { get => creator; }
            public int CreatorID { get => creator_id; }
            public double BPM { get => bpm; }
            public string Source { get => source; }
            public string Tags { get => tags; }
            public int GenreID { get => genre_id; }
            public int LanguageID { get => language_id; }
            public int FavoriteCount { get => favourite_count; }
            public double Rating { get => rating; }
            public bool Downloadable { get { if (download_unavailable == 0) return true; else return false; } }
            public bool AudioAvailable { get { if (audio_unavailable == 0) return true; else return false; } }
            public int PlayCount { get => playcount; }
            public int PassCount { get => passcount; }
            public int MaxCombo { get => max_combo; }
            public double AimDiff { get => diff_aim; }
            public double SpeedDiff { get => diff_speed; }
            public double Stars { get => difficultyrating; }
        }
        partial class OnlineUser
        {
            public int UserID { get => user_id; }
            public int PlayCount { get => playcount; }
            public double RankedScore { get => ranked_score; }
            public double TotalScore { get => total_score; }
            public double Accuracy { get => accuracy; }
            public double Level { get => level; }
            public double PP { get => pp_raw; }
            public int SSCount { get => count_rank_ss; }
            public int SSHCount { get => count_rank_ssh; }
            public int SCount { get => count_rank_s; }
            public int SHCount { get => count_rank_sh; }
            public int ACount { get => count_rank_a; }
            public int GlobalRank { get => pp_rank; }
            public int CountryRank { get => pp_country_rank; }
            public string UserName { get => username; }
            public string Country { get => country; }
            public DateTime JoinDate { get { return t; } }
            public TimeSpan GameTime { get { return TimeSpan.FromSeconds(total_seconds_played); } }
        }
        partial class OnlineBestResult
        {
            public uint BeatmapID { get => beatmap_id; }
            public uint ScoreID { get => score_id; }
            public int Score { get => score; }
            public double PP { get => pp; }
            public int MaxCombo { get => maxcombo; }
            public int c300g { get => countgeki; }
            public int c300 { get => count300; }
            public int c200 { get => countkatu; }
            public int c100 { get => count100; }
            public int c50 { get => count50; }
            public int cMiss { get => countmiss; }
            public int UserID { get => user_id; }
            public string Rank { get => rank; }
            public bool Perfect { get => per; }
            public DateTime GetDate { get => d; }
        }
       public partial class OnlineScore
        {
            public uint ScoreID { get => score_id; }
            public int Score { get => score; }
            public double PP { get => pp; }
            public int MaxCombo { get => maxcombo; }
            public int c300g { get => countgeki; }
            public int c300 { get => count300; }
            public int c200 { get => countkatu; }
            public int c100 { get => count100; }
            public int c50 { get => count50; }
            public int cMiss { get => countmiss; }
            public int UserID { get => user_id; }
            public string Rank { get => rank; }
            public bool Perfect { get => per; }
            public DateTime GetDate { get => d; }
            public bool ReplayAvailable { get => rep;  }
        }
        partial class RecentOnlineResult
        {
            public uint BeatmapID { get => beatmap_id; }
            public int Score { get => score; }
            public int MaxCombo { get => maxcombo; }
            public int c300g { get => countgeki; }
            public int c300 { get => count300; }
            public int c200 { get => countkatu; }
            public int c100 { get => count100; }
            public int c50 { get => count50; }
            public int cMiss { get => countmiss; }
            public int UserID { get => user_id; }
            public string Rank { get => rank; }
            public bool Perfect { get => per; }
            public DateTime GetDate { get => d; }
            
        }
    }
}