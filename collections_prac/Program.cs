using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays
            // Create an array to hold integer values 0 through 9
            int[] numberArray = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numberArray[i] = i;
                Console.WriteLine(value: i);
            }
            

            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] nameArray = new string[4];
            nameArray[0] = "Tim";
            nameArray[1] = "Martin";
            nameArray[2] = "Nikki";
            nameArray[3] = "Sara";
            foreach (string name in nameArray){
                Console.WriteLine(name);
            }


            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] booleanArray = new bool[10];
            for (int j = 0; j < 10; j++){
                if (j % 2 == 0)
                {
                    booleanArray[j] = true;
                }
                else
                {
                    booleanArray[j] = false;
                }
            }
            foreach (bool array in booleanArray){
                    Console.WriteLine(array);
            }


            // Multiplication Table
            // With the values 1-10, use code to generate a multiplication table like the one below.
            // ADD ANSWERS HERE!


            // List of Flavors
            // Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Strawberry");
            flavors.Add("Blueberry");
            flavors.Add("Caramel"); 

            // Output the length of this list after building it
            Console.WriteLine(flavors.Count);

            // Output the third flavor in the list, then remove this value.
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);

            // Output the new length of the list (Note it should just be one less~)
            Console.WriteLine(flavors.Count);


            // User Info Dictionary
            // Create a Dictionary that will store both string keys as well as string values
            Dictionary<string,string> profile = new Dictionary<string,string>();

            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            foreach (string name in nameArray)
            {
                profile.Add(name, null);
            }

            // For each name key, select a random flavor from the flavor list above and store it as the value
            Random rand = new Random();
            List<string> keys = new List<string>(profile.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                profile[keys[i]] = flavors[rand.Next(0,4)];
            }

            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach (var dude in profile)
            {
                Console.WriteLine(dude.Key + " - " + dude.Value);
            }
        }
    }
}