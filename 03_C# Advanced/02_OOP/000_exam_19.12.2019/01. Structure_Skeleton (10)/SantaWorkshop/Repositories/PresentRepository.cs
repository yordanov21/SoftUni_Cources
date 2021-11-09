using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> presents;
        public PresentRepository()
        {
            this.presents = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models => this.presents.AsReadOnly();

        public void Add(IPresent model)
        {
            this.presents.Add(model);
        }

        public IPresent FindByName(string name)
        {
            //TODO Check for NULL
            return this.presents.Find(x => x.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return this.Remove(model);
        }
    }
}
