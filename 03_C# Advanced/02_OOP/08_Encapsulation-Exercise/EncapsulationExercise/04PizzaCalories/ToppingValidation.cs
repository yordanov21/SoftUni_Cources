namespace _04PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ToppingValidation
    {
        private static Dictionary<string, double> toppingtypes;

        public static bool IsValidToppingType(string type)
        {
            if (toppingtypes == null)
            {
                Initialize();
            }

            return toppingtypes.ContainsKey(type.ToLower());
        }

        public static double GetModifier(string type)
           => toppingtypes[type.ToLower()];

        private static void Initialize()
        {
            toppingtypes = new Dictionary<string, double>
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };
        }
    }
}
