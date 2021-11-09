using MXGP.Core.Contracts;
using MXGP.Models.Riders;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        public ChampionshipController()
        {
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            throw new NotImplementedException();
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            throw new NotImplementedException();
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            throw new NotImplementedException();
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string CreateRider(string riderName)
        {
            Rider rider = new Rider(riderName);
            return "d";
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
