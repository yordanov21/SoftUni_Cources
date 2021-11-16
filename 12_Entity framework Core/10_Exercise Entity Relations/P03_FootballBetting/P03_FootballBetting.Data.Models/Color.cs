namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Color
    {
        public Color()
        {
            //inicial the colections in the ctor. 
            //To be optimize they are initializing with Hashset and make virtual!!! For better resurch and fast work with it 
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }
        public int ColorId { get; set; }

        public string Name { get; set; }

        //Color has many PrimaryKitTeams and many SecondaryKitTeams
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }  //set to virtual: to load dinamic 
        public ICollection<Team> SecondaryKitTeams { get; set; }  //set to virtual: to load dinamic 
    }
}
