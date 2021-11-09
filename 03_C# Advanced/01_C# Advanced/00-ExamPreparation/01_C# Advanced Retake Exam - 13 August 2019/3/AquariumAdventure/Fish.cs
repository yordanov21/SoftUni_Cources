using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        private string name;
        private string color;
        private int fins;

        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public  int Fins
        {
            get { return fins; }
            set { fins = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fish: {this.name}");
            sb.AppendLine($"Color: {this.color}");
            sb.AppendLine($"Numberof find: {this.fins}");
            return sb.ToString().Trim();
        }
    }
}
