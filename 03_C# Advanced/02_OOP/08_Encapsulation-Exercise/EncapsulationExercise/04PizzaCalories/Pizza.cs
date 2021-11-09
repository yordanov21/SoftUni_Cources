namespace _04PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }

        public Dough Dough { get; }
        public string Name
        {
            get
            {
                return name;
            }
          private  set
            {
                if (value.Length< 1|| value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                name = value; 
            }
        }

        public int TopingCount
            => this.toppings.Count;

        public double TotalCalories
            => toppings.Sum(x => x.GetTotalCalories()) + Dough.GetTotalCalories();
       
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public int CheckToppingCount()
        {
            if (toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            return TopingCount;
        }
    }
}
