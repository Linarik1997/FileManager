using FileManager.CommandParser;
using FileManager.CommandParser.Functions;
using FileManager.UI.Base;
using FileManager.UI.Frames;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Threading;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] empty = new string[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\l.khamitov\source\FileManagerCs\FileManager\appconfig.json", optional: true)
                .Build();
            Console.WindowHeight = int.Parse(configuration.GetSection("WindowHeight").Value);
            Console.WindowWidth = int.Parse(configuration.GetSection("WindowWidth").Value);
            int page = int.Parse(configuration.GetSection("Paging").Value);
            FrameManager fm = new FrameManager();
            fm.TreeFrame();
            fm.InfoFrame();
            fm.clFrame();
            while (true)
            {
                fm.SetCursorToCL();
                var b = Console.ReadLine();
                var command = b.Split(' ');
                fm.ClearCL();
                Parser parser = new Parser();
                Command line = parser.ParseLine(command);
                line.Handle(command);
            }
            var fs = Listing.GetFS(@"C:\Users\l.khamitov\source");
            var pages = Listing.PagingHelper(fs, 1, page, out int count);
            fm.TreeFrameManageContent(pages);
            Console.ReadLine();
        }
    }
}
