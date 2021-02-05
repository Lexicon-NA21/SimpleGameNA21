using LimitedList;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new ConfigurationBuilder()
            //                    .SetBasePath(Environment.CurrentDirectory)
            //                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //                    .Build();

            //var ui = config.GetSection("consolegame:ui").Value;
            //var x = config.GetSection("consolegame:mapsettings:x").Value;
            //var mapsettings = config.GetSection("consolegame:mapsettings").GetChildren();

            var startup = new StartUp();
            startup.SetUp();

            //Game game = new Game(config);
            //game.Run();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
