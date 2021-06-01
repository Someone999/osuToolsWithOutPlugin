using System.Collections.Generic;
using System.Drawing;
using osuTools.StoryBoard;
using osuTools.StoryBoard.Command;
using System.Collections.Generic;
using System.Drawing;
public class MoveYTranslation : ITranslation
{
    public double StartPoint { get; private set; }
    public double TargetPoint { get; private set; }
    public int StartTime { get; private set; }
    public int EndTime { get; private set; }
    public MoveYTranslation(double start, double target, int sttm, int edtm)
    {
        StartPoint = start;
        TargetPoint = target;
        StartTime = sttm;
        EndTime = edtm;
    }
}
public class MoveY : IStoryBoardSubCommand, IDurable, IHasEasing, IShortcutableCommand
{
    public StoryBoardEvent Command { get; } = StoryBoardEvent.MoveY;
    public List<IStoryBoardSubCommand> SubCommands { get; private set; }
    public IStoryBoardCommand ParentCommand { get; private set; }
    public int StartTime { get; private set; }
    public int EndTime { get; private set; }
    public List<ITranslation> Translations { get; private set; } = new List<ITranslation>();
    public StoryBoardEasing Easing { get; private set; }
    public void Parse(string line)
    {
        string[] parts = line.Split(',');
        int eas = 0;
        if (int.TryParse(parts[1], out eas))
            Easing = (StoryBoardEasing)eas;
        else
            Easing = StoryBoardTools.GetStoryBoardEasingByString(parts[1]);
        var ed = parts[3];
        if (string.IsNullOrEmpty(ed)) parts[3] = parts[2];
        StartTime = int.Parse(parts[2]);
        EndTime = int.Parse(parts[3]);
        int i = 4, j = 0;
        if(i + 1 == parts.Length)
            Translations.Add(new MoveYTranslation(double.Parse(parts[4]), double.Parse(parts[4]), StartTime, EndTime));
        while (i + 1 < parts.Length)
        {
            int stindex = i;
            double st = double.Parse(parts[i++]);
            double end = double.Parse(parts[i + 1 < parts.Length ? i++ : i + 1 == parts.Length ? i : stindex]);
            int dur = EndTime - StartTime;
            Translations.Add(new MoveYTranslation(st, end, StartTime + j * dur, EndTime + j * dur));
            j++;
            if (i + 1 < parts.Length)
                i--;
        }
    }
}