using osuTools.Skins.Interfaces;
using System;
using System.Drawing;
using System.IO;

namespace osuTools.Skins.Images.Mods
{
    public class ModImage:ISkinImage
    {
        public string SkinImageTypeName { get; } = "Mod";
        public string FileName { get; private set; } = "default";
        public string FullPath { get; private set; } = "default";
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
                return new ModImage(tmpname, Path.Combine(tmppath, tmpname));
            throw new FileNotFoundException("没有找到该皮肤文件的@2x版本。");

        }
        public ModImage(string fileName,string fullPath)
        {
            FileName = fileName + ".png";
            FullPath = fullPath;
        }
    }
    public class ModImageCollection
    {
        public ModImage Easy { get; internal set; }
        public ModImage HalfTime { get; internal set; }
        public ModImage NoFail { get; internal set; }
        public ModImage HardRock { get; internal set; }
        public ModImage SuddenDeath { get; internal set; }
        public ModImage Perfect { get; internal set; }
        public ModImage DoubleTime { get; internal set; }
        public ModImage NightCore { get; internal set; }
        public ModImage Hidden { get; internal set; }
        public ModImage FadeIn { get; internal set; }
        public ModImage Random { get; internal set; }
        public ModImage Mirror { get; internal set; }
        public ModImage Flashlight { get; internal set; }
        public ModImage Relax { get; internal set; }
        public ModImage AutoPilot { get; internal set; }
        public ModImage SpunOut { get; internal set; }
        public ModImage AutoPlay { get; internal set; }
        public ModImage Cinema { get; internal set; }
        public ModImage ScoreV2 { get; internal set; }
        public ModImage Key1 { get; internal set; }
        public ModImage Key2 { get; internal set; }
        public ModImage Key3 { get; internal set; }
        public ModImage Key4 { get; internal set; }
        public ModImage Key5 { get; internal set; }
        public ModImage Key6 { get; internal set; }
        public ModImage Key7 { get; internal set; }
        public ModImage Key8 { get; internal set; }
        public ModImage Key9 { get; internal set; }
        public ModImage KeyCoop { get; internal set; }

    }
}