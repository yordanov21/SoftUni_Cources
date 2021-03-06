using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
          this.Make = "VW";
          this.Model = "Golf";
          this.Year = 2025;
          this.FuelQuantity = 200;
          this.FuelConsumption = 10;
        }
        public Car(
            string make,
            string model,
            int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(
            string make,
            string model,
            int year,
             double fuelQuantity,
            double fuelConsumption
           ) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(
            string make,
            string model,
            int year,
             double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire []tires)
            : this(make, model, year,fuelQuantity,fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine{ get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            double expenceFuel = this.FuelConsumption * distance / 100;

            if (expenceFuel > this.FuelQuantity)
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
