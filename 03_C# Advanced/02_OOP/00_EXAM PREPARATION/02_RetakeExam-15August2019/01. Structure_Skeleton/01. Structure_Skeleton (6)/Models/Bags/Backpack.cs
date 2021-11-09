using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly List<string> items;
        public Backpack()
        {
            this.items = new List<string>();
        }
        public ICollection<string> Items => items.ToList();

        //TODO add method;
    }
}
