using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleGameNA21
{
    internal class ConsoleMap : IMap
    {
        private Cell[,] cells;

        public int Width { get; }
        public int Height { get; }

        public List<Creature> Creatures { get; set; } = new List<Creature>();

        public ConsoleMap(IConfiguration config)
        {
            Width = config.GetMapSizeFor("x");
            Height = config.GetMapSizeFor("y");
            

            cells = new Cell[Height, Width];


            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    cells[y, x] = new Cell(new Position(y, x));
                }
            }
        }

        public Cell GetCell(int y, int x)
        {

            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[y, x];
        }

        public Cell GetCell(Position newPosition)
        {
            return GetCell(newPosition.Y, newPosition.X);
        }

        public void Place(Creature creature)
        {
            if (Creatures.Where(c => c.Cell == creature.Cell).Count() >= 1)
                creature = null;
            else
                Creatures.Add(creature);
        }

        //Se CreatureAtExtension
        public IDrawable CreatureAt(Cell cell)
        {
            return Creatures.FirstOrDefault(creature => creature.Cell == cell);
        }
    }
}