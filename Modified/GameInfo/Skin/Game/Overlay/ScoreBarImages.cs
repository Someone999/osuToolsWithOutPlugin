namespace osuTools.Skins.SkinObjects.Generic
{
    using System.Collections.Generic;
    public class ScoreBarSkinImageCollection
    {
        public GenericSkinImage ScoreBarBackgorund { get; internal set; }
        public List<GenericSkinImage> ScoreBarColour { get; internal set; } = new List<GenericSkinImage>();
        public GenericSkinImage ScoreBarKi { get; internal set; }
        public GenericSkinImage ScoreBarKiDanger { get; internal set; }
        public GenericSkinImage ScoreBarKiCritical { get; internal set; }
        public GenericSkinImage ScoreBarMarker { get; internal set; }
    }
}