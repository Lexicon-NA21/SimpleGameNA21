using Microsoft.Extensions.Configuration;
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
    }
}
