using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortFiles
{
    class Program
    {
        static Dictionary<string, List<string>> type = new Dictionary<string, List<string>> {
           { "Text", new List<string> { ".txt", ".doc",".pdf"} },
           { "Images", new List<string> { ".png", ".jpeg",".ico",".jpg" } },
           { "Programs", new List<string> { ".exe" } },
           { "Videos", new List<string> { ".avi", ".mp4",".gif" } },
           { "Music", new List<string> { ".mp3", ".wav",".ogg" } },
           { "Archive", new List<string> { ".zip", ".rar" } },
           { "Code", new List<string> { ".cs", ".html",".php",".cpp",".js" } }

        };
        static string path = String.Empty;
        static List<string> files = new List<string>();
        static void Main(string[] args)
        {
            try
            {
                path = args[0];
                files = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
                CreateDirectories();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        static void CreateDirectories()
        {
            foreach (var item in type)
            {
                files.ForEach(file =>
                {
                    foreach (var val in item.Value)
                    {
                        if (file.Contains(val))
                        {
                            if(!Directory.Exists(@$"{path}\" + item.Key))
                                Directory.CreateDirectory(@$"{path}\" + item.Key);
                            File.Move(file, @$"{path}\" + @$"{item.Key}\" + Path.GetFileName(file));
                        }
                    }
                });
            }
        }
    }
}
