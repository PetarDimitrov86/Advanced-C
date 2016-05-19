using System;
using System.Collections.Generic;
class UniqueUsernames
{
    static void Main(string[] args)
    {
        HashSet<string> hash = new HashSet<string>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            hash.Add(input);
        }
        foreach (var item in hash)
        {
            Console.WriteLine(item);
        }
    }
}