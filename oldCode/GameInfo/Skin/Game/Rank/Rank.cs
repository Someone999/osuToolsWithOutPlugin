namespace osuTools.Skins.Images.General.Rank
{
    using Interfaces;
    using osuTools.Skins.Exceptions;
    using System.Drawing;
    using System;
    using System.IO;
    public class RankingImage : ISkinImage
    {
        public string FileName { get; private set; } = "default";
        public string FullPath { get; private set; } = "default";
        public string SkinImageTypeName { get; private set; } = "RankSkinImage";
        public Image LoadImage()
        {
            if (FileName == "default" && FullPath == "default")
                throw new NotSupportedException("无法加载未自定义图片的Mod的图片。");
            if (File.Exists(FullPath))
                return Image.FromFile(FullPath);
            else
                throw new SkinFileNotFoundException();
        }
        public ISkinImage GetIcon()
        {
            var tmpname = FileName.Replace(".png", "-small.png");
            var tmppath = Path.GetDirectoryName(FullPath);
            if (File.Exists(Path.Combine(tmppath, tmpname)))
                return new GenericSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new SkinFileNotFoundException("没有找到这个Rank图片的小图标。");
        }
        public ISkinImage GetHighResolutionImage()
        {
            var tmpname = FileName.Replace(".png", "@2x.png");
            var tmppath = Path.GetDirectoryName(FullPath);
            if (File.Exists(Path.Combine(tmppath, tmpname)))
                return new GenericSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new SkinFileNotFoundException("没有找到这个Rank图片的@2x版本。");
        }
        public RankingImage(string fileName, string fullFileName)
        {
            FileName = fileName + ".png";
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }

    }
    public class RankingImageCollection
    {
        public RankingImage SS { get; internal set; }
        public RankingImage SSH { get; internal set; }
        public RankingImage S { get; internal set; }
        public RankingImage SH { get; internal set; }
        public RankingImage A { get; internal set; }
        public RankingImage B { get; internal set; }
        public RankingImage C { get; internal set; }
        public RankingImage D { get; internal set; }
    }
}