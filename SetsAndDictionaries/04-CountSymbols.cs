using System;
using System.Collections.Generic;
class CountSymbols
{
    static void Main(string[] args)
    {
        SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();
        string input = Console.ReadLine();
        for (int i = 0; i < input.Length; i++)
        {
            if (!occurences.ContainsKey(input[i]))
                occurences[input[i]] = 0;
            occurences[input[i]]++;
        }
        foreach (var kvp in occurences)
            Console.WriteLine("{0}: {1} time/s", kvp.Key, kvp.Value);
    }
}