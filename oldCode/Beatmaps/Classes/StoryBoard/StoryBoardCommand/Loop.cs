namespace osuTools.StoryBoard.Command
{
    using System.Collections.Generic;
    class Loop:ILoopCommand,IHasStartTime
    {
        public IStoryBoardCommand ParentCommand { get; private set; }
        public StoryBoardEvent Command { get; } = StoryBoardEvent.Loop;
        public List<IStoryBoardSubCommand> SubCommands { get; private set; } = new List<IStoryBoardSubCommand>();
        public int StartTime { get; private set; }
        public int LoopCount { get; private set; }
        public void Parse(string data)
        {
            var parts = data.Split(',');
            StartTime = int.Parse(parts[1]);
            LoopCount = int.Parse(parts[2]);
        }
    }
}