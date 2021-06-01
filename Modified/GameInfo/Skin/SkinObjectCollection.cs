using osuTools.Skins.SkinObjects.Catch;
using osuTools.Skins.SkinObjects.Mania;
using osuTools.Skins.SkinObjects.Generic;
using osuTools.Skins.SkinObjects.Mods;
using osuTools.Skins.SkinObjects.Osu;
using osuTools.Skins.SkinObjects.Taiko;

namespace osuTools.Skins.SkinObjects.Collections
{
    public class SkinObjectCollection
    {

        public GenericSkinObjectCollection GenericSkinObjects { get; internal set; } = new GenericSkinObjectCollection();
        public OsuSkinImageCollection OsuSkinImages { get; internal set; } = new OsuSkinImageCollection();
        public CatchSkinImageCollection CatchSkinImages { get; internal set; } = new CatchSkinImageCollection();
        public TaikoSkinImageCollection TaikoSkinImages { get; internal set; } = new TaikoSkinImageCollection();
        public ManiaHitBurstImageCollection ManiaHitBurstImages { get; internal set; } = new ManiaHitBurstImageCollection();
        public ManiaComboBurstCollection ManiaComboBurstImages { get; internal set; } = new ManiaComboBurstCollection();
        public ModImageCollection ModImages { get; internal set; } = new ModImageCollection();
        
    }
}
namespace osuTools.Skins
{
    public partial class Skin
    {
        public SkinObjects.Collections.SkinObjectCollection SkinObjects { get; internal set; } = new SkinObjects.Collections.SkinObjectCollection();
    }
}