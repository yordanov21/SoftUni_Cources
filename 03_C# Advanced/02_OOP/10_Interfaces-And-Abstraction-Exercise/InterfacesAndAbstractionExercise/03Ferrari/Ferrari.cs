using System;
using System.Collections.Generic;
using System.Text;

namespace _03Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string Breakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Breakes()}/{Gas()}/{this.Driver}";
        }
    }
}
