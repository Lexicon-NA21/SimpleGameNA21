using System;

namespace SimpleGameNA21
{
    internal class Hero : Creature
    {
        public Hero(Cell cell) : base(cell, "H ")
        {
            Color = ConsoleColor.Yellow;
        }
    }
}