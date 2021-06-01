using System;
namespace osuTools
{
    using OsuRTDataProvider.Mods;
    partial class ORTDP
    {
        System.Timers.Timer timer1=new System.Timers.Timer();
        int ManiaTotalhits=0;
        int OsuTotalhits = 0;
        int CTBTotalhits = 0;
        int mh, ch, oh;
        int ff = 0;
        int cc = 0;
        int hit = 0;
        int allhit;
        double persec = 0;
       void HitChanged()
        {
            System.Threading.Tasks.Task.Run(new Action(() =>
            {
                while (true)
                {
                    if (GameMode.CurrentMode == OsuGameMode.Mania)
                    {
                        allhit = c300g + c300 + c200 + c100 + c50 + cMiss;
                        System.Threading.Thread.Sleep(500);
                        persec = 2*((c300g + c300 + c200 + c100 + c50 + cMiss) - allhit);
                    }
                    if(GameMode.CurrentMode== OsuGameMode.Osu)
                    {
                        allhit =  c300 + c100 + c50 + cMiss;
                        System.Threading.Thread.Sleep(500);
                        persec = 2*(( c300 + c100 + c50 + cMiss) - allhit);
                    }
                    if(GameMode.CurrentMode==OsuGameMode.Catch)
                    {
                        allhit = c300 + c50 + cMiss;
                        System.Threading.Thread.Sleep(500);
                        persec = 2*((c300 + c50 + cMiss) - allhit);
                    }
                }
            }));

        }
        void InitLisenter()
        {
           
            p = new OsuRTDataProvider.OsuRTDataProviderPlugin();
            p.OnEnable();
            lm = p.ListenerManager;
            lm.OnCountGekiChanged += Lm_OnCountGekiChanged;
            lm.OnCount300Changed += Lm_OnCount300Changed;
            lm.OnCountKatuChanged += Lm_OnCountKatuChanged;
            lm.OnCount100Changed += Lm_OnCount100Changed;
            lm.OnCount50Changed += Lm_OnCount50Changed;
            lm.OnCountMissChanged += Lm_OnCountMissChanged;
            lm.OnComboChanged += Lm_OnComboChanged;
            lm.OnScoreChanged += Lm_OnScoreChanged;
            lm.OnPlayingTimeChanged += Lm_OnPlayingTimeChanged;
            lm.OnHealthPointChanged += Lm_OnHealthPointChanged;
            lm.OnAccuracyChanged += Lm_OnAccuracyChanged;
            lm.OnBeatmapChanged += Lm_OnBeatmapChanged;
            lm.OnModsChanged += Lm_OnModsChanged;
            lm.OnPlayModeChanged += Lm_OnPlayModeChanged;
            lm.OnStatusChanged += Lm_OnStatusChanged;
            lm.OnPlayerChanged += Lm_OnPlayerChanged;
            gm = new GMMode("???", "???");
            gs = new GMStatus("???", "???");
            t=new TotalHit(0,0,0);
            ca = new ClearAndFail();
            b = new Beatmaps.Beatmap();
            sta = new Statistics();
        }

        private void Lm_OnPlayerChanged(string player)
        {
            pn = player.Trim();
        }

        void InitLisenter(OsuRTDataProvider.OsuRTDataProviderPlugin pl)
        {
            HitChanged();
            p = pl;
            lm = p.ListenerManager;
            lm.OnCountGekiChanged += Lm_OnCountGekiChanged;
            lm.OnCount300Changed += Lm_OnCount300Changed;
            lm.OnCountKatuChanged += Lm_OnCountKatuChanged;
            lm.OnCount100Changed += Lm_OnCount100Changed;
            lm.OnCount50Changed += Lm_OnCount50Changed;
            lm.OnCountMissChanged += Lm_OnCountMissChanged;
            lm.OnComboChanged += Lm_OnComboChanged;
            lm.OnScoreChanged += Lm_OnScoreChanged;
            lm.OnPlayingTimeChanged += Lm_OnPlayingTimeChanged;
            lm.OnHealthPointChanged += Lm_OnHealthPointChanged;
            lm.OnAccuracyChanged += Lm_OnAccuracyChanged;
            lm.OnBeatmapChanged += Lm_OnBeatmapChanged;
            lm.OnModsChanged += Lm_OnModsChanged;
            lm.OnPlayModeChanged += Lm_OnPlayModeChanged;
            lm.OnStatusChanged += Lm_OnStatusChanged;
            gm = new GMMode("???", "???");
            gs = new GMStatus("???", "???");
            t = new TotalHit(0, 0, 0);
            ca = new ClearAndFail();
            b = new Beatmaps.Beatmap();
            sta = new Statistics();
        }
       
