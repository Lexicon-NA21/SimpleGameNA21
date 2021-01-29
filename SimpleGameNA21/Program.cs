using System;
using System.Collections.Generic;

namespace SimpleGameNA21
{
    class Program
    {
        static void Main(string[] args)
        {

            //string str = "Kalle";
            //var result =  str.AddWord("Anka");

            //var res2 = "Nisse";
            //var xx = res2.AddWord("Karlsson");

            Game game = new Game();
            game.Run();

            List<int> numbers = new List<int>();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
