namespace osuTools.Skins
{
   /// <summary>
   /// 表示一个皮肤使用的图片文件
   /// </summary>
    public interface ISkinImage
    {
        /// <summary>
        /// 获得该使用该图片的皮肤
        /// </summary>
        /// <returns></returns>
        Skin GetSkin();
        /// <summary>
        /// 图片的文件名
        /// </summary>
        string Name { get; }
        /// <summary>
        ///  图片的全路径
        /// </summary>
        string Path { get; }
    }
}