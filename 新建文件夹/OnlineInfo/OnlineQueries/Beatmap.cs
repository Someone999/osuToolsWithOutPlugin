namespace osuTools
{
    namespace Online
    {
        using System.Collections;
        using System.Collections.Generic;
        using System;
        using Newtonsoft.Json.Linq;
        public class OnlineBeatmapCollection : OnlineInfo<OnlineBeatmap>
        {
            OnlineBeatmap[] beatmaps;
            public OnlineBeatmap[] Result { get => beatmaps; }
            int pos = -1;
            int i = 0;
            public OnlineBeatmap this[int x]
            {
                get => beatmaps[x];
                set => beatmaps[x] = value;
            }
            public OnlineBeatmapCollection()
            {
                Sync.Tools.IO.CurrentIO.Write("OnlineBeatmaps Class");

            }
            object IEnumerator.Current { get => beatmaps[pos]; }
            public OnlineBeatmap Current
            {
                get => beatmaps[pos];
            }
            public bool MoveNext()
            {
                if (pos < beatmaps.Length)
                {
                    pos++; return true;
                }
                else
                    return false;
            }
            public void Reset()
            {
                pos = -1;
            }
            public void Dispose()
            {

            }
            public OnlineBeatmap[] Beatmaps { get => beatmaps; }
            public void AllParse(OsuApiQuery query)
            {


                if (query.QueryType != OsuApiType.GetBeatmaps)
                {
                    throw new ArgumentException("请使用OsuApiType.GetBeatmaps来获取谱面!");
                }
                var jarr = query.Query();
                beatmaps = new OnlineBeatmap[query.JsonArray.Count];
                for (int x = 0; x < jarr.Count; x++)
                {

                    try
                    {

                        beatmaps[x].Parse((JObject)jarr[x]);

                    }
                    catch
                    {
                        beatmaps[x] = new OnlineBeatmap();
                    }
                }
            }
            public IEnumerator<OnlineBeatmap> GetEnumerator()
            {
                for (int i = 0; i < pos; i++)
                    yield return beatmaps[i];

            }
        }
        public partial class OnlineBeatmap : IEquatable<OnlineBeatmap>
        {

            public bool IsEmpty()
            {
                if (file_md5 == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public void Parse(JObject jobj)
            {

                int.TryParse(jobj["beatmapset_id"].ToString(), out beatmapset_id);
                int.TryParse(jobj["beatmap_id"].ToString(), out beatmap_id);
                int.TryParse(jobj["approved"].ToString(), out approved);
                int.TryParse(jobj["total_length"].ToString(), out total_length);
                int.TryParse(jobj["hit_length"].ToString(), out hit_length);
                int.TryParse(jobj["mode"].ToString(), out mode);
                int.TryParse(jobj["count_normal"].ToString(), out count_normal);
                int.TryParse(jobj["count_slider"].ToString(), out count_slider);
                int.TryParse(jobj["count_spinner"].ToString(), out count_spinner);
                int.TryParse(jobj["creator_id"].ToString(), out creator_id);
                int.TryParse(jobj["genre_id"].ToString(), out genre_id);
                int.TryParse(jobj["language_id"].ToString(), out language_id);
                int.TryParse(jobj["playcount"].ToString(), out playcount);
                int.TryParse(jobj["passcount"].ToString(), out passcount);
                int.TryParse(jobj["favourite_count"].ToString(), out favourite_count);
                int.TryParse(jobj["max_combo"].ToString(), out max_combo);
                double.TryParse(jobj["diff_overall"].ToString(), out diff_overall);
                double.TryParse(jobj["diff_approach"].ToString(), out diff_approach);
                double.TryParse(jobj["diff_drain"].ToString(), out diff_drain);
                double.TryParse(jobj["diff_size"].ToString(), out diff_size);
                double.TryParse(jobj["bpm"].ToString(), out bpm);
                double.TryParse(jobj["rating"].ToString(), out rating);
                double.TryParse(jobj["diff_speed"].ToString(), out diff_speed);
                double.TryParse(jobj["diff_aim"].ToString(), out diff_aim);
                double.TryParse(jobj["difficultyrating"].ToString(), out difficultyrating);
                version = jobj["version"].ToString();
                file_md5 = jobj["file_md5"].ToString();
                submit_date = jobj["submit_date"].ToString();
                last_update = jobj["last_update"].ToString();
                approved_date = jobj["approved_date"].ToString();
                title = jobj["title"].ToString();
                artist = jobj["artist"].ToString();
                creator = jobj["creator"].ToString();
                tags = jobj["tags"].ToString();
                source = jobj["source"].ToString();
            }
            int beatmapset_id = -2;

            int beatmap_id = -2;

            int approved = -1;
            int total_length = -1;
            int hit_length = -1;
            string version = "";
            string file_md5 = "0";
            double diff_size = -1;
            double diff_overall = -1;

            double diff_approach = -1;

            double diff_drain = -1;

            int mode = -1;

            int count_normal = -1;

            int count_slider = -1;

            int count_spinner = -1;

            string submit_date = "0-0-0 0:0:0";

            string approved_date = "0-0-0 0:0:0";

            string last_update = "0-0-0 0:0:0";

            string artist = "";

            string title = "";

            string creator = "";

            int creator_id = 0;

            double bpm = 0.0;

            string source = "";

            string tags = "";

            int genre_id = 0;

            int language_id = 0;

            int favourite_count = 0;

            double rating = 0.0;

            int download_unavailable = 0;

            int audio_unavailable = 0;

            int playcount = 0;

            int passcount = 0;

            int max_combo = 0;

            double diff_aim = 0.0;

            double diff_speed = 0.0;

            double difficultyrating = 0.0;

            public override string ToString()
            {
                return $"{Artist} - {Title} [{Version}] ({tags})\nMode:{Mode.ToString()} Stars:{difficultyrating.ToString("f2")} BPM:{bpm}\nOD:{OD} AR:{AR} CS:{CS} HP:{HP}";
            }

            bool IEquatable<OnlineBeatmap>.Equals(OnlineBeatmap other)
            {
                if (file_md5 == other.file_md5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}