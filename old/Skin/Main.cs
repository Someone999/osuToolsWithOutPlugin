namespace osuTools
{
    namespace Skins
    {
        using System.IO;
        /// <summary>
        /// 存储皮肤的基本信息
        /// </summary>
        public class Skin
        {
            string[] lines;
            ManiaSkinConfig maniaSkin;
            /// <summary>
            /// Mania皮肤的配置
            /// </summary>
            public ManiaSkinConfig ManiaSkin { get => maniaSkin; }
            string skin;
            string SkinDir { get => skin; }
            /// <summary>
            /// 使用skin.ini或皮肤文件夹初始化Skin类
            /// </summary>
            /// <param name="SkinDir"></param>
            public Skin(string SkinDir)
            {
                string skinini = SkinDir;
                if (!SkinDir.Contains("skin.ini"))
                    skinini = Path.Combine(SkinDir, "skin.ini");
                if (File.Exists(skinini))
                {
                    lines = File.ReadAllLines(skinini);
                    skin = skinini.Replace("skin.ini", "");
                }
                else
                {
                    throw new FileNotFoundException();
                }

                GetInfo();
            }
            void GetInfo()
            {

                maniaSkin = new ManiaSkinConfig(lines);
                for (int i = 0; i < lines.Length; i++)
                {
                    //System.Diagnostics.Debug.WriteLine(lines[i]);


                    if (lines[i].Contains("Name"))
                    {
                        name = lines[i].Split(':')[1].Trim();
                    }
                    if (lines[i].Contains("Author"))
                    {
                        author = lines[i].Split(':')[1].Trim();
                    }
                }
            }
            /// <summary>
            /// 皮肤的名字
            /// </summary>
            public string Name { get => name; }
            string name;
            /// <summary>
            /// 皮肤的作者
            /// </summary>
            public string Author { get => author; }
            /// <summary>
            /// skin.ini的路径
            /// </summary>
            public string ConfigFileDir { get => Path.Combine(SkinDir, "skin.ini"); }
            string author;
        }
    }
}