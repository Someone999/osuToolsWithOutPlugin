namespace osuTools
{
    using System.IO;
    using System.Security.Cryptography;
    public  partial class OsrReader
    {
        string[] songs;
           short C300g, C300, C200, C100, C50, Cmiss, maxco;
           int sco, ver;
           byte mode, per, flag;
           bool perb;
           string md5, beatmapmd5, playern, modestr,fulf;
        
        string dir;
        OsrData data;
        BinaryReader r;
        FileStream fs;
      public OsrReader(string d)
        {
            if(File.Exists(d))
            {
                dir = d;
                fs = File.Open(d, FileMode.Open);
                r = new BinaryReader(fs);
                data = new OsrData(r,d);
            }
            
        }
        public OsrReader(BinaryReader re)
        {
            if(re is null)
            {
                throw new System.NullReferenceException();
                
            }
            else
            {
                r = re;
                data = new OsrData(r);
            }
            
        }
        public OsrData ReplayInfo { get => data; }
        public void GetBeatmap()
        {
            MD5CryptoServiceProvider m = new MD5CryptoServiceProvider();
            
                songs = Directory.GetFiles("D:\\a\\s\\osu\\osu!\\songs\\", "*.osu", SearchOption.AllDirectories);
                foreach (var song in songs)
                {

                    var data = File.Open(song, FileMode.Open);
                    var tmd5 = m.ComputeHash(data);
                    string mmd5 = System.Text.Encoding.Default.GetString(tmd5);
                    if (mmd5 == md5)
                    {
                        System.Windows.Forms.MessageBox.Show("Find!Beatmap is :" + song);
                        break;
                    }


                }
           
            System.Windows.Forms.MessageBox.Show("Not Found");
        }
       /* void Read()
        {
            mode = r.ReadByte();
            ver = r.ReadInt32();
            flag = r.ReadByte();
            beatmapmd5 = r.ReadString();
            flag = r.ReadByte();
            playern = r.ReadString();
            flag = r.ReadByte();
            md5 = r.ReadString();
            C300 = r.ReadInt16();
            C100 = r.ReadInt16();
            C50 = r.ReadInt16();
            Cmiss = r.ReadInt16();
            sco = r.ReadInt32();
            maxco = r.ReadInt16();
            per = r.ReadByte();
            if (per == 1)
            {
                perb = true;
            }
            else
            {
                perb = false;
            }
        }*/

    }
  
}