using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
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

        //  private readonly IAquarium aquarium;

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
                throw new InvalidOperationException("Invalid aquarium type.");
                //  return ExceptionMessages.InvalidAquariumType;

            }
            if (aquariumType == "FreshwaterAquarium")
            {
                FreshwaterAquarium freshwaterAquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(freshwaterAquarium);
            }
            else
            {
                SaltwaterAquarium freshwaterAquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(freshwaterAquarium);
            }

            return $"Successfully added {aquariumType}.";

        }

        public string AddDecoration(string decorationType)
        {

            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException("Invalid decoration type.");
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

            return $"Successfully added {decorationType}.";

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            //            Functionality
            //Adds the desired Fish to the Aquarium with the given name.
            //Valid Fish types are: "FreshwaterFish", "SaltwaterFish".
            //If the Fish type is invalid, you have to throw an 
            //InvalidOperationException with the following message "Invalid fish type.".
            //If no errors are thrown, return one of the following messages:
            //•	"Water not suitable." - if the Fish cannot live in the Aquarium
            //•	"Successfully added {fishType} to {aquariumName}." - 
            //if the Fish is added successfully in the Aquarium
            var aquaruum = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            if (fishType==" SaltwaterFish")
            {
                return "Water not suitable.";
            }
            //TODO check
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
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException($"There isn’t a decoration of type {decorationType}.");
                //  return $"There isn’t a decoration of type {decorationType}.";

            }
            if (decorationType == "Ornament")
            {
                Ornament ornament = new Ornament();

                aquaruum.Decorations.Add(ornament);
                decorationRepository.Remove(ornament);
            }
            else
            {
                Plant plant = new Plant();
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
