using System;

namespace fundamentals_one
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a Loop that prints all values from 1-255
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }

            // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            for (int j = 1; j <= 100; j++)
            {
                if (j % 5 == 0 && j % 3 == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(j);
                }
            }

            // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            for (int k = 1; k <= 100; k++)
            {
                if (k % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                if (k % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if (k % 5 == 0 && k % 3 == 0)
                {
                    Console.WriteLine("FizzBuzz");   
                }
            }

            // (Optional) If you used modulus in the last step, try doing the same without using it. Vice-versa for those who didn't! 
            for (int l = 1; l <= 100; l++)
            {
                
            }

            // (Optional) Generate 10 random values and output the respective word, in relation to step three, for the generated values
            Random rand = new Random();
            for (int m = 1; m <= 100; m++)
            {
                Console.Write(rand.Next(1,10) + " " + rand.Next(1,10) + "\n")
                // HI, ADD MORE
            }
        }
    }
}
