using System;
using System.Linq;
class FormattingNumbers
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        int a = int.Parse(input[0]);
        decimal b = decimal.Parse(input[1]);
        decimal c = decimal.Parse(input[2]);

        string first = string.Format(a.ToString("X").PadRight(10, ' '));
        string firstInBinary = Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10);
        string second = string.Format(b.ToString("F2").PadLeft(10, ' '));
        string third = string.Format(c.ToString("F3").PadRight(10, ' '));
        Console.WriteLine($"|{first}|{firstInBinary}|{second}|{third}|");
    }
}