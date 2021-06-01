namespace osuTools
{

    partial class SyncPPInfo
    {
        public int c300g { get => C300g; }
        public int c300 { get => C300; }
        public int c200 { get => C200; }
        public int c100 { get => C100; }
        public int c50 { get => C50; }
        public int cMiss { get => Cmiss; }
        public int FullCombo { get => rtppi.HitCount.FullCombo; }
        public int ObjectCount { get => rtppi.BeatmapTuple.ObjectsCount; }
        public string RawStr { get => rawstr; }
        public int MaxCombo { get =>rtppi.HitCount.CurrentMaxCombo; }
        public int PlayerMaxCombo { get => rtppi.HitCount.PlayerMaxCombo; }
        public int CurrentCombo { get => rtppi.HitCount.CurrentMaxCombo; }
        public double AccuracyPP { get => rtppi.SmoothPP.RealTimeAccuracyPP; }
        public double AimPP { get => rtppi.SmoothPP.RealTimeAimPP; }
        public double SpeedPP { get => rtppi.SmoothPP.RealTimeSpeedPP; }
        public double FCAccuracyPP { get => rtppi.SmoothPP.FullComboAccuracyPP; }
        public double FCAimPP { get => rtppi.SmoothPP.FullComboAimPP; }
        public double FCSpeedPP { get => rtppi.SmoothPP.FullComboSpeedPP; }
        public double MaxAccuracyPP { get => rtppi.SmoothPP.MaxAccuracyPP; }
        public double MaxAimPP { get => rtppi.SmoothPP.MaxAimPP; }
        public double MaxSpeedPP { get => rtppi.SmoothPP.MaxSpeedPP; }
        public double FcPP { get => rtppi.SmoothPP.FullComboPP; }
        public double MaxPP { get => rtppi.SmoothPP.MaxPP; }
        public double CurrentPP { get => rtppi.SmoothPP.RealTimePP; }
        public System.TimeSpan SongDuration { get { durat = System.TimeSpan.FromMilliseconds(rtppi.BeatmapTuple.Duration);return durat; } }
        public System.TimeSpan CurrentTime { get => System.TimeSpan.FromMilliseconds(rtppi.Playtime); }
        public double TimePercent { get => rtppi.Playtime/ rtppi.BeatmapTuple.Duration; }
        public string FormatedTimeStr { get => fortime; }
        public string FormatedPPStr { get => forpp; }
        public string FormatedHitStr { get => forhit; }
        public double Stars { get => rtppi.BeatmapTuple.Stars; }
        public bool Perfect
        {
            get
            {
                if (ot.GameMode.CurrentMode == OsuGameMode.Mania)
                {
                    return c100 == 0 && c50 == 0 && cMiss == 0;
                }
                if (ot.GameMode.CurrentMode == OsuGameMode.Osu)
                {
                    return FcPP == MaxPP;
                }
                return false;
            }
        }
        public double c300gRate
        {
            get => (double)c300g / (c300 + c300g);
        }
        public string AccuracyPPStr { get => AccuracyPP.ToString("f2"); }
        public string AimPPStr { get => AimPP.ToString("f2"); }
        public string SpeedPPStr { get => SpeedPP.ToString("f2"); }
        public string CurrentPPStr { get => CurrentPP.ToString("f2"); }
       
        public string MaxPPStr { get => MaxPP.ToString("f2"); }
        public string MaxAimPPStr { get => MaxAimPP.ToString("f2"); }
        public string MaxSpeedPPStr { get => MaxSpeedPP.ToString("f2"); }
        public string MaxAccuracyPPStr { get => MaxAccuracyPP.ToString("f2"); }
        public string FcPPStr { get => FcPP.ToString("f2"); }
        public string FcAimPPStr { get => FCAimPP.ToString("f2"); }
        public string FCSpeedPPStr { get => FCSpeedPP.ToString("f2"); }
        public string FCAccuracyPPStr { get => FCAccuracyPP.ToString("f2"); }
        public string CurrentTimeStr {
            get
            {
                string temp;
                temp = $"{CurrentTime.Minutes.ToString("d2")}:{CurrentTime.Seconds.ToString("d2")}";
                return temp;
            }
        }
        public string SongDurationStr {
            get
            {
                string temp;
                if(rtppi.Playtime>rtppi.BeatmapTuple.Duration)
                {
                    durat = System.TimeSpan.FromMilliseconds(rtppi.Playtime);
                }
                temp = $"{SongDuration.Minutes.ToString("d2")}:{SongDuration.Seconds.ToString("d2")}";
                return temp;
            }
        }
    }
    
}