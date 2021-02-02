using LimitedList;
using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LimitedList<int>(6);
            var number2 = list[1];
            //list[2] = 4;

            Game game = new Game();
            game.Run();

            List<int> numbers = new List<int>();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
