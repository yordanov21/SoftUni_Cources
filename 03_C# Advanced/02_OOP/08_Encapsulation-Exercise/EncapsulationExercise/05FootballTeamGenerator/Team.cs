using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {

            var player = players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            players.Remove(player);
        }

        public int GetRating()
        {
            int rating = 0;
            foreach (var player in players)
            {
                rating += players.Sum(p => p.GetSkillLevel());
            }
            return rating;
        }
    }
}
