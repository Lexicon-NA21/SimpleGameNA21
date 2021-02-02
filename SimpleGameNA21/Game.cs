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
                GetInput();
                //execute
                //Drawmap
                //Enemy actions
                //Drawmap

                //Console.ReadKey();
            } while (gameInProgress);
        }

        private void GetInput()
        {
            var keyPressed = UI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    Move(Direction.West);
                    break;
                case ConsoleKey.RightArrow:
                    Move(Direction.East);
                    break;
                case ConsoleKey.UpArrow:
                    Move(Direction.North);
                    break;
                case ConsoleKey.DownArrow:
                    Move(Direction.South);
                    break;
                case ConsoleKey.P:
                    PickUp();
                    break;
                case ConsoleKey.I:
                    Inventory();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private void Inventory()
        {
            foreach (var item in hero.BackPack)
            {
                Console.WriteLine(item);
            }
        }

        private void PickUp()
        {
            throw new NotImplementedException();
        }

        private void Move(Position movement)
        {

            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);
            if (newCell != null) hero.Cell = newCell;
        }

        private void DrawMap()
        {
            UI.Clear();
            UI.Draw(map);
           
        }

        private void Initialize()
        {
            //ToDo Take from config
            map = new Map(height: 10, width: 10);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);

            //ToDo random position
            map.GetCell(3, 3).Items.Add(Item.Coin());
            map.GetCell(1, 6).Items.Add(Item.Coin());
            map.GetCell(6, 7).Items.Add(Item.Torch());

        }
    }
}