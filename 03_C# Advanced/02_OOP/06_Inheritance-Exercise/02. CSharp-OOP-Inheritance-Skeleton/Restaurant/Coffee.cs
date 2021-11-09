using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMillimiters = 50;
        private const decimal CoffeePrice = 3.50m;
        public Coffee(string name, double caffeine)
            : base(name, CoffeePrice, CoffeeMillimiters)
        {

            this.Caffeine = caffeine;
        }

        //public override double Milliliters => CoffeeMillimiters;

        //public override decimal Price => CoffeePrice;

        public double Caffeine { get; set; }

    }
}
