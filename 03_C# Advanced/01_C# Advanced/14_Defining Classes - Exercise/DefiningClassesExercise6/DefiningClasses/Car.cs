using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
     public class Car
    {
        private string model;
        private double fuelAmount;
        private double travelledDistance;
        private double fuelConsumptionPerKm;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm, double travelledDistanse)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TravelledDistance = travelledDistanse;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            set { fuelConsumptionPerKm = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void CheckCarDistance(double currenttraveledDistance)
        {
            double currentfuelPerDistance = fuelConsumptionPerKm * currenttraveledDistance;
            if (currentfuelPerDistance > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                fuelAmount -= currentfuelPerDistance;
                travelledDistance += currenttraveledDistance;
            }
        }

    }
}
