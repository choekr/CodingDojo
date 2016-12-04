using System;

namespace WizNinSam
{
    public class Samurai : Human
    {
        // public int health = 200;
        protected static int Count = 0;
        
        public Samurai(string name) : base(name, 3, 3, 3, 200)
        {
            Count ++;
        }

        public void Death_Blow (Human enemy) 
        {
            if (enemy.health < 50) 
            {
                Console.WriteLine("{0}'s been wiped out by {1}'s Death Blow. RIP", enemy.name, name);
                enemy.health = 0;
            }
            else 
            {
                Console.WriteLine("{0} has enough health to resist {1}'s Death Blow.", enemy.name, name);
            }
        }

        public void Meditate () 
        {
            if (health > 200) 
            {
                Console.WriteLine("No need to meditate! have more than enough health!");
            }
            else if (health <200) 
            {
                Console.WriteLine("Piece of mind");
                health = 200;
            }

        }

        public int how_many()
        {
            if (Count <= 1)
            {
            Console.WriteLine("There is {0} of your kind (Samurai)", Count);
            }
            else
            {
            Console.WriteLine("There are {0} of your kind (Samurais)", Count);
            }
            return Count;
        }
    }
}
