using System;
using System.Linq;
class LettersChangeNumbers
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        decimal totalSum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string command = input[i];
            char firstChar = command[0];
            char lastChar = command[command.Length - 1];
            decimal number = decimal.Parse(command.Substring(1, command.Length - 2));

            if (char.IsUpper(firstChar))
                totalSum += number / ((int)firstChar - 64);
            else if (char.IsLower(firstChar))
                totalSum += number * ((int)firstChar - 96);

            if (char.IsUpper(lastChar))
                totalSum -= (int)lastChar - 64;
            else if (char.IsLower(lastChar))
                totalSum += (int)lastChar - 96;
        }
        Console.WriteLine("{0:f2}", totalSum);
    }
}