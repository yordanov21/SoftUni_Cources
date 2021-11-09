using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ShoppingSpree
{
    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
          
            try
            {
                string[] inputPeople = Console.ReadLine()
               .Split(';', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                for (int i = 0; i < inputPeople.Length; i++)
                {
                    string[] currentPerson = inputPeople[i].Split('=');
                    string name = currentPerson[0];
                    decimal money = decimal.Parse(currentPerson[1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }

                string[] inputProducts = Console.ReadLine()
                   .Split(';', StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                for (int i = 0; i < inputProducts.Length; i++)
                {
                    string[] currentProduct = inputProducts[i].Split('=');
                    string name = currentProduct[0];
                    decimal cost = decimal.Parse(currentProduct[1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] inputInfo = input.Split();

                    string name = inputInfo[0];
                    string productName = inputInfo[1];

                    Person person = people.FirstOrDefault(x => x.Name == name);
                    Product product = products.FirstOrDefault(x => x.Name == productName);
                    person.AddToBag(product);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }       
    }
}
