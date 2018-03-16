namespace vehicles_prac
{
    public class Vehicle
    {
        public int numPassengers;
        public double distance;
        private double odo;

        public Vehicle(int val = 0)
        {
            numPassengers = val;
            distance = 0.0;
        }

        // This was added by Intellisense???
        public Vehicle(int val = 0, double odo = 0) : this(val) 
        {
            this.odo = odo;
        }

        public void Move(double miles)
        {
            distance += miles;
        }
    }
}