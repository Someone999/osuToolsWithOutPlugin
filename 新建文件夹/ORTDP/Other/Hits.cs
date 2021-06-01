namespace osuTools
{
    public partial class TotalHit
    {
        int mania;
        int ctb;
        int osu;
        public int Mania { get => mania; }
        public int Osu { get => osu; }
        public int CTB { get => ctb; }
        public TotalHit(int Mania, int Osu, int CTB)
        {
            this.mania = Mania;
            this.osu = Osu;
            this.ctb = CTB;
        }
    }
}