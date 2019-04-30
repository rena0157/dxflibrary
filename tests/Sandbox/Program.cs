using System;
using System.Threading;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hello World";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello World");
            Thread.Sleep(5000);
        }
    }
}
