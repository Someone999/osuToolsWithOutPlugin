using osuTools.Skins.Images.Mods;
using System.IO;
using System.Linq;

namespace osuTools.Skins
{
    public partial class Skin
    {

        void getModsImages()
        {
            string[] s = Directory.GetFiles(ConfigFileDirectory.Replace("skin.ini", ""),"*.png",SearchOption.TopDirectoryOnly);
            foreach(var filedir in s)
            {
                var filename = Path.GetFileName(filedir);
                if(filename.StartsWith("selection-mod-"))
                {
                    string str = filename.Split('-').Last().Replace(".png","");
                    if(str=="nofail")
                    {
                        SkinImages.ModImages.NoFail = new ModImage(filename,filedir);
                    }
                    if (str == "easy")
                    {
                        SkinImages.ModImages.Easy = new ModImage(filename, filedir);
                    }
                    if (str == "halftime")
                    {
                        SkinImages.ModImages.HalfTime = new ModImage(filename, filedir);
                    }
                    if (str == "hardrock")
                    {
                        SkinImages.ModImages.HardRock = new ModImage(filename, filedir);
                    }
                    if (str == "suddendeath")
                    {
                        SkinImages.ModImages.SuddenDeath = new ModImage(filename, filedir);
                    }
                    if (str == "perfect")
                    {
                        SkinImages.ModImages.Perfect = new ModImage(filename, filedir);
                    }
                    if (str == "doubletime")
                    {
                        SkinImages.ModImages.DoubleTime = new ModImage(filename, filedir);
                    }
                    if (str == "nightcore")
                    {
                        SkinImages.ModImages.NightCore = new ModImage(filename, filedir);
                    }
                    if (str == "fadein")
                    {
                        SkinImages.ModImages.FadeIn = new ModImage(filename, filedir);
                    }
                    if (str == "hidden")
                    {
                        SkinImages.ModImages.Hidden = new ModImage(filename, filedir);
                    }
                    if (str == "flashlight")
                    {
                        SkinImages.ModImages.Flashlight= new ModImage(filename, filedir);
                    }
                    if (str == "key1")
                    {
                        SkinImages.ModImages.Key1 = new ModImage(filename, filedir);
                    }
                    if (str == "key2")
                    {
                        SkinImages.ModImages.Key2 = new ModImage(filename, filedir);
                    }
                    if (str == "key3")
                    {
                        SkinImages.ModImages.Key3 = new ModImage(filename, filedir);
                    }
                    if (str == "key4")
                    {
                        SkinImages.ModImages.Key4 = new ModImage(filename, filedir);
                    }
                    if (str == "key5")
                    {
                        SkinImages.ModImages.Key5 = new ModImage(filename, filedir);
                    }
                    if (str == "key6")
                    {
                        SkinImages.ModImages.Key6 = new ModImage(filename, filedir);
                    }
                    if (str == "key7")
                    {
                        SkinImages.ModImages.Key7 = new ModImage(filename, filedir);
                    }
                    if (str == "key8")
                    {
                        SkinImages.ModImages.Key8 = new ModImage(filename, filedir);
                    }
                    if (str == "key9")
                    {
                        SkinImages.ModImages.Key9 = new ModImage(filename, filedir);
                    }
                    if (str == "keycoop")
                    {
                        SkinImages.ModImages.KeyCoop = new ModImage(filename, filedir);
                    }
                    if (str == "relax")
                    {
                        SkinImages.ModImages.Relax = new ModImage(filename, filedir);
                    }
                    if (str == "autopilot")
                    {
                        SkinImages.ModImages.AutoPilot = new ModImage(filename, filedir);
                    }
                    if (str == "spunout")
                    {
                        SkinImages.ModImages.SpunOut = new ModImage(filename, filedir);
                    }
                    if (str == "random")
                    {
                        SkinImages.ModImages.Random = new ModImage(filename, filedir);
                    }
                    if (str == "mirror")
                    {
                        SkinImages.ModImages.Mirror = new ModImage(filename, filedir);
                    }
                    if (str == "autoplay")
                    {
                        SkinImages.ModImages.AutoPlay = new ModImage(filename, filedir);
                    }
                    if (str == "cinema")
                    {
                        SkinImages.ModImages.Cinema = new ModImage(filename, filedir);
                    }
                    if (str == "scorev2")
                    {
                        SkinImages.ModImages.ScoreV2 = new ModImage(filename, filedir);
                    }
                    
                }

            }

        }
    }
}