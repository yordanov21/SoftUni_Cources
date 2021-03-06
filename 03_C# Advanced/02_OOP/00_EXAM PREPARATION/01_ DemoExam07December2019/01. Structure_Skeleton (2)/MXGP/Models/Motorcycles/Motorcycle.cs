using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
   
        //pri abstracten clas imame protected constructor
        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }    

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }
        public abstract int HorsePower { get; protected set; } //pravim go protected zada moje naslednicite da go preizpolzvat
        public double CubicCentimeters { get; } //setvame go prez constructora

        public double CalculateRacePoints(int laps)
        {
            double racePoint = this.CubicCentimeters / this.HorsePower * laps;
            return racePoint;
        }
    }
}
