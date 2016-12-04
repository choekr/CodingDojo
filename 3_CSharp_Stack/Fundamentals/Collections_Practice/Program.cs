using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // //Create an empty array to hold integer values 0 through 9
            // int [] array1 = new int[10];
            // int [] array2 = {0,1,2,3,4,5,6,7,8,9};

            // //Create an array of the names "Tim", "Martin", "Nikki", and "Sara"
            // string [] array3 = new string[4];
            // array3[0] = "Tim";
            // array3[1] = "Martin";
            // array3[2] = "Nikki";
            // array3[3] = "Sara";
            // for (int idx=0; idx<array3.Length; idx++) {
            //     Console.WriteLine(array3[idx]);
            // }

            // string [] array4 = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            // for (int idx=0; idx<array4.Length; idx++){
            //     Console.WriteLine(array4[idx]);
            // }

            // //Create an array with space 10 that alternates between true and false values, starting with true
            // bool [] array5 = new bool [10];
            // for (int idx=0; idx<array5.Length; idx++) {
            //     if (idx%2 == 0) {
            //         array5[idx] = true;
            //     } else {
            //         array5[idx] = false;
            //     }
            // }
            // for (int idx=0; idx<array5.Length; idx++) {
            //     Console.WriteLine(array5[idx]);
            // }

            // //With the values 1-10, use code to generate a multiplication table

            // for (int i = 1; i <= 10; i++) {
            //     Console.Write("[");
            //     for (int j = 1; j <= 10; j++) {
            //         Console.Write(i * j + "," + "\t");
            //     }
            //     Console.Write("]");
            //     Console.Write("\n");
            // }

            // //Use a multidimensional array to store all values
            // int [,] array6 = new int[10,10];
            // for (int i = 0; i < 10; i++) {
            //     for (int j = 0; j < 10; j++) {
            //         array6[i,j] = (i+1)*(j+1); 
            //     }
            // }

            // for (int i = 0; i <10; i++) {
            //     Console.Write("[");
            //     for (int j = 0; j<10; j++) {
            //         Console.Write(array6[i,j] + "," + "\t");
            //     }
            //     Console.Write("]");
            //     Console.Write("\n");
            // }

            // // Create a Dictionary for storing Name, Favorite Sport, Num of Pets, and True/False for whether or not a user likes IceCream.

            // Dictionary<string,object> profile = new Dictionary<string,object>();
            // profile.Add("Name", "K");
            // profile.Add("Favorite Sport", "Football");
            // profile.Add("Num of Pets", 3);
            // profile.Add("Likes Ice Cream?", true);
            // foreach (var entry in profile)
            // {
            // Console.WriteLine(entry.Key + "-" + entry.Value);
            // }

            // // Create 4 different dictionaries holding information for the 4 people in the array you created earlier

            // Dictionary<string,object> tim = new Dictionary<string,object>();
            // tim.Add("Name", array3[0]);
            // tim.Add("Favorite Sport", "Football");
            // tim.Add("Num of Pets", 1);
            // tim.Add("Likes Ice Cream?", true);

            // Dictionary<string,object> martin = new Dictionary<string,object>();
            // martin.Add("Name", array3[1]);
            // martin.Add("Favorite Sport", "Soccer");
            // martin.Add("Num of Pets", 2);
            // martin.Add("Likes Ice Cream?", false);

            // Dictionary<string,object> nikki = new Dictionary<string,object>();
            // nikki.Add("Name", array3[2]);
            // nikki.Add("Favorite Sport", "Volleyball");
            // nikki.Add("Num of Pets", 3);
            // nikki.Add("Likes Ice Cream?", true);

            // Dictionary<string,object> sara = new Dictionary<string,object>();
            // sara.Add("Name", array3[3]);
            // sara.Add("Favorite Sport", "Softball");
            // sara.Add("Num of Pets", 4);
            // sara.Add("Likes Ice Cream?", false);

            // List<Dictionary<string,object>> profiles = new List<Dictionary<string, object>>();
            //     profiles.Add(sara);
            //     profiles.Add(nikki);
            //     profiles.Add(martin);
            //     profiles.Add(tim);
            
            // foreach(Dictionary<string,object> profile in profiles) {
            //     foreach(KeyValuePair<string,object> entry in profile) {
            //         Console.WriteLine(entry.Key + " - " + entry.Value);
            //     }
            //     // Console.WriteLine("-" + profile);
            // }
        }
    }
}

