using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            //inicial the colections in the ctor. 
            //To be optimize they are initializing with Hashset and make virtual!!! For better resurch and fast work with it 
            this.Teams = new HashSet<Team>();
        }
        public int TownId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
        //Town can be placed in one Country 
       public Country Country { get; set; }
        //Town can host several Teams
        public virtual ICollection<Team> Teams { get; set; }
    }
}
