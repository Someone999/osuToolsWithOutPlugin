using osuTools.Skins.Images.General;

namespace osuTools.Skins
{
    using osuTools.Skins.Images.General.Rank;
    using System.IO;
    public partial class Skin
    {
        
        void getGenericSkinImage()
        {
            #region Background
            var lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "menu-background");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.MenuBackground = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region Cursor
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "cursor");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.Cursor = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "cursortrail");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.CursorTrail = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region HitCircleNumber
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "default-");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.GenericSkinImages.HitCircleNumberImages.Add(new GenericSkinImage(Path.GetFileName(file), file));
            #endregion
            #region Score

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "Score-dot");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ScoreImages.Dot = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "Score-comma");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ScoreImages.Coma = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "Score-percent");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ScoreImages.Percent = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "score-x");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ScoreImages.x = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "default-");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.GenericSkinImages.HitCircleNumberImages.Add(new GenericSkinImage(Path.GetFileName(file), file));
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "Score-");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.GenericSkinImages.ScoreImages.ScoreNumbers.Add(new GenericSkinImage(Path.GetFileName(file), file));
            #endregion
            #region MenuBack
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "menu-back-");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.GenericSkinImages.MenuBackImages.Add(new GenericSkinImage(Path.GetFileName(file), file));
            #endregion
            #region MenuButtonBackground
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "menu-button-background");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.MenuButtonBackground = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region MenuSnow
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "menu-snow");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.MenuSnow = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region ModeList
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "mode-osu-med");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ModeListImages.Osu = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "mode-taiko-med");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ModeListImages.Taiko = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "mode-fruits-med");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ModeListImages.Catch = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "mode-mania-med");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ModeListImages.Mania = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region Skip
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "play-skip-");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.GenericSkinImages.SkipImages.Add(new GenericSkinImage(Path.GetFileName(file), file));
            #endregion
            #region RankingImage
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-X");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.SS= new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-XH");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.SSH = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-S");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.S = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-SH");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.SH = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-A");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.A = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-B");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.B = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-C");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.C = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-D");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.RankingImages.D = new RankingImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region ResultPage
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-accuracy");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.Accuracy = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-panel");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.Panel= new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-graph");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.TimePerformanceBox = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-perfect");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.Perfect = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-maxcombo");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.MaxCombo = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ranking-title");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.Title = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pause-retry");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.Retry = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pause-replay");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.ResultPageImages.Replay = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region PauseMenu
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pause-retry");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.PauseMenuImages.Retry = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pause-back");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.PauseMenuImages.Back = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "pause-continue");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.PauseMenuImages.Continue = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region ReadyCountdown

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "ready");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.CountdownImages.Ready = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "count1");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.CountdownImages.One = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "count2");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.CountdownImages.Two = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "count3");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.CountdownImages.Three = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "go");
            if (lst.Count > 0)
                SkinImages.GenericSkinImages.CountdownImages.Go = new GenericSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
        }
    }
}