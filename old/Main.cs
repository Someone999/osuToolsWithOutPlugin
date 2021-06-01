﻿namespace osuTools
{
    using osuTools.KeyBindings;
    using osuTools.Skins;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtraMethod
    {
        /// <summary>
        /// 将整数转换成布尔值
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool ToBool(this int Value)
        {
            if (Value == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        internal static ManiaSkinInfo CheckIndexAndGetValue(this Dictionary<int, ManiaSkinInfo> var, int index)
        {
            try
            {
                return var[index];

            }
            catch (KeyNotFoundException)
            {

                return new ManiaSkinInfo(-1, false, false);
            }
        }
        internal static Keys CheckIndexAndGetValue(this Dictionary<string, Keys> var, string index)
        {
            try
            {
                string tmp =
                        index == "LeftShift" ? "LShiftKey" :
                        index == "RightShift" ? "RShiftKey" :
                        index == "LeftControl" ? "LControlKey" :
                        index == "RightControl" ? "RControlKey" :
                        index == "LeftAlt" ? "LMenu" :
                        index == "RightAlt" ? "RMenu" : index;
                return var[tmp];
            }
            catch (KeyNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine($"找不到键位:{index}");
                return (Keys)(-1);
            }
        }
        internal static OsuGameMod CheckIndexAndGetValue(this Dictionary<string, OsuGameMod> var, string index)
        {
            try
            {
                if (index == "Auto")
                {
                    index = "AutoPlay";
                }
                if (index == "Autopilot")
                {
                    index = "AutoPilot";
                }
                if (index.StartsWith("key"))
                {
                    return var[index.Replace("key", "")];
                }
                return var[index];

            }
            catch (KeyNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine($"不支持的Mod:{index}");
                return OsuGameMod.Unknown;
            }
        }
        internal static Keys CheckIndexAndGetValue(this Dictionary<OsuGameMod, Keys> var, OsuGameMod index)
        {
            try
            {
                var tmp = index;
                if (index.ToString().Contains("Key"))
                {
                    tmp = OsuGameMod.Relax;
                }
                if (index == OsuGameMod.NightCore) tmp = OsuGameMod.DoubleTime;
                if (index == OsuGameMod.Perfect) tmp = OsuGameMod.SuddenDeath;
                if (index == OsuGameMod.FadeIn) tmp = OsuGameMod.Hidden;
                if (index == OsuGameMod.Random) tmp = OsuGameMod.AutoPilot;
                return var[tmp];

            }
            catch (KeyNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine($"不支持的Mod:{index}");
                return (Keys)(-1);
            }
        }


    }
    /// <summary>
    /// 表示最基本的游戏信息
    /// </summary>
    public class OsuInfo
    {
        string ver, song, osudir, username, skin;
        string cfg;
        int off;
        string[] lines;
        bool runing = false;
        Skin sk;
        /// <summary>
        /// 获取当前的皮肤，尚未完工。
        /// </summary>
        public Skin CurrentSkin { get => sk; }
        KeyBinding d;
        /// <summary>
        /// 快捷键的获取，实验功能。
        /// </summary>
        public KeyBinding ShortcutKeys { get => d; }
        void Init()
        {
            try
            {
                osuprocess = System.Diagnostics.Process.GetProcessesByName("osu!")[0];
                if (osuprocess.Id != 0)
                {
                    runing = true;
                }
                StringBuilder osudir;
                if (OsuDirectory != null)
                {
                    osudir = new StringBuilder(OsuDirectory);
                }
                else
                {
                    ReadFromFile();
                    osudir = new StringBuilder(this.osudir);
                }
                StringBuilder user = new StringBuilder($"osu!.");
                user.Append(Environment.UserName + ".cfg");
                osudir.Replace("osu!.exe", user.ToString());
                cfg = osudir.ToString() + user.ToString();
                lines = File.ReadAllLines(cfg);
                d = new KeyBinding(lines);
                this.osudir = osudir.ToString();
                GetCurrentSkin();
                GetOffset();
                GetSongDir();
                GetUserName();
                GetVersion();
                sk = new Skin(CurrentSkinDir);

                this.osudir = osudir.ToString();
                SaveToFile();
            }
            catch (NullReferenceException e)
            {
                ReadFromFile();
                lines = File.ReadAllLines(cfg);
                d = new KeyBinding(lines);
                GetCurrentSkin();
                GetOffset();
                GetSongDir();
                GetUserName();
                GetVersion();
                sk = new Skin(CurrentSkinDir);
                if (BeatmapDirectory == null)
                    throw new osuToolsException.FailToParse($"未能从文件读取，异常:{e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                ReadFromFile();
                lines = File.ReadAllLines(cfg);
                d = new KeyBinding(lines);
                GetCurrentSkin();
                GetOffset();
                GetSongDir();
                GetUserName();
                GetVersion();
                sk = new Skin(CurrentSkinDir);
                if (BeatmapDirectory == null)
                    throw new osuToolsException.FailToParse($"未能从文件读取，异常:{e.Message}");
            }
        }
        private void SetValue(string Name, string DestVal)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string data = lines[i];
                if (data.Contains(Name))
                {
                    string[] tmp = data.Split('=');
                    data = data.Replace(tmp[1].Trim(), DestVal);
                    lines[i] = data;
                    //MessageBox.Show(data);
                }
            }
        }
        /// <summary>
        /// 初始化一个OsuInfo对象
        /// </summary>
        public OsuInfo()
        {
            Init();
        }
        System.Diagnostics.Process osuprocess;
        /// <summary>
        /// osu!的窗口句柄
        /// </summary>
        public IntPtr WindowHanle { get => osuprocess.MainWindowHandle; }
        /// <summary>
        /// osu!的进程句柄
        /// </summary>
        public IntPtr ProcessHandle { get => osuprocess.Handle; }
        /// <summary>
        /// osu!当前的窗口标题
        /// </summary>
        public string Title { get => osuprocess.MainWindowTitle; }
        /// <summary>
        /// osu!的PID
        /// </summary>
        public int ProcessID { get => osuprocess.Id; }
        /// <summary>
        /// 当前存放osu!进程信息的System.Diagnostics.Process对象
        /// </summary>
        public System.Diagnostics.Process CurrentOsuProcess { get => osuprocess; }
        /// <summary>
        /// 强制关闭osu!
        /// </summary>
        public void KillGame() => osuprocess.Kill();
        /// <summary>
        /// osu!所在文件夹的全路径。
        /// </summary>
        public string OsuDirectory { get { if (osuprocess != null) { return osuprocess.MainModule.FileName.Replace("osu!.exe", ""); } return osudir; } } 
        void GetSongDir()
        {
            string osudir;
            if (osuprocess != null)
            {
                osudir = OsuDirectory;
            }
            else
            {
                osudir = this.osudir;
            }
            string tmp = string.Empty;
            foreach (var data in lines)
            {
                if (data.Trim().StartsWith("BeatmapDirectory"))
                {
                    tmp = data.Split('=')[1].Trim();
                    break;
                }
            }
            if (string.IsNullOrWhiteSpace(tmp))
                song = string.Empty;
            else
                song = osudir + tmp;
        }
        /// <summary>
        /// 获取存储谱面的文件夹的名称
        /// </summary>
        public string BeatmapDirectory
        {
            get => song;
            set
            {
                SetValue("BeatmapDirectory", value);
            }
        }
        void GetUserName()
        {
            foreach (var data in lines)
            {

                if (data.Trim().StartsWith("Username"))
                {
                    //MessageBox.Show(data.Split('=')[0].Trim()+"="+data.Split('=')[1].Trim());
                    username = data.Split('=')[1].Trim();
                    return;
                }
            }
            username = string.Empty;
        }/// <summary>
        /// 获取osu!当前登录用户的用户名
        /// </summary>
        public string UserName
        {
            get => username;
        }
        void GetVersion()
        {
            foreach (var data in lines)
            {
                var Cur = data.Trim();
                if (Cur.StartsWith("LastVersion"))
                {
                    string[] tmparr = new string[] { };
                    if (Cur.Split('=')[0].Trim() == "LastVersion")
                    {
                        tmparr = data.Split('=');
                        ver = tmparr[1].Trim();
                        return;
                    }
                    else if (Cur.Split('=')[0].Trim() == "LastVersionPermissionsFailed")
                    {

                    }

                }
            }
            ver = string.Empty;
        }/// <summary>
        /// 获取当前osu!的版本
        /// </summary>
        public string OsuVersion
        {
            get => ver;
        }
        void GetOffset()
        {
            {
                foreach (var data in lines)
                {
                    if (data.Trim().StartsWith("Offset"))
                    {
                        off = int.Parse(data.Split('=')[1].Trim());
                    }
                }
                off = 0;
            }
        }
        /// <summary>
        /// 获取当前的全局偏移量
        /// </summary>
        public int OverallOffset
        {
            get => off;
        }
        void GetCurrentSkin()
        {
            foreach (var data in lines)
            {
                if (data.StartsWith("Skin = "))
                {
                    skin = data.Split('=')[1].Trim();
                }
            }
        }
        /// <summary>
        /// 获取当前皮肤的全路径
        /// </summary>
        public string CurrentSkinDir
        {
            get => Path.Combine(SkinDir, skin);
            set
            {
                SetValue("Skin", value);
                skin = value;
            }
        }
        /// <summary>
        /// 获取存放皮肤的文件夹的全路径
        /// </summary>
        public string SkinDir
        {
            get => osudir + ("skins");
        }
        /// <summary>
        /// 将配置文件的路径存储到文件
        /// </summary>
        public void SaveToFile()
        {
            try
            {

                if (osuprocess != null)
                {
                    string FileName = "OsuInfo.txt";
                    File.WriteAllText(FileName, $"Osucfg = {cfg}");
                }
            }
            catch
            {
                
            }
           
        }
        /// <summary>
        /// 从文件读取信息
        /// </summary>
        public void ReadFromFile()
        {
            try
            {
                string FileName = "OsuInfo.txt";
                //System.Diagnostics.Debug.WriteLine($"ReadFileFrom{FileName}");
                var strs = File.ReadAllLines(FileName);
                foreach (string i in strs)
                {
                    string[] tmp = i.Split('=');
                    if (tmp[0].Trim() == "Osucfg")
                    {
                        //System.Diagnostics.Debug.WriteLine(tmp[0] + "  " + tmp[1]);

                        cfg = tmp[1].Trim();
                        if (File.Exists(cfg))
                            osudir = cfg.Replace($"osu!.{Environment.UserName}.cfg", "");
                        else throw new FileNotFoundException();
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 将对象中存储的信息写入文件
        /// </summary>
        /// <param name="FileName"></param>
        public void WriteConfigToFile(string FileName) => File.WriteAllLines(FileName, lines);
        /// <summary>
        /// 如果osu!在运行，则在析构时将配置文件的路径保存至文件
        /// </summary>
        ~OsuInfo()
        {
            if (runing)
                SaveToFile();
        }
    }
}
