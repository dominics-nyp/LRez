using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRezService
{
    public class Log
    {
        public static void Message(string message)
        {
            Console.WriteLine(message);
        }

        public static void Warning(string message)
        {
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}