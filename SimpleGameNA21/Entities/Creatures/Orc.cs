using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    class Orc : Creature
    {
        public Orc(Cell cell, int maxHealth) : base(cell, "O ", maxHealth)
        {
            Damage = 30;
            Color = ConsoleColor.DarkYellow;
        }
    } 
}
