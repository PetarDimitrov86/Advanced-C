using System;
using System.Collections.Generic;
class aMinerTask
{
    static void Main(string[] args)
    {
        Dictionary<string, decimal> resources = new Dictionary<string, decimal>();
        string material = Console.ReadLine();
        string quantity = Console.ReadLine();
        while (material != "stop")
        {
            if (!resources.ContainsKey(material))
                resources[material] = 0;
            resources[material] += decimal.Parse(quantity);
            material = Console.ReadLine();
            if (material == "stop")
                break;
            quantity = Console.ReadLine();
        }
        foreach (var kvp in resources)
             Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
    }
}