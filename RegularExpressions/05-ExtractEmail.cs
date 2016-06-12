using System;
using System.Text.RegularExpressions;
class ExtractEmail
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"(?:^|\s)((?:[a-zA-Z0-9]+[.\-_])*[a-zA-Z0-9]+@(?:[a-zA-Z]+-?)+[a-zA-Z](?:\.[a-zA-Z]+)+)(?:\.\s)?";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);
        foreach (Match match in matches)
            Console.WriteLine(match.Groups[0]);
    }
}