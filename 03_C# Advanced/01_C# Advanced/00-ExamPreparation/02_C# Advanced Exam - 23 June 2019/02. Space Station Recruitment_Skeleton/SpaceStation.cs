using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {

        private string name;
        private int capacity;

        private List<Astronaut> astronauts;


        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.astronauts = new List<Astronaut>(); //zadavame tuk referenciq imache shte ni gurmi;(no reference exseption)
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count => this.astronauts.Count;  //tova e propurty samo s geter (dulgiq sintaksis vuv videoto ot 22.10.2019)

        public void Add(Astronaut astronaut)
        {

            if (Capacity > 0)
            {
                this.astronauts.Add(astronaut);
                Capacity--;
            }
        }
        public bool Remove(string name)
        {
            foreach (var astronaut in this.astronauts)
            {
                if (astronaut.Name == name)
                {
                    this.astronauts.Remove(astronaut);
                    Capacity++;
                    return true;
                }
            }
            return false;

            // Astronaut CurrentAstronaut = astronauts.FirstOrDefault(x => x.Name == name);
            // if (CurrentAstronaut != null)
            // {
            //     astronauts.Remove(CurrentAstronaut);
            //     Capacity++;
            //     return true;
            // }
            //
            // return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            //и така работи:
            // Astronaut result = new Astronaut(string.Empty, int.MinValue, string.Empty);
            // foreach (var astronaut in this.astronauts)
            // {
            //     if (astronaut.Age > result.Age)
            //     {
            //
            //         result = astronaut;
            //     }
            // }
            // return result;
            return astronauts.OrderByDescending(x => x.Age).FirstOrDefault();

        }

        public Astronaut GetAstronaut(string name)
        {
            //и така работи:
        // Astronaut result = null;
        // foreach (var astronaut in this.astronauts)
        // {
        //     if (astronaut.Name == name)
        //     {
        //
        //         result = astronaut;
        //         break;
        //     }
        // }
        // return result;
            return this.astronauts.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sbilder = new StringBuilder();
            sbilder.AppendLine($"Astronauts working at Space Station {Name}");

            foreach (var astro in astronauts)
            {
                sbilder.AppendLine(astro.ToString());
            }

            return sbilder.ToString().TrimEnd();
        }
    }
}

