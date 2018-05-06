using System;

namespace Akka.NetCore.Utils
{
    public static class ConsoleUtil
    {
        public static void WriteColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}