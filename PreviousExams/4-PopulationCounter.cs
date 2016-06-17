using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class PopulationCounter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<string, Dictionary<string, long>> mainDictionary = new Dictionary<string, Dictionary<string, long>>();
        while (input != "report")
        {
            string[] stats = input.Split('|');
            string city = stats[0];
            string country = stats[1];
            long population = long.Parse(stats[2]);
            if (!mainDictionary.ContainsKey(country))
            {
                mainDictionary.Add(country, new Dictionary<string, long>());
            }
            mainDictionary[country].Add(city, population);
            input = Console.ReadLine();
        }
        var result = mainDictionary.OrderByDescending(x => x.Value.Values.Sum());
        foreach (var kvp in result)
        {
            Console.WriteLine("{0} (total population: {1})", kvp.Key, kvp.Value.Values.Sum());
            foreach (var innerPair in kvp.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("=>{0}: {1}", innerPair.Key, innerPair.Value);
            }
        }
    }
}