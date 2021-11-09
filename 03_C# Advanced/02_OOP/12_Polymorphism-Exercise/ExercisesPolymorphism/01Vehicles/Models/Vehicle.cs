using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set 
            {
                if (value >this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }              
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
             set { fuelConsumption = value; }
        }


        public double TankCapacity
        {
            get { return tankCapacity; }
          private set { tankCapacity = value; }
        }


        public virtual double Drive(double distance)
        {
            bool cadDrave = this.FuelQuantity - this.FuelConsumption * distance >= 0;
            if (cadDrave)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return distance;
            }
       
            return 0;
        }
        public virtual void Refuele(double fuel)
        {
            if(this.FuelQuantity + fuel > this.tankCapacity)
            {
              throw new InvalidOperationException ($"Cannot fit {fuel} fuel in the tank"); 
            }
            else if (fuel <= 0)
            {
                throw new InvalidOperationException ("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += fuel;
            }
                       
        }
    }
}
