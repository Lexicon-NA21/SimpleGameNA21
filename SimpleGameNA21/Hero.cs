using LimitedList;
using System;

namespace SimpleGameNA21
{
    internal class Hero : Creature
    {
        public LimitedList<Item> BackPack { get; }
        public Hero(Cell cell) : base(cell, "H ", 100)
        {
            Color = ConsoleColor.Yellow;
            BackPack = new LimitedList<Item>(3); //ToDo Read from Config
            Damage = 100;
        }
    }
}