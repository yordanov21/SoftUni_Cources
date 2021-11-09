using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionConsumation = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditionConsumation;
        }
    }
}
