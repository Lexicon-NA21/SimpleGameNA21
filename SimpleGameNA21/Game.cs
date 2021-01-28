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
            
        }

        private void Initialize()
        {
            map = new Map(width: 10, height: 10);
            hero = new Hero();
        }
    }
}