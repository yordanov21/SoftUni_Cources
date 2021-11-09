using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gem
    {
        public Gem(string name)
        {
            this.Name = name;
            this.Quantity = 0;
        }

        public string Name { get; set; }
        public long Quantity { get; set; }

        public long AddGemQuantity(long quantity)
        {
            return this.Quantity += quantity;
        }
    }
}
