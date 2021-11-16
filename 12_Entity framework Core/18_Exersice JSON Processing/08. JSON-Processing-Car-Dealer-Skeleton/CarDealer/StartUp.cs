using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string DirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            //first reset DB
            //Resetdatabase(db);


            //DESTERALIZARION-**************************************************************************************************

            ////09. Import Suppliers
            //string inputJson09 = File.ReadAllText("../../../Datasets/suppliers.json");
            //string result09 = ImportSuppliers(db, inputJson09);
            //Console.WriteLine(result09);

            ////10.Import Parts
            //string inputJson10 = File.ReadAllText("../../../Datasets/parts.json");
            //string result10 = ImportParts(db, inputJson10);
            //Console.WriteLine(result10);


            ////11. Import Cars
            //string importJson11 = File.ReadAllText("../../../Datasets/cars.json");
            //string result11 = ImportCars(db, importJson11);
            //Console.WriteLine(result11);

            //////12. Import Customers
            //string importJson12 = File.ReadAllText("../../../Datasets/customers.json");
            //string result12 = ImportCustomers(db, importJson12);
            //Console.WriteLine(result12);

            ////13. Import Sales
            //string importJson13 = File.ReadAllText("../../../Datasets/sales.json");
            //string result13 = ImportSales(db, importJson13);
            //Console.WriteLine(result13);




            //14. Export Ordered Customers
            string json14 =GetOrderedCustomers(db);
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/ordered-customers.json", json14);
            Console.WriteLine(json14);


            //EXERCISE 15 - Export Cars from Make Toyota
            Console.WriteLine(GetCarsFromMakeToyota(db));

            //EXERCISE 16 -  Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(db));

            //EXERCISE 17 - Export Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(db));

            //EXERCISE 18 - Export Total Sales by Customer
            Console.WriteLine(GetTotalSalesByCustomer(db));

            //EXERCISE 19 - Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        private static void Resetdatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was succsessfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was succsessfully crerated!");
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            //with ARRAY
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            //add suppliers colection to the context
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}."; ;
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierCount = context.Suppliers.Count();
            //with LIST
            IEnumerable<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => p.SupplierId <= supplierCount);

            //add parts colection to the context
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";

        }

        //11. Import Cars   50/100 must be with DTO
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {

                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,

                };
                cars.Add(newCar);

                foreach (var carPartId in carDto.PartsId.Distinct())
                {
                    var newCarPart = new PartCar()
                    {
                        PartId = carPartId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }

            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported { cars.Count()}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        // Get all customers ordered by their birth date ascending.
        //If two customers are born on the same date first print those who
        //are not young drivers(e.g.print experienced drivers first).
        //Export the list of customers to JSON in the format provided below.

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver

                })
                .ToList();
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;

        }

        //EXERCISE 15 - Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Where(x => x.Make.ToLower() == "toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                }).ToList();
            var toyotaCarsJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return toyotaCarsJson;
        }

        //EXERCISE 16 -  Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                }).ToList();

            var suppliersJsonResult = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return suppliersJsonResult;
        }

        //EXERCISE 17 - Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var targetCars = context.Cars
                .Select(c => new
                {
                    car = new { c.Make, c.Model, c.TravelledDistance },
                    parts = c.PartCars.Select(x => new { Name = x.Part.Name, Price = x.Part.Price.ToString("F") }).ToList()
                }).ToList();
            var resultJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return resultJson;
        }

        //EXERCISE 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var targetCars = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = $"{x.Name}",
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();
            var resultJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return resultJson;
        }

        //EXERCISE 19 - Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var targetCars = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new { x.Car.Make, x.Car.Model, x.Car.TravelledDistance },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(s => s.Part.Price).ToString("F"),
                    priceWithDiscount = (x.Car.PartCars.Sum(s => s.Part.Price) * (1M - x.Discount / 100M)).ToString("F")
                }).ToList();

            var resultJson = JsonConvert.SerializeObject(targetCars, Formatting.Indented);
            return resultJson;
        }
    }
}