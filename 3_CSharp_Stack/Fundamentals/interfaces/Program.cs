using System;

namespace ConsoleApplication
{
    public class Program
    {
        interface CanRun
        {
            int Run();
        }

        class Goat : CanRun
        {
            public int Run()
            {
                Console.WriteLine("I'm a goat running~");
                return 5;
            }
        }

        class Bird 
        {
            
        }

        class Ostrich: Bird, CanRun
        {
            public int Run()
            {
                Console.WriteLine("I'm a running bird...crazy");
                return -16;
            }
        }
        public static void Main(string[] args)
        {
            CanRun obj1 = new Ostrich();
            CanRun obj2 = new Goat();
            Bird obj3 = new Bird();

            obj1.Run();
            obj2.Run();
        }
    }
}
