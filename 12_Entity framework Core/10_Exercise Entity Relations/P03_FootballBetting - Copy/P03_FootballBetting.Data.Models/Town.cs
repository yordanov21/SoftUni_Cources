﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        //TODO: Nav prop

    }
}
