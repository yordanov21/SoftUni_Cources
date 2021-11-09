namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        private int hoursePower;
        private double fuel;

        public Vehicle(int hoursePower, double fuel)
        {
            this.HoursePower = hoursePower;
            this.Fuel = fuel;
        }

        public int HoursePower
        {
            get { return hoursePower; }
            set { hoursePower = value; }
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public virtual double FuelConsumption 
            => DefaultFuelConsumption;
       
        public virtual void Drive(double kilometers)
        {
            bool canDrive = this.Fuel - kilometers * this.FuelConsumption >= 0;
            if (canDrive)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }         
        }

        public override string ToString()
        {
            return   $"Type: {this.GetType().Name} Fuel: {this.Fuel} FuelConsumption: {this.FuelConsumption}";
        }
    }
}
