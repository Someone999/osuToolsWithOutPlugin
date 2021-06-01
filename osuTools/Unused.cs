using System;
using osuTools.Game;
using osuTools.Game.Modes;

namespace osuTools
{

    [Serializable,Obsolete("This calss had been replaced by enum.",true)]
    class OsuGameStatusA
    {
        string Sta;
        public string Status { get => Sta; }
        public OsuGameStatusA(string s)
        {
            if (s != "Eiditing" && s != "Idle" && s != "MatchSetup" && s != "NoFoundProcess" && s != "Playing" && s != "Rank" && s != "SelectSong")
            {
                s = "Unknown";
            }
            Sta = s;
        }
        public static OsuGameStatusA
              Eiditing = new OsuGameStatusA("Eiditing"),
              Idle = new OsuGameStatusA("Idle"),
              Lobby = new OsuGameStatusA("Lobby"),
              MatchSetup = new OsuGameStatusA("MatchSetup"),
              ProcessNotFound = new OsuGameStatusA("NoFoundProcess"),
              Playing = new OsuGameStatusA("Playing"),
              Rank = new OsuGameStatusA("Rank"),
              SelectSong = new OsuGameStatusA("SelectSong"),
              Unknown = new OsuGameStatusA("Unknown");
        public static bool operator ==(OsuGameStatusA g, OsuGameStatusA s) => g.Status == s.Status || g.Status.Contains(s.Status);

        public static bool operator !=(OsuGameStatusA g, OsuGameStatusA s) => g.Status != s.Status || !g.Status.Contains(s.Status);
        public override bool Equals(object obj)
        {
            OsuGameStatusA gms = obj as OsuGameStatusA;
            if (gms != null && gms.Status == Status)
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return Status;
        }
        public OsuGameStatus ToEnum()
        {
            return this == Eiditing ? OsuGameStatus.Editing :
                   this == Idle ? OsuGameStatus.Idle :
                   this == Lobby ? OsuGameStatus.Lobby :
                   this == MatchSetup ? OsuGameStatus.MatchSetup :
                   this == ProcessNotFound ? OsuGameStatus.ProcessNotFound :
                   this == Playing ? OsuGameStatus.Playing :
                   this == Rank ? OsuGameStatus.Rank :
                   this == SelectSong ? OsuGameStatus.SelectSong :
                   this == Unknown ? OsuGameStatus.Unkonwn : OsuGameStatus.Unkonwn;
        }
        public static bool operator ==(OsuGameStatusA g, OsuGameStatus c)
        {
            return g.ToEnum() == c;
        }
        public static bool operator !=(OsuGameStatusA g, OsuGameStatus c)
        {
            return g.ToEnum() != c;
        }
        public static bool operator ==(OsuGameStatus c, OsuGameStatusA g)
        {
            return g.ToEnum() == c;
        }
        public static bool operator !=(OsuGameStatus c, OsuGameStatusA g)
        {
            return g.ToEnum() != c;
        }
    }
    [Serializable, Obsolete("This calss had been replaced by enum.", true)]
    class OsuGameModeA
    {

        public string Mode { get => modea; }
        string modea;
        int modei;
        public OsuGameModeA(int mode)
        {
            switch (mode)
            {
                case 0: modea = Osu.ToString(); modei = mode; ; break;
                case 1: modea = Taiko.ToString(); modei = mode; break;
                case 2: modea = Catch.ToString(); modei = mode; break;
                case 3: modea = Mania.ToString(); modei = mode; break;
                default: modea = Unknown.ToString(); modei = 4; break;
            }
        }
        public OsuGameModeA(OsuGameMode mode)
        {
            switch (mode)
            {
                case OsuGameMode.Osu: modea = Osu.ToString(); modei = (int)mode; ; break;
                case OsuGameMode.Taiko: modea = Taiko.ToString(); modei = (int)mode; break;
                case OsuGameMode.Catch: modea = Catch.ToString(); modei = (int)mode; break;
                case OsuGameMode.Mania: modea = Mania.ToString(); modei = (int)mode; break;
                default: modea = Unknown.ToString(); modei = 4; break;
            }
        }
        public static OsuGameModeA Mania = new OsuGameModeA("Mania");
        public static OsuGameModeA Catch = new OsuGameModeA("CatchTheBeat");
        public static OsuGameModeA Osu = new OsuGameModeA("Osu");
        public static OsuGameModeA Taiko = new OsuGameModeA("Taiko");
        public static OsuGameModeA Unknown = new OsuGameModeA("Unknown");
        public static OsuGameModeA unDefined = new OsuGameModeA("Undefined");
        public OsuGameModeA(string c)
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
        
        public static bool operator ==(OsuGameModeA g, OsuGameModeA c)
        {
            return g.Mode == c.Mode || g.Mode.Contains(c.Mode);
        }
        public static bool operator !=(OsuGameModeA g, OsuGameModeA c)
        {
            return g.Mode != c.Mode || !g.Mode.Contains(c.Mode);
        }
        public static bool operator ==(OsuGameModeA g, OsuGameMode c)
        {
            if (g.ToEnum() == c)
            {
                return true;
            }

            return false;
        }
        public static bool operator !=(OsuGameModeA g, OsuGameMode c)
        {
            if (g.ToEnum() != c)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(OsuGameMode c, OsuGameModeA g)
        {
            if (g.ToEnum() == c)
            {
                return true;
            }

            return false;
        }
        public static bool operator !=(OsuGameMode c, OsuGameModeA g)
        {
            if (g.ToEnum() != c)
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return Mode;
        }
        public override bool Equals(object obj)
        {
            OsuGameModeA gm = obj as OsuGameModeA;
            if (gm != null && Mode == gm.Mode)
            {
                return true;
            }

            return false;
        }
        public OsuGameMode ToEnum()
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
            if (modea == "Unknow")
            {
                modei = 4;
            }
            return (OsuGameMode)modei;
        }
    }

}