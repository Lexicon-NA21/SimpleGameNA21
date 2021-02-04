using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    abstract class Creature : IDrawable
    {
        private  int health;

        public int Health
        {
            get 
            { 
                return health < 0 ? 0 : health; 
            }
            set 
            { 
                health = value >= MaxHealth ? MaxHealth : value; 
            }
        }
        public int MaxHealth { get; private set; }
        public int Damage { get; set; }

        public bool IsDead => health <= 0;

        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public string Symbol { get; }
        public int Maxhealth { get; }
        public Cell Cell { get; set; }

        public Creature(Cell cell, string symbol, int maxhealth)
        {
            Cell = cell;
            Symbol = symbol;
            Maxhealth = maxhealth;
            health = maxhealth;
        }

    }
}
