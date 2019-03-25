using System;
using System.Collections.Generic;
using ColinChang.ConfigurationManager;

namespace ColinChang.ConfigurationManager.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //try to run "dotnet run --name Colin --age 18"
            CommandLineConfiguration(args);

            InMemoryCollectionConfiguration();

            JsonFileConfiguration();

            JsonFileObjectConfiguration();

            Console.ReadKey();
        }

        private static void CommandLineConfiguration(string[] args)
        {
            var config = new Core.ConfigurationManager(args);

            Console.WriteLine($"name:{config["name"]} \t age:{config["age"]}");
        }

        private static void InMemoryCollectionConfiguration()
        {
            var settings = new Dictionary<string, string>
            {
                {"gender", "male"},
                {"nationality", "China"}
            };
            var config = new Core.ConfigurationManager(memoryCollection: settings);
            Console.WriteLine($"gender:{config["gender"]} \t nationality:{config["nationality"]}");
        }

        private static void JsonFileConfiguration()
        {
            var appName = Core.ConfigurationManager.Configuration["AppName"];
            //var className = Core.ConfigurationManager.Configuration["Class:ClassName"];
            var className = Core.ConfigurationManager.GetAppSettings("Class", "ClassName");
            var firstStudentName = Core.ConfigurationManager.Configuration["Class:Students:0:Name"];

            Console.WriteLine($"AppName:{appName}\tClassName:{className}\tFirstStudentName:{firstStudentName}");
        }

        private static void JsonFileObjectConfiguration()
        {
            var cls = Core.ConfigurationManager.GetAppSettings<Class>("Class");
            Console.WriteLine(cls.ClassName);
        }
    }
}