using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models
            => astronauts.ToList().AsReadOnly();

        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            //TODO for null
            IAstronaut surchedAstronaut = Models.FirstOrDefault(x => x.Name == name);
            return surchedAstronaut;
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
            //if (astronauts.Contains(model))
            //{
            //    astronauts.Remove(model);
            //    return true;
            //}

            //return false;
        }
    }
    
}
