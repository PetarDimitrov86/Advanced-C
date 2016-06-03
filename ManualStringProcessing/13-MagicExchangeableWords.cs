using System;
using System.Collections.Generic;
using System.Linq;
class MagicExchangeableWords
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ').ToArray();
        string word1 = input[0];
        string word2 = input[1];
        HashSet<char> first = new HashSet<char>();
        HashSet<char> second = new HashSet<char>();
        for (int i = 0; i < word1.Length; i++)
            first.Add(word1[i]);
        for (int i = 0; i < word2.Length; i++)
            second.Add(word2[i]);
        if (first.Count == second.Count)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }
}