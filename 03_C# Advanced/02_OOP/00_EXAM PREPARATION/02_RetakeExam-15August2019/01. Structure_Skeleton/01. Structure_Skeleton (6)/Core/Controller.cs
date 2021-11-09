using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private int exploaredPlanetCount;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.exploaredPlanetCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                var astronaut = new Biologist(astronautName);
                astronauts.Add(astronaut);
                string result = $"Successfully added {type}: {astronautName}!";
                return result;
            }
            else if (type == "Geodesist")
            {
                var astronaut = new Geodesist(astronautName);
                astronauts.Add(astronaut);
                string result = $"Successfully added {type}: {astronautName}!";
                return result;
            }
            else if (type == "Meteorologist")
            {
                var astronaut = new Meteorologist(astronautName);
                astronauts.Add(astronaut);
                string result = $"Successfully added {type}: {astronautName}!";
                return result;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);
            string result = $"Successfully added Planet: {planetName}!";
            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            var mision = new Mission();
            var planet = planets.FindByName(planetName);
            var astronautSendToSpace = astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (astronautSendToSpace.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mision.Explore(planet, astronautSendToSpace);
            exploaredPlanetCount++;

            string result = $"Planet: {planetName} was explored! Exploration finished with {astronautSendToSpace.Where(a=>a.CanBreath==false).Count()} dead astronauts!";
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"{exploaredPlanetCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astro  in astronauts.Models)
            {
                sb.AppendLine($"Name: { astro.Name}");
                sb.AppendLine($"Oxygen: { astro.Oxygen}");
                sb.AppendLine($"Bag items: {(astro.Bag.Items.Count==0? "none":string.Join(", ",astro.Bag.Items)) }");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,astronautName));
            }

            IAstronaut astroForRemove = this.astronauts.FindByName(astronautName);
            this.astronauts.Remove(astroForRemove);

            string result = $"Astronaut {astronautName} was retired!";
            return result;
        }
    }
}
