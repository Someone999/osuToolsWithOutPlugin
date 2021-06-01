using System.Drawing;

namespace osuTools.Skins.Interfaces
{
    public interface ISkinObjectBase
    {
    }
    public interface ISkinObject
    {
        string FileName { get; }
        
        string FullPath { get; }
    }
    /// <summary>
    /// 一个皮肤的图像元素
    /// </summary>
    public interface ISkinImage:ISkinObject
    {
        string SkinImageTypeName { get; }
        /// <summary>
        /// 将图像读入内存
        /// </summary>
        /// <returns></returns>
        Image LoadImage();
        /// <summary>
        /// 获取在高分辨率下显示的图像
        /// </summary>
        /// <returns></returns>
        ISkinImage GetHighResolutionImage();
    }
    public interface ISkinSound : ISkinObject
    {
        string SkinSoundTypeName { get; }
    }
    public interface ISoundedSkinImage:ISkinObjectBase
    {
        ISkinImage Image { get; }
        ISkinSound Sound { get; }
    }
    public interface IModImage:ISkinObject
    {
        OsuGameMod Mod { get; }
    }
}