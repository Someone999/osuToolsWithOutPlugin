namespace osuTools
{
    public partial class GMStatus
    {
        OsuGameStatus l, m;
        public OsuGameStatus LastStatus { get => l; }
        public OsuGameStatus CurrentStatus { get => m; }
        public GMStatus(string Last, string Now)
        {
            if (Last == null || Last == "")
            {
                l = new OsuGameStatus("Unknown");
            }
            else
            {
                l = new OsuGameStatus(Last);
            }
            if (Now == null || Now == "")
            {
                m = new OsuGameStatus("Unknown");
            }
            else
            {
                m = new OsuGameStatus(Now);
            }
        }
    }
    public partial class OsuGameStatus
    {
        string Sta;
        public string Status { get => Sta; }
        public OsuGameStatus(string s)
        {
            if (s != "Eiditing" && s != "Idle" && s != "MatchSetup" && s != "NoFoundProcess" && s != "Playing" && s != "Rank" && s != "SelectSong")
            {
                s = "Unknown";
            }
            Sta = s;
        }
        public static OsuGameStatus
              Eiditing = new OsuGameStatus("Eiditing"),
              Idle = new OsuGameStatus("Idle"),
              Lobby = new OsuGameStatus("Lobby"),
              MatchSetup = new OsuGameStatus("MatchSetup"),
              ProcessNotFound = new OsuGameStatus("NoFoundProcess"),
              Playing = new OsuGameStatus("Playing"),
              Rank = new OsuGameStatus("Rank"),
              SelectSong = new OsuGameStatus("SelectSong"),
              Unknown = new OsuGameStatus("Unknown");
        public static bool operator ==(OsuGameStatus g, OsuGameStatus s) => g.Status == s.Status || g.Status.Contains(s.Status);

        public static bool operator !=(OsuGameStatus g, OsuGameStatus s) => g.Status != s.Status || !g.Status.Contains(s.Status);
        public override bool Equals(object obj)
        {
            OsuGameStatus gms = obj as OsuGameStatus;
            if (gms != null && gms.Status == Status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return Status;
        }
    }


}