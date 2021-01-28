using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    internal class Cell : IDrawable
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";
        public ConsoleColor Color { get; set; }

        public Cell()
        {
            Color = ConsoleColor.Red;
        }
    }
}