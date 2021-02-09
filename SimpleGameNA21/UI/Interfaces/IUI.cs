﻿using System;

namespace SimpleGameNA21
{
    internal interface IUI
    {
        void AddMessage(string message);
        void Clear();
        void Draw();
        ConsoleKey GetKey();
        void PrintLog();
        void PrintStats(string stats);
    }
}