using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Repositories.Contracts
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!guns.Contains(model))
            {
                guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            var gun= guns.Find(x=>x.Name==name);
            return gun;
        }

        public bool Remove(IGun model)
        {
           return this.guns.Remove(model);
        }
    }
}
