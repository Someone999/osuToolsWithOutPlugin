namespace osuTools.Skins.Images.General
{
    using System;
    using System.IO;
    using System.Drawing;
    using osuTools.Skins.Interfaces;
    using System.Collections.Generic;

    public class GeneralSkinImage:ISkinImage
    {
        public string FileName { get; private set; } = "default";
        public string FullPath { get; private set; } = "default";
        public string SkinImageTypeName { get; private set; } = "MenuSkinImage";
        public Image LoadImage()
        {
            if (FileName == "default" && FullPath == "default")
                throw new NotSupportedException("无法加载未自定义图片的Mod的图片。");
            if (File.Exists(FullPath))
                return Image.FromFile(FullPath);
            else
                throw new FileNotFoundException("找不到文件。原因可能是该皮肤使用了非标准的扩展名。");
        }
        public ISkinImage GetHighResolutionImage()
        {
            var tmpname = FileName.Replace(".png", "@2x.png");
            var tmppath = Path.GetDirectoryName(FullPath);
            if (File.Exists(Path.Combine(tmppath, tmpname)))
                return new GeneralSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new FileNotFoundException("没有找到该皮肤文件的@2x版本。");
        }
        public GeneralSkinImage(string fileName, string fullFileName)
        {
            FileName = fileName + ".png";
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }
    }
    
    
    public class GeneralSkinImageCollection
    {
        public GeneralSkinImage Background { get; internal set; }
        public GeneralSkinImage Cursor { get; internal set; }
        public GeneralSkinImage CursorTrail { get; internal set; }
        public List<GeneralSkinImage> HitCircleNumberImages { get; internal set; } = new List<GeneralSkinImage>();
        public List<GeneralSkinImage> ScoreNumberImages { get; internal set; } = new List<GeneralSkinImage>();


    }
}