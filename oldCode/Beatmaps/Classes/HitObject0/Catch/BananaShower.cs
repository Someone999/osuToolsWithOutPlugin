﻿using System.Collections.Generic;
using System;
namespace osuTools.Beatmaps.HitObject
{


    public class BananaShower : IHitObject
    {
        public HitObjectTypes HitObjectType { get; } = HitObjectTypes.BananaShower;
        public int Offset { get; set; } = -1;
        public OsuPixel Position { get; } = new OsuPixel(256, 192);
        public HitSounds HitSound { get; private set; } = HitSounds.Normal;
        public Sounds.HitSample HitSample { get; private set; }=new Sounds.HitSample();
        public OsuGameMode SpecifiedMode { get; } = OsuGameMode.Catch;
        public int EndTime { get; internal set; }
        int type = 0;
        string hitsample;

        public void Parse(string data)
        {
            var info = data.Split(',');
            Offset = int.Parse(info[2]);
            type = int.Parse(info[3]);
            if (!HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(type).Contains(HitObjectTypes.Spinner))
            {
                throw new ArgumentException("该行的数据不适用。");
            }
            else
            {
                HitSound = HitObjectTools.GetGenericTypesByInt<HitSounds>(int.Parse(info[4]))[0];
                EndTime = int.Parse(info[5]);
                hitsample = info[6];
                HitSample = new Sounds.HitSample(info[6]);
            }
        }
        public string GetData()
        {
            return $"256,192,{Offset},{type},{1<<(int)HitSound},{EndTime},{hitsample}";
        }
    }
}