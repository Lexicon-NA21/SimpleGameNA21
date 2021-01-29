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
    }
}
