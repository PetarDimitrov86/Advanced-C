using System;
using System.Collections.Generic;
using System.Linq;
class Palindromes
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new[] { ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        SortedSet<string> result = new SortedSet<string>();
        foreach (var item in input)
        {
            if (IsSymetrical(item))
                result.Add(item);
        }
        Console.WriteLine("[{0}]", string.Join(", ", result));
    }
    public static bool IsSymetrical(string input)
    {
        string leftPart = string.Empty;
        string rightPart = string.Empty;
        for (int i = 0; i < input.Length / 2; i++)
            leftPart += input[i];
        for (int i = input.Length - 1; i >= (input.Length + 1) / 2; i--)
            rightPart += input[i];
        if (leftPart == rightPart)
            return true;
        return false;
    }
}