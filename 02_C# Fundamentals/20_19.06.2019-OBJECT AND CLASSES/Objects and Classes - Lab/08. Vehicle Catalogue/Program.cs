using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>();
            List<Truck> Trucks = new List<Truck>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] commandArr = command.Split("/");
                if (commandArr[0] == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = commandArr[1],
                        Model = commandArr[2],
                        HorsePower = commandArr[3]
                    };
                    Cars.Add(car);
                }
                else if (commandArr[0] == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = commandArr[1],
                        Model = commandArr[2],
                        Weight = commandArr[3]
                    };
                    Trucks.Add(truck);
                }

            }
            List<Car> OrderedCars = Cars.OrderBy(x => x.Brand).ToList();
            List<Truck> OrderedTrucks = Trucks.OrderBy(x => x.Brand).ToList();
            if (OrderedCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var item in OrderedCars)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }
            if (OrderedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var item in OrderedTrucks)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }
        }
    }
     class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }
    //class Catalog
    //{
    //    public List<Car> OrderedCars { get; set; }
    //    public List<Truck> OrderedTrucks { get; set; }
    //}
}
