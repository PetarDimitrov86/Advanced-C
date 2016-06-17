using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class TextTransformer
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder fullText = new StringBuilder();
        while (input != "burp")
        {
            fullText.Append(input);
            input = Console.ReadLine();
        }
        string whiteSpacePattern = @"\s+";
        Regex whiteSpaceRegex = new Regex(whiteSpacePattern);
        string resultNoWhiteSpace = whiteSpaceRegex.Replace(fullText.ToString(), " ");
        string patternMessage = @"([$%&'])([^$%&']+)\1";
        Regex extractMessage = new Regex(patternMessage);
        StringBuilder finalAnswer = new StringBuilder();
        MatchCollection matches = extractMessage.Matches(resultNoWhiteSpace);
        foreach (Match match in matches)
        {
           string multiplier = match.Groups[1].Value;
            int points = 0;
            switch (multiplier)
            {
                case "$":
                    points = 1;
                    break;
                case "%":
                    points = 2;
                    break;
                case "&":
                    points = 3;
                    break;
                case "'":
                    points = 4;
                    break;
            }
            string text = match.Groups[2].Value;
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 0)
                    finalAnswer.Append((char) (text[i] + points));
                else
                    finalAnswer.Append((char)(text[i] - points));
            }
            finalAnswer.Append(" ");
        }
        Console.WriteLine(finalAnswer);
    }
}
