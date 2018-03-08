using System;

namespace vehicles_prac
{
    class Program
    {
        static void Main(string[] args)
        {
            Car oldCar = new Car(167263);
            Console.WriteLine($"Car Condition: {oldCar.Condition}");
            Console.WriteLine($"Max occupancy: {oldCar.numPassengers}");
            oldCar.Move(6);
            Console.WriteLine($"Current Milage: {oldCar.distance} miles");
            Car myCar = new Car();
            Console.WriteLine($"Car Condition: {myCar.Condition}");
            Console.WriteLine("Max occupancy: {0}", myCar.numPassengers);
            myCar.Move(26.6);
            Console.WriteLine("Current Milage: " + myCar.distance + " miles");
        }
    }
}
