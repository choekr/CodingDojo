using System;

namespace WizNinSam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human Sam = new Human("Sam");
            Human Bob = new Human("Bob");
            Wizard Dan = new Wizard("Dan");
            Ninja PJ = new Ninja("PJ");
            Samurai Leo = new Samurai("Leo");
            object Dave = new Object();

            Console.WriteLine("Sam's Health is: {0}", Sam.health);
            Bob.Attack(Sam);
            Console.WriteLine("Sam's Health is: {0}", Sam.health);  

            
            Console.WriteLine("============================");
            Console.WriteLine("Dan's health: {0}", Dan.health);
            // Dan.Heal();
            // Console.WriteLine("Dan's health: {0}", Dan.health);
            
            Console.WriteLine("============================");

            Console.WriteLine("PJ's Health: {0}", PJ.health);
            // PJ.Steal(Sam);
            // Console.WriteLine("Sam's health: {0}", Sam.health);
            // PJ.Steal(Dan);
            // Console.WriteLine("Dan's health: {0}", Dan.health);
            // PJ.Steal(Leo);
            // Console.WriteLine("Leo's health: {0}", Leo.health);
            // Leo.Meditate();
            // Console.WriteLine("Leo's health: {0}", Leo.health);
            // Dan.Fireball(PJ);
            // Console.WriteLine("PJ's health: {0}", PJ.health);            
            // Console.WriteLine("============================");
            // PJ.Attack(Sam);
            // Console.WriteLine("Sam's health: {0}", Sam.health);            
            PJ.Get_away();
            Console.WriteLine("PJ's Health: {0}", PJ.health);   
            PJ.Get_away();
            Console.WriteLine("PJ's Health: {0}", PJ.health);    
            PJ.Get_away();
            Console.WriteLine("PJ's Health: {0}", PJ.health);    
            PJ.Get_away();
            Console.WriteLine("PJ's Health: {0}", PJ.health);    
            PJ.Get_away();
            Console.WriteLine("PJ's Health: {0}", PJ.health);    
            PJ.Get_away();
            Console.WriteLine("PJ's Health: {0}", PJ.health);        
            Leo.how_many();  
            Leo.Death_Blow(PJ);
            Console.WriteLine("PJ's Health: {0}", PJ.health);
            
            // Console.WriteLine;
        }
    }
}
