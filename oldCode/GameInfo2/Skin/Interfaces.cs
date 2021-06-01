using System.Drawing;

namespace osuTools.Skins.Interfaces
{
    public interface ISkinObject
    {
        string FileName { get; }
        
        string FullPath { get; }
    }
    public interface ISkinImage:ISkinObject
    {
        string SkinImageTypeName { get; }
        Image LoadImage();
        ISkinImage GetHighResolutionImage();
    }
    public interface ISkinSound : ISkinObject
    {
        string SkinSoundTypeName { get; }
    }
    public interface IModImage:ISkinObject
    {
        OsuGameMod Mod { get; }
    }
}