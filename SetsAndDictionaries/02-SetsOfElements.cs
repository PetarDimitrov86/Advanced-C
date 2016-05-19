using System;
using System.Collections.Generic;
using System.Linq;
class SetsOfElements
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int n = input[0];
        int m = input[1];
        HashSet<int> firstSet = new HashSet<int>();
        HashSet<int> secondSet = new HashSet<int>();
        HashSet<int> result = new HashSet<int>();

        for (int i = 0; i < n; i++)
            firstSet.Add(int.Parse(Console.ReadLine()));
        for (int i = 0; i < m; i++)
            secondSet.Add(int.Parse(Console.ReadLine()));

        foreach (var item in firstSet)
        {
            if (secondSet.Contains(item))
                result.Add(item);
        }
        Console.WriteLine(string.Join(" ", result));
    }
}