        private void Lm_OnPlayModeChanged(OsuRTDataProvider.Listen.OsuPlayMode last, OsuRTDataProvider.Listen.OsuPlayMode mode)
        {
            gm = new GMMode(last.ToString().Trim(), mode.ToString().Trim());
        }

        private void Lm_OnModsChanged(ModsInfo mods)
        {
            mod = mods.ShortName;
            mo = new GMMod(mods.Name);
            //unRanked = mod.Contains("AP") || mod.Contains("Auto") || mod.Contains("RL") || mod.Contains("V2");
            unRanked = mods.HasMod(ModsInfo.Mods.AutoPilot) && mods.HasMod(ModsInfo.Mods.Autoplay) && mods.HasMod(ModsInfo.Mods.Relax) && mods.HasMod(ModsInfo.Mods.ScoreV2);
            Ranked = !unRanked;
            canfail = !mods.HasMod(ModsInfo.Mods.NoFail) && !mods.HasMod(ModsInfo.Mods.AutoPilot) && !mods.HasMod(ModsInfo.Mods.SpunOut) && !mods.HasMod(ModsInfo.Mods.Autoplay) && !mods.HasMod(ModsInfo.Mods.Relax);
            ManiaRanked = !mods.HasMod(ModsInfo.Mods.KeyCoop) && !mods.HasMod(ModsInfo.Mods.HardRock) && !mods.HasMod(ModsInfo.Mods.Random) && Ranked;
            //System.Windows.Forms.MessageBox.Show(mods.Mod.ToString());

        }
         private void Lm_OnStatusChanged(OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus last_status, OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus status)
        {
            //System.Windows.Forms.MessageBox.Show("Changed","",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
            gs = new GMStatus(last_status.ToString().Trim(), status.ToString().Trim());
            if(last_status==OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.Playing&&status==OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.Rank&&Ranked)
            {
                ppc++;
            }
            if (GameStatus.CurrentStatus == OsuGameStatus.Idle || GameStatus.CurrentStatus == OsuGameStatus.SelectSong || GameStatus.CurrentStatus == OsuGameStatus.Playing)
            {
                
                if (status == OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.Rank && last_status == OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.Playing && !Mods.Contains("Auto"))
                {
                    cc++;
                    ca.AddSuccess();
                    sta = new Statistics(t, ca);
                }
            }
            if (status == OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.SelectSong)
            {
                rt = 0;
                ijk = 0;
            }
            while (last_status == OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.Rank || status == OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.Playing || status == OsuRTDataProvider.Listen.OsuListenerManager.OsuStatus.SelectSong)
            {
                
                    if (C300 != 0 || C300g != 0 || C200 != 0 || C100 != 0 || C50 != 0 || Cmiss != 0 || score != 0 || acc != 0)
                    {
                        C300 = 0;
                        C300g = 0;
                        C200 = 0;
                        C100 = 0;
                        C50 = 0;
                        Cmiss = 0;
                        score = 0;
                        acc = 0;
                        Ranking = "???";
                    }
                    else
                    {
                        break;
                    }
                    np = $"{b.Artist} - {b.Title} [{b.Difficulty}]";
                    stars = b.Stars;              
            }
        }

