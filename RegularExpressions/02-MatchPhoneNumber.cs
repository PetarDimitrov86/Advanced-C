using System;
using System.Text.RegularExpressions;
class MatchPhoneNumber
{
    static void Main(string[] args)
    {
        string number = Console.ReadLine();
        string pattern = @"^\+359( |-)2{1}\1\d{3}\1\d{4}\b";
        Regex regex = new Regex(pattern);
        while (number != "end")
        {
            if (regex.IsMatch(number))
                Console.WriteLine(number);
            number = Console.ReadLine();
        }

    }
}