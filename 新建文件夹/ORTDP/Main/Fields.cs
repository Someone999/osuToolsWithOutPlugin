namespace osuTools
{
    partial class ORTDP
    {
        int dmp = 0;
        double tmper = 0;
        int bests;
        double bestp;
        Statistics sta;
        TotalHit t;
        GMMod mo;
        ClearAndFail ca;
        bool ManiaRanked = false;
        bool unRanked = false;
        bool Ranked;
        public SyncPPInfo ppinfo;
        double stars;
        ORTDP d;
        GMMode gm;
        GMStatus gs;
        int rt;
        string Ranking = "Unknown";
        Beatmaps.Beatmap b;
        ConsoleApp1.RtppdInfo rtppi;
        OsuRTDataProvider.Listen.OsuListenerManager lm;
        OsuRTDataProvider.OsuRTDataProviderPlugin p;
        int C300g = 0, C300 = 0, C200 = 0, C100 = 0, C50 = 0, Cmiss = 0, combo = 0, score = 0, time = 0, mco = 0,ppc=0;
        string pn="";
        RealTimePPDisplayer.RealTimePPDisplayerPlugin arp;
        double acc, hp, maxpp, fcpp, scc = 0;
        string mod, np;
        bool canfail = false;
    }
}