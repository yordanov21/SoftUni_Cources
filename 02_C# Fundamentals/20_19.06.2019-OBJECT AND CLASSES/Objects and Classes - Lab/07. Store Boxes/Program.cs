using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{
    class Program
    {
        public static decimal PriceOneBox(int a, decimal b)
        {
            return a * b;
        }
        static void Main(string[] args)
        {
            List<Box> boxs = new List<Box>();
            while (true)
            {
                string data = Console.ReadLine();
                if (data == "end")
                {
                    break;
                }

                string[] symbols = data.Split();
                string serialNumber = symbols[0];
                string itemName = symbols[1];
                int itemQuantity = int.Parse(symbols[2]);
                decimal itemPrice = decimal.Parse(symbols[3]);

                Item item = new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    Quantity = itemQuantity,
                    PriceBox = PriceOneBox(itemQuantity, itemPrice)
                };

                boxs.Add(box);
                
            }
            List <Box> orderedBoxs = boxs.OrderByDescending(x => x.PriceBox).ToList();
            foreach (Box curent in orderedBoxs)
            {    
                Console.WriteLine(curent.SerialNumber);
                Console.WriteLine($"-- {curent.Item.Name} - ${curent.Item.Price:f2}: {curent.Quantity}");
                Console.WriteLine($"-- ${curent.PriceBox:f2}");
            }          
        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    } 
}
