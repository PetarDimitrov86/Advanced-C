using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class ValidUsernames
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"\b([a-zA-Z]\w{2,24})[\\\/\)\( ]?\b";
        Regex regex = new Regex(pattern);
        int sum = 0;
        int biggestSum = int.MinValue;
        MatchCollection matches = regex.Matches(input);
        List<string> result = new List<string>();
        string pairUsernames = string.Empty;
        foreach (Match item in matches)
        {
            pairUsernames += item.Groups[1] + "(";
        }
        string[] usernames = pairUsernames.Split(new char[] { '\\', '/', '(', ')' });
        for (int i = 0; i < usernames.Length - 1; i++)
        {
            string firstUsername = usernames[i];
            string secondUsername = usernames[i + 1];
            sum = firstUsername.Length + secondUsername.Length;
            if (sum > biggestSum)
            {
                result.Clear();
                result.Add(usernames[i]);
                result.Add(usernames[i+1]);
                biggestSum = sum;
            }
            sum = 0;
        }
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}