using LimitedList;
using System;
using System.Linq;

namespace SimpleGameNA21
{
    internal class ConsoleUI : IUI
    {
        private ILimitedList<string> messageLog;
        private readonly IMap map;

        public ConsoleUI(ILimitedList<string> messageLog, IMap map)
        {
            this.messageLog = messageLog;
            this.map = map;
        }

        //ToDo Exception...
        public void AddMessage(string message) => messageLog.Add(message);

        public void PrintLog()
        {
            messageLog.ActionAll(m => Console.WriteLine(m + new string(' ', Console.WindowWidth - m.Length)));
        }

        //public static void PrintLog2()
        //{
        //    messageLog.ActionAll(Print);
        //}

        //private static void Print(string message)
        //{
        //    Console.WriteLine(message);
        //}

        public void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats + new string(' ', Console.WindowWidth - stats.Length));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        public void Draw()
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);
                    // IDrawable drawable = cell;

                    IDrawable drawable = (map.CreatureAt(cell) ??
                                         cell.Items.FirstOrDefault()) ??
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