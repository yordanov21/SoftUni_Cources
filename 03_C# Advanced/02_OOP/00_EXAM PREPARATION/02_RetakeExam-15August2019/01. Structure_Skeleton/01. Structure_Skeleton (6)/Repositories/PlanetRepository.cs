using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models
            => models.ToList().AsReadOnly();

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var surchedAstronaut = Models.FirstOrDefault(x => x.Name == name);
            return surchedAstronaut;
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);

            //if (models.Contains(model))
            //{
            //    models.Remove(model);
            //    return true;
            //}

            //return false;
        }
    }
}
