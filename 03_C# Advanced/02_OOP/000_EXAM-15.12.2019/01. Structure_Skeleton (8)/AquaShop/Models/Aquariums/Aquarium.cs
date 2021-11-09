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
        private int capacity;
        private ICollection<IDecoration> decorationsRepository;
        private ICollection<IFish> fishes;
        private string type;

      

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fishes = new List<IFish>();
            this.decorationsRepository = new List<IDecoration>();
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

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public string Type
        {
            get { return type; }
           private set { type = value; }
        }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);
       

        public ICollection<IDecoration> Decorations => this.decorationsRepository;

        public ICollection<IFish> Fish => fishes;

        public void AddDecoration(IDecoration decoration)
        {
            decorationsRepository.Add(decoration);

        }

        public void AddFish(IFish fish)
        {
            //za controlera eventualno
            if (Fish.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            Fish.Add(fish);

        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }

        public void Feed()
        {
            // The Feed() method feeds all fish, calls their Eat() method.
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {

            string message = string.Empty;
            message = $"{this.Name} {this.Type}" + Environment.NewLine;
            if (fishes.Count == 0)
            {
              
                message += "Fish: none";
            }
            else
            {
                message += $"Fish: {string.Format(", ",fishes)}" + Environment.NewLine;
            }
            message+=$"Decorations: { decorationsRepository.Count}" + Environment.NewLine;
            message += $"Comfort: {Comfort}";

            return message;
        }

    }
}
