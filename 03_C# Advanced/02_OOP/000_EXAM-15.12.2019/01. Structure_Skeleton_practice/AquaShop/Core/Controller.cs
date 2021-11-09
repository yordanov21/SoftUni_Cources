using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    class Controller : IController
    {
    
        private readonly IRepository<IDecoration> decorationRepository;
        private readonly List<IAquarium> aquariums;

        public Controller()
        {

            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {

            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);           
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                FreshwaterAquarium freshwaterAquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(freshwaterAquarium);
            }
            else
            {
                SaltwaterAquarium saltwaterAquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(saltwaterAquarium);
            }

            return string.Format(OutputMessages.SuccessfullyAdded,aquariumType);

        }

        public string AddDecoration(string decorationType)
        {

            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
                // return "Invalid decoration type.";
            }
            if (decorationType == "Ornament")
            {
                Ornament ornament = new Ornament();
                decorationRepository.Add(ornament);
            }
            else
            {
                Plant plant = new Plant();
                decorationRepository.Add(plant);
            }

            // return $"Successfully added {decorationType}.";
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
      
            var aquaruum = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            if ((fishType=="SaltwaterFish"&&aquaruum.GetType().Name== "FreshwaterAquarium")||
                (fishType == "FreshwaterFish" && aquaruum.GetType().Name == "SaltwaterAquarium"))
            {
                return "Water not suitable.";
            }

            if(fishType == "SaltwaterFish")
            {
                var fish = new SaltwaterFish(fishName, fishSpecies, price);
                this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(fish);

            }
            else if(fishType == "FreshwaterFish")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);
                this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(fish);
            }
           
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
     
            var aquaruum = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var price = aquaruum.Fish.Sum(x => x.Price);
            var price2 = aquaruum.Decorations.Sum(x => x.Price);
            var allprice = price + price2;
            string message = $"The value of Aquarium {aquariumName} is {allprice:f2}.";
            return message;
         
        }

        public string FeedFish(string aquariumName)
        {
         
            var aquaruum = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            foreach (var fish in aquaruum.Fish)
            {
                fish.Eat();
            }
            return $"Fish fed: {aquaruum.Fish.Count}";

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquaruum = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            bool checkDecorationType = decorationRepository.Models.Any(x => x.GetType().Name == decorationType);
            if (!checkDecorationType)
            {
                throw new InvalidOperationException($"There isn’t a decoration of type {decorationType}.");
                //  return $"There isn’t a decoration of type {decorationType}.";

            }
            if (decorationType == "Ornament")
            {
                var ornament = decorationRepository
                    .Models
                    .Where(x => x.GetType().Name == decorationType).FirstOrDefault();
                                
                aquaruum.Decorations.Add(ornament);
                decorationRepository.Remove(ornament);
            }
            else
            {
                var plant = decorationRepository
                   .Models
                   .Where(x => x.GetType().Name == decorationType).FirstOrDefault();

                aquaruum.Decorations.Add(plant);
                decorationRepository.Remove(plant);
            }

            return $"Successfully added {decorationType} to {aquariumName}.";

        }

        public string Report()
        {
         
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums )
            {
              sb.AppendLine (aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
