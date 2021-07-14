using System;
using System.Linq;
using osuTools.Beatmaps;
using osuTools.Beatmaps.HitObject;
using osuTools.Beatmaps.HitObject.Catch;
using osuTools.Exceptions;
using osuTools.Game.Mods;
using osuTools.PerformanceCalculator.Catch;

namespace osuTools.Game.Modes
{
    /// <summary>
    /// Catch模式
    /// </summary>
    public class CatchMode : GameMode, ILegacyMode
    {
        ///<inheritdoc/>
        public override string ModeName => "Catch";
        ///<inheritdoc/>
        public override Mod[] AvaliableMods => Mod.CatchMods;
        ///<inheritdoc/>
        public override string Description => "接水果";
        private CatchBeatmap _innerBeatmap;
        private CatchPerformanceCalculator _performanceCalculator;

        internal double TestPerformanceCalculator(ScoreInfo info,Beatmap b)
        {
            _innerBeatmap = _innerBeatmap ?? new CatchBeatmap(b);
            _performanceCalculator =
                _performanceCalculator ?? new CatchPerformanceCalculator(_innerBeatmap, info.Mods);
            return _performanceCalculator.CalculatePerformance(AccuracyCalc(info), info.MaxCombo, info.CountMiss);
        }
       
        ///<inheritdoc/>
        public OsuGameMode LegacyMode => OsuGameMode.Catch;
        ///<inheritdoc/>
        public override double AccuracyCalc(ScoreInfo scoreInfo)
        {
            double c300 = scoreInfo.Count300;
            double c200 = scoreInfo.CountKatu;
            double c50 = scoreInfo.Count50;
            double c100 = scoreInfo.Count100;
            double cMiss = scoreInfo.CountMiss;
            var rawValue = (c300 + c100 + c50) / (c300 + c100 + c200 + c50 + cMiss);
            return double.IsNaN(rawValue) ? 0 : double.IsInfinity(rawValue) ? 0 : rawValue;
        }
       
        ///<inheritdoc/>
        public override int GetBeatmapHitObjectCount(Beatmap b, ModList mods)
        {
            if (b == null) return 0;
            var hitObjects = b.HitObjects;
            var juice = hitObjects.Where(h => h.HitObjectType == HitObjectTypes.JuiceStream);
            var bananaShower = hitObjects.Where(h => h.HitObjectType == HitObjectTypes.BananaShower);
            return hitObjects.Count + juice.Count() - bananaShower.Count();
        }
        ///<inheritdoc/>
        public override bool IsPerfect(ScoreInfo info)
        {
            return AccuracyCalc(info) >= 1;
        }
        ///<inheritdoc/>
        public override int GetPassedHitObjectCount(ScoreInfo i)
        {
            if (i is null) return 0;
            return i.Count300 + i.Count100;
        }
        ///<inheritdoc/>
        public override double GetCount300Rate(ScoreInfo info)
        {
            if (info is null) return 0d;
            return AccuracyCalc(info);
        }
        ///<inheritdoc/>
        public override double GetCountGekiRate(ScoreInfo info)
        {
            if (info is null) return 0d;
            return AccuracyCalc(info);
        }
        ///<inheritdoc/>
        public override IHitObject CreateHitObject(string data)
        {
            IHitObject hitobject = null;
            var d = data.Split(',');
            var types = HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(int.Parse(d[3]));
            if (types.Contains(HitObjectTypes.HitCircle))
                hitobject = new Fruit();
            if (types.Contains(HitObjectTypes.Slider))
                hitobject = new JuiceStream();
            if (types.Contains(HitObjectTypes.Spinner))
                hitobject = new BananaShower();
            if (hitobject == null) throw new IncorrectHitObjectException(this, types[0]);
            hitobject.Parse(data);
            return hitobject;
        }
        ///<inheritdoc/>
        public override GameRanking GetRanking(ScoreInfo info)
        {
            if (info is null) return GameRanking.Unknown;
            var isHdOrFl = false;
            if (info.Mods.Count > 0)
                isHdOrFl = info.Mods.Contains(typeof(HiddenMod)) || info.Mods.Contains(typeof(FlashlightMod));
            if (Math.Abs(AccuracyCalc(info) * 100 - 100) == 0)
            {

                if (isHdOrFl) return GameRanking.SSH;
                return GameRanking.SS;
            }

            if (AccuracyCalc(info) * 100 > 98.01)
            {
                if (isHdOrFl) return GameRanking.SH;
                return GameRanking.S;
            }

            if (AccuracyCalc(info) * 100 > 94)
            {
                return GameRanking.A;
            }

            if (AccuracyCalc(info) * 100 > 90)
            {
                return GameRanking.B;
            }

            if (AccuracyCalc(info) * 100 > 85)
            {
                return GameRanking.C;
            }

            if (AccuracyCalc(info) * 100 < 85)
            {
                return GameRanking.D;
            }

            return GameRanking.Unknown;
        }
       
        /// <inheritdoc/>
        public override int GetBeatmapMaxCombo(ScoreInfo info, Beatmap b) =>
            _performanceCalculator.Beatmap.MaxCombo;
        ///<inheritdoc/>
        public override double GetHitObjectPercent(ScoreInfo info, Beatmap b) =>
            GetPassedHitObjectCount(info) / (double)GetBeatmapMaxCombo(info, b);

    }
}