using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes
{
    class HeroRepository
    {
        public int Count => this.heros.Count;  //tova e propurty samo s geter (dulgiq sintaksis vuv videoto ot 22.10.2019)
        private Dictionary<string, Hero> heros;

        public HeroRepository()
        {
            this.heros = new Dictionary<string, Hero>();
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

   
        public void Add(Hero hero)
        {
            this.heros.Add(hero.Name, hero);
        }

        public bool Remove(string name)
        {
         foreach (var hero in this.heros)
         {
             if (hero.Key == name)
             {
                 this.heros.Remove(hero.Key);
                 return true;
             }
         }
         return false;
           
        }

        public Hero GetHeroWithHighestStrength()
        {
            return heros.Values.OrderByDescending(x => x.Item.Strenght).FirstOrDefault();
        }
        public Hero GetHeroWithHighestAbility()
        {
            return heros.Values.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            return heros.Values.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }
        public override string ToString()
        {
          
            StringBuilder sb = new StringBuilder();
            if (heros.Count > 0)//може и без проверката;
            {
                foreach (var hero in heros)
                {
                    sb.AppendLine(hero.Value.ToString());
                }
            }
           
            //Hero: Hero Name - 24lvl
            //Item:
            //*Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48
            //Hero: Second Hero Name - 125lvl
            //Item:
            //    * Strength: 100
            //    * Ability: 20
            //    * Intelligence: 13
            return sb.ToString().Trim();
        }
    }
}
