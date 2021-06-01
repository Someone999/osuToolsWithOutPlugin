namespace osuTools.Skins.Settings.Slider
{
    public class SliderSetting
    {
        public bool AllowSliderBallTint { get; internal set; } = false;
        public bool SliderBallFlip { get; internal set; } = true;
        public uint SliderBallFrames { get; internal set; }
        public SliderStyles SliderStyle { get; internal set; } = SliderStyles.Gradient;
    }
}