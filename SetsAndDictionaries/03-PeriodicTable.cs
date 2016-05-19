using System;
using System.Collections.Generic;
class PeriodicTable
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<string> uniqueCompounds = new SortedSet<string>();
        for (int i = 0; i < n; i++)
        {
            string[] compounds = Console.ReadLine().Split(' ');
            for (int j = 0; j < compounds.Length; j++)
                uniqueCompounds.Add(compounds[j]);
        }
        Console.WriteLine(string.Join(" ", uniqueCompounds));
    }
}