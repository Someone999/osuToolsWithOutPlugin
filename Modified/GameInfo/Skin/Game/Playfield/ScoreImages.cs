using System.Collections.Generic;

namespace osuTools.Skins.SkinObjects.Generic.Score
{
    public class ScoreImageCollections
    {
        public List<GenericSkinImage> ScoreNumbers { get; internal set; } = new List<GenericSkinImage>();
        public GenericSkinImage Coma { get; internal set; }
        public GenericSkinImage Dot { get; internal set; }
        public GenericSkinImage Percent { get; internal set; }
        public GenericSkinImage x { get; internal set; }
    }
}