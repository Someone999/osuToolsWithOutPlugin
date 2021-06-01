namespace osuTools.Skins.Colors.Settings
{
    public class ColorSetting
    {
        public ComboColorCollection ComboColors { get; internal set; } = new ComboColorCollection();
        public TextColor InputOverlayText { get; internal set; } = new TextColor(0, 0, 0);
        public OverlayColor MenuGlow { get; internal set; } = new OverlayColor(0, 78, 155);
        public RGBColor SliderBall { get; internal set; } = new RGBColor(2, 170, 255);
        public RGBColor SliderBorder { get; internal set; } = new RGBColor(255, 255, 255);
        public RGBColor SliderTrackOverride { get; internal set; }
        public TextColor SongSelectActiveText { get; internal set; } = new TextColor(0, 0, 0);
        public TextColor SongSelectInactiveText { get; internal set; } = new TextColor(255, 255, 255);
        public OverlayColor SpinnerBackground { get; internal set; } = new OverlayColor(100, 100, 100);
        public OverlayColor StarBreakAdditive { get; internal set; } = new OverlayColor(255, 182, 193);
    }
}