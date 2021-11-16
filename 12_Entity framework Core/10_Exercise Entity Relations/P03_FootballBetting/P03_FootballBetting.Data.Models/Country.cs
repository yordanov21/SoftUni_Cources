﻿using System.Collections;
using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public  class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }


        public int CountryId { get; set; }

        public string Name { get; set; }

        //and a Country can have many Towns
        public virtual ICollection<Town> Towns { get; set; }
    }
}
