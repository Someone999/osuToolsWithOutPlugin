using System.Collections.Generic;
using osuTools.Skins.SkinObjects.Osu;
namespace osuTools.Skins.SkinObjects.Osu.Slider
{
    public class SliderSkinImageCollection
    {
        public List<OsuSkinImage> SliderStartCircleOverlay { get; internal set; } = new List<OsuSkinImage>();
        public List<OsuSkinImage> SliderEndCircleOverlay { get; internal set; } = new List<OsuSkinImage>();
        public List<OsuSkinImage> SliderBall { get; internal set; } = new List<OsuSkinImage>();
        public List<OsuSkinImage> SliderFollowCircle { get; internal set; } = new List<OsuSkinImage>();

        public OsuSkinImage SliderStartCircle { get; internal set; } = new OsuSkinImage();
        public OsuSkinImage SliderEndCircle { get; internal set; } = new OsuSkinImage();
        public OsuSkinImage SliderScorePoint { get; internal set; } = new OsuSkinImage();
        public OsuSkinImage ReverseArrow { get; internal set; } = new OsuSkinImage();
    }
}