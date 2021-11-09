namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption=8;

        public RaceMotorcycle(int hoursePower, double fuel) 
            : base(hoursePower, fuel)
        {        
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
