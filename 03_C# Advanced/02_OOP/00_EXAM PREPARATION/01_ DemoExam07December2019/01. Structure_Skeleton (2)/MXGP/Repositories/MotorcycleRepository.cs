using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Repositories.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
           => motorcycles.Add(model);


        public IReadOnlyCollection<IMotorcycle> GetAll()
         => this.motorcycles.ToList();

        public IMotorcycle GetByName(string name)
             => this.motorcycles.FirstOrDefault(x => x.Model == name);

        public bool Remove(IMotorcycle model)
          => motorcycles.Remove(model);

    }
}
