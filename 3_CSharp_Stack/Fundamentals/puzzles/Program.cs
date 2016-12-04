using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // randomArray();
            TossCoin(null);
            TossMultipleCoins(100);
            // Names();
            // longerNames(string[] names);
            // string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            
        }

        // // Random Array        

        // // List to Array method
        // public static void randomArr(){
        //     Random random = new Random();
        //     List<int> integers = new List<int>();
        //     for (int i=0; i<10; i++) {
        //         int num = random.Next(5,26);
        //         integers.Add(num);
        //     }
        //     int[] randomArr = integers.ToArray();
        
        // // Array directly
        // public static int[] randomArray() {
        //     Random random = new Random();
        //     int[] randomArr = new int[10];
        //     for (int i=0; i<10; i++) {
        //         randomArr[i] = random.Next(5,26);
        //     }
        // // Print whole array
        //     for (int i=0; i<10; i++) {
        //         Console.WriteLine(randomArr[i]);
        //     }

        // // Print the min and max
        //     int min = randomArr[0];
        //     int max = randomArr[0];
        //     for (int j=1; j<10; j++) {
        //         if (min > randomArr[j]) {
        //             min = randomArr[j];
        //         }
        //         if (max < randomArr[j]) {
        //             max = randomArr[j];
        //         }
        //     }
        //     Console.WriteLine("Max: {0}, Min:{1}", max, min);

        // // Print the sum of all values
        //     int sum = randomArr[0]; 
        //     for (int k=1; k<10; k++) {
        //         sum += randomArr[k];
        //     }
        //     Console.WriteLine("Sum: {0}", sum);

        // Return an integer array
        //     return randomArr;
        // }

        // // Coin Flip
        public static string TossCoin(Random ran) {
            Random ran1 = new Random();
            ran1 = (ran == null) ? new Random() : ran;
            string result;
            int flip = ran1.Next(0,2);
            if (flip == 0) {
                result = "Heads";
            } else {
                result = "Tails";
            }
            Console.WriteLine("Tossing a Coin!");
            Console.WriteLine("The result of this coin flip was {0}", result);
            return result;
        }
        // // Multiple Coin flips
        public static double TossMultipleCoins(int num) {
            double TailCount = 0;
            double HeadCount = 0;
            Random random = new Random();
            for (int i=0; i<num; i++) {
                string toss = TossCoin(random);
                if (toss == "Tails") {
                    TailCount += 1;
                } else {
                    HeadCount += 1;
                }
            }
            double ratio = HeadCount/num;

            Console.WriteLine("Heads: {0}, Tails: {1}, Total: {2}, Ratio: {3}", HeadCount, TailCount, num, ratio);
            return ratio;
        }

        // Name
        // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the array and point the values in the new order
        public static string[] Names() {
            // string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            string[] names = new string[5];
            names[0] = "Todd";
            names[1] = "Tiffany";
            names[2] = "Charlie";
            names[3] = "Geneva";
            names[4] = "Sydney";

            string[] shuffledNames = new string[5];

            Random random = new Random();

            for (int i=0; i<names.Length; i++) {
                int pos = random.Next(0,shuffledNames.Length);
                if (shuffledNames[pos] == null) {
                    shuffledNames[pos] = names[i];
                } else {
                    i-=1;
                }
            }
            for (int j=0; j<shuffledNames.Length; j++) {
                Console.WriteLine(shuffledNames[j]);
            }
            // return shuffledNames;

        // Return an array that only includes names longer than 5 characters
            List<string> longerNames = new List<string>();
            for (int i=0; i<names.Length; i++) {
                if (names[i].Length > 5) {
                    longerNames.Add(names[i]);
                }
            }
            string[] result = longerNames.ToArray();

            for (int i=0; i<result.Length; i++) {
                Console.WriteLine(result[i]);
            }

            return result;
        }
    }
}