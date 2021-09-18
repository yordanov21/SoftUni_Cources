using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Teamwork_projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teamList = new List<Team>();
            List<string> membersList = new List<string>();
            for (int i=0; i < teamCount; i++)
            {
                
                string[] teamArr = Console.ReadLine().Split('-');
                string user = teamArr[0];
                string teamName = teamArr[1];
                if (teamList.Select(x => x.TeamName).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else if (teamList.Select(x => x.User).Contains(user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }
                Team team = new Team(user, teamName);
                membersList.Add(user);
                team.Members = membersList;
                teamList.Add(team);

                Console.WriteLine(team);
                
            }

            while (true)
            {
                string commnad = Console.ReadLine();
                if(commnad== "end of assignment")
                {
                    break;
                }

                string[] teamToJoinArr = commnad.Split("->");
                string userToJoin = teamToJoinArr[0];
                string teamToJoin = teamToJoinArr[1];

                if (teamList.Select(x => x.TeamName).Contains(teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }
                else if (teamList.Select(x => x.User).Contains(userToJoin) || teamList.Select(x=>x.Members).Any(y=>y.Contains(userToJoin)) )
                {
                    Console.WriteLine($"Member {userToJoin} cannot join team {teamToJoin}!");
                    continue;
                }

                Team team = new Team(userToJoin, teamToJoin);
                membersList.Add(userToJoin);
                team.Members = membersList;
                teamList.Add(team);

            }

            var teamsToDisband = teamList.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0);
            var fullTeams = teamList.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0);
            foreach(var item in fullTeams)
            {
                Console.WriteLine($"{item.TeamName}");
                Console.WriteLine($"-{item.User}");
                foreach (var member in item.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"--{member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var item in teamsToDisband)
            {
                Console.WriteLine(item.TeamName);
            }


        }
    }

    class Team
    {
        public string User { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public Team(string user,string teamName)
        {
            this.User = user;
            this.TeamName = teamName;
        }

        public override string ToString()
        {
            return $"Team {this.TeamName} has been created by {this.User}!";
        }

    }
}
