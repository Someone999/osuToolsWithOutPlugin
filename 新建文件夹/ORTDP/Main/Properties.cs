namespace osuTools
{
    using System;
    public partial class ORTDP
    {
        public int c300g { get => C300g; }
        public int c300 { get => C300; }
        public int c200 { get => C200; }
        public int c100 { get => C100; }
        public int c50 { get => C50; }
        public int cMiss { get => Cmiss; }
        public int Combo { get => combo; }
        public double Score { get => score; }
        public int PlayTime { get => time; }
        public double HP { get => hp; }
        public string AccuracyPPStr { get => ppinfo.AccuracyPPStr; }
        public string AimPPStr { get => ppinfo.AimPPStr; }
        public string SpeedPPStr { get => ppinfo.SpeedPPStr; }
        public string CurrentPPStr { get => ppinfo.CurrentPPStr; }
        public int DiffcultyMultiply {get => dmp;}
        public string MaxPPStr { get => ppinfo.MaxPPStr; }
        public string MaxAimPPStr { get => ppinfo.MaxAimPPStr; }
        public string MaxSpeedPPStr { get => ppinfo.MaxSpeedPPStr; }
        public string MaxAccuracyPPStr { get => ppinfo.MaxAccuracyPPStr; }
        public string FcPPStr { get => ppinfo.FcPPStr; }
        public string FcAimPPStr { get => ppinfo.FcAimPPStr; }
        public string FcSpeedPPStr { get => ppinfo.FCSpeedPPStr; }
        public string FcAccuracyPPStr { get => ppinfo.FCAccuracyPPStr; }
        public string HPStr { get
            {

                double hh = hp,ff=0;
                hh = RealTimePPDisplayer.SmoothMath.SmoothDamp(hh, hp,ref ff, 0.2, 0.033);
                return (hh/200).ToString("p");
            }
        }
        public double Accuracy { get => acc; }
        public string AccuracyStr { get => (acc).ToString("f2"); }
        public Beatmaps.Beatmap Beatmap { get => b; }
        public int BestScore { get => bests; }
        public double BestPP { get => bestp; }
        public double ObjectPerSecond { get => persec; }
        public string Mods { get => mod; }
        public bool CanFail { get => canfail; }
        public string NowPlaying { get => np; }
        public GMMode GameMode { get => gm; }
        public int RetryCount{ get => rt; }
        public int PlayCount { get => ppc; }
        public string c300gRateStr {
            get
            {
                if (c300 + c300g != 0)
                {
                    return ((double)c300g / (c300 + c300g)).ToString("p");
                }
                else
                {
                    return "0%";
                }
            }
        }
        public string c300RateStr { get
            {
                if ((c300 + c100 + c50 + cMiss) != 0)
                   return c300Rate.ToString("p");
                else return "0%";
            }
        }
        public double c300Rate
        {
            get
            {
                if (CurrentMode != OsuGameMode.Mania)
                {
                   return (double)(c300) / (c300 + c100 + c50 + cMiss);
                }
                else
                {
                    return (double)(c300 + c300g) / (c300 + c300g + c200 + c100 + c50 + cMiss);
                }
            }
        }
        public string PlayerName { get => pn; }
        public double c300gRate { get => ((double)c300g / (c300 + c300g)); }
        public string Tags { get => b.Tags; }
        public string Source { get => b.Source; }
        //public int MaxCombo { get => mco; }
        public string CurrentRank
        {
            get
            {
                bool NoMiss = cMiss == 0;
                double All = c300 + c100 + c50 + cMiss;  
                double c100Rate = c100 / All;
                double c50Rate = c50 / All;
               // System.Windows.Forms.MessageBox.Show(OsuGameStatus.CurrentStatus.Contains("Playing").ToString());
                if (GameStatus.CurrentStatus==OsuGameStatus.Playing)
                {
                    if (GameMode.CurrentMode==OsuGameMode.Osu)
                    {
                        if (Accuracy == 100 && c300 == All)
                        {
                            Ranking = "SS";
                            if (Mods.Contains("HD") || Mods.Contains("FL"))
                            {
                                Ranking += "+";
                            }
                            return Ranking;

                        }
                        if (Accuracy > 93.17 && c50Rate < 0.01 && c100Rate < 0.1 && c300Rate > 0.9&&NoMiss)
                        {
                            Ranking = "S";
                            if (Mods.Contains("HD") || Mods.Contains("FL"))
                            {
                                Ranking += "+";
                            }
                            return Ranking;

                        }
                        if ((c300Rate > 0.8 && NoMiss) || ((c300Rate > 0.9 && !NoMiss)))
                        {
                            Ranking = "A";
                            return Ranking;
                        }
                        if ((c300Rate > 0.8 && !NoMiss) || (c300Rate > 0.7 && NoMiss))
                        {
                            Ranking = "B";
                            return Ranking;
                        }
                        if (c300Rate > 0.6)
                        {
                            Ranking = "C";
                            return Ranking;
                        }
                        else
                        {
                            Ranking = "D";
                            return Ranking;
                        }

                       
                    }
                    if (GameMode.CurrentMode==OsuGameMode.Catch)
                    {
                        if (Accuracy == 100)
                        {
                            Ranking = "SS";
                            if (Mods.Contains("HD") || Mods.Contains("FL"))
                            {
                                Ranking += "+";
                            }
                            return Ranking;
                        }

                        if(Accuracy>98.01)
                        {

                            Ranking = "S";
                            if (Mods.Contains("HD") || Mods.Contains("FL"))
                            {
                                Ranking += "+";
                            }
                            return Ranking;
                        }
                        if(Accuracy>94.01)
                        {
                            Ranking = "A"; return Ranking;
                        }
                        if(Accuracy>90)
                        {
                            Ranking = "B"; return Ranking;
                        }
                        if(Accuracy>80)
                        {
                            Ranking = "C"; return Ranking;
                        }
                        if(Accuracy<80)
                        {
                            Ranking = "D"; return Ranking;
                        }
                        
                    }
                    if(GameMode.CurrentMode==OsuGameMode.Mania)
                    {
                        if(Accuracy==100)
                        {
                            Ranking = "SS";
                            if (Mods.Contains("HD") || Mods.Contains("FL"))
                            {
                                Ranking += "+";
                            }
                            return Ranking;
                        }
                        if (Accuracy >95.01)
                        {
                            Ranking = "S";
                            if (Mods.Contains("HD") || Mods.Contains("FL"))
                            {
                                Ranking += "+";
                            }
                            return Ranking;
                        }
                        if (Accuracy >90.01)
                        {
                            Ranking = "A"; return Ranking;
                        }
                        if (Accuracy > 80.01)
                        {
                            Ranking = "B"; return Ranking;
                        }
                        if (Accuracy >70.01)
                        {
                            Ranking = "C"; return Ranking;
                        }
                        else
                        {
                            Ranking = "D"; return Ranking;
                        }
                       
                    }
                   
                }
                return Ranking;
            }
        }
       
        public Statistics Statistic { get => sta; }
        public OsuGameMode LastMode { get => gm.LastMode; }
        public OsuGameMode CurrentMode { get => gm.CurrentMode; }
        public GMStatus GameStatus { get => gs; }
        public OsuGameStatus LastStatus { get => gs.LastStatus; }
        public OsuGameStatus CurrentStatus { get => gs.CurrentStatus; }
        //public GMMod NMod { get => mo; }
        
        public DateTime SysTime { get => DateTime.Now; }
        public int FullCombo { get =>ppinfo.FullCombo; }
        public int ObjectCount { get => ppinfo.ObjectCount; }
        public int MaxCombo { get => ppinfo.MaxCombo; }
        public int PlayerMaxCombo { get => ppinfo.PlayerMaxCombo; }
        public int CurrentCombo { get => ppinfo.CurrentCombo; }
        public double AccuracyPP { get => ppinfo.AccuracyPP; }
        public double AimPP { get => ppinfo.AimPP; }
        public double SpeedPP { get => ppinfo.SpeedPP; }
        public double FCAccuracyPP { get => ppinfo.FCAccuracyPP; }
        public double FCAimPP { get => ppinfo.FCAimPP; }
        public double FCSpeedPP { get => ppinfo.FCSpeedPP; }
        public double MaxAccuracyPP { get => ppinfo.MaxAccuracyPP; }
        public double MaxAimPP { get => ppinfo.MaxAimPP; }
        public double MaxSpeedPP { get => ppinfo.MaxSpeedPP; }
        public double FcPP { get => ppinfo.FcPP; }
        public double MaxPP { get => ppinfo.MaxPP; }
        public double CurrentPP { get => ppinfo.CurrentPP; }
        public string Title { get => b.Title; }
        public string UnicodeTitle { get => b.UnicodeTitle; }
        public string Artist { get => b.Artist; }
        public string UnicodeArtist { get => b.UnicodeArtist; }
        public string Creator { get => b.Creator; }
        public string Difficulty { get => b.Difficulty; }
        public string Version { get => b.Version; }
        public string FileName { get => b.FileName; }
        public string FullFileName { get => b.FullFileName; }
        public string DownloadLink { get => b.DownloadLink; }
        public string BackgroundFileName { get => b.BackgroundFileName; }
        public int BeatmapID { get => b.BeatmapID; }
        public double OD { get => b.OD; }
        public double HPRate { get => b.HP; }
        public double AR { get => b.AR; }
        public double CS { get => b.CS; }
        //public double Stars { get => b.Stars; }
        public string AudioFileName { get => b.AudioFileName; }
        public TimeSpan SongDuration
        {
            get
            {
               if(time<=dur.TotalMilliseconds)
                {
                    return dur;
                }
               else if(time>dur.TotalMilliseconds+500)
                {
                    return TimeSpan.FromMilliseconds(time);
                }
                return new TimeSpan();
            } 
        }
        public TimeSpan CurrentTime { get => cur; }
        public double TimePercent { get => tmper;}
        public string TimePercentStr { get => tmper.ToString("p"); }
        public string FormatedTimeStr { get => ppinfo.FormatedTimeStr; }
        public string FormatedPPStr { get => ppinfo.FormatedPPStr; }
        public string FormatedHitStr { get => ppinfo.FormatedHitStr; }
        public string RawStr { get => ppinfo.RawStr; }
        public string PPpercent { get => (ppinfo.CurrentPP/ppinfo.MaxPP).ToString("p"); }
        public double Stars { get => ppinfo.Stars; }
        public string StarsStr { get => Stars.ToString("f2"); }
        public bool Perfect
        {
            get
            {
                if(Accuracy==100)
                {
                    return true;
                }
                if (GameMode.CurrentMode == OsuGameMode.Mania)
                {
                    return c100 == 0 && c50 == 0 && cMiss == 0;
                }
                if (GameMode.CurrentMode == OsuGameMode.Osu)
                {
                    return PlayerMaxCombo==MaxCombo;
                }
                return false;
            }
        }
        public string PerfectRank { get { if (Perfect) { return "&& Perfect"; } else { return ""; } } }
        public string CurrentTimeStr { get => ppinfo.CurrentTimeStr; }
        public string SongDurationStr { get=> ppinfo.SongDurationStr; }
        public string Diffculty { get => b.Difficulty; }

       
    }
}