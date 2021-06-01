namespace osuTools
{
    using System;

    namespace OtherTools
    {
        public class LevelInfo
        {
            double exp;
            double lv;
            public double Exp { get => exp; }
            public double Level { get => lv; }
            public LevelInfo(double Level=0)
            {
                lv = Level;
                exp = ExpCalculator(Level);
            }
            public void FromExp(double Exp)
            {

                while (ExpCalculator(lv) < Exp)
                {
                    if (Exp < ExpCalculator(lv + 1))
                        lv += lv / ExpCalculator(lv + 1);
                    lv++;
                    Console.WriteLine($"{lv}:{Exp}");
                }
            }
            public static LevelInfo FormExp(double Exp)
            {
                LevelInfo l = new LevelInfo();
                while (l.ExpCalculator(l.lv) < Exp)
                {
                    if (Exp < l.ExpCalculator(l.lv + 1))
                        l.lv += l.lv / l.ExpCalculator(l.lv + 1);
                    l.lv++;
                    Console.WriteLine($"{l.lv}:{Exp}/{l.ExpCalculator(l.lv)}");
                }
                return l;
            }
            double ExpCalculator(double Level)
            {
                double Exp = 0;
                if (Level > 0 && Level < 100)
                {
                    Exp = 5000 / 3 * (Math.Pow(4 * Level, 3) - Math.Pow(3 * Level, 2) - Level) + 1.25 * Math.Pow(1.8, (Level - 60));

                }
                else if (Level > 100)
                {
                    Exp = 26931190829 + 100000000000 * (Level - 100);
                }
                return Exp;
            }
        }
    }
}