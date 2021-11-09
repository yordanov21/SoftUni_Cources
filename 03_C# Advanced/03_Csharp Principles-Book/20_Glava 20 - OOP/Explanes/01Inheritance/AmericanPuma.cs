using System;
using System.Collections.Generic;
using System.Text;

namespace _01Inheritance
{
    public class AmericanPuma : Puma
    {
        private string color;
        public AmericanPuma(bool male, int weight, string color) : base(male, weight)
        {
            this.color = color;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }

        public override string ToString()
        {
            return $"AmericanPuma, male: {this.Male}, weight: {this.Weight})";
        }
    }
}
