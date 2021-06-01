namespace osuTools.Beatmaps.HitObject
{
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// 存储IHitObject的集合
    /// </summary>
    public class HitObjectCollection:List<IHitObject>
    {
        /// <summary>
        /// 连接两个谱面
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="breakTimeInMs"></param>
        /// <returns></returns>
        public static HitObjectCollection Contract(HitObjectCollection a,HitObjectCollection b,int breakTimeInMs=0)
        {
            int beatmapoffset = a.Last().Offset;
            HitObjectCollection c = new HitObjectCollection();
            foreach (var hitobject in a)
                c.Add(hitobject);
            foreach (var hitobject in b)
            {
                hitobject.Offset += breakTimeInMs + beatmapoffset;
                if (hitobject is ManiaHold)
                    (hitobject as ManiaHold).EndTime += beatmapoffset + breakTimeInMs;
                if (hitobject is Spinner)
                    (hitobject as Spinner).EndTime += beatmapoffset + breakTimeInMs;
                if (hitobject is BananaShower)
                    (hitobject as BananaShower).EndTime += beatmapoffset + breakTimeInMs;
                c.Add(hitobject);
            }
            
           
            return c;

        }
        /// <summary>
        /// 将集合中的所有IHitObject按照osu文件的格式写入指定文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="overwrite"></param>
        public void WriteToFile(string file,bool overwrite=false)
        {
            List<string> datas = new List<string>();
            foreach(var hitobject in this)
            {
                datas.Add(hitobject.GetData());
            }
            if (!overwrite)
                System.IO.File.AppendAllLines(file,datas.ToArray());
            else
                System.IO.File.WriteAllLines(file, datas.ToArray());

        }
    }
}