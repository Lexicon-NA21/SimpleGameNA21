using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    static class Extensions
    {
        public static string AddWord(this string str, string newWord)
        {
            return $"{str} {newWord}";
        }

        public static IDrawable CreatureAtExtension(this IEnumerable<Creature> creatures, Cell cell)
        {
            IDrawable result = null;
            foreach (var creature in creatures)
            {
                if (creature.Cell == cell)
                {
                    result = creature;
                    break;
                }
            }
            return result;
        }


        public static int GetMapSizeFor(this IConfiguration config, string name)
        {
            var section = config.GetSection("consolegame:mapsettings");
            return int.TryParse(section[name], out int result) ? result : 0;
        } 
        
        public static void AddUI(this ServiceCollection services, IConfiguration config)
        {
            var ui = config.GetSection("consolegame:ui").Value;

            switch (ui)
            {
                case "console":
                    services.AddSingleton<IUI, ConsoleUI>();
                    break;
                //Add more options here...
                default:
                    break;
            }
        }

    }
}
