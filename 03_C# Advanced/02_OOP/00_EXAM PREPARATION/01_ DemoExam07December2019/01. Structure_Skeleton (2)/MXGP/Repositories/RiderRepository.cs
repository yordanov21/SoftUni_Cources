using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public void Add(IRider model)
           => riders.Add(model);

        public IReadOnlyCollection<IRider> GetAll()
         => this.riders.ToList();

        public IRider GetByName(string name)
             => this.riders.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRider model)
          => riders.Remove(model);
    }
}
