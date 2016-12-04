using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Loop that prints all values from 1-255

            // for (var i = 1; i<=255; i++) {
            //     Console.WriteLine(i);
            // }

            // Create a new loop hat prints all values from 1-100 that are divisible by 3 or 5, but not both
            // for (var i = 1; i<=100; i++) {
            //     if ((i%3 == 0 || i%5 == 0) && !(i%3 == 0 && i%5 ==0)){
            //         Console.WriteLine(i);
            //     }
            // }

            // Modify the previous loop to print
            // int num = 1;
            // while (num<101){
            //     if (num%3 == 0 ^ num%5 == 0) {
            //         Console.WriteLine(num);
            //     }                    
            //     num = num + 1;
            // }

            // If you used modulus in the last step, try doing the same without using it. Vice-versa for those who didn't!

            for (var i = 1; i <=100; i++) {
                decimal threes=i/3;
                decimal fives=i/5;
                if ((i - 3 * Math.Floor(threes) == 0 || i - 5 * Math.Floor(fives) ==0) && !(i - 3 * Math.Floor(threes) ==0 && i - 5 * Math.Floor(fives) == 0)){
                    Console.WriteLine(i);
                }
            }
        }
    }
}
