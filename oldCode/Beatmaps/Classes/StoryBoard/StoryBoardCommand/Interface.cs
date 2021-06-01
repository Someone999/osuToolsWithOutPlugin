namespace osuTools.StoryBoard.Command
{
    using System.Collections.Generic;
    /// <summary>
    /// 表示一个StoryBoard的命令
    /// </summary>
    public interface IStoryBoardCommand
    {
        /// <summary>
        /// 将字符串解析为命令
        /// </summary>
        /// <param name="data"></param>
        void Parse(string data);
        /// <summary>
        /// 子命令列表
        /// </summary>
        List<IStoryBoardSubCommand> SubCommands { get; }
    }
    public interface ITranslation:IDurable
    {

    }
    public interface IShortcutableCommand
    {
        List<ITranslation> Translations { get; }
    }
    public interface IHasStartTime
    {
        int StartTime { get; }
    }
    public interface IHasEndTime
    {
        int EndTime { get; }
    }
    public interface IDurable:IHasStartTime,IHasEndTime
    {

    }
    public interface IHasEasing
    {
        StoryBoardEasing Easing { get; }
    }
    /// <summary>
    /// 表示一个StroyBoard子命令
    /// </summary>
    public interface IStoryBoardSubCommand:IStoryBoardCommand
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        StoryBoardEvent Command { get; }
        
        /// <summary>
        /// 父命令
        /// </summary>
        IStoryBoardCommand ParentCommand { get; }
    }
    /// <summary>
    /// 表示一个StoryBoard的主命令
    /// </summary>
    public interface IStoryBoardMainCommand:IStoryBoardCommand
    {
        /// <summary>
        /// StoryBoard资源类型
        /// </summary>
        StoryBoardResourceType ResourceType { get; }
        /// <summary>
        /// StoryBoard资源
        /// </summary>
        IStoryBoardResource Resource { get; }
    }
    /// <summary>
    /// 表示一个触发器命令
    /// </summary>
    public interface ITriggerCommand:IStoryBoardSubCommand,IDurable
    {
        /// <summary>
        /// 触发器类型
        /// </summary>
        string TriggerType { get; }
       
    }
    /// <summary>
    /// 表示一个循环命令
    /// </summary>
    public interface ILoopCommand:IStoryBoardSubCommand,IHasStartTime
    {
       
        /// <summary>
        /// 循环次数
        /// </summary>
        int LoopCount { get; }
    }

}