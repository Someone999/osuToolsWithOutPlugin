namespace osuTools.OsuDB
{
    /// <summary>
    ///     一个变速点或时间标志。
    /// </summary>
    public class OsuBeatmapTimePoint
    {
        internal OsuBeatmapTimePoint(double bpm, double offset, bool uninherit)
        {
            Bpm = 1 / bpm * 1000 * 60;
            Offset = offset;
            Uninherit = uninherit;
        }

        /// <summary>
        ///     该时间点对应的BPM
        /// </summary>
        public double Bpm { get; internal set; }

        /// <summary>
        ///     该时间点相对于开始的偏移量
        /// </summary>
        public double Offset { get; internal set; }

        /// <summary>
        ///     是否为非继承时间线(是不是红线)
        /// </summary>
        public bool Uninherit { get; internal set; }
    }
}