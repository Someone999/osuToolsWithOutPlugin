namespace osuTools.Skins.SkinObjects.Generic
{
    using System;
    using System.IO;
    using System.Drawing;
    using osuTools.Skins.Interfaces;
    using System.Collections.Generic;
    using osuTools.Skins.Exceptions;
    using osuTools.Skins.SkinObjects.Generic.Menu;
    using osuTools.Skins.SkinObjects.Generic.Rank;
    using osuTools.Skins.SkinObjects.Generic.Score;
    using osuTools.Skins.SkinObjects.Generic.ResultPage;
    using osuTools.Skins.SkinObjects.Generic.PauseMenu;
    using osuTools.Skins.SkinObjects.Generic.PlayField.Countdown;

    public class GenericSkinImage:ISkinImage
    {
        public string FileName { get; protected set; } = "default";
        public string FullPath { get; protected set; } = "default";
        public string SkinImageTypeName { get; protected set; } = "MenuSkinImage";
        public Image LoadImage()
        {
            if (FileName == "default" && FullPath == "default")
                throw new NotSupportedException("无法加载未自定义的皮肤元素。");
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
                return new GenericSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new SkinFileNotFoundException("没有找到该皮肤文件的@2x版本。");
        }
        public GenericSkinImage(string fileName, string fullFileName)
        {
            FileName = fileName;
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }
    }
    
    
   
    public class GenericSkinObjectCollection
    { 
        public GenericSkinImage Cursor { get; internal set; }
        public GenericSkinImage CursorTrail { get; internal set; }
        public List<GenericSkinImage> HitCircleNumberImages { get; internal set; } = new List<GenericSkinImage>();
        public ScoreImageCollections ScoreImages { get; internal set; } = new ScoreImageCollections();
        public List<GenericSkinImage> MenuBackImages { get; internal set; } = new List<GenericSkinImage>();
        public GenericSkinImage MenuButtonBackground { get; internal set; }
        public GenericSkinImage MenuBackground { get; internal set; }
        public GenericSkinImage MenuSnow { get; internal set; }
        public ModeListOverlay ModeListImages { get; internal set; } = new ModeListOverlay();
        public List<GenericSkinImage> SkipImages { get; internal set; } = new List<GenericSkinImage>();
        public RankingImageCollection RankingImages { get; internal set; } = new RankingImageCollection();
        public ResultPageImageCollection ResultPageImages { get; internal set; } = new ResultPageImageCollection();
        public PauseMenuImageCollection PauseMenuImages { get; internal set; } = new PauseMenuImageCollection();
        public CountdownImageCollection Countdown { get; internal set; } = new CountdownImageCollection();
        public GenericSkinImage Star { get; internal set; }
        public ScoreBarSkinImageCollection ScoreBarSkinImages { get; internal set; } = new ScoreBarSkinImageCollection();


    }
}