        private void Lm_OnBeatmapChanged(OsuRTDataProvider.BeatmapInfo.Beatmap map)
        {
            try
            {
                b = new Beatmaps.Beatmap(map);
                np = $"{b.Artist} - {b.Title} [{b.Difficulty}]";
                stars = b.Stars;
                string[] bi = System.IO.File.ReadAllLines(map.FilenameFull);
                double thp, tcs, tar, tod;
                double st;
                b.SetStars(rtppi.BeatmapTuple.Stars);
                b.SetOverallDifficulty(0);
                b.SetHPDrainRate(0);
                b.SetCircleSize(0);
                b.SetApproachRate(0);           
                mco = rtppi.HitCount.Combo;
                foreach (string i in bi)
                {
                    if (i.Contains("HPDrainRate"))
                    {
                        double.TryParse(i.Split(':')[1], out thp);
                        b.SetHPDrainRate(thp);
                    }
                    if (i.Contains("CircleSize"))
                    {
                        double.TryParse(i.Split(':')[1], out tcs);
                        b.SetCircleSize(tcs);
                    }
                    if (i.Contains("ApproachRate"))
                    {
                        double.TryParse(i.Split(':')[1], out tar);
                        b.SetApproachRate(tar);
                    }
                    if (i.Contains("OverallDifficulty"))
                    {
                        double.TryParse(i.Split(':')[1], out tod);
                        b.SetOverallDifficulty(tod);

                    }
                }
            }
            catch
            {

            }
           /* try
            {
                if (GameMode.CurrentMode==OsuGameMode.Mania)
                {
                    while (b.Stars == 0)
                    {
                        double.TryParse(System.IO.File.ReadAllText("D:\\osu\\stars.txt"), out st);
                        b.SetStars(st);
                    }
                    


                }
                else
                {

                    OppaiWNet.Wrap.Ezpp ez = new OppaiWNet.Wrap.Ezpp(System.IO.File.ReadAllBytes(b.FullFileName));
                    b.SetStars(ez.Stars);
                    mco = ez.MaxCombo;
                    
                }
            }
            catch (Exception x)
            {
                System.Windows.Forms.MessageBox.Show(x.ToString());
                b.SetStars(-1);
            }*/

        }

