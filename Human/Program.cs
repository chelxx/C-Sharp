using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default Values
            Human rick = new Human("Rick");
            Human morty = new Human("Morty");
            rick.attack(morty);
            morty.attack(rick);

            // Input Values
            Human beth = new Human("Beth", 10, 50, 75, 250);
            Human summer = new Human("Summer", 100, 100, 100, 1000);
            beth.attack(summer);
            summer.attack(beth);
        }
    }
}