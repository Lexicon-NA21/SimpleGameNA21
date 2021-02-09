using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    internal class Cell : IDrawable
    {
        public Position Position { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";
        public ConsoleColor Color { get; set; }

        public Cell(Position position)
        {
            Color = ConsoleColor.Red;
            Position = position;
        }
    }
}