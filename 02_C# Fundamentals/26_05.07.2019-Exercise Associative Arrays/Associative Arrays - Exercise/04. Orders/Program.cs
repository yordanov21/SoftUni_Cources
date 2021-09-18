using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            //var quantity = new Dictionary<string, double>();
            //var price = new Dictionary<string, double>();
            var orders = new Dictionary<string, Procucts>();
            while (true)
            {
                string order = Console.ReadLine();

                if (order == "buy")
                {
                    break;
                }

                string[] products = order.Split();

                string nameProduct = products[0];
                double pricePerOneProduct = double.Parse(products[1]);
                int quantityOfproduct = int.Parse(products[2]);

                Procucts product = new Procucts(pricePerOneProduct, quantityOfproduct);

                if (!orders.ContainsKey(nameProduct))
                {
                    orders[nameProduct] = product;
                }
                else
                {
                    orders[nameProduct].Price = pricePerOneProduct;
                    orders[nameProduct].Quantity += quantityOfproduct;
                }
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Price * item.Value.Quantity:f2}");
            }
        }
    }
    class Procucts
    {
        public double Price { get; set; }
        public double Quantity { get; set; }

        public Procucts(double price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }
        // public void Rezult()
        //     {
        //     return Price * Quantity; //нещо не ства така
        //     }     
    }

}
