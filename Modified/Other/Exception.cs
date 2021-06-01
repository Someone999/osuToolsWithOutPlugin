namespace osuTools
{
    using osuTools.Beatmaps;
    using osuTools.Game.Modes;
    using osuTools.Game.Mods;
    using System;

    namespace osuToolsException
    {
        /// <summary>
        /// osuTools异常的基类
        /// </summary>
        public class osuToolsExceptionBase : Exception
        {
            /// <summary>
            /// 使用指定的信息初始化一个osuToolsExceptionBase
            /// </summary>
            /// <param name="msg">信息</param>
            public osuToolsExceptionBase(string msg) : base(msg)
            {

            }
            public osuToolsExceptionBase(string msg,Exception innerException) : base(msg,innerException)
            {

            }
            

        }
        /// <summary>
        /// 当指定的文件不是谱面文件的时候引发的异常。
        /// </summary>
        public class InvalidBeatmapFileException : osuToolsExceptionBase
        {
            /// <summary>
            /// 使用指定的信息初始化一个InvalidBeatmapFileException
            /// </summary>
            /// <param name="msg">信息</param>
            public InvalidBeatmapFileException(string msg) : base(msg)
            {

            }
            public InvalidBeatmapFileException(string msg, Exception innerException) : base(msg, innerException)
            {

            }
        }
        /// <summary>
        /// osu!api查询失败时引发的异常。
        /// </summary>
        public class OnlineQueryFailedException : osuToolsExceptionBase
        {
            /// <summary>
            /// 使用指定的信息初始化一个OnlineQueryFailedException
            /// </summary>
            /// <param name="infom">信息</param>
            public OnlineQueryFailedException(string infom) : base(infom)
            {

            }
            public OnlineQueryFailedException(string msg, Exception innerException) : base(msg, innerException)
            {

            }
        }

        /// <summary>
        /// 处理osu文件时出现错误引发的异常。
        /// </summary>
        public class FailToParseException : osuToolsExceptionBase
        {
            /// <summary>
            /// 使用指定的信息初始化一个FailToParseException
            /// </summary>
            /// <param name="message">信息</param>
            public FailToParseException(string message) : base(message)
            {

            }
            public FailToParseException(string msg, Exception innerException) : base(msg, innerException)
            {

            }
        }
        /// <summary>
        /// 在指定的文件夹中找不到有效谱面时引发的异常。
        /// </summary>
        public class NoBeatmapInFolderException : osuToolsExceptionBase
        {
            string f;
            /// <summary>
            /// 文件夹
            /// </summary>
            public string Folder { get => f; }
            /// <summary>
            /// 使用指定的信息与文件夹初始化一个NoBeatmapInFolderException
            /// </summary>
            /// <param name="message">信息</param>
            /// <param name="folder">文件夹</param>
            public NoBeatmapInFolderException(string message, string folder) : base(message)
            {
                f = folder;
            }
        }
        /// <summary>
        /// 找不到与指定条件匹配的谱面时引发的异常。
        /// </summary>
        public class BeatmapNotFoundException : osuToolsExceptionBase
        {
            /// <summary>
            /// 使用指定的信息初始化一个BeatmapNotFoundException
            /// </summary>
            /// <param name="message">信息</param>
            public BeatmapNotFoundException(string message) : base(message)
            {

            }
        }
        /// <summary>
        /// 在指定的文件夹中找不到回放时引发的异常。
        /// </summary>
        public class NoReplayInFolderException : osuToolsExceptionBase
        {
            string f;
            /// <summary>
            /// 文件夹
            /// </summary>
            public string Folder { get => f; }
            /// <summary>
            /// 使用指定的信息与文件夹初始化一个NoReplayInFolderException
            /// </summary>
            /// <param name="message">信息</param>
            /// <param name="folder">文件夹</param>

            public NoReplayInFolderException(string message, string folder) : base(message)
            {
                f = folder;
            }
        }
        /// <summary>
        /// 找不到与指定条件匹配的回放时引发的异常。
        /// </summary>
        public class ReplayNotFoundException : osuToolsExceptionBase
        {
            /// <summary>
            /// 使用指定的信息初始化一个ReplayNotFoundException
            /// </summary>
            /// <param name="message">信息</param>
            public ReplayNotFoundException(string message) : base(message)
            {

            }
        }
        public class ConflictingModExistedException:osuToolsExceptionBase
        {
            public ConflictingModExistedException(string message="已存在一个或多个与该Mod相冲突的Mod。"):base(message)
            {
            }
            public ConflictingModExistedException(Mod exsitedMod,Mod toAdd): base($"Mod\"{exsitedMod.Name}\"与Mod\"{toAdd.Name}\"不能共存。")
            {
            }
            

        }
        public class ModExsitedException:osuToolsExceptionBase
        {
            public ModExsitedException(string msg="要添加的Mod已经在列表中。"):base(msg)
            {

            }
            public ModExsitedException(Mod existedMod ) : base($"Mod\"{existedMod.Name}\"已经在列表中。")
            {

            }
        }

        public class NotSupportHitObjectException:osuToolsExceptionBase
        {
            public NotSupportHitObjectException(string msg) : base(msg)
            {
            }
            public NotSupportHitObjectException(GameMode mode,HitObjectTypes hitObjectType):base($"模式{mode.ModeName}无法使用类型为\"{hitObjectType}\"的HitObject")
            {
            }
            public NotSupportHitObjectException(GameMode mode, HitObjectTypes hitObjectType, string msg) : base($"模式{mode.ModeName}无法使用类型为\"{hitObjectType}\"的HitObject.\n 附加信息:" + msg)
            {
            }
        }
        public class InitializationFailedException:osuToolsExceptionBase
        {
            public InitializationFailedException(string msg):base(msg)
            {

            }
            public InitializationFailedException(string msg,Exception innerException) : base(msg,innerException)
            {

            }
        }

    }
}