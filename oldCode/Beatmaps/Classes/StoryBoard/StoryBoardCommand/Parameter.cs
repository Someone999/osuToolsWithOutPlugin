using System.Collections.Generic;
using System.Drawing;
using osuTools.StoryBoard;
using osuTools.StoryBoard.Command;
using System.Collections.Generic;
using System.Drawing;

public class Parameter : IStoryBoardSubCommand, IDurable, IHasEasing
{
    public StoryBoardEvent Command { get; } = StoryBoardEvent.Parameter;
    public List<IStoryBoardSubCommand> SubCommands { get; private set; }
    public IStoryBoardCommand ParentCommand { get; private set; }
    public int StartTime { get; private set; }
    public int EndTime { get; private set; }
    public ParameterOperation Operation { get; private set; } = ParameterOperation.None;
    public StoryBoardEasing Easing { get; private set; }
    public void Parse(string line)
    {
        string[] parts = line.Split(',');
        int eas = 0;
        var ed = parts[3];
        if (string.IsNullOrEmpty(ed)) ed = parts[2];
        if (int.TryParse(parts[1], out eas))
            Easing = (StoryBoardEasing)eas;
        else
            Easing = StoryBoardTools.GetStoryBoardEasingByString(parts[1]);
        StartTime = int.Parse(parts[2]);
        if (string.IsNullOrEmpty(parts[3])) parts[3] = parts[2];
        EndTime = int.Parse(parts[3]);
        var op = parts[4];
        Operation = op == "A" ? ParameterOperation.AddictiveColorBlend : op == "H" ? ParameterOperation.HorizentalFlip : op == "V" ? ParameterOperation.VerticalFlip : ParameterOperation.None;
    }
}