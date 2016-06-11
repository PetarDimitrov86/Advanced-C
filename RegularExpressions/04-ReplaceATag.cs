using System;
using System.Text.RegularExpressions;
class ReplaceATag
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"(<ahref="")(\S*)(\"">)(\w*)(<\/a>)";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(input);
        string replacement = @"[URL href=""" + match.Groups[2].Value + "\"]" + match.Groups[4].Value + "[/URL]";
        string result = regex.Replace(input, replacement);
        Console.WriteLine(result);
    }
}