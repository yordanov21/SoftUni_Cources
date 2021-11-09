
namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Arena
    {
        private string name;
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }
        public void Remove(string name)
        {

            gladiators.Remove(gladiators.Where(x=>x.Name==name).FirstOrDefault()); 
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            gladiators.OrderByDescending(x => x.Stat);
            return gladiators[0];
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            gladiators.OrderByDescending(x => x.Weapon);
            return gladiators[0];
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {

            gladiators.OrderByDescending(x => x.GetTotalPower());
            return gladiators[0];
        }
        public int Count()
        {
            return gladiators.Count();
        }

        public override string ToString()
        {
            StringBuilder sb =new StringBuilder( $"[{Name}] - [{gladiators.Count}] gladiators are participating.");
            return sb.ToString();
        }
    }
}
