﻿using osuTools.Skins.Images.Catch;
using System.IO;

namespace osuTools.Skins
{
    public partial class Skin
    {
        
        void getCatchSkinImage()
        {
            #region CatchFruitImage
            var lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-apple");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.Apple = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-grapes");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.Grapes = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-orange");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.Orange = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-pear");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.Pear = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-bananas");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.Bananas = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-drop");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.Drop = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion
            #region FruitCatcherImage
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-catcher-idle");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.CatchSkinImages.FruitCatcher.Idle.Add(new CatchSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-catcher-fail");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.CatchSkinImages.FruitCatcher.Fail.Add(new CatchSkinImage(Path.GetFileName(file), file));

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-catcher-kiai");
            if (lst.Count > 0)
                foreach (var file in lst)
                    SkinImages.CatchSkinImages.FruitCatcher.Kiai.Add(new CatchSkinImage(Path.GetFileName(file), file));

            #endregion
            #region CatchFruitOverlay
            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-apple-overlay");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.AppleOverlay = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-pear-overlay");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.PearOverlay = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-grapes-overlay");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.GrapesOverlay = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-orange-overlay");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.OrangeOverlay = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-bananas-overlay");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.BananasOverlay = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);

            lst = Tools.SkinTools.GetMultipleFileSkinObject(files, "fruit-drop-overlay");
            if (lst.Count > 0)
                SkinImages.CatchSkinImages.Fruit.DropOverlay = new CatchSkinImage(Path.GetFileName(lst[0]), lst[0]);
            #endregion


        }
    }
}