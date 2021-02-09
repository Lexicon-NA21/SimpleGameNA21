using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    class Goblin : Creature
    {
        public Goblin(Cell cell, int maxHealth) : base(cell, "G ", maxHealth)
        {
            //Konstruktor?
            Damage = 15;
            Color = ConsoleColor.DarkMagenta;
        }
    }
}
