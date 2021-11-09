namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Product //it's better to be abstract class
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
