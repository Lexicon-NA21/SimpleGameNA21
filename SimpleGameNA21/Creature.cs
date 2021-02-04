using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21
{
    abstract class Creature : IDrawable
    {
        private  int health;
        private ConsoleColor color;
        private string name => this.GetType().Name;

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


        public ConsoleColor Color
        {
            get
            {
                return IsDead ? ConsoleColor.Gray : color;
            }
            set
            {
                color = value;
            }

        }
        public int MaxHealth { get; private set; }
        public int Damage { get; set; }

        public bool IsDead => health <= 0;

        public string Symbol { get; }
        //public int Maxhealth { get; }
        public Cell Cell { get; set; }
        public Action<string>  AddMessage { get; set; }

        public Creature(Cell cell, string symbol, int maxhealth)
        {
            Cell = cell;
            Symbol = symbol;
            MaxHealth = maxhealth;
            health = maxhealth;
            Color = ConsoleColor.Green;
        }

        internal void Attack(Creature target)
        {
            if (target.IsDead) return;

            var thisName = this.name;
            var targetName = target.name;

            target.Health -= Damage;
            AddMessage?.Invoke($"The {thisName} attacks the {targetName} for {this.Damage}");

            if (target.IsDead)
            {
                AddMessage?.Invoke($"The {targetName} is dead");
                return;
            }

            Health -= target.Damage;
            AddMessage?.Invoke($"The {targetName} attacks the {thisName} for {target.Damage}");

            if (IsDead)
            {
                AddMessage?.Invoke($"The {thisName} is dead");
                return;
            }

        }

    }
}
