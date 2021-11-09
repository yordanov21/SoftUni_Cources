using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPass = new Dictionary<string, string>();
            var users = new SortedDictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();
            while (line != "end of contests")
            {
                var currentLine = line.Split(":");
                var currentContest = currentLine[0];
                var passContest = currentLine[1];
                contestsAndPass.Add(currentContest, passContest);

                line = Console.ReadLine();
            }

            string input = Console.ReadLine();
            while (input != "end of submissions")
            {
                var submission = input.Split("=>").ToArray();
                var contest = submission[0];
                var password = submission[1];
                var username = submission[2];
                var points = int.Parse(submission[3]);

                if (contestsAndPass.ContainsKey(contest) && contestsAndPass[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                        users[username].Add(contest, points);
                    }
                    else
                    {
                        if (!users[username].ContainsKey(contest))
                        {
                            users[username].Add(contest, points);
                        }
                        else
                        {
                            
                            if (users[username][contest] < points)
                            {
                                users[username].Remove(contest);
                                users[username].Add(contest, points);
                            }

                        }

                    }
                }

                input = Console.ReadLine();
            }

            int bestPoint = 0;
            string bestcandidate = string.Empty;
            foreach (var (user, contest) in users)
            {
                int currentPoint = 0;
                foreach (var point in contest)
                {
                    currentPoint += point.Value;
                }
                if (currentPoint > bestPoint)
                {
                    bestPoint = currentPoint;
                    bestcandidate = user;
                }
            }

            Console.WriteLine($"Best candidate is {bestcandidate} with total {bestPoint} points.");
            Console.WriteLine("Ranking:");

            foreach (var (user, contest) in users)
            {
                Console.WriteLine(user);
                foreach (var point in contest.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {point.Key} -> {point.Value}");
                }
            }
        }
    }
}
