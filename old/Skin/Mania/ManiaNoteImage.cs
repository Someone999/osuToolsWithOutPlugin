using System.IO;
using System.Windows.Forms.VisualStyles;

namespace osuTools.Skins
{
    /// <summary>
    /// 表示一个按键图标的信息
    /// </summary>
    public class ManiaNoteImage:ISkinImage
    {
        Skin s;
        /// <summary>
        /// 获取使用该图片的皮肤
        /// </summary>
        /// <returns></returns>
        public Skin GetSkin() => s;
        /// <summary>
        /// 图标的用途
        /// </summary>
        public string ImageUsage { get; private set; }
        /// <summary>
        /// 图标的名字
        /// </summary>
        public string Name { get; private set; }
        internal bool Failed { get; private set; } = false;
        string path;
        /// <summary>
        /// 图标的全路径
        /// </summary>
        public string Path {
            get
            {
                try
                {
                    string[] files = Directory.GetFiles(s.ConfigFileDir.Replace("skin.ini", ""), Name + ".*");
                    return files[0];
                }
                catch
                {
                    Failed = true;
                    return null;
                }
            }

            private set => path = value; }
        /// <summary>
        /// 将图标文件拷贝到指定目录
        /// </summary>
        /// <param name="path">目标路径</param>
        /// <param name="fileName">文件名</param>

        public void CopyTo(string path, string fileName = null)
        {
            if (string.IsNullOrEmpty(fileName))
                fileName = Name;
            if(!File.Exists(System.IO.Path.Combine(path, fileName)))
            File.Copy(Path, System.IO.Path.Combine(path, fileName));
        }
        void Parse(string str)
        {
            try
            {
                string[] data = str.Split('=');
                ImageUsage = data[0];
                Name = data[1];
                Name = System.IO.Path.GetFileName(Path);
            }
            catch
            {
                Failed = true;
            }

        }
        /// <summary>
        /// 使用skin.ini与一行数据初始化一个ManiaNoteImage对象
        /// </summary>
        /// <param name="skin"></param>
        /// <param name="data"></param>
        public ManiaNoteImage(Skin skin,string data)
        {
            s = skin;
            Parse(data);
        }
    }
}