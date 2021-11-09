namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;

        public Car(int hoursePower, double fuel)
            : base(hoursePower, fuel)
        {          
        }

        public override double FuelConsumption => DefaultFuelConsumption;

    }
}
