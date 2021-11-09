using _03WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type, params string[] foodArgs)
        {
            string foodType = type.ToLower();
            int quantity =int.Parse( foodArgs[0]);
            switch (foodType)
            {
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeeds":
                    return new Seeds(quantity);
                case "vegetable":
                    return new Vegetable(quantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
