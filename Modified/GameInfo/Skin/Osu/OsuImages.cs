using osuTools.Skins.Interfaces;
using System.Drawing;
using System.IO;
using System;
using System.Collections.Generic;
using osuTools.Skins.SkinObjects.Osu.Slider;
using osuTools.Skins.SkinObjects.Osu.Spinner;
using osuTools.Skins.Exceptions;

namespace osuTools.Skins.SkinObjects.Osu
{
    public class OsuSkinImage:ISkinImage
    {
        public string FileName { get; private set; } = "default";
        public string FullPath { get; private set; } = "default";
        public string SkinImageTypeName { get; private set; } = "OsuSkinImage";
        public ISkinImage GetHighResolutionImage()
        {
            var tmpname = FileName.Replace(".png", "@2x.png");
            var tmppath = Path.GetDirectoryName(FullPath);
            if (File.Exists(Path.Combine(tmppath, tmpname)))
                return new OsuSkinImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new SkinFileNotFoundException("没有找到该皮肤文件的@2x版本。");

        }
        public Image LoadImage()
        {
            if (FileName == "default" && FullPath == "default")
                throw new NotSupportedException("无法加载未自定义的图片。");
            if (File.Exists(FullPath))
                return Image.FromFile(FullPath);
            else
                throw new SkinFileNotFoundException();
        }
        public OsuSkinImage(string fileName,string fullFileName)
        {
            FileName = fileName;
            var type = fileName.Replace(".png", "");
            FullPath = fullFileName;
        }
        public OsuSkinImage()
        {
        }
    }
    public class GeneralHitBurstImages
    {
        public List<ISkinImage> Hit0 { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> Hit50 { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> Hit100 { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> Hit300 { get; internal set; } = new List<ISkinImage>();

    }
    public class OsuHitBurstImageCollection:GeneralHitBurstImages
    {
        public List<ISkinImage> Hit100k { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> Hit300k { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> SliderPoint10 { get; internal set; } = new List<ISkinImage>();
        public List<ISkinImage> SliderPoint30 { get; internal set; } = new List<ISkinImage>();
    }
    public class OsuSkinImageCollection
    {
        public OsuSkinImage ApproachCircle { get; internal set; } = new OsuSkinImage();
        public OsuSkinImage HitCircle { get; internal set; } = new OsuSkinImage();

        public OsuSkinImage FollowPoint { get; internal set; } = new OsuSkinImage();       
        public OsuSkinImage HitCircleSelect { get; internal set; } = new OsuSkinImage();
        public SliderSkinImageCollection SliderSkinImages { get; internal set; } = new SliderSkinImageCollection();
        public SpinnerSkinImageCollection SpinnerSkinImages { get; internal set; } = new SpinnerSkinImageCollection();
        public List<OsuSkinImage> HitCircleOverlay { get; internal set; } = new List<OsuSkinImage>();
        public OsuHitBurstImageCollection HitBurstImages { get; internal set; } = new OsuHitBurstImageCollection();
        
    }
}