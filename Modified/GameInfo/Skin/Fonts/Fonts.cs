using osuTools.OsuDB;

namespace osuTools.Skins.Settings.Fonts
{
    public class FontSetting
    {
        public string HitCirclePrefix { get; internal set; } = "default";
        public int HitCircleOverlap { get; internal set; } = -2;
        public string ScorePrefix { get; internal set; } = "score";
        public int ScoreOverlap { get; internal set; } = -2;
        public string ComboPrefix { get; internal set; } = "score";
        public int ComboOverlap { get; internal set; } = -2;
    }
}