using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();

            List<int> numbers = new List<int>();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
