namespace osuTools.Game.Mods
{
    /// <summary>
    /// 没有Note的AutoPlay
    /// </summary>
    public class CinemaMod : Mod, ILegacyMod, IHasConflictMods
    {
        /// <inheritdoc />
        public override bool IsRankedMod { get; protected set; } = false;
        /// <inheritdoc />
        public override string Name { get; } = "Cinema";
        /// <inheritdoc />
        public override string ShortName { get; } = "CM";
        /// <inheritdoc />
        public override double ScoreMultiplier { get; protected set; } = 1.0d;
        /// <inheritdoc />
        public override ModType Type => ModType.Automation;
        /// <inheritdoc />
        public override string Description { get; protected set; } = "看不到Note的全自动游玩";
        /// <inheritdoc />
        public Mod[] ConflictMods => new Mod[]
        {
            new RelaxMod(), new AutoPilotMod(), new SpunOutMod(), new AutoPlayMod(), new SuddenDeathMod(),
            new PerfectMod()
        };
        /// <inheritdoc />
        public OsuGameMod LegacyMod => OsuGameMod.Cinema;
    }
}