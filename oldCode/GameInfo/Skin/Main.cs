using osuTools.Skins.Settings.Catch;
using osuTools.Skins.Colors;
using osuTools.Skins.Colors.Settings;
using osuTools.Skins.Settings.ComboBurst;
using osuTools.Skins.Settings.Cursor;
using osuTools.Skins.Settings.Fonts;
using osuTools.Skins.Settings.Mania;
using System.ComponentModel;
using System.IO;
using osuTools.Skins.Settings.Slider;
using osuTools.Skins.Settings.Spinner;

namespace osuTools.Skins
{
    public partial class Skin
    {
        string[] data;
        public string ConfigFileDirectory { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Version { get; private set; } = "latest";
        public uint AnimationFrameRate { get; private set; }
        public CursorSetting CursorSettings { get; internal set; } = new CursorSetting();
        public ComboBurstSetting ComboBurstSettings { get; internal set; } = new ComboBurstSetting();
        public SliderSetting SliderSettings { get; internal set; } = new SliderSetting();
        public bool HitCircleOverlayAboveNumber { get; private set; } = true;
        public bool LayeredHitSounds { get; private set; } = true;
        public SpinnerSetting SpinnerSettings { get; internal set; } = new SpinnerSetting();
        public ColorSetting ColorSettings { get; private set; }
        public FontSetting FontSettings { get; private set; }
        public CatchSkinSetting CatchSettings { get; private set; }
        public MultipleKeysSettings ManiaSettings { get; private set; }



        public Skin(string skinConfigFile)
        {
            if (!skinConfigFile.EndsWith("\\"))
                skinConfigFile += "\\";
            if (!skinConfigFile.EndsWith("skin.ini"))
                skinConfigFile += "skin.ini";
            if (File.Exists(skinConfigFile))
            {

                ConfigFileDirectory = skinConfigFile;
                data = File.ReadAllLines(skinConfigFile);
                files = Directory.GetFiles(ConfigFileDirectory.Replace("skin.ini", ""), "*.*", SearchOption.TopDirectoryOnly);
                getInfo();
                getModsImages();
                getOsuSkinImage();
                getCatchSkinImage();
                getTaikoSkinImage();
                getManiaSkinImages();
                getGenericSkinImage();
                getSkinSound();
            }
            else
                throw new FileNotFoundException();
        }
        public Skin()
        {
            ConfigFileDirectory = null;
            getModsImages();
            getOsuSkinImage();
            getCatchSkinImage();
            getTaikoSkinImage();
            getManiaSkinImages();
        }
    }
}