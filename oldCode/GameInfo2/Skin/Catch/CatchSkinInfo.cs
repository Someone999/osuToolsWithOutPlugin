using osuTools.Skins.Colors;

namespace osuTools.Skins.Settings.Catch
{
    public class CatchSkinSetting
    {
        public RGBColor HyperDash { get; internal set; } = new RGBColor(255, 0, 0);
        public RGBColor HyperDashFruit { get; internal set; }
        public RGBColor HyperDashAfterImage { get; internal set; }
        public CatchSkinSetting()
        {
            HyperDashAfterImage = HyperDashFruit = HyperDash;
        }
    }
}