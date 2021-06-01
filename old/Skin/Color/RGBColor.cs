using osuTools.Beatmaps;
using System.CodeDom.Compiler;

namespace osuTools.Skins.Colors
{
    public class RGBColor
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        public RGBColor()
        {
            R = 0;
            B = 0;
            G = 0;
        }
        public RGBColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
        static bool isdig(char c) => c >= '0' && c <= '9';
        public static RGBColor Parse(string s)
        {
            char spliter = (char)0;
            foreach (var ch in s)
                if (!isdig(ch) && ch != ' ')
                {
                    spliter = ch;
                    break;
                }
            var vals=s.Split(spliter);
            RGBColor c = new RGBColor(int.Parse(vals[0]), int.Parse(vals[1]), int.Parse(vals[2]));
            return c;
        }
        public static bool operator ==(RGBColor a, RGBColor b) => a.R == b.R && a.B == b.B && a.G == b.G;
        public static bool operator !=(RGBColor a, RGBColor b) => a.R != b.R || a.B != b.B || a.G == b.G;
        public override int GetHashCode()
        {
            return R * B * G ;
        }
    }
    public class RGBAColor:RGBColor
    {
        
        public RGBAColor():base(0,0,0)
        {

        }
        public int Alpha { get; private set; }
        public RGBAColor(int r, int g, int b, int alpha=255) : base(r, g, b)
        {            
            Alpha = alpha;
        }
        public static RGBAColor Parse(string s)
        {
            char spliter = (char)0;
            RGBAColor c=new RGBAColor(0,0,0);
            foreach (var ch in s)
                if (!ch.IsDigit() && ch != ' ')
                {
                    spliter = ch;
                    break;
                }
            var vals = s.Split(spliter);
            if (vals.Length > 3)
            {
                c = new RGBAColor(int.Parse(vals[0]), int.Parse(vals[1]), int.Parse(vals[2]), int.Parse(vals[3]));
            }
            else
            {
                c = new RGBAColor(int.Parse(vals[0]), int.Parse(vals[1]), int.Parse(vals[2]));
            }
            return c;
        }
    }
}