        private void Lm_OnCountGekiChanged(int hit)
        {
            C300g = hit;
          
            if (hit != 0)
            {
                if (Ranked && ManiaRanked)
                {
                    if (GameMode.CurrentMode==OsuGameMode.Mania)
                    {
                        ManiaTotalhits ++;
                       
                    }
                }
                t = new TotalHit(ManiaTotalhits, OsuTotalhits, CTBTotalhits);
                sta = new Statistics(t, ca);

            }
          
        }
        private void Lm_OnCount300Changed(int hit)
        {
            C300 = hit;
           
            if (hit != 0)
            {
                if (Ranked)
                {
                    if (ManiaRanked)
                    {
                        if (GameMode.CurrentMode==OsuGameMode.Mania)
                        {
                            ManiaTotalhits++;

                           
                        }
                    }
                    if (GameMode.CurrentMode==OsuGameMode.Mania)
                    {
                        OsuTotalhits = c300 + c100 + c50;
                    }
                    if (GameMode.CurrentMode==OsuGameMode.Mania)
                    {
                        CTBTotalhits = c300 + c100;
                    }
                    
                   
                }
            }
           
        }
        private void Lm_OnCountKatuChanged(int hit)
        {
            C200 = hit;
          
            if (hit!=0)
            {
                if (Ranked)
                {
                    if (ManiaRanked)
                    {
                        if (GameMode.CurrentMode==OsuGameMode.Mania)
                        {
                            ManiaTotalhits++;
                            
                        }
                    }

                }
                t = new TotalHit(ManiaTotalhits, OsuTotalhits, CTBTotalhits);
                sta = new Statistics(t, ca);
            }
           
        }
        private void Lm_OnCount100Changed(int hit)
        {
            C100 = hit;
            
            if (hit != 0)
            {
                if (Ranked)
                {
                    if (ManiaRanked)
                    {
                        if (GameMode.CurrentMode==OsuGameMode.Mania)
                        {
                            ManiaTotalhits++;
                        }
                    }
                    if (GameMode.CurrentMode==OsuGameMode.Osu)
                    {
                        OsuTotalhits++;
                    }
                    if (GameMode.CurrentMode==OsuGameMode.Catch)
                    {
                        CTBTotalhits++;
                    }
                }
                t = new TotalHit(ManiaTotalhits, OsuTotalhits, CTBTotalhits);
                sta = new Statistics(t, ca);
                
            }
           
        }
        private void Lm_OnCount50Changed(int hit)
        {
            C50 = hit;
            
            if (hit != 0)
            {
                if (Ranked)
                {
                    if (ManiaRanked)
                    {
                        if (GameMode.CurrentMode==OsuGameMode.Mania)
                        {
                            ManiaTotalhits ++;
                        }
                    }
                    if (GameMode.CurrentMode==OsuGameMode.Osu)
                    {
                        OsuTotalhits ++;
                    }
                }
                t = new TotalHit(ManiaTotalhits, OsuTotalhits, CTBTotalhits);
                sta = new Statistics(t, ca);
            }
        }
        private void Lm_OnCountMissChanged(int hit)
        {
            Cmiss = hit;
            
        }
        private void Lm_OnComboChanged(int combo)
        {
            this.combo = combo;
            if (GameMode.CurrentMode == OsuGameMode.Catch || GameMode.CurrentMode == OsuGameMode.Osu)
            {
                if (combo == 3)
                {
                    dmp = (int)Score - 900;
                }
            }
        }
        // IntPtr fcpp = OppaiWNet.Oppai.ezpp_new();
        //public double pp;+
        int ijk = 0;
        int flag = 0;
        private void Lm_OnPlayingTimeChanged(int ms)
        {
            
            if (ms != 0)
            {
                d = this;
            }
            double i = ms/rtppi.BeatmapTuple.Duration,k=0;
         
            
               tmper = RealTimePPDisplayer.SmoothMath.SmoothDamp(tmper, i, ref k, 0.5, 0.033);
                    tmper = ms/rtppi.BeatmapTuple.Duration;
            if(tmper>1)
            {
                tmper = 1;
            }
            // pp=OppaiWNet.Oppai.ezpp_pp(fcpp); 
            time = ms;
            
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
        }

        private void Lm_OnScoreChanged(int obj)
        {

            double current = obj - score, temp = 0;

            double ff = 0;
            score = obj;
            if (CurrentStatus == OsuGameStatus.SelectSong)
                ff++;
            if (obj == 0 && ff >= 0 && PlayerMaxCombo != 0)
            {
                if (CurrentStatus != OsuGameStatus.Rank)
                {
                    Sync.Tools.IO.CurrentIO.WriteColor($"Retry at {time}ms Score:{obj}", ConsoleColor.Yellow);
                    rt++;
                    OnRetry(rt);
                }

            }
            //scc = RealTimePPDisplayer.SmoothMath.SmoothDamp(score, obj, ref ff, 0.2, 0.033);
        }
        private void Lm_OnHealthPointChanged(double hp)
        {
            this.hp = hp;

            if (hp <= 0 && cMiss > 3 && CanFail && gs.CurrentStatus==OsuGameStatus.Playing && gs.LastStatus!=OsuGameStatus.Playing && !Mods.Contains("Unknown"))
            {
                //string c = $"{hp <= 0&&cMiss > 3&&CanFail&&Mods.Contains("NF")&&gs.CurrentStatus.ToString().Contains("Playing")&&!gs.LastStatus.Contains("Playing")}";//date1 = DateTime.Now;
                //System.Windows.Forms.MessageBox.Show(c,"",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);

                OnFail(new EventArgs());
                ff++;
                ca.AddFail();
                sta = new Statistics(t, ca);

            }
            if(hp<=0&&cMiss>3&&!CanFail)
            {
                
                OnNoFail(new EventArgs());
            }
        }
        private void Lm_OnAccuracyChanged(double acc)
        {
            this.acc = acc;
            double x=0;
            this.acc = RealTimePPDisplayer.SmoothMath.SmoothDamp(this.acc, acc, ref x, 0.2, 0.033);
        }


    }
}