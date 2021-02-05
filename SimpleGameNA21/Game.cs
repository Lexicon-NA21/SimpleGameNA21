using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleGameNA21
{
    internal class Game
    {
        private IUI ui;
        private IMap map;
        private Hero hero;
        private bool gameInProgress;
        private IConfiguration config;

        public Game(IConfiguration config, IMap map, IUI ui)
        {
            this.config = config;
            this.ui = ui;
            this.map = map;
        }

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {
            gameInProgress = true;
            do
            {
                //Drawmap
                DrawMap();
                //Get command
                GetInput();
                //execute
                DrawMap();
                //Enemy actions
                //Drawmap

                //Console.ReadKey();
            } while (gameInProgress);
        }

        private void GetInput()
        {
            var keyPressed = ui.GetKey();

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
                //case ConsoleKey.P:
                //    PickUp();
                //    break;
                //case ConsoleKey.I:
                //    Inventory();
                //    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;

            }

            var actionMeny = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.P, PickUp },
                        {ConsoleKey.I, Inventory },
                        {ConsoleKey.D, Drop }
                    };

            if (actionMeny.ContainsKey(keyPressed))
                actionMeny[keyPressed]?.Invoke();

        }

        private void Drop()
        {
            var item = hero.BackPack.FirstOrDefault();
            if (hero.BackPack.Remove(item))
            {
                //map.GetCell(hero.Cell.Position).Items.Add(item);
                hero.Cell.Items.Add(item);
                ui.AddMessage($"Hero dropped the {item}");
            }
            else
                ui.AddMessage("Backpack is empty");
        }

        private void Inventory()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Inventory: ");

            for (int i = 0; i < hero.BackPack.Count; i++)
            {
                builder.AppendLine($"{i + 1}: \t{hero.BackPack[i]}");
            }
            ui.AddMessage(builder.ToString());
        }

        private void PickUp()
        {
            if (hero.BackPack.IsFull)
            {
                ui.AddMessage("BackPack is full");
                return;
            }

            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item is null) return;

            if(item is IUsable usable)
            {
                usable.Use(hero);
                hero.Cell.Items.Remove(item);
                ui.AddMessage($"Hero use the {item}");
                return;
            }

            if (hero.BackPack.Add(item))
            {
                ui.AddMessage($"Hero picks up {item}");
                items.Remove(item);
            }

        }

        private void Move(Position movement)
        {

            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);

            var opponent = map.CreatureAt(newCell) as Creature;
            if (opponent != null) hero.Attack(opponent);

            gameInProgress = !hero.IsDead;

            if (newCell != null)
            {
                hero.Cell = newCell;
                if (newCell.Items.Any())
                    ui.AddMessage("You see " + string.Join(", ", newCell.Items.Select(i => i.ToString())));
            }
        }

        private void DrawMap()
        {
            ui.Clear();
            ui.Draw();
            ui.PrintStats($"Health: {hero.Health}, Enemys: {map.Creatures.Where(c => !c.IsDead).Count() - 1}");
            ui.PrintLog();
        }

        private void Initialize()
        {
            var width = config.GetMapSizeFor("x");
            var height = config.GetMapSizeFor("y");

            //var width =   int.Parse(config.GetSection("consolegame:mapsettings:x").Value);
            //var mapSettings = config.GetSection("consolegame:mapsettings");
            //int.TryParse(mapSettings["y"], out int height);

            //map = new ConsoleMap(height, width);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);

            var r = new Random();

            //map.GetCell(2,2).Items.Add(Item.Coin());
            //map.GetCell(2,2).Items.Add(Item.Coin());
            map.GetCell(RH(r),RW(r)).Items.Add(Item.Coin());
            map.GetCell(RH(r),RW(r)).Items.Add(Item.Coin());
            map.GetCell(RH(r), RW(r)).Items.Add(Item.Torch());
            map.GetCell(RH(r), RW(r)).Items.Add(Potion.HealthPortion());
            map.GetCell(RH(r), RW(r)).Items.Add(Potion.HealthPortion());

            map.Place(new Orc(map.GetCell(RH(r),RW(r)), 120));
            map.Place(new Orc(map.GetCell(RH(r),RW(r)), 120));
            map.Place(new Troll(map.GetCell(RH(r), RW(r)), 160));
            map.Place(new Troll(map.GetCell(RH(r), RW(r)), 160));
            map.Place(new Goblin(map.GetCell(RH(r), RW(r)), 200));

            map.Creatures.ForEach(c =>
            {
                c.AddMessage = ui.AddMessage;
                c.AddMessage += m => Debug.WriteLine(m);
            });

        }

        private int RH(Random random)
        {
            return random.Next(0, map.Height);
        }

        private int RW(Random random)
        {
            return random.Next(0, map.Width);
        }
    }
}