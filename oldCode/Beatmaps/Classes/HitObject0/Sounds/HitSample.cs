﻿namespace osuTools.Beatmaps.HitObject.Sounds
{
    using System.Linq;
    /// <summary>
    /// 自定义音效
    /// </summary>
    public class HitSample
    {
        /// <summary>
        /// 普通预设音效
        /// </summary>
        public SampleSets NormalSet { get; private set; } = SampleSets.Default;
        /// <summary>
        /// 附加预设音效
        /// </summary>
        public SampleSets AdditionSet { get; private set; } = SampleSets.Default;
        /// <summary>
        /// 编号
        /// </summary>
        public int Index { get; private set; } = 0;
        /// <summary>
        /// 音量
        /// </summary>
        public int Volume { get; private set; } = 0;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; private set; } = "";
        /// <summary>
        /// 构建一个空的HitSample对象
        /// </summary>
        public HitSample()
        {

        }
        /// <summary>
        /// 使用两种音效，编号，音量，和文件名构造一个HitSample对象
        /// </summary>
        /// <param name="normalSet"></param>
        /// <param name="addtionSet"></param>
        /// <param name="index"></param>
        /// <param name="volume"></param>
        /// <param name="fileName"></param>
        public HitSample(SampleSets normalSet,SampleSets addtionSet,int index,int volume,string fileName)
        {
            NormalSet = normalSet;
            AdditionSet = addtionSet;
            Index = index;
            Volume = volume;
            if (!string.IsNullOrEmpty(fileName))
                FileName = fileName;
            else
                FileName = "";
        }
        /// <summary>
        /// 将字符串解析成HitSample对象
        /// </summary>
        /// <param name="data"></param>
        public HitSample(string data)
        {
            var datas = data.Split(':');
            NormalSet = (SampleSets)int.Parse(datas[0]);
            AdditionSet= (SampleSets)int.Parse(datas[1]);
            Index = int.Parse(datas[2]);
            Volume = int.Parse(datas[3]);
            var fileName = datas[4];
            if (string.IsNullOrEmpty(fileName))
            {
                FileName = "";
            }
            else FileName = fileName;
        }
        /// <summary>
        /// 将HitSample对象转换成字符串再转化为osu文件中的格式
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            return $"{(int)NormalSet}:{(int)AdditionSet}:{Index}:{Volume}:{FileName}";
        }
    }
}