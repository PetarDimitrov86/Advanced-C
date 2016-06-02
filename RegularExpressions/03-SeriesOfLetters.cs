using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class SeriesOfLetters
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        HashSet<char> letters = new HashSet<char>();
        for (int i = 0; i < text.Length; i++)
            letters.Add(text[i]);
        foreach (var item in letters)
        {
            string pattern = item + @"{2,}";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(text, item.ToString());
            text = result;
        }
        Console.WriteLine(text);
    }
}