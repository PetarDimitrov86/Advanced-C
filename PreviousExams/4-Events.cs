using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Events
{
    static void Main(string[] args)
    {
        int numOfEvents = int.Parse(Console.ReadLine());
        string pattern = @"^#([a-zA-z]+):\s*@([a-zA-z]+)\s*([0-1][0-9]|[2][0-3]):([0-5][0-9])$";
        Dictionary<string, Dictionary<string, List<string>>> events = new Dictionary<string, Dictionary<string, List<string>>>();
        Regex regex = new Regex(pattern);
        for (int i = 0; i < numOfEvents; i++)
        {
            string input = Console.ReadLine();
            Match match = regex.Match(input);
            string name = match.Groups[1].Value;
            string city = match.Groups[2].Value;
            string hour = match.Groups[3].Value;
            string minutes = match.Groups[4].Value;
            if (minutes == "")
            {
                minutes = "00";
            }
            if (!events.ContainsKey(city))
            {
                events.Add(city, new Dictionary<string, List<string>>());
            }
            if (!events[city].ContainsKey(name))
            {
                events[city].Add(name, new List<string>());
            }
            events[city][name].Add(hour + ":" + minutes);
        }
        string[] locations = Console.ReadLine().Split(',');
        foreach (var item in locations.OrderBy(x => x))
        {
            if (events.ContainsKey(item))
            {
                Console.WriteLine("{0}:", item);
                int counter = 1;
                foreach (var innerPair in events[item].OrderBy(x => x.Key))
                {
                    Console.WriteLine("{0}. {1} -> {2}", counter, innerPair.Key, string.Join(", ", innerPair.Value.OrderBy(x => x)));
                    counter++;
                }
            }
        }
    }
}