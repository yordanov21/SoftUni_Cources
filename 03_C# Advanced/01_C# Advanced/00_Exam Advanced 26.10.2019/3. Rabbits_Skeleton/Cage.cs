namespace Rabbits
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Cage
    {
        private HashSet<Rabbit> rabbits;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.rabbits.Count;
        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            this.rabbits = new HashSet<Rabbit>();
        }

        public void Add(Rabbit rabbit)
        {
            if (Capacity > 0)
            {
                bool existRabbit = false;
                foreach (var currenrabit in rabbits)
                {
                    if (currenrabit.Name == rabbit.Name)
                    {
                        existRabbit = true;
                    }

                }
                if (existRabbit == false)//proverka dali syshtestvuva
                {
                    this.rabbits.Add(rabbit);
                    Capacity--;
                }            
            }
        }
        public bool RemoveRabbit(string name)
        {
            foreach (var rabbit in this.rabbits)
            {
                if (rabbit.Name == name)
                {
                    this.rabbits.Remove(rabbit);
                    Capacity++;
                    return true;
                }
            }

            return false;
        }
        public void RemoveSpecies(string species)
        {
            foreach (var rabit in rabbits)
            {
                if (rabit.Species == species)
                {
                    rabbits.Remove(rabit);
                    Capacity++;
                }
            }
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit seledRabit = rabbits.Where(x => x.Name == name).FirstOrDefault();
            foreach (var rabit in rabbits)
            {
                if (rabit.Name == name)
                {

                    rabit.Available = false;
                    seledRabit = rabit;
                }

            }

            return seledRabit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var listRabit = new List<Rabbit>();
            foreach (var rabit in rabbits)
            {
                if (rabit.Species == species)
                {
                    rabit.Available = false;
                    listRabit.Add(rabit);
                }
            }

            var resultRabit = listRabit.ToArray();
            return resultRabit;
        }
        public string Report()
        {
            StringBuilder sbilder = new StringBuilder();
            sbilder.AppendLine($"Rabbits available at {Name}:");
            rabbits = rabbits.Where(x => x.Available == true).ToHashSet();

            foreach (var rabit in rabbits)
            {
                sbilder.AppendLine(rabit.ToString());
            }

            return sbilder.ToString().TrimEnd();
        }
    }
}
