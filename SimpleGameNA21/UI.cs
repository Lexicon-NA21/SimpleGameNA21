using LimitedList;
using System;
using System.Linq;

namespace SimpleGameNA21
{
    internal static class UI
    {
        private static MessageLog<string> messageLog = new MessageLog<string>(6);

        //ToDo Exception...
        public static void AddMessage(string message) => messageLog.Add(message);

        public static void PrintLog()
        {
            messageLog.ActionAll(m => Console.WriteLine(m + new string(' ' , Console.WindowWidth - m.Length)));
        }

        //public static void PrintLog2()
        //{
        //    messageLog.ActionAll(Print);
        //}

        //private static void Print(string message)
        //{
        //    Console.WriteLine(message);
        //}

        internal static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);
                   // IDrawable drawable = cell;

                    IDrawable drawable = (map.Creatures.CreatureAtExtension(cell) ?? 
                                         cell.Items.FirstOrDefault())  ?? 
                                         cell;

                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}