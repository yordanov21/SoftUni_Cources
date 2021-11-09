using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionConsumation = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
            this.FuelConsumption += AirConditionConsumation;
        }

        public override void Refuele(double fuel)
        {
            if (fuel > this.TankCapacity - this.FuelQuantity)
            {
                base.Refuele(fuel);
            }
            else
            {
                fuel *= 0.95;
                base.Refuele(fuel);
            }          
        }
    }
}
