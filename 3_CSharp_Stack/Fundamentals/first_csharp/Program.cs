using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int rings = 5;
            const string name = "Kobe";
            if (rings >= 5 && name == "Kobe")
            {
                Console.WriteLine("Welcome to the party {0}, congratulations on your {1} rings", name, rings);
            }
        }
    }
}
