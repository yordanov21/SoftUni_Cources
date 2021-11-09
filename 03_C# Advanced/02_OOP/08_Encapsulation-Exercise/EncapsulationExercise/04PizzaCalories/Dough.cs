namespace _04PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dough
    {   
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechType, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!DoughValidator.IsValidVFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (!DoughValidator.IsValidBakingTechniques(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }


        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return this.Weight * 2
                * DoughValidator.GetFlourModifier(this.FlourType) 
                * DoughValidator.GetBakingTechiquesModifier(this.BakingTechnique);
        }

    }
}
