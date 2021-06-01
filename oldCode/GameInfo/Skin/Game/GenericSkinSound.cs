using osuTools.Skins.Interfaces;

namespace osuTools.Skins.Sounds.Generic
{
    public class GenericSkinSound:ISkinSound
    {
        public string SkinSoundTypeName { get; internal set; } = "Default";
        public string FileName { get; internal set; } = "Default";
        public string FullPath { get; internal set; } = "Default";
    }
}