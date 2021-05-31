using FileManager.UI.Frames;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace FileManager.CommandParser.Functions
{
    class Listing:Command
    {
        public override string name { get; } = "ls";
        public override bool canHandle(string[] args)
        {
            if (args.Length < 3)
                return false;
            if (args[0] != name)
                return false;
            if (!Directory.Exists(args[1]))
                throw new DirectoryNotFoundException();
            if (args[2] != "-p")
                return false;
            if (!int.TryParse(args[3], out int result))
                return false;
            else
                return true;
        }
        public override void Handle(string[] args)
        {
            try
            {
                if (canHandle(args))
                {
                    var config = Config.LoadConfig();
                    var fs = GetFS(args[1]);
                    var page = int.Parse(args[3]);
                    var requiredPage = PagingHelper(fs, page, config.Paging, out int count);
                    FrameManager fm = new FrameManager();
                    fm.TreeFrameManageContent(requiredPage);
                }
            }
            catch(Exception e)
            {
                string[] err = { e.Message };
                FrameManager fm = new FrameManager();
                fm.TreeFrameManageContent(err);
            }
        }
        //public static string GetFS(string path)
        //{
        //    if (!Directory.Exists(path))
        //    {
        //        throw new DirectoryNotFoundException();
        //    }
        //    var pathName = path.Split('\\');
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"{path}");
        //    string[] files = Directory.GetFiles(path);
        //    if (files != null)
        //    {
        //        foreach (var file in files)
        //        {
        //            var fileName = file.Split('\\');
        //            sb.AppendLine($"{new string(' ',1)}*{fileName[fileName.Length - 1]}");
        //        }
        //    }
        //    var subdirs = Directory.GetDirectories(path);
        //    foreach (var subdir in subdirs)
        //    {
        //        var subdirName = subdir.Split('\\');
        //        sb.AppendLine($"{new string(' ', 1)}[]{subdirName[subdirName.Length - 1]}");
        //        string[] subsubdirs = Directory.GetDirectories(subdir);
        //        foreach(var subsubdir in subsubdirs)
        //        {
        //            var subsubdirName = subsubdir.Split("\\");
        //            sb.AppendLine($"{new string(' ', 2)}[]{subsubdirName[subsubdirName.Length - 1]}");
        //        }
        //        string[] subfiles = Directory.GetFiles(subdir);
        //        foreach(var subfile in subfiles)
        //        {
        //            var subfileName = subfile.Split('\\');
        //            sb.AppendLine($"{new string(' ', 2)}*{subfileName[subfileName.Length - 1]}");
        //        }
        //    }
        //    return sb.ToString().TrimEnd();
        //}

        public static List<string> GetFS(string path)
        {
            List<string> fileSystem = new List<string>();
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
            fileSystem.Add($"{path}\n\r");
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileName = file.Split('\\');
                    fileSystem.Add($"{new string(' ', 1)}*{fileName[fileName.Length - 1]}\n\r");
                }
            }
            var subdirs = Directory.GetDirectories(path);
            foreach (var subdir in subdirs)
            {
                var subdirName = subdir.Split('\\');
                fileSystem.Add($"{new string(' ', 1)}[]{subdirName[subdirName.Length - 1]}\n\r");
                string[] subsubdirs = Directory.GetDirectories(subdir);
                foreach (var subsubdir in subsubdirs)
                {
                    var subsubdirName = subsubdir.Split("\\");
                    fileSystem.Add($"{new string(' ', 2)}[]{subsubdirName[subsubdirName.Length - 1]}\n\r");
                }
                string[] subfiles = Directory.GetFiles(subdir);
                foreach (var subfile in subfiles)
                {
                    var subfileName = subfile.Split('\\');
                    fileSystem.Add($"{new string(' ', 2)}*{subfileName[subfileName.Length - 1]}\n\r");
                }
            }
            return fileSystem;
        }
        public static string[] PagingHelper(List<string> fs,int page,int perpage,out int count) //возвращает массив строк с пагинацией 
        {
            if (fs.Count == 0)
            {
                count = 0;//для пустой директории = 0
                return fs.ToArray();
            }
            var maxPages = fs.Count % perpage > 0 ? fs.Count / perpage + 1 : fs.Count / perpage;
            if(page > maxPages)
            {
                count = 0;
                return new string[0];
            }
            if(perpage*page > fs.Count)
            {
                count = fs.Count - ((page-1)*perpage);
                return fs.GetRange(perpage * (page - 1), count).ToArray();
            }
            else
            {
                count = perpage;
                return fs.GetRange((perpage * (page-1)), count).ToArray();
            }
        }
    }
}
