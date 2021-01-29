using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    internal class Cell : IDrawable
    {
        public int X { get; }
        public int Y { get; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";
        public ConsoleColor Color { get; set; }

        public Cell(int y, int x)
        {
            Color = ConsoleColor.Red;
            Y = y;
            X = x;
        }
    }
}