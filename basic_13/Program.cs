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
        public static void Iterate_Array()
        {
            int[] numberArray = {1,3,5,7,9,13};
            for(int i = 0; i < numberArray.Length; i++){
                    Console.WriteLine(numberArray[i]);
            }
        }
        // #5 Find Max
        public static void Find_Max()
        {
            int[] max_Array = {1,2,3,14,5};
            int max = max_Array[0];
            for(int i = 0; i < max_Array.Length; i++)
            {
                if (max < max_Array[i])
                {
                    max = max_Array[i];
                }
            }
                Console.WriteLine("The Max Number is: " + max);
        }
        // #6 Get Average
        public static void Get_Average()
        {
            int[] avg_Array = {1,2,3,4,5};
            int sum = 0;
            for (int i = 0; i < avg_Array.Length + 1; i++)
            {
                sum = sum + i;
            }
            int avg = sum / avg_Array.Length;
            Console.WriteLine("The Average Number is: " + avg);
        }
        // #7 Array with Odd Numbers
        public static void Odd_Numbers()
        {
            List<int> odd_List = new List<int>();
            for(int i = 0; i <= 255; i++)
            {
                if(i % 2 != 0)
                {
                    odd_List.Add(i);
                }
            }
            int[] y = odd_List.ToArray();
            Console.Write("[");
            foreach(var odd in odd_List)
            {
                Console.Write(odd.ToString());
                if(odd != 255)
                {
                    Console.Write(", "); // Replaces the Even Number
                }
            }
            Console.Write("]");
        }
        // #8 Greater than Y
        public static void Greater_Than_Y()
        {

        }
        // #9 Square the Values
        public static void Square_Values()
        {

        }
        // #10 Eliminate Negative Numbers
        public static void No_Negatives()
        {

        }
        // #11 Min, Max, and Average
        public static void Find_Min_Max_Avg()
        {

        }
        // #12 Shifting the values in an array
        public static void Shifting_Values()
        {

        }
        // #13 Number to String
        public static void Number_To_String()
        {

        }
        // Calling the Functions
        public static void Main(string[] args)
        {
            int[] the_Array = {1,2,3,14,5,-88};
            Print_1_to_255();
            Print_Odds_1_to_255();
            Print_Sum();
            Iterate_Array();
            Find_Max();
            Get_Average();
            Odd_Numbers();
            Greater_Than_Y();
            Square_Values();
            No_Negatives();
            Find_Min_Max_Avg();
            Shifting_Values();
            Number_To_String();
        }
    }
}
