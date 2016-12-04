using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // printNum();  
            // printOdds();     
            // printSum();
            // iterate(new int[6] {1,3,5,7,9,13});
            // findMax(new int[3] {-3,-5,-7});
            // findMax(new int[3] {3,5,7});
            // findMax(new int[3] {13, -5, 100});
            // average(new int[3] {2,10,3});
            // oddArray();
            // greaterThanY(new int[4] {1,3,5,7}, 3);
            // square(new double[4] {1,3,5,7});
            // noNeg(new int[4] {1,5,10,-2});
            // minMaxAvg(new int[4] {1,5,10,-2});
            // shift(new int[5] {1,5,10,7,-2});
            // numToStr(new int[3] {-1, -3, 2}); //When using List to String method
            // numToStr(new object[3] {-1, -3, 2}); //When using typecast method
        }

        // // Print 1-255
        // public static void printNum(){
        //     for (int i = 1; i <= 255; i++) {
        //         Console.WriteLine(i);
        //     }
        // }  

        // // Print odds between 1-255
        // public static void printOdds() {
        //     for (int i = 1; i <=255; i++) {
        //         if (i%2 != 0) {
        //             Console.WriteLine(i);
        //         }
        //     }
        // }

        // // Print Sum
        // public static void printSum() {
        //     int sum = 0;
        //     for (int i=0; i<=255; i++) {
        //         sum = sum + i;
        //         Console.WriteLine("New number:  {0}  Sum: {1}", i, sum);
        //     }
        // }

        // // Iterating through an Array
        // public static void iterate(int[] arr) {
        //     for (int i=0; i<arr.Length; i++) {
        //         Console.WriteLine(arr[i]);
        //     }
        // }

        // // Find Max
        // public static int findMax(int[] arr) {
        //     int max = arr[0];
        //     for (int i = 1; i<arr.Length; i++) {
        //         if(max<arr[i]) {
        //             max = arr[i];
        //         }
        //     }
        //     Console.WriteLine(max);
        //     return max;
        // }

        // // Get Average
        // public static void average(int[] arr) {
        //     int total = 0;
        //     for (int i=0; i<arr.Length; i++) {
        //         total += arr[i];
        //     }
        //     int avg = total/arr.Length;
        //     Console.Write(avg);
        // }

        // // Array with Odd number
        // public static void oddArray() {
        //     List<int> odds = new List<int>();
        //     for (int i=1; i<=255; i++) {
        //         if (i%2 != 0) {
        //             odds.Add(i);
        //         }
        //     }
        //     int[] oddArr = odds.ToArray();
        //     for (int j=0; j<oddArr.Length; j++) {
        //     Console.WriteLine(oddArr[j]);
        //     }
        //     // Console.Write(odds);
        // }

        // //Greater than y
        // public static int greaterThanY(int[] arr, int Y) {
        //     int count = 0;
        //     for (int i=0; i<arr.Length; i++){
        //         if (arr[i]>Y){
        //             count += 1;
        //         }
        //     }
        //     Console.WriteLine(count);                
        //     return count;
        // }

        // // Square the Values
        // public static void square(double[] arr){
        //     for (int i=0; i<arr.Length; i++) {
        //         arr[i] = Math.Pow(arr[i], 2);
        //     }
        //     for (int i=0; i<arr.Length; i++) {
        //         Console.WriteLine(arr[i]);
        //     }
        // }

        // // Eliminate negative numbers
        // public static void noNeg(int[] arr) {
        //     for (int i=0; i<arr.Length; i++) {
        //         if (arr[i]<0) {
        //             arr[i] = 0;
        //         }
        //     }
        //     for (int i=0; i<arr.Length; i++) {
        //         Console.WriteLine(arr[i]);
        //     }
        // }

        // // Min, Max, and Average
        // public static void minMaxAvg(int[] arr) {
        //     int min = 0;
        //     int max = 0;
        //     double total = 0;
        //     for (int i=0; i<arr.Length; i++) {
        //         total += arr[i];
        //         if(min>arr[i]){
        //             min = arr[i];
        //         }
        //         if(max<arr[i]){
        //             max = arr[i];
        //         }
        //     }
        //     double avg = total/arr.Length;

        //     Console.WriteLine("Min:{0}, Max:{1}, Average:{2}", min, max, avg);
        // }

        // // Shifting the values in an Array
        // public static void shift(int[] arr) {
        //     for (int i = 0; i < arr.Length; i++) {
        //         if (i != arr.Length-1) {
        //             arr[i] = arr[i+1];
        //         } else if (i == arr.Length-1) {
        //             arr[i] = 0; 
        //         }
        //     }
        //     for (int i=0; i<arr.Length; i++) {
        //         Console.WriteLine(arr[i]);
        //     }
        // }

        // // Number to string
        // // Using List to Array method

        // public static void numToStr(int[] arr) {
        //     List<object> list = new List<object>();
        //     for (int i = 0; i<arr.Length; i++) {
        //         if (arr[i]<0) {
        //             list.Add("Dojo");
        //         } else if (arr[i]>0) {
        //             list.Add(arr[i]);
        //         }
        //     }
        //     object[] newArr = list.ToArray();
        //     for (int i = 0; i<newArr.Length; i++){
        //         Console.WriteLine(newArr[i]);
        //     }
        // }

        // // Using TypeCast method
        // public static void numToStr(object[] arr) {
        //     for (int i=0; i<arr.Length; i++) {
        //         if ((int)arr[i] <0) {
        //             arr[i] = "Dojo";
        //         }
        //     }
        //     for (int i=0; i<arr.Length; i++) {
        //         Console.WriteLine(arr[i]);
        //     }
        // }

    }
}
