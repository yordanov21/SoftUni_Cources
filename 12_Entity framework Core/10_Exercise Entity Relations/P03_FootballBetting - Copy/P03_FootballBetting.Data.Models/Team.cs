﻿namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        //TODO: NAV PROPERTIES
        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorOd { get; set; }

        public int TownId { get; set; }
    }
}
