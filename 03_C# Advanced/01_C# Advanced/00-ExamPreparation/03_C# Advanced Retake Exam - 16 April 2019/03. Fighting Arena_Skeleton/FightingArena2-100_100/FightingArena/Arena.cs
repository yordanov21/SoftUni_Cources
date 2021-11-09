
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
        public int Count => this.gladiators.Count();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
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
            Gladiator highestStat = gladiators[0];

            foreach (var glad in gladiators)
            {
                if (glad.GetStatPower() > highestStat.GetStatPower())
                {
                    highestStat = glad;
                }
            }
            return highestStat;
            // gladiators.OrderByDescending(x => x.Stat); не работи така
            // return gladiators[0];
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator highestWeapon = gladiators[0];

            foreach (var glad in gladiators)
            {
                if (glad.GetWeaponPower() > highestWeapon.GetWeaponPower())
                {
                    highestWeapon = glad;
                }
            }
            return highestWeapon;
            // gladiators.OrderByDescending(x => x.Weapon); не работи така
            // return gladiators[0];
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator highestTotal = gladiators[0];

            foreach (var glad in gladiators)
            {
                if (glad.GetTotalPower() > highestTotal.GetTotalPower())
                {
                    highestTotal = glad;
                }
            }
            return highestTotal;
            //  gladiators.OrderByDescending(x => x.GetTotalPower()); не работи така
            //  return gladiators[0];
        }

        public override string ToString()
        {
            StringBuilder sb =new StringBuilder( $"[{Name}] - [{gladiators.Count}] gladiators are participating.");
            return sb.ToString();
        }
    }
}
