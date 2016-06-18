using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ShmoogleCounter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder fullText = new StringBuilder();
        while (input != "//END_OF_CODE")
        {
            fullText.Append(input);
            fullText.Append("\n");
            input = Console.ReadLine();

        }
        string textAsString = fullText.ToString();
        string pattern = @".{1}(int|double)\s+([a-z]+[a-zA-Z0-9]*)";
        Regex regex = new Regex(pattern);
        Dictionary<string, List<string>> occurences = new Dictionary<string, List<string>>();
        MatchCollection matches = regex.Matches(textAsString);
        foreach (Match match in matches)
        {
            string type = match.Groups[1].Value;
            string nameOfVar = match.Groups[2].Value;
            if (!occurences.ContainsKey(type))
            {
                occurences.Add(type, new List<string>());
            }
            occurences[type].Add(nameOfVar);
            occurences[type].Sort();
        }
        try
        {
            Console.WriteLine("Doubles: {0}", string.Join(", ", occurences["double"]));
        }
        catch (Exception)
        {
            Console.WriteLine("Doubles: None");
        }
        try
        {
            Console.WriteLine("Ints: {0}", string.Join(", ", occurences["int"]));
        }
        catch (Exception)
        {
            Console.WriteLine("Ints: None");
        }
    }
}