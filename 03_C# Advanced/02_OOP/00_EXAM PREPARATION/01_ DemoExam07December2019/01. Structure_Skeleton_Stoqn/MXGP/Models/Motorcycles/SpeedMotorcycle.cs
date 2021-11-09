using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle, IMotorcycle
    {
        private const double SpeedMotocycleCubicCentimeters = 125;
        private const double SpeedMotocycleCubicMinHP = 50;
        private const double SpeedMotocycleCubicMaxHP = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, SpeedMotocycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < SpeedMotocycleCubicMinHP || value > SpeedMotocycleCubicMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }
    }
}
