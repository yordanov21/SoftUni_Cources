using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        //    private string type;



        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Fish = new List<IFish>();
            this.Decorations = new List<IDecoration>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);


        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            
            if (Fish.Count == Capacity)
            {
                throw new InvalidOperationException(OutputMessages.NotEnoughCapacity);
            }

            Fish.Add(fish);

        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }

        public void Feed()
        {
            // The Feed() method feeds all fish, calls their Eat() method.
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {

            string message = string.Empty;
            message = $"{this.Name} ({this.GetType().Name})" + Environment.NewLine;
            if (Fish.Count == 0)
            {        
                message += "Fish: none" + Environment.NewLine;
            }
            else
            {
                var fishNames = new List<string>();
                foreach (var fish in this.Fish)
                {
                    string name = fish.Name;
                    fishNames.Add(name);
                }
                message += $"Fish: {string.Join(", ", fishNames)}" + Environment.NewLine;
            }
            message+=$"Decorations: { Decorations.Count}" + Environment.NewLine;
            message += $"Comfort: {Comfort}";

            return message;
        }

    }
}
