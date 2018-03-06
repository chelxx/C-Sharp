using System;
using System.Collections.Generic;

namespace basic_13
{
    class Program
    {
        // #1 Print 1-255
        public static void Print_1_to_255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        // #2 Print odd numbers between 1-255
        public static void Print_Odds_1_to_255()
        {
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        // #3 Print Sum
        public static void Print_Sum()
        {
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                sum = sum + i;
                Console.WriteLine("New Number: " + i + ", Sum: " + sum);
            }
        }
        // #4 Iterating through an Array
        public static void Iterate_Array(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++){
                    Console.WriteLine(arr[i]);
            }
        }
        // #5 Find Max
        public static void Find_Max(int[] arr)
        {
            int max = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
                Console.WriteLine("The Max Number is: " + max);
        }
        // #6 Get Average
        public static void Get_Average(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length + 1; i++)
            {
                sum = sum + i;
            }
            int avg = sum / arr.Length;
            Console.WriteLine("The Average Number is: " + avg);
        }
        // #7 Array with Odd Numbers
        public static void Odd_Numbers()
        {

        }
        // #8 Greater than Y
        public static void Greater_Than_Y(int[] arr, int y)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > y)
                {
                    count = count + 1;
                }
            }
            Console.WriteLine("There are " + count + " numbers greater than Y.");
        }
        // #9 Square the Values
        public static void Square_Values(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * arr[i];
                Console.WriteLine(arr[i]);
            }
        }
        // #10 Eliminate Negative Numbers
        public static void No_Negatives()
        {
            int[] no_Negs = new int[6] {1,2,3,14,5,-88};
            for (int i = 0; i < no_Negs.Length; i++)
            {
                if (no_Negs[i] < 0)
                {
                    no_Negs[i] = 0;
                }
                Console.WriteLine(no_Negs[i]);
            }
        }
        // #11 Min, Max, and Average
        public static void Find_Min_Max_Avg(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
                if (min > arr[i])
                {
                    min = arr[i];
                }
                sum = sum + arr[i];
            }
            int avg = sum / arr.Length;
            Console.WriteLine("The results are: Min is " + min + ", Max is " + max + ", Sum is " + sum + ", and Avg is " + avg);
        }
        // #12 Shifting the values in an array
        public static void Shifting_Values(int[] arr)
        {
            List<int> shift = new List<int>();
        
            for(int i = 0; i < arr.Length-1; i++){
                shift.Add(arr[i+1]);
            }
            shift.Add(0);
            foreach(var thing in shift){
                Console.WriteLine(thing);
            }
        }
        // #13 Number to String
        public static void Number_To_String()
        {
            List<string> templist = new List<string>();

            for(int i = 0; i < numberArray.Length; i++){
                if(numberArray[i] < 0){
                    templist.Add("Dojo");
                } else {
                    templist.Add(numberArray[i].ToString());
                }
            }
            // templist.ToArray();
            foreach(var item in templist){
                Console.WriteLine(item);
            }
            return templist;
        }
        // Calling the Functions
        public static void Main(string[] args)
        {
            Print_1_to_255();
            Print_Odds_1_to_255();
            Print_Sum();
            int[] the_Array = new int[4] {1,5,10,-2};
            Iterate_Array(the_Array);
            Find_Max(the_Array);
            Get_Average(the_Array);
            Odd_Numbers(); // Needs work
            Greater_Than_Y(the_Array, 2);
            Square_Values(the_Array);
            No_Negatives(); // This has its own array
            Find_Min_Max_Avg(the_Array);
            Shifting_Values(the_Array);
            //object here
            Number_To_String();
        }
    }
}
