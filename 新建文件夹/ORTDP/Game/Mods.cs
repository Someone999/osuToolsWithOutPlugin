namespace osuTools
{
    using System.Collections.Generic;
    public partial class GMMod
    {
        List<OsuGameMod> mods = new List<OsuGameMod>();
        public GMMod(string vs)
        {
            string[] vss = vs.Split(',');
            for (int i = 0; i < vss.Length; i++)
            {
                mods.Add(new OsuGameMod(vss[i].Trim()));
            }
        }
        public override string ToString()
        {
            string AllMod = "";
            foreach (OsuGameMod mod in mods)
            {
                // AllMod += mod.ToString() + " ";
            }
            return AllMod;
        }
        public bool HasMod(OsuGameMod m)
        {
            foreach (OsuGameMod mod in mods)
            {
                if (mod == m)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
public class OsuGameMod
{
    string mod = "???";
    string longmod = "???";
    public OsuGameMod Mod { get; }
    public OsuGameMod(string x)
    {
        if (x == "EZ") { longmod = "Easy"; mod = x; }
        if (x == "HT") { longmod = "HalfTime"; mod = x; }

        if (x == "NF") { longmod = "NoFail"; mod = x; }
        if (x == "HR") { longmod = "HardRock"; mod = x; }
        if (x == "SD") { longmod = "SuddenDeath"; mod = x; }
        if (x == "PF") { longmod = "Perfect"; mod = x; }
        if (x == "DT") { longmod = "DoubleTime"; mod = x; }
        if (x == "NC") { longmod = "NightCore"; mod = x; }
        if (x == "HD") { longmod = "Hidden"; mod = x; }
        if (x == "FI") { longmod = "FadeIn"; mod = x; }
        if (x == "FL") { longmod = "Flashlight"; mod = x; }
        if (x == "1K") { longmod = "Key1"; mod = x; }
        if (x == "2K") { longmod = "Key2"; mod = x; }
        if (x == "3K") { longmod = "Key3"; mod = x; }
        if (x == "4K") { longmod = "Key4"; mod = x; }
        if (x == "5K") { longmod = "Key5"; mod = x; }
        if (x == "6K") { longmod = "Key6"; mod = x; }
        if (x == "7K") { longmod = "Key7"; mod = x; }
        if (x == "8K") { longmod = "Key8"; mod = x; }
        if (x == "9K") { longmod = "Key9"; mod = x; }
        if (x == "Co-op") { longmod = "KeyCoop"; mod = x; }
        if (x == "RD") { longmod = "Random"; mod = x; }
        if (x == "Auto") { longmod = "AutoPlay"; mod = x; }
        if (x == "CN") { longmod = "Cinema"; mod = x; }
        if (x == "V2") { longmod = "SocreV2"; mod = x; }
        if (x == "RL") { longmod = "Relax"; mod = x; }
        if (x == "AP") { longmod = "AutoPilot"; mod = x; }
        if (x == "SO") { longmod = "SpunOut"; mod = x; }
        x = "Unknown";
        mod = x;


    }
    public static bool operator ==(OsuGameMod o1, OsuGameMod o2)
    {
        return (o1.mod == o2.mod);
    }
    public static bool operator !=(OsuGameMod o1, OsuGameMod o2)
    {
        return (o1.mod != o2.mod);
    }
    public static OsuGameMod
        Easy = new OsuGameMod("EZ"),
        HalfTime = new OsuGameMod("HT"),
        NoFail = new OsuGameMod("NF"),
        HardRock = new OsuGameMod("HR"),
        SuddenDeath = new OsuGameMod("SD"),
        Perfect = new OsuGameMod("PF"),
        DoubleTime = new OsuGameMod("DT"),
        NightCore = new OsuGameMod("NC"),
        Hidden = new OsuGameMod("HD"),
        FadeIn = new OsuGameMod("FI"),
        Flashlight = new OsuGameMod("FL"),
        Key1 = new OsuGameMod("1K"),
        Key2 = new OsuGameMod("2K"),
        Key3 = new OsuGameMod("3K"),
        Key4 = new OsuGameMod("4K"),
        Key5 = new OsuGameMod("5K"),
        Key6 = new OsuGameMod("6K"),
        Key7 = new OsuGameMod("7K"),
        Key8 = new OsuGameMod("8K"),
        Key9 = new OsuGameMod("9K"),
        Relax = new OsuGameMod("RL"),
        AutoPilot = new OsuGameMod("AP"),
        SpunOut = new OsuGameMod("SO"),
        KeyCoop = new OsuGameMod("Co-op"),
        Random = new OsuGameMod("RD"),
        AutoPlay = new OsuGameMod("AP"),
        Cinema = new OsuGameMod("CN"),
        ScoreV2 = new OsuGameMod("V2"),
        Unknown = new OsuGameMod("Unknown");
    public override string ToString()
    {
        if (mod is null)
        {
            return "???";
        }
        return mod;
    }

}