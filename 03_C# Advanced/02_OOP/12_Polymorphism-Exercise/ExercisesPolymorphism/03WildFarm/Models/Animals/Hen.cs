using System;
using System.Collections.Generic;
using System.Text;
using _03WildFarm.Models.Foods;

namespace _03WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeight = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds)
            };
           
        }

        protected override double WeightMultiplier
            => HenWeight;

        protected override ICollection<Type> AllowedFoods { get; }
           

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
