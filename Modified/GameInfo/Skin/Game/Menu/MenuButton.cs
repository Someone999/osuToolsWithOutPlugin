using osuTools.Skins.Interfaces;

namespace osuTools.Skins.SkinObjects.Generic.Menu
{
    using System.IO;
    using Skins.Exceptions;
    using SkinObjects.Generic;
    public class MenuButton:GenericSkinImage
    {
        public MenuButton(string fileName, string fullFileName):base(fileName,fullFileName)
        {
            FileName = fileName;
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
            
        }
        public ISkinImage GetMouseOverImage()
        {
            var tmpname = FileName.Replace(".png", "-over.png");
            var tmppath = Path.GetDirectoryName(FullPath);
            if (File.Exists(Path.Combine(tmppath, tmpname)))
                return new GenericSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new SkinFileNotFoundException();
        }
    }
    public class MenuButtonImageCollection
    {
        public MenuButton Mods { get;internal set; }
        public MenuButton Mode { get; internal set; }
        public MenuButton BeatmapOption { get;internal set; }
        public MenuButton Random { get; internal set; }
    }

}