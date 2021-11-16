using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {

        public Team()
        {
            //inicial the colections in the ctor. 
            //To be optimize they are initializing with Hashset and make virtual!!! For better resurch and fast work with it 
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        //Team has one PrimaryKitColor and one SecondaryKitColor
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorOd { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }

        //Team residents in one Town
        public Town Town { get; set; }

        //Team can have many HomeGames and many AwayGames (from the inverce properties)
        public virtual ICollection<Game> HomeGames { get; set; }
        public virtual ICollection<Game> AwayGames { get; set; }

    }
}
