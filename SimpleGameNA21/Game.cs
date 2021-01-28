using System;

namespace SimpleGameNA21
{
    internal class Game
    {
        private Map map;
        private Hero hero;

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {
            bool gameInProgress = true;
            do
            {
                //Drawmap
                DrawMap();
                //Get command
                //execute
                //Drawmap
                //Enemy actions
                //Drawmap

                Console.ReadKey();
            } while (gameInProgress);
        }

        private void DrawMap()
        {
            UI.Clear();
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);

                    Console.Write(cell.Symbol);
                }
                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            //ToDo Take from config
            map = new Map(height: 10, width: 10);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
        }
    }
}