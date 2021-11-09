namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rabbit
    {
        private string name;
        private string species;
        private bool available=true;

        public Rabbit(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public override string ToString()
        {
            StringBuilder rabbit = new StringBuilder();
            rabbit.Append($"Rabbit ({species}): {name}");
            return rabbit.ToString().TrimEnd();
        }
    }
}
