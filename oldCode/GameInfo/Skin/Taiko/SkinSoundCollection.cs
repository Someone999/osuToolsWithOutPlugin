using osuTools.Skins.Sounds.Generic;
using System.Collections.Generic;

namespace osuTools.Skins.Sounds
{
    public class ReadySounds
    {
        public GenericSkinSound Three { get; internal set; }
        public GenericSkinSound Two { get; internal set; }
        public GenericSkinSound One { get; internal set; }
        public GenericSkinSound Go { get; internal set; }
    }
    public class SkinSoundCollection
    {
        public List<GenericSkinSound> ComboBurstSounds { get; internal set; } = new List<GenericSkinSound>();
        
    }
}