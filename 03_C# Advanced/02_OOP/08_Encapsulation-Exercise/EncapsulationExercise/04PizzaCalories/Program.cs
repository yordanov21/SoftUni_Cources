namespace _04PizzaCalories
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            try
            {
                string[] inputPizzaName = Console.ReadLine().Split().ToArray();
                string pizzaName = inputPizzaName[1];

                string[] inputDough = Console.ReadLine().Split().ToArray();
                string type = inputDough[1];
                string bakingTech = inputDough[2];
                double weight = double.Parse(inputDough[3]);

                Dough dough = new Dough(type, bakingTech, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {

                    string toppingInput = Console.ReadLine();

                    if (toppingInput == "END")
                    {
                        break;
                    }

                    string[] toppingInfo = toppingInput.Split();
                    string toppingtType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingtType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                pizza.CheckToppingCount();

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
