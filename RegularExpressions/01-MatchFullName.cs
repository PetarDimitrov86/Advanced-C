using System;
using System.Text.RegularExpressions;
class MatchFullName
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string pattern = @"\b([A-Z][a-z]+ [A-Z][a-z]+)\b";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(text);
        while (text != "end")
        {
            if (regex.IsMatch(text))
                Console.WriteLine(regex.Match(text));
            text = Console.ReadLine();
        }
    }
}