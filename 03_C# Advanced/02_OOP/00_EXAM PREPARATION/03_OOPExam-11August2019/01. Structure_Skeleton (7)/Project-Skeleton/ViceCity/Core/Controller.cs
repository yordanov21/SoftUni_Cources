using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Repositories.Contracts;
using System.Linq;
using ViceCity.Models.Neghbourhoods;
using System.Collections;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayer);
            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                Gun gun = new Pistol(name);
                guns.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                Gun gun = new Rifle(name);
                guns.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            IPlayer currentPlayer = civilPlayers.FirstOrDefault(x => x.Name == name);
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.guns.FirstOrDefault();
            if (name == "Vercetti")
            {
               
                this.mainPlayer.GunRepository.Add(gun);
                this.guns.Remove(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (civilPlayers!=null)
            {
                currentPlayer.GunRepository.Add(gun);
                this.guns.Remove(gun);

                return $"Successfully added {gun.Name} to the Civil Player: {name}";
            }
            else
            {
                return "Civil player with that name doesn't exists!";              
            }

        }

        public string Fight()
        {
            int mainPlayerLivePoints = this.mainPlayer.LifePoints;
            int totalSumLifePoints = this.civilPlayers.Sum(p => p.LifePoints);

            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            int mainPlayerLivePointsAfterFight = this.mainPlayer.LifePoints;
            int aliveCivilPlayersCount = this.civilPlayers.Where(p => p.IsAlive).Count();
            int totalSumLifePointsAfterFight = this.civilPlayers.Sum(p => p.LifePoints);

            string message = string.Empty;
            if (mainPlayerLivePoints==mainPlayerLivePointsAfterFight              
                && totalSumLifePoints==totalSumLifePointsAfterFight)
            { 
                message= "Everything is okay!";
            }
            else
            {
                message = "A fight happened:" + Environment.NewLine;
                message += $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine;
                message += $"Tommy has killed: {this.civilPlayers.Count-aliveCivilPlayersCount} players!"
                    + Environment.NewLine;
                message += $"Left Civil Players: {aliveCivilPlayersCount}!";
            }     
            
            return message;
        }
    }
}