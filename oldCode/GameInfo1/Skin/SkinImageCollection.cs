using osuTools.Skins.Images.Catch;
using osuTools.Skins.Images;
using osuTools.Skins.Images.Mania;
using osuTools.Skins.Images.General;
using osuTools.Skins.Images.Mods;
using osuTools.Skins.Images.Osu;
using osuTools.Skins.Images.Taiko;

namespace osuTools.Skins.Images
{
    public class SkinImageCollection
    {
        public OsuSkinImageCollection OsuSkinImages { get; internal set; } = new OsuSkinImageCollection();
        public CatchSkinImageCollection CatchSkinImages { get; internal set; } = new CatchSkinImageCollection();
        public TaikoSkinImageCollection TaikoSkinImages { get; internal set; } = new TaikoSkinImageCollection();
        public ManiaHitBurstImageCollection ManiaHitBurstImages { get; internal set; } = new ManiaHitBurstImageCollection();
        public GeneralSkinImageCollection OverlayImageCollection { get; internal set; } = new GeneralSkinImageCollection();
        public ModImageCollection ModImages { get; internal set; } = new ModImageCollection();
    }
}
namespace osuTools.Skins
{
    public partial class Skin
    {
        public SkinImageCollection SkinImages { get; internal set; } = new SkinImageCollection();
    }
}