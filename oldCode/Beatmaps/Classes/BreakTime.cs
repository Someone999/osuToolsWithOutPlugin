namespace osuTools.Beatmaps
{
    using System;
    /// <summary>
    /// 表示一个休息时间。
    /// </summary>
    public class BreakTime
    {
        /// <summary>
        /// 开始时间，以毫秒为单位
        /// </summary>
        public long Start { get; internal set; }
        /// <summary>
        /// 结束时间，以毫秒为单位
        /// </summary>
        public long End { get; internal set; }
        /// <summary>
        /// 休息时间的间隔。
        /// </summary>
        public TimeSpan Period { get { return TimeSpan.FromMilliseconds(End - Start); } }
        /// <summary>
        /// 将休息时间转换成字符串形式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Start} to {End}";
        }
        /// <summary>
        /// 使用开始时间和结束时间构造一个BreakTime对象
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public BreakTime(long start, long end)
        {
            Start = start;
            End = end;
        }
        /// <summary>
        /// 判断给定时间是否在休息时间中
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool InBreakTime(long offset)
        {
            if (offset > Start && offset < End)
                return true;
            else return false;
        }
    }
}