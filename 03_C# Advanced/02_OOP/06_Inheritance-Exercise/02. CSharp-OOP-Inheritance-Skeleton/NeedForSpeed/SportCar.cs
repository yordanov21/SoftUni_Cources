namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const  double DefaultFuelConsumption = 10;

        public SportCar(int hoursePower, double fuel)
            : base(hoursePower, fuel)
        {          
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
