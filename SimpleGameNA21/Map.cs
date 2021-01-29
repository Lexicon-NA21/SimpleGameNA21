using System.Collections.Generic;

namespace SimpleGameNA21
{
    internal class Map
    {
        private Cell[,] cells;

        public int Width { get; }
        public int Height { get; }

        public List<Creature> Creatures { get; set; } = new List<Creature>();

        public Map(int height, int width)
        {
            Width = width;
            Height = height;

            cells = new Cell[height, width];


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell(y, x);
                }
            }
        }

        internal Cell GetCell(int y, int x)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[y, x];
        }

    }
}