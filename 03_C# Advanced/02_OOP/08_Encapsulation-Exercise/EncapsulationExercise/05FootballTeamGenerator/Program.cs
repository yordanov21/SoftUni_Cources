using System;
using System.Linq;
using System.Collections.Generic;

namespace _05FootballTeamGenerator
{
    public class Program
    {
        static void Main()
        {
            List<Team> teams =new List<Team>();

            while (true)
            {
                string commnad = Console.ReadLine();

                if (commnad == "END")
                {
                    break;
                }

                try
                {
                    string[] commnadInfo = commnad.Split(";").ToArray();

                    string action = commnadInfo[0];
                    string teamName = commnadInfo[1];
                    if (action == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (action == "Add")
                    {

                        string playerName = commnadInfo[2];
                        Player player = new Player(playerName);

                        int endurance = int.Parse(commnadInfo[3]);
                        int sprint = int.Parse(commnadInfo[4]);
                        int dribble = int.Parse(commnadInfo[5]);
                        int passing = int.Parse(commnadInfo[6]);
                        int shooting = int.Parse(commnadInfo[7]);

                        Stat EnduranceStat = new Stat("Endurance", endurance);
                        Stat SprintStat = new Stat("Sprint", sprint);
                        Stat DribbleStat = new Stat("Dribble", dribble);
                        Stat PassingStat = new Stat("Passing", passing);
                        Stat ShootingStat = new Stat("Shooting", shooting);

                        player.AddStats(EnduranceStat);
                        player.AddStats(SprintStat);
                        player.AddStats(DribbleStat);
                        player.AddStats(PassingStat);
                        player.AddStats(ShootingStat);

                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        CheckTeamExist(teamName, team);
                        team.AddPlayer(player);

                    }
                    else if (action == "Remove")
                    {
                        string playerName = commnadInfo[2];
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        CheckTeamExist(teamName, team);
                        Console.WriteLine($"{team.Name} - {team.GetRating()}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                          
            }
            
        }

        private static void CheckTeamExist(string teamName, Team team)
        {
            if (team == null)
            {
                throw new Exception($"Team {teamName} does not exist.");
            }
        }
    }
}
