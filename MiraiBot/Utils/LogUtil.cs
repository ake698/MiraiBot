using System;
using System.Collections.Generic;
using System.Text;

namespace MiraiBot.Utils
{
    public static class LogUtil
    {
        public static void LogInfo(this string log)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.Now:hh:mm:ss}: {log}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogError(this string log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now:hh:mm:ss}: {log}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
