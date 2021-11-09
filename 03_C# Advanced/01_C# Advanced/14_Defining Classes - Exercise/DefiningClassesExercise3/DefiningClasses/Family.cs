﻿using System;
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
        public Person GetOldestMember() 
        {
          var person=  people.OrderByDescending(a => a.Age).FirstOrDefault();   //може да се напише с "=>"
            return person;
        }
    }
}
