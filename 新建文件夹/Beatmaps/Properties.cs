namespace osuTools
{
   namespace Beatmaps
    {
        public partial class Beatmap
        {
            public string FullAudioFileName { get => fuau; }
            public string MD5 { get => md; }
            public string Source { get => sou; }
            public string Tags { get => tag; }
            public string Maker { get => mak; }
            public string AudioFileName { get => au; }
            public string Title { get => t; }
            public string UnicodeTitle { get => ut; }
            public string Artist { get => a; }
            public string UnicodeArtist { get => ua; }
            public string Creator { get => c; }
            public string Difficulty { get => dif; }
            public string Version { get => ver; }
            public string FileName { get => fn; }
            public string FullFileName { get => fullfn; }
            public string DownloadLink { get => dlnk; }
            public string BackgroundFileName { get => bgf; }
            public int BeatmapID { get => id; }
            public double OD { get => od; }
            public double HP { get => hp; }
            public double AR { get => ar; }
            public double CS { get => cs; }
            public double Stars { get => stars; }
        }

    }
}