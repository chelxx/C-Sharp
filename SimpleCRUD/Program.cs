using System;
using DbConnection;

namespace SimpleCRUD
{
    class Program
    {
        public static void Create() 
        {
            System.Console.WriteLine("Enter Your First Name:");
            string f = Console.ReadLine();
            System.Console.WriteLine("Enter Your Last Name:");
            string l = Console.ReadLine();
            System.Console.WriteLine("Enter Your Nickname:");
            string n = Console.ReadLine();
            System.Console.WriteLine("Enter Your Age:");
            string a = Console.ReadLine();
            System.Console.WriteLine("Enter Your Favorite Number:");
            string fn = Console.ReadLine();
            System.Console.WriteLine("Enter Your Favorite Color:");
            string fc = Console.ReadLine();
            System.Console.WriteLine($"Hello, {f} {l}. Nickname: {n}, Age: {a}, Fave Number: {fn}, Fave Color: {fc}.");

            // MySQL query to INSERT data into my Users table
            string insertquery = $"INSERT INTO Users (FirstName, LastName, Nickname, Age, FavoriteNumber, FavoriteColor) VALUES ({f}, {l}, {n}, {a}, {fn}, {fc})";
            DbConnector.Execute(insertquery);
        }
        static void Main(string[] args)
        {
            Create();
        }
    }
}
