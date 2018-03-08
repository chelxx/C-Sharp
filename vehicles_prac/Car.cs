namespace vehicles_prac
{
    public class Car : Vehicle
    {
        public int NumberOfWheels = 4;
        public string Condition;
        public Car() : base(5)
        {
            Condition = "New";
        }
        public Car(double odo) : base(5, odo)
        {
            Condition = "Used";
        }
    }
}