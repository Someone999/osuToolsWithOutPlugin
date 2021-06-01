namespace osuTools
{
    namespace Beatmaps
    {
        using osuTools.Online;
        using System;
        using System.Collections.Generic;
        using StoryBoard;
        using System.Security.Cryptography;
        using System.Text;
        using osuTools.Online.ApiV1.Querier;
        using osuTools.Online.ApiV1;

        /// <summary>
        /// 谱面类，其中包含谱面的信息。
        /// </summary>
        [System.Serializable]
        public partial class Beatmap
        {
            OsuGameMode mode;
            /// <summary>
            /// 谱面的游戏模式
            /// </summary>
            public OsuGameMode Mode { get => mode; }
            string t = "", ut = "", a = "", ua = "", c = "", dif = "", ver = "", fn = "", fullfn = "", dlnk = "", bgf = "", au = "", sou = "", tag = "", mak = "", fuau = "", vi = "", fuvi = "", fubgf = "";
            MD5String md = new MD5String();
            bool havevideo = false;
            double od = 0, cs = 0, hp = 0, ar = 0, stars = 0;
            int m = 0;
            int id = -2048, setid = -2048, mco = 0;
            public int BeatmapSetID { get { if (setid == -2048) throw new NotSupportedException("暂不支持从谱面文件中获取BeatmapSetID"); else return setid; } }
            bool ModeHasSet = false;
            [NonSerialized]
            StringBuilder b = new StringBuilder();
            bool FileDataAvalable = false, FileStreamAvalable = false;
            System.IO.FileInfo info;
            [System.NonSerialized]
            MD5CryptoServiceProvider md5calc = new MD5CryptoServiceProvider();
            double bpm;
            public System.IO.FileInfo BeatmapFile { get { if (FileStreamAvalable) { return info; } else throw new System.NotSupportedException(); } }
            //OsuRTDataProvider.BeatmapInfo.Beatmap bmap;
            //public OsuRTDataProvider.BeatmapInfo.Beatmap ToOsuRTDataProviderBeatmap { get => bmap; }
            public Beatmap(Online.ApiV1.OnlineBeatmap olbeatmap)
            {
                t = olbeatmap.Title;
                ut = t;
                a = olbeatmap.Artist;
                ua = a;
                c = olbeatmap.Creator;
                dif = olbeatmap.Version;
                ver = dif;
                fn = "";
                fullfn = "";
                dlnk = "";
                sou = olbeatmap.Source;
                tag = olbeatmap.Tags;
                mak = "";
                md = new MD5String(olbeatmap.MD5);
                fuau = "";
            }
            internal void SetBeatmapID(int beatmap_id)
            {
                id = beatmap_id;
            }
            internal void SetBeatmapSetID(int beatmapset_id)
            {
                setid = beatmapset_id;
            }
            /// <summary>
            /// 在指定的文件夹搜索该谱面的录像。
            /// </summary>
            /// <param name="replyfolder">要搜索的文件夹</param>
            /// <returns>返回一个存储录像信息的类的数组</returns>
            public Replay.ReplayCollection GetReplaysForBeatmap(string replyfolder = "")
            {
                OsuInfo info = new OsuInfo();
                Replay.ReplayCollection r = new Replay.ReplayCollection();
                if (replyfolder == "")
                    replyfolder = info.OsuDirectory + "\\Replays";
                var replays = Replay.ReplayCollection.GetAllReplays(replyfolder);
                foreach (var replay in replays)
                {
                    if (replay.BeatmapMD5 == MD5.ToString())
                        r.Add(replay);
                }
                return r;
            }
            /// <summary>
            /// 使用osu!api在线查询谱面信息
            /// </summary>
            /// <returns></returns>
            public OnlineBeatmap GetOnlineBeatmap()
            {
                string osuApiKey = "fa2748650422c84d59e0e1d5021340b6c418f62f";
                OnlineBeatmapQuery q = new OnlineBeatmapQuery();
                q.OsuApiKey = osuApiKey;
                q.BeatmapID = BeatmapID;
                return q.Beatmaps[0];
            }
            /// <summary>
            /// 将该谱面转换成OsuBeatmap
            /// </summary>
            /// <returns></returns>
            public OsuDB.OsuBeatmap ToOsuBeatmap()
            {
                OsuInfo info = new OsuInfo();
                OsuDB.OsuBaseDB baseDB = new OsuDB.OsuBaseDB();
                return baseDB.Beatmaps.FindByMD5(MD5.ToString());
            }
            /// <summary>
            /// 使用OsuBeatmap初始化Beatmap对象
            /// </summary>
            /// <param name="beatmap"></param>
            /// <param name="getStars"></param>
            public Beatmap(OsuDB.OsuBeatmap beatmap, bool getStars = true)
            {
                OsuInfo info = new OsuInfo();
                t = beatmap.Title;
                ut = beatmap.TitleUnicode;
                a = beatmap.Artist;
                ua = beatmap.ArtistUnicode;
                c = beatmap.Creator;
                dif = beatmap.Difficulty;
                ver = dif;
                fn = beatmap.FileName;
                fullfn = info.BeatmapDirectory + "\\" + beatmap.FolderName + "\\" + beatmap.FileName;
                dlnk = $"http://osu.ppy.sh/b/{beatmap.BeatmapID}";
                sou = beatmap.Source;
                tag = beatmap.Tags;
                mak = "";
                md = new MD5String(beatmap.MD5);
                fuau = info.BeatmapDirectory + "\\" + beatmap.FolderName + "\\" + beatmap.AudioFileName;
                fuvi = "";
                od = beatmap.OD;
                hp = beatmap.HPDrain;
                ar = beatmap.AR;
                cs = beatmap.CS;
                setid = beatmap.BeatmapSetID;
                au = beatmap.AudioFileName;
                mode = beatmap.Mode;
                if (getStars)
                    double.TryParse(beatmap.Stars.ToString(), out stars);
                else stars = 0;
                if (fullfn == "" || !System.IO.File.Exists(fullfn)) return;
                var alllines = System.IO.File.ReadAllLines(FullFileName);
                foreach (string line in alllines)
                {
                    var temparr = line.Split(':');
                    if (temparr[0].StartsWith("0,0,\""))
                    {
                        if (!string.IsNullOrEmpty(bgf))
                            bgf = temparr[0].Split(',')[2].Replace("\"", "").Trim();
                    }
                    if (temparr[0].StartsWith("Video,"))
                    {
                        if (!string.IsNullOrEmpty(vi))
                        {
                            vi = temparr[0].Split(',')[2].Replace("\"", "").Trim();
                            havevideo = true;
                        }
                        else
                        {
                            havevideo = false;
                        }
                    }
                    fuvi = FullFileName.Replace(FileName, vi);
                    if (line.Contains("TimingPoints"))
                    {
                        break;
                    }
                }
                SetBeatmapID(beatmap.BeatmapID);

            }
            /// <summary>
            /// 使用MD5判断两个谱面是否相同
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static bool operator ==(Beatmap a, Beatmap b)
            {
                if (((object)a == null && (object)b != null) || ((object)a != null && (object)b == null)) return false;
                if ((object)a == null && (object)b == null) return true;
                try
                {
                    return a.MD5 == b.MD5;
                }
                catch (NullReferenceException)
                {
                    return false;
                }

            }
            /// <summary>
            /// 使用MD5判断两个谱面是否相同
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static bool operator !=(Beatmap a, Beatmap b)
            {
                if (((object)a == null && (object)b != null) || ((object)a != null && (object)b == null)) return true;
                if ((object)a == null && (object)b == null) return false;
                try
                {
                    return a.MD5 != b.MD5;
                }
                catch (NullReferenceException) 
                { return false; 
                }
                
            }
            /// <summary>
            /// 获取谱面所有的的休息时间
            /// </summary>
            /// <returns>返回一个BreakTime列表</returns>
            public List<BreakTime> GetBreakTimes()
            {
                List<BreakTime> breaktimes = new List<BreakTime>();
                DataBlock block = DataBlock.None;
                string[] map = System.IO.File.ReadAllLines(FullFileName);
                foreach (string str in map)
                {
                    if (str.Contains("Storyboard") && str.StartsWith("//"))
                    {
                        block = DataBlock.Background;
                    }
                    if (str.Contains("Break Periods") && str.StartsWith("//"))
                    {
                        block = DataBlock.BreakTime;
                    }
                    if (block == DataBlock.BreakTime)
                    {

                        string[] breakstr = str.Split(',');
                        if (breakstr.Length == 3)
                        {
                            if (int.Parse(breakstr[0]) == 2)
                                breaktimes.Add(new BreakTime(long.Parse(breakstr[1]), long.Parse(breakstr[2])));
                        }
                    }
                    if (str.Contains("HitObjects"))
                    {
                        block = DataBlock.HitObjects;
                        System.Diagnostics.Debug.WriteLine(block);
                        break;
                    }
                }
                return breaktimes;
            }
            /// <summary>
            /// 获取谱面中所有的打击物件
            /// </summary>
            /// <returns>返回一个包含所有IHitObjects的列表</returns>
           public HitObject.HitObjectCollection GetHitObjects()
            {
                DataBlock block = DataBlock.None;
                HitObject.HitObjectCollection objects = new HitObject.HitObjectCollection();
                string[] map = System.IO.File.ReadAllLines(FullFileName);
                foreach(var str in map)
                {                  
                    if (str.Contains("[HitObjects]"))
                    {
                        block = DataBlock.HitObjects;
                        continue;
                    }
                    if(block==DataBlock.HitObjects)
                    {
                        string[] comasp = str.Split(',');
                        if (comasp.Length > 4)
                        {
                            var realtype = HitObjectTypes.Unknown;
                            var types = HitObject.HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(int.Parse(comasp[3]));
                            if(types.Contains(HitObjectTypes.HitCircle))
                            {
                                realtype = HitObjectTypes.HitCircle;
                            }
                            if(types.Contains(HitObjectTypes.Slider))
                            {
                                realtype = HitObjectTypes.Slider;
                            }
                            if (types.Contains(HitObjectTypes.Spinner))
                            {
                                realtype = HitObjectTypes.Spinner;
                            }
                            if (types.Contains(HitObjectTypes.ManiaHold))
                            {
                                realtype = HitObjectTypes.ManiaHold;
                            }
                            if(Mode==OsuGameMode.Taiko)
                            {
                                var hitSounds = HitObject.HitObjectTools.GetGenericTypesByInt<HitSounds>(int.Parse(comasp[4]));
                                if(hitSounds.Count==1)
                                {
                                    if(hitSounds[0]==HitSounds.Finish)
                                    {
                                        realtype = HitObjectTypes.LargeTaikoRedHit;
                                    }
                                }
                                if (hitSounds.Contains(HitSounds.Clap)||hitSounds.Contains(HitSounds.Whistle))
                                {
                                    realtype = HitObjectTypes.TaikoBlueHit;
                                    if(hitSounds.Contains(HitSounds.Finish))
                                    {
                                        realtype = HitObjectTypes.LargeTaikoBlueHit;
                                    }
                                }
                                else if(hitSounds.Contains(HitSounds.Normal))
                                {
                                    realtype = HitObjectTypes.TaikoRedHit;
                                    if (hitSounds.Contains(HitSounds.Finish))
                                    {
                                        realtype = HitObjectTypes.LargeTaikoRedHit;
                                    }
                                }
              
                            }
                            var hit = HitObject.HitObjectTools.GetHitObjectClass(Mode, realtype);
                            if(Mode==OsuGameMode.Mania)
                            {
                                switch(realtype)
                                {
                                    case HitObjectTypes.HitCircle:((HitObject.ManiaHit)(hit)).SetBeatmapColumn((int)CS);break;
                                    case HitObjectTypes.ManiaHold: ((HitObject.ManiaHold)(hit)).SetBeatmapColumn((int)CS); break;
                                }
                            }
                            hit.Parse(str);
                            objects.Add(hit); 
                        }
                    }                    
                }                
                return objects;
            }
            /// <summary>
            /// 获取谱面中指定类型的打击物件
            /// </summary>
            /// <typeparam name="T">要获取的打击物件的类型</typeparam>
            /// <returns>包含所有指定类型的IHitObject的列表</returns>
            public List<T> GetHitObjects<T>() where T:HitObject.IHitObject
            {
                List<T> lst = new List<T>();
                var tmplst = GetHitObjects();
                foreach(var hitobject in tmplst)
                {
                    if(hitobject is T)
                    {
                        lst.Add((T)hitobject);
                    }
                }
                return lst;
            }
            /// <summary>
            /// 获取谱面所有的时间点
            /// </summary>
            /// <returns>包含所有TimePoint的列表</returns>
            /// <summary>
            /// 获取谱面所有的时间点
            /// </summary>
            /// <returns>包含所有TimePoint的列表</returns>
            public List<TimePoint> GetTimePoints()
            {
                DataBlock block = DataBlock.None;
                string[] map = System.IO.File.ReadAllLines(FullFileName);
                List<TimePoint> timePoints = new List<TimePoint>();
                var nstr = "";
                foreach (var str in map)
                {
                    if (str.Trim().StartsWith("[") && str.Trim().EndsWith("]"))
                    {
                        nstr = str.Trim().TrimStart('[').TrimEnd(']');
                    }
                    if (nstr == "TimingPoints")
                    {

                        string[] comasp = str.Split(',');
                        if (comasp.Length > 7)
                        {
                            timePoints.Add(new TimePoint(str));
                        }
                        continue;
                    }
                    if (nstr != "TimingPoints")
                    {
                        continue;
                    }
                }
                return timePoints;
            }
            /// <summary>
            /// 获取指定类型的StoryBoard的资源
            /// </summary>
            /// <typeparam name="T">要获取的资源类型</typeparam>
            /// <returns>包含指定资源信息的列表</returns>
            public List<T> GetStoryBoardResources<T>() where T:osuTools.StoryBoard.IStoryBoardResource,new()
            {
                string[] dirs=System.IO.Directory.GetFiles($"{FullFileName.Replace(FileName, "")}\\", "*.osb", System.IO.SearchOption.AllDirectories);
                string[] map=new string[1];
                if(dirs.Length>0)
                {
                    map=System.IO.File.ReadAllLines(dirs[0]);
                }
                else
                {
                    map = System.IO.File.ReadAllLines(FullFileName);
                }
                List<T> resources = new List<T>();
                foreach (var str in map)
                {
                    T obj = new T();                   
                    string[] comasp = str.Split(',');
                    if (comasp.Length == obj.ExcpectLength &&comasp[0]==obj.DataIdentifier)
                    {                            
                        obj.Parse(str);
                        resources.Add(obj);
                    }
                    else
                    {
                        continue;
                    }
                }
                return resources;

            }
            public List<IStoryBoardResource> GetStoryBoardResources()
            {
                string[] dirs = System.IO.Directory.GetFiles($"{FullFileName.Replace(FileName, "")}\\", "*.osb", System.IO.SearchOption.AllDirectories);
                string[] map = new string[1];
                if (dirs.Length > 0)
                {
                    map = System.IO.File.ReadAllLines(dirs[0]);
                }
                else
                {
                    map = System.IO.File.ReadAllLines(FullFileName);
                }
                List<IStoryBoardResource> resources = new List<IStoryBoardResource>();
                IStoryBoardResource resource = null;
                foreach (var line in map)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == "Sprite")
                    {
                        resource = new Sprite();
                        resource.Parse(line);
                    }
                    if (parts[0] == "Animation")
                    {
                        resource = new Animation();
                        resource.Parse(line);
                    }
                    if (parts[0] == "Sample")
                    {
                        resource = new Audio();
                        resource.Parse(line);
                    }
                    else
                        continue;
                    resources.Add(resource);
                }
                return resources;
            }

            public Beatmap()
            {
                fuau = "";
                au = "";
                t = "";
                ut = "";
                a = "";
                ua = "";
                c = "";
                dif = "";
                ver = "";
                fn = "";
                fullfn = "";
                dlnk = "";
                bgf = "";
                mak = "";
                sou = "";
                tag = "";
                md = new MD5String("");
                id = 0;
            }
            internal bool notv = false;
            public override string ToString()
            {
                return $"{Artist} - {Title} [{Version}]";
            }
            /// <summary>
            /// 通过osu文件路径来构造一个Beatmap
            /// </summary>
            /// <param name="s">osu文件路径</param>
            public Beatmap(string s)
            {
                FileDataAvalable = true;
                FileStreamAvalable = true;

                info = null;

                if (System.IO.File.Exists(s))
                {
                    info = new System.IO.FileInfo(s);
                }
                else
                {
                    throw new System.IO.FileNotFoundException("无法找到指定的谱面。");
                }
                int i = 0;
                fn = info.Name;
                fullfn = info.FullName;
                string[] map = System.IO.File.ReadAllLines(s);

                if (map.Length == 0)
                {
                    notv = true;
                    throw new osuToolsException.InvalidBeatmapFileException($"文件{s}为空。");                    
                }
                if (!map[0].Contains("osu file format"))
                {
                    notv = true;
                    throw new osuToolsException.InvalidBeatmapFileException($"文件{s}不是谱面文件。");
                }
                DataBlock block = DataBlock.None;

                foreach (string str in map)
                {
                    i++;
                    string[] temparr = str.Split(':');
                    if (temparr[0].Contains("AudioFile"))
                    {
                        au = temparr[1].Trim();
                        fuau = info.DirectoryName + "\\" + AudioFileName;
                    }
                    if (temparr[0].Contains("Title") && temparr[0].Length <= "Titleuni".Length)
                    {
                        t = temparr[1].Trim();
                    }


                    if (temparr[0].Contains("TitleUnicode"))
                    {
                        ut = str.Replace("TitleUnicode:","").Trim();
                    }
                    if (temparr[0].Contains("Artist") && temparr[0].Length <= "Artistuni".Length)
                    {
                        a = str.Replace("Artist:", "").Trim();
                    }
                    if (temparr[0].Contains("ArtistUnicode"))
                    {
                        ua = str.Replace("ArtistUnicode:", "").Trim();
                    }
                    if (temparr[0].Contains("Creator"))
                    {
                        c = str.Replace("Creator:", "").Trim();
                    }
                    if (temparr[0].Contains("Version"))
                    {
                        ver = str.Replace("Version:", "").Trim();
                        dif = ver;
                    }
                    if (temparr[0].Contains("Maker"))
                    {
                        mak = str.Replace("Maker:", "").Trim();

                    }
                    if (temparr[0].Contains("Source"))
                    {
                        sou = str.Replace("Source:", "").Trim();

                    }
                    if (temparr[0].Contains("Tags"))
                    {
                        tag = str.Replace("Tags:", "").Trim();

                    }
                    if (temparr[0].Contains("BeatmapID"))
                    {
                        int.TryParse(temparr[1].Trim(), out id);
                    }
                    if (temparr[0].Contains("CircleSize"))
                    {
                        double.TryParse(temparr[1].Trim(), out cs);
                    }
                    if (temparr[0].Contains("OverallDifficulty"))
                    {
                        double.TryParse(temparr[1].Trim(), out od);
                    }
                    if (temparr[0].Contains("ApproachRate"))
                    {
                        double.TryParse(temparr[1].Trim(), out ar);
                    }
                    if (temparr[0].Contains("HPDrainRate"))
                    {
                        double.TryParse(temparr[1].Trim(), out hp);
                    }
                    if (temparr[0].Contains("Mode"))
                    {
                        if (!ModeHasSet)
                        {
                            int.TryParse(temparr[1].Trim(), out m);
                            mode = (OsuGameMode)(m);
                            ModeHasSet = true;
                        }
                    }

                    dlnk = $"http://osu.ppy.sh/b/{BeatmapID}";
                    if (str.StartsWith("0,0,\""))
                    {
                        bgf = str.Split(',')[2].Replace("\"", "").Trim();
                    }
                    if (str.StartsWith("Video,"))
                    {
                        vi = str.Split(',')[2].Replace("\"", "").Trim();
                        havevideo = true;
                    }
                }
                md5calc.ComputeHash(System.IO.File.ReadAllBytes(info.FullName));
                md = md5calc.GetMD5String();
            }
            /// <summary>
            /// 设置HP
            /// </summary>
            /// <param name="Value"></param>
            public void SetHPDrainRate(double Value)
            {
                hp = Value;
            }
            /// <summary>
            /// 设置CS
            /// </summary>
            /// <param name="Value"></param>
            public void SetCircleSize(double Value)
            {
                cs = Value;
            }
            /// <summary>
            /// 设置AR
            /// </summary>
            /// <param name="Value"></param>
            public void SetApproachRate(double Value)
            {
                ar = Value;
            }
            /// <summary>
            /// 设置OD
            /// </summary>
            /// <param name="Value"></param>
            public void SetOverallDifficulty(double Value)
            {
                od = Value;
            }
            /// <summary>
            /// 设置难度星级
            /// </summary>
            /// <param name="Value"></param>
            public void SetStars(double Value)
            {
                stars = Value;
            }
        }
    }
}