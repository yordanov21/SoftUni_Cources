using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double PowerMotocycleCubicCentimeters = 450;
        private const double PowerMotocycleCubicMinHP = 70;
        private const double PowerMotocycleCubicMaxHP = 100;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, PowerMotocycleCubicCentimeters)
        {
        }
      
        public override int HorsePower 
        {
            get => horsePower;
            protected set
            {
                if (value < PowerMotocycleCubicMinHP || value > PowerMotocycleCubicMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }
    }
}
