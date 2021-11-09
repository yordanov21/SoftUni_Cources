using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> racers;

        public RaceRepository()
        {
            this.racers = new List<IRace>();
        }
        public void Add(IRace model)
           => racers.Add(model);


        public IReadOnlyCollection<IRace> GetAll()
         => this.racers.ToList();

        public IRace GetByName(string name)
             => this.racers.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRace model)
          => racers.Remove(model);
    }
}
