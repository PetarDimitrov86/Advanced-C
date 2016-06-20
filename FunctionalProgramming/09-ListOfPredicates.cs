using System;
using System.Collections.Generic;
using System.Linq;
class ListOfPredicates
{
    static void Main(string[] args)
    {
        int end = int.Parse(Console.ReadLine());
        int start = 1;
        List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToList();
        List<Predicate<int>> predList = new List<Predicate<int>>();
        foreach (var num in nums)
        {
            predList.Add(x => x % num != 0);
        }
        bool IsValid = true;
        for (int k = start; k <= end; k++)
        {
            IsValid = true;
            for (int j = 0; j < predList.Count; j++)
            {
                if (predList[j](k))
                {
                    IsValid = false;
                    break;
                }
            }
            if (IsValid)
            {
                Console.Write(k + " ");
            }
        }
        Console.WriteLine();
    }
}