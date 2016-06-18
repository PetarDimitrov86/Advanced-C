using System;
using System.Text;
using System.Text.RegularExpressions;

class BasicMarkupLanguage
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int commandNumber = 0;
        while (input != "<stop/>")
        {
            commandNumber++;
            StringBuilder text = new StringBuilder();
            string pattern = @"\s*<\s*([a-zA-z]*).+=\s*""(.+)""";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            string command = match.Groups[1].Value;
            string message = match.Groups[2].Value;
            switch (command)
            {
                case "inverse":
                    text.Clear();
                    for (int i = 0; i < message.Length; i++)
                    {
                        string charString = message[i].ToString();
                        if (char.IsLower(message[i]))
                        {
                            text.Append(charString.ToUpper());
                        }
                        else if (char.IsUpper(message[i]))
                        {
                            text.Append(charString.ToLower());
                        }
                        else
                        {
                            text.Append(message[i]);
                        }
                    }
                    if (message.Length > 0)
                    {
                        Console.WriteLine("{0}. {1}", commandNumber, text.ToString());
                    }
                    break;
                case "reverse":
                    text.Clear();
                    for (int i = message.Length - 1; i >= 0; i--)
                    {
                        text.Append(message[i]);
                    }
                    if (message.Length > 0)
                    {
                        Console.WriteLine("{0}. {1}", commandNumber, text.ToString());
                    }
                    break;
                case "repeat":
                    string tempPattern = @"value\s*=\s*""\s*([0-9]+)";
                    Regex tempRegex = new Regex(tempPattern);
                    Match tempMatch = tempRegex.Match(input);
                    int repeatTimes = int.Parse(tempMatch.Groups[1].Value);
                    if (message.Length > 0)
                    {
                        for (int i = 0; i < repeatTimes; i++)
                        {
                            Console.WriteLine("{0}. {1}", commandNumber, message);
                            commandNumber++;
                        }
                    }                 
                    commandNumber--;
                    break;
                default:
                    commandNumber--;
                    break;
            }
            input = Console.ReadLine();
        }
    }
}