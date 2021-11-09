namespace _04PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechniques;

        public static bool IsValidVFlourType(string type)
        {
            if (flourTypes == null || bakingTechniques == null)
            {
                Initialize();
            }

            return flourTypes.ContainsKey(type.ToLower());
        }

        public static double GetFlourModifier(string type)
            => flourTypes[type.ToLower()];

        public static double GetBakingTechiquesModifier(string type)
            => bakingTechniques[type.ToLower()];

        public static bool IsValidBakingTechniques(string technique)
        {
            if (flourTypes == null || bakingTechniques == null)
            {
                Initialize();
            }

            return bakingTechniques.ContainsKey(technique.ToLower());
        }

        private static void Initialize()
        {
            flourTypes = new Dictionary<string, double>();
            bakingTechniques = new Dictionary<string, double>();

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1);

            bakingTechniques.Add("crispy", 0.9);
            bakingTechniques.Add("chewy", 1.1);
            bakingTechniques.Add("homemade", 1.0);
        }
    }
}
