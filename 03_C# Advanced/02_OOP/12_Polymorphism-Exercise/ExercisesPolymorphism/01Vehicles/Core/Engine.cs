using _01Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split()
                .ToArray();

            string[] truckInfo = Console.ReadLine()
               .Split()
               .ToArray();

            string[] busInfo = Console.ReadLine()
              .Split()
              .ToArray();

            double carFuelQunatity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQunatity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQunatity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            var car = new Car(carFuelQunatity, carFuelConsumption, carTankCapacity);
            var truck = new Truck(truckFuelQunatity, truckFuelConsumption, truckTankCapacity);
            var bus = new Bus(busFuelQunatity, busFuelConsumption, busTankCapacity);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] inputInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                    string command = inputInfo[0];
                    string vehicleType = inputInfo[1];
                    double value = double.Parse(inputInfo[2]);

                    if (command == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            DriveVehicle(car, value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            DriveVehicle(truck, value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.IsEmpty =false;
                            DriveVehicle(bus, value);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuele(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuele(value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuele(value);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        if (vehicleType == "Bus")
                        {
                            bus.IsEmpty = true;
                            DriveVehicle(bus, value);
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2):f2}");
            Console.WriteLine($"Bus: {Math.Round(bus.FuelQuantity, 2):f2}");
        }

        static void DriveVehicle(Vehicle vehicle, double value)
        {
            if (value == 0)
            {
                string result = $"{vehicle.GetType().Name} travelled {value} km";

                Console.WriteLine(result);
            }
            else
            {
                double travelledDistance = vehicle.Drive(value);

                string result = travelledDistance == 0
                    ? $"{vehicle.GetType().Name} needs refueling"
                    : $"{vehicle.GetType().Name} travelled {travelledDistance} km";

                Console.WriteLine(result);
            }

        }
    }
}
