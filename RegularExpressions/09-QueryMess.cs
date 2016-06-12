using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class QueryMess
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder fullText = new StringBuilder();
        string pattern = @"([a-zA-Z0-9:\/.\-*,_]*)\+*=((?:%20|\+)*([a-zA-Z0-9:\/.\-*,_]*)(&\1=(%20|\+)([a-zA-Z0-9:\/.\-*,_]*))*)*";
        Regex regex = new Regex(pattern);
        while (input != "END")
        {
            MatchCollection matches = regex.Matches(input);
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (Match match in matches)
            {
                string textToAdd = match.Groups[0].Value.Substring(match.Groups[1].Length);
                textToAdd = textToAdd.Replace("+", " ").Trim();
                textToAdd = textToAdd.Replace("%20", " ").Trim();
                textToAdd = textToAdd.Replace("=", " ").Trim();
                while (textToAdd.Contains("  "))
                {
                    textToAdd = textToAdd.Replace("  ", " ");
                }
                textToAdd = textToAdd.Trim();
                if (!result.ContainsKey(match.Groups[1].Value))
                {
                    result.Add(match.Groups[1].Value, textToAdd.Trim());
                }
                else
                {
                    result[match.Groups[1].Value] += ", " + textToAdd;
                }
            }
            foreach (var kvp in result)
            {
                Console.Write($"{kvp.Key}=[{kvp.Value}]");
            }
            Console.WriteLine();
            input = Console.ReadLine();
        }
    }
}