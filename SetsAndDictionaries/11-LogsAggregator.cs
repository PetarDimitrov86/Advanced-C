using System;
using System.Collections.Generic;
using System.Linq;
class LogsAggregator
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        SortedDictionary<string, long> userWithDuration = new SortedDictionary<string, long>();
        Dictionary<string, List<string>> userIPs = new Dictionary<string, List<string>>();
        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split(' ').ToArray();
            string IP = command[0];
            string user = command[1];
            long duration = long.Parse(command[2]);
            if (!userWithDuration.ContainsKey(user))
                userWithDuration.Add(user, 0);
            userWithDuration[user] += duration;
            if (!userIPs.ContainsKey(user))
                userIPs.Add(user, new List<string>());
            if (userIPs[user].Contains(IP))
                continue;
            userIPs[user].Add(IP);
        }
        foreach (var kvp in userWithDuration)
        {
            userIPs[kvp.Key].Sort();
            Console.WriteLine("{0}: {1} [{2}]", kvp.Key, kvp.Value, string.Join(", ", userIPs[kvp.Key]));
        }
    }
}