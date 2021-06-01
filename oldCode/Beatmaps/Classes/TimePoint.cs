namespace osuTools.Beatmaps
{
    using osuTools.ExtraMethods;
    using System;
    /// <summary>
    /// 表示一个时间点
    /// </summary>
    public class TimePoint
    {
        void bitprocesser(int num)
        {
            int cur = num;
            if (cur == 0) return;
            while (cur > 0)
            {
                int log2int = (int)Math.Truncate(Math.Log(cur, 2));
                int value = log2int;
                if (value == 0)
                {
                    KiaiTime = true;
                }
                if (value == 3)
                {
                    OmitFirstBarline = true;
                }
                cur -= (int)Math.Pow(2, log2int);
            }
        }
        /// <summary>
        /// 该时间点相对于歌曲开始的时间
        /// </summary>
        public int Offset { get; set; } = -1;
        /// <summary>
        /// 如果该时间点不是继承的，则为BPM，如果是继承的则为0
        /// </summary>
        public double BPM { get; private set; }
        /// <summary>
        /// 一个节拍所用的时间，以毫秒为单位
        /// </summary>
        public double BeatLength { get; private set; } = -1;
        /// <summary>
        /// 一次测量的节拍数
        /// </summary>
        public int Meter { get; private set; } = -1;
        /// <summary>
        /// 指定的音效的类型
        /// </summary>
        public SampleSets SampleSet { get; private set; } = SampleSets.Default;
        /// <summary>
        /// 音效的编号
        /// </summary>
        public int SampleIndex { get; private set; } = -1;
        /// <summary>
        /// 指定音效的音量
        /// </summary>
        public int Volume { get; private set; } = -1;
        /// <summary>
        /// 时间点是否为继承
        /// </summary>
        public bool Uninherited { get; private set; } = true;
        /// <summary>
        /// 是否开始一个KiaiTime
        /// </summary>
        public bool KiaiTime { get; private set; } = false;
        /// <summary>
        /// 是否省略Mania或Taiko的第一条小节线
        /// </summary>
        public bool OmitFirstBarline { get; private set; } = false;
        /// <summary>
        /// 滑条速度，单位为百分比
        /// </summary>
        public double SliderVelocity { get; private set; } = -1;
        /// <summary>
        /// 通过正确的字符串构造一个TimePoint对象
        /// </summary>
        /// <param name="line">指定的字符串</param>
        public TimePoint(string line)
        {
            string[] data = line.Split(',');
            Offset = int.Parse(data[0]);
            BeatLength = double.Parse(data[1]);
            Meter = int.Parse(data[2]);
            SampleSet = (SampleSets)int.Parse(data[3]);
            SampleIndex = int.Parse(data[4]);
            Volume = int.Parse(data[5]);
            Uninherited = int.Parse(data[6]).ToBool();
            if (!Uninherited)
            {
                SliderVelocity = BeatLength / 100;
                BeatLength = -1;
            }
            int effect = int.Parse(data[7]);
            BPM = 1 / BeatLength * 1000 * 60;
            bitprocesser(effect);
        }
        /// <summary>
        /// 返回TimePoint的部分信息。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Offset:{Offset} BPM:{BPM} BeatLength:{BeatLength} Uninherited:{Uninherited} KiaiTime:{KiaiTime} OmitFirstBarline:{OmitFirstBarline}";
        }
    }
}