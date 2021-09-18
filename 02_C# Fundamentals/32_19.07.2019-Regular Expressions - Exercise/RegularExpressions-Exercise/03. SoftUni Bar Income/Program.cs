using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\%(?<name>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";
            string command = Console.ReadLine();

            List<Customer> custimerList = new List<Customer>();
            while(command!= "end of shift")
            {
                MatchCollection order = Regex.Matches(command, regex);
                foreach(Match item in order)
                {
                    string customerName = item.Groups["name"].Value;
                    string product = item.Groups["product"].Value;
                    int count = int.Parse(item.Groups["count"].Value);
                    double price =double.Parse( item.Groups["price"].Value);
                    Customer customer = new Customer(customerName, product, count, price);
                    custimerList.Add(customer);
                }
                command = Console.ReadLine();
            }
            double totalIncome = 0;
            foreach(var custom in custimerList)
            {
                string custName = custom.CustomerName;
                string product = custom.Product;
                int count = custom.Count;
                double price = custom.Price;
                double custPrice = count * price;
                totalIncome += custPrice;
                Console.WriteLine($"{custName}: {product} - {custPrice:f2}");
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
    class Customer
    {
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
       
        public Customer(string custmomerName, string product, int count, double price)
        {
            this.CustomerName = custmomerName;
            this.Product = product;
            this.Count = count;
            this.Price = price;
        }
    }
}
