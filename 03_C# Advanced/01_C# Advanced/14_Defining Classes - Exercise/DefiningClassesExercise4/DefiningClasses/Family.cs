using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public List<Person> sortPeople()
        {
            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            return people;
        }     
    }
}
