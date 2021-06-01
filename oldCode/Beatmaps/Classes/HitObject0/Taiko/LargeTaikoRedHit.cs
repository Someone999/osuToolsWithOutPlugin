﻿namespace osuTools.Beatmaps.HitObject
{
    /// <summary>
    /// 表示Taiko模式的内侧双打
    /// </summary>
    public class LargeTaikoRedHit : IHitObject
    {
        /// <summary>
        /// 该打击物件的类型
        /// </summary>
        public HitObjectTypes HitObjectType { get; } = HitObjectTypes.LargeTaikoRedHit;
        /// <summary>
        /// 该打击物件相对于开始的偏移
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// 音效
        /// </summary>
        public Sounds.HitSample HitSample { get; set; }
        /// <summary>
        /// 音效的类型
        /// </summary>
        public HitSounds HitSound { get; } = HitSounds.Normal;
        /// <summary>
        /// 该Note会出现的模式
        /// </summary>
        public OsuGameMode SpecifiedMode { get; } = OsuGameMode.Taiko;
        /// <summary>
        /// 此属性对LargeTaikoRedHit无效
        /// </summary>
        public OsuPixel Position { get; private set; }
        int type;
        /// <summary>
        /// 使用字符串构建一个LargeTaikoRedHit
        /// </summary>
        /// <param name="data"></param>
        public void Parse(string data)
        {
            string[] info = data.Split(',');
            Position = new OsuPixel(int.Parse(info[0]), int.Parse(info[1]));
            Offset = int.Parse(info[2]);
            type = int.Parse(info[3]);
            if (HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(type).Contains(HitObjectTypes.HitCircle))
            {
                if (info.Length > 5)
                    HitSample = new Sounds.HitSample(info[5]);

            }
        }
        /// <summary>
        /// 获取以osu文件的格式为标准的字符串
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            return $"{Position.x},{Position.y},{Offset},{type},{0},{HitSample.GetData()}";
        }
    }
}