namespace osuTools
{
    public partial class Statistics
    {
        TotalHit hit;
        ClearAndFail clr;
        public TotalHit Hits { get => hit; }
        public ClearAndFail ClearsAndFails { get => clr; }
        public Statistics()
        {
            hit = new TotalHit(0, 0, 0);
            clr = new ClearAndFail();
        }
        public Statistics(TotalHit t, ClearAndFail c)
        {
            if (c == null)
            {
                clr = new ClearAndFail();
            }
            if (t == null)
            {
                hit = new TotalHit(0, 0, 0);
            }
            hit = t;
            clr = c;
        }
        public void WriteToFile()
        {
            string[] clrs = new string[2], hitf = new string[3];
            clrs[0] = "Cleared:" + clr.Clears.ToString();
            clrs[1] = "Failed:" + clr.Fails.ToString();
            hitf[0] = "Mania:" + hit.Mania.ToString();
            hitf[1] = "Osu:" + hit.Osu.ToString();
            hitf[2] = "CTB:" + hit.CTB.ToString();
            System.IO.File.WriteAllLines("D:\\osu\\HitCounts.txt", hitf);
            System.IO.File.WriteAllLines("D:\\osu\\ClearFailCount.txt", clrs);
        }
        public void ReadFromFile()
        {
            int m, o, ctb, cl, fa;
            string[] thits = System.IO.File.ReadAllLines("D:\\osu\\HitCount.txt");
            foreach (string t in thits)
            {
                string[] temp = t.Split(':');
                if (temp[0].Contains("Mania"))
                {
                    int.TryParse(temp[1], out m);
                }
                if (temp[0].Contains("CTB"))
                {
                    int.TryParse(temp[1], out ctb);
                }
                if (temp[0].Contains("Osu"))
                {
                    int.TryParse(temp[1], out o);
                }
            }
            string[] clf = new string[2];
            clf = System.IO.File.ReadAllLines("D:\\osu\\ClearFailCount.txt");
            foreach (string x in clf)
            {
                string[] s = x.Split(':');
                if (s[0].Contains("Cleared"))
                {
                    int.TryParse(s[1], out cl);
                }
                if (s[0].Contains("Failed"))
                {
                    int.TryParse(s[1], out fa);
                }
            }
        }
    }
}
