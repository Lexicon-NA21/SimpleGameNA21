using System;

namespace SimpleGameNA21
{
    internal class UI
    {
        internal static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }
    }
}