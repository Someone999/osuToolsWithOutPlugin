using osuTools.Skins.Images.Taiko;

namespace osuTools.Skins
{
    using System.IO;
    public partial class Skin
    {
        void getTaikoSkinImage()
        {
            var files = Directory.GetFiles(ConfigFileDirectory.Replace("skin.ini", ""), "*.*", SearchOption.TopDirectoryOnly);
            #region TaikoSkinImages
            var lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taikobigcircle");
            if (lst.Count > 0)
                SkinImages.TaikoSkinImages.TaikoBigCircle = new TaikoSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taikocircle");
            if (lst.Count > 0)
                SkinImages.TaikoSkinImages.TaikoHitCircle = new TaikoSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderscorepoint");
            if (lst.Count > 0)
                SkinImages.TaikoSkinImages.SliderScorePoint = new TaikoSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-roll-middle");
            if (lst.Count > 0)
                SkinImages.TaikoSkinImages.TaikoRollMiddle = new TaikoSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-roll-end");
            if (lst.Count > 0)
                SkinImages.TaikoSkinImages.TaikoRollEnd = new TaikoSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-warning");
            if (lst.Count > 0)
                SkinImages.TaikoSkinImages.SpinnerWarning = new TaikoSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region TaikoSkinImagesOverlay
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taikobigcircleoverlay");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.TaikoBigCircleOverlay.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taikohitcircleoverlay");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.TaikoHitCircleOverlay.Add(new TaikoSkinImage(Path.GetFileName(file), file));
            #endregion
            #region TaikoHitBurstImages
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-hit0");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.HitBurstImages.Hit0.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-hit100");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.HitBurstImages.Hit100.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-hit100k");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.HitBurstImages.Hit100k.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-hit300");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.HitBurstImages.Hit300.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "taiko-hit300k");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.HitBurstImages.Hit300k.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            #endregion
            #region TaikoPipidonImages
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pippidonclear");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.PippidonImages.PippidonClear.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pippidonfail");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.PippidonImages.PippidonFail.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pippidonidle");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.PippidonImages.PippidonIdle.Add(new TaikoSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pippidonkiai");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.TaikoSkinImages.PippidonImages.PipidonKiai.Add(new TaikoSkinImage(Path.GetFileName(file), file));
            #endregion
        }
    }
}