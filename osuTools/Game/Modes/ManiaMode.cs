using osuTools.Beatmaps;
using osuTools.Beatmaps.HitObject;
using osuTools.Beatmaps.HitObject.Mania;
using osuTools.Exceptions;
using osuTools.Game.Mods;

namespace osuTools.Game.Modes
{
    /// <summary>
    /// Mania模式
    /// </summary>
    public class ManiaMode : GameMode, ILegacyMode
    {
        /// <inheritdoc />
        public override string ModeName => "Mania";
        /// <inheritdoc/>
        public override Mod[] AvaliableMods => Mod.ManiaMods;
        /// <inheritdoc/>
        public override string Description => "砸键盘";
        /// <inheritdoc/>
        public OsuGameMode LegacyMode => OsuGameMode.Mania;
        /// <inheritdoc/>
        public override double AccuracyCalc(ScoreInfo scoreInfo)
        {
            double c300g = scoreInfo.CountGeki;
            double c300 = scoreInfo.Count300;
            double c200 = scoreInfo.CountKatu;
            double c50 = scoreInfo.Count50;
            double c100 = scoreInfo.Count100;
            double cMiss = scoreInfo.CountMiss;
            var rawValue = (c300g + c300 + c200 * (2 / 3.0) + c100 * (1.0 / 3) + c50 * (1 / 6.0)) /
                           (c300g + c300 + c100 + c200 + c50 + cMiss);
            return double.IsNaN(rawValue) ? 0 : double.IsInfinity(rawValue) ? 0 : rawValue;
        }
        /// <inheritdoc/>
        public override int GetPassedHitObjectCount(ScoreInfo info)
        {
            if (info is null) return 0;
            return info.CountGeki + info.Count300 + info.CountKatu + info.Count100 + info.Count50 + info.CountMiss;
        }
        /// <inheritdoc/>
        public override int GetBeatmapHitObjectCount(Beatmap b)
        {
            if (b is null) return 0;
            return b.HitObjects.Count;
        }
        /// <inheritdoc/>
        public override double GetCountGekiRate(ScoreInfo info)
        {
            if (info is null) return 0;
            var rawValue = info.CountGeki / (double) (info.Count300 + info.CountGeki);
            if (double.IsNaN(rawValue) || double.IsInfinity(rawValue))
                return 0;
            return rawValue;
        }
        /// <inheritdoc/>
        public override double GetCount300Rate(ScoreInfo info)
        {
            if (info is null) return 0;
            double rawValue;
            if (info.CountGeki > 0 && info.Count300 == 0)
                rawValue = GetCountGekiRate(info);
            else
                rawValue = (info.Count300 + info.CountGeki) /
                           (double) (info.CountGeki + info.Count300 + info.CountKatu + info.Count100 + info.Count50 + info.CountMiss);
            if (double.IsNaN(rawValue) || double.IsInfinity(rawValue))
                return 0;
            return rawValue;
        }
        /// <inheritdoc/>
        public override GameRanking GetRanking(ScoreInfo info)
        {
            if (info is null) return GameRanking.Unknown;
            bool isHdOrFl = false;
            if (!string.IsNullOrEmpty(info.Mods.GetShortModsString()))
                isHdOrFl = info.Mods.GetShortModsString().Contains("HD") || info.Mods.GetShortModsString().Contains("FL");
            return AccuracyCalc(info) * 100 >= 100 ? isHdOrFl ? GameRanking.SSH : GameRanking.SS :
                AccuracyCalc(info) * 100 > 95 ? isHdOrFl ? GameRanking.SH : GameRanking.S :
                AccuracyCalc(info) * 100 > 90 ? GameRanking.A :
                AccuracyCalc(info) * 100 > 80 ? GameRanking.B :
                AccuracyCalc(info) * 100 > 70 ? GameRanking.C :
                GameRanking.D;
        }
        /// <inheritdoc/>
        public override IHitObject CreateHitObject(string data, int maniaColumn)
        {
            var d = data.Split(',');
            var types = HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(int.Parse(d[3]));
            IHitObject hitobject = null;
            if (types.Contains(HitObjectTypes.HitCircle))
                hitobject = new ManiaHit();
            if (types.Contains(HitObjectTypes.ManiaHold))
                hitobject = new ManiaHold();
            if (hitobject == null)
                throw new IncorrectHitObjectException(this, types[0]);
            ((IManiaHitObject) hitobject).BeatmapColumn = maniaColumn;
            hitobject.Parse(data);
            return hitobject;
        }
        /// <inheritdoc/>
        public override bool IsPerfect(ScoreInfo info)
        {
            if (info is null) return false;
            return info.Count100 + info.Count50 + info.CountMiss == 0;
        }
    }
}