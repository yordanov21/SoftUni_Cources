using _03WildFarm.Models.Foods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public abstract void ProduceSound();

        protected abstract double WeightMultiplier { get; }

        protected abstract ICollection<Type> AllowedFoods { get; }
        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(typeof(Food)));
            {
                //"{AnimalType} does not eat {FoodType}!"
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
        }
    }
}
