namespace osuTools
{
    using System.Collections.Generic;
    using System.Linq;
    namespace Beatmaps
    {
        public class SongInfoCollection
        {
            List<string> song = new List<string>();
            public IReadOnlyList<string> SongInfo { get => song.AsReadOnly(); }
            public SongInfoCollection(BeatmapCollection c)
            {
                foreach(var beatmap in c)
                {
                    song.Add(beatmap.ToString());
                }
            }
        }
        public class BeatmapCollection
        {
            
            List<Beatmap> beatmaps;
            public BeatmapCollection Find(string KeyWord)
            {
                BeatmapCollection b = new BeatmapCollection();
                foreach(var beatmap in beatmaps)
                {
                    if(beatmap.ToString().ToUpper().Contains(KeyWord.ToUpper()) || beatmap.Source.ToUpper().Contains(KeyWord.ToUpper())|| beatmap.Tags.ToUpper().Contains(KeyWord.ToUpper()))
                    {
                        b.Add(beatmap);
                    }
                }
                if(b.Beatmaps.Count==0)
                {
                    throw new osuTools.osuToolsException.BeatmapWasNotFound("找不到指定的谱面");
                }
                return b;
            }
            public Beatmap Find(int BeatmapID)
            {
                if (BeatmapID != -1)
                    foreach (var beatmap in beatmaps)
                    {
                        if(beatmap.BeatmapID==BeatmapID)
                        {
                            return beatmap;
                        }
                    }
                return null;
            }
            
            int sortfun(Beatmap a, Beatmap b)
            {
                int ret = string.Compare(a.Title, b.Title, true);
                return ret>0?1:ret==0?0:-1;
            }
            public IReadOnlyList<Beatmap> Beatmaps { get { beatmaps.Sort(sortfun);return beatmaps; } }
            List<string> sinfo = new List<string>();
            public IReadOnlyList<string> SongInfo { get => sinfo.AsReadOnly(); }
            public BeatmapCollection()
            {
                beatmaps = new List<Beatmap>();
            }
            internal void Add(Beatmap b)
            {
                
                beatmaps.Add(b);
                sinfo.Add(b.ToString());
            }
            public Beatmap this[int x]
            {
                get => beatmaps[x];
            }
            public BeatmapCollection Find(OsuGameMode Mode)
            {
                BeatmapCollection bc = new BeatmapCollection();
                foreach(var b in beatmaps)
                {
                    if(b.Mode==Mode)
                    {
                        bc.Add(b);
                    }
                }
                return bc;
            }
            internal void Remove(Beatmap b)
            {
                beatmaps.Remove(b);
                sinfo.Add(b.ToString());
            }
            public bool Contains(Beatmap b) => beatmaps.Contains(b);
            public IEnumerator<Beatmap> GetEnumerator()
            {
                return beatmaps.GetEnumerator();
            }
        }
        public static class BeatmapTools
        {
           
            public enum BeatmapSearchOption { AllBeatmaps = 0, OnlyTheFirstBeatmap }
            public static BeatmapCollection GetAllBeatmaps(string beatmapdir,BeatmapSearchOption option)
            {

                BeatmapCollection bc = new BeatmapCollection();
                if (option == BeatmapSearchOption.AllBeatmaps)
                {
                    string[] dirs = System.IO.Directory.GetFiles(beatmapdir, "*.osu", System.IO.SearchOption.AllDirectories);
                    foreach (string osufile in dirs)
                    {
                        Beatmap b = new Beatmap(osufile);
                        bc.Add(b);
                    }
                    return bc;
                }
                else if(option==BeatmapSearchOption.OnlyTheFirstBeatmap)
                {
                    string[] dirs = System.IO.Directory.GetDirectories("D:\\a\\s\\osu\\osu!\\songs\\","*",System.IO.SearchOption.AllDirectories);
                    
                    foreach(var dir in dirs)
                    {
                        var em=System.IO.Directory.GetFiles(dir+'\\', "*.osu", System.IO.SearchOption.AllDirectories);
                        try
                        {
                            if (em.Count() == 0)
                            {
                                throw new osuToolsException. NoBeatmapInFolder("指定的文件夹里不包含谱面", dir);
                            }
                            bc.Add(new Beatmap(em.First()));
                           
                        }
                        catch(osuToolsException.NoBeatmapInFolder x)
                        {
                            //System.Diagnostics.Debug.WriteLine($"已跳过目录{x.Folder}");
                        }
                    }
                    return bc;
                }
                return new BeatmapCollection();
            }
        }
    }
}