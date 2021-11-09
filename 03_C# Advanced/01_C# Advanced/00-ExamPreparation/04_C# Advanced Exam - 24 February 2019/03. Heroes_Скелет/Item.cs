using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strenght, int ability, int intelligence)
        {
            this.Strenght = strenght;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strenght { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Item:");  
            sb.AppendLine($"  * Strength: {Strenght}");  
            sb.AppendLine($"  * Ability: {Ability}");  
            sb.AppendLine($"  * Intelligence: {Intelligence}");
            return sb.ToString().TrimEnd();
        }
    }
}
