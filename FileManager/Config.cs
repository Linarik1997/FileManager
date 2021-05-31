using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FileManager
{
    class Config
    {
        private readonly string filename = @"C:\Users\l.khamitov\source\FileManagerCs\FileManager\appconfig.json";
        public string LastOpenedPath { get; set; } 
        public int WindowHeight { get; set; } = 40;
        public int WindowWidth { get; set; } = 160;
        public int Paging { get; set; } 

        public static void UpdateConfig()
        {
            Config config = new Config();
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string json = JsonSerializer.Serialize(config, options);
            File.WriteAllText(config.filename, json);
        }
        public static Config LoadConfig()
        {
            Config config = new Config();
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string json = File.ReadAllText(config.filename);
            return config = JsonSerializer.Deserialize<Config>(json);
        }
    }
}
