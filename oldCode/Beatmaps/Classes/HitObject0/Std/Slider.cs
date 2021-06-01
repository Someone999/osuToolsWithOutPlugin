﻿using System.Collections.Generic;
using System;
namespace osuTools.Beatmaps.HitObject
{
    using Sounds;
    using System.Text;
    /// <summary>
    /// 表示一个滑条
    /// </summary>
    public class Slider : IHitObject
    {
        internal static CurveTypes GetCurveTypeByString(string str)
        {
            if (str == "B") return CurveTypes.Bezier;
            if (str == "C") return CurveTypes.CentripetalCatmullRom;
            if (str == "L") return CurveTypes.Linear;
            if (str == "P") return CurveTypes.PerfectCircle;
            return CurveTypes.Unknown;
        }
        string curvetype;
        public HitObjectTypes HitObjectType { get; } = HitObjectTypes.Slider;
        /// <summary>
        /// 该Slider相对于曲目开始的时间
        /// </summary>
        public int Offset { get; set; } = -1;
        public int RawHitSound { get; set; }
        /// <summary>
        /// 滑条在未指定StartingHitSound等时使用的音效
        /// </summary>
        public HitSounds HitSound { get; private set; } = HitSounds.Normal;
        /// <summary>
        /// 滑条在未指定StartingHitSound等时使用的自定义音效
        /// </summary>
        public Sounds.HitSample HitSample { get; private set; }=new Sounds.HitSample();
        /// <summary>
        /// 点到滑条开始的位置播放的音效以及自定义的数据
        /// </summary>
        public SliderHitSound StartingHitSound { get; private set; } = new SliderHitSound();
        /// <summary>
        /// 经过小豆豆时播放的音效以及自定义的数据
        /// </summary>
        public SliderHitSound DuringHitSound { get; private set; } = new SliderHitSound();
        /// <summary>
        /// 滑条结束时播放的音效以及自定义的数据
        /// </summary>
        public SliderHitSound EndingHitSound { get; private set; } = new SliderHitSound();
        /// <summary>
        /// 滑条的起始端点
        /// </summary>
        public OsuPixel Position { get; private set; }
        List<OsuPixel> curvePoints { get; set; } = new List<OsuPixel>();
        /// <summary>
        /// 绘制该滑条所需的点
        /// </summary>
        public IReadOnlyList<OsuPixel> CurvePoints{ get=>curvePoints.AsReadOnly(); }
        /// <summary>
        /// 滑条的算法
        /// </summary>
        public CurveTypes CurveType { get; private set; }
        /// <summary>
        /// 需要在滑条上走的次数
        /// </summary>
        public int RepeatTime { get; private set; }
        /// <summary>
        /// 滑条的长度
        /// </summary>
        public double Length { get; private set; }
        /// <summary>
        /// 滑条出现的特定模式
        /// </summary>
        public OsuGameMode SpecifiedMode { get; } = OsuGameMode.Osu;
        int type;
        /// <summary>
        /// 使用格式正确的字符串构造一个Slider
        /// </summary>
        /// <param name="data">要使用的字符串</param>
        public void Parse(string data)
        {
            var info = data.Split(',');
            Position = new OsuPixel(int.Parse(info[0]), int.Parse(info[1]));
            Offset = int.Parse(info[2]);
            type = int.Parse(info[3]);
            if(!HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(type).Contains(HitObjectTypes.Slider))
            {
                throw new System.ArgumentException("该行的数据不适用。");
            }
            else
            {
                RawHitSound = int.Parse(info[4]);
                HitSound = HitObjectTools.GetGenericTypesByInt<HitSounds>(int.Parse(info[4]))[0];
                var sliderinfo = info[5];
                var typeAndPoint = sliderinfo.Split('|');
                curvetype = typeAndPoint[0];
                CurveType = GetCurveTypeByString(curvetype);
                for(int i=1;i<typeAndPoint.Length;i++)
                {
                    var point = typeAndPoint[i].Split(':');
                    if (point.Length==2)
                    {
                        int x = int.Parse(point[0]);
                        int y = int.Parse(point[1]);
                        curvePoints.Add(new OsuPixel(x, y));
                    }
                }
                RepeatTime = int.Parse(info[6]);
                Length = double.Parse(info[7]);
                if (info.Length > 8)
                {
                    List<SampleSets> sampleSets = new List<SampleSets>();
                    List<SampleSets> additionSampleSets = new List<SampleSets>();
                    List<HitSounds> hitSounds = new List<HitSounds>();
                    var hitSoundstrs = info[8].Split('|');
                    foreach (var str in hitSoundstrs)
                    {
                        hitSounds.Add(HitObjectTools.GetGenericTypesByInt<HitSounds>(int.Parse(str))[0]);
                    }
                    if (hitSoundstrs.Length>0)
                        StartingHitSound = new SliderHitSound(hitSounds[0]);
                    if (hitSoundstrs.Length > 1)
                        DuringHitSound = new SliderHitSound(hitSounds[1]);
                    if (hitSoundstrs.Length>2)
                        EndingHitSound = new SliderHitSound(hitSounds[2]);
                    if (info.Length > 9)
                    {
                        var sampleSetstrs = info[9].Split('|');
                        for (int i = 0; i < sampleSetstrs.Length; i++)
                        {
                            var samples = sampleSetstrs[i].Split(':');
                            var sampleSet = int.Parse(samples[0]);
                            var addionSampleSet = int.Parse(samples[1]);
                            sampleSets.Add((SampleSets)sampleSet);
                            additionSampleSets.Add((SampleSets)addionSampleSet);
                        }
                        if(sampleSets.Count>1)
                            StartingHitSound = new SliderHitSound(hitSounds[0], new EdgeSound(sampleSets[0], additionSampleSets[0]));
                        if (sampleSets.Count > 2)
                            DuringHitSound = new SliderHitSound(hitSounds[1], new EdgeSound(sampleSets[1], additionSampleSets[1]));
                        if (sampleSets.Count > 3)
                            EndingHitSound = new SliderHitSound(hitSounds[2], new EdgeSound(sampleSets[2], additionSampleSets[2]));
                    }
                    if (info.Length > 10)
                        HitSample = new HitSample(info[10]);
                }
            }            
        }
        /// <summary>
        /// 获取osu!格式的数据
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            StringBuilder b = new StringBuilder($"{Position.x},{Position.y},{Offset},{type},{curvetype}");
            for (int i = 0; i < curvePoints.Count; i++)
            {
                if (curvePoints.Count == 1)
                {
                    b.Append("|" + curvePoints[i].GetData() + ",");
                    break;
                }
                if (i == curvePoints.Count - 1)
                {
                    b.Append("|" + curvePoints[i].GetData() + ",");
                }
                else
                    b.Append($"|{curvePoints[i].GetData()}");
                
            }
            b.Append($"{RepeatTime},{Length},{1<<(int)StartingHitSound.HitSound}|{1<<(int)DuringHitSound.HitSound}|{1<<(int)EndingHitSound.HitSound},");
            b.Append($"{StartingHitSound.Sound.GetData()}|{DuringHitSound.Sound.GetData()}|{EndingHitSound.Sound.GetData()},");
            b.Append($"{HitSample.GetData()}");
            return b.ToString();
        }
    }
}