using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    abstract class Creature
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public string Symbol { get; }
        public Cell Cell { get; }

        public Creature(Cell cell, string symbol)
        {
            Cell = cell;
            Symbol = symbol;
        }

    }
}
