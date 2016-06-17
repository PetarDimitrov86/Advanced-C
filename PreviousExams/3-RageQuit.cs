using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"(\D+)(\d+)";
        Regex regex = new Regex(pattern);
        StringBuilder result = new StringBuilder();
        HashSet<char> unique = new HashSet<char>();
        MatchCollection matches = regex.Matches(input);
        foreach (Match match in matches)
        {
            string textToFlood = match.Groups[1].Value.ToUpper();
            int repeatTimes = int.Parse(match.Groups[2].Value);
            if (repeatTimes > 0)
            {
                for (int i = 0; i < textToFlood.Length; i++)
                {
                    unique.Add(textToFlood[i]);
                }
            }
            for (int i = 0; i < repeatTimes; i++)
                result.Append(textToFlood);
        }
        Console.WriteLine("Unique symbols used: {0}", unique.Count);
        Console.WriteLine(result);
    }
}