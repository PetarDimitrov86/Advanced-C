using System;
using System.Linq;
class CharacterMultiplier
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ').ToArray();
        string left = input[0];
        string right = input[1];
        long sum = GetCharSum(left, right);
        Console.WriteLine(sum);
    }
    public static long GetCharSum(string left, string right)
    {
        string first = left;
        string second = right;
        if (first.Length < second.Length)
            first = left.PadRight(second.Length, ' ');
        else if (second.Length < first.Length)
            second = right.PadRight(first.Length, ' ');
        long totalSum = 0;
        for (int i = 0; i < first.Length; i++)
        {
            int currentChar1 = first[i];
            int currentChar2 = second[i];
            if (currentChar1 != ' ' && currentChar2 != ' ')
                totalSum += currentChar2 * currentChar1;
            else if (currentChar1 == ' ')
                totalSum += currentChar2;
            else if (currentChar2 == ' ')
                totalSum += currentChar1;
        }
        return totalSum;
    }
}