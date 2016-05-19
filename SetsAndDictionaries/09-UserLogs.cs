using System;
using System.Collections.Generic;
using System.Linq;
class UserLogs
{
    static void Main(string[] args)
    {
        string command = Console.ReadLine();
        string IP = string.Empty;
        string user = string.Empty;
        SortedDictionary<string, Dictionary<string, int>> occurences = new SortedDictionary<string, Dictionary<string, int>>();
        while (command != "end")
        {
            string[] input = command.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            IP = input[1];
            user = input[input.Length - 1];
            if (!occurences.ContainsKey(user))
                occurences[user] = new Dictionary<string, int>();
            if (!occurences[user].ContainsKey(IP))
                occurences[user].Add(IP, 0);
            occurences[user][IP]++;

            command = Console.ReadLine();
        }
        foreach (var outerPair in occurences)
        {
            List<string> IPOccur = new List<string>();
            Console.WriteLine("{0}:",outerPair.Key);
            foreach (var innerPair in outerPair.Value)
            {
                string result = string.Format("{0} => {1}", innerPair.Key, innerPair.Value);
                IPOccur.Add(result);
            }
            Console.Write(string.Join(", ", IPOccur));
            Console.WriteLine(".");
        }
    }
}