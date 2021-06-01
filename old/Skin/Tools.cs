using osuTools.Beatmaps;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace osuTools.Skins.Tools
{
    public static class SkinTools
    {
         public static T StringToEnum<T>(string str)
         {
            return (T)System.Enum.Parse(typeof(T), str);
         }
        public static List<string> GetMultipleFileSkinObject(osuTools.Skins.Skin s, string frontFileName)
        {
            string pattern = $"*.*";
            string dir = s.ConfigFileDirectory.Replace("skin.ini", "");
            var lst = Directory.GetFiles(dir, pattern, SearchOption.TopDirectoryOnly);
            int num = 0;
            List<string> files = new List<string>();
            foreach (var n in lst)
            {
                var fileName = Path.GetFileNameWithoutExtension(n);
                if (fileName.Remove(fileName.Length - 1) == frontFileName)
                {
                    if (fileName.Last().IsDigit())
                    {
                        num = fileName.Last() - '0';
                        files.Add(n);
                    }                    
                }
                else if (fileName == n)
                {
                    files.Add(n);
                }
            }
            if (files.Count == 0)
                files.Add("default");
            return files;
        }
        public static List<string> GetMultipleFileSkinObject(string[] fileList, string frontFileName)
        {
            string pattern = $"*.*";
            var lst = fileList;
            int num = 0;
            List<string> files = new List<string>();
            foreach (var n in lst)
            {
                var fileName = Path.GetFileNameWithoutExtension(n);
                if (fileName.Remove(fileName.Length - 1) == "-") fileName = fileName.Remove(fileName.Length - 1);
                if (fileName.Remove(fileName.Length - 1) == frontFileName)
                {
                    if (fileName.Last().IsDigit())
                    {
                        num = fileName.Last() - '0';
                        files.Add(n);
                    }
                }
                else if (fileName == frontFileName)
                {
                    files.Clear();
                    files.Add(n);
                    continue;
                }            
            }
            if (files.Count == 0)
            {
                //Debug.WriteLine($"Target file \"{frontFileName}\" can not be found with pattern {pattern}. Fallback method has invoked.");
                files.Add("default");
            }
            else
            {
                //Debug.WriteLine($"Found {files.Count} files with keyword \"{frontFileName}\".");
            }
            return files;
        }
    }
}