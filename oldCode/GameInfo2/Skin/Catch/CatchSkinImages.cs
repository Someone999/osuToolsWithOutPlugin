using osuTools.Skins.Interfaces;
using System.Drawing;
using System;
using System.IO;
using System.Collections.Generic;

namespace osuTools.Skins.Images.Catch
{
    public class CatchSkinImage : ISkinImage
    {
        public string FileName { get; private set; } = "default";
        public string FullPath { get; private set; } = "default";
        public string SkinImageTypeName { get; private set; } = "OsuSkinImage";
        public Image LoadImage()
        {
            if (FileName == "default" && FullPath == "default")
                throw new NotSupportedException("无法加载未自定义的图片。");
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
                return new CatchSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new FileNotFoundException("没有找到该皮肤文件的@2x版本。");

        }
        public CatchSkinImage(string fileName, string fullFileName)
        {
            FileName = fileName;
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }
    }
    public class FruitImages
    {
        public CatchSkinImage Apple { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage Grapes { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage Orange { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage Pear { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage Bananas { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage Drop { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage AppleOverlay { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage GrapesOverlay { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage OrangeOverlay { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage PearOverlay { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage BananasOverlay { get; internal set; } = new CatchSkinImage("default", "default");
        public CatchSkinImage DropOverlay { get; internal set; } = new CatchSkinImage("default", "default");
    }
    public class FruitCatcherImages
    {
        public List<CatchSkinImage> Fail { get; internal set; } = new List<CatchSkinImage>();
        public List<CatchSkinImage> Idle { get; internal set; } = new List<CatchSkinImage>();

        public List<CatchSkinImage> Kiai { get; internal set; } = new List<CatchSkinImage>();

    }
    public class CatchSkinImageCollection
    {
        public FruitImages Fruit { get; internal set; } = new FruitImages();
        public FruitCatcherImages FruitCatcher { get; internal set; } = new FruitCatcherImages();
    }



}