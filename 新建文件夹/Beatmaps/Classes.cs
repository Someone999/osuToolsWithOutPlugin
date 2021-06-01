namespace osuTools
{
    namespace Beatmaps
    {
        public partial class Beatmap
        {
            OsuGameMode mod;
            public OsuGameMode Mode { get => mod; }
            string t, ut, a, ua, c, dif, ver, fn, fullfn, dlnk, bgf, au, sou, tag, mak, md, fuau;
            double od = 0, cs = 0, hp = 0, ar = 0, stars = 0;
            int m = 0;
            int id;
            System.IO.FileInfo info;
            System.Security.Cryptography.MD5CryptoServiceProvider md5calc = new System.Security.Cryptography.MD5CryptoServiceProvider();
            public System.IO.FileInfo BeatmapFile { get => info; }
            //OsuRTDataProvider.BeatmapInfo.Beatmap bmap;
            //public OsuRTDataProvider.BeatmapInfo.Beatmap ToOsuRTDataProviderBeatmap { get => bmap; }
            public Beatmap(OsuRTDataProvider.BeatmapInfo.Beatmap x, double Stars = 0)
            {
                //bmap = x;
                t = x.Title;
                ut = x.TitleUnicode;
                a = x.Artist;
                ua = x.ArtistUnicode;
                c = x.Creator;
                dif = x.Difficulty;
                ver = x.Version;
                fn = x.Filename;
                fullfn = x.FilenameFull;
                dlnk = x.DownloadLink;
                bgf = x.BackgroundFilename;
                id = x.BeatmapID;
                sou = "";
                tag = "";
                mak = "";
                fuau = "";

                md = System.Text.Encoding.Default.GetString(md5calc.ComputeHash(System.IO.File.ReadAllBytes(x.FilenameFull)));
                stars = Stars;
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
                md = "";
                id = 0;
            }
            public override string ToString()
            {
                return $"{Artist} - {Title} [{Version}]";
            }
            public Beatmap(string s)
            {

                info = new System.IO.FileInfo("D:\\a\\s\\osu\\osu!\\Arcaea\\axuim\\axuim.osu");
                if (System.IO.File.Exists(s))
                {
                    info = new System.IO.FileInfo(s);
                }
                int i = 0;
                fn = info.Name;
                fullfn = info.FullName;
                string[] map = System.IO.File.ReadAllLines(s);
                foreach (string str in map)
                {

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
                        ut = temparr[1].Trim();
                    }
                    if (temparr[0].Contains("Artist") && temparr[0].Length <= "Artistuni".Length)
                    {
                        a = temparr[1].Trim();
                    }
                    if (temparr[0].Contains("ArtistUnicode"))
                    {
                        ua = temparr[1].Trim();
                    }
                    if (temparr[0].Contains("Creator"))
                    {
                        c = temparr[1].Trim();
                    }
                    if (temparr[0].Contains("Version"))
                    {
                        ver = temparr[1].Trim();
                        dif = ver;
                    }
                    if (temparr[0].Contains("Maker"))
                    {
                        mak = temparr[1].Trim();

                    }
                    if (temparr[0].Contains("Source"))
                    {
                        sou = temparr[1].Trim();

                    }
                    if (temparr[0].Contains("Tags"))
                    {
                        tag = temparr[1].Trim();

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

                        int.TryParse(temparr[1].Trim(), out m);
                        mod = new OsuGameMode(m);
                    }
                    dlnk = $"osu.ppy.sh/b/{BeatmapID}";
                    i++;
                    if (str.Contains("Background and Video events"))
                    {
                        break;
                    }
                }
                md = System.Text.Encoding.Default.GetString(md5calc.ComputeHash(System.IO.File.ReadAllBytes(info.FullName)));
                try
                {
                    string[] v = map[i].Split(',');
                    if (v.Length < 2)
                    {
                        throw new osuToolsException.FailToParse($"在文件{FullFileName}中获取图片文件名失败");
                    }
                    bgf = v[2].Trim('\"');
                }
                catch (osuToolsException.FailToParse x)
                {
                    //System.Diagnostics.Debug.WriteLine(x.Message);

                }
            }
            public void SetHPDrainRate(double Value)
            {
                hp = Value;
            }
            public void SetCircleSize(double Value)
            {
                cs = Value;
            }
            public void SetApproachRate(double Value)
            {
                ar = Value;
            }
            public void SetOverallDifficulty(double Value)
            {
                od = Value;
            }
            public void SetStars(double Value)
            {
                stars = Value;
            }
        }
    }
}