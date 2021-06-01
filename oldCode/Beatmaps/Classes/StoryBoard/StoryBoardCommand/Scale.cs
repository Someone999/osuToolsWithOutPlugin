using osuTools.StoryBoard;
using osuTools.StoryBoard.Command;
using System.Collections.Generic;
public class ScaleMultiplier
{
    /// <summary>
    /// 整体缩放倍率
    /// </summary>
    public double Overall { get; set; } = 1;
    public ScaleMultiplier(double overall)
    {
        Overall = overall;
    }
}
public class ScaleTranslation : ITranslation
{
    public ScaleMultiplier StartScaleMultiplier { get; private set; }
    public ScaleMultiplier TargetScaleMultiplier { get; private set; }
    public int StartTime { get; private set; }
    public int EndTime { get;private set; }
    public ScaleTranslation(ScaleMultiplier start,ScaleMultiplier target,int starttm,int endtm)
    {
        StartScaleMultiplier = start;
        TargetScaleMultiplier = target;
        StartTime = starttm;
        EndTime = endtm;
    }
}
public class Scale : IStoryBoardSubCommand, IDurable, IHasEasing,IShortcutableCommand
{
    public StoryBoardEvent Command { get; } = StoryBoardEvent.Scale;
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
        StartTime = int.Parse(parts[2]);
        if (string.IsNullOrEmpty(parts[3])) parts[3] = parts[2];
        EndTime = int.Parse(parts[3]);
        int i = 4;
        int j = 0;
        if(i + 1 == parts.Length)
            Translations.Add(new ScaleTranslation(new ScaleMultiplier(double.Parse(parts[4])), new ScaleMultiplier(double.Parse(parts[4])), StartTime, EndTime));
        while (i+1<parts.Length)
        {
            int stindex = i;
            double st = double.Parse(parts[i++]);
            double ed = double.Parse(parts[i + 1 < parts.Length ? i++ : parts.Length == i + 1 ? i : stindex]);
            int du = EndTime - StartTime;
            Translations.Add(new ScaleTranslation(new ScaleMultiplier(st),new ScaleMultiplier(ed), StartTime + j * du, EndTime + j * du));
            if (i + 1 < parts.Length)
                i--;
            j++;
        }
    }
}