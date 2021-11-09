using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> dwarfs;
        public DwarfRepository()
        {
            this.dwarfs = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => this.dwarfs.AsReadOnly();

        public void Add(IDwarf model)
        {
            this.dwarfs.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            //Returns the first dwarf with the given name, if such exists.Otherwise, returns null.

            //TODO Check for NULL
            return this.dwarfs.Find(x => x.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            //Removes a dwarf from the collection. Returns true if the deletion was sucessful,
            //otherwise - false.

            return dwarfs.Remove(model);
        }
    }
}
