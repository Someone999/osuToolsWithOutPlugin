using Newtonsoft.Json.Linq;
using osuTools.ExtraMethods;
using osuTools.Online.ApiV1;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace osuTools.Online.ApiV2.Classes
{
    public class Availibility
    {
        public bool DownloadDisabled { get; internal set; } = false;
        public string MoreInformation { get; internal set; } = "";
    }
    public class Hype
    {
        public bool CanBeHyped { get; internal set; } = false;
        public int CurrentHyped { get; internal set; } = -1;
        public int RequiredHype { get; internal set; } = -1;
    }
    public class Nomination
    {
        public int CurrentNominations { get; internal set; } = -1;
        public int RequiredNominations { get; internal set; } = -1;
    }
    public class OnlineBeatmapSetV2
    {
        public List<OnlineBeatmapV2> Beatmaps { get; internal set; } = new List<OnlineBeatmapV2>();
        public string Artist { get; internal set; } = "";
        public string ArtistUnicode { get; internal set; } = "";
        public ImageUrl Covers { get; internal set; } = new ImageUrl();
        public string Creator { get; internal set; } = "";
        public int CreatorUserID { get; internal set; } = -1;
        public int FavoriteCount { get; internal set; } = -1;
        public int SetID { get; internal set; } = -1;
        public int PlayCount { get; internal set; } = -1;
        public string PreviewUrl { get; internal set; } = "";
        public string Source { get; internal set; } = "";
        public BeatmapStatus Status { get; internal set; } = BeatmapStatus.None;
        public string Title { get; internal set; } = "";
        public string TitleUnicode { get; internal set; } = "";
        public bool HasVideo { get; internal set; } = false;
        public Availibility BeatmapAvailability { get; internal set; } = new Availibility();
        public double BPM { get; internal set; } = -1;
        public Hype HypeStatus { get; internal set; } = new Hype();
        public bool IsScoreable { get; internal set; } = false;
        public DateTime? LastUpdate { get; internal set; } = null;
        public string LegacyThreadUrl { get; internal set; } = "";
        public Nomination Nominations { get; internal set; } = new Nomination();
        public bool Ranked { get; internal set; } = false;
        public DateTime? RankedDate { get; internal set; } = null;
        public bool HasStoryBoard { get; internal set; } = false;
        public DateTime? SubmittedDate { get; internal set; } = null;
        public string Tags { get; internal set; } = "";
        public List<double> Rating { get; internal set; } = new List<double>();
        public OnlineBeatmapSetV2(JObject json)
        {
            JObject setinfo = new JObject();
            JArray beatmaps = new JArray();
            if (json.GetValue("beatmaps") != null)
            {
                setinfo = json;
                beatmaps = (JArray)json["beatmaps"];
                foreach (var js in beatmaps)
                    Beatmaps.Add(new OnlineBeatmapV2((JObject)js));
            }
            else
            {
                setinfo = (JObject)json["beatmapset"];
                Beatmaps.Add(new OnlineBeatmapV2(json));
            }
            Artist = setinfo["artist"].ToString();
            ArtistUnicode = setinfo["artist_unicode"].ToString();
            Creator = setinfo["creator"].ToString();
            FavoriteCount = setinfo["favourite_count"].ToObject<int>();
            SetID = setinfo["id"].ToObject<int>();
            PlayCount = setinfo["play_count"].ToObject<int>();
            PreviewUrl = setinfo["preview_url"].ToString();
            Source = setinfo["source"].ToString();
            var arr = setinfo["status"].ToString().ToCharArray();
            arr[0] -= (char)Math.Abs('A' - 'a');
            Status = (BeatmapStatus)Enum.Parse(typeof(BeatmapStatus), new string(arr));
            Title = setinfo["title"].ToString();
            TitleUnicode = setinfo["title_unicode"].ToString();
            CreatorUserID = setinfo["user_id"].ToObject<int>();
            HasVideo = setinfo["video"].ToObject<bool>();
            BPM = setinfo["bpm"].ToObject<double>();
            IsScoreable = setinfo["is_scoreable"].ToObject<bool>();
            LastUpdate = setinfo["last_updated"].ToString().ToNullableDateTime();
            LegacyThreadUrl = setinfo["legacy_thread_url"].ToString();
            Ranked = setinfo["ranked"].ToObject<bool>();
            RankedDate = setinfo["ranked_date"].ToString().ToNullableDateTime();
            HasStoryBoard = setinfo["storyboard"].ToObject<bool>();
            SubmittedDate = setinfo["submitted_date"].ToString().ToNullableDateTime();
            Tags = setinfo["tags"].ToString();
            Rating = setinfo["ratings"].ToObject<List<double>>();
            #region 谱面的被推荐次数(???)
            var nomin = setinfo["nominations"];
            Nominations.CurrentNominations = nomin["current"].ToObject<int>();
            Nominations.RequiredNominations=nomin["required"].ToObject<int>();
            #endregion
            #region 谱面能否被宣传(???)
            var hyped = setinfo["hype"];
            HypeStatus.CanBeHyped = setinfo["can_be_hyped"].ToObject<bool>();
            HypeStatus.CurrentHyped = hyped["current"].ToObject<int>();
            HypeStatus.RequiredHype = hyped["required"].ToObject<int>();
            #endregion
            #region 谱面是否可下载
            var ava = setinfo["availability"];
            BeatmapAvailability.DownloadDisabled = ava["download_disabled"].ToObject<bool>();
            BeatmapAvailability.MoreInformation = ava["more_information"].ToString();
            #endregion
            #region 封面等图片
            JObject covers = (JObject)(setinfo["covers"]);
            Covers.Card = covers["card"].ToString();
            Covers.Card2x = covers["card@2x"].ToString();
            Covers.Cover= covers["cover"].ToString();
            Covers.Cover2x = covers["cover@2x"].ToString();
            Covers.List = covers["list"].ToString();
            Covers.List2x = covers["list@2x"].ToString();
            Covers.SlimCover = covers["slimcover"].ToString();
            Covers.SlimCover2x = covers["slimcover@2x"].ToString();
            #endregion

        }
        public OnlineBeatmapSetV2()
        {
            
        }

    }
    public class ImageUrl
    {
        public string Cover { get; internal set; }
        public string Cover2x { get; internal set; }
        public string Card { get; internal set; }
        public string Card2x { get; internal set; }
        public string List { get; internal set; }
        public string List2x { get; internal set; }
        public string SlimCover { get; internal set; }
        public string SlimCover2x { get; internal set; }
    }
    public class OnlineBeatmapV2
    {
        public double Stars { get; internal set; } = -1;
        public int BeatmapID { get; internal set; } = -2;
        public int BeatmapSetID { get; internal set; } = -2;
        public OsuGameMode Mode { get; internal set; } = OsuGameMode.Unkonwn;
        public string Version { get; internal set; } = "";
        public double OD { get; internal set; } = -1;
        public double AR { get; internal set; } = -1;
        public double HP { get; internal set; } = -1;
        public double CS { get; internal set; } = -1;
        public double BPM { get; internal set; } = -1;
        public bool Convert { get; internal set; } = false;
        public short CircleCount { get; internal set; } = -1;
        public short SliderCount { get; internal set; } = -1;
        public short SpinnerCount { get; internal set; } = -1;
        public DateTime? DeleteAt { get; internal set; } = null;
        public TimeSpan HitLength { get; internal set; } = new TimeSpan();
        public bool IsScoreable { get; internal set; } = false;
        public DateTime? LastUpdate { get; internal set; } = null;
        public int PassCount { get; internal set; } = -1;
        public int PlayCount { get; internal set; } = -1;
        public bool Ranked { get; internal set; } = false;
        public BeatmapStatus Status { get; internal set; } = BeatmapStatus.None;
        public TimeSpan TotalLength { get; internal set; } = new TimeSpan();
        public string BeatmapDownloadPageUrl { get; internal set; } = "";
        public List<int> FailTimesAtSongPercent { get; internal set; } = new List<int>();
        public List<int> ExitTimesAtSongPercent { get; internal set; } = new List<int>();
        public OnlineBeatmapV2(JObject json)
        {
            JToken jtoken;
            bool suc = json.TryGetValue("beatmaps", out jtoken);
            if (suc)
                throw new ArgumentException("不应用BeatmapSet的返回json实例化Beatmap。");
            Stars = json["difficulty_rating"].ToObject<double>();
            BeatmapID = json["id"].ToObject<int>();
            Mode = json["mode_int"].ToObject<OsuGameMode>();
            Version = json["version"].ToString();
            OD = json["accuracy"].ToObject<double>();
            AR = json["ar"].ToObject<double>();
            HP = json["drain"].ToObject<double>();
            BeatmapSetID = json["beatmapset_id"].ToObject<int>();
            BPM = json["bpm"].ToObject<double>();
            Convert = json["convert"].ToObject<bool>();
            CircleCount = json["count_circles"].ToObject<short>();
            SliderCount = json["count_sliders"].ToObject<short>();
            SpinnerCount = json["count_spinners"].ToObject<short>();
            DeleteAt = json["deleted_at"].ToString().ToNullableDateTime();
            HitLength = TimeSpan.FromSeconds(json["hit_length"].ToObject<int>());
            IsScoreable = json["is_scoreable"].ToObject<bool>();
            LastUpdate = json["last_updated"].ToString().ToNullableDateTime();
            PassCount = json["passcount"].ToObject<int>();
            PlayCount = json["playcount"].ToObject<int>();
            Ranked = json["ranked"].ToObject<bool>();
            var arr=json["status"].ToString().ToCharArray();
            arr[0] -= (char)Math.Abs('A' - 'a');
            Status = (BeatmapStatus)Enum.Parse(typeof(BeatmapStatus), new string(arr));
            TotalLength = TimeSpan.FromSeconds(json["total_length"].ToObject<int>());
            BeatmapDownloadPageUrl = json["url"].ToString();
            var failstat = json["failtimes"];
            FailTimesAtSongPercent = failstat["fail"].ToObject<List<int>>();
            ExitTimesAtSongPercent = failstat["exit"].ToObject<List<int>>();
        }
        public OnlineBeatmapV2()
        {
        }
    }
}