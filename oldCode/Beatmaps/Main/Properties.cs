namespace osuTools
{
    namespace Beatmaps
    {
        public partial class Beatmap
        {
            /// <summary>
            /// 谱面对应音频文件的全路径
            /// </summary>
            public string FullAudioFileName { get => fuau; }
            /// <summary>
            /// 谱面对应图片文件的全路径
            /// </summary>
            public string FullBackgroundFileName { get => fubgf; }
            /// <summary>
            /// 谱面对应的视频文件的全路径
            /// </summary>
            public string FullVideoFileName { get { if (havevideo == true) return fuvi; else return null; } }
            /// <summary>
            /// 谱面对应的音频文件名
            /// </summary>
            public string AudioFileName { get => au; }
            /// <summary>
            /// 谱面对应的视频文件名
            /// </summary>
            public string VideoFileName { get { if (havevideo) return vi; else return null; } }
            /// <summary>
            /// 存储谱面的文件夹的全路径
            /// </summary>
            public string BeatmapFolder { get => fullfn.Replace(FileName, ""); }
            /// <summary>
            /// 谱面的MD5
            /// </summary>
            public MD5String MD5 { get => md; }
            /// <summary>
            /// 谱面的来源
            /// </summary>
            public string Source { get => sou; }
            /// <summary>
            /// 谱面的标签
            /// </summary>
            public string Tags { get => tag; }
            /// <summary>
            /// 谱面的作者
            /// </summary>
            public string Maker { get => mak; }
            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get => t; }
            /// <summary>
            /// 标题的Unicode形式
            /// </summary>
            public string UnicodeTitle { get => ut; }
            /// <summary>
            /// 艺术家
            /// </summary>
            public string Artist { get => a; }
            /// <summary>
            /// 艺术家的Unicode形式
            /// </summary>
            public string UnicodeArtist { get => ua; }
            /// <summary>
            /// 谱面的作者
            /// </summary>
            public string Creator { get => c; }
            /// <summary>
            /// 谱面的难度
            /// </summary>
            public string Difficulty { get => dif; }
            /// <summary>
            /// 谱面的难度
            /// </summary>
            public string Version { get => ver; }
            /// <summary>
            /// 谱面文件的文件名
            /// </summary>
            public string FileName { get => fn; }
            /// <summary>
            /// 谱面文件的全路径
            /// </summary>
            public string FullFileName { get => fullfn; }
            /// <summary>
            /// 谱面文件的下载链接
            /// </summary>
            public string DownloadLink { get => dlnk; }
            /// <summary>
            /// 背景文件的文件名
            /// </summary>
            public string BackgroundFileName { get => bgf; }
            /// <summary>
            /// 谱面ID
            /// </summary>
            public int BeatmapID { get => id; }
            /// <summary>
            /// 综合难度
            /// </summary>
            public double OD { get => od; }
            /// <summary>
            /// 掉血速度，回血难度
            /// </summary>
            public double HP { get => hp; }
            /// <summary>
            /// 缩圈速度
            /// </summary>
            public double AR { get => ar; }
            /// <summary>
            /// 圈圈大小
            /// </summary>
            public double CS { get => cs; }
            /// <summary>
            /// 难度星级
            /// </summary>
            public double Stars { get => stars; }
        }

    }
}