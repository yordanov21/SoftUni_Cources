using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStation.Models.Planets
{
    class Planet : IPlanet
    {
        private string name;
        private List<string> items;

        public Planet(string name)
        {
            this.Name = name;

            this.items = new List<string>();
        }

        public ICollection<string> Items => items.ToList();
       
        public string Name 
        { get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

    }
}
