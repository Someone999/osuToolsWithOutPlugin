namespace osuTools
{
    using System.IO;
    using System;
   public class FileInfoHasNoValue :Exception{ public FileInfoHasNoValue(string m) : base(m) { } }
     public partial class OsrData
    {
        short C300g, C300, C200, C100, C50, Cmiss, maxco;
        int sco, ver;

        double acc;
        string accstr;
        byte mode, per, flag;
        bool perb;
        string md5, beatmapmd5, playern;
        OsuGameMode modestr;
        bool infonovalue;
        BinaryReader r;
        FileInfo Info;
        string d;
        public FileInfo ReplayFile
        {
            get
            {
                if (infonovalue)
                    throw new FileInfoHasNoValue("当前的构造函数没有为FileInfo赋值");
                else
                    return Info;

            }
        }
        public OsrData(BinaryReader b,string Dir)
        {
            if(b is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                r = b;
            }
            Info = new FileInfo(Dir);
            Read();
        }
        public OsrData(BinaryReader b)
        {
            if (b is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                r = b;
            }
            Info = null;
            infonovalue = true;
            Read();
        }
        void Read()
        {
            mode = r.ReadByte();
            modestr = new OsuGameMode(mode);
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
            acc = AccCalculater(new OsuGameMode(mode));
            accstr = acc.ToString("p");
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
        }
        double AccCalculater(OsuGameMode mode)
        {
            double a300 = 1, a200 = 2 / 3, a100 = 1 / 3, a50 = 1 / 6;
            if(Mode==OsuGameMode.Osu)
            {
                return (C300 + C100*a100 + C50*a50) / (C300 + C100 + C50 + Cmiss);
            }
            if(Mode==OsuGameMode.Catch)
            {
                return (C300 + C100 + C50) / (C50 + C100 + C300 + Cmiss + C200);
            }
            if(Mode==OsuGameMode.Taiko)
            {
                return (C300 + C100 * (1.0 / 2.0)) / (C300 + C100 + Cmiss);
            }
            if(Mode==OsuGameMode.Mania)
            {
                return (C300 + C300g + C200 * a200 + c100 * a100 + c50 * a50) / (c300 + c300g + c200 + c100 + c50 + cMiss);
            }
            if(Mode==OsuGameMode.Unknown || Mode==OsuGameMode.unDefined)
            {
                return 0.0;
            }
            return 0.0;
        }

    }
}