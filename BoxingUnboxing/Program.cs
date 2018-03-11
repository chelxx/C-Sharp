using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            BoxingUnboxingAssignment();
        }
        public static void BoxingUnboxingAssignment()
        {
            // Create an empty List of type object
            List<object> box_list = new List<object>();
            int sum = 0;

            // Add the following values to the list: 7, 28, -1, true, "chair"
            box_list.Add(7);
            box_list.Add(28);
            box_list.Add(-1);
            box_list.Add(true);
            box_list.Add("chair");

            // Loop through the list and print all values (Hint: Type Inference might help here!)
            for (int i = 0; i < box_list.Count; i++)
            {
                Console.WriteLine(box_list[i]);

            // Add all values that are Int type together and output the sum
                if (box_list[i] is int)
                {
                    sum += (int)box_list[i];
                }
            Console.WriteLine(sum);
            }
        } 
    }
}