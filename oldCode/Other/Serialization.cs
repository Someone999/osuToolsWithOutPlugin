namespace osuTools
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    /// <summary>
    /// 通用的序列化、反序列化工具
    /// </summary>
    public class SerilazeTools
    {
        /// <summary>
        /// 序列化指定类型的对象到指定的文件
        /// </summary>
        /// <typeparam name="T">要序列化的对象的类型</typeparam>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="FileName">要写入的文件</param>
        public static void Serialize<T>(object obj, string FileName)
        {
            FileStream stream;
            string[] path = FileName.Split('\\');
            string replacedpath = FileName.Replace(path[path.Length - 1], "");
            if (!Directory.Exists(replacedpath))
                Directory.CreateDirectory(replacedpath);
            if (!File.Exists(FileName))
            {
                stream = new FileStream(FileName, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Close();
                return;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 从文件反序列化出对象
        /// </summary>
        /// <typeparam name="T">要生成的对象</typeparam>
        /// <param name="FileName">要读取的文件</param>
        /// <returns>使用文件数据生成的对象的实例</returns>
        public static T Deserialize<T>(string FileName)
        {
            FileStream stream;
            stream = new FileStream(FileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            T CurObj = (T)formatter.Deserialize(stream);
            stream.Close();
            return CurObj;
        }
    }
}