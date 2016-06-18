using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ChampionsLeague
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"([a-zA-Z\s]*)\s+\|\s+([a-zA-Z\s]*)\s+\|\s+(\d+:\d+)\s+\|\s+(\d+:\d+)";
        Dictionary<string, Dictionary<string, int>> pointsList = new Dictionary<string, Dictionary<string, int>>();
        while (input != "stop")
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            string team1 = match.Groups[1].Value;
            string team2 = match.Groups[2].Value;
            string score1 = match.Groups[3].Value;
            string score2 = match.Groups[4].Value;

            string[] score1Split = score1.Split(':');
            string[] score2Split = score2.Split(':');

            int team1Score1Goals = int.Parse(score1Split[0]);
            int team2Score1Goals = int.Parse(score1Split[1]) * 2;

            int team1Score2Goals = int.Parse(score2Split[1])*2;
            int team2Score2Goals = int.Parse(score2Split[0]);

            string winner = string.Empty;
            string loser = string.Empty;
            int team1Goals = team1Score1Goals + team1Score2Goals;
            int team2Goals = team2Score1Goals + team2Score2Goals;
            if (team1Goals > team2Goals)
            {
                winner = team1;
                loser = team2;
            }
            else
            {
                winner = team2;
                loser = team1;
            }
            if (!pointsList.ContainsKey(winner))
            {
                pointsList.Add(winner, new Dictionary<string, int>());
            }
            if (!pointsList[winner].ContainsKey(loser))
            {
                pointsList[winner].Add(loser, 0);
            }
            pointsList[winner][loser]++;
            if (!pointsList.ContainsKey(loser))
            {
                pointsList.Add(loser, new Dictionary<string, int>());
            }
            if (!pointsList[loser].ContainsKey(winner))
            {
                pointsList[loser].Add(winner, 0);
            }
            input = Console.ReadLine();
        }
        foreach (var outerPair in pointsList.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
        {
            Console.WriteLine(outerPair.Key);
            Console.WriteLine("- Wins: {0}", outerPair.Value.Values.Sum());
            Console.Write("- Opponents: ");
            Console.WriteLine(string.Join(", ", outerPair.Value.Keys.OrderBy(x =>x)));
        }
    }
}
