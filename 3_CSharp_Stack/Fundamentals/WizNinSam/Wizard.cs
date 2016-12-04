using System;

namespace WizNinSam
{
    public class Wizard : Human
    {
        // public int health = 50;
        // public int intelligence = 25;
        public Wizard(string name) : base(name, 3, 25, 3, 50)
        {

        }

        public object Heal() {
            health += intelligence*5;
            Console.WriteLine("{0} used heal", name);
            return health;
        }

        // public object Heal (object Human2) {
        //     if (Human2 is Human) {
        //         Human Human3 = (Human)Human2;
        //         Human3.health += intelligence*5;
        //         return Human3;                
        //     } else {
        //         Console.WriteLine("This is not Human! Cannot Heal it!");
        //         return $"This is not Human";
        //     }
        // }
        public object Fireball (object Human2) {
            Random rand = new Random();
            int damage = rand.Next(20, 51);
            if (Human2 is Human) {
                Human Human3 = (Human)Human2;
                Human3.health -= damage;
                return Human3;                
            } else {
                Console.WriteLine("This is not Human. Cannot damage it.");
                return $"This is not Human";
            }
        }
    }
}
