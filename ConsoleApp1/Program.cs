using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("What's your name?");
            var nombre = Console.ReadLine();
            Console.WriteLine("Hey {0}", nombre);
            Console.Read();
        }
    }
}
