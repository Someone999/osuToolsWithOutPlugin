using osuTools.Skins.Interfaces;
using osuTools.Skins.Settings.Mania.MultipleColumnsSettings;
using osuTools.Skins.Images.Osu;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using osuTools.Skins.Exceptions;

namespace osuTools.Skins.Images.Mania
{
    public class ManiaSkinImage:ISkinImage
    {
        public string FileName { get; private set; }
        public string FullPath { get; private set; }
        public string SkinImageTypeName { get; private set; }
        public Image LoadImage()
        {
            if (File.Exists(FullPath))
                return Image.FromFile(FullPath);
            else
                throw new SkinFileNotFoundException();
        }
        public ISkinImage GetHighResolutionImage()
        {
            var tmpname = FileName.Replace(".png", "@2x.png");
            var tmppath = Path.GetDirectoryName(FullPath);
            if (File.Exists(Path.Combine(tmppath, tmpname)))
                return new ManiaSkinImage(tmppath, tmpname, Path.Combine(tmppath, tmpname));
            throw new SkinFileNotFoundException("没有找到该皮肤文件的@2x版本。");

        }
        public ManiaSkinImage()
        {

        }
        public ManiaSkinImage(Skin parentSkin,string fileName,string skinImageTypeName)
        {
            var ini = parentSkin.ConfigFileDirectory;
            FileName = fileName;
            var tmppath = Path.GetDirectoryName(ini);
            FullPath = Path.Combine(tmppath, fileName);
            SkinImageTypeName = skinImageTypeName;
        }
        public ManiaSkinImage(string parentSkinDir, string fileName, string skinImageTypeName)
        {            
            var ini = Path.GetDirectoryName(parentSkinDir);
            FileName = fileName;
            FullPath = ini;
            SkinImageTypeName = skinImageTypeName;
        }
    }
    public class ManiaSkinImageCollection
    {
        public MultipleColumnsSetting<ManiaSkinImage> KeyImage { get; internal set; } = new MultipleColumnsSetting<ManiaSkinImage>();
        public MultipleColumnsSetting<ManiaSkinImage> KeyImageD { get; internal set; } = new MultipleColumnsSetting<ManiaSkinImage>();
        public MultipleColumnsSetting<ManiaSkinImage> NoteImage { get; internal set; } = new MultipleColumnsSetting<ManiaSkinImage>();
        public MultipleColumnsSetting<ManiaSkinImage> NoteImageH { get; internal set; } = new MultipleColumnsSetting<ManiaSkinImage>();
        public MultipleColumnsSetting<ManiaSkinImage> NoteImageL { get; internal set; } = new MultipleColumnsSetting<ManiaSkinImage>();
        public MultipleColumnsSetting<ManiaSkinImage> NoteImageT { get; internal set; } = new MultipleColumnsSetting<ManiaSkinImage>();
        public ManiaSkinImage StageLeft { get; internal set; }
        public ManiaSkinImage StageRight { get; internal set; }
        public ManiaSkinImage StageBottom { get; internal set; }
        public ManiaSkinImage StageHint { get; internal set; }
        public ManiaSkinImage StageLight { get; internal set; }
        public ManiaSkinImage LightingN { get; internal set; }
        public ManiaSkinImage LightingL { get; internal set; }
        public ManiaSkinImage WarningArrow { get; internal set; }  
    }
    public class ManiaHitBurstImageCollection : GeneralHitBurstImages
    {
        public List<ISkinImage> Hit200 { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> Hit300g { get; internal set; } = new List<ISkinImage>();
    }
   
    public class ManiaComboBurstCollection
    {
       public List<ManiaSkinImage> ComboBurstImages { get; internal set; } = new List<ManiaSkinImage>();
    }
}