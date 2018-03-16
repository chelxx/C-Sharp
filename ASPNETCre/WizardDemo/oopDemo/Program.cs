using System;

namespace oopDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard harry = new Wizard("Gryffindor", "Harry", 60);
            Wizard steve = new Wizard("Hufflepuff", "Steve");
            harry.stupefy(harry);

        }
    }
}
