using System;
using System.Collections.Generic;
using System.Linq;
class PopulationCounter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<string, Dictionary<string, long>> countryStats = new Dictionary<string, Dictionary<string, long>>();
        while (input != "report")
        {
            string[] command = input.Split('|');
            string country = command[1];
            string city = command[0];
            long population = long.Parse(command[2]);

            if (!countryStats.ContainsKey(country))
                countryStats.Add(country, new Dictionary<string, long>());
            countryStats[country].Add(city, population);
            input = Console.ReadLine();
        }
        var resultDict = countryStats.OrderByDescending(x => x.Value.Sum(y => y.Value));
        foreach (var outerPair in resultDict)
        {
            Console.WriteLine("{0} (total population: {1})", outerPair.Key, outerPair.Value.Values.Sum());
            foreach (var countrySt in outerPair.Value.OrderBy(x => -x.Value))
                Console.WriteLine("=>{0}: {1}", countrySt.Key, countrySt.Value);
        }
    }
}