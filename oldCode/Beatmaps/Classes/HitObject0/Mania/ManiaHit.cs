﻿namespace osuTools.Beatmaps.HitObject
{
    using System;
    /// <summary>
    /// 表示Mania中的一个Note
    /// </summary>
    public class ManiaHit : IHitObject
    {
        /// <summary>
        /// 该打击物件的类型
        /// </summary>
        public HitObjectTypes HitObjectType { get; } = HitObjectTypes.ManiaHit;
        /// <summary>
        /// 该打击物件相对于开始的偏移
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// 音效的类型
        /// </summary>
        public HitSounds HitSound { get;  set; } = HitSounds.Normal;
        /// <summary>
        /// 该打击物件出现的模式
        /// </summary>
        public OsuGameMode SpecifiedMode { get; } = OsuGameMode.Mania;
        /// <summary>
        /// 该Note所在的行
        /// </summary>
        public int Column { get; private set; }
        /// <summary>
        /// 谱面的键位数
        /// </summary>
        public int BeatmapColumn { get;  set; } = 0;
        /// <summary>
        /// 自定义音效
        /// </summary>
        public Sounds.HitSample HitSample { get;  set; }=new Sounds.HitSample();
        internal void SetBeatmapColumn(int column) => BeatmapColumn = (column >= 1 && column <= 10) ? column : -1;
        /// <summary>
        /// 此属性对ManiaHit无效
        /// </summary>
        public OsuPixel Position { get;  set; }
        int type;
        /// <summary>
        /// 使用字符串构建一个ManiaHit对象
        /// </summary>
        /// <param name="data"></param>
        public void Parse(string data)
        {
            string[] info = data.Split(',');
            if (BeatmapColumn == 0)
                throw new System.ArgumentException();
            Position = new OsuPixel(int.Parse(info[0]), int.Parse(info[1]));
            Offset = int.Parse(info[2]);
            type = int.Parse(info[3]);
            if(!HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(type).Contains(HitObjectTypes.HitCircle))
            {
                throw new System.ArgumentException("该行的数据不适用。");
            }
            else
            {
                Column = (int)Math.Floor(Position.x * BeatmapColumn / 512d);
                HitSound = HitObjectTools.GetGenericTypesByInt<HitSounds>(int.Parse(info[4]))[0];
                if (info.Length > 5)
                    HitSample = new Sounds.HitSample(info[5]);
            }
        }
        /// <summary>
        /// 以osu文件中的数据为标准的字符串
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {          
                return $"{Position.x},{Position.y},{Offset},{type},{(int)HitSound},{HitSample.GetData()}";
        }
    }
}