namespace osuTools.Exceptions
{
    /// <summary>
    ///     在指定的文件夹中找不到回放时引发的异常。
    /// </summary>
    public class NoReplayInFolderException : osuToolsExceptionBase
    {
        /// <summary>
        ///     使用指定的信息与文件夹初始化一个NoReplayInFolderException
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="folder">文件夹</param>
        public NoReplayInFolderException(string message, string folder) : base(message)
        {
            Folder = folder;
        }

        /// <summary>
        ///     文件夹
        /// </summary>
        public string Folder { get; }
    }
}