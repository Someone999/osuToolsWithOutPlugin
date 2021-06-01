namespace osuTools
{
    using System.Collections.Generic;
    namespace Skins
    {
        /// <summary>
        /// 存储Mania特定的皮肤信息
        /// </summary>
        public class ManiaSkinInfo
        {
            /// <summary>
            /// 判定线的位置
            /// </summary>
            public int HitPosition { get => hitpos; }
            int hitpos;
            bool bar;
            /// <summary>
            /// 是否显示判定线
            /// </summary>
            public bool JudgementLine { get => judge; }
            /// <summary>
            /// 小节线的粗度
            /// </summary>
            public bool BarlineHeight { get => bar; }
            bool judge;
            /// <summary>
            /// 使用判定线的位置，是否显示判定线，和小节线粗度构造一个ManiaSkinBasicInfo
            /// </summary>
            /// <param name="hitPosion"></param>
            /// <param name="judgementLine"></param>
            /// <param name="barline"></param>
            public ManiaSkinInfo(int hitPosion, bool judgementLine, bool barline)
            {
                hitpos = hitPosion;
                judge = judgementLine;
            }
        }
        /// <summary>
        /// Mania的皮肤的配置
        /// </summary>
        public class ManiaSkinConfig
        {
            string[] lines;
            /// <summary>
            /// 将多行数据依次解析为需要的数据
            /// </summary>
            /// <param name="data"></param>
            public ManiaSkinConfig(string[] data)
            {
                lines = data;
                Parse();
            }
            Dictionary<int, ManiaSkinInfo> skininfo;
            /// <summary>
            /// 1K的数据
            /// </summary>
            public ManiaSkinInfo Key1 { get => skininfo.CheckIndexAndGetValue(1); }
            /// <summary>
            /// 2K的数据
            /// </summary>
            public ManiaSkinInfo Key2 { get => skininfo.CheckIndexAndGetValue(2); }
            /// <summary>
            /// 3K的数据
            /// </summary>
            public ManiaSkinInfo Key3 { get => skininfo.CheckIndexAndGetValue(3); }
            /// <summary>
            /// 4K的数据
            /// </summary>
            public ManiaSkinInfo Key4 { get => skininfo.CheckIndexAndGetValue(4); }
            /// <summary>
            /// 5K的数据
            /// </summary>
            public ManiaSkinInfo Key5 { get => skininfo.CheckIndexAndGetValue(5); }
            /// <summary>
            /// 6K的数据
            /// </summary>
            public ManiaSkinInfo Key6 { get => skininfo.CheckIndexAndGetValue(6); }
            /// <summary>
            /// 7K的数据
            /// </summary>
            public ManiaSkinInfo Key7 { get => skininfo.CheckIndexAndGetValue(7); }
            /// <summary>
            /// 8K的数据
            /// </summary>
            public ManiaSkinInfo Key8 { get => skininfo.CheckIndexAndGetValue(8); }
            /// <summary>
            /// 9K的数据
            /// </summary>
            public ManiaSkinInfo Key9 { get => skininfo.CheckIndexAndGetValue(9); }
            void Parse()
            {
                int hitPos = 0;
                bool judgeLine = false;
                bool barLine = false;
                int k = 0;
                skininfo = new Dictionary<int, ManiaSkinInfo>();
                for (int i = 0; i < lines.Length; i++)
                {

                    if (lines[i].Contains("Keys:"))
                    {
                        //System.Diagnostics.Debug.WriteLine(lines[i]);
                        k = int.Parse(lines[i].Split(':')[1].Trim());
                    }
                    if (lines[i].Contains("JudgementLine"))
                    {
                        int x = int.Parse(lines[i].Split(':')[1].Trim()); ;
                        judgeLine = x.ToBool();
                    }
                    if (lines[i].Contains("HitPosition"))
                    {
                        hitPos = int.Parse(lines[i].Split(':')[1].Trim());
                    }
                    if (lines[i].Contains("BarlineHeight"))
                    {
                        barLine = (int.Parse(lines[i].Split(':')[1].Trim())).ToBool();
                    }

                    skininfo[k] = new ManiaSkinInfo(hitPos, judgeLine, barLine);
                }
            }

        }
    }
}