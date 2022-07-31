using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteTextWithColor(ConsoleColor color,string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();

        }

        public static void WriteTextWithColor(object grey, string v)
        {
            throw new NotImplementedException();
        }

        public static void WriteTextWithColor(ConsoleColor yellow, object name)
        {
            throw new NotImplementedException();
        }
    }
}
