using System;
using osuTools.Beatmaps;
using osuTools.Beatmaps.HitObject;
using osuTools.Beatmaps.HitObject.Std;
using osuTools.Exceptions;
using osuTools.Game.Mods;

namespace osuTools.Game.Modes
{
    /// <summary>
    /// Std模式
    /// </summary>
    public class OsuMode : GameMode, ILegacyMode
    {
        /// <inheritdoc/>
        public override string ModeName => "Osu";
        /// <inheritdoc/>
        public override Mod[] AvaliableMods => Mod.OsuMods;
        /// <inheritdoc/>
        public override string Description => "戳泡泡";
       
        /// <inheritdoc/>

        public OsuGameMode LegacyMode => OsuGameMode.Osu;
        /// <inheritdoc/>

        public override double AccuracyCalc(ScoreInfo scoreInfo)
        {
            double c300 = scoreInfo.Count300;
            double c100 = scoreInfo.Count100;
            double c50 = scoreInfo.Count50;
            double cMiss = scoreInfo.CountMiss;
            var rawValue = (c300 + c100 * (1 / 3d) + c50 * (1 / 6d)) / (c300 + c100 + c50 + cMiss);
            return double.IsNaN(rawValue) ? 0 : double.IsInfinity(rawValue) ? 0 : rawValue;
        }
        /// <inheritdoc/>

        public override IHitObject CreateHitObject(string data)
        {
            IHitObject hitobject = null;
            var d = data.Split(',');
            var types = HitObjectTools.GetGenericTypesByInt<HitObjectTypes>(int.Parse(d[3]),out var maybeType);
            if (maybeType == HitObjectTypes.HitCircle || types.Contains(HitObjectTypes.HitCircle))
                hitobject = new HitCircle();
            if (maybeType == HitObjectTypes.Slider || types.Contains(HitObjectTypes.Slider))
                hitobject = new Slider();
            if (maybeType == HitObjectTypes.Spinner || types.Contains(HitObjectTypes.Spinner))
                hitobject = new Spinner();
            var type = maybeType;
            if (hitobject == null) throw new IncorrectHitObjectException(this, type ?? types[0]);
            hitobject.Parse(data);
            return hitobject;
        }
        /// <inheritdoc/>
        public override int GetBeatmapHitObjectCount(Beatmap b,ModList mods)
        {
            return b?.HitObjects.Count ?? 0;
        }
        /// <inheritdoc/>
        public override int GetPassedHitObjectCount(ScoreInfo info)
        {
            return info is null ? 0 : info.Count300 + info.Count100 + info.Count50 + info.CountMiss;
        }
        /// <inheritdoc/>
        public override bool IsPerfect(ScoreInfo info)
        {
            return !(info is null) && info.PlayerMaxCombo == info.MaxCombo;
        }
        
        /// <inheritdoc/>
        public override GameRanking GetRanking(ScoreInfo info)
        {
            if (info is null) return GameRanking.Unknown;

            var noMiss = info.CountMiss == 0;
            double all = info.Count300 + info.Count100 + info.Count50 + info.CountMiss;
            var c100Rate = info.Count100 / all;
            var c50Rate = info.Count50 / all;
            var isHdOrFl = false;
            if (info.Mods.Count > 0)
                isHdOrFl = info.Mods.Contains(typeof(HiddenMod)) || info.Mods.Contains(typeof(FlashlightMod));
            if (Math.Abs(AccuracyCalc(info) * 100 - 100) == 0 && Math.Abs(info.Count300 - all) == 0)
            {
                if (isHdOrFl) return GameRanking.SSH;
                return GameRanking.SS;
            }

            if (AccuracyCalc(info) * 100 > 93.17 && c50Rate < 0.01 && c100Rate < 0.1 && GetCount300Rate(info) > 0.9 &&
                noMiss)
            {
                if (isHdOrFl) return GameRanking.SH;
                return GameRanking.S;
            }

            if (GetCount300Rate(info) > 0.8 && noMiss || GetCount300Rate(info) > 0.9 && !noMiss)
            {
                return GameRanking.A;
            }

            if (GetCount300Rate(info) > 0.8 && !noMiss || GetCount300Rate(info) > 0.7 && noMiss)
            {
                return GameRanking.B;
            }

            if (GetCount300Rate(info) > 0.6)
            {
                return GameRanking.C;
            }

            return GameRanking.D;
        }
        /// <inheritdoc/>
        public override double GetCountGekiRate(ScoreInfo info)
        {
            var rawValue = info.CountGeki / (double) (info.CountGeki + info.CountKatu);
            if (double.IsNaN(rawValue) || double.IsInfinity(rawValue))
                return 0d;
            return rawValue;
        }
        /// <inheritdoc/>
        public override double GetCount300Rate(ScoreInfo info)
        {
            var rawValue = info.Count300 / (double) (info.Count300 + info.Count100 + info.Count50 + info.CountMiss);
            if (double.IsNaN(rawValue) || double.IsInfinity(rawValue))
                return 0d;
            return rawValue;
        }
    }
}