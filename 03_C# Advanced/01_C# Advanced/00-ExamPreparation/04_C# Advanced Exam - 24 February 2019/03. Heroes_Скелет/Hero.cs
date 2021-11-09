using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hero: {Name} – {Level}lvl");
            sb.AppendLine("Item:");
            sb.AppendLine($"  * Strength: {Item.Strenght}");
            sb.AppendLine($"  * Ability: {Item.Ability}");
            sb.AppendLine($"  * Intelligence: {Item.Intelligence}");

            return sb.ToString().Trim();
        }
    }
}
