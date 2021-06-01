namespace osuTools
{
    public partial class GMMode
    {
        OsuGameMode l = OsuGameMode.unDefined, m = OsuGameMode.unDefined;
        public OsuGameMode LastMode { get => l; }
        public OsuGameMode CurrentMode { get => m; }
        public GMMode(string LastMode, string NowMode)
        {
            if (LastMode != "")
            {
                l = new OsuGameMode(LastMode);
            }
            if (NowMode != "")
            {
                m = new OsuGameMode(NowMode);
            }
        }
    }
    public class OsuGameMode
    {
        public string Mode { get => modea; }
        string modea;
        int modei;
        public OsuGameMode(int mode)
        {
            switch (mode)
            {
                case 0: modea = Osu.ToString(); modei = mode; ; break;
                case 1: modea = Taiko.ToString(); modei = mode; break;
                case 2: modea = Catch.ToString(); modei = mode; break;
                case 3: modea = Mania.ToString(); modei = mode; break;
                default: modea = Unknown.ToString(); modei = -1; break;
            }
        }
        public static OsuGameMode Mania = new OsuGameMode("Mania");
        public static OsuGameMode Catch = new OsuGameMode("CatchTheBeat");
        public static OsuGameMode Osu = new OsuGameMode("Osu");
        public static OsuGameMode Taiko = new OsuGameMode("Taiko");
        public static OsuGameMode Unknown = new OsuGameMode("Unknown");
        public static OsuGameMode unDefined = new OsuGameMode("Undefined");
        public OsuGameMode(string c)
        {
            if (c != "Mania" && c != "CatchTheBeat" && c != "Osu" && c != "Taiko")
            {
                if (c == "Mania")
                {
                    modei = 3;
                }
                if (c == "CatchTheBeat")
                {
                    modei = 2;
                }
                if (c == "Taiko")
                {
                    modei = 1;
                }
                if (c == "Osu")
                {
                    modei = 0;
                }
                c = "Unknown";
            }
            modea = c;

        }

        public static bool operator ==(OsuGameMode g, OsuGameMode c)
        {
            return g.Mode == c.Mode || g.Mode.Contains(c.Mode);
        }
        public static bool operator !=(OsuGameMode g, OsuGameMode c)
        {
            return g.Mode != c.Mode || !g.Mode.Contains(c.Mode);
        }
        public override string ToString()
        {
            return Mode;
        }
        public override bool Equals(object obj)
        {
            OsuGameMode gm = obj as OsuGameMode;
            if (gm != null && Mode == gm.Mode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ToIntMode()
        {
            if (modea == "Mania")
            {
                modei = 3;
            }
            if (modea == "CatchTheBeat")
            {
                modei = 2;
            }
            if (modea == "Taiko")
            {
                modei = 1;
            }
            if (modea == "Osu")
            {
                modei = 0;
            }
            return modei;
        }
    }
}
