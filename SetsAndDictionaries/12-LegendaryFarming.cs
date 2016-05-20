using System;
using System.Collections.Generic;
using System.Linq;
class LegendaryFarming
{
    static void Main(string[] args)
    {
        Dictionary<string, int> resources = new Dictionary<string, int>();
        SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
        resources.Add("shards", 0);
        resources.Add("fragments", 0);
        resources.Add("motes", 0);
        bool notEnoughMaterial = true;
        while (notEnoughMaterial)
        {
            string[] command = Console.ReadLine().ToLower().Split(' ').ToArray();
            for (int i = 0; i < command.Length ; i+=2)
            {
                int quantity = int.Parse(command[i]);
                string material = command[i + 1];
                if (resources.ContainsKey(material))
                {
                    resources[material] += quantity;
                    if (resources[material] >= 250)
                    {
                        resources[material] -= 250;
                        string result = string.Empty;
                        switch (material)
                        {
                            case "shards": result = "Shadowmourne"; break;
                            case "fragments": result = "Valanyr"; break;
                            case "motes": result = "Dragonwrath"; break;
                        }
                        Console.WriteLine("{0} obtained!", result);
                        notEnoughMaterial = false;
                        break;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(material))
                        junk.Add(material, 0);
                    junk[material] += quantity;
                }
            }           
        }
        var finalResources = resources.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
        foreach (var kvp in finalResources)
            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
        foreach (var kvp in junk)
            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
    }
}