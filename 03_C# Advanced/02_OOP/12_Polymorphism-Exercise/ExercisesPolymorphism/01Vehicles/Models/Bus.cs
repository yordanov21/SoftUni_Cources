using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models
{
    class Bus : Vehicle
    {
        private const double AirConditionConsumation = 1.4;
        private double defautFielConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { 
            this.defautFielConsumption=fuelConsumption;
        }
        public bool IsEmpty { get; set; }

        public override double Drive(double distance)
        {
            if (this.IsEmpty==false)
            {
                base.FuelConsumption =this.FuelConsumption+ AirConditionConsumation;
            }
            else
            {
                base.FuelConsumption =this.defautFielConsumption;
            }
            return base.Drive(distance);
        }
    }
}
