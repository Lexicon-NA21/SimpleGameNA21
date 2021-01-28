using System;

namespace SimpleGameNA21
{
    internal class UI
    {
        internal static void Clear()
        {
            //Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
    }
}