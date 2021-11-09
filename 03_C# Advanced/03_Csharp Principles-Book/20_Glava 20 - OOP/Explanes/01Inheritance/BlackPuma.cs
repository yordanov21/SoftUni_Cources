namespace _01Inheritance
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BlackPuma : Puma
    {
        private string color;
        public BlackPuma(bool male, int weight, string color) 
            : base(male, weight )
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
            return $"(BlackPuma, male: {this.Male}, weight: {this.Weight})";
        }
    }
}
