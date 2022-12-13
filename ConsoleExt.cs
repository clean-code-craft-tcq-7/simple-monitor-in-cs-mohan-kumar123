using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment4
{
    public static class ConsoleExt
    {
        public static void WriteLineForRange(this string str, string input)
        {
            Console.WriteLine("{0} is out of range!", input);
        }
    }
}
