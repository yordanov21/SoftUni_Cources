using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;             //fields
        private string model;            //fields
        private int year;                //fields
        private double fuelQuantity;     //fields
        private double fuelConsumption;  //fields

        public string Make 
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public void Drive(double distance)
        {
            double expenceFuel =this.FuelConsumption * distance / 100;

            if (expenceFuel >this.FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
               this.FuelQuantity -= distance / 100 * this.FuelConsumption;
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();
        }

    }
}
