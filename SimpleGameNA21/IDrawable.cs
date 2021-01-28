using System;

namespace SimpleGameNA21
{
    interface IDrawable
    {
        ConsoleColor Color { get; set; }
        string Symbol { get; }
    }
}