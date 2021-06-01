﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuTools.StoryBoard.Commands.Interface;

namespace osuTools.StoryBoard.Tools
{
    /// <summary>
    /// StoryBoard命令的解析器
    /// </summary>
    public class StoryBoardCommandParser
    {
        /// <summary>
        /// 包含StoryBoard数据的文件
        /// </summary>
        public string StoryBoardCommandFile { get; }
        /// <summary>
        /// 字符串处理器
        /// </summary>
        public StringProcessor StringProcessor { get; set; }
        private readonly HashSet<IStoryBoardCommand> _commands = new HashSet<IStoryBoardCommand>();
        /// <summary>
        /// 使用指定的文件初始化StoryBoardCommandParser
        /// </summary>
        /// <param name="storyBoardCommandFile"></param>
        public StoryBoardCommandParser(string storyBoardCommandFile)
        {
            StoryBoardCommandFile = storyBoardCommandFile;
        }
        /// <summary>
        /// 解析文件
        /// </summary>
        /// <returns></returns>
        public IStoryBoardCommand[] Parse()
        {
            string[] s = File.ReadAllLines(StoryBoardCommandFile);
            StoryBoardCommandString lastStr = null;
            foreach (var line in s)
            {
                StringProcessor = new StringProcessor(line);
                StringProcessor.Process();
                lastStr = StringProcessor.SpaceNum == 0
                    ? new StoryBoardCommandString(null, StringProcessor.ProcessedString, StringProcessor.SpaceNum)
                    : new StoryBoardCommandString(lastStr, StringProcessor.ProcessedString, StringProcessor.SpaceNum);
                if (!string.IsNullOrEmpty(lastStr.Command))
                {
                    if (lastStr.CurrentCommand is IStoryBoardMainCommand && !_commands.Contains(lastStr.CurrentCommand)) //如果当前的命令是主命令
                        _commands.Add(lastStr.CurrentCommand);//添加到列表
                    /*if (!_commands.Contains(lastStr.ParentCommand) && !(lastStr.ParentCommand is null)) //如果当前命令的主命令不为空
                        _commands.Add(lastStr.ParentCommand);  // 添加到列表*/
                }

                /*if (!string.IsNullOrEmpty(lastStr.Command))
                {
                    if (lastStr.Parent == null)
                    {
                        last = new StoryBoardMainCommand();
                        last.Parse(lastStr.Command);
                        _commands.Add(last);
                    }
                    else
                    {
                        var par = last;
                        last = osuTools.StoryBoard.StoryBoardTools.GetEventClassByString(lastStr.Command);
                        if (last is IStoryBoardSubCommand sub)
                        {
                            sub.ParentCommand = par;
                            par.SubCommands.Add(sub);
                            if (!_commands.Contains(par))
                            {
                                if(!(par is IStoryBoardSubCommand))
                                {
                                    _commands.Add(par);
                                }
                            }
                        }
                    }
                    if (last == null)
                    {
                        Console.WriteLine("无法解析的文本。");
                        continue;
                    } 

                }*/

            }
            return _commands.ToArray();
        }

    }
}