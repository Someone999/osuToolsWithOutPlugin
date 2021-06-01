using osuTools.Skins.Images.Mania;
using osuTools.Skins.Images.Osu;
using osuTools.Skins.Images.Taiko;
using System.Diagnostics;
using System.IO;

namespace osuTools.Skins
{
    public partial class Skin
    {
        string[] files = new string[0];
        void getOsuSkinImage()
        {

            #region OsuRelatedImages
            
            var lst =Tools.SkinTools.GetMultipleFileSkinObject(files, "approachcircle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.ApproachCircle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hitcircle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.HitCircle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hitcircleselect");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.HitCircleSelect = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "followpoint");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.FollowPoint = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "reversearrow");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SliderSkinImages.ReverseArrow = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderendcircle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SliderSkinImages.SliderEndCircle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderstartcircle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SliderSkinImages.SliderStartCircle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderscorepoint");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SliderSkinImages.SliderScorePoint = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-circle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerCircle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-background");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerBackground = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-metre");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerMeter = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-bottom");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerBottom = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-glow");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerGlow = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-middle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerMiddle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-middle2");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerMiddle2 = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-top");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerTop = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-approachcircle");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerApproachCircle = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-clear");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerClear = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-spin");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerSpin = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "spinner-rpm");
            if (lst.Count > 0)
                SkinImages.OsuSkinImages.SpinnerSkinImages.SpinnerRPM = new OsuSkinImage(Path.GetFileName(lst[0]), lst[0]);

            #endregion
            #region OsuRelatedOverlay
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hitcircleoverlay");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.OsuSkinImages.HitCircleOverlay.Add(new OsuSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderstartcircleoverlay");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.OsuSkinImages.SliderSkinImages.SliderStartCircleOverlay.Add(new OsuSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderendcircleoverlay");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.OsuSkinImages.SliderSkinImages.SliderEndCircleOverlay.Add(new OsuSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderb");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.OsuSkinImages.SliderSkinImages.SliderBall.Add(new OsuSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "sliderfollowcircle");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.OsuSkinImages.SliderSkinImages.SliderFollowCircle.Add(new OsuSkinImage(Path.GetFileName(file), file));
            #endregion
            #region HitBurst
            
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hit300");
            if (lst.Count > 0)
                foreach (var file in lst)
                {
                    SkinImages.OsuSkinImages.HitBurstImages.Hit300.Add(new OsuSkinImage(Path.GetFileName(file), file));
                }

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hit100");
            if (lst.Count > 0)
                foreach (var file in lst)
                {
                    SkinImages.OsuSkinImages.HitBurstImages.Hit100.Add(new OsuSkinImage(Path.GetFileName(file), file));
                }

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hit50");
            if (lst.Count > 0)
                foreach (var file in lst)
                {
                    SkinImages.OsuSkinImages.HitBurstImages.Hit50.Add(new OsuSkinImage(Path.GetFileName(file), file));
                }

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hit0");
            if (lst.Count > 0)
                foreach (var file in lst)
                {
                    SkinImages.OsuSkinImages.HitBurstImages.Hit0.Add(new OsuSkinImage(Path.GetFileName(file), file));
                }
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hit300k");
            if (lst.Count > 0)
                foreach (var file in lst)
                {
                    SkinImages.OsuSkinImages.HitBurstImages.Hit300k.Add(new OsuSkinImage(Path.GetFileName(file), file));
                }
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "hit100k");
            if (lst.Count > 0)
                foreach (var file in lst)
                {
                    SkinImages.OsuSkinImages.HitBurstImages.Hit100k.Add(new OsuSkinImage(Path.GetFileName(file), file));
                }
            
            #endregion



        }
    }
}