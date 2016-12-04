using System;

namespace WizNinSam
{
    public class Ninja : Human
    {
        // public int dexterity = 175;
        public Ninja(string name) : base(name, 3, 3, 175, 100)
        {

        }

        public void Steal(Human enemy) 
        {
            Attack(enemy);
            health += 10;
        }

        public object Get_away() {
            Console.WriteLine("{0} is now getting away!", name);
            health -= 15;
            return health;
        }
    }
}
