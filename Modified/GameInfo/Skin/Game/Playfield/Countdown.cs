using osuTools.Skins.Interfaces;

namespace osuTools.Skins.SkinObjects.Generic.PlayField.Countdown
{
    public class ReadyCountdown:ISoundedSkinImage
    {
        public ISkinImage Image { get; internal set; }
        public ISkinSound Sound { get; internal set; }
    }
    public class CountdownImageCollection
    {
        public ReadyCountdown Ready { get; internal set; } = new ReadyCountdown();
        public ReadyCountdown Three { get; internal set; } = new ReadyCountdown();
        public ReadyCountdown Two { get; internal set; } = new ReadyCountdown();
        public ReadyCountdown One { get; internal set; } = new ReadyCountdown();
        public ReadyCountdown Go { get; internal set; } = new ReadyCountdown();
    }
}