namespace _05FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Player
    {
        private string name;
        private List<Stat> stats;

        public Player(string name)
        {
            this.Name = name;
            this.stats = new List<Stat>();
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

        public void AddStats(Stat stat)
        {
            stats.Add(stat);
        }

        public int GetSkillLevel()
        {
            return (int)Math.Round(stats.Sum(x => x.Power) /5.0);
        }

    }
}
