namespace osuTools.Skins.SkinObjects.Taiko
{
    using osuTools.Skins.Interfaces;
    using osuTools.Skins.SkinObjects.Osu;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;

    public class TaikoSkinImage:ISkinImage
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
                return new TaikoSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new FileNotFoundException("没有找到该皮肤文件的@2x版本。");

        }
        public TaikoSkinImage(string fileName, string fullFileName)
        {
            FileName = fileName;
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }
    }
    public class TaikoSkinImageCollection
    {
        public TaikoSkinImage TaikoBigCircle { get; internal set; } = new TaikoSkinImage("default", "default");
        public TaikoSkinImage TaikoHitCircle { get; internal set; } = new TaikoSkinImage("default", "default");
        public TaikoSkinImage SliderScorePoint { get; internal set; } = new TaikoSkinImage("default", "default");
        public TaikoSkinImage TaikoRollMiddle { get; internal set; } = new TaikoSkinImage("default", "default");
        public TaikoSkinImage TaikoRollEnd { get; internal set; } = new TaikoSkinImage("default", "default");
        public TaikoSkinImage SpinnerWarning { get; internal set; } = new TaikoSkinImage("default", "default");
        public List<TaikoSkinImage> TaikoHitCircleOverlay { get; internal set; } = new List<TaikoSkinImage>();
        public List<TaikoSkinImage> TaikoBigCircleOverlay { get; internal set; } = new List<TaikoSkinImage>();
        public PipidonSkinImageCollection PippidonImages { get; internal set; } = new PipidonSkinImageCollection();
        public TaikoHitBurstImageCollection HitBurstImages { get; internal set; } = new TaikoHitBurstImageCollection();

    }
    public class PipidonSkinImageCollection
    {
        public List<TaikoSkinImage> PippidonClear { get; internal set; } = new List<TaikoSkinImage>();
        public List<TaikoSkinImage> PippidonFail { get; internal set; } = new List<TaikoSkinImage>();
        public List<TaikoSkinImage> PippidonIdle { get; internal set; } = new List<TaikoSkinImage>();
        public List<TaikoSkinImage> PipidonKiai { get; internal set; } = new List<TaikoSkinImage>();
    }
    public class TaikoHitBurstImageCollection:GeneralHitBurstImages
    {
        public List<TaikoSkinImage> Hit100k { get; internal set; } = new List<TaikoSkinImage>();
        public List<TaikoSkinImage> Hit300k { get; internal set; } = new List<TaikoSkinImage>();
    }
}