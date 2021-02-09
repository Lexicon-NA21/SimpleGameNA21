using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    class Potion : Item, IUsable
    {
        public Potion(string symbol, ConsoleColor color, string name) : base(symbol, color, name) { }

        public void Use(Creature creature) => creature.Health += 15;

        public static Potion HealthPortion() => new Potion("p ", ConsoleColor.Green, "Potion");
    }
}
