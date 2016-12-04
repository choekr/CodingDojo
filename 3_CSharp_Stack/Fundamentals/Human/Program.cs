using System;

namespace ConsoleApplication
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public Human(string name1) {
            name = name1;
        }
        public Human(string name1, int strength1, int intelligence1, int dexterity1, int health1){
            name = name1;
            strength = strength1;
            intelligence = intelligence1;
            dexterity = dexterity1;
            health = health1;
        }
        // //Add a method called attack, which when invoked, should attack another Human object that is passed as a parameter. The damage done should be 5x strength.
        // public Human Attack(Human Human2) {
        //     Human2.health -= strength*5;
        //     Console.WriteLine(health);
        //     return Human2;
        // }

        // Check for type Human before applying damage.
        public object Attack (object Human2) {
            if (Human2 is Human) {
                Human Human3 = (Human)Human2;
                Human3.health -= strength*5;
                return Human3;                
            } else {
                Console.WriteLine("This is not Human");
                return $"This is not Human";
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Human Sam = new Human("Sam");
            Human Bob = new Human("Bob");
            object Dave = new Object();
            Console.WriteLine("Sam's Health is: {0}", Sam.health);
            Bob.Attack(Sam);
            Console.WriteLine("Sam's Health is: {0}", Sam.health);            
        }
    }
}
