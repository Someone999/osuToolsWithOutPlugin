namespace osuTools.Skins.Images.General
{
    using System;
    using System.IO;
    using System.Drawing;
    using osuTools.Skins.Interfaces;
    using System.Collections.Generic;
    using osuTools.Skins.Exceptions;
    using osuTools.Skins.Images.General.Menu;
    using osuTools.Skins.Images.General.Rank;
    using osuTools.Skins.Images.General.Score;
    using osuTools.Skins.Images.General.ResultPage;
    using osuTools.Skins.Images.General.PauseMenu;
    using osuTools.Skins.Images.General.PlayField.Countdown;

    public class GenericSkinImage:ISkinImage
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
            FileName = fileName + ".png";
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }
    }
    
    
   
    public class GenericSkinImageCollection
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
        public CountdownImageCollection CountdownImages { get; internal set; } = new CountdownImageCollection();




    }
}