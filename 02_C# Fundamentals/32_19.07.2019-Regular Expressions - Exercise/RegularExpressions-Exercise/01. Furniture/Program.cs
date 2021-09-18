using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitureName = new List<string>();
            List<double> furniturePrice = new List<double>();
            List<double> furnitureQuantity = new List<double>();

            string command = Console.ReadLine();
            while (command != "Purchase")
            {
                string regex = @"\>>(?<name>[A-Z]*[a-z]*)\<<(?<price>[0-9.]+)!(?<quantity>\d+)\b";

                MatchCollection furnitures = Regex.Matches(command, regex);


                foreach (Match furniture in furnitures)
                {
                    var furnitureCurentName = furniture.Groups["name"].Value;
                    var furnitureCurentPrice = double.Parse(furniture.Groups["price"].Value);
                    var furnitureCurentQuantity = double.Parse(furniture.Groups["quantity"].Value);

                    furnitureName.Add(furnitureCurentName);
                    furniturePrice.Add(furnitureCurentPrice);
                    furnitureQuantity.Add(furnitureCurentQuantity);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var furniture in furnitureName)
            {
                Console.WriteLine(furniture);
            }
            double totalPrice = 0;
            for (int i = 0; i < furniturePrice.Count; i++)
            {
                totalPrice += furniturePrice[i] * furnitureQuantity[i];
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
